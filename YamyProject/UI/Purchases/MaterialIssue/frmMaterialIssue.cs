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

namespace YamyProject.UI.Purchases.MaterialIssue
{
    public partial class frmMaterialIssue : Form
    {
        int issueId = 0;

        public frmMaterialIssue(int _id = 0)
        {
            InitializeComponent();
            this.issueId = _id;

            txtIssueQty.TextChanged += CalcTotal;
            txtCost.TextChanged += CalcTotal;
            cmbItem.SelectedIndexChanged += CmbItem_SelectedIndexChanged;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitGrid();

            if (issueId > 0)
                LoadData();
            else
                NewRecord();
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_material_issue where issue_id = @id", DBClass.CreateParameter("@id", issueId)))
            {
                if (reader.Read())
                {
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbWarehouse.SelectedValue = reader["warehouse_id"];
                    txtNo.Text = reader["issue_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["issue_date"]);
                    cmbStatus.Text = reader["status"].ToString();
                    cmbReservation.SelectedValue = reader["reservation_id"];
                    cmbRequestedBy.SelectedValue = reader["requested_by"];
                    cmbIssuedTo.SelectedValue = reader["issued_to"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    txtPurpose.Text = reader["purpose"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    //items
                    using (MySqlDataReader reader1 = DBClass.ExecuteReader("select i.name,mri.* from tbl_material_issue_item mri INNER JOIN tbl_items i ON i.id = mri.item_id where issue_id = @id", DBClass.CreateParameter("@id", issueId)))
                    {
                        while (reader1.Read())
                        {
                            dgvItems.Rows.Add(reader1["item_id"], reader1["name"], reader1["reserved_qty"], reader1["available_qty"], reader1["issue_qty"], reader1["uom"], reader1["unit_cost"], reader1["line_total"]);
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

            cmbReservation.DataSource = DBClass.ExecuteDataTable(
                "SELECT reservation_id, reservation_no FROM tbl_material_reservation");
            cmbReservation.DisplayMember = "reservation_no";
            cmbReservation.ValueMember = "reservation_id";

            cmbRequestedBy.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_employee");
            cmbRequestedBy.DisplayMember = "name";
            cmbRequestedBy.ValueMember = "id";

            cmbIssuedTo.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_employee");
            cmbIssuedTo.DisplayMember = "name";
            cmbIssuedTo.ValueMember = "id";

            cmbZone.DataSource = DBClass.ExecuteDataTable("SELECT id, zone_name FROM tbl_project_zone");
            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbItem.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_items");
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft","Pending","Approved","Issued","Cancelled"
            });
        }

        void InitGrid()
        {
            dgvItems.Columns.Add("itemId", "Item Id");
            dgvItems.Columns.Add("itemName", "Item");
            dgvItems.Columns.Add("reservedQty", "Reserved");
            dgvItems.Columns.Add("availableQty", "Available");
            dgvItems.Columns.Add("issueQty", "Issue Qty");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("cost", "Cost");
            dgvItems.Columns.Add("total", "Total");

            dgvItems.Columns["itemId"].Visible = false;
        }

        void NewRecord()
        {
            issueId = 0;
            txtNo.Text = "ISS-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtDate.Value = DateTime.Today;
            cmbStatus.Text = "Draft";
            txtPurpose.Clear();
            txtRemarks.Clear();
            dgvItems.Rows.Clear();
        }

        void CalcTotal(object sender, EventArgs e)
        {
            try
            {
                decimal qty = Convert.ToDecimal(txtIssueQty.Text);
                decimal cost = Convert.ToDecimal(txtCost.Text);
                txtTotal.Text = (qty * cost).ToString("0.00");
            }
            catch
            {
                txtTotal.Text = "0.00";
            }
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedValue == null || cmbWarehouse.SelectedValue == null)
                return;

            string sql = @"
            SELECT IFNULL(SUM(qty_in - qty_out),0)
            FROM tbl_item_transaction
            WHERE item_id=@item AND warehouse_id=@wh";

            txtAvailableQty.Text =
                DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@item", cmbItem.SelectedValue),
                DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue)).ToString();

            txtReservedQty.Text = "0";
            txtUom.Text = "";
            txtCost.Text = "0";
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            decimal avail = Convert.ToDecimal(txtAvailableQty.Text);
            decimal issue = Convert.ToDecimal(txtIssueQty.Text);

            if (issue > avail)
            {
                MessageBox.Show("Issue qty exceeds available stock.");
                return;
            }

            dgvItems.Rows.Add(
                cmbItem.SelectedValue,
                cmbItem.Text,
                txtReservedQty.Text,
                txtAvailableQty.Text,
                txtIssueQty.Text,
                txtUom.Text,
                txtCost.Text,
                txtTotal.Text
            );
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = @"
            INSERT INTO tbl_material_issue
            (issue_no,issue_date,project_id,warehouse_id,reservation_id,
             requested_by,issued_to,zone_id,purpose,status,
             remarks,created_by)
            VALUES
            (@no,@date,@project,@wh,@rsv,@req,@to,@zone,@purpose,
             @status,@remarks,@user);
            SELECT LAST_INSERT_ID();";

            issueId = Convert.ToInt32(DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@no", txtNo.Text),
                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@rsv", cmbReservation.SelectedValue),
                DBClass.CreateParameter("@req", cmbRequestedBy.SelectedValue),
                DBClass.CreateParameter("@to", cmbIssuedTo.SelectedValue),
                DBClass.CreateParameter("@zone", cmbZone.SelectedValue),
                DBClass.CreateParameter("@purpose", txtPurpose.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@user", frmLogin.userId)));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_issue_item
                (issue_id,item_id,reserved_qty,available_qty,
                 issue_qty,uom,unit_cost,line_total)
                VALUES
                (@id,@item,@res,@avail,@qty,@uom,@cost,@total)",

                DBClass.CreateParameter("@id", issueId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@res", row.Cells["reservedQty"].Value),
                DBClass.CreateParameter("@avail", row.Cells["availableQty"].Value),
                DBClass.CreateParameter("@qty", row.Cells["issueQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@total", row.Cells["total"].Value));
            }
            EventHub.RefreshMaterialIssue();
            MessageBox.Show("Saved Successfully");
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (issueId == 0) return;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_item_transaction
                (date,type,reference,item_id,cost_price,
                 qty_out,description,warehouse_id,project_id, GlobalId, DeviceId)
                VALUES
                (@date,'ISSUE',@ref,@item,@cost,@qty,
                 'Material Issue to Site',@wh,@project, @GlobalId, @DeviceId)",

                DBClass.CreateParameter("@date", dtDate.Value.Date),
                DBClass.CreateParameter("@ref", txtNo.Text),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@qty", row.Cells["issueQty"].Value),
                DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue),
                DBClass.CreateParameter("@project", cmbProject.SelectedValue),
                DBClass.CreateParameter("GlobalId", Guid.NewGuid().ToString()),
                DBClass.CreateParameter("DeviceId", Utilities.MachineName));
            }

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_material_issue SET status='Issued', approved_by=@u WHERE issue_id=@id",
                DBClass.CreateParameter("@u", frmLogin.userId),
                DBClass.CreateParameter("@id", issueId));

            MessageBox.Show("Material Issued Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(issueId == 0) return;

            string sql = @"
            UPDATE tbl_material_issue SET
             issue_no = @no,issue_date = @date,project_id = @project,warehouse_id=@wh,reservation_id=@rsv,
             requested_by=@req,issued_to=@to,zone_id=@zone,purpose=@purpose,status=@status,
             remarks=@remarks where issue_id=@issueId";

            DBClass.ExecuteNonQuery(sql,
            DBClass.CreateParameter("@no", txtNo.Text),
            DBClass.CreateParameter("@date", dtDate.Value.Date),
            DBClass.CreateParameter("@project", cmbProject.SelectedValue),
            DBClass.CreateParameter("@wh", cmbWarehouse.SelectedValue),
            DBClass.CreateParameter("@rsv", cmbReservation.SelectedValue),
            DBClass.CreateParameter("@req", cmbRequestedBy.SelectedValue),
            DBClass.CreateParameter("@to", cmbIssuedTo.SelectedValue),
            DBClass.CreateParameter("@zone", cmbZone.SelectedValue),
            DBClass.CreateParameter("@purpose", txtPurpose.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text),
            DBClass.CreateParameter("@issueId", issueId));

            DBClass.ExecuteNonQuery("Delete from tbl_material_issue_item where issue_id = @issueId", DBClass.CreateParameter("@issueId", issueId));

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_material_issue_item
                (issue_id,item_id,reserved_qty,available_qty,
                 issue_qty,uom,unit_cost,line_total)
                VALUES
                (@id,@item,@res,@avail,@qty,@uom,@cost,@total)",

                DBClass.CreateParameter("@id", issueId),
                DBClass.CreateParameter("@item", row.Cells["itemId"].Value),
                DBClass.CreateParameter("@res", row.Cells["reservedQty"].Value),
                DBClass.CreateParameter("@avail", row.Cells["availableQty"].Value),
                DBClass.CreateParameter("@qty", row.Cells["issueQty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["uom"].Value),
                DBClass.CreateParameter("@cost", row.Cells["cost"].Value),
                DBClass.CreateParameter("@total", row.Cells["total"].Value));
            }

            EventHub.RefreshMaterialIssue();
            MessageBox.Show("Edited Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery("Delete from tbl_material_issue where issue_id = @issueId", DBClass.CreateParameter("@issueId", issueId));
            DBClass.ExecuteNonQuery("Delete from tbl_material_issue_item where issue_id = @issueId", DBClass.CreateParameter("@issueId", issueId));
            
            EventHub.RefreshMaterialIssue();
            MessageBox.Show("Deleted Successfully");
        }
    }
}
