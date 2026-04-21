using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using YamyProject.UI.Project_Management;

namespace YamyProject
{
    public partial class frmEngineerActivity : Form
    {
        private DataTable _projectTable;

        public frmEngineerActivity()
        {
            InitializeComponent();
            this.Text = "Project Center";
            LocalizationManager.LocalizeForm(this);
        }
        private void frmEngineerActivity_Load(object sender, EventArgs e)
        {
            ProjectData();
        }
        public void ProjectData()
        {
            string query = @"SELECT ROW_NUMBER() OVER (ORDER BY id) AS SN, id, Code, Name, start_date `Start Date`, end_date `End Date`,Status,Description,updated_at 'Updated On' FROM tbl_projects";
            string username = frmLogin.userName;
            if (frmLogin.userRole == "Engineer")
            {
                query += " WHERE id IN (SELECT project_id from tbl_projects_engineers pe INNER JOIN tbl_engineers e ON e.id = pe.engineer_id WHERE e.name = @eng); ";
            }

                
            _projectTable = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@eng", username));
            if (_projectTable == null)
                return;

            dgvCustomer.DataSource = _projectTable;
            if (dgvCustomer.Columns.Contains("id"))
                dgvCustomer.Columns["id"].Visible = false;

            if (dgvCustomer.Columns.Contains("SN"))
                dgvCustomer.Columns["SN"].Width = 50;

            if (dgvCustomer.Columns.Contains("Code"))
                dgvCustomer.Columns["Code"].Width = 100;

            if (dgvCustomer.Columns.Contains("Name"))
            {
                dgvCustomer.Columns["Name"].MinimumWidth = 200;
                dgvCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvCustomer.Columns.Contains("Status"))
                dgvCustomer.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (dgvCustomer.Columns.Contains("Description"))
                dgvCustomer.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);

            if (dgvCustomer.Rows != null && dgvCustomer.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }

            ApplySearchFilter(); // keep search after refresh
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
                    $"Convert(SN, 'System.String') LIKE '%{searchText}%' OR " +
                    $"Convert(Code, 'System.String') LIKE '%{searchText}%' OR " +
                    $"Convert(Name, 'System.String') LIKE '%{searchText}%' OR " +
                    $"Convert(Status, 'System.String') LIKE '%{searchText}%' OR " +
                    $"Convert(Description, 'System.String') LIKE '%{searchText}%'";
            }

            dgvCustomer.DataSource = _projectTable.DefaultView;
        }
        private void AddViewDocImageColumn()
        {
            if (!dgvCustomer.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvCustomer.Columns.Add(imgColumn);
            }
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            int pId = int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString());
            if (pId > 0)
            {
                new ProjectStatusUpdate(pId).ShowDialog();
                ProjectData();
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                int _vId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["Id"].Value);
                string type = "PROJECTS";
                AttachmentManager.OpenAttachmentByType(_vId, type);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
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
            languageMenu.Items.Add("French", null, (s, ea) => ChangeLanguage("fr"));
            languageMenu.Items.Add("Hindi", null, (s, ea) => ChangeLanguage("hi"));
            languageMenu.Items.Add("Urdu", null, (s, ea) => ChangeLanguage("ur"));
            languageMenu.Items.Add("Spanish", null, (s, ea) => ChangeLanguage("es"));
            languageMenu.Items.Add("German", null, (s, ea) => ChangeLanguage("gr"));
            languageMenu.Items.Add("Japanese", null, (s, ea) => ChangeLanguage("ja"));
            languageMenu.Items.Add("Korean", null, (s, ea) => ChangeLanguage("ko"));
            languageMenu.Items.Add("Tagalog / Filipino", null, (s, ea) => ChangeLanguage("fil"));
            languageMenu.Items.Add("Simplified Chinese", null, (s, ea) => ChangeLanguage("zh-CN"));
            languageMenu.Items.Add("Traditional Chinese", null, (s, ea) => ChangeLanguage("zh-TW"));

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

        private void btnSearch_Click_Click(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }
    }
}
