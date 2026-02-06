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
    public partial class frmEngRevenueRecognition : Form
    {
        public frmEngRevenueRecognition()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngRevenueRecognition_Load(object sender, EventArgs e)
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

        private void LoadRevenue()
        {
            if (cmbProject.SelectedIndex == -1) return;

            dgvRevenue.DataSource = DBClass.ExecuteDataTable(
                @"SELECT recognition_method, completion_percent, recognized_amount, recognition_date
                  FROM tbl_eng_project_revenue
                  WHERE project_id=@pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue));

            LocalizationManager.LocalizeDataGridViewHeaders(dgvRevenue);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal contractValue = Convert.ToDecimal(txtContractValue.Text);
            decimal completion = Convert.ToDecimal(txtCompletion.Text);

            decimal recognized = 0;

            if (cmbMethod.Text == "POC")
            {
                recognized = contractValue * (completion / 100);
            }
            else if (cmbMethod.Text == "Manual")
            {
                recognized = Convert.ToDecimal((string.IsNullOrEmpty(txtRecognizedAmount.Text) ? "0" : txtRecognizedAmount.Text));
            }

            txtRecognizedAmount.Text = recognized.ToString("N2");
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_eng_project_revenue
                  (project_id, phase_id, recognition_method, completion_percent,
                   total_contract_value, recognized_amount, recognition_date, approved_by)
                  VALUES
                  (@pid,@ph,@method,@comp,@value,@amount,NOW(),@user)",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue),
                DBClass.CreateParameter("@ph", cmbPhase.SelectedValue),
                DBClass.CreateParameter("@method", cmbMethod.Text),
                DBClass.CreateParameter("@comp", txtCompletion.Text),
                DBClass.CreateParameter("@value", txtContractValue.Text),
                DBClass.CreateParameter("@amount", txtRecognizedAmount.Text.Replace(",", "")),
                DBClass.CreateParameter("@user", frmLogin.userId)
            );

            LoadRevenue();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhases();
            LoadRevenue();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
