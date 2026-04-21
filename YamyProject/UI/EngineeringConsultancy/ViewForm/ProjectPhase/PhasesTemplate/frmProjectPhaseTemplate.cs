using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectPhaseTemplate : Form
    {
        private int id = 0;
        public frmProjectPhaseTemplate(int _id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            this.id = _id;
        }
        private void frmProjectPhaseTemplate_Load(object sender, EventArgs e)
        {
            if (id > 0)
                LoadData();
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_project_phase_templates where template_id =@id", DBClass.CreateParameter("@id", id)))
            {
                if (reader.Read())
                {
                    txtPhaseNo.Text = reader["phase_no"].ToString();
                    txtPhaseName.Text = reader["phase_name"].ToString();
                    txtSortOrder.Text = reader["sort_order"].ToString();
                    ChkActive.Checked = reader.GetBoolean("is_active");
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";
            if (id == 0)
            {
                query = "INSERT INTO tbl_project_phase_templates (phase_no, phase_name, sort_order,is_active) VALUES (@no,@name,@order,@is_active)";
            }
            else
            {
                query = "UPDATE tbl_project_phase_templates SET phase_no=@no, phase_name=@name, sort_order=@order, is_active=@is_active WHERE template_id=@id";
            }

            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("@no", txtPhaseNo.Text),
                DBClass.CreateParameter("@name", txtPhaseName.Text),
                DBClass.CreateParameter("@order", txtSortOrder.Text),
                DBClass.CreateParameter("@is_active", ChkActive.Checked),
                DBClass.CreateParameter("@id", id)
            );
            EventHub.RefreshPhase();
            this.Close();
        }

        private void txtPhaseNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore non-digit input
            }
        }
    }
}
