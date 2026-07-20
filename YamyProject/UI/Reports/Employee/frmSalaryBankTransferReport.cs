using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmSalaryBankTransferReport : Form
    {
        int id;
        public frmSalaryBankTransferReport(int _id=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }

        private void frmSalaryBankTransferReport_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ▼";
            
            var EnglishMonths = new CultureInfo("en-US")
                .DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m))
                .ToArray();

            cmbMonths.Items.AddRange(EnglishMonths);

            cmbMonths.SelectedItem = DateTime.Now.ToString("MMMM", new CultureInfo("en-US"));
            cmbMonths.SelectedIndex = -1;

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
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                DBClass.CreateParameter("@id", id)
            };

            string dateFilter = "";
            if (!chkDate.Checked)
            {
                dateFilter = " AND YEAR(s.date) = @year AND MONTH(s.date) = @month";
                if (cmbMonths.SelectedItem == null)
                {
                    cmbMonths.SelectedIndex = 0;
                }
                string selectedMonth = cmbMonths.SelectedItem.ToString();
                int monthNumber = DateTime.ParseExact(selectedMonth.Trim(), "MMMM", new CultureInfo("en-US")).Month;
                parameters.Add(DBClass.CreateParameter("@year", guna2NumericUpDown1.Value));
                parameters.Add(DBClass.CreateParameter("@month", monthNumber));
            }

            string query = $@"
                            SELECT
                                DATE_FORMAT(s.date, '%b-%Y') AS `Salary Month`,
                                p.name AS `Category`,
                                e.code AS Code,
                                e.name AS Name,
                                IFNULL(b.name,'') AS Bank,
                                e.Iban_Number AS `IBAN Number`,
                                e.Bank_account_Number AS `Bank Account Number`,
                                s.net_salary AS `Net Salary`
                            FROM tbl_attendance_salary s
                            INNER JOIN tbl_employee e
                                ON s.emp_code = e.code
                            LEFT JOIN tbl_position p
                                ON e.Position_id = p.id
                            LEFT JOIN tbl_bank b
                                ON e.bank_id = b.id
                            WHERE e.id > 0
                                {dateFilter}
                            ORDER BY
                                p.name,
                                e.name;
                            ";

            dgvSales.DataSource = DBClass.ExecuteDataTable(query, parameters.ToArray());

            dgvSales.Columns["Net Salary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSales.Columns["Net Salary"].DefaultCellStyle.Format = "N2";
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            // Get company name from DB
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
            center.AddFormattedText("Salary Bank Transfer\n", TextFormat.Bold).Font.Size = 10;
            center.AddFormattedText("All Transactions", TextFormat.NotBold).Font.Size = 9;

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            // Bold black line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Table for data
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0;

            List<string> headerText = new List<string>();

            foreach (DataGridViewColumn col in dgvSales.Columns)
            {
                dataTable.AddColumn(Unit.FromCentimeter(3));
                headerText.Add(col.HeaderText);
            }

            Row headerRow0 = dataTable.AddRow();

            for (int i = 0; i < headerText.Count; i++)
            {
                headerRow0.Cells[i].AddParagraph(headerText[i]);
            }
            foreach (DataGridViewRow dgvRow in dgvSales.Rows)
            {
                if (dgvRow.IsNewRow)
                    continue;

                Row pdfRow = dataTable.AddRow();

                for (int i = 0; i < dgvSales.Columns.Count; i++)
                {
                    object value = dgvRow.Cells[i].Value;
                    string text = "";

                    if (value != null && value != DBNull.Value)
                    {
                        if (value is DateTime dt)
                            text = dt.ToString("dd-MM-yyyy");
                        else if (value is decimal dec)
                            text = dec.ToString("N2");
                        else if (value is double dbl)
                            text = dbl.ToString("N2");
                        else
                            text = value.ToString();
                    }

                    pdfRow.Cells[i].AddParagraph(text);
                }
            }

            // Export
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Save PDF";
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FileName = "SalaryBankTransfer.pdf";

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
                saveDialog.FileName = "SalaryBankTransfer.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Salary Bank Transfer";

                    // Merge and format header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "E1"];
                    headerRange.Merge();
                    headerRange.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    // Column headers
                    for (int col = 0; col < dgvSales.Columns.Count; col++)
                    {
                        worksheet.Cells[2, col + 1] = dgvSales.Columns[col].HeaderText;

                        var cell = worksheet.Cells[2, col + 1];
                        cell.Font.Bold = true;
                        cell.Font.Name = "Times New Roman";
                        cell.Font.Size = 10;
                        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }

                    int rowIndex = 3;

                    foreach (DataGridViewRow dgvRow in dgvSales.Rows)
                    {
                        if (dgvRow.IsNewRow)
                            continue;

                        for (int col = 0; col < dgvSales.Columns.Count; col++)
                        {
                            object value = dgvRow.Cells[col].Value;

                            worksheet.Cells[rowIndex, col + 1] = value;

                            var cell = worksheet.Cells[rowIndex, col + 1];
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 10;

                            // Right-align numeric values
                            if (value is int || value is long || value is float ||
                                value is double || value is decimal)
                            {
                                cell.HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            }
                            // Center dates
                            else if (value is DateTime dt)
                            {
                                cell.NumberFormat = "dd-MM-yyyy";
                                cell.HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }
                        }

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

        private void frmSalaryBankTransferReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            //dgvSales.CellMouseEnter -= dgvSales_CellMouseEnter;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            guna2NumericUpDown1.Enabled = cmbMonths.Enabled = !chkDate.Checked;
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

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonths.SelectedItem == null)
                return;

            LoadData();
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSales_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
