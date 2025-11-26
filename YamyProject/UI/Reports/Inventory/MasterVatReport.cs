using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterVatReport : Form
    {
        public MasterVatReport()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //_mainForm.openChildForm(new frmAddnvoice(_mainForm, this, 0));
        }
        private void MasterVatReport_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            BindVat();
        }
        public void BindVat()
        {
            DataTable dt;

            if (cmbType.Text == "Vat Input")
            {
                if (chkDate.Checked)
                    dt = DBClass.ExecuteDataTable(@"SELECT s.id,'Purchase' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                             s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                            FROM tbl_purchase s, tbl_vendor c
                            WHERE s.vendor_id = c.id AND s.vat>0
                            UNION ALL
                            SELECT s.id,'Sales Return' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                    s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                                    FROM tbl_sales_return s, tbl_customer c
                                    WHERE s.customer_id = c.id AND s.vat>0
                            UNION ALL
                            SELECT s.id,'Debit Note' TYPE,s.date AS DATE,s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                     '' AS 'Payment Method',s.amount AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.total AS 'Total Amount' 
									FROM tbl_debit_note s, tbl_vendor c, tbl_purchase p
                            WHERE p.invoice_id = s.invoice_id and p.vendor_id = c.id AND s.vat>0 
                            UNION ALL
                            SELECT s.id,'Petty Cash' type,s.date AS DATE,s.code AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                     '' AS 'Payment Method',s.total_before_vat AS 'Amount Before Vat', s.total_vat AS 'Vat Amount', s.net_amount AS 'Total Amount' 
									FROM tbl_petty_cash_submition s, tbl_employee c
							WHERE s.name = c.id AND s.total_vat>0");
                else
                    dt = DBClass.ExecuteDataTable(@"SELECT s.id,'Purchase' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                             s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                            FROM tbl_purchase s, tbl_vendor c
                            WHERE s.vendor_id = c.id AND s.vat>0 AND s.DATE BETWEEN @datefrom AND @dateTo
                            UNION ALL
                            SELECT s.id,'Sales Return' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                   s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                                   FROM tbl_sales_return s, tbl_customer c
                                   WHERE s.customer_id = c.id AND s.vat>0 AND s.DATE BETWEEN @datefrom AND @dateTo
                            UNION ALL
                            SELECT s.id,'Debit Note' TYPE,s.date AS DATE,s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                   '' AS 'Payment Method',s.amount AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.total AS 'Total Amount' 
								   FROM tbl_debit_note s, tbl_vendor c, tbl_purchase p
                            WHERE p.invoice_id = s.invoice_id and p.vendor_id = c.id AND s.vat>0 AND s.DATE BETWEEN @datefrom AND @dateTo 
                            UNION ALL
                            SELECT s.id,'Petty Cash' type,s.date AS DATE,s.code AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                     '' AS 'Payment Method',s.total_before_vat AS 'Amount Before Vat', s.total_vat AS 'Vat Amount', s.net_amount AS 'Total Amount' 
									FROM tbl_petty_cash_submition s, tbl_employee c
							WHERE s.name = c.id AND s.total_vat>0 AND s.DATE BETWEEN @datefrom AND @dateTo",
                DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                            DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            }
            else
            {
                if (chkDate.Checked)
                    dt = DBClass.ExecuteDataTable(@"SELECT s.id,'Sales' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                                    s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                                                    FROM tbl_sales s, tbl_customer c WHERE s.customer_id = c.id AND s.vat>0
                                                    UNION ALL
                                                    SELECT s.id,'Purchase Return' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                                    s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                                                    FROM tbl_purchase_return s, tbl_vendor c WHERE s.vendor_id = c.id AND s.vat>0
                                                    UNION ALL
                                                    SELECT s.id,'Debit Note' TYPE,s.date AS DATE,s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                                    '' AS 'Payment Method',s.amount AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.total AS 'Total Amount' 
                                                    FROM tbl_credit_note s, tbl_customer c, tbl_sales p
                                                    WHERE p.invoice_id = s.invoice_id and p.customer_id = c.id AND s.vat>0  ");
                else
                    dt = DBClass.ExecuteDataTable(@"SELECT s.id,'Sales' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                                    s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                                                    FROM tbl_sales s, tbl_customer c WHERE s.customer_id = c.id AND s.vat>0
                                                    UNION ALL
                                                    SELECT s.id,'Purchase Return' type,s.date AS DATE, s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                                    s.payment_method AS 'Payment Method',s.total AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.net AS 'Total Amount'
                                                    FROM tbl_purchase_return s, tbl_vendor c WHERE s.vendor_id = c.id AND s.vat>0
                                                    UNION ALL
                                                    SELECT s.id,'Credit Note' TYPE,s.date AS DATE,s.invoice_id AS 'Inv No', CONCAT(c.code,' - ',c.name) AS 'Name',
                                                    '' AS 'Payment Method',s.amount AS 'Amount Before Vat', s.vat AS 'Vat Amount', s.total AS 'Total Amount' 
                                                    FROM tbl_credit_note s, tbl_customer c, tbl_sales p
                                                    WHERE p.invoice_id = s.invoice_id and p.customer_id = c.id AND s.vat>0 AND s.DATE BETWEEN @datefrom AND @dateTo",
                                        DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                                        DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            }
            dgvCustomer.DataSource = dt;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Amount Before Vat"].Width = dgvCustomer.Columns["Vat Amount"].Width = dgvCustomer.Columns["Total Amount"].Width = 160;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "N2";
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns["Amount Before Vat"].DefaultCellStyle = style;
            dgvCustomer.Columns["Vat Amount"].DefaultCellStyle = style;
            dgvCustomer.Columns["Total Amount"].DefaultCellStyle = style;
            dgvCustomer.Columns["Payment Method"].Width = 120;
            dgvCustomer.Columns["type"].Width = 100;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbType.Text == "Customer")
                BindVat();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            //_mainForm.openChildForm(new frmAddnvoice(_mainForm, this, int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            string type = cmbType.Text.Trim() == "Vat Input" ? "Vat Input" : "Vat Output";

            //frmLogin.frmMain.openChildForm(new MasterTransactionJournal("0", type));
            //else
            if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Sales")
                frmLogin.frmMain.openChildForm(new frmSales(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            else if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Purchase")
                frmLogin.frmMain.openChildForm(new frmPurchase(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            else if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Purchase Return")
                frmLogin.frmMain.openChildForm(new frmPurchaseReturn(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            else if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Sales Return")
                frmLogin.frmMain.openChildForm(new frmSalesReturn(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            else if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Debit Note")
                frmLogin.frmMain.openChildForm(new frmDebitNote(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            else if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Credit Note")
                frmLogin.frmMain.openChildForm(new frmCreditNote(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            else if (dgvCustomer.CurrentRow.Cells["type"].Value.ToString() == "Petty Cash")
                frmLogin.frmMain.openChildForm(new frmPettyCashSubmission(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_sales SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Sales", "Sales", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Sales: " + dgvCustomer.SelectedRows[0].Cells["Inv No"].Value.ToString());
            
            BindVat();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            //_mainForm.openChildForm(new MasterInventoryRecycle(_mainForm, this));

        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindVat();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVat();
            headerUC1.FormText = "Vat Report ( "+cmbType.Text+" )";
        }

        private void BindTypes(string text)
        {
          
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindVat();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Build PDF of displayed VAT rows and append totals for numeric columns
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Amount Before Vat", "Vat Amount", "Total Amount"
            };

            // compute totals
            var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            foreach (DataGridViewColumn col in dgvCustomer.Columns)
                if (numericColumns.Contains(col.Name))
                    totals[col.Name] = 0m;

            foreach (DataGridViewRow r in dgvCustomer.Rows)
            {
                if (r.IsNewRow) continue;
                foreach (var key in new List<string>(totals.Keys))
                {
                    object v = null;
                    try { v = r.Cells[key].Value; } catch { v = null; }
                    decimal d;
                    if (decimal.TryParse(Convert.ToString(v), NumberStyles.Any, CultureInfo.CurrentCulture, out d))
                        totals[key] += d;
                }
            }

            // company
            string companyName = "";
            using (MySqlDataReader rd = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
            {
                if (rd.Read() && rd["name"] != DBNull.Value) companyName = rd["name"].ToString();
            }

            // create PDF
            Document doc = new Document();
            Section section = doc.AddSection();
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // header
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
            center.AddFormattedText("VAT Report - " + cmbType.Text + "\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText($"From: {dtFrom.Value:dd/MM/yyyy}  To: {dtTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

            Paragraph separator = section.AddParagraph();
            separator.Format.Borders.Bottom.Width = 2;
            separator.Format.SpaceAfter = "0.5cm";

            // data table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // add columns mapped to grid columns
            for (int c = 0; c < dgvCustomer.Columns.Count; c++)
            {
                var col = dgvCustomer.Columns[c];
                if (numericColumns.Contains(col.Name))
                    table.AddColumn("3.0cm");
                else if (col.Name.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    table.AddColumn("5.0cm");
                else
                    table.AddColumn("3.0cm");
            }

            // header row
            Row hdr = table.AddRow();
            hdr.Shading.Color = Colors.LightGray;
            hdr.Format.Font.Bold = true;
            for (int c = 0; c < dgvCustomer.Columns.Count; c++)
                hdr.Cells[c].AddParagraph(dgvCustomer.Columns[c].HeaderText);

            // rows
            foreach (DataGridViewRow r in dgvCustomer.Rows)
            {
                if (r.IsNewRow) continue;
                Row row = table.AddRow();
                for (int c = 0; c < dgvCustomer.Columns.Count; c++)
                {
                    string colName = dgvCustomer.Columns[c].Name;
                    string text = r.Cells[c].Value?.ToString() ?? "";
                    if (numericColumns.Contains(colName))
                    {
                        decimal d;
                        string formatted = decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out d) ? d.ToString("N2") : text;
                        row.Cells[c].AddParagraph(formatted);
                        row.Cells[c].Format.Alignment = ParagraphAlignment.Right;
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
            for (int i = 0; i < dgvCustomer.Columns.Count; i++)
                if (numericColumns.Contains(dgvCustomer.Columns[i].Name)) { firstNumericIndex = i; break; }
            if (firstNumericIndex <= 0) firstNumericIndex = Math.Min(1, dgvCustomer.Columns.Count - 1);
            tot.Cells[0].MergeRight = firstNumericIndex - 1;
            tot.Cells[0].AddParagraph("TOTAL");

            for (int c = 0; c < dgvCustomer.Columns.Count; c++)
            {
                string colName = dgvCustomer.Columns[c].Name;
                if (numericColumns.Contains(colName))
                {
                    decimal v = totals.ContainsKey(colName) ? totals[colName] : 0m;
                    tot.Cells[c].AddParagraph(v.ToString("N2"));
                    tot.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                }
            }

            // render
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save VAT Report";
                saveFile.FileName = "VatReport.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveFile.FileName);
                    Process.Start("explorer.exe", saveFile.FileName);
                }
            }
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Amount Before Vat", "Vat Amount", "Total Amount"
            };

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save VAT Report";
                saveDialog.FileName = "VatReport.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "VatReport";

                int cols = dgvCustomer.Columns.Count;

                // Header merged row
                var headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, cols]];
                headerRange.Merge();
                headerRange.Value = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
                headerRange.Font.Bold = true;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.Size = 10;
                headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Column headers
                for (int c = 0; c < cols; c++)
                {
                    worksheet.Cells[2, c + 1] = dgvCustomer.Columns[c].HeaderText;
                    var hdr = worksheet.Cells[2, c + 1] as Microsoft.Office.Interop.Excel.Range;
                    hdr.Font.Bold = true;
                    hdr.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    hdr.Font.Name = "Times New Roman";
                    hdr.Font.Size = 10;
                    hdr.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }

                int rowIndex = 3;
                var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
                foreach (DataGridViewColumn col in dgvCustomer.Columns)
                    if (numericColumns.Contains(col.Name))
                        totals[col.Name] = 0m;

                for (int r = 0; r < dgvCustomer.Rows.Count; r++)
                {
                    var gridRow = dgvCustomer.Rows[r];
                    if (gridRow.IsNewRow) continue;

                    for (int c = 0; c < cols; c++)
                    {
                        string colName = dgvCustomer.Columns[c].Name;
                        object val = gridRow.Cells[c].Value;
                        if (numericColumns.Contains(colName))
                        {
                            decimal d;
                            decimal.TryParse(Convert.ToString(val), NumberStyles.Any, CultureInfo.CurrentCulture, out d);
                            worksheet.Cells[rowIndex, c + 1] = d;
                            var rng = worksheet.Cells[rowIndex, c + 1] as Microsoft.Office.Interop.Excel.Range;
                            rng.NumberFormat = "#,##0.00";
                            rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            totals[colName] += d;
                        }
                        else
                        {
                            worksheet.Cells[rowIndex, c + 1] = val?.ToString() ?? "";
                            var rng = worksheet.Cells[rowIndex, c + 1] as Microsoft.Office.Interop.Excel.Range;
                            rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        }
                    }

                    rowIndex++;
                }

                // totals row
                int totalRow = rowIndex;
                int firstNumericIndex = -1;
                for (int i = 0; i < cols; i++)
                    if (numericColumns.Contains(dgvCustomer.Columns[i].Name)) { firstNumericIndex = i + 1; break; }
                if (firstNumericIndex <= 1) firstNumericIndex = Math.Min(2, cols);

                var labelRange = worksheet.Range[worksheet.Cells[totalRow, 1], worksheet.Cells[totalRow, firstNumericIndex - 1]];
                labelRange.Merge();
                labelRange.Value = "TOTAL";
                labelRange.Font.Bold = true;
                labelRange.Font.Name = "Times New Roman";

                for (int c = 0; c < cols; c++)
                {
                    string colName = dgvCustomer.Columns[c].Name;
                    if (numericColumns.Contains(colName))
                    {
                        var cell = worksheet.Cells[totalRow, c + 1] as Microsoft.Office.Interop.Excel.Range;
                        cell.Value = totals[colName];
                        cell.NumberFormat = "#,##0.00";
                        cell.Font.Bold = true;
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    }
                }

                worksheet.Columns.AutoFit();
                workbook.SaveAs(saveDialog.FileName);
                workbook.Close(false);
                excelApp.Quit();

                MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
