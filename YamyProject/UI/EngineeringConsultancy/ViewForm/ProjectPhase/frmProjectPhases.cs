using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmProjectPhases : Form
    {
        private int selectedPhaseId = 0;
        private int selectedTaskId = 0;
        private int selectedStageId = 0;

        public frmProjectPhases()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProjectPhases_Load(object sender, EventArgs e)
        {
            LoadPhaseTemplates();
            LoadPhaseTasks();
            LoadPhaseDropdown();
            LoadProjectDropdown();
        }

        private void LoadProjectDropdown()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        #region ================= PHASE TEMPLATE =================

        private void LoadPhaseTemplates()
        {
            dgvPhaseTemplates.DataSource = DBClass.ExecuteDataTable("SELECT * FROM tbl_project_phase_templates");

            dgvPhaseTemplates.Columns["template_id"].Visible = false;
            dgvPhaseTemplates.Columns["phase_no"].HeaderText = "Phase No";
            dgvPhaseTemplates.Columns["phase_name"].HeaderText = "Phase Name";
            dgvPhaseTemplates.Columns["sort_order"].HeaderText = "Sort Order";
            dgvPhaseTemplates.Columns["is_active"].HeaderText = "Active";

            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhaseTemplates);
        }

        private void btnSavePhase_Click(object sender, EventArgs e)
        {
            string query = selectedPhaseId == 0
                ? "INSERT INTO tbl_project_phase_templates (phase_no, phase_name, sort_order,is_active) VALUES (@no,@name,@order,@active)"
                : "UPDATE tbl_project_phase_templates SET phase_no=@no, phase_name=@name, sort_order=@order, is_active=@active WHERE template_id=@id";

            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@no", txtPhaseNo.Text),
                DBClass.CreateParameter("@name", txtPhaseName.Text),
                DBClass.CreateParameter("@order", txtPhaseOrder.Text),
                DBClass.CreateParameter("@active", chkPhaseActive.Checked),
                DBClass.CreateParameter("@id", selectedPhaseId)
            );

            ClearPhaseForm();
            LoadPhaseTemplates();
            LoadPhaseDropdown();
        }

        private void dgvPhaseTemplates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvPhaseTemplates.Rows[e.RowIndex];

            selectedPhaseId = Convert.ToInt32(row.Cells["template_id"].Value);
            txtPhaseNo.Text = row.Cells["phase_no"].Value.ToString();
            txtPhaseName.Text = row.Cells["phase_name"].Value.ToString();
            txtPhaseOrder.Text = row.Cells["sort_order"].Value.ToString();
            chkPhaseActive.Checked = Convert.ToBoolean(row.Cells["is_active"].Value);
        }

        private void ClearPhaseForm()
        {
            selectedPhaseId = 0;
            txtPhaseNo.Clear();
            txtPhaseName.Clear();
            txtPhaseOrder.Clear();
            chkPhaseActive.Checked = true;
        }

        #endregion

        #region ================= TASK TEMPLATE =================

        private void LoadPhaseDropdown()
        {
            cmbPhase.DataSource = DBClass.ExecuteDataTable(
                "SELECT template_id, phase_name FROM tbl_project_phase_templates ORDER BY sort_order");

            cmbPhase.DisplayMember = "phase_name";
            cmbPhase.ValueMember = "template_id";
        }

        private void LoadPhaseTasks()
        {
            dgvTasks.DataSource = DBClass.ExecuteDataTable(@"
            SELECT pptt.task_template_id,pptt.template_id,
                   ppt.phase_name,pptt.task_name,
                   pptt.sort_order,pptt.is_mandatory,pptt.is_active
            FROM tbl_project_phase_task_templates pptt
            INNER JOIN tbl_project_phase_templates ppt
                ON pptt.template_id = ppt.template_id");

            dgvTasks.Columns["task_template_id"].Visible = false;
            dgvTasks.Columns["template_id"].Visible = false;

            dgvTasks.Columns["phase_name"].AutoSizeMode =
            dgvTasks.Columns["task_name"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvTasks.Columns["phase_name"].HeaderText = "Phase Name";
            dgvTasks.Columns["task_name"].HeaderText = "Task Name";
            dgvTasks.Columns["sort_order"].HeaderText = "Sort Order";
            dgvTasks.Columns["is_mandatory"].HeaderText = "Mandatory";
            dgvTasks.Columns["is_active"].HeaderText = "Active";

            LocalizationManager.LocalizeDataGridViewHeaders(dgvTasks);
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            string query = selectedTaskId == 0
                ? @"INSERT INTO tbl_project_phase_task_templates 
               (template_id, task_name, sort_order, is_mandatory, is_active)
               VALUES (@phase,@name,@order,@mandatory,@active)"
                : @"UPDATE tbl_project_phase_task_templates 
               SET template_id=@phase, task_name=@name, sort_order=@order,
                   is_mandatory=@mandatory, is_active=@active
               WHERE task_template_id=@id";

            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@phase", cmbPhase.SelectedValue),
                DBClass.CreateParameter("@name", txtTaskName.Text),
                DBClass.CreateParameter("@order", txtTaskOrder.Text),
                DBClass.CreateParameter("@mandatory", chkMandatory.Checked ? 1 : 0),
                DBClass.CreateParameter("@active", chkTaskActive.Checked ? 1 : 0),
                DBClass.CreateParameter("@id", selectedTaskId)
            );

            ClearTaskForm();
            LoadPhaseTasks();
        }

        private void dgvTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvTasks.Rows[e.RowIndex];

            selectedTaskId = Convert.ToInt32(row.Cells["task_template_id"].Value);
            cmbPhase.SelectedValue = row.Cells["template_id"].Value;
            txtTaskName.Text = row.Cells["task_name"].Value.ToString();
            txtTaskOrder.Text = row.Cells["sort_order"].Value.ToString();
            chkMandatory.Checked = Convert.ToBoolean(row.Cells["is_mandatory"].Value);
            chkTaskActive.Checked = Convert.ToBoolean(row.Cells["is_active"].Value);
        }

        private void ClearTaskForm()
        {
            selectedTaskId = 0;
            txtTaskName.Clear();
            txtTaskOrder.Clear();
            chkMandatory.Checked = true;
            chkTaskActive.Checked = true;
        }

        #endregion


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbProject.Focused) return;

            LoadWorkflowData();
        }

        private void dgvPhases_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddWorkFlow_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            CreateDefaultProjectWorkflow(Convert.ToInt32(cmbProject.SelectedValue));

            MessageBox.Show("Project Workflow Created");

            LoadWorkflowData();
        }

        private void LoadWorkflowData()
        {
            dgvWorkflowPhases.Rows.Clear();
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
                    dgvWorkflowPhases.Rows.Add(
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

            dgvWorkflowPhases.Columns["phase_id"].Visible = dgvWorkflowPhases.Columns["template_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvWorkflowPhases);
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
    }
}
