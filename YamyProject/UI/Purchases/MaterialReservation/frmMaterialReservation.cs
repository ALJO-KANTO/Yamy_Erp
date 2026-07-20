using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.Purchases
{
    public partial class frmMaterialReservation : Form
    {
        int reservationId = 0;

        public frmMaterialReservation(int id = 0)
        {
            InitializeComponent();

            this.reservationId = id;
            Load += Frm_Load;
            btnAddItem.Click += BtnAddItem_Click;
            btnSave.Click += BtnSave_Click;
            btnApprove.Click += BtnApprove_Click;
            btnNew.Click += BtnNew_Click;
            btnClear.Click += BtnNew_Click;
            cmbItem.SelectedIndexChanged += CmbItem_SelectedIndexChanged;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();

            if (reservationId > 0)
                LoadData();
            else
                NewRecord();
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_reservation where reservation_id = @id", DBClass.CreateParameter("@id", reservationId)))
            {
                if (reader.Read())
                {
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbWarehouse.SelectedValue = reader["warehouse_id"];
                    txtNo.Text = reader["reservation_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["reservation_date"]);
                    cmbStatus.Text = reader["Status"].ToString();
                    cmbMR.SelectedValue = reader["mr_id"];
                    txtRemarks.Text = reader["remarks"].ToString();

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,mri.* from tbl_material_reservation_item mri INNER JOIN tbl_items i ON i.id = mri.item_id where reservation_id = @id", DBClass.CreateParameter("@id", reservationId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["requested_qty"], reader1["available_qty"], reader1["reserved_qty"], reader1["uom"]);
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

            cmbWarehouse.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_warehouse");
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";

            cmbMR.DataSource = DBClass.ExecuteDataTable("SELECT mr_id, mr_no FROM tbl_material_request");
            cmbMR.DisplayMember = "mr_no";
            cmbMR.ValueMember = "mr_id";

            cmbItem.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_items");
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft","Reserved","Approved","Cancelled"
            });
        }

        void InitGrid()
        {
            dgvItems.Columns.Add("itemId", "Item Id");
            dgvItems.Columns.Add("itemName", "Item");
            dgvItems.Columns.Add("reqQty", "Req Qty");
            dgvItems.Columns.Add("availQty", "Avail Qty");
            dgvItems.Columns.Add("reserveQty", "Reserve Qty");
            dgvItems.Columns.Add("uom", "UOM");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            reservationId = 0;
            txtNo.Text = "RSV-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtDate.Value = DateTime.Today;
            cmbStatus.Text = "Draft";
            txtRemarks.Clear();
            dgvItems.Rows.Clear();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedValue == null) return;

            string sql = @"
            SELECT IFNULL(SUM(qty_in - qty_out),0)
            FROM tbl_item_transaction
            WHERE item_id=@item
            AND warehouse_id=@wh";

            txtAvailQty.Text = DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@item", cmbItem.SelectedValue),
                DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue)).ToString();

            txtUom.Text = "";
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            decimal avail = Convert.ToDecimal(txtAvailQty.Text);
            decimal reserve = Convert.ToDecimal(txtReserveQty.Text);

            if (reserve > avail)
            {
                MessageBox.Show("Reserve Qty exceeds available stock.");
                return;
            }

            dgvItems.Rows.Add(
                cmbItem.SelectedValue,
                cmbItem.Text,
                txtReqQty.Text,
                txtAvailQty.Text,
                txtReserveQty.Text,
                txtUom.Text
            );
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = @"
            INSERT INTO tbl_material_reservation
            (reservation_no,reservation_date,mr_id,project_id,
             warehouse_id,reserved_by,status,remarks,created_by)
            VALUES
            (@no,@date,@mr,@project,@wh,@by,@status,@remarks,@cb);
            SELECT LAST_INSERT_ID();";

            reservationId = Convert.ToInt32(DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@mr", cmbMR.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@by", frmLogin.userId),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@cb", frmLogin.userId)));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_reservation_item
                (reservation_id,item_id,requested_qty,
                 available_qty,reserved_qty,uom)
                VALUES
                (@rid,@item,@req,@avail,@res,@uom)",

                DBClass.CreateParameter("@rid", reservationId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@req", row.Cells["reqQty"].Value),
                DBClass.CreateParameter("@avail", row.Cells["availQty"].Value),
                DBClass.CreateParameter("@res", row.Cells["reserveQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value));
            }
            EventHub.RefreshMaterialReservation();
            MessageBox.Show("Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (reservationId == 0) return;

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_material_reservation SET status='Approved' WHERE reservation_id=@id",
                DBClass.CreateParameter("@id", reservationId));

            MessageBox.Show("Reservation Approved");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(reservationId == 0) return;
            
            string sql = @"
            Update tbl_material_reservation SET
            reservation_no = @no, reservation_date = @date, mr_id = @mr, project_id = @project, warehouse_id = @wh, reserved_by = @by, status = @status, remarks = @remarks
            WHERE reservation_id = @id";

            DBClass.ExecuteNonQuery(sql,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@mr", cmbMR.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@by", frmLogin.userId),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@id", reservationId));

            DBClass.ExecuteNonQuery("Delete from tbl_material_reservation_item where reservation_id = @id", DBClass.CreateParameter("@id", reservationId));
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_reservation_item
                (reservation_id,item_id,requested_qty,
                 available_qty,reserved_qty,uom)
                VALUES
                (@rid,@item,@req,@avail,@res,@uom)",

                DBClass.CreateParameter("@rid", reservationId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@req", row.Cells["reqQty"].Value),
                DBClass.CreateParameter("@avail", row.Cells["availQty"].Value),
                DBClass.CreateParameter("@res", row.Cells["reserveQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value));
            }

            EventHub.RefreshMaterialReservation();
            MessageBox.Show("Edited Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // delete data
            DBClass.ExecuteNonQuery("Delete from tbl_material_reservation_item where reservation_id = @id", DBClass.CreateParameter("@id", reservationId));
            DBClass.ExecuteNonQuery("Delete from tbl_material_reservation where reservation_id = @id", DBClass.CreateParameter("@id", reservationId));

            EventHub.RefreshMaterialReservation();
            MessageBox.Show("Deleted Successfully");
        }
    }
}