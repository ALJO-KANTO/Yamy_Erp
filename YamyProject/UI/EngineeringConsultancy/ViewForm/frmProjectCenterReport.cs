using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmProjectCenterReport : Form
    {
        public frmProjectCenterReport()
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProjectCenterReport_Load(object sender, EventArgs e)
        {
            LoadClassification();
            LoadProjects();
            UpdateSummary();
            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);
        }

        #region Load Data

        private void LoadClassification()
        {
            cmbClassification.DataSource = DBClass.ExecuteDataTable("Select 0 id,'' name_ar,'' as name_en UNION SELECT id,name_ar,name_en FROM tbl_project_Classification");
            cmbClassification.ValueMember = "id";
            string savedCulture = Properties.Settings.Default.ApplicationLanguage ?? "en";
            if (savedCulture == "ar")
                cmbClassification.DisplayMember = "name_ar";
            else
                cmbClassification.DisplayMember = "name_en";

            cmbClassification.SelectedIndex = -1;
        }

        private void LoadProjects()
        {
            string savedCulture = Properties.Settings.Default.ApplicationLanguage ?? "en";

            string search = txtSearch.Text.Trim();
            string classification = cmbClassification.Text;
            int starred = chkStarred.Checked ? 1 : 0;

            string query = @"SELECT 
                p.id,
                p.code `Code`,
                p.name `Name`,
                p.owner_name `Owner`,
                p.plot_number `Plot`,
                p.basin_number `Basin`,
                p.municipality_project_no as `Municipality Project No`,
                p.bank_project_no as `Bank Project No`,";

            if (savedCulture == "ar")
            {
                query += "ifnull((SELECT name_ar from tbl_project_Classification WHERE id = p.project_Classification),'') `Classification`,";
            }
            else
            {
                query += "ifnull((SELECT name_en from tbl_project_Classification WHERE id = p.project_Classification),'') `Classification`,";
            }
            
            query += @"p.is_starred `Starred`,
                p.priority_color as `Priority Color`,
                p.start_date as `Start Date`,
                p.end_date as `End Date`,
                p.last_progress_update as `Last Progress Update`,
                ps.stage_name as `Current Stage`,
                ph.phase_name AS `Current Phase`,
                ph.phase_color as `Phase Color`,
                IFNULL(DATEDIFF(CURDATE(), COALESCE(p.extend_delay, p.end_date)), 0) AS `Delay (Days)`,
                CASE 
                    WHEN p.last_progress_update IS NULL 
                         OR p.last_progress_update < DATE_SUB(NOW(), INTERVAL 30 DAY)
                    THEN 1 ELSE 0 END AS `Stale`
            FROM tbl_projects p
            LEFT JOIN tbl_project_stages ps 
                ON ps.project_id = p.id AND ps.is_current = 1
            LEFT JOIN tbl_eng_project_phases ph
                ON ph.project_id = p.id AND ph.status = 'In Progress'";

            //@"
            //WHERE
            //    (@search = '' OR
            //     p.owner_name LIKE CONCAT('%', @search, '%') OR
            //     p.plot_number LIKE CONCAT('%', @search, '%') OR
            //     p.basin_number LIKE CONCAT('%', @search, '%') OR
            //     p.municipality_project_no LIKE CONCAT('%', @search, '%') OR
            //     p.bank_project_no LIKE CONCAT('%', @search, '%') OR
            //     p.name LIKE CONCAT('%', @search, '%'))

            //    AND (@classification = 'All' OR p.project_classification = @classification)
            //    AND (@starred = 0 OR p.is_starred = 1)

            //ORDER BY p.is_starred DESC, p.priority_level DESC, p.updated_at DESC"
            if (!string.IsNullOrEmpty(search))
            {
                query += " WHERE (p.owner_name LIKE CONCAT('%', @search, '%') OR " +
                         "p.plot_number LIKE CONCAT('%', @search, '%') OR " +
                         "p.basin_number LIKE CONCAT('%', @search, '%') OR " +
                         "p.municipality_project_no LIKE CONCAT('%', @search, '%') OR " +
                         "p.bank_project_no LIKE CONCAT('%', @search, '%') OR " +
                         "p.name LIKE CONCAT('%', @search, '%'))";
            }
            if (classification != "")
            {
                query += string.IsNullOrEmpty(search) ? " WHERE " : " AND ";
                query += "p.project_classification = (select id from tbl_project_Classification where name_en = @classification OR name_ar = @classification)";
            }
            if (starred == 1)
            {
                query += (string.IsNullOrEmpty(search) && classification == "") ? " WHERE " : " AND ";
                query += "p.is_starred = 1";
            }
            if (!query.Contains("ORDER BY"))
            {
                query += " ORDER BY p.is_starred DESC, p.priority_level DESC, p.updated_at DESC";
            }

            dgvProjects.DataSource = DBClass.ExecuteDataTable(query,
                DBClass.CreateParameter("@search", search),
                DBClass.CreateParameter("@classification", classification),
                DBClass.CreateParameter("@starred", starred)
            );

            FormatGrid();
        }

        #endregion

        #region Grid Formatting

        private void FormatGrid()
        {
            if (dgvProjects.Columns.Count == 0) return;

            dgvProjects.Columns["id"].Visible = false;
            dgvProjects.Columns["Priority Color"].Visible = false;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);

            dgvProjects.ClearSelection();
            dgvProjects.DefaultCellStyle.SelectionBackColor = dgvProjects.DefaultCellStyle.BackColor;
            dgvProjects.DefaultCellStyle.SelectionForeColor = dgvProjects.DefaultCellStyle.ForeColor;
        }

        private void dgvProjects_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProjects.Rows[e.RowIndex];

            int delay = Convert.ToInt32(row.Cells["Delay (Days)"].Value);
            int stale = Convert.ToInt32(row.Cells["Stale"].Value);
            string color = row.Cells["Priority Color"].Value?.ToString();

            //if (delay > 0)
            //    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;

            if (stale == 1)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            else if (color == "Red")
                row.DefaultCellStyle.BackColor = System.Drawing.Color.IndianRed;
            else if (color == "Green")
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            else if (color == "Yellow")
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            else if (color == "Gray")
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
        }

        #endregion

        #region Summary

        private void UpdateSummary()
        {
            if (dgvProjects.Rows.Count == 0)
            {
                lblSummary.Text = "No data";
                return;
            }

            int total = dgvProjects.Rows.Count;

            int delayed = dgvProjects.Rows.Cast<DataGridViewRow>()
                .Count(r => Convert.ToInt32(r.Cells["Delay (Days)"].Value) > 0);

            int stale = dgvProjects.Rows.Cast<DataGridViewRow>()
                .Count(r => Convert.ToInt32(r.Cells["Stale"].Value) == 1);

            lblSummary.Text = $"Total: {total} | Delayed: {delayed} | Stale: {stale}";
        }

        #endregion

        #region Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProjects();
            UpdateSummary();
        }

        #endregion

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