using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectClassificationCenter : Form
    {
        private EventHandler projectClassificationUpdatedHandler;
        public frmProjectClassificationCenter()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectClassificationUpdatedHandler = (sender, args) => LoadClassification();
            headerUC1.FormText = this.Text;
            EventHub.ProjectClassification += projectClassificationUpdatedHandler;
        }

        private void frmProjectClassification_Load(object sender, EventArgs e)
        {
            LoadClassification();
        }

        private void LoadClassification()
        {
            /*
             *INSERT INTO project_categories (name_ar, name_en, code) VALUES
              ('مشاريع تصميم', 'Design Projects', 'DESIGN'),
              ('مشاريع فعالة إشراف', 'Active Supervision Projects', 'ACTIVE_SUPERVISION'),
              ('مشاريع إشراف فقط', 'Supervision Only Projects', 'SUPERVISION_ONLY'),
              ('مشاريع ديكور', 'Interior Design Projects', 'DECOR'),
              ('مشاريع موقفة', 'On Hold Projects', 'ON_HOLD'),
              ('مشاريع منجزة', 'Completed Projects', 'COMPLETED');
             */

            DataTable dt = DBClass.ExecuteDataTable("SELECT id,name_ar,name_en,(SELECT COUNT(*) FROM tbl_projects WHERE project_classification = tbl_project_Classification.id) Project from tbl_project_Classification where is_active = 1");

            if (dt == null) return;

            dgvCustomer.DataSource = dt;

            string savedCulture = Properties.Settings.Default.ApplicationLanguage ?? "en";

            if (savedCulture.StartsWith("ar"))
            {
                dgvCustomer.Columns["name_en"].Visible = false;
            }
            else
            {
                dgvCustomer.Columns["name_ar"].Visible = false;
            }

            //add Button to edit classification
            if (!dgvCustomer.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = LocalizationManager.GetString("Edit"),
                    Text = LocalizationManager.GetString("Edit"),
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvCustomer.Columns.Add(editButtonColumn);
            }

            //dgvCustomer.Columns["id"].Visible = false;
            //fill column headers with
            dgvCustomer.Columns["name_ar"].HeaderText = "Name"; 
            dgvCustomer.Columns["name_en"].HeaderText = "Name"; 
            dgvCustomer.Columns["name_ar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["name_en"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProjectClassification().ShowDialog();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int classificationId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["id"].Value);
                frmLogin.frmMain.openChildForm(new MasterProject(classificationId));
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomer.Columns[e.ColumnIndex].Name == "Edit")
            {
                int classificationId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["id"].Value);
                new frmProjectClassification(classificationId).ShowDialog();
            }
        }
    }

}