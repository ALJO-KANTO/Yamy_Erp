using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class ItemInAndOutReport : Form
    {
        int id;
        string type = "";
        public ItemInAndOutReport(int _id=0,string _type="")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            id = _id;
            type = _type;
            headerUC1.FormText = this.Text;
        }

        private void ItemInAndOutReport_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            // Optionally show a loading message or disable the grid
            dgvCustomer.Enabled = false;

            // Capture filter values to avoid cross-thread issues
            bool isDateChecked = chkDate.Checked;
            string selectionMethod = cmbSelectionMethod.Text;
            int localId = id;
            DateTime dateFrom = dtFrom.Value.Date;
            DateTime dateTo = dtTo.Value.Date;

            Task.Run(() =>
            {
                DataTable dt;
                string query = @"SELECT ROW_NUMBER() OVER (ORDER BY it.date) AS `SN`,
                        it.date Date,it.type Type,
                        concat('000', it.reference) as `Ref Id`,
                        i.name Name,i.code Code,it.cost_price CostPrice,it.sales_price `Selling Price`,it.qty_in `Qty IN`,it.qty_out `Qty OUT`
                        from tbl_item_transaction it,tbl_items i where it.item_id=i.id and i.state = 0 ";

                List<MySqlParameter> parameters = new List<MySqlParameter>();
                if (!isDateChecked)
                    query += " and it.date >= @dateFrom and it.date <= @dateTo";
                if (selectionMethod == "Default")
                {
                    if (localId > 0)
                    {
                        query += " and i.id=@id";
                        parameters.Add(DBClass.CreateParameter("id", localId.ToString()));
                    }
                }
                else if (selectionMethod == "Opening Qty")
                {
                    query += " and it.type='Opening Qty' ";
                    if (localId > 0)
                    {
                        query += " and i.id=@id";
                        parameters.Add(DBClass.CreateParameter("id", localId.ToString()));
                    }
                }
                else if (selectionMethod == "Purchase")
                {
                    query += " and it.type='Purchase Invoice' ";
                    if (localId > 0)
                    {
                        query += " and i.id=@id";
                        parameters.Add(DBClass.CreateParameter("id", localId.ToString()));
                    }
                }
                else if (selectionMethod == "Sales")
                {
                    query += " and it.type='Sales Invoice' ";
                    if (localId > 0)
                    {
                        query += " and i.id=@id";
                        parameters.Add(DBClass.CreateParameter("id", localId.ToString()));
                    }
                }
                parameters.Add(DBClass.CreateParameter("dateFrom", dateFrom));
                parameters.Add(DBClass.CreateParameter("dateTo", dateTo));
                dt = DBClass.ExecuteDataTable(query, parameters.ToArray());

                // Update UI on the main thread
                this.Invoke((MethodInvoker)delegate
                {
                    dgvCustomer.DataSource = dt;
                    dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
                    BeautifyDataGridView();
                    dgvCustomer.Enabled = true;
                });
            });
        }

        public void BindDataOld()
        {
            DataTable dt;
            string query = "";
            //if (cmbSelectionMethod.Text == "Default")
                query = @"SELECT ROW_NUMBER() OVER (ORDER BY it.date) AS `SN`,
                        it.date Date,it.type Type,
                        concat('000', it.reference) as `Ref Id`,
                        i.name Name,i.code Code,it.cost_price CostPrice,it.sales_price `Selling Price`,it.qty_in `Qty IN`,it.qty_out `Qty OUT`
                        
                        from tbl_item_transaction it,tbl_items i where it.item_id=i.id and i.state = 0 ";
            //else
            //    query = @"SELECT ROW_NUMBER() OVER (ORDER BY tbl_item_stock_settlement.date) AS `SN`, 
            //            tbl_item_stock_settlement.date AS Date, 
            //            tbl_item_stock_settlement.id,
            //            tbl_item_stock_settlement.code AS 'INV NO', 
            //            concat(ti.code,' - ',ti.name) as 'Item Name' ,ts.On_Hand As Qty,ts.price 
            //            As 'Cost Price' , ts.new_on_hand  ,ts.minusamount ,ts.plusamount
            //            FROM tbl_item_stock_settlement
            //            INNER JOIN tbl_item_stock_settlement_details ts ON tbl_item_stock_settlement.id = ts.settle_id
            //            inner join tbl_items ti on ts.item_id =ti.id
            //            WHERE tbl_item_stock_settlement.state = 0";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            if (!chkDate.Checked)
                query += " and it.date >= @dateFrom and it.date <= @dateTo";
            if (cmbSelectionMethod.Text == "Default")
            {
                if (id > 0)
                {
                    query += " and i.id=@id";
                    parameters.Add(DBClass.CreateParameter("id", id.ToString()));
                }
            }
            else if (cmbSelectionMethod.Text == "Opening Qty")
            {
                query += " and it.type='Opening Qty' ";
                if (id > 0)
                {
                    query += " and i.id=@id";
                    parameters.Add(DBClass.CreateParameter("id", id.ToString()));
                }
            }
            else if (cmbSelectionMethod.Text == "Purchase")
            {
                query += " and it.type='Purchase Invoice' ";
                if (id > 0)
                {
                    query += " and i.id=@id";
                    parameters.Add(DBClass.CreateParameter("id", id.ToString()));
                }
            }
            else if (cmbSelectionMethod.Text == "Sales")
            {
                query += " and it.type='Sales Invoice' ";
                if (id > 0)
                {
                    query += " and i.id=@id";
                    parameters.Add(DBClass.CreateParameter("id", id.ToString()));
                }
            }
            //    query += " GROUP BY tbl_item_stock_settlement.id, tbl_item_stock_settlement.date, tbl_item_stock_settlement.code; ";

            //else
            //    query += " GROUP BY tbl_item_stock_settlement.id, tbl_item_stock_settlement.date, tbl_item_stock_settlement.code,ti.code,ti.name,ts.on_hand,ts.price,ts.new_on_hand  ,ts.minusamount ,ts.plusamount; ";
            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgvCustomer.DataSource = dt;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvCustomer.Columns["id"].Visible = false;
            //if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
            //bindInvoiceItems();
            //else
            //    dgvItems.DataSource = null;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);

            BeautifyDataGridView();
        }

        private void BeautifyDataGridView()
        {
            // Set the column headers style
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SlateBlue;
            dgvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set alternating row colors for better readability
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            // Set default row color and highlight selection
            dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvCustomer.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dgvCustomer.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            // Set a border for the rows and columns
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Set the default alignment of the content
            dgvCustomer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Adjust specific columns for custom formatting (example for currency, date, etc.)
            dgvCustomer.Columns["Qty IN"].DefaultCellStyle.Alignment = dgvCustomer.Columns["Qty OUT"].DefaultCellStyle.Alignment= dgvCustomer.Columns["CostPrice"].DefaultCellStyle.Alignment = dgvCustomer.Columns["Selling Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // For currency format
            //dgvCustomer.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd"; // For date format

            // Adjust column width
            dgvCustomer.Columns["SN"].Width = 60; // Set specific column width
            dgvCustomer.Columns["Ref Id"].Width = 100;
            dgvCustomer.Columns["Qty IN"].Width = 80;
            dgvCustomer.Columns["Qty OUT"].Width = 80;

            // Set the row height for better readability
            dgvCustomer.RowTemplate.Height = 35;

            // Enable sorting on specific columns (optional)
            dgvCustomer.Columns["SN"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvCustomer.Columns["Date"].SortMode = DataGridViewColumnSortMode.Automatic;

            // Optional: Add tooltips to columns
            dgvCustomer.Columns["SN"].ToolTipText = "Serial Number";
            dgvCustomer.Columns["Ref Id"].ToolTipText = "Reference ID";
            dgvCustomer.Columns["Date"].ToolTipText = "Transaction Date";

            // Enable multi-line text for certain columns if needed
            dgvCustomer.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        //private void bindInvoiceItems()
        //{
        //    DataTable dt = DBClass.ExecuteDataTable(@"select concat(ti.code,' - ' ,ti.name) as 'Item Name' ,ts.on_hand as Qty ,ts.price as 'Cost Price' , ts.new_on_hand  from 
        //                                             tbl_item_stock_settlement_details ts inner join tbl_items ti on ts.item_id = ti.id where settle_id = @id",
        //                                             DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
        //    dgvItems.DataSource = dt;
        //    dgvItems.Columns["item name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //}

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmViewItem( int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LbHeader_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Restore down
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Maximize
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFrom.Enabled = dtTo.Enabled = !chkDate.Checked;
            BindData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Build PDF of current grid including totals for numeric columns
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var numericColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "CostPrice", "Selling Price", "Qty IN", "Qty OUT"
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

            // company
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

            // Header table
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
            center.AddFormattedText("Item In And Out Report\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText($"From: {dtFrom.Value:dd/MM/yyyy}  To: {dtTo.Value:dd/MM/yyyy}", TextFormat.NotBold).Font.Size = 9;

            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Data table
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // add columns mapping to dgvCustomer columns
            foreach (DataGridViewColumn col in dgvCustomer.Columns)
            {
                if (numericColumns.Contains(col.Name))
                    table.AddColumn("2.0cm");
                else if (col.Name.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    table.AddColumn("4.0cm");
                else
                    table.AddColumn("2.5cm");
            }

            // header row
            Row hdr = table.AddRow();
            hdr.Shading.Color = Colors.LightGray;
            hdr.Format.Font.Bold = true;
            for (int c = 0; c < dgvCustomer.Columns.Count; c++)
                hdr.Cells[c].AddParagraph(dgvCustomer.Columns[c].HeaderText);

            // data rows
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
            // find first numeric column index
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

            // render & save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Item In And Out Report";
                saveFile.FileName = "ItemInAndOutReport.pdf";

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
                "CostPrice", "Selling Price", "Qty IN", "Qty OUT"
            };

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Item In And Out Report";
                saveDialog.FileName = "ItemInAndOutReport.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "ItemInAndOut";

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
                // determine first numeric column (1-based)
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
