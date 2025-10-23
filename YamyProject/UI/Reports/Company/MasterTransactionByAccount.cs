using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterTransactionByAccount : Form
    {
        int account_id;
        string account_header = "Transactions By Account";
        public MasterTransactionByAccount(string _account_header, int _account_id)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.account_id = _account_id;
            this.account_header = string.IsNullOrEmpty(_account_header) ? "Transactions By Account" : _account_header;
            dgvCustomer.DataBindingComplete += dgvCustomer_DataBindingComplete;

            headerUC1.FormText = this.Text;
        }

        private void MasterTransactionByAccount_Load(object sender, EventArgs e)
        {
            dgvCustomer.Enabled = false;
            dgvCustomer.Columns.Clear();

            dgvCustomer.Columns.Add("date", "Date");
            dgvCustomer.Columns.Add("type", "Type");
            dgvCustomer.Columns.Add("hum_id", "HumID");
            dgvCustomer.Columns.Add("description", "Description");
            dgvCustomer.Columns.Add("transaction_id", "TransactionID");
            dgvCustomer.Columns.Add("debit", "Debit");
            dgvCustomer.Columns.Add("credit", "Credit");
            dgvCustomer.Columns.Add("Amount", "Balance");
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            }
            bindDGVAccount();
        }

        DataTable dt = new DataTable();

        private void bindDGVAccount()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                DBClass.CreateParameter("id", account_id)
            };

            string dateFilter = "";
            DateTime from = DateTime.MinValue, to = DateTime.MaxValue;
            bool DateChecked = comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "All";
            if (!DateChecked)
            {
                dateFilter = " AND t.date >= @startDate AND t.date <= @endDate";
                from = dtFrom.Value.Date;
                to = dtTo.Value.Date;
            }

            if (!DateChecked)
            {
                parameters.Add(DBClass.CreateParameter("startDate", from));
                parameters.Add(DBClass.CreateParameter("endDate", to));
            }

            string query = $@"
                            SELECT 
                                t.date,
                                t.type,
                                t.hum_id,
                                t.description,
                                t.transaction_id,
                                t.debit,
                                t.credit,
                                SUM(t.debit - t.credit) OVER (PARTITION BY t.account_id ORDER BY t.date, t.id) AS Amount
                            FROM tbl_transaction t
                            WHERE t.account_id = @id
                            {dateFilter}
                            ORDER BY t.date, t.id;";

            Task.Run(() =>
            {
                // This can run in the background thread
                DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());

                // Then update DataGridView in UI thread
                dgvCustomer.Invoke((MethodInvoker)delegate
                {
                    dgvCustomer.Rows.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        dgvCustomer.Rows.Add(
                            Convert.ToDateTime(row["date"]).ToString("yyyy-MM-dd"),
                            row["type"].ToString(),
                            row["hum_id"].ToString(),
                            row["description"].ToString(),
                            row["transaction_id"].ToString(),
                            Convert.ToDecimal(row["debit"]).ToString("N2"),
                            Convert.ToDecimal(row["credit"]).ToString("N2"),
                            Convert.ToDecimal(row["Amount"]).ToString("N2")
                        );
                    }

                    // Format columns
                    dgvCustomer.Columns["hum_id"].Visible = false;
                    dgvCustomer.Columns["transaction_id"].Visible = false;
                    dgvCustomer.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCustomer.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvCustomer.Columns["date"].Width = 65;
                    dgvCustomer.Columns["type"].Width = 140;
                    dgvCustomer.Columns["debit"].Width = 80;
                    dgvCustomer.Columns["credit"].Width = 80;
                    dgvCustomer.Enabled = true;

                    LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
                });
            });
        }

        private void bindDGVAccountOld()
        {
            var parameters = new[]
                {
                    DBClass.CreateParameter("id", account_id)
                };
            string dateFilter = "";
            bool DateChecked = comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "All";
            if (!DateChecked)
            {
                dateFilter =" AND t.date >= @startDate AND t.date <= @endDate";
                parameters = parameters.Concat(new[]
                {
                    DBClass.CreateParameter("startDate", dtFrom.Value.Date),
                    DBClass.CreateParameter("endDate", dtTo.Value.Date)
                }).ToArray();
            }

            DataTable dt = DBClass.ExecuteDataTable($@"SELECT 
                                                            t.date,
                                                            t.type,
                                                            t.hum_id,
                                                            t.description,
                                                            t.transaction_id,
                                                            t.debit,
                                                            t.credit,
                                                            SUM(t.debit - t.credit) OVER (PARTITION BY t.account_id ORDER BY t.date, t.id) AS Amount
                                                        FROM tbl_transaction t
                                                        WHERE t.account_id = @id
                                                        {dateFilter}
                                                        ORDER BY t.date, t.id;

                            ", parameters.ToArray());

            dgvCustomer.DataSource = dt;
            dgvCustomer.Columns["hum_id"].Visible = dgvCustomer.Columns["transaction_id"].Visible = false;
            dgvCustomer.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns["date"].Width = 65;
            dgvCustomer.Columns["type"].Width = 140;
            dgvCustomer.Columns["debit"].Width = dgvCustomer.Columns["credit"].Width = 80;
            dgvCustomer.Columns["Amount"].HeaderText = "Balance";
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }

        private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //ChangeRowColors();
        }
        bool DrawRect,showPnlHeader;
        private int rowIndex = 0; 
        private int pageNumber = 1;

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCustomer.RowTemplate.DefaultCellStyle.SelectionBackColor = dgvCustomer.CurrentRow.DefaultCellStyle.BackColor;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int startX = e.MarginBounds.Left-60;
            int startY = e.MarginBounds.Top ; // Space for header
            int rowHeight = 30; // Add 4 to the row height
            int maxRowsPerPage = (e.MarginBounds.Height - startY - 40) / rowHeight;
            int rowsPrinted = 0;

            // Column Width Adjustments (adding +10 to each column width)
            int maxDescriptionWidth = 300; // Limit Description column width
            Dictionary<int, int> colWidths = new Dictionary<int, int>();
            List<int> colPositions = new List<int>();
            int currentX = startX;
            // pdf header

            foreach (DataGridViewColumn col in dgvCustomer.Columns)
            {
                if (col.Visible)
                {
                    int colWidth = col.Width; // Add 10 to each column's width
                    if (col.Name.ToLower() == "description")
                    {
                        colWidth = Math.Min(colWidth, maxDescriptionWidth); // Limit Description width
                    }
                    if (col.Name.ToLower().Contains("date"))
                    {
                        colWidth = Math.Max(colWidth, 100); // Ensure a minimum width for date columns
                    }
                    colPositions.Add(currentX);
                    colWidths[col.Index] = colWidth;
                    currentX += colWidth;
                }
            }

            // Print Column Headers
            int colIndex = 0;
            foreach (DataGridViewColumn col in dgvCustomer.Columns)
            {
                if (col.Visible)
                {
                    e.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, colPositions[colIndex], startY);
                    colIndex++;
                }
            }
            startY += rowHeight;

            // Print Rows
            while (rowIndex < dgvCustomer.Rows.Count && rowsPrinted < maxRowsPerPage)
            {
                DataGridViewRow row = dgvCustomer.Rows[rowIndex];
                colIndex = 0;
                int maxRowHeight = rowHeight;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (dgvCustomer.Columns[cell.ColumnIndex].Visible)
                    {
                        string cellText = cell.Value?.ToString() ?? "";
                        DateTime dateValue;
                        // Fix Date Formatting
                        if (dgvCustomer.Columns[cell.ColumnIndex].Name.ToLower().Contains("date") &&
                            DateTime.TryParse(cellText, out  dateValue))
                        {
                            cellText = dateValue.ToString("yyyy-MM-dd"); // Ensure proper date format
                        }

                        Font cellFont = new Font("Segoe UI", 10);
                        int colWidth = colWidths[cell.ColumnIndex];

                        // Wrap text for description column
                        if (dgvCustomer.Columns[cell.ColumnIndex].Name.ToLower() == "description")
                        {
                            RectangleF cellRect = new RectangleF(colPositions[colIndex], startY, colWidth, rowHeight * 3);
                            SizeF textSize = e.Graphics.MeasureString(cellText, cellFont, colWidth);
                            maxRowHeight = Math.Max(maxRowHeight, (int)Math.Ceiling(textSize.Height));
                            e.Graphics.DrawString(cellText, cellFont, Brushes.Black, cellRect);
                        }
                        else
                        {
                            // Normal text drawing for other columns
                            RectangleF cellRect = new RectangleF(colPositions[colIndex], startY, colWidth+10, rowHeight);
                            e.Graphics.DrawString(cellText, cellFont, Brushes.Black, cellRect);
                        }

                        // Draw Cell Borders
                        if (DrawRect)
                            e.Graphics.DrawRectangle(Pens.Black, colPositions[colIndex], startY, colWidth, maxRowHeight);

                        colIndex++;
                    }
                }

                startY += maxRowHeight;
                rowIndex++;
                rowsPrinted++;
            }

            // Print Page Number
            string pageNumText = "Page " + pageNumber;
            Font pageFont = new Font("Segoe UI", 10, FontStyle.Italic);
            SizeF textSizePage = e.Graphics.MeasureString(pageNumText, pageFont);
            float pageX = e.MarginBounds.Left + (e.MarginBounds.Width - textSizePage.Width) / 2;
            float pageY = e.MarginBounds.Bottom + 20;
            e.Graphics.DrawString(pageNumText, pageFont, Brushes.Black, pageX, pageY);

            if (rowIndex < dgvCustomer.Rows.Count)
            {
                pageNumber++;
                e.HasMorePages = true;
            }
            else
            {
                pageNumber = 1;
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            bindDGVAccount();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            bindDGVAccount();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            showPnlHeader = DrawRect = false;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc
            };

            rowIndex = 0; // Reset row index for new printing
            previewDialog.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Excel File";
                saveDialog.FileName = account_header.Trim() + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = account_header;

                    // Merge and format header row (Date)
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["B1", "C1"];
                    headerRange.Merge();
                    headerRange.Value = DateTime.Now.ToString("MMM dd, yy");
                    headerRange.Font.Bold = true;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 10;
                    headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    int rowIndex = 2;
                    foreach (DataGridViewRow row in dgvCustomer.Rows)
                    {
                        if (row.IsNewRow) continue;
                        for (int colIndex = 0; colIndex < dgvCustomer.Columns.Count; colIndex++)
                        {
                            if (dgvCustomer.Columns[colIndex].Visible)
                            {
                                worksheet.Cells[rowIndex, colIndex + 1] = row.Cells[colIndex].Value?.ToString() ?? "";
                            }
                        }
                    }
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            bindDGVAccount();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dtFrom, dtTo);
                bindDGVAccount();
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.SelectedRows[0].Cells["transaction_id"].Value.ToString() == "")
                return;

            string type = dgvCustomer.SelectedRows[0].Cells["type"].Value.ToString();
            frmLogin.frmMain.openChildForm(new MasterTransactionJournal(dgvCustomer.SelectedRows[0].Cells["transaction_id"].Value.ToString(), type));
        }
    }
}
