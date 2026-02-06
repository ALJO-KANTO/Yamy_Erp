using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    public partial class frmInventoryTurnoverByItem : Form
    {
        public frmInventoryTurnoverByItem()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }

        private void frmValuationStockStatusByItem_Load(object sender, EventArgs e)
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
            dgvReport.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvReport.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvReport.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvReport.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvReport.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvReport.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            SetupDataGridView();
            string sql = @"
                            SELECT 
                                -- Item Identifiers
                                i.type,
                                i.code,
                                i.name AS description,
                                c.code AS category_code,
                                c.name AS category_name,
                                IFNULL(
                                    (
                                        IFNULL((
                                            SELECT SUM(t.qty_out * t.cost_price)
                                            FROM tbl_item_transaction t
                                            WHERE t.date BETWEEN @sDate AND @eDate 
                                              AND t.item_id = i.id
                                        ), 0) /
                                        NULLIF((
                                            (
                                                IFNULL((
                                                    SELECT SUM(t.qty_in - t.qty_out)
                                                    FROM tbl_item_transaction t
                                                    WHERE t.date < @sDate AND t.item_id = i.id
                                                ), 0) +
                                                IFNULL((
                                                    SELECT SUM(t.qty_in - t.qty_out)
                                                    FROM tbl_item_transaction t
                                                    WHERE t.date <= @eDate AND t.item_id = i.id
                                                ), 0)
                                            ) / 2
                                        ), 0)
                                    ), 0
                                ) AS turnover_ratio,
                                -- Turnover Days = 365 / Turnover Ratio
                                IFNULL(
                                    365 / NULLIF((
                                        IFNULL((
                                            SELECT SUM(t.qty_out * t.cost_price)
                                            FROM tbl_item_transaction t
                                            WHERE t.date BETWEEN @sDate AND @eDate 
                                              AND t.item_id = i.id
                                        ), 0) /
                                        NULLIF((
                                            (
                                                IFNULL((
                                                    SELECT SUM(t.qty_in - t.qty_out)
                                                    FROM tbl_item_transaction t
                                                    WHERE t.date < @sDate AND t.item_id = i.id
                                                ), 0) +
                                                IFNULL((
                                                    SELECT SUM(t.qty_in - t.qty_out)
                                                    FROM tbl_item_transaction t
                                                    WHERE t.date <= @eDate AND t.item_id = i.id
                                                ), 0)
                                            ) / 2
                                        ), 0)
                                    ), 0)
                                , 0) AS turnover_days,
                                -- Last Sell Date
                                IFNULL((
                                    SELECT t.date
                                    FROM tbl_item_transaction t
                                    WHERE t.item_id = i.id AND t.qty_out > 0
                                    ORDER BY t.date DESC
                                    LIMIT 1
                                ),'') AS last_sell_date,
                                i.cost_price AS cost_per_unit, i.sales_price, 
	                             -- Quantity on hand (Closing)
                                IFNULL((
                                    SELECT SUM(t.qty_in - t.qty_out)
                                    FROM tbl_item_transaction t
                                    WHERE t.date <= @eDate AND t.item_id = i.id
                                ), 0) AS quantity_on_hand,
                                -- Reorder Points
                                '' AS reorder_point_min,
                                '' AS reorder_point_max,
                                -- COGS (qty_out * cost_price)
                                IFNULL((
                                    SELECT SUM(t.qty_out * t.cost_price)
                                    FROM tbl_item_transaction t
                                    WHERE t.date BETWEEN @sDate AND @eDate 
                                      AND t.item_id = i.id
                                ), 0) AS cogs,
                                -- Closing Stock Value (last cost price * closing qty)
                                IFNULL((
                                    SELECT SUM(t.qty_in - t.qty_out)
                                    FROM tbl_item_transaction t
                                    WHERE t.date <= @eDate AND t.item_id = i.id
                                ), 0) AS closing_stock,
	                            -- Opening Stock
                                IFNULL((
                                    SELECT SUM(t.qty_in - t.qty_out)
                                    FROM tbl_item_transaction t
                                    WHERE t.date < @sDate AND t.item_id = i.id
                                ), 0) AS opening_stock,
                                -- Purchases during period
                                IFNULL((
                                    SELECT SUM(t.qty_in)
                                    FROM tbl_item_transaction t
                                    WHERE t.date BETWEEN @sDate AND @eDate 
                                      AND t.item_id = i.id AND t.type='Purchase Invoice'
                                ), 0) AS purchases,
                                -- Average Inventory = (opening + closing)/2
                                (
                                    IFNULL((
                                        SELECT SUM(t.qty_in - t.qty_out)
                                        FROM tbl_item_transaction t
                                        WHERE t.date < @sDate AND t.item_id = i.id
                                    ), 0) +
                                    IFNULL((
                                        SELECT SUM(t.qty_in - t.qty_out)
                                        FROM tbl_item_transaction t
                                        WHERE t.date <= @eDate AND t.item_id = i.id
                                    ), 0)
                                ) / 2 AS average_inventory
                            FROM tbl_items i
                            JOIN tbl_item_category c ON i.category_id = c.id
                            WHERE i.state = 0
                            ORDER BY c.name, i.name;
                            ";

            DataTable dt = DBClass.ExecuteDataTable(sql,
                DBClass.CreateParameter("sDate", dtpFrom.Value.Date),
                DBClass.CreateParameter("eDate", dtpTo.Value.Date));

            LoadInventoryValuationSummary(dt);

        }
        private void LoadInventoryValuationSummary(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            dgvReport.Rows.Clear();

            // Group by Type
            var typeGroups = dt.AsEnumerable()
                               .GroupBy(r => r["type"].ToString())
                               .ToList();

            foreach (var grpType in typeGroups)
            {
                string type = grpType.Key.Split('-')[1].Trim();

                // --- TYPE HEADER ---
                dgvReport.Rows.Add(type, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                DataGridViewRow typeRow = dgvReport.Rows[dgvReport.Rows.Count - 1];
                typeRow.DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                var categoryGroups = grpType.GroupBy(r => r["category_name"].ToString()).ToList();

                foreach (var grpCategory in categoryGroups)
                {
                    string category = grpCategory.Key;

                    bool hacCatCode = false;
                    // --- ITEM ROWS ---
                    foreach (var r in grpCategory)
                    {
                        string category_code = r["category_code"].ToString();
                        string category_name = r["category_name"].ToString();
                        string categoryType = "Uncategorized";

                        if (!hacCatCode)
                        {
                            dgvReport.Rows.Add(category_code, category_name, categoryType, "", "", "", "0", "0", "0", "", "", "0", "0", "0", "0", "0");
                            hacCatCode = true;
                        }
                        string itemCode = r["code"].ToString();
                        string itemName = r["description"].ToString();
                        decimal turnover_ratio = Convert.ToDecimal(r["turnover_ratio"]);
                        decimal turnover_days = Convert.ToDecimal(r["turnover_days"]);
                        string last_sell_date = r["last_sell_date"].ToString();
                        decimal cost_per_unit = Convert.ToDecimal(r["cost_per_unit"]);
                        decimal sales_price = Convert.ToDecimal(r["sales_price"]);
                        decimal quantity_on_hand = Convert.ToDecimal(r["quantity_on_hand"]);
                        string reorder_point_min = r["reorder_point_min"].ToString();
                        string reorder_point_max = r["reorder_point_max"].ToString();
                        decimal cogs = Convert.ToDecimal(r["cogs"]);
                        decimal closing_stock = Convert.ToDecimal(r["closing_stock"]);
                        decimal opening_stock = Convert.ToDecimal(r["opening_stock"]);
                        decimal purchases = Convert.ToDecimal(r["purchases"]);
                        decimal average_inventory = Convert.ToDecimal(r["average_inventory"]);
                        dgvReport.Rows.Add(category_code + ":" + itemCode, itemName, categoryType, turnover_ratio, turnover_days, last_sell_date, cost_per_unit, sales_price, quantity_on_hand, reorder_point_min, reorder_point_max, cogs, closing_stock, opening_stock, purchases, average_inventory);
                    }
                }
            }

            // --- FORMAT COLUMNS ---
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Index > 2)
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvReport.Columns.Clear();

            //dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.Columns.Add("Item", "Item");
            dgvReport.Columns.Add("Description", "Description");
            dgvReport.Columns.Add("Category", "Category");
            dgvReport.Columns.Add("TurnoverRatio", "Turnover Ratio");
            dgvReport.Columns.Add("TurnoverDays", "Turnover Days");
            dgvReport.Columns.Add("LastSellDate", "Last Sell Date");
            dgvReport.Columns.Add("CostPerUnit", "Cost Per Unit");
            dgvReport.Columns.Add("SalesPrice", "Sales Price");
            dgvReport.Columns.Add("QuantityOnHand", "Quantity on Hand");
            dgvReport.Columns.Add("ReorderPointMin", "Reorder Point Min");
            dgvReport.Columns.Add("ReorderPointMax", "Reorder Point Max");
            dgvReport.Columns.Add("COGS", "COGS");
            dgvReport.Columns.Add("ClosingStock", "Closing Stock");
            dgvReport.Columns.Add("OpeningStock", "Opening Stock");
            dgvReport.Columns.Add("Purchases", "Purchases");
            dgvReport.Columns.Add("AverageInventory", "Average Inventory");

            // Set Column Autosizing
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Name == "Item" ||
                    col.Name == "Description" ||
                    col.Name == "Category")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   // make main columns expand
                }
                else
                {
                    //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // numeric/date columns shrink
                }
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

            FormattedText titleText = center.AddFormattedText("Inventory Turnover By Item\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Inventory Turnover By Item", TextFormat.NotBold);
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
                dlg.Title = "Inventory Turnover By Item";
                dlg.FileName = "InventoryTurnoverByItem.pdf";

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
                saveDialog.Title = "Inventory Turnover By Item";
                saveDialog.FileName = "InventoryTurnoverByItem.xlsx";

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
                            worksheet.Name = "InventoryTurnoverByItem";

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

        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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