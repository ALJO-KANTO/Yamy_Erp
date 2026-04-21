using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using YamyProject.Localization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmManagerReports : Form
    {
        public frmManagerReports()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmManagerReports_Load(object sender, EventArgs e)
        {
            LoadAll();
        }
        private void LoadAll()
        {
            LoadProjectReport();
            LoadPhaseReport();
            LoadEngineerReport();
            LoadApprovalReport();
        }
        private void LoadProjectReport()
        {
            string savedCulture = Properties.Settings.Default.ApplicationLanguage ?? "en";

            string query = @"
                SELECT 
                    id,
                    name `Name`,
                    owner_name `Owner Name`,";

            if (savedCulture == "ar")
            {
                query += "ifnull((SELECT name_ar from tbl_project_Classification where id = project_Classification),'') `Classification`,";
            }
            else
            {
                query += "ifnull((SELECT name_en from tbl_project_Classification where id = project_Classification),'') `Classification`,";
            }
            
            query += @"status `Status`,
                    priority_level `Priority Level`,
                    is_starred `Starred`,
                    IFNULL(DATEDIFF(CURDATE(), COALESCE(extend_delay, end_date)), 0) AS `Delay Days`,
                    CASE
                        WHEN last_progress_update IS NULL
                             OR last_progress_update<DATE_SUB(NOW(), INTERVAL 30 DAY)
                        THEN 'Stale' ELSE 'Active' END AS `Activity Status`
                FROM tbl_projects
                ORDER BY priority_level DESC";

            dgvProjects.DataSource = DBClass.ExecuteDataTable(query);

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);
        }
        private void LoadPhaseReport()
        {
            dgvPhases.DataSource = DBClass.ExecuteDataTable(@"
                SELECT 
                    p.name AS Project,
                    ph.phase_name `Phase Name`,
                    ph.status Status,
                    ph.phase_color `Phase Color`,
                    COUNT(t.task_id) AS `Total Tasks`,
                    SUM(CASE WHEN t.is_completed = 1 THEN 1 ELSE 0 END) AS `Completed Tasks`,
                    ROUND(
                        (SUM(CASE WHEN t.is_completed = 1 THEN 1 ELSE 0 END) 
                        / COUNT(t.task_id)) * 100, 2
                    ) AS `Progress %`
                FROM tbl_eng_project_phases ph
                LEFT JOIN tbl_project_phase_tasks t ON t.phase_id = ph.phase_id
                LEFT JOIN tbl_projects p ON p.id = ph.project_id
                GROUP BY ph.phase_id");

            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhases);
        }
        private void LoadEngineerReport()
        {
            dgvEngineers.DataSource = DBClass.ExecuteDataTable(@"
                SELECT 
                    e.name AS Engineer,
                    COUNT(f.file_id) AS `Total Files`,
                    SUM(CASE WHEN f.status = 'Approved' THEN 1 ELSE 0 END) AS Approved,
                    SUM(CASE WHEN f.status = 'Rejected' THEN 1 ELSE 0 END) AS Rejected,
                    COUNT(a.activity_id) AS Activities
                FROM tbl_engineers e
                LEFT JOIN tbl_project_files f ON f.engineer_id = e.id
                LEFT JOIN tbl_engineer_activity a ON a.engineer_id = e.id

                GROUP BY e.id");

            LocalizationManager.LocalizeDataGridViewHeaders(dgvEngineers);
        }
        private void LoadApprovalReport()
        {
            dgvFiles.DataSource = DBClass.ExecuteDataTable(@"
                SELECT 
                    p.name AS Project,
                    f.file_name `File Name`,
                    f.description Description,
                    f.status Status,
                    f.uploaded_at `Updated On`,
                    TIMESTAMPDIFF(DAY, f.uploaded_at, NOW()) AS `Waiting Days`
                FROM tbl_project_files f
                LEFT JOIN tbl_projects p ON p.id = f.project_id
                ORDER BY f.uploaded_at DESC");

            LocalizationManager.LocalizeDataGridViewHeaders(dgvFiles);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Minimized;
        }
    }
}
