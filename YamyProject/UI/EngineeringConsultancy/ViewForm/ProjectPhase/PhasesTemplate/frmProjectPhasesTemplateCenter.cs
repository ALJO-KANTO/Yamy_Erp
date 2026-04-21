using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectPhasesTemplateCenter : Form
    {
        private EventHandler projectPhaseUpdatedHandler;
        public frmProjectPhasesTemplateCenter()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectPhaseUpdatedHandler = (sender, args) => LoadPhases();
            headerUC1.FormText = this.Text;
            EventHub.ProjectPhase += projectPhaseUpdatedHandler;
        }
        
        private void frmProjectPhasesTemplateCenter_Load(object sender, EventArgs e)
        {
            LoadPhases();
        }

        private void LoadPhases()
        {
            dgvPhaseTemplates.DataSource = DBClass.ExecuteDataTable("SELECT * FROM tbl_project_phase_templates");

            dgvPhaseTemplates.Columns["template_id"].Visible = false;
            dgvPhaseTemplates.Columns["phase_no"].HeaderText = "Phase No";
            dgvPhaseTemplates.Columns["phase_name"].HeaderText = "Phase Name";
            dgvPhaseTemplates.Columns["sort_order"].HeaderText = "Sort Order";
            dgvPhaseTemplates.Columns["is_active"].HeaderText = "Active";

            dgvPhaseTemplates.Columns["phase_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //add Button to edit
            if (!dgvPhaseTemplates.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = LocalizationManager.GetString("Edit"),
                    Text = LocalizationManager.GetString("Edit"),
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvPhaseTemplates.Columns.Add(editButtonColumn);
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhaseTemplates);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProjectPhaseTaskTemplate(0).ShowDialog();
        }

        private void dgvPhaseTemplates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int tempId = Convert.ToInt32(dgvPhaseTemplates.Rows[e.RowIndex].Cells["template_id"].Value);
                frmLogin.frmMain.openChildForm(new frmProjectPhaseTaskTemplateCenter(tempId));
            }
        }

        private void dgvPhaseTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPhaseTemplates.Columns[e.ColumnIndex].Name == "Edit")
            {
                int tempId = Convert.ToInt32(dgvPhaseTemplates.Rows[e.RowIndex].Cells["template_id"].Value);
                new frmProjectPhaseTaskTemplate(tempId).ShowDialog();
            }
        }
    }

}