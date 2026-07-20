using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmDailySiteWorkEntry : Form
    {
        int entryId = 0;

        public frmDailySiteWorkEntry()
        {
            InitializeComponent();

            Load += Frm_Load;

            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrids();

            if (entryId > 0)
                LoadData();
            else
                NewRecord(); 
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_daily_site_entry where entry_id = @id", DBClass.CreateParameter("id", entryId)))
            {
                if (reader.Read())
                {
                    txtEntryNo.Text = reader["entry_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["entry_date"]);
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSite.SelectedValue = reader["site_id"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    cmbSupervisor.SelectedValue = reader["supervisor_id"];
                    cmbEngineer.SelectedValue = reader["engineer_id"];
                    cmbShift.Text = reader["shift_type"].ToString();
                    cmbWeather.Text = reader["weather"].ToString();
                    txtProgress.Text = reader["overall_progress"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    using (MySqlDataReader readerActivity = DBClass.ExecuteReader("select * from tbl_daily_site_activity where entry_id = @id", DBClass.CreateParameter("id", entryId)))
                    {
                        while (readerActivity.Read())
                        {
                            dgvActivities.Rows.Add(readerActivity["wbs_id"], readerActivity["activity_id"], readerActivity["planned_qty"], readerActivity["actual_qty"], readerActivity["uom"], readerActivity["progress_percent"], readerActivity["status"], readerActivity["remarks"]);
                        }
                    }
                    using (MySqlDataReader readerLabour = DBClass.ExecuteReader("select * from tbl_daily_labour where entry_id=@id", DBClass.CreateParameter("id", entryId)))
                    {
                        while (readerLabour.Read())
                        {
                            dgvLabour.Rows.Add(readerLabour["employee_id"], readerLabour["trade_name"], readerLabour["attendance"], readerLabour["ot_hours"], readerLabour["remarks"]);
                        }
                    }
                    using (MySqlDataReader readerEquipment = DBClass.ExecuteReader("select * from tbl_daily_equipment where entry_id = @id", DBClass.CreateParameter("id", entryId)))
                    {
                        dgvEquipment.Rows.Add(readerEquipment["equipment_id"], readerEquipment["start_hour"], readerEquipment["end_hour"], readerEquipment["working_hours"], readerEquipment["fuel_used"], readerEquipment["remarks"]);
                    }
                    using (MySqlDataReader readerMaterial = DBClass.ExecuteReader("select * from tbl_daily_material where entry_id = @id", DBClass.CreateParameter("id", entryId)))
                    {
                        dgvMaterials.Rows.Add(readerMaterial["item_id"], readerMaterial["qty_used"], readerMaterial["uom"], readerMaterial["remarks"]);
                    }
                    using (MySqlDataReader readerIssue = DBClass.ExecuteReader("select * from tbl_daily_issue where entry_id = @id", DBClass.CreateParameter("id", entryId)))
                    {
                        dgvIssues.Rows.Add(readerIssue["issue_type"], readerIssue["description"], readerIssue["impact_level"], readerIssue["action_taken"]);
                    }
                }
            }
        }

        void LoadCombos()
        {
            cmbProject.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_projects");

            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbSite.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_project_sites");

            cmbSite.DisplayMember = "name";
            cmbSite.ValueMember = "id";

            cmbZone.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,zone_name FROM tbl_project_zone");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbSupervisor.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_employee");

            cmbSupervisor.DisplayMember = "name";
            cmbSupervisor.ValueMember = "id";

            cmbEngineer.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_employee");

            cmbEngineer.DisplayMember = "name";
            cmbEngineer.ValueMember = "id";

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
                "Windy",
                "Hot"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft",
                "Pending",
                "Approved"
            });
        }

        void InitializeGrids()
        {
            // ACTIVITIES

            dgvActivities.Columns.Add("wbs", "WBS");
            dgvActivities.Columns.Add("activity", "Activity");
            dgvActivities.Columns.Add("planned", "Planned Qty");
            dgvActivities.Columns.Add("actual", "Actual Qty");
            dgvActivities.Columns.Add("uom", "UOM");
            dgvActivities.Columns.Add("progress", "Progress %");
            dgvActivities.Columns.Add("status", "Status");
            dgvActivities.Columns.Add("remarks", "Remarks");

            // LABOUR

            dgvLabour.Columns.Add("employee", "Employee");
            dgvLabour.Columns.Add("trade", "Trade");
            dgvLabour.Columns.Add("attendance", "Attendance");
            dgvLabour.Columns.Add("ot", "OT Hours");
            dgvLabour.Columns.Add("remarks", "Remarks");

            // EQUIPMENT

            dgvEquipment.Columns.Add("equipment", "Equipment");
            dgvEquipment.Columns.Add("start", "Start Hour");
            dgvEquipment.Columns.Add("end", "End Hour");
            dgvEquipment.Columns.Add("working", "Working Hours");
            dgvEquipment.Columns.Add("fuel", "Fuel");
            dgvEquipment.Columns.Add("remarks", "Remarks");

            // MATERIALS

            dgvMaterials.Columns.Add("material", "Material");
            dgvMaterials.Columns.Add("qty", "Qty Used");
            dgvMaterials.Columns.Add("uom", "UOM");
            dgvMaterials.Columns.Add("remarks", "Remarks");

            // ISSUES

            dgvIssues.Columns.Add("type", "Issue Type");
            dgvIssues.Columns.Add("description", "Description");
            dgvIssues.Columns.Add("impact", "Impact");
            dgvIssues.Columns.Add("action", "Action Taken");
        }

        void NewRecord()
        {
            entryId = 0;

            txtEntryNo.Text = "DSE-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtDate.Value = DateTime.Today;

            cmbShift.Text = "Day";
            cmbWeather.Text = "Sunny";
            cmbStatus.Text = "Draft";

            txtProgress.Text = "0";

            txtRemarks.Clear();

            dgvActivities.Rows.Clear();
            dgvLabour.Rows.Clear();
            dgvEquipment.Rows.Clear();
            dgvMaterials.Rows.Clear();
            dgvIssues.Rows.Clear();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveHeader();

            SaveActivities();

            SaveLabour();

            SaveEquipment();

            SaveMaterials();

            SaveIssues();

            MessageBox.Show(
                "Daily Site Work Entry Saved Successfully");
        }

        void SaveHeader()
        {
            string sql = @"
            INSERT INTO tbl_daily_site_entry
            (
                entry_no,
                entry_date,
                project_id,
                site_id,
                zone_id,
                supervisor_id,
                engineer_id,
                shift_type,
                weather,
                overall_progress,
                status,
                remarks,
                created_by
            )
            VALUES
            (
                @entry_no,
                @entry_date,
                @project_id,
                @site_id,
                @zone_id,
                @supervisor_id,
                @engineer_id,
                @shift_type,
                @weather,
                @overall_progress,
                @status,
                @remarks,
                @created_by
            );

            SELECT LAST_INSERT_ID();";

            entryId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter(
                    "@entry_no",
                    txtEntryNo.Text),

                DBClass.CreateParameter(
                    "@entry_date",
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
                    "@supervisor_id",
                    cmbSupervisor.SelectedValue),

                DBClass.CreateParameter(
                    "@engineer_id",
                    cmbEngineer.SelectedValue),

                DBClass.CreateParameter(
                    "@shift_type",
                    cmbShift.Text),

                DBClass.CreateParameter(
                    "@weather",
                    cmbWeather.Text),

                DBClass.CreateParameter(
                    "@overall_progress",
                    txtProgress.Text),

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

        void SaveActivities()
        {
            foreach (DataGridViewRow row in dgvActivities.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_daily_site_activity
                (
                    entry_id,
                    planned_qty,
                    actual_qty,
                    uom,
                    progress_percent,
                    status,
                    remarks
                )
                VALUES
                (
                    @entry_id,
                    @planned_qty,
                    @actual_qty,
                    @uom,
                    @progress_percent,
                    @status,
                    @remarks
                )",

                DBClass.CreateParameter("@entry_id", entryId),

                DBClass.CreateParameter(
                    "@planned_qty",
                    row.Cells["planned"].Value),

                DBClass.CreateParameter(
                    "@actual_qty",
                    row.Cells["actual"].Value),

                DBClass.CreateParameter(
                    "@uom",
                    row.Cells["uom"].Value),

                DBClass.CreateParameter(
                    "@progress_percent",
                    row.Cells["progress"].Value),

                DBClass.CreateParameter(
                    "@status",
                    row.Cells["status"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveLabour()
        {
            foreach (DataGridViewRow row in dgvLabour.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_daily_labour
                (
                    entry_id,
                    trade_name,
                    attendance,
                    ot_hours,
                    remarks
                )
                VALUES
                (
                    @entry_id,
                    @trade_name,
                    @attendance,
                    @ot_hours,
                    @remarks
                )",

                DBClass.CreateParameter("@entry_id", entryId),

                DBClass.CreateParameter(
                    "@trade_name",
                    row.Cells["trade"].Value),

                DBClass.CreateParameter(
                    "@attendance",
                    row.Cells["attendance"].Value),

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
                INSERT INTO tbl_daily_equipment
                (
                    entry_id,
                    start_hour,
                    end_hour,
                    working_hours,
                    fuel_used,
                    remarks
                )
                VALUES
                (
                    @entry_id,
                    @start_hour,
                    @end_hour,
                    @working_hours,
                    @fuel_used,
                    @remarks
                )",

                DBClass.CreateParameter("@entry_id", entryId),

                DBClass.CreateParameter(
                    "@start_hour",
                    row.Cells["start"].Value),

                DBClass.CreateParameter(
                    "@end_hour",
                    row.Cells["end"].Value),

                DBClass.CreateParameter(
                    "@working_hours",
                    row.Cells["working"].Value),

                DBClass.CreateParameter(
                    "@fuel_used",
                    row.Cells["fuel"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveMaterials()
        {
            foreach (DataGridViewRow row in dgvMaterials.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_daily_material
                (
                    entry_id,
                    qty_used,
                    uom,
                    remarks
                )
                VALUES
                (
                    @entry_id,
                    @qty_used,
                    @uom,
                    @remarks
                )",

                DBClass.CreateParameter("@entry_id", entryId),

                DBClass.CreateParameter(
                    "@qty_used",
                    row.Cells["qty"].Value),

                DBClass.CreateParameter(
                    "@uom",
                    row.Cells["uom"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveIssues()
        {
            foreach (DataGridViewRow row in dgvIssues.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_daily_issue
                (
                    entry_id,
                    issue_type,
                    description,
                    impact_level,
                    action_taken
                )
                VALUES
                (
                    @entry_id,
                    @issue_type,
                    @description,
                    @impact_level,
                    @action_taken
                )",

                DBClass.CreateParameter("@entry_id", entryId),

                DBClass.CreateParameter(
                    "@issue_type",
                    row.Cells["type"].Value),

                DBClass.CreateParameter(
                    "@description",
                    row.Cells["description"].Value),

                DBClass.CreateParameter(
                    "@impact_level",
                    row.Cells["impact"].Value),

                DBClass.CreateParameter(
                    "@action_taken",
                    row.Cells["action"].Value));
            }
        }
    }
}