using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management.ProjectWBS
{
    public partial class MasterProjectWBSActivity : Form
    {
        private int selectedSiteSetupId = 0;
        public MasterProjectWBSActivity()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }
        private void MaterWBSActivity_Load(object sender, EventArgs e)
        {
            cmbWBSStatus.SelectedIndex = 0;
            cmbActivityStatus.SelectedIndex = 0;

            LoadSiteSetup();
            ClearWBS();
            ClearActivity();
        }

        private string Safe(object value)
        {
            return value == null ? "" : value.ToString().Replace("'", "''");
        }

        private void LoadSiteSetup()
        {
            string q = @"
                SELECT 
                    s.id,
                    CONCAT('Setup #', s.id, ' - Project ', s.project_id, ' / Site ', s.site_id) AS display_name
                FROM tbl_projects_site_setup s
                ORDER BY s.id DESC";

            DataTable dt = DBClass.ExecuteDataTable(q);

            cmbSiteSetup.DataSource = dt;
            cmbSiteSetup.DisplayMember = "display_name";
            cmbSiteSetup.ValueMember = "id";
            cmbSiteSetup.SelectedIndex = -1;
        }

        private void LoadSiteSetupDetails()
        {
            if (cmbSiteSetup.SelectedIndex == -1) return;

            selectedSiteSetupId = cmbSiteSetup.SelectedValue == null ? 0 : Convert.ToInt32(cmbSiteSetup.SelectedValue);

            // ⚠️ Replace project/site/tender master table names if needed
            string q = @"
                SELECT 
                    s.id,
                    s.project_id,
                    s.site_id,
                    s.tender_id,
                    s.engineer_supervisor,
                    IFNULL(p.name, CONCAT('Project ID: ', s.project_id)) AS project_name,
                    IFNULL(st.name, CONCAT('Site ID: ', s.site_id)) AS site_name,
                    IFNULL(t.name, CONCAT('Tender ID: ', s.tender_id)) AS tender_name
                FROM tbl_projects_site_setup s
                LEFT JOIN tbl_projects p ON p.id = s.project_id
                LEFT JOIN tbl_project_sites st ON st.id = s.site_id
                LEFT JOIN tbl_tender_names t ON t.id = s.tender_id
                WHERE s.id = " + selectedSiteSetupId;

            DataTable dt = DBClass.ExecuteDataTable(q);

            if (dt.Rows.Count > 0)
            {
                txtProject.Text = dt.Rows[0]["project_name"].ToString();
                txtSite.Text = dt.Rows[0]["site_name"].ToString();
                txtTender.Text = dt.Rows[0]["tender_name"].ToString();
                txtSupervisor.Text = dt.Rows[0]["engineer_supervisor"].ToString();
            }

            LoadZones();
            LoadParentWBS();
            LoadWBSCombo();
            LoadDependencyActivity();
            LoadWBSGrid();
            LoadActivityGrid();
        }

        private void LoadZones()
        {
            if (selectedSiteSetupId <= 0) return;

            string q = @"
                SELECT id, zone_name
                FROM tbl_project_zone
                WHERE site_setup_id = " + selectedSiteSetupId + @"
                ORDER BY zone_name";

            DataTable dt = DBClass.ExecuteDataTable(q);

            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["zone_name"] = "-- Select Zone --";
            dt.Rows.InsertAt(dr, 0);

            cmbZone.DataSource = dt;
            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";
            cmbZone.SelectedIndex = 0;
        }

        private void LoadParentWBS()
        {
            if (selectedSiteSetupId <= 0) return;

            string q = @"
                SELECT id, CONCAT(wbs_code, ' - ', wbs_name) AS wbs_name
                FROM tbl_project_wbs
                WHERE site_setup_id = " + selectedSiteSetupId + @"
                ORDER BY wbs_code";

            DataTable dt = DBClass.ExecuteDataTable(q);

            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["wbs_name"] = "-- No Parent --";
            dt.Rows.InsertAt(dr, 0);

            cmbParentWBS.DataSource = dt;
            cmbParentWBS.DisplayMember = "wbs_name";
            cmbParentWBS.ValueMember = "id";
            cmbParentWBS.SelectedIndex = 0;
        }

        private void LoadWBSCombo()
        {
            if (selectedSiteSetupId <= 0) return;

            string q = @"
                SELECT id, CONCAT(wbs_code, ' - ', wbs_name) AS wbs_name
                FROM tbl_project_wbs
                WHERE site_setup_id = " + selectedSiteSetupId + @"
                ORDER BY wbs_code";

            DataTable dt = DBClass.ExecuteDataTable(q);

            cmbWBS.DataSource = dt;
            cmbWBS.DisplayMember = "wbs_name";
            cmbWBS.ValueMember = "id";
            cmbWBS.SelectedIndex = -1;
        }

        private void LoadDependencyActivity()
        {
            if (selectedSiteSetupId <= 0) return;

            string q = @"
                SELECT id, CONCAT(activity_code, ' - ', activity_name) AS activity_name
                FROM tbl_project_activity
                WHERE site_setup_id = " + selectedSiteSetupId + @"
                ORDER BY activity_code";

            DataTable dt = DBClass.ExecuteDataTable(q);

            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["activity_name"] = "-- No Dependency --";
            dt.Rows.InsertAt(dr, 0);

            cmbDependencyActivity.DataSource = dt;
            cmbDependencyActivity.DisplayMember = "activity_name";
            cmbDependencyActivity.ValueMember = "id";
            cmbDependencyActivity.SelectedIndex = 0;
        }

        private void LoadWBSGrid()
        {
            if (selectedSiteSetupId <= 0) return;

            string q = @"
                SELECT 
                    w.id,
                    w.wbs_code AS 'WBS Code',
                    w.wbs_name AS 'WBS Name',
                    IFNULL(pw.wbs_name, '') AS 'Parent WBS',
                    w.wbs_level AS 'Level',
                    DATE_FORMAT(w.start_date, '%d-%m-%Y') AS 'Start Date',
                    DATE_FORMAT(w.end_date, '%d-%m-%Y') AS 'End Date',
                    w.responsible_engineer AS 'Engineer',
                    w.status AS 'Status'
                FROM tbl_project_wbs w
                LEFT JOIN tbl_project_wbs pw ON pw.id = w.parent_wbs_id
                WHERE w.site_setup_id = " + selectedSiteSetupId + @"
                ORDER BY w.id DESC";

            dgvWBS.DataSource = DBClass.ExecuteDataTable(q);
            dgvWBS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadActivityGrid()
        {
            if (selectedSiteSetupId <= 0) return;

            string q = @"
                SELECT 
                    a.id,
                    a.activity_code AS 'Activity Code',
                    a.activity_name AS 'Activity Name',
                    w.wbs_name AS 'WBS',
                    DATE_FORMAT(a.start_date, '%d-%m-%Y') AS 'Start Date',
                    DATE_FORMAT(a.end_date, '%d-%m-%Y') AS 'End Date',
                    a.duration_days AS 'Duration',
                    a.planned_qty AS 'Planned Qty',
                    a.unit AS 'Unit',
                    IFNULL(d.activity_name, '') AS 'Dependency',
                    a.status AS 'Status'
                FROM tbl_project_activity a
                INNER JOIN tbl_project_wbs w ON w.id = a.wbs_id
                LEFT JOIN tbl_project_activity d ON d.id = a.dependency_activity_id
                WHERE a.site_setup_id = " + selectedSiteSetupId + @"
                ORDER BY a.id DESC";

            dgvActivity.DataSource = DBClass.ExecuteDataTable(q);
            dgvActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearWBS()
        {
            txtWBSCode.Clear();
            txtWBSName.Clear();
            txtWBSLevel.Text = "1";
            txtWBSEngineer.Clear();
            txtWBSRemarks.Clear();
            dtpWBSStart.Value = DateTime.Today;
            dtpWBSEnd.Value = DateTime.Today;
            if (cmbParentWBS.Items.Count > 0) cmbParentWBS.SelectedIndex = 0;
            cmbWBSStatus.SelectedIndex = 0;
        }

        private void ClearActivity()
        {
            if (cmbWBS.Items.Count > 0) cmbWBS.SelectedIndex = -1;
            txtActivityCode.Clear();
            txtActivityName.Clear();
            txtDuration.Text = "0";
            txtActEngineer.Clear();
            txtPlannedQty.Text = "0";
            txtUnit.Clear();
            txtActivityRemarks.Clear();
            dtpActStart.Value = DateTime.Today;
            dtpActEnd.Value = DateTime.Today;
            if (cmbDependencyActivity.Items.Count > 0) cmbDependencyActivity.SelectedIndex = 0;
            cmbActivityStatus.SelectedIndex = 0;
        }

        private void cmbSiteSetup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbSiteSetup.Focused) return;

            if (cmbSiteSetup.SelectedIndex >= 0)
            {
                LoadSiteSetupDetails();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cmbSiteSetup.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Site Setup.");
                return;
            }

            LoadSiteSetupDetails();
        }

        private void btnNewZone_Click(object sender, EventArgs e)
        {
            if (selectedSiteSetupId <= 0)
            {
                MessageBox.Show("Please select Site Setup first.");
                return;
            }

            string zoneName = Microsoft.VisualBasic.Interaction.InputBox("Enter Zone Name:", "Add Zone", "");
            if (string.IsNullOrWhiteSpace(zoneName))
                return;

            string q = @"
                INSERT INTO tbl_project_zone
                (site_setup_id, zone_code, zone_name, description, status)
                VALUES
                (" + selectedSiteSetupId + ", '', '" + Safe(zoneName) + "', '', 'Active')";

            DBClass.ExecuteNonQuery(q);
            LoadZones();

            MessageBox.Show("Zone added successfully.");
        }

        private void btnSaveWBS_Click(object sender, EventArgs e)
        {
            if (selectedSiteSetupId <= 0)
            {
                MessageBox.Show("Please select Site Setup.");
                return;
            }

            if (cmbZone.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Zone.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWBSCode.Text))
            {
                MessageBox.Show("Enter WBS Code.");
                txtWBSCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWBSName.Text))
            {
                MessageBox.Show("Enter WBS Name.");
                txtWBSName.Focus();
                return;
            }

            int zoneId = Convert.ToInt32(cmbZone.SelectedValue);
            int parentWBSId = cmbParentWBS.SelectedIndex > -1 ? Convert.ToInt32(cmbParentWBS.SelectedValue) : 0;
            int level = 1;

            int.TryParse(txtWBSLevel.Text, out level);
            if (level <= 0) level = 1;

            string q = @"
                INSERT INTO tbl_project_wbs
                (
                    site_setup_id,
                    zone_id,
                    wbs_code,
                    wbs_name,
                    parent_wbs_id,
                    wbs_level,
                    start_date,
                    end_date,
                    responsible_engineer,
                    status,
                    remarks
                )
                VALUES
                (
                    " + selectedSiteSetupId + @",
                    " + zoneId + @",
                    '" + Safe(txtWBSCode.Text) + @"',
                    '" + Safe(txtWBSName.Text) + @"',
                    " + (parentWBSId == 0 ? "NULL" : parentWBSId.ToString()) + @",
                    " + level + @",
                    '" + dtpWBSStart.Value.ToString("yyyy-MM-dd") + @"',
                    '" + dtpWBSEnd.Value.ToString("yyyy-MM-dd") + @"',
                    '" + Safe(txtWBSEngineer.Text) + @"',
                    '" + Safe(cmbWBSStatus.Text) + @"',
                    '" + Safe(txtWBSRemarks.Text) + @"'
                )";

            DBClass.ExecuteNonQuery(q);

            MessageBox.Show("WBS saved successfully.");

            LoadParentWBS();
            LoadWBSCombo();
            LoadWBSGrid();
            ClearWBS();
        }

        private void btnNewWBS_Click(object sender, EventArgs e)
        {
            ClearWBS();
        }

        private void btnSaveActivity_Click(object sender, EventArgs e)
        {
            if (selectedSiteSetupId <= 0)
            {
                MessageBox.Show("Please select Site Setup.");
                return;
            }

            if (cmbZone.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Zone.");
                return;
            }

            if (cmbWBS.SelectedIndex == -1)
            {
                MessageBox.Show("Please select WBS.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtActivityCode.Text))
            {
                MessageBox.Show("Enter Activity Code.");
                txtActivityCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtActivityName.Text))
            {
                MessageBox.Show("Enter Activity Name.");
                txtActivityName.Focus();
                return;
            }

            int zoneId = Convert.ToInt32(cmbZone.SelectedValue);
            int wbsId = Convert.ToInt32(cmbWBS.SelectedValue);
            int dependencyId = cmbDependencyActivity.SelectedIndex > -1 ? Convert.ToInt32(cmbDependencyActivity.SelectedValue) : 0;

            int duration = 0;
            decimal plannedQty = 0;

            int.TryParse(txtDuration.Text, out duration);
            decimal.TryParse(txtPlannedQty.Text, out plannedQty);

            string q = @"
                INSERT INTO tbl_project_activity
                (
                    site_setup_id,
                    zone_id,
                    wbs_id,
                    activity_code,
                    activity_name,
                    activity_type,
                    start_date,
                    end_date,
                    duration_days,
                    dependency_activity_id,
                    responsible_engineer,
                    planned_qty,
                    unit,
                    status,
                    progress_percent,
                    remarks
                )
                VALUES
                (
                    " + selectedSiteSetupId + @",
                    " + zoneId + @",
                    " + wbsId + @",
                    '" + Safe(txtActivityCode.Text) + @"',
                    '" + Safe(txtActivityName.Text) + @"',
                    '',
                    '" + dtpActStart.Value.ToString("yyyy-MM-dd") + @"',
                    '" + dtpActEnd.Value.ToString("yyyy-MM-dd") + @"',
                    " + duration + @",
                    " + (dependencyId == 0 ? "NULL" : dependencyId.ToString()) + @",
                    '" + Safe(txtActEngineer.Text) + @"',
                    " + plannedQty.ToString(System.Globalization.CultureInfo.InvariantCulture) + @",
                    '" + Safe(txtUnit.Text) + @"',
                    '" + Safe(cmbActivityStatus.Text) + @"',
                    0,
                    '" + Safe(txtActivityRemarks.Text) + @"'
                )";

            DBClass.ExecuteNonQuery(q);

            MessageBox.Show("Activity saved successfully.");

            LoadDependencyActivity();
            LoadActivityGrid();
            ClearActivity();
        }

        private void btnNewActivity_Click(object sender, EventArgs e)
        {
            ClearActivity();
        }

    }
}
