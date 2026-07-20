using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectResources
{
    public partial class frmResourceNeeds : Form
    {
        int resourceId = 0;

        public frmResourceNeeds()
        {
            InitializeComponent();

            Load += frmResourceNeeds_Load;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnNew.Click += btnNew_Click;
            btnClear.Click += btnClear_Click;
            dgv.CellClick += dgv_CellClick;
        }

        private void frmResourceNeeds_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadZones();
            LoadCombos();
            LoadGrid();
            NewRecord();
        }

        void LoadProjects()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable(
                "SELECT project_id, project_name FROM tbl_projects ORDER BY project_name");

            cmbProject.DisplayMember = "project_name";
            cmbProject.ValueMember = "project_id";
        }

        void LoadZones()
        {
            cmbZone.DataSource = DBClass.ExecuteDataTable(
                "SELECT zone_name FROM tbl_project_zones ORDER BY zone_name");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "zone_name";
        }

        void LoadCombos()
        {
            cmbNeedType.Items.AddRange(new object[]
            {
                "Labor","Material","Equipment"
            });

            cmbPriority.Items.AddRange(new object[]
            {
                "Low","Medium","High","Critical"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft","Pending","Approved","Issued","Closed"
            });
        }

        void LoadGrid()
        {
            dgv.DataSource = DBClass.ExecuteDataTable(@"
            SELECT resource_id, request_date, need_type,
                   category_name, item_name, qty,
                   zone_name, status
            FROM tbl_project_resource_needs
            ORDER BY resource_id DESC");

            dgv.Columns["resource_id"].Visible = false;
        }

        void NewRecord()
        {
            resourceId = 0;

            dtRequestDate.Value = DateTime.Today;
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today.AddDays(7);

            txtCategory.Clear();
            txtItem.Clear();
            txtUnit.Clear();
            txtQty.Text = "0";
            txtRequestedBy.Clear();
            txtApprovedBy.Clear();
            txtRemarks.Clear();

            cmbNeedType.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 1;
            cmbStatus.Text = "Draft";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery(@"
            INSERT INTO tbl_project_resource_needs
            (
                project_id,request_date,need_type,category_name,item_name,
                unit_name,qty,required_from,required_to,
                priority_level,zone_name,requested_by,approved_by,status,remarks
            )
            VALUES
            (
                @project_id,@request_date,@need_type,@category_name,@item_name,
                @unit_name,@qty,@required_from,@required_to,
                @priority_level,@zone_name,@requested_by,@approved_by,@status,@remarks
            )",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@request_date", dtRequestDate.Value.Date),
            DBClass.CreateParameter("@need_type", cmbNeedType.Text),
            DBClass.CreateParameter("@category_name", txtCategory.Text),
            DBClass.CreateParameter("@item_name", txtItem.Text),
            DBClass.CreateParameter("@unit_name", txtUnit.Text),
            DBClass.CreateParameter("@qty", txtQty.Text),
            DBClass.CreateParameter("@required_from", dtFrom.Value.Date),
            DBClass.CreateParameter("@required_to", dtTo.Value.Date),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@zone_name", cmbZone.Text),
            DBClass.CreateParameter("@requested_by", txtRequestedBy.Text),
            DBClass.CreateParameter("@approved_by", txtApprovedBy.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text));

            MessageBox.Show("Saved Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (resourceId == 0) return;

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_resource_needs SET
                project_id=@project_id,
                request_date=@request_date,
                need_type=@need_type,
                category_name=@category_name,
                item_name=@item_name,
                unit_name=@unit_name,
                qty=@qty,
                required_from=@required_from,
                required_to=@required_to,
                priority_level=@priority_level,
                zone_name=@zone_name,
                requested_by=@requested_by,
                approved_by=@approved_by,
                status=@status,
                remarks=@remarks
            WHERE resource_id=@resource_id",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@request_date", dtRequestDate.Value.Date),
            DBClass.CreateParameter("@need_type", cmbNeedType.Text),
            DBClass.CreateParameter("@category_name", txtCategory.Text),
            DBClass.CreateParameter("@item_name", txtItem.Text),
            DBClass.CreateParameter("@unit_name", txtUnit.Text),
            DBClass.CreateParameter("@qty", txtQty.Text),
            DBClass.CreateParameter("@required_from", dtFrom.Value.Date),
            DBClass.CreateParameter("@required_to", dtTo.Value.Date),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@zone_name", cmbZone.Text),
            DBClass.CreateParameter("@requested_by", txtRequestedBy.Text),
            DBClass.CreateParameter("@approved_by", txtApprovedBy.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text),
            DBClass.CreateParameter("@resource_id", resourceId));

            MessageBox.Show("Updated Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (resourceId == 0) return;

            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_project_resource_needs WHERE resource_id=@id",
                DBClass.CreateParameter("@id", resourceId));

            MessageBox.Show("Deleted Successfully");
            LoadGrid();
            NewRecord();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            resourceId = Convert.ToInt32(
                dgv.Rows[e.RowIndex].Cells["resource_id"].Value);
        }
    }
}
