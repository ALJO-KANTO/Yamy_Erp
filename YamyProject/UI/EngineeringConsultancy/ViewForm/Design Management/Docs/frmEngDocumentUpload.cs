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
    public partial class frmEngDocumentUpload : Form
    {
        public frmEngDocumentUpload()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmDocumentUpload_Load(object sender, EventArgs e)
        {

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Document";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = ofd.FileName;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDocumentName.Text))
            {
                MessageBox.Show("Document name is required.");
                return;
            }

            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Select document type.");
                return;
            }

            if (string.IsNullOrEmpty(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Select a valid file.");
                return;
            }

            // Save file to server/folder
            string targetFolder = Path.Combine(Application.StartupPath, "Documents", ProjectId.ToString(), PhaseId.ToString());
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            string fileName = Path.GetFileName(txtFilePath.Text);
            string targetPath = Path.Combine(targetFolder, fileName);
            File.Copy(txtFilePath.Text, targetPath, true);

            // Insert record
            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_design_documents
                    (project_id, phase_id, document_name, document_type, version, file_path, uploaded_by, upload_date, status)
                  VALUES
                    (@pid, @ph, @name, @type, @ver, @path, @user, NOW(), 'Pending')",
                DBClass.CreateParameter("@pid", ProjectId),
                DBClass.CreateParameter("@ph", PhaseId),
                DBClass.CreateParameter("@name", txtDocumentName.Text),
                DBClass.CreateParameter("@type", cmbType.SelectedItem.ToString()),
                DBClass.CreateParameter("@ver", txtVersion.Text),
                DBClass.CreateParameter("@path", targetPath),
                DBClass.CreateParameter("@user", frmLogin.userId)
            );

            MessageBox.Show("Document uploaded successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
