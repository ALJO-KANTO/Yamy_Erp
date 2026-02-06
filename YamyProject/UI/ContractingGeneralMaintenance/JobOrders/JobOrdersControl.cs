using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Vbe.Interop;
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

namespace YamyProject.UI.ContractingGeneralMaintenance.JobOrders
{
    public partial class JobOrdersControl : Form
    {
        public JobOrdersControl()
        {
            InitializeComponent();
        }

        private void JobOrdersControl_Load(object sender, EventArgs e)
        {
            LoadJobs();
        }
        private void LoadJobs()
        {
            // Replace with DB query
            DataTable dt = new DataTable();
            dt.Columns.Add("Job ID");
            dt.Columns.Add("Job Type");
            dt.Columns.Add("Project");
            dt.Columns.Add("Assigned To");
            dt.Columns.Add("Status");
            dt.Columns.Add("Estimated Hours");
            dt.Columns.Add("Actual Hours");
            dt.Columns.Add("EstimatedCost");
            dt.Columns.Add("Actual Cost");

            //dt.Rows.Add(1001, "Work Order", "Tower Project", "Team A", "Open", 40, 0, 0);
            //dt.Rows.Add(1002, "Maintenance Job", "Mall Renovation", "Technician Ahmed", "Approved", 8, 6, 1200);
            //dt.Rows.Add(1003, "Emergency Job", "Warehouse", "Team B", "Completed", 12, 14, 3500);
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT j.job_id, j.job_type,j.project_id,p.name project_name,j.asset_id, j.assigned_to, j.status, j.estimated_hours, j.actual_hours, j.estimated_cost, j.actual_cost, j.priority, j.remarks FROM tbl_job_orders j LEFT JOIN tbl_projects p ON p.id = j.project_id LEFT JOIN tbl_coa_level_4 a ON a.id = j.asset_id"))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["job_id"],
                        reader["job_type"],
                        reader["project_name"],
                        reader["assigned_to"],
                        reader["status"],
                        reader["estimated_hours"],
                        reader["actual_hours"],
                        reader["estimated_cost"],
                        reader["actual_cost"]
                    );
                }
            }
            dgvJobs.DataSource = dt;

            dgvJobs.Columns["job id"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JobOrderForm frm = new JobOrderForm();
            frm.ShowDialog();
            LoadJobs();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0) return;

            // Update job status to Approved
            int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["Job ID"].Value);
            string query = @"UPDATE tbl_job_orders SET status = 'Approved' WHERE job_id = @id";
            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@id", jobId));
            LoadJobs();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Mark job as completed?",
                "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Update status to Completed
                int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["Job ID"].Value);
                string query = @"UPDATE tbl_job_orders SET status = 'Completed' WHERE job_id = @id";
                DBClass.ExecuteNonQuery(query,
                    DBClass.CreateParameter("@id", jobId));
                LoadJobs();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void dgvJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvJobs.SelectedRows.Count == 0) return;

            int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["Job ID"].Value);
            JobOrderForm frm = new JobOrderForm(jobId);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
