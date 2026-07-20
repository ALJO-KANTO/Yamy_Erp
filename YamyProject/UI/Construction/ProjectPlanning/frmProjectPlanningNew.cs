using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectPlanning
{
    public partial class frmProjectPlanningNew : Form
    {
        int planId = 0;
        public frmProjectPlanningNew()
        {
            InitializeComponent();
            Load += frmProjectPlanning_Load;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnNew.Click += btnNew_Click;
            btnClear.Click += btnClear_Click;
            dgv.CellClick += dgv_CellClick;
            dtStart.ValueChanged += DatesChanged;
            dtEnd.ValueChanged += DatesChanged;
        }

        private void frmProjectPlanning_Load(object sender, EventArgs e)
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
            cmbWeeklyOff.Items.AddRange(new object[] { "Friday", "Sunday", "Saturday" });
            cmbPriority.Items.AddRange(new object[] { "Low", "Medium", "High", "Critical" });
            cmbStatus.Items.AddRange(new object[] { "Draft", "Planned", "Running", "Hold", "Completed" });
        }

        void LoadGrid()
        {
            dgv.DataSource = DBClass.ExecuteDataTable(@"
            SELECT plan_id, planning_no, plan_date, start_date, end_date,
                   total_days, planning_engineer, status, progress_percent
            FROM tbl_project_planning_new
            ORDER BY plan_id DESC");

            dgv.Columns["plan_id"].Visible = false;
        }

        void DatesChanged(object sender, EventArgs e)
        {
            txtDays.Text = (dtEnd.Value.Date - dtStart.Value.Date).Days.ToString();
        }

        void NewRecord()
        {
            planId = 0;
            txtPlanNo.Text = "PLAN-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtPlanDate.Value = DateTime.Today;
            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today.AddDays(30);
            txtEngineer.Clear();
            txtHours.Text = "8";
            txtProgress.Text = "0";
            txtMilestone.Clear();
            txtNotes.Clear();
            txtDays.Text = "30";
            cmbWeeklyOff.SelectedIndex = 0;
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
            INSERT INTO tbl_project_planning_new
            (
                project_id,planning_no,plan_date,start_date,end_date,total_days,
                planning_engineer,work_hours,weekly_off,priority_level,
                progress_percent,status,milestone,notes
            )
            VALUES
            (
                @project_id,@planning_no,@plan_date,@start_date,@end_date,@total_days,
                @planning_engineer,@work_hours,@weekly_off,@priority_level,
                @progress_percent,@status,@milestone,@notes
            )",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@planning_no", txtPlanNo.Text),
            DBClass.CreateParameter("@plan_date", dtPlanDate.Value.Date),
            DBClass.CreateParameter("@start_date", dtStart.Value.Date),
            DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
            DBClass.CreateParameter("@total_days", txtDays.Text),
            DBClass.CreateParameter("@planning_engineer", txtEngineer.Text),
            DBClass.CreateParameter("@work_hours", txtHours.Text),
            DBClass.CreateParameter("@weekly_off", cmbWeeklyOff.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@progress_percent", txtProgress.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@milestone", txtMilestone.Text),
            DBClass.CreateParameter("@notes", txtNotes.Text));

            MessageBox.Show("Saved Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (planId == 0) return;

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_planning_new SET
                project_id=@project_id,
                planning_no=@planning_no,
                plan_date=@plan_date,
                start_date=@start_date,
                end_date=@end_date,
                total_days=@total_days,
                planning_engineer=@planning_engineer,
                work_hours=@work_hours,
                weekly_off=@weekly_off,
                priority_level=@priority_level,
                progress_percent=@progress_percent,
                status=@status,
                milestone=@milestone,
                notes=@notes
            WHERE plan_id=@plan_id",

            DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
            DBClass.CreateParameter("@planning_no", txtPlanNo.Text),
            DBClass.CreateParameter("@plan_date", dtPlanDate.Value.Date),
            DBClass.CreateParameter("@start_date", dtStart.Value.Date),
            DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
            DBClass.CreateParameter("@total_days", txtDays.Text),
            DBClass.CreateParameter("@planning_engineer", txtEngineer.Text),
            DBClass.CreateParameter("@work_hours", txtHours.Text),
            DBClass.CreateParameter("@weekly_off", cmbWeeklyOff.Text),
            DBClass.CreateParameter("@priority_level", cmbPriority.Text),
            DBClass.CreateParameter("@progress_percent", txtProgress.Text),
            DBClass.CreateParameter("@status", cmbStatus.Text),
            DBClass.CreateParameter("@milestone", txtMilestone.Text),
            DBClass.CreateParameter("@notes", txtNotes.Text),
            DBClass.CreateParameter("@plan_id", planId));

            MessageBox.Show("Updated Successfully");
            LoadGrid();
            NewRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (planId == 0) return;

            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_project_planning_new WHERE plan_id=@id",
                DBClass.CreateParameter("@id", planId));

            MessageBox.Show("Deleted Successfully");
            LoadGrid();
            NewRecord();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            planId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["plan_id"].Value);
        }
    }
}
