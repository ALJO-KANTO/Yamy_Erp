using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using YamyProject.DAL;

namespace YamyProject
{
    public partial class FrmReconciliation : Form
    {
        public FrmReconciliation()
        {
            InitializeComponent();
        }

        private void FrmReconciliation_Load(object sender, EventArgs e)
        {
            EnsureReconciliationTables();
            LoadAccounts();
            dtStatementDate.Value = DateTime.Now.Date;
            // default period (you can wire dtFrom/dtTo pickers)
            dtFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtTo.Value = DateTime.Now.Date;
            AppTheme.DefaultFont(dgvTransactions);
        }

        private void EnsureReconciliationTables()
        {
            // create simple reconciliation tables if they don't exist (safe to run repeatedly)
            DBClass.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS tbl_reconciliation (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    account_id INT NOT NULL,
                    statement_date DATE NOT NULL,
                    ending_balance DECIMAL(18,4) NOT NULL,
                    service_charge DECIMAL(18,4) DEFAULT 0,
                    interest_amount DECIMAL(18,4) DEFAULT 0,
                    created_by INT,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                ) ENGINE=InnoDB;
            ");

            DBClass.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS tbl_reconciliation_item (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    reconciliation_id INT NOT NULL,
                    transaction_id INT NOT NULL,
                    amount DECIMAL(18,4) NOT NULL,
                    cleared_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (reconciliation_id) REFERENCES tbl_reconciliation(id)
                ) ENGINE=InnoDB;
            ");
        }

        private void LoadAccounts()
        {
            cmbAccount.Items.Clear();

            using (var reader = DBClass.ExecuteReader(@"
                SELECT id, CONCAT(code, ' - ', name) AS display
                FROM tbl_coa_level_4
                ORDER BY code;
            "))
            {
                while (reader.Read())
                {
                    cmbAccount.Items.Add(new ComboboxItem
                    {
                        Text = reader["display"].ToString(),
                        Value = reader["id"]
                    });
                }
            }

            if (cmbAccount.Items.Count > 0)
                cmbAccount.SelectedIndex = 0;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!(cmbAccount.SelectedItem is ComboboxItem item)) return;

            int acctId = Convert.ToInt32(item.Value);
            DateTime stmtDate = dtStatementDate.Value.Date;

            // beginning balance = sum(debit - credit) BEFORE the statement date
            decimal beginning = 0;
            using (var r = DBClass.ExecuteReader(@"
                SELECT COALESCE(SUM(debit) - SUM(credit), 0) AS bal
                FROM tbl_transaction
                WHERE account_id = @acctId AND date < @stmtDate AND state = 0;
            ", DBClass.CreateParameter("acctId", acctId), DBClass.CreateParameter("stmtDate", stmtDate)))
            {
                if (r.Read() && r["bal"] != DBNull.Value)
                    beginning = Convert.ToDecimal(r["bal"]);
            }

            lblBeginningBalance.Text = beginning.ToString("N2");
            // load transactions in statement date range
            LoadTransactions(acctId, dtFrom.Value.Date, dtTo.Value.Date);
        }

        private void LoadTransactions(int accountId, DateTime from, DateTime to)
        {
            dgvTransactions.Rows.Clear();
            dgvTransactions.Columns.Clear();

            // Columns: Clear checkbox | Date | Type | Num | Memo | Debit | Credit | Balance | trxId
            dgvTransactions.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "colClear", HeaderText = "Clr", Width = 40 });
            dgvTransactions.Columns.Add("colDate", "Date");
            dgvTransactions.Columns.Add("colType", "Type");
            dgvTransactions.Columns.Add("colNum", "Num");
            dgvTransactions.Columns.Add("colMemo", "Memo");
            dgvTransactions.Columns.Add("colDebit", "Debit");
            dgvTransactions.Columns.Add("colCredit", "Credit");
            dgvTransactions.Columns.Add("colBalance", "Running Balance");
            dgvTransactions.Columns.Add("colTrxId", "trxId");
            dgvTransactions.Columns["colTrxId"].Visible = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Assign relative fill weights (higher = wider)
            dgvTransactions.Columns["colClear"].FillWeight = 30;
            dgvTransactions.Columns["colDate"].FillWeight = 70;
            dgvTransactions.Columns["colType"].FillWeight = 60;
            dgvTransactions.Columns["colNum"].FillWeight = 50;
            dgvTransactions.Columns["colMemo"].FillWeight = 150;
            dgvTransactions.Columns["colDebit"].FillWeight = 70;
            dgvTransactions.Columns["colCredit"].FillWeight = 70;
            dgvTransactions.Columns["colBalance"].FillWeight = 90;
            dgvTransactions.Columns["colDebit"].DefaultCellStyle.Alignment = dgvTransactions.Columns["colCredit"].DefaultCellStyle.Alignment = dgvTransactions.Columns["colBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["colDebit"].HeaderCell.Style.Format = dgvTransactions.Columns["colCredit"].HeaderCell.Style.Format = dgvTransactions.Columns["colBalance"].HeaderCell.Style.Format = "N2";



            // Query transactions for the account and period
            using (var reader = DBClass.ExecuteReader(@"
                SELECT id, date, t_type, transaction_id as num, (select NAME FROM tbl_coa_level_4 WHERE id = account_id)
                        AS name,description memo,
                       COALESCE(debit,0) AS debit, COALESCE(credit,0) AS credit
                FROM tbl_transaction
                WHERE account_id = @acctId AND date BETWEEN @from AND @to AND state = 0
                ORDER BY date, id;
            ",
            DBClass.CreateParameter("acctId", accountId),
            DBClass.CreateParameter("from", from),
            DBClass.CreateParameter("to", to)))
            {
                decimal running = 0;
                while (reader.Read())
                {
                    decimal debit = Convert.ToDecimal(reader["debit"]);
                    decimal credit = Convert.ToDecimal(reader["credit"]);
                    running += debit - credit;

                    dgvTransactions.Rows.Add(false,
                        Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd"),
                        reader["t_type"].ToString(),
                        reader["num"]?.ToString() ?? "",
                        reader["memo"]?.ToString() ?? reader["name"]?.ToString() ?? "",
                        debit == 0 ? "" : debit.ToString("N2"),
                        credit == 0 ? "" : credit.ToString("N2"),
                        running.ToString("N2"),
                        reader["id"].ToString()
                        );
                }
            }
        }

        private void btnSaveReconciliation_Click(object sender, EventArgs e)
        {
            if (!(cmbAccount.SelectedItem is ComboboxItem item)) return;
            int acctId = Convert.ToInt32(item.Value);
            DateTime stmtDate = dtStatementDate.Value.Date;

            decimal endingBalance;
            if (!decimal.TryParse(txtEndingBalance.Text, out endingBalance))
            {
                MessageBox.Show("Enter a valid ending balance.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gather cleared transaction IDs
            var cleared = new List<int>();
            for (int i = 0; i < dgvTransactions.Rows.Count; i++)
            {
                var row = dgvTransactions.Rows[i];
                bool isChecked = Convert.ToBoolean(row.Cells["colClear"].Value ?? false);
                if (isChecked)
                {
                    cleared.Add(Convert.ToInt32(row.Cells["colTrxId"].Value));
                }
            }

            // Insert reconciliation header
            DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_reconciliation (account_id, statement_date, ending_balance, service_charge, interest_amount, created_by)
                VALUES (@acctId, @stmtDate, @ending, @svc, @intAmt, @createdBy);
            ",
            DBClass.CreateParameter("acctId", acctId),
            DBClass.CreateParameter("stmtDate", stmtDate),
            DBClass.CreateParameter("ending", endingBalance),
            DBClass.CreateParameter("svc", Utilities.FormatDecimal(txtServiceCharge.Text)),
            DBClass.CreateParameter("intAmt", Utilities.FormatDecimal(txtInterest.Text)),
            DBClass.CreateParameter("createdBy", frmLogin.userId)
            );

            int recId = GetLastInsertId();

            // Save cleared transaction items
            foreach (var trxId in cleared)
            {
                // get transaction amount for info
                decimal amount = 0;
                using (var r = DBClass.ExecuteReader("SELECT COALESCE(debit,0) - COALESCE(credit,0) AS amt FROM tbl_transaction WHERE id = @id", DBClass.CreateParameter("id", trxId)))
                {
                    if (r.Read() && r["amt"] != DBNull.Value) amount = Convert.ToDecimal(r["amt"]);
                }

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_reconciliation_item (reconciliation_id, transaction_id, amount)
                    VALUES (@recId, @trxId, @amt);
                ",
                DBClass.CreateParameter("recId", recId),
                DBClass.CreateParameter("trxId", trxId),
                DBClass.CreateParameter("amt", amount)
                );
            }

            if (Convert.ToDecimal(txtServiceCharge.Text) != 0 || Convert.ToDecimal(txtInterest.Text) != 0)
            {
                CreateAdjustingJournal(recId, acctId, stmtDate, Convert.ToDecimal(txtServiceCharge.Text), Convert.ToDecimal(txtInterest.Text));
            }

            // reload to reflect cleared items
            LoadTransactions(acctId, dtFrom.Value.Date, dtTo.Value.Date);
            MessageBox.Show("Reconciliation saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateAdjustingJournal(int refId,int bankAccountId, DateTime date, decimal serviceCharge, decimal interest)
        {
            // Service charge: expense debit, bank credit
            if (serviceCharge != 0)
            {
                int svcExpenseAccountId = GetDefaultServiceChargeExpenseAccount(); // implement as needed / or UI select
                //DBClass.ExecuteNonQuery(@"
                //    INSERT INTO tbl_transaction (account_id, transaction_id, t_type, date, debit, credit, memo, state)
                //    VALUES (@acct, @trxId, 'RECONCILIATION', @date, @debit, @credit, @memo, 0);
                //",
                //DBClass.CreateParameter("acct", svcExpenseAccountId),
                //DBClass.CreateParameter("trxId", refId),
                //DBClass.CreateParameter("date", date),
                //DBClass.CreateParameter("debit", serviceCharge),
                //DBClass.CreateParameter("credit", 0),
                //DBClass.CreateParameter("memo", "Service charge (reconciliation)")
                //);
                CommonInsert.addTransactionEntry(date, svcExpenseAccountId.ToString(), serviceCharge.ToString(), "0", refId.ToString(), "0", "Reconciliation", "RECONCILIATION", "Service charge (reconciliation)", frmLogin.userId, DateTime.Now.Date,"");

                //DBClass.ExecuteNonQuery(@"
                //    INSERT INTO tbl_transaction (account_id, transaction_id, t_type, date, debit, credit, memo, state)
                //    VALUES (@acct, @trxId, 'RECONCILIATION', @date, @debit, @credit, @memo, 0);
                //",
                //DBClass.CreateParameter("acct", bankAccountId),
                //DBClass.CreateParameter("trxId", refId),
                //DBClass.CreateParameter("date", date),
                //DBClass.CreateParameter("debit", 0),
                //DBClass.CreateParameter("credit", serviceCharge),
                //DBClass.CreateParameter("memo", "Service charge (reconciliation)")
                //);
                CommonInsert.addTransactionEntry(date, bankAccountId.ToString(), "0", serviceCharge.ToString(), refId.ToString(), "0", "Reconciliation", "RECONCILIATION", "Service charge (reconciliation)", frmLogin.userId, DateTime.Now.Date, "");
            }

            // Interest: bank debit, interest income credit
            if (interest != 0)
            {
                int interestIncomeAccountId = GetDefaultInterestIncomeAccount(); // implement as needed / or UI select
                //DBClass.ExecuteNonQuery(@"
                //    INSERT INTO tbl_transaction (account_id, transaction_id, t_type, date, debit, credit, memo, state)
                //    VALUES (@acct, @trxId, 'JOURNAL', @date, @debit, @credit, @memo, 0);
                //",
                //DBClass.CreateParameter("acct", bankAccountId),
                //DBClass.CreateParameter("trxId", refId),
                //DBClass.CreateParameter("date", date),
                //DBClass.CreateParameter("debit", interest),
                //DBClass.CreateParameter("credit", 0),
                //DBClass.CreateParameter("memo", "Interest earned (reconciliation)")
                //);
                CommonInsert.addTransactionEntry(date, bankAccountId.ToString(), interest.ToString(), "0", refId.ToString(), "0", "Reconciliation", "RECONCILIATION", "Interest earned (reconciliation)", frmLogin.userId, DateTime.Now.Date, "");


                //DBClass.ExecuteNonQuery(@"
                //    INSERT INTO tbl_transaction (account_id, transaction_id, t_type, date, debit, credit, memo, state)
                //    VALUES (@acct, @trxId, 'JOURNAL', @date, @debit, @credit, @memo, 0);
                //",
                //DBClass.CreateParameter("acct", interestIncomeAccountId),
                //DBClass.CreateParameter("trxId", refId),
                //DBClass.CreateParameter("date", date),
                //DBClass.CreateParameter("debit", 0),
                //DBClass.CreateParameter("credit", interest),
                //DBClass.CreateParameter("memo", "Interest earned (reconciliation)")
                //);
                CommonInsert.addTransactionEntry(date, interestIncomeAccountId.ToString(), "0", interest.ToString(), refId.ToString(), "0", "Reconciliation", "RECONCILIATION", "Interest earned (reconciliation)", frmLogin.userId, DateTime.Now.Date, "");
            }
        }

        private int GetLastInsertId()
        {
            using (var r = DBClass.ExecuteReader("SELECT LAST_INSERT_ID() AS id;"))
            {
                if (r.Read() && r["id"] != DBNull.Value)
                    return Convert.ToInt32(r["id"]);
            }
            return 0;
        }

        // Replace these with UI selected accounts or configuration
        private int GetDefaultServiceChargeExpenseAccount()
        {
            // fallback to an expense account id, adjust as needed
            using (var r = DBClass.ExecuteReader("SELECT id FROM tbl_coa_level_4 WHERE code = '6101002' LIMIT 1;"))
            {
                if (r.Read() && r["id"] != DBNull.Value) return Convert.ToInt32(r["id"]);
            }
            return 0;
        }

        private int GetDefaultInterestIncomeAccount()
        {
            using (var r = DBClass.ExecuteReader("SELECT id FROM tbl_coa_level_4 WHERE code = '4101003' LIMIT 1;"))
            {
                if (r.Read() && r["id"] != DBNull.Value) return Convert.ToInt32(r["id"]);
            }
            return 0;
        }

        private void TextBox_NumericOnly(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits and a single decimal point
            TextBox textBox = sender as TextBox;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // reject other characters
            }
            else if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true; // only one decimal point allowed
            }
        }

    }

    // small helper for combobox items
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString() { return Text; }
    }
}