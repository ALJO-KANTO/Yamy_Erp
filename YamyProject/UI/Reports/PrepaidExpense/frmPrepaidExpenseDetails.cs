using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmPrepaidExpenseDetails : Form
    {
        int id;
        public frmPrepaidExpenseDetails(int _id=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }

        private void frmPrepaidExpenseDetails_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print";
            DateTime dated = DateTime.Now;
            guna2HtmlLabel11.Text = dated.TimeOfDay.ToString();
            guna2HtmlLabel11.Text = dated.Date.ToShortDateString();
            loadCompany();
            LoadFixedAssetDetails();
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
        private void LoadFixedAssetDetails()
        {
            dgvSales.Rows.Clear();

            if (dgvSales.Columns.Count == 0)
            {
                dgvSales.Columns.Add("id", "SN");
                dgvSales.Columns.Add("Date", "Date");
                dgvSales.Columns.Add("transactionId", "Transaction ID");
                dgvSales.Columns.Add("AccountCode", "A/C CODE");
                dgvSales.Columns.Add("AccountName", "A/C NAME");
                dgvSales.Columns.Add("Debit", "Debit");
                dgvSales.Columns.Add("Credit", "Credit");
                dgvSales.Columns.Add("Type", "Type");
                LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);

                dgvSales.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSales.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSales.Columns["Debit"].DefaultCellStyle.Format = "N2";
                dgvSales.Columns["Credit"].DefaultCellStyle.Format = "N2";
                dgvSales.Columns["transactionId"].Visible = false;

                foreach (DataGridViewColumn col in dgvSales.Columns)
                {
                    col.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8F, FontStyle.Regular);
                }

                dgvSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8F, FontStyle.Bold);
                dgvSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvSales.EnableHeadersVisualStyles = false;
                dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvSales.GridColor = System.Drawing.Color.LightGray;
                dgvSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                dgvSales.RowHeadersVisible = false;
                dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                DBClass.CreateParameter("transaction_id", id)
            };

            string dateFilter = "";

            if (!chkDate.Checked)
            {
                dateFilter = " AND t.date BETWEEN @dateFrom AND @dateTo";
                parameters.Add(DBClass.CreateParameter("dateFrom", dtpFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)));
            }

            string query = $@"
                            SELECT 
                                ROW_NUMBER() OVER (ORDER BY t.date) AS `SN`,
                                t.date,
                                t.transaction_id,
                                t.type AS `Type`,
                                c.code AS `A/C CODE`,
                                c.name AS `A/C NAME`,
                                t.debit AS `DEBIT`,
                                t.credit AS `CREDIT`
                            FROM 
                                tbl_transaction t
                            INNER JOIN 
                                tbl_coa_level_4 c ON t.account_id = c.id
                            WHERE 
                                t.transaction_id = @transaction_id
                                AND t.type = 'Prepaid Expense'
                                {dateFilter};";

            decimal totalDebit = 0;
            decimal totalCredit = 0;

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters.ToArray()))
            {
                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["date"]);
                    string transactionId = reader["transaction_id"].ToString();
                    string accountCode = reader["A/C CODE"].ToString();
                    string accountName = reader["A/C NAME"].ToString();
                    decimal debit = Convert.ToDecimal(reader["DEBIT"]);
                    decimal credit = Convert.ToDecimal(reader["CREDIT"]);
                    string Type = reader["Type"].ToString();

                    int rowIndex = dgvSales.Rows.Add(
                        reader["SN"].ToString(),
                        date.ToString("MMM dd, yyyy"),
                        transactionId,
                        accountCode,
                        accountName,
                        debit.ToString("N2"),
                        credit.ToString("N2"),
                        Type
                    );

                    dgvSales.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvSales.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8F, FontStyle.Regular);

                    totalDebit += debit;
                    totalCredit += credit;
                }
            }

            // Add total row
            int totalRow = dgvSales.Rows.Add("", "", "", "TOTAL", "", totalDebit.ToString("N2"), totalCredit.ToString("N2"));
            dgvSales.Rows[totalRow].DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8F, FontStyle.Bold | FontStyle.Underline);
            dgvSales.Rows[totalRow].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            dgvSales.Rows[totalRow].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.Rows[totalRow].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSales.Rows[totalRow].Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvSales.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    int _id = int.Parse(dgvSales.Rows[e.RowIndex].Cells["transactionId"].Value.ToString());
                    var _type = dgvSales.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    if (_type.Contains("Prepaid Expense"))
                    {
                        frmLogin.frmMain.openChildForm(new frmViewPrepaidExpense(_id));
                    }
                }
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSales.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // numeric columns to sum/format
                var numericCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Debit", "Credit" };

                decimal totalDebit = 0m;
                decimal totalCredit = 0m;

                // Prepare document
                Document doc = new Document();
                Section section = doc.AddSection();
                section.PageSetup.TopMargin = Unit.FromCentimeter(1);
                section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
                section.PageSetup.RightMargin = Unit.FromCentimeter(1);
                section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

                // header: company and date/time
                string companyName = "";
                using (MySqlDataReader rd = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                {
                    if (rd.Read() && rd["name"] != DBNull.Value) companyName = rd["name"].ToString();
                }

                Table headerTable = section.AddTable();
                headerTable.Borders.Width = 0;
                headerTable.AddColumn("5cm");
                headerTable.AddColumn("8cm");
                headerTable.AddColumn("5cm");
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
                center.AddFormattedText("Prepaid Expense Details\n", TextFormat.Bold).Font.Size = 12;
                center.AddFormattedText($"From: {dtpFrom.Value:dd/MM/yyyy}  To: {dtpTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

                Paragraph sep = section.AddParagraph();
                sep.Format.Borders.Bottom.Width = 2;
                sep.Format.SpaceAfter = "0.5cm";

                // build table columns dynamically based on grid
                Table table = section.AddTable();
                table.Borders.Width = 0.75;
                table.Format.Font.Name = "Times New Roman";
                table.Format.Font.Size = 9;

                for (int c = 0; c < dgvSales.Columns.Count; c++)
                {
                    var col = dgvSales.Columns[c];
                    if (numericCols.Contains(col.Name))
                        table.AddColumn("2.5cm");
                    else if (col.Name.Equals("AccountName", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Type", StringComparison.OrdinalIgnoreCase))
                        table.AddColumn("4.0cm");
                    else
                        table.AddColumn("2.5cm");
                }

                // header row
                Row hdr = table.AddRow();
                hdr.Shading.Color = Colors.LightGray;
                hdr.Format.Font.Bold = true;
                for (int c = 0; c < dgvSales.Columns.Count; c++)
                {
                    hdr.Cells[c].AddParagraph(dgvSales.Columns[c].HeaderText);
                }

                // data rows - skip the grid TOTAL row (AccountCode == "TOTAL")
                foreach (DataGridViewRow r in dgvSales.Rows)
                {
                    if (r.IsNewRow) continue;
                    string acctCode = Convert.ToString(r.Cells["AccountCode"].Value ?? "");
                    if (!string.IsNullOrEmpty(acctCode) && acctCode.Trim().ToUpper() == "TOTAL")
                        continue;

                    Row row = table.AddRow();
                    for (int c = 0; c < dgvSales.Columns.Count; c++)
                    {
                        string colName = dgvSales.Columns[c].Name;
                        string text = r.Cells[c].Value?.ToString() ?? "";
                        if (numericCols.Contains(colName))
                        {
                            decimal d;
                            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out d))
                            {
                                row.Cells[c].AddParagraph(d.ToString("N2"));
                                row.Cells[c].Format.Alignment = ParagraphAlignment.Right;

                                if (colName.Equals("Debit", StringComparison.OrdinalIgnoreCase)) totalDebit += d;
                                if (colName.Equals("Credit", StringComparison.OrdinalIgnoreCase)) totalCredit += d;
                            }
                            else
                            {
                                row.Cells[c].AddParagraph(text);
                                row.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            row.Cells[c].AddParagraph(text);
                        }
                    }
                }

                // totals row
                Row tot = table.AddRow();
                tot.Format.Font.Bold = true;
                int firstNumericIndex = -1;
                for (int i = 0; i < dgvSales.Columns.Count; i++)
                    if (numericCols.Contains(dgvSales.Columns[i].Name)) { firstNumericIndex = i; break; }
                if (firstNumericIndex <= 0) firstNumericIndex = Math.Min(1, dgvSales.Columns.Count - 1);
                tot.Cells[0].MergeRight = firstNumericIndex - 1;
                tot.Cells[0].AddParagraph("TOTAL");

                for (int c = 0; c < dgvSales.Columns.Count; c++)
                {
                    string colName = dgvSales.Columns[c].Name;
                    if (colName.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                    {
                        tot.Cells[c].AddParagraph(totalDebit.ToString("N2"));
                        tot.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                    }
                    else if (colName.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                    {
                        tot.Cells[c].AddParagraph(totalCredit.ToString("N2"));
                        tot.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                    }
                }

                // render and save
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
                {
                    Document = doc
                };
                renderer.RenderDocument();

                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFile.Title = "Save Prepaid Expense Details";
                    saveFile.FileName = "PrepaidExpenseDetails.pdf";

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        renderer.PdfDocument.Save(saveFile.FileName);
                        Process.Start("explorer.exe", saveFile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "CustomerBalanceDetails.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Customer Balance Details";

                    // Merge and format header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "G1"];
                    headerRange.Merge();
                    headerRange.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    // Adding Column Headers
                    worksheet.Cells[2, 1] = "ID";
                    worksheet.Cells[2, 2] = "Type";
                    worksheet.Cells[2, 3] = "Date";
                    worksheet.Cells[2, 4] = "transactionId";
                    worksheet.Cells[2, 5] = "Account";
                    worksheet.Cells[2, 6] = "Amount";
                    worksheet.Cells[2, 7] = "Balance";

                    int rowIndex = 3;
                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string id = row.Cells["id"].Value?.ToString();
                        string type = row.Cells["Type"].Value?.ToString();
                        string date = row.Cells["Date"].Value?.ToString();
                        string num = row.Cells["transactionId"].Value?.ToString();
                        string account = row.Cells["Account"].Value?.ToString();
                        string amount = row.Cells["Amount"].Value?.ToString();
                        string balance = row.Cells["Balance"].Value?.ToString();

                        worksheet.Cells[rowIndex, 1] = id;
                        worksheet.Cells[rowIndex, 2] = type;
                        worksheet.Cells[rowIndex, 3] = date;
                        worksheet.Cells[rowIndex, 4] = num;
                        worksheet.Cells[rowIndex, 5] = account;
                        worksheet.Cells[rowIndex, 6] = amount;
                        worksheet.Cells[rowIndex, 7] = balance;

                        // Formatting the cells
                        var accountCell = worksheet.Cells[rowIndex, 5];
                        var amountCell = worksheet.Cells[rowIndex, 6];

                        accountCell.Font.Name = "Times New Roman";
                        amountCell.Font.Name = "Times New Roman";

                        // If account contains 'TOTAL', apply special formatting
                        if (account.ToUpper().Contains("TOTAL"))
                        {
                            accountCell.Font.Size = 10;
                            accountCell.Font.Bold = true;

                            amountCell.Font.Size = 10;
                            amountCell.Font.Bold = true;
                            amountCell.Font.Underline = Microsoft.Office.Interop.Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                        }
                        else
                        {
                            accountCell.Font.Size = 10;
                            accountCell.Font.Bold = true;

                            amountCell.Font.Size = 9;
                        }

                        amountCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                        rowIndex++;
                    }

                    worksheet.Columns[1].AutoFit();
                    worksheet.Columns[2].AutoFit();
                    worksheet.Columns[3].AutoFit();
                    worksheet.Columns[4].AutoFit();
                    worksheet.Columns[5].AutoFit();
                    worksheet.Columns[6].AutoFit();
                    worksheet.Columns[7].AutoFit();

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
            LoadFixedAssetDetails();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadFixedAssetDetails();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = !chkDate.Checked;
            LoadFixedAssetDetails();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dtpFrom, dtpTo);
                LoadFixedAssetDetails();
            }
        }
    }
}
