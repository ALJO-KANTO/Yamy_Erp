using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectPaymentVoucher : Form
    {
        private int selectedId = 0;
        int Id = 0;
        string ReceiptCode = "";
        int level4VatId = 0, level4RetentionAccount = 0;
        public frmProjectPaymentVoucher(int id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            Id = id;
        }

        private void frmProjectPaymentVoucher_Load(object sender, EventArgs e)
        {
            LoadPaymentSources();
            LoadProjects();
            LoadEngineers();
            LoadClientOwner();
            ClearForm();

            LoadDebitAc();
            BindCombos.PopulateAllLevel4Account(cmbCreditAccountName, false);
            BindCombos.PopulateAllLevel4Account(cmbDesignRevenue, false);
            BindCombos.PopulateAllLevel4Account(cmbSupervisionRevenue, false);

            //ReceiptId = Convert.ToInt32(GenerateNextReceiptId());
            ReceiptCode = GenerateNextReceiptCode();

            level4VatId = frmLogin.defaultAccounts.ContainsKey("Vat Output") ? frmLogin.defaultAccounts["Vat Output"] : 0;
            level4RetentionAccount = frmLogin.defaultAccounts.ContainsKey("Retention") ? frmLogin.defaultAccounts["Retention"] : 0;

            if (Id > 0)
            {
                selectedId = Id;
                LoadSingleRecord(selectedId);
            }
        }

        private void LoadDebitAc()
        {
            string query = @"";
            if (cmbPaymentSource.SelectedItem.ToString() != "Bank")
            {
                query = @"SELECT l4.id, l4.code, l4.name from tbl_coa_level_4 l4 
                            INNER JOIN tbl_coa_level_3 l3 ON l4.main_id = l3.id 
                            INNER JOIN tbl_coa_level_2 l2 ON l3.main_id = l2.id 
                            INNER JOIN tbl_coa_level_1 l1 ON l2.main_id = l1.id 
                            WHERE l1.category_code='ASSET' ORDER BY NAME ";
            } else
                query = @"SELECT id, code, name FROM tbl_coa_level_4 ORDER BY name";
            
            cmbDebitAccountName.DataSource = DBClass.ExecuteDataTable(query);
            cmbDebitAccountName.DisplayMember = "name";
            cmbDebitAccountName.ValueMember = "id";
            cmbDebitAccountName.SelectedIndex = -1;
            cmbDebitAccountName.SelectedValue = (frmLogin.defaultAccounts.ContainsKey("Default Account For Bank") ? frmLogin.defaultAccounts["Default Account For Bank"] : 0);
        }

        private string GenerateNextReceiptId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_project_payments"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }
        private string GenerateNextReceiptCode()
        {
            string newCode = "PV-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(code, 4) AS UNSIGNED)) AS lastCode FROM tbl_project_payments"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "PV-" + code.ToString("D4");
                }
            }

            return newCode;
        }
        private void LoadPaymentSources()
        {
            cmbPaymentSource.SelectedIndex = 0;
        }
        private void LoadProjects()
        {
            try
            {

                string query = @"
                        SELECT 0 AS id, '--- Select Project ---' AS name
                        UNION ALL
                        SELECT id, name FROM tbl_projects
                        ORDER BY id";

                DataTable dt = DBClass.ExecuteDataTable(query);

                cmbProject.DataSource = dt;
                cmbProject.DisplayMember = "name";
                cmbProject.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadProjects Error: " + ex.Message);
            }
        }

        private void LoadEngineers()
        {
            try
            {
                string query = @"
                        SELECT 0 AS id, '--- Select Engineer ---' AS name
                        UNION ALL
                        SELECT id, name FROM tbl_engineers
                        ORDER BY id";

                DataTable dt = DBClass.ExecuteDataTable(query);

                cmbEngineer.DataSource = dt;
                cmbEngineer.DisplayMember = "name";
                cmbEngineer.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadEngineers Error: " + ex.Message);
            }
        }

        private void LoadClientOwner()
        {
            try
            {
                string query = @"
                        SELECT 0 AS id, '--- Select Client / Owner ---' AS name
                        UNION ALL
                        SELECT id, name FROM tbl_customer
                        ORDER BY id";

                DataTable dt = DBClass.ExecuteDataTable(query);

                cmbClientOwner.DataSource = dt;
                cmbClientOwner.DisplayMember = "name";
                cmbClientOwner.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Client/Owner Error: " + ex.Message);
            }
        }
        private decimal GetDecimal(Guna2TextBox txt)
        {
            decimal.TryParse(txt.Text.Trim(), out decimal val);
            return val;
        }

        private void SetDecimal(Guna2TextBox txt, decimal value)
        {
            txt.Text = value.ToString("0.00");
        }

        private void CalculateAll()
        {
            try
            {
                decimal projectValue = GetDecimal(txtProjectValue);
                decimal consultancyPercentage = GetDecimal(txtConsultancyPercentage);

                // Consultancy Fee
                decimal consultancyFee = (projectValue * consultancyPercentage) / 100m;
                SetDecimal(txtConsultancyFee, consultancyFee);

                // Design Balance = Design Fee + Design Tax - Design Received - Design Tax Received
                decimal designFee = GetDecimal(txtDesignFee);
                decimal designReceived = GetDecimal(txtDesignReceived);
                decimal designTax = GetDecimal(txtDesignTax);
                decimal designTaxReceived = GetDecimal(txtDesignTaxReceived);

                decimal designBalance = (designFee + designTax) - (designReceived + designTaxReceived);
                SetDecimal(txtDesignBalance, designBalance);

                // Supervision Payment Value = Supervision Fee * Received%
                decimal supervisionFee = GetDecimal(txtSupervisionFee);
                decimal supervisionReceivedPercentage = GetDecimal(txtSupervisionReceivedPercentage);
                decimal supervisionPaymentValue = (supervisionFee * supervisionReceivedPercentage) / 100m;
                SetDecimal(txtSupervisionPaymentValue, supervisionPaymentValue);

                // Retention
                decimal retentionPercentage = GetDecimal(txtRetentionPercentage);
                decimal retentionAmount = (supervisionPaymentValue * retentionPercentage) / 100m;
                SetDecimal(txtRetentionAmount, retentionAmount);

                // After Retention
                decimal afterRetention = supervisionPaymentValue - retentionAmount;
                SetDecimal(txtSupervisionReceivedAfterRetention, afterRetention);

                // Supervision Balance = Supervision Fee + Sup Tax - After Retention - Sup Tax Received
                decimal supervisionTax = GetDecimal(txtSupervisionTax);
                decimal supervisionTaxReceived = GetDecimal(txtSupervisionTaxReceived);

                decimal supervisionBalance = (supervisionFee + supervisionTax) - (afterRetention + supervisionTaxReceived);
                SetDecimal(txtSupervisionBalance, supervisionBalance);
            }
            catch
            {
                // prevent UI crash during typing
            }
        }

        private bool ValidateForm()
        {
            if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
            {
                MessageBox.Show("Please select project.");
                cmbProject.Focus();
                return false;
            }
            else if (cmbClientOwner.SelectedValue == null || Convert.ToInt32(cmbClientOwner.SelectedValue) == 0)
            {
                MessageBox.Show("Please select client/owner.");
                return false;
            }
            else if (string.IsNullOrEmpty(cmbPaymentSource.Text))
            {
                MessageBox.Show("Please select payment source.");
                cmbPaymentSource.Focus();
                return false;
            }
            else if (GetDecimal(txtProjectValue) <= 0)
            {
                MessageBox.Show("Project value must be greater than zero.");
                txtProjectValue.Focus();
                return false;
            }
            else if (cmbCreditAccountName.SelectedValue == null || Convert.ToInt32(cmbCreditAccountName.SelectedValue) == 0)
            {
                MessageBox.Show("Please select credit account.");
                cmbCreditAccountName.Focus();
                return false;
            }
            else if (cmbDesignRevenue.SelectedValue == null || Convert.ToInt32(cmbDesignRevenue.SelectedValue) == 0)
            {
                MessageBox.Show("Please select design revenue account.");
                cmbDesignRevenue.Focus();
                return false;
            }
            else if (cmbSupervisionRevenue.SelectedValue == null || Convert.ToInt32(cmbSupervisionRevenue.SelectedValue) == 0)
            {
                MessageBox.Show("Please select supervision revenue account.");
                cmbSupervisionRevenue.Focus();
                return false;
            }
            else if (cmbDebitAccountName.SelectedValue == null || Convert.ToInt32(cmbDebitAccountName.SelectedValue) == 0)
            {
                MessageBox.Show("Please select debit account.");
                cmbDebitAccountName.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedId = 0;

            dtpPaymentDate.Value = DateTime.Now;

            if (cmbProject.Items.Count > 0) cmbProject.SelectedIndex = 0;
            if (cmbEngineer.Items.Count > 0) cmbEngineer.SelectedIndex = 0;
            if (cmbClientOwner.Items.Count > 0) cmbClientOwner.SelectedIndex = 0;
            if (cmbPaymentSource.Items.Count > 0) cmbPaymentSource.SelectedIndex = 0;

            txtProjectValue.Text = "0.00";
            txtConsultancyPercentage.Text = "0.00";
            txtConsultancyFee.Text = "0.00";

            txtDesignFee.Text = "0.00";
            txtDesignReceived.Text = "0.00";
            txtDesignTax.Text = "0.00";
            txtDesignTaxReceived.Text = "0.00";
            txtDesignBalance.Text = "0.00";

            txtSupervisionFee.Text = "0.00";
            txtSupervisionReceivedPercentage.Text = "0.00";
            txtSupervisionPaymentValue.Text = "0.00";
            txtRetentionPercentage.Text = "10.00";
            txtRetentionAmount.Text = "0.00";
            txtSupervisionReceivedAfterRetention.Text = "0.00";
            txtSupervisionTax.Text = "0.00";
            txtSupervisionTaxReceived.Text = "0.00";
            txtSupervisionBalance.Text = "0.00";

            txtRemarks.Text = "";
            //ReceiptId = Convert.ToInt32(GenerateNextReceiptId());
            ReceiptCode = GenerateNextReceiptCode();
            CalculateAll();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                string query = @"
                        INSERT INTO tbl_project_payments
                        (
                            code,payment_date, project_id, engineer_id, client_id,
                            payment_source, project_value, consultancy_percentage, consultancy_fee,
                            design_fee, design_received, design_tax, design_tax_received, design_balance,
                            supervision_fee, supervision_received_percentage, supervision_payment_value,
                            retention_percentage, retention_amount, supervision_received_after_retention,
                            supervision_tax, supervision_tax_received, supervision_balance,
                            remarks, debit_account_id, credit_account_id, design_revenue_account_id, supervision_revenue_account_id
                        )
                        VALUES
                        (
                            @code, @payment_date, @project_id, @engineer_id, @client_id,
                            @payment_source, @project_value, @consultancy_percentage, @consultancy_fee,
                            @design_fee, @design_received, @design_tax, @design_tax_received, @design_balance,
                            @supervision_fee, @supervision_received_percentage, @supervision_payment_value,
                            @retention_percentage, @retention_amount, @supervision_received_after_retention,
                            @supervision_tax, @supervision_tax_received, @supervision_balance,
                            @remarks, @debit_account_id, @credit_account_id, @design_revenue_account_id, @supervision_revenue_account_id
                        );SELECT LAST_INSERT_ID();";

                List<MySqlParameter> parameters = new List<MySqlParameter>();
                FillParameters(parameters);
                parameters.Add(DBClass.CreateParameter("@code", ReceiptCode));
                int invId = Convert.ToInt32(DBClass.ExecuteScalar(query, parameters.ToArray()));
                InsertProjectPaymentJournals(invId);

                MessageBox.Show("Saved successfully.");
                //LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            if (!ValidateForm()) return;

            try
            {
                string query = @"
                        UPDATE tbl_project_payments SET
                            payment_date = @payment_date,
                            project_id = @project_id,
                            engineer_id = @engineer_id,
                            client_id = @client_id,
                            payment_source = @payment_source,
                            project_value = @project_value,
                            consultancy_percentage = @consultancy_percentage,
                            consultancy_fee = @consultancy_fee,
                            design_fee = @design_fee,
                            design_received = @design_received,
                            design_tax = @design_tax,
                            design_tax_received = @design_tax_received,
                            design_balance = @design_balance,
                            supervision_fee = @supervision_fee,
                            supervision_received_percentage = @supervision_received_percentage,
                            supervision_payment_value = @supervision_payment_value,
                            retention_percentage = @retention_percentage,
                            retention_amount = @retention_amount,
                            supervision_received_after_retention = @supervision_received_after_retention,
                            supervision_tax = @supervision_tax,
                            supervision_tax_received = @supervision_tax_received,
                            supervision_balance = @supervision_balance,
                            remarks = @remarks,
                            debit_account_id = @debit_account_id,
                            credit_account_id = @credit_account_id,
                            design_revenue_account_id = @design_revenue_account_id,
                            supervision_revenue_account_id = @supervision_revenue_account_id
                        WHERE id = @id";

                List<MySqlParameter> parameters = new List<MySqlParameter>();
                FillParameters(parameters);
                parameters.Add(DBClass.CreateParameter("@id", selectedId));
                DBClass.ExecuteNonQuery(query, parameters.ToArray());
                InsertProjectPaymentJournals(selectedId);

                MessageBox.Show("Updated successfully.");
                //LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }
        private void InsertProjectPaymentJournals(int paymentId)
        {
            try
            {
                string voucherNo = "PP-" + paymentId.ToString(); // or your code field
                string voucherType = "PROJECT PAYMENT";

                // IMPORTANT: replace these with actual account IDs from your chart of accounts
                string bankAccountId = cmbDebitAccountName.SelectedValue.ToString();                // Bank / Cash
                string designRevenueAccountId = cmbDesignRevenue.SelectedValue.ToString();       // Design Revenue
                string supervisionRevenueAccountId = cmbSupervisionRevenue.SelectedValue.ToString();  // Supervision Revenue
                string vatOutputAccountId = level4VatId.ToString();           // Output VAT Payable
                string retentionReceivableAccountId = level4RetentionAccount.ToString(); // Retention Receivable

                decimal designReceived = GetDecimal(txtDesignReceived);
                decimal designTaxReceived = GetDecimal(txtDesignTaxReceived);

                decimal supervisionPaymentValue = GetDecimal(txtSupervisionPaymentValue);
                decimal retentionAmount = GetDecimal(txtRetentionAmount);
                decimal supervisionReceivedAfterRetention = GetDecimal(txtSupervisionReceivedAfterRetention);
                decimal supervisionTaxReceived = GetDecimal(txtSupervisionTaxReceived);

                // 1) DESIGN RECEIPT
                if (designReceived > 0)
                {
                    InsertDoubleJournal(
                        dtpPaymentDate.Value.Date,
                        bankAccountId,
                        designRevenueAccountId,
                        designReceived,
                        paymentId,
                        voucherType,
                        "Design receipt for project payment #" + paymentId,
                        voucherNo
                    );
                }

                // 2) DESIGN VAT RECEIVED
                if (designTaxReceived > 0)
                {
                    InsertDoubleJournal(
                        dtpPaymentDate.Value.Date,
                        bankAccountId,
                        vatOutputAccountId,
                        designTaxReceived,
                        paymentId,
                        voucherType,
                        "Design VAT received for project payment #" + paymentId,
                        voucherNo
                    );
                }

                // 3) SUPERVISION RECEIPT WITH RETENTION
                if (supervisionPaymentValue > 0)
                {
                    InsertSupervisionJournalWithRetention(
                        dtpPaymentDate.Value.Date,
                        bankAccountId,
                        retentionReceivableAccountId,
                        supervisionRevenueAccountId,
                        supervisionReceivedAfterRetention,
                        retentionAmount,
                        supervisionPaymentValue,
                        paymentId,
                        voucherType,
                        "Supervision receipt with retention for project payment #" + paymentId,
                        voucherNo
                    );
                }

                // 4) SUPERVISION VAT RECEIVED
                if (supervisionTaxReceived > 0)
                {
                    InsertDoubleJournal(
                        dtpPaymentDate.Value.Date,
                        bankAccountId,
                        vatOutputAccountId,
                        supervisionTaxReceived,
                        paymentId,
                        voucherType,
                        "Supervision VAT received for project payment #" + paymentId,
                        voucherNo
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Journal Insert Error: " + ex.Message);
            }
        }
        private void InsertDoubleJournal(DateTime trxDate,
                                 string debitAccountId,
                                 string creditAccountId,
                                 decimal amount,
                                 int refId,
                                 string voucherType,
                                 string description,
                                 string voucherNo)
        {
            if (amount <= 0) return;

            CommonInsert.addTransactionEntry(
                trxDate,
                debitAccountId,
                amount.ToString("0.00"),
                "0",
                refId.ToString(),
                "0",
                voucherType,
                voucherType,
                description,
                frmLogin.userId,
                DateTime.Now.Date,
                voucherNo, 
                Convert.ToInt32(cmbProject.SelectedValue)
            );

            CommonInsert.addTransactionEntry(
                trxDate,
                creditAccountId,
                "0",
                amount.ToString("0.00"),
                refId.ToString(),
                "0",
                voucherType,
                voucherType,
                description,
                frmLogin.userId,
                DateTime.Now.Date,
                voucherNo, 
                Convert.ToInt32(cmbProject.SelectedValue)
            );
        }
        private void InsertSupervisionJournalWithRetention(DateTime trxDate,
                                                   string bankAccountId,
                                                   string retentionReceivableAccountId,
                                                   string supervisionRevenueAccountId,
                                                   decimal bankReceived,
                                                   decimal retentionAmount,
                                                   decimal totalRevenue,
                                                   int refId,
                                                   string voucherType,
                                                   string description,
                                                   string voucherNo)
        {
            if (totalRevenue <= 0) return;

            // Debit Bank (actual received)
            if (bankReceived > 0)
            {
                CommonInsert.addTransactionEntry(
                    trxDate,
                    bankAccountId,
                    bankReceived.ToString("0.00"),
                    "0",
                    refId.ToString(),
                    "0",
                    voucherType,
                    voucherType,
                    description + " - Bank Portion",
                    frmLogin.userId,
                    DateTime.Now.Date,
                    voucherNo, 
                    Convert.ToInt32(cmbProject.SelectedValue)
                );
            }

            // Debit Retention Receivable (withheld by client)
            if (retentionAmount > 0)
            {
                CommonInsert.addTransactionEntry(
                    trxDate,
                    retentionReceivableAccountId,
                    retentionAmount.ToString("0.00"),
                    "0",
                    refId.ToString(),
                    "0",
                    voucherType,
                    voucherType,
                    description + " - Retention Portion",
                    frmLogin.userId,
                    DateTime.Now.Date,
                    voucherNo, 
                    Convert.ToInt32(cmbProject.SelectedValue)
                );
            }

            // Credit Supervision Revenue (full earned amount)
            CommonInsert.addTransactionEntry(
                trxDate,
                supervisionRevenueAccountId,
                "0",
                totalRevenue.ToString("0.00"),
                refId.ToString(),
                "0",
                voucherType,
                voucherType,
                description + " - Revenue",
                frmLogin.userId,
                DateTime.Now.Date,
                voucherNo, 
                Convert.ToInt32(cmbProject.SelectedValue)
            );
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {

                string query = "DELETE FROM tbl_project_payments WHERE id = @id";
                DBClass.ExecuteNonQuery(query, DBClass.CreateParameter("@id", selectedId));
                CommonInsert.DeleteTransactionEntry(selectedId, "PROJECT PAYMENT");

                MessageBox.Show("Deleted successfully.");
                //LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private void FillParameters(List<MySqlParameter> parameters)
        {
            parameters.Add(DBClass.CreateParameter("@payment_date", dtpPaymentDate.Value.Date));
            parameters.Add(DBClass.CreateParameter("@project_id", Convert.ToInt32(cmbProject.SelectedValue)));
            parameters.Add(DBClass.CreateParameter("@engineer_id", Convert.ToInt32(cmbEngineer.SelectedValue)));
            parameters.Add(DBClass.CreateParameter("@client_id", Convert.ToInt32(cmbClientOwner.SelectedValue)));
            parameters.Add(DBClass.CreateParameter("@payment_source", cmbPaymentSource.Text.Trim()));

            parameters.Add(DBClass.CreateParameter("@project_value", GetDecimal(txtProjectValue)));
            parameters.Add(DBClass.CreateParameter("@consultancy_percentage", GetDecimal(txtConsultancyPercentage)));
            parameters.Add(DBClass.CreateParameter("@consultancy_fee", GetDecimal(txtConsultancyFee)));

            parameters.Add(DBClass.CreateParameter("@design_fee", GetDecimal(txtDesignFee)));
            parameters.Add(DBClass.CreateParameter("@design_received", GetDecimal(txtDesignReceived)));
            parameters.Add(DBClass.CreateParameter("@design_tax", GetDecimal(txtDesignTax)));
            parameters.Add(DBClass.CreateParameter("@design_tax_received", GetDecimal(txtDesignTaxReceived)));
            parameters.Add(DBClass.CreateParameter("@design_balance", GetDecimal(txtDesignBalance)));

            parameters.Add(DBClass.CreateParameter("@supervision_fee", GetDecimal(txtSupervisionFee)));
            parameters.Add(DBClass.CreateParameter("@supervision_received_percentage", GetDecimal(txtSupervisionReceivedPercentage)));
            parameters.Add(DBClass.CreateParameter("@supervision_payment_value", GetDecimal(txtSupervisionPaymentValue)));
            parameters.Add(DBClass.CreateParameter("@retention_percentage", GetDecimal(txtRetentionPercentage)));
            parameters.Add(DBClass.CreateParameter("@retention_amount", GetDecimal(txtRetentionAmount)));
            parameters.Add(DBClass.CreateParameter("@supervision_received_after_retention", GetDecimal(txtSupervisionReceivedAfterRetention)));
            parameters.Add(DBClass.CreateParameter("@supervision_tax", GetDecimal(txtSupervisionTax)));
            parameters.Add(DBClass.CreateParameter("@supervision_tax_received", GetDecimal(txtSupervisionTaxReceived)));
            parameters.Add(DBClass.CreateParameter("@supervision_balance", GetDecimal(txtSupervisionBalance)));
            parameters.Add(DBClass.CreateParameter("@remarks", txtRemarks.Text.Trim()));
        }
        //private void LoadData()
        //{
        //    try
        //    {
        //        string query = @"
        //                SELECT 
        //                    p.id,
        //                    p.payment_date,
        //                    pr.name AS project_name,
        //                    e.name AS engineer_name,
        //                    s.name AS `Client / Owner`,
        //                    p.payment_source,
        //                    p.project_value,
        //                    p.consultancy_percentage,
        //                    p.consultancy_fee,
        //                    p.design_fee,
        //                    p.design_received,
        //                    p.design_balance,
        //                    p.supervision_fee,
        //                    p.supervision_received_percentage,
        //                    p.supervision_payment_value,
        //                    p.retention_amount,
        //                    p.supervision_received_after_retention,
        //                    p.supervision_balance,
        //                    p.remarks
        //                FROM tbl_project_payments p
        //                LEFT JOIN tbl_projects pr ON p.project_id = pr.id
        //                LEFT JOIN tbl_engineers e ON p.engineer_id = e.id
        //                LEFT JOIN tbl_customer s ON p.client_id = s.id
        //                ORDER BY p.id DESC";

        //        DataTable dt = DBClass.ExecuteDataTable(query);
        //        dgvPayments.DataSource = dt;
        //        dgvPayments.Columns["id"].Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("LoadData Error: " + ex.Message);
        //    }
        //}

        //private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || dgvPayments.Rows.Count == 0) return;

        //    try
        //    {
        //        selectedId = Convert.ToInt32(dgvPayments.Rows[e.RowIndex].Cells["id"].Value);

        //        LoadSingleRecord(selectedId);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Grid Select Error: " + ex.Message);
        //    }
        //}

        private void LoadSingleRecord(int id)
        {
            try
            {
                string query = "SELECT * FROM tbl_project_payments WHERE id = @id";

                using (MySqlDataReader dr = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", id)))
                {
                    if (dr.Read())
                    {
                        dtpPaymentDate.Value = Convert.ToDateTime(dr["payment_date"]);
                        cmbProject.SelectedValue = Convert.ToInt32(dr["project_id"]);
                        cmbEngineer.SelectedValue = Convert.ToInt32(dr["engineer_id"]);
                        cmbClientOwner.SelectedValue = Convert.ToInt32(dr["client_id"]);
                        cmbPaymentSource.Text = dr["payment_source"].ToString();

                        txtProjectValue.Text = dr["project_value"].ToString();
                        txtConsultancyPercentage.Text = dr["consultancy_percentage"].ToString();
                        txtConsultancyFee.Text = dr["consultancy_fee"].ToString();

                        txtDesignFee.Text = dr["design_fee"].ToString();
                        txtDesignReceived.Text = dr["design_received"].ToString();
                        txtDesignTax.Text = dr["design_tax"].ToString();
                        txtDesignTaxReceived.Text = dr["design_tax_received"].ToString();
                        txtDesignBalance.Text = dr["design_balance"].ToString();

                        txtSupervisionFee.Text = dr["supervision_fee"].ToString();
                        txtSupervisionReceivedPercentage.Text = dr["supervision_received_percentage"].ToString();
                        txtSupervisionPaymentValue.Text = dr["supervision_payment_value"].ToString();
                        txtRetentionPercentage.Text = dr["retention_percentage"].ToString();
                        txtRetentionAmount.Text = dr["retention_amount"].ToString();
                        txtSupervisionReceivedAfterRetention.Text = dr["supervision_received_after_retention"].ToString();
                        txtSupervisionTax.Text = dr["supervision_tax"].ToString();
                        txtSupervisionTaxReceived.Text = dr["supervision_tax_received"].ToString();
                        txtSupervisionBalance.Text = dr["supervision_balance"].ToString();

                        txtRemarks.Text = dr["remarks"].ToString();

                        cmbDebitAccountName.SelectedValue = dr["debit_account_id"].ToString();
                        cmbCreditAccountName.SelectedValue = dr["credit_account_id"].ToString();
                        cmbDesignRevenue.SelectedValue = dr["design_revenue_account_id"].ToString();
                        cmbSupervisionRevenue.SelectedValue = dr["supervision_revenue_account_id"].ToString();

                    }
                }

                CalculateAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSingleRecord Error: " + ex.Message);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbProject.Focused) return;
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT total_value FROM tbl_projects WHERE id = @id", DBClass.CreateParameter("@id", cmbProject.SelectedValue)))
            {
                if (reader.Read())
                {
                    txtProjectValue.Text = reader["total_value"].ToString();
                }
            }
            CalculateAll();
        }

        private void txtConsultancyPercentage_TextChanged(object sender, EventArgs e)
        {
            if (!txtConsultancyPercentage.Focused) return;
            CalculateAll();
        }

        private void txtDesignFee_TextChanged(object sender, EventArgs e)
        {
            if (!txtDesignFee.Focused) return;
            CalculateAll();
        }

        private void txtDesignReceived_TextChanged(object sender, EventArgs e)
        {
            if (!txtDesignReceived.Focused) return;
            CalculateAll();
        }

        private void txtDesignTax_TextChanged(object sender, EventArgs e)
        {
            if (!txtDesignTax.Focused) return;
            CalculateAll();
        }

        private void txtDesignTaxReceived_TextChanged(object sender, EventArgs e)
        {
            if (!txtDesignTaxReceived.Focused) return;
            CalculateAll();
        }

        private void txtSupervisionFee_TextChanged(object sender, EventArgs e)
        {
            if (!txtSupervisionFee.Focused) return;
            CalculateAll();
        }

        private void txtSupervisionReceivedPercentage_TextChanged(object sender, EventArgs e)
        {
            if (!txtSupervisionReceivedPercentage.Focused) return;
            CalculateAll();
        }

        private void txtRetentionPercentage_TextChanged(object sender, EventArgs e)
        {
            if (!txtRetentionPercentage.Focused) return;
            CalculateAll();
        }

        private void txtSupervisionTax_TextChanged(object sender, EventArgs e)
        {
            if (!txtSupervisionTax.Focused) return;
            CalculateAll();
        }

        private void txtSupervisionTaxReceived_TextChanged(object sender, EventArgs e)
        {
            if (!txtSupervisionTaxReceived.Focused) return;
            CalculateAll();
        }

        private void cmbPaymentSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbPaymentSource.Focused) return;
            LoadDebitAc();
        }
    }
}
