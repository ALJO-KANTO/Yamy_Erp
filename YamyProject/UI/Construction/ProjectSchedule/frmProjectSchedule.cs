using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectSchedule
{
    public partial class frmProjectSchedule : Form
    {
        int scheduleId = 0;
        public frmProjectSchedule()
        {
            InitializeComponent();

            Load += frmProjectSchedule_Load;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnNew.Click += btnNew_Click;
            btnClear.Click += btnClear_Click;
            dgv.CellClick += dgv_CellClick;
            txtDuration.TextChanged += DurationChanged;
            dtStart.ValueChanged += DurationChanged;
        }

        private void frmProjectSchedule_Load(object sender, EventArgs e)
        {
            LoadProjects();
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

        void LoadCombos()
        {
            cmbPriority.Items.AddRange(new object[] { "Low", "Medium", "High", "Critical" });
            cmbStatus.Items.AddRange(new object[] { "Planned", "Running", "Hold", "Completed", "Cancelled" });
        }

        void LoadGrid()
        {
            dgv.DataSource = DBClass.ExecuteDataTable(@"
            SELECT schedule_id, activity_code, activity_name,
                   start_date, end_date, duration_days,
                   progress_percent, status
            FROM tbl_project_schedule
            ORDER BY schedule_id DESC");

            dgv.Columns["schedule_id"].Visible = false;
        }

        void DurationChanged(object sender, EventArgs e)
        {
            int d;
            if (int.TryParse(txtDuration.Text, out d))
                dtEnd.Value = dtStart.Value.AddDays(d);
        }

        void NewRecord()
        {
            scheduleId = 0;
            txtCode.Text = "ACT-" + DateTime.Now.ToString("HHmmss");
            txtName.Clear();
            txtWBS.Clear();
            txtPred.Clear();
            txtDuration.Text = "1";
            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today.AddDays(1);
            txtProgress.Text = "0";
            txtResp.Clear();
            txtResource.Clear();
            txtRemarks.Clear();
            cmbPriority.SelectedIndex = 1;
            cmbStatus.Text = "Planned";
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
            INSERT INTO tbl_project_schedule
            (
                project_id,activity_code,activity_name,wbs_code,predecessor,
                duration_days,start_date,end_date,progress_percent,
                responsible_person,resource_required,priority_level,status,remarks
            )
            VALUES
            (
                @project_id,@activity_code,@activity_name,@wbs_code,@predecessor,
                @duration_days,@start_date,@end_date,@progress_percent,
                @responsible_person,@resource_required,@priority_level,@status,@remarks
            )",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@activity_code", txtCode.Text),
            DBClass.CreateParameter("@activity_name", txtName.Text),
            DBClass.CreateParameter("@wbs_code", txtWBS.Text),
            DBClass.CreateParameter("@predecessor", txtPred.Text),
            DBClass.CreateParameter("@duration_days", txtDuration.Text),
            DBClass.CreateParameter("@start_date", dtStart.Value.Date),
            DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
            DBClass.CreateParameter("@progress_percent", txtProgress.Text),
            DBClass.CreateParameter("@responsible_person", txtResp.Text),
            DBClass.CreateParameter("@resource_required", txtResource.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text));

            MessageBox.Show("Saved Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (scheduleId == 0) return;

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_schedule SET
                project_id=@project_id,
                activity_code=@activity_code,
                activity_name=@activity_name,
                wbs_code=@wbs_code,
                predecessor=@predecessor,
                duration_days=@duration_days,
                start_date=@start_date,
                end_date=@end_date,
                progress_percent=@progress_percent,
                responsible_person=@responsible_person,
                resource_required=@resource_required,
                priority_level=@priority_level,
                status=@status,
                remarks=@remarks
            WHERE schedule_id=@schedule_id",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@activity_code", txtCode.Text),
            DBClass.CreateParameter("@activity_name", txtName.Text),
            DBClass.CreateParameter("@wbs_code", txtWBS.Text),
            DBClass.CreateParameter("@predecessor", txtPred.Text),
            DBClass.CreateParameter("@duration_days", txtDuration.Text),
            DBClass.CreateParameter("@start_date", dtStart.Value.Date),
            DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
            DBClass.CreateParameter("@progress_percent", txtProgress.Text),
            DBClass.CreateParameter("@responsible_person", txtResp.Text),
            DBClass.CreateParameter("@resource_required", txtResource.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@remarks", txtRemarks.Text),
            DBClass.CreateParameter("@schedule_id", scheduleId));

            MessageBox.Show("Updated Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (scheduleId == 0) return;

            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_project_schedule WHERE schedule_id=@id",
                DBClass.CreateParameter("@id", scheduleId));

            MessageBox.Show("Deleted Successfully");
            LoadGrid();
            NewRecord();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            scheduleId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["schedule_id"].Value);
        }
    }
}