using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;

namespace YamyProject.UI.Project_Management.ProjectWBS
{
    public partial class frmProjectWBS : Form
    {
        int id;
        private DataTable dtWBS = new DataTable();
        public frmProjectWBS(int id = 0)
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
            this.id = id;
        }

        private void frmProjectWBS_Load(object sender, EventArgs e)
        {
            try
            {
                SetupGrid();
                BindCombos.PopulateProjects(cmbProject);

                ResetForm();

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on form load: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupGrid()
        {
            dgvWBS.AutoGenerateColumns = false;

            // Optional nice settings
            dgvWBS.EnableHeadersVisualStyles = false;
            dgvWBS.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvWBS.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvWBS.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvWBS.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvWBS.RowTemplate.Height = 28;
        }
        private void LoadParentWBS()
        {
            try
            {
                if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
                {
                    cmbParentWBS.DataSource = null;
                    return;
                }

                int projectId = Convert.ToInt32(cmbProject.SelectedValue);
                int currentId = GetCurrentID();

                string query = @"
                    SELECT id, CONCAT(code, ' - ', name) AS display_name, wbs_level
                    FROM tbl_project_wbs
                    WHERE project_id = @project_id
                      AND is_active = 1
                      AND id <> @current_id
                    ORDER BY code";

                //query = @"
                //        SELECT pt.id, bo.name AS display_name,pt.sr wbs_level
                //        FROM tbl_project_tender_details pt INNER JOIN tbl_items_boq bo ON bo.id = pt.item_id INNER JOIN tbl_project_tender p ON p.id = pt.tender_id WHERE p.project_id = @project_id
                //        ";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@project_id", projectId), DBClass.CreateParameter("@current_id", currentId));

                // Add Root option
                DataRow dr = dt.NewRow();
                dr["id"] = 0;
                dr["display_name"] = "Root / Top Level";
                dr["wbs_level"] = 0;
                dt.Rows.InsertAt(dr, 0);

                cmbParentWBS.DataSource = dt;
                cmbParentWBS.DisplayMember = "display_name";
                cmbParentWBS.ValueMember = "id";
                cmbParentWBS.SelectedIndex = 0;

                SetLevelFromParent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading parent WBS: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadWBSGrid(string searchText = "")
        {
            try
            {
                if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
                {
                    dgvWBS.Rows.Clear();
                    return;
                }

                int projectId = Convert.ToInt32(cmbProject.SelectedValue);

                string query = @"
                    SELECT 
                        w.id,
                        w.project_id,
                        w.parent_wbs_id,
                        w.code,
                        w.name,
                        IFNULL(CONCAT(p.code, ' - ', p.name), 'Root / Top Level') AS parent_name,
                        w.wbs_level,
                        w.description,
                        w.is_active
                    FROM tbl_project_wbs w
                    LEFT JOIN tbl_project_wbs p ON w.parent_wbs_id = p.id
                    WHERE w.project_id = @project_id
                ";

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @" AND (
                                    w.code LIKE @search
                                    OR w.name LIKE @search
                                    OR w.description LIKE @search
                                    OR IFNULL(p.name, '') LIKE @search
                                )";
                }

                query += " ORDER BY w.code";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                parameters.Add(DBClass.CreateParameter("@project_id", projectId));




                if (!string.IsNullOrWhiteSpace(searchText))
                    parameters.Add(DBClass.CreateParameter("@search", "%" + searchText.Trim() + "%"));

                DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());

                dtWBS = dt;

                dgvWBS.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvWBS.Rows.Add(
                        row["id"],
                        row["project_id"],
                        row["parent_wbs_id"],
                        row["code"].ToString(),
                        row["name"].ToString(),
                        row["parent_name"].ToString(),
                        row["wbs_level"],
                        row["description"].ToString(),
                        Convert.ToBoolean(row["is_active"])
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading WBS grid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadWBSTree()
        {
            try
            {
                tvWBS.Nodes.Clear();

                if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
                    return;

                int projectId = Convert.ToInt32(cmbProject.SelectedValue);

                string query = @"
                    SELECT id, parent_wbs_id, code, name, wbs_level, is_active
                    FROM tbl_project_wbs
                    WHERE project_id = @project_id
                    ORDER BY code";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@project_id", projectId));

                // Root nodes
                var rootRows = dt.AsEnumerable()
                                 .Where(r => Convert.ToInt32(r["parent_wbs_id"]) == 0)
                                 .OrderBy(r => r["code"].ToString());

                foreach (DataRow row in rootRows)
                {
                    TreeNode node = CreateTreeNode(row);
                    tvWBS.Nodes.Add(node);
                    AddChildNodes(node, dt);
                }

                tvWBS.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading WBS tree: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddChildNodes(TreeNode parentNode, DataTable dt)
        {
            int parentId = Convert.ToInt32(parentNode.Tag);

            var childRows = dt.AsEnumerable()
                              .Where(r => Convert.ToInt32(r["parent_wbs_id"]) == parentId)
                              .OrderBy(r => r["code"].ToString());

            foreach (DataRow row in childRows)
            {
                TreeNode childNode = CreateTreeNode(row);
                parentNode.Nodes.Add(childNode);
                AddChildNodes(childNode, dt);
            }
        }

        private TreeNode CreateTreeNode(DataRow row)
        {
            string text = row["code"].ToString() + " - " + row["name"].ToString();
            TreeNode node = new TreeNode(text);
            node.Tag = Convert.ToInt32(row["id"]);

            bool isActive = Convert.ToBoolean(row["is_active"]);
            if (!isActive)
            {
                node.ForeColor = Color.Gray;
            }

            return node;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a project first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadParentWBS();
            LoadWBSGrid();
            LoadWBSTree();
            ResetEntryOnly();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a project first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadWBSGrid(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
            {
                ResetForm();
                return;
            }

            LoadParentWBS();
            LoadWBSGrid(txtSearch.Text.Trim());
            LoadWBSTree();
            ResetEntryOnly();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                int projectId = Convert.ToInt32(cmbProject.SelectedValue);
                int parentId = Convert.ToInt32(cmbParentWBS.SelectedValue);
                int level = Convert.ToInt32(nudLevel.Value);

                if (IsDuplicateCode(projectId, txtWBSCode.Text.Trim(), 0))
                {
                    MessageBox.Show("WBS Code already exists for this project.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWBSCode.Focus();
                    return;
                }

                string query = @"
                    INSERT INTO tbl_project_wbs
                    (
                        project_id,
                        parent_wbs_id,
                        code,
                        name,
                        wbs_level,
                        description,
                        is_active,
                        created_by
                    )
                    VALUES
                    (
                        @project_id,
                        @parent_wbs_id,
                        @code,
                        @name,
                        @wbs_level,
                        @description,
                        @is_active,
                        @created_by
                    )";

                DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@project_id", projectId),
                DBClass.CreateParameter("@parent_wbs_id", parentId),
                DBClass.CreateParameter("@code", txtWBSCode.Text.Trim()),
                DBClass.CreateParameter("@name", txtWBSName.Text.Trim()),
                DBClass.CreateParameter("@wbs_level", level),
                DBClass.CreateParameter("@description", txtDescription.Text.Trim()),
                DBClass.CreateParameter("@is_active", chkIsActive.Checked ? 1 : 0),
                DBClass.CreateParameter("@created_by", 1));

                MessageBox.Show("WBS saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadParentWBS();
                LoadWBSGrid(txtSearch.Text.Trim());
                LoadWBSTree();
                ResetEntryOnly();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving WBS: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetCurrentID();
                if (id == 0)
                {
                    MessageBox.Show("Please select a WBS record first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateForm())
                    return;

                int projectId = Convert.ToInt32(cmbProject.SelectedValue);
                int parentId = Convert.ToInt32(cmbParentWBS.SelectedValue);
                int level = Convert.ToInt32(nudLevel.Value);

                // Prevent self parent
                if (parentId == id)
                {
                    MessageBox.Show("A WBS item cannot be its own parent.", "Invalid Parent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Prevent circular parent
                if (IsDescendant(parentId, id))
                {
                    MessageBox.Show("Invalid parent selection. Cannot assign a child as parent.", "Hierarchy Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IsDuplicateCode(projectId, txtWBSCode.Text.Trim(), id))
                {
                    MessageBox.Show("WBS Code already exists for this project.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWBSCode.Focus();
                    return;
                }

                string query = @"
                    UPDATE tbl_project_wbs
                    SET
                        project_id = @project_id,
                        parent_wbs_id = @parent_wbs_id,
                        code = @code,
                        name = @name,
                        wbs_level = @wbs_level,
                        description = @description,
                        is_active = @is_active
                    WHERE id = @id";

                DBClass.ExecuteNonQuery(query, DBClass.CreateParameter("@project_id", projectId),
                    DBClass.CreateParameter("@parent_wbs_id", parentId),
                    DBClass.CreateParameter("@code", txtWBSCode.Text.Trim()),
                    DBClass.CreateParameter("@name", txtWBSName.Text.Trim()),
                    DBClass.CreateParameter("@wbs_level", level),
                    DBClass.CreateParameter("@description", txtDescription.Text.Trim()),
                    DBClass.CreateParameter("@is_active", chkIsActive.Checked ? 1 : 0),
                    DBClass.CreateParameter("@id", id));

                // Update children levels recursively if parent changed or level changed
                UpdateChildrenLevels(id);

                MessageBox.Show("WBS updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadParentWBS();
                LoadWBSGrid(txtSearch.Text.Trim());
                LoadWBSTree();
                ResetEntryOnly();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating WBS: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetEntryOnly();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetCurrentID();
                if (id == 0)
                {
                    MessageBox.Show("Please select a WBS record first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (HasChildren(id))
                {
                    MessageBox.Show("Cannot delete this WBS because it has child WBS items.\nDelete child items first.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to delete this WBS?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                string query = "DELETE FROM tbl_project_wbs WHERE id = @id";

                DBClass.ExecuteNonQuery(query, DBClass.CreateParameter("@id", id));

                MessageBox.Show("WBS deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadParentWBS();
                LoadWBSGrid(txtSearch.Text.Trim());
                LoadWBSTree();
                ResetEntryOnly();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting WBS: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetEntryOnly();
        }

        private void cmbParentWBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLevelFromParent();
        }
        private void SetLevelFromParent()
        {
            try
            {
                if (cmbParentWBS.DataSource == null)
                {
                    nudLevel.Value = 1;
                    return;
                }

                if (cmbParentWBS.SelectedValue == null)
                {
                    nudLevel.Value = 1;
                    return;
                }

                int parentId = Convert.ToInt32(cmbParentWBS.SelectedValue);

                if (parentId == 0)
                {
                    nudLevel.Value = 1;
                    return;
                }

                string query = "SELECT wbs_level FROM tbl_project_wbs WHERE id = @id LIMIT 1";

                object result = DBClass.ExecuteScalar(query, DBClass.CreateParameter("@id", parentId));

                if (result != null)
                {
                    int parentLevel = Convert.ToInt32(result);
                    nudLevel.Value = parentLevel + 1;
                }
                else
                {
                    nudLevel.Value = 1;
                }
            }
            catch
            {
                nudLevel.Value = 1;
            }
        }

        private void tvWBS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node == null || e.Node.Tag == null)
                    return;

                int id = Convert.ToInt32(e.Node.Tag);
                LoadRecordByID(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting tree item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWBS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                int id = Convert.ToInt32(dgvWBS.Rows[e.RowIndex].Cells["colID"].Value);
                LoadRecordByID(id);

                // Select same node in tree
                SelectTreeNodeById(tvWBS.Nodes, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting grid row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRecordByID(int id)
        {
            try
            {
                string query = @"
                    SELECT id, project_id, parent_wbs_id, code, name, wbs_level, description, is_active
                    FROM tbl_project_wbs
                    WHERE id = @id
                    LIMIT 1";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@id", id));

                if (dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];

                txtID.Text = row["id"].ToString();

                // ensure project is selected
                if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) != Convert.ToInt32(row["project_id"]))
                {
                    cmbProject.SelectedValue = Convert.ToInt32(row["project_id"]);
                }

                // reload parents excluding current id
                LoadParentWBS();

                txtWBSCode.Text = row["code"].ToString();
                txtWBSName.Text = row["name"].ToString();
                txtDescription.Text = row["description"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(row["is_active"]);

                int parentId = Convert.ToInt32(row["parent_wbs_id"]);
                cmbParentWBS.SelectedValue = parentId;

                nudLevel.Value = Convert.ToDecimal(row["wbs_level"]);

                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbProject.SelectedValue == null) return;
            if (Convert.ToInt32(cmbProject.SelectedValue) == 0) return;

            LoadWBSGrid(txtSearch.Text.Trim());
        }
        private bool ValidateForm()
        {
            if (cmbProject.SelectedValue == null || Convert.ToInt32(cmbProject.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a project.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProject.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtWBSCode.Text))
            {
                MessageBox.Show("Please enter WBS Code.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWBSCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtWBSName.Text))
            {
                MessageBox.Show("Please enter WBS Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWBSName.Focus();
                return false;
            }

            return true;
        }
        private bool IsDuplicateCode(int projectId, string code, int excludeId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM tbl_project_wbs
                    WHERE project_id = @project_id
                      AND code = @code
                      AND id <> @exclude_id";

                object obj = DBClass.ExecuteScalar(query,
                    DBClass.CreateParameter("@project_id", projectId),
                    DBClass.CreateParameter("@code", code),
                    DBClass.CreateParameter("@exclude_id", excludeId));

                if (obj != null)
                {
                    int count = Convert.ToInt32(obj);

                    return count > 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private bool HasChildren(int id)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tbl_project_wbs WHERE parent_wbs_id = @id";

                object obj = DBClass.ExecuteScalar(query, DBClass.CreateParameter("@id", id));
                if (obj != null)
                {
                    int count = Convert.ToInt32(obj);

                    return count > 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private bool IsDescendant(int selectedParentId, int currentId)
        {
            if (selectedParentId == 0) return false;

            int tempParent = selectedParentId;

            while (tempParent != 0)
            {
                if (tempParent == currentId)
                    return true;

                tempParent = GetParentId(tempParent);
            }

            return false;
        }
        private int GetParentId(int id)
        {
            try
            {
                string query = "SELECT parent_wbs_id FROM tbl_project_wbs WHERE id = @id LIMIT 1";

                object result = DBClass.ExecuteScalar(query, DBClass.CreateParameter("@id", id));

                if (result != null && result != null)
                    return Convert.ToInt32(result);

            }
            catch
            {
                //
            }

            return 0;
        }
        private void UpdateChildrenLevels(int parentId)
        {
            try
            {
                int parentLevel = GetWBSLevel(parentId);

                string query = "SELECT id FROM tbl_project_wbs WHERE parent_wbs_id = @parent_id";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@parent_id", parentId));


                foreach (DataRow row in dt.Rows)
                {
                    int childId = Convert.ToInt32(row["id"]);
                    int childLevel = parentLevel + 1;

                    DBClass.ExecuteNonQuery("UPDATE tbl_project_wbs SET wbs_level = @lvl WHERE id = @id",
                        DBClass.CreateParameter("@lvl", childLevel),
                        DBClass.CreateParameter("@id", childId));


                    // recursive
                    UpdateChildrenLevels(childId);
                }
            }
            catch
            {
                //
            }
        }
        private int GetWBSLevel(int id)
        {
            try
            {
                string query = "SELECT wbs_level FROM tbl_project_wbs WHERE id = @id LIMIT 1";

                object result = DBClass.ExecuteScalar(query);

                if (result != null)
                    return Convert.ToInt32(result);
            }
            catch
            {
                //
            }

            return 1;
        }

        private int GetCurrentID()
        {
            int id = 0;
            int.TryParse(txtID.Text.Trim(), out id);
            return id;
        }

        private void ResetForm()
        {
            txtSearch.Clear();
            ResetEntryOnly();

            dgvWBS.Rows.Clear();
            tvWBS.Nodes.Clear();
        }

        private void ResetEntryOnly()
        {
            txtID.Text = "0";
            txtWBSCode.Clear();
            txtWBSName.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = true;

            if (cmbParentWBS.DataSource != null)
                cmbParentWBS.SelectedValue = 0;

            nudLevel.Value = 1;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtWBSCode.Focus();
        }

        private void SelectTreeNodeById(TreeNodeCollection nodes, int id)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null && Convert.ToInt32(node.Tag) == id)
                {
                    tvWBS.SelectedNode = node;
                    node.EnsureVisible();
                    return;
                }

                SelectTreeNodeById(node.Nodes, id);
            }
        }
    }
}
