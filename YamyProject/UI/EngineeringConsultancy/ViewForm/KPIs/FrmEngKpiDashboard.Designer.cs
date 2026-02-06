using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    partial class FrmEngKpiDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.cardKpiScore = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.cardTrend = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.cardRank = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.cardTarget = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pnlChart = new Guna.UI2.WinForms.Guna2Panel();
            this.chartKpi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKpi)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.cmbYear);
            this.pnlHeader.Controls.Add(this.cmbMonth);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1400, 70);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "KPI Dashboard";
            // 
            // cmbYear
            // 
            this.cmbYear.BackColor = System.Drawing.Color.Transparent;
            this.cmbYear.BorderRadius = 6;
            this.cmbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FocusedColor = System.Drawing.Color.Empty;
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbYear.ItemHeight = 30;
            this.cmbYear.Location = new System.Drawing.Point(764, 18);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(140, 36);
            this.cmbYear.TabIndex = 1;
            // 
            // cmbMonth
            // 
            this.cmbMonth.BackColor = System.Drawing.Color.Transparent;
            this.cmbMonth.BorderRadius = 6;
            this.cmbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMonth.ItemHeight = 30;
            this.cmbMonth.Location = new System.Drawing.Point(914, 18);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(160, 36);
            this.cmbMonth.TabIndex = 2;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.cardKpiScore);
            this.pnlSummary.Controls.Add(this.cardTrend);
            this.pnlSummary.Controls.Add(this.cardRank);
            this.pnlSummary.Controls.Add(this.cardTarget);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.FillColor = System.Drawing.Color.Transparent;
            this.pnlSummary.Location = new System.Drawing.Point(0, 70);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(20);
            this.pnlSummary.Size = new System.Drawing.Size(1400, 140);
            this.pnlSummary.TabIndex = 2;
            // 
            // cardKpiScore
            // 
            this.cardKpiScore.BackColor = System.Drawing.Color.Transparent;
            this.cardKpiScore.FillColor = System.Drawing.Color.White;
            this.cardKpiScore.Location = new System.Drawing.Point(0, 0);
            this.cardKpiScore.Name = "cardKpiScore";
            this.cardKpiScore.ShadowColor = System.Drawing.Color.Black;
            this.cardKpiScore.Size = new System.Drawing.Size(200, 100);
            this.cardKpiScore.TabIndex = 0;
            // 
            // cardTrend
            // 
            this.cardTrend.BackColor = System.Drawing.Color.Transparent;
            this.cardTrend.FillColor = System.Drawing.Color.White;
            this.cardTrend.Location = new System.Drawing.Point(0, 0);
            this.cardTrend.Name = "cardTrend";
            this.cardTrend.ShadowColor = System.Drawing.Color.Black;
            this.cardTrend.Size = new System.Drawing.Size(200, 100);
            this.cardTrend.TabIndex = 1;
            // 
            // cardRank
            // 
            this.cardRank.BackColor = System.Drawing.Color.Transparent;
            this.cardRank.FillColor = System.Drawing.Color.White;
            this.cardRank.Location = new System.Drawing.Point(0, 0);
            this.cardRank.Name = "cardRank";
            this.cardRank.ShadowColor = System.Drawing.Color.Black;
            this.cardRank.Size = new System.Drawing.Size(200, 100);
            this.cardRank.TabIndex = 2;
            // 
            // cardTarget
            // 
            this.cardTarget.BackColor = System.Drawing.Color.Transparent;
            this.cardTarget.FillColor = System.Drawing.Color.White;
            this.cardTarget.Location = new System.Drawing.Point(0, 0);
            this.cardTarget.Name = "cardTarget";
            this.cardTarget.ShadowColor = System.Drawing.Color.Black;
            this.cardTarget.Size = new System.Drawing.Size(200, 100);
            this.cardTarget.TabIndex = 3;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chartKpi);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart.Location = new System.Drawing.Point(0, 210);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChart.Size = new System.Drawing.Size(1400, 320);
            this.pnlChart.TabIndex = 1;
            // 
            // chartKpi
            // 
            this.chartKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartKpi.Location = new System.Drawing.Point(20, 20);
            this.chartKpi.Name = "chartKpi";
            this.chartKpi.Size = new System.Drawing.Size(1360, 280);
            this.chartKpi.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvHistory);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 530);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20);
            this.pnlGrid.Size = new System.Drawing.Size(1400, 290);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHistory.Location = new System.Drawing.Point(20, 20);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.Size = new System.Drawing.Size(1360, 250);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvHistory.ThemeStyle.ReadOnly = true;
            this.dgvHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHistory.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1080, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 29);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FrmEngKpiDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1400, 820);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEngKpiDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KPI Dashboard";
            this.Load += new System.EventHandler(this.FrmKpiDashboard_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartKpi)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        //private void SetupCard(Guna.UI2.WinForms.Guna2ShadowPanel card, string title, int left)
        //{
        //    card.Size = new System.Drawing.Size(230, 100);
        //    card.Location = new System.Drawing.Point(left, 20);
        //    card.Radius = 10;
        //    card.ShadowDepth = 4;
        //    card.FillColor = System.Drawing.Color.White;

        //    var lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel
        //    {
        //        Text = title,
        //        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
        //        Location = new System.Drawing.Point(12, 8)
        //    };

        //    var lblValue = new Guna.UI2.WinForms.Guna2HtmlLabel
        //    {
        //        Name = "lblValue",
        //        Text = "--",
        //        Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
        //        Location = new System.Drawing.Point(12, 35)
        //    };

        //    card.Controls.Add(lblTitle);
        //    card.Controls.Add(lblValue);
        //}

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private Guna.UI2.WinForms.Guna2Panel pnlChart;
        private Guna.UI2.WinForms.Guna2Panel pnlGrid;

        private Guna.UI2.WinForms.Guna2ComboBox cmbYear;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMonth;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

        private Guna.UI2.WinForms.Guna2ShadowPanel cardKpiScore;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardTrend;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardRank;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardTarget;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartKpi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHistory;
        private Guna2Button btnRefresh;
    }
}