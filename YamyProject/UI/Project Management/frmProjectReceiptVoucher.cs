using CrystalDecisions.CrystalReports.Engine;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using static YamyProject.BindCombos;

namespace YamyProject
{
    public partial class frmProjectReceiptVoucher : Form
    {
        int id;
        decimal totalAmount = 0;
        string code, InvNo="";
        int invoiceId = 0;
        int projectId = 0;

        public frmProjectReceiptVoucher(int id = 0, int invoiceId = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.id = id;
            headerUC1.FormText = this.Text;
            this.invoiceId = invoiceId;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmProjectReceiptVoucher_Load(object sender, EventArgs e)
        {
            dtOpen.Value = DateTime.Now.Date;
            txtPVCode.Text = GenerateNextReceiptCode();
            txtId.Text = GenerateNextReceiptId();
            BindCombos.PopulateAllLevel4Account(cmbCreditAccountName, false);

            //BindCombos.PopulateAllLevel4Account(cmbDebitAccountName, true);
            cmbDebitAccountName.DataSource = DBClass.ExecuteDataTable("SELECT l4.id, l4.code, l4.name from tbl_coa_level_4 l4 INNER JOIN tbl_coa_level_3 l3 ON l4.main_id = l3.id INNER JOIN tbl_coa_level_2 l2 ON l3.main_id = l2.id INNER JOIN tbl_coa_level_1 l1 ON l2.main_id = l1.id WHERE l1.category_code='ASSET' ORDER BY NAME ");
            cmbDebitAccountName.DisplayMember = "name";
            cmbDebitAccountName.ValueMember = "id";
            cmbDebitAccountName.SelectedIndex = -1;
            cmbDebitAccountName.SelectedValue = (frmLogin.defaultAccounts.ContainsKey("Default Account For Bank") ? frmLogin.defaultAccounts["Default Account For Bank"] : 0);

            cmbMethod.SelectedIndex = 0;
            if (id > 0)
            {
                BindVoucher();
            }
            else
            {
                if (invoiceId > 0)
                {
                    LoadData();
                }
            }
        }
        private void BindVoucher()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT * FROM tbl_projects_receipt_voucher WHERE id = " + id))
                if (reader.Read())
                {
                    txtId.Text = reader["id"].ToString();
                    dtOpen.Value = DateTime.Parse(reader["date"].ToString());
                    code = reader["code"].ToString();
                    txtPVCode.Text = reader["code"].ToString();
                    cmbMethod.Text = reader["method"].ToString();
                    txtAmount.Text = decimal.Parse(reader["amount"].ToString()).ToString(".00");
                    cmbCreditAccountName.SelectedValue = reader["credit_account_id"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                    cmbDebitAccountName.SelectedValue = reader["debit_account_id"].ToString();


                    txtAmount.Enabled = true;
                    txtPay.Text = txtAmount.Text;
                    LastBalance();
                }
        }
        
        private string GenerateNextReceiptId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_projects_receipt_voucher"))
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
            string newCode = "RV-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(code, 4) AS UNSIGNED)) AS lastCode FROM tbl_projects_receipt_voucher"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "RV-" + code.ToString("D4");
                }
            }

            return newCode;
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LastBalance();
            if (id == 0)
            {
                if (insertRV())
                {
                    MessageBox.Show("The Project Receipt Voucher  Saved");
                    EventHub.RefreshReceiptVoucher();
                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                    txtPVCode.Text = GenerateNextReceiptCode();
                }
            } else
            {
                if (updateRV())
                {
                    MessageBox.Show("The Project Receipt Voucher  Updated");
                    EventHub.RefreshReceiptVoucher();
                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                    txtPVCode.Text = GenerateNextReceiptCode();
                }
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LastBalance();

            if (id == 0)
            {
                if (insertRV())
                {
                    EventHub.RefreshReceiptVoucher();
                    this.Close();
                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
            else
            {
                if (updateRV())
                {
                    EventHub.RefreshReceiptVoucher();
                    this.Close();
                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
        }

        private void loadPrint()
        {

            DialogResult result = MessageBox.Show("Do You want To Show This Payment ",
                                             "Confirmation",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ShowReport();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
        }
        private bool updateRV()
        {
            if (!chkRequireData())
                return false;

            DBClass.ExecuteScalar(@"UPDATE tbl_projects_receipt_voucher SET
                                                          date=@date, code=@code, type=@type, method=@method, amount=@amount,  debit_account_id=@debit_account_id,debit_cost_center_id=@debit_cost_center_id, 
                                                          description=@description,credit_account_id=@credit_account_id,credit_cost_center_id=@credit_cost_center_id,
                                                          bank_account_id=@bank_account, book_no=@book_no,bank_id=@bank_id, bank_code=@bank_code, check_name=@check_name, check_no=@check_no,
                                                          check_date=@check_date,trans_date=@trans_date, trans_name=@trans_name, trans_ref=@trans_ref, modified_by=@modified_by, modified_date=@modified_date,project_id=@project_id where id=@id",
                                                          DBClass.CreateParameter("id", id),
                                                          DBClass.CreateParameter("date", dtOpen.Value.Date),
                   DBClass.CreateParameter("code", code),
                   DBClass.CreateParameter("type", ""),
                   DBClass.CreateParameter("method", cmbMethod.Text),
                   DBClass.CreateParameter("amount", decimal.Parse(txtAmount.Text)),
                   DBClass.CreateParameter("credit_account_id", cmbCreditAccountName.SelectedValue ?? DBNull.Value),
                   DBClass.CreateParameter("credit_cost_center_id", "0"),
                   DBClass.CreateParameter("description", txtDescription.Text),
                   DBClass.CreateParameter("debit_account_id", cmbDebitAccountName.SelectedValue ?? DBNull.Value),
                   DBClass.CreateParameter("debit_cost_center_id", "0"),
                   DBClass.CreateParameter("bank_id", "0"),
                   DBClass.CreateParameter("bank_account", "0"),
                   DBClass.CreateParameter("book_no", "0"),
                   DBClass.CreateParameter("bank_code", ""),
                   DBClass.CreateParameter("check_name", ""),
                   DBClass.CreateParameter("check_no", ""),
                   DBClass.CreateParameter("check_date", dtOpen.Value),
                   DBClass.CreateParameter("trans_date", dtOpen.Value),
                   DBClass.CreateParameter("trans_name", ""),
                   DBClass.CreateParameter("trans_ref", ""),
                   DBClass.CreateParameter("modified_by", frmLogin.userId),
                   DBClass.CreateParameter("modified_date", DateTime.Now.Date),
                   DBClass.CreateParameter("project_id", projectId));

            DBClass.ExecuteNonQuery("Delete from tbl_projects_receipt_voucher_details where payment_id=@id", DBClass.CreateParameter("id", id));
            CommonInsert.DeleteTransactionEntry(id, "PROJECT RECEIPT");

            //if (cmbMethod.Text == "Cheque")
            //{//DefaultBankId from first account and cheque id
            //    int chequeId = GetChequeBookIdByCompanyOrFirst();
            //    object result = DBClass.ExecuteScalar(@"SELECT id FROM tbl_check_details WHERE pvc_no = @pvc_no AND check_type = @check_type AND check_id = @check_id",
            //        DBClass.CreateParameter("pvc_no", id),
            //        DBClass.CreateParameter("check_type", "Project Receipt"),
            //        DBClass.CreateParameter("check_id", chequeId.ToString())
            //    );
            //    int checkDetail_Id = Convert.ToInt32(result);
            //    if (checkDetail_Id > 0)
            //    {
            //        DBClass.ExecuteNonQuery(@"
            //            UPDATE tbl_check_details
            //            SET check_no = @check_no, 
            //                check_date = @check_date, 
            //                check_name = @check_name, 
            //                amount = @amount,
            //            WHERE pvc_no = @pvc_no AND check_type = @check_type AND check_id = @check_id and id = @id",
            //            DBClass.CreateParameter("check_no", txtCheckNo.Text),
            //            DBClass.CreateParameter("check_date", dt_check_date.Value.Date),
            //            DBClass.CreateParameter("check_name", txtCheckName.Text),
            //            DBClass.CreateParameter("amount", decimal.Parse(txtAmount.Text)),
            //            //DBClass.CreateParameter("state", "New"),
            //            DBClass.CreateParameter("pvc_no", id),
            //            DBClass.CreateParameter("check_type", "Project Receipt"),
            //            DBClass.CreateParameter("check_id", chequeId.ToString()),
            //            DBClass.CreateParameter("id", checkDetail_Id)
            //        );
            //    }
            //    else
            //    {
            //        int checkDetailId = (int)decimal.Parse(DBClass.ExecuteScalar(@"
            //            INSERT INTO tbl_check_details
            //            (date, check_id, check_no, check_date, check_type, pvc_no, check_name, amount, state)
            //            VALUES
            //            (@date, @check_id, @check_no, @check_date, @check_type, @pvc_no, @check_name, @amount, @state);
            //            SELECT LAST_INSERT_ID();",
            //            DBClass.CreateParameter("date", dtOpen.Value.Date),
            //            DBClass.CreateParameter("check_id", chequeId.ToString()),
            //            DBClass.CreateParameter("check_no", txtCheckNo.Text),
            //            DBClass.CreateParameter("check_date", dt_check_date.Value.Date),
            //            DBClass.CreateParameter("check_type", "Project Receipt"),
            //            DBClass.CreateParameter("pvc_no", id),
            //            DBClass.CreateParameter("check_name", txtCheckName.Text),
            //            DBClass.CreateParameter("amount", decimal.Parse(txtAmount.Text)),
            //            DBClass.CreateParameter("state", "New")
            //        ).ToString());
            //    }

            //}
            //else if (cmbMethod.Text == "Transfer")
            //{
            //}
            //insertJournals();
            insertINV(id);
            CommonInsert.DeleteCostCenterTransactionEntry(id.ToString(), "Project Receipt");
            //CommonInsert.InsertCostCenterTransaction(dtOpen.Value, txtAmount.Text.ToString(), "0", id.ToString(), "Project Receipt", "Project Receipt Debit Entry", cmbDebitCostCenter.SelectedValue.ToString());
            //CommonInsert.InsertCostCenterTransaction(dtOpen.Value, "0", txtAmount.Text.ToString(), id.ToString(), "Project Receipt", "Project Receipt Credit Entry", cmbCreditCostCenter.SelectedValue.ToString());
            Utilities.LogAudit(frmLogin.userId, "Update Project Receipt Voucher", "Project Receipt Voucher", id, "Updated Project Receipt Voucher: " + code);

            if (!string.IsNullOrEmpty(filePath))
            {
                AddFileData(id);
            }
            return true;
        }
        private void AddFileData(int fId)
        {
            AttachmentManager.SaveAttachment(
                    "PROJECT RECEIPT",
                    fId,
                    openFileDialog1.FileName
                );
        }
        private bool insertRV()
        {
            if (!chkRequireData())
                return false;
            code = GenerateNextReceiptCode();
            id = (int)decimal.Parse(DBClass.ExecuteScalar(@"
                    INSERT INTO tbl_projects_receipt_voucher(
                        date, code, type, method, amount,  
                        debit_account_id, debit_cost_center_id, 
                        credit_account_id, credit_cost_center_id, description,
                        bank_id, bank_account_id, book_no, check_name, check_no, check_date,
                        trans_date, trans_name, trans_ref, created_by, created_date, state, project_id
                    ) 
                    VALUES (
                        @date, @code, @type, @method, @amount, 
                        @debit_account_id, @debit_cost_center_id, 
                        @credit_account_id, @credit_cost_center_id, @description,
                        @bank_id, @bank_account, @book_no, @check_name, @check_no, @check_date,
                        @trans_date, @trans_name, @trans_ref, @created_by, @created_date, 0, @project_id
                    ); 
                    SELECT LAST_INSERT_ID();",

                   DBClass.CreateParameter("date", dtOpen.Value.Date),
                   DBClass.CreateParameter("code", code),
                   DBClass.CreateParameter("type", ""),
                   DBClass.CreateParameter("method", ""),
                   DBClass.CreateParameter("amount", decimal.Parse(txtAmount.Text)), 
                   DBClass.CreateParameter("credit_account_id", cmbCreditAccountName.SelectedValue ?? DBNull.Value),
                   DBClass.CreateParameter("credit_cost_center_id", "0"),
                   DBClass.CreateParameter("description", txtDescription.Text),
                   DBClass.CreateParameter("debit_account_id", cmbDebitAccountName.SelectedValue ?? DBNull.Value),
                   DBClass.CreateParameter("debit_cost_center_id", "0"),
                   DBClass.CreateParameter("bank_id", "0"),
                   DBClass.CreateParameter("bank_account", "0"), 
                   DBClass.CreateParameter("book_no", "0"),
                   DBClass.CreateParameter("check_name", ""),
                   DBClass.CreateParameter("check_no", ""),
                   DBClass.CreateParameter("check_date", dtOpen.Value.Date),
                   DBClass.CreateParameter("trans_date", dtOpen.Value.Date),
                   DBClass.CreateParameter("trans_name", ""),
                   DBClass.CreateParameter("trans_ref", ""),
                   DBClass.CreateParameter("created_by", frmLogin.userId),
                   DBClass.CreateParameter("created_date", DateTime.Now.Date),
                   DBClass.CreateParameter("project_id", projectId)
               ).ToString());

            //if (cmbMethod.Text == "Cheque")
            //{
            //    //DefaultBankId from first account and cheque id
            //    int chequeId = GetChequeBookIdByCompanyOrFirst();
            //    int checkDetailId = (int)decimal.Parse(DBClass.ExecuteScalar(@"INSERT INTO tbl_check_details
            //            (date, check_id, check_no, check_date, check_type, pvc_no, check_name, amount, state)
            //            VALUES
            //            (@date, @check_id, @check_no, @check_date, @check_type, @pvc_no, @check_name, @amount, @state); 
            //            SELECT LAST_INSERT_ID();",
            //            DBClass.CreateParameter("date", dtOpen.Value.Date),
            //            DBClass.CreateParameter("check_id", chequeId.ToString()),
            //            DBClass.CreateParameter("check_no", txtCheckNo.Text),
            //            DBClass.CreateParameter("check_date", dt_check_date.Value.Date),
            //            DBClass.CreateParameter("check_type", "Project Receipt"),
            //            DBClass.CreateParameter("pvc_no", id),
            //            DBClass.CreateParameter("check_name", txtCheckName.Text),
            //            DBClass.CreateParameter("amount", decimal.Parse(txtAmount.Text)),
            //            DBClass.CreateParameter("state", "New")
            //        ).ToString());
            //}
            //else if (cmbMethod.Text == "Transfer")
            //{
            //}

            //insertJournals();
            insertINV(id);
            //CommonInsert.InsertCostCenterTransaction(dtOpen.Value, txtAmount.Text.ToString(), "0", id.ToString(), "Project Receipt", "Project Receipt Debit Entry", cmbDebitCostCenter.SelectedValue.ToString());
            //CommonInsert.InsertCostCenterTransaction(dtOpen.Value, "0", txtAmount.Text.ToString(), id.ToString(), "Project Receipt", "Project Receipt Credit Entry", cmbCreditCostCenter.SelectedValue.ToString());
            Utilities.LogAudit(frmLogin.userId, "Create Project Receipt Voucher", "Project Receipt Voucher", id, "Created Project Receipt Voucher: " + code);
            if (!string.IsNullOrEmpty(filePath))
            {
                AddFileData(id);
            }

            EventHub.RefreshProjectInvoice();

            return true;
        }

        private bool chkRequireData()
        {
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment Amount.");
                return false;
            }
            if (cmbDebitAccountName.Text.Trim() == "")
            {
                MessageBox.Show("Please Choose Debit Account Name");
                return false;
            }
            if (cmbCreditAccountName.Text.Trim() == "")
            {
                MessageBox.Show("Please Choose Credit Account Name");
                return false;
            }
            if (txtAmount.Text == "" || decimal.Parse(txtAmount.Text) == 0)
            {
                MessageBox.Show("Enter Amount");
                return false;
            }

            return true;
        }
        private void insertINV(int pvId)
        {
            decimal total;

            if (!decimal.TryParse(txtAmount.Text.Replace(",", ""), out total))
            {
                MessageBox.Show("Please enter a valid amount.");
                txtAmount.Focus();
                return;
            }

            var invId = invoiceId.ToString();
            object objHum = DBClass.ExecuteScalar(@"SELECT milestone_id from tbl_projects_invoices where invoice_id = @id", DBClass.CreateParameter("@id", invoiceId));
            var hum = int.Parse(objHum != null ? objHum.ToString() : "0");
            string payment = txtPay.Text;
            var description = txtDescription;
            string voucherType = "Project Receipt";
            DateTime date = dtInv.Value;

            DBClass.ExecuteNonQuery(@"INSERT INTO tbl_projects_receipt_voucher_details
                                        (date,payment_id,hum_id, inv_id,inv_code,total, payment, description) 
                                        VALUES (@date,@payment_id,@hum_id ,@inv_id,@inv_code,@total, @payment, @description);",
                DBClass.CreateParameter("@payment_id", pvId),
                DBClass.CreateParameter("@date", date.Date),
                DBClass.CreateParameter("@hum_id", hum.ToString()),
                DBClass.CreateParameter("@inv_code", InvNo.ToString()),
                DBClass.CreateParameter("@total", total),
                DBClass.CreateParameter("@inv_id", int.Parse(invId)),
                DBClass.CreateParameter("@payment", payment),
                DBClass.CreateParameter("@description", description));

            if (invId != "")
            {
                if (int.Parse(invId) > 0)
                {
                    int currentInvId = int.Parse(invId);

                    object netResult = DBClass.ExecuteScalar(
                        "SELECT total FROM tbl_projects_invoices WHERE invoice_id = @id",
                        DBClass.CreateParameter("id", currentInvId)
                    );
                    decimal net = netResult != DBNull.Value ? Convert.ToDecimal(netResult) : 0;

                    object result = DBClass.ExecuteScalar(
                        "SELECT SUM(payment) FROM tbl_projects_receipt_voucher_details WHERE inv_id = @id",
                        DBClass.CreateParameter("id", currentInvId)
                    );
                    decimal totalPaid = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    object objAdvance = DBClass.ExecuteScalar("SELECT advance_amount FROM tbl_projects_invoices WHERE invoice_id = @id",
                        DBClass.CreateParameter("id", currentInvId)
                    );
                    decimal advance = objAdvance != DBNull.Value ? Convert.ToDecimal(objAdvance) : 0;
                    totalPaid += advance;
                    //decimal totalPaidInvoice = string.IsNullOrEmpty(txtPaid.Text) ? 0 : decimal.Parse(txtPaid.Text);
                    decimal remaining = net - totalPaid; //totalPaidInvoice;

                    DBClass.ExecuteNonQuery(
                        "UPDATE tbl_projects_invoices SET paid_amount = @paid WHERE invoice_id = @id",
                        DBClass.CreateParameter("@paid", totalPaid),
                        DBClass.CreateParameter("id", currentInvId)
                    );
                    Utilities.LogAudit(frmLogin.userId, "Update Project Invoice", "Project Invoice", currentInvId, "Updated Project Invoice: " + InvNo);
                }
            }

            insertJournals(voucherType, payment, description.ToString(), hum);

            EventHub.RefreshProjectInvoice();
        }
        void insertJournals(string voucherType, string amount, string description,int humId)
        {
            CommonInsert.addTransactionEntry(dtOpen.Value.Date,
                      cmbDebitAccountName.SelectedValue.ToString(),
                      amount, "0", id.ToString(), humId.ToString(), "Project Receipt", "PROJECT RECEIPT", "Receipt Voucher NO. " + code,
                       frmLogin.userId, DateTime.Now.Date, txtPVCode.Text, projectId);

            CommonInsert.addTransactionEntry(dtOpen.Value.Date,
                                  cmbCreditAccountName.SelectedValue.ToString(),
                                 "0", amount, id.ToString(), projectId.ToString(), "Project Receipt", "PROJECT RECEIPT", "Project Receipt Voucher NO. " + code,
                                   frmLogin.userId, DateTime.Now.Date, txtPVCode.Text, projectId);
            
        }

        private void LoadData()
        {

            using (var reader = DBClass.ExecuteReader(@"SELECT invoice_number,amount,vat,total,paid_amount,invoice_date,account_id,project_id from tbl_projects_invoices where invoice_id = @id;",
                                                                  DBClass.CreateParameter("@id", invoiceId)))
            {
                while (reader.Read())
                {
                    InvNo = reader["invoice_number"].ToString();
                    txtPaid.Text = reader["paid_amount"].ToString();
                    txtBillAmount.Text = reader["total"].ToString();
                    txtPay.Text = "0";
                    dtInv.Value = DateTime.Parse(reader["invoice_date"].ToString());
                    int level4PaymentCreditMethodId = frmLogin.defaultAccounts.ContainsKey("Customer") ? frmLogin.defaultAccounts["Customer"] : 0;
                    cmbCreditAccountName.SelectedValue = level4PaymentCreditMethodId;
                    projectId = int.Parse(reader["project_id"].ToString());
                }
            }
        }

        private void txtDebitCode_TextChanged(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where code =@code",
              DBClass.CreateParameter("code", txtDebitAccountCode.Text)))
                if (reader.Read())
                    cmbDebitAccountName.SelectedValue = int.Parse(reader["id"].ToString());

            if (txtDebitAccountCode.Focused)
            {
                string input = txtDebitAccountCode.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    lstAccountSuggestions.Visible = false;
                    return;
                }
                string query = @"SELECT code, name FROM tbl_coa_level_4 
                         WHERE code LIKE @search OR name LIKE @search LIMIT 20";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@search", "%" + input + "%"));

                lstAccountSuggestions.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    lstAccountSuggestions.Items.Add(new ItemSuggestion { Code = row["code"].ToString(), Name = row["name"].ToString() });
                }
                if (lstAccountSuggestions.Items.Count > 0)
                {
                    Point locationOnForm = txtDebitAccountCode.Parent.PointToScreen(txtDebitAccountCode.Location);
                    Point locationRelativeToForm = this.PointToClient(locationOnForm);

                    lstAccountSuggestions.SetBounds(
                        locationRelativeToForm.X,
                        locationRelativeToForm.Y + txtDebitAccountCode.Height,
                        txtDebitAccountCode.Width + 100,
                        120
                    );

                    lstAccountSuggestions.Tag = txtDebitAccountCode;
                    lstAccountSuggestions.Visible = true;
                    lstAccountSuggestions.BringToFront();
                }
                else
                {
                    lstAccountSuggestions.Visible = false;
                }
            }
        }

        private void txtCreditAccountCode_TextChanged(object sender, EventArgs e)
        {

            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where code =@code",
            DBClass.CreateParameter("code", txtCreditAccountCode.Text)))
                if (reader.Read())
                    cmbCreditAccountName.SelectedValue = int.Parse(reader["id"].ToString());

            if (txtCreditAccountCode.Focused)
            {
                string input = txtCreditAccountCode.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    lstAccountSuggestions.Visible = false;
                    return;
                }
                string query = @"SELECT code, name FROM tbl_coa_level_4 
                         WHERE code LIKE @search OR name LIKE @search LIMIT 20";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@search", "%" + input + "%"));

                lstAccountSuggestions.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    lstAccountSuggestions.Items.Add(new ItemSuggestion { Code = row["code"].ToString(), Name = row["name"].ToString() });
                }
                if (lstAccountSuggestions.Items.Count > 0)
                {
                    Point locationOnForm = txtCreditAccountCode.Parent.PointToScreen(txtCreditAccountCode.Location);
                    Point locationRelativeToForm = this.PointToClient(locationOnForm);

                    lstAccountSuggestions.SetBounds(
                        locationRelativeToForm.X,
                        locationRelativeToForm.Y + txtCreditAccountCode.Height,
                        txtCreditAccountCode.Width + 100,
                        120
                    );

                    lstAccountSuggestions.Tag = txtCreditAccountCode;
                    lstAccountSuggestions.Visible = true;
                    lstAccountSuggestions.BringToFront();
                }
                else
                {
                    lstAccountSuggestions.Visible = false;
                }
            }
        }

        private void txtDebitCode_Leave(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where code =@code",
            DBClass.CreateParameter("code", txtDebitAccountCode.Text)))
                if (!reader.Read())
                    cmbDebitAccountName.SelectedIndex = -1;

            BeginInvoke((Action)(() =>
            {
                if (!lstAccountSuggestions.Focused)
                    lstAccountSuggestions.Visible = false;
            }));
        }

        private void txtCreditAccountCode_Leave(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where code =@code",
            DBClass.CreateParameter("code", txtDebitAccountCode.Text)))
                if (!reader.Read())
                    cmbCreditAccountName.SelectedIndex = -1;

            BeginInvoke((Action)(() =>
            {
                if (!lstAccountSuggestions.Focused)
                    lstAccountSuggestions.Visible = false;
            }));
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMethod.Text == "Cash")
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id,code FROM tbl_coa_level_4 WHERE id = (select account_id from tbl_coa_config where category=@cat)", DBClass.CreateParameter("@cat", "Default Account For Cash")))
                    if (reader.Read())
                    {
                        txtDebitAccountCode.Text = reader["code"].ToString();
                        string accountId = reader["id"].ToString();
                        if (!string.IsNullOrEmpty(accountId))
                        {
                            cmbDebitAccountName.SelectedValue = int.Parse(accountId);
                        }
                    }
            }

        }
       
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                txtAmountInWord.Text = "";
                return;
            }
            //txtAmountInWord.Text = AmountToWordsHelper.ConvertToSelectedLanguage(decimal.Parse(txtAmount.Text));
            txtAmountInWord.Text = AmountToWordsHelper.ConvertToSelectedLanguage(decimal.Parse(txtAmount.Text));
        }

        bool isDebitAccountNameRefreshing = false;
        private void cmbDebitAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDebitAccountName.SelectedValue == null)
            {
                txtDebitAccountCode.Text = "";
                return;
            }

            if (cmbDebitAccountName.Focused && int.Parse(cmbDebitAccountName.SelectedValue.ToString()) == -1)
            {
                new frmAddAccount().ShowDialog();
                isDebitAccountNameRefreshing = true;
                BindCombos.PopulateAllLevel4Account(cmbDebitAccountName, true);
                cmbDebitAccountName.SelectedIndex = cmbDebitAccountName.Items.Count - 1;
                isDebitAccountNameRefreshing = false;
            }
            else
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where id = @id", DBClass.CreateParameter("@id",cmbDebitAccountName.SelectedValue.ToString())))
                    if (reader.Read())
                        txtDebitAccountCode.Text = reader["code"].ToString();
                    else
                        txtDebitAccountCode.Text = "";
            }
        }

        bool isCreditAccountNameRefreshing = false;
        private void cmbCreditAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCreditAccountName.SelectedValue == null)
            {
                txtCreditAccountCode.Text = "";
                return;
            }
            if (cmbCreditAccountName.Focused && int.Parse(cmbCreditAccountName.SelectedValue.ToString()) == -1)
            {
                new frmAddAccount().ShowDialog();

                isCreditAccountNameRefreshing = true;
                BindCombos.PopulateAllLevel4Account(cmbCreditAccountName, true);
                cmbCreditAccountName.SelectedIndex = cmbCreditAccountName.Items.Count - 1;
                isCreditAccountNameRefreshing = false;
            }
            else
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where id = " + cmbCreditAccountName.SelectedValue.ToString()))
                    if (reader.Read())
                        txtCreditAccountCode.Text = reader["code"].ToString();
                    else
                        txtCreditAccountCode.Text = "";
            }
        }

        public DataTable COMPANYINFO(int a1)
        {
            return DBClass.ExecuteDataTable("SELECT * FROM tbl_company limit 1");
        }

        public DataTable TransactionInfo(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT ROW_NUMBER() OVER (ORDER BY tr.id) AS sn,
                                    (SELECT Code FROM tbl_coa_level_4 WHERE id=tr.account_id)as acCode,
                                    (SELECT NAME FROM tbl_coa_level_4 WHERE id=tr.account_id)as acName,
                                     tr.debit,tr.credit,
                                    (SELECT NAME FROM tbl_sub_cost_center WHERE id = (select cost_center_id FROM tbl_projects_receipt_voucher_details WHERE payment_id=r.id LIMIT 1)) AS centerName 
                                     FROM tbl_transaction tr,tbl_projects_receipt_voucher r WHERE tr.transaction_id=r.id and r.id=@id AND tr.TYPE = 'Customer Receipt'; ",DBClass.CreateParameter("id",id));
                    
        }

        public DataTable ReceiptVoucher(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT id,date,CODE AS RvNo,type,method,amount,
                                (SELECT code FROM tbl_customer WHERE id=(SELECT hum_id FROM tbl_projects_receipt_voucher_details WHERE payment_id = tbl_projects_receipt_voucher.id)) reciverCode,
                                (SELECT name FROM tbl_customer WHERE id=(SELECT hum_id FROM tbl_projects_receipt_voucher_details WHERE payment_id = tbl_projects_receipt_voucher.id)) reciverName,
                                (SELECT code FROM tbl_coa_level_4 WHERE id=debit_account_id) debitAccountcode,
                                (SELECT NAME FROM tbl_coa_level_4 WHERE id=debit_account_id) debitAccount,
                                (SELECT NAME FROM tbl_sub_cost_center WHERE id=debit_cost_center_id) debitCostCenter,
                                (SELECT code FROM tbl_coa_level_4 WHERE id=credit_account_id) creditAccountcode,
                                (SELECT NAME FROM tbl_coa_level_4 WHERE id=credit_account_id) creditAccount,
                                (select name FROM tbl_sub_cost_center WHERE id=credit_cost_center_id) creditCostCenter,
                                description description,(select name FROM tbl_bank WHERE id = bank_id) bankName,
                                (select code FROM tbl_bank WHERE id = bank_id) bankAccountcode,
                                (select account_name FROM tbl_bank_card WHERE id = bank_account) bankAccount,
                                check_name,check_no,check_date,trans_date,trans_name,trans_ref 
                                FROM tbl_projects_receipt_voucher where id=@id;", DBClass.CreateParameter("id", id));
        }

        public DataTable ReceiptDetail(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT ROW_NUMBER() OVER (ORDER BY d.id) AS sn,d.date,d.inv_id,
                                CASE
                                    WHEN i.type = 'Customer' THEN(SELECT NAME FROM tbl_customer WHERE id = d.hum_id)
                                    WHEN i.type = 'Vendor' THEN (SELECT NAME FROM tbl_vendor WHERE id = d.hum_id)
                                    WHEN i.type = 'Employee' THEN (SELECT NAME FROM tbl_employee WHERE id = d.hum_id)
                                    WHEN i.type = 'General' THEN (SELECT NAME FROM tbl_coa_level_4 WHERE id = d.hum_id)
                                    ELSE 'Unregistered'
                                END AS NAME,d.hum_id,d.inv_code,d.total,d.payment,d.description,(SELECT NAME FROM tbl_sub_cost_center WHERE id = d.cost_center_id) AS costCenterName
                            FROM tbl_projects_receipt_voucher_details d,tbl_projects_receipt_voucher i WHERE d.payment_id = i.id AND i.id= @receiptId;", DBClass.CreateParameter("@receiptId", a1));
        }

        public void ShowReport()
        {

            try
            {
                DataTable companyData = COMPANYINFO(1);  // Assuming you want to pass ID 1

                ReportDocument cr = new ReportDocument();
                if (companyData.Rows[0][companyData.Columns["name"]].ToString().Contains("Majestic"))
                {
                    string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", "ReceiptVoucherMajestic.rpt");
                    // Load the report file from disk
                    cr.Load(reportPath);
                    // Load the main report data
                    //DataTable transactionData = TransactionInfo(id.ToString());
                    //DataTable receiptVoucherData = ReceiptVoucher(id.ToString());
                    DataTable receiptDetailData = ReceiptDetail(id.ToString());
                    if (companyData != null)  // Ensure that data was successfully retrieved
                    {
                        cr.SetDataSource(receiptDetailData);
                        //cr.Subreports["Company"].SetDataSource(companyData);
                        //cr.Subreports["ReceiptHeader"].SetDataSource(receiptVoucherData);
                        //cr.Subreports["AccountHeader"].SetDataSource(transactionData);
                        //cr.Subreports["ChequeHeader"].SetDataSource(receiptVoucherData);
                        //cr.Subreports["ReceiptDetails"].SetDataSource(receiptDetailData);
                        //((TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["Text2"]).Text = txtDescription.Text;
                        ((TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Text1"]).Text = txtAmountInWord.Text;
                    }
                    else
                    {
                        MessageBox.Show("No data available for the report.");
                        return;  // Exit the method if no data is available
                    }
                }
                else
                {
                    string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", "ReceiptVoucher.rpt");
                    // Load the report file from disk
                    cr.Load(reportPath);
                    // Load the main report data
                    DataTable transactionData = TransactionInfo(id.ToString());
                    DataTable receiptVoucherData = ReceiptVoucher(id.ToString());
                    DataTable receiptDetailData = ReceiptDetail(id.ToString());
                    if (companyData != null)  // Ensure that data was successfully retrieved
                    {
                        cr.Subreports["Company"].SetDataSource(companyData);
                        cr.Subreports["ReceiptHeader"].SetDataSource(receiptVoucherData);
                        cr.Subreports["AccountHeader"].SetDataSource(transactionData);
                        cr.Subreports["ChequeHeader"].SetDataSource(receiptVoucherData);
                        cr.Subreports["ReceiptDetails"].SetDataSource(receiptDetailData);
                        ((TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["Text2"]).Text = txtDescription.Text;
                    }
                    else
                    {
                        MessageBox.Show("No data available for the report.");
                        return;  // Exit the method if no data is available
                    }
                }
                string fileName = "ProjectReceiptVoucher_" + id + "_" + cmbCreditAccountName.Text.Trim();
                MasterReportView reportForm = new MasterReportView(cr, fileName);
                reportForm.crReportViewer.ReportSource = cr;
                reportForm.crReportViewer.RefreshReport();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Restore down
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Maximize
            }
        }

        private void pnlBank_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panel6_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text); // Utilities.GetVoucherIdFromCode(txtPVCode.Text);
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

            string query = "SELECT id FROM tbl_projects_receipt_voucher WHERE state = 0 AND id = @id";

            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
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
            int? currentId = Convert.ToInt32(txtId.Text); // Utilities.GetVoucherIdFromCode(txtPVCode.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            txtId.Text = currentId.ToString();
            string query = "SELECT id FROM tbl_projects_receipt_voucher WHERE state = 0 AND id = @id";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPVCode.Text = GenerateNextReceiptCode();
            clear();
        }
        private void clear()
        {
            totalAmount = 0;
            txtAmount.Text = "0";
            txtAmountInWord.Text = "";
            txtDescription.Text = "";
            txtPay.Text = "0";
            txtDebitAccountCode.Text = "";
            txtCreditAccountCode.Text = "";
            id = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Read all records before deletion
            DataTable dtReceipt = DBClass.ExecuteDataTable(
                "SELECT * FROM tbl_projects_receipt_voucher WHERE id = @id",
                DBClass.CreateParameter("id", id.ToString())
            );

            DataTable dtDetails = DBClass.ExecuteDataTable(
                "SELECT * FROM tbl_projects_receipt_voucher_details WHERE payment_id = @id",
                DBClass.CreateParameter("id", id.ToString())
            );

            DataTable dtTransaction = DBClass.ExecuteDataTable(
                "SELECT * FROM tbl_transaction WHERE transaction_id = @id AND t_type='RECEIPT'",
                DBClass.CreateParameter("id", id.ToString())
            );

            // 2. Backup into tbl_deleted_records
            void BackupData(DataTable dt, string tableName)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DBClass.ExecuteNonQuery(
                        "INSERT INTO tbl_deleted_records (table_name, record_data, deleted_by) VALUES (@table, @data, @user)",
                        DBClass.CreateParameter("table", tableName),
                        DBClass.CreateParameter("data", Newtonsoft.Json.JsonConvert.SerializeObject(row)),
                        DBClass.CreateParameter("user", frmLogin.userId.ToString())
                    );
                }
            }

            BackupData(dtReceipt, "tbl_projects_receipt_voucher");
            BackupData(dtDetails, "tbl_projects_receipt_voucher_details");
            BackupData(dtTransaction, "tbl_transaction");

            // 3. Permanently delete records
            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_transaction WHERE transaction_id = @id AND t_type='PROJECT RECEIPT'",
                DBClass.CreateParameter("id", id.ToString())
            );
            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_projects_receipt_voucher_details WHERE payment_id = @id",
                DBClass.CreateParameter("id", id.ToString())
            );
            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_projects_receipt_voucher WHERE id = @id",
                DBClass.CreateParameter("id", id.ToString())
            );

            // 4. Log and clear
            Utilities.LogAudit(frmLogin.userId, "Project Receipt Voucher Permanently Deleted", "Project Receipt Voucher", id, "Deleted Project Receipt Voucher with ID: " + id);
            clear();
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            id = 0;
        }

        private void lstAccountSuggestions_Click(object sender, EventArgs e)
        {
            if (lstAccountSuggestions.SelectedItem != null && lstAccountSuggestions.Tag is Guna2TextBox targetTextBox)
            {
                string selected = lstAccountSuggestions.SelectedItem.ToString();
                string selectedCode = "";// selected.Split('-')[0].Trim();
                if (lstAccountSuggestions.SelectedItem is ItemSuggestion item)
                {
                    selectedCode = item.Code;
                }
                targetTextBox.Text = selectedCode;
                lstAccountSuggestions.Visible = false;

                // Trigger TextChanged manually if needed
                targetTextBox.Focus();
                targetTextBox.SelectionStart = targetTextBox.Text.Length;

                // Example of post-selection logic:
                if (targetTextBox == txtDebitAccountCode)
                {
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where code =@code",
                        DBClass.CreateParameter("code", selectedCode)))
                        if (reader.Read())
                            cmbDebitAccountName.SelectedValue = int.Parse(reader["id"].ToString());
                }
                else if (targetTextBox == txtCreditAccountCode)
                {
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_coa_level_4 where code =@code",
                        DBClass.CreateParameter("code", selectedCode)))
                        if (reader.Read())
                            cmbCreditAccountName.SelectedValue = int.Parse(reader["id"].ToString());
                }
            }
        }

        static string filePath = "";
        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
        }
        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            if (txtPay.Text == "")
                return;

            if (decimal.TryParse(txtPay.Text, out decimal payAmount))
            {
                if (payAmount > 0)
                {
                    LastBalance();
                }
            }
            txtAmount.Text = txtPay.Text;
        }

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block the input
            }
        }

        private void LastBalance()
        {
            txtBalance.Text = "0";
            decimal billAmount = string.IsNullOrEmpty(txtBillAmount.Text) ? 0 : decimal.Parse(txtBillAmount.Text);
            decimal paidAmount = string.IsNullOrEmpty(txtPaid.Text) ? 0 : decimal.Parse(txtPaid.Text);
            decimal payAmount = string.IsNullOrEmpty(txtPay.Text) ? 0 : decimal.Parse(txtPay.Text);
            decimal lastBalance = billAmount - paidAmount - payAmount;
            txtBalance.Text = lastBalance.ToString(".00");
        }
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true; // Block the input
            }

            // Allow only one decimal point
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}