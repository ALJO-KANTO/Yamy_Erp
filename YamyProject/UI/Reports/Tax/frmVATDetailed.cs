using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Reports.Tax
{
    public partial class frmVATDetailed : Form
    {
        public frmVATDetailed()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }
        string guna2HtmlLabel8 = "";

        private void frmVATDetailed_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;

            int quarter = (today.Month - 1) / 3 + 1;

            DateTime fromDate = new DateTime(
                today.Year,
                (quarter - 1) * 3 + 1,
                1);

            DateTime toDate = fromDate.AddMonths(3).AddDays(-1);

            dtpFrom.Value = fromDate;
            dtpTo.Value = toDate;

            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    guna2HtmlLabel8 = reader["name"].ToString();
                }
            }
            LoadData();
        }

        private void LoadData()
        {
            dgvVAT.Rows.Clear();

            string query = @"
                    -- Sales VAT Detail
                    SELECT
                        s.date AS Date,
                        'Sales Invoice' AS Type,
                        s.invoice_id AS Reference,
                        c.name AS Party,
                        (d.qty*d.price)-d.discount AS Taxable,
                        d.vatp AS VAT,
                        d.total AS Total

                    FROM tbl_sales s

                    INNER JOIN tbl_sales_details d
                        ON s.id=d.sales_id

                    INNER JOIN tbl_customer c
                        ON s.customer_id=c.id

                    WHERE s.date BETWEEN @from AND @to


                    UNION ALL


                    -- Project Invoice VAT Detail
                    SELECT
                        p.invoice_date AS Date,
                        'Project Invoice' AS Type,
                        p.invoice_id AS Reference,
                        CONCAT('Project #',p.project_id) AS Party,
                        p.amount AS Taxable,
                        p.vat AS VAT,
                        p.total AS Total

                    FROM tbl_projects_invoices p

                    WHERE p.invoice_date BETWEEN @from AND @to


                    UNION ALL


                    -- Purchase VAT Detail
                    SELECT
                        p.date AS Date,
                        'Purchase' AS Type,
                        p.invoice_id AS Reference,
                        v.name AS Party,
                        (d.qty*d.cost_price)-d.discount AS Taxable,
                        d.vatp AS VAT,
                        d.total AS Total

                    FROM tbl_purchase p

                    INNER JOIN tbl_purchase_details d
                        ON p.id=d.purchase_id

                    INNER JOIN tbl_vendor v
                        ON p.vendor_id=v.id

                    WHERE p.date BETWEEN @from AND @to


                    ORDER BY Date;
                    ";


            using (var reader = DBClass.ExecuteReader(
                query,
                DBClass.CreateParameter("@from", dtpFrom.Value.Date),
                DBClass.CreateParameter("@to", dtpTo.Value.Date)))
            {
                while (reader.Read())
                {
                    dgvVAT.Rows.Add(
                        Convert.ToDateTime(reader["Date"]).ToString("dd-MM-yyyy"),
                        reader["Type"].ToString(),
                        reader["Reference"].ToString(),
                        reader["Party"].ToString(),
                        Convert.ToDecimal(reader["Taxable"]),
                        Convert.ToDecimal(reader["VAT"]),
                        Convert.ToDecimal(reader["Total"])
                    );
                }

                //ColDate	ColType	ColReference	ColParty	ColTaxable	ColVAT	ColTotal
                dgvVAT.Columns["ColTaxable"].DefaultCellStyle.Format = "N2";
                dgvVAT.Columns["ColVAT"].DefaultCellStyle.Format = "N2";
                dgvVAT.Columns["ColTotal"].DefaultCellStyle.Format = "N2";
                dgvVAT.Columns["ColTaxable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVAT.Columns["ColVAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVAT.Columns["ColTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            // Get company name from DB
            string companyName = guna2HtmlLabel8;

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
            center.AddFormattedText("VAT Detail Report\n", TextFormat.Bold).Font.Size = 10;
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

            foreach (DataGridViewColumn col in dgvVAT.Columns)
            {
                dataTable.AddColumn(Unit.FromCentimeter(3));
                headerText.Add(col.HeaderText);
            }

            Row headerRow0 = dataTable.AddRow();

            for (int i = 0; i < headerText.Count; i++)
            {
                headerRow0.Cells[i].AddParagraph(headerText[i]);
            }
            foreach (DataGridViewRow dgvRow in dgvVAT.Rows)
            {
                if (dgvRow.IsNewRow)
                    continue;

                Row pdfRow = dataTable.AddRow();

                for (int i = 0; i < dgvVAT.Columns.Count; i++)
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
                saveDialog.FileName = "VATDetailReport.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(saveDialog.FileName);
                    Process.Start("explorer.exe", saveDialog.FileName);
                }
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = !chkDate.Checked;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = "VATDetailReport.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "VAT Detail Report";

                    // Merge and format header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "G1"];
                    headerRange.Merge();
                    headerRange.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    // Column headers
                    for (int col = 0; col < dgvVAT.Columns.Count; col++)
                    {
                        worksheet.Cells[2, col + 1] = dgvVAT.Columns[col].HeaderText;

                        var cell = worksheet.Cells[2, col + 1];
                        cell.Font.Bold = true;
                        cell.Font.Name = "Times New Roman";
                        cell.Font.Size = 10;
                        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }

                    int rowIndex = 3;

                    foreach (DataGridViewRow dgvRow in dgvVAT.Rows)
                    {
                        if (dgvRow.IsNewRow)
                            continue;

                        for (int col = 0; col < dgvVAT.Columns.Count; col++)
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
    }
}
