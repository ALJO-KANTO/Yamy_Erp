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
using YamyProject.UI.Sales;

namespace YamyProject
{
    public partial class frmDeliveryNote : Form
    {
        private EventHandler customerUpdatedHandler;
        private EventHandler warehouseUpdatedHandler;

        decimal invId;
        int sId;
        int id;
        string formType = "";

        public frmDeliveryNote(int _id = 0, string _formType = "", int _sId = 0)
        {
            InitializeComponent();
            dgvItems.EnableHeadersVisualStyles = false; // important
            AppTheme.DefaultFont(dgvItems);
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            warehouseUpdatedHandler = (sender, args) => BindCombos.PopulateWarehouse(cmbWarehouse);
            EventHub.Customer += customerUpdatedHandler;
            EventHub.wareHouse += warehouseUpdatedHandler;
            this.formType = _formType;
            if (formType == "SI")
            {
                this.sId = _sId;
                txtPONO.Text = sId.ToString();
            }
            else
            {
                this.sId = _sId;
                txtPONO.Text = "";
            }
            this.id = _id;
            headerUC1.FormText = this.Text;
        }
        private void frmDeliveryNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
            EventHub.wareHouse -= warehouseUpdatedHandler;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDeliveryNote_Load(object sender, EventArgs e)
        {
            dtInv.Value = dtShip.Value = DateTime.Now.Date;
            AppTheme.DefaultFont(dgvItems);
            BindCombos.PopulateWarehouse(cmbWarehouse);
            if (cmbWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Enter At Least One Warehouse");
                new frmViewWarehouse().ShowDialog();
                BindCombos.PopulateWarehouse(cmbWarehouse, false, true);
            }
            loadVat();
            bindCombo();
            txtNextCode.Text = GenerateNextSalesCode();
            txtId.Text = GenerateNextSalesId();
            if (formType == "")
            {
                if (id != 0)
                {
                    btnSave.Enabled = true;// UserPermissions.canEdit("Delivery Note");
                    BindInvoice();
                }
            }
            else
            {
                if (id == 0 && sId > 0 && formType == "SI")
                {
                    txtPONO.Text = sId.ToString();
                    FetchFromSalesInvoice(txtPONO.Text);
                }
            }
        }

        private void BindInvoice()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_delivery_note where id = @id",
                DBClass.CreateParameter("id", id)))
                if (reader.Read())
                {
                    txtId.Text = reader["id"].ToString();
                    txtNextCode.Text = reader["invoice_id"].ToString();
                    cmbCustomer.SelectedValue = reader["customer_id"].ToString();
                    
                    cmbShipVia.Text = reader["ship_via"].ToString();
                    cmbWarehouse.SelectedValue = reader["warehouse_id"].ToString();
                    txtCustomerCode.Text = reader["invoice_id"].ToString();
                    invId = id;
                    txtBillTo.Text = reader["bill_to"].ToString();
                    txtShipTo.Text = reader["ship_to"].ToString();
                    if (int.TryParse(reader["sales_man"]?.ToString(), out int salesManId))
                    {
                        cmbSalesMan.SelectedValue = salesManId;
                    }
                    richTextDescription.Text = reader["description"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    BindInvoiceItems();
                    CalculateTotal();
                }
        }
        private void BindInvoiceItems()
        {
            dgvItems.Rows.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT tbl_delivery_note_details.*,tbl_items.type,method, tbl_items.code , tbl_items.name FROM tbl_delivery_note_details INNER JOIN 
                                                                    tbl_items ON tbl_delivery_note_details.item_id = tbl_items.id WHERE 
                                                                    tbl_delivery_note_details.sales_id = @id;",
                                                            DBClass.CreateParameter("id", id)))
                while (reader.Read())
                {
                    dgvItems.Rows.Add(reader["item_id"].ToString(), "", reader["code"].ToString(), reader["name"].ToString(), reader["qty"].ToString(),
                        reader["cost_price"].ToString(), reader["price"].ToString());
                    DataGridViewComboBoxCell comboCell = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vat"] as DataGridViewComboBoxCell;
                    if (comboCell != null && reader["vat"].ToString() != "0")
                    {
                        comboCell.Value = int.Parse(reader["vat"].ToString());
                        dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value = decimal.Parse(reader["vatP"].ToString());
                    }

                    decimal netPrice = (decimal.Parse(dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["qty"].Value.ToString()) * decimal.Parse(dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["price"].Value.ToString()));
                    dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["total"].Value = (netPrice + decimal.Parse(dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value == null ? "0" : dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value.ToString()));
                    dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["method"].Value = reader["method"].ToString();
                    dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["type"].Value = reader["type"].ToString();
                }
        }

        private void loadVat()
        {
            DataTable dt = DBClass.ExecuteDataTable("select id, concat(name,'-',value , '%') as name,value from tbl_tax");
            DataGridViewComboBoxColumn vat = (DataGridViewComboBoxColumn)dgvItems.Columns["vat"];
            vat.DataSource = dt;
            vat.DisplayMember = "name";
            vat.ValueMember = "id";
            vat.FlatStyle = FlatStyle.Popup;
            vat.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            vat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            var dTax = Utilities.GeneralSettings("DEFAULT TAX PERCENTAGE");
            if (!string.IsNullOrEmpty(dTax) & int.Parse(dTax) > 0)
            {
                defaultTax = dTax;
            }
        }
        string defaultTax = "";
        private void bindCombo()
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            BindCombos.PopulateEmployees(cmbSalesMan);
        }
        private string GenerateNextSalesCode()
        {
            string newCode = "DN-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(invoice_id, 4) AS UNSIGNED)) AS lastCode FROM tbl_delivery_note"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "DN-" + code.ToString("D4");
                }
            }

            return newCode;
        }
        private string GenerateNextSalesId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_delivery_note"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }

        private DataTable GetFilteredProductsByName(string name = "")
        {
            int selectedWarehouseId = cmbWarehouse.SelectedValue == null ? 0 : Convert.ToInt32(cmbWarehouse.SelectedValue);

            string allItemsOption = Utilities.GeneralSettingsState("ALL ITEMS IN SALES");
            string warehouseOption = Utilities.GeneralSettingsState("WAREHOUSE ITEMS IN SALES 0");

            var parameters = new List<MySqlParameter>();
            string query;

            if (!string.IsNullOrEmpty(warehouseOption) && cmbWarehouse.Items.Count > 1)
            {
                // Use tbl_items_warehouse join
                query = @"
                        SELECT i.code, i.name 
                        FROM tbl_items_warehouse w
                        INNER JOIN tbl_items i ON w.item_id = i.id
                        WHERE w.warehouse_id = @warehouseId
                          AND i.state = 0 AND i.active = 0";

                parameters.Add(new MySqlParameter("@warehouseId", selectedWarehouseId));
            }
            else
            {
                // Use tbl_items directly
                query = "SELECT code, name FROM tbl_items WHERE state = 0 AND active = 0";

                if (string.IsNullOrEmpty(allItemsOption) || int.Parse(allItemsOption) <= 0)
                {
                    query += " AND type IN ('11 - Inventory Part', '12 - Service')";
                }

                if (!string.IsNullOrEmpty(warehouseOption))
                {
                    query += " AND warehouse_id = @warehouseId";
                    parameters.Add(new MySqlParameter("@warehouseId", selectedWarehouseId));
                }
            }

            // Apply name filter if provided
            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND name LIKE @name";
                parameters.Add(new MySqlParameter("@name", $"%{name}%"));
            }

            query += " ORDER BY name LIMIT 20";

            return DBClass.ExecuteDataTable(query, parameters.ToArray());
        }

        private DataTable GetFilteredProductsByCode(string code = "")
        {
            int selectedWarehouseId = cmbWarehouse.SelectedValue == null ? 0 : Convert.ToInt32(cmbWarehouse.SelectedValue);

            string allItemsOption = Utilities.GeneralSettingsState("ALL ITEMS IN SALES");
            string warehouseOption = Utilities.GeneralSettingsState("WAREHOUSE ITEMS IN SALES 0");

            var parameters = new List<MySqlParameter>();
            string query;

            if (!string.IsNullOrEmpty(warehouseOption) && cmbWarehouse.Items.Count > 1)
            {
                // Use tbl_items_warehouse join
                query = @"
                        SELECT i.code, i.name 
                        FROM tbl_items_warehouse w
                        INNER JOIN tbl_items i ON w.item_id = i.id
                        WHERE w.warehouse_id = @warehouseId
                          AND i.state = 0 AND i.active = 0";

                parameters.Add(new MySqlParameter("@warehouseId", selectedWarehouseId));
            }
            else
            {
                // Use tbl_items directly
                query = "SELECT code, name FROM tbl_items WHERE state = 0 AND active = 0";

                if (string.IsNullOrEmpty(allItemsOption) || int.Parse(allItemsOption) <= 0)
                {
                    query += " AND type IN ('11 - Inventory Part', '12 - Service')";
                }

                if (!string.IsNullOrEmpty(warehouseOption))
                {
                    query += " AND warehouse_id = @warehouseId";
                    parameters.Add(new MySqlParameter("@warehouseId", selectedWarehouseId));
                }
            }

            // Apply code filter if provided
            if (!string.IsNullOrWhiteSpace(code))
            {
                query += " AND code LIKE @code";
                parameters.Add(new MySqlParameter("@code", $"%{code}%"));
            }

            query += " ORDER BY code LIMIT 20";

            return DBClass.ExecuteDataTable(query, parameters.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0 || dgvItems.Rows.Count == 1 && dgvItems.Rows[0].IsNewRow)
            {
                MessageBox.Show("Can't Save Empty Delivery Note");
                // Optionally, you can stop the event if needed, but normally the event will end after the message.
                return;
            }
            if (id == 0)
            {
                if (insertInvoice())
                {
                    EventHub.RefreshDeliveryNote();
                    MessageBox.Show("The Delivery Note  Saved");
                    dgvItems.Rows.Clear();

                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
            else
            {
                if (updateInvoice())
                {
                    EventHub.RefreshDeliveryNote();
                    MessageBox.Show("The Delivery Note  Update");
                    dgvItems.Rows.Clear();

                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
          
        }
        private bool updateInvoice()
        {
            if (!chkRequiredDate())
                return false;

            DBClass.ExecuteNonQuery(@"UPDATE tbl_delivery_note 
                                     SET  modified_by = @modifiedBy, modified_date = @modifiedDate ,date = @date,sales_man=@sales_man, customer_id = @customer_id, invoice_id = @invoice_id, warehouse_id = @warehouse_id,
                                     po_num = @po_num, bill_to = @bill_to, ship_date = @ship_date, 
                                     ship_via = @ship_via, ship_to = @ship_to, address = @address, total = @total, 
                                     vat = @vat, net = @net, city = @city, description = @description WHERE id = @id;",
                                       DBClass.CreateParameter("id", id),
                                       DBClass.CreateParameter("date", dtInv.Value.Date),
                                       DBClass.CreateParameter("customer_id", cmbCustomer.SelectedValue),
                                       DBClass.CreateParameter("invoice_id", txtNextCode.Text),
                                       DBClass.CreateParameter("warehouse_id", cmbWarehouse.SelectedValue),
                                       DBClass.CreateParameter("po_num", txtPONO.Text),
                                       DBClass.CreateParameter("bill_to", txtBillTo.Text),
                                       DBClass.CreateParameter("city", cmbCity.Text),
                                       DBClass.CreateParameter("address", txtAddress.Text),
                                       DBClass.CreateParameter("ship_date", dtShip.Value.Date),
                                       DBClass.CreateParameter("sales_man", (cmbSalesMan.SelectedValue == null ? "0" : cmbSalesMan.SelectedValue.ToString())),
                                       DBClass.CreateParameter("ship_via", cmbShipVia.Text),
                                       DBClass.CreateParameter("ship_to", txtShipTo.Text),
                                       DBClass.CreateParameter("vat", txtTotalVat.Text),
                                       DBClass.CreateParameter("total", txtTotalBefore.Text),
                                       DBClass.CreateParameter("net", txtTotal.Text),
                                       DBClass.CreateParameter("description", richTextDescription.Text),
                                       DBClass.CreateParameter("@modifiedBy", frmLogin.userId),
                                       DBClass.CreateParameter("@modifiedDate", DateTime.Now.Date)
                                    );

            DBClass.ExecuteNonQuery("delete from tbl_delivery_note_details where sales_id =@id", DBClass.CreateParameter("id", id));
            insertInvItems();
            Utilities.LogAudit(frmLogin.userId, "Update Delivery Note", "Delivery Note", id, "Updated Delivery Note: " + txtNextCode.Text);

            if (!string.IsNullOrEmpty(filePath))
            {
                AddFileData(id);
            }


            return true;
        }

        private bool insertInvoice()
        {
            if (!chkRequiredDate())
                return false;

            invId = decimal.Parse(DBClass.ExecuteScalar(@"INSERT INTO tbl_delivery_note (date, customer_id, invoice_id,warehouse_id, po_num, bill_to,city,sales_man,
               ship_date,ship_via, ship_to, address, total,vat,net, created_by, created_date, state, description) 
               VALUES (@DATE, @customer_id, @invoice_id,@warehouse_id,
               @po_num, @bill_to,@city,@sales_man, @ship_date, @ship_via,@ship_to, @address, 
               @total,  @vat,@net, @created_by, @created_date, @state, @description);
               SELECT LAST_INSERT_ID();",
               DBClass.CreateParameter("date", dtInv.Value.Date),
               DBClass.CreateParameter("customer_id", cmbCustomer.SelectedValue),
               DBClass.CreateParameter("invoice_id", txtNextCode.Text),
               DBClass.CreateParameter("city", cmbCity.Text),
               DBClass.CreateParameter("warehouse_id", cmbWarehouse.SelectedValue),
               DBClass.CreateParameter("po_num", txtPONO.Text),
               DBClass.CreateParameter("bill_to", txtBillTo.Text),
               DBClass.CreateParameter("ship_date", dtShip.Value.Date),
               DBClass.CreateParameter("sales_man", (cmbSalesMan.SelectedValue == null ? "0" : cmbSalesMan.SelectedValue.ToString())),
               DBClass.CreateParameter("ship_via", cmbShipVia.Text),
               DBClass.CreateParameter("ship_to", txtShipTo.Text),
               DBClass.CreateParameter("address", txtAddress.Text),
               DBClass.CreateParameter("vat", txtTotalVat.Text),
               DBClass.CreateParameter("total", txtTotalBefore.Text),
               DBClass.CreateParameter("net", txtTotal.Text),
               DBClass.CreateParameter("description", richTextDescription.Text),
               DBClass.CreateParameter("created_by", frmLogin.userId),
               DBClass.CreateParameter("created_date", DateTime.Now.Date),
               DBClass.CreateParameter("state", 0)).ToString());
                insertInvItems();

            Utilities.LogAudit(frmLogin.userId, "Add Delivery Note", "Delivery Note", (int)invId, "Added Delivery Note: " + txtNextCode.Text);

            if (!string.IsNullOrEmpty(filePath))
            {
                AddFileData((int)invId);
            }

            return true;
        }
        private void insertInvItems()
        {
            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                int itemId = Convert.ToInt32(dgvItems.Rows[i].Cells["itemId"].Value);
                decimal qty = dgvItems.Rows[i].Cells["qty"].Value == DBNull.Value ? 0 : Convert.ToDecimal(dgvItems.Rows[i].Cells["qty"].Value);
                string itemType = dgvItems.Rows[i].Cells["type"].Value.ToString();
                string method = dgvItems.Rows[i].Cells["method"].Value.ToString();

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_delivery_note_details (sales_id, item_id, qty, cost_price, price, vatp, vat, total)
                    VALUES (@sales_id, @item_id, @qty, @cost_price, @price, @vatp, @vat, @total);",
                    DBClass.CreateParameter("sales_id", invId),
                    DBClass.CreateParameter("item_id", itemId),
                    DBClass.CreateParameter("qty", qty),
                    DBClass.CreateParameter("price", dgvItems.Rows[i].Cells["price"].Value ?? 0),
                    DBClass.CreateParameter("cost_price", dgvItems.Rows[i].Cells["cost_price"].Value.ToString() == "" ? null : dgvItems.Rows[i].Cells["cost_price"].Value.ToString()),
                    DBClass.CreateParameter("vat", dgvItems.Rows[i].Cells["vat"].Value ?? 0),
                    DBClass.CreateParameter("vatp", Convert.ToDecimal(dgvItems.Rows[i].Cells["vatp"].Value ?? 0)),
                    DBClass.CreateParameter("total", Convert.ToDecimal(dgvItems.Rows[i].Cells["total"].Value ?? 0))
                );

            }
        }
        private bool chkRequiredDate()
        {
            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                if (dgvItems.Rows[i].Cells["total"].Value == null
                    || dgvItems.Rows[i].Cells["total"].Value.ToString() == ""
                    || decimal.Parse(dgvItems.Rows[i].Cells["total"].Value.ToString()) == 0)
                {
                    MessageBox.Show("Total Item In Row " + (dgvItems.Rows[i].Index + 1) + " Can't Be 0 or Null");
                    return false;
                }
            }
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Customer Must be Selected.");
                cmbCustomer.Focus();
                return false;
            }
            if(cmbSalesMan.SelectedValue == null)
            {
                MessageBox.Show("Salesman Must be Selected.");
                cmbSalesMan.Focus();
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
            if (txtShipTo.Text == "")
            {
                MessageBox.Show("Ship To can't empty");
                return false;
            }
            return true;
        }
        private void resetTextBox()
        {
            txtBillTo.Text = txtShipTo.Text = txtPONO.Text =
                txtTotal.Text = txtTotalVat.Text = "";
            cmbSalesMan.SelectedIndex = id = 0;
            dtInv.Value = DateTime.Now;
            dgvItems.Rows.Clear();
            txtNextCode.Text = GenerateNextSalesCode();
            txtId.Text = GenerateNextSalesId();
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertInvoice())
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
        }
        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where code =@code",
                DBClass.CreateParameter("code", txtCustomerCode.Text)))
                if (reader.Read())
                    cmbCustomer.SelectedValue = int.Parse(reader["id"].ToString());

            if (txtCustomerCode.Focused)
            {
                string input = txtCustomerCode.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    lstAccountSuggestions.Visible = false;
                    return;
                }
                string query = @"SELECT code, name FROM tbl_customer 
                         WHERE code LIKE @search OR name LIKE @search LIMIT 20";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@search", "%" + input + "%"));

                lstAccountSuggestions.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    lstAccountSuggestions.Items.Add(new ItemSuggestion
                    {
                        Code = row["code"].ToString(),
                        Name = row["name"].ToString()
                    });
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
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where code =@code",
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
                textBoxBase.TextChanged -= ItemCode_TextChanged;
                textBoxBase.TextChanged -= ItemName_TextChanged;
                textBoxBase.KeyPress -= NumericColumn_KeyPress;

                if (lstAccountSuggestions.Visible)
                    lstAccountSuggestions.Visible = false;

                lstAccountSuggestions.SendToBack();
            }

            if (colIndex == dgvItems.Columns["name"].Index)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.TextChanged -= ItemName_TextChanged;
                    textBox.TextChanged += ItemName_TextChanged;
                    lstAccountSuggestions.Tag = textBox;
                }
            }
            else if (colIndex == dgvItems.Columns["vat"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBoxTax_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBoxTax_SelectedIndexChanged;
                }
            }
            else if (colIndex == dgvItems.Columns["code"].Index)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.TextChanged -= ItemCode_TextChanged;
                    textBox.TextChanged += ItemCode_TextChanged;
                    lstAccountSuggestions.Tag = textBox;
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

        private void ItemCode_TextChanged(object sender, EventArgs e)
        {
            TextBox editingTextBox = sender as TextBox;
            if (editingTextBox == null) return;

            string input = editingTextBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                lstAccountSuggestions.Visible = false;
                return;
            }

            DataTable filtered = GetFilteredProductsByCode(input);

            lstAccountSuggestions.Items.Clear();

            foreach (DataRow row in filtered.Rows)
            {
                lstAccountSuggestions.Items.Add(new ItemSuggestion { Code = row["code"].ToString(), Name = row["name"].ToString() });
            }

            if (lstAccountSuggestions.Items.Count > 0)
            {
                // Get cell location
                var cellRect = dgvItems.GetCellDisplayRectangle(dgvItems.CurrentCell.ColumnIndex, dgvItems.CurrentCell.RowIndex, true);
                Point locationOnForm = dgvItems.PointToScreen(cellRect.Location);
                Point locationRelativeToForm = this.PointToClient(locationOnForm);

                lstAccountSuggestions.SetBounds(
                    locationRelativeToForm.X,
                    locationRelativeToForm.Y + cellRect.Height,
                    cellRect.Width + 100,
                    120
                );

                lstAccountSuggestions.Tag = editingTextBox;
                lstAccountSuggestions.Visible = true;
                lstAccountSuggestions.BringToFront();
            }
            else
            {
                lstAccountSuggestions.Visible = false;
            }
        }

        private void ItemName_TextChanged(object sender, EventArgs e)
        {
            TextBox editingTextBox = sender as TextBox;
            if (editingTextBox == null) return;

            string input = editingTextBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                lstAccountSuggestions.Visible = false;
                return;
            }

            DataTable filtered = GetFilteredProductsByName(input);

            lstAccountSuggestions.Items.Clear();

            foreach (DataRow row in filtered.Rows)
            {
                lstAccountSuggestions.Items.Add(new ItemSuggestion { Code = row["code"].ToString(), Name = row["name"].ToString() });
            }

            if (lstAccountSuggestions.Items.Count > 0)
            {
                // Get cell location
                var cellRect = dgvItems.GetCellDisplayRectangle(dgvItems.CurrentCell.ColumnIndex, dgvItems.CurrentCell.RowIndex, true);
                Point locationOnForm = dgvItems.PointToScreen(cellRect.Location);
                Point locationRelativeToForm = this.PointToClient(locationOnForm);

                lstAccountSuggestions.SetBounds(
                    locationRelativeToForm.X,
                    locationRelativeToForm.Y + cellRect.Height,
                    cellRect.Width + 100,
                    120
                );

                lstAccountSuggestions.Tag = editingTextBox;
                lstAccountSuggestions.Visible = true;
                lstAccountSuggestions.BringToFront();
            }
            else
            {
                lstAccountSuggestions.Visible = false;
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
                decimal qty = GetDecimalValue(row, "qty");

                if (price == 0 || qty == 0)
                {
                    row.Cells["vatp"].Value = row.Cells["total"].Value = "0";
                }
                else
                {
                    decimal net = (price * qty);
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
            decimal qty = GetDecimalValue(dgvItems.CurrentRow, "qty");

            if (price == 0 || qty == 0)
            {
                row.Cells["vatp"].Value = "0";
                row.Cells["total"].Value = "0";
                return;
            }

            try
            {
                decimal netPrice = (qty * price);

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

        decimal GetTotalQtyInGrid(int itemId)
        {
            decimal totalQty = 0;

            for (int i = 0; i < dgvItems.Rows.Count; i++)
                if (dgvItems.Rows[i].Cells["itemId"].Value != null &&
                    dgvItems.Rows[i].Cells["itemId"].Value.ToString() == itemId.ToString())
                    if (dgvItems.Rows[i].Cells["qty"].Value != null &&
                        dgvItems.Rows[i].Cells["qty"].Value.ToString() != "")
                        totalQty += decimal.Parse(dgvItems.Rows[i].Cells["qty"].Value.ToString());

            return totalQty;
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
                decimal costPrice = GetDecimalValue(row, "cost_price");
                if (e.ColumnIndex == dgvItems.Columns["price"].Index && dgvItems.Rows[e.RowIndex].Cells["type"].Value != null && dgvItems.Rows[e.RowIndex].Cells["type"].Value.ToString() != "Service")
                {
                    if (price < costPrice)
                    {
                        MessageBox.Show("Sales Price Must Be Greater Than Cost Price");
                        row.Cells["price"].Value = costPrice;
                    }
                }
                else if (e.ColumnIndex == dgvItems.Columns["Code"].Index)
                {
                    string codeValue = row.Cells["Code"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(codeValue))
                        insertItemThroughCodeOrText("code", codeValue);
                }
                else if (e.ColumnIndex == dgvItems.Columns["Name"].Index)
                {
                    string nameValue = row.Cells["Name"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(nameValue))
                        insertItemThroughCodeOrText("name", nameValue);
                }
                else if (e.ColumnIndex == dgvItems.Columns["qty"].Index)
                {
                    decimal salesQty = 0;
                    if (id != 0)
                    {
                        string _itemId = dgvItems.CurrentRow.Cells["itemid"].Value==null ? "0" : dgvItems.CurrentRow.Cells["itemid"].Value.ToString();
                        using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_delivery_note_details where sales_id = @sales_id and item_id = @item_id",
                          DBClass.CreateParameter("sales_id", id),
                          DBClass.CreateParameter("item_id", _itemId)))
                            if (reader.Read() && reader["qty"].ToString() != "")
                                salesQty = decimal.Parse(reader["qty"].ToString());
                    }
                    if (dgvItems.CurrentRow.Cells["itemId"].Value == null)
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
        private void insertItemThroughCodeOrText(string type, string inputText = null)
        {
            if (string.IsNullOrWhiteSpace(inputText))
                return;

            MySqlDataReader reader = null;
            try
            {
                if (type == "code")
                {
                    reader = DBClass.ExecuteReader(@"
                            SELECT id, method, type, code, sales_price, cost_price, name 
                            FROM tbl_items 
                            WHERE code = @code",
                        DBClass.CreateParameter("code", inputText.Trim()));
                }
                else if (type == "name")
                {
                    // Search by name (case-insensitive)
                    reader = DBClass.ExecuteReader(@"
                                SELECT id, method, type, code, sales_price, cost_price, name 
                                FROM tbl_items 
                                WHERE name = @name COLLATE utf8mb4_general_ci LIMIT 1",
                        DBClass.CreateParameter("name", inputText.Trim()));
                }

                if (reader != null && reader.Read())
                {
                    dgvItems.CurrentRow.Cells["qty"].Value = 0;
                    dgvItems.CurrentRow.Cells["itemid"].Value = reader["id"].ToString();
                    dgvItems.CurrentRow.Cells["cost_price"].Value = reader["cost_price"].ToString();
                    dgvItems.CurrentRow.Cells["price"].Value = reader["sales_price"];
                    dgvItems.CurrentRow.Cells["method"].Value = reader["method"];
                    dgvItems.CurrentRow.Cells["type"].Value = reader["type"];
                    dgvItems.CurrentRow.Cells["code"].Value = reader["code"].ToString();
                    dgvItems.CurrentRow.Cells["name"].Value = reader["name"].ToString();

                    // Optional default VAT
                    if (!string.IsNullOrEmpty(defaultTax))
                    {
                        dgvItems.CurrentRow.Cells["vat"].Value = int.Parse(defaultTax);
                    }
                }
                else
                {
                    DataGridViewRow row = dgvItems.CurrentRow;
                    if (row != null)
                    {
                        row.Cells["itemid"].Value = null;
                        row.Cells["cost_price"].Value = null;
                        row.Cells["price"].Value = null;
                        row.Cells["method"].Value = null;
                        row.Cells["type"].Value = null;
                        row.Cells["vat"].Value = null;
                        if (type == "name")
                            row.Cells["code"].Value = null;
                        if (type == "code")
                            row.Cells["name"].Value = null;
                    }
                }
            }
            finally
            {
                reader?.Close();
                reader?.Dispose();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
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

            string query = "select id from tbl_delivery_note where state = 0 and id =@id";

            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
                return;

            int? currentId = Convert.ToInt32(txtId.Text); // Utilities.GetVoucherIdFromCode(txtInvoiceId.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            string query = "SELECT id FROM tbl_delivery_note WHERE state = 0 AND id =@id";

            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No next records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void lnkNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewCustomer(0));
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.Rows.Count > 1 && dgvItems.CurrentRow.Cells["delete"].ColumnIndex == e.ColumnIndex)
            {
                dgvItems.Rows.Remove(dgvItems.CurrentRow);
                CalculateTotal();
            }
        }
        private void dgvItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvItems.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        public DataTable COMPANYINFO(int id)
        {
            return DBClass.ExecuteDataTable("SELECT * FROM tbl_company   LIMIT 1 ", DBClass.CreateParameter("@1", id));
        }

        public DataTable SalesDetails(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT s.id,s.date,s.customer_id,s.invoice_id,s.bill_to,s.city,s.sales_man,s.ship_date,s.ship_via,s.ship_to,IFNULL((SELECT NAME FROM tbl_employee e WHERE e.id = s.sales_man),'') accountName,s.po_num,s.address payment_method,'' payment_terms,'2020-01-01' payment_date,s.total,s.vat,s.net,s.net pay,0 `change` 
                                    ,c.name customerName,c.main_phone,c.email,c.trn FROM tbl_delivery_note s,tbl_customer c WHERE s.customer_id = c.id AND s.id AND s.id = @salesId;", DBClass.CreateParameter("@salesId", a1));
        }

        public DataTable ItemDetails(string a1)
        {
            return DBClass.ExecuteDataTable(@"SELECT d.id,d.item_id,i.name,d.qty,d.cost_price,d.price,(d.qty*d.cost_price) subCostTotal,(d.qty*d.price) subPriceTotal,0 discount,((d.qty*d.price)) subTotal,d.vatp vatAmount,d.vat vatPercentage,d.total,d.cost_center_id,(SELECT NAME FROM tbl_sub_cost_center WHERE id=cost_center_id) costCenterName,i.type,i.method,i.unit_id,(select name from tbl_unit WHERE id=i.unit_id) unitName, i.code as code FROM  tbl_delivery_note_details d 
                                       INNER JOIN tbl_items i ON d.item_id = i.id WHERE d.sales_id=@salesId; ", DBClass.CreateParameter("@salesId", a1));
        }

        public void ShowReport()
        {
            ShowReportS("DeliveryNote.rpt", "CompanyHeader", "SalesHeader", "ItemsHeader");
        }
        private void ShowReportS(string reportFileName, string companySubReportName, string salesSubReportName, string itemsSubReportName)
        {
            try
            {
                string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", reportFileName);
                ReportDocument cr = new ReportDocument();
                cr.Load(reportPath);

                DataTable companyData = COMPANYINFO(1);
                DataTable salesData = SalesDetails(invId.ToString());
                DataTable itemData = ItemDetails(invId.ToString());

                if (companyData == null || companyData.Rows.Count == 0)
                {
                    MessageBox.Show("No company data available for the report.");
                    return;
                }

                if (salesData == null || salesData.Rows.Count == 0)
                {
                    MessageBox.Show("No sales data available for the report.");
                    return;
                }

                if (itemData == null || itemData.Rows.Count == 0)
                {
                    MessageBox.Show("No item data available for the report.");
                    return;
                }

                cr.Subreports[companySubReportName].SetDataSource(companyData);
                cr.Subreports[salesSubReportName].SetDataSource(salesData);
                cr.Subreports[itemsSubReportName].SetDataSource(itemData);

                using (var reportForm = new MasterReportView())
                {
                    reportForm.crReportViewer.ReportSource = cr;
                    reportForm.crReportViewer.RefreshReport();
                    reportForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing report: " + ex.Message);
            }
        }

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0 || dgvItems.Rows.Count == 1 && dgvItems.Rows[0].IsNewRow)
            {
                MessageBox.Show("Can't Save Empty Delivery Note");
                // Optionally, you can stop the event if needed, but normally the event will end after the message.
                return;
            }
            if (id == 0)
            {
                if (insertInvoice())
                {
                    EventHub.RefreshDeliveryNote();
                    MessageBox.Show("The Delivery Note  Saved");
                    dgvItems.Rows.Clear();

                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                    this.Close();
                }
            }
            else
            {
                if (updateInvoice())
                {
                    EventHub.RefreshDeliveryNote();
                    MessageBox.Show("The Delivery Note  Update");
                    dgvItems.Rows.Clear();

                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                    this.Close();
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

        private void guna2TileButton28_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmSalesByCustomerDetails(int.Parse(cmbCustomer.SelectedValue.ToString()), "tbl_delivery_note"));
        }

        private void guna2TileButton21_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery("UPDATE tbl_delivery_note SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", id.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Delivery Note", "Delivery Note", id, "Deleted Delivery Note: " + txtNextCode.Text);
            id = 0;
            clearData();
        }

        private void guna2TileButton23_Click(object sender, EventArgs e)
        {
            txtNextCode.Text = GenerateNextSalesCode();
            clearData();
        }
        private void clearData()
        {
            resetTextBox();
            id = 0;
        }
        private void guna2TileButton22_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void guna2TileButton20_Click(object sender, EventArgs e)
        {
            id = 0;
        }

        private void lstAccountSuggestions_Click(object sender, EventArgs e)
        {
            if (lstAccountSuggestions.SelectedItem == null)
                return;

            string selected = lstAccountSuggestions.SelectedItem.ToString();
            //int separatorIndex = selected.IndexOf('-');
            //if (separatorIndex == -1) return;

            string selectedCode = "";// selected.Substring(0, separatorIndex).Trim();
            string selectedName = "";// selected.Substring(separatorIndex + 1).Trim();

            if (lstAccountSuggestions.SelectedItem is ItemSuggestion item)
            {
                selectedCode = item.Code;
            }

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
            else if (lstAccountSuggestions.Tag is TextBox textBox)
            {
                if (dgvItems.CurrentCell != null && dgvItems.CurrentCell.ColumnIndex == dgvItems.Columns["code"].Index)
                {
                    dgvItems.CurrentCell.Value = selectedCode;
                }
                else if (dgvItems.CurrentCell != null && dgvItems.CurrentCell.ColumnIndex == dgvItems.Columns["name"].Index)
                {
                    dgvItems.CurrentCell.Value = selectedName;
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

        string filePath = "";
        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
        }

        private void AddFileData(int fId)
        {
            AttachmentManager.SaveAttachment(
                    "SALES Delivery Note",
                    fId,
                    openFileDialog1.FileName
                );
        }

        private void txtPONO_TextChanged(object sender, EventArgs e)
        {
            if (!txtPONO.Focused)
                return;

            if (string.IsNullOrEmpty(txtPONO.Text))
                return;

            FetchFromSalesInvoice(txtPONO.Text);
        }

        private void FetchFromSalesInvoice(string refId)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader(" select * from tbl_sales where id = @id",
                DBClass.CreateParameter("id", refId)))
                if (reader.Read())
                {
                    //txtPONO.Text = reader["id"].ToString();
                    dtInv.Value = DateTime.Parse(reader["date"].ToString());
                    cmbCustomer.SelectedValue = reader["customer_id"].ToString();
                    cmbShipVia.Text = reader["ship_via"].ToString();
                    richTextDescription.Text = reader["description"].ToString();
                    cmbWarehouse.SelectedValue = reader["warehouse_id"].ToString();
                    //txtNextCode.Text = reader["invoice_id"].ToString();
                    //invId = id;
                    txtBillTo.Text = reader["bill_to"].ToString();
                    txtShipTo.Text = reader["ship_to"].ToString();
                    if (int.TryParse(reader["sales_man"]?.ToString(), out int salesManId))
                    {
                        cmbSalesMan.SelectedValue = salesManId;
                    }

                    InvoiceItems(txtPONO.Text);
                    CalculateTotal();
                }
        }

        private void InvoiceItems(string refId)
        {
            dgvItems.Rows.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT tbl_sales_details.*,tbl_items.type,method, tbl_items.code, tbl_items.name FROM tbl_sales_details INNER JOIN 
                                                                    tbl_items ON tbl_sales_details.item_id = tbl_items.id WHERE 
                                                                    tbl_sales_details.sales_id = @id;",
                                                            DBClass.CreateParameter("id", refId)))
                while (reader.Read())
                {
                    dgvItems.Rows.Add(reader["item_id"].ToString(), "", reader["code"].ToString(), reader["name"].ToString(), Utilities.FormatDecimal(reader["qty"]),
                        Utilities.FormatDecimal(reader["cost_price"]), Utilities.FormatDecimal(reader["price"]));
                    DataGridViewComboBoxCell comboCell = dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vat"] as DataGridViewComboBoxCell;
                    if (comboCell != null && reader["vat"].ToString() != "0")
                    {
                        comboCell.Value = int.Parse(reader["vat"].ToString());
                        dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value = decimal.Parse(reader["vatP"].ToString());
                    }
                    
                    decimal netPrice = (decimal.Parse(dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["qty"].Value.ToString()) * decimal.Parse(dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["price"].Value.ToString()));
                    dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["total"].Value = (netPrice + decimal.Parse(dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value == null ? "0" : dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["vatp"].Value.ToString()));
                    dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["method"].Value = reader["method"].ToString();
                    dgvItems.Rows[dgvItems.Rows.Count - 2].Cells["type"].Value = reader["type"].ToString();
                }
        }

        private void txtPONO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
