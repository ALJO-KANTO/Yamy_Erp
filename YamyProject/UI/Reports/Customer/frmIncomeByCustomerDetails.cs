using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmIncomeByCustomerDetails : Form
    {
        int id;
        public frmIncomeByCustomerDetails(int _id=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }

        private void frmIncomeByCustomerDetails_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ";
            DateTime dated = DateTime.Now;
            guna2HtmlLabel11.Text = dated.TimeOfDay.ToString();
            guna2HtmlLabel11.Text = dated.Date.ToShortDateString();
            loadCompany();
            LoadData();
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
        private void LoadData()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>
    {
        DBClass.CreateParameter("@CustomerID", id)
    };

            string dateFilter = "";
            if (!chkDate.Checked)
            {
                dateFilter = " AND t.date >= @dateFrom AND t.date <= @dateTo";
                parameters.Add(DBClass.CreateParameter("@dateFrom", dtpFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)));
            }

            string query = $@"
                                SELECT
                                    t.id,
                                    t.transaction_id,
                                    h.name AS 'Customer',
                                    t.type AS 'Type',
                                    t.date AS 'Date',
                                    t.voucher_no AS 'Num',
                                    t.description AS 'Memo',
                                    acc.name AS 'Account',
                                    t.debit AS 'Debit',
                                    t.credit AS 'Credit'
                                FROM
                                    tbl_transaction t
                                JOIN
                                    tbl_customer h ON t.hum_id = h.id
                                LEFT JOIN
                                    tbl_coa_level_4 acc ON t.account_id = acc.id
                                WHERE
                                    t.type IN ('Sales Invoice', 'Sales Invoice Cash', 'Customer Opening Balance', 'Customer Receipt')
                                    AND h.id = @CustomerID
                                    {dateFilter}
                                ORDER BY
                                    h.name, t.date, t.id;
                            ";

            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());

            // Add Balance column
            dt.Columns.Add("Balance", typeof(decimal));

            // Calculate running balance
            decimal balance = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal debit = row["Debit"] != DBNull.Value ? Convert.ToDecimal(row["Debit"]) : 0;
                decimal credit = row["Credit"] != DBNull.Value ? Convert.ToDecimal(row["Credit"]) : 0;
                balance += debit - credit;
                row["Balance"] = balance;
            }

            dgvSales.DataSource = dt;
            dgvSales.Columns["id"].Visible = dgvSales.Columns["transaction_id"].Visible = false;
            dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9);

            dgvSales.Columns["Debit"].DefaultCellStyle.Format = "N2";
            dgvSales.Columns["Credit"].DefaultCellStyle.Format = "N2";
            dgvSales.Columns["Balance"].DefaultCellStyle.Format = "N2";

            dgvSales.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);
        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvSales.Rows[e.RowIndex].Cells["transaction_id"].Value != null)
                {
                    int _id = int.Parse(dgvSales.Rows[e.RowIndex].Cells["transaction_id"].Value.ToString());
                    var _type = dgvSales.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    if (_type.Contains("Sales Invoice") || _type.Contains("Sales Invoice Cash") )
                    {
                        frmLogin.frmMain.openChildForm(new frmSales(_id));
                    }
                    else if(_type == "Customer Receipt")
                    {
                        frmLogin.frmMain.openChildForm(new frmViewReceiptVoucher(_id));
                    }
                    else if (_type == "Customer Opening Balance")
                    {
                        frmLogin.frmMain.openChildForm(new frmTransactionJournal(_id,_type,_id.ToString()));
                    }
                }
            }
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = !chkDate.Checked;
            LoadData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "IncomeByCustomerDetail.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Income By Customer Detail";

                    // Header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "C1"];
                    headerRange.Merge();
                    headerRange.Value = "Date: " + DateTime.Now.ToString("MMM dd, yyyy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    // Column headers
                    worksheet.Cells[2, 1] = "Customer";
                    worksheet.Cells[2, 2] = "Type";
                    worksheet.Cells[2, 3] = "Date";
                    worksheet.Cells[2, 4] = "Num";
                    worksheet.Cells[2, 5] = "Memo";
                    worksheet.Cells[2, 6] = "Account";
                    worksheet.Cells[2, 7] = "Debit";
                    worksheet.Cells[2, 8] = "Credit";
                    worksheet.Cells[2, 9] = "Balance";

                    for (int i = 1; i <= 9; i++)
                    {
                        var headerCell = worksheet.Cells[2, i];
                        headerCell.Font.Bold = true;
                        headerCell.Font.Name = "Times New Roman";
                        headerCell.Font.Size = 10;
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        headerCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }

                    int rowIndex = 9;
                    decimal totalBalance = 0, totalDebit = 0, totalCredit = 0;
                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;
                        worksheet.Cells[rowIndex, 1] = row.Cells["Customer"].Value?.ToString() ?? "";
                        worksheet.Cells[rowIndex, 2] = row.Cells["Type"].Value?.ToString() ?? "";
                        worksheet.Cells[rowIndex, 3] = row.Cells["Date"].Value != null ? Convert.ToDateTime(row.Cells["Date"].Value).ToString("dd/MM/yyyy") : "";
                        worksheet.Cells[rowIndex, 4] = row.Cells["Num"].Value?.ToString() ?? "";
                        worksheet.Cells[rowIndex, 5] = row.Cells["Memo"].Value?.ToString() ?? "";
                        worksheet.Cells[rowIndex, 6] = row.Cells["Account"].Value?.ToString() ?? "";
                        decimal debit = row.Cells["Debit"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Debit"].Value) : 0;
                        decimal credit = row.Cells["Credit"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Credit"].Value) : 0;
                        decimal balance = row.Cells["Balance"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Balance"].Value) : 0;
                        decimal debitAmount;
                        decimal.TryParse(row.Cells["Debit"].Value?.ToString(), out debitAmount);
                        decimal creditAmount;
                        decimal.TryParse(row.Cells["Credit"].Value?.ToString(), out creditAmount);
                        decimal balanceAmount;
                        decimal.TryParse(row.Cells["Balance"].Value?.ToString(), out balanceAmount);
                        totalBalance += balanceAmount;
                        totalDebit += debitAmount;
                        totalCredit += creditAmount;
                        worksheet.Cells[rowIndex, 7] = debit;
                        worksheet.Cells[rowIndex, 8] = credit;
                        worksheet.Cells[rowIndex, 9] = balance;
                        // Formatting for each row
                        for (int i = 1; i <= 9; i++)
                        {
                            var dataCell = worksheet.Cells[rowIndex, i];
                            dataCell.Font.Name = "Times New Roman";
                            dataCell.Font.Size = 9;
                            if (i >= 7) // Debit, Credit, Balance columns
                            {
                                dataCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                dataCell.NumberFormat = "#,##0.00";
                            }
                            else
                            {
                                dataCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            }
                        }

                        rowIndex++;
                    }
                    // Add TOTAL row
                    worksheet.Cells[rowIndex, 1] = "TOTAL";
                    worksheet.Cells[rowIndex, 1].Font.Bold = true;
                    worksheet.Cells[rowIndex, 7] = totalDebit;
                    worksheet.Cells[rowIndex, 7].Font.Bold = true;
                    worksheet.Cells[rowIndex, 7].Font.Underline = Microsoft.Office.Interop.Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                    worksheet.Cells[rowIndex, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    worksheet.Cells[rowIndex, 8] = totalCredit;
                    worksheet.Cells[rowIndex, 8].Font.Bold = true;
                    worksheet.Cells[rowIndex, 8].Font.Underline = Microsoft.Office.Interop.Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                    worksheet.Cells[rowIndex, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    worksheet.Cells[rowIndex, 9] = totalBalance;
                    worksheet.Cells[rowIndex, 9].Font.Bold = true;
                    worksheet.Cells[rowIndex, 9].Font.Underline = Microsoft.Office.Interop.Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                    worksheet.Cells[rowIndex, 9].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                    worksheet.Columns.AutoFit();

                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string companyName = guna2HtmlLabel8.Text;
            // Create PDF document
            Document doc = new Document();
            Section section = doc.AddSection();

            // Set margins
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Header table
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            // Customer, Type, Date, Num, Memo, Account, Debit, Credit, Balance
            headerTable.AddColumn("11cm"); // Customer
            headerTable.AddColumn("3cm");  // Type
            headerTable.AddColumn("2.5cm");  // Date
            headerTable.AddColumn("2cm");  // Num
            headerTable.AddColumn("4cm");  // Memo
            headerTable.AddColumn("4cm");  // Account
            headerTable.AddColumn("3cm");  // Debit
            headerTable.AddColumn("3cm");  // Credit
            headerTable.AddColumn("3cm");  // Balance

            Row headerRow = headerTable.AddRow();
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText("Income By Customer Detail\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText("All Transactions", TextFormat.NotBold).Font.Size = 9;

            //section.Add(headerTable);

            // Separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Main data table
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0.75;
            dataTable.Format.Font.Name = "Times New Roman";
            dataTable.Format.Alignment = ParagraphAlignment.Center;
            dataTable.Format.Font.Size = 9;

            dataTable.AddColumn("11cm"); // Customer
            dataTable.AddColumn("3cm");  // Type
            dataTable.AddColumn("2.5cm");  // Date
            dataTable.AddColumn("2cm");  // Num
            dataTable.AddColumn("4cm");  // Memo
            dataTable.AddColumn("4cm");  // Account
            dataTable.AddColumn("3cm");  // Debit
            dataTable.AddColumn("3cm");  // Credit
            dataTable.AddColumn("3cm");  // Balance

            Row header = dataTable.AddRow();
            header.Shading.Color = Colors.LightGray;
            header.Format.Font.Bold = true;
            header.Cells[0].AddParagraph("Customer");
            header.Cells[1].AddParagraph("Type");
            header.Cells[2].AddParagraph("Date");
            header.Cells[3].AddParagraph("Num");
            header.Cells[4].AddParagraph("Memo");
            header.Cells[5].AddParagraph("Account");
            header.Cells[6].AddParagraph("Debit");
            header.Cells[7].AddParagraph("Credit");
            header.Cells[8].AddParagraph("Balance");
            // Add data rows
            decimal totalBalance = 0, totalDebit = 0, totalCredit = 0;
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                string customer = row.Cells["Customer"].Value?.ToString() ?? "";
                string type = row.Cells["Type"].Value?.ToString() ?? "";
                string date = row.Cells["Date"].Value != null ? Convert.ToDateTime(row.Cells["Date"].Value).ToString("dd/MM/yyyy") : "";
                string num = row.Cells["Num"].Value?.ToString() ?? "";
                string memo = row.Cells["Memo"].Value?.ToString() ?? "";
                string account = row.Cells["Account"].Value?.ToString() ?? "";
                decimal debit = row.Cells["Debit"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Debit"].Value) : 0;
                decimal credit = row.Cells["Credit"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Credit"].Value) : 0;
                decimal balance = row.Cells["Balance"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Balance"].Value) : 0;

                decimal debitAmount;
                decimal.TryParse(row.Cells["Debit"].Value?.ToString(), out debitAmount);
                decimal creditAmount;
                decimal.TryParse(row.Cells["Credit"].Value?.ToString(), out creditAmount);
                decimal balanceAmount;
                decimal.TryParse(row.Cells["Balance"].Value?.ToString(), out balanceAmount);
                totalBalance += balanceAmount;
                totalDebit += debitAmount;
                totalCredit += creditAmount;

                Row dataRow = dataTable.AddRow();
                dataRow.Cells[0].AddParagraph(customer);
                dataRow.Cells[1].AddParagraph(type);
                dataRow.Cells[2].AddParagraph(date);
                dataRow.Cells[3].AddParagraph(num);
                dataRow.Cells[4].AddParagraph(memo);
                dataRow.Cells[5].AddParagraph(account);
                dataRow.Cells[6].AddParagraph(debit.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                dataRow.Cells[7].AddParagraph(credit.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
                dataRow.Cells[8].AddParagraph(balance.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
            }

            // Totals row
            Row totalsRow = dataTable.AddRow();
            totalsRow.Cells[0].MergeRight = 1;
            totalsRow.Cells[0].AddParagraph("TOTAL").Format.Font.Bold = true;

            totalsRow.Cells[6].AddParagraph(totalDebit.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
            totalsRow.Cells[7].AddParagraph(totalCredit.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;
            totalsRow.Cells[8].AddParagraph(totalBalance.ToString("N2")).Format.Alignment = ParagraphAlignment.Right;

            //section.Add(dataTable);

            // Ask user to save file
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveDialog.Title = "Save Income By Customer Detail";
                saveDialog.FileName = "IncomeByCustomerDetail.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                    renderer.Document = doc;
                    renderer.RenderDocument();
                    renderer.PdfDocument.Save(saveDialog.FileName);
                    Process.Start("explorer.exe", saveDialog.FileName);
                }
            }
        }
    }
}
