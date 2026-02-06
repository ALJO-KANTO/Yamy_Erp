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

namespace YamyProject.UI.ContractingGeneralMaintenance.KPIDashboard
{
    public partial class KPIDashboardForm : Form
    {
        public KPIDashboardForm()
        {
            InitializeComponent();
        }

        private void KPIDashboardForm_Load(object sender, EventArgs e)
        {
            LoadKPIDashboard();
        }
        private void LoadKPIDashboard()
        {
            string sql = @"
                        SELECT
                            kpi_category,
                            CASE WHEN 
                            SUM(weight) < SUM(target_value) THEN
	 	                        ROUND((SUM(weight) / SUM(target_value)) * 100, 0)
	                         ELSE
	 	                        ROUND((SUM(target_value) / SUM(weight)) * 100, 0)
	                         END AS kpi_percentage
                        FROM tbl_kpi_master
                        GROUP BY kpi_category";

            using (MySqlDataReader r = DBClass.ExecuteReader(sql))
            {
                while (r.Read())
                {
                    string category = r["kpi_category"].ToString();
                    string value = r["kpi_percentage"].ToString() + "%";

                    if (category == "Project")
                        txtProjectPerformance.Text = value;

                    else if (category == "Finance")
                        txtFinancialPerformance.Text = value;

                    else if (category == "Maintenance")
                        txtMaintenancePerformance.Text = value;

                    else if (category == "HR")
                        txtHRPerformance.Text = value;
                }
            }
        }

    }
}
