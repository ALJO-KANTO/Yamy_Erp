using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmPurchaseByUnpaidDetails : Form
    {
        int id;
        public frmPurchaseByUnpaidDetails(int _id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }

        private void frmPurchaseByUnpaidDetails_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ";
            DateTime dated = DateTime.Now;
            guna2HtmlLabel11.Text = dated.TimeOfDay.ToString();
            guna2HtmlLabel11.Text = dated.Date.ToShortDateString();
            loadCompany();
            LoadData();
        }

        private void loadCompany()
        {
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    guna2HtmlLabel8.Text = reader["name"].ToString();
                }
            }
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
            dgvSales.Rows.Clear();

            // Ensure columns exist
            if (dgvSales.Columns.Count == 0)
            {
                dgvSales.Columns.Add("id", "Id");
                dgvSales.Columns["id"].Visible = false;
                dgvSales.Columns.Add("type", "Type");
                dgvSales.Columns.Add("date", "Date");
                dgvSales.Columns.Add("num", "Num");
                dgvSales.Columns.Add("due_date", "Due Date");
                dgvSales.Columns.Add("Aging", "Aging");
                dgvSales.Columns.Add("open_balance", "Open Balance");
                LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);

                dgvSales.Columns["open_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSales.Columns["open_balance"].DefaultCellStyle.Format = "N2";

                dgvSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Regular);
                dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
                dgvSales.EnableHeadersVisualStyles = false;
                dgvSales.RowHeadersVisible = false;
                dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }


            decimal customerTotal = 0;

            string query = @"SELECT 
                                s.id AS id,
                                'Bill' AS type,
                                s.date,
                                s.invoice_id AS num,
                                s.payment_date,'' Aging, 
	                            s.change
                            FROM 
                                tbl_purchase s
                            JOIN 
                                tbl_vendor c ON s.vendor_id = c.id AND c.`type`='Vendor'
                            WHERE 
                                s.state = 0 AND s.change > 0
                            AND s.date >= @startDate AND s.date<= @endDate
                            ORDER BY 
                                s.date;";

            var parameters = new[]
            {
                DBClass.CreateParameter("@cid", id),
                DBClass.CreateParameter("startDate", dateTimePicker1.Value.Date),
                DBClass.CreateParameter("endDate", dateTimePicker2.Value.Date)
            };

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters))
            {
                while (reader.Read())
                {
                    int refId = Convert.ToInt32(reader["id"]);
                    string type = reader["type"].ToString();
                    string date = Convert.ToDateTime(reader["date"]).ToString("dd/MM/yyyy");
                    string num = reader["num"].ToString();
                    string payment_date = Convert.ToDateTime(reader["payment_date"]).ToString("dd/MM/yyyy");
                    string change = reader["change"].ToString();
                    decimal amount = decimal.Parse(reader["change"].ToString());

                    dgvSales.Rows.Add(
                        refId.ToString(), // id
                        type,
                        date,
                        num,
                        payment_date,
                        "",
                        amount.ToString("N2")
                    );

                    customerTotal += amount;
                }
            }

            // Final TOTAL row
            dgvSales.Rows.Add("0", "Total", "", "", "", "", customerTotal.ToString("N2"));
            dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline);
            dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;

        }
        
        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string name = dgvSales.Rows[e.RowIndex].Cells["name"].Value?.ToString();
                if (string.Equals(name, "TOTAL", StringComparison.OrdinalIgnoreCase))
                    return;
                if (dgvSales.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    int _id = int.Parse(dgvSales.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    var _type = dgvSales.Rows[e.RowIndex].Cells["type"].Value.ToString();
                    if (_type.Contains("Invoice"))
                    {
                        frmLogin.frmMain.openChildForm(new frmPurchase(int.Parse(dgvSales.CurrentRow.Cells["id"].Value.ToString())));
                    }
                    //else if(_type == "Purchase Return Invoice")
                    //{
                    //    frmLogin.frmMain.openChildForm(new frmPurchaseReturn(id));
                    //}
                }
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            string companyName = "Company Name";

            // Get company name from DB
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                if (reader.Read())
                {
                    companyName = reader["name"].ToString();
                }

            // Create PDF document
            Document doc = new Document();
            Section section = doc.AddSection();

            // Page margins
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Header layout
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");
            headerTable.AddColumn("8cm");
            headerTable.AddColumn("5cm");

            Row headerRow = headerTable.AddRow();

            // Left side: Date/Time
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center: Company name + Title
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText titleText = center.AddFormattedText("Purchase By Vendor Details\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText subtitleText = center.AddFormattedText("All Transaction", TextFormat.NotBold);
            subtitleText.Font.Size = 9;

            //section.Add(headerTable); // ✅ Attach header table

            // Bold separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Main table
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0.75;
            dataTable.Format.Font.Name = "Times New Roman";
            dataTable.Format.Font.Size = 9;

            // Define columns (total = 18.5cm)
            dataTable.AddColumn("2.2cm"); // Type
            dataTable.AddColumn("2.2cm"); // Date
            dataTable.AddColumn("2.2cm"); // Num
            dataTable.AddColumn("3.2cm"); // Name
            dataTable.AddColumn("4.0cm"); // Item
            dataTable.AddColumn("1.3cm"); // Qty
            dataTable.AddColumn("2.0cm"); // Sales Price
            dataTable.AddColumn("2.0cm"); // Amount

            // Header row
            Row tableHeader = dataTable.AddRow();
            tableHeader.Shading.Color = Colors.LightGray;
            tableHeader.Format.Font.Bold = true;
            tableHeader.Cells[0].AddParagraph("Type");
            tableHeader.Cells[1].AddParagraph("Date");
            tableHeader.Cells[2].AddParagraph("Num");
            tableHeader.Cells[3].AddParagraph("Name");
            tableHeader.Cells[4].AddParagraph("Item");
            tableHeader.Cells[5].AddParagraph("Qty");
            tableHeader.Cells[6].AddParagraph("Sales Price");
            tableHeader.Cells[7].AddParagraph("Amount");

            decimal totalAmount = 0;

            // Add data rows
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                string type = row.Cells["type"]?.Value?.ToString() ?? "";
                string date = row.Cells["date"]?.Value?.ToString() ?? "";
                string num = row.Cells["num"]?.Value?.ToString() ?? "";
                string name = row.Cells["name"]?.Value?.ToString() ?? "";
                string item = row.Cells["item"]?.Value?.ToString() ?? "";
                string qty = row.Cells["qty"]?.Value?.ToString() ?? "";
                string price = row.Cells["price"]?.Value?.ToString() ?? "";
                string amountStr = row.Cells["amount"]?.Value?.ToString() ?? "0";

                // Avoid printing rows with TOTAL in name (just in case)
                if (name.Trim().ToUpper() == "TOTAL") continue;

                decimal amount;
                decimal.TryParse(amountStr, out amount);
                totalAmount += amount;

                Row tRow = dataTable.AddRow();
                tRow.Cells[0].AddParagraph(type);
                tRow.Cells[1].AddParagraph(date);
                tRow.Cells[2].AddParagraph(num);
                tRow.Cells[3].AddParagraph(name);
                tRow.Cells[4].AddParagraph(item);
                tRow.Cells[5].AddParagraph(qty).Format.Alignment = ParagraphAlignment.Right;
                tRow.Cells[6].AddParagraph(price).Format.Alignment = ParagraphAlignment.Right;
                Paragraph amt = tRow.Cells[7].AddParagraph();
                amt.AddFormattedText(amount.ToString("N2"));
                tRow.Cells[7].Format.Alignment = ParagraphAlignment.Right;
            }

            // Total row (only once)
            Row totalRow = dataTable.AddRow();
            totalRow.Cells[0].MergeRight = 6;
            Paragraph totalLabel = totalRow.Cells[0].AddParagraph("TOTAL");
            totalLabel.Format.Font.Bold = true;

            Paragraph totalVal = totalRow.Cells[7].AddParagraph();
            FormattedText formattedTotal = totalVal.AddFormattedText(totalAmount.ToString("N2"));
            formattedTotal.Font.Bold = true;
            formattedTotal.Font.Underline = Underline.Single;
            totalRow.Cells[7].Format.Alignment = ParagraphAlignment.Right;

            //section.Add(dataTable); // ✅ Attach main table

            // Render PDF
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Sales By Customer Details";
                saveFile.FileName = "PurchaseByVendorDetails.pdf";

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
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "PurchaseByUnpaidDetails.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Purchase By Unpaid Details";

                    Excel.Range headerRange0 = worksheet.Range["C1", "F1"];
                    headerRange0.Merge();
                    headerRange0.Value = guna2HtmlLabel8.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["C2", "F2"];
                    headerRange1.Merge();
                    headerRange1.Value = guna2HtmlLabel7.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["C3", "F3"];
                    headerRange2.Merge();
                    headerRange2.Value = "From " + dateTimePicker1.Text + " - To " + dateTimePicker2.Text;
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["C4", "F4"];
                    headerRange3.Merge();
                    headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange3.Font.Bold = false;
                    headerRange3.Font.Name = "Times New Roman";
                    headerRange3.Font.Size = 9;
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    int rowIndex = 5;

                    // Column headers
                    for (int col = 0; col < dgvSales.Columns.Count; col++)
                    {
                        var column = dgvSales.Columns[col];

                        // Skip hidden columns if needed
                        if (!column.Visible) continue;

                        var headerCell = worksheet.Cells[rowIndex, col];
                        headerCell.Value = column.HeaderText;  // show column header
                        headerCell.Font.Bold = true;
                        headerCell.Font.Name = "Times New Roman";
                        headerCell.Font.Size = 11;
                        headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                    }

                    rowIndex++; // move to next row for data

                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int colIndex = 1; // Excel column index starts at 1

                        foreach (DataGridViewColumn column in dgvSales.Columns)
                        {
                            if (!column.Visible) continue;

                            object value = row.Cells[column.Name].Value;
                            string textValue = value?.ToString() ?? "";

                            // Write value to Excel
                            var cell = worksheet.Cells[rowIndex, colIndex];
                            cell.Value = textValue;

                            // Common font formatting
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 9;

                            // Check if the value is numeric or decimal
                            if (decimal.TryParse(textValue, out _))
                            {
                                // Right-align numeric values
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            else
                            {
                                // Left-align text by default
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }

                            colIndex++;
                        }

                        rowIndex++;
                    }

                    // Auto-fit columns
                    worksheet.Columns.AutoFit();

                    // Save
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dateTimePicker1, dateTimePicker2);
                LoadData();
            }
        }
    }
}
