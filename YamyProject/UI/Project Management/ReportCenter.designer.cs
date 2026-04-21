using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject
{
    partial class ReportCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private SplitContainer splitContainerMain;
        private ListBox lstCategories;
        private Panel panelRightTop;
        private TabControl tabControlModes;
        private TabPage tabStandard;
        private TabPage tabMemorized;
        private TabPage tabFavorites;
        private TabPage tabRecent;
        private TabPage tabContributed;
        private FlowLayoutPanel flowReports;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblHeader;

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
            this.components = new Container();
            this.splitContainerMain = new SplitContainer();
            this.lstCategories = new ListBox();
            this.panelRightTop = new Panel();
            this.lblHeader = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.tabControlModes = new TabControl();
            this.tabStandard = new TabPage();
            this.tabMemorized = new TabPage();
            this.tabFavorites = new TabPage();
            this.tabRecent = new TabPage();
            this.tabContributed = new TabPage();
            this.flowReports = new FlowLayoutPanel();

            ((ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelRightTop.SuspendLayout();
            this.tabControlModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = DockStyle.Fill;
            this.splitContainerMain.FixedPanel = FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = false;
            this.splitContainerMain.Location = new Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            //
            // splitContainerMain.Panel1
            //
            this.splitContainerMain.Panel1.BackColor = Color.White;
            this.splitContainerMain.Panel1.Controls.Add(this.lstCategories);
            //
            // splitContainerMain.Panel2
            //
            this.splitContainerMain.Panel2.Controls.Add(this.flowReports);
            this.splitContainerMain.Panel2.Controls.Add(this.panelRightTop);
            this.splitContainerMain.Size = new Size(1000, 640);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 0;
            // 
            // lstCategories
            // 
            this.lstCategories.Dock = DockStyle.Fill;
            this.lstCategories.BorderStyle = BorderStyle.None;
            this.lstCategories.Font = new Font("Segoe UI", 10F);
            this.lstCategories.ItemHeight = 18;
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.BackColor = Color.White;
            this.lstCategories.SelectionMode = SelectionMode.One;
            this.lstCategories.Margin = new Padding(8);
            // sample items will be added in code-behind
            // 
            // panelRightTop
            // 
            this.panelRightTop.Dock = DockStyle.Top;
            this.panelRightTop.Height = 120;
            this.panelRightTop.Padding = new Padding(12);
            this.panelRightTop.BackColor = Color.FromArgb(245, 247, 250);
            this.panelRightTop.Controls.Add(this.lblHeader);
            this.panelRightTop.Controls.Add(this.txtSearch);
            this.panelRightTop.Controls.Add(this.btnSearch);
            this.panelRightTop.Controls.Add(this.tabControlModes);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new Point(6, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Report Center";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.txtSearch.Width = 220;
            this.txtSearch.Location = new Point(740, 10);
            this.txtSearch.Name = "txtSearch";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSearch.Location = new Point(965 - 28, 8); // adjust to keep inside panel
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(28, 24);
            this.btnSearch.Text = "🔍";
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.BackColor = Color.Transparent;
            // 
            // tabControlModes
            // 
            this.tabControlModes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.tabControlModes.Location = new Point(6, 40);
            this.tabControlModes.Name = "tabControlModes";
            this.tabControlModes.SelectedIndex = 0;
            this.tabControlModes.Size = new Size(950, 68);
            this.tabControlModes.TabIndex = 0;
            this.tabControlModes.Controls.Add(this.tabStandard);
            this.tabControlModes.Controls.Add(this.tabMemorized);
            this.tabControlModes.Controls.Add(this.tabFavorites);
            this.tabControlModes.Controls.Add(this.tabRecent);
            this.tabControlModes.Controls.Add(this.tabContributed);
            // 
            // tab Standard pages
            // 
            this.tabStandard.Text = "Standard";
            this.tabMemorized.Text = "Memorized";
            this.tabFavorites.Text = "Favorites";
            this.tabRecent.Text = "Recent";
            this.tabContributed.Text = "Contributed";
            // 
            // flowReports
            // 
            this.flowReports.Dock = DockStyle.Fill;
            this.flowReports.AutoScroll = true;
            this.flowReports.WrapContents = false;
            this.flowReports.FlowDirection = FlowDirection.LeftToRight;
            this.flowReports.Padding = new Padding(12);
            this.flowReports.BackColor = Color.White;
            // 
            // ReportCenter (Form)
            // 
            this.ClientSize = new Size(1000, 640);
            this.Controls.Add(this.splitContainerMain);
            this.MinimumSize = new Size(800, 480);
            this.Name = "ReportCenter";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Report Center";
            this.Load += new EventHandler(this.ReportCenter_Load);

            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelRightTop.ResumeLayout(false);
            this.panelRightTop.PerformLayout();
            this.tabControlModes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}