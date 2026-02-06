using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Banking.BankTransactions;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class MasterBankTransactions : Form
    {
        private EventHandler bankUpdatedHandler;

        public MasterBankTransactions()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            bankUpdatedHandler  = (sender, args) => BindBanks();
            EventHub.Bank += bankUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterBankTransactions_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Bank -= bankUpdatedHandler;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmBankTransaction().ShowDialog();
        }
        private void MasterBankTransactions_Load(object sender, EventArgs e)
        {
            BindBanks();
        }
        public void BindBanks()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"SELECT a.id,a.bank_account_id,b.name 'Bank Name',a.account_id,c.name 'Account Name',a.statement_date as 'TRF Date',a.value_date Date,a.Narration,a.Debit,a.Credit,a.running_balance Balance,a.reference_no,a.cheque_no ChequeNo,a.Reconciled 
                                                    FROM tbl_bank_transaction a 
                                                    INNER JOIN tbl_coa_level_4 b ON a.bank_account_id = b.id 
                                                    INNER JOIN tbl_coa_level_4 c ON a.account_id = c.id;", DBClass.CreateParameter("@state", (CmbState.Text == "Registered" ? "0" : "-1" )));
            dgvCustomer.DataSource = dt;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["bank_account_id"].Visible = false;
            dgvCustomer.Columns["account_id"].Visible = false;
            dgvCustomer.Columns["Bank Name"].AutoSizeMode = dgvCustomer.Columns["Account Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvCustomer.Rows.Count > 0)
            {
                btnRemove.Enabled = UserPermissions.canDelete("Bank Center");
            }
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            if (dgvCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show(LocalizationManager.GetString("select_row_delete"), LocalizationManager.GetString("delete"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show(LocalizationManager.GetString("confirm_delete"), LocalizationManager.GetString("delete"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            } else
            {
                int selectedId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["id"].Value);
                DBClass.ExecuteNonQuery("DELETE FROM tbl_bank_transaction WHERE id = @id",
                    DBClass.CreateParameter("id", selectedId));
                CommonInsert.DeleteTransactionEntry(selectedId, "Bank Statement");
                Utilities.LogAudit(frmLogin.userId, "Delete Bank Transaction", "Bank Transaction", selectedId, "Deleted Bank Transaction: " + dgvCustomer.SelectedRows[0].Cells["reference_no"].Value);
                BindBanks();
            }


            //DBClass.ExecuteNonQuery("update tbl_bank set state = -1 where id =@id",
            //    DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            //Utilities.LogAudit(frmLogin.userId, "Delete Bank", "Bank", Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["id"].Value), "Deleted Bank: " + dgvCustomer.SelectedRows[0].Cells["Bank Name"].Value);
            //BindBanks();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomer.CurrentRow != null)
            {
                int selectedId = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["id"].Value);
                new frmBankTransaction(selectedId).ShowDialog();
            }
        }

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBanks();
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "BankStatement_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                var excelApp = new Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Bank Statement";

                // Merge and format header row (Report Title)
                Excel.Range headerRange = worksheet.Range["A1", "G1"];
                headerRange.Merge();
                headerRange.Value = "Bank Statement - " + DateTime.Now.ToString("dd MMM yyyy");
                headerRange.Font.Bold = true;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.Size = 11;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                var columns = dgvCustomer.Columns
                                                .Cast<DataGridViewColumn>()
                                                .Where(c => c.Visible)
                                                .OrderBy(c => c.DisplayIndex)
                                                .ToList();

                // Write column headers
                for (int i = 0; i < columns.Count; i++)
                {
                    worksheet.Cells[2, i + 1] = columns[i].HeaderText;

                    var cell = worksheet.Cells[2, i + 1];
                    cell.Font.Bold = true;
                    cell.Font.Name = "Times New Roman";
                    cell.Font.Size = 10;
                    cell.Interior.Color =
                        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                // Write data rows
                int rowIndex = 3;
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    if (row.IsNewRow) continue;

                    for (int col = 0; col < columns.Count; col++)
                    {
                        var dgvCol = columns[col];

                        // IMPORTANT: supports ComboBox columns
                        object value = row.Cells[dgvCol.Name].FormattedValue;

                        worksheet.Cells[rowIndex, col + 1] = value;

                        var cell = worksheet.Cells[rowIndex, col + 1];
                        cell.Font.Name = "Times New Roman";
                        cell.Font.Size = 9;

                        // Formatting rules
                        if (dgvCol.Name == "Debit" || dgvCol.Name == "Credit" || dgvCol.Name == "Balance")
                        {
                            if (decimal.TryParse(value?.ToString(), out decimal cost))
                                cell.Value = cost;

                            cell.NumberFormat = "#,##0.00";
                            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        }
                        else if (dgvCol.Name == "SN")
                        {
                            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        }
                        else
                        {
                            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        }
                    }

                    rowIndex++;
                }

                // Auto-fit all columns
                for (int i = 1; i <= columns.Count; i++)
                {
                    ((Excel.Range)worksheet.Columns[i]).AutoFit();
                }

                // Save the file
                workbook.SaveAs(saveDialog.FileName);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
