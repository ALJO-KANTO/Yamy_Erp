using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.UI.Banking;

namespace YamyProject.UI.Accountant
{
    public partial class FrmBatchEnterTransactions : Form
    {
        public FrmBatchEnterTransactions(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        int NextId = 0;
        int id = 0;
        private void FrmBatchEnterTransactions_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvBatch);
            LoadGridColumns();
            LoadBanks();
            NextId = GenerateNextId();
        }

        private int GenerateNextId()
        {
            int newCode = 0;

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_batch_transaction_detail"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    newCode = int.Parse(reader["lastCode"].ToString());
                }
            }

            return newCode;
        }
        private void dgvBatch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvBatch.Rows)
            {
                if (row.IsNewRow) continue;

                string cellValue = Convert.ToString(row.Cells["amount"].Value);

                if (decimal.TryParse(cellValue,
                                     NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,
                                     CultureInfo.CurrentCulture,
                                     out decimal val))
                {
                    total += val;
                }
            }

            lblTotalValue.Text = total.ToString("N2");
        }

        private void BindData()
        {
            if (cmbTranType.SelectedIndex < 0)
                return;
            if (cmbBank.SelectedValue == null)
                return;

            dgvBatch.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_batch_transaction where tran_type = @type",
                DBClass.CreateParameter("@type", cmbTranType.SelectedItem)))
            {
                while (reader.Read())
                {
                    int refId = Convert.ToInt32(reader["ref_no"].ToString());
                    int accountId = Convert.ToInt32(reader["account_Id"].ToString());
                    DateTime tranDate = Convert.ToDateTime(reader["tran_date"].ToString());
                    string query = @"SELECT d.id, d.tran_id,
                                        COALESCE(v.name, c.name, '') AS payee_name,
                                        d.payee_id,
                                        IFNULL(a.name, '') AS account_name,
                                        d.account_id,
                                        IFNULL(i.name, '') item_name,d.item_id, d.description,d.qty,d.rate,d.amount,d.tax_code,d.tax_item,d.tax_amount,d.terms,d.bill_due,d.check_no
                                    FROM tbl_batch_transaction_detail d
                                    LEFT JOIN tbl_vendor v ON v.id = d.payee_id
                                    LEFT JOIN tbl_customer c ON c.id = d.payee_id
                                    LEFT JOIN tbl_coa_level_4 a ON a.id = d.account_id
                                    LEFT JOIN tbl_items i ON i.id = d.item_id
                                    WHERE d.tran_id = @refId";
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader(query, DBClass.CreateParameter("@refId", refId)))
                    {
                        while (reader1.Read())
                        {
                            // --- Common fields ---
                            decimal amount = Convert.ToDecimal(reader1["amount"]);

                            string account = "", description = "", terms = "", item = "", party ="";
                            decimal qty = 0, rate = 0, taxAmount = 0, total = 0;
                            string taxCode = "", taxItem = "", bill_due = "", check_no = "";

                            int payee_id = 0, item_id = 0, account_id = 0;

                            payee_id = Convert.ToInt32(reader1["payee_id"].ToString() ?? "0");
                            item_id = Convert.ToInt32(reader1["item_id"].ToString() ?? "0");
                            account_id = Convert.ToInt32(reader1["account_id"].ToString() ?? "0");

                            if (cmbTranType.Text == "Checks")
                            {
                                account = reader1["account_name"].ToString() ?? "0";
                                party = reader1["payee_name"].ToString() ?? "0";
                                description = reader1["description"] != null ? reader1["description"].ToString() : "";

                                dgvBatch.Rows.Add(tranDate.Date, refId, party, account, amount, description, payee_id, account_id, item_id);
                            }
                            else if (cmbTranType.Text == "Invoices & Credit Memos")
                            {
                                party = reader1["payee_name"].ToString() ?? "0";
                                terms = reader1["terms"].ToString() ?? "";
                                description = reader1["description"].ToString() ?? "";
                                item = reader1["item_name"].ToString() ?? "";
                                qty = Convert.ToDecimal(reader1["qty"]);
                                rate = Convert.ToDecimal(reader1["rate"]);
                                taxCode = reader1["tax_code"].ToString() ?? "";
                                taxItem = reader1["tax_item"].ToString() ?? "";
                                taxAmount = Convert.ToDecimal(reader1["tax_amount"]);
                                total = Convert.ToDecimal(reader1["amount"]) + taxAmount;

                                dgvBatch.Rows.Add(tranDate.Date, refId, party, terms, amount, description, item, qty, rate, taxCode, taxItem, taxAmount, total, payee_id, account_id, item_id);
                            }
                            else if (cmbTranType.Text == "Bills & Bill Credits")
                            {
                                terms = reader1["terms"].ToString() ?? "";
                                bill_due = reader1["bill_due"].ToString() ?? "";
                                account = reader1["account_name"].ToString() ?? "";
                                description = reader1["description"].ToString() ?? "";

                                dgvBatch.Rows.Add(tranDate.Date, refId, party, terms, bill_due, account, amount, description, payee_id, account_id, item_id);
                            }
                            else if (cmbTranType.Text == "Credit Card Charges & Credits")
                            {
                                account = reader1["account_name"].ToString() ?? "";
                                description = reader1["description"].ToString() ?? "";

                                dgvBatch.Rows.Add(tranDate.Date, party, account, amount, description, payee_id, account_id, item_id);
                            }
                            else if (cmbTranType.Text == "Deposits")
                            {
                                account = reader1["account_name"].ToString() ?? "0";
                                description = reader1["description"].ToString() ?? "";
                                check_no = reader1["check_no"].ToString() ?? "";

                                dgvBatch.Rows.Add(tranDate.Date, party, account, description, check_no, amount, payee_id, account_id, item_id);
                            }
                        }
                    }
                    id = 1;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                MessageBox.Show("Cant edit existing batch. Please go to write Cheques");
                return;
            }
                if (!ValidateBatch())
                return;

            if (dgvBatch.Rows.Count == 0) return;
            if (!ValidateErrorCell())
            {
                MessageBox.Show("Please correct error cell");
                return;
            }

            try
            {
                
                foreach (DataGridViewRow row in dgvBatch.Rows)
                {
                    if (row.IsNewRow) continue;

                    // --- Common fields ---
                    DateTime tranDate = Convert.ToDateTime(row.Cells["date"].Value);
                    decimal amount = Convert.ToDecimal(row.Cells["amount"].Value);

                    string account = "", description = "", terms = "", item = "";
                    decimal qty = 0, rate = 0, taxAmount = 0, total = 0;
                    string taxCode = "", taxItem = "", bill_due = "", check_no = "";

                    if (cmbTranType.Text == "Checks")
                    {
                        account = row.Cells["account"].Value.ToString() ?? "0";
                        description = row.Cells["memo"].Value != null ? row.Cells["memo"].Value.ToString() : "";
                    }
                    else if (cmbTranType.Text == "Invoices & Credit Memos")
                    {
                        terms = row.Cells["terms"].Value.ToString() ?? "";
                        description = row.Cells["description"].Value.ToString() ?? "";
                        item = row.Cells["item"].Value.ToString() ?? "";
                        qty = Convert.ToDecimal(row.Cells["qty"].Value);
                        rate = Convert.ToDecimal(row.Cells["rate"].Value);
                        taxCode = row.Cells["tax code"].Value.ToString() ?? "";
                        taxItem = row.Cells["tax item"].Value.ToString() ?? "";
                        taxAmount = Convert.ToDecimal(row.Cells["tax amount"].Value);
                        total = Convert.ToDecimal(row.Cells["total"].Value);
                    }
                    else if (cmbTranType.Text == "Bills & Bill Credits")
                    {
                        terms = row.Cells["terms"].Value.ToString() ?? "";
                        bill_due = row.Cells["bill_due"].Value.ToString() ?? "";
                        account = row.Cells["account"].Value.ToString() ?? "";
                        description = row.Cells["memo"].Value.ToString() ?? "";
                    }
                    else if (cmbTranType.Text == "Credit Card Charges & Credits")
                    {
                        account = row.Cells["account"].Value.ToString() ?? "";
                        description = row.Cells["memo"].Value.ToString() ?? "";
                    }
                    else if (cmbTranType.Text == "Deposits")
                    {
                        account = row.Cells["account from"].Value.ToString() ?? "0";
                        description = row.Cells["memo"].Value.ToString() ?? "";
                        check_no = row.Cells["check no"].Value.ToString() ?? "";
                    }

                    string refNo = GetCellValue(row, "number", "ref no", "check no");
                    string party = GetCellValue(row, "payee", "vendor", "customer:Job", "received from");
                    int account_id = 0;
                    // Get account id from name
                    using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id FROM tbl_coa_level_4 WHERE name = @name",
                        DBClass.CreateParameter("@name", account)))
                    {
                        if (reader.Read())
                        {
                            account_id = Convert.ToInt32(reader["id"]);
                        }
                    }
                   //---Insert header-- -
                   int headerId = Convert.ToInt32(
                           DBClass.ExecuteScalar(@"
                            INSERT INTO tbl_batch_transaction
                            (tran_type, tran_date, account_id, ref_no, total_amount)
                            VALUES (@type, @date,@accountId, @ref, @amount);
                            SELECT LAST_INSERT_ID();",
                           DBClass.CreateParameter("@type", cmbTranType.Text),
                           DBClass.CreateParameter("@date", tranDate),
                           DBClass.CreateParameter("@accountId", cmbBank.SelectedValue),
                           DBClass.CreateParameter("@ref", refNo),
                           DBClass.CreateParameter("@amount", amount)
                       )
                   );

                    DBClass.ExecuteNonQuery(@"
                        INSERT INTO tbl_batch_transaction_detail
                        (tran_id, payee_name, account_name, account_id, item_name, description, qty, rate, amount, tax_code, tax_item, tax_amount)
                        VALUES (@hid, @party, @account_name, @account_id, @item_name, @desc, @qty, @rate, @amt, @tax_code, @tax_item, @tax_amount)",
                        DBClass.CreateParameter("@hid", headerId),
                        DBClass.CreateParameter("@party", party),
                        DBClass.CreateParameter("@account_name", account),
                        DBClass.CreateParameter("@account_id", account_id),
                        DBClass.CreateParameter("@item_name", item),
                        DBClass.CreateParameter("@desc", description),
                        DBClass.CreateParameter("@qty", qty),
                        DBClass.CreateParameter("@rate", rate),
                        DBClass.CreateParameter("@amt", amount),
                        DBClass.CreateParameter("@tax_code", taxCode),
                        DBClass.CreateParameter("@tax_item", taxItem),
                        DBClass.CreateParameter("@tax_amount", taxAmount)
                    );

                    PostTransaction(cmbTranType.Text, headerId, amount, tranDate, account_id);
                }

                //DBClass.CommitTransaction();
                MessageBox.Show("Batch saved successfully.");
                dgvBatch.Rows.Clear();
            }
            catch (Exception ex)
            {
                //DBClass.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateErrorCell()
        {
            foreach (DataGridViewRow row in dgvBatch.Rows)
            {
                if (row.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.Visible)
                        continue;

                    if (cell.Style.ForeColor == Color.Red)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string GetCellValue(DataGridViewRow row, params string[] columnNames)
        {
            foreach (string col in columnNames)
            {
                if (row.DataGridView.Columns.Contains(col) &&
                    row.Cells[col].Value != null)
                {
                    return row.Cells[col].Value.ToString();
                }
            }
            return string.Empty;
        }

        public void PostTransaction(string type, int headerId, decimal amount, DateTime tranDate, int account_id)
        {
            if(type == "Checks")
            {
                // DR Expense
                // CR Bank
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Checks of Bank", frmLogin.userId, DateTime.Now.Date, "");
                CommonInsert.addTransactionEntry(tranDate, cmbBank.SelectedValue.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Checks of Bank", frmLogin.userId, DateTime.Now.Date, "");
            }
            else if (type == "Deposits")
            {
                // DR Bank
                // CR Revenue
                CommonInsert.addTransactionEntry(tranDate, cmbBank.SelectedValue.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Deposits of Bank", frmLogin.userId, DateTime.Now, "");
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Deposits of Bank", frmLogin.userId, DateTime.Now.Date, "");
            }
            else if (type == "Credit Card Charges & Credits")
            {
                // DR Expense
                // CR Credit Card Liability
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Credit Card Charges & Credits", frmLogin.userId, DateTime.Now.Date, "");
                CommonInsert.addTransactionEntry(tranDate, cmbBank.SelectedValue.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Credit Card Charges & Credits", frmLogin.userId, DateTime.Now, "");
            }
            else
            if (type == "Invoices & Credit Memos")
            {
                // DR Accounts Receivable
                // CR Revenue
                CommonInsert.addTransactionEntry(tranDate, cmbBank.SelectedValue.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Invoices & Credit Memos", frmLogin.userId, DateTime.Now, "");
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Invoices & Credit Memos", frmLogin.userId, DateTime.Now.Date, "");
            }
            else if (type == "Bills & Bill Credits")
            {
                // DR Expense
                // CR Accounts Payable
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Bills & Bill Credits", frmLogin.userId, DateTime.Now.Date, "");
                CommonInsert.addTransactionEntry(tranDate, cmbBank.SelectedValue.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Bills & Bill Credits", frmLogin.userId, DateTime.Now, "");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvBatch.Rows.Clear();
            cmbBank.SelectedIndex = -1;
        }

        private void cmbTranType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBank.DataSource = null;

            if (cmbTranType.SelectedIndex == 0) {
                lbAccounts.Text = "BANK ACCOUNT"; 
                LoadBanks();
                LoadGridColumns();
            }
            else if(cmbTranType.SelectedIndex == 1)
            {
                lbAccounts.Text = "DEPOSIT TO";
                LoadBanks();
                LoadGridColumns();
            }
            else if (cmbTranType.SelectedIndex ==2)
            {
                lbAccounts.Text = "CREDIT CARD";
                //check credit card is exist or not and show messages
                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id,name from tbl_credit_card"))
                {
                    if (reader.HasRows)
                    {
                        LoadBanks();
                        LoadGridColumns();
                    }
                    else
                    {
                        var result = MessageBox.Show("No credit card found. Do you want to create one now?", "Credit Card", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            var setup = new frmCreditCardRegister();
                            if (setup.ShowDialog() == DialogResult.OK)
                            {
                                // After creation → open register
                                new frmCreditCardRegister().Show();
                            }
                        }
                    }
                }
            }
            else if (cmbTranType.SelectedIndex == 3)
            {
                lbAccounts.Text = "A/P ACCOUNT";
                LoadBanks();
                LoadGridColumns();
            }
            else if (cmbTranType.SelectedIndex == 4)
            {
                lbAccounts.Text = "A/R ACCOUNT";
                LoadBanks();
                LoadGridColumns();
            }
            else
            {
                lbAccounts.Text = "BANK ACCOUNT";
                LoadBanks();
                LoadGridColumns();
            }

            //BindData();
        }
        private void LoadBanks()
        {
            string query = "SELECT id,name FROM tbl_coa_level_4";
            if (cmbTranType.SelectedIndex == 0 || cmbTranType.SelectedIndex == 1)
            {
                query = "SELECT id,name FROM tbl_coa_level_4 WHERE main_id = 1";
            }
            else if (cmbTranType.SelectedIndex == 2)
            {
                query = "SELECT id,name from tbl_credit_card";
            }
            else if (cmbTranType.SelectedIndex == 3)
            {
                query = "SELECT id,name from tbl_coa_level_4 WHERE main_id = 13";
            }
            else if (cmbTranType.SelectedIndex == 4)
            {
                query = "SELECT id,name from tbl_coa_level_4 WHERE main_id = 2";
            }
            else
            {
                query = "SELECT 1 as id,'select type' as name FROM tbl_coa_level_4";
            }
            DataTable dt = DBClass.ExecuteDataTable(query);
            cmbBank.DataSource = dt;
            cmbBank.ValueMember = "id";
            cmbBank.DisplayMember = "name";
            cmbBank.SelectedIndex = 0;
        }
        private void LoadGridColumns()
        {
            dgvBatch.Columns.Clear();

            if (cmbTranType.SelectedIndex == 0)
            {
                dgvBatch.Columns.Add("date", "DATE");
                dgvBatch.Columns.Add("number", "NUMBER");
                dgvBatch.Columns.Add("payee", "PAYEE");
                dgvBatch.Columns.Add("account", "ACCOUNT");
                dgvBatch.Columns.Add("amount", "AMOUNT");
                dgvBatch.Columns.Add("memo", "MEMO");
                // add column and hide
                dgvBatch.Columns.Add("cleared", "Cleared");
                dgvBatch.Columns.Add("billable?", "Billable?");
                dgvBatch.Columns.Add("customer:Job", "Customer:Job");
                dgvBatch.Columns.Add("item", "Item");
                dgvBatch.Columns.Add("cost", "Cost");
                dgvBatch.Columns.Add("qty", "Qty");
                dgvBatch.Columns["cleared"].Visible = false;
                dgvBatch.Columns["billable?"].Visible = false;
                dgvBatch.Columns["customer:Job"].Visible = false;
                dgvBatch.Columns["item"].Visible = false;
                dgvBatch.Columns["cost"].Visible = false;
                dgvBatch.Columns["qty"].Visible = false;
            }
            else if (cmbTranType.SelectedIndex == 1)
            {
                dgvBatch.Columns.Add("date", "DATE");
                dgvBatch.Columns.Add("received from", "RECEIVED FROM");
                dgvBatch.Columns.Add("account from", "ACCOUNT FROM");
                dgvBatch.Columns.Add("memo", "MEMO");
                dgvBatch.Columns.Add("check no", "CHECK NO");
                dgvBatch.Columns.Add("amount", "AMOUNT");
                // add column and hide
                dgvBatch.Columns.Add("Due Date", "Due Date");
                dgvBatch.Columns.Add("Sales Rep", "Sales Rep");
                dgvBatch.Columns.Add("To Print", "To Print");
                dgvBatch.Columns.Add("To Be Emailed", "To Be Emailed");
                dgvBatch.Columns.Add("Price Level", "Price Level");
                dgvBatch.Columns.Add("Template", "Template");
                dgvBatch.Columns.Add("Online Pay", "Online Pay");
                dgvBatch.Columns["Due Date"].Visible = false;
                dgvBatch.Columns["Sales Rep"].Visible = false;
                dgvBatch.Columns["To Print"].Visible = false;
                dgvBatch.Columns["To Be Emailed"].Visible = false;
                dgvBatch.Columns["Price Level"].Visible = false;
                dgvBatch.Columns["Template"].Visible = false;
                dgvBatch.Columns["Online Pay"].Visible = false;
            }
            else if (cmbTranType.SelectedIndex == 2)
            {
                dgvBatch.Columns.Add("date", "DATE");
                dgvBatch.Columns.Add("payee", "PAYEE");
                dgvBatch.Columns.Add("account", "ACCOUNT");
                dgvBatch.Columns.Add("amount", "AMOUNT");
                dgvBatch.Columns.Add("memo", "MEMO");
                // add column and hide
                dgvBatch.Columns.Add("billable?", "Billable?");
                dgvBatch.Columns.Add("customer:Job", "Customer:Job");
                dgvBatch.Columns.Add("item", "Item");
                dgvBatch.Columns.Add("cost", "Cost");
                dgvBatch.Columns.Add("qty", "Qty");
                dgvBatch.Columns["billable?"].Visible = false;
                dgvBatch.Columns["customer:Job"].Visible = false;
                dgvBatch.Columns["item"].Visible = false;
                dgvBatch.Columns["cost"].Visible = false;
                dgvBatch.Columns["qty"].Visible = false;
            }
            else if (cmbTranType.SelectedIndex == 3)
            {
                dgvBatch.Columns.Add("date", "DATE");
                dgvBatch.Columns.Add("ref no", "REF NO");
                dgvBatch.Columns.Add("vendor", "VENDOR");
                dgvBatch.Columns.Add("terms", "TERMS");
                dgvBatch.Columns.Add("bill_due", "BILL DUE");
                dgvBatch.Columns.Add("account", "ACCOUNT");
                dgvBatch.Columns.Add("amount", "AMOUNT");
                dgvBatch.Columns.Add("memo", "MEMO");
                // add column and hide
                dgvBatch.Columns.Add("ref", "Ref");
                dgvBatch.Columns.Add("cleared", "Cleared");
                dgvBatch.Columns.Add("billable?", "Billable?");
                dgvBatch.Columns.Add("customer:Job", "Customer:Job");
                dgvBatch.Columns.Add("item", "Item");
                dgvBatch.Columns.Add("cost", "Cost");
                dgvBatch.Columns.Add("qty", "Qty");
                dgvBatch.Columns["ref"].Visible = false;
                dgvBatch.Columns["cleared"].Visible = false;
                dgvBatch.Columns["billable?"].Visible = false;
                dgvBatch.Columns["customer:Job"].Visible = false;
                dgvBatch.Columns["item"].Visible = false;
                dgvBatch.Columns["cost"].Visible = false;
                dgvBatch.Columns["qty"].Visible = false;
            }
            else if (cmbTranType.SelectedIndex == 4)
            {
                dgvBatch.Columns.Add("date", "DATE");
                dgvBatch.Columns.Add("number", "NUMBER");
                dgvBatch.Columns.Add("customer:Job", "CUSTOMER JOB");
                dgvBatch.Columns.Add("terms", "TERMS");
                dgvBatch.Columns.Add("amount", "AMOUNT");
                dgvBatch.Columns.Add("description", "DESCRIPTION");
                dgvBatch.Columns.Add("item", "ITEM");
                dgvBatch.Columns.Add("qty", "QTY");
                dgvBatch.Columns.Add("rate", "RATE");
                dgvBatch.Columns.Add("tax code", "TAX CODE");
                dgvBatch.Columns.Add("tax item", "TAX ITEM");
                dgvBatch.Columns.Add("tax amount", "TAX AMOUNT");
                dgvBatch.Columns.Add("total", "TOTAL");
                // add column and hide
                dgvBatch.Columns.Add("cleared", "Cleared");
                dgvBatch.Columns.Add("class", "Class");
                dgvBatch.Columns.Add("Payment Method", "Payment Method");
                dgvBatch.Columns["cleared"].Visible = false;
                dgvBatch.Columns["class"].Visible = false;
                dgvBatch.Columns["Payment Method"].Visible = false;
            }
            dgvBatch.Columns.Add("payee_id", "payee_id");
            dgvBatch.Columns["payee_id"].Visible = false;
            dgvBatch.Columns.Add("account_id", "account_id");
            dgvBatch.Columns["account_id"].Visible = false;
            dgvBatch.Columns.Add("item_id", "item_id");
            dgvBatch.Columns["item_id"].Visible = false;
        }

        private void dgvBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteFromClipboardSingleColumn(dgvBatch);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void PasteFromClipboardSingleColumn(DataGridView dgv)
        {
            //if (!Clipboard.ContainsText()) return;

            //string clipboardText = Clipboard.GetText();

            //// Excel separates rows by newline
            //string[] rows = clipboardText
            //    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //if (dgv.CurrentCell == null) return;

            //int startRow = dgv.CurrentCell.RowIndex;
            //int colIndex = dgv.CurrentCell.ColumnIndex;

            //for (int i = 0; i < rows.Length; i++)
            //{
            //    int targetRow = startRow + i;

            //    // Add new row if needed
            //    if (targetRow >= dgv.Rows.Count)
            //        dgv.Rows.Add();

            //    dgv.Rows[targetRow].Cells[colIndex].Value = rows[i].Trim();
            //}
            if (!Clipboard.ContainsText()) return;
            if (dgv.CurrentCell == null) return;

            string clipboardText = Clipboard.GetText();

            // Excel-safe parsing
            List<string> excelRows = new List<string>();
            StringBuilder current = new StringBuilder();
            bool insideQuotes = false;

            for (int i = 0; i < clipboardText.Length; i++)
            {
                char c = clipboardText[i];

                if (c == '"')
                {
                    insideQuotes = !insideQuotes;
                    continue;
                }

                // Row break ONLY if not inside quoted cell
                if (!insideQuotes && c == '\n')
                {
                    excelRows.Add(
                        current.ToString()
                               .Replace("\r", "")
                               .TrimEnd()
                    );
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }

            if (current.Length > 0)
                excelRows.Add(current.ToString().Replace("\r", "").TrimEnd());

            int startRow = dgv.CurrentCell.RowIndex;
            int colIndex = dgv.CurrentCell.ColumnIndex;

            for (int i = 0; i < excelRows.Count; i++)
            {
                int targetRow = startRow + i;

                if (targetRow >= dgv.Rows.Count - (dgv.AllowUserToAddRows ? 1 : 0))
                    dgv.Rows.Add();

                dgv.Rows[targetRow].Cells[colIndex].Value = excelRows[i];
            }
        }
        private bool ValidateBatch()
        {
            foreach (DataGridViewRow row in dgvBatch.Rows)
            {
                if (row.IsNewRow) continue;

                if (!ValidateRow(row))
                    return false;
            }
            return true;
        }
        private bool ValidateRow(DataGridViewRow row)
        {
            string tranType = cmbTranType.Text;

            // Clear previous error
            row.ErrorText = "";

            // ---- DATE ----
            if (!TryGetDate(row, "date", out DateTime tranDate))
                return RowError(row, "Invalid or missing date");

            if (tranDate.Year < 2000 || tranDate > DateTime.Today.AddYears(1))
                return RowError(row, "Transaction date is out of range");

            // ---- AMOUNT ----
            if (!TryGetDecimal(row, "amount", out decimal amount) || amount <= 0)
                return RowError(row, "Amount must be greater than zero");

            // ---- TYPE-SPECIFIC RULES ----
            switch (tranType)
            {
                case "Check":
                case "Credit Card Charge":
                    if (IsEmpty(row, "payee"))
                        return RowError(row, "Payee is required");
                    if (IsEmpty(row, "account"))
                        return RowError(row, "Account is required");
                    //if(isAccountExists(row.Cells["payee"].Value.ToString()))
                    //    return RowError(row, "Payee does not exist");
                    //if(isAccountExists(row.Cells["account"].Value.ToString()))
                    //    return RowError(row, "Account does not exist");
                    break;

                case "Invoice":
                case "Credit Memo":
                    if (IsEmpty(row, "customer:Job"))
                        return RowError(row, "Customer Job is required");
                    if (IsEmpty(row, "item"))
                        return RowError(row, "Item is required");

                    ValidateInvoiceMath(row);
                    break;

                case "Bill":
                case "Bill Credit":
                    if (IsEmpty(row, "vendor"))
                        return RowError(row, "Vendor is required");
                    if (IsEmpty(row, "account"))
                        return RowError(row, "Expense account is required");
                    break;

                case "Deposit":
                    if (IsEmpty(row, "received from"))
                        return RowError(row, "Received From is required");
                    break;
            }

            return true;
        }
        private void ValidateInvoiceMath(DataGridViewRow row)
        {
            if (!TryGetDecimal(row, "qty", out decimal qty)) qty = 1;
            if (!TryGetDecimal(row, "rate", out decimal rate)) rate = 0;

            decimal calculated = qty * rate;

            if (TryGetDecimal(row, "amount", out decimal amount))
            {
                if (Math.Round(calculated, 2) != Math.Round(amount, 2))
                {
                    row.Cells["amount"].Value = calculated;
                }
            }
        }
        private bool TryGetDate(DataGridViewRow row, string col, out DateTime value)
        {
            value = DateTime.MinValue;
            return row.DataGridView.Columns.Contains(col)
                && DateTime.TryParse(row.Cells[col].Value?.ToString(), out value);
        }

        private bool TryGetDecimal(DataGridViewRow row, string col, out decimal value)
        {
            value = 0;
            return row.DataGridView.Columns.Contains(col)
                && decimal.TryParse(row.Cells[col].Value?.ToString(), out value);
        }

        private bool IsEmpty(DataGridViewRow row, string col)
        {
            return !row.DataGridView.Columns.Contains(col)
                || string.IsNullOrWhiteSpace(row.Cells[col].Value?.ToString());
        }

        private bool RowError(DataGridViewRow row, string message)
        {
            row.ErrorText = message;
            dgvBatch.CurrentCell = row.Cells[0];
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void dgvBatch_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (cmbTranType.SelectedIndex == 0 || cmbTranType.SelectedIndex == 4)
                dgvBatch.Rows[e.RowIndex].Cells["number"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnCustomize_Click(object sender, EventArgs e)
        {
            using (var frm = new frmCustomizeColumns(cmbTranType.SelectedIndex))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var columns = frm.SelectedColumns;
                    // Apply to DataGridView
                    foreach (DataGridViewColumn col in dgvBatch.Columns)
                        col.Visible = false;

                    foreach (string colName in columns)
                    {
                        dgvBatch.Columns[colName].Visible = true;
                        dgvBatch.Columns[colName].DisplayIndex = columns.IndexOf(colName);
                    }
                }
            }

        }

        private void dgvBatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvBatch.Columns[e.ColumnIndex].Name;

            if (columnName == "payee" || columnName == "account" || columnName == "account from" || columnName == "customer:Job" || columnName == "received from" || columnName == "item" || columnName == "vendor")
            {
                Rectangle cellRect = dgvBatch.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                Point location = dgvBatch.PointToScreen(cellRect.Location);
                location = this.PointToClient(location);

                pnlLookup.Location = new Point(location.X, location.Y - cellRect.Height - 25);
                pnlLookup.Width = cellRect.Width;
                pnlLookup.Height = 150;

                pnlLookup.Visible = true;
                pnlLookup.BringToFront();

                if (columnName == "account" || columnName == "account from")
                {
                    LoadAccountLookup();
                }
                if (columnName == "customer:Job" || columnName == "received from" || columnName == "payee")
                {
                    LoadCustomerLookup();
                }
                if (columnName == "item")
                {
                    LoadItemLookup();
                }
                if (columnName == "vendor")
                {
                    LoadVendorLookup();
                }
            }
            else
            {
                pnlLookup.Visible = false;
            }
        }

        private void LoadAccountLookup()
        {
            lstLookup.Items.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_coa_level_4"))
            {
                while (reader.Read())
                {
                    lstLookup.Items.Add(reader["name"].ToString());
                }
            }
        }
        private void LoadCustomerLookup()
        {
            lstLookup.Items.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_customer"))
            {
                while (reader.Read())
                {
                    lstLookup.Items.Add(reader["name"].ToString());
                }
            }
        }
        private void LoadVendorLookup()
        {
            lstLookup.Items.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_vendor"))
            {
                while (reader.Read())
                {
                    lstLookup.Items.Add(reader["name"].ToString());
                }
            }
        }
        private void LoadItemLookup()
        {
            lstLookup.Items.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_items"))
            {
                while (reader.Read())
                {
                    lstLookup.Items.Add(reader["name"].ToString());
                }
            }
        }

        private void lstLookup_Click(object sender, EventArgs e)
        {
            if(lstLookup.SelectedItem == null) return;

            dgvBatch.CurrentCell.Value = lstLookup.SelectedItem.ToString();
            pnlLookup.Visible = false;
        }

        protected override void OnClick(EventArgs e)
        {
            pnlLookup.Visible = false;
            base.OnClick(e);
        }

        private void dgvBatch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex <0 || e.RowIndex <0) return;

            string columnName = dgvBatch.Columns[e.ColumnIndex].Name;
            if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                return;
            }
            if (string.IsNullOrEmpty(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                return;
            }

            if (columnName == "date")
            {
                if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Visible)
                {
                    // check date format is correct else show cell value color red
                    if (!DateTime.TryParse(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out DateTime dt))
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            if(columnName == "account" || columnName == "account from")
            {
                if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Visible)
                {
                    // check account or payee is exist or not
                    if (!isAccountExists(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "", e.RowIndex))
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            if(columnName == "customer:Job" || columnName == "received from" || columnName == "payee")
            {
                if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Visible)
                {
                    if (!isCustomerExists(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "", e.RowIndex))
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            if (columnName == "item")
            {
                if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Visible)
                {
                    // check item is exist or not
                    if (!isItemExists(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "", e.RowIndex))
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            if(columnName == "vendor")
            {
                if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Visible)
                {
                    // check vendor is exist or not
                    if (!isVendorExists(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "", e.RowIndex))
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            if(columnName == "due date" || columnName == "bill_due")
            {
                if (dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Visible)
                {
                    if (!DateTime.TryParse(dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out DateTime dt))
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private bool isVendorExists(string v,int rowIndex)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id FROM tbl_vendor WHERE name = @name",
                        DBClass.CreateParameter("@name", v)))
            {
                if (reader.Read())
                {
                    dgvBatch.Rows[rowIndex].Cells["payee_id"].Value = reader["id"].ToString();
                    return true;
                }
                else
                {
                    var dialogResult = MessageBox.Show("Vendor '" + v + "' does not exist. Please create the vendor first.", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        new frmViewVendor().ShowDialog();
                        LoadAccountLookup();
                    }
                    return false;
                }
            }
        }

        private bool isAccountExists(string accountName,int rowIndex)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id FROM tbl_coa_level_4 WHERE name = @name",
                        DBClass.CreateParameter("@name", accountName)))
            {
                if (reader.Read())
                {
                    dgvBatch.Rows[rowIndex].Cells["account_id"].Value = reader["id"].ToString();
                    return true;
                }
                else
                {
                    var dialogResult = MessageBox.Show("Account '" + accountName + "' does not exist. Please create the account first.", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        new frmAddAccount().ShowDialog();
                        LoadAccountLookup();
                    }
                    return false;
                }
            }
        }

        private bool isItemExists(string v,int rowIndex)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id FROM tbl_items WHERE name = @name",
                        DBClass.CreateParameter("@name", v)))
            {
                if (reader.Read())
                {
                    dgvBatch.Rows[rowIndex].Cells["item_id"].Value = reader["id"].ToString();
                    return true;
                }
                else
                {
                    var dialogResult = MessageBox.Show("Item '" + v + "' does not exist. Please create the item first.", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        new frmViewItem().ShowDialog();
                        LoadAccountLookup();
                    }
                    return false;
                }
            }
        }

        private bool isCustomerExists(string v,int rowIndex)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id FROM tbl_customer WHERE name = @name",
                        DBClass.CreateParameter("@name", v)))
            {
                if (reader.Read())
                {
                    dgvBatch.Rows[rowIndex].Cells["payee_id"].Value = reader["id"].ToString();
                    return true;
                }
                else
                {
                    var dialogResult = MessageBox.Show("Customer '" + v + "' does not exist. Please create the customer first.", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        new frmViewCustomer().ShowDialog();
                        LoadAccountLookup();
                    }
                    return false;
                }
            }
        }


        //public FrmBatchEnterTransactions()
        //{
        //    InitializeComponent();
        //    cmbTranType.SelectedIndex = 0;
        //}
        //private void cmbTranType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadGridColumns(cmbTranType.Text);
        //}

        //private void LoadGridColumns(string tranType)
        //{
        //    dgvBatch.Columns.Clear();

        //    dgvBatch.Columns.Add("tran_date", "Date");
        //    dgvBatch.Columns.Add("party", tranType == "Invoice" ? "Customer" : "Vendor");
        //    dgvBatch.Columns.Add("ref_no", "Ref No");

        //    if (tranType == "Invoice" || tranType == "Credit Memo")
        //    {
        //        dgvBatch.Columns.Add("account", "Income Account");
        //        dgvBatch.Columns.Add("description", "Description");
        //        dgvBatch.Columns.Add("amount", "Amount");
        //    }
        //    else if (tranType == "Bill" || tranType == "Bill Credit")
        //    {
        //        dgvBatch.Columns.Add("expense", "Expense Account");
        //        dgvBatch.Columns.Add("amount", "Amount");
        //        dgvBatch.Columns.Add("due_date", "Due Date");
        //    }
        //    else if (tranType == "Check" || tranType == "Credit Card Charge")
        //    {
        //        dgvBatch.Columns.Add("bank", "Bank / Card");
        //        dgvBatch.Columns.Add("expense", "Expense Account");
        //        dgvBatch.Columns.Add("amount", "Amount");
        //    }
        //    else if (tranType == "Deposit")
        //    {
        //        dgvBatch.Columns.Add("bank", "Bank Account");
        //        dgvBatch.Columns.Add("income", "Income Account");
        //        dgvBatch.Columns.Add("amount", "Amount");
        //    }
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (dgvBatch.Rows.Count == 0) return;

        //    //DBClass.BeginTransaction();

        //    try
        //    {
        //        foreach (DataGridViewRow row in dgvBatch.Rows)
        //        {
        //            if (row.IsNewRow) continue;

        //            DateTime date = Convert.ToDateTime(row.Cells["tran_date"].Value);
        //            string party = row.Cells["party"].Value?.ToString();
        //            string refNo = row.Cells["ref_no"].Value?.ToString();
        //            decimal amount = Convert.ToDecimal(row.Cells["amount"].Value);

        //            int headerId = int.Parse(DBClass.ExecuteScalar(@"
        //                INSERT INTO tbl_transaction_header
        //                (tran_type, tran_date, party_name, ref_no, total_amount)
        //                VALUES (@type, @date, @party, @ref, @amount);
        //                SELECT LAST_INSERT_ID();",
        //                DBClass.CreateParameter("@type", cmbTranType.Text),
        //                DBClass.CreateParameter("@date", date),
        //                DBClass.CreateParameter("@party", party),
        //                DBClass.CreateParameter("@ref", refNo),
        //                DBClass.CreateParameter("@amount", amount)
        //            ).ToString());

        //            DBClass.ExecuteNonQuery(@"
        //                INSERT INTO tbl_transaction_lines
        //                (header_id, description, amount)
        //                VALUES (@hid, @desc, @amt)",
        //                DBClass.CreateParameter("@hid", headerId),
        //                DBClass.CreateParameter("@desc", "Batch Entry"),
        //                DBClass.CreateParameter("@amt", amount)
        //            );

        //            PostTransaction(cmbTranType.Text, amount);
        //        }

        //        //DBClass.CommitTransaction();
        //        MessageBox.Show("Batch saved successfully.");
        //        dgvBatch.Rows.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        //DBClass.RollbackTransaction();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //public void PostTransaction(string type, decimal amount)
        //{
        //    // Example: Invoice
        //    if (type == "Invoice")
        //    {
        //        // DR Accounts Receivable
        //        // CR Revenue
        //    }
        //    else if (type == "Bill")
        //    {
        //        // DR Expense
        //        // CR Accounts Payable
        //    }
        //    // Extend for other types
        //}
    }
}
