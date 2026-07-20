using System;
using System.Data;
using System.Windows.Forms;
using YamyProject;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmResourceDeployment : Form
    {
        int deploymentId = 0;
        public frmResourceDeployment()
        {
            InitializeComponent();
        }

        private void frmResourceDeployment_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrid();

            if (deploymentId > 0)
                LoadData();
            else
                NewRecord();
        }

        private void LoadData()
        {
            throw new NotImplementedException();
        }

        private void LoadCombos()
        {
            cmbProject.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT project_id,project_name FROM tbl_projects");

            cmbProject.DisplayMember = "project_name";
            cmbProject.ValueMember = "project_id";

            cmbSite.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT site_id,site_name FROM tbl_project_site");

            cmbSite.DisplayMember = "site_name";
            cmbSite.ValueMember = "site_id";

            cmbZone.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT zone_id,zone_name FROM tbl_project_zones");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "zone_id";

            DataTable dtEmp =
                DBClass.ExecuteDataTable(
                "SELECT id as employee_id,name as employee_name FROM tbl_employee");

            cmbRequestedBy.DataSource = dtEmp.Copy();
            cmbRequestedBy.DisplayMember = "employee_name";
            cmbRequestedBy.ValueMember = "employee_id";

            cmbApprovedBy.DataSource = dtEmp;
            cmbApprovedBy.DisplayMember = "employee_name";
            cmbApprovedBy.ValueMember = "employee_id";

            cmbDeploymentType.Items.AddRange(new object[]
            {
                    "Labour",
                    "Equipment",
                    "Material",
                    "Vehicle",
                    "Mixed"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                    "Draft",
                    "Requested",
                    "Approved",
                    "Completed",
                    "Cancelled"
            });
        }

        void InitializeGrid()
        {
            dgvResources.Columns.Add("resource_type", "Resource Type");

            dgvResources.Columns.Add("resource_name", "Resource");

            dgvResources.Columns.Add("activity", "Activity");

            dgvResources.Columns.Add("planned_qty", "Planned Qty");

            dgvResources.Columns.Add("deployed_qty", "Deployed Qty");

            dgvResources.Columns.Add("unit", "Unit");

            dgvResources.Columns.Add("days", "Days");

            dgvResources.Columns.Add("cost_per_day", "Cost/Day");

            dgvResources.Columns.Add("total_cost", "Total Cost");

            dgvResources.Columns.Add("utilization", "Utilization %");

            dgvResources.Columns.Add("status", "Status");

            dgvResources.Columns.Add("remarks", "Remarks");

            dgvMovement.Columns.Add("movement_date", "Movement Date");

            dgvMovement.Columns.Add("from_location", "From");

            dgvMovement.Columns.Add("to_location", "To");

            dgvMovement.Columns.Add("moved_by", "Moved By");

            dgvMovement.Columns.Add("remarks", "Remarks");

            dgvAttachment.Columns.Add("file_path", "File Path");

            dgvAttachment.Columns.Add("description", "Description");
        }

        void NewRecord()
        {
            deploymentId = 0;

            txtDeploymentNo.Text =
                "RD-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            dtStartDate.Value = DateTime.Today;
            dtEndDate.Value = DateTime.Today;

            cmbStatus.Text = "Draft";

            txtTotalResources.Text = "0";
            txtTotalCost.Text = "0";

            dgvResources.Rows.Clear();
            dgvMovement.Rows.Clear();
            dgvAttachment.Rows.Clear();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotals();
        }
        void CalculateTotals()
        {
            decimal totalCost = 0;
            int totalResources = 0;

            foreach (DataGridViewRow row in dgvResources.Rows)
            {
                if (row.IsNewRow) continue;

                decimal qty =
                    Utilities.ParseDecimalValue(
                        row.Cells["deployed_qty"].Value);

                decimal days =
                    Utilities.ParseDecimalValue(
                        row.Cells["days"].Value);

                decimal costPerDay =
                    Utilities.ParseDecimalValue(
                        row.Cells["cost_per_day"].Value);

                decimal total =
                    qty * days * costPerDay;

                row.Cells["total_cost"].Value =
                    total.ToString("0.00");

                totalCost += total;

                totalResources++;
            }

            txtTotalResources.Text =
                totalResources.ToString();

            txtTotalCost.Text =
                totalCost.ToString("0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CalculateTotals();

            SaveHeader();

            SaveResources();

            SaveMovements();

            SaveAttachments();

            MessageBox.Show("Resource Deployment Saved Successfully");
        }

        void SaveHeader()
        {
            string sql = @"
                INSERT INTO tbl_resource_deployment
                (
                    deployment_no,
                    deployment_date,
                    project_id,
                    site_id,
                    zone_id,
                    deployment_type,
                    requested_by,
                    approved_by,
                    start_date,
                    end_date,
                    status,
                    remarks,
                    created_by
                )
                VALUES
                (
                    @deployment_no,
                    @deployment_date,
                    @project_id,
                    @site_id,
                    @zone_id,
                    @deployment_type,
                    @requested_by,
                    @approved_by,
                    @start_date,
                    @end_date,
                    @status,
                    @remarks,
                    @created_by
                );

                SELECT LAST_INSERT_ID();";

            deploymentId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,
                DBClass.CreateParameter("@deployment_no", txtDeploymentNo.Text),
                DBClass.CreateParameter("@deployment_date", dtDate.Value.Date),
                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                DBClass.CreateParameter("@site_id", cmbSite.SelectedValue),
                DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                DBClass.CreateParameter("@deployment_type", cmbDeploymentType.Text),
                DBClass.CreateParameter("@requested_by", cmbRequestedBy.SelectedValue),
                DBClass.CreateParameter("@approved_by", cmbApprovedBy.SelectedValue),
                DBClass.CreateParameter("@start_date", dtStartDate.Value.Date),
                DBClass.CreateParameter("@end_date", dtEndDate.Value.Date),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@created_by", frmLogin.userId)));
        }

        void SaveResources()
        {
            foreach (DataGridViewRow row in dgvResources.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_resource_deployment_details
                    (
                        deployment_id,
                        resource_type,
                        resource_name,
                        planned_qty,
                        deployed_qty,
                        unit,
                        deployment_days,
                        cost_per_day,
                        total_cost,
                        utilization_percent,
                        status,
                        remarks
                    )
                    VALUES
                    (
                        @deployment_id,
                        @resource_type,
                        @resource_name,
                        @planned_qty,
                        @deployed_qty,
                        @unit,
                        @deployment_days,
                        @cost_per_day,
                        @total_cost,
                        @utilization_percent,
                        @status,
                        @remarks
                    )",

                DBClass.CreateParameter(
                    "@deployment_id",
                    deploymentId),

                DBClass.CreateParameter(
                    "@resource_type",
                    row.Cells["resource_type"].Value),

                DBClass.CreateParameter(
                    "@resource_name",
                    row.Cells["resource_name"].Value),

                DBClass.CreateParameter(
                    "@planned_qty",
                    row.Cells["planned_qty"].Value),

                DBClass.CreateParameter(
                    "@deployed_qty",
                    row.Cells["deployed_qty"].Value),

                DBClass.CreateParameter(
                    "@unit",
                    row.Cells["unit"].Value),

                DBClass.CreateParameter(
                    "@deployment_days",
                    row.Cells["days"].Value),

                DBClass.CreateParameter(
                    "@cost_per_day",
                    row.Cells["cost_per_day"].Value),

                DBClass.CreateParameter(
                    "@total_cost",
                    row.Cells["total_cost"].Value),

                DBClass.CreateParameter(
                    "@utilization_percent",
                    row.Cells["utilization"].Value),

                DBClass.CreateParameter(
                    "@status",
                    row.Cells["status"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveMovements()
        {
            foreach (DataGridViewRow row in dgvMovement.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_resource_deployment_movement
                    (
                        deployment_id,
                        movement_date,
                        from_location,
                        to_location,
                        moved_by,
                        remarks
                    )
                    VALUES
                    (
                        @deployment_id,
                        @movement_date,
                        @from_location,
                        @to_location,
                        @moved_by,
                        @remarks
                    )",

                DBClass.CreateParameter(
                    "@deployment_id",
                    deploymentId),

                DBClass.CreateParameter(
                    "@movement_date",
                    row.Cells["movement_date"].Value),

                DBClass.CreateParameter(
                    "@from_location",
                    row.Cells["from_location"].Value),

                DBClass.CreateParameter(
                    "@to_location",
                    row.Cells["to_location"].Value),

                DBClass.CreateParameter(
                    "@moved_by",
                    row.Cells["moved_by"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveAttachments()
        {
            foreach (DataGridViewRow row in dgvAttachment.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_resource_deployment_attachment
                    (
                        deployment_id,
                        file_path,
                        description
                    )
                    VALUES
                    (
                        @deployment_id,
                        @file_path,
                        @description
                    )",

                DBClass.CreateParameter(
                    "@deployment_id",
                    deploymentId),

                DBClass.CreateParameter(
                    "@file_path",
                    row.Cells["file_path"].Value),

                DBClass.CreateParameter(
                    "@description",
                    row.Cells["description"].Value));
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            deploymentId = 0;

            cmbDeploymentType.Text = "";
            cmbStatus.Text = "Draft";
            txtRemarks.Clear();
            txtTotalResources.Text = "0";
            txtTotalCost.Text = "0.00";

            // Clear Grids
            dgvAttachment.Rows.Clear();
            dgvMovement.Rows.Clear();
            dgvResources.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (deploymentId == 0) return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this resource deployment? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Delete child records first to maintain referential integrity
                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment_attachment WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment_movement WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment_details WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                // Delete header
                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                MessageBox.Show("Resource Deployment deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form for a new record
                NewRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Resource Deployment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation

                if (deploymentId == 0)
                {
                    MessageBox.Show(
                        "Please save the deployment first.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Confirm

                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to approve this deployment?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                // Update header status

                string updateQuery = @"
                    UPDATE tbl_resource_deployment
                    SET
                        status = 'Approved',
                        approved_by = @approved_by
                    WHERE deployment_id = @deployment_id";

                DBClass.ExecuteNonQuery(updateQuery,

                    DBClass.CreateParameter(
                        "@approved_by",
                        frmLogin.userId),

                    DBClass.CreateParameter(
                        "@deployment_id",
                        deploymentId)
                );

                // Optional:
                // Insert approval movement/history log

                string historyQuery = @"
                        INSERT INTO tbl_resource_deployment_movement
                        (
                            deployment_id,
                            movement_date,
                            from_location,
                            to_location,
                            moved_by,
                            remarks
                        )
                        VALUES
                        (
                            @deployment_id,
                            NOW(),
                            'Approval Pending',
                            'Approved',
                            @moved_by,
                            @remarks
                        )";

                DBClass.ExecuteNonQuery(historyQuery,

                    DBClass.CreateParameter(
                        "@deployment_id",
                        deploymentId),

                    DBClass.CreateParameter(
                        "@moved_by",
                        frmLogin.userId),

                    DBClass.CreateParameter(
                        "@remarks",
                        "Deployment approved by system")
                );

                // Audit Log

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Approve Resource Deployment",
                    "Resource Deployment",
                    deploymentId,
                    "Approved Deployment : " + txtDeploymentNo.Text
                );

                // Update screen

                cmbStatus.Text = "Approved";

                btnApprove.Enabled = false;

                MessageBox.Show(
                    "Deployment Approved Successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Ensure we have a record to update
            if (deploymentId == 0)
            {
                MessageBox.Show("No resource deployment loaded. Please save a new record or load an existing one before updating.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Make sure totals are current
            CalculateTotals();

            try
            {
                // 3. Update header
                string sqlUpdate = @"
                    UPDATE tbl_resource_deployment
                    SET
                        deployment_no = @deployment_no,
                        deployment_date = @deployment_date,
                        project_id = @project_id,
                        site_id = @site_id,
                        zone_id = @zone_id,
                        deployment_type = @deployment_type,
                        requested_by = @requested_by,
                        approved_by = @approved_by,
                        start_date = @start_date,
                        end_date = @end_date,
                        status = @status,
                        remarks = @remarks
                    WHERE deployment_id = @deployment_id
                ";

                DBClass.ExecuteNonQuery(sqlUpdate,

                    DBClass.CreateParameter("@deployment_no", txtDeploymentNo.Text),
                    DBClass.CreateParameter("@deployment_date", dtDate.Value.Date),
                    DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@site_id", cmbSite.SelectedValue),
                    DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                    DBClass.CreateParameter("@deployment_type", cmbDeploymentType.Text),
                    DBClass.CreateParameter("@requested_by", cmbRequestedBy.SelectedValue),
                    DBClass.CreateParameter("@approved_by", cmbApprovedBy.SelectedValue),
                    DBClass.CreateParameter("@start_date", dtStartDate.Value.Date),
                    DBClass.CreateParameter("@end_date", dtEndDate.Value.Date),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@deployment_id", deploymentId)
                );

                // 4. Remove existing child records to prepare for reinsertion
                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment_attachment WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment_movement WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_resource_deployment_details WHERE deployment_id = @deployment_id",
                    DBClass.CreateParameter("@deployment_id", deploymentId));

                // 5. Re-insert current child rows from the UI
                SaveResources();
                SaveMovements();
                SaveAttachments();

                MessageBox.Show("Resource Deployment updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Resource Deployment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}