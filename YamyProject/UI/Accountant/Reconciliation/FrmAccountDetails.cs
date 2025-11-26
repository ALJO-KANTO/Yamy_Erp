using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject.UI.Accountant.Reconciliation
{
    public partial class FrmAccountDetails : Form
    {
        private string _accountId;
        string lblCompany = "";
        string header_text = "Reconciliation Detail";
        public FrmAccountDetails(string accountId, string accountName)
        {
            InitializeComponent();
            _accountId = accountId;
            //lblAccountName.Text = accountName;
            LoadTransactions();
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    lblCompany = reader["name"].ToString();
                }
            }
        }

        private void LoadTransactions()
        {
            dgvTransactions.Columns.Add("date", "DATE");
            dgvTransactions.Columns.Add("number", "NUMBER");
            dgvTransactions.Columns.Add("type", "TYPE");
            dgvTransactions.Columns.Add("account", "ACCOUNT");
            dgvTransactions.Columns.Add("payee", "PAYEE");
            dgvTransactions.Columns.Add("memo", "MEMO");
            dgvTransactions.Columns.Add("payment", "PAYMENT");
            dgvTransactions.Columns.Add("deposit", "DEPOSIT");
            dgvTransactions.Columns.Add("balance", "BALANCE");
            dgvTransactions.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTransactions.Columns["payment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["deposit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["payment"].DefaultCellStyle.Format = dgvTransactions.Columns["deposit"].DefaultCellStyle.Format = dgvTransactions.Columns["balance"].DefaultCellStyle.Format = "N2";

            dgvTransactions.Columns["payment"].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvTransactions.Columns["deposit"].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvTransactions.Columns["balance"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;


            string query = @"SELECT t.date,transaction_id number, TYPE,a.name ACCOUNT,'' payee,description memo,t.debit as payment,t.credit as deposit,0 balance
                     FROM tbl_transaction t Inner Join tbl_coa_level_4 a ON t.account_id = a.id
                     WHERE t.account_id = @account_id
                     ORDER BY t.date";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query, new MySqlParameter("@account_id", _accountId)))
            {
                decimal runningBalance = 0;
                while (reader.Read())
                {
                    runningBalance += Convert.ToDecimal(reader["payment"]) - Convert.ToDecimal(reader["deposit"]);
                    dgvTransactions.Rows.Add(
                        reader["date"],
                        reader["number"],
                        reader["type"],
                        reader["account"],
                        reader["payee"],
                        reader["memo"],
                        reader["payment"],
                        reader["deposit"],
                        runningBalance.ToString("N2")
                    );
                }
                guna2TextBox1.Text = runningBalance.ToString("N2");
            }
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Honeydew;
            dgvTransactions.Columns["balance"].DefaultCellStyle.Format = "N2";
        }

        private void dgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "BALANCE" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val) && val < 0)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        bool DrawRect, showPnlHeader;
        private int rowIndex = 0;
        private int pageNumber = 1;
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            string companyName = lblCompany;
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
            string title = header_text.Replace(" ", "");
            FormattedText summaryText = center.AddFormattedText(title + "\n", TextFormat.Bold);
            summaryText.Font.Size = 12;

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;


            //section.Add(headerTable);

            // Bold line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";


            //dynamic columns so i want to create table based on dgv columns
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0;
            // Add columns based on DataGridView
            // Add columns starting from index 3
            for (int i = 3; i < dgvTransactions.Columns.Count; i++)
            {
                DataGridViewColumn dgvCol = dgvTransactions.Columns[i];
                if (dgvCol.Visible) // only add visible columns
                {
                    dataTable.AddColumn(Unit.FromCentimeter(3)); // Adjust width as needed
                }
            }

            // Add header row
            Row header = dataTable.AddRow();
            int colIndex = 0;
            for (int i = 3; i < dgvTransactions.Columns.Count; i++)
            {
                DataGridViewColumn dgvCol = dgvTransactions.Columns[i];
                if (!dgvCol.Visible) continue;

                Paragraph p = header.Cells[colIndex].AddParagraph(dgvCol.HeaderText);
                p.Format.Font.Bold = true;
                p.Format.Font.Name = "Times New Roman";
                p.Format.Alignment = ParagraphAlignment.Center;
                colIndex++;
            }

            // Add data rows
            foreach (DataGridViewRow dgvRow in dgvTransactions.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                Row row = dataTable.AddRow();
                int dataColIndex = 0;

                for (int i = 3; i < dgvTransactions.Columns.Count; i++)
                {
                    DataGridViewColumn dgvCol = dgvTransactions.Columns[i];
                    if (!dgvCol.Visible) continue;

                    DataGridViewCell dgvCell = dgvRow.Cells[i];
                    Paragraph p = row.Cells[dataColIndex].AddParagraph(dgvCell.Value?.ToString() ?? "");
                    p.Format.Font.Name = "Times New Roman";

                    // Align numeric columns to right
                    string colName = dgvCol.Name.ToLower();
                    if (colName.Contains("deposit") || colName.Contains("payment") || colName.Contains("balance"))
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

            //section.Add(dataTable);

            // Render and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), title + ".pdf");
            renderer.PdfDocument.Save(filePath);
            Process.Start("explorer.exe", filePath);
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = header_text.Replace(" ", "") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = header_text.Replace(" ", "");

                    Excel.Range headerRange0 = worksheet.Range["D1", "F1"];
                    headerRange0.Merge();
                    headerRange0.Value = lblCompany;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    //headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["A2", "C2"];
                    headerRange1.Merge();
                    headerRange1.Value = header_text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["A3", "C3"];
                    headerRange2.Merge();
                    headerRange2.Value = "Sorted By: Date, Type, Number/Ref";
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["G4", "H4"];
                    headerRange3.Merge();
                    headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange3.Font.Bold = false;
                    headerRange3.Font.Name = "Times New Roman";
                    headerRange3.Font.Size = 9;
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    int rowIndex = 5;

                    // 1️⃣ Write header row first
                    for (int col = 0; col < dgvTransactions.Columns.Count; col++)
                    {
                        var column = dgvTransactions.Columns[col];

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

                    // 2️⃣ Write data rows
                    rowIndex++; // move to next row for data
                    foreach (DataGridViewRow row in dgvTransactions.Rows)
                    {
                        if (row.IsNewRow) continue; // skip the new row

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            var column = dgvTransactions.Columns[cell.ColumnIndex];
                            if (!column.Visible) continue;

                            var excelCell = worksheet.Cells[rowIndex, cell.ColumnIndex + 1];

                            // Set cell value
                            excelCell.Value = cell.Value?.ToString() ?? string.Empty;

                            // Default font
                            excelCell.Font.Name = "Times New Roman";
                            excelCell.Font.Size = 10;

                            // Handle dynamic columns by header text
                            string columnName = column.HeaderText.ToLower();

                            if (columnName.Contains("balance") ||
                                     columnName.Contains("deposit") ||
                                     columnName.Contains("payment"))
                            {
                                excelCell.Font.Size = 9;
                                excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            else
                            {
                                excelCell.Font.Size = 10;
                                excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }
                        }

                        rowIndex++; // move to next row
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
    }
}
