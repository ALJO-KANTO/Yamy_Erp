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

namespace YamyProject.UI.ContractingGeneralMaintenance.Labor
{
    public partial class LaborAssignmentForm : Form
    {
        int Id;
        public LaborAssignmentForm(int _Id = 0)
        {
            InitializeComponent();
            Id = _Id;
        }

        private void LaborAssignmentForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateEmployees(cmbEmployee);
            BindCombos.PopulateProjects(cmbProject);

            if (Id > 0)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_labor_assignments WHERE id = @Id", new MySqlParameter("@Id", Id)))
            {
                if(reader.Read())
                {
                    cmbEmployee.SelectedValue = reader["employee_id"];
                    cmbProject.SelectedValue = reader["project_id"];
                    txtRate.Text = Convert.ToDecimal(reader["daily_rate"]).ToString("N2");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (Id > 0)
                {
                    DBClass.ExecuteNonQuery("UPDATE tbl_labor_assignments SET employee_id = @EmployeeId, project_id = @ProjectId, daily_rate = @DailyRate WHERE id = @Id",
                        DBClass.CreateParameter("@EmployeeId", cmbEmployee.SelectedValue),
                        DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue),
                        DBClass.CreateParameter("@DailyRate", Convert.ToDecimal(txtRate.Text)),
                        DBClass.CreateParameter("@Id", Id)
                    );

                    MessageBox.Show("Labor assignment updated successfully.");
                }
                else
                {
                    DBClass.ExecuteNonQuery("INSERT INTO tbl_labor_assignments (employee_id, project_id, daily_rate, hours_worked, labor_cost, productivity) VALUES (@EmployeeId, @ProjectId, @DailyRate, 0, 0, 0)",
                        DBClass.CreateParameter("@EmployeeId", cmbEmployee.SelectedValue),
                        DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue),
                        DBClass.CreateParameter("@DailyRate", Convert.ToDecimal(txtRate.Text)),
                        DBClass.CreateParameter("@Id", Id)
                    );

                    MessageBox.Show("Labor assignment created successfully.");
                }
            }
        }

        private bool ValidateFields()
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.");
                return false;
            }
            if(cmbProject.SelectedValue == null)
            {
                MessageBox.Show("Please select a project.");
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtRate.Text) || !decimal.TryParse(txtRate.Text, out decimal rate) || rate <= 0)
            {
                MessageBox.Show("Please enter a valid daily rate.");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtLaborCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
