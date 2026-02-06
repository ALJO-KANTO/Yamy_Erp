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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    public partial class frmEngExecutiveDashboardOld : Form
    {
        public frmEngExecutiveDashboardOld()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngExecutiveDashboard_Load(object sender, EventArgs e)
        {
            LoadSummary();
            LoadProjectSummary();
            LoadPendingApprovals();
        }

        private void LoadSummary()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT 
                    COUNT(*) AS TotalProjects,
                    IFNULL(SUM(r.recognized_amount),0) AS Revenue,
                    IFNULL(SUM(c.actual_cost),0) AS Cost
                  FROM tbl_projects p
                  LEFT JOIN tbl_eng_project_revenue r ON r.project_id = p.id
                  LEFT JOIN tbl_eng_project_costing c ON c.project_id = p.id"
            );

            decimal revenue = Convert.ToDecimal(dt.Rows[0]["Revenue"]);
            decimal cost = Convert.ToDecimal(dt.Rows[0]["Cost"]);
            decimal profit = revenue - cost;
            decimal margin = revenue == 0 ? 0 : (profit / revenue) * 100;

            lblProjects.Text = $"Projects: {dt.Rows[0]["TotalProjects"]}";
            lblRevenue.Text = $"Revenue: {revenue:N2}";
            lblCost.Text = $"Cost: {cost:N2}";
            lblProfit.Text = $"Profit: {profit:N2}";
            lblMargin.Text = $"Margin: {margin:N2} %";
        }

        private void LoadProjectSummary()
        {
            dgvProjectSummary.DataSource = DBClass.ExecuteDataTable(
                @"SELECT p.name AS Project,
                         IFNULL(SUM(c.actual_cost),0) AS Cost,
                         IFNULL(SUM(r.recognized_amount),0) AS Revenue,
                         (IFNULL(SUM(r.recognized_amount),0)-IFNULL(SUM(c.actual_cost),0)) AS Profit,
                         CASE WHEN IFNULL(SUM(r.recognized_amount),0)=0 THEN 0 ELSE
                             (IFNULL(SUM(r.recognized_amount),0)-IFNULL(SUM(c.actual_cost),0))/IFNULL(SUM(r.recognized_amount),0)*100 END AS MarginPercent
                  FROM tbl_projects p
                  LEFT JOIN tbl_eng_project_costing c ON c.project_id = p.id
                  LEFT JOIN tbl_eng_project_revenue r ON r.project_id = p.id
                  GROUP BY p.name"
            );
        }

        private void LoadPendingApprovals()
        {
            dgvPendingApprovals.DataSource = DBClass.ExecuteDataTable(
                @"SELECT d.document_name, p.name AS Project, r.revised_date, r.status
                  FROM tbl_eng_design_revisions r
                  JOIN tbl_eng_design_documents d ON d.document_id = r.document_id
                  JOIN tbl_projects p ON p.id = d.project_id
                  WHERE r.status='Pending'"
            );
        }
    }
}
