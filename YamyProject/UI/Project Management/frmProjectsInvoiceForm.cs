using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectsInvoiceForm : Form
    {
        int id;
        private EventHandler customerUpdatedHandler;

        public frmProjectsInvoiceForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
            headerUC1.FormText = this.Text;
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            EventHub.Customer += customerUpdatedHandler;
        }

        int level4PaymentCreditMethodId, level4VatId, level4RetentionAccount, level4DeductionAccount, level4AdvancePayment;

        private void frmInvoiceForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);
            BindCombos.PopulateCustomers(cmbCustomer);
            //cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT CONCAT(CODE ,' - ' , name) as name ,id FROM tbl_projects where id IN (select project_id from tbl_eng_project_phases p)");
            //cmbProject.DisplayMember = "name";
            //cmbProject.ValueMember = "id";
            //cmbProject.SelectedIndex = -1;

            BindCombos.PopulateCostCenter(cmbCostCenter);
            BindCombos.PopulateAllLevel4Account(cmbAccountCashName);

            cmbVat.DataSource = DBClass.ExecuteDataTable("SELECT id, CONCAT(value, '%') AS display_text, value FROM tbl_tax");
            cmbVat.DisplayMember = "display_text";
            cmbVat.ValueMember = "id";
            cmbVat.FlatStyle = FlatStyle.Popup;

            string dTax = Utilities.GeneralSettings("DEFAULT TAX PERCENTAGE");
            if (!string.IsNullOrEmpty(dTax) && int.TryParse(dTax, out int val) && val > 0)
            {
                if (!string.IsNullOrEmpty(dTax))
                    cmbVat.SelectedValue = int.Parse(dTax);
            }
            
            level4PaymentCreditMethodId = frmLogin.defaultAccounts.ContainsKey("Customer") ? frmLogin.defaultAccounts["Customer"] : 0;
            level4VatId = frmLogin.defaultAccounts.ContainsKey("Vat Output") ? frmLogin.defaultAccounts["Vat Output"] : 0;
            cmbAccountCashName.SelectedValue = frmLogin.defaultAccounts.ContainsKey("Sales") ? frmLogin.defaultAccounts["Sales"] : 0;
            level4RetentionAccount = frmLogin.defaultAccounts.ContainsKey("Retention") ? frmLogin.defaultAccounts["Retention"] : 0;
            level4DeductionAccount = frmLogin.defaultAccounts.ContainsKey("Deduction") ? frmLogin.defaultAccounts["Deduction"] : 0;
            level4AdvancePayment = frmLogin.defaultAccounts.ContainsKey("Customer Advances") ? frmLogin.defaultAccounts["Customer Advances"] : 0;


            if (id > 0)
            {
                txtId.Text = id.ToString();
                BindInvoice();
            }
            else
            {
                txtInvoiceNo.Text = GenerateNextInvoiceCode();
                txtId.Text = GenerateNextInvoiceId();
            }
        }
        private string GenerateNextInvoiceCode()
        {
            string newCode = "PI-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(invoice_number, 4) AS UNSIGNED)) AS lastCode FROM tbl_projects_invoices"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "PI-" + code.ToString("D4");
                }
            }

            return newCode;
        }
        private string GenerateNextInvoiceId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(invoice_id) AS lastCode FROM tbl_projects_invoices"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }
        private void BindInvoice()
        {
            string query = "SELECT invoice_number as invoice_no,invoice_date,milestone_id,project_id,amount,vat,total,status,account_id,payment_status,paid_amount,description,cost_center_id,retention_amount,retention_percentage,deduction,advance_amount,advance_percentage From tbl_projects_invoices WHERE invoice_id = @Id";
            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    txtInvoiceNo.Text = reader["invoice_no"].ToString();
                    dtpInvoiceDate.Text = reader["invoice_date"].ToString();
                    cmbProject.SelectedValue = Convert.ToInt32(reader["project_id"]);
                    cmbCustomer.SelectedValue = Convert.ToInt32(reader["milestone_id"]);
                    txtAmount.Text = reader["amount"].ToString();
                    txtVatAmount.Text = reader["vat"].ToString();
                    TxtTotalAmount.Text = reader["total"].ToString();
                    cmbStatus.SelectedItem = reader["status"].ToString();
                    cmbAccountCashName.SelectedValue = reader["account_id"] != null ? Convert.ToInt32(reader["account_id"]) : -1;
                    richTextDescription.Text = reader["description"].ToString();
                    cmbCostCenter.SelectedValue = Convert.ToInt32(reader["cost_center_id"].ToString());
                    txtId.Text = id.ToString();

                    if (!string.IsNullOrEmpty(reader["retention_amount"].ToString()))
                    {
                        txtRetentionAmount.Text = Convert.ToDecimal(reader["retention_amount"]).ToString("0.00");
                    }
                    else
                    {
                        txtRetentionAmount.Text = "0";
                    }
                    if (!string.IsNullOrEmpty(reader["retention_percentage"].ToString()))
                    {
                        txtRetentionPercent.Text = Convert.ToDecimal(reader["retention_percentage"]).ToString("0.00");
                    }
                    else
                    {
                        txtRetentionPercent.Text = "0";
                    }
                    if(string.IsNullOrEmpty(reader["deduction"].ToString()))
                    {
                        txtDeductionAmount.Text = "0";
                    }
                    else
                    {
                        txtDeductionAmount.Text = Convert.ToDecimal(reader["deduction"]).ToString("0.00");
                    }
                    if (string.IsNullOrEmpty(reader["advance_amount"].ToString()))
                    {
                        txtAdvancePayment.Text = "0";
                    }
                    else
                    {
                        txtAdvancePayment.Text = Convert.ToDecimal(reader["advance_amount"]).ToString("0.00");
                    }
                    if (string.IsNullOrEmpty(reader["advance_percentage"].ToString()))
                    {
                        txtAdvancePercent.Text = "0";
                    }
                    else
                    {
                        txtAdvancePercent.Text = Convert.ToDecimal(reader["advance_percentage"]).ToString("0.00");
                    }
                }
            }
        }
        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
            {
                MessageBox.Show("Please enter Invoice Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbProject.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Project.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbAccountCashName.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an Account.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtContractValue.Text) || !decimal.TryParse(txtContractValue.Text, out _))
            {
                MessageBox.Show("project don't have Contract Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(txtContractValue.Text))
            {
                MessageBox.Show("Amount grater than Contract amount", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Customer Must be Selected.");
                cmbCustomer.Focus();
                return false;
            }

            return true;
        }
        private void guna2TileButton22_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                decimal amount;

                if (!decimal.TryParse(txtAmount.Text.Replace(",", ""), out amount))
                {
                    MessageBox.Show("Please enter a valid amount.");
                    txtAmount.Focus();
                    return;
                }
                decimal vatAmount;

                if (!decimal.TryParse(txtVatAmount.Text.Replace(",", ""), out vatAmount))
                {
                    MessageBox.Show("Please enter a valid Vat amount.");
                    txtAmount.Focus();
                    return;
                }
                decimal totalAmount;

                if (!decimal.TryParse(TxtTotalAmount.Text.Replace(",", ""), out totalAmount))
                {
                    MessageBox.Show("Please enter a valid amount.");
                    txtAmount.Focus();
                    return;
                }

                decimal advance = string.IsNullOrEmpty(txtAdvancePayment.Text) ? 0 : decimal.Parse(txtAdvancePayment.Text);
                decimal paid = 0;

                if (id == 0)
                {
                    paid = advance;
                    int invId = int.Parse(
                        DBClass.ExecuteScalar(@"INSERT INTO tbl_projects_invoices (invoice_number, milestone_id, project_id, amount, status, invoice_date,vat_id,vat,total,account_id,payment_status,paid_amount,description,cost_center_id,retention_percentage,retention_amount,deduction,advance_amount,advance_percentage) 
                            VALUES (@InvoiceNo, @CustomerId, @ProjectId, @Amount, @Status, @InvoiceDate,@vatId,@vat,@total,@account_id,@payment_status,@paid_amount,@description,@cost_center_id,@retention_percentage,@retention_amount,@deduction,@advance_amount,@advance_percentage);
                            SELECT LAST_INSERT_ID();",
                            DBClass.CreateParameter("@InvoiceNo", txtInvoiceNo.Text),
                            DBClass.CreateParameter("@CustomerId", cmbCustomer.SelectedValue),
                            DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue),
                            DBClass.CreateParameter("@Amount", amount),
                            DBClass.CreateParameter("@Status", cmbStatus.SelectedItem.ToString()),
                            DBClass.CreateParameter("@InvoiceDate", dtpInvoiceDate.Value),
                            DBClass.CreateParameter("@vatId", cmbVat.SelectedValue),
                            DBClass.CreateParameter("@vat", vatAmount),
                            DBClass.CreateParameter("@total", totalAmount),
                            DBClass.CreateParameter("@account_id", cmbAccountCashName.SelectedValue),
                            DBClass.CreateParameter("@payment_status", "Pending"),
                            DBClass.CreateParameter("@paid_amount", paid.ToString("0.00")),
                            DBClass.CreateParameter("@cost_center_id", cmbCostCenter.SelectedValue),
                            DBClass.CreateParameter("@retention_amount", string.IsNullOrEmpty(txtRetentionAmount.Text) ? 0 : Convert.ToDecimal(txtRetentionAmount.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@retention_percentage", string.IsNullOrEmpty(txtRetentionPercent.Text) ? 0 : Convert.ToDecimal(txtRetentionPercent.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@deduction", string.IsNullOrEmpty(txtDeductionAmount.Text) ? 0 : Convert.ToDecimal(txtDeductionAmount.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@advance_amount", string.IsNullOrEmpty(txtAdvancePayment.Text) ? 0 : Convert.ToDecimal(txtAdvancePayment.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@advance_percentage", string.IsNullOrEmpty(txtAdvancePercent.Text) ? 0 : Convert.ToDecimal(txtAdvancePercent.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@description", richTextDescription.Text)).ToString());


                    CostCenter(invId, amount);
                    Transaction(invId, amount, vatAmount, totalAmount, Convert.ToInt32(cmbProject.SelectedValue));
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        AddFileData(id);
                    }
                    EventHub.RefreshProjectInvoice();
                    MessageBox.Show("Invoice created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    object result = DBClass.ExecuteScalar(
                        "SELECT SUM(payment) FROM tbl_projects_receipt_voucher_details WHERE inv_id = @id",
                        DBClass.CreateParameter("id", id)
                    );
                    decimal totalPaid = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    paid = advance + totalPaid;

                    // Update existing invoice logic
                    DBClass.ExecuteNonQuery("UPDATE tbl_projects_invoices SET invoice_number = @InvoiceNo, milestone_id = @CustomerId, project_id = @ProjectId, amount = @Amount, status = @Status, invoice_date = @InvoiceDate, vat_id=@vatId, vat= @vat,total=@total,account_id=@account_id,payment_status=@payment_status,paid_amount=@paid_amount,description=@description,cost_center_id=@cost_center_id,retention_percentage=@retention_percentage,retention_amount=@retention_amount,deduction=@deduction,advance_amount=@advance_amount,advance_percentage=@advance_percentage WHERE invoice_id = @Id",
                            DBClass.CreateParameter("@InvoiceNo", txtInvoiceNo.Text),
                            DBClass.CreateParameter("@CustomerId", cmbCustomer.SelectedValue),
                            DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue),
                            DBClass.CreateParameter("@Amount", amount),
                            DBClass.CreateParameter("@Status", cmbStatus.SelectedItem.ToString()),
                            DBClass.CreateParameter("@InvoiceDate", dtpInvoiceDate.Value),
                            DBClass.CreateParameter("@vatId", cmbVat.SelectedValue),
                            DBClass.CreateParameter("@vat", vatAmount),
                            DBClass.CreateParameter("@total", totalAmount),
                            DBClass.CreateParameter("@account_id", cmbAccountCashName.SelectedValue),
                            DBClass.CreateParameter("@payment_status", "Pending"),
                            DBClass.CreateParameter("@paid_amount", paid.ToString("0.00")),
                            DBClass.CreateParameter("@cost_center_id", cmbCostCenter.SelectedValue),
                            DBClass.CreateParameter("@description", richTextDescription.Text),
                            DBClass.CreateParameter("retention_amount", string.IsNullOrEmpty(txtRetentionAmount.Text) ? 0 : Convert.ToDecimal(txtRetentionAmount.Text.Replace(",", ""))),
                            DBClass.CreateParameter("retention_percentage", string.IsNullOrEmpty(txtRetentionPercent.Text) ? 0 : Convert.ToDecimal(txtRetentionPercent.Text.Replace(",", ""))),
                            DBClass.CreateParameter("deduction", string.IsNullOrEmpty(txtDeductionAmount.Text) ? 0 : Convert.ToDecimal(txtDeductionAmount.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@advance_amount", string.IsNullOrEmpty(txtAdvancePayment.Text) ? 0 : Convert.ToDecimal(txtAdvancePayment.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@advance_percentage", string.IsNullOrEmpty(txtAdvancePercent.Text) ? 0 : Convert.ToDecimal(txtAdvancePercent.Text.Replace(",", ""))),
                            DBClass.CreateParameter("@Id", id)
                        );

                    CommonInsert.DeleteCostCenterTransactionEntry(id.ToString(), "Project Invoice");
                    CommonInsert.DeleteTransactionEntry(id, "PROJECT INVOICE");

                    CostCenter(id, amount);
                    Transaction(id, amount, vatAmount, totalAmount, Convert.ToInt32(cmbProject.SelectedValue));
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        AddFileData(id);
                    }
                    EventHub.RefreshProjectInvoice();
                    MessageBox.Show("Invoice updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AddFileData(int fId)
        {
            AttachmentManager.SaveAttachment(
                    "PROJECT INVOICE",
                    fId,
                    openFileDialog1.FileName
                );
        }
        private void CostCenter(int invId, decimal amountValue)
        {
            //add cost center
            if (cmbCostCenter.SelectedValue != null && int.Parse(cmbCostCenter.SelectedValue.ToString()) > 0)
                CommonInsert.InsertCostCenterTransaction(dtpInvoiceDate.Value, "0", amountValue.ToString(), invId.ToString(), "Project Invoice", "", (cmbCostCenter.SelectedValue ?? 0).ToString());
        }

        private void Transaction(int invId,decimal amount, decimal vatAmount, decimal totalAmount,int projectId)
        {
            if (totalAmount > 0)
            {
                string _accountId = level4PaymentCreditMethodId.ToString();
                CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                       _accountId,
                       totalAmount.ToString(), "0", invId.ToString(), cmbCustomer.SelectedValue.ToString(), "Project Invoice", "PROJECT INVOICE", "Project Invoice NO. " + txtInvoiceNo.Text,
                       frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text, projectId);

                CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                  cmbAccountCashName.SelectedValue.ToString(), "0", amount.ToString(), invId.ToString(), "0", "Project Invoice", "PROJECT INVOICE",
                  "Project Revenue For Invoice No. " + txtInvoiceNo.Text, frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text, projectId);

                if (vatAmount > 0)
                {
                    CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                      level4VatId.ToString(), "0", vatAmount.ToString(), invId.ToString(), "0", "Project Invoice", "PROJECT INVOICE",
                      "Vat Output For Invoice No. " + txtInvoiceNo.Text, frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text, projectId);
                }
                if (txtRetentionAmount.Text != "0" && !string.IsNullOrEmpty(txtRetentionAmount.Text))
                {
                    if (decimal.Parse(txtRetentionAmount.Text) > 0)
                    {
                        CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                          level4RetentionAccount.ToString(), txtRetentionAmount.Text.ToString().Replace(",", ""), "0", invId.ToString(), "0", "Project Invoice", "PROJECT INVOICE",
                          "Retention For Invoice No. " + txtInvoiceNo.Text, frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text, projectId);
                    }
                }
                if (txtDeductionAmount.Text != "0" && !string.IsNullOrEmpty(txtDeductionAmount.Text))
                {
                    if (decimal.Parse(txtDeductionAmount.Text) > 0)
                    {
                        CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                          level4DeductionAccount.ToString(), txtDeductionAmount.Text.ToString().Replace(",", ""), "0", invId.ToString(), "0", "Project Invoice", "PROJECT INVOICE",
                          "Deduction For Invoice No. " + txtInvoiceNo.Text, frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text, projectId);
                    }
                }
                if (txtAdvancePayment.Text != "0" && !string.IsNullOrEmpty(txtAdvancePayment.Text))
                {
                    if (!string.IsNullOrEmpty(txtAdvancePayment.Text) && decimal.Parse(txtAdvancePayment.Text.Replace(",", "")) > 0)
                    {
                        CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                           level4AdvancePayment.ToString(),
                           txtAdvancePayment.Text.Replace(",", ""), "0", invId.ToString(), "0", "Project Invoice", "PROJECT INVOICE", "Advance For Invoice NO. " + txtInvoiceNo.Text + " Advance Payment",
                           frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text);

                        CommonInsert.addTransactionEntry(dtpInvoiceDate.Value.Date,
                           _accountId,
                            "0", txtAdvancePayment.Text.Replace(",", ""), invId.ToString(), 
                            cmbCustomer.SelectedValue.ToString(), 
                            "Project Invoice", "PROJECT INVOICE", "Advance For Invoice NO. " + txtInvoiceNo.Text + " Advance Payment",
                           frmLogin.userId, DateTime.Now.Date, txtInvoiceNo.Text);
                    }
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void guna2TileButton31_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton30_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text); // Utilities.GetVoucherIdFromCode(txtInvoiceId.Text);
            if (currentId == null || currentId <= 1)
                return;

            currentId = currentId - 1;
            if (currentId <= 0)
            {
                clearData();
                MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "select invoice_id as id from tbl_projects_invoices where invoice_id =@id";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void clearData()
        {
            txtAmount.Text = txtVatAmount.Text = txtRetentionAmount.Text = txtRetentionPercent.Text = TxtTotalAmount.Text = string.Empty;
            //cmbMilestone.SelectedIndex = cmbProject.SelectedIndex = cmbStatus.SelectedIndex = cmbAccountCashName.SelectedIndex = -1;
            dtpInvoiceDate.Value = DateTime.Now;
            txtInvoiceNo.Text = GenerateNextInvoiceCode();
            txtId.Text = GenerateNextInvoiceId();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text); // Utilities.GetVoucherIdFromCode(txtInvoiceId.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            string query = "SELECT invoice_id id FROM tbl_projects_invoices WHERE invoice_id =@id";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No More Records");
                }
        }

        private void guna2TileButton23_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (cmbVat.SelectedValue != null && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                object vatPercentObj = DBClass.ExecuteScalar("SELECT value FROM tbl_tax WHERE id = @id", DBClass.CreateParameter("@id", cmbVat.SelectedValue));
                if (vatPercentObj != null)
                {
                    decimal vatPercent = Convert.ToDecimal(vatPercentObj.ToString());
                    decimal vatAmount = amount * vatPercent / 100;
                    txtVatAmount.Text = vatAmount.ToString("0.00");
                    CalculateTotalAmount();
                }
            }
        }
        private void CalculateTotalAmount()
        {
            decimal totalBeforeVat = string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text);
            decimal retentionAmount = string.IsNullOrEmpty(txtRetentionAmount.Text) ? 0 : Convert.ToDecimal(txtRetentionAmount.Text);
            decimal totalDeduction = string.IsNullOrEmpty(txtDeductionAmount.Text) ? 0 : Convert.ToDecimal(txtDeductionAmount.Text);
            decimal taxableAfterRetention = totalBeforeVat - retentionAmount - totalDeduction;
            decimal totalVat = string.IsNullOrEmpty(txtVatAmount.Text) ? 0 : Convert.ToDecimal(txtVatAmount.Text);
            //decimal newVat = 0;

            //if (totalBeforeVat > 0)
            //    newVat = totalVat * (taxableAfterRetention / totalBeforeVat);

            TxtTotalAmount.Text = (taxableAfterRetention + totalVat).ToString("0.00");
            //TxtTotalAmount.Text = (totalBeforeVat + totalVat).ToString("0.00");
        }

        private void cmbVat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbVat.SelectedValue != null && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                object vatPercentObj = DBClass.ExecuteScalar("SELECT value FROM tbl_tax WHERE id = @id", DBClass.CreateParameter("@id", cmbVat.SelectedValue));
                if (vatPercentObj != null)
                {
                    decimal vatPercent = Convert.ToDecimal(vatPercentObj.ToString());
                    decimal vatAmount = amount * vatPercent / 100;
                    txtVatAmount.Text = vatAmount.ToString("0.00");
                    CalculateTotalAmount();
                }
            }
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbProject.SelectedValue == null) return;

            object objContractValue = DBClass.ExecuteScalar("Select total_value from tbl_projects a where a.id = @id",
                      DBClass.CreateParameter("id", cmbProject.SelectedValue));
            if (objContractValue != null)
            {
                txtContractValue.Text = Convert.ToDecimal(objContractValue).ToString("0.00");
            }
        }

        private void guna2TileButton21_Click(object sender, EventArgs e)
        {
            if(id <= 0)
            {
                MessageBox.Show("No invoice selected to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this invoice?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DBClass.ExecuteNonQuery("Delete from tbl_projects_invoices WHERE invoice_id = @id;", DBClass.CreateParameter("id", id.ToString()));
            CommonInsert.DeleteCostCenterTransactionEntry(id.ToString(), "Project Invoice");
            CommonInsert.DeleteTransactionEntry(id, "PROJECT INVOICE");

            Utilities.LogAudit(frmLogin.userId, "Project", "Delete Project Invoice", id, "Deleted Project Invoice with ID: " + id.ToString());

            EventHub.RefreshProjectInvoice(); 
            clearData();
        }

        private void guna2TileButton13_Click(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                MessageBox.Show("No invoice selected to create receipt voucher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new frmProjectReceiptVoucher(0, id).ShowDialog();
        }

        string filePath = "";
        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
        }

        private void guna2TileButton20_Click(object sender, EventArgs e)
        {
            id = 0;
        }

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {

        }

        private bool isUpdatingRetention = false;
        private bool isUpdatingAdvance = false;

        private void txtAdvancePercent_TextChanged(object sender, EventArgs e)
        {
            if (!txtAdvancePercent.Focused)
                return;

            if (decimal.TryParse(txtAdvancePercent.Text, out decimal percent))
            {
                isUpdatingAdvance = true;

                decimal amountBeforeVat = string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text);
                decimal vat = string.IsNullOrEmpty(txtVatAmount.Text) ? 0 : Convert.ToDecimal(txtVatAmount.Text);
                decimal retention = string.IsNullOrEmpty(txtRetentionAmount.Text) ? 0 : Convert.ToDecimal(txtRetentionAmount.Text);
                decimal total = amountBeforeVat + vat + retention;
                decimal advanceAmount = total * (percent / 100);

                txtAdvancePayment.Text = advanceAmount.ToString("0.00");

                isUpdatingAdvance = false;
            }
        }

        private void txtAdvancePayment_TextChanged(object sender, EventArgs e)
        {
            if (!txtAdvancePayment.Focused)
                return;

            if (isUpdatingAdvance) return;

            if (decimal.TryParse(txtAdvancePayment.Text, out decimal amount))
            {
                isUpdatingAdvance = true;

                decimal amountBeforeVat = string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text);
                decimal vat = string.IsNullOrEmpty(txtVatAmount.Text) ? 0 : Convert.ToDecimal(txtVatAmount.Text);
                decimal retention = string.IsNullOrEmpty(txtRetentionAmount.Text) ? 0 : Convert.ToDecimal(txtRetentionAmount.Text);
                decimal total = amountBeforeVat + vat + retention;

                if (total > 0)
                {
                    decimal percent = (amount / total) * 100;
                    txtAdvancePercent.Text = percent.ToString("0.00");
                }

                isUpdatingAdvance = false;
            }
        }

        private void frmProjectsInvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Customer Must be Selected.");
                cmbCustomer.Focus();
            }
        }

        private void txtDeductionAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtRetentionPercent_TextChanged(object sender, EventArgs e)
        {
            if (!txtRetentionPercent.Focused)
                return;

            if (isUpdatingRetention) return;
            if (string.IsNullOrEmpty(txtAmount.Text))
                return;

            if (decimal.TryParse(txtRetentionPercent.Text, out decimal percent))
            {
                isUpdatingRetention = true;

                decimal totalBeforeVat = string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text);
                decimal retentionAmount = totalBeforeVat * (percent / 100);

                txtRetentionAmount.Text = retentionAmount.ToString("0.00");

                CalculateTotalAmount();

                isUpdatingRetention = false;
            }
        }

        private void txtRetentionAmount_TextChanged(object sender, EventArgs e)
        {
            if (!txtRetentionAmount.Focused)
                return;

            if (isUpdatingRetention) return;

            if (decimal.TryParse(txtRetentionAmount.Text, out decimal amount))
            {
                isUpdatingRetention = true;

                decimal totalBeforeVat = string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text);

                if (totalBeforeVat > 0)
                {
                    decimal percent = (amount / totalBeforeVat) * 100;
                    txtRetentionPercent.Text = percent.ToString("0.00");
                }

                CalculateTotalAmount();

                isUpdatingRetention = false;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
