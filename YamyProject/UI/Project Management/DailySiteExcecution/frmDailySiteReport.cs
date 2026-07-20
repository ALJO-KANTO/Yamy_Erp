using CrystalDecisions.Shared;
using DocumentFormat.OpenXml.Vml.Office;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YamyProject.UI.Project_Management
{
    public partial class frmDailySiteReport : Form
    {
        int reportId = 0;
        public frmDailySiteReport()
        {
            InitializeComponent();
        }

        private void frmDailySiteReport_Load(object sender, EventArgs e)
        {
            LoadCombos();
            InitializeGrid();

            if (reportId > 0)
                LoadData();
            else
                NewRecord();

        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_daily_site_report where report_id = @id", DBClass.CreateParameter("id", reportId)))
            {
                if (reader.Read())
                {
                    txtReportNo.Text = reader["report_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["report_date"]);
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSite.SelectedValue = reader["site_id"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    cmbEngineer.SelectedValue = reader["engineer_id"];
                    cmbWeather.Text = reader["weather"].ToString();
                    txtTemperature.Text = reader["temperature"].ToString();
                    txtManpower.Text = reader["manpower_count"].ToString();
                    txtEquipmentCount.Text = reader["equipment_count"].ToString();
                    txtProgress.Text = reader["total_progress_percent"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();
                    cmbStatus.Text = reader["status"].ToString();

                    dgvActivity.Rows.Clear();
                    dgvDelay.Rows.Clear();
                    dgvEquipment.Rows.Clear();
                    dgvLabour.Rows.Clear();
                    dgvMaterial.Rows.Clear();
                    dgvVisitor.Rows.Clear();

                    using (MySqlDataReader readerActivity = DBClass.ExecuteReader("select * from tbl_daily_site_report_activity where report_id = @id", DBClass.CreateParameter("id", reportId)))
                    {
                        dgvActivity.Rows.Add(readerActivity["activity_name"], readerActivity["location"], readerActivity["work_description"], readerActivity["planned_qty"], readerActivity["completed_qty"], readerActivity["unit"], readerActivity["progress_percent"], readerActivity["manpower_used"], readerActivity["equipment_used"], readerActivity["remarks"]);
                    }
                    using (MySqlDataReader readerLabour = DBClass.ExecuteReader("select * from tbl_daily_site_report_labour where report_id = @id", DBClass.CreateParameter("id", reportId)))
                    {
                        dgvLabour.Rows.Add(readerLabour["trade_name"], readerLabour["manpower_count"], readerLabour["overtime_hours"], readerLabour["remarks"]);
                    }
                    using (MySqlDataReader readerEquipment = DBClass.ExecuteReader("select * from tbl_daily_site_report_equipment where report_id = @id", DBClass.CreateParameter("id", reportId)))
                    {
                        dgvEquipment.Rows.Add(readerEquipment["equipment_name"], readerEquipment["working_hours"], readerEquipment["idle_hours"], readerEquipment["breakdown_hours"], readerEquipment["remarks"]);
                    }
                    using (MySqlDataReader readerMaterial = DBClass.ExecuteReader("select * from tbl_daily_site_report_material where report_id = @id", DBClass.CreateParameter("id", reportId)))
                    {
                        dgvMaterial.Rows.Add(readerMaterial["material_name"], readerMaterial["qty_used"], readerMaterial["unit"], readerMaterial["remarks"]);
                    }
                    using (MySqlDataReader readerDelay = DBClass.ExecuteReader("select * from tbl_daily_site_report_delay where report_id = @id", DBClass.CreateParameter("id", reportId)))
                    {
                        dgvDelay.Rows.Add(readerDelay["reason"], readerDelay["activity"], readerDelay["hours"], readerDelay["action"]);
                    }
                    using (MySqlDataReader readerVisitor = DBClass.ExecuteReader("select * from tbl_daily_site_report_visitor where report_id = @id", DBClass.CreateParameter("id", reportId)))
                    {
                        dgvVisitor.Rows.Add(readerVisitor["visitor_name"], readerVisitor["company_name"], readerVisitor["purpose"], readerVisitor["visit_time"]);
                    }
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateSummary();
        }

        void CalculateSummary()
        {
            int manpower = 0;
            int equipment = 0;

            decimal progress = 0;
            int progressRows = 0;

            foreach (DataGridViewRow row in dgvLabour.Rows)
            {
                if (row.IsNewRow) continue;

                manpower += Convert.ToInt32(
                    Utilities.ParseDecimalValue(
                    row.Cells["count"].Value));
            }

            foreach (DataGridViewRow row in dgvEquipment.Rows)
            {
                if (row.IsNewRow) continue;

                equipment++;
            }

            foreach (DataGridViewRow row in dgvActivity.Rows)
            {
                if (row.IsNewRow) continue;

                progress +=
                    Utilities.ParseDecimalValue(
                    row.Cells["progress"].Value);

                progressRows++;
            }

            if (progressRows > 0)
                progress = progress / progressRows;

            txtManpower.Text = manpower.ToString();

            txtEquipmentCount.Text = equipment.ToString();

            txtProgress.Text =
                progress.ToString("0.00");
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation

                if (reportId == 0)
                {
                    MessageBox.Show(
                        "Please save the Daily Site Report first.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cmbStatus.Text == "Approved")
                {
                    MessageBox.Show(
                        "This report is already approved.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // Confirmation

                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to approve this Daily Site Report?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                // Update Status

                string updateQuery = @"
                                            UPDATE tbl_daily_site_report
                                            SET
                                                status = 'Approved',
                                                approved_by = @approved_by
                                            WHERE report_id = @report_id";

                DBClass.ExecuteNonQuery(updateQuery,

                    DBClass.CreateParameter(
                        "@approved_by",
                        frmLogin.userId),

                    DBClass.CreateParameter(
                        "@report_id",
                        reportId)
                );

                // Audit Log

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Approve Daily Site Report",
                    "Daily Site Report",
                    reportId,
                    "Approved Daily Site Report : " + txtReportNo.Text
                );

                // Update UI

                cmbStatus.Text = "Approved";

                btnApprove.Enabled = false;

                btnSave.Enabled = false;

                btnUpdate.Enabled = false;

                // Success Message

                MessageBox.Show(
                    "Daily Site Report Approved Successfully.",
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

        void LoadCombos()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_projects");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbSite.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_project_sites");
            cmbSite.DisplayMember = "name";
            cmbSite.ValueMember = "id";

            cmbZone.DataSource = DBClass.ExecuteDataTable("SELECT id,zone_name FROM tbl_project_zone");
            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbEngineer.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_employee");
            cmbEngineer.DisplayMember = "name";
            cmbEngineer.ValueMember = "id";

            cmbWeather.Items.AddRange(new object[] { "Sunny", "Cloudy", "Rainy", "Hot", "Windy" });

            cmbStatus.Items.AddRange(new object[] { "Draft", "Approved", "Submitted", "Closed" });
        }

        void InitializeGrid()
        {
            dgvActivity.Columns.Add("activity", "Activity");
            dgvActivity.Columns.Add("location", "Location");
            dgvActivity.Columns.Add("description", "Description");
            dgvActivity.Columns.Add("planned_qty", "Planned");
            dgvActivity.Columns.Add("completed_qty", "Completed");
            dgvActivity.Columns.Add("unit", "Unit");
            dgvActivity.Columns.Add("progress", "Progress %");
            dgvActivity.Columns.Add("manpower", "Manpower");
            dgvActivity.Columns.Add("equipment", "Equipment");
            dgvActivity.Columns.Add("remarks", "Remarks");

            dgvLabour.Columns.Add("trade", "Trade");
            dgvLabour.Columns.Add("count", "Count");
            dgvLabour.Columns.Add("ot", "OT Hours");
            dgvLabour.Columns.Add("remarks", "Remarks");

            dgvEquipment.Columns.Add("equipment", "Equipment");
            dgvEquipment.Columns.Add("working", "Working");
            dgvEquipment.Columns.Add("idle", "Idle");
            dgvEquipment.Columns.Add("breakdown", "Breakdown");
            dgvEquipment.Columns.Add("remarks", "Remarks");

            dgvMaterial.Columns.Add("material", "Material");
            dgvMaterial.Columns.Add("qty", "Qty");
            dgvMaterial.Columns.Add("unit", "Unit");
            dgvMaterial.Columns.Add("remarks", "Remarks");

            dgvDelay.Columns.Add("reason", "Reason");
            dgvDelay.Columns.Add("activity", "Affected Activity");
            dgvDelay.Columns.Add("hours", "Hours");
            dgvDelay.Columns.Add("action", "Action");

            dgvVisitor.Columns.Add("visitor", "Visitor");
            dgvVisitor.Columns.Add("company", "Company");
            dgvVisitor.Columns.Add("purpose", "Purpose");
            dgvVisitor.Columns.Add("time", "Time");
        }

        void NewRecord()
        {
            reportId = 0;

            txtReportNo.Text =
                "DSR-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            cmbStatus.Text = "Draft";

            txtManpower.Text = "0";
            txtEquipmentCount.Text = "0";
            txtProgress.Text = "0";

            dgvActivity.Rows.Clear();
            dgvLabour.Rows.Clear();
            dgvEquipment.Rows.Clear();
            dgvMaterial.Rows.Clear();
            dgvDelay.Rows.Clear();
            dgvVisitor.Rows.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CalculateSummary();

            SaveHeader();
            SaveActivities();
            SaveLabour();
            SaveEquipment();
            SaveMaterials();
            SaveDelay();
            SaveVisitor();

            MessageBox.Show("Daily Site Report Saved Successfully");
        }

        void SaveHeader()
        {
            string sql = @"
                INSERT INTO tbl_daily_site_report
                (
                    report_no,
                    report_date,
                    project_id,
                    site_id,
                    zone_id,
                    engineer_id,
                    weather,
                    temperature,
                    manpower_count,
                    equipment_count,
                    total_progress_percent,
                    remarks,
                    status,
                    created_by
                )
                VALUES
                (
                    @report_no,
                    @report_date,
                    @project_id,
                    @site_id,
                    @zone_id,
                    @engineer_id,
                    @weather,
                    @temperature,
                    @manpower_count,
                    @equipment_count,
                    @total_progress_percent,
                    @remarks,
                    @status,
                    @created_by
                );

                SELECT LAST_INSERT_ID();";

            reportId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter(
                    "@report_no",
                    txtReportNo.Text),

                DBClass.CreateParameter(
                    "@report_date",
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
                    "@engineer_id",
                    cmbEngineer.SelectedValue),

                DBClass.CreateParameter(
                    "@weather",
                    cmbWeather.Text),

                DBClass.CreateParameter(
                    "@temperature",
                    txtTemperature.Text),

                DBClass.CreateParameter(
                    "@manpower_count",
                    txtManpower.Text),

                DBClass.CreateParameter(
                    "@equipment_count",
                    txtEquipmentCount.Text),

                DBClass.CreateParameter(
                    "@total_progress_percent",
                    txtProgress.Text),

                DBClass.CreateParameter(
                    "@remarks",
                    txtRemarks.Text),

                DBClass.CreateParameter(
                    "@status",
                    cmbStatus.Text),

                DBClass.CreateParameter(
                    "@created_by",
                    frmLogin.userId)
                ));
        }
        void SaveActivities()
        {
            foreach (DataGridViewRow row in dgvActivity.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_site_report_activity
                    (
                        report_id,
                        activity_id,
                        activity_name,
                        location,
                        work_description,
                        planned_qty,
                        completed_qty,
                        unit,
                        progress_percent,
                        manpower_used,
                        equipment_used,
                        remarks
                    )
                    VALUES
                    (
                        @report_id,
                        @activityId,
                        @activityName,
                        @location,
                        @description,
                        @planned_qty,
                        @completed_qty,
                        @uom,
                        @progress_percent,
                        @manpower,
                        @equipment,
                        @remarks
                    )",

                DBClass.CreateParameter("@report_id", reportId),
                DBClass.CreateParameter("@activityId", 0),
                DBClass.CreateParameter("@activityName", row.Cells["activity"].Value),
                DBClass.CreateParameter("@location", row.Cells["location"].Value),
                DBClass.CreateParameter("@description", row.Cells["description"].Value),
                DBClass.CreateParameter("@planned_qty", row.Cells["planned_qty"].Value),
                DBClass.CreateParameter("@completed_qty", row.Cells["completed_qty"].Value),
                DBClass.CreateParameter("@uom", row.Cells["unit"].Value),
                DBClass.CreateParameter("@progress_percent", row.Cells["progress"].Value),
                DBClass.CreateParameter("@manpower", row.Cells["manpower"].Value),
                DBClass.CreateParameter("@equipment", row.Cells["equipment"].Value),
                DBClass.CreateParameter("@remarks", row.Cells["remarks"].Value));
            }
        }

        void SaveLabour()
        {
            foreach (DataGridViewRow row in dgvLabour.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_site_report_labour
                    (
                        report_id,
                        trade_name,
                        manpower_count,
                        overtime_hours,
                        remarks
                    )
                    VALUES
                    (
                        @report_id,
                        @trade_name,
                        @count,
                        @ot_hours,
                        @remarks
                    )",

                DBClass.CreateParameter("@report_id", reportId),

                DBClass.CreateParameter(
                    "@trade_name",
                    row.Cells["trade"].Value),

                DBClass.CreateParameter(
                    "@count",
                    row.Cells["count"].Value),

                DBClass.CreateParameter(
                    "@ot_hours",
                    row.Cells["ot"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveEquipment()
        {
            foreach (DataGridViewRow row in dgvEquipment.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_site_report_equipment
                    (
                        report_id,
                        equipment_name,
                        working_hours,
                        idle_hours,
                        breakdown_hours,
                        remarks
                    )
                    VALUES
                    (
                        @report_id,
                        @equipment,
                        @working,
                        @idle,
                        @breakdown,
                        @remarks
                    )",

                DBClass.CreateParameter("@report_id", reportId),
                DBClass.CreateParameter("@equipment", row.Cells["equipment"].Value),
                DBClass.CreateParameter("@working", row.Cells["working"].Value),
                DBClass.CreateParameter("@idle", row.Cells["idle"].Value),
                DBClass.CreateParameter("@breakdown", row.Cells["breakdown"].Value),
                DBClass.CreateParameter("@remarks", row.Cells["remarks"].Value));
            }
        }

        void SaveMaterials()
        {
            foreach (DataGridViewRow row in dgvMaterial.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_site_report_material
                    (
                        report_id,
                        material_name,
                        qty_used,
                        unit,
                        remarks
                    )
                    VALUES
                    (
                        @report_id,
                        @material,
                        @qty,
                        @unit,
                        @remarks
                    )",

                DBClass.CreateParameter("@report_id", reportId),

                DBClass.CreateParameter(
                    "@material",
                    row.Cells["material"].Value),
                DBClass.CreateParameter(
                    "@qty",
                    row.Cells["qty"].Value),

                DBClass.CreateParameter(
                    "@unit",
                    row.Cells["unit"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveDelay()
        {
            foreach (DataGridViewRow row in dgvDelay.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_site_report_delay
                    (
                        report_id,
                        delay_reason,
                        affected_activity,
                        delay_hours,
                        corrective_action
                    )
                    VALUES
                    (
                        @report_id,
                        @reason,
                        @activity,
                        @hours,
                        @action
                    )",

                DBClass.CreateParameter("@report_id", reportId),

                DBClass.CreateParameter(
                    "@reason",
                    row.Cells["reason"].Value),

                DBClass.CreateParameter(
                    "@activity",
                    row.Cells["activity"].Value),

                DBClass.CreateParameter(
                    "@hours",
                    row.Cells["hours"].Value),

                DBClass.CreateParameter(
                    "@action",
                    row.Cells["action"].Value));
            }
        }
        void SaveVisitor()
        {
            // Fixed: iterate dgvVisitor (was dgvDelay) and use correct parameter names
            foreach (DataGridViewRow row in dgvVisitor.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_site_report_visitor
                    (
                        report_id,
                        visitor_name,
                        company_name,
                        purpose,
                        visit_time
                    )
                    VALUES
                    (
                        @report_id,
                        @visitor,
                        @company,
                        @purpose,
                        @time
                    )",

                DBClass.CreateParameter("@report_id", reportId),
                DBClass.CreateParameter("@visitor", row.Cells["visitor"].Value),
                DBClass.CreateParameter("@company", row.Cells["company"].Value),
                DBClass.CreateParameter("@purpose", row.Cells["purpose"].Value),
                DBClass.CreateParameter("@time", row.Cells["time"].Value));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtReportNo.Text = "";
            txtTemperature.Text = "";
            txtRemarks.Text = "";
            dgvActivity.Rows.Clear();
            dgvDelay.Rows.Clear();
            dgvEquipment.Rows.Clear();
            dgvLabour.Rows.Clear();
            dgvMaterial.Rows.Clear();
            dgvVisitor.Rows.Clear();
            NewRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportId == 0) return;

                CalculateSummary();

                string sql = @"
                    UPDATE tbl_daily_site_report
                    SET
                        report_date = @report_date,
                        project_id = @project_id,
                        site_id = @site_id,
                        zone_id = @zone_id,
                        engineer_id = @engineer_id,
                        weather = @weather,
                        temperature = @temperature,
                        manpower_count = @manpower_count,
                        equipment_count = @equipment_count,
                        total_progress_percent = @total_progress_percent,
                        remarks = @remarks,
                        status = @status
                    WHERE report_id = @report_id";

                DBClass.ExecuteNonQuery(sql,
                    DBClass.CreateParameter("@report_date", dtDate.Value.Date),
                    DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@site_id", cmbSite.SelectedValue),
                    DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                    DBClass.CreateParameter("@engineer_id", cmbEngineer.SelectedValue),
                    DBClass.CreateParameter("@weather", cmbWeather.Text),
                    DBClass.CreateParameter("@temperature", txtTemperature.Text),
                    DBClass.CreateParameter("@manpower_count", txtManpower.Text),
                    DBClass.CreateParameter("@equipment_count", txtEquipmentCount.Text),
                    DBClass.CreateParameter("@total_progress_percent", txtProgress.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@report_id", reportId)
                );

                // Delete existing child records
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_activity WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_labour WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_equipment WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_material WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_delay WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_visitor WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));

                // Reinsert current details
                SaveActivities();
                SaveLabour();
                SaveEquipment();
                SaveMaterials();
                SaveDelay();
                SaveVisitor();

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Update Daily Site Report",
                    "Daily Site Report",
                    reportId,
                    "Updated Daily Site Report : " + txtReportNo.Text
                );

                MessageBox.Show("Daily Site Report Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportId == 0) return;

                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to delete this Daily Site Report?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr != DialogResult.Yes) return;

                // Delete child records first
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_activity WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_labour WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_equipment WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_material WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_delay WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report_visitor WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));

                // Delete header
                DBClass.ExecuteNonQuery("DELETE FROM tbl_daily_site_report WHERE report_id = @report_id", DBClass.CreateParameter("@report_id", reportId));

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Delete Daily Site Report",
                    "Daily Site Report",
                    reportId,
                    "Deleted Daily Site Report : " + txtReportNo.Text
                );

                // Reset UI
                reportId = 0;
                NewRecord();

                MessageBox.Show("Daily Site Report Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}