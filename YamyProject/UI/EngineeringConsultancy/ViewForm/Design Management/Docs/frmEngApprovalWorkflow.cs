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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management.Docs
{
    public partial class frmEngApprovalWorkflow : Form
    {
        public frmEngApprovalWorkflow()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngApprovalWorkflow_Load(object sender, EventArgs e)
        {
            LoadDocument();
        }

        private void LoadDocument()
        {
            if (DocumentId == 0) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT document_name, status FROM tbl_eng_design_documents WHERE document_id=@docId",
                DBClass.CreateParameter("@docId", DocumentId)
            );

            if (dt.Rows.Count > 0)
            {
                txtDocumentName.Text = dt.Rows[0]["document_name"].ToString();
                string status = dt.Rows[0]["status"].ToString();
                cmbStatus.SelectedItem = status == "Approved" ? "Approved" : status == "Rejected" ? "Rejected" : null;
            }
        }

        private void ApproveOrReject(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                MessageBox.Show("Select a status.");
                return;
            }

            DBClass.ExecuteNonQuery(
                @"UPDATE tbl_eng_design_documents
                  SET status=@status
                  WHERE document_id=@docId",
                DBClass.CreateParameter("@status", newStatus),
                DBClass.CreateParameter("@docId", DocumentId)
            );

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_design_approvals
                    (document_id, approved_by, approval_date, status, remarks)
                  VALUES
                    (@docId, @user, NOW(), @status, @remarks)",
                DBClass.CreateParameter("@docId", DocumentId),
                DBClass.CreateParameter("@user", frmLogin.userId),
                DBClass.CreateParameter("@status", newStatus),
                DBClass.CreateParameter("@remarks", txtRemarks.Text)
            );

            MessageBox.Show("Document " + newStatus + " successfully.");
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveOrReject("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            ApproveOrReject("Rejected");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
