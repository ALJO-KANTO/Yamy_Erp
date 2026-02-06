using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmManPackingReport : Form
    {
        int bId;
        public frmManPackingReport(int _bId = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            bId = _bId;
        }

        private void frmManItemTreeDetails_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ";
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                if (reader.Read())
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:tt");
            //AddDGVColumns();
            LoadData();
        }
        private void LoadData()
        {
            LoadReport();
        }

        private void LoadReport()
        {
            dgvSales.Rows.Clear();

            string sql = @"SELECT 
                                p.id,
                                p.item_id,
                                i.name AS ItemName,
                                p.batch_id,
                                p.Variant,
                                p.quantity AS Qty,
                                p.batch_number AS Batch,
                                p.packing_date AS PackedOn,
                                p.rack_no AS Rack,
                                p.created_by,
                                p.warehouse_id,
                                w.name AS Warehouse
                            FROM tbl_manufacturer_packing p
                            LEFT JOIN tbl_items i ON i.id = p.item_id
                            LEFT JOIN tbl_warehouse w ON w.id = p.warehouse_id;
                            ";
            if (bId > 0)
            {
                sql = sql.Replace(";", $" WHERE p.item_id = {bId};");
            }
            DataTable dt = DBClass.ExecuteDataTable(sql);

            dgvSales.DataSource = dt;
            dgvSales.Columns["id"].Visible = dgvSales.Columns["item_id"].Visible = dgvSales.Columns["created_by"].Visible = dgvSales.Columns["warehouse_id"].Visible = dgvSales.Columns["batch_id"].Visible = false;

            dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvSales.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            // Create the link column
            DataGridViewLinkColumn printLinkColumn = new DataGridViewLinkColumn();
            printLinkColumn.HeaderText = "Print";
            printLinkColumn.Text = "Print";
            printLinkColumn.Name = "printLink";
            printLinkColumn.UseColumnTextForLinkValue = true;

            // Add it to the DataGridView
            dgvSales.Columns.Add(printLinkColumn);

            // Optional: handle the link click event
            dgvSales.CellContentClick += (s, e) =>
            {
                if (dgvSales.Columns[e.ColumnIndex].Name == "printLink" && e.RowIndex >= 0)
                {
                    // Get the ID of the selected row
                    var id = dgvSales.Rows[e.RowIndex].Cells["id"].Value;
                    string clientName = dgvSales.Rows[e.RowIndex].Cells["variant"].Value.ToString();
                    // Call your print logic here
                    //MessageBox.Show($"Printing record with ID: {id}");
                    ChooseInfoForm dlg = new ChooseInfoForm(
                        clientName,
                        "",
                        ""
                    );

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        // Update labels with chosen values
                        clientName = dlg.ClientNameValue;
                        string clientAddress = dlg.ClientAddressValue;
                        string clientContact = dlg.ClientContactValue;
                        string clientItemUnitPrice = dlg.ClientItemUnitPrice;
                        clientItemUnitPrice = string.IsNullOrEmpty(clientItemUnitPrice) ? "0" : clientItemUnitPrice;
                        bool isIncludeTax = dlg.IncludeTax;

                        GenerateQuotation(clientName, clientAddress, clientContact, clientItemUnitPrice, isIncludeTax);
                    }
                }
            };
        }
        private void GenerateQuotation(string clientName, string clientAddress, string clientContact, string clientItemUnitPrice, bool isIncludeTax)
        {
            // ---------------------------------------
            //  COMPANY INFORMATION (FROM YOUR LABELS)
            // ---------------------------------------
            
            string companyName = lblCompany.Text;
            string companyAddress = "";
            string companyPhone = "";
            string companyEmail = "";
            string companyWebsite = "";
            byte[] companyLogoBytes = null;

            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name, address, phone1, gmail, website, logoComp FROM tbl_company LIMIT 1"))
            {
                if (reader.Read())
                {
                    companyName = reader["name"].ToString();
                    companyAddress = reader["address"].ToString();
                    companyPhone = reader["phone1"].ToString();
                    companyEmail = reader["gmail"].ToString();
                    companyWebsite = reader["website"].ToString();

                    if (!reader.IsDBNull(reader.GetOrdinal("logoComp")))
                    {
                        companyLogoBytes = (byte[])reader["logoComp"];
                    }
                }
            }

            // ---------------------------------------
            // CREATE DOCUMENT
            // ---------------------------------------
            Document doc = new Document();
            Section section = doc.AddSection();

            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // ---------------------------------------
            // HEADER TABLE
            // ---------------------------------------
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("10cm");
            headerTable.AddColumn("10cm");

            Row headerRow = headerTable.AddRow();

            // LEFT — COMPANY INFO + LOGO
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;

            // Add Logo (from MySQL BLOB)
            if (companyLogoBytes != null && companyLogoBytes.Length > 0)
            {
                string tempLogo = Path.Combine(Path.GetTempPath(), "company_logo.png");
                File.WriteAllBytes(tempLogo, companyLogoBytes);

                MigraDoc.DocumentObjectModel.Shapes.Image image = left.AddImage(tempLogo);
                image.Width = Unit.FromCentimeter(3);

                left.AddLineBreak();
            }

            // Company info text
            left.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            left.AddText(companyAddress + "\n");
            left.AddText("Phone: " + companyPhone + "\n");
            left.AddText("Email: " + companyEmail + "\n");
            left.AddText("Website: " + companyWebsite + "\n");

            // ---------------------------------------
            // RIGHT — CLIENT INFO
            // ---------------------------------------
            Paragraph right = headerRow.Cells[1].AddParagraph();
            right.Format.Font.Name = "Times New Roman";
            right.Format.Font.Size = 10;
            right.Format.Alignment = ParagraphAlignment.Left;

            right.AddFormattedText("Quotation For:\n", TextFormat.Bold);
            right.AddText(clientName + "\n");
            right.AddText(clientAddress + "\n");
            right.AddText("Contact: " + clientContact + "\n");

            // ---------------------------------------
            // SEPARATOR LINE
            // ---------------------------------------
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // ---------------------------------------
            // SELECTED ROW FROM DATAGRIDVIEW
            // ---------------------------------------
            var row = dgvSales.CurrentRow;
            if (row == null || row.IsNewRow || !row.Visible)
                return;

            string brand = row.Cells["Variant"].Value?.ToString() ?? "Unknown";

            // Brand Header
            Paragraph brandPara = section.AddParagraph();
            brandPara.AddFormattedText("Brand: " + brand + "\n", TextFormat.Bold);
            brandPara.Format.Font.Size = 11;
            brandPara.Format.SpaceBefore = "0.2cm";
            brandPara.Format.SpaceAfter = "0.2cm";

            // ---------------------------------------
            // ITEMS TABLE
            // ---------------------------------------
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 10;

            table.AddColumn("10cm");  // Item Name
            table.AddColumn("3cm");   // Quantity
            table.AddColumn("3cm");   // Unit Price
            table.AddColumn("3cm");   // Total Price

            // Table Header
            Row head = table.AddRow();
            head.Shading.Color = Colors.LightGray;
            head.Format.Font.Bold = true;
            head.Cells[0].AddParagraph("Item Name");
            head.Cells[1].AddParagraph("Quantity");
            head.Cells[2].AddParagraph("Unit Price");
            head.Cells[3].AddParagraph("Total Price");

            // Item Row
            Row tRow = table.AddRow();
            tRow.Cells[0].AddParagraph(row.Cells["ItemName"].Value?.ToString() ?? "");

            decimal qtyVal, priceVal, subtotalVal;

            // Quantity
            Paragraph qtyPara = tRow.Cells[1].AddParagraph();
            qtyPara.Format.Alignment = ParagraphAlignment.Right;
            qtyPara.AddText(decimal.TryParse(row.Cells["Qty"].Value?.ToString(), out qtyVal)
                ? qtyVal.ToString("N2")
                : "0.00");

            // Unit Price
            Paragraph unitPricePara = tRow.Cells[2].AddParagraph();
            unitPricePara.Format.Alignment = ParagraphAlignment.Right;
            unitPricePara.AddText(decimal.TryParse(clientItemUnitPrice, out priceVal)
                ? priceVal.ToString("N2")
                : "0.00");

            // Subtotal
            subtotalVal = qtyVal * priceVal;
            Paragraph subtotalPara = tRow.Cells[3].AddParagraph();
            subtotalPara.Format.Alignment = ParagraphAlignment.Right;
            subtotalPara.AddText(subtotalVal.ToString("N2"));

            // ---------------------------------------
            // TAX & GRAND TOTAL
            // ---------------------------------------
            // Subtotal
            subtotalVal = qtyVal * priceVal;
            Paragraph sub = section.AddParagraph();
            sub.Format.Alignment = ParagraphAlignment.Right;
            sub.Format.SpaceBefore = "0.5cm";

            // Set a right-aligned tab stop at 6cm from left edge (adjust as needed)
            sub.Format.TabStops.AddTabStop(Unit.FromCentimeter(6), MigraDoc.DocumentObjectModel.TabAlignment.Right);

            sub.AddFormattedText("Subtotal : ", TextFormat.Bold);
            sub.AddText("\t" + subtotalVal.ToString("N2"));

            // ---------------------------------------------
            // TAX SECTION (Only if enabled)
            // ---------------------------------------------
            decimal taxRate = 5;  // your tax %
            decimal taxAmount = 0;

            if (isIncludeTax)
            {
                taxAmount = subtotalVal * (taxRate / 100);


                Paragraph taxP = section.AddParagraph();
                taxP.Format.Alignment = ParagraphAlignment.Right;
                taxP.Format.TabStops.AddTabStop(Unit.FromCentimeter(6), MigraDoc.DocumentObjectModel.TabAlignment.Right);
                taxP.AddFormattedText($"Tax ({taxRate}%) : ", TextFormat.Bold);
                taxP.AddText("\t" + taxAmount.ToString("N2"));
            }
                // ---------------------------------------------
                // GRAND TOTAL
                // ---------------------------------------------
                decimal grandTotal = subtotalVal + taxAmount;

            Paragraph grand = section.AddParagraph();
            grand.Format.Alignment = ParagraphAlignment.Right;
            grand.Format.Font.Size = 12;
            grand.Format.SpaceBefore = "0.3cm";
            grand.Format.TabStops.AddTabStop(Unit.FromCentimeter(6), MigraDoc.DocumentObjectModel.TabAlignment.Right);
            grand.AddFormattedText("GRAND TOTAL : ", TextFormat.Bold);
            grand.AddText("\t" + grandTotal.ToString("N2"));


            // ---------------------------------------
            // RENDER & SAVE PDF
            // ---------------------------------------
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Quotation";
                saveFile.FileName = "Quotation.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveFile.FileName);
                    Process.Start("explorer.exe", saveFile.FileName);
                }
            }
        }

        //private void GenerateQuotation(string clientName, string clientAddress, string clientContact, string clientItemUnitPrice)
        //{
        //    string companyName = lblCompany.Text;

        //    // Create PDF doc
        //    Document doc = new Document();
        //    Section section = doc.AddSection();

        //    section.PageSetup.TopMargin = Unit.FromCentimeter(1);
        //    section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
        //    section.PageSetup.RightMargin = Unit.FromCentimeter(1);
        //    section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

        //    // HEADER
        //    Table headerTable = section.AddTable();
        //    headerTable.Borders.Width = 0;
        //    headerTable.AddColumn("10cm");
        //    headerTable.AddColumn("10cm");

        //    Row headerRow = headerTable.AddRow();

        //    // Left: Company Info
        //    Paragraph left = headerRow.Cells[0].AddParagraph();
        //    left.Format.Font.Name = "Times New Roman";
        //    left.Format.Font.Size = 10;
        //    left.Format.Alignment = ParagraphAlignment.Left;
        //    left.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);

        //    // Right: Client Info
        //    Paragraph right = headerRow.Cells[1].AddParagraph();
        //    right.Format.Font.Name = "Times New Roman";
        //    right.Format.Font.Size = 10;
        //    right.Format.Alignment = ParagraphAlignment.Left;
        //    right.AddFormattedText("Quotation For:\n", TextFormat.Bold);
        //    right.AddText(clientName + "\n");
        //    right.AddText(clientAddress + "\n");
        //    right.AddText("Contact: " + clientContact + "\n");

        //    // Separator Line
        //    Paragraph line = section.AddParagraph();
        //    line.Format.Borders.Bottom.Width = 2;
        //    line.Format.SpaceAfter = "0.5cm";

        //    var row = dgvSales.CurrentRow;   // or dgvSales.SelectedRows[0]

        //    if (row == null || row.IsNewRow || !row.Visible)
        //        return;

        //    // get brand
        //    string brand = row.Cells["Variant"].Value?.ToString() ?? "Unknown";

        //    // Brand Header
        //    Paragraph brandPara = section.AddParagraph();
        //    brandPara.AddFormattedText("Brand: " + brand + "\n", TextFormat.Bold);
        //    brandPara.Format.Font.Size = 11;
        //    brandPara.Format.SpaceBefore = "0.2cm";
        //    brandPara.Format.SpaceAfter = "0.2cm";

        //    // Create table
        //    Table table = section.AddTable();
        //    table.Borders.Width = 0.75;
        //    table.Format.Font.Name = "Times New Roman";
        //    table.Format.Font.Size = 10;

        //    table.AddColumn("10cm");  // Item Name
        //    table.AddColumn("3cm");  // Quantity
        //    table.AddColumn("3cm");  // Unit Price
        //    table.AddColumn("3cm");  // Total Price

        //    // Header Row
        //    Row head = table.AddRow();
        //    head.Shading.Color = Colors.LightGray;
        //    head.Format.Font.Bold = true;
        //    head.Cells[0].AddParagraph("Item Name");
        //    head.Cells[1].AddParagraph("Quantity");
        //    head.Cells[2].AddParagraph("Unit Price");
        //    head.Cells[3].AddParagraph("Total Price");

        //    // Data Row
        //    Row tRow = table.AddRow();
        //    tRow.Cells[0].AddParagraph(row.Cells["ItemName"].Value?.ToString() ?? "");

        //    decimal qtyVal, priceVal, totalVal;

        //    // Quantity
        //    Paragraph qtyPara = tRow.Cells[1].AddParagraph();
        //    qtyPara.Format.Alignment = ParagraphAlignment.Right;
        //    qtyPara.AddText(decimal.TryParse(row.Cells["Qty"].Value?.ToString(), out qtyVal)
        //        ? qtyVal.ToString("N2") : "");

        //    // Unit Price
        //    Paragraph unitPricePara = tRow.Cells[2].AddParagraph();
        //    unitPricePara.Format.Alignment = ParagraphAlignment.Right;
        //    unitPricePara.AddText(decimal.TryParse(clientItemUnitPrice, out priceVal)
        //        ? priceVal.ToString("N2") : "");

        //    // Total Price
        //    Paragraph totalPricePara = tRow.Cells[3].AddParagraph();
        //    totalPricePara.Format.Alignment = ParagraphAlignment.Right;
        //    totalVal = qtyVal * priceVal;
        //    totalPricePara.AddText(totalVal.ToString("N2"));

        //    // Group by Brand
        //    //var brands = dgvSales.Rows.Cast<DataGridViewRow>()
        //    //                    .Where(r => !r.IsNewRow && r.Visible)
        //    //                    .GroupBy(r => r.Cells["Variant"].Value?.ToString() ?? "Unknown");

        //    //foreach (var brandGroup in brands)
        //    //{
        //    //    // Brand Header
        //    //    Paragraph brandPara = section.AddParagraph();
        //    //    brandPara.AddFormattedText("Brand: " + brandGroup.Key + "\n", TextFormat.Bold);
        //    //    brandPara.Format.Font.Size = 11;
        //    //    brandPara.Format.SpaceBefore = "0.2cm";
        //    //    brandPara.Format.SpaceAfter = "0.2cm";

        //    //    // Table for items
        //    //    Table table = section.AddTable();
        //    //    table.Borders.Width = 0.75;
        //    //    table.Format.Font.Name = "Times New Roman";
        //    //    table.Format.Font.Size = 10;

        //    //    table.AddColumn("12cm"); // Item Name
        //    //    table.AddColumn("3cm");  // Quantity
        //    //    table.AddColumn("3cm");  // Unit Price
        //    //    table.AddColumn("3cm");  // Total Price

        //    //    // Header Row
        //    //    Row head = table.AddRow();
        //    //    head.Shading.Color = Colors.LightGray;
        //    //    head.Format.Font.Bold = true;
        //    //    head.Cells[0].AddParagraph("Item Name");
        //    //    head.Cells[1].AddParagraph("Quantity");
        //    //    head.Cells[2].AddParagraph("Unit Price");
        //    //    head.Cells[3].AddParagraph("Total Price");

        //    //    // Data Rows
        //    //    foreach (DataGridViewRow row in brandGroup)
        //    //    {
        //    //        Row tRow = table.AddRow();
        //    //        tRow.Cells[0].AddParagraph(row.Cells["ItemName"].Value?.ToString() ?? "");

        //    //        decimal qtyVal, priceVal, totalVal;
        //    //        Paragraph qtyPara = tRow.Cells[1].AddParagraph();
        //    //        qtyPara.Format.Alignment = ParagraphAlignment.Right;
        //    //        qtyPara.AddText(decimal.TryParse(row.Cells["Qty"].Value?.ToString(), out qtyVal)
        //    //            ? qtyVal.ToString("N2") : "");
        //    //        // Placeholder for Unit Price and Total Price
        //    //        Paragraph unitPricePara = tRow.Cells[2].AddParagraph();
        //    //        unitPricePara.Format.Alignment = ParagraphAlignment.Right;
        //    //        unitPricePara.AddText(decimal.TryParse(clientItemUnitPrice, out priceVal)
        //    //            ? priceVal.ToString("N2") : "");
        //    //        // total price
        //    //        Paragraph totalPricePara = tRow.Cells[3].AddParagraph();
        //    //        totalPricePara.Format.Alignment = ParagraphAlignment.Right;
        //    //        totalVal = qtyVal * priceVal;
        //    //        totalPricePara.AddText(totalVal.ToString("N2"));

        //    //    }
        //    //}

        //    // Render PDF
        //    PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
        //    renderer.Document = doc;
        //    renderer.RenderDocument();

        //    // Save file
        //    using (SaveFileDialog saveFile = new SaveFileDialog())
        //    {
        //        saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
        //        saveFile.Title = "Save Quotation";
        //        saveFile.FileName = "Quotation.pdf";

        //        if (saveFile.ShowDialog() == DialogResult.OK)
        //        {
        //            renderer.PdfDocument.Save(saveFile.FileName);
        //            Process.Start("explorer.exe", saveFile.FileName);
        //        }
        //    }
        //}

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string companyName = lblCompany.Text;

            // Create PDF doc
            Document doc = new Document();
            Section section = doc.AddSection();

            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // HEADER
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");
            headerTable.AddColumn("8cm");
            headerTable.AddColumn("5cm");

            Row headerRow = headerTable.AddRow();

            // Left: Date & time
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center: Title
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;

            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText titleText = center.AddFormattedText("PACKING REPORT\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText subTitle = center.AddFormattedText("All Packing Transactions", TextFormat.NotBold);
            subTitle.Font.Size = 9;

            // Separator Line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // MAIN TABLE
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Columns for Packing Report
            table.AddColumn("3.0cm"); // Item Name
            table.AddColumn("2.0cm"); // Batch No
            table.AddColumn("2.5cm"); // Variant
            table.AddColumn("2.0cm"); // Qty
            table.AddColumn("2.5cm"); // Packed On
            table.AddColumn("2.0cm"); // Rack
            table.AddColumn("3.0cm"); // Warehouse

            // Header Row
            Row head = table.AddRow();
            head.Shading.Color = Colors.LightGray;
            head.Format.Font.Bold = true;

            string[] headers =
            {
                "Item Name", "Batch No", "Variant", "Qty",
                "Packed On", "Rack No", "Warehouse"
            };

            for (int i = 0; i < headers.Length; i++)
                head.Cells[i].AddParagraph(headers[i]);

            // Data Rows from DataGridView
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow || !row.Visible) continue;

                Row tRow = table.AddRow();

                tRow.Cells[0].AddParagraph(row.Cells["ItemName"].Value?.ToString() ?? "");
                tRow.Cells[1].AddParagraph(row.Cells["Batch"].Value?.ToString() ?? "");
                tRow.Cells[2].AddParagraph(row.Cells["Variant"].Value?.ToString() ?? "");

                // Qty numeric right aligned
                decimal qtyVal;
                tRow.Cells[3].AddParagraph(decimal.TryParse(row.Cells["Qty"].Value?.ToString(), out qtyVal)
                    ? qtyVal.ToString("N2") : "").Format.Alignment = ParagraphAlignment.Right;

                tRow.Cells[4].AddParagraph(Convert.ToDateTime(row.Cells["PackedOn"].Value).ToString("dd/MM/yyyy"));
                tRow.Cells[5].AddParagraph(row.Cells["Rack"].Value?.ToString() ?? "");
                tRow.Cells[6].AddParagraph(row.Cells["Warehouse"].Value?.ToString() ?? "");
            }

            // Render PDF
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            // Save file dialog
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Packing Report";
                saveFile.FileName = "PackingReport.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveFile.FileName);
                    Process.Start("explorer.exe", saveFile.FileName);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Packing Report";
                saveDialog.FileName = "PackingReport.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Packing Report";

                    // ================================
                    // HEADER (Date and time)
                    // ================================

                    Excel.Range headerRange0 = worksheet.Range["B1", "E1"];
                    headerRange0.Merge();
                    headerRange0.Value = lblCompany.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["B2", "E2"];
                    headerRange1.Merge();
                    headerRange1.Value = guna2HtmlLabel7.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["B3", "E3"];
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
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    int rowIndex = 5;

                    // ================================
                    // COLUMN HEADERS
                    // ================================

                    // Column headers
                    string[] headers =
                    {
                        "Item Name", "Batch No", "Variant", "Qty",
                        "Packed On", "Rack", "Warehouse"
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[rowIndex, i + 1] = headers[i];
                        var cell = worksheet.Cells[rowIndex, i + 1];
                        cell.Font.Bold = true;
                        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        cell.Font.Name = "Times New Roman";
                        cell.Font.Size = 10;
                    }
                    rowIndex++;

                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow || !row.Visible) continue;

                        string itemName = row.Cells["ItemName"].Value?.ToString() ?? "";
                        string batch = row.Cells["Batch"].Value?.ToString() ?? "";
                        string variant = row.Cells["Variant"].Value?.ToString() ?? "";

                        string qty = FormatNumber(row.Cells["Qty"].Value);

                        string packedOn = "";
                        if (DateTime.TryParse(row.Cells["PackedOn"].Value?.ToString(), out DateTime d))
                            packedOn = d.ToString("dd/MM/yyyy");

                        string rack = row.Cells["Rack"].Value?.ToString() ?? "";
                        string warehouse = row.Cells["Warehouse"].Value?.ToString() ?? "";

                        worksheet.Cells[rowIndex, 1] = itemName;
                        worksheet.Cells[rowIndex, 2] = batch;
                        worksheet.Cells[rowIndex, 3] = variant;
                        worksheet.Cells[rowIndex, 4] = qty;
                        worksheet.Cells[rowIndex, 5] = packedOn;
                        worksheet.Cells[rowIndex, 6] = rack;
                        worksheet.Cells[rowIndex, 7] = warehouse;

                        // Align right for Qty column
                        var qtyCell = worksheet.Cells[rowIndex, 4];
                        qtyCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                        for (int col = 1; col <= 8; col++)
                        {
                            var cell = worksheet.Cells[rowIndex, col];
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 9;
                        }

                        rowIndex++;
                    }

                    worksheet.Columns.AutoFit();
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Packing Report exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string FormatNumber(object val)
        {
            decimal result;
            return decimal.TryParse(Convert.ToString(val), out result) ? result.ToString("N2") : "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dtpFrom, dtpTo);
                LoadData();
            }
        }
    }
    public partial class ChooseInfoForm : Form
    {
        TextBox textBox1, textBox2, textBox3, textBox4;
        Label lbl1, lbl2, lbl3, lbl4;
        Button btnOK, btnCancel;
        CheckBox chkIncludeTax;

        public string ClientNameValue { get; set; }
        public string ClientAddressValue { get; set; }
        public string ClientContactValue { get; set; }
        public string ClientItemUnitPrice { get; set; }
        public bool IncludeTax { get; set; }

        public ChooseInfoForm(string clientName, string clientAddress, string clientContact)
        {
            CreateControls();

            textBox1.Text = clientName;
            textBox2.Text = clientAddress;
            textBox3.Text = clientContact;
            chkIncludeTax.Checked = true;
        }

        private void CreateControls()
        {
            this.Width = 450;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterParent;

            lbl1 = new Label { Left = 10, Top = 10, Text = "Client Name" };
            textBox1 = new TextBox { Left = 110, Top = 10, Width = 300 };
            lbl2 = new Label { Left = 10, Top = 40, Text = "Client Address" };
            textBox2 = new TextBox { Left = 110, Top = 40, Width = 300 };
            lbl3 = new Label { Left = 10, Top = 70, Text = "Client Contact" };
            textBox3 = new TextBox { Left = 110, Top = 70, Width = 300 };
            lbl4 = new Label { Left = 10, Top = 100, Text = "Client Item Unit Price" };
            textBox4 = new TextBox { Left = 110, Top = 100, Width = 300 };
            chkIncludeTax = new CheckBox { Left = 110, Top = 130, Text = "Include Tax (5%)" };
            btnOK = new Button { Left = 20, Top = 200, Text = "OK" };
            btnCancel = new Button { Left = 120, Top = 200, Text = "Cancel" };

            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;

            Controls.Add(lbl1);
            Controls.Add(textBox1);
            Controls.Add(lbl2);
            Controls.Add(textBox2);
            Controls.Add(lbl3);
            Controls.Add(textBox3);
            Controls.Add(lbl4);
            Controls.Add(textBox4);
            Controls.Add(chkIncludeTax);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClientNameValue = textBox1.Text;
            ClientAddressValue = textBox2.Text;
            ClientContactValue = textBox3.Text;
            ClientItemUnitPrice = textBox4.Text;
            IncludeTax = chkIncludeTax.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}