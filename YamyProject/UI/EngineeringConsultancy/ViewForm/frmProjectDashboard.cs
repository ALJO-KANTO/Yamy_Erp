using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmProjectDashboard : Form
    {
        public frmProjectDashboard()
        {
            InitializeComponent();
        }
        private void frmProjectDashboard_Load(object sender, EventArgs e)
        {
            LoadProjects();
            timerAlerts.Start();
        }
        private void LoadProjects()
        {
            string q = @"
                SELECT 
                    p.id,
                    p.name,
                    p.status,
                    MAX(a.created_at) as last_update,
                    DATEDIFF(NOW(), MAX(a.created_at)) as days_no_update
                FROM tbl_projects p
                LEFT JOIN tbl_project_activity_log a 
                    ON p.id = a.project_id
                GROUP BY p.id
                ";

            DataTable dt = DBClass.ExecuteDataTable(q);

            dgvProjects.DataSource = dt;


            lblLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString("HH:mm:ss");
        }
        private void dgvProjects_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvProjects.Rows[e.RowIndex];

            if (row.Cells["days_no_update"].Value == DBNull.Value) return;

            int days = Convert.ToInt32(row.Cells["days_no_update"].Value);
            string status = row.Cells["status"].Value?.ToString();

            // 🔴 Delayed
            if (days > 30)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
            // 🟡 Warning
            else if (days > 15)
            {
                row.DefaultCellStyle.BackColor = Color.Khaki;
            }
            // 🟢 Completed
            else if (status == "Completed")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            string status = cmbStatus.Text;

            (dgvProjects.DataSource as DataTable).DefaultView.RowFilter =
                $"name LIKE '%{search}%' " +
                (status != "All" ? $" AND status = '{status}'" : "");
        }
        private void timerAlerts_Tick(object sender, EventArgs e)
        {
            CheckDelayedProjects();
        }
        private void CheckDelayedProjects()
        {
            string q = @"
                SELECT p.id, p.name,
                       DATEDIFF(NOW(), MAX(a.created_at)) as days_no_update
                FROM tbl_projects p
                LEFT JOIN tbl_project_activity_log a 
                    ON p.id = a.project_id
                GROUP BY p.id
                HAVING days_no_update > 3";

            using (MySqlDataReader reader = DBClass.ExecuteReader(q))
            {
                while (reader.Read())
                {
                    int projectId = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    int days = reader.GetInt32("days_no_update");

                    CreateDelayNotification(projectId, name, days);
                }

                reader.Close();

                LoadProjects(); // refresh UI
            }
        }
        private void CreateDelayNotification(int projectId, string name, int days)
        {
            // Prevent duplicate alerts
            string check = @"SELECT COUNT(*) FROM tbl_notifications
                         WHERE project_id=@pid 
                         AND notification_type='Warning'
                         AND DATE(created_at)=CURDATE()";

            var cmdCheck = DBClass.ExecuteScalar(check,
            DBClass.CreateParameter("@pid", projectId));

            int exists = Convert.ToInt32(cmdCheck);
            if (exists > 0) return;

            string insert = @"INSERT INTO tbl_notifications
                        (project_id, title, message, notification_type)
                        VALUES
                        (@pid, 'Project Delay',
                         CONCAT('Project ', @name, 
                         ' has no update for ', @days, ' days'),
                         'Warning')";

            DBClass.ExecuteNonQuery(insert,
            DBClass.CreateParameter("@pid", projectId),
            DBClass.CreateParameter("@name", name),
            DBClass.CreateParameter("@days", days));
        }
    }
}
