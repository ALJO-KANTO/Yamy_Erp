using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Reports.Employee.SalaryTransferSheet
{
    public partial class frmSalaryTransferSheet : Form
    {
        public frmSalaryTransferSheet()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }

        private void frmSalaryTransferSheet_Load(object sender, EventArgs e)
        {
            var EnglishMonths = new CultureInfo("en-US")
                .DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m))
                .ToArray();

            cmbMonths.Items.AddRange(EnglishMonths);

            cmbMonths.SelectedItem = DateTime.Now.ToString("MMMM", new CultureInfo("en-US"));
            cmbMonths.SelectedIndex = -1;

            LoadData();
        }
        private void LoadData()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter> {};
            string selectedMonth = "";
            string dateFilter = "";
            if (!chkDate.Checked)
            {
                dateFilter = " AND YEAR(s.date)= @year AND MONTH(s.date)= @month";
                if (cmbMonths.SelectedItem == null)
                {
                    cmbMonths.SelectedIndex = 0;
                }
                selectedMonth = cmbMonths.SelectedItem.ToString();
                int monthNumber = DateTime.ParseExact(selectedMonth.Trim(), "MMMM", new CultureInfo("en-US")).Month;
                parameters.Add(DBClass.CreateParameter("@year", guna2NumericUpDown1.Value));
                parameters.Add(DBClass.CreateParameter("@month", monthNumber));
            }

            string query = $@"SELECT
                                DATE_FORMAT(s.date, '%b-%Y') AS SalaryMonth,
                                p.name AS Category,
                                e.code,
                                e.name,
                                IFNULL(b.name, '') AS Bank,
                                e.Iban_Number,
                                e.Bank_account_Number,
                                s.net_salary
                            FROM tbl_attendance_salary s
                            INNER JOIN tbl_employee e
                                ON s.emp_code = e.code
                            LEFT JOIN tbl_position p
                                ON e.Position_id = p.id
                            LEFT JOIN tbl_bank b
                                ON e.bank_id = b.id
                            WHERE 1 = 1 
                                {dateFilter}
                            ORDER BY
                            p.name,
                            e.name;";

            DataTable dtSalary = DBClass.ExecuteDataTable(query, parameters.ToArray());
            DataTable dtCompany = DBClass.ExecuteDataTable("SELECT * FROM tbl_company LIMIT 1");

            string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", "SalaryTransferSheet.rpt");
            ReportDocument cr = new ReportDocument();
            cr.Load(reportPath);

            cr.SetDataSource(dtSalary);
            if (dtCompany.Rows.Count > 0)
            {
                DataRow dr = dtCompany.Rows[0];
                cr.SetParameterValue("name", dr["name"].ToString());
            }
            cr.SetParameterValue("PreparedBy", frmLogin.userFName);
            cr.SetParameterValue("SelectedMonth", selectedMonth);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            guna2NumericUpDown1.Enabled = cmbMonths.Enabled = !chkDate.Checked;
            //LoadData();
        }
    }
}
