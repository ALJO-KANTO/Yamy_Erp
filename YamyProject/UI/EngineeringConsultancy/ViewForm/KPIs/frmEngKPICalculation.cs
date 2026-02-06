using MySql.Data.MySqlClient;
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
    public partial class frmEngKPICalculation : Form
    {
        public frmEngKPICalculation()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEngKPICalculation_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateEmployees(cmbEmployee);
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";

            cmbMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray());
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            // Set range first
            numYear.Minimum = 2000; // or whatever makes sense
            numYear.Maximum = 2100;

            numYear.Value = DateTime.Now.Year;

            LoadLog();
            if (frmLogin.userRole.ToLower() == "employee")
            {
                cmbEmployee.Enabled = false;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex + 1;
            int year = (int)numYear.Value;

            if (IsPeriodLocked(month, year))
            {
                MessageBox.Show("This KPI period is locked.");
                return;
            }

            CalculateKPIs(month, year);

            lblStatus.Text = $"KPIs calculated for {cmbMonth.Text} {year}";
            LoadLog();
        }

        private void CalculateKPIs(int month, int year)
        {
            if(string.IsNullOrEmpty(txtActual.Text) || string.IsNullOrEmpty(txtTarget.Text))
            {
                MessageBox.Show("Please enter both Actual and Target values.");
                return;
            }
            decimal actualValue = Convert.ToDecimal(txtActual.Text);
            decimal targetValue = Convert.ToDecimal(txtTarget.Text);
            decimal score = CalculateKpiScore(calcMethod, actualValue, targetValue);

            DBClass.ExecuteNonQuery(
            @"INSERT INTO tbl_kpi_results(kpi_id, employee_id, period_month, period_year, actual_value, score, calculated_at)
                VALUES
                (@kpiId, @empId, @month, @year, @actual, @score, NOW())",
            DBClass.CreateParameter("@kpiId", kpiId),
            DBClass.CreateParameter("@empId", cmbEmployee.SelectedValue),
            DBClass.CreateParameter("@month", month),
            DBClass.CreateParameter("@year", year),
            DBClass.CreateParameter("@actual", actualValue.ToString("N2")),
            DBClass.CreateParameter("@score", score.ToString("N2"))
            );

        }
        decimal CalculateKpiScore(string method, decimal actual, decimal target)
        {
            if (target == 0) return 0;

            switch (method)
            {
                case "PERCENTAGE":
                    return (actual / target) * 100;

                case "RATIO":
                    return actual == 0 ? 0 : (target / actual) * 100;

                case "SCORE":
                    return actual; // already scored (e.g. 1–10)

                case "AMOUNT":
                    return (actual / target) * 100;

                default:
                    return 0;
            }
        }

        private void btnLockPeriod_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex + 1;
            int year = (int)numYear.Value;

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_kpi_periods (period_month, period_year, is_locked, locked_at)
                  VALUES (@m,@y,1,NOW())
                  ON DUPLICATE KEY UPDATE is_locked=1, locked_at=NOW()",
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            lblStatus.Text = "KPI period locked.";
        }

        private bool IsPeriodLocked(int month, int year)
        {
            object val = DBClass.ExecuteScalar(
                @"SELECT is_locked FROM tbl_kpi_periods
                WHERE period_month=@m AND period_year=@y",
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            return val != null && Convert.ToBoolean(val);
        }

        private void LoadLog()
        {
            dgvLog.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader(
                @"SELECT k.employee_id,e.name `Employee Name`, k.KPI_Name, k.kpi_id, k.target_value,k.weight,k.EvaluationPeriod,k.calculation_method
                  FROM tbl_kpi_master k
                  JOIN tbl_employee e ON e.id=k.employee_id where k.employee_id=@empId
                  ORDER BY e.name", DBClass.CreateParameter("@empId", cmbEmployee.SelectedValue)))
            {
                while (reader.Read())
                {
                    dgvLog.Rows.Add(
                        reader["employee_id"],
                        reader["Employee Name"],
                        reader["KPI_Name"],
                        reader["kpi_id"],
                        reader["target_value"],
                        reader["weight"],
                        reader["EvaluationPeriod"],
                        reader["calculation_method"]
                        );
                }
            }

                LocalizationManager.LocalizeDataGridViewHeaders(dgvLog);
        }

        private void dgvLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLog.Rows[e.RowIndex];
                // Handle cell click event, e.g., show details
                kpiId = Convert.ToInt32(row.Cells["kpi_id"].Value);
                txtTarget.Text = Convert.ToDecimal(row.Cells["target_value"].Value).ToString("N2");
                calcMethod = row.Cells["calculate_method"].Value.ToString();
            }
        }
        int kpiId;
        string calcMethod;
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLog();
        }
    }
}
