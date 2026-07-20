using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmDailyProgressUpdate : Form
    {
        int progressId = 0;

        public frmDailyProgressUpdate()
        {
            InitializeComponent();

            Load += Frm_Load;

            btnSave.Click += BtnSave_Click;

            txtPlanned.TextChanged += CalculateVariance;
            txtActual.TextChanged += CalculateVariance;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrids();

            if (progressId > 0)
                LoadData();
            else
                NewRecord();
        }
        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_daily_progress where progress_id = @id", DBClass.CreateParameter("id", progressId)))
            {
                if (reader.Read())
                {
                    txtProgressNo.Text = reader["progress_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["progress_date"].ToString());
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSite.SelectedValue = reader["site_id"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    cmbPreparedBy.SelectedValue = reader["prepared_by"];
                    cmbApprovedBy.SelectedValue = reader["approved_by"];
                    txtPlanned.Text = reader["planned_progress"].ToString();
                    txtActual.Text = reader["actual_progress"].ToString();
                    txtVariance.Text = reader["variance_progress"].ToString();
                    cmbStatus.Text = reader["overall_status"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    using (MySqlDataReader readerProgressActivity = DBClass.ExecuteReader("select * from from tbl_daily_progress_activity where progress_id = @id", DBClass.CreateParameter("id", progressId)))
                    {
                        while (readerProgressActivity.Read()) {
                            dgvActivities.Rows.Add(
                                //readerProgressActivity["wbs_id INT NULL,
                                //readerProgressActivity["activity_id INT NULL,
                                readerProgressActivity["activity_name"],
                                readerProgressActivity["unit"],
                                readerProgressActivity["planned_qty"],
                                readerProgressActivity["actual_qty"],
                                readerProgressActivity["cumulative_qty"],
                                readerProgressActivity["planned_percent"],
                                readerProgressActivity["actual_percent"],
                                readerProgressActivity["variance_percent"],
                                readerProgressActivity["manpower_count"],
                                readerProgressActivity["equipment_count"],
                                readerProgressActivity["status"],
                                readerProgressActivity["remarks"]
                            );
                        }
                    }
                    using (MySqlDataReader readerDelays = DBClass.ExecuteReader("select * from tbl_daily_progress_delay where progress_id = @id", DBClass.CreateParameter("id", progressId)))
                    {
                        while (readerDelays.Read())
                        {
                            dgvDelays.Rows.Add(readerDelays["delay_type"], readerDelays["delay_reason"], readerDelays["affected_activity"], readerDelays["impact_days"], readerDelays["corrective_action"]);
                        }
                    }
                    using (MySqlDataReader readerDelays = DBClass.ExecuteReader("select * from tbl_daily_progress_photo where progress_id = @id", DBClass.CreateParameter("id", progressId)))
                    {
                        while (readerDelays.Read())
                        {
                            dgvPhotos.Rows.Add(readerDelays["photo_path"], readerDelays["description"]);
                        }
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

            DataTable dtEmp =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_employee");

            cmbPreparedBy.DataSource = dtEmp.Copy();
            cmbPreparedBy.DisplayMember = "name";
            cmbPreparedBy.ValueMember = "id";

            cmbApprovedBy.DataSource = dtEmp;
            cmbApprovedBy.DisplayMember = "name";
            cmbApprovedBy.ValueMember = "id";

            cmbStatus.Items.AddRange(new object[]
            {
                "On Track",
                "Delayed",
                "Critical",
                "Completed"
            });
        }

        void InitializeGrids()
        {
            // ACTIVITIES

            dgvActivities.Columns.Add("activity", "Activity");

            dgvActivities.Columns.Add("unit", "Unit");

            dgvActivities.Columns.Add("planned_qty", "Planned Qty");

            dgvActivities.Columns.Add("actual_qty", "Actual Qty");

            dgvActivities.Columns.Add("cumulative", "Cumulative Qty");

            dgvActivities.Columns.Add("planned_percent", "Planned %");

            dgvActivities.Columns.Add("actual_percent", "Actual %");

            dgvActivities.Columns.Add("variance", "Variance");

            dgvActivities.Columns.Add("manpower", "Manpower");

            dgvActivities.Columns.Add("equipment", "Equipment");

            dgvActivities.Columns.Add("status", "Status");

            dgvActivities.Columns.Add("remarks", "Remarks");

            // DELAYS

            dgvDelays.Columns.Add("delay_type", "Delay Type");

            dgvDelays.Columns.Add("reason", "Reason");

            dgvDelays.Columns.Add("affected", "Affected Activity");

            dgvDelays.Columns.Add("impact", "Impact Days");

            dgvDelays.Columns.Add("action", "Corrective Action");

            // PHOTOS

            dgvPhotos.Columns.Add("photo_path", "Photo Path");

            dgvPhotos.Columns.Add("description", "Description");
        }

        void NewRecord()
        {
            progressId = 0;

            txtProgressNo.Text =
                "DPU-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            txtPlanned.Text = "0";
            txtActual.Text = "0";
            txtVariance.Text = "0";

            cmbStatus.Text = "On Track";

            txtRemarks.Clear();

            dgvActivities.Rows.Clear();
            dgvDelays.Rows.Clear();
            dgvPhotos.Rows.Clear();
        }

        void CalculateVariance(object sender, EventArgs e)
        {
            decimal planned =
                Utilities.ParseDecimalValue(
                    txtPlanned.Text);

            decimal actual =
                Utilities.ParseDecimalValue(
                    txtActual.Text);

            txtVariance.Text =
                (actual - planned).ToString("0.00");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveHeader();

            SaveActivities();

            SaveDelays();

            SavePhotos();

            MessageBox.Show(
                "Daily Progress Update Saved Successfully");
        }

        void SaveHeader()
        {
            string sql = @"
            INSERT INTO tbl_daily_progress
            (
                progress_no,
                progress_date,
                project_id,
                site_id,
                zone_id,
                prepared_by,
                approved_by,
                planned_progress,
                actual_progress,
                variance_progress,
                overall_status,
                remarks,
                created_by
            )
            VALUES
            (
                @progress_no,
                @progress_date,
                @project_id,
                @site_id,
                @zone_id,
                @prepared_by,
                @approved_by,
                @planned_progress,
                @actual_progress,
                @variance_progress,
                @overall_status,
                @remarks,
                @created_by
            );

            SELECT LAST_INSERT_ID();";

            progressId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter(
                    "@progress_no",
                    txtProgressNo.Text),

                DBClass.CreateParameter(
                    "@progress_date",
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
                    "@prepared_by",
                    cmbPreparedBy.SelectedValue),

                DBClass.CreateParameter(
                    "@approved_by",
                    cmbApprovedBy.SelectedValue),

                DBClass.CreateParameter(
                    "@planned_progress",
                    txtPlanned.Text),

                DBClass.CreateParameter(
                    "@actual_progress",
                    txtActual.Text),

                DBClass.CreateParameter(
                    "@variance_progress",
                    txtVariance.Text),

                DBClass.CreateParameter(
                    "@overall_status",
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
                INSERT INTO tbl_daily_progress_activity
                (
                    progress_id,
                    activity_name,
                    unit,
                    planned_qty,
                    actual_qty,
                    cumulative_qty,
                    planned_percent,
                    actual_percent,
                    variance_percent,
                    manpower_count,
                    equipment_count,
                    status,
                    remarks
                )
                VALUES
                (
                    @progress_id,
                    @activity_name,
                    @unit,
                    @planned_qty,
                    @actual_qty,
                    @cumulative_qty,
                    @planned_percent,
                    @actual_percent,
                    @variance_percent,
                    @manpower_count,
                    @equipment_count,
                    @status,
                    @remarks
                )",

                DBClass.CreateParameter("@progress_id", progressId),

                DBClass.CreateParameter("@activity_name",
                    row.Cells["activity"].Value),

                DBClass.CreateParameter("@unit",
                    row.Cells["unit"].Value),

                DBClass.CreateParameter("@planned_qty",
                    row.Cells["planned_qty"].Value),

                DBClass.CreateParameter("@actual_qty",
                    row.Cells["actual_qty"].Value),

                DBClass.CreateParameter("@cumulative_qty",
                    row.Cells["cumulative"].Value),

                DBClass.CreateParameter("@planned_percent",
                    row.Cells["planned_percent"].Value),

                DBClass.CreateParameter("@actual_percent",
                    row.Cells["actual_percent"].Value),

                DBClass.CreateParameter("@variance_percent",
                    row.Cells["variance"].Value),

                DBClass.CreateParameter("@manpower_count",
                    row.Cells["manpower"].Value),

                DBClass.CreateParameter("@equipment_count",
                    row.Cells["equipment"].Value),

                DBClass.CreateParameter("@status",
                    row.Cells["status"].Value),

                DBClass.CreateParameter("@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveDelays()
        {
            foreach (DataGridViewRow row in dgvDelays.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_daily_progress_delay
                (
                    progress_id,
                    delay_type,
                    delay_reason,
                    affected_activity,
                    impact_days,
                    corrective_action
                )
                VALUES
                (
                    @progress_id,
                    @delay_type,
                    @delay_reason,
                    @affected_activity,
                    @impact_days,
                    @corrective_action
                )",

                DBClass.CreateParameter("@progress_id", progressId),

                DBClass.CreateParameter("@delay_type",
                    row.Cells["delay_type"].Value),

                DBClass.CreateParameter("@delay_reason",
                    row.Cells["reason"].Value),

                DBClass.CreateParameter("@affected_activity",
                    row.Cells["affected"].Value),

                DBClass.CreateParameter("@impact_days",
                    row.Cells["impact"].Value),

                DBClass.CreateParameter("@corrective_action",
                    row.Cells["action"].Value));
            }
        }

        void SavePhotos()
        {
            foreach (DataGridViewRow row in dgvPhotos.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_daily_progress_photo
                (
                    progress_id,
                    photo_path,
                    description
                )
                VALUES
                (
                    @progress_id,
                    @photo_path,
                    @description
                )",

                DBClass.CreateParameter("@progress_id", progressId),

                DBClass.CreateParameter("@photo_path",
                    row.Cells["photo_path"].Value),

                DBClass.CreateParameter("@description",
                    row.Cells["description"].Value));
            }
        }
    }
}