using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject.UI.Reports.FinancialReports
{
    public partial class ProfitLossReport : Form
    {
        string reportType = "";
        public ProfitLossReport(string _type)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.reportType = _type;
            headerUC1.FormText = this.Text;
        }
        void Dates(DateTime d)
        {
            //DateTime sDateOfY = new DateTime(d.Year, 1, 1);
            dtFrom.Value = new DateTime(d.Year, d.Month, 1);
            //DateTime eDateOfY = new DateTime(d.Year, 12, 31);
            //dtFrom.Value = sDateOfY;
            //dtTo.Value = eDateOfY;
        }

        private void ProfitLossReport_Load(object sender, EventArgs e)
        {
            Dates(DateTime.Now);
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            }
            dateChangeTo();
            //dgvCustomer.Columns.Clear();
            //dgvCustomer.Columns.Add("id", "ID");
            //dgvCustomer.Columns.Add("currLvl", "Level");
            //dgvCustomer.Columns.Add("currname", "Name");
            //dgvCustomer.Columns.Add("lvl1", "Account");
            //dgvCustomer.Columns.Add("balance", "Balance");
            //dgvCustomer.Columns["id"].Visible = false;
            //dgvCustomer.Columns["currLvl"].Visible = false;
            //dgvCustomer.Columns["currname"].Visible = false;
            //dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvCustomer.Columns["balance"].Width = 40;
            //dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCustomer.Columns["balance"].HeaderCell.Style.Format = "N2";
            int width = 40;
            AddDGVColumnsAll(width);

            LoadReport();
            DateWords();
        }
        private void AddDGVColumnsAll(int width)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            //dt.Rows.Add(1, "");

            switch (reportType)
            {
                case "standard":
                case "Unclassified":
                    AddStandardColumns(width);
                    break;

                case "YTD Comparison":
                    AddYTDColumns(width);
                    break;

                case "Prev Year Comparison":
                    AddPrevYearColumns(width);
                    break;

                case "by Class":
                    AddClassColumns(width);
                    break;

                case "by Job":
                    AddJobColumns(dt,width); // DataTable of customers
                    break;
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }
        private void AddStandardColumns(int width)
        {
            AddBaseColumns();

            dgvCustomer.Columns.Add("balance", "Amount");

            dgvCustomer.Columns["balance"].Width = width;
            dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns["balance"].DefaultCellStyle.Format = "N2";

            dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }
        private void AddYTDColumns(int width)
        {
            AddBaseColumns();

            string currentPeriod =
                $"{dtFrom.Value:MMM d} - {dtTo.Value:MMM d, yy}";

            string previousPeriod =
                $"{prevFrom:MMM d} - {prevTo:MMM d, yy}";

            dgvCustomer.Columns.Add("balance1", currentPeriod);
            dgvCustomer.Columns.Add("balance2", previousPeriod);

            foreach (string col in new[] { "balance1", "balance2" })
            {
                dgvCustomer.Columns[col].Width = width;
                dgvCustomer.Columns[col].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.Columns[col].DefaultCellStyle.Format = "N2";
                dgvCustomer.Columns[col].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddPrevYearColumns(int width)
        {
            AddBaseColumns();

            dgvCustomer.Columns.Add(
                "balance1",
                $"{dtFrom.Value:MMM d} - {dtTo.Value:MMM d, yy}");

            dgvCustomer.Columns.Add(
                "balance2",
                $"{prevFrom:MMM d} - {prevTo:MMM d, yy}");
            dgvCustomer.Columns.Add("change", "Change");
            dgvCustomer.Columns.Add("change_percentage", "% Change");

            foreach (string col in new[]
            {
                "balance1",
                "balance2",
                "change",
                "change_percentage"
            })
            {
                dgvCustomer.Columns[col].Width = width;
                dgvCustomer.Columns[col].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvCustomer.Columns[col].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCustomer.Columns["balance1"].DefaultCellStyle.Format = "N2";
            dgvCustomer.Columns["balance2"].DefaultCellStyle.Format = "N2";
            dgvCustomer.Columns["change"].DefaultCellStyle.Format = "N2";
        }
        private void AddClassColumns(int width)
        {
            AddBaseColumns();

            dgvCustomer.Columns.Add("balance", "Unclassified");
            dgvCustomer.Columns.Add("balance1", "Total");

            foreach (string col in new[] { "balance", "balance1" })
            {
                dgvCustomer.Columns[col].Width = width;
                dgvCustomer.Columns[col].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.Columns[col].DefaultCellStyle.Format = "N2";
                dgvCustomer.Columns[col].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddJobColumns(DataTable jobs,int width)
        {
            AddBaseColumns();

            foreach (DataRow dr in jobs.Rows)
            {
                string col = dr["name"].ToString();

                dgvCustomer.Columns.Add(col, col);

                dgvCustomer.Columns[col].Width = width;
                dgvCustomer.Columns[col].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvCustomer.Columns[col].DefaultCellStyle.Format = "N2";
            }

            dgvCustomer.Columns.Add("Total", "Total");

            dgvCustomer.Columns["Total"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvCustomer.Columns["Total"].DefaultCellStyle.Format = "N2";
        }
        private void AddBaseColumns()
        {
            dgvCustomer.Columns.Clear();

            dgvCustomer.Columns.Add("id", "");
            dgvCustomer.Columns.Add("currLvl", "");
            dgvCustomer.Columns.Add("currname", "");
            dgvCustomer.Columns.Add("lvl1", "Account");

            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["currLvl"].Visible = false;
            dgvCustomer.Columns["currname"].Visible = false;

            dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }
        DateTime prevFrom;
        DateTime prevTo;
        private void dateChangeTo()
        {
            if (reportType == "Prev Year Comparison" || reportType == "by Job" || reportType == "by class")
            {
                dtFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            }
            //prevFrom = new DateTime(dtFrom.Value.Year, 1, 1);
            //prevTo = new DateTime(dtTo.Value.Year, dtTo.Value.Month, DateTime.DaysInMonth(dtTo.Value.Year, dtTo.Value.Month));
            switch (reportType)
            {
                case "YTD Comparison":

                    // Current Period = User Selected
                    // YTD = Jan 1 -> Selected To Date
                    prevFrom = new DateTime(dtTo.Value.Year, 1, 1);
                    prevTo = dtTo.Value;
                    break;

                case "Prev Year Comparison":

                    // Same period last year
                    prevFrom = dtFrom.Value.AddYears(-1);
                    prevTo = dtTo.Value.AddYears(-1);
                    break;

                case "by Job":
                case "by Class":

                    // Whatever logic you need
                    prevFrom = new DateTime(dtTo.Value.Year, 1, 1);
                    prevTo = dtTo.Value;
                    break;

                default:

                    prevFrom = dtFrom.Value;
                    prevTo = dtTo.Value;
                    break;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = guna2HtmlLabel7.Text.Replace(" ", "") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = guna2HtmlLabel7.Text.Replace(" ", "");
                    if (reportType == "standard" || reportType == "Unclassified")
                    {
                        Excel.Range headerRange0 = worksheet.Range["A1", "C1"];
                        headerRange0.Merge();
                        headerRange0.Value = lblCompany.Text;
                        headerRange0.Font.Bold = true;
                        headerRange0.Font.Name = "Times New Roman";
                        headerRange0.Font.Size = 12;
                        headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange1 = worksheet.Range["A2", "C2"];
                        headerRange1.Merge();
                        headerRange1.Value = guna2HtmlLabel7.Text;
                        headerRange1.Font.Bold = true;
                        headerRange1.Font.Name = "Times New Roman";
                        headerRange1.Font.Size = 11;
                        headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange2 = worksheet.Range["A3", "C3"];
                        headerRange2.Merge();
                        headerRange2.Value = "From " + dtFrom.Text + " - To " + dtTo.Text;
                        headerRange2.Font.Bold = false;
                        headerRange2.Font.Name = "Times New Roman";
                        headerRange2.Font.Size = 9;
                        headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        // Merge and format header row (Date)
                        Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                        headerRange3.Merge();
                        headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                        headerRange3.Font.Bold = false;
                        headerRange3.Font.Name = "Times New Roman";
                        headerRange3.Font.Size = 9;
                        headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        int rowIndex = 5;
                        // 1️⃣ Write header row (aligned with data columns)
                        var accountHeaderCell = worksheet.Cells[rowIndex, 2];
                        var amountHeaderCell = worksheet.Cells[rowIndex, 3];

                        accountHeaderCell.Value = "Account";
                        amountHeaderCell.Value = "Balance";

                        foreach (var headerCell in new[] { accountHeaderCell, amountHeaderCell })
                        {
                            headerCell.Font.Bold = true;
                            headerCell.Font.Name = "Times New Roman";
                            headerCell.Font.Size = 11;
                            headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        }

                        // 2️⃣ Write data rows
                        rowIndex++; // move to next row for data
                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                        {
                            if (row.IsNewRow) continue;


                            string account = row.Cells["lvl1"].Value?.ToString();
                            string amount = row.Cells["balance"].Value?.ToString();

                            var accountCell = worksheet.Cells[rowIndex, 2];
                            var amountCell = worksheet.Cells[rowIndex, 3];


                            //accountCell.Value = account.Replace("▶", "").Trim().Replace("▼", "").Trim();
                            string safeText = account.Replace("▶", "").Replace("▼", "").Trim();

                            // Excel max cell length
                            if (safeText.Length > 32767)
                                safeText = safeText.Substring(0, 32767);

                            accountCell.Value2 = safeText;

                            accountCell.Value = account.Replace("▶", "").Trim().Replace("▼", "").Trim();
                            amountCell.Value = amount.Replace("◀", "").Trim().Trim().Replace("▼", "").Trim();

                            accountCell.Font.Name = "Times New Roman";
                            amountCell.Font.Name = "Times New Roman";

                            if (account.ToUpper().Contains("TOTAL"))
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amountCell.Font.Size = 10;
                                amountCell.Font.Bold = true;
                                amountCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                            }
                            else
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amountCell.Font.Size = 9;
                            }

                            amountCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                            rowIndex++;
                        }

                        worksheet.Columns[2].AutoFit();
                        worksheet.Columns[3].AutoFit();
                    }
                    else if (reportType == "YTD Comparison")
                    {
                        Excel.Range headerRange0 = worksheet.Range["A1", "C1"];
                        headerRange0.Merge();
                        headerRange0.Value = lblCompany.Text;
                        headerRange0.Font.Bold = true;
                        headerRange0.Font.Name = "Times New Roman";
                        headerRange0.Font.Size = 12;
                        headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange1 = worksheet.Range["A2", "C2"];
                        headerRange1.Merge();
                        headerRange1.Value = guna2HtmlLabel7.Text;
                        headerRange1.Font.Bold = true;
                        headerRange1.Font.Name = "Times New Roman";
                        headerRange1.Font.Size = 11;
                        headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange2 = worksheet.Range["A3", "C3"];
                        headerRange2.Merge();
                        headerRange2.Value = "From " + dtFrom.Text + " - To " + dtTo.Text;
                        headerRange2.Font.Bold = false;
                        headerRange2.Font.Name = "Times New Roman";
                        headerRange2.Font.Size = 9;
                        headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        // Merge and format header row (Date)
                        Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                        headerRange3.Merge();
                        headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                        headerRange3.Font.Bold = false;
                        headerRange3.Font.Name = "Times New Roman";
                        headerRange3.Font.Size = 9;
                        headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        int rowIndex = 5;
                        // 1️⃣ Write header row (aligned with data columns)
                        var accountHeaderCell = worksheet.Cells[rowIndex, 2];
                        var amount1HeaderCell = worksheet.Cells[rowIndex, 3];
                        var amount2HeaderCell = worksheet.Cells[rowIndex, 4];

                        accountHeaderCell.Value = "Account";
                        amount1HeaderCell.Value = dgvCustomer.Columns["balance1"].HeaderCell.Value;
                        amount2HeaderCell.Value = dgvCustomer.Columns["balance2"].HeaderCell.Value;

                        foreach (var headerCell in new[] { accountHeaderCell, amount1HeaderCell, amount2HeaderCell })
                        {
                            headerCell.Font.Bold = true;
                            headerCell.Font.Name = "Times New Roman";
                            headerCell.Font.Size = 11;
                            headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        }

                        // 2️⃣ Write data rows
                        rowIndex++; // move to next row for data
                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                        {
                            if (row.IsNewRow) continue;


                            string account = row.Cells["lvl1"].Value?.ToString();
                            string amount1 = row.Cells["balance1"].Value?.ToString();
                            string amount2 = row.Cells["balance2"].Value?.ToString();

                            var accountCell = worksheet.Cells[rowIndex, 2];
                            var amount1Cell = worksheet.Cells[rowIndex, 3];
                            var amount2Cell = worksheet.Cells[rowIndex, 4];

                            accountCell.Value = account.Replace("▶", "").Trim().Replace("▼", "").Trim();
                            amount1Cell.Value = amount1.Replace("◀", "").Trim().Trim().Replace("▼", "").Trim();
                            amount2Cell.Value = amount2.Replace("◀", "").Trim().Trim().Replace("▼", "").Trim();

                            accountCell.Font.Name = "Times New Roman";
                            amount1Cell.Font.Name = "Times New Roman";
                            amount2Cell.Font.Name = "Times New Roman";

                            if (account.ToUpper().Contains("TOTAL"))
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amount1Cell.Font.Size = 10;
                                amount2Cell.Font.Size = 10;
                                amount1Cell.Font.Bold = true;
                                amount2Cell.Font.Bold = true;
                                amount1Cell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                                amount2Cell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                            }
                            else
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amount1Cell.Font.Size = 9;
                                amount2Cell.Font.Size = 9;
                            }

                            amount1Cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            amount2Cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                            rowIndex++;
                        }

                        worksheet.Columns[2].AutoFit();
                        worksheet.Columns[3].AutoFit();
                        worksheet.Columns[4].AutoFit();
                    }
                    else if (reportType == "Prev Year Comparison")
                    {
                        Excel.Range headerRange0 = worksheet.Range["A1", "C1"];
                        headerRange0.Merge();
                        headerRange0.Value = lblCompany.Text;
                        headerRange0.Font.Bold = true;
                        headerRange0.Font.Name = "Times New Roman";
                        headerRange0.Font.Size = 12;
                        headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange1 = worksheet.Range["A2", "C2"];
                        headerRange1.Merge();
                        headerRange1.Value = guna2HtmlLabel7.Text;
                        headerRange1.Font.Bold = true;
                        headerRange1.Font.Name = "Times New Roman";
                        headerRange1.Font.Size = 11;
                        headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange2 = worksheet.Range["A3", "C3"];
                        headerRange2.Merge();
                        headerRange2.Value = "From " + dtFrom.Text + " - To " + dtTo.Text;
                        headerRange2.Font.Bold = false;
                        headerRange2.Font.Name = "Times New Roman";
                        headerRange2.Font.Size = 9;
                        headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        // Merge and format header row (Date)
                        Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                        headerRange3.Merge();
                        headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                        headerRange3.Font.Bold = false;
                        headerRange3.Font.Name = "Times New Roman";
                        headerRange3.Font.Size = 9;
                        headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        int rowIndex = 5;
                        // 1️⃣ Write header row (aligned with data columns)
                        var accountHeaderCell = worksheet.Cells[rowIndex, 2];
                        var amount1HeaderCell = worksheet.Cells[rowIndex, 3];
                        var amount2HeaderCell = worksheet.Cells[rowIndex, 4];
                        var changeHeaderCell = worksheet.Cells[rowIndex, 5];
                        var changePercentageHeaderCell = worksheet.Cells[rowIndex, 6];

                        accountHeaderCell.Value = "Account";
                        amount1HeaderCell.Value = dgvCustomer.Columns["balance1"].HeaderCell.Value;
                        amount2HeaderCell.Value = dgvCustomer.Columns["balance2"].HeaderCell.Value;
                        changeHeaderCell.Value = dgvCustomer.Columns["change"].HeaderCell.Value;
                        changePercentageHeaderCell.Value = dgvCustomer.Columns["change_percentage"].HeaderCell.Value;

                        foreach (var headerCell in new[] { accountHeaderCell, amount1HeaderCell, amount2HeaderCell, changeHeaderCell, changePercentageHeaderCell })
                        {
                            headerCell.Font.Bold = true;
                            headerCell.Font.Name = "Times New Roman";
                            headerCell.Font.Size = 11;
                            headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        }

                        // 2️⃣ Write data rows
                        rowIndex++; // move to next row for data
                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                        {
                            if (row.IsNewRow) continue;


                            string account = row.Cells["lvl1"].Value?.ToString();
                            string amount1 = row.Cells["balance1"].Value?.ToString();
                            string amount2 = row.Cells["balance2"].Value?.ToString();
                            string change = row.Cells["change"].Value?.ToString();
                            string change_percentage = row.Cells["change_percentage"].Value?.ToString();

                            var accountCell = worksheet.Cells[rowIndex, 2];
                            var amount1Cell = worksheet.Cells[rowIndex, 3];
                            var amount2Cell = worksheet.Cells[rowIndex, 4];
                            var changeCell = worksheet.Cells[rowIndex, 5];
                            var changePercentageCell = worksheet.Cells[rowIndex, 6];

                            accountCell.Value = account.Replace("▶", "").Trim().Replace("▼", "").Trim();
                            amount1Cell.Value = amount1.Trim();
                            amount2Cell.Value = amount2.Trim();
                            changeCell.Value = change.Trim();
                            changePercentageCell.Value = change_percentage.Trim();

                            accountCell.Font.Name = "Times New Roman";
                            amount1Cell.Font.Name = "Times New Roman";
                            amount2Cell.Font.Name = "Times New Roman";
                            changeCell.Font.Name = "Times New Roman";
                            changePercentageCell.Font.Name = "Times New Roman";

                            if (account.ToUpper().Contains("TOTAL"))
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amount1Cell.Font.Size = amount2Cell.Font.Size = changeCell.Font.Size = changePercentageCell.Font.Size = 10;
                                amount1Cell.Font.Bold = amount2Cell.Font.Bold = changeCell.Font.Bold = changePercentageCell.Font.Bold = true;
                                amount1Cell.Font.Underline = amount2Cell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                                changeCell.Font.Underline = changePercentageCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                            }
                            else
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;
                                amount1Cell.Font.Size = amount2Cell.Font.Size = 9;
                                changeCell.Font.Size = changePercentageCell.Font.Size = 9;
                            }

                            amount1Cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            amount2Cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            changeCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            changePercentageCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                            rowIndex++;
                        }

                        worksheet.Columns[2].AutoFit();
                        worksheet.Columns[3].AutoFit();
                        worksheet.Columns[4].AutoFit();
                        worksheet.Columns[5].AutoFit();
                        worksheet.Columns[6].AutoFit();
                    }
                    else if (reportType == "by Job")
                    {
                        Excel.Range headerRange0 = worksheet.Range["A1", "C1"];
                        headerRange0.Merge();
                        headerRange0.Value = lblCompany.Text;
                        headerRange0.Font.Bold = true;
                        headerRange0.Font.Name = "Times New Roman";
                        headerRange0.Font.Size = 12;
                        headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange1 = worksheet.Range["A2", "C2"];
                        headerRange1.Merge();
                        headerRange1.Value = guna2HtmlLabel7.Text;
                        headerRange1.Font.Bold = true;
                        headerRange1.Font.Name = "Times New Roman";
                        headerRange1.Font.Size = 11;
                        headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange2 = worksheet.Range["A3", "C3"];
                        headerRange2.Merge();
                        headerRange2.Value = "From " + dtFrom.Text + " - To " + dtTo.Text;
                        headerRange2.Font.Bold = false;
                        headerRange2.Font.Name = "Times New Roman";
                        headerRange2.Font.Size = 9;
                        headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        // Merge and format header row (Date)
                        Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                        headerRange3.Merge();
                        headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                        headerRange3.Font.Bold = false;
                        headerRange3.Font.Name = "Times New Roman";
                        headerRange3.Font.Size = 9;
                        headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        int rowIndex = 5;
                        // header names from dgvCustomer
                        foreach (DataGridViewColumn col in dgvCustomer.Columns)
                        {
                            if (col.Visible)
                            {
                                var headerCell = worksheet.Cells[rowIndex, col.Index + 1];
                                headerCell.Value = col.HeaderText;
                                headerCell.Font.Bold = true;
                                headerCell.Font.Name = "Times New Roman";
                                headerCell.Font.Size = 11;
                                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                            }
                        }
                        
                        rowIndex++; // move to next row for data
                        
                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                        {
                            if (row.IsNewRow) continue;
                            foreach (DataGridViewColumn col in dgvCustomer.Columns)
                            {
                                if (col.Visible)
                                {
                                    var dataCell = worksheet.Cells[rowIndex, col.Index + 1];
                                    DataGridViewCell dgvCell = row.Cells[col.Index];
                                    dataCell.Value = dgvCell.Value?.ToString() ?? "";
                                    dataCell.Font.Name = "Times New Roman";
                                    // Align numeric columns to right
                                    string colName = col.Name.ToLower();
                                    if (colName.Contains("balance") || colName.Contains("debit") || colName.Contains("credit") || colName.Contains("amount") || colName.Contains("total"))
                                    {
                                        dataCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        dataCell.Font.Size = 9;
                                    }
                                    else
                                    {
                                        dataCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        dataCell.Font.Size = 10;
                                    }
                                }
                            }
                            rowIndex++;
                        }
                    }
                    else if (reportType == "by Class")
                    {
                        Excel.Range headerRange0 = worksheet.Range["A1", "D1"];
                        headerRange0.Merge();
                        headerRange0.Value = lblCompany.Text;
                        headerRange0.Font.Bold = true;
                        headerRange0.Font.Name = "Times New Roman";
                        headerRange0.Font.Size = 12;
                        headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange1 = worksheet.Range["A2", "D2"];
                        headerRange1.Merge();
                        headerRange1.Value = guna2HtmlLabel7.Text;
                        headerRange1.Font.Bold = true;
                        headerRange1.Font.Name = "Times New Roman";
                        headerRange1.Font.Size = 11;
                        headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        Excel.Range headerRange2 = worksheet.Range["A3", "D3"];
                        headerRange2.Merge();
                        headerRange2.Value = "From " + dtFrom.Text + " - To " + dtTo.Text;
                        headerRange2.Font.Bold = false;
                        headerRange2.Font.Name = "Times New Roman";
                        headerRange2.Font.Size = 9;
                        headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        // Merge and format header row (Date)
                        Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                        headerRange3.Merge();
                        headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                        headerRange3.Font.Bold = false;
                        headerRange3.Font.Name = "Times New Roman";
                        headerRange3.Font.Size = 9;
                        headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        int rowIndex = 5;
                        // 1️⃣ Write header row (aligned with data columns)
                        var accountHeaderCell = worksheet.Cells[rowIndex, 2];
                        var amountHeaderCell = worksheet.Cells[rowIndex, 3];
                        var amount1HeaderCell = worksheet.Cells[rowIndex, 4];

                        accountHeaderCell.Value = "Account";
                        amountHeaderCell.Value = "Unclassified";
                        amount1HeaderCell.Value = "Total";

                        foreach (var headerCell in new[] { accountHeaderCell, amountHeaderCell, amount1HeaderCell })
                        {
                            headerCell.Font.Bold = true;
                            headerCell.Font.Name = "Times New Roman";
                            headerCell.Font.Size = 11;
                            headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        }

                        // 2️⃣ Write data rows
                        rowIndex++; // move to next row for data
                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                        {
                            if (row.IsNewRow) continue;


                            string account = row.Cells["lvl1"].Value?.ToString();
                            string amount = row.Cells["balance"].Value?.ToString();
                            string amount1 = row.Cells["balance1"].Value?.ToString();

                            var accountCell = worksheet.Cells[rowIndex, 2];
                            var amountCell = worksheet.Cells[rowIndex, 3];
                            var amount1Cell = worksheet.Cells[rowIndex, 4];

                            accountCell.Value = account.Replace("▶", "").Trim().Replace("▼", "").Trim();
                            amountCell.Value = amount.Replace("◀", "").Trim().Trim().Replace("▼", "").Trim();
                            amount1Cell.Value = amount1.Replace("◀", "").Trim().Trim().Replace("▼", "").Trim();

                            accountCell.Font.Name = "Times New Roman";
                            amountCell.Font.Name = "Times New Roman";
                            amount1Cell.Font.Name = "Times New Roman";

                            if (account.ToUpper().Contains("TOTAL"))
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amountCell.Font.Size = 10;
                                amountCell.Font.Bold = true;
                                amountCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                                amount1Cell.Font.Size = 10;
                                amount1Cell.Font.Bold = true;
                                amount1Cell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                            }
                            else
                            {
                                accountCell.Font.Size = 10;
                                accountCell.Font.Bold = true;

                                amountCell.Font.Size = 9;
                                amount1Cell.Font.Size = 9;
                            }

                            amountCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            amount1Cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                            rowIndex++;
                        }

                        worksheet.Columns[2].AutoFit();
                        worksheet.Columns[3].AutoFit();
                    }
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //open same excel file
                    Process.Start("explorer.exe", saveDialog.FileName);
                }
            }

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string companyName = lblCompany.Text;
            // Create PDF document
            Document doc = new Document();
            Section section = doc.AddSection();
            // Adjust page margins to position content to top-left
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Create a header table with 3 columns
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");  // Time/Date
            headerTable.AddColumn("8cm");  // Title Center
            headerTable.AddColumn("5cm");  // Empty for spacing

            Row headerRow = headerTable.AddRow();

            // Left cell - Time & Date (Top-left aligned, Times New Roman)
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            left.Format.SpaceAfter = 0;
            headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            //left.AddFormattedText("Time: ", TextFormat.Bold);
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            //left.AddFormattedText("Date: ", TextFormat.Bold);
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center cell - Company Name & Report Titles
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            center.Format.SpaceAfter = 0;

            // Company name - Bold, size 10
            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            // "ProfitAndLoss Summary" - Bold, size 10
            string title = guna2HtmlLabel7.Text.Replace(" ", "");
            FormattedText summaryText = center.AddFormattedText(title + "\n", TextFormat.Bold);
            summaryText.Font.Size = 12;

            // "All Transactions" - Regular, size 9
            FormattedText allTransText = center.AddFormattedText("All Transactions", TextFormat.NotBold);
            allTransText.Font.Size = 9;

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;


            //section.Add(headerTable);

            // Bold line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            if (reportType == "standard" || reportType == "Unclassified")
            {
                // Table for data
                Table dataTable = section.AddTable();
                dataTable.Borders.Width = 0;
                dataTable.AddColumn("10cm");
                dataTable.AddColumn("5cm");

                decimal totalAmount = 0;

                // Load from DataGridView
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    if (row.IsNewRow) continue;

                    string account = row.Cells["lvl1"].Value?.ToString() ?? "";
                    if (account.ToUpper().Contains("TOTAL")) continue;

                    string amountStr = row.Cells["balance"].Value?.ToString() ?? "0";
                    account = account.Replace("▶", "").Trim();
                    amountStr = amountStr.Replace("◀", "").Trim();

                    decimal amount = 0;
                    decimal.TryParse(amountStr, out amount);

                    Row tRow = dataTable.AddRow();
                    tRow.Cells[0].AddParagraph(account);
                    tRow.Cells[1].AddParagraph(amount.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;

                    totalAmount += amount;
                }

                // TOTAL row
                Row totalRow = dataTable.AddRow();
                totalRow.Cells[0].AddParagraph("TOTAL").Format.Font.Bold = true;
                Paragraph totalText = totalRow.Cells[1].AddParagraph(totalAmount.ToString("N2"));
                totalText.Format.Font.Bold = true;
                totalText.Format.Font.Underline = Underline.Single;
                totalRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            }
            else if (reportType == "YTD Comparison")
            {
                //dynamic columns so i want to create table based on dgv columns
                Table dataTable = section.AddTable();
                dataTable.Borders.Width = 0;
                // Add columns based on DataGridView
                // Add columns starting from index 3
                for (int i = 3; i < dgvCustomer.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                    if (dgvCol.Visible) // only add visible columns
                    {
                        if (dgvCol.HeaderText.Contains("Account Name"))
                            dataTable.AddColumn("10cm"); // Adjust width as needed
                        else
                            dataTable.AddColumn("3cm"); // Adjust width as needed
                    }
                }

                // Add header row
                Row header = dataTable.AddRow();
                int colIndex = 0;
                for (int i = 3; i < dgvCustomer.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                    if (!dgvCol.Visible) continue;

                    Paragraph p = header.Cells[colIndex].AddParagraph(dgvCol.HeaderText);
                    p.Format.Font.Bold = true;
                    p.Format.Font.Name = "Times New Roman";
                    p.Format.Alignment = ParagraphAlignment.Center;
                    colIndex++;
                }

                // Add data rows
                foreach (DataGridViewRow dgvRow in dgvCustomer.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    Row row = dataTable.AddRow();
                    int dataColIndex = 0;

                    for (int i = 3; i < dgvCustomer.Columns.Count; i++)
                    {
                        DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                        if (!dgvCol.Visible) continue;

                        DataGridViewCell dgvCell = dgvRow.Cells[i];
                        Paragraph p = row.Cells[dataColIndex].AddParagraph(dgvCell.Value?.ToString() ?? "");
                        p.Format.Font.Name = "Times New Roman";

                        // Align numeric columns to right
                        string colName = dgvCol.Name.ToLower();
                        if (colName.Contains("balance1") || colName.Contains("balance2"))
                        {
                            p.Format.Alignment = ParagraphAlignment.Right;
                            p.Format.Font.Size = 9;
                        }
                        else
                        {
                            p.Format.Alignment = ParagraphAlignment.Left;
                            p.Format.Font.Size = 10;
                        }

                        dataColIndex++;
                    }
                }
            }
            else if (reportType == "Prev Year Comparison")
            {
                // dynamic columns so i want to create table based on dgv columns
                Table dataTable = section.AddTable();
                dataTable.Borders.Width = 0;
                // Add columns based on DataGridView
                // Add columns starting from index 3
                for (int i = 3; i < dgvCustomer.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                    if (dgvCol.Visible) // only add visible columns
                    {
                        if (dgvCol.HeaderText.Contains("Account Name"))
                            dataTable.AddColumn("7cm"); // Adjust width as needed
                        else
                            dataTable.AddColumn("3cm"); // Adjust width as needed
                    }
                }

                // Add header row
                Row header = dataTable.AddRow();
                int colIndex = 0;
                for (int i = 3; i < dgvCustomer.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                    if (!dgvCol.Visible) continue;

                    Paragraph p = header.Cells[colIndex].AddParagraph(dgvCol.HeaderText);
                    p.Format.Font.Bold = true;
                    p.Format.Font.Name = "Times New Roman";
                    p.Format.Alignment = ParagraphAlignment.Center;
                    colIndex++;
                }

                // Add data rows
                foreach (DataGridViewRow dgvRow in dgvCustomer.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    Row row = dataTable.AddRow();
                    int dataColIndex = 0;

                    for (int i = 3; i < dgvCustomer.Columns.Count; i++)
                    {
                        DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                        if (!dgvCol.Visible) continue;

                        DataGridViewCell dgvCell = dgvRow.Cells[i];
                        Paragraph p = row.Cells[dataColIndex].AddParagraph(dgvCell.Value?.ToString() ?? "");
                        p.Format.Font.Name = "Times New Roman";

                        // Align numeric columns to right
                        string colName = dgvCol.Name.ToLower();
                        if (colName.Contains("balance1") || colName.Contains("balance2") || colName.Contains("change") || colName.Contains("change_percentage"))
                        {
                            p.Format.Alignment = ParagraphAlignment.Right;
                            p.Format.Font.Size = 9;
                        }
                        else
                        {
                            p.Format.Alignment = ParagraphAlignment.Left;
                            p.Format.Font.Size = 10;
                        }

                        dataColIndex++;
                    }
                }
            }
            else if (reportType == "by Job")
            {
                // dynamic columns so i want to create table based on dgv columns
                Table dataTable = section.AddTable();
                dataTable.Borders.Width = 0;
                // Add columns based on DataGridView
                // Add columns starting from index 0
                for (int i = 0; i < dgvCustomer.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                    if (dgvCol.Visible) // only add visible columns
                    {
                        if (dgvCol.HeaderText.Contains("Account Name") || dgvCol.HeaderText.Contains("Job"))
                            dataTable.AddColumn("7cm"); // Adjust width as needed
                        else
                            dataTable.AddColumn("3cm"); // Adjust width as needed
                    }
                }
                // Add header row
                Row header = dataTable.AddRow();
                int colIndex = 0;
                for (int i = 0; i < dgvCustomer.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                    if (!dgvCol.Visible) continue;
                    Paragraph p = header.Cells[colIndex].AddParagraph(dgvCol.HeaderText);
                    p.Format.Font.Bold = true;
                    p.Format.Font.Name = "Times New Roman";
                    p.Format.Alignment = ParagraphAlignment.Center;
                    colIndex++;
                }
                // Add data rows
                foreach (DataGridViewRow dgvRow in dgvCustomer.Rows)
                {
                    if (dgvRow.IsNewRow) continue;
                    Row row = dataTable.AddRow();
                    int dataColIndex = 0;
                    for (int i = 0; i < dgvCustomer.Columns.Count; i++)
                    {
                        DataGridViewColumn dgvCol = dgvCustomer.Columns[i];
                        if (!dgvCol.Visible) continue;
                        DataGridViewCell dgvCell = dgvRow.Cells[i];
                        Paragraph p = row.Cells[dataColIndex].AddParagraph(dgvCell.Value?.ToString() ?? "");
                        p.Format.Font.Name = "Times New Roman";
                        // Align numeric columns to right
                        string colName = dgvCol.Name.ToLower();
                        if (colName.Contains("balance") || colName.Contains("debit") || colName.Contains("credit") || colName.Contains("amount") || colName.Contains("total"))
                        {
                            p.Format.Alignment = ParagraphAlignment.Right;
                            p.Format.Font.Size = 9;
                        }
                        else
                        {
                            p.Format.Alignment = ParagraphAlignment.Left;
                            p.Format.Font.Size = 10;
                        }
                        dataColIndex++;
                    }
                }
            }
            else if (reportType == "by Class")
            {
                // Table for data
                Table dataTable = section.AddTable();
                dataTable.Borders.Width = 0;
                dataTable.AddColumn("10cm");
                dataTable.AddColumn("5cm");

                decimal totalAmount = 0;
                decimal totalAmount1 = 0;

                // Load from DataGridView
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    if (row.IsNewRow) continue;

                    string account = row.Cells["lvl1"].Value?.ToString() ?? "";
                    if (account.ToUpper().Contains("TOTAL")) continue;

                    string amountStr = row.Cells["balance"].Value?.ToString() ?? "0";
                    string amount1Str = row.Cells["balance1"].Value?.ToString() ?? "0";
                    account = account.Replace("▶", "").Trim();
                    amountStr = amountStr.Replace("◀", "").Trim();
                    amount1Str = amount1Str.Replace("◀", "").Trim();

                    decimal amount = 0;
                    decimal amount1 = 0;
                    decimal.TryParse(amountStr, out amount);
                    decimal.TryParse(amount1Str, out amount1);

                    Row tRow = dataTable.AddRow();
                    tRow.Cells[0].AddParagraph(account);
                    tRow.Cells[1].AddParagraph(amount.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                    tRow.Cells[1].AddParagraph(amount1.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;

                    totalAmount += amount;
                    totalAmount1 += amount1;
                }

                //// TOTAL row
                //Row totalRow = dataTable.AddRow();
                //totalRow.Cells[0].AddParagraph("TOTAL").Format.Font.Bold = true;
                //Paragraph totalText = totalRow.Cells[1].AddParagraph(totalAmount.ToString("N2"));
                //totalText.Format.Font.Bold = true;
                //totalText.Format.Font.Underline = Underline.Single;
                //totalRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                //Paragraph totalText1 = totalRow.Cells[2].AddParagraph(totalAmount1.ToString("N2"));
                //totalText1.Format.Font.Bold = true;
                //totalText1.Format.Font.Underline = Underline.Single;
                //totalRow.Cells[2].Format.Alignment = ParagraphAlignment.Right;
            }

            //section.Add(dataTable);

            // Render and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), title + ".pdf");
            renderer.PdfDocument.Save(filePath);
            Process.Start("explorer.exe", filePath);
        }
        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
        }
        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string FromDate = dtTo.Value.ToString("yyyy-MM-dd");
            string ToDate = dtFrom.Value.ToString("yyyy-MM-dd");

            dateChangeTo();
            AddDGVColumnsAll(80);
            LoadReport();

            DateWords();
        }

        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            //LoadReport();
        }

        private ProfitLossRenderer renderer;
        private ProfitLossReportEngine engine;

        private void LoadReport()
        {
            ReportType type = reportType == "YTD Comparison" ? ReportType.YTDComparison :
                reportType == "Prev Year Comparison" ? ReportType.PreviousYearComparison :
                reportType == "by Class" ? ReportType.ByClass :
                reportType == "by Job" ? ReportType.ByJob :
                reportType == "Unclassified" ? ReportType.Unclassified :
                ReportType.Standard;

            engine = new ProfitLossReportEngine(
                dtFrom.Value.Date,
                dtTo.Value.Date);

            engine.ReportType = type;
            engine.Load();
            engine.BuildReport(type);
            renderer = new ProfitLossRenderer(dgvCustomer);
            renderer.Render(engine);
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //renderer.Toggle(e.RowIndex);
            if (e.RowIndex < 0)
                return;

            ReportRow row =
                dgvCustomer.Rows[e.RowIndex].Tag as ReportRow;

            if (row == null)
                return;

            engine.Toggle(row);

            renderer.Render(engine);
        }
        private void DateWords()
        {
            string fromDate = dtFrom.Value.ToString("MMMM dd, yyyy");
            string toDate = dtTo.Value.ToString("MMMM dd, yyyy");
            guna2HtmlLabel10.Text = $"{fromDate} through {toDate}";

            if (reportType == "standard")
            {
                guna2HtmlLabel7.Text = "Profit and Loss";
            }
            else if (reportType == "YTD Comparison")
            {
                guna2HtmlLabel7.Text = "Profit and Loss YTD Comparison";
            }
            else if (reportType == "Prev Year Comparison")
            {
                guna2HtmlLabel7.Text = "Profit and Loss Previous Year Comparison";
            }
            else if (reportType == "by Class")
            {
                guna2HtmlLabel7.Text = "Profit and Loss by Class";
            }
            else if (reportType == "by Job")
            {
                guna2HtmlLabel7.Text = "Profit and Loss by Job";
            }
            else
            {
                guna2HtmlLabel7.Text = "Profit and Loss Unclassified";
            }
        }
    }
}
