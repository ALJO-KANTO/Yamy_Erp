using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Media;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmEngProjectPhases : Form
    {
        int selectedPhaseId = 0;

        public frmEngProjectPhases()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngProjectPhases_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadStatuses();
            ClearForm();
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

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Planned");
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("On Hold");
        }

        private void LoadPhases()
        {
            dgvPhases.Rows.Clear();
            if (cmbProject.SelectedIndex == -1)
                return;

            using (MySqlDataReader reader = DBClass.ExecuteReader(
                @"SELECT phase_id,
                         phase_name,
                         start_date,
                         end_date,
                         weight_percentage,
                         status
                  FROM tbl_eng_project_phases
                  WHERE project_id = @project_id
                  ORDER BY start_date",
                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue)
            ))
            {
                while (reader.Read())
                {
                    dgvPhases.Rows.Add(reader["phase_id"], reader["phase_name"], Convert.ToDateTime(reader["start_date"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(reader["end_date"]).ToString("yyyy-MM-dd"), reader["weight_percentage"], reader["status"]);
                }
            }

            dgvPhases.Columns["phase_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvPhases);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_project_phases
                    (project_id, phase_name, start_date, end_date, weight_percentage, status)
                  VALUES
                    (@project_id, @phase_name, @start_date, @end_date, @weight, @status)",

                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                DBClass.CreateParameter("@phase_name", txtPhaseName.Text.Trim()),
                DBClass.CreateParameter("@start_date", dtStartDate.Value.Date),
                DBClass.CreateParameter("@end_date", dtEndDate.Value.Date),
                DBClass.CreateParameter("@weight", numWeight.Value),
                DBClass.CreateParameter("@status", cmbStatus.Text)
            );

            LoadPhases();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPhaseId == 0) return;
            if (!ValidateForm()) return;

            DBClass.ExecuteNonQuery(
                @"UPDATE tbl_eng_project_phases SET
                        phase_name = @phase_name,
                        start_date = @start_date,
                        end_date = @end_date,
                        weight_percentage = @weight,
                        status = @status
                  WHERE phase_id = @phase_id",

                DBClass.CreateParameter("@phase_name", txtPhaseName.Text.Trim()),
                DBClass.CreateParameter("@start_date", dtStartDate.Value.Date),
                DBClass.CreateParameter("@end_date", dtEndDate.Value.Date),
                DBClass.CreateParameter("@weight", numWeight.Value),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@phase_id", selectedPhaseId)
            );

            LoadPhases();
            ClearForm();
        }

        private void dgvPhases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPhases.Rows[e.RowIndex];

            selectedPhaseId = Convert.ToInt32(row.Cells["phase_id"].Value);
            txtPhaseName.Text = row.Cells["phase_name"].Value.ToString();
            dtStartDate.Value = Convert.ToDateTime(row.Cells["start_date"].Value);
            dtEndDate.Value = Convert.ToDateTime(row.Cells["end_date"].Value);
            numWeight.Value = Convert.ToDecimal(row.Cells["weight_percentage"].Value);
            cmbStatus.Text = row.Cells["status"].Value.ToString();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            ClearForm();
        }

        private bool ValidateForm()
        {
            if (cmbProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a project.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhaseName.Text))
            {
                MessageBox.Show("Phase name is required.");
                return false;
            }

            if (dtEndDate.Value < dtStartDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtPhaseName.Clear();
            numWeight.Value = 0;
            cmbStatus.SelectedIndex = -1;
            selectedPhaseId = 0;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
