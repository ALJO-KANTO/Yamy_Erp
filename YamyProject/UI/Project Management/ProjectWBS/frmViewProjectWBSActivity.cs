using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.ProjectWBS
{
    public partial class frmViewProjectWBSActivity : Form
    {
        int projectID, TenderId, SiteSetupId;
        public frmViewProjectWBSActivity(int projectID,int TenderId, int SiteSetupId)
        {
            InitializeComponent();
            this.projectID = projectID;
            this.TenderId = TenderId;
            this.SiteSetupId = SiteSetupId;
        }

        private void frmViewProjectWBSActivity_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = @"SELECT 
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
                WHERE s.id = @id";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", SiteSetupId)))
            {
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int pId = reader.GetInt32("project_id");
                    int siteId = reader.GetInt32("site_id");
                    int tenderId = reader.GetInt32("tender_id");
                    string engineer_supervisor = reader.GetString("engineer_supervisor");
                    string projectName = reader.GetString("project_name");
                    string siteName = reader.GetString("site_name");
                    string tenderName = reader.GetString("tender_name");
                    //LoadZones();
                    //LoadParentWBS();
                    //LoadWBSCombo();
                    //LoadDependencyActivity();
                    //LoadWBSGrid();
                    //LoadActivityGrid();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetEntryOnly();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetEntryOnly();
        }
        private void ResetForm()
        {
            //txtSearch.Clear();
            ResetEntryOnly();

            dgvWBS.Rows.Clear();
            //tvWBS.Nodes.Clear();
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

            //nudLevel.Value = 1;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtWBSCode.Focus();
        }
    }
}
