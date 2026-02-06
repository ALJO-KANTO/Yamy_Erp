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
    public partial class frmInventoryStockStatusByItem : Form
    {
        public frmInventoryStockStatusByItem()
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
            SetupDataGridView();
            string sql = @"
                            SELECT i.type,
                                   CONCAT(c.code, ' (', c.name, ')') AS category_name,
                                   CONCAT(i.code, ' (', i.name, ')') AS item_name,
                                   IFNULL((SELECT NAME FROM tbl_vendor WHERE id = i.vendor_id),'') AS PrefVendor,
                                   '' AS ReorderPtMin,
                                   '' AS Max,
                                   IFNULL((SELECT SUM(a.qty_in - a.qty_out) FROM tbl_item_transaction a WHERE a.item_id = i.id AND a.date >= @sDate AND a.date <= @eDate), 0) AS OnHand,
                                   (SELECT IFNULL(SUM(qty),0) FROM tbl_item_assembly WHERE item_id=i.id) AS ForAssemblies,
                                   IFNULL((SELECT SUM(a.qty_in - a.qty_out) FROM tbl_item_transaction a WHERE a.item_id = i.id AND a.date >= @sDate AND a.date <= @eDate), 0) AS Available,
                                   (SELECT IFNULL(SUM(a.qty),0) FROM tbl_purchase_order_details a,tbl_purchase_order b WHERE b.id = a.purchase_id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id and a.item_id NOT IN (SELECT a.item_id FROM tbl_purchase_details a,tbl_purchase b WHERE a.purchase_id = b.id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id)) AS `Order`,
                                   (SELECT IFNULL(SUM(a.qty),0) FROM tbl_purchase_order_details a,tbl_purchase_order b WHERE b.id = a.purchase_id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id and a.item_id IN (SELECT a.item_id FROM tbl_purchase_details a,tbl_purchase b WHERE a.purchase_id = b.id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id)) AS OnPO,
                                   (SELECT IFNULL(SUM(a.qty),0) FROM tbl_purchase_order_details a,tbl_purchase_order b WHERE b.id = a.purchase_id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id and a.item_id NOT IN (SELECT a.item_id FROM tbl_purchase_details a,tbl_purchase b WHERE a.purchase_id = b.id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id)) AS ReorderQty,
                                   IFNULL((SELECT b.ship_date FROM tbl_sales_details a,tbl_sales b WHERE b.id = a.sales_id AND b.date >= @sDate AND b.date <= @eDate and a.item_id = i.id ORDER BY b.date LIMIT 1),'') AS NextDelivery,
                                   IFNULL((SELECT AVG(a.qty * a.price) FROM tbl_sales_details a, tbl_sales b WHERE a.sales_id = b.id and a.item_id = i.id AND b.date >= @sDate AND b.date <= @eDate),0) AS SalesWeek
                            FROM tbl_items i
                            JOIN tbl_item_category c ON i.category_id = c.id
                            WHERE i.state = 0
                            ORDER BY c.name, i.name;
                        ";

            DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("sDate", dtpFrom.Value.Date), DBClass.CreateParameter("eDate", dtpTo.Value.Date));
            LoadInventoryValuationSummary(dt);
        }

        private void LoadInventoryValuationSummary(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            dgvReport.Rows.Clear();
            decimal grandOnHandTotal = 0, grandForAssembliesTotal = 0, grandAvailableTotal = 0, grandOrderTotal = 0, grandOnPOTotal = 0, grandReorderQtyTotal = 0, grandSalesWeekTotal = 0;

            // Group by Type
            var typeGroups = dt.AsEnumerable()
                               .GroupBy(r => r.Field<string>("type"))
                               .ToList();

            foreach (var grpType in typeGroups)
            {
                string type = grpType.Key;

                decimal typeOnHandTotal = 0, typeForAssembliesTotal = 0, typeAvailableTotal = 0, typeOrderTotal = 0, typeOnPOTotal = 0, typeReorderQtyTotal = 0, typeSalesWeekTotal = 0;

                // TYPE HEADER row (bold)
                dgvReport.Rows.Add(type, "", "", "", "", "", "", "", "", "", "", "");
                var typeRow = dgvReport.Rows[dgvReport.Rows.Count - 1];
                typeRow.DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                // Group by Category inside this Type
                var categoryGroups = grpType.GroupBy(r => r.Field<string>("category_name")).ToList();

                foreach (var grpCategory in categoryGroups)
                {
                    string category = grpCategory.Key;

                    decimal catOnHandTotal = 0, catForAssembliesTotal = 0, catAvailableTotal = 0, catOrderTotal = 0, catOnPOTotal = 0, catReorderQtyTotal = 0, catSalesWeekTotal = 0;

                    // CATEGORY HEADER row (bold, indented 2 spaces)
                    dgvReport.Rows.Add("  " + category, "", "", "", "", "", "", "", "", "", "", "");
                    var catRow = dgvReport.Rows[dgvReport.Rows.Count - 1];
                    catRow.DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                    // ITEM rows (indented 4 spaces)
                    foreach (var r in grpCategory)
                    {
                        string itemName = r["item_name"].ToString();
                        string PrefVendor = r["PrefVendor"]?.ToString() ?? "";
                        string ReorderPtMin = r["ReorderPtMin"] != DBNull.Value ? r["ReorderPtMin"].ToString() : "";
                        string rMax = r["Max"] != DBNull.Value ? r["Max"].ToString() : "";
                        decimal onHand = Convert.ToDecimal(r["OnHand"]);
                        decimal ForAssemblies = Convert.ToDecimal(r["ForAssemblies"]);
                        decimal Available = Convert.ToDecimal(r["Available"]);
                        decimal Order = Convert.ToDecimal(r["Order"]);
                        decimal OnPO = Convert.ToDecimal(r["OnPO"]);
                        decimal ReorderQty = Convert.ToDecimal(r["ReorderQty"]);
                        string NextDelivery = (r["NextDelivery"] != DBNull.Value && r["NextDelivery"].ToString() != "")
                                ? Convert.ToDateTime(r["NextDelivery"]).ToString("MM/dd/yyyy")
                                : "";
                        decimal SalesWeek = Convert.ToDecimal(r["SalesWeek"]);

                        dgvReport.Rows.Add(
                            "    " + itemName,
                            PrefVendor,
                            ReorderPtMin,
                            rMax,
                            onHand,
                            ForAssemblies,
                            Available,
                            Order,
                            OnPO,
                            ReorderQty,
                            NextDelivery,
                            SalesWeek
                        );

                        catOnHandTotal += onHand;
                        catForAssembliesTotal += ForAssemblies;
                        catAvailableTotal += Available;
                        catOrderTotal += Order;
                        catOnPOTotal += OnPO;
                        catReorderQtyTotal += ReorderQty;
                        catSalesWeekTotal += SalesWeek;
                    }

                    // --- CATEGORY TOTAL ---
                    int catTotalIndex = dgvReport.Rows.Add("   Total " + category, "", "", "", catOnHandTotal, catForAssembliesTotal, catAvailableTotal, catOrderTotal, catOnPOTotal, catReorderQtyTotal, "", catSalesWeekTotal);
                    dgvReport.Rows[catTotalIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    dgvReport.Rows[catTotalIndex].DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                    typeOnHandTotal += catOnHandTotal;
                    typeForAssembliesTotal += catForAssembliesTotal;
                    typeAvailableTotal += catAvailableTotal;
                    typeOrderTotal += catOrderTotal;
                    typeOnPOTotal += catOnPOTotal;
                    typeReorderQtyTotal += catReorderQtyTotal;
                    typeSalesWeekTotal += catSalesWeekTotal;
                }

                // --- TYPE TOTAL ---
                int typeTotalIndex = dgvReport.Rows.Add(" Total " + type, "", "", "", typeOnHandTotal, typeForAssembliesTotal, typeAvailableTotal, typeOrderTotal, typeOnPOTotal, typeReorderQtyTotal, "", typeSalesWeekTotal);
                dgvReport.Rows[typeTotalIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                dgvReport.Rows[typeTotalIndex].DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

                grandOnHandTotal += typeOnHandTotal;
                grandForAssembliesTotal += typeForAssembliesTotal;
                grandAvailableTotal += typeAvailableTotal;
                grandOrderTotal += typeOrderTotal;
                grandOnPOTotal += typeOnPOTotal;
                grandReorderQtyTotal += typeReorderQtyTotal;
                grandSalesWeekTotal += typeSalesWeekTotal;
            }
            // --- GRAND TOTAL ---
            int grandTotalIndex = dgvReport.Rows.Add("TOTAL", "", "", "", grandOnHandTotal, grandForAssembliesTotal, grandAvailableTotal, grandOrderTotal, grandOnPOTotal, grandReorderQtyTotal, "", grandSalesWeekTotal);
            dgvReport.Rows[grandTotalIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvReport.Rows[grandTotalIndex].DefaultCellStyle.Font = new System.Drawing.Font(dgvReport.Font, FontStyle.Bold);

            // --- FORMAT COLUMNS ---
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Index > 1)
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add("Type", "");
            dgvReport.Columns.Add("PrefVendor", "Pref Vendor");
            dgvReport.Columns.Add("ReorderPtMin", "Reorder Pt (Min)");
            dgvReport.Columns.Add("Max", "Max");
            dgvReport.Columns.Add("OnHand", "On Hand");
            dgvReport.Columns.Add("ForAssemblies", "For Assemblies");
            dgvReport.Columns.Add("Available", "Available");
            dgvReport.Columns.Add("Order", "Order");
            dgvReport.Columns.Add("OnPO", "On PO");
            dgvReport.Columns.Add("ReorderQty", "Reorder Qty");
            dgvReport.Columns.Add("NextDelivery", "Next Deliv");
            dgvReport.Columns.Add("SalesWeek", "Sales/Week");

            // Optional: format NextDelivery as date
            dgvReport.Columns["NextDelivery"].DefaultCellStyle.Format = "MM/dd/yyyy";

            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Name == "Type")
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

            FormattedText titleText = center.AddFormattedText("Inventory Stock Status By Item\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Inventory Stock Status By Item", TextFormat.NotBold);
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
                dlg.Title = "Inventory Stock Status By Item";
                dlg.FileName = "InventoryStockStatusByItem.pdf";

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
                saveDialog.Title = "Inventory Stock Status By Item";
                saveDialog.FileName = "InventoryStockStatusByItem.xlsx";

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
                            worksheet.Name = "Inventory Stock Status By Item";

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