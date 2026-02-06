using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management.Docs
{
    public partial class frmEngDocumentRevision : Form
    {
        public frmEngDocumentRevision()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmDocumentRevision_Load(object sender, EventArgs e)
        {
            LoadRevisions();
        }

        private void LoadRevisions()
        {
            if (DocumentId == 0) return;

            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT revision_id, version, change_description, revised_by, revised_date, status
                  FROM tbl_eng_design_revisions
                  WHERE document_id=@docId
                  ORDER BY revised_date DESC",
                DBClass.CreateParameter("@docId", DocumentId)
            );

            dgvRevisions.DataSource = dt;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvRevisions);
        }

        private void btnAddRevision_Click(object sender, EventArgs e)
        {
            if (DocumentId == 0) return;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Revised Document";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string fileName = Path.GetFileName(ofd.FileName);
            string targetFolder = Path.Combine(Application.StartupPath, "DocumentsRevisions", DocumentId.ToString());
            if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);

            string targetPath = Path.Combine(targetFolder, fileName);
            File.Copy(ofd.FileName, targetPath, true);

            string newVersion = Microsoft.VisualBasic.Interaction.InputBox("Enter version number:", "New Revision", "1.1");
            string changeDesc = Microsoft.VisualBasic.Interaction.InputBox("Enter change description:", "New Revision", "");

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_design_revisions
                    (document_id, version, change_description, file_path, revised_by, revised_date, status)
                  VALUES
                    (@docId, @ver, @desc, @path, @user, NOW(), 'Pending')",
                DBClass.CreateParameter("@docId", DocumentId),
                DBClass.CreateParameter("@ver", newVersion),
                DBClass.CreateParameter("@desc", changeDesc),
                DBClass.CreateParameter("@path", targetPath),
                DBClass.CreateParameter("@user", frmLogin.userId)
            );

            LoadRevisions();
            MessageBox.Show("Revision added successfully.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
