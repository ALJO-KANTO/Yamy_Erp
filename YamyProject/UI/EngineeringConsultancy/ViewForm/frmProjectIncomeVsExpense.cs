using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmProjectIncomeVsExpense : Form
    {
        public frmProjectIncomeVsExpense()
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProjectAmountSummery_Load(object sender, EventArgs e)
        {
            LoadTransactions();
            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);
        }
        private void FilterChanged(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            string search = txtSearch.Text.Trim();

            string query = @"
                    SELECT 
                        p.id,
                        MAX(p.code) AS `Code`,
                        MAX(p.name) AS `Name`,
                        MAX(p.owner_name) AS `Owner`,
                        MAX(p.start_date) AS `Start Date`,
                        MAX(p.end_date) AS `End Date`,
                        MAX(p.total_value) AS `Total Value`,
                        IFNULL(SUM(t.debit), 0) AS Income,
                        IFNULL(SUM(t.credit), 0) AS Expense,
                        MAX(IFNULL(p.last_progress_update,'')) AS `Last Progress Update`,
                        MAX(IFNULL(ps.stage_name,'')) AS `Current Stage`,
                        MAX(IFNULL(ph.phase_name,'')) AS `Current Phase`
                    FROM tbl_projects p
                    LEFT JOIN tbl_transaction t ON t.hum_id = p.id
                    LEFT JOIN tbl_project_stages ps ON ps.project_id = p.id
                    LEFT JOIN tbl_eng_project_phases ph ON ph.project_id = p.id
                ";

            // -------- WHERE CONDITIONS --------
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(search))
            {
                conditions.Add(@"(
                    p.owner_name LIKE CONCAT('%', @search, '%') OR
                    p.plot_number LIKE CONCAT('%', @search, '%') OR
                    p.basin_number LIKE CONCAT('%', @search, '%') OR
                    p.municipality_project_no LIKE CONCAT('%', @search, '%') OR
                    p.bank_project_no LIKE CONCAT('%', @search, '%') OR
                    p.name LIKE CONCAT('%', @search, '%')
                )");
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            // -------- GROUP BY --------
            query += " GROUP BY p.id";

            // -------- FILTER (HAVING) --------
            if (rbIncome.Checked)
            {
                query += " HAVING IFNULL(SUM(t.debit),0) > 0";
            }
            else if (rbExpense.Checked)
            {
                query += " HAVING IFNULL(SUM(t.credit),0) > 0";
            }
            // "All" → no HAVING

            // -------- ORDER BY --------
            query += " ORDER BY `Code`, `Name`";

            // -------- EXECUTE --------
            dgvProjects.DataSource = DBClass.ExecuteDataTable(
                query,
                DBClass.CreateParameter("@search", search)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);
        }

        private void dgvProjects_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //var row = dgvProjects.Rows[e.RowIndex];

            //int delay = Convert.ToInt32(row.Cells["Delay (Days)"].Value);
            //int stale = Convert.ToInt32(row.Cells["Stale"].Value);
            //string color = row.Cells["Priority Color"].Value?.ToString();

            //if (delay > 0)
            //    row.DefaultCellStyle.BackColor = Color.LightCoral;

            //else if (stale == 1)
            //    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            //else if (color == "Blue")
            //    row.DefaultCellStyle.BackColor = Color.LightBlue;

            //else if (color == "Green")
            //    row.DefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvProjects.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ──────── 1. Create document ────────
            Document doc = new Document();
            Section section = doc.AddSection();

            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;

            // ──────── 2. Header ────────
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;

            headerTable.AddColumn("5cm");
            headerTable.AddColumn("15cm");

            Row headerRow = headerTable.AddRow();

            // Left: Date & Time
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Size = 9;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n" +
                         DateTime.Now.ToString("dd/MM/yyyy"));

            // Center: Title
            Paragraph centre = headerRow.Cells[1].AddParagraph();
            centre.Format.Alignment = ParagraphAlignment.Center;
            centre.AddFormattedText("Project Report\n", TextFormat.Bold).Font.Size = 14;
            centre.AddFormattedText("Projects Summary").Font.Size = 10;

            // Line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 1.5;
            line.Format.SpaceAfter = "0.5cm";

            // ──────── 3. Table ────────
            Table table = section.AddTable();
            table.Borders.Width = 0.5;

            List<int> visibleColumns = new List<int>();

            // Add columns FIRST
            foreach (DataGridViewColumn dgvCol in dgvProjects.Columns)
            {
                if (dgvCol.Visible)
                {
                    table.AddColumn(Unit.FromCentimeter(3));
                    visibleColumns.Add(dgvCol.Index);
                }
            }

            // ──────── 4. Header Row (ONLY ONE ROW) ────────
            Row header = table.AddRow();
            header.Shading.Color = Colors.LightGray;
            header.Format.Font.Bold = true;

            for (int i = 0; i < visibleColumns.Count; i++)
            {
                var dgvCol = dgvProjects.Columns[visibleColumns[i]];
                header.Cells[i].AddParagraph(dgvCol.HeaderText);
                header.Cells[i].Format.Alignment = ParagraphAlignment.Center;
            }

            // ──────── 5. Data Rows ────────
            foreach (DataGridViewRow dgvRow in dgvProjects.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                Row row = table.AddRow();

                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    var cellValue = dgvRow.Cells[visibleColumns[i]].Value?.ToString() ?? "";
                    row.Cells[i].AddParagraph(cellValue);
                }
            }

            // ──────── 6. Render PDF ────────
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "ProjectReport.pdf");

            renderer.PdfDocument.Save(path);

            Process.Start(new ProcessStartInfo()
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvProjects.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "ProjectReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = false;

                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Project Report";

                // ===== Get visible columns =====
                List<DataGridViewColumn> visibleCols = dgvProjects.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .ToList();

                int colCount = visibleCols.Count;

                // ===== Header Title =====
                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[1, 1],
                    worksheet.Cells[1, colCount]
                ];

                headerRange.Merge();
                headerRange.Value = "Project Report - " + DateTime.Now.ToString("dd MMM yyyy");
                headerRange.Font.Bold = true;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.Size = 14;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ===== Column Headers =====
                for (int i = 0; i < colCount; i++)
                {
                    worksheet.Cells[2, i + 1] = visibleCols[i].HeaderText;

                    Excel.Range cell = worksheet.Cells[2, i + 1];
                    cell.Font.Bold = true;
                    cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                // ===== Data Rows =====
                int rowIndex = 3;

                foreach (DataGridViewRow dgvRow in dgvProjects.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    for (int i = 0; i < colCount; i++)
                    {
                        var value = dgvRow.Cells[visibleCols[i].Index].Value;
                        worksheet.Cells[rowIndex, i + 1] = value?.ToString() ?? "";
                    }

                    rowIndex++;
                }

                // ===== Formatting =====
                Excel.Range usedRange = worksheet.Range[
                    worksheet.Cells[2, 1],
                    worksheet.Cells[rowIndex - 1, colCount]
                ];

                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                // ===== Save =====
                workbook.SaveAs(saveDialog.FileName);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Excel exported successfully!",
                                "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                // ===== Clean COM objects (IMPORTANT) =====
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                worksheet = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}