using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class ProjectStatusUpdate : Form
    {
        int projectId;
        public ProjectStatusUpdate(int projectId)
        {
            InitializeComponent();
            headerUC1.FormText = "Update Project Status";
            this.projectId = projectId;
            LocalizationManager.LocalizeForm(this);
        }

        private void ProjectStatusUpdate_Load(object sender, EventArgs e)
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT p.code,p.name,p.`status`,p.description,p.start_date,p.end_date FROM tbl_projects p WHERE p.id = @id", DBClass.CreateParameter("@id", projectId)))
            {
                if(reader.Read())
                {
                    txtStatus.Text = reader["Status"].ToString();
                    txtCode.Text = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                    dtStart.Value = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : DateTime.Now;
                    dtEnd.Value = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : DateTime.Now;

                    LoadAttachFile();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (projectId <= 0)
            {
                MessageBox.Show("Invalid project ID.");
                return;
            }

            string updateQuery = "UPDATE tbl_projects SET status = @status, description = @description WHERE id = @id";
            DBClass.ExecuteNonQuery(updateQuery,
                DBClass.CreateParameter("@status", txtStatus.Text),
                DBClass.CreateParameter("@description", txtDescription.Text),
                DBClass.CreateParameter("@id", projectId)
                );

            Utilities.LogAudit(frmLogin.userId, "update Project Status", "Project Status", projectId, "Update Project Status: " + txtStatus.Text);

            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                int pId = Convert.ToInt32(projectId + "00") + frmLogin.userId;
                AddFileData(pId);
            }

            this.Close();
        }
        private void AddFileData(int fId)
        {
            AttachmentManager.SaveAttachment(
                    "PROJECTS",
                    fId,
                    openFileDialog1.FileName
                );
        }
        private void LoadAttachFile()
        {
            string sql = @"SELECT attachment_id, reference_type, reference_id, file_name, file_type, file_data, uploaded_on FROM tbl_attachments where reference_type='PROJECTS' and reference_id = @refId ORDER BY uploaded_on DESC";
            using (MySqlDataReader reader = DBClass.ExecuteReader(sql, DBClass.CreateParameter("@refId", Convert.ToInt32(projectId + "00") + frmLogin.userId)))
            {
                if (reader.Read())
                {
                    guna2ImageButton1.Enabled = true;
                    txtFilePath.Text = reader["file_name"].ToString();
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            int _vId = Convert.ToInt32(projectId + "00") + frmLogin.userId;
            string type = "PROJECTS";
            AttachmentManager.OpenAttachmentByType(_vId, type);
        }
    }
}
