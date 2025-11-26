using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using PdfSharp.Pdf.Content.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.RMS.Class;

namespace YamyProject
{
    public partial class frmLaborAttendance : Form
    {
        int code = 0;
        int id = 0;
        bool isAllDataSucceed = true;
        TimeSpan defaultTimeIn = TimeSpan.Zero;

        public frmLaborAttendance(int id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isAllDataSucceed)
            {
                MessageBox.Show("Check All Data Required First...");
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_labor_attendance where labor_id = @id and date=@date",
                                             DBClass.CreateParameter("id", dgvAttendance.Rows[0].Cells[1].Value.ToString()),
                                             DBClass.CreateParameter("date", DateTime.Parse(dgvAttendance.Rows[0].Cells[3].Value.ToString()).ToString("yyyy-MM-dd"))))
                if (reader.Read())
                {
                    MessageBox.Show("Employee Month already saved before");
                    return;
                }
            for (int i = 0; i < dgvAttendance.Rows.Count; i++)
            {

                if ((dgvAttendance.Rows[i].Cells["time_in"].Value.ToString() == "" || dgvAttendance.Rows[i].Cells["time_out"].Value.ToString() == "") && (dgvAttendance.Rows[i].Cells["status"].Value.ToString() == "p"))
                {
                    MessageBox.Show("Date " + dgvAttendance.Rows[i].Cells["date"].Value.ToString() + " Does Not Contain Time, Please Check It.");
                    return;
                }
            }
            SaveMultipleAttendanceRows();
            MessageBox.Show("Employee Month Saved Successfully");
        }
        private void SaveMultipleAttendanceRows()
        {
            DateTime workDate = DateTime.Parse(dgvAttendance.Rows[0].Cells["date"].Value.ToString());
            DateTime endOfMonthDate = new DateTime(workDate.Year, workDate.Month, DateTime.DaysInMonth(workDate.Year, workDate.Month));
            int totalDelayMinutesNew = 0;
            DateTime parseDateR = DateTime.Parse(dgvAttendance.Rows[0].Cells["date"].Value.ToString());
            string refr = (parseDateR.Year % 100) + $"{parseDateR.Month:D2}";

            int _month = parseDateR.Month;
            int _year = parseDateR.Year;

            int totalPrecentDays = 0;
            int workingDays = dgvAttendance.Rows
                                        .Cast<DataGridViewRow>()
                                        .Count(r => r.Cells["Status"].Value != null &&
                                                    (r.Cells["Status"].Value.ToString().ToUpper() == "P" || r.Cells["Status"].Value.ToString().ToUpper() == "V"));

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.Cells["Status"].Value == null || row.Cells["Status"].Value.ToString().ToUpper() == "A")
                {
                    //
                }
                else if (row.Cells["Status"].Value.ToString().ToUpper() == "P")
                {
                    string timeIn = TimeSpan.Parse(row.Cells["Time_In"].Value.ToString() + ":00").ToString();

                    TimeSpan actualTimeIn0 = TimeSpan.Parse(row.Cells["Time_In"].Value.ToString() + ":00");
                    TimeSpan actualTimeOut0 = TimeSpan.Parse(row.Cells["Time_Out"].Value.ToString() + ":00");

                    int delayMinutes0 = (actualTimeIn0 > defaultTimeIn) ? (int)(actualTimeIn0 - defaultTimeIn).TotalMinutes : 0;
                    totalDelayMinutesNew += (actualTimeIn0 > defaultTimeIn) ? (int)(actualTimeIn0 - defaultTimeIn).TotalMinutes : 0;

                    totalPrecentDays++;
                }
                DBClass.ExecuteNonQuery(@"INSERT INTO tbl_labor_attendance
                                        (date, employee_id, time_in, lunch_start, lunch_end, time_out, overtime_hours, labor_id,Status) 
                                        VALUES(@date, @employee_id, @time_in, @lunch_start, @lunch_end, @time_out, @overtime_hours, @labor_id, @Status)",
                                            DBClass.CreateParameter("@employee_id", row.Cells["emp_id"].Value ?? 0),
                                            DBClass.CreateParameter("@date", DateTime.Parse(row.Cells["date"].Value.ToString()).ToString("yyyy-MM-dd")),
                                            DBClass.CreateParameter("@time_in", row.Cells["Time_In"].Value.ToString() + ":00"),
                                            DBClass.CreateParameter("@lunch_start", row.Cells["lunch_start"].Value.ToString() + ":00"),
                                            DBClass.CreateParameter("@lunch_end", row.Cells["lunch_end"].Value.ToString() + ":00"),
                                            DBClass.CreateParameter("@time_out", row.Cells["time_out"].Value.ToString() + ":00"),
                                            DBClass.CreateParameter("@overtime_hours", row.Cells["overtime_hours"].Value.ToString()),
                                            DBClass.CreateParameter("@labor_id", cmbEmployees.SelectedValue.ToString()),
                                            DBClass.CreateParameter("@Status", row.Cells["Status"].Value ?? "A")
                                        );
            }
            string dateValue = dgvAttendance.Rows[0].Cells["date"].Value.ToString();
            DateTime parseDate = DateTime.Parse(dateValue);

            var empId = dgvAttendance.Rows[0].Cells["Emp_ID"].Value ?? DBNull.Value;
            int month = parseDate.Month;
            int year = parseDate.Year;

            Utilities.LogAudit(frmLogin.userId, "Save Labor Attendance", "Labor Attendance", int.Parse(cmbEmployees.SelectedValue.ToString()), "Saved Attendance for Labor: " + dgvAttendance.Rows[0].Cells["Emp_ID"].Value.ToString() + " for Month: " + parseDate.ToString("MMMM yyyy"));
        }
        private void frmLaborAttendance_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjectResourceLabor(cmbEmployees);
            cmbEmployees.SelectedIndex = -1;

            cmbMonths.Items.AddRange(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m)).ToArray());

            cmbMonths.SelectedItem = DateTime.Now.ToString("MMMM");
            cmbMonths.SelectedIndex = -1;
        }

        //private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbEmployeeName.SelectedValue == null)
        //    {
        //        return;
        //    }
        //    using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_employee where id = " + cmbEmployeeName.SelectedValue.ToString()))
        //        if (reader.Read())
        //        {
        //            cmbEmployeeName.Text = reader["code"].ToString();
        //            codest = reader["code"].ToString();
        //            code = Convert.ToInt32(codest);
        //        }
        //    BindCombos.monthcheckcmb(cmbmonth, code);
        //}

        //private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        //{
        
        //}

        private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAttendance.DataSource = null;

            if (cmbEmployees.SelectedValue == null)
            {
                return;
            }
            if (cmbSelectionMethod.Text == "Select")
                return;

            LoadData();
        }
        private void LoadData()
        {
            if (dgvAttendance.Columns.Count <= 0)
            {
                //CREATE TABLE IF NOT EXISTS tbl_labor_attendance(
                //    id INT AUTO_INCREMENT PRIMARY KEY,
                //    employee_id INT NOT NULL,
                //    date DATE NOT NULL,
                //    time_in TIME NOT NULL,
                //    lunch_start TIME DEFAULT NULL,
                //    lunch_end TIME DEFAULT NULL,
                //    time_out TIME DEFAULT NULL,
                //    overtime_hours DECIMAL(5,2) DEFAULT 0,
                //    labor_id INT DEFAULT 0
                //);
                dgvAttendance.Columns.Clear();
                dgvAttendance.Columns.Add("id", "id");
                dgvAttendance.Columns.Add("emp_id", "emp id");
                dgvAttendance.Columns.Add("name", "Name");
                dgvAttendance.Columns.Add("date", "Work Date");
                dgvAttendance.Columns.Add("time_in", "Time In");
                dgvAttendance.Columns.Add("lunch_start", "Lunch Start");
                dgvAttendance.Columns.Add("lunch_end", "Lunch End");
                dgvAttendance.Columns.Add("time_out", "Time Out");
                dgvAttendance.Columns.Add("overtime_hours", "Overtime Hours");
                dgvAttendance.Columns.Add("Day Of Week", "Day of Week");

                // Create Status dropdown column
                DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
                statusColumn.Name = "Status";
                statusColumn.HeaderText = "Status";
                statusColumn.Items.AddRange("P", "A", "V"); // Present, Absent, Vacation
                statusColumn.DefaultCellStyle.NullValue = "P"; // default value
                dgvAttendance.Columns.Add(statusColumn);
                LocalizationManager.LocalizeDataGridViewHeaders(dgvAttendance);
            }

            dgvAttendance.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT a.id,a.employee_id,a.date,a.time_in,a.lunch_start,a.lunch_end,a.time_out,a.overtime_hours,a.Status,r.name name FROM tbl_labor_attendance a INNER JOIN tbl_project_resource r ON r.id = a.labor_id WHERE r.TYPE='Labour' AND a.labor_id=@id", DBClass.CreateParameter("id", cmbEmployees.SelectedValue.ToString())))
                while (reader.Read())
                {
                    dgvAttendance.Rows.Add(
                        reader["id"].ToString(),
                        reader["employee_id"].ToString(),
                        reader["name"].ToString(),
                        DateTime.Parse(reader["date"].ToString()).ToString("yyyy-MM-dd"),
                        TimeSpan.Parse(reader["time_in"].ToString()).ToString(@"hh\:mm"),
                        reader["lunch_start"] != DBNull.Value ? TimeSpan.Parse(reader["lunch_start"].ToString()).ToString(@"hh\:mm") : "",
                        reader["lunch_end"] != DBNull.Value ? TimeSpan.Parse(reader["lunch_end"].ToString()).ToString(@"hh\:mm") : "",
                        reader["time_out"] != DBNull.Value ? TimeSpan.Parse(reader["time_out"].ToString()).ToString(@"hh\:mm") : "",
                        reader["overtime_hours"].ToString(),
                        DateTime.Parse(reader["date"].ToString()).DayOfWeek.ToString(),
                        reader["Status"].ToString()
                    );
                }

            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.Columns["id"].Visible = false;
            dgvAttendance.Columns["emp_id"].Visible = false;
        }

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedItem == null || cmbMonths.SelectedItem == null)
                return;

            // Clear previous data
            dgvAttendance.DataSource = null;
            dgvAttendance.Rows.Clear();
            dgvAttendance.Columns.Clear();

            // Setup columns
            dgvAttendance.Columns.Add("id", "id");
            dgvAttendance.Columns.Add("emp_id", "emp id");
            dgvAttendance.Columns.Add("name", "Name");
            dgvAttendance.Columns.Add("date", "Work Date");
            dgvAttendance.Columns.Add("time_in", "Time In");
            dgvAttendance.Columns.Add("lunch_start", "Lunch Start");
            dgvAttendance.Columns.Add("lunch_end", "Lunch End");
            dgvAttendance.Columns.Add("time_out", "Time Out");
            dgvAttendance.Columns.Add("overtime_hours", "Overtime Hours");
            dgvAttendance.Columns.Add("DayOfWeek", "Day of Week");

            // Create Status dropdown column
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                Items = { "P", "A", "V" },  // Present, Absent, Vacation
                DefaultCellStyle = { NullValue = "P" } // default value
            };
            dgvAttendance.Columns.Add(statusColumn);

            // Localize headers if needed
            LocalizationManager.LocalizeDataGridViewHeaders(dgvAttendance);

            // Get month & year
            string selectedMonth = cmbMonths.SelectedItem.ToString();
            int monthNumber = DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.InvariantCulture).Month;
            int year = DateTime.Now.Year;

            // Get default attendance settings
            DateTime startDate = new DateTime(year, monthNumber, 1);
            int daysInMonth = DateTime.DaysInMonth(year, monthNumber);

            string query = @"SELECT id, date, day, timein, timeout,'13:00' lunch_start,'14:00' lunch_end 
                     FROM tbl_setting_attendance 
                     WHERE date = @date AND state = 1 
                     ORDER BY id DESC 
                     LIMIT 1;";

            string actualTimeIn = "08:00", actualTimeOut = "18:00";
            string actualLunchStart = "13:00", actualLunchEnd = "14:00";

            using (MySqlDataReader settingsReader = DBClass.ExecuteReader(query, DBClass.CreateParameter("date", startDate)))
            {
                if (settingsReader.Read())
                {
                    actualTimeIn = settingsReader["timein"].ToString();
                    actualTimeOut = settingsReader["timeout"].ToString();
                    actualLunchStart = settingsReader["lunch_start"].ToString();
                    actualLunchEnd = settingsReader["lunch_end"].ToString();
                }
            }

            // Populate grid
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime workDate = new DateTime(year, monthNumber, day);
                string dayOfWeek = workDate.DayOfWeek.ToString();
                string status = (workDate.DayOfWeek == DayOfWeek.Sunday) ? "V" : "P";

                dgvAttendance.Rows.Add(
                    0,
                    cmbEmployees.SelectedValue.ToString(),
                    cmbEmployees.Text,
                    workDate.ToString("yyyy-MM-dd"),
                    actualTimeIn,
                    actualLunchStart,
                    actualLunchEnd,
                    actualTimeOut,
                    "0.0",
                    dayOfWeek,
                    status
                );
            }

            // Enable editing
            //dgvAttendance.ReadOnly = false;

            // Make all columns read-only first
            foreach (DataGridViewColumn col in dgvAttendance.Columns)
            {
                col.ReadOnly = true;
            }

            // Enable editing only for specific columns
            dgvAttendance.Columns["overtime_hours"].ReadOnly = false;
            dgvAttendance.Columns["Status"].ReadOnly = false;

            // Hide ID columns
            dgvAttendance.Columns["id"].Visible = false;
            dgvAttendance.Columns["emp_id"].Visible = false;

            // Control edit mode
            dgvAttendance.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // Success flag
            isAllDataSucceed = dgvAttendance.Rows.Count > 0 && chkCorrectDataForEmpNameEmpCode();
        }

        //private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbEmployees.SelectedItem == null || cmbMonths.SelectedItem == null)
        //        return;
        //    dgvAttendance.DataSource = null;
        //    dgvAttendance.Rows.Clear();
        //    dgvAttendance.Columns.Clear();

        //    // Setup columns
        //    dgvAttendance.Columns.Add("id", "id");
        //    dgvAttendance.Columns.Add("emp_id", "emp id");
        //    dgvAttendance.Columns.Add("name", "Name");
        //    dgvAttendance.Columns.Add("date", "Work Date");
        //    dgvAttendance.Columns.Add("time_in", "Time In");
        //    dgvAttendance.Columns.Add("lunch_start", "Lunch Start");
        //    dgvAttendance.Columns.Add("lunch_end", "Lunch End");
        //    dgvAttendance.Columns.Add("time_out", "Time Out");
        //    dgvAttendance.Columns.Add("Day Of Week", "Day of Week");
        //    dgvAttendance.Columns.Add("overtime_hours", "Overtime Hours");

        //    // Create Status dropdown column
        //    DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
        //    statusColumn.Name = "Status";
        //    statusColumn.HeaderText = "Status";
        //    statusColumn.Items.AddRange("P", "A", "V"); // Present, Absent, Vacation
        //    statusColumn.DefaultCellStyle.NullValue = "P"; // default value
        //    dgvAttendance.Columns.Add(statusColumn);

        //    LocalizationManager.LocalizeDataGridViewHeaders(dgvAttendance);
        //    string selectedMonth = cmbMonths.SelectedItem.ToString();
        //    int monthNumber = DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.InvariantCulture).Month;
        //    int year = DateTime.Now.Year;

        //    // Get settings
        //    DateTime startDate = new DateTime(year, monthNumber, 1);
        //    int daysInMonth = DateTime.DaysInMonth(year, monthNumber);
        //    string query = @"SELECT id,date,day,timein,timeout FROM tbl_setting_attendance 
        //                                WHERE DATE >= @date AND DATE <= @date AND state=1 order by id DESC limit 1;";
        //    string actualTimeIn= "08:00", actualTimeOut= "18:00";
        //    string actualLunchStart = "13:00", actualLunchEnd = "14:00";
        //    using (MySqlDataReader settingsReader = DBClass.ExecuteReader(query, DBClass.CreateParameter("date", startDate)))
        //        if (settingsReader.Read())
        //        {
        //            actualTimeIn = settingsReader["timein"].ToString() + ":00";
        //            actualTimeOut = settingsReader["timeout"].ToString() + ":00";
        //            //actualLunchEnd = settingsReader["lunch_end"].ToString() + ":00";
        //            //actualLunchStart = settingsReader["lunch_start"].ToString() + ":00";
        //        }

        //    for (int day = 1; day <= daysInMonth; day++)
        //    {
        //        DateTime workDate = new DateTime(year, monthNumber, day);
        //        string dayOfWeek = workDate.DayOfWeek.ToString();
        //        string status = (workDate.DayOfWeek == DayOfWeek.Sunday) ? "V" : "P";
        //        dgvAttendance.Rows.Add(0,cmbEmployees.SelectedValue.ToString(), cmbEmployees.Text, workDate.ToString("yyyy-MM-dd"), actualTimeIn, actualLunchStart, actualLunchEnd, actualTimeOut, dayOfWeek, status);
        //    }
        //    // 1. Enable editing for the whole grid
        //    dgvAttendance.ReadOnly = false;

        //    // 2. Make all columns read-only first
        //    foreach (DataGridViewColumn col in dgvAttendance.Columns)
        //    {
        //        col.ReadOnly = true;
        //    }

        //    // 3. Enable editing only for specific columns
        //    dgvAttendance.Columns["time_in"].ReadOnly = false;
        //    dgvAttendance.Columns["time_out"].ReadOnly = false;
        //    dgvAttendance.Columns["Status"].ReadOnly = false;
        //    dgvAttendance.Columns["id"].Visible = false;
        //    dgvAttendance.Columns["emp_id"].Visible = false;
        //    // Optional: Control how editing starts
        //    dgvAttendance.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        //    isAllDataSucceed = true;
        //    if (dgvAttendance.Rows.Count == 0)
        //        isAllDataSucceed = false;
        //    else if (!chkCorrectDataForEmpNameEmpCode())
        //        isAllDataSucceed = false;
        //}

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
                int month = DateTime.Parse(dgvAttendance.Rows[0].Cells[3].Value?.ToString()).Month;

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
                    if (DateTime.Parse(row.Cells[3].Value?.ToString()).Month != month)
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
        
        private void cmbSelectionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMethod();
        }

        private void BindMethod()
        {
            if (cmbSelectionMethod.Text == "")
                return;

            if (cmbSelectionMethod.Text == "Labour")
            {
                BindCombos.PopulateProjectResourceLabor(cmbEmployees);
            }
            else if (cmbSelectionMethod.Text == "Employee")
            {
                BindCombos.PopulateEmployees(cmbEmployees);
            }
            else if (cmbSelectionMethod.Text == "Subcontractor")
            {
                BindCombos.PopulateVendors(cmbEmployees, false, false, "Subcontractor");
            }
            else
            {
                cmbEmployees.SelectedIndex = -1;
            }
        }
    }
}