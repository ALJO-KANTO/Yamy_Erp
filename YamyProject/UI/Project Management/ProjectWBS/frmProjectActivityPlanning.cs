using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.ProjectWBS
{
    public partial class frmProjectActivityPlanning : Form
    {
        private int selectedWbsId = 0;

        public frmProjectActivityPlanning()
        {
            InitializeComponent();
        }

        private void frmProjectActivityPlanning_Load(object sender, EventArgs e)
        {
            LoadProjects();
            ResetWBS();
            ResetActivity();
            GenerateNextActivityCode();
        }

        private void GenerateNextActivityCode()
        {
            string newCode = "ACT-001";

            string query = @"SELECT MAX(CAST(SUBSTRING(a.activity_code, 5) AS UNSIGNED)) AS lastCode
            FROM tbl_project_activity_plan a
                    INNER JOIN tbl_project_wbs w ON w.id = a.wbs_id
                    WHERE a.site_setup_id = @site_setup_id
            ";
            if (selectedWbsId > 0)
                query += " AND a.wbs_id = @wbs_id";

            using (var reader = DBClass.ExecuteReader(query,
                    DBClass.CreateParameter("@site_setup_id", GetSiteSetupId()),
                    DBClass.CreateParameter("@wbs_id", selectedWbsId)))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "ACT-" + code.ToString("D3");
                }
            }
            txtActivityCode.Text = newCode;
        }

        private void LoadProjects()
        {
            try
            {
                // CHANGE TABLE/COLUMN names if needed
                string sql = @"SELECT id,name project_name 
                               FROM tbl_projects 
                               ORDER BY name";

                DataTable dt = DBClass.ExecuteDataTable(sql);

                cmbProject.DataSource = dt;
                cmbProject.DisplayMember = "project_name";
                cmbProject.ValueMember = "id";
                cmbProject.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadProjects Error: " + ex.Message);
            }
        }

        private void LoadSiteSetups()
        {
            try
            {
                if (cmbProject.SelectedIndex == -1)
                {
                    cmbSiteSetup.DataSource = null;
                    return;
                }

                int projectId = Convert.ToInt32(cmbProject.SelectedValue);

                string sql = @"
                    SELECT 
                        id,
                        CONCAT('SiteSetup #', id, ' | Site ID: ', site_id, ' | Tender ID: ', tender_id) AS setup_name
                    FROM tbl_projects_site_setup
                    WHERE project_id = @project_id
                    ORDER BY id DESC";

                DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@project_id", projectId));

                cmbSiteSetup.DataSource = dt;
                cmbSiteSetup.DisplayMember = "setup_name";
                cmbSiteSetup.ValueMember = "id";
                cmbSiteSetup.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSiteSetups Error: " + ex.Message);
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!ValidateHeader()) return;

            LoadParentWBS();
            LoadWBSTree();
            LoadResponsibleResources();
            LoadBOQItems();
            LoadDependencyActivities();
            LoadActivitiesGrid();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbProject.Focused) return;

            if (cmbProject.SelectedIndex != -1)
                LoadSiteSetups();
        }

        private void LoadParentWBS()
        {
            try
            {
                int siteSetupId = GetSiteSetupId();

                string sql = @"
                    SELECT 0 AS id, '--- ROOT LEVEL ---' AS name
                    UNION ALL
                    SELECT id, CONCAT(code, ' - ', name) AS name
                    FROM tbl_project_wbs
                    WHERE site_setup_id = @site_setup_id
                    ORDER BY id";

                DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@site_setup_id", siteSetupId));

                cmbParentWBS.DataSource = dt;
                cmbParentWBS.DisplayMember = "name";
                cmbParentWBS.ValueMember = "id";
                cmbParentWBS.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadParentWBS Error: " + ex.Message);
            }
        }

        private void LoadWBSTree()
        {
            try
            {
                tvWBS.Nodes.Clear();

                int siteSetupId = GetSiteSetupId();

                string sql = @"
                    SELECT id, parent_wbs_id, code,  name
                    FROM tbl_project_wbs
                    WHERE site_setup_id = @site_setup_id
                    ORDER BY code";

                DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@site_setup_id", siteSetupId));

                foreach (DataRow row in dt.Select("parent_wbs_id = 0"))
                {
                    TreeNode node = new TreeNode(row["code"] + " - " + row["name"]);
                    node.Tag = row["id"];
                    tvWBS.Nodes.Add(node);
                    AddChildNodes(node, dt);
                }

                tvWBS.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadWBSTree Error: " + ex.Message);
            }
        }

        private void AddChildNodes(TreeNode parentNode, DataTable dt)
        {
            int parentId = Convert.ToInt32(parentNode.Tag);

            foreach (DataRow row in dt.Select("parent_wbs_id = " + parentId))
            {
                TreeNode child = new TreeNode(row["code"] + " - " + row["name"]);
                child.Tag = row["id"];
                parentNode.Nodes.Add(child);
                AddChildNodes(child, dt);
            }
        }

        private void btnSaveWBS_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateHeader()) return;

                if (string.IsNullOrWhiteSpace(txtWbsCode.Text))
                {
                    MessageBox.Show("Enter WBS Code");
                    txtWbsCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtWbsName.Text))
                {
                    MessageBox.Show("Enter WBS Name");
                    txtWbsName.Focus();
                    return;
                }

                int siteSetupId = GetSiteSetupId();
                int projectId = GetProjectId();
                int parentId = Convert.ToInt32(cmbParentWBS.SelectedValue ?? 0);
                int level = GetWbsLevel(parentId);

                string sql = @"
                    INSERT INTO tbl_project_wbs
                    (
                        site_setup_id, project_id, parent_wbs_id, code, name,
                        wbs_level, description, is_active, created_by
                    )
                    VALUES
                    (
                        @site_setup_id, @project_id, @parent_wbs_id, @code, @name,
                        @wbs_level, @description, 1, @created_by
                    )";

                int rows = DBClass.ExecuteNonQuery(sql,
                    DBClass.CreateParameter("@site_setup_id", siteSetupId),
                    DBClass.CreateParameter("@project_id", projectId),
                    DBClass.CreateParameter("@parent_wbs_id", parentId),
                    DBClass.CreateParameter("@code", txtWbsCode.Text.Trim()),
                    DBClass.CreateParameter("@name", txtWbsName.Text.Trim()),
                    DBClass.CreateParameter("@wbs_level", level),
                    DBClass.CreateParameter("@description", txtWbsDescription.Text.Trim()),
                    DBClass.CreateParameter("@created_by", 1) // replace with login user id
                );

                if (rows > 0)
                {
                    MessageBox.Show("WBS saved successfully.");
                    ResetWBS();
                    LoadParentWBS();
                    LoadWBSTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save WBS Error: " + ex.Message);
            }
        }

        private int GetWbsLevel(int parentId)
        {
            if (parentId == 0) return 1;

            string sql = "SELECT IFNULL(wbs_level,1) FROM tbl_project_wbs WHERE id=@id";
            object result = DBClass.ExecuteScalar(sql, DBClass.CreateParameter("@id", parentId));
            int parentLevel = Convert.ToInt32(result);

            return parentLevel + 1;
        }

        private void btnNewWBS_Click(object sender, EventArgs e)
        {
            ResetWBS();
        }

        private void ResetWBS()
        {
            txtWbsCode.Clear();
            txtWbsName.Clear();
            txtWbsDescription.Clear();

            if (cmbParentWBS.Items.Count > 0)
                cmbParentWBS.SelectedValue = 0;
        }

        private void tvWBS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                selectedWbsId = Convert.ToInt32(e.Node.Tag);
                LoadActivitiesGrid();
                LoadDependencyActivities();
            }
        }

        private void LoadResponsibleResources()
        {
            try
            {
                int siteSetupId = GetSiteSetupId();

                string sql = @"
                    SELECT 
                        0 AS resource_id, '--- Select Resource ---' AS resource_name
                    UNION ALL
                    SELECT 
                        pra.resource_id,
                        CONCAT(pra.resource_id,' - ', pr.name) AS resource_name
                    FROM tbl_project_resource_assignment pra INNER JOIN tbl_project_resource pr ON pr.id = pra.resource_id
                    WHERE pra.site_setup_id = @site_setup_id
                    ORDER BY resource_id";

                DataTable dt = DBClass.ExecuteDataTable(sql,
                    DBClass.CreateParameter("@site_setup_id", siteSetupId));

                cmbResponsible.DataSource = dt;
                cmbResponsible.DisplayMember = "resource_name";
                cmbResponsible.ValueMember = "resource_id";
                cmbResponsible.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadResponsibleResources Error: " + ex.Message);
            }
        }

        private void LoadBOQItems()
        {
            try
            {
                if (cmbSiteSetup.SelectedIndex == -1)
                {
                    cmbBOQ.DataSource = null;
                    return;
                }

                int siteSetupId = GetSiteSetupId();

                string sql = @"
                    SELECT 0 AS id, '--- Select BOQ Item ---' AS boq_name
                    UNION ALL
                    SELECT DISTINCT b.id, CONCAT(b.id, ' - ', b.name) AS boq_name
                    FROM tbl_project_tender_details ptd INNER JOIN tbl_items_boq b ON ptd.item_id = b.id
                    WHERE ptd.tender_id = (SELECT tender_id FROM tbl_projects_site_setup WHERE id = @site_setup_id)
                    ORDER BY id;";

                DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@site_setup_id", siteSetupId));

                cmbBOQ.DataSource = dt;
                cmbBOQ.DisplayMember = "boq_name";
                cmbBOQ.ValueMember = "id";
                cmbBOQ.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                // If no BOQ table yet, keep safe
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("boq_name", typeof(string));
                dt.Rows.Add(0, "--- Select BOQ Item ---");

                cmbBOQ.DataSource = dt;
                cmbBOQ.DisplayMember = "boq_name";
                cmbBOQ.ValueMember = "id";
                cmbBOQ.SelectedValue = 0;
            }
        }

        private void LoadDependencyActivities()
        {
            try
            {
                int siteSetupId = GetSiteSetupId();

                string sql = @"
                    SELECT 0 AS id, '--- No Dependency ---' AS activity_name
                    UNION ALL
                    SELECT 
                        id,
                        CONCAT(activity_code, ' - ', activity_name) AS activity_name
                    FROM tbl_project_activity_plan
                    WHERE site_setup_id = @site_setup_id
                    ORDER BY id";

                DataTable dt = DBClass.ExecuteDataTable(sql,
                    DBClass.CreateParameter("@site_setup_id", siteSetupId));

                cmbDependency.DataSource = dt;
                cmbDependency.DisplayMember = "activity_name";
                cmbDependency.ValueMember = "id";
                cmbDependency.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDependencyActivities Error: " + ex.Message);
            }
        }
        int activity_id = 0;
        private void btnSaveActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateHeader()) return;

                if (selectedWbsId == 0)
                {
                    MessageBox.Show("Please select a WBS from tree.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtActivityCode.Text))
                {
                    MessageBox.Show("Enter Activity Code");
                    txtActivityCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtActivityName.Text))
                {
                    MessageBox.Show("Enter Activity Name");
                    txtActivityName.Focus();
                    return;
                }

                decimal plannedQty = 0;
                decimal.TryParse(txtPlannedQty.Text.Trim(), out plannedQty);


                if (activity_id > 0)
                {
                    string sql = @"
                    UPDATE tbl_project_activity_plan SET
                        wbs_id = @wbs_id,
                        activity_code = @activity_code,
                        activity_name = @activity_name,
                        boq_item_id = @boq_item_id,
                        planned_qty = @planned_qty,
                        unit = @unit,
                        start_date = @start_date,
                        end_date = @end_date,
                        dependency_activity_id = @dependency_activity_id,
                        responsible_resource_id = @responsible_resource_id,
                        remarks = @remarks
                    WHERE id = @activity_id";

                    int rows = DBClass.ExecuteNonQuery(sql,
                                DBClass.CreateParameter("@wbs_id", selectedWbsId),
                                DBClass.CreateParameter("@activity_code", txtActivityCode.Text.Trim()),
                                DBClass.CreateParameter("@activity_name", txtActivityName.Text.Trim()),
                                DBClass.CreateParameter("@boq_item_id", Convert.ToInt32(cmbBOQ.SelectedValue ?? 0)),
                                DBClass.CreateParameter("@planned_qty", plannedQty),
                                DBClass.CreateParameter("@unit", txtUnit.Text.Trim()),
                                DBClass.CreateParameter("@start_date", dtpStart.Value.Date),
                                DBClass.CreateParameter("@end_date", dtpEnd.Value.Date),
                                DBClass.CreateParameter("@dependency_activity_id", Convert.ToInt32(cmbDependency.SelectedValue ?? 0)),
                                DBClass.CreateParameter("@responsible_resource_id", Convert.ToInt32(cmbResponsible.SelectedValue ?? 0)),
                                DBClass.CreateParameter("@remarks", txtRemarks.Text.Trim()),
                                DBClass.CreateParameter("@activity_id", activity_id)
                                );

                    if (rows > 0)
                    {
                        activity_id = 0;
                        MessageBox.Show("Activity updated successfully.");
                        ResetActivity();
                        LoadDependencyActivities();
                        LoadActivitiesGrid();
                    }
                }
                else
                {
                    string sql = @"
                    INSERT INTO tbl_project_activity_plan
                    (
                        site_setup_id, project_id, wbs_id,
                        activity_code, activity_name,
                        boq_item_id, planned_qty, unit,
                        start_date, end_date,
                        dependency_activity_id, responsible_resource_id,
                        remarks, status, created_by
                    )
                    VALUES
                    (
                        @site_setup_id, @project_id, @wbs_id,
                        @activity_code, @activity_name,
                        @boq_item_id, @planned_qty, @unit,
                        @start_date, @end_date,
                        @dependency_activity_id, @responsible_resource_id,
                        @remarks, 'Planned', @created_by
                    )";

                    int rows = DBClass.ExecuteNonQuery(sql,
                                DBClass.CreateParameter("@site_setup_id", GetSiteSetupId()),
                                DBClass.CreateParameter("@project_id", GetProjectId()),
                                DBClass.CreateParameter("@wbs_id", selectedWbsId),
                                DBClass.CreateParameter("@activity_code", txtActivityCode.Text.Trim()),
                                DBClass.CreateParameter("@activity_name", txtActivityName.Text.Trim()),
                                DBClass.CreateParameter("@boq_item_id", Convert.ToInt32(cmbBOQ.SelectedValue ?? 0)),
                                DBClass.CreateParameter("@planned_qty", plannedQty),
                                DBClass.CreateParameter("@unit", txtUnit.Text.Trim()),
                                DBClass.CreateParameter("@start_date", dtpStart.Value.Date),
                                DBClass.CreateParameter("@end_date", dtpEnd.Value.Date),
                                DBClass.CreateParameter("@dependency_activity_id", Convert.ToInt32(cmbDependency.SelectedValue ?? 0)),
                                DBClass.CreateParameter("@responsible_resource_id", Convert.ToInt32(cmbResponsible.SelectedValue ?? 0)),
                                DBClass.CreateParameter("@remarks", txtRemarks.Text.Trim()),
                                DBClass.CreateParameter("@activity_id", activity_id),
                                DBClass.CreateParameter("@created_by", 1)
                                );

                    if (rows > 0)
                    {
                        MessageBox.Show("Activity saved successfully.");
                        ResetActivity();
                        LoadDependencyActivities();
                        LoadActivitiesGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Activity Error: " + ex.Message);
            }
        }

        private void LoadActivitiesGrid()
        {
            GenerateNextActivityCode();
            try
            {
                if (cmbSiteSetup.SelectedIndex == -1)
                {
                    dgvActivities.DataSource = null;
                    return;
                }

                string sql = @"
                    SELECT 
                        a.id,
                        w.code `WBS Code`,
                        w.name `WBS Name`,
                        a.activity_code `Activity Code`,
                        a.activity_name `Activity Name`,
                        a.boq_item_id,
                        ib.name `BOQ Item`,
                        a.planned_qty `Planned Qty`,
                        a.unit `Unit`,
                        a.start_date `Start Date`,
                        a.end_date `End Date`,
                        a.status `Status`
                    FROM tbl_project_activity_plan a
                    INNER JOIN tbl_project_wbs w ON w.id = a.wbs_id
                    INNER JOIN tbl_items_boq ib ON ib.id = a.boq_item_id
                    WHERE a.site_setup_id = @site_setup_id";

                if (selectedWbsId > 0)
                    sql += " AND a.wbs_id = @wbs_id";

                sql += " ORDER BY a.id";

                DataTable dt;

                if (selectedWbsId > 0)
                {
                    dt = DBClass.ExecuteDataTable(sql,
                        DBClass.CreateParameter("@site_setup_id", GetSiteSetupId()),
                        DBClass.CreateParameter("@wbs_id", selectedWbsId));
                }
                else
                {
                    dt = DBClass.ExecuteDataTable(sql,
                        DBClass.CreateParameter("@site_setup_id", GetSiteSetupId()));
                }

                dgvActivities.DataSource = dt;
                dgvActivities.Columns["id"].Visible = false;
                dgvActivities.Columns["boq_item_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadActivitiesGrid Error: " + ex.Message);
            }
        }

        private void btnNewActivity_Click(object sender, EventArgs e)
        {
            ResetActivity();
        }

        private void ResetActivity()
        {
            txtActivityCode.Clear();
            txtActivityName.Clear();
            txtPlannedQty.Text = "0";
            txtUnit.Clear();
            txtRemarks.Clear();

            if (cmbBOQ.Items.Count > 0) cmbBOQ.SelectedValue = 0;
            if (cmbDependency.Items.Count > 0) cmbDependency.SelectedValue = 0;
            if (cmbResponsible.Items.Count > 0) cmbResponsible.SelectedValue = 0;

            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
            GenerateNextActivityCode();
        }
        private bool ValidateHeader()
        {
            if (cmbProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Project.");
                cmbProject.Focus();
                return false;
            }

            if (cmbSiteSetup.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Site Setup.");
                cmbSiteSetup.Focus();
                return false;
            }

            return true;
        }

        private int GetProjectId()
        {
            return Convert.ToInt32(cmbProject.SelectedValue);
        }

        private int GetSiteSetupId()
        {
            return Convert.ToInt32(cmbSiteSetup.SelectedValue);
        }

        private void dgvActivities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int activityId = Convert.ToInt32(dgvActivities.Rows[e.RowIndex].Cells["id"].Value);

                string sql = @"
                    Select 
                        site_setup_id, project_id, wbs_id,
                        activity_code, activity_name,
                        boq_item_id, planned_qty, unit,
                        start_date, end_date,
                        dependency_activity_id, responsible_resource_id,
                        remarks, status from tbl_project_activity_plan Where id = @id";

                using (MySqlDataReader reader = DBClass.ExecuteReader(sql, DBClass.CreateParameter("@id", activityId))) {
                    if (reader.Read())
                    {
                        activity_id = activityId;
                        selectedWbsId = Convert.ToInt32(reader["wbs_id"]);
                        txtActivityCode.Text = reader["activity_code"].ToString();
                        txtActivityName.Text = reader["activity_name"].ToString();
                        cmbBOQ.SelectedValue = Convert.ToInt32(reader["boq_item_id"]);
                        txtPlannedQty.Text = reader["planned_qty"].ToString();
                        txtUnit.Text = reader["unit"].ToString();
                        dtpStart.Value = Convert.ToDateTime(reader["start_date"]);
                        dtpEnd.Value = Convert.ToDateTime(reader["end_date"]);
                        cmbDependency.SelectedValue = Convert.ToInt32(reader["dependency_activity_id"]);
                        cmbResponsible.SelectedValue = Convert.ToInt32(reader["responsible_resource_id"]);
                        txtRemarks.Text = reader["remarks"].ToString();
                    }
                }
            }
        }
    }
}
