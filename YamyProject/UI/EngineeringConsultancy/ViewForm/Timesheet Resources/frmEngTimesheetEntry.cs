using Mysqlx.Crud;
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
    public partial class frmEngTimesheetEntry : Form
    {
        public int TimesheetId { get; set; } = 0; // 0 = new entry
        public int ProjectId { get; set; }
        public int PhaseId { get; set; }
        public int MilestoneId { get; set; }
        public int EmployeeId { get; set; }
        public frmEngTimesheetEntry()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmTimesheetEntry_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadPhases();
            LoadMilestones();
            LoadEmployee();

            if (TimesheetId != 0)
                LoadTimesheetData();
        }

        private void LoadEmployee()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_employee ORDER BY name");
            cmbEmployee.DataSource = dt;
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";
            cmbEmployee.SelectedValue = EmployeeId;
        }

        private void LoadProjects()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DataSource = dt;
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedValue = ProjectId;
        }

        private void LoadPhases()
        {
            if (ProjectId == 0) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT phase_id, phase_name FROM tbl_eng_project_phases WHERE project_id=@pid",
                DBClass.CreateParameter("@pid", ProjectId));
            cmbPhase.DataSource = dt;
            cmbPhase.DisplayMember = "phase_name";
            cmbPhase.ValueMember = "phase_id";
            cmbPhase.SelectedValue = PhaseId;
        }

        private void LoadMilestones()
        {
            if (PhaseId == 0) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT milestone_id, milestone_name FROM tbl_eng_project_milestones WHERE phase_id=@ph",
                DBClass.CreateParameter("@ph", PhaseId));
            cmbMilestone.DataSource = dt;
            cmbMilestone.DisplayMember = "milestone_name";
            cmbMilestone.ValueMember = "milestone_id";
            cmbMilestone.SelectedValue = MilestoneId;
        }

        private void LoadTimesheetData()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT work_date, hours, is_billable, remarks FROM tbl_eng_timesheets WHERE timesheet_id=@id",
                DBClass.CreateParameter("@id", TimesheetId));

            if (dt.Rows.Count == 0) return;

            dtWorkDate.Value = Convert.ToDateTime(dt.Rows[0]["work_date"]);
            numHours.Value = Convert.ToDecimal(dt.Rows[0]["hours"]);
            chkBillable.Checked = Convert.ToBoolean(dt.Rows[0]["is_billable"]);
            txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedIndex == -1 || cmbPhase.SelectedIndex == -1 ||
                cmbMilestone.SelectedIndex == -1)
            {
                MessageBox.Show("Please select project, phase, and milestone.");
                return;
            }
            if (cmbEmployee.SelectedIndex >= 0)
            {
                EmployeeId = int.Parse(cmbEmployee.SelectedValue.ToString());
            }

            if (numHours.Value <= 0)
            {
                MessageBox.Show("Hours must be greater than 0.");
                return;
            }

            if (TimesheetId == 0)
            {
                // INSERT
                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_eng_timesheets 
                        (project_id, phase_id, milestone_id, employee_id, work_date, hours, is_billable, remarks)
                      VALUES
                        (@pid, @ph, @mid, @eid, @date, @hours, @billable, @remarks)",
                    DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@ph", cmbPhase.SelectedValue),
                    DBClass.CreateParameter("@mid", cmbMilestone.SelectedValue),
                    DBClass.CreateParameter("@eid", EmployeeId),
                    DBClass.CreateParameter("@date", dtWorkDate.Value.Date),
                    DBClass.CreateParameter("@hours", numHours.Value),
                    DBClass.CreateParameter("@billable", chkBillable.Checked ? 1 : 0),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text)
                );
            }
            else
            {
                // UPDATE
                DBClass.ExecuteNonQuery(
                    @"UPDATE tbl_eng_timesheets SET
                        project_id=@pid,
                        phase_id=@ph,
                        milestone_id=@mid,
                        work_date=@date,
                        hours=@hours,
                        is_billable=@billable,
                        remarks=@remarks
                      WHERE timesheet_id=@id",
                    DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@ph", cmbPhase.SelectedValue),
                    DBClass.CreateParameter("@mid", cmbMilestone.SelectedValue),
                    DBClass.CreateParameter("@date", dtWorkDate.Value.Date),
                    DBClass.CreateParameter("@hours", numHours.Value),
                    DBClass.CreateParameter("@billable", chkBillable.Checked ? 1 : 0),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@id", TimesheetId)
                );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbProject.Focused)
                return;

            ProjectId = int.Parse(cmbProject.SelectedValue.ToString());
            LoadPhases();
        }

        private void cmbMilestone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbMilestone.Focused)
                return;

            MilestoneId = int.Parse(cmbMilestone.SelectedValue.ToString());
            LoadTimesheetData();
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbPhase.Focused)
                return;

            PhaseId = int.Parse(cmbPhase.SelectedValue.ToString());
            LoadMilestones();
        }
    }
}
