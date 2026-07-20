using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmEquipmentUsage : Form
    {
        int usageId = 0;
        public frmEquipmentUsage()
        {
            InitializeComponent();
        }

        private void frmEquipmentUsage_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrid();

            if (usageId > 0)
                LoadData(); 
            else
                NewRecord();
        }

        private void LoadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_equipment_usage where usage_id = @id", DBClass.CreateParameter("id", usageId)))
            {
                if (reader.Read())
                {
                    txtUsageNo.Text = reader["usage_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["usage_date"]);
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSite.SelectedValue = reader["site_id"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    cmbOperator.SelectedValue = reader["operator_id"];
                    cmbShift.Text = reader["shift_type"].ToString();
                    cmbWeather.Text = reader["weather"].ToString();
                    txtTotalHours.Text = reader["total_working_hours"].ToString();
                    txtTotalFuel.Text = reader["total_fuel_used"].ToString();
                    txtTotalCost.Text = reader["total_cost"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    using (MySqlDataReader readerDetails = DBClass.ExecuteReader("select * from tbl_equipment_usage_details where usage_id = @id", DBClass.CreateParameter("id", usageId)))
                    {
                        while (readerDetails.Read())
                        {
                            dgvUsage.Rows.Add(readerDetails["equipment_code"], readerDetails["equipment_name"], readerDetails["activity"], readerDetails["start_meter"], readerDetails["end_meter"],
                            readerDetails["working_hours"], readerDetails["idle_hours"], readerDetails["breakdown_hours"], readerDetails["fuel_used"], readerDetails["fuel_rate"], readerDetails["fuel_cost"],
                            readerDetails["operator_cost"], readerDetails["rental_cost"], readerDetails["total_cost"], readerDetails["utilization_percent"], readerDetails["status"], readerDetails["remarks"]);
                        }
                    }
                    using (MySqlDataReader readerBreakdown = DBClass.ExecuteReader("select * from tbl_equipment_breakdown where usage_id=@id", DBClass.CreateParameter("id", usageId)))
                    {
                        dgvBreakdown.Rows.Add(readerBreakdown["equipment_id"], readerBreakdown["breakdown_time"], readerBreakdown["resume_time"], readerBreakdown["breakdown_reason"], readerBreakdown["corrective_action"], readerBreakdown["maintenance_required"]);

                    }
                    using (MySqlDataReader readerFuel = DBClass.ExecuteReader("select * from tbl_equipment_fuel_log where usage_id=@id", DBClass.CreateParameter("id", usageId)))
                    {
                        dgvFuel.Rows.Add(readerFuel["equipment_id"], readerFuel["fuel_date"], readerFuel["fuel_qty"], readerFuel["fuel_rate"], readerFuel["amount"], readerFuel["fuel_station"], readerFuel["remarks"]);
                    }
                }
            }
        }

        void LoadCombos()
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

            cmbOperator.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT employee_id,employee_name FROM tbl_employee");

            cmbOperator.DisplayMember = "employee_name";
            cmbOperator.ValueMember = "employee_id";

            cmbShift.Items.AddRange(new object[]
            {
                "Day",
                "Night"
            });

            cmbWeather.Items.AddRange(new object[]
            {
                "Sunny",
                "Cloudy",
                "Rainy",
                "Hot",
                "Windy"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft",
                "Approved",
                "Completed",
                "Closed"
            });
        }
        void InitializeGrid()
        {
            dgvUsage.Columns.Add("equipment_code", "Code");

            dgvUsage.Columns.Add("equipment_name", "Equipment");

            dgvUsage.Columns.Add("activity", "Activity");

            dgvUsage.Columns.Add("start_meter", "Start Meter");

            dgvUsage.Columns.Add("end_meter", "End Meter");

            dgvUsage.Columns.Add("working_hours", "Working Hours");

            dgvUsage.Columns.Add("idle_hours", "Idle Hours");

            dgvUsage.Columns.Add("breakdown_hours", "Breakdown");

            dgvUsage.Columns.Add("fuel_used", "Fuel Used");

            dgvUsage.Columns.Add("fuel_rate", "Fuel Rate");

            dgvUsage.Columns.Add("fuel_cost", "Fuel Cost");

            dgvUsage.Columns.Add("operator_cost", "Operator Cost");

            dgvUsage.Columns.Add("rental_cost", "Rental Cost");

            dgvUsage.Columns.Add("total_cost", "Total Cost");

            dgvUsage.Columns.Add("utilization", "Utilization %");

            dgvUsage.Columns.Add("status", "Status");

            dgvUsage.Columns.Add("remarks", "Remarks");

            dgvBreakdown.Columns.Add("equipment", "Equipment");

            dgvBreakdown.Columns.Add("breakdown_time", "Breakdown Time");

            dgvBreakdown.Columns.Add("resume_time", "Resume Time");

            dgvBreakdown.Columns.Add("reason", "Reason");

            dgvBreakdown.Columns.Add("action", "Action");

            dgvBreakdown.Columns.Add("maintenance", "Maintenance");

            dgvFuel.Columns.Add("equipment", "Equipment");

            dgvFuel.Columns.Add("fuel_date", "Fuel Date");

            dgvFuel.Columns.Add("qty", "Qty");

            dgvFuel.Columns.Add("rate", "Rate");

            dgvFuel.Columns.Add("amount", "Amount");

            dgvFuel.Columns.Add("station", "Fuel Station");

            dgvFuel.Columns.Add("remarks", "Remarks");
        }
        void NewRecord()
        {
            usageId = 0;

            txtUsageNo.Text =
                "EU-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            cmbShift.Text = "Day";

            cmbStatus.Text = "Draft";

            txtTotalHours.Text = "0";
            txtTotalFuel.Text = "0";
            txtTotalCost.Text = "0";

            dgvUsage.Rows.Clear();
            dgvBreakdown.Rows.Clear();
            dgvFuel.Rows.Clear();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotals();
        }
        void CalculateTotals()
        {
            decimal totalHours = 0;
            decimal totalFuel = 0;
            decimal totalCost = 0;

            foreach (DataGridViewRow row in dgvUsage.Rows)
            {
                if (row.IsNewRow) continue;

                decimal startMeter =
                    Utilities.ParseDecimalValue(
                        row.Cells["start_meter"].Value);

                decimal endMeter =
                    Utilities.ParseDecimalValue(
                        row.Cells["end_meter"].Value);

                decimal working =
                    endMeter - startMeter;

                decimal fuel =
                    Utilities.ParseDecimalValue(
                        row.Cells["fuel_used"].Value);

                decimal fuelRate =
                    Utilities.ParseDecimalValue(
                        row.Cells["fuel_rate"].Value);

                decimal fuelCost =
                    fuel * fuelRate;

                decimal operatorCost =
                    Utilities.ParseDecimalValue(
                        row.Cells["operator_cost"].Value);

                decimal rentalCost =
                    Utilities.ParseDecimalValue(
                        row.Cells["rental_cost"].Value);

                decimal total =
                    fuelCost + operatorCost + rentalCost;

                decimal utilization = 0;

                if (working > 0)
                {
                    utilization =
                        (working / 24) * 100;
                }

                row.Cells["working_hours"].Value =
                    working.ToString("0.00");

                row.Cells["fuel_cost"].Value =
                    fuelCost.ToString("0.00");

                row.Cells["total_cost"].Value =
                    total.ToString("0.00");

                row.Cells["utilization"].Value =
                    utilization.ToString("0.00");

                totalHours += working;
                totalFuel += fuel;
                totalCost += total;
            }

            txtTotalHours.Text =
                totalHours.ToString("0.00");

            txtTotalFuel.Text =
                totalFuel.ToString("0.00");

            txtTotalCost.Text =
                totalCost.ToString("0.00");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CalculateTotals();

            SaveHeader();

            SaveUsage();

            SaveBreakdown();

            SaveFuel();

            MessageBox.Show(
                "Equipment Usage Saved Successfully");
        }
        void SaveHeader()
        {
            string sql = @"
            INSERT INTO tbl_equipment_usage
            (
                usage_no,
                usage_date,
                project_id,
                site_id,
                zone_id,
                operator_id,
                shift_type,
                weather,
                total_working_hours,
                total_fuel_used,
                total_cost,
                status,
                remarks,
                created_by
            )
            VALUES
            (
                @usage_no,
                @usage_date,
                @project_id,
                @site_id,
                @zone_id,
                @operator_id,
                @shift_type,
                @weather,
                @total_working_hours,
                @total_fuel_used,
                @total_cost,
                @status,
                @remarks,
                @created_by
            );

            SELECT LAST_INSERT_ID();";

            usageId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter(
                    "@usage_no",
                    txtUsageNo.Text),

                DBClass.CreateParameter(
                    "@usage_date",
                    dtDate.Value.Date),

                DBClass.CreateParameter(
                    "@project_id",
                    cmbProject.SelectedValue),

                DBClass.CreateParameter(
                    "@site_id",
                    cmbSite.SelectedValue),

                DBClass.CreateParameter(
                    "@zone_id",
                    cmbZone.SelectedValue),

                DBClass.CreateParameter(
                    "@operator_id",
                    cmbOperator.SelectedValue),

                DBClass.CreateParameter(
                    "@shift_type",
                    cmbShift.Text),

                DBClass.CreateParameter(
                    "@weather",
                    cmbWeather.Text),

                DBClass.CreateParameter(
                    "@total_working_hours",
                    txtTotalHours.Text),

                DBClass.CreateParameter(
                    "@total_fuel_used",
                    txtTotalFuel.Text),

                DBClass.CreateParameter(
                    "@total_cost",
                    txtTotalCost.Text),

                DBClass.CreateParameter(
                    "@status",
                    cmbStatus.Text),

                DBClass.CreateParameter(
                    "@remarks",
                    txtRemarks.Text),

                DBClass.CreateParameter(
                    "@created_by",
                    frmLogin.userId)
                ));
        }
        void SaveUsage()
        {
            foreach (DataGridViewRow row in dgvUsage.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_equipment_usage_details
                (
                    usage_id,
                    equipment_code,
                    equipment_name,
                    start_hour_meter,
                    end_hour_meter,
                    working_hours,
                    idle_hours,
                    breakdown_hours,
                    fuel_used,
                    fuel_rate,
                    fuel_cost,
                    operator_cost,
                    rental_cost,
                    total_cost,
                    utilization_percent,
                    status,
                    remarks
                )
                VALUES
                (
                    @usage_id,
                    @equipment_code,
                    @equipment_name,
                    @start_hour_meter,
                    @end_hour_meter,
                    @working_hours,
                    @idle_hours,
                    @breakdown_hours,
                    @fuel_used,
                    @fuel_rate,
                    @fuel_cost,
                    @operator_cost,
                    @rental_cost,
                    @total_cost,
                    @utilization_percent,
                    @status,
                    @remarks
                )",

                DBClass.CreateParameter(
                    "@usage_id",
                    usageId),

                DBClass.CreateParameter(
                    "@equipment_code",
                    row.Cells["equipment_code"].Value),

                DBClass.CreateParameter(
                    "@equipment_name",
                    row.Cells["equipment_name"].Value),

                DBClass.CreateParameter(
                    "@start_hour_meter",
                    row.Cells["start_meter"].Value),

                DBClass.CreateParameter(
                    "@end_hour_meter",
                    row.Cells["end_meter"].Value),

                DBClass.CreateParameter(
                    "@working_hours",
                    row.Cells["working_hours"].Value),

                DBClass.CreateParameter(
                    "@idle_hours",
                    row.Cells["idle_hours"].Value),

                DBClass.CreateParameter(
                    "@breakdown_hours",
                    row.Cells["breakdown_hours"].Value),

                DBClass.CreateParameter(
                    "@fuel_used",
                    row.Cells["fuel_used"].Value),

                DBClass.CreateParameter(
                    "@fuel_rate",
                    row.Cells["fuel_rate"].Value),

                DBClass.CreateParameter(
                    "@fuel_cost",
                    row.Cells["fuel_cost"].Value),

                DBClass.CreateParameter(
                    "@operator_cost",
                    row.Cells["operator_cost"].Value),

                DBClass.CreateParameter(
                    "@rental_cost",
                    row.Cells["rental_cost"].Value),

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

        void SaveBreakdown()
        {
            foreach (DataGridViewRow row in dgvBreakdown.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_equipment_breakdown
                (
                    usage_id,
                    breakdown_time,
                    resume_time,
                    breakdown_reason,
                    corrective_action,
                    maintenance_required
                )
                VALUES
                (
                    @usage_id,
                    @breakdown_time,
                    @resume_time,
                    @breakdown_reason,
                    @corrective_action,
                    @maintenance_required
                )",

                DBClass.CreateParameter(
                    "@usage_id",
                    usageId),

                DBClass.CreateParameter(
                    "@breakdown_time",
                    row.Cells["breakdown_time"].Value),

                DBClass.CreateParameter(
                    "@resume_time",
                    row.Cells["resume_time"].Value),

                DBClass.CreateParameter(
                    "@breakdown_reason",
                    row.Cells["reason"].Value),

                DBClass.CreateParameter(
                    "@corrective_action",
                    row.Cells["action"].Value),

                DBClass.CreateParameter(
                    "@maintenance_required",
                    row.Cells["maintenance"].Value));
            }
        }

        void SaveFuel()
        {
            foreach (DataGridViewRow row in dgvFuel.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_equipment_fuel_log
                (
                    usage_id,
                    fuel_date,
                    fuel_qty,
                    fuel_rate,
                    amount,
                    fuel_station,
                    remarks
                )
                VALUES
                (
                    @usage_id,
                    @fuel_date,
                    @fuel_qty,
                    @fuel_rate,
                    @amount,
                    @fuel_station,
                    @remarks
                )",

                DBClass.CreateParameter(
                    "@usage_id",
                    usageId),

                DBClass.CreateParameter(
                    "@fuel_date",
                    row.Cells["fuel_date"].Value),

                DBClass.CreateParameter(
                    "@fuel_qty",
                    row.Cells["qty"].Value),

                DBClass.CreateParameter(
                    "@fuel_rate",
                    row.Cells["rate"].Value),

                DBClass.CreateParameter(
                    "@amount",
                    row.Cells["amount"].Value),

                DBClass.CreateParameter(
                    "@fuel_station",
                    row.Cells["station"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            usageId = 0;
            dgvBreakdown.Rows.Clear();
            dgvFuel.Rows.Clear();
            dgvUsage.Rows.Clear();
            txtRemarks.Text = "";
            txtTotalCost.Text = "0";
            txtTotalFuel.Text = "0";
            txtTotalHours.Text = "0";
            txtUsageNo.Text = "0";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // update 
            if (usageId > 0)
            {
                // Recalculate totals from grid values
                CalculateTotals();

                // Update header
                string sql = @"
                UPDATE tbl_equipment_usage
                SET
                    usage_no = @usage_no,
                    usage_date = @usage_date,
                    project_id = @project_id,
                    site_id = @site_id,
                    zone_id = @zone_id,
                    operator_id = @operator_id,
                    shift_type = @shift_type,
                    weather = @weather,
                    total_working_hours = @total_working_hours,
                    total_fuel_used = @total_fuel_used,
                    total_cost = @total_cost,
                    status = @status,
                    remarks = @remarks
                WHERE usage_id = @usage_id;";

                DBClass.ExecuteNonQuery(
                    sql,
                    DBClass.CreateParameter("@usage_no", txtUsageNo.Text),
                    DBClass.CreateParameter("@usage_date", dtDate.Value.Date),
                    DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@site_id", cmbSite.SelectedValue),
                    DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                    DBClass.CreateParameter("@operator_id", cmbOperator.SelectedValue),
                    DBClass.CreateParameter("@shift_type", cmbShift.Text),
                    DBClass.CreateParameter("@weather", cmbWeather.Text),
                    DBClass.CreateParameter("@total_working_hours", txtTotalHours.Text),
                    DBClass.CreateParameter("@total_fuel_used", txtTotalFuel.Text),
                    DBClass.CreateParameter("@total_cost", txtTotalCost.Text),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@usage_id", usageId)
                );

                // Remove previous detail rows for this usage and re-insert current ones
                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_equipment_usage_details WHERE usage_id = @usage_id",
                    DBClass.CreateParameter("@usage_id", usageId));

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_equipment_breakdown WHERE usage_id = @usage_id",
                    DBClass.CreateParameter("@usage_id", usageId));

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_equipment_fuel_log WHERE usage_id = @usage_id",
                    DBClass.CreateParameter("@usage_id", usageId));

                // Re-save details from grids
                SaveUsage();
                SaveBreakdown();
                SaveFuel();

                MessageBox.Show("Equipment Usage Updated Successfully");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Ensure a record is selected
            if (usageId > 0)
            {
                // 2. Confirm deletion
                var res = MessageBox.Show("Are you sure you want to delete this Equipment Usage record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        // 3a. Delete related detail rows
                        DBClass.ExecuteNonQuery(
                            "DELETE FROM tbl_equipment_usage_details WHERE usage_id = @usage_id",
                            DBClass.CreateParameter("@usage_id", usageId));

                        DBClass.ExecuteNonQuery(
                            "DELETE FROM tbl_equipment_breakdown WHERE usage_id = @usage_id",
                            DBClass.CreateParameter("@usage_id", usageId));

                        DBClass.ExecuteNonQuery(
                            "DELETE FROM tbl_equipment_fuel_log WHERE usage_id = @usage_id",
                            DBClass.CreateParameter("@usage_id", usageId));

                        // 3b. Delete header row
                        DBClass.ExecuteNonQuery(
                            "DELETE FROM tbl_equipment_usage WHERE usage_id = @usage_id",
                            DBClass.CreateParameter("@usage_id", usageId));

                        // 3c. Reset form state
                        usageId = 0;
                        NewRecord();

                        // 3d. Notify success
                        MessageBox.Show("Equipment Usage Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // 4. Error handling
                        MessageBox.Show("An error occurred while deleting the record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // 5. No record selected
                MessageBox.Show("No Equipment Usage record is selected to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation

                if (usageId == 0)
                {
                    MessageBox.Show(
                        "Please save the Equipment Usage first.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cmbStatus.Text == "Approved")
                {
                    MessageBox.Show(
                        "This record is already approved.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // Confirmation

                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to approve this Equipment Usage?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                // Update Status

                string updateQuery = @"
                    UPDATE tbl_equipment_usage
                    SET
                        status = 'Approved'
                    WHERE usage_id = @usage_id";

                DBClass.ExecuteNonQuery(updateQuery,

                    DBClass.CreateParameter(
                        "@usage_id",
                        usageId)
                );

                // Optional:
                // Update related detail rows

                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_equipment_usage_details
                    SET status = 'Approved'
                    WHERE usage_id = @usage_id",

                    DBClass.CreateParameter(
                        "@usage_id",
                        usageId)
                );

                // Audit Log

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Approve Equipment Usage",
                    "Equipment Usage",
                    usageId,
                    "Approved Equipment Usage : " + txtUsageNo.Text
                );

                // Update UI

                cmbStatus.Text = "Approved";

                btnApprove.Enabled = false;

                btnSave.Enabled = false;

                btnUpdate.Enabled = false;

                // Success Message

                MessageBox.Show(
                    "Equipment Usage Approved Successfully.",
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
    }
}
