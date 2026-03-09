using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmSalesTaxLiabilityRevenue : Form
    {
        int id;
        string tblDetailName = "tbl_sales_details";
        string reportType = "";

        public frmSalesTaxLiabilityRevenue(string _type = "")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            if(_type == "SalesTaxLiability")
            {
                headerUC1.Text = guna2HtmlLabel7.Text = "Sales Tax Liability Report";
            }
            else if(_type == "SalesTaxRevenue")
            {
                headerUC1.Text = guna2HtmlLabel7.Text = "Sales Tax Revenue Report";
            }
            else
                headerUC1.FormText = this.Text;

            this.reportType = _type;
        }

        private void frmSalesTaxLiabilityRevenue_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ▼";
            DateTime dated = DateTime.Now;
            guna2HtmlLabel11.Text = dated.TimeOfDay.ToString();
            guna2HtmlLabel11.Text = dated.Date.ToShortDateString();
            loadCompany();
            LoadSalesData();
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
        private void LoadSalesData()
        {
            dgvSales.Rows.Clear();

            // Ensure columns exist
            if (dgvSales.Columns.Count == 0)
            {
                if (reportType == "SalesTaxLiability")
                {
                    dgvSales.Columns.Add("id", "Id");
                    dgvSales.Columns["id"].Visible = false;
                    dgvSales.Columns.Add("type", "");
                    dgvSales.Columns.Add("total", "Total Sales");
                    dgvSales.Columns.Add("non_tax_sales", "Non-Taxable Sales");
                    dgvSales.Columns.Add("taxable_sales", "Taxable Sales");
                    dgvSales.Columns.Add("tax_rate", "Tax Rate");
                    dgvSales.Columns.Add("tax_collected", "Tax Collected");
                    dgvSales.Columns.Add("date", "Amount on Date");

                    dgvSales.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["non_tax_sales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["taxable_sales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["tax_rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["tax_collected"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["total"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["non_tax_sales"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["taxable_sales"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["tax_rate"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["tax_collected"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["date"].DefaultCellStyle.Format = "N2";
                    dgvSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Regular);
                    dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dgvSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
                    dgvSales.EnableHeadersVisualStyles = false;
                    dgvSales.RowHeadersVisible = false;
                    dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                } else if(reportType == "SalesTaxRevenue")
                {
                    dgvSales.Columns.Add("id", "Id");
                    dgvSales.Columns["id"].Visible = false;
                    dgvSales.Columns.Add("type", "");
                    dgvSales.Columns.Add("taxable_sales", "Taxable Sales");
                    dgvSales.Columns.Add("non_tax_sales", "Non-Taxable Sales");
                    dgvSales.Columns.Add("total", "Total");

                    dgvSales.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["non_tax_sales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns["taxable_sales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvSales.Columns["total"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["non_tax_sales"].DefaultCellStyle.Format = "N2";
                    dgvSales.Columns["taxable_sales"].DefaultCellStyle.Format = "N2";

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
                LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);
            }

            string query = @"
                -- SALES TAX LIABILITY REPORT (with VAT Output condition and hum_id filter)
                            SELECT 
                                COALESCE(
                                    (SELECT name FROM tbl_coa_level_4 x WHERE x.id = t.account_id),
                                    'No tax vendor'
                                ) AS tax_vendor,
    
                                SUM(s.net) AS total_sales,
                                SUM(CASE WHEN s.vat = 0 THEN s.net ELSE 0 END) AS non_taxable_sales,
                                SUM(CASE WHEN s.vat > 0 THEN s.net ELSE 0 END) AS taxable_sales,
    
                                CASE 
                                    WHEN SUM(s.net) > 0 THEN ROUND(SUM(s.vat) / SUM(s.net) * 100, 2)
                                    ELSE 0
                                END AS tax_rate,
    
                                SUM(s.vat) AS tax_collected,
    
                                COALESCE(SUM(
                                    CASE 
                                        WHEN t.account_id = (SELECT account_id FROM tbl_coa_config WHERE category = 'Vat Output') 
                                        THEN t.credit 
                                        ELSE 0 
                                    END
                                ), 0) AS tax_paid,
    
                                SUM(s.vat) 
                                    - COALESCE(SUM(
                                        CASE 
                                            WHEN t.account_id = (SELECT account_id FROM tbl_coa_config WHERE category = 'Vat Output') 
                                            THEN t.credit 
                                            ELSE 0 
                                        END
                                    ), 0) AS tax_payable

                            FROM tbl_sales s
                            LEFT JOIN tbl_transaction t 
                                ON t.transaction_id = s.id
                                AND t.type IN ('Sales Invoice','Sales Invoice Cash','SalesReturn Invoice')
                                AND (
                                    t.account_id = (SELECT account_id FROM tbl_coa_config WHERE category = 'Vat Output')
                                    OR t.account_id IS NULL -- include non-tax vendors
                                )

                            WHERE s.date BETWEEN @startDate AND @endDate
                            AND (t.hum_id = 0 OR t.hum_id IS NULL)
                            -- AND s.customer_id = 1 -- optional filter

                            GROUP BY tax_vendor
                            ORDER BY tax_vendor;
                            ";

            var parameters = new[]{
                DBClass.CreateParameter("startDate", dateTimePicker1.Value.Date),
                DBClass.CreateParameter("endDate", dateTimePicker2.Value.Date)
            };

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters))
            {
                decimal totalSalesTotal = 0, nonTaxableSalesTotal = 0, taxableSalesTotal = 0, taxRateTotal = 0, taxCollectedTotal = 0, taxPaidTotal = 0, taxPayableTotal = 0;
                while (reader.Read())
                {
                    if (reportType == "SalesTaxLiability")
                    {
                        string taxVendor = reader["tax_vendor"].ToString();
                        decimal totalSales = Convert.ToDecimal(reader["total_sales"]);
                        decimal nonTaxableSales = Convert.ToDecimal(reader["non_taxable_sales"]);
                        decimal taxableSales = Convert.ToDecimal(reader["taxable_sales"]);
                        decimal taxRate = Convert.ToDecimal(reader["tax_rate"]);
                        decimal taxCollected = Convert.ToDecimal(reader["tax_collected"]);
                        decimal taxPaid = Convert.ToDecimal(reader["tax_paid"]);
                        decimal taxPayable = Convert.ToDecimal(reader["tax_payable"]);
                        dgvSales.Rows.Add(
                            "0", // id
                            taxVendor,
                            totalSales.ToString("N2"),
                            nonTaxableSales.ToString("N2"),
                            taxableSales.ToString("N2"),
                            taxRate.ToString("N2"),
                            taxCollected.ToString("N2"),
                            taxPaid.ToString("N2"),
                            taxPayable.ToString("N2")
                        );
                        totalSalesTotal += totalSales;
                        nonTaxableSalesTotal += nonTaxableSales;
                        taxableSalesTotal += taxableSales;
                        taxRateTotal += taxRate;
                        taxCollectedTotal += taxCollected;
                        taxPaidTotal += taxPaid;
                        taxPayableTotal += taxPayable;

                    }
                    else if (reportType == "SalesTaxRevenue")
                    {
                        string taxVendor = reader["tax_vendor"].ToString();
                        decimal taxableSales = Convert.ToDecimal(reader["taxable_sales"]);
                        decimal nonTaxableSales = Convert.ToDecimal(reader["non_taxable_sales"]);
                        decimal totalSales = Convert.ToDecimal(reader["total_sales"]);
                        dgvSales.Rows.Add(
                            "0", // id
                            taxVendor,
                            taxableSales.ToString("N2"),
                            nonTaxableSales.ToString("N2"),
                            totalSales.ToString("N2")
                        );
                        taxableSalesTotal += taxableSales;
                        nonTaxableSalesTotal += nonTaxableSales;
                        totalSalesTotal += totalSales;
                    }
                }

                if (reportType == "SalesTaxLiability")
                {
                    // Final TOTAL row
                    dgvSales.Rows.Add(
                        "0",
                        "TOTAL",
                        totalSalesTotal.ToString("N2"),
                        nonTaxableSalesTotal.ToString("N2"),
                        taxableSalesTotal.ToString("N2"),
                        taxRateTotal.ToString("N2"),
                        taxCollectedTotal.ToString("N2"),
                        taxPaidTotal.ToString("N2"),
                        taxPayableTotal.ToString("N2")
                    );
                }
                else if (reportType == "SalesTaxRevenue")
                {
                    // Final TOTAL row
                    dgvSales.Rows.Add(
                        "0",
                        "TOTAL",
                        taxableSalesTotal.ToString("N2"),
                        nonTaxableSalesTotal.ToString("N2"),
                        totalSalesTotal.ToString("N2")
                    );
                }
                dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline);
                dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            }
            //string salesQuery = @"
            //                    SELECT distinct c.id,CONCAT(CODE,' - ',c.name) name FROM tbl_transaction t
            //                        JOIN tbl_customer c ON t.hum_id = c.id
            //                        WHERE t.state = 0 AND
            //                        t.type IN (
            //                            'Sales Invoice',
            //                            'Sales Invoice Cash',
            //                            'SalesReturn Invoice'
            //                        )
            //                        AND t.date >= @startDate AND t.date <= @endDate";

            //var param = new[]{
            //    DBClass.CreateParameter("startDate", dateTimePicker1.Value.Date),
            //    DBClass.CreateParameter("endDate", dateTimePicker2.Value.Date)
            //    };

            //using (MySqlDataReader customerReader = DBClass.ExecuteReader(salesQuery, param.ToArray()))
            //{
            //    decimal totalSales = 0, nonTaxableSales = 0, taxableSales = 0, taxRate = 0, taxCollected = 0 , amountTotal;

            //    while (customerReader.Read())
            //    {
            //        int customerId = Convert.ToInt32(customerReader["id"]);
            //        string customerName = customerReader["name"].ToString();
            //        dgvSales.Rows.Add(customerId.ToString(), customerName, "", "", "", "", "", "");

            //        string itemQuery = @"
            //                      -- SALES TAX LIABILITY REPORT
            //                            SELECT s.id,
            //                                (SELECT NAME FROM tbl_coa_level_4 x WHERE x.id = t.account_id) AS tax_vendor,
            //                                SUM(s.total) AS total_sales,
            //                                SUM(CASE WHEN s.vat = 0 THEN s.total ELSE 0 END) AS non_taxable_sales,
            //                                SUM(CASE WHEN s.vat > 0 THEN s.net ELSE 0 END) AS taxable_sales,
            //                                CASE 
            //                                    WHEN SUM(s.net) > 0 THEN ROUND(SUM(s.vat) / SUM(s.net) * 100, 2)
            //                                    ELSE 0
            //                                END AS tax_rate,
            //                                SUM(s.vat) AS tax_collected,
            //                                COALESCE(SUM(s.vat), 0) AS tax_paid,
            //                                (SUM(s.net) - COALESCE(SUM(s.total), 0)) AS tax_payable
            //                            FROM tbl_sales s
            //                            LEFT JOIN tbl_transaction t 
            //                                ON t.transaction_id = s.id
            //                                AND t.type IN (
            //                                'Sales Invoice',
            //                                'Sales Invoice Cash',
            //                                'SalesReturn Invoice'
            //                            )
            //                            WHERE s.date BETWEEN @startDate AND @endDate AND s.customer_id = @id
            //                            GROUP BY t.account_id,s.id;";

            //        var itemParam = new[]{
            //                DBClass.CreateParameter("@id", customerId),
            //                DBClass.CreateParameter("startDate", dateTimePicker1.Value.Date),
            //                DBClass.CreateParameter("endDate", dateTimePicker2.Value.Date)
            //                };

            //        using (MySqlDataReader invoiceReader = DBClass.ExecuteReader(itemQuery, itemParam))
            //        {
            //            decimal customerTotal = 0, customerQtyTotal = 0;
            //            while (invoiceReader.Read())
            //            {
            //                int saleId = Convert.ToInt32(invoiceReader["id"]);
            //                string type = invoiceReader["type"].ToString();
            //                string date = Convert.ToDateTime(invoiceReader["date"]).ToString("dd/MM/yyyy");
            //                string num = invoiceReader["num"].ToString();
            //                string ship_to = invoiceReader["ship_to"].ToString();
            //                string ship_via = invoiceReader["ship_via"].ToString();
            //                string ship_date = Convert.ToDateTime(invoiceReader["ship_date"]).ToString("dd/MM/yyyy");

            //                string item = invoiceReader["Item Name"].ToString();
            //                decimal qty = Convert.ToDecimal(invoiceReader["Qty"]);
            //                decimal price = Convert.ToDecimal(invoiceReader["Price"]);
            //                decimal amount = Convert.ToDecimal(invoiceReader["Total"]);

            //                dgvSales.Rows.Add(
            //                    saleId.ToString(), // id
            //                    type,
            //                    date,
            //                    num,
            //                    ship_to,
            //                    ship_via,
            //                    ship_date,
            //                    item,
            //                    qty.ToString("N2"),
            //                    price.ToString("N2"),
            //                    amount.ToString("N2")
            //                );

            //                customerTotal += amount;
            //                customerQtyTotal += qty;
            //            }
            //            dgvSales.Rows.Add("0", "TOTAL "+customerName, "", "", "", "", "", "", customerQtyTotal.ToString("N2"), "", customerTotal.ToString("N2"));
            //            dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline);
            //            dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;

            //            netTotal += customerTotal;
            //            netQtyTotal += customerQtyTotal;
            //        }
            //    }
            //    // Final TOTAL row
            //    dgvSales.Rows.Add("0", "TOTAL", "", "", "", "", "", "", netQtyTotal.ToString("N2"), "", netTotal.ToString("N2"));
            //    dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline);
            //    dgvSales.Rows[dgvSales.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            //}

        }
        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //string name = dgvSales.Rows[e.RowIndex].Cells["type"].Value?.ToString();
                //if (string.Equals(name, "TOTAL", StringComparison.OrdinalIgnoreCase))
                //    return;
                //if (dgvSales.Rows[e.RowIndex].Cells["id"].Value != null)
                //{
                //    int _id = int.Parse(dgvSales.Rows[e.RowIndex].Cells["id"].Value.ToString());
                //    var _type = dgvSales.Rows[e.RowIndex].Cells["type"].Value.ToString();
                //    if (_type.Contains("Invoice"))
                //    {
                //        frmLogin.frmMain.openChildForm(new frmSales(int.Parse(dgvSales.CurrentRow.Cells["id"].Value.ToString())));
                //    }
                //    //else if(_type == "Purchase Return Invoice")
                //    //{
                //    //    frmLogin.frmMain.openChildForm(new frmPurchaseReturn(id));
                //    //}
                //}
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
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

            // Left: Date/Time
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center: Company + Report Title
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;
            headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

            FormattedText companyText = center.AddFormattedText(guna2HtmlLabel8.Text.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText titleText = center.AddFormattedText(reportType + "\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText subtitleText = center.AddFormattedText("All Transaction", TextFormat.NotBold);
            subtitleText.Font.Size = 9;

            section.Add(headerTable);

            // Bold separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            // Main table
            Table dataTable = section.AddTable();
            dataTable.Borders.Width = 0.75;
            dataTable.Format.Font.Name = "Times New Roman";
            dataTable.Format.Font.Size = 9;

            // Define columns dynamically based on report type
            List<string> columns = new List<string>();
            if (reportType == "SalesTaxLiability")
            {
                columns = new List<string> { "type", "total", "non_tax_sales", "taxable_sales", "tax_rate", "tax_collected", "date" };
                foreach (var col in columns) dataTable.AddColumn(Unit.FromCentimeter(3));
            }
            else if (reportType == "SalesTaxRevenue")
            {
                columns = new List<string> { "type", "taxable_sales", "non_tax_sales", "total" };
                foreach (var col in columns) dataTable.AddColumn(Unit.FromCentimeter(4.5));
            }

            // Header row
            Row tableHeader = dataTable.AddRow();
            tableHeader.Shading.Color = Colors.LightGray;
            tableHeader.Format.Font.Bold = true;
            for (int i = 0; i < columns.Count; i++)
            {
                tableHeader.Cells[i].AddParagraph(dgvSales.Columns[columns[i]].HeaderText);
                tableHeader.Cells[i].Format.Alignment = ParagraphAlignment.Center;
            }

            decimal totalAmount = 0;

            // Add data rows
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                Row tRow = dataTable.AddRow();
                for (int i = 0; i < columns.Count; i++)
                {
                    string cellValue = row.Cells[columns[i]]?.Value?.ToString() ?? "";
                    Paragraph p = tRow.Cells[i].AddParagraph(cellValue);

                    // Align numeric values to the right
                    if (columns[i] != "type")
                        p.Format.Alignment = ParagraphAlignment.Right;

                    // Sum totals if applicable
                    if (columns[i] == "total" || columns[i] == "tax_collected")
                    {
                        if (decimal.TryParse(cellValue, out decimal amt))
                            totalAmount += amt;
                    }
                }
            }

            // Total row
            if (columns.Contains("total"))
            {
                Row totalRow = dataTable.AddRow();
                totalRow.Cells[0].MergeRight = columns.Count - 2;
                Paragraph totalLabel = totalRow.Cells[0].AddParagraph("TOTAL");
                totalLabel.Format.Font.Bold = true;
                totalLabel.Format.Alignment = ParagraphAlignment.Right;

                Paragraph totalVal = totalRow.Cells[columns.Count - 1].AddParagraph(totalAmount.ToString("N2"));
                totalVal.Format.Font.Bold = true;
                totalVal.Format.Font.Underline = Underline.Single;
                totalRow.Cells[columns.Count - 1].Format.Alignment = ParagraphAlignment.Right;
            }

            section.Add(dataTable);

            // Render PDF
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true) { Document = doc };
            renderer.RenderDocument();

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFile.Title = "Save Sales Report";
                saveFile.FileName = reportType + ".pdf";

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
                saveDialog.FileName = reportType + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = reportType;

                    int rowIndex = 1;

                    // --- Header Section ---
                    Excel.Range headerRange0 = worksheet.Range["C1", "F1"];
                    headerRange0.Merge();
                    headerRange0.Value = guna2HtmlLabel8.Text; // Company Name
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    Excel.Range headerRange1 = worksheet.Range["C2", "F2"];
                    headerRange1.Merge();
                    headerRange1.Value = reportType; // Report Title
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

                    rowIndex = 5; // Start row for table headers

                    // --- Column Headers ---
                    int colIndex = 1;
                    List<DataGridViewColumn> visibleColumns = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn column in dgvSales.Columns)
                    {
                        if (column.Visible)
                        {
                            visibleColumns.Add(column);
                            var headerCell = worksheet.Cells[rowIndex, colIndex];
                            headerCell.Value = column.HeaderText;
                            headerCell.Font.Bold = true;
                            headerCell.Font.Name = "Times New Roman";
                            headerCell.Font.Size = 11;
                            headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                            colIndex++;
                        }
                    }

                    rowIndex++; // Move to first data row

                    // --- Data Rows ---
                    decimal totalAmount = 0;
                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        colIndex = 1;
                        foreach (var column in visibleColumns)
                        {
                            object value = row.Cells[column.Name]?.Value;
                            string textValue = value?.ToString() ?? "";

                            var cell = worksheet.Cells[rowIndex, colIndex];
                            cell.Value = textValue;
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 9;

                            // Right-align numeric columns
                            if (column.Name == "total" || column.Name == "non_tax_sales" || column.Name == "taxable_sales" || column.Name == "tax_rate" || column.Name == "tax_collected")
                            {
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                if (decimal.TryParse(textValue, out decimal amt))
                                {
                                    // Sum total for footer row
                                    if (column.Name == "total" || column.Name == "tax_collected")
                                        totalAmount += amt;
                                }
                            }
                            else
                            {
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }

                            colIndex++;
                        }
                        rowIndex++;
                    }

                    // --- Total Row ---
                    if (visibleColumns.Exists(c => c.Name == "total") || visibleColumns.Exists(c => c.Name == "tax_collected"))
                    {
                        colIndex = 1;
                        int mergeCols = visibleColumns.Count - 1;
                        Excel.Range totalLabelCell = worksheet.Range[worksheet.Cells[rowIndex, colIndex], worksheet.Cells[rowIndex, mergeCols]];
                        totalLabelCell.Merge();
                        totalLabelCell.Value = "TOTAL";
                        totalLabelCell.Font.Bold = true;
                        totalLabelCell.Font.Name = "Times New Roman";
                        totalLabelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                        // Total value
                        int lastColIndex = visibleColumns.Count;
                        Excel.Range totalValueCell = worksheet.Cells[rowIndex, lastColIndex];
                        totalValueCell.Value = totalAmount.ToString("N2");
                        totalValueCell.Font.Bold = true;
                        totalValueCell.Font.Name = "Times New Roman";
                        totalValueCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
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
            LoadSalesData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dateTimePicker1, dateTimePicker2);
                LoadSalesData();
            }
        }
    }
}
