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

namespace YamyProject.UI.ContractingGeneralMaintenance.Inventory
{
    public partial class MaterialForm : Form
    {
        int materialId;
        public MaterialForm(int _materialId = 0)
        {
            InitializeComponent();
            this.materialId = _materialId;
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateWarehouse(cmbWarehouse);

            if (materialId > 0)
            {
                using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_items WHERE id = @id", new MySqlParameter("@id", materialId)))
                {
                    if(reader.Read())
                    {
                        txtName.Text = reader["name"].ToString();
                        cmbWarehouse.SelectedItem = reader["warehouse_id"].ToString();
                        txtQty.Text = decimal.Parse(reader["on_hand"].ToString()).ToString("N2");
                        txtMin.Text = decimal.Parse(reader["min_amount"].ToString()).ToString("N2");
                        txtCost.Text = decimal.Parse(reader["cost_price"].ToString()).ToString("N2");
                    }
                }
            }
        }
        string itemCode = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!validateForm()) return;

            if (materialId > 0)
            {
                // update
                DBClass.ExecuteNonQuery(@"UPDATE tbl_items SET name = @name, warehouse_id=@warehouseId,
                                      min_amount = @min_amount,cost_price = @cost_price
                                      WHERE id = @id",
                                    DBClass.CreateParameter("name", txtName.Text),
                                    DBClass.CreateParameter("warehouseId", cmbWarehouse.SelectedValue.ToString()),
                                    DBClass.CreateParameter("min_amount", txtMin.Text),
                                    DBClass.CreateParameter("cost_price", txtCost.Text == "" ? "0" : txtCost.Text),
                                    DBClass.CreateParameter("id", materialId));


                DBClass.ExecuteNonQuery("delete from tbl_items_unit where item_id=@id", DBClass.CreateParameter("id", materialId));
                DBClass.ExecuteNonQuery("delete from tbl_item_assembly where assembly_id=@id", DBClass.CreateParameter("id", materialId));

                DBClass.ExecuteNonQuery(@"DELETE FROM tbl_item_transaction where type = 'Opening Qty' and item_id = @id;DELETE FROM tbl_transaction where type = 'Opening Qty' AND transaction_id= @id", DBClass.CreateParameter("id", materialId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_item_card_details WHERE `trans_type` = 'Opening Qty' and itemId = @id", DBClass.CreateParameter("id", materialId));
                string TotalValue = (decimal.Parse(txtQty.Text) * decimal.Parse(txtCost.Text == "" ? "0" : txtCost.Text)).ToString("N2").Replace(",","");
                insertItemTransaction();
                insertItemJournal(TotalValue);

                Utilities.LogAudit(frmLogin.userId, "Update Item", "Item", materialId, "Updated Item: " + txtName.Text + " with Code: " + itemCode);

                MessageBox.Show("Material updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_items where name = @name",
               DBClass.CreateParameter("name", txtName.Text));
                if (reader.Read())
                {
                    MessageBox.Show("Item Already Exists. Enter Another Name.");
                }
                else
                {
                    int IncomeAccountId = BindCombos.SelectDefaultLevelAccount("Sales");
                    int AssetAccountId = BindCombos.SelectDefaultLevelAccount("Inventory");
                    int COGSAccountId = BindCombos.SelectDefaultLevelAccount("COGS");
                    itemCode = getNextCode();
                    string TotalValue = (decimal.Parse(txtQty.Text) * decimal.Parse(txtCost.Text == "" ? "0" : txtCost.Text)).ToString("N2").Replace(",", "");
                    materialId = (int)decimal.Parse(DBClass.ExecuteScalar(@"INSERT INTO `tbl_items`(`code`,`warehouse_id`,  `type`,category_id, `name`, `unit_id`, `barcode`, `cost_price`, 
                                    `cogs_account_id`, `vendor_id`, `sales_price`, `income_account_id`, `asset_account_id`, 
                                    `min_amount`, `max_amount`, `on_hand`,method, `total_value`, `date`, `img`, `active`, `state`, 
                                    `created_By`, `created_date`,Item_type) VALUES (
                                    @code, @warehouseId, @type,@category, @name, @unit_id, @barcode, @cost_price, 
                                    @cogs_account_id, @vendor_id, @sales_price, @income_account_id, @asset_account_id, 
                                    @min_amount, @max_amount, @on_hand,@method, @total_value, @date, @img, @active, @state, 
                                    @created_By, @created_date,@Item_type); SELECT LAST_INSERT_ID();",
                                     DBClass.CreateParameter("code", itemCode),
                                     DBClass.CreateParameter("warehouseId", cmbWarehouse.SelectedValue.ToString()),
                                     DBClass.CreateParameter("type", "11 - Inventory Part"),
                                     DBClass.CreateParameter("category", 0),
                                     DBClass.CreateParameter("name", txtName.Text),
                                     DBClass.CreateParameter("unit_id", 0),
                                     DBClass.CreateParameter("barcode", ""),
                                     DBClass.CreateParameter("cost_price", txtCost.Text == "" ? "0" : txtCost.Text),
                                     DBClass.CreateParameter("cogs_account_id", COGSAccountId),
                                     DBClass.CreateParameter("vendor_id", 0),
                                     DBClass.CreateParameter("sales_price", 0),
                                     DBClass.CreateParameter("income_account_id", IncomeAccountId),
                                     DBClass.CreateParameter("asset_account_id", AssetAccountId),
                                     DBClass.CreateParameter("min_amount", txtMin.Text),
                                     DBClass.CreateParameter("max_amount", txtCost.Text == "" ? "0" : txtCost.Text),
                                     DBClass.CreateParameter("on_hand", txtQty.Text),
                                     DBClass.CreateParameter("method", "avg"),
                                     DBClass.CreateParameter("total_value", TotalValue),
                                     DBClass.CreateParameter("date", DateTime.Now.Date),
                                     DBClass.CreateParameter("img", ""),
                                     DBClass.CreateParameter("active", 0),
                                     DBClass.CreateParameter("state", 0),
                                     DBClass.CreateParameter("created_By", frmLogin.userId),
                                     DBClass.CreateParameter("created_date", DateTime.Now.Date),
                                     DBClass.CreateParameter("@Item_type", "Inventory ")).ToString());


                    if (txtQty.Text.Trim() != "0")
                    {
                        insertItemTransaction();
                        insertItemJournal(TotalValue);
                    }
                    Utilities.LogAudit(frmLogin.userId, "Insert Item", "Item", materialId, "Inserted Item: " + txtName.Text + " with Code: " + itemCode);

                    MessageBox.Show("Material added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private void insertItemTransaction()
        {
            CommonInsert.InsertItemTransaction(DateTime.Now.Date, "Opening Qty", "0", materialId.ToString(), txtCost.Text,
                txtQty.Text, "0", "0", txtQty.Text, "Opening Balance", cmbWarehouse.SelectedValue.ToString());
        }
        private void insertItemJournal(string TotalValue)
        {
            CommonInsert.InsertTransactionEntry(DateTime.Now.Date, BindCombos.SelectDefaultLevelAccount("Inventory").ToString(), TotalValue, "0",
                materialId.ToString(), materialId.ToString(), "Opening Qty", "Opening Balance - Item Code - " + itemCode, frmLogin.userId, DateTime.Now.Date);
            CommonInsert.InsertTransactionEntry(DateTime.Now.Date, BindCombos.SelectDefaultLevelAccount("Opening Balance Equity").ToString(), "0", TotalValue,
                    materialId.ToString(), "0", "Opening Qty", "Opening Balance Equity - Item Code - " + itemCode, frmLogin.userId, DateTime.Now.Date);
        }

        private bool validateForm()
        {
            if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Material name is required.");
                return false;
            }
            if(cmbWarehouse.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a warehouse.");
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtQty.Text) || !decimal.TryParse(txtQty.Text, out _))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtMin.Text) || !decimal.TryParse(txtMin.Text, out _))
            {
                txtMin.Text ="0";
            }
            if(string.IsNullOrWhiteSpace(txtCost.Text) || !decimal.TryParse(txtCost.Text, out _))
            {
                txtCost.Text = "0";
            }
            if (!Utilities.AreDefaultAccountsSet(new List<string> { "COGS", "Sales", "Inventory" }))
            {
                MessageBox.Show("Default accounts for Item are not properly configured. Please check your settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        string getNextCode()
        {
            string typeCategory = "1100";
            object result = DBClass.ExecuteScalar("SELECT MAX(RIGHT(code, 4)) FROM tbl_items WHERE LEFT(code, 5)");
            int nextSerial = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
            string formattedSerial = nextSerial.ToString().PadLeft(4, '0');
            string newItemCode = typeCategory + formattedSerial;
            return newItemCode;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
