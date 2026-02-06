using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Maintenance
{
    public partial class MaintenanceControl : Form
    {
        public MaintenanceControl()
        {
            InitializeComponent();
        }

        private void MaintenanceControl_Load(object sender, EventArgs e)
        {
            LoadMaintenanceRequests();
        }

        private void LoadMaintenanceRequests()
        {
            // Replace with DB data
            DataTable dt = new DataTable();
            dt.Columns.Add("Request ID");
            dt.Columns.Add("Asset");
            dt.Columns.Add("Type");
            dt.Columns.Add("Priority");
            dt.Columns.Add("Technician");
            dt.Columns.Add("Status");
            dt.Columns.Add("Cost");

            using(MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT m.*,a.name asset_name from tbl_maintenance_requests m LEFT JOIN tbl_coa_level_4 a ON m.asset_id=a.id")) { 
                while (reader.Read()) {
                    dt.Rows.Add(reader["request_id"], reader["asset_name"], reader["maintenance_type"], reader["priority"], reader["technician"], reader["status"], reader["estimated_cost"]);
                }
            }
            dgvMaintenance.DataSource = dt;

            dgvMaintenance.Columns["Request ID"].Visible = false;
        }   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MaintenanceRequestForm frm = new MaintenanceRequestForm();
            frm.ShowDialog();
            LoadMaintenanceRequests();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0) return;
            int requestId = Convert.ToInt32(dgvMaintenance.SelectedRows[0].Cells["Request ID"].Value);
            MaintenanceRequestForm frm = new MaintenanceRequestForm(requestId);
            frm.ShowDialog();
            LoadMaintenanceRequests();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Close selected maintenance job?",
                "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int requestId = Convert.ToInt32(dgvMaintenance.SelectedRows[0].Cells["Request ID"].Value);
                // Update status in DB
                string query = @"
                    UPDATE tbl_maintenance_requests
                    SET status = 'Completed'
                    WHERE request_id = @id";

                DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@id", requestId)
                );
                LoadMaintenanceRequests();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMaintenanceRequests();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
