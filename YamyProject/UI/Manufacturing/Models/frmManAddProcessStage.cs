using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;
using YamyProject.RMS.Class;

namespace YamyProject.UI.Manufacturing.Models
{
    public partial class frmManAddProcessStage : Form
    {
        public int id = 0;

        public frmManAddProcessStage(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void frmManAddProcessStage_Load(object sender, EventArgs e)
        {
            BindCombos.LoadProcessStageManufacture(CBStages);
            if (id != 0)
            {
                guna2Button4.Visible = false;
                btnUpdateStage.Visible = true;
                btnDeleteStage.Visible = true;
                loadData();
            }
            else
            {
                guna2Button4.Visible = true;
                btnUpdateStage.Visible = false;
                btnDeleteStage.Visible = false;
                CBStages.SelectedIndex = -1;
            }
            GenerateNextCode();
        }

        private void loadData()
        {
            if (CBStages.Items.Count > 0)
            {
                if (id > 0)
                {
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_Manufacturing_Steps where id = @id", DBClass.CreateParameter("id", id)))
                    {
                        if (reader.Read())
                        {
                            CBStages.SelectedValue = reader["id"];
                            txtDescription.Text = reader["description"].ToString();
                        }
                    }
                }
            }
        }

        public string GenerateNextCode()
        {
            int code;
            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(code AS UNSIGNED)) AS lastCode FROM tbl_Manufacturing_Steps"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                    code = int.Parse(reader["lastCode"].ToString()) + 1;
                else
                    code = 10001;
            }
            return code.ToString("D5");
        }
        private void CBDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (id != 0)
            {
                guna2Button4.Visible = false;
                btnUpdateStage.Visible = true;
                btnDeleteStage.Visible = true;
            }
            else
            {
                guna2Button4.Visible = true;
                btnUpdateStage.Visible = false;
                btnDeleteStage.Visible = false;
            }
        }

        private void CBDepartment_TextChanged(object sender, EventArgs e)
        {
            if (id != 0)
            {
                guna2Button4.Visible = false;
                btnUpdateStage.Visible = true;
                btnDeleteStage.Visible = true;
            }
            else
            {
                guna2Button4.Visible = true;
                btnUpdateStage.Visible = false;
                btnDeleteStage.Visible = false;
            }
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(CBStages.SelectedValue);
            DialogResult result = MessageBox.Show("Are you Sure want to Delete This Stage", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool isUsed = false;
                if (isUsed)
                {
                    MessageBox.Show("Can't Delete This Stage Used");
                    return;
                }
                else
                {
                    string qry1 = "Delete from tbl_Manufacturing_Steps where id= " + id + "";
                    Hashtable ht = new Hashtable();
                    RMSClass.SQl(qry1, ht);
                    Utilities.LogAudit(frmLogin.userId, "Delete Stage", "Stage", id, "Deleted Stage: " + CBStages.Text);
                    MessageBox.Show("Delete Successfully");
                    CBStages.ResetText();
                    BindCombos.LoadProcessStageManufacture(CBStages);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Can't Saved Position Empty ");
                return;
            }
            if (CBStages.Text == "")
            {
                MessageBox.Show("Please Select Stage ");
                return;
            }

            if (id == 0)
            {
                SaveData();
                BindCombos.LoadProcessStageManufacture(CBStages);
            }
            else
            {
                UpdateData();
                BindCombos.LoadProcessStageManufacture(CBStages);
            }
        }

        private void UpdateData()
        {
            string query = @"update tbl_Manufacturing_Steps set code = @code,step_name = @name,description = @description,step_order=@step_order,is_completed=@is_completed,created_by = @user_id where id =@id";
            DBClass.ExecuteNonQuery(
                query,
                DBClass.CreateParameter("code", GenerateNextCode()),
                DBClass.CreateParameter("name", CBStages.Text),
                DBClass.CreateParameter("description", txtDescription.Text),
                DBClass.CreateParameter("step_order", 0),
                DBClass.CreateParameter("is_completed", 0),
                DBClass.CreateParameter("user_id", frmLogin.userId),
                DBClass.CreateParameter("id", id)
            );
            Utilities.LogAudit(frmLogin.userId, "Update process stage", "MFR Stage", id, "Updated stage: " + CBStages.Text + txtDescription.Text);
            clearText();
            MessageBox.Show("Update Successfully...");
        }

        private void SaveData()
        {
            /* 
             * tbl_Manufacturing_Steps (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(20) NOT NULL,
                            step_name VARCHAR(100) NOT NULL,
                            description VARCHAR(500),
                            step_order INT NOT NULL,
                            is_completed TINYINT(1) DEFAULT 0,
                            created_by INT,
             *
             */
            string query = @"INSERT INTO tbl_Manufacturing_Steps (code,step_name,description,step_order,is_completed,created_by) VALUES (@code,@name,@description,@step_order,@is_completed,@user_id); SELECT LAST_INSERT_ID();";
            int refId = int.Parse(DBClass.ExecuteScalar(query,
                DBClass.CreateParameter("code", GenerateNextCode()),
                DBClass.CreateParameter("name", CBStages.Text),
                DBClass.CreateParameter("description", txtDescription.Text),
                DBClass.CreateParameter("step_order", 0),
                DBClass.CreateParameter("is_completed", 0),
                DBClass.CreateParameter("user_id", frmLogin.userId)
            ).ToString());

            Utilities.LogAudit(refId, "Add process stage", "MFR Stage", refId, "Added stage: " + CBStages.Text + txtDescription.Text);
            clearText();
            MessageBox.Show("save Successfully...");
        }

        private void clearText()
        {
            id = 0;
            CBStages.Text = "";
            txtDescription.Text = "";
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateStage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Can't Saved Position Empty ");
                return;
            }
            if (CBStages.Text == "")
            {
                MessageBox.Show("Please Select Stage ");
                return;
            }

            if (id == 0)
            {
                SaveData();
            }
            else
            {
                UpdateData();
            }
        }
    }
}