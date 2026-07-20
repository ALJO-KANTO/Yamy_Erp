using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using System;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialReceipt
{
    public partial class frmMaterialReceipt : Form
    {
        int receiptId;
        public frmMaterialReceipt(int _id = 0)
        {
            InitializeComponent();
            this.receiptId = _id;
            Load += Frm_Load;

            btnNew.Click += BtnNew_Click;
            btnClear.Click += BtnNew_Click;
            btnAddItem.Click += BtnAddItem_Click;
            btnSave.Click += BtnSave_Click;
            btnApprove.Click += BtnApprove_Click;

            txtReceiveQty.TextChanged += CalcLineTotal;
            txtCost.TextChanged += CalcLineTotal;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();

            if (receiptId > 0)
                LoadData();
            else
                NewRecord();
        }
        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_receipt where receipt_id = @id", DBClass.CreateParameter("@id", receiptId)))
            {
                if (reader.Read())
                {
                    txtNo.Text = reader["receipt_no"].ToString();
                    cmbPO.SelectedValue = reader["po_id"];
                    cmbSupplier.SelectedValue = reader["supplier_id"];
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbWarehouse.SelectedValue = reader["warehouse_id"];
                    dtDate.Value = Convert.ToDateTime(reader["receipt_date"]);
                    dtInvoiceDate.Value = Convert.ToDateTime(reader["invoice_date"]);
                    txtInvoiceNo.Text = reader["invoice_no"].ToString();
                    cmbReceivedBy.SelectedValue = reader["received_by"];
                    cmbCheckedBy.SelectedValue = reader["checked_by"];
                    txtVehicle.Text = reader["vehicle_no"].ToString();
                    txtDriver.Text = reader["driver_name"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtSubtotal.Text = Convert.ToDecimal(reader["subtotal"]).ToString("0.00");
                    txtVAT.Text = Convert.ToDecimal(reader["vat_amount"]).ToString("0.00");
                    txtNet.Text = Convert.ToDecimal(reader["net_amount"]).ToString("0.00");
                    txtRemarks.Text = reader["remarks"].ToString();

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,mri.* from tbl_material_receipt_item mri INNER JOIN tbl_items i ON i.id = mri.item_id where receipt_id = @id", DBClass.CreateParameter("@id", receiptId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["ordered_qty"], reader1["received_qty"], reader1["accepted_qty"], reader1["rejected_qty"], reader1["uom"], reader1["unit_cost"], reader1["line_total"]);
                        }
                    }
                }
            }
        }
        void LoadCombos()
        {
            cmbPO.DataSource = DBClass.ExecuteDataTable("SELECT id, invoice_id FROM tbl_purchase_order");
            cmbPO.DisplayMember = "invoice_id";
            cmbPO.ValueMember = "id";

            cmbSupplier.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_vendor");
            cmbSupplier.DisplayMember = "name";
            cmbSupplier.ValueMember = "id";

            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_projects");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbWarehouse.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_warehouse");
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";

            cmbReceivedBy.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_employee");
            cmbReceivedBy.DisplayMember = "name";
            cmbReceivedBy.ValueMember = "id";

            cmbCheckedBy.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_employee");
            cmbCheckedBy.DisplayMember = "name";
            cmbCheckedBy.ValueMember = "id";

            cmbItem.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_items");
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft","Pending","Approved","Rejected"
            });
        }

        void InitGrid()
        {
            dgvItems.Columns.Add("itemId", "Item Id");
            dgvItems.Columns.Add("itemName", "Item");
            dgvItems.Columns.Add("orderQty", "Order Qty");
            dgvItems.Columns.Add("recvQty", "Received");
            dgvItems.Columns.Add("accQty", "Accepted");
            dgvItems.Columns.Add("rejQty", "Rejected");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("cost", "Cost");
            dgvItems.Columns.Add("total", "Total");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            receiptId = 0;

            txtNo.Text = "GRN-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;
            dtInvoiceDate.Value = DateTime.Today;

            cmbStatus.Text = "Draft";

            txtRemarks.Clear();
            txtSubtotal.Text = "0";
            txtVAT.Text = "0";
            txtNet.Text = "0";

            dgvItems.Rows.Clear();
        }

        void CalcLineTotal(object sender, EventArgs e)
        {
            try
            {
                decimal qty = Convert.ToDecimal(txtReceiveQty.Text);
                decimal cost = Convert.ToDecimal(txtCost.Text);

                txtLineTotal.Text = (qty * cost).ToString("0.00");
            }
            catch
            {
                txtLineTotal.Text = "0";
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            dgvItems.Rows.Add(
                cmbItem.SelectedValue,
                cmbItem.Text,
                txtOrderQty.Text,
                txtReceiveQty.Text,
                txtAcceptedQty.Text,
                txtRejectedQty.Text,
                txtUom.Text,
                txtCost.Text,
                txtLineTotal.Text
            );

            CalculateSummary();
        }

        void CalculateSummary()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                subtotal += Convert.ToDecimal(row.Cells["total"].Value);
            }

            decimal vat = subtotal * 0.05m;
            decimal net = subtotal + vat;

            txtSubtotal.Text = subtotal.ToString("0.00");
            txtVAT.Text = vat.ToString("0.00");
            txtNet.Text = net.ToString("0.00");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = @"
            INSERT INTO tbl_material_receipt
            (receipt_no,receipt_date,po_id,supplier_id,
             project_id,warehouse_id,invoice_no,invoice_date,
             received_by,checked_by,vehicle_no,driver_name,
             status,subtotal,vat_amount,net_amount,
             remarks,created_by)
            VALUES
            (@no,@date,@po,@supplier,@project,@warehouse,
             @invoice,@invdate,@received,@checked,
             @vehicle,@driver,@status,@subtotal,
             @vat,@net,@remarks,@user);

            SELECT LAST_INSERT_ID();";

            receiptId = Convert.ToInt32(DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@po", cmbPO.SelectedValue),
                DBClass.CreateParameter("@supplier", cmbSupplier.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@warehouse", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@invoice", txtInvoiceNo.Text),
                DBClass.CreateParameter("@invdate", dtInvoiceDate.Value.Date),
                DBClass.CreateParameter("@received", cmbReceivedBy.SelectedValue),
                DBClass.CreateParameter("@checked", cmbCheckedBy.SelectedValue),
                DBClass.CreateParameter("@vehicle", txtVehicle.Text),
                DBClass.CreateParameter("@driver", txtDriver.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@subtotal", txtSubtotal.Text),
                DBClass.CreateParameter("@vat", txtVAT.Text),
                DBClass.CreateParameter("@net", txtNet.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@user", frmLogin.userId)
            ));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_receipt_item
                (receipt_id,item_id,ordered_qty,received_qty,
                 accepted_qty,rejected_qty,uom,unit_cost,line_total)
                VALUES
                (@rid,@item,@ord,@recv,@acc,@rej,@uom,@cost,@total)",

                DBClass.CreateParameter("@rid", receiptId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@ord", row.Cells["orderQty"].Value),
                DBClass.CreateParameter("@recv", row.Cells["recvQty"].Value),
                DBClass.CreateParameter("@acc", row.Cells["accQty"].Value),
                DBClass.CreateParameter("@rej", row.Cells["rejQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@total", row.Cells["total"].Value));
            }

            EventHub.RefreshMaterialReceipt();
            MessageBox.Show("Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (receiptId == 0) return;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal acceptedQty =
                    Convert.ToDecimal(row.Cells["accQty"].Value);

                if (acceptedQty <= 0)
                    continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_item_transaction
                (date,type,reference,item_id,
                 cost_price,qty_in,
                 description,warehouse_id,project_id, GlobalId, DeviceId)
                VALUES
                (@date,'RECEIPT',@ref,@item,
                 @cost,@qty,
                 'Material Receipt / GRN',
                 @warehouse,@project, @GlobalId, @DeviceId)",

                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@ref", txtNo.Text),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@qty", acceptedQty),
                DBClass.CreateParameter("@warehouse", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("GlobalId", Guid.NewGuid().ToString()),
                DBClass.CreateParameter("DeviceId", Utilities.MachineName));
            }

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_material_receipt SET status='Approved', approved_by=@u WHERE receipt_id=@id",

                DBClass.CreateParameter("@u", frmLogin.userId),
                DBClass.CreateParameter("@id", receiptId));

            MessageBox.Show("GRN Approved & Stock Updated");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (receiptId == 0) return;

            string query = @"Update tbl_material_receipt SET receipt_no=@no,receipt_date=@date,po_id=@po,supplier_id=@supplier,
             project_id=@project,warehouse_id=@warehouse,invoice_no=@invoice,invoice_date=@invdate,
             received_by=@received,checked_by=@checked,vehicle_no=@vehicle,driver_name=@driver,
             status=@status,subtotal=@subtotal,vat_amount=@vat,net_amount=@net,
             remarks=@remarks WHERE receipt_id=@id";

            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@po", cmbPO.SelectedValue),
                DBClass.CreateParameter("@supplier", cmbSupplier.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@warehouse", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@invoice", txtInvoiceNo.Text),
                DBClass.CreateParameter("@invdate", dtInvoiceDate.Value.Date),
                DBClass.CreateParameter("@received", cmbReceivedBy.SelectedValue),
                DBClass.CreateParameter("@checked", cmbCheckedBy.SelectedValue),
                DBClass.CreateParameter("@vehicle", txtVehicle.Text),
                DBClass.CreateParameter("@driver", txtDriver.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@subtotal", txtSubtotal.Text),
                DBClass.CreateParameter("@vat", txtVAT.Text),
                DBClass.CreateParameter("@net", txtNet.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@id", receiptId)
            );

            DBClass.ExecuteNonQuery("Delete from tbl_material_receipt_item WHERE receipt_id = @id", DBClass.CreateParameter("@id", receiptId));
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_receipt_item
                (receipt_id,item_id,ordered_qty,received_qty,
                 accepted_qty,rejected_qty,uom,unit_cost,line_total)
                VALUES
                (@rid,@item,@ord,@recv,@acc,@rej,@uom,@cost,@total)",

                DBClass.CreateParameter("@rid", receiptId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@ord", row.Cells["orderQty"].Value),
                DBClass.CreateParameter("@recv", row.Cells["recvQty"].Value),
                DBClass.CreateParameter("@acc", row.Cells["accQty"].Value),
                DBClass.CreateParameter("@rej", row.Cells["rejQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@total", row.Cells["total"].Value));
            }

            EventHub.RefreshMaterialReceipt();
            MessageBox.Show("Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(receiptId == 0) return;

            DBClass.ExecuteNonQuery("Delete from tbl_material_receipt_item WHERE receipt_id = @id", DBClass.CreateParameter("@id", receiptId));
            DBClass.ExecuteNonQuery("Delete from tbl_material_receipt WHERE receipt_id = @id", DBClass.CreateParameter("@id", receiptId));

            EventHub.RefreshMaterialReceipt();
            MessageBox.Show("Delete Successfully");
        }
    }
}