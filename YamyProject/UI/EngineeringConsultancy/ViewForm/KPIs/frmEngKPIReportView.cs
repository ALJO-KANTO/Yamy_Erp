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
using YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    public partial class frmEngKPIReportView : Form
    {
        string type = "";
        public frmEngKPIReportView(string _type)
        {
            InitializeComponent();
            type = _type;
        }

        private void frmEngKPIReportView_Load(object sender, EventArgs e)
        {
            lblFormName.Text = type;
            cmbMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray());

            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = DateTime.Now.Year;

            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            int month = cmbMonth.SelectedIndex + 1;
            int year = (int)numYear.Value;

            string query = "select 'No Data' message";

            if (type == "Monthly / Quarterly Sales Target Achievement (%)")
            {
                query = @"SELECT 
                            c.name AS `Client Name`,
                            (SUM(net) / @target) * 100 AS `Actual Value`
                        FROM tbl_sales s
                        INNER JOIN tbl_customer c ON c.id = s.customer_id
                        WHERE s.state = 1
                          AND YEAR(s.date)=@y AND MONTH(s.date)=@m
                        GROUP BY s.customer_id;";
            }
            else if (type == "Number of New Leads Generated")
            {
                query = @"SELECT 
                            e.name `Employee Name`,
                            COUNT(*) AS `Actual Value`
                        FROM tbl_crm_leads l INNER JOIN tbl_employee e ON l.assigned_to = e.id
                        WHERE YEAR(l.created_date)=@y AND MONTH(l.created_date)=@m
                        GROUP BY l.assigned_to;
                        ";
            }
            else if (type == "Conversion Rate (Leads to Contracts %)")
            {
                query = @"SELECT
                            e.name `Employee Name`,
                            CASE 
                                WHEN COUNT(l.lead_id)=0 THEN 0
                                ELSE COUNT(DISTINCT c.contract_id)/COUNT(l.lead_id)*100
                            END AS actual_value
                        FROM tbl_crm_leads l
                        LEFT JOIN tbl_crm_proposals p ON p.employee_id=l.assigned_to
                        LEFT JOIN tbl_crm_contracts c ON c.client_id=p.client_id
                        INNER JOIN tbl_employee e ON l.assigned_to = e.id
                        WHERE YEAR(l.created_date)=@y AND MONTH(l.created_date)=@m
                        GROUP BY l.assigned_to;
                        ";
            }
            else if (type == "Value of Contracts Won (AED)")
            {
                query = @"SELECT
                            cc.LeadName AS Name,
                            SUM(contract_value) AS actual_value
                        FROM tbl_crm_contracts c
                        INNER JOIN tbl_crmcustomer cc ON c.client_id = cc.ID
                        WHERE YEAR(start_date)=@y AND MONTH(start_date)=@m
                        GROUP BY client_id;
                        ";
            }
            else if (type == "Average Sales Cycle Duration (days)")
            {
                query = @"SELECT
                            e.name AS `Employee Name`,
                            AVG(DATEDIFF(c.start_date,l.created_date)) AS actual_value
                        FROM tbl_crm_leads l
                        JOIN tbl_crm_contracts c ON c.client_id=l.assigned_to
                        INNER JOIN tbl_employee e ON e.id = l.assigned_to
                        GROUP BY l.assigned_to;
                        ";
            }
            else if (type == "Proposal Success Rate (%)")
            {
                query = @"SELECT
                            e.name AS `Employee Name`,
                            CASE
                                WHEN COUNT(p.proposal_id)=0 THEN 0
                                ELSE COUNT(c.contract_id)/COUNT(p.proposal_id)*100
                            END AS actual_value
                        FROM tbl_crm_proposals p
                        LEFT JOIN tbl_crm_contracts c ON c.client_id=p.client_id
                        INNER JOIN tbl_employee e ON e.id = p.employee_id
                        GROUP BY p.employee_id;
                        ";
            }
            else if (type == "Client Retention Rate (%)")
            {
                query = @"SELECT
                            COUNT(DISTINCT client_id) * 100.0 /
                            (SELECT COUNT(*) FROM tbl_crm_contracts) AS `Actual Value`
                        FROM tbl_crm_contracts;
                        ";
            }
            else if (type == "Outstanding Receivables vs Sales(%)")
            {
                query = @"SELECT
                            IFNULL((SUM(net - pay) / SUM(net)),0) * 100 AS `Actual Value`
                        FROM tbl_sales
                        WHERE state = 1 AND YEAR(date)=@y AND MONTH(date)=@m;
                        ";
            }

            dgvReport.DataSource = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@m", month), DBClass.CreateParameter("@y", year));

            LocalizationManager.LocalizeDataGridViewHeaders(dgvReport);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CommonExport.ExportToExcel((DataTable)dgvReport.DataSource, type);
        }
    }
}
