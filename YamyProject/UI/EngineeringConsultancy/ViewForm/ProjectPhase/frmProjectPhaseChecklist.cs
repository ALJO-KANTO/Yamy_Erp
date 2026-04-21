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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.ProjectPhase
{
    public partial class frmProjectPhaseChecklist : Form
    {

        private int selectedProjectId = 0;
        private int currentPhaseNo = 1;

        public frmProjectPhaseChecklist()
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProjectPhaseChecklist_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadTabPhased();
        }

        private void LoadProjects()
        {
            dgvProjects.DataSource = DBClass.ExecuteDataTable(@"
                SELECT id, code, name
                FROM tbl_projects
                ORDER BY is_starred DESC, priority_level DESC");

            // hide id column
            dgvProjects.Columns["id"].Visible =  dgvProjects.Columns["code"].Visible = false;
            // column width
            //dgvProjects.Columns["code"].Width = 30;
            //dgvProjects.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);
        }

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedProjectId = Convert.ToInt32(dgvProjects.Rows[e.RowIndex].Cells["id"].Value);
            tabPhases.SelectedIndex = 0;

            LoadPhase(1);
        }
        bool tabPhasesFocused = false;
        private void LoadTabPhased()
        {
            tabPhases.TabPages.Clear();

            //add TabbPage from database and color them based on status
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT template_id,phase_no, phase_name, sort_order FROM tbl_project_phase_templates"))
            {
                while (reader.Read())
                {
                    TabPage tabPage = new TabPage();
                    tabPage.Text = reader.GetString("phase_name");

                    tabPhases.TabPages.Add(tabPage);
                }
            }
            tabPhasesFocused = true;
        }
        private void LoadPhase(int phaseNo)
        {
            dgvTasks.DataSource = null;

            //DataTable dt0 = DBClass.ExecuteDataTable(@"
            //    SELECT phase_no, phase_color
            //    FROM tbl_eng_project_phases
            //    WHERE project_id = @project_id",
            //    DBClass.CreateParameter("@project_id", selectedProjectId));

            //foreach (DataRow row in dt0.Rows)
            //{
            //    int _phaseNo = Convert.ToInt32(row["phase_no"]);
            //    string color = row["phase_color"].ToString();

            //    TabPage tab = tabPhases.TabPages[_phaseNo - 1];

            //    if (color == "Green")
            //        tab.BackColor = Color.LightGreen;
            //    else if (color == "Yellow")
            //        tab.BackColor = Color.LightYellow;
            //    else
            //        tab.BackColor = Color.LightGray;
            //}

            currentPhaseNo = phaseNo;

            DataTable dt1 = DBClass.ExecuteDataTable(@"
                    SELECT phase_id, phase_color, status
                    FROM tbl_eng_project_phases
                    WHERE project_id = @project_id AND phase_no = @phase_no",
                DBClass.CreateParameter("@project_id", selectedProjectId),
                DBClass.CreateParameter("@phase_no", phaseNo));

            if (dt1.Rows.Count == 0) return;

            int phaseId = Convert.ToInt32(dt1.Rows[0]["phase_id"]);

            LoadTasks(phaseId);
            UpdateProgress(phaseId);

            foreach (TabPage tab in tabPhases.TabPages)
            {
                tab.Enabled = IsPhaseCompleted(tabPhases.TabPages.IndexOf(tab) + 1);
            }
        }
        private int currentPhaseId = 0;
        private bool IsPhaseCompleted(int phaseNo)
        {
            object status = DBClass.ExecuteScalar(@"
                SELECT status FROM tbl_eng_project_phases
                WHERE project_id = @project_id AND phase_no = @phase_no",
                DBClass.CreateParameter("@project_id", selectedProjectId),
                DBClass.CreateParameter("@phase_no", phaseNo));

            return status != null && status.ToString() == "Completed";
        }

        private void LoadTasks(int phaseId)
        {
            currentPhaseId = phaseId;

            dgvTasks.DataSource = DBClass.ExecuteDataTable(@"
                SELECT 
                    task_id,
                    task_name,
                    is_required,
                    is_completed,
                    completed_on,
                    remarks
                FROM tbl_project_phase_tasks
                WHERE phase_id = @phase_id
                ORDER BY sort_order",
                DBClass.CreateParameter("@phase_id", phaseId));

            SetupTaskGrid();
        }
        private void SetupTaskGrid()
        {
            dgvTasks.Columns["task_id"].Visible = false;

            dgvTasks.Columns["task_name"].HeaderText = "Task";
            dgvTasks.Columns["is_required"].HeaderText = "Required";
            dgvTasks.Columns["is_completed"].HeaderText = "Done";

            dgvTasks.Columns["is_completed"].ReadOnly = false;

            dgvTasks.Columns["completed_on"].HeaderText = "Completed On";
            dgvTasks.Columns["remarks"].HeaderText = "Remarks";

            dgvTasks.ClearSelection();
            dgvTasks.DefaultCellStyle.SelectionBackColor = dgvTasks.DefaultCellStyle.BackColor;
            dgvTasks.DefaultCellStyle.SelectionForeColor = dgvTasks.DefaultCellStyle.ForeColor;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvTasks);
        }

        private void dgvTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTasks.Columns[e.ColumnIndex].Name == "is_completed")
            {
                bool done = Convert.ToBoolean(dgvTasks.Rows[e.RowIndex].Cells["is_completed"].Value);

                if (done)
                    dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }

        private void dgvTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvTasks.Columns[e.ColumnIndex].Name != "is_completed") return;

            int taskId = Convert.ToInt32(dgvTasks.Rows[e.RowIndex].Cells["task_id"].Value);
            bool isDone = Convert.ToBoolean(dgvTasks.Rows[e.RowIndex].Cells["is_completed"].Value);

            DBClass.ExecuteNonQuery(@"
                UPDATE tbl_project_phase_tasks
                SET is_completed = @done,
                    completed_on = CASE WHEN @done = 1 THEN NOW() ELSE NULL END
                WHERE task_id = @task_id",
                DBClass.CreateParameter("@done", isDone ? 1 : 0),
                DBClass.CreateParameter("@task_id", taskId));

            // 🔥 Update phase + project
            UpdatePhaseStatus(currentPhaseId);
            UpdateProjectLastUpdate(selectedProjectId);

            LoadPhase(currentPhaseNo);
        }
        private void UpdateProgress(int phaseId)
        {
            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT 
                    COUNT(*) total,
                    IFNULL(SUM(CASE WHEN is_completed = 1 THEN 1 ELSE 0 END),0) done
                FROM tbl_project_phase_tasks
                WHERE phase_id = @phase_id",
                DBClass.CreateParameter("@phase_id", phaseId));

            int total = Convert.ToInt32(dt.Rows[0]["total"]);
            int done = Convert.ToInt32(dt.Rows[0]["done"]);

            int percent = total == 0 ? 0 : (done * 100 / total);

            progressBar.Value = percent;
            lblStatus.Text = $"Progress: {percent}%";
        }
        private void UpdatePhaseStatus(int phaseId)
        {
            object remaining = DBClass.ExecuteScalar(@"
                SELECT COUNT(*) FROM tbl_project_phase_tasks
                WHERE phase_id = @phase_id AND is_required = 1 AND is_completed = 0",
                DBClass.CreateParameter("@phase_id", phaseId));

            if (Convert.ToInt32(remaining) == 0)
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_eng_project_phases
                    SET status = 'Completed',
                        phase_color = 'Green',
                        completed_on = NOW()
                    WHERE phase_id = @phase_id",
                    DBClass.CreateParameter("@phase_id", phaseId));

                TriggerNextPhase(phaseId);
            }
            else
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_eng_project_phases
                    SET status = 'In Progress',
                        phase_color = 'Yellow'
                    WHERE phase_id = @phase_id",
                    DBClass.CreateParameter("@phase_id", phaseId));
            }
        }
        private void TriggerNextPhase(int phaseId)
        {
            var dt = DBClass.ExecuteDataTable(@"
                SELECT project_id, phase_no
                FROM tbl_eng_project_phases
                WHERE phase_id = @phase_id",
                DBClass.CreateParameter("@phase_id", phaseId));

            int projectId = Convert.ToInt32(dt.Rows[0]["project_id"]);
            int phaseNo = Convert.ToInt32(dt.Rows[0]["phase_no"]);

            int next = phaseNo + 1;

            DBClass.ExecuteNonQuery(@"
                UPDATE tbl_eng_project_phases
                SET status = 'In Progress', phase_color = 'Yellow'
                WHERE project_id = @project_id AND phase_no = @next",
                DBClass.CreateParameter("@project_id", projectId),
                DBClass.CreateParameter("@next", next));

            // 🔥 Update stages also
            //UpdateProjectStage(projectId, phaseNo);

            // 🔔 Notification
            //AddNotification(projectId, $"Phase {phaseNo} Completed", "Next phase started");
        }
        private void UpdateProjectLastUpdate(int projectId)
        {
            DBClass.ExecuteNonQuery(@"
                UPDATE tbl_projects
                SET last_progress_update = NOW()
                WHERE id = @id",
                DBClass.CreateParameter("@id", projectId));
        }

        private void tabPhases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedProjectId == 0) return;
            if (!tabPhasesFocused) return;

            int phaseNo = tabPhases.SelectedIndex + 1;

            LoadPhase(phaseNo);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Focused)
            {
                string keyword = txtSearch.Text.Trim();
                (dgvProjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("name LIKE '%{0}%'", keyword.Replace("'", "''"));
            }
        }
    }
}
