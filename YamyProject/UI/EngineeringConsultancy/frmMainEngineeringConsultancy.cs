using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.EngineeringConsultancy.ViewForm;
using YamyProject.UI.EngineeringConsultancy.ViewForm.Common;
using YamyProject.UI.EngineeringConsultancy.ViewForm.CRM;
using YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management;
using YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management.Docs;
using YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs;
using YamyProject.UI.EngineeringConsultancy.ViewForm.Project_Finance;
using YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources;
namespace YamyProject.UI.Manufacturing
{
    public partial class frmMainEngineeringConsultancy : Form
    {

        static frmMainEngineeringConsultancy _obj;
        public static frmMainEngineeringConsultancy Instance
        {
            get { if (_obj == null) { _obj = new frmMainEngineeringConsultancy(); } return _obj; }
        }
        public frmMainEngineeringConsultancy()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);

            if (IsArabicCulture())
            {
                guna2HtmlLabel2.Visible = false;
                guna2HtmlLabel3.Visible = false;
                guna2HtmlLabel4.Visible = false;
                guna2HtmlLabel5.Visible = false;
                guna2HtmlLabel6.Visible = false;
                guna2HtmlLabel7.Visible = false;
                guna2HtmlLabel8.Visible = false;
                guna2HtmlLabel9.Visible = false;
                guna2HtmlLabel10.Visible = false;
                guna2HtmlLabel11.Visible = false;
                guna2HtmlLabel12.Visible = false;
                guna2HtmlLabel13.Visible = false;
                guna2HtmlLabel14.Visible = false;
                guna2HtmlLabel15.Visible = false;
                guna2HtmlLabel16.Visible = false;
                guna2HtmlLabel17.Visible = false;
                guna2HtmlLabel18.Visible = false;
                guna2HtmlLabel19.Visible = false;
                guna2HtmlLabel20.Visible = false;
                guna2HtmlLabel21.Visible = false;
                guna2HtmlLabel22.Visible = false;
                guna2HtmlLabel23.Visible = false;
                guna2HtmlLabel25.Visible = false;
                guna2HtmlLabel26.Visible = false;
            }
        }
        private bool IsArabicCulture()
        {
            // You can check either CurrentUICulture or CurrentCulture
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;

            // Arabic cultures start with "ar" (e.g., ar-SA, ar-EG)
            return currentUICulture.TwoLetterISOLanguageName.Equals("ar", StringComparison.OrdinalIgnoreCase);
        }

        private void btnDesignManagement_Click(object sender, EventArgs e)
        {
            //DesignManagement
            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.Items.Clear();
            }
            ToolStripMenuItem item1 = new ToolStripMenuItem("Documents");
            item1.Click += (s, args) =>
            {
                indicator.Visible = false;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngDocuments());
            };
            ToolStripMenuItem item2 = new ToolStripMenuItem("DocumentUpload");
            item2.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngDocumentUpload());
            };
            ToolStripMenuItem item3 = new ToolStripMenuItem("DocumentRevision");
            item3.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngDocumentRevision());
            };
            ToolStripMenuItem item4 = new ToolStripMenuItem("ApprovalWorkflow");
            item4.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngApprovalWorkflow());
            };

            contextMenuStrip1.Items.Add(item1);
            contextMenuStrip1.Items.Add(item2);
            contextMenuStrip1.Items.Add(item3);
            contextMenuStrip1.Items.Add(item4);

            contextMenuStrip1.Show(btnDesignManagement, new Point(0, btnDesignManagement.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }


        private void frmMainEngineeringConsultancy_Load(object sender, EventArgs e)
        {
            _obj = this;
            indicator.Visible = false;
        }

        public Form addcontrols2(Form f)
        {
            pnlcenter.Controls.Clear();
            f.TopLevel = false;
            pnlcenter.Controls.Add(f);
            f.Show();
            return f;
        }

        private void btnNav_Click(object sender, EventArgs e)
        {
            indicator.Visible = true;
            var btnC = (Control)sender;
            //Pages.SetPage(btn.Tag.ToString());     
            indicator.Top = btnC.Top + (btnC.Height / 2 - indicator.Height / 2);
            addcontrols2(new frmEngDashboard());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Restore down
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Maximize
            }
        }

        private void guna2GradientPanel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Restore down
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Maximize
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnProjectManagement_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.Items.Clear();
            }
            ToolStripMenuItem item1 = new ToolStripMenuItem("Project List");
            item1.Click += (s, args) =>
            {
                indicator.Visible = false;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProjectList());
            };
            ToolStripMenuItem item2 = new ToolStripMenuItem("Project Setup");
            item2.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProjectSetup());
            };
            ToolStripMenuItem item3 = new ToolStripMenuItem("Project Phases");
            item3.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProjectPhases());
            };
            ToolStripMenuItem item4 = new ToolStripMenuItem("Milestones");
            item4.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngMilestones());
            };
            ToolStripMenuItem item5 = new ToolStripMenuItem("Deliverables");
            item5.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngDeliverables());
            };
            ToolStripMenuItem item6 = new ToolStripMenuItem("Project Dashboard");
            item6.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProjectDashboard());
            };

            contextMenuStrip1.Items.Add(item1);
            contextMenuStrip1.Items.Add(item2);
            contextMenuStrip1.Items.Add(item3);
            contextMenuStrip1.Items.Add(item4);
            contextMenuStrip1.Items.Add(item5);
            contextMenuStrip1.Items.Add(item6);

            contextMenuStrip1.Show(btnProjectManagement, new Point(0, btnProjectManagement.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }

        //private void btnKPI_Click(object sender, EventArgs e)
        //{
        //    // for HR / Admin
        //    //KPIs
        //    if (contextMenuStrip1 != null)
        //    {
        //        contextMenuStrip1.Items.Clear();
        //    }
        //    ToolStripMenuItem item1 = new ToolStripMenuItem("KPIs");
        //    item1.Click += (s, args) =>
        //    {
        //        indicator.Visible = false;
        //        indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
        //        addcontrols2(new frmEngKPIMaster());
        //    };
        //    ToolStripMenuItem item2 = new ToolStripMenuItem("ExecutiveDashboard");
        //    item2.Click += (s, args) =>
        //    {
        //        indicator.Visible = true;
        //        indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
        //        addcontrols2(new frmEngExecutiveDashboardOld());
        //    };

        //    contextMenuStrip1.Items.Add(item1);
        //    contextMenuStrip1.Items.Add(item2);

        //    contextMenuStrip1.Show(btnKPI, new Point(0, btnKPI.Height));

        //}
        private void btnKPI_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1 != null)
                contextMenuStrip1.Items.Clear();

            // Setup submenu
            ToolStripMenuItem itemSetup = new ToolStripMenuItem("Setup");

            ToolStripMenuItem itemMaster = new ToolStripMenuItem("KPI Master");
            itemMaster.Click += (s, args) => addcontrols2(new frmEngKPIMaster());

            ToolStripMenuItem itemCalc = new ToolStripMenuItem("KPI Calculation");
            itemCalc.Click += (s, args) => addcontrols2(new frmEngKPICalculation());

            itemSetup.DropDownItems.Add(itemMaster);
            itemSetup.DropDownItems.Add(itemCalc);

            //// View submenu
            //ToolStripMenuItem itemView = new ToolStripMenuItem("View");

            //ToolStripMenuItem itemMyKPIs = new ToolStripMenuItem("My KPIs");
            //itemMyKPIs.Click += (s, args) => addcontrols2(new frmEngMyKPIs());

            //ToolStripMenuItem itemTeamKPIs = new ToolStripMenuItem("Team KPIs");
            //itemTeamKPIs.Click += (s, args) => addcontrols2(new frmEngTeamKPIs());

            //ToolStripMenuItem itemHistory = new ToolStripMenuItem("KPI History");
            //itemHistory.Click += (s, args) => addcontrols2(new frmEngKPIHistory());

            //itemView.DropDownItems.Add(itemMyKPIs);
            //itemView.DropDownItems.Add(itemTeamKPIs);
            //itemView.DropDownItems.Add(itemHistory);

            // Analytics submenu
            ToolStripMenuItem itemAnalytics = new ToolStripMenuItem("Analytics");

            ToolStripMenuItem itemDash = new ToolStripMenuItem("KPI Dashboard");
            itemDash.Click += (s, args) => addcontrols2(new FrmEngKpiDashboard());
            
            //ToolStripMenuItem itemExecDash = new ToolStripMenuItem("Executive Dashboard");
            //itemExecDash.Click += (s, args) => addcontrols2(new frmEngExecutiveDashboard());

            //ToolStripMenuItem itemBonus = new ToolStripMenuItem("Bonus Simulation");
            //itemBonus.Click += (s, args) => addcontrols2(new frmEngBonusSimulation());

            itemAnalytics.DropDownItems.Add(itemDash);
            //itemAnalytics.DropDownItems.Add(itemExecDash);
            //itemAnalytics.DropDownItems.Add(itemBonus);


            //ToolStripMenuItem itemReportView = new ToolStripMenuItem("Report View");
            ////Monthly / Quarterly Sales Target Achievement (%)
            //ToolStripMenuItem itemKPIReportSalesTargetAchievement = new ToolStripMenuItem("Monthly / Quarterly Sales Target Achievement (%)");
            //itemKPIReportSalesTargetAchievement.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Monthly / Quarterly Sales Target Achievement (%)"));
            ////Number of New Leads Generated
            //ToolStripMenuItem itemKPIReportNumberOfNewLeads = new ToolStripMenuItem("Number of New Leads Generated");
            //itemKPIReportNumberOfNewLeads.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Number of New Leads Generated"));
            ////Conversion Rate (Leads to Contracts %)
            //ToolStripMenuItem itemKPIReportConversionRate = new ToolStripMenuItem("Conversion Rate (Leads to Contracts %)");
            //itemKPIReportConversionRate.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Conversion Rate (Leads to Contracts %)"));
            //// Value of Contracts Won (AED)
            //ToolStripMenuItem itemKPIReportValueOfContractsWon = new ToolStripMenuItem("Value of Contracts Won (AED)");
            //itemKPIReportValueOfContractsWon.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Value of Contracts Won (AED)"));
            //// Average Sales Cycle Duration (days)
            //ToolStripMenuItem itemKPIReportAverageSalesCycleDuration = new ToolStripMenuItem("Average Sales Cycle Duration (days)");
            //itemKPIReportAverageSalesCycleDuration.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Average Sales Cycle Duration (days)"));
            //// Proposal Success Rate (%)
            //ToolStripMenuItem itemKPIReportProposalSuccessRate = new ToolStripMenuItem("Proposal Success Rate (%)");
            //itemKPIReportProposalSuccessRate.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Proposal Success Rate (%)"));
            //// Client Retention Rate (%)
            //ToolStripMenuItem itemKPIReportClientRetentionRate = new ToolStripMenuItem("Client Retention Rate (%)");
            //itemKPIReportClientRetentionRate.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Client Retention Rate (%)"));
            //// Outstanding Receivables vs Sales(%)
            //ToolStripMenuItem itemKPIReportOutstandingReceivablesVsSales = new ToolStripMenuItem("Outstanding Receivables vs Sales(%)");
            //itemKPIReportOutstandingReceivablesVsSales.Click += (s, args) => addcontrols2(new frmEngKPIReportView("Outstanding Receivables vs Sales(%)"));

            //itemReportView.DropDownItems.Add(itemKPIReportSalesTargetAchievement);
            //itemReportView.DropDownItems.Add(itemKPIReportNumberOfNewLeads);
            //itemReportView.DropDownItems.Add(itemKPIReportConversionRate);
            //itemReportView.DropDownItems.Add(itemKPIReportValueOfContractsWon);
            //itemReportView.DropDownItems.Add(itemKPIReportAverageSalesCycleDuration);
            //itemReportView.DropDownItems.Add(itemKPIReportProposalSuccessRate);
            //itemReportView.DropDownItems.Add(itemKPIReportClientRetentionRate);
            //itemReportView.DropDownItems.Add(itemKPIReportOutstandingReceivablesVsSales);


            // Add top-level menus
            contextMenuStrip1.Items.Add(itemSetup);
            //contextMenuStrip1.Items.Add(itemView);
            contextMenuStrip1.Items.Add(itemAnalytics);
            //contextMenuStrip1.Items.Add(itemReportView);

            contextMenuStrip1.Show(btnKPI, new Point(0, btnKPI.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }

        private void btnOrderD_Click(object sender, EventArgs e)
        {
            indicator.Visible = true;
            var btnC = (Control)sender;
            //Pages.SetPage(btn.Tag.ToString());     
            indicator.Top = btnC.Top + (btnC.Height / 2 - indicator.Height / 2);
            //addcontrols2(new frmManDashboard());
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnProjectFinance_Click(object sender, EventArgs e)
        {
            //ProjectFinance 
            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.Items.Clear();
            }
            ToolStripMenuItem item1 = new ToolStripMenuItem("ProjectCosting");
            item1.Click += (s, args) =>
            {
                indicator.Visible = false;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProjectCosting());
            };
            ToolStripMenuItem item2 = new ToolStripMenuItem("RevenueRecognition");
            item2.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngRevenueRecognition());
            };
            ToolStripMenuItem item3 = new ToolStripMenuItem("ProjectProfitability");
            item3.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProjectProfitability());
            };

            contextMenuStrip1.Items.Add(item1);
            contextMenuStrip1.Items.Add(item2);
            contextMenuStrip1.Items.Add(item3);

            contextMenuStrip1.Show(btnProjectFinance, new Point(0, btnProjectFinance.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }

        private void btnCRM_Click(object sender, EventArgs e)
        {
            //CRM
            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.Items.Clear();
            }
            ToolStripMenuItem item1 = new ToolStripMenuItem("Client List");
            item1.Click += (s, args) =>
            {
                indicator.Visible = false;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngClientList());
            };
            ToolStripMenuItem item2 = new ToolStripMenuItem("Proposal");
            item2.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProposal());
            };
            ToolStripMenuItem item3 = new ToolStripMenuItem("Contract");
            item3.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngContract());
            };
            ToolStripMenuItem item4 = new ToolStripMenuItem("CRM Leads");
            item4.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmCRMLeads());
            };

            contextMenuStrip1.Items.Add(item1);
            contextMenuStrip1.Items.Add(item2);
            contextMenuStrip1.Items.Add(item3);
            contextMenuStrip1.Items.Add(item4);

            contextMenuStrip1.Show(btnCRM, new Point(0, btnCRM.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            indicator.Visible = true;
            var btndashboard = (Control)sender;
            //Pages.SetPage(btn.Tag.ToString());     
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            indicator.Visible = true;
            var btndashboard = (Control)sender;
            //Pages.SetPage(btn.Tag.ToString());     
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //indicator.Visible = true;
            //var btnC = (Control)sender;
            //indicator.Top = btnC.Top + (btnC.Height / 2 - indicator.Height / 2);
            //pnlcenter.Controls.Clear();
        }

        private void btnCommon_Click(object sender, EventArgs e)
        {
            //Common
            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.Items.Clear();
            }
            if (contextMenuStrip1 != null && contextMenuStrip1.Items.Count <= 0)
            {
                ToolStripMenuItem item1 = new ToolStripMenuItem("Lookups");
                item1.Click += (s, args) =>
                {
                    indicator.Visible = true;
                    indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                    addcontrols2(new frmEngLookups());
                };
                ToolStripMenuItem item2 = new ToolStripMenuItem("Settings");
                item2.Click += (s, args) =>
                {
                    indicator.Visible = true;
                    indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                    addcontrols2(new frmGeneralSettings());
                };
                ToolStripMenuItem item3 = new ToolStripMenuItem("ApprovalLog");
                item3.Click += (s, args) =>
                {
                    indicator.Visible = true;
                    indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                    addcontrols2(new frmEngApprovalLog());
                };
                contextMenuStrip1.Items.Add(item1);
                contextMenuStrip1.Items.Add(item2);
                contextMenuStrip1.Items.Add(item3);
            }
            contextMenuStrip1.Show(btnCommon, new Point(0, btnCommon.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnTimesheetResource_Click(object sender, EventArgs e)
        {
            //TimesheetResource
            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.Items.Clear();
            }
            ToolStripMenuItem item1 = new ToolStripMenuItem("TimesheetEntry");
            item1.Click += (s, args) =>
            {
                indicator.Visible = false;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngTimesheetEntry());
            };
            ToolStripMenuItem item2 = new ToolStripMenuItem("TimesheetApproval");
            item2.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngTimesheetApproval());
            };
            ToolStripMenuItem item3 = new ToolStripMenuItem("ResourceUtilization");
            item3.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngResourceUtilization());
            };
            ToolStripMenuItem item4 = new ToolStripMenuItem("ProductivityReport");
            item4.Click += (s, args) =>
            {
                indicator.Visible = true;
                indicator.Top = ((Control)sender).Top + (((Control)sender).Height / 2 - indicator.Height / 2);
                addcontrols2(new frmEngProductivityReport());
            };

            contextMenuStrip1.Items.Add(item1);
            contextMenuStrip1.Items.Add(item2);
            contextMenuStrip1.Items.Add(item3);
            contextMenuStrip1.Items.Add(item4);

            contextMenuStrip1.Show(btnTimesheetResource, new Point(0, btnTimesheetResource.Height));
            LocalizationManager.LocalizeContextMenu(contextMenuStrip1);
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
