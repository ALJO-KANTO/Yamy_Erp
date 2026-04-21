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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using YamyProject.UI.Project_Management;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class MasterProject : Form
    {
        private EventHandler projectUpdatedHandler;
        int classificationId = 0;
        public MasterProject(int _classificationId = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectUpdatedHandler  = (sender, args) => ProjectData();
            EventHub.Project += projectUpdatedHandler;
            this.Text = "Project Center";
            headerUC1.FormText = this.Text;
            this.classificationId = _classificationId;
        }
        private void MasterProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Project -= projectUpdatedHandler;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //new frmAddProject(this, 0).ShowDialog();
            frmLogin.frmMain.openChildForm(new frmProjectsManage());
        }
        private void MasterProject_Load(object sender, EventArgs e)
        {
            ProjectData();
        }
        public void ProjectData()
        {
            string query = @"SELECT 
                    ROW_NUMBER() OVER (ORDER BY p.id) AS SN,
                    p.id,
                    p.Code,
                    p.owner_name AS `Owner name`,
                    p.part_no AS `Part No`,
                    p.basin_number AS `Basin No`,
                    p.municipality_project_no AS `Municipality Project No`,
                    p.bank_project_no AS `Bank Project No`,
                    p.details AS `Description of the Project`,
                    DATEDIFF(p.end_date, p.start_date) AS `Implementation Period`,
                    p.total_value AS `Total Amount`,
                    p.Status,
                    p.start_date AS `Start Date`,
                    p.end_date AS `End Date`,
                    IFNULL(p.last_progress_update,'') AS `Updated On`,
                    c.name_en,
                    c.name_ar
                    FROM tbl_projects p
                    LEFT JOIN tbl_project_classification c 
                    ON c.id = p.project_classification";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            string condition = "";

            if (classificationId > 0)
            {
                condition += " WHERE p.project_classification = @classificationId";
                parameters.Add(DBClass.CreateParameter("@classificationId", classificationId));
            }

            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                if (condition == "")
                    condition += " WHERE ";
                else
                    condition += " AND ";

                condition += @"(
                                    p.owner_name LIKE CONCAT('%', @search, '%') OR
                                    p.part_no LIKE CONCAT('%', @search, '%') OR
                                    p.basin_number LIKE CONCAT('%', @search, '%') OR
                                    p.municipality_project_no LIKE CONCAT('%', @search, '%') OR
                                    p.bank_project_no LIKE CONCAT('%', @search, '%') OR
                                    p.details LIKE CONCAT('%', @search, '%') OR
                                    p.name LIKE CONCAT('%', @search, '%')
                                )";

                parameters.Add(DBClass.CreateParameter("@search", txtSearch.Text.Trim()));
            }

            query += condition;

            DataTable dT = DBClass.ExecuteDataTable(query, parameters.ToArray());
            if (dT == null)
                return;

            dgvCustomer.DataSource = dT;

            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["SN"].Width = 50;
            dgvCustomer.Columns["Code"].Width = 100;

            dgvCustomer.Columns["Description of the Project"].MinimumWidth = 200;
            dgvCustomer.Columns["Owner name"].MinimumWidth = 200;

            dgvCustomer.Columns["Description of the Project"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Owner name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string savedCulture = Properties.Settings.Default.ApplicationLanguage ?? "ar";
            if (savedCulture == "ar")
            {
                dgvCustomer.Columns["name_ar"].Visible = true; 
                dgvCustomer.Columns["name_en"].Visible = false;
                dgvCustomer.Columns["name_ar"].HeaderText = "Classification";
            }
            else
            {
                dgvCustomer.Columns["name_en"].Visible = true;
                dgvCustomer.Columns["name_ar"].Visible = false;
                dgvCustomer.Columns["name_en"].HeaderText = "Classification";
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
            //if (dgvCustomer.Rows != null && dgvCustomer.Rows.Count > 0)
            //{
            //    AddViewDocImageColumn();
            //}
        }

        private void AddViewDocImageColumn()
        {
            if (!dgvCustomer.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvCustomer.Columns.Add(imgColumn);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            object result = DBClass.ExecuteScalar(@"SELECT COUNT(1) FROM tbl_project_tender 
                  WHERE project_id = @id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            int recordCount = 0;
            if (result != null && result != DBNull.Value)
                recordCount = Convert.ToInt32(result);
            if (recordCount > 0)
            {
                MessageBox.Show("Already used");
                return;
            }
            DBClass.ExecuteNonQuery("DELETE FROM tbl_projects WHERE id=@id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            MessageBox.Show("Deleted");
            ProjectData();
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmProjectsManage(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
            //new frmAddProject(null, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())).ShowDialog();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                int _vId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["vrefId"].Value);
                string type = dgvCustomer.Rows[e.RowIndex].Cells["vVoucherType"].Value.ToString();
                AttachmentManager.OpenAttachmentByType(_vId, type);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Focused)
            {
                ProjectData();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
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
            centre.AddFormattedText("Project List\n", TextFormat.Bold).Font.Size = 14;
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
            foreach (DataGridViewColumn dgvCol in dgvCustomer.Columns)
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
                var dgvCol = dgvCustomer.Columns[visibleColumns[i]];
                header.Cells[i].AddParagraph(dgvCol.HeaderText);
                header.Cells[i].Format.Alignment = ParagraphAlignment.Center;
            }

            // ──────── 5. Data Rows ────────
            foreach (DataGridViewRow dgvRow in dgvCustomer.Rows)
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
                "ProjectList.pdf");

            renderer.PdfDocument.Save(path);

            Process.Start(new ProcessStartInfo()
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "ProjectList_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
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
                List<DataGridViewColumn> visibleCols = dgvCustomer.Columns
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

                foreach (DataGridViewRow dgvRow in dgvCustomer.Rows)
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
