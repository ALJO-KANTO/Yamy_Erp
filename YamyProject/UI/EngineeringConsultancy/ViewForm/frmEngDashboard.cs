using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{

    public partial class frmEngDashboard : Form
    {
        private Guna2Panel cardProjects, cardPhases, cardMilestones, cardDeliverables, cardHours, cardKPI, cardProfit;
        private Guna2DataGridView dgvKPITrend, dgvTopProjects;

        public frmEngDashboard()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }
        private void frmEngDashboard_Load(object sender, EventArgs e)
        {
            BuildUI();
        }
        private void BuildUI()
        {
            int cardWidth = 250, cardHeight = 100, margin = 20;

            int totalCardWidth = (cardWidth + margin) * 7; // 7 cards
            int cardHeightWithMargin = cardHeight + margin;
            panelMain.AutoScrollMinSize = new Size(totalCardWidth, cardHeightWithMargin + 300 + 300);
            // 300 + 300 are your two DataGridViews heights

            cardProjects = CreateCard("Total Projects", new Point(0, 0));
            cardPhases = CreateCard("Total Phases", new Point(cardWidth + margin, 0));
            cardMilestones = CreateCard("Total Milestones", new Point((cardWidth + margin) * 2, 0));
            cardDeliverables = CreateCard("Total Deliverables", new Point((cardWidth + margin) * 3, 0));
            cardHours = CreateCard("Total Hours", new Point((cardWidth + margin) * 4, 0));
            cardKPI = CreateCard("Average KPI", new Point((cardWidth + margin) * 5, 0));
            cardProfit = CreateCard("Top Project Profit", new Point((cardWidth + margin) * 6, 0));

            panelMain.Controls.AddRange(new Control[] { cardProjects, cardPhases, cardMilestones, cardDeliverables, cardHours, cardKPI, cardProfit });

            dgvKPITrend = new Guna2DataGridView
            {
                Location = new Point(0, cardHeight + margin),
                Size = new Size(1200, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None
            };
            panelMain.Controls.Add(dgvKPITrend);

            dgvTopProjects = new Guna2DataGridView
            {
                Location = new Point(0, cardHeight + margin + dgvKPITrend.Height + margin),
                Size = new Size(1200, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None
            };
            panelMain.Controls.Add(dgvTopProjects);

            LoadDashboard();
        }

        private Guna2Panel CreateCard(string title, Point location)
        {
            var card = new Guna2Panel
            {
                Size = new Size(250, 100),
                Padding = new Padding(0, 80, 0, 0),
                Location = location,
                BorderRadius = 10,
                FillColor = Color.White,
                ShadowDecoration = { Enabled = true, Depth = 10 }
            };

            var lblTitle = new Label
            {
                Text = LocalizationManager.GetString(title),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            card.Controls.Add(lblTitle);

            var lblValue = new Label
            {
                Name = "lblValue",
                Text = "0",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(10, 40),
                AutoSize = true
            };
            card.Controls.Add(lblValue);

            return card;
        }

        private void LoadDashboard()
        {
            // Total Projects
            DataTable dt = DBClass.ExecuteDataTable("SELECT COUNT(DISTINCT project_id) AS total FROM tbl_eng_project_phases");
            cardProjects.Controls["lblValue"].Text = dt.Rows[0]["total"].ToString();

            // Total Phases
            dt = DBClass.ExecuteDataTable("SELECT COUNT(*) AS total FROM tbl_eng_project_phases");
            cardPhases.Controls["lblValue"].Text = dt.Rows[0]["total"].ToString();

            // Total Milestones
            dt = DBClass.ExecuteDataTable("SELECT COUNT(*) AS total FROM tbl_eng_project_milestones");
            cardMilestones.Controls["lblValue"].Text = dt.Rows[0]["total"].ToString();

            // Total Deliverables
            dt = DBClass.ExecuteDataTable("SELECT COUNT(*) AS total FROM tbl_eng_project_deliverables");
            cardDeliverables.Controls["lblValue"].Text = dt.Rows[0]["total"].ToString();

            // Total Approved Hours
            dt = DBClass.ExecuteDataTable("SELECT IFNULL(SUM(hours),0) AS total FROM tbl_eng_timesheets WHERE is_approved=1");
            cardHours.Controls["lblValue"].Text = dt.Rows[0]["total"].ToString();

            // Average KPI
            dt = DBClass.ExecuteDataTable("SELECT ROUND(AVG(score),2) AS avg_kpi FROM tbl_kpi_results WHERE period_year = YEAR(CURDATE())");
            cardKPI.Controls["lblValue"].Text = dt.Rows[0]["avg_kpi"].ToString() + " %";

            // KPI Trend
            dgvKPITrend.DataSource = DBClass.ExecuteDataTable(
                @"SELECT period_month AS Month, ROUND(AVG(score),2) AS AvgScore
              FROM tbl_kpi_results
              WHERE period_year = YEAR(CURDATE())
              GROUP BY period_month
              ORDER BY period_month"
            );

            // Top 5 Profitable Projects
            dgvTopProjects.DataSource = DBClass.ExecuteDataTable(
                @"SELECT prj.id project_id, MAX(prj.name) AS `Project Name`,
                     SUM(r.recognized_amount) AS Revenue,
                     SUM(c.actual_cost) AS Cost,
                     (SUM(r.recognized_amount) - SUM(c.actual_cost)) AS Profit,
                     ROUND((SUM(r.recognized_amount) - SUM(c.actual_cost)) / NULLIF(SUM(r.recognized_amount),0) * 100,2) AS ProfitPercent
              FROM tbl_eng_project_revenue r
              JOIN tbl_eng_project_costing c ON r.project_id = c.project_id
              JOIN tbl_projects prj ON r.project_id = prj.id
              GROUP BY r.project_id
              ORDER BY Profit DESC
              LIMIT 5"
            );

            dgvTopProjects.Columns["project_id"].Visible = false;


            cardProfit.Controls["lblValue"].Text = dgvTopProjects.Rows.Count > 0
                ? dgvTopProjects.Rows[0].Cells["Profit"].Value.ToString()
                : "0";

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKPITrend);
            LocalizationManager.LocalizeDataGridViewHeaders(dgvTopProjects);
        }

        //private void LoadDashboard()
        //{
        //    // === Projects Summary ===
        //    DataTable dtProjects = DBClass.ExecuteDataTable(
        //        "SELECT COUNT(*) AS TotalProjects, SUM(actual_cost) AS TotalCost, SUM(revenue_amount) AS TotalRevenue FROM eng_project_financials");
        //    if (dtProjects.Rows.Count > 0)
        //    {
        //        cardProjects.Controls["lblValue"].Text = dtProjects.Rows[0]["TotalProjects"].ToString();
        //        cardFinancials.Controls["lblValue"].Text = "AED " + dtProjects.Rows[0]["TotalRevenue"].ToString();
        //    }

        //    // === KPI Summary ===
        //    DataTable dtKPI = DBClass.ExecuteDataTable(
        //        @"SELECT ROUND(AVG(score),2) AS AvgKPI FROM tbl_kpi_results
        //      WHERE period_year = YEAR(CURDATE())");
        //    if (dtKPI.Rows.Count > 0)
        //    {
        //        cardKPI.Controls["lblValue"].Text = dtKPI.Rows[0]["AvgKPI"].ToString() + " %";
        //    }

        //    // === Resource Utilization ===
        //    DataTable dtResource = DBClass.ExecuteDataTable(
        //        @"SELECT COUNT(DISTINCT employee_id) AS TotalEngineers,
        //             SUM(hours) AS TotalHours
        //      FROM tbl_eng_timesheets
        //      WHERE is_approved = 1");
        //    if (dtResource.Rows.Count > 0)
        //    {
        //        cardResources.Controls["lblValue"].Text = dtResource.Rows[0]["TotalEngineers"].ToString() + " Engineers";
        //    }

        //    // === KPI Trend (last 12 months) ===
        //    dgvKPITrend.DataSource = DBClass.ExecuteDataTable(
        //        @"SELECT period_month, ROUND(AVG(score),2) AS AvgScore
        //      FROM tbl_kpi_results
        //      WHERE period_year = YEAR(CURDATE())
        //      GROUP BY period_month
        //      ORDER BY period_month");
        //}

        
        Dictionary<string, string> DashboardTitlesAr = new Dictionary<string, string>()
        {
            { "Total Projects", "إجمالي المشاريع" },
            { "Total Phases", "إجمالي المراحل" },
            { "Total Milestones", "إجمالي المعالم" },
            { "Total Deliverables", "إجمالي المخرجات" },
            { "Total Hours", "إجمالي الساعات" },
            { "Average KPI", "متوسط مؤشرات الأداء" },
            { "Top Project Profit", "أعلى ربح مشروع" }
        };

    }
}
