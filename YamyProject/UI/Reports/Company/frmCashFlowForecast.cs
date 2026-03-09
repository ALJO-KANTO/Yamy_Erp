using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;
using Font = System.Drawing.Font;

namespace YamyProject
{
    public partial class frmCashFlowForecast : Form
    {
        public frmCashFlowForecast()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this); 
            dgvReport.EnableHeadersVisualStyles = false; // important
            AppTheme.DefaultFont(dgvReport);
            AppTheme.DefaultFont6(dgvReport);
            headerUC1.FormText = this.Text;
        }

        private void frmCashFlowForecast_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:tt");
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            }
            btnPrint.Text = "Print ▼";
            LoadData();
        }

        private void LoadData()
        {
            AddDGVColumns();
            BindDGV();
            putDateWords();
        }

        private void AddDGVColumns()
        {
            dgvReport.Columns.Clear();
            dgvReport.AutoGenerateColumns = false;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Description Column
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.Name = "colDesc";
            colDesc.HeaderText = "";
            colDesc.Width = 220;
            colDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReport.Columns.Add(colDesc);

            // Accounts Receivable
            dgvReport.Columns.Add(CreateAmountColumn("colAR", "Accnts Receivable"));

            // Accounts Payable
            dgvReport.Columns.Add(CreateAmountColumn("colAP", "Accnts Payable"));

            // Bank Accounts
            dgvReport.Columns.Add(CreateAmountColumn("colBank", "Bank Acnts"));

            // Net Inflows
            dgvReport.Columns.Add(CreateAmountColumn("colNet", "Net Inflows"));

            // Projected Balance
            dgvReport.Columns.Add(CreateAmountColumn("colBal", "Proj Balance"));

            // Header Style
            dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgvReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvReport.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvReport.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvReport.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvReport.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvReport);
        }
        private DataGridViewTextBoxColumn CreateAmountColumn(string name, string header)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = header;
            col.Width = 130;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = "N2";   // 2 decimal format
            return col;
        }

        public void BindDGV()
        {
            dgvReport.Rows.Clear();

            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // 1️ Opening Bank Balance
            object objOpBank = DBClass.ExecuteScalar(@"
                                                        SELECT COALESCE(SUM(t.debit - t.credit),0) AS OpeningBalance
                                                        FROM tbl_transaction t
                                                        JOIN tbl_coa_level_4 l4 ON t.account_id = l4.id
                                                        JOIN tbl_coa_level_3 l3 ON l4.main_id = l3.id
                                                        JOIN tbl_coa_level_2 l2 ON l3.main_id = l2.id
                                                        JOIN tbl_coa_level_1 l1 ON l2.main_id = l1.id
                                                        WHERE l1.category_code = 'ASSET'
                                                          AND l3.name = 'BANKS'
                                                          AND t.state = 0
                                                          AND t.date < @startDate;
                                                    ", DBClass.CreateParameter("@startDate", startDate));

            decimal openingBalance = objOpBank == null ? 0 : Convert.ToDecimal(objOpBank);
            decimal projectedBalance = openingBalance;

            // 2️ Accounts Receivable (Expected Cash In)
            DataTable dtAR = DBClass.ExecuteDataTable(@"
                                    SELECT YEAR(payment_date) AS Yr,
                                           WEEK(payment_date,1) AS Wk,
                                           MIN(payment_date) AS WeekStart,
                                           SUM(`change`) AS ExpectedAR
                                    FROM tbl_sales
                                    WHERE `change` > 0
                                      AND payment_date BETWEEN @startDate AND @endDate
                                    GROUP BY YEAR(payment_date), WEEK(payment_date,1);
                                ", DBClass.CreateParameter("@startDate", startDate),
                               DBClass.CreateParameter("@endDate", endDate));

            // 3️ Accounts Payable (Expected Cash Out)
            DataTable dtAP = DBClass.ExecuteDataTable(@"
                    SELECT YEAR(payment_date) AS Yr,
                           WEEK(payment_date,1) AS Wk,
                           MIN(payment_date) AS WeekStart,
                           SUM(`change`) AS ExpectedAP
                    FROM tbl_purchase
                    WHERE `change` > 0
                      AND payment_date BETWEEN @startDate AND @endDate
                    GROUP BY YEAR(payment_date), WEEK(payment_date,1);
                ", DBClass.CreateParameter("@startDate", startDate),
               DBClass.CreateParameter("@endDate", endDate));

            // 4️ Bank Movements
            DataTable dtBank = DBClass.ExecuteDataTable(@"
                        SELECT YEAR(t.date) AS Yr,
                               WEEK(t.date,1) AS Wk,
                               MIN(t.date) AS WeekStart,
                               SUM(t.debit) AS CashIn,
                               SUM(t.credit) AS CashOut,
                               SUM(t.debit - t.credit) AS NetBankMovement
                        FROM tbl_transaction t
                        JOIN tbl_coa_level_4 l4 ON t.account_id = l4.id
                        JOIN tbl_coa_level_3 l3 ON l4.main_id = l3.id
                        JOIN tbl_coa_level_2 l2 ON l3.main_id = l2.id
                        JOIN tbl_coa_level_1 l1 ON l2.main_id = l1.id
                        WHERE l1.category_code = 'ASSET'
                          AND l3.name = 'BANKS'
                          AND t.state = 0
                          AND t.date BETWEEN @startDate AND @endDate
                        GROUP BY YEAR(t.date), WEEK(t.date,1);
                    ", DBClass.CreateParameter("@startDate", startDate),
               DBClass.CreateParameter("@endDate", endDate));

            // 5️ Beginning Balance row
            int rowIndex = dgvReport.Rows.Add(
                "Beginning Balance",
                0, 0, openingBalance, "", projectedBalance);

            // 6 Weekly Forecast
            DateTime current = startDate;
            while (current <= endDate)
            {
                // Find AR, AP, Bank data for this week
                DataRow arRow = dtAR.AsEnumerable()
                                    .FirstOrDefault(r => ((DateTime)r["WeekStart"]).Date == current.Date);
                DataRow apRow = dtAP.AsEnumerable()
                                    .FirstOrDefault(r => ((DateTime)r["WeekStart"]).Date == current.Date);
                DataRow bankRow = dtBank.AsEnumerable()
                                    .FirstOrDefault(r => ((DateTime)r["WeekStart"]).Date == current.Date);

                decimal ar = arRow != null ? Convert.ToDecimal(arRow["ExpectedAR"]) : 0;
                decimal ap = apRow != null ? Convert.ToDecimal(apRow["ExpectedAP"]) : 0;
                decimal bankMov = bankRow != null ? Convert.ToDecimal(bankRow["NetBankMovement"]) : 0;

                decimal netInflows = ar - ap + bankMov;
                projectedBalance += netInflows;

                rowIndex = dgvReport.Rows.Add(
                    "Week of " + current.ToString("MMM dd, yyyy"),
                    ar,
                    ap,
                    bankMov,
                    netInflows,
                    projectedBalance);

                current = current.AddDays(7);
            }

            // 7️ Period Total
            string periodText = startDate.ToString("MMM dd") + " - " + endDate.ToString("MMM dd, yy");
            rowIndex = dgvReport.Rows.Add(periodText, 0, 0, 0, 0, "");

            // 8️ Ending Balance
            rowIndex = dgvReport.Rows.Add(
                "Ending Balance",
                0, 0, projectedBalance, "", projectedBalance);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            contextMenuExport.Show(btnPrint, new Point(0, btnPrint.Height));
        }

        private void Report_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exporting Report...");
        }

        private void SavePDF_Click(object sender, EventArgs e)
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

            // "Cash Flow Forecast" - Bold, size 10
            FormattedText summaryText = center.AddFormattedText("Cash Flow Forecast\n", TextFormat.Bold);
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

            // Table for data
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0;

            // Add columns for PDF table (match DataGridView columns)
            dataTable.AddColumn("5cm");   // Description
            dataTable.AddColumn("3cm");   // Accounts Receivable
            dataTable.AddColumn("3cm");   // Accounts Payable
            dataTable.AddColumn("3cm");   // Bank Accounts
            dataTable.AddColumn("3cm");   // Net Inflows
            dataTable.AddColumn("3cm");   // Projected Balance
                                          // --- Add header row ---
            Row headerRow0 = dataTable.AddRow();
            headerRow0.Shading.Color = Colors.LightGray; // optional: gray background
            headerRow0.Cells[0].AddParagraph("Description").Format.Font.Bold = true;
            headerRow0.Cells[1].AddParagraph("Accounts Receivable").Format.Font.Bold = true;
            headerRow0.Cells[2].AddParagraph("Accounts Payable").Format.Font.Bold = true;
            headerRow0.Cells[3].AddParagraph("Bank Accounts").Format.Font.Bold = true;
            headerRow0.Cells[4].AddParagraph("Net Inflows").Format.Font.Bold = true;
            headerRow0.Cells[5].AddParagraph("Projected Balance").Format.Font.Bold = true;

            // Align headers (optional)
            for (int i = 1; i <= 5; i++)
            {
                headerRow0.Cells[i].Format.Alignment = ParagraphAlignment.Right;
            }

            // Load from DataGridView
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (row.IsNewRow) continue;

                string desc = row.Cells["colDesc"].Value?.ToString() ?? "";

                // Skip rows that are total/summary
                if (desc.ToUpper().Contains("TOTAL")) continue;

                // Parse amounts safely
                decimal ar = 0, ap = 0, bank = 0, net = 0, bal = 0;
                decimal.TryParse(row.Cells["colAR"].Value?.ToString(), out ar);
                decimal.TryParse(row.Cells["colAP"].Value?.ToString(), out ap);
                decimal.TryParse(row.Cells["colBank"].Value?.ToString(), out bank);
                decimal.TryParse(row.Cells["colNet"].Value?.ToString(), out net);
                decimal.TryParse(row.Cells["colBal"].Value?.ToString(), out bal);

                // Add row to PDF table
                Row tRow = dataTable.AddRow();
                tRow.Cells[0].AddParagraph(desc);
                tRow.Cells[1].AddParagraph(ar.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                tRow.Cells[2].AddParagraph(ap.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                tRow.Cells[3].AddParagraph(bank.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                tRow.Cells[4].AddParagraph(net.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                tRow.Cells[5].AddParagraph(bal.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
            }

            // Render and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CashFlowForecast.pdf");
            renderer.PdfDocument.Save(filePath);
            Process.Start("explorer.exe", filePath);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "CashFlowForecast.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Cash Flow Forecast";

                    Excel.Range headerRange0 = worksheet.Range["A1", "F1"];
                    headerRange0.Merge();
                    headerRange0.Value = lblCompany.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["A2", "F2"];
                    headerRange1.Merge();
                    headerRange1.Value = label1.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["A3", "F3"];
                    headerRange2.Merge();
                    headerRange2.Value = "From " + dateTimePicker1.Text + " - To " + dateTimePicker2.Text;
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["A4", "F4"];
                    headerRange3.Merge();
                    headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange3.Font.Bold = false;
                    headerRange3.Font.Name = "Times New Roman";
                    headerRange3.Font.Size = 9;
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    int rowIndex = 5;
                    int excelCol = 1;
                    for (int col = 0; col < dgvReport.Columns.Count; col++)
                    {
                        var column = dgvReport.Columns[col];

                        // Skip hidden columns if needed
                        if (!column.Visible) continue;

                        string headerText = (column.HeaderText ?? "").Trim();
                        if (string.IsNullOrEmpty(headerText))
                            headerText = "";

                        //{
                            var headerCell = worksheet.Cells[rowIndex, excelCol];
                            headerCell.Value = headerText;  // show column header
                            headerCell.Font.Bold = true;
                            headerCell.Font.Name = "Times New Roman";
                            headerCell.Font.Size = 11;
                            headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        //}

                        excelCol++;
                    }

                    // 2️⃣ Write data rows
                    rowIndex++; // move to next row for data

                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Read all columns
                        string desc = row.Cells["colDesc"].Value?.ToString() ?? "";
                        string ar = row.Cells["colAR"].Value?.ToString() ?? "0";
                        string ap = row.Cells["colAP"].Value?.ToString() ?? "0";
                        string bank = row.Cells["colBank"].Value?.ToString() ?? "0";
                        string net = row.Cells["colNet"].Value?.ToString() ?? "0";
                        string bal = row.Cells["colBal"].Value?.ToString() ?? "0";

                        // Write to Excel cells
                        var descCell = worksheet.Cells[rowIndex, 1];
                        var arCell = worksheet.Cells[rowIndex, 2];
                        var apCell = worksheet.Cells[rowIndex, 3];
                        var bankCell = worksheet.Cells[rowIndex, 4];
                        var netCell = worksheet.Cells[rowIndex, 5];
                        var balCell = worksheet.Cells[rowIndex, 6];

                        // Clean up text
                        descCell.Value = desc.Replace("▶", "").Replace("▼", "").Trim();
                        arCell.Value = ar.Replace("◀", "").Replace("▼", "").Trim();
                        apCell.Value = ap.Replace("◀", "").Replace("▼", "").Trim();
                        bankCell.Value = bank.Replace("◀", "").Replace("▼", "").Trim();
                        netCell.Value = net.Replace("◀", "").Replace("▼", "").Trim();
                        balCell.Value = bal.Replace("◀", "").Replace("▼", "").Trim();

                        // Font settings
                        descCell.Font.Name = "Times New Roman";
                        arCell.Font.Name = "Times New Roman";
                        apCell.Font.Name = "Times New Roman";
                        bankCell.Font.Name = "Times New Roman";
                        netCell.Font.Name = "Times New Roman";
                        balCell.Font.Name = "Times New Roman";

                        // Highlight totals
                        if (desc.ToUpper().Contains("TOTAL"))
                        {
                            descCell.Font.Size = 10;
                            descCell.Font.Bold = true;

                            arCell.Font.Size = 10;
                            arCell.Font.Bold = true;
                            arCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;

                            apCell.Font.Size = 10;
                            apCell.Font.Bold = true;
                            apCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;

                            bankCell.Font.Size = 10;
                            bankCell.Font.Bold = true;
                            bankCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;

                            netCell.Font.Size = 10;
                            netCell.Font.Bold = true;
                            netCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;

                            balCell.Font.Size = 10;
                            balCell.Font.Bold = true;
                            balCell.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                        }
                        else
                        {
                            descCell.Font.Size = 10;
                            descCell.Font.Bold = false;

                            arCell.Font.Size = 9;
                            apCell.Font.Size = 9;
                            bankCell.Font.Size = 9;
                            netCell.Font.Size = 9;
                            balCell.Font.Size = 9;
                        }

                        // Align numeric columns to the right
                        arCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        apCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        bankCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        netCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        balCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                        rowIndex++;
                    }

                    worksheet.Columns[2].AutoFit();
                    worksheet.Columns[3].AutoFit();

                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Utilities.UserPermissionCheck("CustomerBalanceSummery"))
            //{
            //int id = int.Parse(dgvReport.CurrentRow.Cells["id"].Value.ToString());
            //frmLogin.frmMain.openChildForm(new frmCustomerBalanceDetails(id));
            //}
            if (e.RowIndex < 0) return;

            //
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //BindDGV();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //BindDGV();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dateTimePicker1, dateTimePicker2);
                LoadData();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void putDateWords()
        {
            string fromDate = dateTimePicker1.Value.ToString("MMMM dd, yyyy");
            string toDate = dateTimePicker2.Value.ToString("MMMM dd, yyyy");
            label2.Text = $"{fromDate} through {toDate}";
        }
    }
}