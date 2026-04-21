using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectPhaseTaskTemplate : Form
    {
        int id;
        public frmProjectPhaseTaskTemplate(int _id)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }
        private void frmProjectPhaseTaskTemplate_Load(object sender, EventArgs e)
        {
            LoadPhaseTemplate();
            if (id > 0)
                LoadData();
        }
        private void LoadPhaseTemplate()
        {
            cmbPhaseTemplate.DataSource = DBClass.ExecuteDataTable("select template_id, phase_name from tbl_project_phase_templates order by sort_order");
            cmbPhaseTemplate.DisplayMember = "phase_name";
            cmbPhaseTemplate.ValueMember = "template_id";
        }
        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_project_phase_task_templates where task_template_id = @id",
                DBClass.CreateParameter("@id", id)))
            {
                if (reader.Read())
                {
                    cmbPhaseTemplate.SelectedValue = reader.GetInt32("template_id");
                    txtTaskName.Text = reader.GetString("task_name");
                    txtSortOrder.Text = reader.GetString("sort_order");
                    ChkMandatory.Checked = reader.GetBoolean("is_mandatory");
                    ChkActive.Checked = reader.GetBoolean("is_active");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";
            if (id == 0)
            {
                query = "INSERT INTO tbl_project_phase_task_templates (template_id, task_name, sort_order, is_mandatory, is_active) VALUES (@templateId,@name,@order, @is_mandatory,@is_active)";
            }
            else
            {
                query = "UPDATE tbl_project_phase_task_templates SET template_id=@templateId, task_name=@name, sort_order=@order, is_mandatory=@is_mandatory, is_active=@is_active WHERE task_template_id=@id";
            }

            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@templateId", cmbPhaseTemplate.SelectedValue),
                DBClass.CreateParameter("@name", txtTaskName.Text),
                DBClass.CreateParameter("@order", txtSortOrder.Text),
                DBClass.CreateParameter("@is_mandatory", ChkMandatory.Checked ? 1 : 0),
                DBClass.CreateParameter("@is_active", ChkActive.Checked ? 1 : 0),
                DBClass.CreateParameter("@id", id)
            );

            EventHub.RefreshPhase();
            this.Close();
        }

        private void txtPhaseNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore non-digit input
            }
        }
    }
}
