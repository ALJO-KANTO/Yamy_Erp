using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmViewItemMovingReport : Form
    {
        private string type;

        public frmViewItemMovingReport(string _type="")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            type = _type;
            headerUC1.FormText = this.Text;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }
        
        private void frmViewItemMovingReport_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            
            //cmbSelectionMethod.Text = type == "Customer Summary"? "" : type == "Item Details" ? "Item Wise" : type == "Item Summary" ? "Item Wise" : type== "Aging Summary" ? "A/R Aging Summary" : "";

            BindInvoices();
        }

        private void BindInvoices()
        {
            dgvItems.Enabled = false;

            bool isDateChecked = true;
            DateTime dateFrom = DateTime.Today;
            DateTime dateTo = DateTime.Today;

            this.Invoke((MethodInvoker)(() =>
            {
                isDateChecked = chkDate.Checked;
                dateFrom = dtFrom.Value.Date;
                dateTo = dtTo.Value.Date;
            }));

            Task.Run(() =>
            {
                DataTable dt;
                string query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY i.id) AS `SN`, 
                            i.code,
                            i.name,
                            i.barcode,
                            i.cost_price AS CostPrice,
                            i.sales_price AS SalesPrice,
                            SUM(CASE WHEN t.type = 'Opening Qty' THEN (t.qty_in) ELSE 0 END) AS OpeningQty,
                            SUM(CASE WHEN t.type = 'Purchase Invoice' THEN (t.qty_in) ELSE 0 END) AS Purchase,
                            SUM(CASE WHEN t.type = 'Sales Invoice' THEN (t.qty_out) ELSE 0 END) AS Sales,
                            SUM(CASE WHEN t.type = 'Purchase Return Invoice' THEN (t.qty_out) ELSE 0 END) AS PurchaseReturn,
                            SUM(CASE WHEN t.type = 'Sales Return Invoice' THEN (t.qty_in) ELSE 0 END) AS SalesReturn,
                            SUM(CASE WHEN t.type = 'Damage' THEN (t.qty_out) ELSE 0 END) AS Damage,
                            SUM(t.qty_in - t.qty_out) AS `BalanceQty`
                        FROM
                            tbl_items i
                        INNER JOIN 
                            tbl_item_transaction t ON i.id = t.item_id
                        WHERE 
                            i.type = '11 - Inventory Part' AND i.active = 0
                        ";

                List<MySqlParameter> parameters = new List<MySqlParameter>();
                if (!isDateChecked)
                {
                    query += " AND t.date >= @dateFrom AND t.date <= @dateTo ";
                    parameters.Add(DBClass.CreateParameter("dateFrom", dateFrom));
                    parameters.Add(DBClass.CreateParameter("dateTo", dateTo));
                }

                query += " GROUP BY i.id, i.code, i.name, i.barcode, i.cost_price, i.sales_price";

                dt = DBClass.ExecuteDataTable(query, parameters.ToArray());

                this.Invoke((MethodInvoker)delegate
                {
                    dgvItems.Columns.Clear();
                    dgvItems.Rows.Clear();
                    dgvItems.Enabled = false;

                    foreach (DataColumn col in dt.Columns)
                    {
                        dgvItems.Columns.Add(col.ColumnName, col.ColumnName);
                    }

                    string[] numericColumns = {
                        "CostPrice", "SalesPrice", "OpeningQty", "Purchase",
                        "Sales", "PurchaseReturn", "SalesReturn", "Damage", "BalanceQty"
                    };

                    foreach (DataGridViewColumn column in dgvItems.Columns)
                    {
                        if (numericColumns.Contains(column.Name))
                        {
                            column.DefaultCellStyle.Format = "N2";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }

                    Task.Run(() =>
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!this.IsHandleCreated || this.IsDisposed) return;

                            object[] rowData = dr.ItemArray;

                            this.Invoke((MethodInvoker)delegate
                            {
                                dgvItems.Rows.Add(rowData);
                            });
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dgvItems.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                            LocalizationManager.LocalizeDataGridViewHeaders(dgvItems);
                            dgvItems.Enabled = true;
                        });
                    });
                });

            });
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
            dtFrom.Enabled = dtTo.Enabled = !chkDate.Checked;
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

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Set formatting and alignment for the specific columns when the editing control is shown
            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                // Only format these columns
                if (column.Name == "CostPrice" || column.Name == "SalesPrice" ||
                    column.Name == "OpeningQty" || column.Name == "Purchase" ||
                    column.Name == "Sales" || column.Name == "PurchaseReturn" ||
                    column.Name == "SalesReturn" || column.Name == "Damage" ||
                    column.Name == "BalanceQty")
                {
                    // Format the decimal columns (for example, for cost and sales prices)
                    column.DefaultCellStyle.Format = "N2";  // Two decimal places format

                    // Align the content to the right
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            // You can also apply resizing, but consider doing this in the Form Load or DataBinding event for better performance
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvItems.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if(dtFrom.Focused)
                BindInvoices();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtTo.Focused)
                BindInvoices();
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
            // Build PDF using MigraDoc with the current grid content and totals for numeric columns
            if (dgvItems.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Determine numeric columns
            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "CostPrice", "SalesPrice", "OpeningQty", "Purchase",
                "Sales", "PurchaseReturn", "SalesReturn", "Damage", "BalanceQty"
            };

            // Sum totals
            var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            foreach (DataGridViewColumn col in dgvItems.Columns)
                if (numericColumns.Contains(col.Name))
                    totals[col.Name] = 0m;

            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                if (r.IsNewRow) continue;
                foreach (var colName in totals.Keys.ToList())
                {
                    var cellVal = r.Cells[colName].Value;
                    decimal d;
                    if (decimal.TryParse(Convert.ToString(cellVal), out d))
                        totals[colName] += d;
                }
            }

            // Get company name
            string companyName = "";
            using (MySqlDataReader rd = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
            {
                if (rd.Read() && rd["name"] != DBNull.Value) companyName = rd["name"].ToString();
            }

            // Create document
            Document doc = new Document();
            Section section = doc.AddSection();
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Header
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
            center.AddFormattedText("Item Moving Report\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText($"From: {dtFrom.Value:dd/MM/yyyy}  To: {dtTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

            // Separator
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Data table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Add columns - choose a reasonable width per column type
            foreach (DataGridViewColumn col in dgvItems.Columns)
            {
                if (numericColumns.Contains(col.Name))
                    table.AddColumn("2.0cm");
                else if (col.Name.Equals("code", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("barcode", StringComparison.OrdinalIgnoreCase))
                    table.AddColumn("2.2cm");
                else if (col.Name.Equals("name", StringComparison.OrdinalIgnoreCase))
                    table.AddColumn("4.0cm");
                else
                    table.AddColumn("2.5cm");
            }

            // Header row
            Row hdr = table.AddRow();
            hdr.Shading.Color = Colors.LightGray;
            hdr.Format.Font.Bold = true;
            for (int c = 0; c < dgvItems.Columns.Count; c++)
                hdr.Cells[c].AddParagraph(dgvItems.Columns[c].HeaderText);

            // Data rows
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                if (r.IsNewRow) continue;
                Row row = table.AddRow();
                for (int c = 0; c < dgvItems.Columns.Count; c++)
                {
                    string colName = dgvItems.Columns[c].Name;
                    string text = r.Cells[c].Value?.ToString() ?? "";
                    if (numericColumns.Contains(colName))
                    {
                        decimal d;
                        string formatted = decimal.TryParse(text, out d) ? d.ToString("N2") : text;
                        row.Cells[c].AddParagraph(formatted);
                        row.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                    }
                    else
                    {
                        row.Cells[c].AddParagraph(text);
                    }
                }
            }

            // Totals row: add at bottom, bold
            Row totRow = table.AddRow();
            totRow.Format.Font.Bold = true;
            // Merge first columns up to the first numeric column for a "TOTAL" label
            int firstNumericIndex = -1;
            for (int i = 0; i < dgvItems.Columns.Count; i++)
            {
                if (numericColumns.Contains(dgvItems.Columns[i].Name))
                {
                    firstNumericIndex = i;
                    break;
                }
            }

            if (firstNumericIndex <= 0) firstNumericIndex = Math.Min(1, dgvItems.Columns.Count - 1);
            totRow.Cells[0].MergeRight = firstNumericIndex - 1;
            totRow.Cells[0].AddParagraph("TOTAL");

            for (int c = 0; c < dgvItems.Columns.Count; c++)
            {
                string colName = dgvItems.Columns[c].Name;
                if (numericColumns.Contains(colName))
                {
                    decimal val = totals.ContainsKey(colName) ? totals[colName] : 0m;
                    totRow.Cells[c].AddParagraph(val.ToString("N2"));
                    totRow.Cells[c].Format.Alignment = ParagraphAlignment.Right;
                }
                else
                {
                    if (c > 0 && c <= firstNumericIndex) continue; // cells merged
                    totRow.Cells[c].AddParagraph("");
                }
            }

            // Render PDF and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Item Moving Report";
                saveFile.FileName = "ItemMovingReport.pdf";

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

            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "CostPrice", "SalesPrice", "OpeningQty", "Purchase",
                "Sales", "PurchaseReturn", "SalesReturn", "Damage", "BalanceQty"
            };

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Item Moving Report";
                saveDialog.FileName = "ItemMovingReport.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Item Moving";

                // Header (date)
                Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", GetColumnLetter(dgvItems.Columns.Count) + "1"];
                headerRange.Merge();
                headerRange.Value = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
                headerRange.Font.Bold = true;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.Size = 10;
                headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Column headers row 2
                for (int c = 0; c < dgvItems.Columns.Count; c++)
                {
                    worksheet.Cells[2, c + 1] = dgvItems.Columns[c].HeaderText;
                    var hdr = worksheet.Cells[2, c + 1] as Microsoft.Office.Interop.Excel.Range;
                    hdr.Font.Bold = true;
                    hdr.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    hdr.Font.Name = "Times New Roman";
                    hdr.Font.Size = 10;
                    hdr.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }

                int rowIndex = 3;
                // Totals dictionary for numeric columns
                var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
                foreach (DataGridViewColumn col in dgvItems.Columns)
                    if (numericColumns.Contains(col.Name))
                        totals[col.Name] = 0m;

                foreach (DataGridViewRow r in dgvItems.Rows)
                {
                    if (r.IsNewRow) continue;
                    for (int c = 0; c < dgvItems.Columns.Count; c++)
                    {
                        string colName = dgvItems.Columns[c].Name;
                        var val = r.Cells[c].Value;
                        if (numericColumns.Contains(colName))
                        {
                            decimal d;
                            decimal.TryParse(Convert.ToString(val), out d);
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

                // Write totals row
                int totalRowIndex = rowIndex;
                // First numeric column index
                int firstNumericIndex = -1;
                for (int i = 0; i < dgvItems.Columns.Count; i++)
                    if (numericColumns.Contains(dgvItems.Columns[i].Name)) { firstNumericIndex = i + 1; break; }

                if (firstNumericIndex <= 1) firstNumericIndex = Math.Min(2, dgvItems.Columns.Count);

                // Put TOTAL label merged across columns before first numeric
                Microsoft.Office.Interop.Excel.Range labelRange = worksheet.Range[worksheet.Cells[totalRowIndex, 1], worksheet.Cells[totalRowIndex, firstNumericIndex - 1]];
                labelRange.Merge();
                labelRange.Value = "TOTAL";
                labelRange.Font.Bold = true;
                labelRange.Font.Name = "Times New Roman";

                // Fill numeric totals
                for (int c = 0; c < dgvItems.Columns.Count; c++)
                {
                    string colName = dgvItems.Columns[c].Name;
                    if (numericColumns.Contains(colName))
                    {
                        var cell = worksheet.Cells[totalRowIndex, c + 1] as Microsoft.Office.Interop.Excel.Range;
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

        private string GetColumnLetter(int colIndex)
        {
            // 1 -> A, 2 -> B, ... 27 -> AA
            string letters = "";
            while (colIndex > 0)
            {
                int rem = (colIndex - 1) % 26;
                letters = (char)('A' + rem) + letters;
                colIndex = (colIndex - 1) / 26;
            }
            return letters;
        }
    }
}
