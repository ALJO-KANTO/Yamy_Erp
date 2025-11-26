using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Colors = MigraDoc.DocumentObjectModel.Colors;
using Row = MigraDoc.DocumentObjectModel.Tables.Row;
using Table = MigraDoc.DocumentObjectModel.Tables.Table;

namespace YamyProject
{
    public partial class MasterInventoryProfitStatement : Form
    {
        public MasterInventoryProfitStatement()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }

        private void MasterInventoryProfitStatement_Load(object sender, EventArgs e)
        {
            BindItems();
        }
        public void BindItems()
        {
            string query = @"SELECT ts.date AS DATE,ts.invoice_id AS 'Inv No',  CONCAT(tc.code,' - ',tc.name) AS 'Customer Name',
                                                    CONCAT(ti.code,' - ',ti.name) AS 'Item Name',
                                                    tsd.cost_price AS 'Cost Price', 
                                                    tsd.price AS 'Sales Price',
                                                    tsd.qty AS Qty,
                                                    (tsd.cost_price)*tsd.qty AS 'Cost Amount',
                                                    (tsd.price)*tsd.qty AS 'Sales Amount',										 								
                                                    (tsd.price-tsd.cost_price)*tsd.qty AS 'Profit'
                                                    FROM tbl_sales_details tsd
                                                    INNER JOIN tbl_items ti ON tsd.item_id= ti.id
                                                    INNER JOIN tbl_sales ts ON tsd.sales_id=ts.id
                                                    INNER JOIN tbl_customer tc ON ts.customer_id= tc.id";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            if (!chkDate.Checked)
            {
                query += " and ts.date >= @dateFrom and ts.date <= @dateTo";
                parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            }
            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgvCustomer.DataSource = dt;
            dgvCustomer.Columns["Item name"].Width = 250;
            dgvCustomer.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["customer name"].MinimumWidth = 180;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);

            string[] numericColumns = { "Cost Price", "Sales Price", "Qty", "Cost Amount", "Sales Amount", "Profit" };

            foreach (DataGridViewColumn column in dgvCustomer.Columns)
            {
                if (numericColumns.Contains(column.Name))
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindItems();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindItems();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Columns considered numeric for totals and formatting
            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Cost Price", "Sales Price", "Qty", "Cost Amount", "Sales Amount", "Profit"
            };

            // Compute totals
            var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            foreach (DataGridViewColumn col in dgvCustomer.Columns)
            {
                if (numericColumns.Contains(col.Name))
                    totals[col.Name] = 0m;
            }

            foreach (DataGridViewRow r in dgvCustomer.Rows)
            {
                if (r.IsNewRow) continue;
                foreach (var key in totals.Keys.ToList())
                {
                    object v = null;
                    try { v = r.Cells[key].Value; } catch { v = null; }
                    decimal d;
                    if (decimal.TryParse(Convert.ToString(v), NumberStyles.Any, CultureInfo.CurrentCulture, out d))
                        totals[key] += d;
                }
            }

            // Company name
            string companyName = "";
            using (MySqlDataReader rd = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
            {
                if (rd.Read() && rd["name"] != DBNull.Value) companyName = rd["name"].ToString();
            }

            // Build PDF
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
            center.AddFormattedText("Inventory Profit Statement\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText($"From: {dtFrom.Value:dd/MM/yyyy}  To: {dtTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Data table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Create columns based on grid
            foreach (DataGridViewColumn col in dgvCustomer.Columns)
            {
                if (numericColumns.Contains(col.Name))
                    table.AddColumn("2.0cm");
                else if (col.Name.Equals("Item Name", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Customer Name", StringComparison.OrdinalIgnoreCase))
                    table.AddColumn("4.0cm");
                else
                    table.AddColumn("2.5cm");
            }

            // Header row
            Row hdr = table.AddRow();
            hdr.Shading.Color = Colors.LightGray;
            hdr.Format.Font.Bold = true;
            for (int c = 0; c < dgvCustomer.Columns.Count; c++)
                hdr.Cells[c].AddParagraph(dgvCustomer.Columns[c].HeaderText);

            // Data rows
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

            // Totals row
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

            // Render and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Inventory Profit Statement";
                saveFile.FileName = "InventoryProfitStatement.pdf";

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
                "Cost Price", "Sales Price", "Qty", "Cost Amount", "Sales Amount", "Profit"
            };

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Inventory Profit Statement";
                saveDialog.FileName = "InventoryProfitStatement.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "InventoryProfit";

                int cols = dgvCustomer.Columns.Count;

                // Header merged row
                var headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, cols]];
                headerRange.Merge();
                headerRange.Value = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
                headerRange.Font.Bold = true;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.Size = 10;
                headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Column headers row 2
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
