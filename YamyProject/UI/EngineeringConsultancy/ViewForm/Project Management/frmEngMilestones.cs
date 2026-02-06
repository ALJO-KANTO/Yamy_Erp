using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmEngMilestones : Form
    {
        int milestoneId = 0;

        public frmEngMilestones()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngMilestones_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadStatus();
            ClearForm();
        }
        private void LoadProjects()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects ORDER BY name");

            cmbProject.DataSource = dt;
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void LoadPhases()
        {
            if (cmbProject.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT phase_id, phase_name FROM tbl_eng_project_phases WHERE project_id=@pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            cmbPhase.DataSource = dt;
            cmbPhase.DisplayMember = "phase_name";
            cmbPhase.ValueMember = "phase_id";
            cmbPhase.SelectedIndex = -1;
        }

        private void LoadStatus()
        {
            cmbStatus.Items.AddRange(new string[]
            {
                "Planned", "In Progress", "Completed", "Approved"
            });
        }

        private void LoadMilestones()
        {
            if (cmbPhase.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT milestone_id, milestone_name Milestone, due_date DueDate, progress_percent Progress, status Status
                  FROM tbl_eng_project_milestones
                  WHERE phase_id=@pid",
                DBClass.CreateParameter("@pid", cmbPhase.SelectedValue));

            dgvMilestones.DataSource = dt;
            dgvMilestones.Columns["milestone_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvMilestones);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_project_milestones
                  (phase_id, milestone_name, due_date, progress_percent, status)
                  VALUES (@phase, @name, @date, @percent, @status)",
                DBClass.CreateParameter("@phase", cmbPhase.SelectedValue),
                DBClass.CreateParameter("@name", txtMilestone.Text.Trim()),
                DBClass.CreateParameter("@date", dtDueDate.Value.Date),
                DBClass.CreateParameter("@percent", numPercent.Value),
                DBClass.CreateParameter("@status", cmbStatus.Text));

            LoadMilestones();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (milestoneId == 0 || !ValidateForm()) return;

            DBClass.ExecuteNonQuery(
                @"UPDATE tbl_eng_project_milestones SET
                    milestone_name=@name,
                    due_date=@date,
                    progress_percent=@percent,
                    status=@status
                  WHERE milestone_id=@id",
                DBClass.CreateParameter("@name", txtMilestone.Text.Trim()),
                DBClass.CreateParameter("@date", dtDueDate.Value.Date),
                DBClass.CreateParameter("@percent", numPercent.Value),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@id", milestoneId));

            LoadMilestones();
            ClearForm();
        }

        private void dgvMilestones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMilestones.Rows[e.RowIndex];
            milestoneId = Convert.ToInt32(row.Cells["milestone_id"].Value);
            txtMilestone.Text = row.Cells["milestone"].Value.ToString();
            dtDueDate.Value = Convert.ToDateTime(row.Cells["dueDate"].Value);
            numPercent.Value = Convert.ToDecimal(row.Cells["progress"].Value);
            cmbStatus.Text = row.Cells["status"].Value.ToString();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            dgvMilestones.DataSource = null;
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMilestones();
        }

        private bool ValidateForm()
        {
            if (cmbProject.SelectedIndex == -1 ||
                cmbPhase.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtMilestone.Text))
            {
                MessageBox.Show("All fields are required.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtMilestone.Clear();
            numPercent.Value = 0;
            cmbStatus.SelectedIndex = -1;
            milestoneId = 0;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
