using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmLeaveSalary : Form
    {

        public frmLeaveSalary(int id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;

            DateTime date = DateTime.Now;

            dtpFrom.Value = date.AddYears(-1);
            dtpTo.Value = date;
        }

        private void frmLeaveSalary_Load(object sender, EventArgs e)
        {
            bindLeaveSalary();
            AppTheme.DefaultFont(dgvLeaveSalary);
        }
        private void bindLeaveSalary()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            string dateFilter = "";

            if (!chkDate.Checked)
            {
                dateFilter = " AND date >= @dateFrom AND date <= @dateTo";
                parameters.Add(DBClass.CreateParameter("@dateFrom", dtpFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("@dateTo", dtpTo.Value.Date));
            }
            string query = $@"SELECT 
                                    CODE AS 'Employee Code',
                                    (select e.NAME from tbl_employee e where e.code = tbl_leave_salary.code) AS 'Employee Name',
                                    SUM(leave_days) AS 'Leave Salary Days',
                                    SUM(credit) AS 'Leave Salary Amount',
                                    SUM(debit) / (SUM(credit) / SUM(leave_days)) AS 'L.S Used Days',
                                    SUM(leave_days) - (SUM(debit) / (SUM(credit) / SUM(leave_days))) AS 'L.S Remaining Days',
                                    SUM(debit) AS 'L.S Received Amount',
                                    SUM(credit) - SUM(debit) AS 'L.S Remaining Amount'
                                FROM tbl_leave_salary where id >0 {dateFilter}
                            GROUP BY CODE,name";

            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgvLeaveSalary.DataSource = dt;

            dgvLeaveSalary.Columns["Employee Code"].Width = 100;
            dgvLeaveSalary.Columns["Employee Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLeaveSalary.Columns["Leave Salary Days"].Width = 120;
            dgvLeaveSalary.Columns["Leave Salary Days"].DefaultCellStyle.Format = "N2";
            dgvLeaveSalary.Columns["Leave Salary Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLeaveSalary.Columns["Leave Salary Amount"].DefaultCellStyle.Format = "N2";
            dgvLeaveSalary.Columns["L.S Used Days"].Width = 100;
            dgvLeaveSalary.Columns["L.S Used Days"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLeaveSalary.Columns["L.S Used Days"].DefaultCellStyle.Format = "N2";
            dgvLeaveSalary.Columns["L.S REMAINING DAYS"].Width = 100;
            dgvLeaveSalary.Columns["L.S REMAINING DAYS"].DefaultCellStyle.Format = "N2";
            dgvLeaveSalary.Columns["L.S RECEIVED AMOUNT"].Width = 150;
            dgvLeaveSalary.Columns["L.S RECEIVED AMOUNT"].DefaultCellStyle.Format = "N2";
            dgvLeaveSalary.Columns["L.S REMAINING AMOUNT"].Width = 160;
            dgvLeaveSalary.Columns["L.S REMAINING AMOUNT"].DefaultCellStyle.Format = "N2";
            LocalizationManager.LocalizeDataGridViewHeaders(dgvLeaveSalary);
        }

        private void dgvLeaveSalary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLeaveSalary.Rows.Count != 0)
            {
                frmLogin.frmMain.openChildForm(new frmLeaveSalaryStatement(int.Parse(dgvLeaveSalary.CurrentRow.Cells["Employee Code"].Value.ToString())));
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = !chkDate.Checked; 
            bindLeaveSalary();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            bindLeaveSalary();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            bindLeaveSalary();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "LeaveSalary.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Leave Salary";

                    // Merge and format header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["B1", "E1"];
                    headerRange.Merge();
                    headerRange.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    // Column headers
                    for (int col = 0; col < dgvLeaveSalary.Columns.Count; col++)
                    {
                        worksheet.Cells[2, col + 1] = dgvLeaveSalary.Columns[col].HeaderText;

                        var cell = worksheet.Cells[2, col + 1];
                        cell.Font.Bold = true;
                        cell.Font.Name = "Times New Roman";
                        cell.Font.Size = 10;
                        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }

                    int rowIndex = 3;

                    foreach (DataGridViewRow dgvRow in dgvLeaveSalary.Rows)
                    {
                        if (dgvRow.IsNewRow)
                            continue;

                        for (int col = 0; col < dgvLeaveSalary.Columns.Count; col++)
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
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnPdf_Click(object sender, EventArgs e)
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
            // Adjust page margins to position content to top-left
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Create a header table with 3 columns
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");  // Time/Date
            headerTable.AddColumn("8cm");  // Title Center
            headerTable.AddColumn("5cm");  // Empty for spacing

            Row headerRow = headerTable.AddRow();

            // Left cell - Time & Date (Top-left aligned, Times New Roman)
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            left.Format.SpaceAfter = 0;
            headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            //left.AddFormattedText("Time: ", TextFormat.Bold);
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            //left.AddFormattedText("Date: ", TextFormat.Bold);
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center cell - Company Name & Report Titles
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            center.Format.SpaceAfter = 0;

            // Company name - Bold, size 10
            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText summaryText = center.AddFormattedText("Leave Salary Summary\n", TextFormat.Bold);
            summaryText.Font.Size = 12;

            // "All Transactions" - Regular, size 9
            FormattedText allTransText = center.AddFormattedText("All Transactions", TextFormat.NotBold);
            allTransText.Font.Size = 9;

            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;


            //section.Add(headerTable);

            // Bold line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Table for data
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0;

            List<string> headerText = new List<string>();

            foreach (DataGridViewColumn col in dgvLeaveSalary.Columns)
            {
                dataTable.AddColumn(Unit.FromCentimeter(3));
                headerText.Add(col.HeaderText);
            }

            Row headerRow0 = dataTable.AddRow();

            for (int i = 0; i < headerText.Count; i++)
            {
                headerRow0.Cells[i].AddParagraph(headerText[i]);
            }
            foreach (DataGridViewRow dgvRow in dgvLeaveSalary.Rows)
            {
                if (dgvRow.IsNewRow)
                    continue;

                Row pdfRow = dataTable.AddRow();

                for (int i = 0; i < dgvLeaveSalary.Columns.Count; i++)
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

            // Render and save
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "LeaveSalarySummary.pdf");
            renderer.PdfDocument.Save(filePath);
            Process.Start("explorer.exe", filePath);
        }
    }
}
