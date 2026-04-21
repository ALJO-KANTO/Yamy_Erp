using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmEngineerTask : Form
    {
        private Timer timer;
        private DataTable _projectTable;
        private bool isNotificationAllowed = true;
        public frmEngineerTask()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngineerTask_Load(object sender, EventArgs e)
        {
            if (isNotificationAllowed)
            {
                timer = new Timer();
                loadNotification();
            }

            ProjectData();
        }

        private int lastUnreadCount = 0;

        private void loadNotification()
        {
            // Load notifications for the engineer based on their activities and file uploads check with timer every 5 seconds

            timer.Interval = 5000; // 5 seconds
            timer.Tick += (s, e) =>
            {
                if (frmLogin.userRole != "Engineer")
                    return;

                CheckNoUpdateProjects();     // ⚠️
                CheckProjectDeadline();      // ⏱️

                int unreadCount = NotificationService.GetUnreadCount(frmLogin.userId);
                lblCount.Text = unreadCount.ToString();
                lblCount.Font = new Font("Segoe UI", 6, FontStyle.Regular);
                lblCount.Visible = unreadCount > 0;

                // Only notify if NEW notifications arrived
                if (unreadCount > lastUnreadCount)
                {
                    int newItems = unreadCount - lastUnreadCount;

                    var result = MessageBox.Show($"You have {newItems} new updates 🔔", "New Notifications", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    lastUnreadCount = unreadCount;
                    if (result == DialogResult.Yes)
                    {
                        object objN = DBClass.ExecuteScalar(@"
                            SELECT n.notification_id 
                            FROM tbl_notification_users nu
                            INNER JOIN tbl_notifications n ON n.notification_id = nu.notification_id
                            WHERE nu.user_id = @uId AND nu.is_read = 0 ORDER BY id DESC LIMIT 1",
                        DBClass.CreateParameter("@uId", frmLogin.userId));
                        int nId = objN != null ? Convert.ToInt32(objN) : 0;
                        NotificationService.MarkAllAsRead(nId, frmLogin.userId);

                        ProjectData();
                    }
                    else if (result == DialogResult.No)
                    {
                        ProjectData();
                    }
                }
            };
            timer.Start();
        }
        private void CheckNoUpdateProjects()
        {
            string query = @"
                SELECT id, name, TIMESTAMPDIFF(DAY, last_progress_update, NOW()) AS days
                FROM tbl_projects
                WHERE last_progress_update IS NOT NULL
                HAVING days > 30";

            var dt = DBClass.ExecuteDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int projectId = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();
                int days = Convert.ToInt32(row["days"]);

                NotificationService.Add(projectId, null, null,
                    $"Project '{name}' has no update for {days} days",
                    "Delay Warning",
                    "Warning");
            }
        }
        private void CheckProjectDeadline()
        {
            string query = @"
                SELECT id, name, end_date
                FROM tbl_projects
                WHERE end_date IS NOT NULL
                AND end_date < CURDATE()";

            var dt = DBClass.ExecuteDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int projectId = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();

                NotificationService.Add(projectId, null, null,
                    $"Project '{name}' is delayed beyond deadline!",
                    "Deadline Alert",
                    "Alert");
            }
        }
        public void ProjectData()
        {
            string query = @"SELECT id, Name FROM tbl_projects";
            query = @"SELECT 
                        p.id,
                        p.priority_level,
                        p.priority_color,
                        CONCAT(
                            IF(p.priority_level = 1, '⭐ ', ''),
                            p.NAME,
                            ' | Recent: ',
                            COALESCE(
                                CONCAT(
                                    DATE_FORMAT(p.last_progress_update, '%Y-%m-%d %H:%i'),
                                    ' (',
                                    TIMESTAMPDIFF(DAY, p.last_progress_update, NOW()),
                                    ' days ago)'
                                ),
                                'No updates'
                            )
                        ) AS Name,
                        TIMESTAMPDIFF(DAY, p.last_progress_update, NOW()) AS days_idle
                    FROM tbl_projects p ";
            string username = frmLogin.userName;
            if (frmLogin.userRole == "Engineer")
            {
                query += " WHERE id IN (SELECT project_id from tbl_projects_engineers pe INNER JOIN tbl_engineers e ON e.id = pe.engineer_id WHERE e.name = @eng); ";
            }


            _projectTable = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@eng", username));
            if (_projectTable == null)
                return;

            dgvProjects.DataSource = _projectTable;
            //if (dgvProjects.Columns.Contains("id"))
            //    dgvProjects.Columns["id"].Visible = false;

            //if (dgvProjects.Columns.Contains("Name"))
            //{
            //    dgvProjects.Columns["Name"].MinimumWidth = 200;
            //    dgvProjects.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //}

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);

            //if (dgvProjects.Rows != null && dgvProjects.Rows.Count > 0)
            //{
            //    AddViewDocImageColumn();
            //}

            ApplySearchFilter(); // keep search after refresh
            LocalizationManager.LocalizeDataGridViewHeaders(dgvActivityLog);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Focused) return;

            ApplySearchFilter();
        }
        private void ApplySearchFilter()
        {
            if (_projectTable == null)
                return;

            string searchText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _projectTable.DefaultView.RowFilter = "";
            }
            else
            {
                _projectTable.DefaultView.RowFilter =
                    $"Convert(Name, 'System.String') LIKE '%{searchText}%'";
            }

            dgvProjects.DataSource = _projectTable.DefaultView;
        }

        int selectedProjectId = 0;
        int engineerId = 0;

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int projectId = Convert.ToInt32(dgvProjects.CurrentRow.Cells["id"].Value);
            ClearDetails();
            LoadProjectInformation(projectId);
        }

        private void ClearDetails()
        {
            txtProjectCode.Text = "";
            txtProjectName.Text = "";
            txtOwner.Text = "";
            txtDescription.Text = "";
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            txtContractor.Text = "";
            txtMunicipalityProjectNo.Text = "";
            txtProjectClassification.Text = "";
            txtPlotNo.Text = "";
            txtBlock.Text = "";
            txtLocation.Text = "";
            txtContactPersion.Text = "";
            txtContactNo.Text = "";
            selectedProjectId = 0;
            selectedFileId = 0;
            dgvFiles.DataSource = null;
            txtNote.Text = "";
            cmbStatus.SelectedIndex = -1;
        }

        private void LoadProjectInformation(int projectId)
        {
            string savedCulture = Properties.Settings.Default.ApplicationLanguage ?? "en";

            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT p.*,ifnull(c.name_ar,'') name_ar, ifnull(c.name_en,'') name_en FROM tbl_projects p LEFT JOIN tbl_project_Classification c ON c.id = p.project_Classification WHERE p.id = @id", DBClass.CreateParameter("@id", projectId)))
            {
                if (reader.Read())
                {
                    txtProjectCode.Text = reader["code"].ToString();
                    txtProjectName.Text = reader["name"].ToString();
                    txtOwner.Text = reader["owner_name"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                    dtStart.Value = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : DateTime.Now;
                    dtEnd.Value = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : DateTime.Now;
                    txtContractor.Text = reader["contractor"].ToString();
                    txtMunicipalityProjectNo.Text = reader["municipality_project_no"].ToString();
                    txtProjectClassification.Text = savedCulture == "en" ? reader["name_en"].ToString() : savedCulture == "ar" ? reader["name_ar"].ToString() : "";
                    txtPlotNo.Text = reader["plot_number"].ToString();
                    txtBlock.Text = reader["block"].ToString();
                    txtLocation.Text = reader["location"].ToString();
                    txtContactPersion.Text = reader["contact_person"].ToString();
                    txtContactNo.Text = reader["contact_person_number"].ToString();
                    selectedProjectId = projectId;
                    object objEngineerId = DBClass.ExecuteScalar("SELECT e.id from tbl_projects_engineers pe INNER JOIN tbl_engineers e ON e.id = pe.engineer_id WHERE e.name = @eng LIMIT 1", DBClass.CreateParameter("@eng", frmLogin.userName));
                    if (objEngineerId != null && int.TryParse(objEngineerId.ToString(), out int engId))
                    {
                        engineerId = engId;
                    }
                    LoadFiles();
                    LoadActivityLog();
                    LoadPhases();
                }
            }
        }

        private void LoadPhases()
        {
            string query = @"
                SELECT pptask.task_id `TaskId`,pptask.phase_id,pptask.task_template_id,pptask.task_name `Task Name`,pptask.is_required `Task Required`,pptask.is_completed `Task Is Completed`,pptask.completed_on `Task Completed On`,pptask.completed_by `Task Completed By`,pptask.remarks `Task Remarks`,
                pptask.`status` `Task Status`,pptask.created_at `Task Created At`,pptask.updated_at `Task Updated At`,
                pptt.is_mandatory `Phase Task Is Mandatory`,
                epp.phase_name `ProjectPhase Name`,epp.start_date `Project StartDate`,epp.end_date `Project EndDate`,epp.completed_on `Project Completed On`,epp.`status` `Project Status`,epp.phase_color `Project Color`
                FROM tbl_project_phase_tasks pptask 
                INNER JOIN tbl_project_phase_task_templates pptt ON pptask.task_template_id = pptt.task_template_id
                INNER JOIN tbl_project_phase_templates pptem ON pptem.template_id = pptt.template_id
                INNER JOIN tbl_eng_project_phases epp ON pptask.phase_id = epp.phase_id
                WHERE epp.project_id = @pid";

            dgvPhases.DataSource = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@pid", selectedProjectId));

            dgvPhases.Columns["TaskId"].Visible = false;
            dgvPhases.Columns["phase_id"].Visible = false;
            dgvPhases.Columns["task_template_id"].Visible = false;
            dgvPhases.Columns["Project Color"].Visible = false;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhases);
        }

        private void LoadActivityLog()
        {
            string query = @"
                SELECT 
                    a.activity_type as `Activity Type`, 
                    a.description as `Description`, 
                    a.status `Status`, 
                    a.created_at `Date`,
                    IFNULL(e.name,'') AS `Engineer`
                FROM tbl_engineer_activity a
                LEFT JOIN tbl_engineers e ON a.engineer_id = e.id
                WHERE a.project_id = @pid" +
                 (frmLogin.userRole == "Engineer" ? " AND a.engineer_id = @eid" : "") +
                 @"
                ORDER BY a.created_at DESC";

            dgvActivityLog.DataSource = DBClass.ExecuteDataTable(query,
                DBClass.CreateParameter("@pid", selectedProjectId),
                DBClass.CreateParameter("@eid", engineerId)
                );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvActivityLog);
        }

        private void LoadFiles()
        {
            dgvFiles.DataSource = DBClass.ExecuteDataTable(@"
                SELECT file_id, file_name, description, status, uploaded_at
                FROM tbl_project_files
                WHERE project_id = @pid AND engineer_id = @eid",
                DBClass.CreateParameter("@pid", selectedProjectId),
                DBClass.CreateParameter("@eid", engineerId));

            if (dgvFiles.Rows != null && dgvFiles.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }

            dgvFiles.Columns["file_id"].HeaderText = "Id";
            dgvFiles.Columns["file_name"].HeaderText = "File Name";
            dgvFiles.Columns["description"].HeaderText = "Description";
            dgvFiles.Columns["status"].HeaderText = "Status";
            dgvFiles.Columns["uploaded_at"].HeaderText = "Updated On";
            dgvFiles.Columns["file_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvFiles);
        }
        private void AddViewDocImageColumn()
        {
            if (!dgvFiles.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvFiles.Columns.Add(imgColumn);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(ofd.FileName);
                string path = ofd.FileName;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_project_files
                    (project_id, engineer_id, file_name, file_path, file_type, description, status)
                    VALUES
                    (@pid, @eid, @name, @path, @type, '', 'Pending')",
                    DBClass.CreateParameter("@pid", selectedProjectId),
                    DBClass.CreateParameter("@eid", engineerId),
                    DBClass.CreateParameter("@name", fileName),
                    DBClass.CreateParameter("@path", path),
                    DBClass.CreateParameter("@type", Path.GetExtension(fileName))
                );

                NotificationService.Add(selectedFileId, null, null, $"New file '{fileName}' uploaded for project '{txtProjectName.Text}'", "File Upload", "Pending");
                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_engineer_activity
                    (project_id, engineer_id, activity_type, description, status)
                    VALUES
                    (@pid, @eid, 'File Upload', @desc, 'Pending')",
                    DBClass.CreateParameter("@pid", selectedProjectId),
                    DBClass.CreateParameter("@eid", engineerId),
                    DBClass.CreateParameter("@desc", $"Uploaded file '{fileName}'")
                );
                LoadFiles();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedFileId == 0)
            {
                string updateQuery = "UPDATE tbl_projects SET last_progress_update = NOW() WHERE id = @id";
                DBClass.ExecuteNonQuery(updateQuery,
                    DBClass.CreateParameter("@description", txtDescription.Text.Trim()),
                    DBClass.CreateParameter("@id", selectedProjectId)
                    );

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_engineer_activity
                (project_id, engineer_id, activity_type, description, status)
                VALUES
                (@pid, @eid, 'Status Updated', @desc, @status)",
                    DBClass.CreateParameter("@pid", selectedProjectId),
                    DBClass.CreateParameter("@eid", engineerId),
                    DBClass.CreateParameter("@desc", txtNote.Text.Trim()),
                    DBClass.CreateParameter("@status", cmbStatus.Text)
                );

                NotificationService.Add(selectedProjectId, null, null, $"Status updated for project '{txtProjectName.Text}'", "Status Update", cmbStatus.Text);
            }
            else
            {

                DBClass.ExecuteNonQuery(@"
                UPDATE tbl_project_files
                SET 
                    description = @desc,
                    status = @status
                WHERE file_id = @id",
                    DBClass.CreateParameter("@desc", txtNote.Text),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@id", selectedFileId)
                );

                string updateQuery = "UPDATE tbl_projects SET last_progress_update = NOW() WHERE id = @id";
                DBClass.ExecuteNonQuery(updateQuery,
                    DBClass.CreateParameter("@description", txtDescription.Text.Trim()),
                    DBClass.CreateParameter("@id", selectedProjectId)
                    );

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_engineer_activity
                (project_id, engineer_id, activity_type, description, status)
                VALUES
                (@pid, @eid, 'Status Update', @desc, @status)",
                    DBClass.CreateParameter("@pid", selectedProjectId),
                    DBClass.CreateParameter("@eid", engineerId),
                    DBClass.CreateParameter("@desc", txtNote.Text.Trim()),
                    DBClass.CreateParameter("@status", cmbStatus.Text)
                );

                NotificationService.Add(selectedProjectId, null, null, $"Status updated for file '{dgvFiles.CurrentRow.Cells["file_name"].Value}' in project '{txtProjectName.Text}'", "Status Update", cmbStatus.Text);
            }

            MessageBox.Show("Updated");

            LoadFiles();
            LoadActivityLog();
        }

        private int selectedFileId = 0;
        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedFileId = Convert.ToInt32(dgvFiles.Rows[e.RowIndex].Cells["file_id"].Value);

            if (dgvFiles.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvFiles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                string sql = "SELECT file_path FROM tbl_project_files WHERE file_id=@id";
                object obj = DBClass.ExecuteScalar(sql, DBClass.CreateParameter("@id", selectedFileId));
                if (obj != null)
                {
                    string path = obj.ToString();
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                    }
                    else
                    {
                        MessageBox.Show("File not found at path: " + path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            txtNote.Text = dgvFiles.Rows[e.RowIndex].Cells["description"].Value.ToString();
            cmbStatus.Text = dgvFiles.Rows[e.RowIndex].Cells["status"].Value.ToString();

        }

        private void dgvFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                if (dgvFiles.Rows.Count > 0)
                {
                    var row = dgvFiles.Rows[e.RowIndex];

                    string status = row.Cells["status"].Value != null ? row.Cells["status"].Value.ToString() : "";

                    if (status == "Pending")
                        row.DefaultCellStyle.BackColor = Color.LightYellow;

                    else if (status == "In Progress")
                        row.DefaultCellStyle.BackColor = Color.LightBlue;

                    else if (status == "Completed")
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (frmLogin.userRole == "Engineer")
            {
                CloseApplication();
            }

            this.Close();
        }
        private void CloseApplication()
        {
            DialogResult result = MessageBox.Show(
                "Do you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel; // Or Abort
                Application.Exit();
            }
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            ContextMenuStrip languageMenu = new ContextMenuStrip();
            languageMenu.Items.Add("English", null, (s, ea) => ChangeLanguage("en"));
            languageMenu.Items.Add("Arabic", null, (s, ea) => ChangeLanguage("ar"));
            //languageMenu.Items.Add("French", null, (s, ea) => ChangeLanguage("fr"));
            //languageMenu.Items.Add("Hindi", null, (s, ea) => ChangeLanguage("hi"));
            //languageMenu.Items.Add("Urdu", null, (s, ea) => ChangeLanguage("ur"));
            //languageMenu.Items.Add("Spanish", null, (s, ea) => ChangeLanguage("es"));
            //languageMenu.Items.Add("German", null, (s, ea) => ChangeLanguage("gr"));
            //languageMenu.Items.Add("Japanese", null, (s, ea) => ChangeLanguage("ja"));
            //languageMenu.Items.Add("Korean", null, (s, ea) => ChangeLanguage("ko"));
            //languageMenu.Items.Add("Tagalog / Filipino", null, (s, ea) => ChangeLanguage("fil"));
            //languageMenu.Items.Add("Simplified Chinese", null, (s, ea) => ChangeLanguage("zh-CN"));
            //languageMenu.Items.Add("Traditional Chinese", null, (s, ea) => ChangeLanguage("zh-TW"));

            var button = sender as Guna2Button;
            languageMenu.Show(button, new System.Drawing.Point(0, button.Height));
        }
        private void ChangeLanguage(string cultureCode)
        {
            LocalizationManager.SetLanguage(cultureCode);

            this.Controls.Clear();
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            ProjectData();
        }

        private void dgvProjects_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvProjects.Rows[e.RowIndex];

            if (row.Cells["days_idle"].Value == DBNull.Value) return;

            int days = Convert.ToInt32(row.Cells["days_idle"].Value);
            bool isPriority = row.Cells["priority_level"] != null && Convert.ToBoolean(row.Cells["priority_level"].Value);

            // ⭐ Priority
            if (isPriority)
            {
                row.DefaultCellStyle.BackColor = Color.LightPink;
            }

            // 🔴 Delay > 30 days
            if (days > 30)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
            // 🟡 Warning
            else if (days > 15)
            {
                row.DefaultCellStyle.BackColor = Color.Khaki;
            }
        }

        private void lblCount_Click(object sender, EventArgs e)
        {
            navigateNotificationForm();
        }

        private void picNotification_Click(object sender, EventArgs e)
        {
            navigateNotificationForm();
        }
        private void navigateNotificationForm()
        {
            frmNotifications frm = new frmNotifications();
            frm.ShowDialog();
        }
    }
}
