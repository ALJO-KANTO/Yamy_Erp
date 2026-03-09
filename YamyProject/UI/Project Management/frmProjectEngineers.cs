using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using PdfSharp.Drawing.BarCodes;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectEngineers : Form
    {
        int engineerId;
        public frmProjectEngineers(int engId)
        {
            InitializeComponent();
            headerUC1.FormText = "Project Engineers";
            LocalizationManager.LocalizeForm(this);
            this.engineerId = engId;
        }

        private void frmProjectEngineers_Load(object sender, EventArgs e)
        {
            if (engineerId <= 0)
            {
                object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(code AS UNSIGNED)), 4, '0') FROM tbl_engineers;");
                int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
                string formattedId = nextId.ToString().PadLeft(3, '0');
                txtCode.Text = formattedId;
            }

            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT code, name, contact_no FROM tbl_engineers WHERE id = @id", DBClass.CreateParameter("@id", engineerId)))
            {
                if(reader.Read())
                {
                    txtPhone.Text = reader["contact_no"].ToString();
                    txtCode.Text = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (engineerId > 0)
            {
                string updateQuery = "UPDATE tbl_engineers SET name = @name, contact_no = @contact_no WHERE id = @id";
                DBClass.ExecuteNonQuery(updateQuery,
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@contact_no", txtPhone.Text),
                    DBClass.CreateParameter("@id", engineerId)
                    );

                Utilities.LogAudit(frmLogin.userId, "update Engineer", "Engineer Edit", engineerId, "Update Engineer : " + txtPhone.Text);
            } 
            else
            {
                string insertQuery = "INSERT INTO tbl_engineers (code, name, contact_no) VALUES (@code, @name, @contact_no)";
                DBClass.ExecuteNonQuery(insertQuery,
                    DBClass.CreateParameter("@code", txtCode.Text),
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@contact_no", txtPhone.Text)
                    );
                Utilities.LogAudit(frmLogin.userId, "add Engineer", "Engineer Save", 0, "Add Engineer : " + txtPhone.Text);
            }
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
