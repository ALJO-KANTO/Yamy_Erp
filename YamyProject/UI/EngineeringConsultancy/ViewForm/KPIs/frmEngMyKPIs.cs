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
    public partial class frmEngMyKPIs : Form
    {
        public frmEngMyKPIs()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngMyKPIs_Load(object sender, EventArgs e)
        {
            cmbMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray());
            
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = DateTime.Now.Year;

            LoadMyKPIs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMyKPIs();
        }
        private void LoadMyKPIs()
        {
            int month = cmbMonth.SelectedIndex + 1;
            int year = (int)numYear.Value;
            int empId = frmLogin.userId; // current employee

            LoadKpiDetails(empId, month, year);
            LoadOverallScore(empId, month, year);
            LoadStrengthWeakness(empId, month, year);
        }
        private void LoadKpiDetails(int empId, int month, int year)
        {
            dgvKpiDetails.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                      k.kpi_name AS KPI,
                      r.actual_value AS Actual,
                      k.target_value AS Target,
                      r.score AS Score
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master k ON k.kpi_id = r.kpi_id
                  WHERE r.employee_id=@emp
                    AND r.period_month=@m
                    AND r.period_year=@y",
                DBClass.CreateParameter("@emp", empId),
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKpiDetails);
        }
        private void LoadOverallScore(int empId, int month, int year)
        {
            object val = DBClass.ExecuteScalar(
                @"SELECT 
                    IFNULL(SUM(r.score * k.weight) / NULLIF(SUM(k.weight),0),0)
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master k ON k.kpi_id=r.kpi_id
                  WHERE r.employee_id=@emp
                    AND r.period_month=@m
                    AND r.period_year=@y",
                DBClass.CreateParameter("@emp", empId),
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            lblOverallScore.Text = $"Overall KPI Score: {Convert.ToDecimal(val):0.00}%";
        }
        private void LoadStrengthWeakness(int empId, int month, int year)
        {
            dgvStrengthWeakness.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                      k.kpi_name AS KPI,
                      CASE 
                        WHEN r.score >= 100 THEN 'Strength'
                        WHEN r.score >= 80 THEN 'Good'
                        ELSE 'Needs Improvement'
                      END AS Status
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master k ON k.kpi_id=r.kpi_id
                  WHERE r.employee_id=@emp
                    AND r.period_month=@m
                    AND r.period_year=@y
                  ORDER BY r.score DESC",
                DBClass.CreateParameter("@emp", empId),
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvStrengthWeakness);
        }

    }
}
