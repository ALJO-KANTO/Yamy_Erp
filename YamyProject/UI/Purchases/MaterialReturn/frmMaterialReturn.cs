using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialReturn
{
    public partial class frmMaterialReturn : Form
    {
        int returnId;
        public frmMaterialReturn(int _id = 0)
        {
            InitializeComponent();

            this.returnId = _id;
            Load += Frm_Load;

            btnNew.Click += BtnNew_Click;
            btnClear.Click += BtnNew_Click;

            btnAddItem.Click += BtnAddItem_Click;
            btnSave.Click += BtnSave_Click;
            btnApprove.Click += BtnApprove_Click;

            txtReturnQty.TextChanged += CalcTotal;
            txtCost.TextChanged += CalcTotal;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();
            if (returnId > 0)
                LoadData();
            else
                NewRecord();
        }
        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_return where return_id = @id", DBClass.CreateParameter("@id", returnId)))
            {
                if (reader.Read())
                {
                    txtNo.Text = reader["return_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["return_date"]);
                    cmbIssue.SelectedValue = reader["issue_id"];
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbFromWarehouse.SelectedValue = reader["from_warehouse_id"];
                    cmbToWarehouse.SelectedValue = reader["to_warehouse_id"];
                    cmbReturnedBy.SelectedValue = reader["returned_by"];
                    cmbReceivedBy.SelectedValue = reader["received_by"];
                    cmbReturnType.Text = reader["return_type"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,mri.* from tbl_material_return_item mri INNER JOIN tbl_items i ON i.id = mri.item_id where return_id = @id", DBClass.CreateParameter("@id", returnId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["issued_qty"], reader1["return_qty"], reader1["damaged_qty"], reader1["uom"], reader1["unit_cost"], reader1["line_total"]);
                        }
                    }

                    CalculateGrandTotal();
                }
            }
        }
        void LoadCombos()
        {
            cmbIssue.DataSource = DBClass.ExecuteDataTable("SELECT issue_id, issue_no FROM tbl_material_issue");
            cmbIssue.DisplayMember = "issue_no";
            cmbIssue.ValueMember = "issue_id";

            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbFromWarehouse.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_warehouse");
            cmbFromWarehouse.DisplayMember = "name";
            cmbFromWarehouse.ValueMember = "id";

            cmbToWarehouse.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_warehouse");
            cmbToWarehouse.DisplayMember = "name";
            cmbToWarehouse.ValueMember = "id";

            cmbReturnedBy.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_employee");
            cmbReturnedBy.DisplayMember = "name";
            cmbReturnedBy.ValueMember = "id";

            cmbReceivedBy.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_employee");
            cmbReceivedBy.DisplayMember = "name";
            cmbReceivedBy.ValueMember = "id";

            cmbItem.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_items");
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbReturnType.Items.AddRange(new object[]
            {
                "Site Return",
                "Warehouse Return",
                "Excess Return",
                "Damaged Return"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft",
                "Pending",
                "Approved",
                "Rejected"
            });
        }

        void InitGrid()
        {
            dgvItems.Columns.Add("itemId", "Item Id");
            dgvItems.Columns.Add("itemName", "Item");
            dgvItems.Columns.Add("issuedQty", "Issued Qty");
            dgvItems.Columns.Add("returnQty", "Return Qty");
            dgvItems.Columns.Add("damageQty", "Damage Qty");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("cost", "Cost");
            dgvItems.Columns.Add("total", "Total");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            returnId = 0;

            txtNo.Text = "RET-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            cmbStatus.Text = "Draft";
            cmbReturnType.Text = "Site Return";

            txtRemarks.Clear();
            txtGrandTotal.Text = "0";

            dgvItems.Rows.Clear();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        void CalcTotal(object sender, EventArgs e)
        {
            try
            {
                decimal qty = Convert.ToDecimal(txtReturnQty.Text);
                decimal cost = Convert.ToDecimal(txtCost.Text);

                txtTotal.Text = (qty * cost).ToString("0.00");
            }
            catch
            {
                txtTotal.Text = "0";
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            decimal issued = Convert.ToDecimal(txtIssuedQty.Text);
            decimal ret = Convert.ToDecimal(txtReturnQty.Text);

            if (ret > issued)
            {
                MessageBox.Show("Return qty cannot exceed issued qty.");
                return;
            }

            dgvItems.Rows.Add(
                cmbItem.SelectedValue,
                cmbItem.Text,
                txtIssuedQty.Text,
                txtReturnQty.Text,
                txtDamagedQty.Text,
                txtUom.Text,
                txtCost.Text,
                txtTotal.Text
            );

            CalculateGrandTotal();
        }

        void CalculateGrandTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                total += Convert.ToDecimal(row.Cells["total"].Value);
            }

            txtGrandTotal.Text = total.ToString("0.00");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = @"
            INSERT INTO tbl_material_return
            (return_no,return_date,issue_id,project_id,
             from_warehouse_id,to_warehouse_id,
             returned_by,received_by,return_type,
             status,remarks,created_by)
            VALUES
            (@no,@date,@issue,@project,@fromwh,@towh,
             @returned,@received,@type,@status,
             @remarks,@user);

            SELECT LAST_INSERT_ID();";

            returnId = Convert.ToInt32(DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@issue", cmbIssue.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@fromwh", cmbFromWarehouse.SelectedValue),
                DBClass.CreateParameter("@towh", cmbToWarehouse.SelectedValue),
                DBClass.CreateParameter("@returned", cmbReturnedBy.SelectedValue),
                DBClass.CreateParameter("@received", cmbReceivedBy.SelectedValue),
                DBClass.CreateParameter("@type", cmbReturnType.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@user", frmLogin.userId)
            ));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_return_item
                (return_id,item_id,issued_qty,
                 return_qty,damaged_qty,uom,
                 unit_cost,line_total)
                VALUES
                (@rid,@item,@issued,@ret,@damage,
                 @uom,@cost,@total)",

                DBClass.CreateParameter("@rid", returnId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@issued", row.Cells["issuedQty"].Value),
                DBClass.CreateParameter("@ret", row.Cells["returnQty"].Value),
                DBClass.CreateParameter("@damage", row.Cells["damageQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@total", row.Cells["total"].Value));
            }

            EventHub.RefreshMaterialReturn();
            MessageBox.Show("Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (returnId == 0)
                return;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal returnQty =
                    Convert.ToDecimal(row.Cells["returnQty"].Value);

                if (returnQty <= 0)
                    continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_item_transaction
                (date,type,reference,item_id,
                 cost_price,qty_in,
                 description,warehouse_id,project_id, GlobalId, DeviceId)
                VALUES
                (@date,'RETURN',@ref,@item,
                 @cost,@qty,
                 'Material Return',
                 @warehouse,@project, @GlobalId, @DeviceId)",

                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@ref", txtNo.Text),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@qty", returnQty),
                DBClass.CreateParameter("@warehouse", cmbToWarehouse.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("GlobalId", Guid.NewGuid().ToString()),
                DBClass.CreateParameter("DeviceId", Utilities.MachineName));
            }

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_material_return SET status='Approved', approved_by=@u WHERE return_id=@id",

                DBClass.CreateParameter("@u", frmLogin.userId),
                DBClass.CreateParameter("@id", returnId));

            MessageBox.Show("Material Return Approved & Stock Updated");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (returnId == 0) return;

            // Update main record
            string sql = @"
            UPDATE tbl_material_return SET
                return_no = @no,
                return_date = @date,
                issue_id = @issue,
                project_id = @project,
                from_warehouse_id = @fromwh,
                to_warehouse_id = @towh,
                returned_by = @returned,
                received_by = @received,
                return_type = @type,
                status = @status,
                remarks = @remarks
            WHERE return_id = @id;";

            DBClass.ExecuteNonQuery(sql,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@issue", cmbIssue.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@fromwh", cmbFromWarehouse.SelectedValue),
                DBClass.CreateParameter("@towh", cmbToWarehouse.SelectedValue),
                DBClass.CreateParameter("@returned", cmbReturnedBy.SelectedValue),
                DBClass.CreateParameter("@received", cmbReceivedBy.SelectedValue),
                DBClass.CreateParameter("@type", cmbReturnType.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@id", returnId)
            );

            DBClass.ExecuteNonQuery("DELETE FROM tbl_material_return_item WHERE return_id = @id", DBClass.CreateParameter("@id", returnId));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                // Skip potential new/empty row
                if (row.IsNewRow) continue;

                // guard against nulls
                var itemId = row.Cells["itemId"].Value ?? DBNull.Value;
                var issued = row.Cells["issuedQty"].Value ?? DBNull.Value;
                var ret = row.Cells["returnQty"].Value ?? DBNull.Value;
                var damage = row.Cells["damageQty"].Value ?? DBNull.Value;
                var uom = row.Cells["uom"].Value ?? DBNull.Value;
                var cost = row.Cells["cost"].Value ?? DBNull.Value;
                var total = row.Cells["total"].Value ?? DBNull.Value;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_material_return_item
                    (return_id,item_id,issued_qty,
                     return_qty,damaged_qty,uom,
                     unit_cost,line_total)
                    VALUES
                    (@rid,@item,@issued,@ret,@damage,
                     @uom,@cost,@total)",
                    DBClass.CreateParameter("@rid", returnId),
                    DBClass.CreateParameter("@item", itemId),
                    DBClass.CreateParameter("@issued", issued),
                    DBClass.CreateParameter("@ret", ret),
                    DBClass.CreateParameter("@damage", damage),
                    DBClass.CreateParameter("@uom", uom),
                    DBClass.CreateParameter("@cost", cost),
                    DBClass.CreateParameter("@total", total)
                );
            }

            CalculateGrandTotal();

            EventHub.RefreshMaterialReturn();
            MessageBox.Show("Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(returnId==0) return;

            //mssage to ask
            var result = MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DBClass.ExecuteNonQuery("Delete from tbl_material_return_item where return_id = @id", DBClass.CreateParameter("@id", returnId));
                DBClass.ExecuteNonQuery("Delete from tbl_material_return where return_id = @id", DBClass.CreateParameter("@id", returnId));
            }

            EventHub.RefreshMaterialReturn();
            MessageBox.Show("Deleted Successfully");
        }
    }
}
