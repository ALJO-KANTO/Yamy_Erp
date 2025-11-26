using CrystalDecisions.CrystalReports.Engine;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;

using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmSalesReturn : Form
    {
        private EventHandler customerUpdatedHandler;
        private EventHandler warehouseUpdatedHandler;

        decimal invId;
        int level4PaymentCreditMethodId, level4VatId, level4SalesReturnId, level4COGS, level4Inventory;
        private MasterSalesReturn _sales;
        MasterCustomer _customer;
        int id;

        public frmSalesReturn(int id)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateSoledCustomers(cmbCustomer);
            warehouseUpdatedHandler = (sender, args) => BindCombos.PopulateWarehouse(cmbWarehouse);
            EventHub.Customer += customerUpdatedHandler;
            EventHub.wareHouse += warehouseUpdatedHandler;
            this.id = id;
            if (id != 0)
                this.Text = "SalesReturn - Edit";
            else
                this.Text = "SalesReturn - New";
           headerUC1.FormText = this.Text;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSalesReturn_Load(object sender, EventArgs e)
        {
            txtNextCode.Text = GenerateNextSalesCode();
            dtPaymentTerms.Value = dtInv.Value = dtShip.Value = DateTime.Now.Date;
            bindCombo();
            LoadVat();
            loadCostCenter();
            cmbPaymentMethod.SelectedIndex = 0;
            txtId.Text = GenerateNextSalesId();
            if (id != 0)
            {
                btnSave.Enabled = UserPermissions.canEdit("Sales Return");
                BindInvoice();
            }
        }
        private void BindInvoice()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader(" select * from tbl_sales_return where id = @id",
                DBClass.CreateParameter("id", id)))
            {
                reader.Read();
                txtId.Text = reader["id"].ToString();
                dtInv.Value = DateTime.Parse(reader["date"].ToString());
                txtNextCode.Text = reader["invoice_id"].ToString();
                cmbCustomer.SelectedValue = reader["customer_id"].ToString();
                cmbPaymentMethod.Text = reader["payment_method"].ToString();
                if (reader["payment_method"].ToString() == "Cash")
                    cmbAccountCashName.SelectedValue = reader["account_cash_id"].ToString();
                else
                {
                    cmbPaymentTerms.Text = reader["payment_terms"].ToString();
                    dtPaymentTerms.Value = DateTime.Parse(reader["payment_date"].ToString());
                }
                cmbShipVia.Text = reader["ship_via"].ToString();
                cmbWarehouse.SelectedValue = reader["warehouse_id"].ToString();
                invId = id;
                txtBillTo.Text = reader["bill_to"].ToString();
                txtShipTo.Text = reader["ship_to"].ToString();
                txtSalesMan.Text = reader["sales_man"].ToString();
                richTextDescription.Text = reader["description"].ToString();
                salesId = int.Parse(reader["sales_ref_id"].ToString());
                txtRefNo.Text = reader["po_num"].ToString();
                BindInvoiceItems();
                CalculateTotal();
            }
        }
        private void BindInvoiceItems()
        {
            dgvItems.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT ti.id,ti.code,ti.name,ti.type, ti.method, sd.qty as S_Qty, IFNULL(srd.Qty,0) Qty, sd.price,sd.discount, sd.vatp, sd.vat, sd.total, sd.cost_price, IFNULL(srd.cost_center_id,0) cost_center_id
                                                    FROM tbl_sales_details sd
                                                    INNER JOIN tbl_items ti ON sd.item_id = ti.id
                                                    LEFT JOIN tbl_sales_return_details srd ON srd.item_id = sd.item_id 
                                                    AND srd.sales_id = @returnId 
                                                    WHERE sd.sales_id = @salesId;",
                                            DBClass.CreateParameter("salesId", salesId),
                                            DBClass.CreateParameter("returnId", id)))
                while (reader.Read())
                {
                    bool isExisting = decimal.Parse(reader["Qty"].ToString()) > 0 ? true : false;
                    dgvItems.Rows.Add(reader["id"].ToString(), "", reader["code"].ToString(), reader["name"].ToString(), isExisting, Utilities.FormatDecimal(reader["S_Qty"].ToString()), Utilities.FormatDecimal(reader["Qty"].ToString()),
                        Utilities.FormatDecimal(reader["cost_price"].ToString()), Utilities.FormatDecimal(reader["price"].ToString()), Utilities.FormatDecimal(reader["discount"].ToString()));
                    DataGridViewComboBoxCell comboCell = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vat"] as DataGridViewComboBoxCell;
                    if (comboCell != null && reader["vat"].ToString() != "0")
                    {
                        comboCell.Value = int.Parse(reader["vat"].ToString());
                        dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value = decimal.Parse(reader["vatP"].ToString());
                    }
                    DataGridViewComboBoxCell comboCellCostCenter = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["cost_center"] as DataGridViewComboBoxCell;
                    if (comboCellCostCenter != null && reader["cost_center_id"].ToString() != "0")
                    {
                        comboCellCostCenter.Value = int.Parse(reader["cost_center_id"].ToString());
                    }
                    int rowIndex = dgvItems.Rows.Count - 2;
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["qty"].Value?.ToString(), out decimal qty0);
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["price"].Value?.ToString(), out decimal price0);
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["discount"].Value?.ToString(), out decimal discount0);
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["vatp"].Value?.ToString(), out decimal vatp0);

                    dgvItems.Rows[rowIndex].Cells["total"].Value = (qty0 * (price0 - discount0)) + vatp0;
                    dgvItems.Rows[rowIndex].Cells["method"].Value = reader["method"]?.ToString() ?? "";
                    dgvItems.Rows[rowIndex].Cells["type"].Value = reader["type"]?.ToString() ?? "";

                }
        }

        private void LoadVat()
        {
            DataTable dt = DBClass.ExecuteDataTable("select id, concat(name,'-',value , '%') as name,value from tbl_tax");
            DataGridViewComboBoxColumn vat = (DataGridViewComboBoxColumn)dgvItems.Columns["vat"];
            vat.DataSource = dt;
            vat.DisplayMember = "name";
            vat.ValueMember = "id";
            var dTax = Utilities.GeneralSettings("DEFAULT TAX PERCENTAGE");
            if (!string.IsNullOrEmpty(dTax) & int.Parse(dTax) > 0)
            {
                defaultTax = dTax;
            }
        }
        private void loadCostCenter()
        {
            DataTable dt = DBClass.ExecuteDataTable("select id,code as name from tbl_sub_cost_center");
            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgvItems.Columns["Cost_Center"];
            col.DataSource = dt;
            col.DisplayMember = "name";
            col.ValueMember = "id";
        }
        string defaultTax = "";
        private void bindCombo()
        {
            BindCombos.PopulateSoledCustomers(cmbCustomer);
            BindCombos.PopulateAllLevel4Account(cmbAccountCashName);
            BindCombos.PopulateWarehouse(cmbWarehouse);
            cmbAccountCashName.SelectedValue = BindCombos.SelectDefaultLevelAccount("Invoice Payment Cash Method");
            level4PaymentCreditMethodId = frmLogin.defaultAccounts.ContainsKey("Customer") ? frmLogin.defaultAccounts["Customer"] : 0;
            level4VatId = BindCombos.SelectDefaultLevelAccount("Vat Output");
            level4SalesReturnId = BindCombos.SelectDefaultLevelAccount("SalesReturn");
            level4COGS = BindCombos.SelectDefaultLevelAccount("COGS");
            level4Inventory = BindCombos.SelectDefaultLevelAccount("Inventory");
            if (level4Inventory == 0 || level4COGS == 0 || level4SalesReturnId == 0 || level4VatId == 0 || level4PaymentCreditMethodId == 0)
            {
                MessageBox.Show("Default Accounts For Invoice Must Be Set First");
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0 || dgvItems.Rows.Count == 1 && dgvItems.Rows[0].IsNewRow)
            {
                MessageBox.Show("The Return Invoice  Update");
                // Optionally, you can stop the event if needed, but normally the event will end after the message.
                return;
            }


            if (id == 0)
            {
                if (insertInvoice())
                {
                    EventHub.RefreshSales();
                    MessageBox.Show("The Return Invoice Saved");
                    dgvItems.Rows.Clear();

                    if (checkBox4.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
            else
            {
                if (updateInvoice())
                {
                    EventHub.RefreshSales();
                    MessageBox.Show("The Return Invoice Saved");
                    dgvItems.Rows.Clear();

                    if (checkBox4.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
        }
        private void preview()
        {
            //DialogResult result = MessageBox.Show("Do You want To Show This Bill ",
            //                                    "Confirmation",
            //                                    MessageBoxButtons.YesNo,
            //                                    MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
                //new MasterReportView().Show();

                ShowReport();
            //}else if(result == DialogResult.No)
            //{
            //    this.Close();
            //}
        }
        private bool updateInvoice()
        {
            if (!chkRequiredDate())
                return false;
            
            DBClass.ExecuteNonQuery(@"UPDATE tbl_sales_return 
                                     SET  modified_by = @modifiedBy, modified_date = @modifiedDate ,date = @date,sales_man=@sales_man, customer_id = @customer_id, invoice_id = @invoice_id, warehouse_id = @warehouse_id,
                                     po_num = @po_num, bill_to = @bill_to, ship_date = @ship_date, 
                                     ship_via = @ship_via, ship_to = @ship_to, payment_method = @payment_method, account_cash_id = @account_cash_id, 
                                     payment_terms = @payment_terms, payment_date = @payment_date, total = @total, 
                                     vat = @vat, net = @net, pay = @pay, `change` = @change, city = @city, description = @description WHERE id = @id;",
                 DBClass.CreateParameter("id", id),
                  DBClass.CreateParameter("date", dtInv.Value.Date),
               DBClass.CreateParameter("customer_id", cmbCustomer.SelectedValue),
               DBClass.CreateParameter("invoice_id", txtNextCode.Text),
               DBClass.CreateParameter("city", cmbCity.Text),
               DBClass.CreateParameter("warehouse_id", cmbWarehouse.SelectedValue),
               DBClass.CreateParameter("po_num", txtRefNo.Text),
               DBClass.CreateParameter("bill_to", txtBillTo.Text),
               DBClass.CreateParameter("ship_date", dtShip.Value.Date),
               DBClass.CreateParameter("sales_man", txtSalesMan.Text),
               DBClass.CreateParameter("ship_via", cmbShipVia.Text),
               DBClass.CreateParameter("ship_to", txtShipTo.Text),
               DBClass.CreateParameter("payment_method", cmbPaymentMethod.Text),
               DBClass.CreateParameter("account_cash_id", cmbPaymentMethod.Text == "Credit" ? level4PaymentCreditMethodId.ToString() : cmbAccountCashName.SelectedValue.ToString()),
               DBClass.CreateParameter("payment_terms", cmbPaymentTerms.Text),
               DBClass.CreateParameter("payment_date", dtPaymentTerms.Value.Date),
               DBClass.CreateParameter("vat", txtTotalVat.Text),
               DBClass.CreateParameter("total", txtTotalBefore.Text),
               DBClass.CreateParameter("net", txtTotal.Text),
               DBClass.CreateParameter("description", richTextDescription.Text),
               DBClass.CreateParameter("@modifiedBy", frmLogin.userId),
               DBClass.CreateParameter("@modifiedDate", DateTime.Now.Date),
               DBClass.CreateParameter("pay", cmbPaymentMethod.Text == "Cash" ? string.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDecimal(txtTotal.Text) : 0),
               DBClass.CreateParameter("change", cmbPaymentMethod.Text == "Cash" ? 0 : string.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDecimal(txtTotal.Text)));
            
            ReturnItemsToInventory();
            DBClass.ExecuteNonQuery(@"DELETE FROM tbl_item_transaction WHERE reference = @invId AND type = 'Sales Return Invoice';
                DELETE FROM tbl_item_card_details WHERE trans_type = 'Sales Return Invoice' and trans_no=@invId", DBClass.CreateParameter("invId", id));

            CommonInsert.DeleteCostCenterTransactionEntry(id.ToString(), "Sales Return");
            insertInvItems();

            CommonInsert.DeleteTransactionEntry(id, "SALES RETURN");
            transaction();
            Utilities.LogAudit(frmLogin.userId, "Update Sales Return Invoice", "Sales Return", id, "Updated Sales Return Invoice: " + txtNextCode.Text);

            return true;
        }

        private void ReturnItemsToInventory()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader(@"select tbl_sales_return_details.* ,tbl_items.method,tbl_items.type from tbl_sales_return_details
                                                           inner join tbl_items on tbl_sales_return_details.item_id = tbl_items.id 
                                                           where sales_id =@id", DBClass.CreateParameter("id", id)))
                while (reader.Read())
                {
                    if (reader["type"].ToString() != "Service")
                    {
                        DBClass.ExecuteNonQuery("update tbl_items set on_hand =on_hand+ @qty where id =@id", DBClass.CreateParameter("id", reader["item_id"].ToString()), DBClass.CreateParameter("qty", reader["qty"].ToString()));
                        DBClass.ExecuteNonQuery("delete from tbl_item_transaction  where reference =@invId and type ='Sales Return Invoice'", DBClass.CreateParameter("invId", id));
                        if (reader["method"].ToString() == "agv")
                            continue;
                        string qr = "";
                        if (reader["method"].ToString() == "fifo")
                            qr = (@"SELECT * FROM tbl_item_transaction WHERE item_id = @id and qty_in != qty_inc
                                                                     and qty_out = 0 ORDER BY id asc");
                        else
                            qr = (@"SELECT * FROM tbl_item_transaction WHERE item_id = @id and qty_in != qty_inc
                                                                     and qty_out = 0 ORDER BY id asc");
                        decimal attempQty = decimal.Parse(reader["qty"].ToString());
                        using (var tReader = DBClass.ExecuteReader(qr, DBClass.CreateParameter("id", reader["item_id"].ToString())))
                            while (tReader.Read())
                            {
                                if (decimal.Parse(tReader["qty_inc"].ToString()) + attempQty <= decimal.Parse(tReader["qty_in"].ToString()))
                                {
                                    DBClass.ExecuteNonQuery("update tbl_item_transaction set qty_inc = qty_inc +@qty where id = @id",
                                        DBClass.CreateParameter("qty", attempQty),
                                        DBClass.CreateParameter("id", tReader["id"].ToString()));
                                    break;
                                }
                                else
                                {
                                    attempQty = attempQty - decimal.Parse(tReader["qty_in"].ToString()) - decimal.Parse(tReader["qty_inc"].ToString());
                                    DBClass.ExecuteNonQuery("update tbl_item_transaction set qty_inc = qty_in where id = @id",
                                      DBClass.CreateParameter("id", tReader["id"].ToString()));
                                }
                            }
                    }
                    DBClass.ExecuteNonQuery("delete from tbl_sales_return_details where id =@id", DBClass.CreateParameter("id", reader["id"].ToString()));
                }
        }
        private string GenerateNextSalesCode()
        {
            string newCode = "SRI-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(invoice_id, 5) AS UNSIGNED)) AS lastCode FROM tbl_sales_return"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "SRI-" + code.ToString("D5");
                }
            }

            return newCode;
        }
        private string GenerateNextSalesId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_sales_return"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }

        private bool insertInvoice()
        {
            if (!chkRequiredDate())
                return false;

                invId = decimal.Parse(DBClass.ExecuteScalar(@"INSERT INTO tbl_sales_return (date, customer_id, invoice_id,warehouse_id, po_num, bill_to,city,sales_man,
               ship_date,ship_via, ship_to, payment_method,account_cash_id, payment_terms, payment_date,  
               total,vat,net, pay, `change`, created_by, created_date, state, description, sales_ref_id) VALUES (@DATE, @customer_id, @invoice_id,@warehouse_id,
               @po_num, @bill_to,@city,@sales_man, @ship_date, @ship_via,@ship_to, @payment_method,@account_cash_id ,@payment_terms, @payment_date, 
               @total,  @vat,@net, @pay, @change, @created_by, @created_date, @state, @description, @sales_ref_id);
               SELECT LAST_INSERT_ID();",
               DBClass.CreateParameter("date", dtInv.Value.Date),
               DBClass.CreateParameter("customer_id", cmbCustomer.SelectedValue),
               DBClass.CreateParameter("invoice_id", txtNextCode.Text),
               DBClass.CreateParameter("city", cmbCity.Text),
               DBClass.CreateParameter("warehouse_id", cmbWarehouse.SelectedValue),
               DBClass.CreateParameter("po_num", txtRefNo.Text),
               DBClass.CreateParameter("sales_ref_id", salesId),
               DBClass.CreateParameter("bill_to", txtBillTo.Text),
               DBClass.CreateParameter("ship_date", dtShip.Value.Date),
               DBClass.CreateParameter("sales_man", txtSalesMan.Text),
               DBClass.CreateParameter("ship_via", cmbShipVia.Text),
               DBClass.CreateParameter("ship_to", txtShipTo.Text),
               DBClass.CreateParameter("payment_method", cmbPaymentMethod.Text),
               DBClass.CreateParameter("account_cash_id", cmbPaymentMethod.Text == "Credit" ? level4PaymentCreditMethodId.ToString() : cmbAccountCashName.SelectedValue.ToString()),
               DBClass.CreateParameter("payment_terms", cmbPaymentTerms.Text),
               DBClass.CreateParameter("payment_date", dtPaymentTerms.Value.Date),
               DBClass.CreateParameter("vat", txtTotalVat.Text),
               DBClass.CreateParameter("total", txtTotalBefore.Text),
               DBClass.CreateParameter("net", txtTotal.Text),
               DBClass.CreateParameter("description", richTextDescription.Text),
               DBClass.CreateParameter("pay", cmbPaymentMethod.Text == "Cash" ? string.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDecimal(txtTotal.Text) : 0),
               DBClass.CreateParameter("change", cmbPaymentMethod.Text == "Cash" ? 0 : string.IsNullOrEmpty(txtTotal.Text) ? 0 : Convert.ToDecimal(txtTotal.Text)),
               DBClass.CreateParameter("created_by", frmLogin.userId),
               DBClass.CreateParameter("created_date", DateTime.Now.Date),
               DBClass.CreateParameter("state", 0)).ToString());
            
            insertInvItems();

            transaction();
            Utilities.LogAudit(frmLogin.userId, "Add Sales Return Invoice", "Sales Return", (int)invId, "Added Sales Return Invoice: " + txtNextCode.Text);

            return true;
        }
        private void transaction()
        {
            if (decimal.Parse(txtTotal.Text) > 0)
            {
                string _accountId = cmbPaymentMethod.Text == "Credit" ? level4PaymentCreditMethodId.ToString() : cmbAccountCashName.SelectedValue.ToString();
                CommonInsert.addTransactionEntry(dtInv.Value.Date, _accountId, "0", txtTotal.Text, invId.ToString(), cmbCustomer.SelectedValue.ToString(), "SalesReturn Invoice", "SALES RETURN", "SalesReturn Invoice NO. " + txtNextCode.Text,
                 frmLogin.userId, DateTime.Now.Date, txtNextCode.Text);

                if (decimal.Parse(txtTotalVat.Text) > 0)
                {
                    CommonInsert.addTransactionEntry(dtInv.Value.Date,
                  level4VatId.ToString(), txtTotalVat.Text, "0", invId.ToString(), "0", "SalesReturn Invoice", "SALES RETURN",
                  "Vat Output For Return Invoice No. " + txtNextCode.Text, frmLogin.userId, DateTime.Now.Date, txtNextCode.Text);
                }
                CommonInsert.addTransactionEntry(dtInv.Value.Date,
                  level4SalesReturnId.ToString(), txtTotalBefore.Text, "0", invId.ToString(), "0", "SalesReturn Invoice", "SALES RETURN",
                  "SalesReturn For Invoice No. " + txtNextCode.Text, frmLogin.userId, DateTime.Now.Date, txtNextCode.Text);
            }
        }
        private void insertInvItems()
        {
            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                if (dgvItems.Rows[i].Cells["Selected_Item"].Value != null && bool.Parse(dgvItems.Rows[i].Cells["Selected_Item"].Value.ToString()))
                {
                    DBClass.ExecuteNonQuery(@"INSERT INTO tbl_sales_return_details (sales_id, item_id, qty,cost_price, price, discount, vatp, vat, total, cost_center_id)
                                         VALUES (@sales_id, @item_id, @qty,@cost_price, @price, @discount, @vatp, @vat, @total, @costCenter);",
                  DBClass.CreateParameter("@sales_id", invId),
                  DBClass.CreateParameter("@item_id", dgvItems.Rows[i].Cells["itemId"].Value.ToString()),
                  DBClass.CreateParameter("@qty", dgvItems.Rows[i].Cells["qty"].Value == DBNull.Value ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["qty"].Value)),
                  DBClass.CreateParameter("@price", dgvItems.Rows[i].Cells["price"].Value == DBNull.Value || dgvItems.Rows[i].Cells["price"].Value.ToString() == "" ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["price"].Value)),
                  DBClass.CreateParameter("@discount", dgvItems.Rows[i].Cells["discount"].Value == DBNull.Value || dgvItems.Rows[i].Cells["discount"].Value.ToString() == "" ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["discount"].Value)),
                  DBClass.CreateParameter("@cost_price", dgvItems.Rows[i].Cells["cost_price"].Value == DBNull.Value || dgvItems.Rows[i].Cells["cost_price"].Value.ToString() == "" ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["cost_price"].Value)),
                  DBClass.CreateParameter("@vat", dgvItems.Rows[i].Cells["vat"].Value == null ? 0 : dgvItems.Rows[i].Cells["vat"].Value),
                  DBClass.CreateParameter("@vatp", dgvItems.Rows[i].Cells["vat"].Value == null ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["vatp"].Value)),
                  DBClass.CreateParameter("@total", dgvItems.Rows[i].Cells["total"].Value == null || dgvItems.Rows[i].Cells["total"].Value.ToString() == "" ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["total"].Value)),
                  DBClass.CreateParameter("@costCenter", dgvItems.Rows[i].Cells["Cost_Center"].Value ?? 0));

                    if (dgvItems.Rows[i].Cells["type"].Value.ToString() != "Service")
                    {
                        insertItemTransaction(dgvItems.Rows[i]);
                    }
                    //add cost center
                    if (dgvItems.Rows[i].Cells["Cost_Center"].Value != null && int.Parse(dgvItems.Rows[i].Cells["Cost_Center"].Value.ToString()) > 0)
                        CommonInsert.InsertCostCenterTransaction(dtInv.Value, Convert.ToDecimal(dgvItems.Rows[i].Cells["total"].Value ?? 0).ToString(), "0", invId.ToString(), "Sales Return", "", (dgvItems.Rows[i].Cells["Cost_Center"].Value ?? 0).ToString());
                }
            }
        }
        private void insertItemTransaction(DataGridViewRow row)
        {
            decimal qty = 0;
            if (row.Cells["itemId"].Value == null || string.IsNullOrWhiteSpace(row.Cells["itemId"].Value.ToString()))
            {
                MessageBox.Show("Invalid Item ID.");
                return;
            }

            if (!decimal.TryParse(row.Cells["qty"].Value.ToString(), out qty) || qty <= 0)
            {
                MessageBox.Show("Invalid Quantity.");
                return;
            }

            CommonInsert.InsertItemTransaction(dtInv.Value.Date, "Sales Return Invoice", invId.ToString(), row.Cells["itemId"].Value.ToString(), row.Cells["cost_price"].Value.ToString(),
                        row.Cells["qty"].Value.ToString(), row.Cells["price"].Value.ToString(), "0", row.Cells["qty"].Value.ToString(), "SalesReturn Invoice No. " + txtNextCode.Text, cmbWarehouse.SelectedValue.ToString());
        }
        private bool chkRequiredDate()
        {
            if(salesId <=0)
            {
                MessageBox.Show("Please select Sales Invoice to return items from.");
                return false;
            }

            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                if (dgvItems.Rows[i].Cells["Selected_Item"].Value != null && bool.Parse(dgvItems.Rows[i].Cells["Selected_Item"].Value.ToString()))
                {
                    if (dgvItems.Rows[i].Cells["total"].Value == null
                        || dgvItems.Rows[i].Cells["total"].Value.ToString() == ""
                        || decimal.Parse(dgvItems.Rows[i].Cells["total"].Value.ToString()) == 0)
                    {
                        MessageBox.Show("Total Item In Row " + (dgvItems.Rows[i].Index + 1) + " Can't Be 0 or Null");
                        return false;
                    }
                }
            }
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Customer Must be Selected.");
                txtCustomerCode.Focus();
                return false;
            }
            if (cmbAccountCashName.SelectedValue == null)
            {
                MessageBox.Show("Account Cash Name Must be Selected.");
                cmbAccountCashName.Focus();
                return false;
            }
            if (dgvItems.Rows.Count == 1)
            {
                MessageBox.Show("Insert Items First.");
                return false;
            }
            if (txtTotal.Text == "" || decimal.Parse(txtTotal.Text) == 0)
            {
                MessageBox.Show("Total Must Be Bigger Than Zero");
                return false;
            }
            return true;
        }
        private void resetTextBox()
        {
            txtSalesMan.Text = txtBillTo.Text = txtShipTo.Text =
                txtTotal.Text = txtTotalVat.Text = "";
            cmbPaymentMethod.SelectedIndex = id = 0;
            dtInv.Value = DateTime.Now;
            dgvItems.Rows.Clear();
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertInvoice())
                    resetTextBox();
            }
            else
            {
                if (updateInvoice())
                    resetTextBox();
            }
        }
        private void txtSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                txtBillTo.Text = txtCustomerCode.Text = "";
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where id = " + cmbCustomer.SelectedValue.ToString()))
                if (reader.Read())
                {
                    txtCustomerCode.Text = reader["code"].ToString();
                    txtBillTo.Text = cmbCustomer.Text;
                }
                else
                    txtBillTo.Text = txtCustomerCode.Text = "";
            if(cmbCustomer.Focused)
                clearData();
        }
        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.Text == "Cash")
            {
                cmbPaymentTerms.SelectedIndex = -1;
                cmbAccountCashName.Enabled = true;
                cmbPaymentTerms.Enabled = false;
            }
            else if (cmbPaymentMethod.Text == "Credit")
            {
                cmbPaymentTerms.SelectedIndex = 0;
                cmbAccountCashName.Enabled = false;
                cmbPaymentTerms.Enabled = true;
            }
        }
        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where id IN (SELECT customer_id from tbl_sales) and code =@code",
                DBClass.CreateParameter("code", txtCustomerCode.Text)))
                if (reader.Read())
                    cmbCustomer.SelectedValue = int.Parse(reader["id"].ToString());

            if (txtCustomerCode.Focused)
            {
                string input = txtCustomerCode.Text.Trim();
                clearData();

                if (string.IsNullOrEmpty(input))
                {
                    lstAccountSuggestions.Visible = false;
                    return;
                }
                string query = @"SELECT code, name FROM tbl_customer 
                         WHERE id IN (SELECT customer_id from tbl_sales) and code LIKE @search OR name LIKE @search LIMIT 20";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@search", "%" + input + "%"));

                lstAccountSuggestions.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    lstAccountSuggestions.Items.Add($"{row["code"]} - {row["name"]}");
                }
                if (lstAccountSuggestions.Items.Count > 0)
                {
                    Point locationOnForm = txtCustomerCode.Parent.PointToScreen(txtCustomerCode.Location);
                    Point locationRelativeToForm = this.PointToClient(locationOnForm);

                    lstAccountSuggestions.SetBounds(
                        locationRelativeToForm.X,
                        locationRelativeToForm.Y + txtCustomerCode.Height,
                        txtCustomerCode.Width + 100,
                        120
                    );

                    lstAccountSuggestions.Tag = txtCustomerCode;
                    lstAccountSuggestions.Visible = true;
                    lstAccountSuggestions.BringToFront();
                }
                else
                {
                    lstAccountSuggestions.Visible = false;
                }
            }
        }
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where id IN (SELECT customer_id from tbl_sales) and code =@code",
            DBClass.CreateParameter("code", txtCustomerCode.Text)))
                if (!reader.Read())
                    cmbCustomer.SelectedIndex = -1;

            BeginInvoke((Action)(() =>
            {
                if (!lstAccountSuggestions.Focused)
                    lstAccountSuggestions.Visible = false;
            }));
        }
        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int colIndex = dgvItems.CurrentCell.ColumnIndex;

            if (e.Control is TextBox textBoxBase)
            {
                textBoxBase.KeyPress -= NumericColumn_KeyPress;

                if (lstAccountSuggestions.Visible)
                    lstAccountSuggestions.Visible = false;

                lstAccountSuggestions.SendToBack();
            }

            if (colIndex == dgvItems.Columns["vat"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBoxTax_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBoxTax_SelectedIndexChanged;
                }
            }
            else if (dgvItems.CurrentCell.OwningColumn.Name == "qty" ||
                     dgvItems.CurrentCell.OwningColumn.Name == "price")
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= NumericColumn_KeyPress;
                    textBox.KeyPress += NumericColumn_KeyPress;
                }
            }
            else
            {
                lstAccountSuggestions.Visible = false;
                lstAccountSuggestions.Tag = null;
            }
        }

        private void NumericColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // block anything that's not a digit or decimal point
            }

            // Allow only one decimal point
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void ComboBoxTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.SelectedItem is DataRowView selectedRow)
            {
                if (dgvItems.CurrentCell == null || dgvItems.CurrentCell.ColumnIndex != dgvItems.Columns["vat"].Index)
                    return;

                var row = dgvItems.CurrentRow;
                if (row == null) return;

                string taxId = selectedRow["id"].ToString();
                string taxP = selectedRow["value"].ToString();

                decimal price = GetDecimalValue(row, "price");
                decimal discount = GetDecimalValue(row, "discount");
                decimal qty = GetDecimalValue(row, "qty");

                if (price == 0 || qty == 0)
                {
                    row.Cells["vatp"].Value = row.Cells["total"].Value = "0";
                }
                else
                {
                    decimal net = ((price - discount) * qty);
                    row.Cells["vat"].Value = Convert.ToInt32(taxId);
                    row.Cells["vatp"].Value = (net * decimal.Parse(taxP) / 100);
                    row.Cells["total"].Value = net + Convert.ToDecimal(row.Cells["vatp"].Value);
                }

                ChkRowValidity();
            }
        }
        private void ChkRowValidity()
        {
            var row = dgvItems.CurrentRow;
            if (row == null) return;

            decimal price = GetDecimalValue(dgvItems.CurrentRow, "price");
            decimal discount = GetDecimalValue(dgvItems.CurrentRow, "discount");
            decimal qty = GetDecimalValue(dgvItems.CurrentRow, "qty");

            if (price == 0 || qty == 0)
            {
                row.Cells["vatp"].Value = "0";
                row.Cells["total"].Value = "0";
                return;
            }

            try
            {
                decimal netPrice = (qty * (price - discount));

                string vatId = row.Cells["vat"].Value?.ToString() ?? "0";
                string vP = "0";

                DataTable vatTable = ((DataGridViewComboBoxColumn)dgvItems.Columns["vat"]).DataSource as DataTable;
                if (vatTable != null)
                {
                    DataRow[] matches = vatTable.Select("id = " + vatId);
                    if (matches.Length > 0)
                    {
                        vP = matches[0]["value"].ToString();
                    }
                }

                decimal vatValue = netPrice * Convert.ToDecimal(vP) / 100;
                row.Cells["vatp"].Value = vatValue;
                row.Cells["total"].Value = netPrice + vatValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("VAT calc error: " + ex.Message);
            }
        }
        
        void CalculateTotal()
        {
            decimal total = 0, vat = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells["total"].Value != null)
                    total += Convert.ToDecimal(row.Cells["total"].Value);
                if (row.Cells["vatp"].Value != null && row.Cells["vatp"].Value.ToString().Trim() != "")
                    vat += Convert.ToDecimal(row.Cells["vatp"].Value);

            }
            txtTotalBefore.Text = (total - vat).ToString("0.000");
            txtTotalVat.Text = vat.ToString("0.000");
            txtTotal.Text = total.ToString("0.000");
        }
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.Rows.Count > 1)
            {
                var row = dgvItems.Rows[e.RowIndex];
                decimal price = GetDecimalValue(row, "price");
                decimal qty = GetDecimalValue(row, "qty");
                decimal Sqty = GetDecimalValue(row, "S_Qty");
                
                decimal costPrice = GetDecimalValue(row, "cost_price");
                if (e.ColumnIndex == dgvItems.Columns["qty"].Index)
                {
                    if (dgvItems.CurrentRow.Cells["itemId"].Value == null)
                        row.Cells["qty"].Value = 0;

                    if (qty > Sqty)
                    {
                        MessageBox.Show("Qty not available in sales");
                        row.Cells["qty"].Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == dgvItems.Columns["Selected_Item"].Index)
                {
                    row.Cells["qty"].Value = 0;
                }

                ChkRowValidity();
                CalculateTotal();
            }
        }
        private decimal GetDecimalValue(DataGridViewRow row, string columnName)
        {
            decimal result;
            var cellValue = row.Cells[columnName].Value;
            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out result))
                return result;
            else
                return 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNextCode.Text))
                return;

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

            string query = "select id from tbl_sales_return where state = 0 and id =@id";

            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No Previous Invoice Found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
                return;

            int? currentId = Convert.ToInt32(txtId.Text); // Utilities.GetVoucherIdFromCode(txtInvoiceId.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            string query = "SELECT id FROM tbl_sales_return WHERE state = 0 AND id =@id";

            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No Next Invoice Found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void frmSalesReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
            EventHub.wareHouse -= warehouseUpdatedHandler;
        }

        private void cmbAccountCashName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountCashName.Focused && int.Parse(cmbAccountCashName.SelectedValue.ToString()) == -1)
            {
                new frmAddAccount().ShowDialog();
            }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvItems.Rows.Count > 1 && dgvItems.CurrentRow.Cells["delete"].ColumnIndex == e.ColumnIndex)
            //{
            //    dgvItems.Rows.Remove(dgvItems.CurrentRow);
            //    CalculateTotal();
            //}
        }
        private void dgvItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvItems.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        public DataTable COMPANYINFO(int id)
        {
            return DBClass.ExecuteDataTable("SELECT * FROM tbl_company ", DBClass.CreateParameter("@1", id));
        }

        public DataTable salesDetails(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT s.id,s.date,s.customer_id,s.invoice_id,s.bill_to,s.city,s.sales_man,s.ship_date,s.ship_via,s.ship_to,(SELECT NAME FROM tbl_coa_level_4 WHERE id=s.account_cash_id) accountName,s.po_num,s.payment_method,s.payment_terms,s.payment_date,s.total,s.vat,s.net,s.pay,s.change 
                                    ,c.name customerName,c.main_phone,c.email,c.trn FROM tbl_sales_return s,tbl_customer c WHERE s.customer_id = c.id AND s.id AND s.id=@salesId;", DBClass.CreateParameter("@salesId", a1));
        }
        public DataTable ItemDetails(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT d.id,d.item_id,i.name,d.qty,d.cost_price,d.price,(d.qty*d.cost_price) subCostTotal,(d.qty*d.price) subPriceTotal,d.discount,((d.qty*d.price)-d.discount) subTotal,d.vatp vatAmount,d.vat vatPercentage,d.total,d.cost_center_id,(SELECT NAME FROM tbl_sub_cost_center WHERE id=cost_center_id) costCenterName,i.type,i.method,i.unit_id,(select name from tbl_unit WHERE id=i.unit_id) unitName, i.code as code FROM tbl_sales_return_details d 
                                       INNER JOIN tbl_items i ON d.item_id = i.id WHERE d.sales_id=@salesId; ", DBClass.CreateParameter("@salesId", a1));
        }

        public void ShowReport()
        {
            try
            {
                string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", "SalesReturnInvoice.rpt");
                // Load the report file from disk
                ReportDocument cr = new ReportDocument();
                cr.Load(reportPath);
                DataTable companyData = COMPANYINFO(1);
                DataTable saleData = salesDetails(invId.ToString());
                DataTable itemData = ItemDetails(invId.ToString());
                if (companyData != null)
                {
                    cr.Subreports["CompanyHeader"].SetDataSource(companyData);
                    cr.Subreports["InvoiceHeader"].SetDataSource(saleData);
                    cr.Subreports["ItemDetails"].SetDataSource(itemData);
                }
                else
                {
                    MessageBox.Show("No data available for the report.");
                    return;
                }

                MasterReportView reportForm = new MasterReportView();
                reportForm.crReportViewer.ReportSource = cr;
                reportForm.crReportViewer.RefreshReport();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {
            preview();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0 || dgvItems.Rows.Count == 1 && dgvItems.Rows[0].IsNewRow)
            {
                MessageBox.Show("The Quotation Invoice  Update");
                // Optionally, you can stop the event if needed, but normally the event will end after the message.
                return;
            }


            if (id == 0)
            {
                if (insertInvoice())
                {
                    EventHub.RefreshSales();
                    MessageBox.Show("The Return Invoice  Saved");
                    dgvItems.Rows.Clear();
                    this.Close();
                    if (checkBox4.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
            else
            {
                if (updateInvoice())
                {
                    EventHub.RefreshSales();
                    MessageBox.Show("The Return Invoice  Saved");
                    dgvItems.Rows.Clear();
                    this.Close();
                    if (checkBox4.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2TileButton21_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery("UPDATE tbl_sales_return SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", id.ToString()));
            CommonInsert.DeleteItemTransaction("Sales Return", id.ToString());
            Utilities.LogAudit(frmLogin.userId, "Delete Sales Return", "Sales Return", id, "Deleted Sales Return Invoice No. " + txtNextCode.Text);
            clearData();
        }

        private void guna2TileButton23_Click(object sender, EventArgs e)
        {
            clearData();
        }
        private void clearData()
        {
            resetTextBox();
            id = 0; 
            txtNextCode.Text = GenerateNextSalesCode();
            txtId.Text = GenerateNextSalesId().ToString();
        }

        private void guna2TileButton22_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void guna2TileButton28_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmSalesByCustomerDetails(int.Parse(cmbCustomer.SelectedValue.ToString()), "tbl_sales_return"));
        }

        private void lstAccountSuggestions_Click(object sender, EventArgs e)
        {
            if (lstAccountSuggestions.SelectedItem == null)
                return;

            string selected = lstAccountSuggestions.SelectedItem.ToString();
            int separatorIndex = selected.IndexOf('-');
            if (separatorIndex == -1) return;

            string selectedCode = selected.Substring(0, separatorIndex).Trim();
            string selectedName = selected.Substring(separatorIndex + 1).Trim();

            if (lstAccountSuggestions.Tag is Guna2TextBox gunaTextBox)
            {
                gunaTextBox.Text = selectedCode;
                gunaTextBox.Focus();
                gunaTextBox.SelectionStart = gunaTextBox.Text.Length;

                if (gunaTextBox == txtCustomerCode)
                {
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select id from tbl_customer where code =@code",
                        DBClass.CreateParameter("code", selectedCode)))
                        if (reader.Read())
                            cmbCustomer.SelectedValue = int.Parse(reader["id"].ToString());
                }
            }

            lstAccountSuggestions.Visible = false;
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvItems.Rows[e.RowIndex];
            var columnName = dgvItems.Columns[e.ColumnIndex].Name;
            string inputText = row.Cells[e.ColumnIndex].Value?.ToString()?.Trim();
            var itemId = row.Cells["itemId"].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(itemId) || string.IsNullOrWhiteSpace(inputText))
                return;

            if ((columnName == "code" || columnName == "name") && lstAccountSuggestions.Items.Count <= 0)
            {
                DataGridViewRow newRow = dgvItems.CurrentRow;
                if (newRow != null)
                {
                    newRow.Cells["itemid"].Value = null;
                    newRow.Cells["cost_price"].Value = null;
                    newRow.Cells["price"].Value = null;
                    newRow.Cells["method"].Value = null;
                    newRow.Cells["type"].Value = null;
                    newRow.Cells["vat"].Value = null;
                    newRow.Cells["name"].Value = null;
                    newRow.Cells["code"].Value = null;
                }
            }
        }
        int salesId = 0;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmViewSalesList selectSalesForm = new frmViewSalesList(0,int.Parse(cmbCustomer.SelectedValue.ToString()));
            if (selectSalesForm.ShowDialog() == DialogResult.OK)
            {
                int selectedSalesId = selectSalesForm.SelectedSalesId;
                salesId = selectedSalesId;
                BindItemsLoad(selectedSalesId);
            }
        }

        private void BindItemsLoad(int refId)
        {
            dgvItems.Rows.Clear();
            string query = @"SELECT
                                tbl_sales_details.*, 
                                tbl_items.type, 
                                tbl_items.method, 
                                tbl_items.code, 
                                tbl_items.name,
                                tbl_sales.invoice_id,
                                tbl_sales.warehouse_id sales_warehouse
                            FROM tbl_sales_details
                            INNER JOIN tbl_items
                                ON tbl_sales_details.item_id = tbl_items.id
                            INNER JOIN tbl_sales
                                ON tbl_sales_details.sales_id = tbl_sales.id
                            WHERE tbl_sales_details.sales_id = @id;";
            string OldQuery = @"SELECT tbl_sales_details.*,tbl_items.type,method, tbl_items.code ,tbl_items.name FROM tbl_sales_details INNER JOIN 
                                                                    tbl_items ON tbl_sales_details.item_id = tbl_items.id WHERE 
                                                                    tbl_sales_details.sales_id = @id;";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query,
                                                            DBClass.CreateParameter("id", refId)))

                while (reader.Read())
                {
                    dgvItems.Rows.Add(reader["item_id"].ToString(), "", reader["code"].ToString(), reader["name"].ToString(), false, Utilities.FormatDecimal(reader["qty"].ToString()), "0",
                        Utilities.FormatDecimal(reader["cost_price"].ToString()), Utilities.FormatDecimal(reader["price"].ToString()), Utilities.FormatDecimal(reader["discount"].ToString()));

                    DataGridViewComboBoxCell comboCell = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vat"] as DataGridViewComboBoxCell;
                    if (comboCell != null && reader["vat"].ToString() != "0")
                    {
                        comboCell.Value = int.Parse(reader["vat"].ToString());
                        dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value = decimal.Parse(reader["vatP"].ToString());
                    }
                    DataGridViewComboBoxCell comboCellCostCenter = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["cost_center"] as DataGridViewComboBoxCell;
                    if (comboCellCostCenter != null && reader["cost_center_id"].ToString() != "0")
                    {
                        comboCellCostCenter.Value = int.Parse(reader["cost_center_id"].ToString());
                    }
                    int rowIndex = dgvItems.Rows.Count - 2;

                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["qty"].Value?.ToString(), out decimal qty0);
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["price"].Value?.ToString(), out decimal price0);
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["discount"].Value?.ToString(), out decimal discount0);
                    decimal.TryParse(dgvItems.Rows[rowIndex].Cells["vatp"].Value?.ToString(), out decimal vatp0);

                    dgvItems.Rows[rowIndex].Cells["total"].Value = (qty0 * (price0 - discount0)) + vatp0;
                    dgvItems.Rows[rowIndex].Cells["method"].Value = reader["method"]?.ToString() ?? "";
                    dgvItems.Rows[rowIndex].Cells["type"].Value = reader["type"]?.ToString() ?? "";


                    txtRefNo.Text = reader["invoice_id"].ToString();
                    cmbWarehouse.SelectedValue = int.Parse(reader["sales_warehouse"].ToString());
                }
        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            if (!txtRefNo.Focused)
                return;
            if (string.IsNullOrWhiteSpace(txtRefNo.Text))
                return;

            dgvItems.Rows.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id,warehouse_id FROM tbl_sales WHERE invoice_id = @invoiceId",
                DBClass.CreateParameter("invoiceId", txtRefNo.Text.Trim())))
            {
                if (reader.Read())
                {
                    salesId = int.Parse(reader["id"].ToString());
                    cmbWarehouse.SelectedValue = int.Parse(reader["warehouse_id"].ToString());
                    using (MySqlDataReader readerReturnSale = DBClass.ExecuteReader("SELECT id from tbl_sales_return where sales_ref_id = @id", DBClass.CreateParameter("id", salesId)))
                        if (readerReturnSale.Read())
                        {
                            MessageBox.Show("Return Already Exist INV : " + readerReturnSale["id"].ToString());
                        }
                        else
                        {
                            BindItemsLoad(salesId);
                        }
                }
                else
                {
                    salesId = 0;
                    dgvItems.Rows.Clear();
                }
            }
        }
    }
}
