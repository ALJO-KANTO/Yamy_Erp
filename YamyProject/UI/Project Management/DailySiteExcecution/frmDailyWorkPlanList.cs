using System;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmDailyWorkPlanList : Form
    {
        public frmDailyWorkPlanList()
        {
            InitializeComponent();
        }

        private void frmDailyWorkPlanList_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadStatus();
            LoadGrid();

            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;
        }
        void LoadProjects()
        {
            cmbProjectFilter.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_projects");
            cmbProjectFilter.DisplayMember = "name";
            cmbProjectFilter.ValueMember = "id";
        }
        void LoadStatus()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Planned");
            cmbStatusFilter.Items.Add("In Progress");
            cmbStatusFilter.Items.Add("Completed");
            cmbStatusFilter.Items.Add("Approved");
            cmbStatusFilter.Text = "All";
        }
        void LoadGrid()
        {
            dgvWorkPlan.DataSource =
            DBClass.ExecuteDataTable(@"
                    SELECT
                    w.workplan_id,
                    w.workplan_no,
                    w.plan_date,
                    p.name project,
                    s.name site,
                    e.name engineer,
                    w.priority,
                    w.status
                    FROM tbl_daily_work_plan w
                    LEFT JOIN tbl_projects p
                    ON p.id=w.project_id
                    LEFT JOIN tbl_project_sites s
                    ON s.id=w.site_id
                    LEFT JOIN tbl_employee e
                    ON e.id=w.engineer_id
                    ORDER BY w.workplan_id DESC
            ");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"
            SELECT
            w.workplan_id,
            w.workplan_no,
            w.plan_date,
            p.name project,
            s.name site,
            e.name engineer,
            w.priority,
            w.status
            FROM tbl_daily_work_plan w
            LEFT JOIN tbl_projects p
            ON p.id=w.project_id
            LEFT JOIN tbl_project_sites s
            ON s.id=w.site_id
            LEFT JOIN tbl_employee e
            ON e.id=w.engineer_id
            WHERE w.workplan_no LIKE @search
            ";
            dgvWorkPlan.DataSource = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@search", "%" + txtSearch.Text + "%"));
        }
        private void dgvWorkPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvWorkPlan.Rows[e.RowIndex].Cells["workplan_id"].Value);

            frmDailyWorkPlan frm = new frmDailyWorkPlan();
            frm.Show();
            frm.LoadWorkPlan(id);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmDailyWorkPlan frm = new frmDailyWorkPlan();
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWorkPlan.CurrentRow == null)
                return;

            int id =
            Convert.ToInt32(
            dgvWorkPlan.CurrentRow
            .Cells["workplan_id"].Value);

            DBClass.ExecuteNonQuery(@"
            DELETE FROM tbl_daily_work_plan_details
            WHERE workplan_id=@id
            ",

            DBClass.CreateParameter(
                "@id",
                id));

            DBClass.ExecuteNonQuery(@"
                DELETE FROM tbl_daily_work_plan
                WHERE workplan_id=@id
                ",
            DBClass.CreateParameter("@id", id));

            LoadGrid();
        }
    }
}
