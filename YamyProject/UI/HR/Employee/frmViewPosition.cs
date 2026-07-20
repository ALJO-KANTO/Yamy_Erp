using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmViewPosition : Form
    {

        private int id;
        public frmViewPosition( int id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);

            this.id = id;

            headerUC1.FormText = id == 0 ? "Employee - New Position" : "Employee - Edit Position";
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewPosition_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateDepartments(cmbDepartments);
            if (id != 0)
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_position where id =@id", DBClass.CreateParameter("id", id)))
                {
                    reader.Read();
                    txtName.Text = reader["name"].ToString();
                    txtAnnualLeaveDays.Text = reader["AnnualLeaveDays"].ToString();
                    txtEOSDays.Text = reader["EOSDaysPerYear"].ToString();
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Department Name First");
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_position where name = @name",
                DBClass.CreateParameter("name", txtName.Text)))
                if (reader.Read())
                {
                    if (id == 0 || (id != int.Parse(reader["id"].ToString())))
                    {
                        MessageBox.Show("Department Already Exists. Enter Another Name.");
                        return;
                    }
                }
            
            if (id == 0)
            {
                int lastId = DBClass.ExecuteNonQuery("insert into tbl_position (name,department_id,AnnualLeaveDays,EOSDaysPerYear) values(@name,@department_id,@AnnualLeaveDays,@EOSDaysPerYear)",
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@department_id", cmbDepartments.SelectedValue.ToString()),
                    DBClass.CreateParameter("@AnnualLeaveDays", string.IsNullOrEmpty(txtAnnualLeaveDays.Text) ? 30 : Convert.ToInt32(txtAnnualLeaveDays.Text.ToString())),
                    DBClass.CreateParameter("@EOSDaysPerYear", string.IsNullOrEmpty(txtEOSDays.Text) ? 30 : Convert.ToInt32(txtEOSDays.Text.ToString()))
                    );
                if (lastId != 0)
                {
                    Utilities.LogAudit(frmLogin.userId, "Create Position", "Position", lastId, "Created Position: " + txtName.Text);
                }
                else
                {
                    string message = Utilities.LastLogError();
                    MessageBox.Show("Error Check your data" + message);
                }
            }
            else
            {
                DBClass.ExecuteNonQuery("update tbl_position set name=@name,AnnualLeaveDays=@AnnualLeaveDays,EOSDaysPerYear=@EOSDaysPerYear where id = @id",
                    DBClass.CreateParameter("id", id),
                    DBClass.CreateParameter("name", txtName.Text),
                    DBClass.CreateParameter("@AnnualLeaveDays", string.IsNullOrEmpty(txtAnnualLeaveDays.Text) ? 30 : Convert.ToDecimal(txtAnnualLeaveDays.Text.ToString())),
                    DBClass.CreateParameter("EOSDaysPerYear", string.IsNullOrEmpty(txtEOSDays.Text) ? 30 : Convert.ToInt32(txtEOSDays.Text.ToString()))
                    );
                Utilities.LogAudit(frmLogin.userId, "Update Position", "Position", id, "Updated Position: " + txtName.Text);
            }
            string key = "select * from tbl_position where department_id=";
            BindCombos.ClearCache(key);
            EventHub.RefreshEmployeePosition();
            this.Close();
        }

        private void txtAnnualLeaveDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
