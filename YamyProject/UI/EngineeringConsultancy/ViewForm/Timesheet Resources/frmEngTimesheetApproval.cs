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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources
{
    public partial class frmEngTimesheetApproval : Form
    {
        public frmEngTimesheetApproval()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmTimesheetApproval_Load(object sender, EventArgs e)
        {
            LoadProjects();
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

        private void LoadMilestones()
        {
            if (cmbPhase.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT milestone_id, milestone_name FROM tbl_eng_project_milestones WHERE phase_id=@ph",
                DBClass.CreateParameter("@ph", cmbPhase.SelectedValue));

            cmbMilestone.DataSource = dt;
            cmbMilestone.DisplayMember = "milestone_name";
            cmbMilestone.ValueMember = "milestone_id";
            cmbMilestone.SelectedIndex = -1;
        }

        private void LoadTimesheets()
        {
            if (cmbProject.SelectedIndex == -1 || cmbPhase.SelectedIndex == -1 ||
                cmbMilestone.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT t.timesheet_id, e.name AS engineer, t.work_date, t.hours, t.is_billable, t.is_approved, t.remarks
                  FROM tbl_eng_timesheets t
                  JOIN tbl_employee e ON e.id = t.employee_id
                  WHERE t.project_id=@pid AND t.phase_id=@ph AND t.milestone_id=@mid
                  ORDER BY t.work_date",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                DBClass.CreateParameter("@ph", cmbPhase.SelectedValue),
                DBClass.CreateParameter("@mid", cmbMilestone.SelectedValue)
            );

            dgvTimesheets.DataSource = dt;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvTimesheets);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadTimesheets();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvTimesheets.SelectedRows.Count == 0) return;

            foreach (DataGridViewRow row in dgvTimesheets.SelectedRows)
            {
                int tsId = Convert.ToInt32(row.Cells["timesheet_id"].Value);
                DBClass.ExecuteNonQuery(
                    "UPDATE tbl_eng_timesheets SET is_approved=1, approved_by=@user, approved_date=NOW() WHERE timesheet_id=@id",
                    DBClass.CreateParameter("@user", frmLogin.userId),
                    DBClass.CreateParameter("@id", tsId)
                );
            }

            LoadTimesheets();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvTimesheets.SelectedRows.Count == 0) return;

            foreach (DataGridViewRow row in dgvTimesheets.SelectedRows)
            {
                int tsId = Convert.ToInt32(row.Cells["timesheet_id"].Value);
                DBClass.ExecuteNonQuery(
                    "UPDATE tbl_eng_timesheets SET is_approved=0, approved_by=NULL, approved_date=NULL WHERE timesheet_id=@id",
                    DBClass.CreateParameter("@id", tsId)
                );
            }

            LoadTimesheets();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTimesheets();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            dgvTimesheets.DataSource = null;
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMilestones();
            dgvTimesheets.DataSource = null;
        }

        private void cmbMilestone_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimesheets();
        }
    }
}
