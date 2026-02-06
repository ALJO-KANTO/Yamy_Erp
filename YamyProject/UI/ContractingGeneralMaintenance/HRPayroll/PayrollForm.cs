using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.HRPayroll
{
    public partial class PayrollForm : Form
    {
        int eId;
        public PayrollForm(int _eId = 0)
        {
            InitializeComponent();
            this.eId = _eId;
        }

        private void PayrollForm_Load(object sender, EventArgs e)
        {
            Years();
            BindMonths();
            cmbMonth.SelectedItem = DateTime.Now.Month.ToString("D2");
            cmbYear.SelectedItem = DateTime.Now.Year.ToString();

            if (eId > 0)
            {
                LoadData();
            }
        }
        private void BindMonths()
        {
            for (int month = 1; month <= 12; month++)
            {
                cmbMonth.Items.Add(month.ToString("D2")); // "01", "02", ..., "12"
            }
        }
        private void Years()
        {
            for (int year = 2000; year <= 2050; year++)
            {
                cmbYear.Items.Add(year.ToString());
            }
        }

        private void LoadData()
        {
            if (cmbMonth.SelectedItem == null || cmbYear.SelectedItem == null)
            {
                MessageBox.Show("Please select both Month and Year.");

                return;
            }
            string selectedMonthName = cmbMonth.SelectedItem.ToString();
            int selectedYear = int.Parse(cmbYear.SelectedItem.ToString());
            int selectedMonth = int.Parse(selectedMonthName);

            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_employee WHERE id =@id", DBClass.CreateParameter("@id", eId)))
            {
                if (reader.Read())
                {
                    string empCode = reader["code"].ToString();
                    lblName.Text = reader["name"].ToString();
                    //basic salary, over time, deductions, net salary
                    using (MySqlDataReader areader = DBClass.ExecuteReader(
                    "SELECT * FROM tbl_attendancesheet WHERE YEAR(WorkDate) = @year AND MONTH(WorkDate) = @month AND code = @id",
                    DBClass.CreateParameter("year", selectedYear),
                    DBClass.CreateParameter("month", selectedMonth),
                    DBClass.CreateParameter("id", empCode)))
                    {
                        if (areader.Read())
                        {
                            decimal allowance = decimal.Parse(reader["HousingAllowance"].ToString()) + decimal.Parse(reader["TransportationAllowance"].ToString());
                            decimal other = decimal.Parse(reader["Other"].ToString());
                            decimal totalBasicSalary = decimal.Parse(reader["basicSalary"].ToString());

                            int absDays = GetAbsenceDays(empCode, selectedYear, selectedMonth);
                            decimal totalLoan = GetTotalLoan(empCode, selectedYear, selectedMonth);
                            decimal totalDelay = GetTotalDelay(empCode, selectedYear, selectedMonth);
                            decimal totalWorkAbsence = GetTotalAbsence(empCode, selectedYear, selectedMonth);
                            int ref_Id = int.Parse(areader["Ref_Code"].ToString());
                            decimal additions = GetSalaryAdjustment(empCode, ref_Id, "Additions");
                            decimal salik = GetSalaryAdjustment(empCode, ref_Id, "Salik");
                            decimal otherDedactions = GetSalaryAdjustment(empCode, ref_Id, "othersDeductions");

                            decimal totalEarnings = totalBasicSalary + allowance + other + additions;
                            decimal totalDeductions = totalLoan + totalDelay + totalWorkAbsence + salik + otherDedactions;
                            decimal netSalary = totalEarnings - totalDeductions;

                            txtBasic.Text = totalBasicSalary.ToString("0.00");
                            txtOvertime.Text = (allowance + other + additions).ToString("0.00");
                            txtDeductions.Text = totalDeductions.ToString("0.00");
                            txtNet.Text = netSalary.ToString("0.00");

                        }
                    }
                }
            }
        }
        private int GetAbsenceDays(string empCode, int year, int month)
        {
            string query = @"SELECT COUNT(attendance_salary_id) AS count FROM tbl_attendancesheet WHERE YEAR(WorkDate) = @year AND MONTH(WorkDate) = @month AND attendance_salary_id = @code AND status = 'A'";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query,
                DBClass.CreateParameter("year", year),
                DBClass.CreateParameter("month", month),
                DBClass.CreateParameter("code", empCode)))
            {
                return reader.Read() && reader["count"] != DBNull.Value ? int.Parse(reader["count"].ToString()) : 0;
            }
        }
        private decimal GetTotalLoan(string empCode, int year, int month)
        {
            string query = @"SELECT SUM(amount) AS totalLoan FROM tbl_loan WHERE YEAR(loandates) = @year AND MONTH(loandates) = @month AND employeeId = @code";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query,
                DBClass.CreateParameter("year", year),
                DBClass.CreateParameter("month", month),
                DBClass.CreateParameter("code", empCode)))
            {
                return reader.Read() && reader["totalLoan"] != DBNull.Value ? decimal.Parse(reader["totalLoan"].ToString()) : 0;
            }
        }
        private decimal GetTotalDelay(string empCode, int year, int month)
        {
            string query = @"SELECT total_delay FROM tbl_attendance_salary 
                     WHERE YEAR(date) = @year AND MONTH(date) = @month AND emp_code = @code";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query,
                DBClass.CreateParameter("year", year),
                DBClass.CreateParameter("month", month),
                DBClass.CreateParameter("code", empCode)))
            {
                if (reader.Read())
                {
                    return reader["total_delay"] != DBNull.Value ? decimal.Parse(reader["total_delay"].ToString()) : 0;
                }
                return 0;
            }
        }
        private decimal GetTotalAbsence(string empCode, int year, int month)
        {
            string query = @"SELECT total_absence FROM tbl_attendance_salary 
                     WHERE YEAR(date) = @year AND MONTH(date) = @month AND emp_code = @code";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query,
                DBClass.CreateParameter("year", year),
                DBClass.CreateParameter("month", month),
                DBClass.CreateParameter("code", empCode)))
            {
                if (reader.Read())
                {
                    return reader["total_absence"] != DBNull.Value ? decimal.Parse(reader["total_absence"].ToString()) : 0;
                }
                return 0;
            }
        }
        private decimal GetSalaryAdjustment(string empCode, int refId, string adjustmentType)
        {
            string query = @"SELECT SUM(amount) FROM tbl_salary_adjustments 
                     WHERE code = @code 
                     AND ref_id = @id and adjustment_type=@adjustment_type";

            object result = DBClass.ExecuteScalar(query,
                DBClass.CreateParameter("@code", empCode),
                DBClass.CreateParameter("@adjustment_type", adjustmentType),
                DBClass.CreateParameter("@id", refId));

            return (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0m;
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBasic.Text) ||
               string.IsNullOrWhiteSpace(txtOvertime.Text) ||
               string.IsNullOrWhiteSpace(txtDeductions.Text))
            {
                MessageBox.Show("Please fill in all fields before calculating.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal basic = decimal.Parse(txtBasic.Text);
            decimal ot = decimal.Parse(txtOvertime.Text);
            decimal ded = decimal.Parse(txtDeductions.Text);

            txtNet.Text = (basic + ot - ded).ToString("0.00");
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
