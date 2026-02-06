using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.ProjectManagement
{
    public partial class ProjectForm : Form
    {
        private int id;
        string txtCode = "";
        public ProjectForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("enter project name");
                return;
            }
            if (string.IsNullOrEmpty(txtBudget.Text))
            {
                MessageBox.Show("enter project budget");
                return;
            }
            if (string.IsNullOrEmpty(txtActualCost.Text))
            {
                MessageBox.Show("enter project actual cost");
                return;
            }

            MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_projects where name = @name",
            DBClass.CreateParameter("name", txtName.Text));
            if (reader.Read())
            {
                if (id == 0 || (id != int.Parse(reader["id"].ToString())))
                {
                    MessageBox.Show(" Name Already In Use. Enter Another Name.");
                    return;
                }
            }


            if (id == 0)
            {
                int projectId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                                                    INSERT INTO tbl_projects (code, name, category, description, start_date, end_date, country_id, city_id) 
                                                    VALUES (@code, @name, @category, @description, @start_date, @end_date, @country_id, @city_id);
                                                    SELECT LAST_INSERT_ID();",
                                                    DBClass.CreateParameter("@code", txtCode),
                                                    DBClass.CreateParameter("@name", txtName.Text),
                                                    DBClass.CreateParameter("@category", txtBudget.Text),
                                                    DBClass.CreateParameter("@description", txtActualCost.Text),
                                                    DBClass.CreateParameter("@start_date", dtStart.Value.Date),
                                                    DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
                                                    DBClass.CreateParameter("@country_id", 0),
                                                    DBClass.CreateParameter("@city_id", 0)
                                                ));

                Utilities.LogAudit(frmLogin.userId, "Add Eng Project", "Eng Project", projectId,
                    "Added New Eng Project: " + txtName.Text + " (Code: " + txtCode + ")");

                MessageBox.Show("Saved", "Successful");
            }
            else
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_projects
                    SET code = @code, name = @name, category = @category, description = @description, 
                        start_date = @start_date, end_date = @end_date, country_id  = @country_id, city_id = @city_id, status = @status
                    WHERE id = @id;",
                    DBClass.CreateParameter("@code", txtCode),
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@category", txtBudget.Text),
                    DBClass.CreateParameter("@description", txtActualCost.Text),
                    DBClass.CreateParameter("@start_date", dtStart.Value.Date),
                    DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
                    DBClass.CreateParameter("@country_id", 0),
                    DBClass.CreateParameter("@city_id", 0),
                    DBClass.CreateParameter("@status", "Pending"),
                    DBClass.CreateParameter("@id", id)
                );


                Utilities.LogAudit(frmLogin.userId, "Update Eng Project", "Eng Project", id,
                    "Updated Eng Project: " + txtName.Text);

                MessageBox.Show("Edited", "Successful");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            if (id != 0)
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_projects where id = @id",
                      DBClass.CreateParameter("id", id)))
                    if (reader.Read())
                    {
                        txtName.Text = reader["name"].ToString();
                        txtCode = reader["code"].ToString();
                        txtBudget.Text = reader["category"].ToString();
                        txtActualCost.Text = reader["description"].ToString();
                        dtStart.Value = reader["start_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["start_date"]);
                        dtEnd.Value = reader["end_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["end_date"]);
                    }
            }
            else
            {
                object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(code AS UNSIGNED)), 4, '0') FROM tbl_projects;");
                int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
                string formattedId = nextId.ToString().PadLeft(3, '0');
                txtCode = formattedId;
            }
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
    }
}
