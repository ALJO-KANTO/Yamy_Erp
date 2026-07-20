using System;
using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectSiteActivityPlan
{
    public partial class frmSiteActivityPlan : Form
    {
        int activityId = 0;

        public frmSiteActivityPlan()
        {
            InitializeComponent();

            Load += frmSiteActivityPlan_Load;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnNew.Click += btnNew_Click;
            btnClear.Click += btnClear_Click;
            dgv.CellClick += dgv_CellClick;
            txtTarget.TextChanged += CalcProgress;
            txtActual.TextChanged += CalcProgress;
        }

        private void frmSiteActivityPlan_Load(object sender, EventArgs e)
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
                "SELECT id, name FROM tbl_projects ORDER BY name");

            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
        }

        void LoadZones()
        {
            cmbZone.DataSource = DBClass.ExecuteDataTable(
                "SELECT zone_id, zone_name FROM tbl_project_zone ORDER BY zone_name");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "zone_id";
        }

        void LoadCombos()
        {
            cmbUnit.Items.AddRange(new object[]
            {
                "Nos","m2","m3","m","Kg","Ton","Lot"
            });

            cmbWeather.Items.AddRange(new object[]
            {
                "Clear","Hot","Cloudy","Rain","Windy","Dust"
            });

            cmbPriority.Items.AddRange(new object[]
            {
                "Low","Medium","High","Critical"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Planned","Running","Delayed","Completed","Cancelled"
            });
        }

        void LoadGrid()
        {
            dgv.DataSource = DBClass.ExecuteDataTable(@"
            SELECT activity_id, activity_date, zone_name, activity_name,
                   supervisor_name, labor_count, target_qty,
                   actual_qty, progress_percent, status
            FROM tbl_project_site_activity_plan
            ORDER BY activity_id DESC");

            dgv.Columns["activity_id"].Visible = false;
        }

        void NewRecord()
        {
            activityId = 0;

            dtActivityDate.Value = DateTime.Today;
            txtActivity.Clear();
            txtSupervisor.Clear();
            txtLabor.Text = "0";
            txtEquipment.Clear();
            txtTarget.Text = "0";
            txtActual.Text = "0";
            txtProgress.Text = "0";
            txtRemarks.Clear();

            cmbUnit.SelectedIndex = 0;
            cmbWeather.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 1;
            cmbStatus.Text = "Planned";
        }

        void CalcProgress(object sender, EventArgs e)
        {
            try
            {
                decimal target = Convert.ToDecimal(txtTarget.Text);
                decimal actual = Convert.ToDecimal(txtActual.Text);

                if (target <= 0)
                {
                    txtProgress.Text = "0";
                    return;
                }

                decimal progress = (actual / target) * 100;
                txtProgress.Text = Math.Round(progress, 2).ToString();
            }
            catch
            {
                txtProgress.Text = "0";
            }
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
            INSERT INTO tbl_project_site_activity_plan
            (
                project_id,activity_date,zone_id,zone_name,
                activity_name,supervisor_name,labor_count,
                equipment_used,target_qty,unit_name,
                actual_qty,progress_percent,weather_status,
                priority_level,status,remarks
            )
            VALUES
            (
                @project_id,@activity_date,@zone_id,@zone_name,
                @activity_name,@supervisor_name,@labor_count,
                @equipment_used,@target_qty,@unit_name,
                @actual_qty,@progress_percent,@weather_status,
                @priority_level,@status,@remarks
            )",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@activity_date", dtActivityDate.Value.Date),
            DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
            DBClass.CreateParameter("@zone_name", cmbZone.Text),
            DBClass.CreateParameter("@activity_name", txtActivity.Text),
            DBClass.CreateParameter("@supervisor_name", txtSupervisor.Text),
            DBClass.CreateParameter("@labor_count", txtLabor.Text),
            DBClass.CreateParameter("@equipment_used", txtEquipment.Text),
            DBClass.CreateParameter("@target_qty", txtTarget.Text),
            DBClass.CreateParameter("@unit_name", cmbUnit.Text),
            DBClass.CreateParameter("@actual_qty", txtActual.Text),
            DBClass.CreateParameter("@progress_percent", txtProgress.Text),
            DBClass.CreateParameter("@weather_status", cmbWeather.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text));

            MessageBox.Show("Saved Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (activityId == 0) return;

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_site_activity_plan SET
                project_id=@project_id,
                activity_date=@activity_date,
                zone_id=@zone_id,
                zone_name=@zone_name,
                activity_name=@activity_name,
                supervisor_name=@supervisor_name,
                labor_count=@labor_count,
                equipment_used=@equipment_used,
                target_qty=@target_qty,
                unit_name=@unit_name,
                actual_qty=@actual_qty,
                progress_percent=@progress_percent,
                weather_status=@weather_status,
                priority_level=@priority_level,
                status=@status,
                remarks=@remarks
            WHERE activity_id=@activity_id",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@activity_date", dtActivityDate.Value.Date),
            DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
            DBClass.CreateParameter("@zone_name", cmbZone.Text),
            DBClass.CreateParameter("@activity_name", txtActivity.Text),
            DBClass.CreateParameter("@supervisor_name", txtSupervisor.Text),
            DBClass.CreateParameter("@labor_count", txtLabor.Text),
            DBClass.CreateParameter("@equipment_used", txtEquipment.Text),
            DBClass.CreateParameter("@target_qty", txtTarget.Text),
            DBClass.CreateParameter("@unit_name", cmbUnit.Text),
            DBClass.CreateParameter("@actual_qty", txtActual.Text),
            DBClass.CreateParameter("@progress_percent", txtProgress.Text),
            DBClass.CreateParameter("@weather_status", cmbWeather.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text),
            DBClass.CreateParameter("@activity_id", activityId));

            MessageBox.Show("Updated Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (activityId == 0) return;

            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_project_site_activity_plan WHERE activity_id=@id",
                DBClass.CreateParameter("@id", activityId));

            MessageBox.Show("Deleted Successfully");
            LoadGrid();
            NewRecord();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            activityId = Convert.ToInt32(
                dgv.Rows[e.RowIndex].Cells["activity_id"].Value);
        }
    }
}