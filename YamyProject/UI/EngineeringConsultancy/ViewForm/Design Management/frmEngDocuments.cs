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
using YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management.Docs;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management
{
    public partial class frmEngDocuments : Form
    {
        public frmEngDocuments()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngDocuments_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DataSource = dt;
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void LoadPhases()
        {
            if (cmbProject.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT phase_id, phase_name FROM tbl_eng_project_phases WHERE project_id=@pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            cmbPhase.DataSource = dt;
            cmbPhase.DisplayMember = "phase_name";
            cmbPhase.ValueMember = "phase_id";
            cmbPhase.SelectedIndex = -1;
        }

        private void LoadDocuments()
        {
            if (cmbProject.SelectedIndex == -1 || cmbPhase.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT document_id, document_name, document_type, version, uploaded_by, upload_date, status
                  FROM tbl_eng_design_documents
                  WHERE project_id=@pid AND phase_id=@ph
                  ORDER BY upload_date DESC",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                DBClass.CreateParameter("@ph", cmbPhase.SelectedValue)
            );

            dgvDocuments.DataSource = dt;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvDocuments);
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            dgvDocuments.DataSource = null;
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDocuments.DataSource = null;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedIndex == -1 || cmbPhase.SelectedIndex == -1)
            {
                MessageBox.Show("Select project and phase first.");
                return;
            }

            frmEngDocumentUpload uploadForm = new frmEngDocumentUpload
            {
                ProjectId = Convert.ToInt32(cmbProject.SelectedValue),
                PhaseId = Convert.ToInt32(cmbPhase.SelectedValue)
            };
            if (uploadForm.ShowDialog() == DialogResult.OK)
                LoadDocuments();
        }

        private void btnRevisions_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;

            int docId = Convert.ToInt32(dgvDocuments.SelectedRows[0].Cells["document_id"].Value);
            frmEngDocumentRevision revForm = new frmEngDocumentRevision { DocumentId = docId };
            revForm.ShowDialog();
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;

            int docId = Convert.ToInt32(dgvDocuments.SelectedRows[0].Cells["document_id"].Value);
            frmEngApprovalWorkflow approvalForm = new frmEngApprovalWorkflow { DocumentId = docId };
            approvalForm.ShowDialog();
            LoadDocuments(); // refresh status
        }

    }
}
