using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmProjectTeamSupervisor : Form
    {
        int teamId = 0;

        public frmProjectTeamSupervisor(int _id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.teamId = _id;
        }
        private void frmProjectTeamSupervisor_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadRoles();
            LoadZones();
            LoadGrid();
            ClearFields();
        }

        void LoadProjects()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
        }

        void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Project Manager");
            cmbRole.Items.Add("Site Engineer");
            cmbRole.Items.Add("Civil Engineer");
            cmbRole.Items.Add("Supervisor");
            cmbRole.Items.Add("Foreman");
            cmbRole.Items.Add("Safety Officer");
            cmbRole.Items.Add("QA/QC Engineer");
            cmbRole.Items.Add("Planning Engineer");
            cmbRole.Items.Add("Quantity Surveyor");
            cmbRole.Items.Add("Store Keeper");
            cmbRole.Items.Add("Accountant");
        }

        void LoadZones()
        {
            cmbZone.DataSource = DBClass.ExecuteDataTable("SELECT id, zone_name FROM tbl_project_zone ORDER BY zone_name");
            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";
        }

        void LoadGrid()
        {
            string sql = @"
                    SELECT 
                        t.team_id,
                        p.name `project_name`,
                        t.emp_code,
                        t.emp_name,
                        t.role_name,
                        z.zone_name,
                        t.mobile,
                        t.join_date
                    FROM tbl_project_team t
                    INNER JOIN tbl_projects p ON p.id = t.project_id
                    LEFT JOIN tbl_project_zone z ON z.id = t.zone_id
                    ORDER BY t.team_id DESC";

            dgvTeam.DataSource = DBClass.ExecuteDataTable(sql);

            dgvTeam.Columns["team_id"].Visible = false;
        }

        // ===============================
        // SAVE
        // ===============================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProject.Text == "" || txtEmpName.Text == "")
            {
                MessageBox.Show("Enter required fields");
                return;
            }

            string sql = @"
            INSERT INTO tbl_project_team
            (
                project_id,
                emp_code,
                emp_name,
                role_name,
                zone_id,
                mobile,
                join_date
            )
            VALUES
            (
                @project_id,
                @emp_code,
                @emp_name,
                @role_name,
                @zone_id,
                @mobile,
                @join_date
            )";

            DBClass.ExecuteNonQuery(sql,
                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                DBClass.CreateParameter("@emp_code", txtEmpCode.Text),
                DBClass.CreateParameter("@emp_name", txtEmpName.Text),
                DBClass.CreateParameter("@role_name", cmbRole.Text),
                DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                DBClass.CreateParameter("@mobile", txtMobile.Text),
                DBClass.CreateParameter("@join_date", dtpJoinDate.Value.Date));

            MessageBox.Show("Saved Successfully");

            LoadGrid();
            ClearFields();
        }

        // ===============================
        // UPDATE
        // ===============================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (teamId == 0) return;

            string sql = @"
            UPDATE tbl_project_team SET
                project_id=@project_id,
                emp_code=@emp_code,
                emp_name=@emp_name,
                role_name=@role_name,
                zone_id=@zone_id,
                mobile=@mobile,
                join_date=@join_date
            WHERE team_id=@team_id";

            DBClass.ExecuteNonQuery(sql,
                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                DBClass.CreateParameter("@emp_code", txtEmpCode.Text),
                DBClass.CreateParameter("@emp_name", txtEmpName.Text),
                DBClass.CreateParameter("@role_name", cmbRole.Text),
                DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                DBClass.CreateParameter("@mobile", txtMobile.Text),
                DBClass.CreateParameter("@join_date", dtpJoinDate.Value.Date),
                DBClass.CreateParameter("@team_id", teamId));

            MessageBox.Show("Updated Successfully");

            LoadGrid();
            ClearFields();
        }

        // ===============================
        // DELETE
        // ===============================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (teamId == 0) return;

            if (MessageBox.Show("Delete selected record?",
                "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            DBClass.ExecuteNonQuery(
                "DELETE FROM tbl_project_team WHERE team_id=@team_id",
                DBClass.CreateParameter("@team_id", teamId));

            MessageBox.Show("Deleted Successfully");

            LoadGrid();
            ClearFields();
        }

        // ===============================
        // GRID CLICK
        // ===============================
        private void dgvTeam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTeam.Rows[e.RowIndex];

            teamId = Convert.ToInt32(row.Cells["team_id"].Value);

            cmbProject.Text = row.Cells["project_name"].Value.ToString();
            txtEmpCode.Text = row.Cells["emp_code"].Value.ToString();
            txtEmpName.Text = row.Cells["emp_name"].Value.ToString();
            cmbRole.Text = row.Cells["role_name"].Value.ToString();
            cmbZone.Text = row.Cells["zone_name"].Value.ToString();
            txtMobile.Text = row.Cells["mobile"].Value.ToString();
            dtpJoinDate.Value = Convert.ToDateTime(row.Cells["join_date"].Value);
        }

        // ===============================
        // CLEAR
        // ===============================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        void ClearFields()
        {
            teamId = 0;

            txtEmpCode.Clear();
            txtEmpName.Clear();
            txtMobile.Clear();

            cmbRole.SelectedIndex = -1;
            cmbZone.SelectedIndex = -1;

            dtpJoinDate.Value = DateTime.Today;

            txtEmpCode.Focus();
        }

        // ===============================
        // AUTO LOAD PROJECT INFO
        // ===============================
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProject.SelectedValue == null) return;

                DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT code, customer, location
                FROM tbl_projects
                WHERE id=@id",

                DBClass.CreateParameter("@id", cmbProject.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    txtProjectCode.Text = dt.Rows[0]["code"].ToString();
                    txtClient.Text = dt.Rows[0]["customer"].ToString();
                    txtLocation.Text = dt.Rows[0]["location"].ToString();
                }
            }
            catch
            {
            }
        }
    }
}