using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmProjectClassification : Form
    {
        private int id;

        public frmProjectClassification( int id=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);

            this.id = id;

            headerUC1.FormText = this.Text;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameEn.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Name En First");
                return;
            }

            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_project_Classification where name_en = @nameEn",
            DBClass.CreateParameter("nameEn", txtNameEn.Text.Trim())))
                if (reader.Read())
                {
                    if (id == 0 || (id != int.Parse(reader["id"].ToString())))
                    {
                        MessageBox.Show(" Name Already In Use. Enter Another Name.");
                        return;
                    }
                }

            if (id == 0)
            {
                DBClass.ExecuteNonQuery(@"INSERT INTO tbl_project_Classification (name_ar,name_en) VALUES (@nameAr, @nameEn);",
                            DBClass.CreateParameter("@nameAr", txtNameAr.Text.Trim()),
                            DBClass.CreateParameter("@nameEn", txtNameEn.Text.Trim()));
                Utilities.LogAudit(frmLogin.userId, "Add Project Classification", "Project Classification", id, "Added Project Classification: " + txtNameEn.Text.Trim());
            }
            else
            {
                DBClass.ExecuteNonQuery(@"UPDATE tbl_project_Classification SET name_ar = @nameAr,name_en = @nameEn WHERE id = @id;",
                        DBClass.CreateParameter("@nameEn", txtNameEn.Text.Trim()),
                        DBClass.CreateParameter("@nameAr", txtNameAr.Text.Trim()),
                        DBClass.CreateParameter("@id", id));
                Utilities.LogAudit(frmLogin.userId, "Update Project Classification", "Project Classification", id, "Updated Project Classification: " + txtNameEn.Text.Trim());
            }

            EventHub.RefreshProjectClassification();

            this.Close();

        }

        private void frmProjectClassification_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_project_Classification where id = @id",
                      DBClass.CreateParameter("id", id)))
                    if (reader.Read())
                    {
                        txtNameEn.Text = reader["name_en"].ToString();
                        txtNameAr.Text = reader["name_ar"].ToString();
                    }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Restore down
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Maximize
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panel6_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
