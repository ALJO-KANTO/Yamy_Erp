using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Default;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmStateMandatedRetirementReport : Form
    {
        public frmStateMandatedRetirementReport()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }

        private void frmStateMandatedRetirementReport_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ▼";
            // add countries to combo box with code, name
            // countries are UAE,USA,UK,India,Canada,Australia add as list
            List<CountryModel> countries = new List<CountryModel>();
            countries.Add(new CountryModel(1, "UAE"));
            countries.Add(new CountryModel(2, "USA"));
            countries.Add(new CountryModel(3, "UK"));
            countries.Add(new CountryModel(4, "KSA"));
            comboBox2.Items.Add(countries);
            comboBox2.SelectedIndex = 0;
            List<CountryStateModel> countriesStateModel = new List<CountryStateModel>();
            countriesStateModel.Add(new CountryStateModel(1, 2, "California"));
            countriesStateModel.Add(new CountryStateModel(2, 2,"Texas"));
            countriesStateModel.Add(new CountryStateModel(3, 2,"Florida"));
            countriesStateModel.Add(new CountryStateModel(4, 2,"New York"));
            countriesStateModel.Add(new CountryStateModel(5, 2,"Washington"));
            countriesStateModel.Add(new CountryStateModel(6, 2,"Nevada"));
            countriesStateModel.Add(new CountryStateModel(7, 2,"Ohio"));
            countriesStateModel.Add(new CountryStateModel(8, 2,"Michigan"));
            countriesStateModel.Add(new CountryStateModel(9, 2,"Illinois"));
            countriesStateModel.Add(new CountryStateModel(10,2, "Pennsylvania"));
            countriesStateModel.Add(new CountryStateModel(11,2, "New Jersey"));
            countriesStateModel.Add(new CountryStateModel(12,2, "Virginia"));
            countriesStateModel.Add(new CountryStateModel(13,2, "North Carolina"));
            countriesStateModel.Add(new CountryStateModel(14,2, "Georgia"));
            countriesStateModel.Add(new CountryStateModel(15,2, "Arizona"));
            countriesStateModel.Add(new CountryStateModel(16,2, "Tennessee"));
            countriesStateModel.Add(new CountryStateModel(17,2, "Indiana"));
            countriesStateModel.Add(new CountryStateModel(18,2, "Massachusetts"));
            countriesStateModel.Add(new CountryStateModel(19,2, "Maryland"));
            countriesStateModel.Add(new CountryStateModel(20,2, "Wisconsin"));
            countriesStateModel.Add(new CountryStateModel(21,2, "Minnesota"));
            countriesStateModel.Add(new CountryStateModel(22,2, "South Carolina"));
            countriesStateModel.Add(new CountryStateModel(23,2, "Alabama"));
            countriesStateModel.Add(new CountryStateModel(24,2, "Louisiana"));
            countriesStateModel.Add(new CountryStateModel(25,2, "Kentucky"));
            countriesStateModel.Add(new CountryStateModel(26,2, "Oregon"));
            countriesStateModel.Add(new CountryStateModel(27,2, "Oklahoma"));
            countriesStateModel.Add(new CountryStateModel(28,2, "Connecticut"));
            countriesStateModel.Add(new CountryStateModel(29,2, "Iowa"));
            countriesStateModel.Add(new CountryStateModel(30,2, "Utah"));
            countriesStateModel.Add(new CountryStateModel(31,2, "Nevada"));
            countriesStateModel.Add(new CountryStateModel(32,2, "Arkansas"));
            countriesStateModel.Add(new CountryStateModel(33,2, "Mississippi"));
            countriesStateModel.Add(new CountryStateModel(34,2, "Kansas"));
            countriesStateModel.Add(new CountryStateModel(35,2, "New Mexico"));
            countriesStateModel.Add(new CountryStateModel(36,2, "Nebraska"));
            countriesStateModel.Add(new CountryStateModel(37,2, "West Virginia"));
            countriesStateModel.Add(new CountryStateModel(38,2, "Idaho"));
            countriesStateModel.Add(new CountryStateModel(39,2, "Hawaii"));
            countriesStateModel.Add(new CountryStateModel(40,2, "Maine"));
            countriesStateModel.Add(new CountryStateModel(41,2, "New Hampshire"));
            countriesStateModel.Add(new CountryStateModel(42,2, "Rhode Island"));
            countriesStateModel.Add(new CountryStateModel(43,2, "Montana"));
            countriesStateModel.Add(new CountryStateModel(44,2, "Delaware"));
            countriesStateModel.Add(new CountryStateModel(45,2, "South Dakota"));
            countriesStateModel.Add(new CountryStateModel(46,2, "North Dakota"));
            countriesStateModel.Add(new CountryStateModel(47,2, "Alaska"));
            countriesStateModel.Add(new CountryStateModel(48,2, "Vermont"));
            countriesStateModel.Add(new CountryStateModel(49,2, "Wyoming"));
            countriesStateModel.Add(new CountryStateModel(50,2, "District of Columbia"));
            countriesStateModel.Add(new CountryStateModel(51,1, "Abu Dhabi"));
            countriesStateModel.Add(new CountryStateModel(52,1, "Dubai"));
            countriesStateModel.Add(new CountryStateModel(53,1, "Sharjah"));
            countriesStateModel.Add(new CountryStateModel(54,1, "Ajman"));
            countriesStateModel.Add(new CountryStateModel(55,1, "Umm Al-Quwain"));
            countriesStateModel.Add(new CountryStateModel(56,1, "Ras Al Khaimah"));
            countriesStateModel.Add(new CountryStateModel(57,1, "Fujairah"));
            countriesStateModel.Add(new CountryStateModel(58,3, "England"));
            countriesStateModel.Add(new CountryStateModel(59,3, "Scotland"));
            countriesStateModel.Add(new CountryStateModel(60,3, "Wales"));
            countriesStateModel.Add(new CountryStateModel(61,3, "Northern Ireland"));
            countriesStateModel.Add(new CountryStateModel(62,4, "Riyadh"));
            countriesStateModel.Add(new CountryStateModel(63,4, "Jeddah"));
            countriesStateModel.Add(new CountryStateModel(64,4, "Dammam"));
            countriesStateModel.Add(new CountryStateModel(65,4, "Khobar"));
            countriesStateModel.Add(new CountryStateModel(66,4, "Mecca"));
            countriesStateModel.Add(new CountryStateModel(67,4, "Medina"));
            countriesStateModel.Add(new CountryStateModel(68,4, "Tabuk"));
            countriesStateModel.Add(new CountryStateModel(69,4, "Buraidah"));
            countriesStateModel.Add(new CountryStateModel(70,4, "Khamis Mushait"));
            countriesStateModel.Add(new CountryStateModel(71,4, "Hail"));
            countriesStateModel.Add(new CountryStateModel(72,4, "Najran"));
            countriesStateModel.Add(new CountryStateModel(73,4, "Jazan"));
            countriesStateModel.Add(new CountryStateModel(74,4, "Al Bahah"));
            countriesStateModel.Add(new CountryStateModel(75,4, "Al Jawf"));
            countriesStateModel.Add(new CountryStateModel(76,4, "Al Qassim"));
            countriesStateModel.Add(new CountryStateModel(77,4, "Asir"));
            countriesStateModel.Add(new CountryStateModel(78,4, "Eastern Province"));
            countriesStateModel.Add(new CountryStateModel(79,4, "Northern Borders"));
            countriesStateModel.Add(new CountryStateModel(80,4, "Al Madinah"));
            countriesStateModel.Add(new CountryStateModel(81,4, "Al Hudud ash Shamaliyah"));
            countriesStateModel.Add(new CountryStateModel(82,4, "Al Qunfudhah"));

            comboBox3.Items.Add(countries);
            LoadData();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                if (reader.Read())
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:tt");
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
            SetupDataGridView();

            string ss = @"SELECT
                                e.last_name,
                                e.first_name,
                                e.ssn,
                                SUM(p.amount) AS contribution_amount,
                                e.external_payroll_id

                            FROM tbl_payroll_transactions p
                            JOIN tbl_employees e ON e.id = p.employee_id
                            JOIN tbl_payroll_items i ON i.id = p.payroll_item_id

                            WHERE i.type = 'STATE_RETIREMENT'
                            AND p.date BETWEEN @sDate AND @eDate

                            GROUP BY e.id, e.last_name, e.first_name, e.ssn, e.external_payroll_id

                            ORDER BY e.last_name, e.first_name;";

            string sql = @"
                            SELECT 
                                '' AS last_name,
                                '' AS first_name,
                                '' AS ssn,
                                '' AS contribution_amount,
                                '' AS external_payroll_id
                        ";

            DataTable dt = DBClass.ExecuteDataTable(sql,
                DBClass.CreateParameter("sDate", dtpFrom.Value.Date),
                DBClass.CreateParameter("eDate", dtpTo.Value.Date));

            LoadPendingBuilds(dt);
        }
        private void LoadPendingBuilds(DataTable dt)
        {
            dgvReport.Rows.Clear();

            foreach (DataRow r in dt.Rows)
            {
                dgvReport.Rows.Add(
                    r["last_name"].ToString(),
                    r["first_name"].ToString(),
                    r["ssn"].ToString(),
                    r["contribution_amount"].ToString(),
                    r["external_payroll_id"].ToString()
                );
            }
        }
        private void SetupDataGridView()
        {
            dgvReport.Columns.Clear();
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvReport.Columns.Add("LastName", "Last Name");
            dgvReport.Columns.Add("FirstName", "First Name");
            dgvReport.Columns.Add("SSN", "SSN/Tax ID");
            dgvReport.Columns.Add("ContributionAmount", "Contribution Amount");
            dgvReport.Columns.Add("ExternalPayrollID", "External Payroll ID");

            dgvReport.Columns["Blank"].Width = 30;
            dgvReport.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            string companyName = lblCompany.Text;

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

            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText titleText = center.AddFormattedText("Pending Builds\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Pending Builds", TextFormat.NotBold);
            sub.Font.Size = 9;

            // Separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            //==========================================
            // DATA TABLE
            //==========================================
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Create columns based on DataGridView columns
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                Column tCol = table.AddColumn(Unit.FromCentimeter(3));
                tCol.Format.Alignment = ParagraphAlignment.Left;
            }

            // Add header row
            Row head = table.AddRow();
            head.Shading.Color = Colors.LightGray;
            head.Format.Font.Bold = true;

            for (int i = 0; i < dgvReport.Columns.Count; i++)
            {
                head.Cells[i].AddParagraph(dgvReport.Columns[i].HeaderText);
            }

            //==========================================
            // ADD DATA ROWS
            //==========================================
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (row.IsNewRow) continue;

                Row tRow = table.AddRow();

                for (int col = 0; col < dgvReport.Columns.Count; col++)
                {
                    string value = GetFormattedValue(row.Cells[col].Value);

                    var p = tRow.Cells[col].AddParagraph(value);

                    // Align numeric values
                    decimal num;
                    if (decimal.TryParse(value, out num))
                    {
                        p.Format.Alignment = ParagraphAlignment.Right;
                    }

                    // Make Type row bold
                    if (col == 0 && !string.IsNullOrWhiteSpace(value) && row.Cells[1].Value.ToString() == "")
                    {
                        p.Format.Font.Bold = true;
                    }

                    // Make Category row italic
                    if (col == 1 && !string.IsNullOrWhiteSpace(value))
                    {
                        p.Format.Font.Italic = true;
                    }

                    //string value = row.Cells[col].Value?.ToString() ?? "";
                    //var p = tRow.Cells[col].AddParagraph(value);
                    //// Align numeric values (warehouse qty)
                    //decimal num;
                    //if (decimal.TryParse(value, out num))
                    //{
                    //    p.Format.Alignment = ParagraphAlignment.Right;
                    //}
                    //// Make Type row bold
                    //if (col == 0 && !string.IsNullOrWhiteSpace(value) && row.Cells[1].Value.ToString() == "")
                    //{
                    //    p.Format.Font.Bold = true;
                    //}
                }
            }

            //==========================================
            // RENDER PDF
            //==========================================
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            // Save file
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Files (*.pdf)|*.pdf";
                dlg.Title = "Pending Builds";
                dlg.FileName = "PendingBuilds.pdf";

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

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Pending Builds";
                saveDialog.FileName = "PendingBuilds.xlsx";

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
                            worksheet.Name = "Pending Builds";

                            int totalRows = dgvReport.Rows.Count;
                            int processed = 0;

                            // ================================
                            // HEADER (Date and time)
                            // ================================

                            Excel.Range headerRange0 = worksheet.Range["B1", "F1"];
                            headerRange0.Merge();
                            headerRange0.Value = lblCompany.Text;
                            headerRange0.Font.Bold = true;
                            headerRange0.Font.Name = "Times New Roman";
                            headerRange0.Font.Size = 12;
                            headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            Excel.Range headerRange1 = worksheet.Range["B2", "F2"];
                            headerRange1.Merge();
                            headerRange1.Value = guna2HtmlLabel7.Text;
                            headerRange1.Font.Bold = true;
                            headerRange1.Font.Name = "Times New Roman";
                            headerRange1.Font.Size = 11;
                            headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            Excel.Range headerRange2 = worksheet.Range["B3", "F3"];
                            headerRange2.Merge();
                            headerRange2.Value = "From " + dtpFrom.Text + " - To " + dtpTo.Text;
                            headerRange2.Font.Bold = false;
                            headerRange2.Font.Name = "Times New Roman";
                            headerRange2.Font.Size = 9;
                            headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            // Merge and format header row (Date)
                            Excel.Range headerRange3 = worksheet.Range["B4", "F4"];
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
                            for (int col = 0; col < dgvReport.Columns.Count; col++)
                            {
                                var column = dgvReport.Columns[col];

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

                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                if (row.IsNewRow) continue;
                                if (progress.CancelRequested)
                                    throw new Exception("Operation cancelled.");

                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    var column = dgvReport.Columns[i];
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

        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Utilities.UserPermissionCheck("CustomerBalanceSummary"))
            //{
                //int id = int.Parse(dgvPurchase.CurrentRow.Cells["id"].Value.ToString());
                //frmLogin.frmMain.openChildForm(new frmPurchaseOrderDetails(id));
            //}
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            //LoadPurchaseData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            //LoadPurchaseData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dtpFrom, dtpTo);
                LoadData();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    internal class CountryStateModel
    {
        private int v1;
        private int v2;
        private string v3;

        public CountryStateModel(int v1, int v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }

    internal class CountryModel
    {
        private int code;
        private string name;

        public CountryModel(int code, string name)
        {
            this.code = code;
            this.name = name;
        }
    }
}