using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.JobOrders
{
    public partial class JobOrderForm : Form
    {
        int jobOrderId = 0;
        public JobOrderForm(int _jobOrderId = 0)
        {
            InitializeComponent();
            this.jobOrderId = _jobOrderId;
        }

        private void JobOrderForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);
            DataTable dtTechnician = DBClass.ExecuteDataTable("SELECT distinct technician FROM tbl_maintenance_requests");
            cmbAssigned.DataSource = dtTechnician;
            cmbAssigned.DisplayMember = "technician";
            cmbAssigned.ValueMember = "technician";
            cmbAssigned.SelectedIndex = 0;

            if (jobOrderId != 0)
            {
                loadData();
            }
        }

        private void loadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_job_orders WHERE job_id = @id",
                DBClass.CreateParameter("@id", jobOrderId)))
            {
                if (reader.Read())
                {
                    cmbType.Text = reader["job_type"].ToString();
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbAssigned.Text = reader["assigned_to"].ToString();
                    txtEstimatedHours.Text = reader["estimated_hours"].ToString();
                    txtActualHours.Text = reader["actual_hours"].ToString();
                    txtActualCost.Text = reader["actual_cost"].ToString();
                    txtEstimatedCost.Text = reader["estimated_cost"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;

            decimal estHours = decimal.Parse(txtEstimatedHours.Text.Trim());
            decimal estCost = decimal.Parse(txtEstimatedCost.Text.Trim());
            decimal actHours = decimal.Parse(txtActualHours.Text.Trim());
            decimal actCost = decimal.Parse(txtActualCost.Text.Trim());
            
            if (jobOrderId == 0)
            {
                string query = @"
                INSERT INTO tbl_job_orders
                (job_type, project_id,project_name, assigned_to, estimated_hours, estimated_cost, actual_hours, actual_cost, status, created_at)
                VALUES
                (@type, @project,@project_name, @assigned, @estimated_hours, @estimate_cost, @actual_hours, @actual_cost, @status, NOW())";
                var pName = (cmbProject.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                DBClass.ExecuteNonQuery(query,
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@project_name", pName),
                    DBClass.CreateParameter("@assigned", cmbAssigned.Text),
                    DBClass.CreateParameter("@estimated_hours", estHours),
                    DBClass.CreateParameter("@estimate_cost", estCost),
                    DBClass.CreateParameter("@actual_hours", actHours),
                    DBClass.CreateParameter("@actual_cost", actCost),
                    DBClass.CreateParameter("@status", "Open"));


                MessageBox.Show("Job Order saved successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Update existing job order
                string query = @"
                UPDATE tbl_job_orders
                SET job_type = @type,
                    project_id = @project,
                    project_name = @project_name,
                    assigned_to = @assigned,
                    estimated_hours = @estimated_hours,
                    actual_hours = @actual_hours,
                    estimated_cost = @estimate_cost,
                    actual_cost = @actual_cost
                WHERE job_id = @id";
                var pName = (cmbProject.SelectedItem as DataRowView).Row.ItemArray[0].ToString();
                DBClass.ExecuteNonQuery(query,
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@project_name", pName),
                    DBClass.CreateParameter("@assigned", cmbAssigned.Text),
                    DBClass.CreateParameter("@estimated_hours", estHours),
                    DBClass.CreateParameter("@estimate_cost", estCost),
                    DBClass.CreateParameter("@actual_hours", actHours),
                    DBClass.CreateParameter("@actual_cost", actCost),
                    DBClass.CreateParameter("@id", jobOrderId));

                MessageBox.Show("Job Order updated successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool validateForm()
        {
            // 1. Validation
            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Job Type");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbProject.Text))
            {
                MessageBox.Show("Please enter Project / Asset");
                return false;
            }

            if (cmbAssigned.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Assigned Team / Technician");
                return false;
            }

            if (!decimal.TryParse(txtEstimatedHours.Text, out decimal estHours))
            {
                MessageBox.Show("Invalid Estimated Hours");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
    }
}
