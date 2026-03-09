using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using YamyProject.UI.Project_Management;

namespace YamyProject
{
    public partial class MasterProject : Form
    {
        private EventHandler projectUpdatedHandler;

        public MasterProject()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectUpdatedHandler  = (sender, args) => ProjectData();
            EventHub.Project += projectUpdatedHandler;
            this.Text = "Project Center";
            headerUC1.FormText = this.Text;
        }
        private void MasterProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Project -= projectUpdatedHandler;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //new frmAddProject(this, 0).ShowDialog();
            new frmProjectsManage().ShowDialog();
        }
        private void MasterProject_Load(object sender, EventArgs e)
        {
            ProjectData();
        }
        public void ProjectData()
        {
            DataTable dT = DBClass.ExecuteDataTable(@"SELECT ROW_NUMBER() OVER (ORDER BY id) AS SN, id,code, name, Category, start_date `Start Date`, end_date `End Date`,updated_at 'Updated On' FROM tbl_projects");
            if (dT == null)
                return;

            dgvCustomer.DataSource = dT;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["SN"].Width = 50;
            dgvCustomer.Columns["code"].Width = 100;
            dgvCustomer.Columns["Name"].MinimumWidth = 200;
            dgvCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //if (dgvCustomer.Rows.Count > 0)
            //{
            //    btnRemove.Enabled = UserPermissions.canDelete("Project Center");
            //}
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
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            object result = DBClass.ExecuteScalar(@"SELECT COUNT(1) FROM tbl_project_tender 
                  WHERE project_id = @id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            int recordCount = 0;
            if (result != null && result != DBNull.Value)
                recordCount = Convert.ToInt32(result);
            if (recordCount > 0)
            {
                MessageBox.Show("Already used");
                return;
            }
            DBClass.ExecuteNonQuery("DELETE FROM tbl_projects WHERE id=@id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            MessageBox.Show("Deleted");
            ProjectData();
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            new frmProjectsManage(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())).ShowDialog();
            //new frmAddProject(null, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())).ShowDialog();
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
