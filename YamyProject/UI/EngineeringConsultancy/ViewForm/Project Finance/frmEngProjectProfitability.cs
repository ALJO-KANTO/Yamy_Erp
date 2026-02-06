using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Project_Finance
{
    public partial class frmEngProjectProfitability : Form
    {
        public frmEngProjectProfitability()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngProjectProfitability_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedIndex == -1) return;

            LoadSummary();
            LoadDetails();
        }

        private void LoadSummary()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT
                    IFNULL(r.revenue,0) AS revenue,
                    IFNULL(c.cost,0) AS cost
                  FROM tbl_projects p
                  LEFT JOIN (
                      SELECT project_id, SUM(recognized_amount) AS revenue
                      FROM tbl_eng_project_revenue
                      GROUP BY project_id
                  ) r ON r.project_id = p.id
                  LEFT JOIN (
                      SELECT project_id, SUM(actual_cost) AS cost
                      FROM tbl_eng_project_costing
                      GROUP BY project_id
                  ) c ON c.project_id = p.id
                  WHERE p.id = @pid",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue)
            );

            decimal revenue = Convert.ToDecimal(dt.Rows[0]["revenue"]);
            decimal cost = Convert.ToDecimal(dt.Rows[0]["cost"]);
            decimal profit = revenue - cost;
            decimal margin = revenue == 0 ? 0 : (profit / revenue) * 100;

            lblRevenue.Text = $"Revenue: {revenue:N2}";
            lblCost.Text = $"Cost: {cost:N2}";
            lblProfit.Text = $"Profit: {profit:N2}";
            lblMargin.Text = $"Margin: {margin:N2} %";
        }
        
        private void LoadDetails()
        {
            dgvProfitability.DataSource = DBClass.ExecuteDataTable(
                @"SELECT
                    ph.phase_name,
                    IFNULL(c.cost,0) AS cost,
                    IFNULL(r.revenue,0) AS revenue,
                    IFNULL(r.revenue,0) - IFNULL(c.cost,0) AS profit
                  FROM tbl_eng_project_phases ph
                  LEFT JOIN (
                      SELECT phase_id, SUM(actual_cost) AS cost
                      FROM tbl_eng_project_costing
                      GROUP BY phase_id
                  ) c ON c.phase_id = ph.phase_id
                  LEFT JOIN (
                      SELECT phase_id, SUM(recognized_amount) AS revenue
                      FROM tbl_eng_project_revenue
                      GROUP BY phase_id
                  ) r ON r.phase_id = ph.phase_id
                  WHERE ph.project_id = @pid
                  ORDER BY ph.phase_name",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProfitability);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}