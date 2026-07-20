using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.RMS.Class;

namespace YamyProject
{
    public partial class MasterAttendanceSheet : Form
    {
        string codest = "";
        int code = 0;
        int id = 0;
        int workDays, totalAbsence = 0;
        decimal dailyDeduction, basicSalary, housingAllowance, transportationAllowance, otherAllowance, deductionAmount = 0, totalDeduction = 0, deductionRate = 0, totalDelayMinutes = 0;
        bool isAllDataSucceed = true;
        DateTime ContractIssuse;
        TimeSpan defaultTimeIn = TimeSpan.Zero;
        bool isManuaEntry = false;

        private Dictionary<string, DataTable> loadedExcelTables = new Dictionary<string, DataTable>();

        // REQUIRED for Activator.CreateInstance
        public MasterAttendanceSheet() : this(0)
        {
        }
        public MasterAttendanceSheet(int id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = id;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            pnlData.Visible = true;
            pnlAddData.Visible = false;
            dgvAttendance.DataSource = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Select Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadExcelSheets(filePath);
                    if (dgvAttendance.Rows.Count == 0)
                        isAllDataSucceed = false;
                    else if (!chkCorrectDataForEmpNameEmpCode())
                        isAllDataSucceed = false;
                    else if (!chkExistingEmployee())
                        isAllDataSucceed = false;
                    else if (!CheckAllDaysIncluded(dgvAttendance, DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value.ToString()).Year, DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value.ToString()).Month))
                        isAllDataSucceed = false;
                }
            }
        }
        private void LoadExcelSheets(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("The selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                cmbSheet.Items.Clear();
                dgvAttendance.DataSource = null;
                dgvAttendance.Rows.Clear();
                dgvAttendance.Columns.Clear();
                loadedExcelTables.Clear();
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    if (sheet.Dimension != null)
                    {
                        DataTable dataTable = new DataTable(sheet.Name);

                        for (int col = 1; col <= sheet.Dimension.End.Column; col++)
                        {
                            string columnName = sheet.Cells[1, col].Text.Trim();
                            if (string.IsNullOrWhiteSpace(columnName)) columnName = "Column " + col;
                            dataTable.Columns.Add(columnName);
                        }

                        for (int row = 2; row <= sheet.Dimension.End.Row; row++)
                        {
                            bool isRowEmpty = true;
                            DataRow dataRow = dataTable.NewRow();

                            for (int col = 1; col <= sheet.Dimension.End.Column; col++)
                            {
                                string cellValue = sheet.Cells[row, col].Text.Trim();

                                if (!string.IsNullOrWhiteSpace(cellValue))
                                    isRowEmpty = false;

                                dataRow[col - 1] = cellValue;
                            }

                            if (!isRowEmpty)
                                dataTable.Rows.Add(dataRow);
                        }

                        RemoveEmptyColumns(dataTable);
                        loadedExcelTables[sheet.Name] = dataTable;

                        dgvAttendance.DataSource = dataTable;

                        dgvAttendance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        cmbSheet.Items.Add(sheet.Name);
                        if (dgvAttendance.Rows.Count == 0)
                            return;
                        pnlData.Visible = true;
                        lblCode.Text = dgvAttendance.Rows[0].Cells[0].Value.ToString();
                        lblName.Text = dgvAttendance.Rows[0].Cells[1].Value.ToString();
                        LocalizationManager.LocalizeDataGridViewHeaders(dgvAttendance);
                    }
                }

                if (cmbSheet.Items.Count > 0)
                    cmbSheet.SelectedIndex = 0;
                else
                    MessageBox.Show("No sheets found in the Excel file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RemoveEmptyColumns(DataTable dt)
        {
            List<DataColumn> emptyColumns = new List<DataColumn>();

            foreach (DataColumn col in dt.Columns)
            {
                bool isEmpty = true;

                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrWhiteSpace(row[col].ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                if (isEmpty)
                    emptyColumns.Add(col);
            }

            foreach (DataColumn col in emptyColumns)
            {
                dt.Columns.Remove(col);
            }
        }
        private bool CheckAllDaysIncluded(DataGridView dgv, int year, int month)
        {
            DateTime _d;
            int totalDaysInMonth = DateTime.DaysInMonth(year, month);
            var expectedDays = Enumerable.Range(1, totalDaysInMonth).ToList();

            var daysInDgv = dgv.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[2].Value)
                .Where(value => DateTime.TryParse(value?.ToString(), out _d))
                .Select(value => DateTime.Parse(value.ToString()))
                .Where(date => date.Year == year && date.Month == month)
                .Select(date => date.Day)
                .Distinct()
                .ToList();

            bool allDaysIncluded = !expectedDays.Except(daysInDgv).Any();

            if (!allDaysIncluded)
            {
                var missingDays = expectedDays.Except(daysInDgv);
                MessageBox.Show($"Missing days for {month}/{year}: {string.Join(", ", missingDays)}");
                return false;
            }
            return true;
        }
        // ===============================================
        // PROFESSIONAL PAYROLL SAVE SYSTEM (ERP VERSION)
        // ===============================================

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isAllDataSucceed)
            {
                MessageBox.Show("Check all required data first.");
                return;
            }

            if (dgvAttendance.Rows.Count == 0)
                return;

            try
            {
                SavePayrollMonth();
                MessageBox.Show("Payroll saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===============================================
        // MAIN SAVE
        // ===============================================
        private void SavePayrollMonth()
        {
            using (MySqlConnection con = new MySqlConnection(DBClass.GetConnectionString()))
            {
                con.Open();

                using (MySqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        string empCode = dgvAttendance.Rows[0].Cells["Emp ID"].Value.ToString();
                        DateTime firstDate = Convert.ToDateTime(dgvAttendance.Rows[0].Cells["Work Date"].Value);

                        int month = firstDate.Month;
                        int year = firstDate.Year;

                        // check duplicate
                        object exists = DBClass.ExecuteScalarNew(con, tran,
                            @"SELECT id FROM tbl_attendance_salary
                              WHERE emp_code=@code
                              AND YEAR(date)=@year
                              AND MONTH(date)=@month LIMIT 1",
                            DBClass.CreateParameter("@code", empCode),
                            DBClass.CreateParameter("@year", year),
                            DBClass.CreateParameter("@month", month));

                        if (exists != null)
                            throw new Exception("Employee month already saved.");

                        // load employee
                        EmployeePayroll emp = LoadEmployeePayroll(con, tran, empCode);

                        // calculate
                        PayrollResult result = CalculatePayroll(emp);

                        // save header
                        int attendanceSalaryId = SavePayrollHeader(con, tran, empCode, firstDate, result);

                        // save detail rows
                        SaveAttendanceRows(con, tran, attendanceSalaryId);

                        // save LS
                        SaveLeaveSalary(con, tran, emp, result, firstDate);

                        // save EOS
                        SaveEOS(con, tran, emp, result, firstDate);

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        // ===============================================
        // LOAD EMPLOYEE
        // ===============================================
        private EmployeePayroll LoadEmployeePayroll(MySqlConnection con, MySqlTransaction tran, string code)
        {
            EmployeePayroll emp = new EmployeePayroll();

            using (MySqlDataReader rd = DBClass.ExecuteReaderNew(con, tran, @"SELECT e.*, p.AnnualLeaveDays, p.EOSDaysPerYear
                        FROM tbl_employee e INNER JOIN tbl_position p ON e.Position_id = p.id
                        WHERE e.code = @code", DBClass.CreateParameter("@code", code)))
            {
                if (rd.Read())
                {
                    emp.Code = code;
                    emp.Basic = Convert.ToDecimal(rd["BasicSalary"]);
                    emp.Housing = Convert.ToDecimal(rd["HousingAllowance"]);
                    emp.Transport = Convert.ToDecimal(rd["TransportationAllowance"]);
                    emp.Other = Convert.ToDecimal(rd["Other"]);
                    emp.ContractDate = Convert.ToDateTime(rd["contractIssueDate"]);

                    emp.PositionId = Convert.ToInt32(rd["Position_id"]);
                    emp.AnnualLeaveDays = Convert.ToInt32(rd["AnnualLeaveDays"]);
                    emp.EOSDaysPerYear = Convert.ToInt32(rd["EOSDaysPerYear"]);
                }
            }

            emp.GrossSalary = emp.Basic + emp.Housing + emp.Transport + emp.Other;

            return emp;
        }

        // ===============================================
        // CALCULATE PAYROLL
        // ===============================================
        private PayrollResult CalculatePayroll(EmployeePayroll emp)
        {
            PayrollResult r = new PayrollResult();

            int totalDays = 0;
            int absentDays = 0;
            int lateMinutes = 0;

            decimal lateRate = GetLateRate();

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;

                string status = row.Cells["Status"].Value.ToString().ToUpper();

                totalDays++;

                if (status == "A")
                {
                    absentDays++;
                }

                if (status == "P")
                {
                    TimeSpan defaultIn = TimeSpan.Parse("08:00:00");
                    TimeSpan actualIn = TimeSpan.Parse(row.Cells["Time In"].Value.ToString() + ":00");

                    if (actualIn > defaultIn)
                        lateMinutes += (int)(actualIn - defaultIn).TotalMinutes;
                }
            }

            decimal dailyRate = emp.GrossSalary / totalDays;
            decimal absenceDeduction = dailyRate * absentDays;
            decimal lateDeduction = lateMinutes * lateRate;

            DateTime dt = Convert.ToDateTime(dgvAttendance.Rows[0].Cells["Work Date"].Value);

            decimal loan = GetEmployeeLoan(emp.Code, dt.Month, dt.Year);

            r.TotalDays = totalDays;
            r.AbsentDays = absentDays;
            r.LateMinutes = lateMinutes;
            r.AbsenceDeduction = Math.Round(absenceDeduction, 2);
            r.LateDeduction = Math.Round(lateDeduction, 2);
            r.Loan = loan;

            r.TotalDeduction = r.AbsenceDeduction + r.LateDeduction + r.Loan;
            r.NetSalary = emp.GrossSalary - r.TotalDeduction;

            return r;
        }

        // ===============================================
        // SAVE HEADER
        // ===============================================
        private int SavePayrollHeader(MySqlConnection con, MySqlTransaction tran,
            string empCode, DateTime dt, PayrollResult r)
        {
            object id = DBClass.ExecuteScalarNew(con, tran,
                            @"INSERT INTO tbl_attendance_salary
                            (
                                date,
                                emp_code,
                                absence_days,
                                total_absence,
                                delay_minutes,
                                total_delay,
                                total_loan,
                                net_salary,
                                pay,
                                `change`,
                                created_by,
                                created_date
                            )
                            VALUES
                            (
                                @date,@code,@abs,@totabs,@late,@totlate,@loan,@net,0,@net,@by,@cd
                            );
                            SELECT LAST_INSERT_ID();",
                            DBClass.CreateParameter("@date", dt),
                            DBClass.CreateParameter("@code", empCode),
                            DBClass.CreateParameter("@abs", r.AbsentDays),
                            DBClass.CreateParameter("@totabs", r.AbsenceDeduction),
                            DBClass.CreateParameter("@late", r.LateMinutes),
                            DBClass.CreateParameter("@totlate", r.LateDeduction),
                            DBClass.CreateParameter("@loan", r.Loan),
                            DBClass.CreateParameter("@net", r.NetSalary),
                            DBClass.CreateParameter("@by", frmLogin.userId),
                            DBClass.CreateParameter("@cd", DateTime.Now)
                        );

            return Convert.ToInt32(id);
        }

        // ===============================================
        // SAVE DETAIL
        // ===============================================
        private void SaveAttendanceRows(MySqlConnection con, MySqlTransaction tran, int salaryId)
        {
            DateTime parseDateR = DateTime.Parse(dgvAttendance.Rows[0].Cells["Work Date"].Value.ToString());
            int _month = parseDateR.Month;
            int _year = parseDateR.Year;

            string refr = (parseDateR.Year % 100) + $"{parseDateR.Month:D2}";
            object ref_no_result = DBClass.ExecuteScalar(@"SELECT Ref_Code FROM tbl_attendancesheet 
                  WHERE YEAR(WorkDate) = @year AND MONTH(WorkDate) = @month 
                  LIMIT 1",
            DBClass.CreateParameter("@year", _year),
            DBClass.CreateParameter("@month", _month));

            int ref_no;
            if (ref_no_result != null && ref_no_result != DBNull.Value && Convert.ToInt32(ref_no_result) > 0)
            {
                ref_no = Convert.ToInt32(ref_no_result);
            }
            else
            {
                object maxResult = DBClass.ExecuteScalar(@"SELECT MAX(Ref_Code) FROM tbl_attendancesheet");
                int max = (maxResult != null && maxResult != DBNull.Value) ? Convert.ToInt32(maxResult) : 600000;
                ref_no = max + 1;
            }

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQueryNew(con, tran,
                    @"INSERT INTO tbl_attendancesheet
                    (
                        attendance_salary_id,
                        code,
                        WorkDate,
                        TimeIn,
                        TimeOut,
                        DayOfWeek,
                        Status, 
                        Reference,
                        Ref_Code
                    )
                    VALUES
                    (
                        @id,@code,@dt,@in,@out,@day,@st,@Reference,@Ref_Code
                    )",
                    DBClass.CreateParameter("@id", salaryId),
                    DBClass.CreateParameter("@code", row.Cells["Emp ID"].Value),
                    DBClass.CreateParameter("@dt", row.Cells["Work Date"].Value),
                    DBClass.CreateParameter("@in", row.Cells["Time In"].Value),
                    DBClass.CreateParameter("@out", row.Cells["Time Out"].Value),
                    DBClass.CreateParameter("@day", row.Cells["Day Of Week"].Value),
                    DBClass.CreateParameter("@st", row.Cells["Status"].Value),
                    DBClass.CreateParameter("@Ref_Code", ref_no.ToString()),
                    DBClass.CreateParameter("@Reference", refr.ToString())
                );
            }
        }

        // ===============================================
        // SAVE LEAVE SALARY
        // ===============================================
        private void SaveLeaveSalary(MySqlConnection con, MySqlTransaction tran,
            EmployeePayroll emp, PayrollResult r, DateTime dt)
        {
            decimal leaveDays = (decimal)(r.TotalDays - r.AbsentDays) / 365m * emp.AnnualLeaveDays;
            decimal amount = emp.Basic * 12m / 365m * leaveDays;

            DBClass.ExecuteNonQueryNew(con, tran,
                @"INSERT INTO tbl_leave_salary
                (date,code,leave_days,credit,created_by,created_date)
                VALUES(@dt,@code,@days,@amt,@by,@cd)",
                DBClass.CreateParameter("@dt", dt),
                DBClass.CreateParameter("@code", emp.Code),
                DBClass.CreateParameter("@days", Math.Round(leaveDays, 2)),
                DBClass.CreateParameter("@amt", Math.Round(amount, 2)),
                DBClass.CreateParameter("@by", frmLogin.userId),
                DBClass.CreateParameter("@cd", DateTime.Now)
            );
        }

        // ===============================================
        // SAVE EOS
        // ===============================================
        private void SaveEOS(MySqlConnection con, MySqlTransaction tran,
            EmployeePayroll emp, PayrollResult r, DateTime dt)
        {
            //int years = (int)((DateTime.Now - emp.ContractDate).TotalDays / 365);
            //decimal eosDays = years < 5
            //    ? ((decimal)(r.TotalDays - r.AbsentDays) / 365m * 21m)
            //    : ((decimal)(r.TotalDays - r.AbsentDays) / 365m * emp.EOSDaysPerYear);
            decimal eosDays = ((decimal)(r.TotalDays - r.AbsentDays) / 365m * emp.EOSDaysPerYear);

            decimal amount = emp.Basic * 12m / 365m * eosDays;

            DBClass.ExecuteNonQueryNew(con, tran,
                @"INSERT INTO tbl_end_of_service
                (date,code,leave_days,credit,created_by,created_date)
                VALUES(@dt,@code,@days,@amt,@by,@cd)",

            DBClass.CreateParameter("@dt", dt),
            DBClass.CreateParameter("@code", emp.Code),
            DBClass.CreateParameter("@days", Math.Round(eosDays, 2)),
            DBClass.CreateParameter("@amt", Math.Round(amount, 2)),
            DBClass.CreateParameter("@by", frmLogin.userId),
            DBClass.CreateParameter("@cd", DateTime.Now));
        }

        // ===============================================
        // HELPERS
        // ===============================================
        private decimal GetLateRate()
        {
            object x = DBClass.ExecuteScalar("SELECT latearrivaldeduction FROM tbl_setting_deduction_config LIMIT 1");
            return x == null ? 0 : Convert.ToDecimal(x);
        }

        // ===============================================
        private class EmployeePayroll
        {
            public string Code;
            public decimal Basic;
            public decimal Housing;
            public decimal Transport;
            public decimal Other;
            public decimal GrossSalary;
            public DateTime ContractDate;

            public int PositionId;
            public int AnnualLeaveDays;
            public int EOSDaysPerYear;
        }

        private class PayrollResult
        {
            public int TotalDays;
            public int AbsentDays;
            public int LateMinutes;

            public decimal AbsenceDeduction;
            public decimal LateDeduction;
            public decimal Loan;
            public decimal TotalDeduction;
            public decimal NetSalary;
        }
        
        private void SaveMultipleAttendanceRows()
        {
            DateTime workDate = DateTime.Parse(dgvAttendance.Rows[0].Cells["Work Date"].Value.ToString());
            DateTime endOfMonthDate = new DateTime(workDate.Year, workDate.Month, DateTime.DaysInMonth(workDate.Year, workDate.Month));
            int totalDelayMinutesNew = 0;
            decimal attendanceSalaryId = decimal.Parse(DBClass.ExecuteScalar(@"INSERT INTO `tbl_attendance_salary`(date,emp_code,created_by,created_date) values(@date,@emp_code,@created_by,@created_date);SELECT LAST_INSERT_ID(); ",
                     DBClass.CreateParameter("@emp_code", dgvAttendance.Rows[0].Cells["Emp ID"].Value.ToString()),
                     DBClass.CreateParameter("@date", endOfMonthDate),
                     DBClass.CreateParameter("@created_by", frmLogin.userId),
                     DBClass.CreateParameter("@created_date", DateTime.Now.Date)).ToString());
                     DateTime parseDateR = DateTime.Parse(dgvAttendance.Rows[0].Cells["Work Date"].Value.ToString());
                     string refr = (parseDateR.Year % 100) + $"{parseDateR.Month:D2}";
            Utilities.LogAudit(frmLogin.userId, "Save Attendance", "Attendance", (int)attendanceSalaryId, "Saved Attendance for Employee: " + dgvAttendance.Rows[0].Cells["Emp ID"].Value.ToString() + " for Month: " + parseDateR.ToString("MMMM yyyy"));
            int _month = parseDateR.Month;
            int _year = parseDateR.Year;
            object ref_no_result = DBClass.ExecuteScalar(@"SELECT Ref_Code FROM tbl_attendancesheet 
                  WHERE YEAR(WorkDate) = @year AND MONTH(WorkDate) = @month 
                  LIMIT 1",
            DBClass.CreateParameter("@year", _year),
            DBClass.CreateParameter("@month", _month));

            int ref_no;
            if (ref_no_result != null && ref_no_result != DBNull.Value && Convert.ToInt32(ref_no_result) > 0)
            {
                ref_no = Convert.ToInt32(ref_no_result);
            }
            else
            {
                object maxResult = DBClass.ExecuteScalar(@"SELECT MAX(Ref_Code) FROM tbl_attendancesheet");
                int max = (maxResult != null && maxResult != DBNull.Value) ? Convert.ToInt32(maxResult) : 600000;
                ref_no = max + 1;
            }

            using (MySqlDataReader Creader = DBClass.ExecuteReader("select delaytime,latearrivaldeduction from tbl_setting_deduction_config LIMIT 1"))
                if (Creader.Read())
                {
                    defaultTimeIn = TimeSpan.Parse(Creader["delaytime"].ToString());
                    deductionRate = Convert.ToDecimal(Creader["latearrivaldeduction"]);
                }

            decimal totalSalary = 0;
            using(MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT BasicSalary, HousingAllowance, TransportationAllowance, Other, WorkDays,contractIssueDate FROM tbl_employee WHERE code = @code",
                      DBClass.CreateParameter("@code", dgvAttendance.Rows[0].Cells["Emp ID"].Value ?? 0)))
            if (reader.Read())
            {
                workDays = int.Parse(reader["workDays"].ToString());
                basicSalary = Convert.ToDecimal(reader["BasicSalary"]);
                housingAllowance = Convert.ToDecimal(reader["HousingAllowance"]);
                transportationAllowance = Convert.ToDecimal(reader["TransportationAllowance"]);
                otherAllowance = Convert.ToDecimal(reader["Other"]);
                ContractIssuse = DateTime.Parse(reader["contractIssueDate"].ToString());
                totalSalary = basicSalary + housingAllowance + transportationAllowance + otherAllowance;
                //dailyDeduction = Math.Round(totalSalary / Convert.ToInt32(reader["WorkDays"]), 3);
            }
            int totalPrecentDays = 0;
            int workingDays = dgvAttendance.Rows
                                        .Cast<DataGridViewRow>()
                                        .Count(r => r.Cells["Status"].Value != null &&
                                                    (r.Cells["Status"].Value.ToString().ToUpper() == "P" || r.Cells["Status"].Value.ToString().ToUpper() == "V"));

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.Cells["Status"].Value.ToString().ToUpper() == "A")
                {
                    dailyDeduction = Math.Round(totalSalary / workingDays, 3);
                    totalDeduction += dailyDeduction;
                    totalAbsence++;
                }
                else if (row.Cells["Status"].Value.ToString().ToUpper() == "P")
                {
                    // check with settings
                    
                        string timeIn = TimeSpan.Parse(row.Cells["Time In"].Value.ToString() + ":00").ToString();
                        string query = @"SELECT (SELECT latearrivaldeduction FROM tbl_setting_deduction_config ) deduction
                                        FROM tbl_setting_attendance 
                                        WHERE DATE >= @date AND DATE <= @date AND state=1;";
                    using (MySqlDataReader settingsReader = DBClass.ExecuteReader(query, DBClass.CreateParameter("date", workDate)))
                        if (settingsReader.Read())
                        {
                            var deductionSet = settingsReader["deduction"];

                            TimeSpan actualTimeIn0 = TimeSpan.Parse(row.Cells["Time In"].Value.ToString() + ":00");
                            TimeSpan actualTimeOut0 = TimeSpan.Parse(row.Cells["Time Out"].Value.ToString() + ":00");

                            int delayMinutes0 = (actualTimeIn0 > defaultTimeIn) ? (int)(actualTimeIn0 - defaultTimeIn).TotalMinutes : 0;
                            totalDelayMinutesNew += (actualTimeIn0 > defaultTimeIn) ? (int)(actualTimeIn0 - defaultTimeIn).TotalMinutes : 0;
                            deductionRate = decimal.Parse(deductionSet.ToString());

                            int delayMinutesx = delayMinutes0;
                            deductionAmount = delayMinutes0 * deductionRate;
                            totalDeduction += deductionAmount;
                            totalDelayMinutes += delayMinutes0;
                        }

                    //TimeSpan actualTimeIn = TimeSpan.Parse(row.Cells["Time In"].Value.ToString() + ":00");
                    //TimeSpan actualTimeOut = TimeSpan.Parse(row.Cells["Time Out"].Value.ToString() + ":00");
                    //int delayMinutes = (actualTimeIn > defaultTimeIn) ? (int)(actualTimeIn - defaultTimeIn).TotalMinutes : 0;
                    //delayMinutes += (actualTimeOut > defaultTimeIn) ? (int)(actualTimeIn - defaultTimeIn).TotalMinutes : 0;
                    //deductionAmount = delayMinutes * deductionRate;
                    //totalDeduction += deductionAmount;
                    //totalDelayMinutes += delayMinutes;
                    totalPrecentDays++;
                }
                id = (int)Convert.ToDecimal(DBClass.ExecuteScalar(@"
                INSERT INTO tbl_attendancesheet 
                (attendance_salary_id, code, WorkDate, TimeIn, TimeOut, DayOfWeek, Status, Reference,Ref_Code) 
                VALUES(@attendance_salary_id, @code, @WorkDate, @TimeIn, @TimeOut, @DayOfWeek, @Status, @Reference,@Ref_Code);
                SELECT LAST_INSERT_ID();",
                DBClass.CreateParameter("@attendance_salary_id", attendanceSalaryId),
                DBClass.CreateParameter("@code", row.Cells["Emp ID"].Value ?? 0),
                DBClass.CreateParameter("@WorkDate", DateTime.Parse(row.Cells["Work Date"].Value.ToString()).ToString("yyyy-MM-dd")),
                DBClass.CreateParameter("@TimeIn", row.Cells["Time In"].Value.ToString() + ":00"),
                DBClass.CreateParameter("@TimeOut", row.Cells["Time Out"].Value.ToString() + ":00"),
                DBClass.CreateParameter("@DayOfWeek", row.Cells["Day Of Week"].Value.ToString()),
                DBClass.CreateParameter("@Status", row.Cells["Status"].Value ?? ""),
                DBClass.CreateParameter("@Reference", refr),
                DBClass.CreateParameter("@Ref_Code",ref_no.ToString())
            ));
            }
            string dateValue = dgvAttendance.Rows[0].Cells["Work Date"].Value.ToString();
            DateTime parseDate = DateTime.Parse(dateValue);
           

            var empId = dgvAttendance.Rows[0].Cells["Emp ID"].Value ?? DBNull.Value;
            int month = parseDate.Month;
            int year = parseDate.Year;

            object result = DBClass.ExecuteScalar(@"SELECT ss_no FROM tbl_attendance_salary 
                  WHERE YEAR(date) = @year AND MONTH(date) = @month 
                  LIMIT 1",
            DBClass.CreateParameter("@year", year),
            DBClass.CreateParameter("@month", month));

            int ss_no;
            if (result != null && result != DBNull.Value && Convert.ToInt32(result)>0)
            {
                ss_no = Convert.ToInt32(result);
            }
            else
            {
                object maxResult = DBClass.ExecuteScalar(@"SELECT MAX(ss_no) FROM tbl_attendance_salary");
                int max = (maxResult != null && maxResult != DBNull.Value) ? Convert.ToInt32(maxResult) : 0;
                ss_no = max + 1;
            }
            decimal loanAmount = GetEmployeeLoan(empId, month, year);
            decimal totalDeductions = totalDeduction + loanAmount;
            decimal totalAdditions = basicSalary + housingAllowance + transportationAllowance + otherAllowance;
            decimal netSalary = totalAdditions - totalDeductions;
            DBClass.ExecuteNonQuery(@"update tbl_attendance_salary set absence_days=@absence_days,total_absence=@total_absence,delay_minutes=@delay_minutes,
                                    total_delay=@total_delay,total_loan=@total_loan,net_salary = @net_salary , pay = 0 , `change` = @net_salary,
                            ss_no = @ss_no where id = @id",
                    DBClass.CreateParameter("@id", attendanceSalaryId),
                    DBClass.CreateParameter("@code", empId),
                    DBClass.CreateParameter("@absence_days", totalAbsence),
                    DBClass.CreateParameter("@total_absence", totalAbsence * dailyDeduction),
                    DBClass.CreateParameter("@delay_minutes", totalDelayMinutes),
                    DBClass.CreateParameter("@total_delay", totalDelayMinutes * deductionRate),
                    DBClass.CreateParameter("@total_loan", loanAmount),
                    DBClass.CreateParameter("@net_salary", netSalary),
                    DBClass.CreateParameter("@ss_no", ss_no),
                    DBClass.CreateParameter("@created_by", frmLogin.userId),
                    DBClass.CreateParameter("@created_date", DateTime.Now.Date)
                    );

            insertJournals(netSalary,id);
            Utilities.LogAudit(frmLogin.userId, "Save Attendance Salary", "Attendance Salary", (int)attendanceSalaryId, "Saved Attendance Salary for Employee: " + dgvAttendance.Rows[0].Cells["Emp ID"].Value.ToString() + " for Month: " + parseDate.ToString("MMMM yyyy"));
        }
        private void MasterAttendanceSheet_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateEmployeesForLoan(cmbEmployeeName);
            BindCombos.PopulateEmployeesForLoan(cmbEmployees);
            cmbEmployees.SelectedIndex = -1;

            var EnglishMonths = new CultureInfo("en-US")
                .DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m))
                .ToArray();

            cmbMonths.Items.AddRange(EnglishMonths);

            cmbMonths.SelectedItem = DateTime.Now.ToString("MMMM", new CultureInfo("en-US"));
            cmbMonths.SelectedIndex = -1;
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployeeName.SelectedValue == null)
            {
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_employee where id = " + cmbEmployeeName.SelectedValue.ToString()))
                if (reader.Read())
                {
                    cmbEmployeeName.Text = reader["code"].ToString();
                    codest = reader["code"].ToString();
                    code = Convert.ToInt32(codest);
                }
            BindCombos.monthcheckcmb(cmbmonth, code);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //guna2DataGridView1.Rows.Clear();
            GetData();
        }

        private decimal GetEmployeeLoan(object empId, int month, int year)
        {
            if (empId == DBNull.Value) return 0;

            object result = DBClass.ExecuteScalar(@"SELECT SUM(amount) AS totalLoan 
                                           FROM tbl_loan 
                                           WHERE YEAR(loandates) = @year 
                                           AND MONTH(loandates) = @month 
                                           AND employeeId = @code",
                            DBClass.CreateParameter("@year", year),
                            DBClass.CreateParameter("@month", month),
                            DBClass.CreateParameter("@code", empId));
            return result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0;
        }

        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void btnAddManualAttendance_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            pnlData.Visible = false;
            pnlAddData.Visible = true;
            dgvAttendance.DataSource = null;
            cmbMonths.SelectedIndex = cmbEmployees.SelectedIndex = -1;
        }

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            pnlData.Visible = false;
            pnlAddData.Visible = false;
            panel5.BringToFront();
            dgvAttendance.DataSource = null;
        }

        private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedValue == null)
            {
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_employee where id = " + cmbEmployees.SelectedValue.ToString()))
                if (reader.Read())
                {
                    lblEmployeeCode.Text = reader["code"].ToString();
                    codest = reader["code"].ToString();
                    code = Convert.ToInt32(codest);
                }

        }

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedItem == null || cmbMonths.SelectedItem == null)
                return;
            dgvAttendance.DataSource = null;
            dgvAttendance.Rows.Clear();
            dgvAttendance.Columns.Clear();

            // Setup columns
            dgvAttendance.Columns.Add("Emp ID", "Emp ID");
            dgvAttendance.Columns.Add("Emp Name", "Emp Name");
            dgvAttendance.Columns.Add("Work Date", "Work Date");
            dgvAttendance.Columns.Add("Time In", "Time In");
            dgvAttendance.Columns.Add("Time Out", "Time Out");
            dgvAttendance.Columns.Add("Day Of Week", "Day of Week");
            dgvAttendance.Columns.Add("Status", "Status");

            LocalizationManager.LocalizeDataGridViewHeaders(dgvAttendance);
            string selectedMonth = cmbMonths.SelectedItem.ToString();
            int monthNumber = DateTime.ParseExact(selectedMonth.Trim(), "MMMM", new CultureInfo("en-US")).Month;
            int year = DateTime.Now.Year;

            DateTime startDate = new DateTime(year, monthNumber, 1);
            int daysInMonth = DateTime.DaysInMonth(year, monthNumber);
            string query = @"SELECT id,date,day,timein,timeout FROM tbl_setting_attendance 
                                        WHERE DATE >= @date AND DATE <= @date AND state=1 order by id DESC limit 1;";
            string actualTimeIn= "08:00", actualTimeOut= "18:00";
            using (MySqlDataReader settingsReader = DBClass.ExecuteReader(query, DBClass.CreateParameter("date", startDate)))
                if (settingsReader.Read())
                {
                    actualTimeIn = settingsReader["timein"].ToString() + ":00";
                    actualTimeOut = settingsReader["timeout"].ToString() + ":00";
                }

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime workDate = new DateTime(year, monthNumber, day);
                string dayOfWeek = workDate.DayOfWeek.ToString();
                string status = (workDate.DayOfWeek == DayOfWeek.Sunday) ? "V" : "P";

                dgvAttendance.Rows.Add(lblEmployeeCode.Text, cmbEmployees.Text, workDate.ToString("yyyy-MM-dd"), actualTimeIn, actualTimeOut, dayOfWeek, status);
            }
            // 1. Enable editing for the whole grid
            dgvAttendance.ReadOnly = false;

            // 2. Make all columns read-only first
            foreach (DataGridViewColumn col in dgvAttendance.Columns)
            {
                col.ReadOnly = true;
            }

            // 3. Enable editing only for specific columns
            dgvAttendance.Columns["Time In"].ReadOnly = false;
            dgvAttendance.Columns["Time Out"].ReadOnly = false;
            dgvAttendance.Columns["Status"].ReadOnly = false;

            // Optional: Control how editing starts
            dgvAttendance.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            isAllDataSucceed = true;
            if (dgvAttendance.Rows.Count == 0)
                isAllDataSucceed = false;
            else if (!chkCorrectDataForEmpNameEmpCode())
                isAllDataSucceed = false;
            else if (!chkExistingEmployee())
                isAllDataSucceed = false;
            else if (!CheckAllDaysIncluded(dgvAttendance, DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value.ToString()).Year, DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value.ToString()).Month))
                isAllDataSucceed = false;
        }

        public void GetData()
        {   
            string qry = @"SELECT WorkDate,TimeIn,TimeOut,DayOfWeek,Status FROM tbl_attendancesheet WHERE  MONTHNAME(WorkDate)  = '" + cmbmonth.Text + "' and YEAR(WorkDate) = '"+ guna2NumericUpDown1.Value.ToString() +"' and code = " + code + "  ";
  
            ListBox lb = new ListBox();
            lb.Items.Add(dgvdate);
            lb.Items.Add(dgvtimeIn);
            lb.Items.Add(dgvTimeOut);
            lb.Items.Add(dgvday);
            lb.Items.Add(dgvStatus);

            RMSClass.loadData(qry, guna2DataGridView1, lb);
        }
        private int GetAccountIdByCategory(string category)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT account_id FROM tbl_coa_config WHERE category = @category",
                DBClass.CreateParameter("category", category)))
                if (reader.Read())
                    return Convert.ToInt32(reader["account_id"]);
                else
                    return 0;
        }

        void insertJournals(decimal netSalary,int id)
        {
            int accruedSalaryAccountId = GetAccountIdByCategory("Accrued Salaries");
            if(accruedSalaryAccountId == 0)
            {
                MessageBox.Show("No Default Account Set for 'Accrued Salaries' Please Add It", "Error", MessageBoxButtons.OK);
                return;
            }

            string empCode = dgvAttendance.Rows[0].Cells["Emp ID"].Value?.ToString();
            object empIdResult = DBClass.ExecuteScalar("SELECT id FROM tbl_employee WHERE code = @code",
                DBClass.CreateParameter("@code", empCode));
            string employeeId = empIdResult.ToString();

            string empAccountID = dgvAttendance.Rows[0].Cells["Emp ID"].Value?.ToString();
            object empAccountIdResult = DBClass.ExecuteScalar("SELECT account_id FROM tbl_coa_config WHERE category = @cat",
                DBClass.CreateParameter("@cat", "Salaries"));
            string empaccId = empAccountIdResult.ToString();

            string description = "Employee Salary";
            string refr = (DateTime.Parse(dgvAttendance.Rows[0].Cells["Work Date"].Value.ToString()).Year % 100).ToString() +
                          $"{DateTime.Parse(dgvAttendance.Rows[0].Cells["Work Date"].Value.ToString()).Month:D2}";
            string voucherNote = "Salary Sheet NO. " + refr;
            string debitAccountId = accruedSalaryAccountId.ToString();

            CommonInsert.addTransactionEntry(
            DateTime.Now.Date, empaccId, netSalary.ToString(), "0", id.ToString(), employeeId, description, "Salary", voucherNote, frmLogin.userId, DateTime.Now.Date,"");

            CommonInsert.addTransactionEntry(
            DateTime.Now.Date, debitAccountId, "0", netSalary.ToString(), id.ToString(), "0", description, "Salary", voucherNote, frmLogin.userId, DateTime.Now.Date,"");
        }
        private bool chkCorrectDataForEmpNameEmpCode()
        {
            if (dgvAttendance.Rows.Count > 1)
            {
                var empCode = dgvAttendance.Rows[0].Cells[0].Value?.ToString();
                var empName = dgvAttendance.Rows[0].Cells[1].Value?.ToString();
                int month = DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value?.ToString()).Month;

                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    if (row.Cells[0].Value?.ToString() != empCode)
                    {
                        MessageBox.Show("Employee Code has Different Values in Column 0 Please Correct it and Re Upload");
                        return false;
                    }
                    if (row.Cells[1].Value?.ToString().ToLower() != empName.ToLower())
                    {
                        MessageBox.Show("Employee Name has Different Values in Column 1 Please Correct it and Re Upload");
                        return false;
                    }
                    if (DateTime.Parse(row.Cells[2].Value?.ToString()).Month != month)
                    {
                        MessageBox.Show("Please Upload Only One Month.");
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
        private bool chkExistingEmployee()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_employee where code = @code",
                          DBClass.CreateParameter("code", dgvAttendance.Rows[0].Cells[0].Value.ToString())))
                if (reader.Read())
                {
                    string dbName = reader["name"].ToString().Trim().ToLower();
                    string excelName = dgvAttendance.Rows[0].Cells[1].Value.ToString().Trim().ToLower();

                    if (dbName != excelName)
                    {
                        MessageBox.Show($"Emp Name Does Not Belong To This Code. (DB: '{dbName}', Excel: '{excelName}')");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No Data For this Code");
                    return false;
                }
            return true;
        }

        private void DownloadExcelSheet_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            pnlData.Visible = true;
            pnlAddData.Visible = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Excel File";
            saveFileDialog.FileName = "Attendance Sheet.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells[1, 1].Value = "Emp ID";
                    worksheet.Cells[1, 2].Value = "Emp Name";
                    worksheet.Cells[1, 3].Value = "Work Date";
                    worksheet.Cells[1, 4].Value = "Time In";
                    worksheet.Cells[1, 5].Value = "Time Out";
                    worksheet.Cells[1, 6].Value = "Day of Week";
                    worksheet.Cells[1, 7].Value = "Status";
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                    MessageBox.Show("Excel file created successfully at: " + filePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            isAllDataSucceed = true;
            string selectedSheet = cmbSheet.SelectedItem.ToString();

                dgvAttendance.DataSource = loadedExcelTables[selectedSheet];
            if (dgvAttendance.Rows.Count == 0)
                isAllDataSucceed = false;
            else if (!chkCorrectDataForEmpNameEmpCode())
                isAllDataSucceed = false;
            else if (!chkExistingEmployee())
                isAllDataSucceed = false;
            else if (!CheckAllDaysIncluded(dgvAttendance, DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value.ToString()).Year, DateTime.Parse(dgvAttendance.Rows[0].Cells[2].Value.ToString()).Month))
                isAllDataSucceed = false;
            if (dgvAttendance.Rows.Count > 0)
                {
                    pnlData.Visible = true;
                    lblCode.Text = dgvAttendance.Rows[0].Cells[0].Value?.ToString() ?? "";
                    lblName.Text = dgvAttendance.Rows[0].Cells[1].Value?.ToString() ?? "";
            }
            LocalizationManager.LocalizeDataGridViewHeaders(dgvAttendance);
        }
    }
}