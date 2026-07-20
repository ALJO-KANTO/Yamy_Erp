using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.UI.Default;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject.UI.Reports.Inventory
{
    public partial class frmStockLedger : Form
    {
        public frmStockLedger()
        {
            InitializeComponent();
            Load += Frm_Load;

            btnLoad.Click += BtnLoad_Click;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();

            dtFrom.Value =
                new DateTime(DateTime.Today.Year,
                             DateTime.Today.Month, 1);

            dtTo.Value = DateTime.Today;
        }

        void LoadCombos()
        {
            // ITEM

            DataTable dtItem =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_items ORDER BY name");

            DataRow itemRow = dtItem.NewRow();

            itemRow["id"] = 0;
            itemRow["name"] = "ALL";

            dtItem.Rows.InsertAt(itemRow, 0);

            cmbItem.DataSource = dtItem;
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            // WAREHOUSE

            DataTable dtWh =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_warehouse");

            DataRow whRow = dtWh.NewRow();

            whRow["id"] = 0;
            whRow["name"] = "ALL";

            dtWh.Rows.InsertAt(whRow, 0);

            cmbWarehouse.DataSource = dtWh;
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";

            // PROJECT

            DataTable dtProject =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_projects");

            DataRow prRow = dtProject.NewRow();

            prRow["id"] = 0;
            prRow["name"] = "ALL";

            dtProject.Rows.InsertAt(prRow, 0);

            cmbProject.DataSource = dtProject;
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            // VIEW TYPE

            cmbViewType.Items.AddRange(new object[]
            {
                "Stock Ledger",
                "Bin Card",
                "Balance Summary"
            });

            cmbViewType.SelectedIndex = 0;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (cmbViewType.Text == "Balance Summary")
            {
                LoadBalanceSummary();
            }
            else
            {
                LoadLedger();
            }
        }

        void LoadLedger()
        {
            string sql = @"
            SELECT
                t.date,
                t.type,
                t.reference,
                i.name `Item Name`,
                w.name `Warehouse Name`,
                p.name `Project Name`,
                t.qty_in,
                t.qty_out,
                (
                    SELECT IFNULL(SUM(t2.qty_in - t2.qty_out),0)
                    FROM tbl_item_transaction t2
                    WHERE t2.item_id=t.item_id
                    AND t2.warehouse_id=t.warehouse_id
                    AND t2.id<=t.id
                ) balance_qty,
                t.cost_price,
                (
                    (
                        SELECT IFNULL(SUM(t2.qty_in - t2.qty_out),0)
                        FROM tbl_item_transaction t2
                        WHERE t2.item_id=t.item_id
                        AND t2.warehouse_id=t.warehouse_id
                        AND t2.id<=t.id
                    ) * t.cost_price
                ) stock_value,
                t.description

            FROM tbl_item_transaction t
            LEFT JOIN tbl_items i ON i.id=t.item_id
            LEFT JOIN tbl_warehouse w ON w.id=t.warehouse_id
            LEFT JOIN tbl_projects p ON p.id=t.project_id

            WHERE
                t.date BETWEEN @fromDate AND @toDate
                AND (@itemId=0 OR t.item_id=@itemId)
                AND (@warehouseId=0 OR t.warehouse_id=@warehouseId)
                AND (@projectId=0 OR t.project_id=@projectId)
            ORDER BY t.date,t.id";

            DataTable dt =
                DBClass.ExecuteDataTable(sql,

                DBClass.CreateParameter(
                    "@fromDate",
                    dtFrom.Value.Date),

                DBClass.CreateParameter(
                    "@toDate",
                    dtTo.Value.Date),

                DBClass.CreateParameter(
                    "@itemId",
                    cmbItem.SelectedValue),

                DBClass.CreateParameter(
                    "@warehouseId",
                    cmbWarehouse.SelectedValue),

                DBClass.CreateParameter(
                    "@projectId",
                    cmbProject.SelectedValue));

            dgvLedger.DataSource = dt;

            dgvLedger.Columns["balance_qty"].HeaderText = "Balance Qty";
            dgvLedger.Columns["date"].HeaderText = "Date";
            dgvLedger.Columns["type"].HeaderText = "Type";
            dgvLedger.Columns["reference"].HeaderText = "Reference";
            dgvLedger.Columns["qty_in"].HeaderText = "Qty in";
            dgvLedger.Columns["qty_out"].HeaderText = "Qty Out";
            dgvLedger.Columns["cost_price"].HeaderText = "Cost Price";
            dgvLedger.Columns["description"].HeaderText = "Description";

            CalculateSummary(dt);
        }

        void LoadBalanceSummary()
        {
            string sql = @"
            SELECT
                i.name `Item Name`,
                w.name `Warehouse Name`,
                IFNULL(SUM(
                    t.qty_in - t.qty_out
                ),0) balance_qty,
                AVG(t.cost_price) avg_cost,
                (
                    IFNULL(SUM(
                        t.qty_in - t.qty_out
                    ),0)
                    *
                    AVG(t.cost_price)
                ) stock_value
            FROM tbl_item_transaction t
            LEFT JOIN tbl_items i
                ON i.id=t.item_id
            LEFT JOIN tbl_warehouse w
                ON w.id=t.warehouse_id
            WHERE
                (@itemId=0 OR t.item_id=@itemId)
                AND (@warehouseId=0 OR t.warehouse_id=@warehouseId)
            GROUP BY
                i.id,
                w.id
            HAVING balance_qty <> 0
            ORDER BY i.name";

            DataTable dt = DBClass.ExecuteDataTable(sql,

                DBClass.CreateParameter(
                    "@itemId",
                    cmbItem.SelectedValue),

                DBClass.CreateParameter(
                    "@warehouseId",
                    cmbWarehouse.SelectedValue));

            dgvLedger.DataSource = dt;

            decimal closing = 0;
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrEmpty(row["balance_qty"].ToString())) 
                    closing += Convert.ToDecimal(row["balance_qty"]);
            }

            txtClosing.Text = closing.ToString("0.000");

            txtTotalIn.Text = "";
            txtTotalOut.Text = "";

            dgvLedger.Columns["balance_qty"].HeaderText = "Balance Qty";
            dgvLedger.Columns["avg_cost"].HeaderText = "AVG Cost";
            dgvLedger.Columns["stock_value"].HeaderText = "Stock Value";
        }

        void CalculateSummary(DataTable dt)
        {
            decimal totalIn = 0;
            decimal totalOut = 0;
            decimal closing = 0;

            if (dt == null) return;
            if (dt.Rows.Count == 0) return;

            foreach (DataRow row in dt.Rows)
            {
                if(!string.IsNullOrEmpty(row["qty_in"].ToString()))
                    totalIn += Convert.ToDecimal(row["qty_in"]);
                if (!string.IsNullOrEmpty(row["qty_out"].ToString()))
                    totalOut += Convert.ToDecimal(row["qty_out"]);
                if (!string.IsNullOrEmpty(row["balance_qty"].ToString()))
                    closing = Convert.ToDecimal(row["balance_qty"]);
            }

            txtTotalIn.Text =
                totalIn.ToString("0.000");

            txtTotalOut.Text =
                totalOut.ToString("0.000");

            txtClosing.Text =
                closing.ToString("0.000");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
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

            FormattedText titleText = center.AddFormattedText("Stock Ledger\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Stock Ledger", TextFormat.NotBold);
            sub.Font.Size = 9;

            // Separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            foreach (DataGridViewColumn col in dgvLedger.Columns)
            {
                Column tCol = table.AddColumn(Unit.FromCentimeter(3));
                tCol.Format.Alignment = ParagraphAlignment.Left;
            }

            Row head = table.AddRow();
            head.Shading.Color = Colors.LightGray;
            head.Format.Font.Bold = true;

            for (int i = 0; i < dgvLedger.Columns.Count; i++)
            {
                head.Cells[i].AddParagraph(dgvLedger.Columns[i].HeaderText);
            }

            foreach (DataGridViewRow row in dgvLedger.Rows)
            {
                if (row.IsNewRow) continue;

                Row tRow = table.AddRow();

                for (int col = 0; col < dgvLedger.Columns.Count; col++)
                {
                    string value = GetFormattedValue(row.Cells[col].Value);
                    var p = tRow.Cells[col].AddParagraph(value);

                    decimal num;
                    if (decimal.TryParse(value, out num))
                    {
                        p.Format.Alignment = ParagraphAlignment.Right;
                    }

                    if (col == 0 && !string.IsNullOrWhiteSpace(value) && row.Cells[1].Value.ToString() == "")
                    {
                        p.Format.Font.Bold = true;
                    }

                    if (col == 1 && !string.IsNullOrWhiteSpace(value))
                    {
                        p.Format.Font.Italic = true;
                    }
                }
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            // Save file
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Files (*.pdf)|*.pdf";
                dlg.Title = "Stock Ledger";
                dlg.FileName = "StockLedger.pdf";

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

        private async void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Stock Ledger";
                saveDialog.FileName = "StockLedger.xlsx";

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
                            worksheet.Name = "Stock Ledger";

                            int totalRows = dgvLedger.Rows.Count;
                            int processed = 0;

                            // ================================
                            // HEADER (Date and time)
                            // ================================

                            Excel.Range headerRange3 = worksheet.Range["B1", "F1"];
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
                            for (int col = 0; col < dgvLedger.Columns.Count; col++)
                            {
                                var column = dgvLedger.Columns[col];

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

                            foreach (DataGridViewRow row in dgvLedger.Rows)
                            {
                                if (row.IsNewRow) continue;
                                if (progress.CancelRequested)
                                    throw new Exception("Operation cancelled.");

                                for (int i = 0; i < dgvLedger.Columns.Count; i++)
                                {
                                    var column = dgvLedger.Columns[i];
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
    }
}