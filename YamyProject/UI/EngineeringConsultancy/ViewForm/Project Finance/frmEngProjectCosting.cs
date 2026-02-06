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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Project_Finance
{
    public partial class frmEngProjectCosting : Form
    {
        public frmEngProjectCosting()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmProjectCosting_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void LoadPhases()
        {
            if (cmbProject.SelectedIndex == -1) return;

            cmbPhase.DataSource = DBClass.ExecuteDataTable(
                "SELECT phase_id, phase_name FROM tbl_eng_project_phases WHERE project_id=@pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));
            cmbPhase.DisplayMember = "phase_name";
            cmbPhase.ValueMember = "phase_id";
            cmbPhase.SelectedIndex = -1;
        }

        private void LoadCosting()
        {
            if (cmbProject.SelectedIndex == -1) return;

            dgvCosting.DataSource = DBClass.ExecuteDataTable(
                @"SELECT cost_type, description, planned_cost, actual_cost, cost_date
                  FROM tbl_eng_project_costing
                  WHERE project_id=@pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCosting);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_project_costing
                  (project_id, phase_id, cost_type, description, planned_cost, actual_cost, cost_date, created_by)
                  VALUES
                  (@pid,@ph,@type,@desc,@plan,@actual,NOW(),@user)",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                DBClass.CreateParameter("@ph", cmbPhase.SelectedValue),
                DBClass.CreateParameter("@type", cmbCostType.Text),
                DBClass.CreateParameter("@desc", txtDescription.Text),
                DBClass.CreateParameter("@plan", txtPlannedCost.Text),
                DBClass.CreateParameter("@actual", txtActualCost.Text),
                DBClass.CreateParameter("@user", frmLogin.userId)
            );

            LoadCosting();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            LoadCosting();
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
