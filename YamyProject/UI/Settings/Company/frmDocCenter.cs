using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using YamyProject.DAL;

namespace YamyProject.UI.Settings.Company
{
    public partial class frmDocCenter : Form
    {
        int selectedDocumentId = 0;
        public frmDocCenter()
        {
            InitializeComponent();
            headerUC1.FormText = "Document Center";
        }
        private void frmDocCenter_Load(object sender, EventArgs e)
        {
            LoadDocuments();
            btnOpen.Enabled = false;
            LoadVouchers();
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            FileInfo file = new FileInfo(openFileDialog1.FileName);

            if(string.IsNullOrEmpty(txtTitle.Text))
                txtTitle.Text = Path.GetFileNameWithoutExtension(file.Name);

            if (string.IsNullOrEmpty(txtKeywords.Text))
                txtKeywords.Text = file.Extension.Replace(".", "");
            if (string.IsNullOrEmpty(txtComments.Text))
                txtComments.Text = "";

            if (selectedDocumentId > 0)
            {
                UpdateDocument(file);
            } else
            {
                SaveDocument(file);
            }
            LoadDocuments();

            btnOpen.Enabled = false;
            BtnUpdate.Enabled = false;
        }

        private void UpdateDocument(FileInfo file)
        {
            if (!string.IsNullOrEmpty(lblFileType.Text))
            {
                byte[] fileBytes = File.ReadAllBytes(file.FullName);
                string sql = @"
                UPDATE tbl_documents
                SET title=@title, description=@description, keywords=@keywords, comments=@comments, file_name=@file_name, file_type=@file_type, file_data=@file_data
                WHERE id=@id";

                DBClass.ExecuteNonQuery(sql,
                    DBClass.CreateParameter("@title", txtTitle.Text),
                    DBClass.CreateParameter("@description", txtDescription.Text),
                    DBClass.CreateParameter("@keywords", txtKeywords.Text),
                    DBClass.CreateParameter("@comments", txtComments.Text),
                    DBClass.CreateParameter("@file_name", file.Name),
                    DBClass.CreateParameter("@file_type", file.Extension),
                    DBClass.CreateParameter("@file_data", fileBytes),
                    DBClass.CreateParameter("@id", selectedDocumentId)
                );
            }
            else
            {
                string sql = @"
                UPDATE tbl_documents
                SET title=@title, description=@description, keywords=@keywords, comments=@comments
                WHERE id=@id";

                DBClass.ExecuteNonQuery(sql,
                    DBClass.CreateParameter("@title", txtTitle.Text),
                    DBClass.CreateParameter("@description", txtDescription.Text),
                    DBClass.CreateParameter("@keywords", txtKeywords.Text),
                    DBClass.CreateParameter("@comments", txtComments.Text),
                    DBClass.CreateParameter("@id", selectedDocumentId)
                );
            }

            MessageBox.Show("Document updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveDocument(FileInfo file)
        {
            byte[] fileBytes = File.ReadAllBytes(file.FullName);

            string sql = @"
                INSERT INTO tbl_documents
                (title, description, keywords, comments, file_name, file_type, file_data)
                VALUES
                (@title, @description, @keywords, @comments, @file_name, @file_type, @file_data)";

            DBClass.ExecuteNonQuery(sql,
                DBClass.CreateParameter("@title", txtTitle.Text),
                DBClass.CreateParameter("@description", txtDescription.Text),
                DBClass.CreateParameter("@keywords", txtKeywords.Text),
                DBClass.CreateParameter("@comments", txtComments.Text),
                DBClass.CreateParameter("@file_name", file.Name),
                DBClass.CreateParameter("@file_type", file.Extension),
                DBClass.CreateParameter("@file_data", fileBytes)
            );

            MessageBox.Show("Document added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadDocuments()
        {
            dgvDocuments.Rows.Clear();
            string sql = @"SELECT id, file_name, title, description, file_type, uploaded_on, comments FROM tbl_documents ORDER BY uploaded_on DESC";
            using (MySqlDataReader reader = DBClass.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    dgvDocuments.Rows.Add(
                        reader["id"],
                        reader["file_name"],
                        reader["title"],
                        reader["description"],
                        reader["file_type"],
                        Convert.ToDateTime(reader["uploaded_on"]).ToString("yyyy-MM-dd HH:mm"),
                        reader["comments"]
                    );
                }
            }
        }
        private void LoadVouchers()
        {
            // This method can be implemented to load vouchers if needed tbl_attachments
            dgvVouchers.Rows.Clear();
            string sql = @"SELECT attachment_id, reference_type, reference_id, file_name, file_type, file_data, uploaded_on FROM tbl_attachments ORDER BY uploaded_on DESC";
            using (MySqlDataReader reader = DBClass.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    //vId, vVoucherType, vrefId, vFileName, vFileType, vAdded
                    dgvVouchers.Rows.Add(
                        reader["attachment_id"],
                        reader["reference_type"],
                        reader["reference_id"],
                        reader["file_name"],
                        reader["file_type"],
                        Convert.ToDateTime(reader["uploaded_on"]).ToString("yyyy-MM-dd HH:mm")
                    );
                }
            }
            if(dgvVouchers.Rows != null && dgvVouchers.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;

            OpenDocument(selectedDocumentId);
        }

        private void OpenDocument(int id)
        {
            string sql = "SELECT file_name, file_data FROM tbl_documents WHERE id=@id";
            DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@id", id));

            if (dt.Rows.Count == 0) return;

            string fileName = dt.Rows[0]["file_name"].ToString();
            byte[] fileData = (byte[])dt.Rows[0]["file_data"];

            string tempPath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllBytes(tempPath, fileData);
            System.Diagnostics.Process.Start(tempPath);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0) return;

            string sql = "DELETE FROM tbl_documents WHERE id=@id";
            DBClass.ExecuteNonQuery(sql, DBClass.CreateParameter("@id", selectedDocumentId));

            LoadDocuments();
        }

        private void dgvDocuments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDocuments.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvDocuments.SelectedRows[0];

            lblFileType.Text = row.Cells["file_name"].Value.ToString();
            txtTitle.Text = row.Cells["title"].Value.ToString();
            txtKeywords.Text = row.Cells["file_type"].Value.ToString();
            txtDescription.Text = row.Cells["description"].Value.ToString();
            txtComments.Text = row.Cells["comments"].Value.ToString();

            selectedDocumentId = Convert.ToInt32(dgvDocuments.Rows[e.RowIndex].Cells["id"].Value);
            //OpenDocument(id);

            btnOpen.Enabled = true;
            BtnUpdate.Enabled = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string sql = @"
                UPDATE tbl_documents
                SET title=@title, description=@description, keywords=@keywords, comments=@comments
                WHERE id=@id";

            DBClass.ExecuteNonQuery(sql,
                DBClass.CreateParameter("@title", txtTitle.Text),
                DBClass.CreateParameter("@description", txtDescription.Text),
                DBClass.CreateParameter("@keywords", txtKeywords.Text),
                DBClass.CreateParameter("@comments", txtComments.Text),
                DBClass.CreateParameter("@id", selectedDocumentId)
            );

            MessageBox.Show("Document updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnUpdate.Enabled = false;
        }
        private void AddViewDocImageColumn()
        {
            if (!dgvVouchers.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvVouchers.Columns.Add(imgColumn);
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvVouchers.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvVouchers.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                int _vId = Convert.ToInt32(dgvVouchers.Rows[e.RowIndex].Cells["vrefId"].Value);
                string type = dgvVouchers.Rows[e.RowIndex].Cells["vVoucherType"].Value.ToString();
                AttachmentManager.OpenAttachmentByType(_vId, type);
            }
        }
    }
}
