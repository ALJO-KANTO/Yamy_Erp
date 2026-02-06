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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmEngDeliverables : Form
    {
        int deliverableId = 0;

        public frmEngDeliverables()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngDeliverables_Load(object sender, EventArgs e)
        {
            LoadProjects();
            LoadTypes();
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

        private void LoadMilestones()
        {
            if (cmbPhase.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT milestone_id, milestone_name FROM tbl_eng_project_milestones WHERE phase_id=@ph",
                DBClass.CreateParameter("@ph", cmbPhase.SelectedValue));

            cmbMilestone.DataSource = dt;
            cmbMilestone.DisplayMember = "milestone_name";
            cmbMilestone.ValueMember = "milestone_id";
            cmbMilestone.SelectedIndex = -1;
        }

        private void LoadDeliverables()
        {
            if (cmbMilestone.SelectedIndex == -1) return;

            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT deliverable_id, deliverable_name Name, deliverable_type Type,
                         due_date DueDate, status Status, remarks Remarks
                  FROM tbl_eng_project_deliverables
                  WHERE milestone_id=@mid",
                DBClass.CreateParameter("@mid", cmbMilestone.SelectedValue));

            dgvDeliverables.DataSource = dt;
            dgvDeliverables.Columns["deliverable_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvDeliverables);
        }

        private void LoadTypes()
        {
            cmbType.Items.AddRange(new string[]
            {
                "Drawing", "Report", "Submission", "Calculation", "As-Built"
            });
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.AddRange(new string[]
            {
                "Planned", "Submitted", "Approved", "Rejected"
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_project_deliverables
                  (milestone_id, deliverable_name, deliverable_type, due_date, status, remarks)
                  VALUES (@mid, @name, @type, @date, @status, @remarks)",
                DBClass.CreateParameter("@mid", cmbMilestone.SelectedValue),
                DBClass.CreateParameter("@name", txtDeliverable.Text.Trim()),
                DBClass.CreateParameter("@type", cmbType.Text),
                DBClass.CreateParameter("@date", dtDueDate.Value.Date),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text.Trim())
            );

            LoadDeliverables();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (deliverableId == 0 || !ValidateForm()) return;

            DBClass.ExecuteNonQuery(
                @"UPDATE tbl_eng_project_deliverables SET
                    deliverable_name=@name,
                    deliverable_type=@type,
                    due_date=@date,
                    status=@status,
                    remarks=@remarks
                  WHERE deliverable_id=@id",
                DBClass.CreateParameter("@name", txtDeliverable.Text.Trim()),
                DBClass.CreateParameter("@type", cmbType.Text),
                DBClass.CreateParameter("@date", dtDueDate.Value.Date),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text.Trim()),
                DBClass.CreateParameter("@id", deliverableId)
            );

            LoadDeliverables();
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvDeliverables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDeliverables.Rows[e.RowIndex];
            deliverableId = Convert.ToInt32(row.Cells["deliverable_id"].Value);
            txtDeliverable.Text = row.Cells["name"].Value.ToString();
            cmbType.Text = row.Cells["type"].Value.ToString();
            dtDueDate.Value = Convert.ToDateTime(row.Cells["duedate"].Value);
            cmbStatus.Text = row.Cells["status"].Value.ToString();
            txtRemarks.Text = row.Cells["remarks"].Value.ToString();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            cmbMilestone.DataSource = null;
            dgvDeliverables.DataSource = null;
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMilestones();
            dgvDeliverables.DataSource = null;
        }

        private void cmbMilestone_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeliverables();
        }
        private bool ValidateForm()
        {
            if (cmbProject.SelectedIndex == -1 ||
                cmbPhase.SelectedIndex == -1 ||
                cmbMilestone.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDeliverable.Text))
            {
                MessageBox.Show("Please complete all required fields.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtDeliverable.Clear();
            cmbType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            txtRemarks.Clear();
            deliverableId = 0;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }
    }
}
