using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectEngineerTreeReport : Form
    {
        public frmProjectEngineerTreeReport()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            AppTheme.DefaultFont(dgvReport);
        }

        private void frmProjectEngineerTreeReport_Load(object sender, EventArgs e)
        {
            LoadProjectsTree();
            LoadAllReportData();
        }

        #region Load Tree

        private void LoadProjectsTree()
        {
            try
            {
                treeViewProjects.Nodes.Clear();

                TreeNode rootNode = new TreeNode(LocalizationManager.GetString("Projects"));
                rootNode.Name = "ROOT";
                treeViewProjects.Nodes.Add(rootNode);

                string query = @"
                    SELECT 
                        p.id AS project_id,
                        p.Code AS project_code,
                        p.Name AS project_name,
                        e.id AS engineer_id,
                        e.name AS engineer_name
                    FROM tbl_projects p
                    LEFT JOIN tbl_projects_engineers pe ON p.id = pe.project_id
                    LEFT JOIN tbl_engineers e ON e.id = pe.engineer_id
                    ORDER BY p.id, e.name;";

                // Replace with your actual method
                DataTable dt = DBClass.ExecuteDataTable(query);

                Dictionary<int, TreeNode> projectNodes = new Dictionary<int, TreeNode>();

                foreach (DataRow row in dt.Rows)
                {
                    int projectId = Convert.ToInt32(row["project_id"]);
                    string projectCode = row["project_code"].ToString();
                    string projectName = row["project_name"].ToString();
                    string engineerName = row["engineer_name"] == null ? "" : row["engineer_name"].ToString();

                    if (!projectNodes.ContainsKey(projectId))
                    {
                        TreeNode projectNode = new TreeNode(projectCode + " - " + projectName);
                        projectNode.Tag = new NodeTag()
                        {
                            NodeType = "PROJECT",
                            ProjectId = projectId,
                            EngineerId = 0
                        };

                        rootNode.Nodes.Add(projectNode);
                        projectNodes.Add(projectId, projectNode);
                    }

                    if (!string.IsNullOrWhiteSpace(engineerName))
                    {
                        TreeNode engineerNode = new TreeNode("👷 " + engineerName);
                        engineerNode.Tag = new NodeTag()
                        {
                            NodeType = "ENGINEER",
                            ProjectId = projectId,
                            EngineerId = Convert.ToInt32(row["engineer_id"])
                        };

                        projectNodes[projectId].Nodes.Add(engineerNode);
                    }
                    else
                    {
                        if (projectNodes[projectId].Nodes.Count == 0)
                        {
                            TreeNode noEngineerNode = new TreeNode(LocalizationManager.GetString("No Engineer Assigned"));
                            noEngineerNode.ForeColor = System.Drawing.Color.Gray;
                            noEngineerNode.Tag = new NodeTag()
                            {
                                NodeType = "PROJECT",
                                ProjectId = projectId,
                                EngineerId = 0
                            };

                            projectNodes[projectId].Nodes.Add(noEngineerNode);
                        }
                    }
                }

                rootNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tree: " + ex.Message);
            }
        }

        #endregion

        #region Load Grid Data

        private void LoadAllReportData()
        {
            try
            {
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY p.id, e.name) AS SN,
                        p.id,
                        p.Code,
                        p.Name,
                        p.start_date AS `Start Date`,
                        p.end_date AS `End Date`,
                        p.Status,
                        p.Description,
                        e.name AS `Engineer Name`,
                        p.updated_at AS `Updated On`
                    FROM tbl_projects p
                    LEFT JOIN tbl_projects_engineers pe ON p.id = pe.project_id
                    LEFT JOIN tbl_engineers e ON e.id = pe.engineer_id
                    ORDER BY p.id, e.name;";

                DataTable dt = DBClass.ExecuteDataTable(query);
                dgvReport.DataSource = dt;
                FormatGrid();
                lblTitle.Text = LocalizationManager.GetString("All Projects / Engineers");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }

        private void LoadProjectReport(int projectId)
        {
            try
            {
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY p.id, e.name) AS SN,
                        p.id,
                        p.Code,
                        p.Name,
                        p.start_date AS `Start Date`,
                        p.end_date AS `End Date`,
                        p.Status,
                        p.Description,
                        e.name AS `Engineer Name`,
                        p.updated_at AS `Updated On`
                    FROM tbl_projects p
                    LEFT JOIN tbl_projects_engineers pe ON p.id = pe.project_id
                    LEFT JOIN tbl_engineers e ON e.id = pe.engineer_id
                    WHERE p.id = " + projectId + @"
                    ORDER BY p.id, e.name;";

                DataTable dt = DBClass.ExecuteDataTable(query);
                dgvReport.DataSource = dt;
                FormatGrid();

                if (dt.Rows.Count > 0)
                    lblTitle.Text = "Project: " + dt.Rows[0]["Code"].ToString() + " - " + dt.Rows[0]["Name"].ToString();
                else
                    lblTitle.Text = "Project Report";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading project report: " + ex.Message);
            }
        }

        private void LoadProjectEngineerReport(int projectId, int engineerId)
        {
            try
            {
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY p.id, e.name) AS SN,
                        p.id,
                        p.Code,
                        p.Name,
                        p.start_date AS `Start Date`,
                        p.end_date AS `End Date`,
                        p.Status,
                        p.Description,
                        e.name AS `Engineer Name`,
                        p.updated_at AS `Updated On`
                    FROM tbl_projects p
                    INNER JOIN tbl_projects_engineers pe ON p.id = pe.project_id
                    INNER JOIN tbl_engineers e ON e.id = pe.engineer_id
                    WHERE p.id = " + projectId + @" 
                      AND e.id = " + engineerId + @"
                    ORDER BY p.id, e.name;";

                DataTable dt = DBClass.ExecuteDataTable(query);
                dgvReport.DataSource = dt;
                FormatGrid();

                if (dt.Rows.Count > 0)
                    lblTitle.Text = "Project: " + dt.Rows[0]["Code"].ToString() + " - " + dt.Rows[0]["Name"].ToString() + " | Engineer: " + dt.Rows[0]["Engineer Name"].ToString();
                else
                    lblTitle.Text = "Project / Engineer Report";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading engineer report: " + ex.Message);
            }
        }

        #endregion

        #region Grid Format

        private void FormatGrid()
        {
            if (dgvReport.Columns.Count == 0) return;

            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvReport.Columns.Contains("Description"))
                dgvReport.Columns["Description"].FillWeight = 180;

            if (dgvReport.Columns.Contains("SN"))
                dgvReport.Columns["SN"].FillWeight = 40;

            if (dgvReport.Columns.Contains("id"))
                dgvReport.Columns["id"].FillWeight = 50;

            dgvReport.Columns["id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvReport);
            AppTheme.DefaultFont(dgvReport);
        }

        #endregion

        #region Events

        private void treeViewProjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;

            NodeTag tag = e.Node.Tag as NodeTag;
            if (tag == null) return;

            if (tag.NodeType == "PROJECT")
            {
                LoadProjectReport(tag.ProjectId);
            }
            else if (tag.NodeType == "ENGINEER")
            {
                LoadProjectEngineerReport(tag.ProjectId, tag.EngineerId);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProjectsTree();
            LoadAllReportData();
        }

        #endregion
    }

    public class NodeTag
    {
        public string NodeType { get; set; }   // ROOT / PROJECT / ENGINEER
        public int ProjectId { get; set; }
        public int EngineerId { get; set; }
    }
}