using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class CompletedJobCardsReport : Form
    {
        int id;
        public CompletedJobCardsReport(int _id=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }

        private void CompletedJobCardsReport_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ▼";
            LoadData();
            DateTime dated = DateTime.Now;
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:tt");
            loadCompany();
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

            if (dgvSales.Columns.Count == 0)
            {
                dgvSales.Columns.Add("SN", "SN");
                dgvSales.Columns.Add("id", "");
                dgvSales.Columns.Add("Code", "Code");
                dgvSales.Columns.Add("Date", "Date");
                dgvSales.Columns.Add("Customer", "Customer");
                dgvSales.Columns.Add("Vehicle", "Vehicle");
                dgvSales.Columns.Add("make", "Make");
                dgvSales.Columns.Add("model", "Model");
                dgvSales.Columns.Add("complaint", "Complaint");
                dgvSales.Columns.Add("estimated_amount", "Estimated Amount");
                LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);

                dgvSales.Columns["estimated_amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSales.Columns["Customer"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSales.Columns["id"].Visible = false;
                dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Bold);
                dgvSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvSales.EnableHeadersVisualStyles = false;
                dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvSales.GridColor = System.Drawing.Color.LightGray;
                dgvSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dgvSales.RowHeadersVisible = false;
            }

            decimal totalAmount = 0;

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                DBClass.CreateParameter("@id", id)
            };

            string dateFilter = "";
            if (!chkDate.Checked)
            {
                dateFilter = " AND jc.job_date BETWEEN @dateFrom AND @dateTo ";
                parameters.Add(DBClass.CreateParameter("@dateFrom", dtpFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)));
            }

            string query = $@"
                            SELECT
                                ROW_NUMBER() OVER(ORDER BY jc.job_date) AS SN,
                                jc.id,
                                jc.code,
                                jc.job_date,
                                c.name AS Customer,
                                v.plate_no AS Vehicle,
                                jc.expected_delivery,
                                jc.approved_amount
                            FROM tbl_job_card jc
                            INNER JOIN tbl_customer c ON c.id=jc.customer_id
                            INNER JOIN tbl_vehicle v ON v.id=jc.vehicle_id
                            WHERE jc.state=1
                            AND jc.status='Completed'

                                {dateFilter}
                            ORDER BY jc.job_date;
                        ";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters.ToArray()))
            {
                while (reader.Read())
                {
                    decimal amount = Convert.ToDecimal(reader["approved_amount"]);

                    int rowIndex = dgvSales.Rows.Add(
                        reader["SN"].ToString(),
                        reader["id"].ToString(),
                        reader["code"].ToString(),
                        Convert.ToDateTime(reader["job_date"]).ToString("dd/MM/yyyy"),
                        reader["Customer"].ToString(),
                        reader["Vehicle"].ToString(),
                        reader["expected_delivery"].ToString(),
                        amount.ToString("N2")
                    );

                    dgvSales.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvSales.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Regular);

                    totalAmount += amount;
                }
            }

            //Add total row
            int totalRow = dgvSales.Rows.Add("", "", "", "", "TOTAL", "", "", totalAmount.ToString("N2"));
            dgvSales.Rows[totalRow].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Bold | FontStyle.Underline);
            dgvSales.Rows[totalRow].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            dgvSales.Rows[totalRow].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.Rows[totalRow].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSales.Rows[totalRow].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //if (dgvSales.Rows[e.RowIndex].Cells["id"].Value != null)
                //{
                //    int _id = int.Parse(dgvSales.Rows[e.RowIndex].Cells["id"].Value.ToString());
                //    var _type = dgvSales.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                //    if (_type == "Employee Loan Payment" || _type == "Employee Salary Payment" || _type == "Employee Petty Cash Payment")
                //    {
                //        //frmLogin.frmMain.openChildForm(new frmViewPaymentVoucher(_id,id));
                //    }

                //}
            }
        }

        private void dgvSales_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            ////if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            ////{
            ////    var cell = dgvSales.Rows[e.RowIndex].Cells[e.ColumnIndex];
            ////    string tooltipText = $"Type: {dgvSales.Rows[e.RowIndex].Cells["Type"].Value?.ToString()}";

            ////    ToolTip tip = new ToolTip();
            ////    tip.Show(tooltipText, dgvSales, dgvSales.PointToClient(Cursor.Position), 2000);
            ////}
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            //Get company name from DB
            string companyName = guna2HtmlLabel8.Text;

            // Create PDF document
            Document doc = new Document();
            Section section = doc.AddSection();
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Header Table (Time/Date + Company Info)
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");
            headerTable.AddColumn("8cm");
            headerTable.AddColumn("5cm");

            Row headerRow = headerTable.AddRow();

            // Left cell - Time and Date
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            left.AddText("Time: " + DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText("Date: " + DateTime.Now.ToString("dd/MM/yyyy"));

            // Center cell - Company Info
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold).Font.Size = 12;
            center.AddFormattedText("Completed Job Card \n", TextFormat.Bold).Font.Size = 10;
            center.AddFormattedText("All Transactions", TextFormat.NotBold).Font.Size = 9;

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Bold black line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Create table for report data
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0.5;
            dataTable.Format.Font.Name = "Times New Roman";
            //Columns from the DataGridView to the PDF table
            dataTable.AddColumn("1.5cm"); // SN
            dataTable.AddColumn("2.5cm"); // Code
            dataTable.AddColumn("2.5cm"); // Date
            dataTable.AddColumn("3.5cm"); // Customer
            dataTable.AddColumn("3.5cm"); // Vehicle
            dataTable.AddColumn("2.5cm"); // Expected Delivery
            dataTable.AddColumn("3.0cm"); // Approved Amount

            // Header row
            Row header = dataTable.AddRow();
            string[] headers = { "SN", "Code", "Date", "Customer", "Vehicle", "Expected Delivery", "Approved Amount" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = header.Cells[i];
                cell.AddParagraph(headers[i]);
                cell.Format.Font.Bold = true;
                cell.Format.Font.Size = 9;
                cell.Borders.Bottom.Width = 0.5;
                cell.Format.Alignment = (i >= 4) ? ParagraphAlignment.Right : ParagraphAlignment.Left;
            }

            // Data rows
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                string sn = row.Cells["SN"]?.Value?.ToString() ?? "";
                string code = row.Cells["Code"]?.Value?.ToString() ?? "";
                string date = row.Cells["Date"]?.Value?.ToString() ?? "";
                string customer = row.Cells["Customer"]?.Value?.ToString() ?? "";
                string vehicle = row.Cells["Vehicle"]?.Value?.ToString() ?? "";
                string expectedDelivery = row.Cells["expected_delivery"]?.Value?.ToString() ?? "";
                string amountStr = row.Cells["approved_amount"]?.Value?.ToString() ?? "";

                Row dataRow = dataTable.AddRow();

                decimal amt;
                decimal.TryParse(amountStr, out amt);
                totalAmount += amt;
            }

            // Total row
            Row totalRow = dataTable.AddRow();
            totalRow.Cells[0].MergeRight = 7; // Merge first 8 cells for "TOTAL" label
            totalRow.Cells[0].AddParagraph("TOTAL").Format.Font.Bold = true;
            Paragraph totalAmountCell = totalRow.Cells[8].AddParagraph(totalAmount.ToString("N2"));
            totalAmountCell.Format.Font.Bold = true;
            totalAmountCell.Format.Font.Underline = Underline.Single;
            totalRow.Cells[8].Format.Alignment = ParagraphAlignment.Right;

            // Export
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Save PDF";
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FileName = "CompletedJobCards.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveDialog.FileName);
                    Process.Start("explorer.exe", saveDialog.FileName);
                }
            }
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "CompletedJobCards.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "CompletedJobCards";

                    // Merge and format header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "G1"];
                    headerRange.Merge();
                    headerRange.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    // Adding Column Headers
                    worksheet.Cells[2, 1] = "SN";
                    worksheet.Cells[2, 2] = "Code";
                    worksheet.Cells[2, 3] = "Date";
                    worksheet.Cells[2, 4] = "Customer";
                    worksheet.Cells[2, 5] = "Vehicle";
                    worksheet.Cells[2, 6] = "Expected Delivery";
                    worksheet.Cells[2, 7] = "Approved Amount";

                    int rowIndex = 3;
                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string sn = row.Cells["SN"].Value?.ToString();
                        string code = row.Cells["Code"].Value?.ToString();
                        string date = row.Cells["Date"].Value?.ToString();
                        string customer = row.Cells["Customer"].Value?.ToString();
                        string vehicle = row.Cells["Vehicle"].Value?.ToString();
                        string expectedDelivery = row.Cells["expected_delivery"].Value?.ToString();
                        string amount = row.Cells["approved_amount"].Value?.ToString();

                        worksheet.Cells[rowIndex, 1] = sn;
                        worksheet.Cells[rowIndex, 2] = code;
                        worksheet.Cells[rowIndex, 3] = date;
                        worksheet.Cells[rowIndex, 4] = customer;
                        worksheet.Cells[rowIndex, 5] = vehicle;
                        worksheet.Cells[rowIndex, 6] = expectedDelivery;
                        worksheet.Cells[rowIndex, 7] = amount;

                        // Formatting the cells
                        var accountCell = worksheet.Cells[rowIndex, 4];
                        var amountCell = worksheet.Cells[rowIndex, 7];
                        accountCell.Font.Name = "Times New Roman";
                        amountCell.Font.Name = "Times New Roman";

                        // If account contains 'TOTAL', apply special formatting
                        if (customer.ToUpper().Contains("TOTAL"))
                        {
                            accountCell.Font.Size = 10;
                            accountCell.Font.Bold = true;

                            amountCell.Font.Size = 10;
                            amountCell.Font.Bold = true;
                            amountCell.Font.Underline = Microsoft.Office.Interop.Excel.XlUnderlineStyle.xlUnderlineStyleDouble;
                        }
                        else
                        {
                            accountCell.Font.Size = 10;
                            accountCell.Font.Bold = true;

                            amountCell.Font.Size = 9;
                        }

                        amountCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                        rowIndex++;
                    }
                    worksheet.Columns.AutoFit();

                    // Save the workbook and close
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CompletedJobCardsReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            //dgvSales.CellMouseEnter -= dgvSales_CellMouseEnter;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = !chkDate.Checked;
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
}
