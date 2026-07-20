using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmDailyWorkPlan : Form
    {
        int workPlanId = 0;

        public frmDailyWorkPlan()
        {
            InitializeComponent();
        }

        private void frmDailyWorkPlan_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrid();

            NewRecord();
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



            cmbEngineer.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_employee");

            cmbEngineer.DisplayMember = "name";
            cmbEngineer.ValueMember = "id";



            cmbSupervisor.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_employee");

            cmbSupervisor.DisplayMember = "name";
            cmbSupervisor.ValueMember = "id";



            cmbPriority.Items.Clear();

            cmbPriority.Items.AddRange(new object[]
            {
                "Low",
                "Medium",
                "High",
                "Critical"
            });



            cmbStatus.Items.Clear();

            cmbStatus.Items.AddRange(new object[]
            {
                "Planned",
                "In Progress",
                "Completed",
                "Cancelled",
                "Approved"
            });
        }
        void InitializeGrid()
        {

            dgvActivity.Columns.Clear();



            dgvActivity.Columns.Add(
                "activity",
                "Activity");



            dgvActivity.Columns.Add(
                "location",
                "Location");



            dgvActivity.Columns.Add(
                "planned_qty",
                "Planned Qty");



            dgvActivity.Columns.Add(
                "unit",
                "Unit");



            dgvActivity.Columns.Add(
                "assigned_to",
                "Assigned To");



            dgvActivity.Columns.Add(
                "remarks",
                "Remarks");

        }
        void NewRecord()
        {

            workPlanId = 0;



            txtWorkPlanNo.Text =
                "WP-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");



            dtPlanDate.Value =
                DateTime.Today;



            dtStartTime.Value =
                DateTime.Today.AddHours(8);



            dtEndTime.Value =
                DateTime.Today.AddHours(17);



            cmbPriority.Text =
                "Medium";



            cmbStatus.Text =
                "Planned";



            txtWorkLocation.Clear();

            txtWorkDescription.Clear();

            txtRemarks.Clear();



            dgvActivity.Rows.Clear();

        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            if (workPlanId == 0)
            {
                SaveWorkPlan();
                SaveActivities();

                MessageBox.Show("Saved Successfully.");
            }
            else
            {
                UpdateWorkPlan();
            }
        }
        void LoadActivities()
        {
            dgvActivity.Rows.Clear();

            DataTable dt =
                DBClass.ExecuteDataTable(@"
                SELECT *
                FROM tbl_daily_work_plan_details
                WHERE workplan_id=@id
                ",
                DBClass.CreateParameter("@id", workPlanId));

            foreach (DataRow row in dt.Rows)
            {
                dgvActivity.Rows.Add(
                    row["activity"],
                    row["location"],
                    row["planned_qty"],
                    row["unit"],
                    row["assigned_to"],
                    row["remarks"]
                );
            }
        }
        void SaveWorkPlan()
        {
            string sql = @"
                INSERT INTO tbl_daily_work_plan
                (
                    workplan_no,
                    plan_date,

                    project_id,
                    site_id,
                    zone_id,

                    engineer_id,
                    supervisor_id,

                    work_location,

                    work_description,

                    planned_start_time,
                    planned_end_time,

                    priority,

                    status,

                    remarks,

                    created_by
                )

                VALUES
                (
                    @workplan_no,
                    @plan_date,

                    @project_id,
                    @site_id,
                    @zone_id,

                    @engineer_id,
                    @supervisor_id,

                    @work_location,

                    @work_description,

                    @planned_start_time,
                    @planned_end_time,

                    @priority,

                    @status,

                    @remarks,

                    @created_by
                );

                SELECT LAST_INSERT_ID();
                ";

            workPlanId =
                Convert.ToInt32(

                DBClass.ExecuteScalar(

                sql,

                DBClass.CreateParameter(
                    "@workplan_no",
                    txtWorkPlanNo.Text),

                DBClass.CreateParameter(
                    "@plan_date",
                    dtPlanDate.Value.Date),

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
                    "@supervisor_id",
                    cmbSupervisor.SelectedValue),

                DBClass.CreateParameter(
                    "@work_location",
                    txtWorkLocation.Text),

                DBClass.CreateParameter(
                    "@work_description",
                    txtWorkDescription.Text),

                DBClass.CreateParameter(
                    "@planned_start_time",
                    dtStartTime.Value.TimeOfDay),

                DBClass.CreateParameter(
                    "@planned_end_time",
                    dtEndTime.Value.TimeOfDay),

                DBClass.CreateParameter(
                    "@priority",
                    cmbPriority.Text),

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
            foreach (DataGridViewRow row in dgvActivity.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_daily_work_plan_details
                    (
                        workplan_id,
                        activity,
                        location,
                        planned_qty,
                        unit,
                        assigned_to,
                        remarks
                    )
                    VALUES
                    (
                        @workplan_id,
                        @activity,
                        @location,
                        @planned_qty,
                        @unit,
                        @assigned_to,
                        @remarks
                    )
                    ",

                DBClass.CreateParameter(
                    "@workplan_id",
                    workPlanId),

                DBClass.CreateParameter(
                    "@activity",
                    row.Cells["activity"].Value),

                DBClass.CreateParameter(
                    "@location",
                    row.Cells["location"].Value),

                DBClass.CreateParameter(
                    "@planned_qty",
                    row.Cells["planned_qty"].Value),

                DBClass.CreateParameter(
                    "@unit",
                    row.Cells["unit"].Value),

                DBClass.CreateParameter(
                    "@assigned_to",
                    row.Cells["assigned_to"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value)

                );
            }
        }
        void UpdateWorkPlan()
        {
            try
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_daily_work_plan
                    SET
                    plan_date=@plan_date,
                    project_id=@project_id,
                    site_id=@site_id,
                    zone_id=@zone_id,
                    engineer_id=@engineer_id,
                    supervisor_id=@supervisor_id,
                    work_location=@work_location,
                    work_description=@work_description,
                    planned_start_time=@planned_start_time,
                    planned_end_time=@planned_end_time,
                    priority=@priority,
                    status=@status,
                    remarks=@remarks
                    WHERE workplan_id=@workplan_id
                    ",

                DBClass.CreateParameter(
                    "@plan_date",
                    dtPlanDate.Value.Date),

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
                    "@supervisor_id",
                    cmbSupervisor.SelectedValue),

                DBClass.CreateParameter(
                    "@work_location",
                    txtWorkLocation.Text),

                DBClass.CreateParameter(
                    "@work_description",
                    txtWorkDescription.Text),

                DBClass.CreateParameter(
                    "@planned_start_time",
                    dtStartTime.Value.TimeOfDay),

                DBClass.CreateParameter(
                    "@planned_end_time",
                    dtEndTime.Value.TimeOfDay),

                DBClass.CreateParameter("@priority", cmbPriority.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@workplan_id", workPlanId));

                DBClass.ExecuteNonQuery(@"
                DELETE FROM tbl_daily_work_plan_details
                WHERE workplan_id=@id ",
                DBClass.CreateParameter("@id", workPlanId));

                SaveActivities();

                MessageBox.Show("Updated Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadWorkPlan(int id)
        {
            try
            {
                DataTable dt =
                    DBClass.ExecuteDataTable(@"
                        SELECT *
                        FROM tbl_daily_work_plan
                        WHERE workplan_id=@id",  
                    DBClass.CreateParameter("@id", id));

                if (dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];
                workPlanId =
                    Convert.ToInt32(
                    row["workplan_id"]);
                txtWorkPlanNo.Text =
                    row["workplan_no"].ToString();
                dtPlanDate.Value =
                    Convert.ToDateTime(
                    row["plan_date"]);
                cmbProject.SelectedValue =
                    row["project_id"];
                cmbSite.SelectedValue =
                    row["site_id"];
                cmbZone.SelectedValue =
                    row["zone_id"];
                cmbEngineer.SelectedValue =
                    row["engineer_id"];
                cmbSupervisor.SelectedValue =
                    row["supervisor_id"];
                txtWorkLocation.Text =
                    row["work_location"].ToString();
                txtWorkDescription.Text =
                    row["work_description"].ToString();
                dtStartTime.Value =
                    DateTime.Today.Add(
                    (TimeSpan)row["planned_start_time"]);
                dtEndTime.Value =
                    DateTime.Today.Add(
                    (TimeSpan)row["planned_end_time"]);
                cmbPriority.Text =
                    row["priority"].ToString();
                cmbStatus.Text =
                    row["status"].ToString();
                txtRemarks.Text =
                    row["remarks"].ToString();

                LoadActivities();

                if (cmbStatus.Text == "Approved")
                    LockForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnApprove_Click(object sender, EventArgs e)
        {
            ApproveWorkPlan();
        }
        void ApproveWorkPlan()
        {
            try
            {
                if (workPlanId == 0)
                {
                    MessageBox.Show("Please save the Work Plan first.");
                    return;
                }

                DialogResult dr =
                    MessageBox.Show(
                    "Approve this Work Plan?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;


                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_daily_work_plan
                    SET
                        status='Approved',
                        approved_by=@approved_by
                    WHERE workplan_id=@workplan_id
                    ",

                DBClass.CreateParameter(
                    "@approved_by",
                    frmLogin.userId),

                DBClass.CreateParameter(
                    "@workplan_id",
                    workPlanId));

                cmbStatus.Text = "Approved";

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Approve Daily Work Plan",
                    "Daily Work Plan",
                    workPlanId,
                    "Approved Work Plan : " +
                    txtWorkPlanNo.Text);

                MessageBox.Show(
                    "Approved Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool ValidateData()
        {
            if (cmbProject.SelectedValue == null)
            {
                MessageBox.Show("Please select Project.");
                cmbProject.Focus();

                return false;
            }

            if (txtWorkDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Work Description.");
                txtWorkDescription.Focus();
                return false;
            }

            if (dtEndTime.Value <= dtStartTime.Value)
            {
                MessageBox.Show("End Time must be greater than Start Time.");
                return false;
            }

            return true;
        }
        void LockForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2TextBox)
                    c.Enabled = false;

                if (c is Guna.UI2.WinForms.Guna2ComboBox)
                    c.Enabled = false;

                if (c is DateTimePicker)
                    c.Enabled = false;
            }

            dgvActivity.ReadOnly = true;

            btnSave.Enabled = false;
        }
        void DeleteWorkPlan()
        {
            try
            {
                if (workPlanId == 0)
                    return;

                DialogResult dr =
                    MessageBox.Show(
                    "Delete this Work Plan?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                DBClass.ExecuteNonQuery(@"
                DELETE FROM tbl_daily_work_plan_details
                WHERE workplan_id=@id
                ",

                DBClass.CreateParameter(
                    "@id",
                    workPlanId));



                DBClass.ExecuteNonQuery(@"
                DELETE FROM tbl_daily_work_plan
                WHERE workplan_id=@id
                ",

                DBClass.CreateParameter(
                    "@id",
                    workPlanId));

                MessageBox.Show("Deleted Successfully.");
                NewRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
