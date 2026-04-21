using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;

namespace YamyProject.UI.Banking
{
    public partial class frmWriteCheque : Form
    {
        int id;
        public frmWriteCheque(int _id=0)
        {
            InitializeComponent();
            headerUC1.FormText = "Write Cheque";
            this.id = _id;
        }

        private void frmWriteCheque_Load(object sender, EventArgs e)
        {
            txtId.Text = txtPVCode.Text = GenerateNextId().ToString();
            AppTheme.DefaultFont(dgvExpenses);
            DataTable dt = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_coa_level_4 WHERE main_id = 1");
            cmbBankAccount.DataSource = dt;
            cmbBankAccount.ValueMember = "id";
            cmbBankAccount.DisplayMember = "name";
        }

        private int GenerateNextId()
        {
            int newCode = 0;

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_batch_transaction"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    newCode = int.Parse(reader["lastCode"].ToString());
                }
            }

            return newCode;
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text);
            if (currentId == null || currentId <= 1)
                return;

            currentId = currentId - 1;
            txtId.Text = currentId.ToString();
            if (currentId <= 0)
            {
                clear();
                MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string query = "select id from tbl_batch_transaction where tran_type = 'Checks' and id =@id";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindVoucher();
                }
                else
                {
                    clear();
                    MessageBox.Show("No previous record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            txtId.Text = currentId.ToString();
            string query = "SELECT id FROM tbl_batch_transaction where tran_type = 'Checks' AND id =@id";
            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
            {
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindVoucher();
                }
                else
                {
                    clear();
                    MessageBox.Show("No next record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BindVoucher()
        {
            dgvExpenses.Rows.Clear();
            dgvItems.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_batch_transaction where tran_type = 'Checks' and id = @id ", DBClass.CreateParameter("@id", id)))
            {
                if (reader.Read())
                {
                    txtPVCode.Text = reader["id"].ToString();
                    dtOpen.Value = Convert.ToDateTime(reader["tran_date"]);
                    cmbBankAccount.SelectedValue = Convert.ToInt32(reader["account_id"]);
                    int refNo = Convert.ToInt32(reader["ref_no"]);
                    txtMemo.Text = reader["status"].ToString();
                    using (MySqlDataReader refReader = DBClass.ExecuteReader(@"SELECT d.id, d.tran_id,
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
                                    WHERE d.tran_id = @refId ", DBClass.CreateParameter("@refId", refNo)))
                    {
                        while (refReader.Read())
                        {
                            // id,payee_id, account_id, item_id, description, qty, rate, amount, tax_code, tax_item, tax_amount, terms, bill_due, check_no
                            // expId, Account, account_id, Amount, Memo, customer_job, payee_id, billable
                            if (!string.IsNullOrWhiteSpace(refReader["account_name"].ToString()))
                                dgvExpenses.Rows.Add(refReader["id"], refReader["account_name"], refReader["account_id"], refReader["amount"], refReader["description"], refReader["payee_name"], refReader["payee_id"]);
                            // Id_item, item, item_id, Description, qty, cost, item_amount, item_customer_job, item_customer_id, item_billable
                            if (!string.IsNullOrWhiteSpace(refReader["item_name"].ToString())) 
                                dgvItems.Rows.Add(refReader["id"], refReader["item_name"], refReader["item_id"], refReader["description"], refReader["qty"], refReader["rate"], refReader["amount"], refReader["payee_name"]);
                        }
                    }

                    calculateTotal();
                }
            }
        }

        private void clear()
        {
            txtMemo.Clear();
            txtBalance.Clear();
            totalAmount = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateData())
            {
                try
                {
                    string cmbTranType = "Checks";
                    string account = "", description = "", terms = "", item = "";
                    decimal qty = 0, rate = 0, taxAmount = 0, total = 0;
                    string taxCode = "", taxItem = "", bill_due = "", check_no = "";

                    if (id != 0)
                    {
                        foreach (DataGridViewRow row in dgvExpenses.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // --- Common fields ---
                            DateTime tranDate = Convert.ToDateTime(row.Cells["date"].Value);
                            decimal amount = Convert.ToDecimal(row.Cells["amount"].Value);

                            if (cmbTranType == "Checks")
                            {
                                account = row.Cells["account"].Value.ToString() ?? "0";
                                description = row.Cells["memo"].Value != null ? row.Cells["memo"].Value.ToString() : "";
                            }
                        }
                        // Update existing record logic here
                        MessageBox.Show("Cheques updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    foreach (DataGridViewRow row in dgvExpenses.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // --- Common fields ---
                        DateTime tranDate = Convert.ToDateTime(row.Cells["date"].Value);
                        decimal amount = Convert.ToDecimal(row.Cells["amount"].Value);

                        
                        if (cmbTranType == "Checks")
                        {
                            account = row.Cells["account"].Value.ToString() ?? "0";
                            description = row.Cells["memo"].Value != null ? row.Cells["memo"].Value.ToString() : "";
                        }
                        //else if (cmbTranType == "Invoices & Credit Memos")
                        //{
                        //    terms = row.Cells["terms"].Value.ToString() ?? "";
                        //    description = row.Cells["description"].Value.ToString() ?? "";
                        //    item = row.Cells["item"].Value.ToString() ?? "";
                        //    qty = Convert.ToDecimal(row.Cells["qty"].Value);
                        //    rate = Convert.ToDecimal(row.Cells["rate"].Value);
                        //    taxCode = row.Cells["tax code"].Value.ToString() ?? "";
                        //    taxItem = row.Cells["tax item"].Value.ToString() ?? "";
                        //    taxAmount = Convert.ToDecimal(row.Cells["tax amount"].Value);
                        //    total = Convert.ToDecimal(row.Cells["total"].Value);
                        //}
                        //else if (cmbTranType == "Bills & Bill Credits")
                        //{
                        //    terms = row.Cells["terms"].Value.ToString() ?? "";
                        //    bill_due = row.Cells["bill_due"].Value.ToString() ?? "";
                        //    account = row.Cells["account"].Value.ToString() ?? "";
                        //    description = row.Cells["memo"].Value.ToString() ?? "";
                        //}
                        //else if (cmbTranType == "Credit Card Charges & Credits")
                        //{
                        //    account = row.Cells["account"].Value.ToString() ?? "";
                        //    description = row.Cells["memo"].Value.ToString() ?? "";
                        //}
                        //else if (cmbTranType == "Deposits")
                        //{
                        //    account = row.Cells["account from"].Value.ToString() ?? "0";
                        //    description = row.Cells["memo"].Value.ToString() ?? "";
                        //    check_no = row.Cells["check no"].Value.ToString() ?? "";
                        //}

                        string refNo = txtId.Text;
                        string party = row.Cells["payee_id"].Value.ToString();
                        string partyId = row.Cells["payee_id"].Value.ToString();
                        int account_id = 0;
                        //---Insert header-- -
                        int headerId = Convert.ToInt32(
                                DBClass.ExecuteScalar(@"
                            INSERT INTO tbl_batch_transaction
                            (tran_type, tran_date, account_id, ref_no, total_amount)
                            VALUES (@type, @date,@accountId, @ref, @amount);
                            SELECT LAST_INSERT_ID();",
                                DBClass.CreateParameter("@type", cmbTranType),
                                DBClass.CreateParameter("@date", tranDate),
                                DBClass.CreateParameter("@accountId", account_id),
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

                        PostTransaction(cmbTranType, headerId, amount, tranDate, account_id);
                    }

                    //DBClass.CommitTransaction();
                    MessageBox.Show("Batch saved successfully.");
                }
                catch (Exception ex)
                {
                    //DBClass.RollbackTransaction();
                    MessageBox.Show(ex.Message);
                }
                // Save logic here
                MessageBox.Show("Cheque saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void PostTransaction(string type, int headerId, decimal amount, DateTime tranDate, int account_id)
        {
            // Example: Invoice
            if (type == "Checks")
            {
                // DR Expense
                // CR Bank
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Checks of Bank", frmLogin.userId, DateTime.Now.Date, "");
                CommonInsert.addTransactionEntry(tranDate, cmbBankAccount.SelectedValue.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Checks of Bank", frmLogin.userId, DateTime.Now.Date, "");
            }
            else if (type == "Deposits")
            {
                // DR Bank
                // CR Revenue
                CommonInsert.addTransactionEntry(tranDate, cmbBankAccount.SelectedValue.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Deposits of Bank", frmLogin.userId, DateTime.Now, "");
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Deposits of Bank", frmLogin.userId, DateTime.Now.Date, "");
            }
            else if (type == "Credit Card Charges & Credits")
            {
                // DR Expense
                // CR Credit Card Liability
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Credit Card Charges & Credits", frmLogin.userId, DateTime.Now.Date, "");
                CommonInsert.addTransactionEntry(tranDate, cmbBankAccount.SelectedValue.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Credit Card Charges & Credits", frmLogin.userId, DateTime.Now, "");
            }
            else
            if (type == "Invoices & Credit Memos")
            {
                // DR Accounts Receivable
                // CR Revenue
                CommonInsert.addTransactionEntry(tranDate, cmbBankAccount.SelectedValue.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Invoices & Credit Memos", frmLogin.userId, DateTime.Now, "");
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Invoices & Credit Memos", frmLogin.userId, DateTime.Now.Date, "");
            }
            else if (type == "Bills & Bill Credits")
            {
                // DR Expense
                // CR Accounts Payable
                CommonInsert.addTransactionEntry(tranDate, account_id.ToString(), amount.ToString(), "0", headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Bills & Bill Credits", frmLogin.userId, DateTime.Now.Date, "");
                CommonInsert.addTransactionEntry(tranDate, cmbBankAccount.SelectedValue.ToString(), "0", amount.ToString(), headerId.ToString(), "0", "Batch Transaction " + type, "Batch Transaction " + type, "Bills & Bill Credits", frmLogin.userId, DateTime.Now, "");
            }
            // Extend for other types
        }

        private bool ValidateData()
        {
            if(string.IsNullOrWhiteSpace(txtPVCode.Text))
            {
                MessageBox.Show("PV Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cmbBankAccount.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a bank account.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(dgvExpenses.Rows.Count == 0)
            {
                MessageBox.Show("At least one expense entry is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            txtId.Text = txtPVCode.Text = GenerateNextId().ToString();
            id = 0;
            dgvItems.Rows.Clear();
            dgvExpenses.Rows.Clear();
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                txtAmountInWord.Text = "";
                return;
            }
            txtAmountInWord.Text = AmountToWordsHelper.ConvertToSelectedLanguage(decimal.Parse(txtAmount.Text));
        }
        decimal totalAmount = 0;
        private void calculateTotal()
        {
            for (int i = 0; i < dgvExpenses.Rows.Count; i++)
            {
                if (dgvExpenses.Rows[i].Cells["amount"].Value ==null || dgvExpenses.Rows[i].Cells["amount"].Value.ToString() == "" || dgvExpenses.CurrentRow.Cells["amount"].Value.ToString() == "")
                    continue;
                totalAmount += decimal.Parse(dgvExpenses.Rows[i].Cells["amount"].Value.ToString());
            }
            txtAmount.Text = totalAmount.ToString();
            totalAmount = 0;
        }

        private void dgvExpenses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExpenses.Rows.Count <= 0)
                return;
            if (dgvExpenses.CurrentRow == null)
                return;

            calculateTotal();
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.Rows.Count <= 0)
                return;
            if (dgvItems.CurrentRow == null)
                return;

            calculateTotal();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            id = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
