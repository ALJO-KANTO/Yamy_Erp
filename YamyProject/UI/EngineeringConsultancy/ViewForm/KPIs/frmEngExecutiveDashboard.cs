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
    public partial class frmEngExecutiveDashboard : Form
    {
        public frmEngExecutiveDashboard()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngExecutiveDashboard_Load(object sender, EventArgs e)
        {
            if (frmLogin.userRole.ToLower() == "engineer" || frmLogin.userRole.ToLower() == "employee")
            {
                MessageBox.Show("Access Denied. Executive Dashboard is only for Managers, HR, and Admin.");
                this.Close();
                return;
            }

            for (int y = DateTime.Now.Year - 5; y <= DateTime.Now.Year; y++)
                cmbYear.Items.Add(y);

            cmbYear.SelectedItem = DateTime.Now.Year;
            LoadDashboard();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }
        private void LoadDashboard()
        {
            LoadSummary();
            LoadKPITrend();
            LoadTopBottomEngineers();
        }
        private void LoadSummary()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT 
                    ROUND(AVG(score),2) AS avg_kpi
                  FROM tbl_kpi_results
                  WHERE period_year=@y",
                DBClass.CreateParameter("@y", cmbYear.SelectedItem)
            );

            lblAvgKPI.Text = dt.Rows[0]["avg_kpi"] + " %";

            DataTable fin = DBClass.ExecuteDataTable(
                @"SELECT 
                IFNULL(SUM(r.recognized_amount),0) AS revenue,
                IFNULL(SUM(c.actual_cost),0) AS cost
              FROM tbl_eng_project_revenue r
              LEFT JOIN tbl_eng_project_costing c ON c.project_id=r.project_id
                  WHERE YEAR(r.recognition_date) = @y
                     OR YEAR(c.cost_date) = @y",
                DBClass.CreateParameter("@y", cmbYear.SelectedItem)
            );

            decimal revenue = Convert.ToDecimal(fin.Rows[0]["revenue"]);
            decimal cost = Convert.ToDecimal(fin.Rows[0]["cost"]);

            lblRevenue.Text = revenue.ToString("N2");
            lblCost.Text = cost.ToString("N2");
            lblProfit.Text = (revenue - cost).ToString("N2");
        }
        private void LoadKPITrend()
        {
            dgvKPITrend.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                    period_month AS Month,
                    ROUND(AVG(score),2) AS AvgScore
                  FROM tbl_kpi_results
                  WHERE period_year=@y
                  GROUP BY period_month
                  ORDER BY period_month",
                DBClass.CreateParameter("@y", cmbYear.SelectedItem)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKPITrend);
        }
        private void LoadTopBottomEngineers()
        {
            dgvTopEngineers.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                    e.name `Employee Name`,
                    ROUND(AVG(r.score),2) AS Score
                  FROM tbl_kpi_results r
                  JOIN tbl_employee e ON e.id=r.employee_id
                  WHERE r.period_year=@y
                  GROUP BY e.id
                  ORDER BY Score DESC
                  LIMIT 5",
                DBClass.CreateParameter("@y", cmbYear.SelectedItem)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvTopEngineers);

            dgvBottomEngineers.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                    e.name `Employee Name`,
                    ROUND(AVG(r.score),2) AS Score
                  FROM tbl_kpi_results r
                  JOIN tbl_employee e ON e.id=r.employee_id
                  WHERE r.period_year=@y
                  GROUP BY e.id
                  ORDER BY Score ASC
                  LIMIT 5",
                DBClass.CreateParameter("@y", cmbYear.SelectedItem)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvBottomEngineers);
        }

    }
}
