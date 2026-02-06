using PdfSharp.Pdf.Content.Objects;
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
    public partial class frmEngProjectDashboard : Form
    {
        public frmEngProjectDashboard()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngProjectDashboard_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            DataTable dt = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects ORDER BY name");

            cmbProject.DataSource = dt;
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedIndex == -1) return;

            LoadSummary();          // ← only this changes internally
            LoadPhaseProgress();
            LoadMilestones();
        }

        private void LoadPhaseProgress()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT phase_name, weight_percentage, status
                  FROM tbl_eng_project_phases
                  WHERE project_id = @pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            dgvPhaseProgress.DataSource = dt;

            dgvPhaseProgress.Columns["phase_name"].HeaderText = "Phase Name";
            dgvPhaseProgress.Columns["weight_percentage"].HeaderText = "Weight %";
            dgvPhaseProgress.Columns["status"].HeaderText = "status";

            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhaseProgress);
        }

        private void LoadMilestones()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT m.milestone_name, m.status, m.progress_percent
                  FROM tbl_eng_project_milestones m
                  JOIN tbl_eng_project_phases p ON p.phase_id = m.phase_id
                  WHERE p.project_id = @pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            dgvMilestoneStatus.DataSource = dt;

            dgvMilestoneStatus.Columns["milestone_name"].HeaderText = "Milestone Name";
            dgvMilestoneStatus.Columns["progress_percent"].HeaderText = "progress %";
            dgvMilestoneStatus.Columns["status"].HeaderText = "status";

            LocalizationManager.LocalizeDataGridViewHeaders(dgvMilestoneStatus);
        }
        private void LoadSummary()
        {
            //DataTable dt = DBClass.ExecuteDataTable(
            //    @"SELECT
            //            0 contract_value,

            //            /* Phase-based progress */
            //            IFNULL(SUM(
            //                CASE 
            //                    WHEN ph.status = 'Completed' 
            //                    THEN ph.weight_percentage 
            //                    ELSE 0 
            //                END
            //            ), 0) AS progress,

            //            /* Milestone progress */
            //            IFNULL(AVG(m.progress_percent), 0) AS milestone_progress,

            //            /* Deliverables approved */
            //            SUM(CASE WHEN d.status = 'Approved' THEN 1 ELSE 0 END) AS approved_deliverables,
            //            COUNT(d.deliverable_id) AS total_deliverables

            //  FROM tbl_projects p
            //  LEFT JOIN tbl_eng_project_phases ph 
            //         ON ph.project_id = p.id
            //  LEFT JOIN tbl_eng_project_milestones m 
            //         ON m.phase_id = ph.phase_id
            //  LEFT JOIN tbl_eng_project_deliverables d 
            //         ON d.milestone_id = m.milestone_id
            //  WHERE p.id = @pid
            //  -- GROUP BY p.contract_value",
            //    DBClass.CreateParameter("@pid", cmbProject.SelectedValue)
            //);
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT 
                    IFNULL(SUM(c.planned_cost),0) AS budget,
                    IFNULL(SUM(c.actual_cost),0) AS cost,
                    IFNULL(SUM(r.recognized_amount),0) AS revenue,
                    CASE 
                        WHEN IFNULL(SUM(c.planned_cost),0) = 0 THEN 0
                        ELSE IFNULL(ROUND(SUM(r.recognized_amount)/SUM(c.planned_cost)*100,2),0)
                    END AS progress
                  FROM tbl_eng_project_costing c
                  LEFT JOIN tbl_eng_project_revenue r 
                    ON r.project_id = c.project_id
                  WHERE c.project_id = @pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue)
            );

            //DataTable dt = DBClass.ExecuteDataTable(
            //    @"SELECT 
            //        IFNULL(SUM(weight_percentage),0) AS progress,
            //        IFNULL(SUM(budget_amount),0) AS budget,
            //        IFNULL(SUM(actual_cost),0) AS cost,
            //        IFNULL(SUM(revenue_amount),0) AS revenue
            //      FROM eng_project_financials
            //      WHERE project_id=@pid",
            //    DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            if (dt.Rows.Count == 0) return;

            decimal progress = Convert.ToDecimal(dt.Rows[0]["progress"]);
            decimal contractValue = Convert.ToDecimal(dt.Rows[0]["budget"]);
            int approved = 0; // Convert.ToInt32(dt.Rows[0]["approved_deliverables"]);
            int total = 0; // Convert.ToInt32(dt.Rows[0]["total_deliverables"]);

            lblProgressValue.Text = progress.ToString("0.##") + " %";
            lblBudgetValue.Text = contractValue.ToString("N2");

            // Phase-1 ERP: cost & revenue not calculated yet
            lblCostValue.Text = Convert.ToDecimal(dt.Rows[0]["cost"]).ToString("N2");
            lblRevenueValue.Text = Convert.ToDecimal(dt.Rows[0]["revenue"]).ToString("N2");

            // Optional (if you add labels later)
            // lblDeliverablesValue.Text = $"{approved}/{total}";
        }
    }
}
