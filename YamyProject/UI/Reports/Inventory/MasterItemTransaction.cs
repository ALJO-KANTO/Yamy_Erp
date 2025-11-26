using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterItemTransaction : Form
    {
        public MasterItemTransaction()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }

        private void MasterItemTransaction_Load(object sender, EventArgs e)
        {
            DataTable dt = DBClass.ExecuteDataTable("select id,name from tbl_items where state = 0 and active = 0");
            cmbSelectionMethod.DataSource = dt;
            cmbSelectionMethod.DisplayMember = "name";
            cmbSelectionMethod.ValueMember = "id";

            dgvCustomer.Columns.Clear();
            dgvCustomer.Columns.Add("SN", "SN");
            dgvCustomer.Columns.Add("Date", "Date");
            dgvCustomer.Columns.Add("Type", "Type");
            dgvCustomer.Columns.Add("RefId", "Ref Id");
            dgvCustomer.Columns.Add("Name", "Name");
            dgvCustomer.Columns.Add("Code", "Code");
            dgvCustomer.Columns.Add("ItemId", "Item Id");
            dgvCustomer.Columns.Add("CostPrice", "Cost Price");
            dgvCustomer.Columns.Add("SellingPrice", "Selling Price");
            dgvCustomer.Columns.Add("QtyIN", "Qty IN");
            dgvCustomer.Columns.Add("QtyOut", "Qty OUT");
            dgvCustomer.Columns.Add("Description", "Description");

            BindInvoices();
        }

        DataTable data;

        public void BindInvoices()
        {
            bool isLoading = false;
            string query = "";
            //query = @"SELECT ROW_NUMBER() OVER (ORDER BY it.date) AS `SN`,
            //            it.date Date,it.type Type,
            //            concat('000', it.reference) as `Ref Id`,
            //            i.name Name,i.code Code,it.item_Id,i.cost_price CostPrice,i.sales_price `Selling Price`,it.qty_in `Qty IN`,it.qty_out,it.description

            //            from tbl_item_transaction it,tbl_items i where it.item_id=i.id and i.state = 0 ";

            //List<MySqlParameter> parameters = new List<MySqlParameter>();
            //if (!chkAllItems.Checked)
            //{
            //    query += " and i.id = @id ";
            //}
            //if (!chkDate.Checked)
            //{


            //    query += " and it.date >= @dateFrom and it.date <= @dateTo";
            //    query += " GROUP BY it.date,it.type,it.reference,it.description,it.qty_in,it.qty_out,i.code,i.name,i.barcode,i.cost_price,i.sales_price,i.id";
            //}
            //parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            //parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            //parameters.Add(DBClass.CreateParameter("id", cmbSelectionMethod.SelectedValue.ToString()));

            query = @"
                            SELECT 
                                ROW_NUMBER() OVER (ORDER BY it.date) AS SN,
                                DATE_FORMAT(it.date, '%d/%m/%Y') AS `Date`,
                                it.type AS Type,
                                CONCAT('000', it.reference) AS `Ref Id`,
                                i.name AS Name,
                                i.code AS Code,
                                it.item_id,
                                i.cost_price AS CostPrice,
                                i.sales_price AS `Selling Price`,
                                it.qty_in AS `Qty IN`,
                                it.qty_out,
                                it.description
                            FROM 
                                tbl_item_transaction it
                            JOIN 
                                tbl_items i ON it.item_id = i.id
                            WHERE 
                                i.state = 0
                                AND (@id IS NULL OR i.id = @id)
                                AND (@dateFilter = 0 OR (it.date BETWEEN @dateFrom AND @dateTo))
                            ORDER BY 
                                it.date;
                        ";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                DBClass.CreateParameter("id", chkAllItems.Checked ? DBNull.Value : (object)cmbSelectionMethod.SelectedValue),
                DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                DBClass.CreateParameter("dateTo", dtTo.Value.Date),
                DBClass.CreateParameter("dateFilter", chkDate.Checked ? 0 : 1)
            };

            if (isLoading) return;
            isLoading = true;

            Task.Run(() =>
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("SN", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Ref Id", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("item_id", typeof(int));
                dt.Columns.Add("CostPrice", typeof(decimal));
                dt.Columns.Add("Selling Price", typeof(decimal));
                dt.Columns.Add("Qty IN", typeof(decimal));
                dt.Columns.Add("qty_out", typeof(decimal));
                dt.Columns.Add("description", typeof(string));
                this.Invoke(new Action(() =>
                {
                    data = DBClass.ExecuteDataTable(query, parameters.ToArray());
                }));
                //using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters.ToArray()))
                //{
                int rowNumber = 0;
                foreach (DataRow reader in data.Rows)
                {
                    var row = new object[]
                    {
                            ++rowNumber,
                            reader["Date"],
                            reader["Type"],
                            reader["Ref Id"],
                            reader["Name"],
                            reader["Code"],
                            reader["item_id"],
                            reader["CostPrice"],
                            reader["Selling Price"],
                            reader["Qty IN"],
                            reader["qty_out"],
                            reader["description"]
                    };

                    this.Invoke(new Action(() =>
                    {
                        dgvCustomer.Rows.Add(row);
                    }));
                }

                this.Invoke(new Action(() =>
                {
                    LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
                    isLoading = false;
                }));
            });

        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmViewItem(int.Parse(dgvCustomer.SelectedRows[0].Cells["itemId"].Value.ToString())));
            if (dgvCustomer.Rows.Count == 0)
                return;
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
            //DBClass.ExecuteNonQuery("UPDATE tbl_items SET state = -1 WHERE id = @id ",
            //                              DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            //BindInvoices();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
            //    //bindInvoiceItems();
            //else
            //    dgvItems.DataSource = null;
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindInvoices();
        }

        private void chkAllItems_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllItems.Checked)
            {
                cmbSelectionMethod.Enabled = false;
                loadFilterData("");
            }
            else
            {
                cmbSelectionMethod.Enabled = true;
                loadFilterData(cmbSelectionMethod.SelectedValue.ToString());
            }
        }

        private void cmbSelectionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbSelectionMethod.Enabled)
                return;

            if (!cmbSelectionMethod.Focused || data == null || data.Rows.Count == 0)
                return;

            string selectedId = cmbSelectionMethod.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedId))
                return;

            loadFilterData(selectedId);
        }

        private void loadFilterData(string selectedId)
        {
            if (dgvCustomer == null) return;

            dgvCustomer.Invoke(new MethodInvoker(delegate
            {
                dgvCustomer.Rows.Clear();
            }));

            Task.Run(() =>
            {
                int rowNumber = 0;
                DataView dv = string.IsNullOrEmpty(selectedId)
                    ? new DataView(data)
                    : new DataView(data) { RowFilter = $"item_id = {selectedId}" };

                foreach (DataRowView drv in dv)
                {
                    var row = new object[]
                    {
                        ++rowNumber,
                        drv["Date"],
                        drv["Type"],
                        drv["Ref Id"],
                        drv["Name"],
                        drv["Code"],
                        drv["item_id"],
                        drv["CostPrice"],
                        drv["Selling Price"],
                        drv["Qty IN"],
                        drv["qty_out"],
                        drv["description"]
                    };

                    if (dgvCustomer.InvokeRequired)
                    {
                        dgvCustomer.Invoke(new MethodInvoker(delegate
                        {
                            dgvCustomer.Rows.Add(row);
                        }));
                    }
                    else
                    {
                        dgvCustomer.Rows.Add(row);
                    }
                }
            });
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Build PDF of the current grid and include totals for numeric columns
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "CostPrice", "SellingPrice", "QtyIN", "QtyOut"
            };

            // Calculate totals
            var totals = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            foreach (DataGridViewColumn col in dgvCustomer.Columns)
            {
                if (numericColumns.Contains(col.Name))
                    totals[col.Name] = 0m;
            }

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

            // Company name
            string companyName = "";
            using (MySqlDataReader rd = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
            {
                if (rd.Read() && rd["name"] != DBNull.Value) companyName = rd["name"].ToString();
            }

            // Create PDF
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
            center.AddFormattedText("Item Transactions\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText($"From: {dtFrom.Value:dd/MM/yyyy}  To: {dtTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Data table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Add columns based on grid columns
            for (int c = 0; c < dgvCustomer.Columns.Count; c++)
            {
                var col = dgvCustomer.Columns[c];
                if (numericColumns.Contains(col.Name))
                    table.AddColumn("2.0cm");
                else if (col.Name.Equals("Name", StringComparison.OrdinalIgnoreCase) || col.Name.Equals("Description", StringComparison.OrdinalIgnoreCase))
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
                saveFile.Title = "Save Item Transactions";
                saveFile.FileName = "ItemTransactions.pdf";

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
                "CostPrice", "SellingPrice", "QtyIN", "QtyOut"
            };

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Item Transactions";
                saveDialog.FileName = "ItemTransactions.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "ItemTransactions";

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
