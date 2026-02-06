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
    public partial class frmAssemblyShortageByVendor : Form
    {
        public frmAssemblyShortageByVendor()
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
                            SELECT
                                IFNULL((SELECT NAME FROM tbl_vendor WHERE id = i.vendor_id),'') AS PrefVendor,
                                IFNULL((SELECT SUM(a.qty_in - a.qty_out)
                                        FROM tbl_item_transaction a
                                        WHERE a.item_id = i.id 
                                        AND a.date >= @sDate AND a.date <= @eDate), 0) AS OnHand,
                                (SELECT IFNULL(SUM(qty),0)
                                 FROM tbl_item_assembly
                                 WHERE item_id = i.id) AS ForAssemblies,
                                IFNULL((SELECT SUM(a.qty_in - a.qty_out)
                                        FROM tbl_item_transaction a
                                        WHERE a.item_id = i.id 
                                        AND a.date >= @sDate AND a.date <= @eDate), 0) AS Available,
                                (SELECT IFNULL(SUM(a.qty),0)
                                 FROM tbl_purchase_order_details a
                                 JOIN tbl_purchase_order b ON b.id = a.purchase_id
                                 WHERE a.item_id = i.id
                                   AND b.date >= @sDate AND b.date <= @eDate
                                   AND a.item_id IN (
                                        SELECT a.item_id
                                        FROM tbl_purchase_details a
                                        JOIN tbl_purchase b ON b.id = a.purchase_id
                                        WHERE b.date >= @sDate AND b.date <= @eDate
                                          AND a.item_id = i.id
                                 )) AS OnPO,
                                0 AS NeededShortage,
                                IFNULL((SELECT b.ship_date
                                        FROM tbl_sales_details a
                                        JOIN tbl_sales b ON b.id = a.sales_id
                                        WHERE a.item_id = i.id
                                          AND b.date >= @sDate AND b.date <= @eDate
                                        ORDER BY b.date
                                        LIMIT 1), '') AS NextDelivery
                            FROM tbl_items i
                            WHERE i.state = 0 and type = '13 - Inventory Assembly'
                            ORDER BY i.name;
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

            foreach (DataRow r in dt.Rows)
            {
                string vendor = r["PrefVendor"]?.ToString() ?? "";
                decimal onHand = r["OnHand"] != DBNull.Value ? Convert.ToDecimal(r["OnHand"]) : 0;
                decimal asm = r["ForAssemblies"] != DBNull.Value ? Convert.ToDecimal(r["ForAssemblies"]) : 0;
                decimal avail = r["Available"] != DBNull.Value ? Convert.ToDecimal(r["Available"]) : 0;
                decimal onpo = r["OnPO"] != DBNull.Value ? Convert.ToDecimal(r["OnPO"]) : 0;
                decimal neededShortage = r["NeededShortage"] != DBNull.Value ? Convert.ToDecimal(r["NeededShortage"]) : 0;
                string nextDelivery =
                    (r["NextDelivery"] != DBNull.Value && r["NextDelivery"].ToString() != "")
                    ? Convert.ToDateTime(r["NextDelivery"]).ToString("MM/dd/yyyy")
                    : "";

                dgvReport.Rows.Add(
                    vendor,
                    onHand,
                    asm,
                    avail,
                    onpo,
                    neededShortage,
                    nextDelivery
                );
            }

            // Number formatting
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Index >= 1) // numeric columns start from OnHand
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add("PrefVendor", "");
            dgvReport.Columns.Add("OnHand", "On Hand");
            dgvReport.Columns.Add("ForAssemblies", "For Assemblies");
            dgvReport.Columns.Add("Available", "Available");
            dgvReport.Columns.Add("OnPO", "On PO");
            dgvReport.Columns.Add("NeededShortage", "Needed/Shortage");
            dgvReport.Columns.Add("NextDelivery", "Next Delivery");

            dgvReport.Columns["NextDelivery"].DefaultCellStyle.Format = "MM/dd/yyyy";

            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                //if (col.Name == "Item")
                //    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //else
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

            FormattedText titleText = center.AddFormattedText("Assembly Shortage By Vendor\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Assembly Shortage By Vendor", TextFormat.NotBold);
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
                dlg.Title = "Assembly Shortage By Vendor";
                dlg.FileName = "AssemblyShortageByVendor.pdf";

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
                saveDialog.Title = "AssemblyShortageByVendor";
                saveDialog.FileName = "AssemblyShortageByVendor.xlsx";

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
                            worksheet.Name = "AssemblyShortageByVendor";

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