using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.FinanceBilling
{
    public partial class ProfitLossForm : Form
    {
        public ProfitLossForm()
        {
            InitializeComponent();
        }

        private void ProfitLossForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);
            cmbProject.SelectedIndex = -1;
            LoadFromData();
        }

        private void LoadFromData()
        {
            int projectId = Convert.ToInt32((cmbProject.SelectedValue == null ? "0" : cmbProject.SelectedValue));

            string query = @"SELECT
                            (SELECT IFNULL(SUM(amount),0)
                             FROM tbl_invoices
                             WHERE status = 'Paid') AS income,

                            (SELECT IFNULL(SUM(amount),0)
                             FROM tbl_expenses) AS expense";

            if (cmbProject.SelectedIndex > -1)
            {
                query = @"SELECT
                            p.name,
                            IFNULL(SUM(i.amount),0) AS income,
                            IFNULL(SUM(e.amount),0) AS expense,
                            IFNULL(SUM(i.amount),0) - IFNULL(SUM(e.amount),0) AS profit
                        FROM tbl_projects p
                        LEFT JOIN tbl_invoices i ON i.project_id = p.id AND i.status='Paid'
                        LEFT JOIN tbl_expenses e ON e.project_id = p.id WHERE p.id = @ProjectId
                        GROUP BY p.id;
                        ";
            }

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@ProjectId", projectId)))
            {
                if (reader.Read())
                {
                    decimal income = Convert.ToDecimal(reader["income"]);
                    decimal expense = Convert.ToDecimal(reader["expense"]);
                    decimal profit = income - expense;

                    txtRevenue.Text = income.ToString("N2");
                    txtCost.Text = expense.ToString("N2");
                    txtProfit.Text = profit.ToString("N2");

                    txtProfit.ForeColor = profit >= 0 ? Color.Green : Color.Red;

                    txtRevenue.ReadOnly = true;
                    txtProfit.ReadOnly = true;
                    txtCost.ReadOnly = true;
                }
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRevenue.Text)){
                MessageBox.Show("Please enter Revenue");
                return;
            }
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("Please enter Cost");
                return;
            }

            decimal income = Convert.ToDecimal(txtRevenue.Text);
            decimal expense = Convert.ToDecimal(txtCost.Text);
            decimal profit = income - expense;

            txtProfit.ForeColor = profit >= 0 ? Color.Green : Color.Red;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFromData();
        }
    }
}
