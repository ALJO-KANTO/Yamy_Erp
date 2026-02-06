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
    public partial class frmEngProductivityReport : Form
    {
        public frmEngProductivityReport()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProductivityReport_Load(object sender, EventArgs e)
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

        private void LoadProductivity()
        {
            if (cmbProject.SelectedIndex == -1) return;

            string sql = @"
                        SELECT e.name AS engineer,
                               IFNULL(SUM(t.hours), 0) AS total_hours,
                               IFNULL(SUM(CASE WHEN t.is_billable = 1 THEN t.hours ELSE 0 END), 0) AS billable_hours,
                               COUNT(DISTINCT d.deliverable_id) AS deliverables_completed,
                               IFNULL(SUM(t.hours) / NULLIF(COUNT(DISTINCT d.deliverable_id), 0),0) AS hours_per_deliverable
                        FROM tbl_employee e
                        LEFT JOIN tbl_eng_timesheets t 
                            ON t.employee_id = e.id
                            AND t.project_id = @pid
                            AND t.is_approved = 1
                            AND (@ph IS NULL OR t.phase_id=@ph)
                            AND (@mid IS NULL OR t.milestone_id=@mid)
                        LEFT JOIN tbl_eng_project_milestones m
                            ON (@mid IS NULL OR m.milestone_id=@mid)
                            AND (@ph IS NULL OR m.phase_id=@ph)
                        LEFT JOIN tbl_eng_project_deliverables d
                            ON d.milestone_id = m.milestone_id AND d.status='Completed'
                        WHERE e.sRole='Engineer'
                        AND (
                            @role IN ('HR','Admin')
                         OR (@role='Manager')
                         OR (@role='Engineer')
                        )
                        GROUP BY e.id, e.name
                        ORDER BY e.name;
                        ";

            object phValue = cmbPhase.SelectedIndex == -1 ? DBNull.Value : cmbPhase.SelectedValue;
            object midValue = cmbMilestone.SelectedIndex == -1 ? DBNull.Value : cmbMilestone.SelectedValue;

            DataTable dt = DBClass.ExecuteDataTable(
                sql,
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                DBClass.CreateParameter("@ph", phValue),
                DBClass.CreateParameter("@mid", midValue),
                DBClass.CreateParameter("@uid", frmLogin.userId),
                DBClass.CreateParameter("@role", frmLogin.userRole)
            );

            dgvProductivity.DataSource = dt;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProductivity);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductivity();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvProductivity.DataSource == null) 
                return;

            CommonExport.ExportToExcel((DataTable)dgvProductivity.DataSource, "ProductivityReport");
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            dgvProductivity.DataSource = null;
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMilestones();
            dgvProductivity.DataSource = null;
        }

        private void cmbMilestone_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProductivity.DataSource = null;
        }
    }
}
