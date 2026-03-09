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
        private EventHandler projectUpdatedHandler;

        public frmEngineerActivity()
        {
            InitializeComponent();
            projectUpdatedHandler  = (sender, args) => ProjectData();
            EventHub.Project += projectUpdatedHandler;
            this.Text = "Project Center";
            headerUC1.FormText = this.Text;
            LocalizationManager.LocalizeForm(this);
        }
        private void frmEngineerActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Project -= projectUpdatedHandler;
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

                
            DataTable dT = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@eng", username));
            if (dT == null)
                return;

            dgvCustomer.DataSource = dT;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["SN"].Width = 50;
            dgvCustomer.Columns["code"].Width = 100;
            dgvCustomer.Columns["Name"].MinimumWidth = 200;
            dgvCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);

            if (dgvCustomer.Rows != null && dgvCustomer.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }
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

                int _vId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["vrefId"].Value);
                string type = dgvCustomer.Rows[e.RowIndex].Cells["vVoucherType"].Value.ToString();
                AttachmentManager.OpenAttachmentByType(_vId, type);
            }
        }
    }
}
