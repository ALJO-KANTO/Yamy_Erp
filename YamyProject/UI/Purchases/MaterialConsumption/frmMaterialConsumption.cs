using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialConsumption
{
    public partial class frmMaterialConsumption : Form
    {
        int consumptionId = 0;

        public frmMaterialConsumption(int _id = 0)
        {
            InitializeComponent();
            this.consumptionId = _id;
            Load += Frm_Load;

            btnNew.Click += BtnNew_Click;
            btnClear.Click += BtnNew_Click;

            btnAddItem.Click += BtnAddItem_Click;
            btnSave.Click += BtnSave_Click;
            btnApprove.Click += BtnApprove_Click;

            txtConsumeQty.TextChanged += CalcTotal;
            txtCost.TextChanged += CalcTotal;

            cmbItem.SelectedIndexChanged += CmbItem_SelectedIndexChanged;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();

            if (consumptionId > 0)
                LoadData();
            else
                NewRecord();
        }
        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_consumption where consumption_id = @id", DBClass.CreateParameter("@id", consumptionId)))
            {
                if (reader.Read())
                {
                    txtNo.Text = reader["consumption_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["consumption_date"]);
                    //dt.Value = Convert.ToDateTime(reader["consumption_date"]);
                    cmbWarehouse.SelectedValue = reader["warehouse_id"];
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    cmbActivity.SelectedValue = reader["activity_id"];
                    cmbWBS.SelectedValue = reader["wbs_id"];
                    cmbConsumedBy.SelectedValue = reader["consumed_by"];
                    cmbType.Text = reader["consumption_type"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtReference.Text = reader["reference_no"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,mti.* from tbl_material_consumption_item mti INNER JOIN tbl_items i ON i.id = mti.item_id where consumption_id = @id", DBClass.CreateParameter("@id", consumptionId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["available_qty"], reader1["consumed_qty"], reader1["wastage_qty"], reader1["uom"], reader1["unit_cost"], reader1["line_total"]);
                        }
                    }

                    CalculateGrandTotal();
                }
            }
        }

        void LoadCombos()
        {
            cmbProject.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects");

            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbZone.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, zone_name FROM tbl_project_zone");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbActivity.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, activity_name FROM tbl_project_activity_plan");

            cmbActivity.DisplayMember = "activity_name";
            cmbActivity.ValueMember = "id";

            cmbWBS.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_project_wbs");

            cmbWBS.DisplayMember = "name";
            cmbWBS.ValueMember = "id";

            cmbWarehouse.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_warehouse");

            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";

            cmbConsumedBy.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_employee");

            cmbConsumedBy.DisplayMember = "name";
            cmbConsumedBy.ValueMember = "id";

            cmbItem.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_items");

            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbType.Items.AddRange(new object[]
            {
                "Site Consumption",
                "Production Consumption",
                "Activity Consumption",
                "Wastage Consumption"
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
            dgvItems.Columns.Add("consumeQty", "Consumed");
            dgvItems.Columns.Add("wastageQty", "Wastage");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("cost", "Cost");
            dgvItems.Columns.Add("total", "Total");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            consumptionId = 0;

            txtNo.Text =
                "CON-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            cmbType.Text = "Site Consumption";
            cmbStatus.Text = "Draft";

            txtRemarks.Clear();

            txtGrandTotal.Text = "0";

            dgvItems.Rows.Clear();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedValue == null ||
                cmbWarehouse.SelectedValue == null)
                return;

            string sql = @"
            SELECT IFNULL(SUM(qty_in - qty_out),0)
            FROM tbl_item_transaction
            WHERE item_id=@item
            AND warehouse_id=@warehouse";

            txtAvailableQty.Text =
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter("@item",
                    cmbItem.SelectedValue),

                DBClass.CreateParameter("@warehouse",
                    cmbWarehouse.SelectedValue)
                ).ToString();
        }

        void CalcTotal(object sender, EventArgs e)
        {
            try
            {
                decimal qty =
                    Convert.ToDecimal(txtConsumeQty.Text);

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

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            decimal available =
                Convert.ToDecimal(txtAvailableQty.Text);

            decimal consume =
                Convert.ToDecimal(txtConsumeQty.Text);

            if (consume > available)
            {
                MessageBox.Show(
                    "Consumption qty exceeds available stock.");

                return;
            }

            dgvItems.Rows.Add(
                cmbItem.SelectedValue,
                cmbItem.Text,
                txtAvailableQty.Text,
                txtConsumeQty.Text,
                txtWastageQty.Text,
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
            INSERT INTO tbl_material_consumption
            (
                consumption_no,
                consumption_date,
                project_id,
                zone_id,
                activity_id,
                wbs_id,
                warehouse_id,
                consumed_by,
                consumption_type,
                reference_no,
                status,
                remarks,
                created_by
            )
            VALUES
            (
                @no,@date,@project,@zone,@activity,
                @wbs,@warehouse,@consumedby,
                @type,@reference,@status,
                @remarks,@user
            );

            SELECT LAST_INSERT_ID();";

            consumptionId =
                Convert.ToInt32(DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@zone", cmbZone.SelectedValue),
                DBClass.CreateParameter("@activity", cmbActivity.SelectedValue),
                DBClass.CreateParameter("@wbs", cmbWBS.SelectedValue),
                DBClass.CreateParameter("@warehouse", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@consumedby", cmbConsumedBy.SelectedValue),
                DBClass.CreateParameter("@type", cmbType.Text),
                DBClass.CreateParameter("@reference", txtReference.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@user", frmLogin.userId)
            ));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_consumption_item
                (
                    consumption_id,
                    item_id,
                    available_qty,
                    consumed_qty,
                    wastage_qty,
                    uom,
                    unit_cost,
                    line_total
                )
                VALUES
                (
                    @consumption,
                    @item,
                    @available,
                    @consume,
                    @wastage,
                    @uom,
                    @cost,
                    @total
                )",

                DBClass.CreateParameter("@consumption",
                    consumptionId),

                DBClass.CreateParameter("@item",
                    row.Cells["itemId"].Value),

                DBClass.CreateParameter("@available",
                    row.Cells["availableQty"].Value),

                DBClass.CreateParameter("@consume",
                    row.Cells["consumeQty"].Value),

                DBClass.CreateParameter("@wastage",
                    row.Cells["wastageQty"].Value),

                DBClass.CreateParameter("@uom",
                    row.Cells["uom"].Value),

                DBClass.CreateParameter("@cost",
                    row.Cells["cost"].Value),

                DBClass.CreateParameter("@total",
                    row.Cells["total"].Value));
            }

            EventHub.RefreshMaterialConsumption();
            MessageBox.Show("Material Consumption Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (consumptionId == 0)
                return;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal consumeQty =
                    Convert.ToDecimal(
                        row.Cells["consumeQty"].Value);

                decimal wastageQty =
                    Convert.ToDecimal(
                        row.Cells["wastageQty"].Value);

                decimal totalQty =
                    consumeQty + wastageQty;

                if (totalQty <= 0)
                    continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_item_transaction
                (
                    date,
                    type,
                    reference,
                    item_id,
                    cost_price,
                    qty_out,
                    description,
                    warehouse_id,
                    project_id, GlobalId, DeviceId
                )
                VALUES
                (
                    @date,
                    'CONSUMPTION',
                    @reference,
                    @item,
                    @cost,
                    @qty,
                    'Material Consumption',
                    @warehouse,
                    @project, @GlobalId, @DeviceId
                )",

                DBClass.CreateParameter("@date",
                    dtDate.Value.Date),

                DBClass.CreateParameter("@reference",
                    txtNo.Text),

                DBClass.CreateParameter("@item",
                    row.Cells["itemId"].Value),

                DBClass.CreateParameter("@cost",
                    row.Cells["cost"].Value),

                DBClass.CreateParameter("@qty",
                    totalQty),

                DBClass.CreateParameter("@warehouse",
                    cmbWarehouse.SelectedValue),

                DBClass.CreateParameter("GlobalId", Guid.NewGuid().ToString()),
                DBClass.CreateParameter("DeviceId", Utilities.MachineName),
                DBClass.CreateParameter("@project",
                    cmbProject.SelectedValue));
            }

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_material_consumption
            SET status='Approved',
                approved_by=@user
            WHERE consumption_id=@id",

            DBClass.CreateParameter("@user",
                frmLogin.userId),

            DBClass.CreateParameter("@id",
                consumptionId));

            MessageBox.Show(
                "Material Consumption Approved Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (consumptionId == 0) return;

            try
            {
                string sql = @"
                            UPDATE tbl_material_consumption
                            SET
                                consumption_no = @no,
                                consumption_date = @date,
                                project_id = @project,
                                zone_id = @zone,
                                activity_id = @activity,
                                wbs_id = @wbs,
                                warehouse_id = @warehouse,
                                consumed_by = @consumedby,
                                consumption_type = @type,
                                reference_no = @reference,
                                status = @status,
                                remarks = @remarks
                            WHERE consumption_id = @id;";

                DBClass.ExecuteNonQuery(sql,
                    DBClass.CreateParameter("@no", txtNo.Text),
                    DBClass.CreateParameter("@date", dtDate.Value.Date),
                    DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@zone", cmbZone.SelectedValue),
                    DBClass.CreateParameter("@activity", cmbActivity.SelectedValue),
                    DBClass.CreateParameter("@wbs", cmbWBS.SelectedValue),
                    DBClass.CreateParameter("@warehouse", cmbWarehouse.SelectedValue),
                    DBClass.CreateParameter("@consumedby", cmbConsumedBy.SelectedValue),
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@reference", txtReference.Text),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@id", consumptionId)
                );

                // Remove existing item lines then re-insert current grid rows
                DBClass.ExecuteNonQuery("DELETE FROM tbl_material_consumption_item WHERE consumption_id = @id",
                    DBClass.CreateParameter("@id", consumptionId));

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.IsNewRow) continue;

                    var itemId = row.Cells["itemId"].Value;
                    if (itemId == null) continue;

                    decimal available = 0;
                    decimal consumed = 0;
                    decimal wastage = 0;
                    decimal cost = 0;
                    decimal total = 0;

                    decimal.TryParse(Convert.ToString(row.Cells["availableQty"].Value), out available);
                    decimal.TryParse(Convert.ToString(row.Cells["consumeQty"].Value), out consumed);
                    decimal.TryParse(Convert.ToString(row.Cells["wastageQty"].Value), out wastage);
                    decimal.TryParse(Convert.ToString(row.Cells["cost"].Value), out cost);
                    decimal.TryParse(Convert.ToString(row.Cells["total"].Value), out total);

                    // skip if nothing to record
                    if ((consumed + wastage) <= 0) continue;

                    DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_material_consumption_item
                    (
                        consumption_id,
                        item_id,
                        available_qty,
                        consumed_qty,
                        wastage_qty,
                        uom,
                        unit_cost,
                        line_total
                    )
                    VALUES
                    (
                        @consumption,
                        @item,
                        @available,
                        @consume,
                        @wastage,
                        @uom,
                        @cost,
                        @total
                    )",
                        DBClass.CreateParameter("@consumption", consumptionId),
                        DBClass.CreateParameter("@item", itemId),
                        DBClass.CreateParameter("@available", available),
                        DBClass.CreateParameter("@consume", consumed),
                        DBClass.CreateParameter("@wastage", wastage),
                        DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                        DBClass.CreateParameter("@cost", cost),
                        DBClass.CreateParameter("@total", total)
                    );
                }

                EventHub.RefreshMaterialConsumption();
                MessageBox.Show("Material Consumption Updated Successfully");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (consumptionId == 0) return;

            //mssage to ask
            var result = MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DBClass.ExecuteNonQuery("DELETE FROM tbl_material_consumption_item WHERE consumption_id = @id", DBClass.CreateParameter("@id", consumptionId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_material_consumption WHERE consumption_id = @id", DBClass.CreateParameter("@id", consumptionId));
            }

            EventHub.RefreshMaterialConsumption();
            MessageBox.Show("Deleted Successfully");
        }
    }
}
