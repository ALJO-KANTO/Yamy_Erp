using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialProcurementRequest
{
    public partial class frmProcurementRequest : Form
    {
        int prId = 0;

        public frmProcurementRequest(int _id = 0)
        {
            InitializeComponent();

            this.prId = _id;
            Load += Frm_Load;
            btnAddItem.Click += BtnAddItem_Click;
            btnSave.Click += BtnSave_Click;
            btnApprove.Click += BtnApprove_Click;
            btnNew.Click += BtnNew_Click;
            btnClear.Click += BtnNew_Click;

            txtQty.TextChanged += CalcAmount;
            txtRate.TextChanged += CalcAmount;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();
            if (prId > 0)
                LoadData();
            else
                NewRecord();
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_procurement_request where pr_id = @id", DBClass.CreateParameter("@id", prId)))
            {
                if (reader.Read())
                {
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSupplier.SelectedValue = reader["supplier_id"];
                    cmbMR.SelectedValue = reader["mr_id"];
                    cmbReservation.SelectedValue = reader["reservation_id"];
                    cmbPriority.Text = reader["priority_level"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtNo.Text = reader["pr_no"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["pr_date"]);
                    dtReqDate.Value = Convert.ToDateTime(reader["required_date"]);

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,pri.* from tbl_procurement_request_item pri INNER JOIN tbl_items i ON i.id = pri.item_id where pri.pr_id = @id", DBClass.CreateParameter("@id", prId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["requested_qty"], reader1["uom"], reader1["est_rate"], reader1["est_amount"]);
                        }
                    }
                }
            }
        }

        void LoadCombos()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbSupplier.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_vendor");
            cmbSupplier.DisplayMember = "name";
            cmbSupplier.ValueMember = "id";

            cmbMR.DataSource = DBClass.ExecuteDataTable(
                "SELECT mr_id, mr_no FROM tbl_material_request");
            cmbMR.DisplayMember = "mr_no";
            cmbMR.ValueMember = "mr_id";

            cmbReservation.DataSource = DBClass.ExecuteDataTable(
                "SELECT reservation_id, reservation_no FROM tbl_material_reservation");
            cmbReservation.DisplayMember = "reservation_no";
            cmbReservation.ValueMember = "reservation_id";

            cmbItem.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_items");
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbPriority.Items.AddRange(new object[]
            {
                "Low","Normal","High","Urgent"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft","Pending Approval","Approved","Cancelled"
            });
        }

        void InitGrid()
        {
            dgvItems.Columns.Add("itemId", "Item Id");
            dgvItems.Columns.Add("itemName", "Item");
            dgvItems.Columns.Add("qty", "Qty");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("rate", "Rate");
            dgvItems.Columns.Add("amount", "Amount");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            prId = 0;
            txtNo.Text = "PR-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtDate.Value = DateTime.Today;
            dtReqDate.Value = DateTime.Today.AddDays(7);
            cmbPriority.Text = "Normal";
            cmbStatus.Text = "Draft";
            txtRemarks.Clear();
            dgvItems.Rows.Clear();
        }

        void CalcAmount(object sender, EventArgs e)
        {
            try
            {
                decimal qty = Convert.ToDecimal(txtQty.Text);
                decimal rate = Convert.ToDecimal(txtRate.Text);
                txtAmount.Text = (qty * rate).ToString("0.00");
            }
            catch
            {
                txtAmount.Text = "0.00";
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
                txtQty.Text,
                txtUom.Text,
                txtRate.Text,
                txtAmount.Text
            );
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = @"
                INSERT INTO tbl_procurement_request
                (pr_no,pr_date,mr_id,reservation_id,project_id,
                 supplier_id,priority_level,required_date,status,
                 remarks,created_by)
                VALUES
                (@no,@date,@mr,@rsv,@project,@supplier,@priority,
                 @reqdate,@status,@remarks,@user);
                SELECT LAST_INSERT_ID();";

            prId = Convert.ToInt32(DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@mr", cmbMR.SelectedValue),
                DBClass.CreateParameter("@rsv", cmbReservation.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@supplier", cmbSupplier.SelectedValue),
                DBClass.CreateParameter("@priority", cmbPriority.Text),
                DBClass.CreateParameter("@reqdate", dtReqDate.Value.Date),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@user", frmLogin.userId)));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_procurement_request_item
                    (pr_id,item_id,requested_qty,ordered_qty,
                     pending_qty,uom,est_rate,est_amount)
                    VALUES
                    (@pr,@item,@qty,0,@qty,@uom,@rate,@amt)",

                DBClass.CreateParameter("@pr", prId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@qty", row.Cells["qty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@rate", row.Cells["rate"].Value),
                DBClass.CreateParameter("@amt", row.Cells["amount"].Value));
            }
            EventHub.RefreshMaterialProcurement();
            MessageBox.Show("Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (prId == 0) return;

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_procurement_request SET status='Approved', approved_by=@u WHERE pr_id=@id",
                DBClass.CreateParameter("@u", frmLogin.userId),
                DBClass.CreateParameter("@id", prId));

            MessageBox.Show("PR Approved");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = @"
                Update tbl_procurement_request SET
                pr_no = @no,pr_date=@date,mr_id=@mr,reservation_id=@rsv,project_id=@project,supplier_id=@supplier,priority_level=@priority,
                required_date=@reqdate,status=@status,remarks=@remarks where pr_id = @pr";

                DBClass.ExecuteScalar(sql,
                    DBClass.CreateParameter("@no", txtNo.Text),
                    DBClass.CreateParameter("@date", dtDate.Value.Date),
                    DBClass.CreateParameter("@mr", cmbMR.SelectedValue),
                    DBClass.CreateParameter("@rsv", cmbReservation.SelectedValue),
                    DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@supplier", cmbSupplier.SelectedValue),
                    DBClass.CreateParameter("@priority", cmbPriority.Text),
                    DBClass.CreateParameter("@reqdate", dtReqDate.Value.Date),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@pr", prId));

            DBClass.ExecuteNonQuery(@"Delete from tbl_procurement_request_item where pr_id = @pr", DBClass.CreateParameter("@pr", prId));
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_procurement_request_item
                    (pr_id,item_id,requested_qty,ordered_qty,
                     pending_qty,uom,est_rate,est_amount)
                    VALUES
                    (@pr,@item,@qty,0,@qty,@uom,@rate,@amt)",

                DBClass.CreateParameter("@pr", prId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@qty", row.Cells["qty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@rate", row.Cells["rate"].Value),
                DBClass.CreateParameter("@amt", row.Cells["amount"].Value));
            }
            EventHub.RefreshMaterialProcurement();
            MessageBox.Show("Edited Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery(@"Delete from tbl_procurement_request_item where pr_id = @pr", DBClass.CreateParameter("@pr", prId));
            DBClass.ExecuteNonQuery(@"Delete from tbl_procurement_request where pr_id = @pr", DBClass.CreateParameter("@pr", prId));
            
            EventHub.RefreshMaterialProcurement();
            MessageBox.Show("Saved Successfully");
        }
    }
}