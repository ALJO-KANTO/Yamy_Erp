using Microsoft.Vbe.Interop;
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
using YamyProject;

namespace YamyProject.UI.Purchases.MaterialTransfer
{
    public partial class frmMaterialTransfer : Form
    {
        int transferId = 0;

        public frmMaterialTransfer(int _id = 0)
        {
            InitializeComponent();
            this.transferId = _id;
            Load += Frm_Load;

            btnNew.Click += BtnNew_Click;
            btnClear.Click += BtnNew_Click;

            btnAddItem.Click += BtnAddItem_Click;
            btnSave.Click += BtnSave_Click;
            btnApprove.Click += BtnApprove_Click;

            txtTransferQty.TextChanged += CalcTotal;
            txtCost.TextChanged += CalcTotal;

            cmbItem.SelectedIndexChanged += CmbItem_SelectedIndexChanged;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();

            if (transferId > 0)
                LoadData();
            else
                NewRecord();
        }
        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_transfer where transfer_id = @id", DBClass.CreateParameter("@id", transferId)))
            {
                if (reader.Read())
                {
                    txtNo.Text = reader["transfer_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["transfer_date"]);
                    cmbTransferType.Text = reader["transfer_type"].ToString();
                    cmbFromWarehouse.SelectedValue = reader["from_warehouse_id"];
                    cmbToWarehouse.SelectedValue = reader["to_warehouse_id"];
                    cmbFromProject.SelectedValue = reader["from_project_id"];
                    cmbToProject.SelectedValue = reader["to_project_id"];
                    cmbRequestedBy.SelectedValue = reader["requested_by"];
                    cmbReceivedBy.SelectedValue = reader["received_by"];
                    txtVehicle.Text = reader["vehicle_no"].ToString();
                    txtDriver.Text = reader["driver_name"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,mti.* from tbl_material_transfer_item mti INNER JOIN tbl_items i ON i.id = mti.item_id where transfer_id = @id", DBClass.CreateParameter("@id", transferId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["available_qty"], reader1["transfer_qty"], reader1["uom"], reader1["unit_cost"], reader1["line_total"]);
                        }
                    }

                    CalculateGrandTotal();
                }
            }
        }
        void LoadCombos()
        {
            cmbFromWarehouse.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_warehouse");

            cmbFromWarehouse.DisplayMember = "name";
            cmbFromWarehouse.ValueMember = "id";

            cmbToWarehouse.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_warehouse");

            cmbToWarehouse.DisplayMember = "name";
            cmbToWarehouse.ValueMember = "id";

            cmbFromProject.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects");

            cmbFromProject.DisplayMember = "name";
            cmbFromProject.ValueMember = "id";

            cmbToProject.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects");

            cmbToProject.DisplayMember = "name";
            cmbToProject.ValueMember = "id";

            cmbRequestedBy.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_employee");

            cmbRequestedBy.DisplayMember = "name";
            cmbRequestedBy.ValueMember = "id";

            cmbReceivedBy.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_employee");

            cmbReceivedBy.DisplayMember = "name";
            cmbReceivedBy.ValueMember = "id";

            cmbItem.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_items");

            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbTransferType.Items.AddRange(new object[]
            {
                "Warehouse Transfer",
                "Project Transfer",
                "Site Transfer"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft",
                "Pending",
                "Approved",
                "Cancelled"
            });
        }

        void InitGrid()
        {
            dgvItems.Columns.Add("itemId", "Item Id");
            dgvItems.Columns.Add("itemName", "Item");
            dgvItems.Columns.Add("availableQty", "Available");
            dgvItems.Columns.Add("transferQty", "Transfer Qty");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("cost", "Cost");
            dgvItems.Columns.Add("total", "Total");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            transferId = 0;

            txtNo.Text =
                "TRF-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            cmbTransferType.Text = "Warehouse Transfer";
            cmbStatus.Text = "Draft";

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
                decimal qty =
                    Convert.ToDecimal(txtTransferQty.Text);

                decimal cost =
                    Convert.ToDecimal(txtCost.Text);

                txtTotal.Text =
                    (qty * cost).ToString("0.00");
            }
            catch
            {
                txtTotal.Text = "0";
            }
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedValue == null ||
                cmbFromWarehouse.SelectedValue == null)
                return;

            string sql = @"
            SELECT IFNULL(SUM(qty_in - qty_out),0)
            FROM tbl_item_transaction
            WHERE item_id=@item
            AND warehouse_id=@wh";

            txtAvailableQty.Text =
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter("@item",
                    cmbItem.SelectedValue),

                DBClass.CreateParameter("@wh",
                    cmbFromWarehouse.SelectedValue)
                ).ToString();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            decimal available =
                Convert.ToDecimal(txtAvailableQty.Text);

            decimal transfer =
                Convert.ToDecimal(txtTransferQty.Text);

            if (transfer > available)
            {
                MessageBox.Show(
                    "Transfer qty exceeds available stock.");

                return;
            }

            dgvItems.Rows.Add(
                cmbItem.SelectedValue,
                cmbItem.Text,
                txtAvailableQty.Text,
                txtTransferQty.Text,
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
                total +=
                    Convert.ToDecimal(
                        row.Cells["total"].Value);
            }

            txtGrandTotal.Text = total.ToString("0.00");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = @"
            INSERT INTO tbl_material_transfer
            (transfer_no, transfer_date, transfer_type, from_warehouse_id, to_warehouse_id, from_project_id, to_project_id, 
                requested_by, received_by, vehicle_no, driver_name, status, remarks, created_by)
            VALUES
            (@no,@date,@type, @fromwh,@towh, @fromproject,@toproject, @requested,@received, @vehicle,@driver, @status,@remarks,@user);

            SELECT LAST_INSERT_ID();";

            transferId =
                Convert.ToInt32(DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date",
                    dtDate.Value.Date),

                DBClass.CreateParameter("@type",
                    cmbTransferType.Text),

                DBClass.CreateParameter("@fromwh",
                    cmbFromWarehouse.SelectedValue),

                DBClass.CreateParameter("@towh",
                    cmbToWarehouse.SelectedValue),

                DBClass.CreateParameter("@fromproject",
                    cmbFromProject.SelectedValue),

                DBClass.CreateParameter("@toproject",
                    cmbToProject.SelectedValue),

                DBClass.CreateParameter("@requested",
                    cmbRequestedBy.SelectedValue),

                DBClass.CreateParameter("@received",
                    cmbReceivedBy.SelectedValue),

                DBClass.CreateParameter("@vehicle",
                    txtVehicle.Text),

                DBClass.CreateParameter("@driver",
                    txtDriver.Text),

                DBClass.CreateParameter("@status",
                    cmbStatus.Text),

                DBClass.CreateParameter("@remarks",
                    txtRemarks.Text),

                DBClass.CreateParameter("@user",
                    frmLogin.userId)
            ));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_transfer_item
                (transfer_id, item_id, available_qty, transfer_qty, uom, unit_cost, line_total)
                VALUES(@transfer, @item, @available, @qty, @uom, @cost, @total)",

                DBClass.CreateParameter("@transfer", transferId),

                DBClass.CreateParameter("@item",
                    row.Cells["itemId"].Value),

                DBClass.CreateParameter("@available",
                    row.Cells["availableQty"].Value),

                DBClass.CreateParameter("@qty",
                    row.Cells["transferQty"].Value),

                DBClass.CreateParameter("@uom",
                    row.Cells["uom"].Value),

                DBClass.CreateParameter("@cost",
                    row.Cells["cost"].Value),

                DBClass.CreateParameter("@total",
                    row.Cells["total"].Value));
            }

            MessageBox.Show("Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (transferId == 0)
                return;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal qty =
                    Convert.ToDecimal(
                        row.Cells["transferQty"].Value);

                if (qty <= 0)
                    continue;

                // OUT STOCK
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_item_transaction
                (date,type,reference,item_id, cost_price,qty_out, description, warehouse_id, project_id, GlobalId, DeviceId)
                VALUES (@date,'TRANSFER_OUT',@ref,@item,@cost,@qty, 'Material Transfer OUT', @warehouse, @project, @GlobalId, @DeviceId)",

                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@ref", txtNo.Text),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@qty", qty),
                DBClass.CreateParameter("@warehouse", cmbFromWarehouse.SelectedValue),
                DBClass.CreateParameter("@project", cmbFromProject.SelectedValue),
                DBClass.CreateParameter("GlobalId", Guid.NewGuid().ToString()),
                DBClass.CreateParameter("DeviceId", Utilities.MachineName));

                // IN STOCK
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_item_transaction
                (date,type,reference,item_id, cost_price,qty_in, description, warehouse_id, project_id, GlobalId, DeviceId)
                VALUES (@date,'TRANSFER_IN',@ref,@item, @cost,@qty, 'Material Transfer IN', @warehouse, @project, @GlobalId, @DeviceId)",
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@ref", txtNo.Text),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@qty", qty),
                DBClass.CreateParameter("@warehouse", cmbToWarehouse.SelectedValue),
                DBClass.CreateParameter("@project", cmbToProject.SelectedValue),
                DBClass.CreateParameter("GlobalId", Guid.NewGuid().ToString()),
                DBClass.CreateParameter("DeviceId", Utilities.MachineName));
            }

            DBClass.ExecuteNonQuery(@"UPDATE tbl_material_transfer SET status='Approved', approved_by=@user WHERE transfer_id=@id",
            DBClass.CreateParameter("@user", frmLogin.userId),
            DBClass.CreateParameter("@id", transferId));

            EventHub.RefreshMaterialTransfer();
            MessageBox.Show("Material Transfer Approved Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (transferId == 0)
            {
                MessageBox.Show("No record selected to update.");
                return;
            }

            try
            {
                // Update header
                string sqlUpdate = @"
                    UPDATE tbl_material_transfer
                    SET
                        transfer_no = @no,
                        transfer_date = @date,
                        transfer_type = @type,
                        from_warehouse_id = @fromwh,
                        to_warehouse_id = @towh,
                        from_project_id = @fromproject,
                        to_project_id = @toproject,
                        requested_by = @requested,
                        received_by = @received,
                        vehicle_no = @vehicle,
                        driver_name = @driver,
                        status = @status,
                        remarks = @remarks
                    WHERE transfer_id = @id";

                DBClass.ExecuteNonQuery(sqlUpdate,
                    DBClass.CreateParameter("@no", txtNo.Text),
                    DBClass.CreateParameter("@date", dtDate.Value.Date),
                    DBClass.CreateParameter("@type", cmbTransferType.Text),
                    DBClass.CreateParameter("@fromwh", cmbFromWarehouse.SelectedValue),
                    DBClass.CreateParameter("@towh", cmbToWarehouse.SelectedValue),
                    DBClass.CreateParameter("@fromproject", cmbFromProject.SelectedValue),
                    DBClass.CreateParameter("@toproject", cmbToProject.SelectedValue),
                    DBClass.CreateParameter("@requested", cmbRequestedBy.SelectedValue),
                    DBClass.CreateParameter("@received", cmbReceivedBy.SelectedValue),
                    DBClass.CreateParameter("@vehicle", txtVehicle.Text),
                    DBClass.CreateParameter("@driver", txtDriver.Text),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@user", frmLogin.userId),
                    DBClass.CreateParameter("@moddate", DateTime.Now),
                    DBClass.CreateParameter("@id", transferId)
                );

                // Remove existing items
                DBClass.ExecuteNonQuery("DELETE FROM tbl_material_transfer_item WHERE transfer_id = @id", DBClass.CreateParameter("@id", transferId));

                // Insert current items
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    // Skip new row placeholder if present
                    if (row.IsNewRow)
                        continue;

                    DBClass.ExecuteNonQuery(@"
                        INSERT INTO tbl_material_transfer_item
                        (transfer_id, item_id, available_qty, transfer_qty, uom, unit_cost, line_total)
                        VALUES
                        (@transfer, @item, @available, @qty, @uom, @cost, @total)",
                        DBClass.CreateParameter("@transfer", transferId),
                        DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                        DBClass.CreateParameter("@available", row.Cells["availableQty"].Value),
                        DBClass.CreateParameter("@qty", row.Cells["transferQty"].Value),
                        DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                        DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                        DBClass.CreateParameter("@total", row.Cells["total"].Value)
                    );
                }

                EventHub.RefreshMaterialTransfer();
                MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (transferId == 0) return;

            //mssage to ask
            var result = MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DBClass.ExecuteNonQuery("DELETE FROM tbl_material_transfer_item WHERE transfer_id = @id", DBClass.CreateParameter("@id", transferId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_material_transfer WHERE transfer_id = @id", DBClass.CreateParameter("@id", transferId));
            }

            EventHub.RefreshMaterialTransfer();
            MessageBox.Show("Deleted Successfully");
        }
    }
}