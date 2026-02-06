using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Common
{
    public partial class frmEngLookups : Form
    {
        public frmEngLookups()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngLookups_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.AddRange(new object[]
            {
                "PROJECT_STATUS",
                "PHASE_STATUS",
                "MILESTONE_STATUS",
                "DELIVERABLE_STATUS",
                "DOCUMENT_TYPE",
                "REVISION_REASON",
                "APPROVAL_STATUS",
                "TIMESHEET_ACTIVITY",
                "RESOURCE_ROLE",
                "COST_TYPE",
                "REVENUE_METHOD"
            });

            cmbCategory.SelectedIndex = 0;
            LoadLookupData();
        }

        private void LoadLookupData()
        {
            if (cmbCategory.SelectedIndex == -1) return;

            dgvLookups.DataSource = DBClass.ExecuteDataTable(
                @"SELECT lookup_id, lookup_code, lookup_value, is_active, sort_order
                  FROM tbl_eng_lookups
                  WHERE lookup_category=@cat
                  ORDER BY sort_order, lookup_value",
                DBClass.CreateParameter("@cat", cmbCategory.Text)
            );
            LocalizationManager.LocalizeDataGridViewHeaders(dgvLookups);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLookupData();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text)) return;

            if (selectedId>0)
            {
                // Edit 
                DBClass.ExecuteNonQuery(
                    @"Update tbl_eng_lookups "
                    );

                MessageBox.Show("Edited");
            }
            else
            {
                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_eng_lookups
                      (lookup_category, lookup_code, lookup_value, is_active, sort_order)
                      VALUES (@cat,@code,@val,@active,@sort)",
                    DBClass.CreateParameter("@cat", cmbCategory.Text),
                    DBClass.CreateParameter("@code", txtCode.Text),
                    DBClass.CreateParameter("@val", txtValue.Text),
                    DBClass.CreateParameter("@active", chkActive.Checked ? 1 : 0),
                    DBClass.CreateParameter("@sort", numSortOrder.Value)
                );

                MessageBox.Show("Saved");
            }

            LoadLookupData();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLookups.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvLookups.CurrentRow.Cells["lookup_id"].Value);

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_eng_lookups SET is_active=0 WHERE lookup_id=@id",
                DBClass.CreateParameter("@id", id)
            );

            LoadLookupData();
        }
        int selectedId=0;
        private void dgvLookups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedId = Convert.ToInt32(dgvLookups.Rows[e.RowIndex].Cells["lookup_id"].Value.ToString());
            txtCode.Text = dgvLookups.Rows[e.RowIndex].Cells["lookup_code"].Value.ToString();
            txtValue.Text = dgvLookups.Rows[e.RowIndex].Cells["lookup_value"].Value.ToString();
            chkActive.Checked = Convert.ToBoolean(dgvLookups.Rows[e.RowIndex].Cells["is_active"].Value);
            numSortOrder.Value = Convert.ToDecimal(dgvLookups.Rows[e.RowIndex].Cells["sort_order"].Value);
        }
        private void ClearForm()
        {
            txtCode.Clear();
            txtValue.Clear();
            chkActive.Checked = true;
            numSortOrder.Value = 0;
            selectedId = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

/*
 * 
 * PROJECT MANAGEMENT
 * INSERT INTO tbl_eng_lookups (lookup_category, lookup_code, lookup_value, sort_order) VALUES
('PROJECT_STATUS','PLN','Planned',1),
('PROJECT_STATUS','ACT','Active',2),
('PROJECT_STATUS','HLD','On Hold',3),
('PROJECT_STATUS','CMP','Completed',4),
('PROJECT_STATUS','CNL','Cancelled',5);

INSERT INTO tbl_eng_lookups VALUES
(NULL,'PHASE_STATUS','NS','Not Started',1,1,NOW()),
(NULL,'PHASE_STATUS','IP','In Progress',2,1,NOW()),
(NULL,'PHASE_STATUS','RV','Under Review',3,1,NOW()),
(NULL,'PHASE_STATUS','CM','Completed',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'MILESTONE_STATUS','PND','Pending',1,1,NOW()),
(NULL,'MILESTONE_STATUS','IP','In Progress',2,1,NOW()),
(NULL,'MILESTONE_STATUS','CMP','Completed',3,1,NOW()),
(NULL,'MILESTONE_STATUS','DL','Delayed',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'DELIVERABLE_STATUS','DRF','Draft',1,1,NOW()),
(NULL,'DELIVERABLE_STATUS','SUB','Submitted',2,1,NOW()),
(NULL,'DELIVERABLE_STATUS','APR','Approved',3,1,NOW()),
(NULL,'DELIVERABLE_STATUS','RJT','Rejected',4,1,NOW()),
(NULL,'DELIVERABLE_STATUS','CMP','Completed',5,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'DELIVERABLE_STATUS','DRF','Draft',1,1,NOW()),
(NULL,'DELIVERABLE_STATUS','SUB','Submitted',2,1,NOW()),
(NULL,'DELIVERABLE_STATUS','APR','Approved',3,1,NOW()),
(NULL,'DELIVERABLE_STATUS','RJT','Rejected',4,1,NOW()),
(NULL,'DELIVERABLE_STATUS','CMP','Completed',5,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'DOCUMENT_TYPE','DWG','Drawing',1,1,NOW()),
(NULL,'DOCUMENT_TYPE','CAL','Calculation',2,1,NOW()),
(NULL,'DOCUMENT_TYPE','SPC','Specification',3,1,NOW()),
(NULL,'DOCUMENT_TYPE','RPT','Report',4,1,NOW()),
(NULL,'DOCUMENT_TYPE','MOD','Model',5,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'REVISION_REASON','CL','Client Comment',1,1,NOW()),
(NULL,'REVISION_REASON','DC','Design Change',2,1,NOW()),
(NULL,'REVISION_REASON','ER','Error Correction',3,1,NOW()),
(NULL,'REVISION_REASON','RV','Review Update',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'APPROVAL_STATUS','PND','Pending',1,1,NOW()),
(NULL,'APPROVAL_STATUS','APR','Approved',2,1,NOW()),
(NULL,'APPROVAL_STATUS','RJT','Rejected',3,1,NOW()),
(NULL,'APPROVAL_STATUS','RVI','Revision Required',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'TIMESHEET_ACTIVITY','DES','Design',1,1,NOW()),
(NULL,'TIMESHEET_ACTIVITY','REV','Review',2,1,NOW()),
(NULL,'TIMESHEET_ACTIVITY','MTG','Meeting',3,1,NOW()),
(NULL,'TIMESHEET_ACTIVITY','SITE','Site Visit',4,1,NOW()),
(NULL,'TIMESHEET_ACTIVITY','ADM','Administration',5,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'RESOURCE_ROLE','ENG','Engineer',1,1,NOW()),
(NULL,'RESOURCE_ROLE','SEN','Senior Engineer',2,1,NOW()),
(NULL,'RESOURCE_ROLE','PM','Project Manager',3,1,NOW()),
(NULL,'RESOURCE_ROLE','QA','QA/QC',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'COST_TYPE','LAB','Labor Cost',1,1,NOW()),
(NULL,'COST_TYPE','MAT','Material Cost',2,1,NOW()),
(NULL,'COST_TYPE','SUB','Subcontract',3,1,NOW()),
(NULL,'COST_TYPE','OVH','Overhead',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'REVENUE_METHOD','POC','Percentage of Completion',1,1,NOW()),
(NULL,'REVENUE_METHOD','MS','Milestone Based',2,1,NOW()),
(NULL,'REVENUE_METHOD','FIX','Fixed Fee',3,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'CLIENT_TYPE','GOV','Government',1,1,NOW()),
(NULL,'CLIENT_TYPE','PRV','Private',2,1,NOW()),
(NULL,'CLIENT_TYPE','INT','International',3,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'CONTRACT_STATUS','DRF','Draft',1,1,NOW()),
(NULL,'CONTRACT_STATUS','SGN','Signed',2,1,NOW()),
(NULL,'CONTRACT_STATUS','ACT','Active',3,1,NOW()),
(NULL,'CONTRACT_STATUS','CLS','Closed',4,1,NOW());

INSERT INTO tbl_eng_lookups VALUES
(NULL,'KPI_TYPE','PRJ','Project KPI',1,1,NOW()),
(NULL,'KPI_TYPE','ENG','Engineer KPI',2,1,NOW()),
(NULL,'KPI_TYPE','FIN','Financial KPI',3,1,NOW());

 * 
 */