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
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class MasterSalesReport : Form
    {
        private string type;

        public MasterSalesReport(string _type="")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            type = _type;
            headerUC1.FormText = this.Text;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }
        
        private void MasterSalesReport_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            
            cmbSelectionMethod.Text = type == "Customer Summary"? "" : type == "Item Details" ? "Item Wise" : type == "Item Summary" ? "Item Wise" : type== "Aging Summary" ? "A/R Aging Summary" : "";

            BindInvoices();
        }
        public void BindInvoices()
        {
            DataTable dt;
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            string query = "";

            if (cmbSelectionMethod.Text == "A/R Aging Details")
            {
                query = @"SELECT 
                                ROW_NUMBER() OVER (ORDER BY tbl_sales.date) AS `SN`, 
                                tbl_sales.date AS Date, 
                                tbl_sales.id,
                                CONCAT('000', MAX(tbl_transaction.transaction_id)) AS 'JV NO', 
                                tbl_sales.invoice_id AS 'INV NO', 
                                CONCAT(tbl_customer.code, ' - ', tbl_customer.name) AS 'Customer Name', 
                                tbl_sales.payment_method AS 'Payment Method',
                                tbl_sales.total AS Total, 
                                tbl_sales.vat AS Vat,
                                tbl_sales.pay AS 'Pay', 
                                tbl_sales.change AS 'Change',
                                DATEDIFF(CURDATE(), tbl_sales.date) AS 'Days Overdue',
                                CASE 
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) BETWEEN 0 AND 30 THEN '0-30 days'
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) BETWEEN 31 AND 60 THEN '31-60 days'
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) BETWEEN 61 AND 90 THEN '61-90 days'
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) > 90 THEN '90+ days'
                                    ELSE 'Not Due Yet' 
                                END AS 'Aging'
                            FROM 
                                tbl_sales
                            INNER JOIN 
                                tbl_transaction ON tbl_sales.id = tbl_transaction.transaction_id
                            INNER JOIN 
                                tbl_customer ON tbl_sales.customer_id = tbl_customer.id
                            WHERE 
                                tbl_sales.state = 0";

                if (cmbCustomer.Text != "" && !chkCustomer.Checked)
                {
                    query += " AND tbl_sales.customer_id = @id";
                    parameters.Add(DBClass.CreateParameter("id", cmbCustomer.SelectedValue.ToString()));
                }

                if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
                {
                    query += " AND tbl_sales.payment_method = @payment";
                    parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
                }

                if (!chkDate.Checked)
                {
                    query += " AND tbl_sales.date BETWEEN @dateFrom AND @dateTo";
                    parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
                    parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
                }

                query += @" GROUP BY
                    tbl_sales.id, tbl_sales.date, tbl_sales.invoice_id, tbl_customer.code, tbl_customer.name, 
                    tbl_sales.payment_method, tbl_sales.total, tbl_sales.vat, tbl_sales.pay, tbl_sales.change";
            }
            else if (cmbSelectionMethod.Text == "A/R Aging Summary")
            {
                query = @"
                        SELECT 
                            CONCAT(tbl_customer.code, ' - ', tbl_customer.name) AS 'Customer Name', 
                            SUM(CASE 
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) BETWEEN 0 AND 30 THEN tbl_sales.total
                                    ELSE 0
                                END) AS '0-30 Days',
                            SUM(CASE 
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) BETWEEN 31 AND 60 THEN tbl_sales.total
                                    ELSE 0
                                END) AS '31-60 Days',
                            SUM(CASE 
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) BETWEEN 61 AND 90 THEN tbl_sales.total
                                    ELSE 0
                                END) AS '61-90 Days',
                            SUM(CASE 
                                    WHEN DATEDIFF(CURDATE(), tbl_sales.date) > 90 THEN tbl_sales.total
                                    ELSE 0
                                END) AS '90+ Days',
                            SUM(tbl_sales.pay) AS 'Total Paid',
                            SUM(tbl_sales.total) - SUM(tbl_sales.pay) AS 'Outstanding Balance'
                        FROM 
                            tbl_sales
                        INNER JOIN 
                            tbl_transaction ON tbl_sales.id = tbl_transaction.transaction_id
                        INNER JOIN 
                            tbl_customer ON tbl_sales.customer_id = tbl_customer.id
                        WHERE 
                            tbl_sales.state = 0";

                if (cmbCustomer.Text != "" && !chkCustomer.Checked)
                {
                    query += " AND tbl_sales.customer_id = @id";
                    parameters.Add(DBClass.CreateParameter("id", cmbCustomer.SelectedValue.ToString()));
                }

                if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
                {
                    query += " AND tbl_sales.payment_method = @payment";
                    parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
                }

                if (!chkDate.Checked)
                {
                    query += " AND tbl_sales.date BETWEEN @dateFrom AND @dateTo";
                    parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
                    parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
                }

                query += @" GROUP BY 
                                tbl_customer.id, tbl_customer.code, tbl_customer.name
                            ORDER BY 
                                tbl_customer.name";
            }
            else
            {
                if (cmbSelectionMethod.Text == "Item Wise")
                {
                    query = @"SELECT 
                                    ROW_NUMBER() OVER (ORDER BY tbl_sales.date) AS `SN`, 
                                    tbl_sales.date AS Date, 
                                    tbl_sales.id,
                                    tbl_sales.invoice_id AS 'INV NO', 
                                    CONCAT(tbl_customer.code,' - ', tbl_customer.name) AS 'Customer Name', 
                                    tbl_sales.payment_method AS 'Payment Method',
                                    tbl_sales.total AS Total, 
                                    tbl_sales.vat AS Vat,
                                    tbl_sales.pay AS 'Pay',
                                    tbl_sales.change AS 'Change',
                                    CONCAT(ti.code,' - ',ti.name) AS 'Item Name',
                                    ts.qty AS Qty,
                                    ts.price AS Price,
                                    ts.vat AS 'Item Vat',
                                    ts.total AS 'Item Total'
                                FROM 
                                    tbl_sales
                                INNER JOIN 
                                    tbl_sales_details ts ON tbl_sales.id = ts.sales_id
                                INNER JOIN 
                                    tbl_items ti ON ts.item_id = ti.id
                                INNER JOIN 
                                    tbl_customer ON tbl_sales.customer_id = tbl_customer.id
                                WHERE 
                                    tbl_sales.state = 0";
                }
                else // Default
                {
                    query = @"SELECT 
                                ROW_NUMBER() OVER (ORDER BY tbl_sales.date) AS `SN`, 
                                tbl_sales.date AS Date, 
                                tbl_sales.id,
                                CONCAT('000', MAX(tbl_transaction.transaction_id)) AS 'JV NO', 
                                tbl_sales.invoice_id AS 'INV NO', 
                                CONCAT(tbl_customer.code,' - ', tbl_customer.name) AS 'Customer Name', 
                                tbl_sales.payment_method AS 'Payment Method',
                                tbl_sales.total AS Total, 
                                tbl_sales.vat AS Vat,
                                tbl_sales.pay AS 'Pay',
                                tbl_sales.change AS 'Change'
                            FROM 
                                tbl_sales
                            INNER JOIN 
                                tbl_transaction ON tbl_sales.id = tbl_transaction.transaction_id
                            INNER JOIN 
                                tbl_customer ON tbl_sales.customer_id = tbl_customer.id
                            WHERE 
                                tbl_sales.state = 0";
                }

                if (cmbCustomer.Text != "" && !chkCustomer.Checked)
                {
                    query += " AND tbl_sales.customer_id = @id";
                    parameters.Add(DBClass.CreateParameter("id", cmbCustomer.SelectedValue.ToString()));
                }

                if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
                {
                    query += " AND tbl_sales.payment_method = @payment";
                    parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
                }

                if (!chkDate.Checked)
                {
                    query += " AND tbl_sales.date BETWEEN @dateFrom AND @dateTo";
                    parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
                    parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
                }

                if (cmbSelectionMethod.Text == "Default")
                {
                    query += @" GROUP BY 
                        tbl_sales.id, tbl_sales.date, tbl_sales.invoice_id, tbl_customer.code, tbl_customer.name, 
                        tbl_sales.payment_method, tbl_sales.total";
                }
                else
                {
                    query += @" GROUP BY 
                        tbl_sales.id, tbl_sales.date, tbl_sales.invoice_id, tbl_customer.code, tbl_customer.name, 
                        tbl_sales.payment_method, tbl_sales.total, tbl_sales.vat, tbl_sales.pay, tbl_sales.change, 
                        ti.code, ti.name, ts.qty, ts.price, ts.vat, ts.total";
                }
            }

            // Execute and bind
            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgvItems.DataSource = dt;

            // Optional: UI Tweaks
            if (dgvItems.Columns.Contains("Customer Name"))
            {
                dgvItems.Columns["Customer Name"].MinimumWidth = 200;
                dgvItems.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvItems.Columns.Contains("id"))
                dgvItems.Columns["id"].Visible = false;

            if (dgvItems.Columns.Contains("Total"))
            {
                dgvItems.Columns["Total"].DefaultCellStyle.Format = "N2";
                dgvItems.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvItems.Columns.Contains("Vat"))
            {
                dgvItems.Columns["Vat"].DefaultCellStyle.Format = "N2";
                dgvItems.Columns["Vat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvItems.Columns.Contains("Pay"))
            {
                dgvItems.Columns["Pay"].DefaultCellStyle.Format = "N2";
                dgvItems.Columns["Pay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvItems.Columns.Contains("Change"))
            {
                dgvItems.Columns["Change"].DefaultCellStyle.Format = "N2";
                dgvItems.Columns["Change"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvItems.Columns.Contains("Item Vat"))
            {
                dgvItems.Columns["Item Vat"].DefaultCellStyle.Format = "N2";
                dgvItems.Columns["Item Vat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvItems.Columns.Contains("Item Total"))
            {
                dgvItems.Columns["Item Total"].DefaultCellStyle.Format = "N2";
                dgvItems.Columns["Item Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Localize headers
            LocalizationManager.LocalizeDataGridViewHeaders(dgvItems);

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCustomer.Rows.Count == 0)
            //    return;
            //if (dgvCustomer.Columns["JV NO"].Index == e.ColumnIndex)
            //    _mainForm.openChildForm(new MasterTransactionJournal(_mainForm, dgvCustomer.CurrentRow.Cells["JV NO"].Value.ToString(), "Sales"));
            //else
            //{
                //if (cmbSalesType.SelectedIndex == 1)
                //{//Sales Order
                //    _mainForm.openChildForm(new frmAddSalesOrder(_mainForm, this, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
                //}
                //else if (cmbSalesType.SelectedIndex == 2)
                //{//Sales Quotation
                //    _mainForm.openChildForm(new frmAddSalesQuotation(_mainForm, this, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
                //}
                //else
                //{
                    //_mainForm.openChildForm(new frmAddnvoice(_mainForm, this, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
                //}
            //}
        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        
        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomer.Checked)
                cmbCustomer.Enabled = false;
            else
                cmbCustomer.Enabled = true;
            BindInvoices();
        }
        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPayment.Checked)
                cmbPaymentMethod.Enabled = false;
            else
                cmbPaymentMethod.Enabled = true;
            BindInvoices();
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindInvoices();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
            //    bindInvoiceItems();
            //else
            //    dgvItems.DataSource = null;
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // numeric columns to consider for totals / formatting
            var numericCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Total", "Vat", "Pay", "Change", "Item Vat", "Item Total", "0-30 Days", "31-60 Days", "61-90 Days", "90+ Days", "Total Paid", "Outstanding Balance"
            };

            // compute totals only for columns that exist
            var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            foreach (DataGridViewColumn col in dgvItems.Columns)
            {
                if (numericCols.Contains(col.Name))
                    totals[col.Name] = 0m;
            }

            foreach (DataGridViewRow r in dgvItems.Rows)
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

            // company name
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
            center.AddFormattedText("Sales Report - " + cmbSelectionMethod.Text + "\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText($"From: {dtFrom.Value:dd/MM/yyyy}  To: {dtTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

            Paragraph separator = section.AddParagraph();
            separator.Format.Borders.Bottom.Width = 2;
            separator.Format.SpaceAfter = "0.5cm";

            // data table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // columns
            for (int c = 0; c < dgvItems.Columns.Count; c++)
            {
                var col = dgvItems.Columns[c];
                if (numericCols.Contains(col.Name))
                    table.AddColumn("2.5cm");
                else if (col.Name.Equals("Customer Name", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Item Name", StringComparison.OrdinalIgnoreCase))
                    table.AddColumn("4.0cm");
                else
                    table.AddColumn("2.5cm");
            }

            // header row
            Row hdr = table.AddRow();
            hdr.Shading.Color = Colors.LightGray;
            hdr.Format.Font.Bold = true;
            for (int c = 0; c < dgvItems.Columns.Count; c++)
                hdr.Cells[c].AddParagraph(dgvItems.Columns[c].HeaderText);

            // data rows
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                if (r.IsNewRow) continue;
                Row row = table.AddRow();
                for (int c = 0; c < dgvItems.Columns.Count; c++)
                {
                    string colName = dgvItems.Columns[c].Name;
                    string text = r.Cells[c].Value?.ToString() ?? "";
                    if (numericCols.Contains(colName))
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
            for (int i = 0; i < dgvItems.Columns.Count; i++)
                if (numericCols.Contains(dgvItems.Columns[i].Name)) { firstNumericIndex = i; break; }
            if (firstNumericIndex <= 0) firstNumericIndex = Math.Min(1, dgvItems.Columns.Count - 1);
            tot.Cells[0].MergeRight = firstNumericIndex - 1;
            tot.Cells[0].AddParagraph("TOTAL");

            for (int c = 0; c < dgvItems.Columns.Count; c++)
            {
                string colName = dgvItems.Columns[c].Name;
                if (totals.ContainsKey(colName))
                {
                    tot.Cells[c].AddParagraph(totals[colName].ToString("N2"));
                    tot.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                }
            }

            // render
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = doc
            };
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Sales Report";
                saveFile.FileName = "SalesReport.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveFile.FileName);
                    Process.Start("explorer.exe", saveFile.FileName);
                }
            }
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var numericCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Total", "Vat", "Pay", "Change", "Item Vat", "Item Total", "0-30 Days", "31-60 Days", "61-90 Days", "90+ Days", "Total Paid", "Outstanding Balance"
            };

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Sales Report";
                saveDialog.FileName = "SalesReport.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                var excelApp = new Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "SalesReport";

                int cols = dgvItems.Columns.Count;

                // header merged row
                var headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, cols]];
                headerRange.Merge();
                headerRange.Value = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
                headerRange.Font.Bold = true;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.Size = 10;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // column headers
                for (int c = 0; c < cols; c++)
                {
                    worksheet.Cells[2, c + 1] = dgvItems.Columns[c].HeaderText;
                    var hdr = worksheet.Cells[2, c + 1] as Excel.Range;
                    hdr.Font.Bold = true;
                    hdr.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    hdr.Font.Name = "Times New Roman";
                    hdr.Font.Size = 10;
                    hdr.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                int rowIndex = 3;
                var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
                foreach (DataGridViewColumn col in dgvItems.Columns)
                    if (numericCols.Contains(col.Name))
                        totals[col.Name] = 0m;

                for (int r = 0; r < dgvItems.Rows.Count; r++)
                {
                    var gridRow = dgvItems.Rows[r];
                    if (gridRow.IsNewRow) continue;

                    for (int c = 0; c < cols; c++)
                    {
                        string colName = dgvItems.Columns[c].Name;
                        object val = gridRow.Cells[c].Value;
                        if (numericCols.Contains(colName))
                        {
                            decimal d;
                            decimal.TryParse(Convert.ToString(val), NumberStyles.Any, CultureInfo.CurrentCulture, out d);
                            worksheet.Cells[rowIndex, c + 1] = d;
                            var rng = worksheet.Cells[rowIndex, c + 1] as Excel.Range;
                            rng.NumberFormat = "#,##0.00";
                            rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            totals[colName] += d;
                        }
                        else
                        {
                            worksheet.Cells[rowIndex, c + 1] = val?.ToString() ?? "";
                            var rng = worksheet.Cells[rowIndex, c + 1] as Excel.Range;
                            rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        }
                    }

                    rowIndex++;
                }

                // totals row
                int totalRow = rowIndex;
                int firstNumericIndex = -1;
                for (int i = 0; i < cols; i++)
                    if (numericCols.Contains(dgvItems.Columns[i].Name)) { firstNumericIndex = i + 1; break; }
                if (firstNumericIndex <= 1) firstNumericIndex = Math.Min(2, cols);

                var labelRange = worksheet.Range[worksheet.Cells[totalRow, 1], worksheet.Cells[totalRow, firstNumericIndex - 1]];
                labelRange.Merge();
                labelRange.Value = "TOTAL";
                labelRange.Font.Bold = true;
                labelRange.Font.Name = "Times New Roman";

                for (int c = 0; c < cols; c++)
                {
                    string colName = dgvItems.Columns[c].Name;
                    if (totals.ContainsKey(colName))
                    {
                        var cell = worksheet.Cells[totalRow, c + 1] as Excel.Range;
                        cell.Value = totals[colName];
                        cell.NumberFormat = "#,##0.00";
                        cell.Font.Bold = true;
                        cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    }
                }

                worksheet.Columns.AutoFit();
                workbook.SaveAs(saveDialog.FileName);
                workbook.Close(false);
                excelApp.Quit();

                MessageBox.Show("Exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
