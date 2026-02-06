using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Default;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmInventoryValuationDetail : Form
    {
        int itemId;
        public frmInventoryValuationDetail(int _itemId =0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.itemId = _itemId;
            headerUC1.FormText = this.Text;
        }

        private void frmInventoryValuationDetail_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ▼";
            LoadData();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                if (reader.Read())
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:tt");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            contextMenuExport.Show(btnPrint, new Point(0, btnPrint.Height));
        }

        private void Report_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exporting Report...");
        }
        private void LoadData()
        {
            SetupDataGridView();

            string sql = @"SELECT
                                i.type,
                                c.id AS category_id,
                                CONCAT(c.code,' (',c.name,')') AS category_name,
                                i.id AS item_id,
                                CONCAT(i.code,' (',i.name,')') AS item_name,
                                j.date,
                                j.hum_id,
                                CASE 
                                     WHEN j.type LIKE 'Sales%' 
                                        THEN IFNULL((SELECT CONCAT(code,' - ',name) FROM tbl_customer WHERE id = j.hum_id),'')
                                     WHEN j.type LIKE 'Purchase%' 
                                        THEN IFNULL((SELECT CONCAT(code,' - ',name) FROM tbl_vendor WHERE id = j.hum_id),'')
                                     ELSE '' 
                                END AS ac_name,
                                j.type AS trans_type,
                                t.type AS item_type,
                                j.voucher_no AS ref_no,
                                t.reference AS ref_id,
                                t.qty_in,
                                t.qty_out,
                                (t.qty_in - t.qty_out * -1) AS qty,
                                t.cost_price
                            FROM tbl_item_transaction t
                            JOIN tbl_items i 
                                ON t.item_id = i.id 
                                -- AND t.type IN ('Sales Invoice','Purchase Invoice',
                                --               'Stock Inventory Settlement','Inventory Settlement',
                                --               'Purchase Return Invoice','Opening Qty','SalesReturn Invoice')
                            JOIN tbl_transaction j 
                                ON j.transaction_id = t.reference
                               AND j.date = t.date
                             --  AND (
                             --           (t.type LIKE 'Sales Invoice%' AND j.type LIKE 'Sales Invoice%')
                             --        OR (t.type LIKE 'Purchase Invoice%' AND j.type LIKE 'Purchase Invoice%')
                                     -- OR t.type = j.type
                             --      )
                               AND j.hum_id != 0
                            JOIN tbl_item_category c ON i.category_id = c.id
                            WHERE t.date BETWEEN @sDate AND @eDate
                            ORDER BY c.name, i.name, t.date, t.id;";

            DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("sDate", dtpFrom.Value.Date), DBClass.CreateParameter("eDate", dtpTo.Value.Date));

            LoadDetailedInventoryReport(dt);
        }

        private void LoadDetailedInventoryReport(DataTable dt)
        {
            dgvReport.Rows.Clear();

            if (dt.Rows.Count == 0) return;

            decimal grandTotalAsset = 0, grandTotalQty = 0;

            var typeGroups = dt.AsEnumerable()
                       .GroupBy(r => r["type"].ToString())
                       .ToList();

            foreach (var grpType in typeGroups)
            {
                string typeName = grpType.Key;

                // --- TYPE HEADER ---
                dgvReport.Rows.Add(typeName, "", "", "", "", "", "", "", "");
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font =
                    new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                decimal typeTotal = 0, typeQtyTotal = 0;

                // GROUP BY CATEGORY WITHIN TYPE
                var categoryGroups = grpType.GroupBy(r => r["category_id"]).ToList();

                foreach (var grpCategory in categoryGroups)
                {
                    string categoryName = grpCategory.First()["category_name"].ToString();

                    // --- CATEGORY HEADER ---
                    dgvReport.Rows.Add("   " + categoryName, "", "", "", "", "", "", "", "");
                    dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font =
                        new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                    decimal categoryTotal = 0, categoryQtyTotal = 0;

                    // GROUP BY ITEM WITHIN CATEGORY
                    var itemGroups = grpCategory.GroupBy(r => r["item_id"]).ToList();

                    foreach (var grpItem in itemGroups)
                    {
                        string itemName = grpItem.First()["item_name"].ToString();

                        // --- ITEM HEADER ---
                        dgvReport.Rows.Add("      " + itemName, "", "", "", "", "", "", "", "");
                        dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font =
                            new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                        decimal onHand = 0;
                        decimal avgCost = 0;

                        // --- TRANSACTION ROWS ---
                        foreach (var r in grpItem.OrderBy(x => Convert.ToDateTime(x["date"])))
                        {
                            decimal qtyIn = Convert.ToDecimal(r["qty_in"]);
                            decimal qtyOut = Convert.ToDecimal(r["qty_out"]);
                            decimal qty = Convert.ToDecimal(r["qty"]);
                            decimal cost = Convert.ToDecimal(r["cost_price"]);

                            // ─── PURCHASE (Bill),sales return, opening stock ───────────────────────────
                            if (qtyIn > 0)
                            {
                                decimal beforeValue = onHand * avgCost;
                                decimal addedValue = qtyIn * cost;
                                onHand += qtyIn;
                                avgCost = onHand == 0 ? 0 : (beforeValue + addedValue) / onHand;
                            }
                            // ─── SALE (Invoice), purchase return , sto ────────────────────────────
                            else if (qtyOut > 0)
                            {
                                onHand -= qtyOut;
                            }

                            decimal assetValue = onHand * avgCost;

                            string qtyValue = qtyIn > 0 ? qtyIn.ToString("N2") : qtyOut.ToString("N2");
                            string costValue = qtyIn > 0 ? cost.ToString("N2") : "";
                            //string itemType = r["trans_type"].ToString().Replace("Cash", "").Trim(); 
                            string itemType = r["item_type"].ToString();

                            dgvReport.Rows.Add(
                                "         " + itemType,
                                Convert.ToDateTime(r["date"]).ToString("MM/dd/yyyy"),
                                r["ac_name"],
                                r["ref_no"],
                                qtyValue,
                                costValue,
                                onHand,
                                avgCost.ToString("N2"),
                                assetValue.ToString("N2")
                            );

                        }

                        decimal itemTotal = onHand * avgCost;
                        categoryTotal += itemTotal;
                        categoryQtyTotal += onHand;
                        typeTotal += itemTotal;
                        typeQtyTotal += onHand;
                        grandTotalAsset += itemTotal;
                        grandTotalQty += onHand;

                        // --- ITEM TOTAL ---
                        dgvReport.Rows.Add("      Total " + itemName, "", "", "", "", "", onHand.ToString("N2"), "", itemTotal.ToString("N2"));
                    }

                    // --- CATEGORY TOTAL ---
                    dgvReport.Rows.Add("   Total " + categoryName, "", "", "", "", "", categoryQtyTotal.ToString("N2"), "", categoryTotal.ToString("N2"));
                    dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }

                // --- TYPE TOTAL ---
                dgvReport.Rows.Add("Total " + typeName, "", "", "", "", "", typeQtyTotal.ToString("N2"), "", typeTotal.ToString("N2"));
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            }

            // --- GRAND TOTAL ---
            dgvReport.Rows.Add("TOTAL", "", "", "", "", "", grandTotalQty.ToString("N2"), "", grandTotalAsset.ToString("N2"));
            dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

            // --- FORMAT COLUMNS ---
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Index > 3)
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add("Type", "Type");
            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("Name", "Name");
            dgvReport.Columns.Add("Ref", "Num");
            dgvReport.Columns.Add("Qty", "Qty");
            dgvReport.Columns.Add("Cost", "Cost");
            dgvReport.Columns.Add("OnHand", "On Hand");
            dgvReport.Columns.Add("AvgCost", "Avg Cost");
            dgvReport.Columns.Add("AssetValue", "Asset Value");

            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Name == "Name" || col.Name == "Type")
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   // expand
                else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // shrink
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            string companyName = lblCompany.Text;

            // Create PDF document
            Document doc = new Document();
            Section section = doc.AddSection();

            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            //==========================================
            // HEADER TABLE
            //==========================================
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");
            headerTable.AddColumn("8cm");
            headerTable.AddColumn("5cm");

            Row headerRow = headerTable.AddRow();

            // Left cell: time/date
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center: company name
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;

            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText titleText = center.AddFormattedText("INVENTORY VALUATION DETAIL\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Inventory Valuation Detail", TextFormat.NotBold);
            sub.Font.Size = 9;

            // Separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            //==========================================
            // DATA TABLE
            //==========================================
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Create columns based on DataGridView columns
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                Column tCol = table.AddColumn(Unit.FromCentimeter(3));
                tCol.Format.Alignment = ParagraphAlignment.Left;
            }

            // Add header row
            Row head = table.AddRow();
            head.Shading.Color = Colors.LightGray;
            head.Format.Font.Bold = true;

            for (int i = 0; i < dgvReport.Columns.Count; i++)
            {
                head.Cells[i].AddParagraph(dgvReport.Columns[i].HeaderText);
            }

            //==========================================
            // ADD DATA ROWS
            //==========================================
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (row.IsNewRow) continue;

                Row tRow = table.AddRow();

                for (int col = 0; col < dgvReport.Columns.Count; col++)
                {
                    string value = GetFormattedValue(row.Cells[col].Value);

                    var p = tRow.Cells[col].AddParagraph(value);

                    // Align numeric values
                    decimal num;
                    if (decimal.TryParse(value, out num))
                    {
                        p.Format.Alignment = ParagraphAlignment.Right;
                    }

                    // Make Type row bold
                    if (col == 0 && !string.IsNullOrWhiteSpace(value) && row.Cells[1].Value.ToString() == "")
                    {
                        p.Format.Font.Bold = true;
                    }

                    // Make Category row italic
                    if (col == 1 && !string.IsNullOrWhiteSpace(value))
                    {
                        p.Format.Font.Italic = true;
                    }

                    //string value = row.Cells[col].Value?.ToString() ?? "";
                    //var p = tRow.Cells[col].AddParagraph(value);
                    //// Align numeric values (warehouse qty)
                    //decimal num;
                    //if (decimal.TryParse(value, out num))
                    //{
                    //    p.Format.Alignment = ParagraphAlignment.Right;
                    //}
                    //// Make Type row bold
                    //if (col == 0 && !string.IsNullOrWhiteSpace(value) && row.Cells[1].Value.ToString() == "")
                    //{
                    //    p.Format.Font.Bold = true;
                    //}
                }
            }

            //==========================================
            // RENDER PDF
            //==========================================
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            // Save file
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Files (*.pdf)|*.pdf";
                dlg.Title = "Inventory Valuation Detail";
                dlg.FileName = "InventoryValuationDetail.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(dlg.FileName);
                    Process.Start("explorer.exe", dlg.FileName);
                }
            }
        }
        private string GetFormattedValue(object val)
        {
            if (val == null || val == DBNull.Value) return "";

            decimal num;

            if (decimal.TryParse(val.ToString(), out num))
            {
                // Format as 0.00
                return num.ToString("N2");
            }

            return val.ToString();
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Inventory Valuation Detail";
                saveDialog.FileName = "InventoryValuationDetail.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Show progress window
                    FrmProgress progress = new FrmProgress();
                    progress.Show();

                    await Task.Run(() =>
                    {
                        try
                        {
                            var excelApp = new Excel.Application();
                            excelApp.Visible = false;

                            var workbook = excelApp.Workbooks.Add(Type.Missing);
                            var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                            worksheet.Name = "Inventory Valuation Detail";

                            int totalRows = dgvReport.Rows.Count;
                            int processed = 0;

                            // ================================
                            // HEADER (Date and time)
                            // ================================

                            Excel.Range headerRange0 = worksheet.Range["B1", "F1"];
                            headerRange0.Merge();
                            headerRange0.Value = lblCompany.Text;
                            headerRange0.Font.Bold = true;
                            headerRange0.Font.Name = "Times New Roman";
                            headerRange0.Font.Size = 12;
                            headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            Excel.Range headerRange1 = worksheet.Range["B2", "F2"];
                            headerRange1.Merge();
                            headerRange1.Value = guna2HtmlLabel7.Text;
                            headerRange1.Font.Bold = true;
                            headerRange1.Font.Name = "Times New Roman";
                            headerRange1.Font.Size = 11;
                            headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            Excel.Range headerRange2 = worksheet.Range["B3", "F3"];
                            headerRange2.Merge();
                            headerRange2.Value = "From " + dtpFrom.Text + " - To " + dtpTo.Text;
                            headerRange2.Font.Bold = false;
                            headerRange2.Font.Name = "Times New Roman";
                            headerRange2.Font.Size = 9;
                            headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            // Merge and format header row (Date)
                            Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                            headerRange3.Merge();
                            headerRange3.Value = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                            headerRange3.Font.Bold = false;
                            headerRange3.Font.Name = "Times New Roman";
                            headerRange3.Font.Size = 9;
                            headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            int rowIndex = 5;

                            // ================================
                            // COLUMN HEADERS
                            // ================================
                            int colIndex = 1;
                            for (int col = 0; col < dgvReport.Columns.Count; col++)
                            {
                                var column = dgvReport.Columns[col];

                                // Skip hidden columns if needed
                                if (!column.Visible) continue;

                                var headerCell = worksheet.Cells[rowIndex, col + 1];
                                headerCell.Value = column.HeaderText;  // show column header
                                headerCell.Font.Bold = true;
                                headerCell.Font.Name = "Times New Roman";
                                headerCell.Font.Size = 11;
                                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                            }
                            rowIndex++;
                            // ================================
                            // DATA ROWS
                            // ================================

                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                if (row.IsNewRow) continue;
                                if (progress.CancelRequested)
                                    throw new Exception("Operation cancelled.");

                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    var column = dgvReport.Columns[i];
                                    if (!column.Visible) continue;

                                    var value = row.Cells[i].Value;

                                    // Set value
                                    worksheet.Cells[rowIndex, i + 1] = value;

                                    var cell = worksheet.Cells[rowIndex, i + 1];
                                    cell.Font.Name = "Times New Roman";
                                    cell.Font.Size = 10;

                                    // Right-align numeric warehouse columns
                                    if (i >= 3) // warehouse and "Main store" start at column index 3
                                    {
                                        cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                    }
                                }

                                rowIndex++;
                                processed++;

                                int percent = processed * 100 / totalRows;
                                progress.UpdateProgress(percent);
                            }

                            worksheet.Columns.AutoFit();
                            workbook.SaveAs(saveDialog.FileName);
                            workbook.Close(false);
                            excelApp.Quit();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Excel Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });

                    progress.Close();
                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dgvReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Utilities.UserPermissionCheck("CustomerBalanceSummary"))
            //{
                //int id = int.Parse(dgvPurchase.CurrentRow.Cells["id"].Value.ToString());
                //frmLogin.frmMain.openChildForm(new frmPurchaseOrderDetails(id));
            //}
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            //LoadPurchaseData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            //LoadPurchaseData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dtpFrom, dtpTo);
                LoadData();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}