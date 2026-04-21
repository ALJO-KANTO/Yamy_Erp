using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Project_Management;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmProjectPhaseWorkflow : Form
    {
        int selectedProjectPhaseId = 0;

        public frmProjectPhaseWorkflow()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProjectPhaseWorkflow_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadData();
            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhases);
        }

        private void LoadProjects()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void LoadData()
        {
            dgvPhases.Rows.Clear();
            if (cmbProject.SelectedIndex == -1)
                return;

            using (MySqlDataReader reader = DBClass.ExecuteReader(
                @"SELECT phase_id,
                         phase_name,
                         start_date,
                         end_date,
                         weight_percentage,
                         status,
                         template_id,
                         phase_no,
                         (SELECT phase_name FROM tbl_project_phase_templates WHERE template_id = tbl_eng_project_phases.template_id) AS template_name,
                         phase_color
                  FROM tbl_eng_project_phases
                  WHERE project_id = @project_id
                  ORDER BY start_date",
                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue)
            ))
            {
                while (reader.Read())
                {
                    dgvPhases.Rows.Add(
                        reader["phase_id"], 
                        reader["phase_name"], 
                        Convert.ToDateTime(reader["start_date"]).ToString("yyyy-MM-dd"), 
                        Convert.ToDateTime(reader["end_date"]).ToString("yyyy-MM-dd"), 
                        reader["weight_percentage"], reader["status"],
                        reader["phase_color"],
                        reader["phase_no"],
                        reader["template_id"],
                        reader["template_name"]
                        );
                }
            }

            dgvPhases.Columns["phase_id"].Visible = dgvPhases.Columns["template_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhases);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            CreateDefaultProjectWorkflow(Convert.ToInt32(cmbProject.SelectedValue));

            MessageBox.Show("Project Workflow Created");

            LoadData();
        }
        private void CreateDefaultProjectWorkflow(int projectId)
        {
            string phaseSql = @"
                SELECT template_id, phase_no, phase_name, sort_order
                FROM tbl_project_phase_templates
                WHERE is_active = 1
                ORDER BY sort_order";

            DataTable dtPhases = DBClass.ExecuteDataTable(phaseSql);

            foreach (DataRow phaseRow in dtPhases.Rows)
            {
                int templateId = Convert.ToInt32(phaseRow["template_id"]);
                int phaseNo = Convert.ToInt32(phaseRow["phase_no"]);
                string phaseName = phaseRow["phase_name"].ToString();

                int phaseId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                    INSERT INTO tbl_eng_project_phases
                    (project_id, template_id, phase_no, phase_name, start_date, end_date, status, phase_color)
                    VALUES
                    (@project_id, @template_id, @phase_no, @phase_name, CURDATE(), CURDATE(), 'Pending', 'Gray');
                    SELECT LAST_INSERT_ID();",
                    DBClass.CreateParameter("@project_id", projectId),
                    DBClass.CreateParameter("@template_id", templateId),
                    DBClass.CreateParameter("@phase_no", phaseNo),
                    DBClass.CreateParameter("@phase_name", phaseName)
                ));

                DataTable dtTasks = DBClass.ExecuteDataTable(@"
                    SELECT task_template_id, task_name, sort_order, is_mandatory
                    FROM tbl_project_phase_task_templates
                    WHERE template_id = @template_id
                    ORDER BY sort_order",
                    DBClass.CreateParameter("@template_id", templateId));

                foreach (DataRow taskRow in dtTasks.Rows)
                {
                    DBClass.ExecuteNonQuery(@"
                        INSERT INTO tbl_project_phase_tasks
                        (phase_id, task_template_id, task_name, is_required, status, sort_order)
                        VALUES
                        (@phase_id, @task_template_id, @task_name, @is_required, 'Pending', @sort_order)",
                        DBClass.CreateParameter("@phase_id", phaseId),
                        DBClass.CreateParameter("@task_template_id", taskRow["task_template_id"]),
                        DBClass.CreateParameter("@task_name", taskRow["task_name"].ToString()),
                        DBClass.CreateParameter("@is_required", Convert.ToInt32(taskRow["is_mandatory"])),
                        DBClass.CreateParameter("@sort_order", Convert.ToInt32(taskRow["sort_order"]))
                    );
                }
            }
        }

        private void dgvPhases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPhases.Rows[e.RowIndex];

            selectedProjectPhaseId = Convert.ToInt32(row.Cells["phase_id"].Value);
            cmbProject.SelectedValue = Convert.ToInt32(row.Cells["project_id"].Value);
        }

        private bool ValidateForm()
        {
            if (cmbProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a project.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            cmbProject.SelectedIndex = -1;
            selectedProjectPhaseId = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!cmbProject.Focused) return;

            LoadData();
        }
    }
}
