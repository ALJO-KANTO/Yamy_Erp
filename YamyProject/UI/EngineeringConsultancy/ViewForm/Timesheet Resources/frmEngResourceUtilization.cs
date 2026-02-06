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
    public partial class frmEngResourceUtilization : Form
    {
        public frmEngResourceUtilization()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmResourceUtilization_Load(object sender, EventArgs e)
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

        private void LoadUtilization()
        {
            if (cmbProject.SelectedIndex == -1) return;

            string sql = @"
                SELECT 
                    e.id,
                    e.name AS engineer,
                    IFNULL(SUM(t.hours),0) AS total_hours,
                    IFNULL(SUM(CASE WHEN t.is_billable=1 THEN t.hours ELSE 0 END),0) AS billable_hours,
                    IFNULL(SUM(CASE WHEN t.is_billable=0 THEN t.hours ELSE 0 END),0) AS non_billable_hours
                FROM tbl_employee e
                LEFT JOIN tbl_eng_timesheets t 
                    ON t.employee_id = e.id
                    AND t.project_id = @pid
                    AND (@ph IS NULL OR t.phase_id = @ph)
                    AND (@mid IS NULL OR t.milestone_id = @mid)
                    AND t.is_approved=1
                WHERE e.SRole='Engineer'
                GROUP BY e.id, e.name
                ORDER BY e.name";

            object phValue = cmbPhase.SelectedIndex == -1 ? DBNull.Value : cmbPhase.SelectedValue;
            object midValue = cmbMilestone.SelectedIndex == -1 ? DBNull.Value : cmbMilestone.SelectedValue;

            DataTable dt = DBClass.ExecuteDataTable(
                sql,
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                DBClass.CreateParameter("@ph", phValue),
                DBClass.CreateParameter("@mid", midValue)
            );

            dgvUtilization.DataSource = dt;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvUtilization);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadUtilization();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            dgvUtilization.DataSource = null;
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMilestones();
            dgvUtilization.DataSource = null;
        }

        private void cmbMilestone_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUtilization.DataSource = null;
        }
    }
}
