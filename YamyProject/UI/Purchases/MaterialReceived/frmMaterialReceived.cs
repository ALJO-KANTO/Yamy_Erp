using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmMaterialReceived : Form
    {
        int id;
        int poId;

        public frmMaterialReceived(int id = 0, int poId = 0)
        {
            InitializeComponent();
            dgvItems.EnableHeadersVisualStyles = false; // important
            AppTheme.DefaultFont(dgvItems);
            LocalizationManager.LocalizeForm(this);
            this.id = id;
            this.poId = poId;
            headerUC1.FormText = this.Text;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmMaterialReceived_Load(object sender, EventArgs e)
        {
            txtPoId.Enabled = true;
            dtInv.Value = DateTime.Now.Date;
            bindCombo();
            txtNextCode.Text = GenerateNextSalesCode();
            txtId.Text = GenerateNextSalesId();

            if (id != 0)
            {
                BindInvoice();
                btnSave.Enabled = UserPermissions.canEdit("Purchase Order");
            }
            else if(poId > 0)
            {
                txtPoId.Enabled = false;
                BindPOItems();
            }
            guna2TileButton15.Visible = Utilities.GetModules("Manufacture");
        }

        private void BindPOItems()
        {
            dgvItems.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT poi.item_id, i.code, i.name, poi.qty, ifnull(u.name,'') uom FROM tbl_purchase_order_details poi
                    INNER JOIN tbl_items i ON poi.item_id = i.id
                    LEFT JOIN tbl_unit u ON u.id = i.unit_id
                    WHERE poi.purchase_id = @poId
            ", DBClass.CreateParameter("@poId", poId)))
            {
                while (reader.Read())
                {
                    //itemId;no;code;name;orderedQty;receivedQty;uom;status
                    dgvItems.Rows.Add(reader["item_id"], null, reader["code"], reader["name"], reader["qty"], "0", reader["uom"]);
                }
            }
        }

        private void BindInvoice()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_received where mr_id = @id",
                DBClass.CreateParameter("@id", id)))
            {
                //mr_id, mr_no, mr_date, po_id, vendor_id, status, remarks, created_by, created_at, updated_at
                reader.Read();
                txtId.Text = reader["mr_id"].ToString();
                dtInv.Value = DateTime.Parse(reader["mr_date"].ToString());
                txtNextCode.Text = reader["mr_no"].ToString();
                cmbVendor.SelectedValue = reader["vendor_id"].ToString();
                cmbStatus.SelectedItem = reader["status"].ToString();
                txtRemarks.Text = reader["remarks"].ToString();
                txtPoId.Text = reader["po_id"].ToString();
                //if (IsProjectOption)
                //    cmbProject.SelectedValue = int.Parse(reader["project_id"].ToString());
                BindInvoiceItems();
                CalculateTotal();
            }
        }
        private void BindInvoiceItems()
        {
            dgvItems.Rows.Clear();
            string query = @"
                            SELECT 
                                mri.po_item_id,
                                mri.ordered_qty,
                                mri.received_qty,
                                mri.uom,
                                mri.status,
                                i.type,
                                i.method,
                                i.code,
                                i.name
                            FROM tbl_material_received_item mri
                            INNER JOIN tbl_items i ON mri.po_item_id = i.id
                            WHERE mri.mr_id = @id;";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", id)))
            {
                while (reader.Read())
                {
                    // Add a new row and get the index
                    int rowIndex = dgvItems.Rows.Add(
                        reader["po_item_id"].ToString(),      
                        dgvItems.Rows.Count + 1,           
                        reader["code"].ToString(),         
                        reader["name"].ToString(),         
                        Utilities.FormatDecimal(reader["ordered_qty"]),
                        Utilities.FormatDecimal(reader["received_qty"]),
                        reader["uom"].ToString(),
                        reader["status"].ToString()
                    );

                    // Optional: If status is ComboBox, set selected value properly
                    DataGridViewComboBoxCell statusCell = dgvItems.Rows[rowIndex].Cells["status"] as DataGridViewComboBoxCell;
                    if (statusCell != null)
                    {
                        string statusValue = reader["status"].ToString();
                        if (statusCell.Items.Contains(statusValue))
                            statusCell.Value = statusValue;
                        else
                            statusCell.Value = statusCell.Items[0]; // default
                    }
                }
            }
        }

        private DataTable GetFilteredProductsByName(string name = "")
        {
            string option = Utilities.GeneralSettingsState("ALL ITEMS IN PURCHASE");

            string query = "select code,name from tbl_items where state = 0 AND active = 0";
            var parameters = new List<MySqlParameter>();

            if (string.IsNullOrEmpty(option) || int.Parse(option) <= 0)
            {
                query += " AND type = '11 - Inventory Part'";
            }

            if (!string.IsNullOrEmpty(name))
            {
                query += " AND name LIKE @name";
                parameters.Add(new MySqlParameter("@name", $"%{name}%"));
            }

            query += " ORDER BY name LIMIT 20";

            return DBClass.ExecuteDataTable(query, parameters.ToArray());
        }

        private DataTable GetFilteredProductsByCode(string code = "")
        {
            string option = Utilities.GeneralSettingsState("ALL ITEMS IN PURCHASE");

            string query = "select code,name from tbl_items where state = 0 AND active = 0";
            var parameters = new List<MySqlParameter>();

            if (string.IsNullOrEmpty(option) || int.Parse(option) <= 0)
            {
                query += " AND type = '11 - Inventory Part'";
            }

            if (!string.IsNullOrEmpty(code))
            {
                query += " AND code LIKE @code";
                parameters.Add(new MySqlParameter("@code", $"%{code}%"));
            }

            query += " ORDER BY code Limit 20";

            return DBClass.ExecuteDataTable(query, parameters.ToArray());
        }

        bool IsProjectOption = false;

        private void bindCombo()
        {
            BindCombos.PopulateVendors(cmbVendor);
            var generalS = Utilities.GeneralSettingsState("PROJECT OPTION");
            if (!string.IsNullOrEmpty(generalS) & int.Parse(generalS) > 0)
            {
                IsProjectOption = true;
            }
            else
            {
                IsProjectOption = false;
            }
            cmbProject.Visible = lblProject.Visible = IsProjectOption;
            BindCombos.PopulateProjects(cmbProject);

            DataGridViewComboBoxColumn statusColumn = dgvItems.Columns["status"] as DataGridViewComboBoxColumn;

            if (statusColumn != null)
            {
                statusColumn.Items.Clear();
                statusColumn.Items.AddRange("Partial", "Received");
            }

        }
        private string GenerateNextSalesCode()
        {
            string newCode = "MR-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(mr_no, 4) AS UNSIGNED)) AS lastCode FROM tbl_material_received"))
            {
                if (reader.Read()) {
                    if (reader["lastCode"] != DBNull.Value){
                        int code = int.Parse(reader["lastCode"].ToString()) + 1;
                        newCode = "MR-" + code.ToString("D4");
                    }
                }
            }

            return newCode;
        }
        private string GenerateNextSalesId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(mr_id) AS lastCode FROM tbl_material_received"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertInvoice())
                {
                    EventHub.RefreshMaterialReceived();
                    MessageBox.Show("The Material Received Saved");
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
                    EventHub.RefreshMaterialReceived();
                    this.ResetText();
                    MessageBox.Show("The Material Received Updated");
                    dgvItems.Rows.Clear();
                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
        }
        private bool insertInvoice()
        {
            if (!chkRequiredDate())
                return false;

            // Insert header
            string insertMRQuery = @"
                    INSERT INTO tbl_material_received
                    (mr_no, mr_date, po_id, vendor_id, status, remarks, created_by)
                    VALUES
                    (@mr_no, @mr_date, @poId, @vendor_id, @status, @remarks, @created_by);
                    SELECT LAST_INSERT_ID();";

            int mrId = Convert.ToInt32(DBClass.ExecuteScalar(insertMRQuery,
                DBClass.CreateParameter("@mr_no", txtNextCode.Text),
                DBClass.CreateParameter("@mr_date", dtInv.Value.Date),
                DBClass.CreateParameter("@vendor_id", cmbVendor.SelectedValue ?? 0),
                DBClass.CreateParameter("@poId", (txtPoId.Text ?? "0")),
                DBClass.CreateParameter("@status", cmbStatus.SelectedItem.ToString()),  // Default status
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@created_by", frmLogin.userId)
            ));

            // Insert MR Items
            InsertItems(mrId);

            // Log audit
            Utilities.LogAudit(frmLogin.userId, "Add Material Received", "Material Received", mrId, "Added Material Received: " + txtNextCode.Text);

            // Add attachments if any
            if (!string.IsNullOrEmpty(filePath))
            {
                AddFileData(mrId);
            }

            return true;
        }


        private bool updateInvoice()
        {
            if (!chkRequiredDate())
                return false;

            // Update header
            string updateQuery = @"
                    UPDATE tbl_material_received 
                    SET 
                        mr_date = @mr_date,
                        vendor_id = @vendor_id,
                        po_id = @poId,
                        status = @status,
                        remarks = @remarks
                    WHERE mr_id = @mr_id";

            DBClass.ExecuteNonQuery(updateQuery,
                DBClass.CreateParameter("@mr_date", dtInv.Value.Date),
                DBClass.CreateParameter("@vendor_id", cmbVendor.SelectedValue ?? 0),
                DBClass.CreateParameter("@poId", (string.IsNullOrEmpty(txtPoId.Text) ? "0" : txtPoId.Text)),
                DBClass.CreateParameter("@status", cmbStatus.SelectedItem.ToString()),  // or keep previous
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@created_by", frmLogin.userId),
                DBClass.CreateParameter("@mr_id", id)
            );

            // Delete old items
            DBClass.ExecuteNonQuery("DELETE FROM tbl_material_received_item WHERE mr_id = @mr_id",
                DBClass.CreateParameter("@mr_id", id));

            // Re-insert items
            InsertItems(id);

            // Log audit
            Utilities.LogAudit(frmLogin.userId, "Update Material Received", "Material Received", id, "Updated Material Received: " + txtNextCode.Text);

            // Update attachments if any
            if (!string.IsNullOrEmpty(filePath))
            {
                AddFileData(id);
            }

            return true;
        }

        private void InsertItems(int mrId)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;

                int itemId = Convert.ToInt32(row.Cells["itemId"].Value);
                decimal rQty = Utilities.ParseDecimalValue(row.Cells["receivedQty"].Value);
                decimal oQty = Utilities.ParseDecimalValue(row.Cells["orderedQty"].Value);
                string uom = row.Cells["uom"].Value?.ToString();
                string status = rQty==oQty ? "Received" : "Partial";

                //tbl_material_received_item id, mr_id,po_item_id,ordered_qty,received_qty,uom ,status,created_at,updated_at
                string insertQuery = @"
                        INSERT INTO tbl_material_received_item
                        (mr_id, po_item_id, ordered_qty, received_qty, uom, status)
                        VALUES
                        (@mr_id, @item_id, @ordered_qty, @received_qty, @uom, @status)";

                DBClass.ExecuteNonQuery(insertQuery,
                    DBClass.CreateParameter("@mr_id", mrId),
                    DBClass.CreateParameter("@item_id", itemId),
                    DBClass.CreateParameter("@ordered_qty", oQty),
                    DBClass.CreateParameter("@received_qty", rQty),
                    DBClass.CreateParameter("@uom", uom),
                    DBClass.CreateParameter("@status", status));
            }
        }

        private bool chkRequiredDate()
        {
            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                if (dgvItems.Rows[i].Cells["orderedQty"].Value == null
                    || dgvItems.Rows[i].Cells["orderedQty"].Value.ToString() == ""
                    || decimal.Parse(dgvItems.Rows[i].Cells["orderedQty"].Value.ToString()) == 0)
                {
                    MessageBox.Show("OrderedQty Item In Row " + (dgvItems.Rows[i].Index + 1) + " Can't Be 0 or Null");
                    return false;
                }
                if (dgvItems.Rows[i].Cells["receivedQty"].Value == null
                    || dgvItems.Rows[i].Cells["receivedQty"].Value.ToString() == ""
                    || decimal.Parse(dgvItems.Rows[i].Cells["receivedQty"].Value.ToString()) == 0)
                {
                    MessageBox.Show("ReceivedQty Item In Row " + (dgvItems.Rows[i].Index + 1) + " Can't Be 0 or Null");
                    return false;
                }
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
            cmbVendor.SelectedIndex = - 1;
            txtTotal.Text = "";
            txtPoId.Text = "";
            id = 0;
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

        }
        private void txtSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox textBox0)
            {
                textBox0.TextChanged -= ItemCode_TextChanged;
                textBox0.TextChanged -= ItemName_TextChanged;
                textBox0.KeyPress -= NumericColumn_KeyPress;
                if (lstAccountSuggestions.Visible)
                {
                    lstAccountSuggestions.Visible = false;
                }
                lstAccountSuggestions.SendToBack();
            }

            if (dgvItems.CurrentCell.ColumnIndex == dgvItems.Columns["name"].Index)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.TextChanged -= ItemName_TextChanged;
                    textBox.TextChanged += ItemName_TextChanged;

                    lstAccountSuggestions.Tag = textBox;
                }
            }
            else if (dgvItems.CurrentCell.ColumnIndex == dgvItems.Columns["code"].Index)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.TextChanged -= ItemCode_TextChanged;
                    textBox.TextChanged += ItemCode_TextChanged;

                    lstAccountSuggestions.Tag = textBox;
                }
            }
            else if (dgvItems.CurrentCell.OwningColumn.Name == "orderedQty" || dgvItems.CurrentCell.OwningColumn.Name == "receivedQty")
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
                lstAccountSuggestions.Items.Add(new ItemSuggestion
                {
                    Code = row["code"].ToString(),
                    Name = row["name"].ToString()
                });
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
                lstAccountSuggestions.Items.Add(new ItemSuggestion
                {
                    Code = row["code"].ToString(),
                    Name = row["name"].ToString()
                });
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
            //if (sender is ComboBox combo && combo.SelectedItem is DataRowView selectedRow)
            //{
            //    //
            //}
        }

        private bool CheckItemValidity(int itemId)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select type from tbl_items where id = @id",
                DBClass.CreateParameter("id", itemId)))
            {
                reader.Read();
                if (reader["type"].ToString() == "Service")
                    return true;
            }
            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                if (dgvItems.Rows[i].Cells["itemId"].Value == null)
                {
                    dgvItems.Rows.Remove(dgvItems.Rows[i]);
                    continue;
                }
            }
            return true;
        }
        void CalculateTotal()
        {
            decimal totalQty = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                totalQty += GetDecimalValue(row, "receivedQty");
            }
            txtTotal.Text = totalQty.ToString("0.00");
        }
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isUpdatingGrid) return;

            if (dgvItems.Rows.Count > 1)
            {
                var row = dgvItems.Rows[e.RowIndex];

                if (e.ColumnIndex == dgvItems.Columns["Code"].Index)
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
                else if (e.ColumnIndex == dgvItems.Columns["orderedQty"].Index)
                {
                    if (dgvItems.CurrentRow.Cells["itemId"].Value == null || !CheckItemValidity(int.Parse(dgvItems.CurrentRow.Cells["itemId"].Value.ToString())))
                        row.Cells["orderedQty"].Value = 0;
                }
                else if (e.ColumnIndex == dgvItems.Columns["receivedQty"].Index)
                {
                    if (dgvItems.CurrentRow.Cells["itemId"].Value == null || !CheckItemValidity(int.Parse(dgvItems.CurrentRow.Cells["itemId"].Value.ToString())))
                        row.Cells["receivedQty"].Value = 0;

                    if(decimal.Parse(row.Cells["receivedQty"].Value.ToString()) > decimal.Parse(row.Cells["orderedQty"].Value.ToString()))
                    {
                        MessageBox.Show("Received Qty can't be grater than Ordered Qty");
                        row.Cells["receivedQty"].Value = 0;
                    }
                }
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
                            SELECT id, method, type, code, name 
                            FROM tbl_items 
                            WHERE code = @code",
                        DBClass.CreateParameter("code", inputText.Trim()));
                }
                else if (type == "name")
                {
                    // Search by name (case-insensitive)
                    reader = DBClass.ExecuteReader(@"
                                SELECT id, method, type, code, name 
                                FROM tbl_items 
                                WHERE name = @name COLLATE utf8mb4_general_ci LIMIT 1",
                        DBClass.CreateParameter("name", inputText.Trim()));
                }

                if (reader != null && reader.Read())
                {
                    dgvItems.CurrentRow.Cells["orderedQty"].Value = 0;
                    dgvItems.CurrentRow.Cells["receivedQty"].Value = 0;
                    dgvItems.CurrentRow.Cells["itemid"].Value = reader["id"].ToString();
                    dgvItems.CurrentRow.Cells["method"].Value = reader["method"];
                    dgvItems.CurrentRow.Cells["type"].Value = reader["type"];
                    dgvItems.CurrentRow.Cells["code"].Value = reader["code"].ToString();
                    dgvItems.CurrentRow.Cells["name"].Value = reader["name"].ToString();
                }
                else
                {
                    DataGridViewRow row = dgvItems.CurrentRow;
                    if (row != null)
                    {
                        row.Cells["itemid"].Value = null;
                        row.Cells["method"].Value = null;
                        row.Cells["type"].Value = null;
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
            int? currentId = Convert.ToInt32(txtId.Text);
            if (currentId == null || currentId <= 1)
                return;

            currentId = currentId - 1;
            if (currentId <= 0)
            {
                clearData();
                MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "select mr_id id from tbl_material_received where mr_id =@id";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No previous records available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            string query = "SELECT mr_id id FROM tbl_material_received WHERE mr_id =@id";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", currentId)))
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No more records available.");
                }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvItems.Rows.Count > 1 && dgvItems.CurrentRow.Cells["delete"].ColumnIndex == e.ColumnIndex)
                {
                    dgvItems.Rows.Remove(dgvItems.CurrentRow);
                    CalculateTotal();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void dgvItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvItems.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        public DataTable COMPANYINFO(int a1)
        {
            return DBClass.ExecuteDataTable("SELECT * FROM tbl_company Limit 1");
        }

        public DataTable ItemDetails(string a1)
        {
            string query = @"
                            SELECT 
                                p.mr_id,
                                p.mr_no,
                                p.mr_date,
                                p.vendor_id,
                                p.department_id,
                                p.status,
                                p.remarks,
                                e.name as employeeName,
                                d.name as departmentName
                            FROM tbl_material_received p
                            LEFT JOIN tbl_employee e ON p.vendor_id = e.id
                            LEFT JOIN tbl_departments d ON p.department_id = d.id
                            WHERE p.mr_id = @id;
                        ";
            return DBClass.ExecuteDataTable(query,
                                  DBClass.CreateParameter("@id", a1));
        }
        public DataTable MaterialReceivedDetails(string a1)
        {
            string query = @"
                        SELECT 
                            mri.mr_item_id,
                            mri.mr_id,
                            mri.item_id,
                            i.code AS itemCode,
                            i.name AS itemName,
                            mri.required_qty AS qty,
                            mri.uom,
                            mri.expected_date,
                            mri.status,
                            mri.remarks,
                            i.type,
                            i.method
                        FROM tbl_material_received_item mri
                        INNER JOIN tbl_items i ON mri.item_id = i.id
                        WHERE mri.mr_id = @id;
                    ";

            return DBClass.ExecuteDataTable(query
                            , DBClass.CreateParameter("@id", a1));
        }
        public void ShowReport()
        {
            return;

            try
            {
                string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", "MaterialReceived.rpt");

                // Load the report file from disk
                ReportDocument cr = new ReportDocument();
                cr.Load(reportPath);
                DataTable companyData = COMPANYINFO(1);
                DataTable VendorData = ItemDetails(id.ToString());
                DataTable PurchaseData = MaterialReceivedDetails(id.ToString());
                if (companyData != null)
                {
                    cr.SetDataSource(companyData);

                    cr.Subreports["Company"].SetDataSource(companyData);
                    cr.Subreports["Vendor"].SetDataSource(VendorData);
                    cr.Subreports["Details"].SetDataSource(PurchaseData);

                    // Set value of Text15 in "Details" subreport
                    ReportDocument subReport = cr.Subreports["Details"];
                    bool textSet = false;
                    foreach (Section section in subReport.ReportDefinition.Sections)
                    {
                        foreach (ReportObject reportObject in section.ReportObjects)
                        {
                            if (reportObject.Kind == ReportObjectKind.TextObject && reportObject.Name == "Text15")
                            {
                                ((TextObject)reportObject).Text = cmbVendor.SelectedText;
                                textSet = true;
                                break;
                            }
                        }
                        if (textSet)
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("No data available for the report.");
                    return;
                }
                string fileName = "MaterialReceived_" + id + "_" + cmbVendor.Text.Trim();
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

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void guna2TileButton23_Click(object sender, EventArgs e)
        {
            clearData();
        }
        private void clearData()
        {
            dgvItems.Rows.Clear();
            resetTextBox();
            txtNextCode.Text = GenerateNextSalesCode();
            txtId.Text = GenerateNextSalesId();
            id = 0;
        }
        private void AddFileData(int fId)
        {
            AttachmentManager.SaveAttachment(
                    "MATERIAL RECEIVED",
                    fId,
                    openFileDialog1.FileName
                );
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertInvoice())
                {
                    EventHub.RefreshMaterialReceived();
                    this.Close();
                    //this.ResetText();
                    //MessageBox.Show("The Material Received Saved");
                    //dgvItems.Rows.Clear();
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
                    EventHub.RefreshMaterialReceived();
                    this.Close();
                    //this.ResetText();
                    //MessageBox.Show("The Material Received Updated");
                    //dgvItems.Rows.Clear();
                    if (chkPrint.Checked == true)
                    {
                        ShowReport();
                    }
                }
            }
        }
        /*
         * 
        private void lnkNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewVendor frm = new frmViewVendor();
            frmLogin.frmMain.openChildForm(frm);
            BindCombos.PopulateVendors(cmbVendor,false,true);
        }
         */
        private void guna2TileButton21_Click(object sender, EventArgs e)
        {
            //DBClass.ExecuteNonQuery("DELETE FROM tbl_material_received WHERE id = @id; DELETE From tbl_material_received_item WHERE mr_id = @id;",
            //                              DBClass.CreateParameter("id", id.ToString()));
            //Utilities.LogAudit(frmLogin.userId, "Delete Material Received", "Material Received", (int)id, "Deleted Material Received: " + id);
            //clearData();
        }

        private void guna2TileButton22_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void guna2TileButton20_Click(object sender, EventArgs e)
        {
            id = 0;
        }

        private void guna2TileButton24_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmPurchaseByVendorSummary());
        }

        private bool _isUpdatingGrid = false;

        private void btnImport_Click(object sender, EventArgs e)
        {
            //
        }

        private void lstAccountSuggestions_Click(object sender, EventArgs e)
        {
            if (lstAccountSuggestions.SelectedItem == null)
                return;

            string selected = lstAccountSuggestions.SelectedItem.ToString();

            //int separatorIndex = selected.IndexOf('-');
            //if (separatorIndex == -1) return;

            string selectedCode = "";
            string selectedName = "";
            if (lstAccountSuggestions.SelectedItem is ItemSuggestion item)
            {
                selectedCode = item.Code;
                selectedName = item.Name;
            }

            if (lstAccountSuggestions.Tag is TextBox textBox)
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

            if ((columnName == "code" || columnName == "name") && lstAccountSuggestions.Items.Count<=0)
            {
                ItemNotFoundMessage(inputText);
            }
        }

        private void ItemNotFoundMessage(string name)
        {
            var result = MessageBox.Show(
                                            $"'{name}' not found!\nDo you want to create it?",
                                            "Invalid Item",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning
                                        );

            if (result == DialogResult.Yes)
            {
                new frmViewItem().ShowDialog();
            }

            DataGridViewRow row = dgvItems.CurrentRow;
            if (row != null)
            {
                row.Cells["itemid"].Value = null;
                row.Cells["method"].Value = null;
                row.Cells["type"].Value = null;
                row.Cells["uom"].Value = null;
                row.Cells["name"].Value = null;
                row.Cells["code"].Value = null;
            }
        }

        private void guna2TileButton15_Click(object sender, EventArgs e)
        {
            //
        }

        private void guna2TileButton17_Click(object sender, EventArgs e)
        {
            //

        }
        string filePath = "";
        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
        }

        private void txtPoId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPoId.Text))
            {
                poId = int.Parse(txtPoId.Text);
                BindPOItems();
            }
        }

        private void txtPoId_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //    e.Handled = true;
        }
    }
}