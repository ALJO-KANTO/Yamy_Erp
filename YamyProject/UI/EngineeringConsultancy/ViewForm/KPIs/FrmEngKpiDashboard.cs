using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using YamyProject;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    public partial class FrmEngKpiDashboard : Form
    {
        public FrmEngKpiDashboard()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }
        private int _employeeId;
        private void FrmKpiDashboard_Load(object sender, EventArgs e)
        {
            using (FrmSelectEmployee dlg = new FrmSelectEmployee())
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    Close(); // user cancelled → no dashboard
                    return;
                }

                _employeeId = dlg.SelectedEmployeeId;
            }

            SetupCard(cardKpiScore, "KPI Score", 20);
            SetupCard(cardTrend, "Trend", 270);
            SetupCard(cardRank, "Rank", 520);
            SetupCard(cardTarget, "Target vs Actual", 770);

            LoadPeriodSelectors();
            //SetupChart();
            LoadDashboard();
            ApplyRolePermissions();
        }

        private void SetupCard(Guna2ShadowPanel card, string title, int left)
        {
            card.Size = new Size(230, 100);
            card.Location = new Point(left, 20);
            card.Radius = 10;
            card.ShadowDepth = 4;
            card.FillColor = Color.White;

            var lblTitle = new Guna2HtmlLabel
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(12, 8)
            };

            var lblValue = new Guna2HtmlLabel
            {
                Name = "lblValue",
                Text = "--",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(12, 35)
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
        }
        private void LoadPeriodSelectors()
        {
            cmbYear.Items.Clear();
            cmbMonth.Items.Clear();

            DataTable periods = DBClass.ExecuteDataTable(
                @"SELECT DISTINCT period_year 
                  FROM tbl_kpi_results 
                  ORDER BY period_year DESC");

            foreach (DataRow r in periods.Rows)
                cmbYear.Items.Add(r["period_year"]);

            cmbMonth.Items.AddRange(
                System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames
                    .Where(m => !string.IsNullOrEmpty(m))
                    .ToArray());

            cmbYear.SelectedItem = DateTime.Now.Year;
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            //cmbYear.Items.Clear();
            //cmbMonth.Items.Clear();

            //for (int y = DateTime.Now.Year - 5; y <= DateTime.Now.Year; y++)
            //    cmbYear.Items.Add(y);

            //cmbMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo
            //    .InvariantInfo.MonthNames);

            //cmbYear.SelectedItem = DateTime.Now.Year;
            //cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
        }
        private void LoadDashboard()
        {
            if (cmbYear.SelectedItem == null || cmbMonth.SelectedIndex < 0)
                return;

            int year = Convert.ToInt32(cmbYear.SelectedItem);
            int month = cmbMonth.SelectedIndex + 1;

            LoadKpiScore(month, year);
            LoadKpiTrend(year);
            LoadKpiHistory(month, year);
        }
        private void LoadKpiScore(int month, int year)
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT 
                    SUM(r.score * m.weight) / SUM(m.weight) AS weighted_score
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master m ON r.kpi_id = m.kpi_id
                  WHERE r.employee_id = @emp
                    AND r.period_month = @m
                    AND r.period_year = @y",
                DBClass.CreateParameter("@emp", _employeeId),
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            string score = dt.Rows[0]["weighted_score"] == DBNull.Value
                ? "0%"
                : $"{Convert.ToDecimal(dt.Rows[0]["weighted_score"]):0.##}%";

            SetCardValue(cardKpiScore, score);
        }
        private void LoadKpiTrend(int year)
        {
            chartKpi.Series.Clear();
            chartKpi.ChartAreas.Clear();

            ChartArea area = chartKpi.ChartAreas.Add("Main");
            area.AxisX.Title = "Month";
            area.AxisY.Title = "KPI Score (%)";

            Series series = chartKpi.Series.Add("KPI Trend");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;

            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT 
                    period_month,
                    ROUND(SUM(r.score * m.weight) / SUM(m.weight),2) AS score
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master m ON r.kpi_id = m.kpi_id
                  WHERE r.employee_id = @emp
                    AND r.period_year = @y
                  GROUP BY period_month
                  ORDER BY period_month",
                DBClass.CreateParameter("@emp", _employeeId),
                DBClass.CreateParameter("@y", year)
            );

            foreach (DataRow r in dt.Rows)
            {
                string monthName =
                    System.Globalization.CultureInfo.CurrentCulture
                        .DateTimeFormat.GetAbbreviatedMonthName(
                            Convert.ToInt32(r["period_month"]));

                series.Points.AddXY(monthName, r["score"]);
            }
        }
        private void LoadKpiHistory(int month, int year)
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT 
                    m.kpi_name `KPI Name`,
                    m.kpi_category `KPI Category`,
                    m.target_value `Target Value`,
                    r.actual_value `Actual Value`,
                    r.score `Score`,
                    r.calculated_at `Calculated At`
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master m ON r.kpi_id = m.kpi_id
                  WHERE r.employee_id = @emp
                    AND r.period_month = @m
                    AND r.period_year = @y
                  ORDER BY m.kpi_category, m.kpi_name",
                DBClass.CreateParameter("@emp", _employeeId),
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            dgvHistory.DataSource = dt;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvHistory);
        }
        private void ApplyRolePermissions()
        {
            if (frmLogin.userRole.ToLower() == "employee")
            {
                // Employee: view only
                dgvHistory.ReadOnly = true;
            }
            else if (frmLogin.userRole.ToLower() == "manager")
            {
                // Manager: can review & comment (future)
            }
            else if (frmLogin.userRole.ToLower() == "hr" || frmLogin.userRole.ToLower() == "admin")
            {
                // HR/Admin: full visibility
            }
        }
        private void SetCardValue(Guna2ShadowPanel card, string value)
        {
            var lbl = card.Controls
                .OfType<Guna2HtmlLabel>()
                .FirstOrDefault(x => x.Name == "lblValue");

            if (lbl != null)
                lbl.Text = value;
        }
        private void SetupChart()
        {
            chartKpi.Series.Clear();
            chartKpi.ChartAreas.Clear();

            var area = chartKpi.ChartAreas.Add("Main");
            area.AxisX.Title = "Month";
            area.AxisY.Title = "KPI Score (%)";

            var series = chartKpi.Series.Add("Performance");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.BorderWidth = 3;

            // Dummy data (replace with DB)
            series.Points.AddXY("Jan", 72);
            series.Points.AddXY("Feb", 78);
            series.Points.AddXY("Mar", 81);
            series.Points.AddXY("Apr", 76);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (FrmSelectEmployee dlg = new FrmSelectEmployee())
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    Close(); // user cancelled → no dashboard
                    return;
                }

                _employeeId = dlg.SelectedEmployeeId;
            }

            //SetupCard(cardKpiScore, "KPI Score", 20);
            //SetupCard(cardTrend, "Trend", 270);
            //SetupCard(cardRank, "Rank", 520);
            //SetupCard(cardTarget, "Target vs Actual", 770);

            //LoadPeriodSelectors();
            //SetupChart();
            LoadDashboard();
            //ApplyRolePermissions();
        }
    }
}
public partial class FrmSelectEmployee : Form
{
    private Guna2ComboBox cmbEmployee;
    private Guna2Button btnOk;
    private Guna2Button btnCancel;
    private Guna2Panel panel;

    public int SelectedEmployeeId { get; private set; }

    public FrmSelectEmployee()
    {
        BuildUI();
        LoadEmployees();
    }

    private void BuildUI()
    {
        // === Form ===
        this.Text = "Select Employee";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new Size(400, 180);
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // === Panel ===
        panel = new Guna2Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20),
            BorderRadius = 10,
            FillColor = Color.White
        };
        this.Controls.Add(panel);

        // === Label ===
        var lbl = new Label
        {
            Text = "Employee",
            AutoSize = true,
            Location = new Point(10, 10),
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        panel.Controls.Add(lbl);

        // === ComboBox ===
        cmbEmployee = new Guna2ComboBox
        {
            Location = new Point(10, 35),
            Width = 360,
            DropDownStyle = ComboBoxStyle.DropDownList,
            BorderRadius = 6,
            Font = new Font("Segoe UI", 10),
        };
        panel.Controls.Add(cmbEmployee);

        // === OK Button ===
        btnOk = new Guna2Button
        {
            Text = "OK",
            Width = 100,
            Height = 36,
            BorderRadius = 8,
            Location = new Point(160, 100),
            FillColor = Color.FromArgb(0, 120, 215),
            Font = new Font("Segoe UI", 9, FontStyle.Bold)
        };
        btnOk.Click += BtnOk_Click;
        panel.Controls.Add(btnOk);

        // === Cancel Button ===
        btnCancel = new Guna2Button
        {
            Text = "Cancel",
            Width = 100,
            Height = 36,
            BorderRadius = 8,
            Location = new Point(270, 100),
            FillColor = Color.Gray,
            Font = new Font("Segoe UI", 9)
        };
        btnCancel.Click += (s, e) =>
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        };
        panel.Controls.Add(btnCancel);
    }

    private void LoadEmployees()
    {
        DataTable dt = DBClass.ExecuteDataTable(
            "SELECT id, name FROM tbl_employee ORDER BY name");

        cmbEmployee.DataSource = dt;
        cmbEmployee.DisplayMember = "name";
        cmbEmployee.ValueMember = "id";
        cmbEmployee.SelectedIndex = -1;
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        if (cmbEmployee.SelectedIndex == -1)
        {
            MessageBox.Show("Please select an employee.", "Required",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        SelectedEmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}

