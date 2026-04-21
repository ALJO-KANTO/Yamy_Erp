using Microsoft.Vbe.Interop;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectEstimateReviewSummary : Form
    {
        public frmProjectEstimateReviewSummary()
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
        }

        private void frmProjectEstimateReviewSummary_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY pt.date) AS `SN`,
                            pt.id,
                            pt.date AS `Date`,
                            CONCAT(p.code, ' - ', p.name) AS `Project Name`,
                            CONCAT(tn.code, ' - ', tn.name) AS `Tender Name`,
                            pt.amount AS `Tender Amount`,
                            (SELECT IFNULL(SUM(amount), 0) total_estimate FROM tbl_project_tender_details WHERE tender_id = pt.id) AS `Tender Total`,
                            (SELECT IFNULL(SUM(total ), 0) total_estimate FROM tbl_project_tender_details WHERE tender_id = pt.id) AS `Estimated Cost`,
                            (pt.amount - (SELECT IFNULL(SUM(total), 0) total_estimate FROM tbl_project_tender_details WHERE tender_id = pt.id)) AS `Estimated Profit`,
                            CASE 
                                WHEN pt.amount > 0 
                                THEN ROUND(((pt.amount - (SELECT IFNULL(SUM(total), 0) total_estimate FROM tbl_project_tender_details WHERE tender_id = pt.id)) / pt.amount) * 100, 2)
                                ELSE 0
                            END AS `Profit %`
                        FROM tbl_project_tender pt
                        INNER JOIN tbl_projects p ON pt.project_id = p.id
                        INNER JOIN tbl_tender_names tn ON pt.tender_name_id = tn.id
                        WHERE pt.state = 0
                    ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbProjects.Text != "" && !chkProject.Checked)
            {
                query += " and pt.project_id = @id";
                parameters.Add(DBClass.CreateParameter("id", cmbProjects.SelectedValue.ToString()));
            }
            //if (cmbTenderName.Text != "" && !chkTenderName.Checked)
            //{
            //    query += " and pt.tender_name_id = @tender";
            //    parameters.Add(DBClass.CreateParameter("tender", cmbTenderName.SelectedValue.ToString()));
            //}
            if (!chkDate.Checked)
                query += " and pt.date >= @dateFrom and pt.date <= @dateTo";

            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            dgvItems.DataSource = DBClass.ExecuteDataTable(query, parameters.ToArray());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
