using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.Reports
{
    partial class ReportCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private HeaderUC headerUC1;
        private SplitContainer splitContainerMain;
        private ListBox lstCategories;
        private Panel panelRightTop;
        private Label lblHeader;
        private Guna2TextBox txtSearch;
        private Button btnSearch;
        private FlowLayoutPanel flowReports;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.flowReports = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRightTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.headerUC1 = new YamyProject.HeaderUC();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelRightTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 37);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerMain.Panel1.Controls.Add(this.lstCategories);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.flowReports);
            this.splitContainerMain.Panel2.Controls.Add(this.panelRightTop);
            this.splitContainerMain.Size = new System.Drawing.Size(1000, 603);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 0;
            // 
            // lstCategories
            // 
            this.lstCategories.BackColor = System.Drawing.Color.White;
            this.lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstCategories.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstCategories.IntegralHeight = false;
            this.lstCategories.ItemHeight = 36;
            this.lstCategories.Location = new System.Drawing.Point(0, 0);
            this.lstCategories.Margin = new System.Windows.Forms.Padding(8);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(200, 603);
            this.lstCategories.TabIndex = 0;
            this.lstCategories.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCategories_DrawItem);
            this.lstCategories.SelectedIndexChanged += new System.EventHandler(this.lstCategories_SelectedIndexChanged);
            // 
            // flowReports
            // 
            this.flowReports.AutoScroll = true;
            this.flowReports.BackColor = System.Drawing.Color.White;
            this.flowReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowReports.Location = new System.Drawing.Point(0, 52);
            this.flowReports.Name = "flowReports";
            this.flowReports.Padding = new System.Windows.Forms.Padding(12);
            this.flowReports.Size = new System.Drawing.Size(796, 551);
            this.flowReports.TabIndex = 0;
            // 
            // panelRightTop
            // 
            this.panelRightTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRightTop.Controls.Add(this.lblHeader);
            this.panelRightTop.Controls.Add(this.txtSearch);
            this.panelRightTop.Controls.Add(this.btnSearch);
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightTop.Location = new System.Drawing.Point(0, 0);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.Padding = new System.Windows.Forms.Padding(12);
            this.panelRightTop.Size = new System.Drawing.Size(796, 52);
            this.panelRightTop.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(6, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(128, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Report Center";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderRadius = 5;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(558, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(220, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(1261, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.HeaderText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1000, 30);
            this.headerUC1.TabIndex = 0;
            // 
            // ReportCenter
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "ReportCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Center";
            this.Load += new System.EventHandler(this.ReportCenter_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelRightTop.ResumeLayout(false);
            this.panelRightTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}