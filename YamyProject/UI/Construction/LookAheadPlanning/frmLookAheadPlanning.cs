using System;
using System.Windows.Forms;

namespace YamyProject.UI.Construction.LookAheadPlanning
{
    public partial class frmLookAheadPlanning : Form
    {
        int lookId = 0;

        public frmLookAheadPlanning()
        {
            InitializeComponent();

            Load += frmLookAheadPlanning_Load;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnNew.Click += btnNew_Click;
            btnClear.Click += btnClear_Click;
            dgv.CellClick += dgv_CellClick;
        }

        private void frmLookAheadPlanning_Load(object sender, EventArgs e)
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
                "SELECT zone_name FROM tbl_project_zone ORDER BY zone_name");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "zone_name";
        }

        void LoadCombos()
        {
            cmbPriority.Items.AddRange(new object[]
            {
                "Low","Medium","High","Critical"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Pending","Ready","Running","Hold","Completed"
            });
        }

        void LoadGrid()
        {
            dgv.DataSource = DBClass.ExecuteDataTable(@"
            SELECT look_id, week_no, from_date, to_date,
                   activity_name, zone_name,
                   responsible_person, required_labor,
                   priority_level, status
            FROM tbl_project_lookahead
            ORDER BY look_id DESC");

            dgv.Columns["look_id"].Visible = false;
        }

        void NewRecord()
        {
            lookId = 0;

            txtWeekNo.Text = GetWeekNo().ToString();
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today.AddDays(6);

            txtActivity.Clear();
            txtResponsible.Clear();
            txtMaterial.Clear();
            txtLabor.Text = "0";
            txtEquipment.Clear();
            txtRemarks.Clear();

            cmbPriority.SelectedIndex = 1;
            cmbStatus.Text = "Pending";
        }

        int GetWeekNo()
        {
            return System.Globalization.CultureInfo.CurrentCulture.Calendar
                .GetWeekOfYear(DateTime.Today,
                System.Globalization.CalendarWeekRule.FirstDay,
                DayOfWeek.Sunday);
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
            INSERT INTO tbl_project_lookahead
            (
                project_id,week_no,from_date,to_date,
                activity_name,zone_name,responsible_person,
                required_material,required_labor,required_equipment,
                priority_level,status,remarks
            )
            VALUES
            (
                @project_id,@week_no,@from_date,@to_date,
                @activity_name,@zone_name,@responsible_person,
                @required_material,@required_labor,@required_equipment,
                @priority_level,@status,@remarks
            )",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@week_no", txtWeekNo.Text),
            DBClass.CreateParameter("@from_date", dtFrom.Value.Date),
            DBClass.CreateParameter("@to_date", dtTo.Value.Date),
            DBClass.CreateParameter("@activity_name", txtActivity.Text),
            DBClass.CreateParameter("@zone_name", cmbZone.Text),
            DBClass.CreateParameter("@responsible_person", txtResponsible.Text),
            DBClass.CreateParameter("@required_material", txtMaterial.Text),
            DBClass.CreateParameter("@required_labor", txtLabor.Text),
            DBClass.CreateParameter("@required_equipment", txtEquipment.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text));

            MessageBox.Show("Saved Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lookId == 0) return;

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_lookahead SET
                project_id=@project_id,
                week_no=@week_no,
                from_date=@from_date,
                to_date=@to_date,
                activity_name=@activity_name,
                zone_name=@zone_name,
                responsible_person=@responsible_person,
                required_material=@required_material,
                required_labor=@required_labor,
                required_equipment=@required_equipment,
                priority_level=@priority_level,
                status=@status,
                remarks=@remarks
            WHERE look_id=@look_id",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@week_no", txtWeekNo.Text),
            DBClass.CreateParameter("@from_date", dtFrom.Value.Date),
            DBClass.CreateParameter("@to_date", dtTo.Value.Date),
            DBClass.CreateParameter("@activity_name", txtActivity.Text),
            DBClass.CreateParameter("@zone_name", cmbZone.Text),
            DBClass.CreateParameter("@responsible_person", txtResponsible.Text),
            DBClass.CreateParameter("@required_material", txtMaterial.Text),
            DBClass.CreateParameter("@required_labor", txtLabor.Text),
            DBClass.CreateParameter("@required_equipment", txtEquipment.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text),
            DBClass.CreateParameter("@look_id", lookId));

            MessageBox.Show("Updated Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lookId == 0) return;

            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_project_lookahead WHERE look_id=@id",
                DBClass.CreateParameter("@id", lookId));

            MessageBox.Show("Deleted Successfully");
            LoadGrid();
            NewRecord();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lookId = Convert.ToInt32(
                dgv.Rows[e.RowIndex].Cells["look_id"].Value);
        }
    }
}