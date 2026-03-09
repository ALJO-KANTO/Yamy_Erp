using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmOpenInvoicesReport : Form
    {
        int id;
        string type = "";
        public frmOpenInvoicesReport(int _id = 0, string _type = "")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            type = _type;
            this.Text = type + " Report";
            headerUC1.FormText = this.Text;
            this.id = _id;
        }

        private void frmOpenInvoicesReport_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ▼";
            guna2HtmlLabel7.Text = type + " Report";
            LoadSalesData();
            DateTime dated = DateTime.Now;
            guna2HtmlLabel11.Text = dated.TimeOfDay.ToString();
            guna2HtmlLabel11.Text = dated.Date.ToShortDateString();
            loadCompany();
            LoadSalesData();
        }
        private void loadCompany()
        {
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    guna2HtmlLabel8.Text = reader["name"].ToString();
                }
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            contextMenuExport.Show(btnPrint, new Point(0, btnPrint.Height));
        }

        private void Report_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exporting Report...");
        }
        private void LoadSalesData()
        {
            //    if (dgvSales.Columns.Count == 0)
            //    {
            //        dgvSales.Columns.Add("id", "");
            //        dgvSales.Columns.Add("Type", "Type");
            //        dgvSales.Columns.Add("Date", "Date");
            //        dgvSales.Columns.Add("Num", "Num");
            //        dgvSales.Columns.Add("Account", "Account");
            //        dgvSales.Columns.Add("Amount", "Amount");
            //        dgvSales.Columns.Add("Balance", "Balance");
            //        LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);

            //        dgvSales.Columns["Account"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        dgvSales.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        dgvSales.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        dgvSales.Columns["Amount"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Regular);
            //        dgvSales.Columns["Account"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Regular);

            //        dgvSales.Columns["id"].Visible = false;
            //        dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //        dgvSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Bold);
            //        dgvSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            //        dgvSales.EnableHeadersVisualStyles = false;
            //        dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //        dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            //        dgvSales.GridColor = System.Drawing.Color.LightGray;
            //        dgvSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //        dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //        dgvSales.RowHeadersVisible = false;
            //    }

            decimal totalAmount = 0;

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(DBClass.CreateParameter("hum_id", id));

            string dateFilter = "";
            if (!chkDate.Checked)
            {
                dateFilter = " AND t.date >= @dateFrom AND t.date <= @dateTo ";
                parameters.Add(DBClass.CreateParameter("dateFrom", dtpFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)));
            }

            string query = $@"
                            SELECT 
                                (Select name from tbl_customer x where x.id = t.hum_id) AS `CustomerName`,
                                t.type AS `Type`,
                                DATE_FORMAT(t.date, '%M %d %Y') AS `Date`,
                                t.voucher_no `Num`,
                                '' PONum,'' Terms,DATE_FORMAT(t.date, '%M %d %Y') AS DueDate,0 as Aging,0 OpenBalance, 
                                t.transaction_id,
                                (t.debit - t.credit) AS `AMOUNT`,
                                SUM(
                                        CASE 
                                            WHEN t.type != 'Sales Invoice Cash' THEN (t.debit - t.credit)
                                            ELSE 0
                                        END
                                    ) OVER (PARTITION BY t.hum_id ORDER BY t.date, t.id) AS `BALANCE`
                            FROM 
                                tbl_transaction t
                            INNER JOIN 
                                tbl_coa_level_4 c ON t.account_id = c.id 
                            WHERE t.hum_id !=0 AND
                                t.type IN (
                                    'Customer Receipt',
                                    'Sales Invoice'
                                )
                        ORDER BY t.date, t.id;";

            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgvSales.DataSource = dt;
            //dgvSales.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //        dgvSales.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Regular);
            dgvSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Regular);
            dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.Columns["transaction_id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters.ToArray()))
            //{
            //    while (reader.Read())
            //    {
            //        if (reader["Date"] == DBNull.Value)
            //            continue;

            //        decimal amount = Convert.ToDecimal(reader["AMOUNT"]);
            //        decimal balance = Convert.ToDecimal(reader["BALANCE"]);

            //        int rowIndex = dgvSales.Rows.Add(
            //            reader["transaction_id"].ToString(),
            //            reader["Type"].ToString(),
            //            reader["date"].ToString(),
            //            reader["Num"].ToString(),
            //            reader["A/C NAME"].ToString(),
            //            amount.ToString("N2"),
            //            balance.ToString("N2") + " ◀"
            //        );

            //        dgvSales.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //        dgvSales.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Regular);

            //        totalAmount += amount;
            //    }
            //}

            //// Add total row
            //int totalRow = dgvSales.Rows.Add(null, null, null, null, "TOTAL", totalAmount.ToString("N2"), "");
            //dgvSales.Rows[totalRow].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Bold | FontStyle.Underline);
            //dgvSales.Rows[totalRow].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            //dgvSales.Rows[totalRow].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //dgvSales.Rows[totalRow].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgvSales.Rows[totalRow].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            putDateWords();
        }

        private void putDateWords()
        {
            string fromDate = dtpFrom.Value.ToString("MMMM dd, yyyy");
            string toDate = dtpTo.Value.ToString("MMMM dd, yyyy");
            guna2HtmlLabel10.Text = $"{fromDate} through {toDate}";
        }
        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvSales.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    int _id = int.Parse(dgvSales.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    var _type = dgvSales.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    if (_type.Contains("Sales"))
                    {
                        frmLogin.frmMain.openChildForm(new frmSales(_id, "", id));
                    }
                    else if(_type == "Customer Receipt")
                    {
                        frmLogin.frmMain.openChildForm(new frmViewReceiptVoucher(id));
                    }
                    else if (_type == "Customer Opening Balance")
                    {
                        frmLogin.frmMain.openChildForm(new frmTransactionJournal(_id, _type, _id.ToString()));
                    }
                }
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            string companyName = guna2HtmlLabel8.Text;
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
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center cell - Company Name & Report Titles
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            center.Format.SpaceAfter = 0;

            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText summaryText = center.AddFormattedText(type+"\n", TextFormat.Bold);
            summaryText.Font.Size = 12;

            FormattedText allTransText = center.AddFormattedText("All Transactions", TextFormat.NotBold);
            allTransText.Font.Size = 9;

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Bold line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Table for data
            Table dataTable = section.AddTable(); // table is already added to section by AddTable()
            dataTable.Borders.Width = 0.75;
            dataTable.Format.Font.Name = "Times New Roman";
            dataTable.Format.Font.Size = 9;

            dataTable.AddColumn("2cm"); // Type
            dataTable.AddColumn("2.5cm"); // Date
            dataTable.AddColumn("2cm"); // Num
            dataTable.AddColumn("4cm"); // Account
            dataTable.AddColumn("2.5cm"); // Amount
            dataTable.AddColumn("2.5cm"); // Balance

            Row header = dataTable.AddRow();
            header.Shading.Color = Colors.LightGray;
            header.Format.Font.Bold = true;
            header.Cells[0].AddParagraph("Type");
            header.Cells[1].AddParagraph("Date");
            header.Cells[2].AddParagraph("Num");
            header.Cells[3].AddParagraph("Account");
            header.Cells[4].AddParagraph("Amount");
            header.Cells[5].AddParagraph("Balance");

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                Row tRow = dataTable.AddRow();
                tRow.Cells[0].AddParagraph(row.Cells["Type"].Value?.ToString() ?? "");
                tRow.Cells[1].AddParagraph(row.Cells["Date"].Value?.ToString() ?? "");
                tRow.Cells[2].AddParagraph(row.Cells["Num"].Value?.ToString() ?? "");
                tRow.Cells[3].AddParagraph(row.Cells["Account"].Value?.ToString() ?? "");
                tRow.Cells[4].AddParagraph(row.Cells["Amount"].Value?.ToString() ?? "").Format.Alignment = ParagraphAlignment.Right;
                tRow.Cells[5].AddParagraph(row.Cells["Balance"].Value?.ToString() ?? "").Format.Alignment = ParagraphAlignment.Right;

                // Highlight total row
                if ((row.Cells["Account"].Value?.ToString() ?? "").ToUpper().Contains("TOTAL"))
                {
                    tRow.Format.Font.Bold = true;
                    tRow.Format.Font.Underline = Underline.Single;
                    tRow.Shading.Color = Colors.Gainsboro;
                }
            }

            // NOTE: Do NOT call section.Add(dataTable) here.
            // dataTable was created with section.AddTable() and is already part of the section.
            // Calling section.Add(dataTable) would attempt to add the same instance again and cause the ArgumentException.

            // Render and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save "+type+" Report";
                saveFile.FileName = (type + "Report").Trim() + ".pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveFile.FileName);
                    System.Diagnostics.Process.Start("explorer.exe", saveFile.FileName);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = (type + "Report").Trim() + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = type + " Report";

                    Excel.Range headerRange0 = worksheet.Range["C1", "F1"];
                    headerRange0.Merge();
                    headerRange0.Value = guna2HtmlLabel8.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["C2", "F2"];
                    headerRange1.Merge();
                    headerRange1.Value = guna2HtmlLabel7.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["C3", "F3"];
                    headerRange2.Merge();
                    headerRange2.Value = "From " + dtpFrom.Text + " - To " + dtpTo.Text;
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["C4", "F4"];
                    headerRange3.Merge();
                    headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange3.Font.Bold = false;
                    headerRange3.Font.Name = "Times New Roman";
                    headerRange3.Font.Size = 9;
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    int rowIndex = 5;

                    // Column headers
                    for (int col = 0; col < dgvSales.Columns.Count; col++)
                    {
                        var column = dgvSales.Columns[col];

                        // Skip hidden columns if needed
                        if (!column.Visible) continue;

                        var headerCell = worksheet.Cells[rowIndex, col];
                        headerCell.Value = column.HeaderText;  // show column header
                        headerCell.Font.Bold = true;
                        headerCell.Font.Name = "Times New Roman";
                        headerCell.Font.Size = 11;
                        headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                    }

                    rowIndex++; // move to next row for data

                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int colIndex = 1; // Excel column index starts at 1

                        foreach (DataGridViewColumn column in dgvSales.Columns)
                        {
                            if (!column.Visible) continue;

                            object value = row.Cells[column.Name].Value;
                            string textValue = value?.ToString() ?? "";
                            
                            // Write value to Excel
                            var cell = worksheet.Cells[rowIndex, colIndex];
                            cell.Value = textValue;

                            // Common font formatting
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 9;

                            // Check if the value is numeric or decimal
                            if (decimal.TryParse(textValue, out _))
                            {
                                // Right-align numeric values
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            else
                            {
                                // Left-align text by default
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }

                            colIndex++;
                        }

                        rowIndex++;
                    }

                    worksheet.Columns[1].AutoFit();
                    worksheet.Columns[2].AutoFit();
                    worksheet.Columns[3].AutoFit();

                    // Save the workbook and close
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = !chkDate.Checked;
            LoadSalesData();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox3.SelectedItem.ToString(), dtpFrom, dtpTo);
                LoadSalesData();
            }
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
