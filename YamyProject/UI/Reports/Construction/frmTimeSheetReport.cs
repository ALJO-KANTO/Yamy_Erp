using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Orientation = MigraDoc.DocumentObjectModel.Orientation;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmTimeSheetReport : Form
    {
        private string type;
        DateTime dtFrom, dtTo;
        string accountId;

        public frmTimeSheetReport(string _type="", string _accountId = "0", DateTime _dtFrom = default, DateTime _dtTo = default)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            type = _type;
            accountId = _accountId;
            headerUC1.FormText = this.Text;
            this.dtFrom = _dtFrom;
            this.dtTo = _dtTo;
        }
        
        private void frmTimeSheetReport_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel10.Text = "Time Sheet Of " + type;
            if (type == "Labour")
            {
                using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT name,phone FROM tbl_project_resource WHERE id = @id",DBClass.CreateParameter("id", accountId)))
                {
                    if (reader.Read())
                    {
                        labelName.Text = reader["name"].ToString();
                        labelMobile.Text = reader["phone"].ToString();
                    }
                }
            }
            else if (type == "Employee")
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name,phone FROM tbl_employee WHERE id = @id", DBClass.CreateParameter("id", accountId)))
                {
                    if (reader.Read())
                    {
                        labelName.Text = reader["name"].ToString();
                        labelMobile.Text = reader["phone"].ToString();
                    }
                }
            }
            else if (type == "Subcontractor")
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name,main_phone phone FROM tbl_vendor WHERE id = @id", DBClass.CreateParameter("id", accountId)))
                {
                    if (reader.Read())
                    {
                        labelName.Text = reader["name"].ToString();
                        labelMobile.Text = reader["phone"].ToString();
                    }
                }
            }
            BindData();
        }
        public void BindData()
        {
            DataTable dt;
            string query = "";
            if (type == "Employee")
            {
                query = @"
                          SELECT 
                                DATE_FORMAT(t.date, '%m/%d/%Y') AS `Dates`,
                                DAYNAME(t.date) AS `Day`,
                                TIME_FORMAT(t.time_in, '%h:%i %p') AS `Time In`,
                                TIME_FORMAT(t.lunch_start, '%h:%i %p') AS `Lunch Start`,
                                TIME_FORMAT(t.lunch_end, '%h:%i %p') AS `Lunch End`,
                                TIME_FORMAT(t.time_out, '%h:%i %p') AS `Time Out`,
                                TIMESTAMPDIFF(HOUR, t.time_in, t.time_out)
                                    - TIMESTAMPDIFF(HOUR, t.lunch_start, t.lunch_end) AS `Hours Worked`,
                                t.overtime_hours AS `Overtime Hours`
                            FROM tbl_labor_attendance t
                            WHERE t.labor_id = @id
                              AND t.date >= @dateFrom 
                              AND t.date <= @dateTo
                            ORDER BY t.date;
                            ";
            }
            else if (type == "Subcontractor")
            {
                query = @"
                          SELECT 
                                DATE_FORMAT(t.date, '%m/%d/%Y') AS `Dates`,
                                DAYNAME(t.date) AS `Day`,
                                TIME_FORMAT(t.time_in, '%h:%i %p') AS `Time In`,
                                TIME_FORMAT(t.lunch_start, '%h:%i %p') AS `Lunch Start`,
                                TIME_FORMAT(t.lunch_end, '%h:%i %p') AS `Lunch End`,
                                TIME_FORMAT(t.time_out, '%h:%i %p') AS `Time Out`,
                                TIMESTAMPDIFF(HOUR, t.time_in, t.time_out)
                                    - TIMESTAMPDIFF(HOUR, t.lunch_start, t.lunch_end) AS `Hours Worked`,
                                t.overtime_hours AS `Overtime Hours`
                            FROM tbl_labor_attendance t
                            WHERE t.labor_id = @id
                              AND t.date >= @dateFrom 
                              AND t.date <= @dateTo
                            ORDER BY t.date;
                            ";
            }
            else
            {
                query = @"
                          SELECT 
                                DATE_FORMAT(t.date, '%m/%d/%Y') AS `Dates`,
                                DAYNAME(t.date) AS `Day`,
                                TIME_FORMAT(t.time_in, '%h:%i %p') AS `Time In`,
                                TIME_FORMAT(t.lunch_start, '%h:%i %p') AS `Lunch Start`,
                                TIME_FORMAT(t.lunch_end, '%h:%i %p') AS `Lunch End`,
                                TIME_FORMAT(t.time_out, '%h:%i %p') AS `Time Out`,
                                TIMESTAMPDIFF(HOUR, t.time_in, t.time_out)
                                    - TIMESTAMPDIFF(HOUR, t.lunch_start, t.lunch_end) AS `Hours Worked`,
                                t.overtime_hours AS `Overtime Hours`
                            FROM tbl_labor_attendance t
                            WHERE t.labor_id = @id
                              AND t.date >= @dateFrom 
                              AND t.date <= @dateTo
                            ORDER BY t.date;
                            ";
            }
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(DBClass.CreateParameter("id", accountId));
            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Date));

            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgvReport.DataSource = dt;

            // ---- Formatting ----
            foreach (DataGridViewColumn column in dgvReport.Columns)
            {
                if (column.Name == "Hours Worked" || column.Name == "Overtime Hours")
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            // ---- Calculate Totals ----
            decimal totalHours = 0;
            decimal totalOvertime = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Hours Worked"].ToString(), out decimal hw))
                    totalHours += hw;

                if (decimal.TryParse(row["Overtime Hours"].ToString(), out decimal ot))
                    totalOvertime += ot;
            }

            // ---- Add Total Row ----
            DataRow totalRow = dt.NewRow();
            totalRow["Time Out"] = "TOTAL";
            totalRow["Hours Worked"] = totalHours;
            totalRow["Overtime Hours"] = totalOvertime;
            dt.Rows.Add(totalRow);

            // ---- Styling the total blank row ----
            int lastRowIndex = dgvReport.Rows.Count - 1;
            var totalDgvRow = dgvReport.Rows[lastRowIndex];

            totalDgvRow.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9, System.Drawing.FontStyle.Bold);
            totalDgvRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            // ---- Add Total blank Row ----
            totalRow = dt.NewRow();
            totalRow["Time Out"] = DBNull.Value;
            totalRow["Hours Worked"] = DBNull.Value;
            totalRow["Overtime Hours"] = DBNull.Value;
            dt.Rows.Add(totalRow);

            // ---- Styling the total row ----
            lastRowIndex = dgvReport.Rows.Count - 1;
            totalDgvRow = dgvReport.Rows[lastRowIndex];

            totalDgvRow.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9, System.Drawing.FontStyle.Bold);
            totalDgvRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            // ---- Add Total Row ----
            totalRow = dt.NewRow();
            totalRow["Time Out"] = "Total Hours Worked";
            totalRow["Hours Worked"] = totalHours + totalOvertime;
            totalRow["Overtime Hours"] = DBNull.Value;
            dt.Rows.Add(totalRow);

            // ---- Styling the total row ----
            lastRowIndex = dgvReport.Rows.Count - 1;
            totalDgvRow = dgvReport.Rows[lastRowIndex];

            totalDgvRow.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9, System.Drawing.FontStyle.Bold);
            totalDgvRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            // ---- Auto size ----
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Localization
            LocalizationManager.LocalizeDataGridViewHeaders(dgvReport);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
                return;
            //if (dgvItems.Columns["JV NO"].Index == e.ColumnIndex)
            //    _mainForm.openChildForm(new MasterTransactionJournal(_mainForm, dgvItems.CurrentRow.Cells["JV NO"].Value.ToString(), "Sales"));
        }
        private void dgvItems_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvItems_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        
        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvItems.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
            //    bindInvoiceItems();
            //else
            //    dgvItems.DataSource = null;
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                GeneratePDF(dgvReport, "Project Resource");
                MessageBox.Show("PDF generated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No data available to pdf.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GeneratePDF(Guna2DataGridView dgvItems, string title)
        {
            string companyName = "";
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                if (reader.Read())
                    companyName = reader["name"].ToString();

            Document doc = new Document();
            Section section = doc.AddSection();
            int visibleColumnCount = dgvReport.Columns.Cast<DataGridViewColumn>().Count(col => col.Visible);
            section.PageSetup.Orientation = visibleColumnCount > 6 ? Orientation.Landscape : Orientation.Portrait;

            // Page margins
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            // Header
            Paragraph header = section.AddParagraph();
            header.Format.Alignment = ParagraphAlignment.Center;
            header.Format.Font.Size = 12;
            header.Format.Font.Bold = true;
            header.AddText(companyName + Environment.NewLine);
            header.AddFormattedText(title + Environment.NewLine, TextFormat.Bold);
            header.Format.SpaceAfter = "0.5cm";

            // Date/Time
            Paragraph timeInfo = section.AddParagraph();
            timeInfo.Format.Alignment = ParagraphAlignment.Right;
            timeInfo.Format.Font.Size = 9;
            timeInfo.AddText(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
            timeInfo.Format.SpaceAfter = "0.5cm";

            // Table for data
            Table table = section.AddTable();
            table.Borders.Width = 0.5;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Define columns dynamically
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Visible)
                {
                    Column tableCol = table.AddColumn(Unit.FromCentimeter(5)); // Adjust width as needed
                    tableCol.Format.Alignment = ParagraphAlignment.Left;
                }
            }

            // Add table header
            Row headerRow = table.AddRow();
            headerRow.Shading.Color = Colors.LightGray;
            headerRow.Format.Font.Bold = true;

            int visibleColIndex = 0;
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (col.Visible)
                {
                    headerRow.Cells[visibleColIndex].AddParagraph(col.HeaderText);
                    visibleColIndex++;
                }
            }

            // Add rows from DataGridView
            foreach (DataGridViewRow dgvRow in dgvReport.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                Row row = table.AddRow();

                int colIndex = 0;
                foreach (DataGridViewColumn col in dgvReport.Columns)
                {
                    if (col.Visible)
                    {
                        string value = dgvRow.Cells[col.Index].Value?.ToString() ?? "";
                        row.Cells[colIndex].AddParagraph(value);
                        row.Cells[colIndex].Format.Alignment = ParagraphAlignment.Left;
                        colIndex++;
                    }
                }
            }

            // Render and save PDF
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = doc
            };
            renderer.RenderDocument();

            string filename = $"{title.Replace(" ", "_")}Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
            renderer.PdfDocument.Save(filePath);

            // Open file
            Process.Start("explorer.exe", filePath);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                GenerateExcel(dgvReport, "Project Resource");
                MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No data available to excel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcel_Click_1(object sender, EventArgs e)
        {
            GenerateExcel(dgvReport, type + "_Time_Sheet");
        }

        private void GenerateExcel(Guna2DataGridView dgvItems, string title)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                string fileName = $"{title.Replace(" ", "_")}_Report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = fileName;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = title;

                    int totalVisibleCols = dgvReport.Columns.Cast<DataGridViewColumn>().Count(col => col.Visible);

                    // Merge and format header row (Date)
                    Excel.Range headerRange0 = worksheet.Range["A1", "G1"];
                    headerRange0.Merge();
                    headerRange0.Value = lblCompany.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["A2", "G2"];
                    headerRange1.Merge();
                    headerRange1.Value = guna2HtmlLabel7.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["A3", "G3"];
                    headerRange2.Merge();
                    headerRange2.Value = "From " + dtFrom.Date.ToShortDateString() + " - To " + dtTo.Date.ToShortDateString();
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                    headerRange3.Merge();
                    headerRange3.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange3.Font.Bold = false;
                    headerRange3.Font.Name = "Times New Roman";
                    headerRange3.Font.Size = 9;
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    Excel.Range headerRange4 = worksheet.Range["A5", "B5"];
                    headerRange4.Merge();
                    headerRange4.Value = type + " Name : ";
                    headerRange4.Font.Bold = false;
                    headerRange4.Font.Name = "Times New Roman";
                    headerRange4.Font.Size = 9;
                    headerRange4.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    Excel.Range headerRange4_1 = worksheet.Range["C5", "D5"];
                    headerRange4_1.Merge();
                    headerRange4_1.Value = labelName.Text;
                    headerRange4_1.Font.Bold = false;
                    headerRange4_1.Font.Name = "Times New Roman";
                    headerRange4_1.Font.Size = 9;
                    headerRange4_1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    Excel.Range headerRange5 = worksheet.Range["A6", "B6"];
                    headerRange5.Merge();
                    headerRange5.Value = "Mobile No : ";
                    headerRange5.Font.Bold = false;
                    headerRange5.Font.Name = "Times New Roman";
                    headerRange5.Font.Size = 9;
                    headerRange5.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    Excel.Range headerRange5_1 = worksheet.Range["C6", "D6"];
                    headerRange5_1.Merge();
                    headerRange5_1.Value = labelMobile.Text;
                    headerRange5_1.Font.Bold = false;
                    headerRange5_1.Font.Name = "Times New Roman";
                    headerRange5_1.Font.Size = 9;
                    headerRange5_1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    int rowIndex = 7;
                    int colIndex = 1;
                    string[] cols = new string[] { "Date", "Day", "Time In", "Lunch Start", "Lunch End", "Time Out", "Hours Worked", "Overtime Hours" };
                    // Write header row
                    for (int i = 0; i < cols.Length; i++)
                    {
                        worksheet.Cells[rowIndex, i + 1] = cols[i];

                        var headerCell = worksheet.Cells[rowIndex, i + 1];
                        headerCell.Font.Bold = true;
                        headerCell.Font.Name = "Times New Roman";
                        headerCell.Font.Size = 10;
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }

                    rowIndex = rowIndex+1;
                    // Add data rows (from row 3)
                    foreach (DataGridViewRow dgvRow in dgvReport.Rows)
                    {
                        if (dgvRow.IsNewRow) continue;

                        colIndex = 1;
                        foreach (DataGridViewColumn col in dgvReport.Columns)
                        {
                            if (!col.Visible) continue;

                            string value = dgvRow.Cells[col.Index].Value?.ToString() ?? "";
                            var cell = worksheet.Cells[rowIndex, colIndex];
                            cell.Value = value;
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 9;

                            // Optional: Right-align numeric columns (if needed)
                            if (decimal.TryParse(value, out _))
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            else
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                            colIndex++;
                        }

                        rowIndex++;
                    }

                    worksheet.Columns.AutoFit();

                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
