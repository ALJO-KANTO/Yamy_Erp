using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectPhaseTaskTemplateCenter : Form
    {
        private EventHandler projectPhaseUpdatedHandler;
        int id;

        public frmProjectPhaseTaskTemplateCenter(int _id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectPhaseUpdatedHandler = (sender, args) => LoadPhases();
            headerUC1.FormText = this.Text;
            EventHub.ProjectPhase += projectPhaseUpdatedHandler;
            this.id = _id;
        }

        private void frmProjectPhaseTaskTemplateCenter_Load(object sender, EventArgs e)
        {
            if (id > 0)
                LoadPhases();
        }

        private void LoadPhases()
        {
            dgvPhaseTemplates.DataSource = DBClass.ExecuteDataTable("SELECT pptt.task_template_id,pptt.template_id,ppt.phase_name,pptt.task_name,pptt.sort_order,pptt.is_mandatory,pptt.is_active FROM tbl_project_phase_task_templates pptt INNER JOIN tbl_project_phase_templates ppt ON pptt.template_id = ppt.template_id where pptt.template_id=@id",
                DBClass.CreateParameter("@id", id));

            dgvPhaseTemplates.Columns["phase_name"].AutoSizeMode = dgvPhaseTemplates.Columns["task_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPhaseTemplates.Columns["template_id"].Visible = false;
            dgvPhaseTemplates.Columns["task_template_id"].Visible = false;

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
                //frmLogin.frmMain.openChildForm(new frmProjectPhaseStageCenter(tempId));
            }
        }

        private void dgvPhaseTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPhaseTemplates.Columns[e.ColumnIndex].Name == "Edit")
            {
                int tempId = Convert.ToInt32(dgvPhaseTemplates.Rows[e.RowIndex].Cells["task_template_id"].Value);
                new frmProjectPhaseTaskTemplate(tempId).ShowDialog();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvPhaseTemplates == null)
                return;

            if (dgvPhaseTemplates.CurrentRow == null)
                return;

            int tempId = Convert.ToInt32(
                dgvPhaseTemplates.CurrentRow.Cells["task_template_id"].Value
            );

            DBClass.ExecuteNonQuery("Delete from tbl_project_phase_task_templates WHERE task_template_id=@id", DBClass.CreateParameter("id", tempId));

            LoadPhases();
        }
    }

}