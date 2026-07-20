using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Reports.FinancialReports
{
    public partial class ProfitLossReport1 : Form
    {
        string reportType = "";
        Dictionary<string, decimal> balanceCache = new Dictionary<string, decimal>();
        DataTable dtLevel1;
        DataTable dtLevel2;
        DataTable dtLevel3;
        DataTable dtLevel4;

        public ProfitLossReport1(string _type = "standard")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.reportType = _type;
            headerUC1.FormText = this.Text;
        }

        void Dates(DateTime d)
        {
            DateTime sDateOfY = new DateTime(d.Year, 1, 1);
            DateTime eDateOfY = new DateTime(d.Year, 12, 31);

            dtFrom.Value = sDateOfY;
            dtTo.Value = eDateOfY;
        }

        private void ProfitLossReport1_Load(object sender, EventArgs e)
        {
            Dates(DateTime.Now);
            using (var reader = DBClass.ExecuteReader("SELECT name FROM tbl_company"))
            {
                if (reader.Read() && reader["name"] != DBNull.Value)
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            }
            dgvCustomer.Font = new System.Drawing.Font("Segoe UI", 7, System.Drawing.FontStyle.Bold);
            btnPrint.Text = "Print ▼";
            dateChangeTo();
            addColumns();
            BindDGV_Data();
            DateWords();
        }

        private void AddDGVColumnsAll()
        {
            dgvCustomer.Columns.Clear();
            if (reportType == "standard" || reportType == "Unclassified")
            {
                dgvCustomer.Columns.Add("state", "");
                dgvCustomer.Columns.Add("loadState", "");
                dgvCustomer.Columns.Add("currLvl", "");
                dgvCustomer.Columns.Add("lvl1", "   ");
                dgvCustomer.Columns.Add("id", "");
                dgvCustomer.Columns.Add("currname", "");
                dgvCustomer.Columns.Add("balance", "Amount");
                dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["state"].Visible = dgvCustomer.Columns["currname"].Visible = dgvCustomer.Columns["id"].Visible = dgvCustomer.Columns["loadState"].Visible = dgvCustomer.Columns["currLvl"].Visible = false;
                dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //dgvCustomer.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
                //dgvCustomer.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Format = "N2";
                dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else if (reportType == "YTD Comparison")
            {
                string currentPeriod = $"{dtFrom.Value:MMM ''yy} – {dtTo.Value:MMM ''yy}";
                string previousPeriod = $"{prevFrom:MMM ''yy} – {prevTo:MMM ''yy}";
                var s = "";
                dgvCustomer.Columns.Add("state", "");
                dgvCustomer.Columns.Add("loadState", "");
                dgvCustomer.Columns.Add("currLvl", "");
                dgvCustomer.Columns.Add("lvl1", "Ordinary Income/Expense");
                dgvCustomer.Columns.Add("id", "");
                dgvCustomer.Columns.Add("currname", "");
                dgvCustomer.Columns.Add("balance1", currentPeriod);
                dgvCustomer.Columns.Add("balance2", previousPeriod);
                dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["state"].Visible = dgvCustomer.Columns["currname"].Visible = dgvCustomer.Columns["id"].Visible = dgvCustomer.Columns["loadState"].Visible = dgvCustomer.Columns["currLvl"].Visible = false;
                dgvCustomer.Columns["balance1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.Columns["balance2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance1"].HeaderCell.Style.Format = dgvCustomer.Columns["balance2"].HeaderCell.Style.Format = "N2";
                dgvCustomer.Columns["balance2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //dgvCustomer.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
                //dgvCustomer.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else if (reportType == "Prev Year Comparison")
            {
                dgvCustomer.Dock = DockStyle.Fill;
                string currentPeriod = $"{dtFrom.Value:MMM dd} – {dtTo.Value:MMM dd yy}";
                string previousPeriod = $"{prevFrom:MMM dd} – {prevTo:MMM dd yy}";

                dgvCustomer.Columns.Add("state", "");
                dgvCustomer.Columns.Add("loadState", "");
                dgvCustomer.Columns.Add("currLvl", "");
                dgvCustomer.Columns.Add("lvl1", "    ");
                dgvCustomer.Columns.Add("id", "");
                dgvCustomer.Columns.Add("currname", "");
                dgvCustomer.Columns.Add("balance1", currentPeriod);
                dgvCustomer.Columns.Add("balance2", previousPeriod);
                dgvCustomer.Columns.Add("change", "Change");
                dgvCustomer.Columns.Add("change_percentage", "% Change");
                dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["state"].Visible = dgvCustomer.Columns["currname"].Visible = dgvCustomer.Columns["id"].Visible = dgvCustomer.Columns["loadState"].Visible = dgvCustomer.Columns["currLvl"].Visible = false;
                dgvCustomer.Columns["balance1"].DefaultCellStyle.Alignment =
                    dgvCustomer.Columns["balance2"].DefaultCellStyle.Alignment =
                    dgvCustomer.Columns["change"].DefaultCellStyle.Alignment =
                    dgvCustomer.Columns["change_percentage"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment =
                    dgvCustomer.Columns["balance1"].HeaderCell.Style.Alignment =
                    dgvCustomer.Columns["balance2"].HeaderCell.Style.Alignment =
                    dgvCustomer.Columns["change"].HeaderCell.Style.Alignment =
                    dgvCustomer.Columns["change_percentage"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance1"].HeaderCell.Style.Format = dgvCustomer.Columns["balance2"].HeaderCell.Style.Format = dgvCustomer.Columns["change"].HeaderCell.Style.Format = dgvCustomer.Columns["change_percentage"].HeaderCell.Style.Format = "N2";
                dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //dgvCustomer.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
                //dgvCustomer.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else if (reportType == "by Job")
            {
                dgvCustomer.Columns.Add("state", "");
                dgvCustomer.Columns.Add("loadState", "");
                dgvCustomer.Columns.Add("currLvl", "");
                dgvCustomer.Columns.Add("lvl1", "    ");
                dgvCustomer.Columns.Add("id", "");
                dgvCustomer.Columns.Add("currname", "");
                // here i want column name from job name(customer name) from tbl_customer and total amount from tbl_transaction
                dgvCustomer.Columns.Add("balance", "Total");
                dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["state"].Visible = dgvCustomer.Columns["currname"].Visible = dgvCustomer.Columns["id"].Visible = dgvCustomer.Columns["loadState"].Visible = dgvCustomer.Columns["currLvl"].Visible = false;
                dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //dgvCustomer.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
                //dgvCustomer.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Format = "N2";
                dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else if (reportType == "by Class")
            {
                dgvCustomer.Columns.Add("state", "");
                dgvCustomer.Columns.Add("loadState", "");
                dgvCustomer.Columns.Add("currLvl", "");
                dgvCustomer.Columns.Add("lvl1", "    ");
                dgvCustomer.Columns.Add("id", "");
                dgvCustomer.Columns.Add("currname", "");
                dgvCustomer.Columns.Add("balance", "Unclassified");
                dgvCustomer.Columns.Add("balance1", "Total");
                dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["state"].Visible = dgvCustomer.Columns["currname"].Visible = dgvCustomer.Columns["id"].Visible = dgvCustomer.Columns["loadState"].Visible = dgvCustomer.Columns["currLvl"].Visible = false;
                dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.Columns["balance1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //dgvCustomer.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
                //dgvCustomer.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Format = "N2";
                dgvCustomer.Columns["balance1"].HeaderCell.Style.Format = "N2";
                dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else if (reportType == "Unclassified")
            {
                dgvCustomer.Columns.Add("state", "");
                dgvCustomer.Columns.Add("loadState", "");
                dgvCustomer.Columns.Add("currLvl", "");
                dgvCustomer.Columns.Add("lvl1", "    ");
                dgvCustomer.Columns.Add("id", "");
                dgvCustomer.Columns.Add("currname", "");
                dgvCustomer.Columns.Add("balance", "Amount");
                dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["state"].Visible = dgvCustomer.Columns["currname"].Visible = dgvCustomer.Columns["id"].Visible = dgvCustomer.Columns["loadState"].Visible = dgvCustomer.Columns["currLvl"].Visible = false;
                dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCustomer.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                //dgvCustomer.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
                //dgvCustomer.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCustomer.Columns["balance"].HeaderCell.Style.Format = "N2";
                dgvCustomer.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomer.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);

        }
        private void LoadAllBalances(DateTime from, DateTime to)
        {
            balanceCache.Clear();

            using (var reader = DBClass.ExecuteReader(@"
        SELECT 
            t1.name AS level1,
            t2.name AS level2,
            t3.name AS level3,
            t4.name AS level4,
            SUM(tt.debit - tt.credit) AS balance
        FROM tbl_coa_level_1 t1
        LEFT JOIN tbl_coa_level_2 t2 ON t2.main_id = t1.id
        LEFT JOIN tbl_coa_level_3 t3 ON t3.main_id = t2.id
        LEFT JOIN tbl_coa_level_4 t4 ON t4.main_id = t3.id
        LEFT JOIN tbl_transaction tt 
            ON tt.account_id = t4.id 
           AND tt.date BETWEEN @from AND @to
        GROUP BY t1.name, t2.name, t3.name, t4.name
    ",
            DBClass.CreateParameter("from", from),
            DBClass.CreateParameter("to", to)))
            {
                while (reader.Read())
                {
                    string key1 = reader["level1"].ToString();
                    string key2 = reader["level2"].ToString();
                    string key3 = reader["level3"].ToString();
                    string key4 = reader["level4"].ToString();

                    var bal = reader["balance"];

                    decimal val = string.IsNullOrEmpty(bal.ToString()) ? 0 : Convert.ToDecimal(bal);

                    //balanceCache[key1] = balanceCache.GetValueOrDefault(key1) + val;

                    if (balanceCache.ContainsKey(key1)) balanceCache[key1] += val;
                    else balanceCache[key1] = val;

                    //balanceCache[key2] = balanceCache.GetValueOrDefault(key2) + val;
                    if (balanceCache.ContainsKey(key2)) balanceCache[key2] += val;
                    else balanceCache[key2] = val;
                    //balanceCache[key3] = balanceCache.GetValueOrDefault(key3) + val;
                    if (balanceCache.ContainsKey(key3)) balanceCache[key3] += val;
                    else balanceCache[key3] = val;
                    //balanceCache[key4] = balanceCache.GetValueOrDefault(key4) + val;
                    if (balanceCache.ContainsKey(key4)) balanceCache[key4] += val;
                    else balanceCache[key4] = val;
                }
            }
        }
        public void BindDGV_Data()
        {
            AddDGVColumnsAll();
            LoadAllBalances(dtFrom.Value, dtTo.Value);
            LoadCOATables();

            if (reportType == "standard")
            {
                dgvCustomer.Rows.Clear();

                decimal totalIncome = 0;
                decimal totalCost = 0;
                decimal totalExpense = 0;

                foreach (DataRow dr in dtLevel1.Rows)
                {
                    if (!(dr["category_code"].ToString().ToUpper() == "INCOME" ||
                          dr["category_code"].ToString().ToUpper() == "COST" ||
                          dr["category_code"].ToString().ToUpper() == "EXPENSE"))
                        continue;

                    string name = dr["name"].ToString();

                    decimal balance = GetBalance(name);

                    //if (balance == 0)
                    //    continue;

                    dgvCustomer.Rows.Add(
                        "e",
                        "l",
                        "1",
                        name,
                        dr["id"],
                        name,
                        Utilities.FormatDecimal(balance)
                    );

                    AddChildren(2, Convert.ToInt32(dr["id"]));

                    switch (dr["category_code"].ToString().ToUpper())
                    {
                        case "INCOME":

                            totalIncome = balance;

                            dgvCustomer.Rows.Add(
                                "n",
                                "l",
                                "1",
                                "Total Income",
                                "",
                                "",
                                Utilities.FormatDecimal(totalIncome));

                            break;

                        case "COST":

                            totalCost = balance;

                            dgvCustomer.Rows.Add(
                                "n",
                                "l",
                                "1",
                                "Gross Profit",
                                "",
                                "",
                                Utilities.FormatDecimal(totalIncome - totalCost));

                            break;

                        case "EXPENSE":

                            totalExpense = balance;

                            dgvCustomer.Rows.Add(
                                "n",
                                "l",
                                "1",
                                "Total Expenses",
                                "",
                                "",
                                Utilities.FormatDecimal(totalExpense));

                            break;
                    }
                }

                decimal netProfit = totalIncome - totalCost - totalExpense;

                dgvCustomer.Rows.Add(
                    "n",
                    "l",
                    "1",
                    "Net Profit",
                    "",
                    "",
                    Utilities.FormatDecimal(netProfit));

                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    string txt = row.Cells["lvl1"].Value?.ToString() ?? "";

                    if (txt.StartsWith("Total") ||
                        txt == "Gross Profit" ||
                        txt == "Net Profit")
                    {
                        row.DefaultCellStyle.Font =
                            new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                }
            }

            //if (reportType == "standard")
            //{
            //    dgvCustomer.Rows.Clear();
            //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
            //            WITH AccountBalances AS (
            //            SELECT 
            //                l1.id,
            //                l1.name,
            //                l1.category_code,
            //                CASE 
            //                    WHEN l1.category_code = 'Income'
            //                        THEN COALESCE(SUM(t.credit) - SUM(t.debit), 0)
            //                    ELSE
            //                        COALESCE(SUM(t.debit) - SUM(t.credit), 0)
            //                END AS balance,
            //                CASE
            //                    WHEN l1.category_code = 'Income'  THEN 1
            //                    WHEN l1.category_code = 'Cost'    THEN 2
            //                    WHEN l1.category_code = 'EXPENSE' THEN 4
            //                END AS sort_order
            //            FROM tbl_coa_level_1 l1
            //            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //            LEFT JOIN tbl_transaction t ON t.account_id = l4.id AND t.date BETWEEN @sDate AND @eDate
            //            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //            GROUP BY l1.id, l1.name, l1.category_code
            //        ),

            //        TotalIncome AS (
            //            SELECT
            //                -1 AS id,
            //                'Total Income' AS name,
            //                'TOTAL_INCOME' AS category_code,
            //                SUM(balance) AS balance,
            //                1.5 AS sort_order
            //            FROM AccountBalances
            //            WHERE category_code = 'Income'
            //        ),

            //        GrossProfit AS (
            //            SELECT
            //                0 AS id,
            //                'Gross Profit' AS name,
            //                'GROSS_PROFIT' AS category_code,
            //                COALESCE(
            //                    (SELECT SUM(balance) FROM AccountBalances WHERE category_code = 'Income'), 0
            //                ) -
            //                COALESCE(
            //                    (SELECT SUM(balance) FROM AccountBalances WHERE category_code = 'Cost'), 0
            //                ) AS balance,
            //                3 AS sort_order
            //        ),

            //        TotalExpenses AS (
            //            SELECT
            //                -2 AS id,
            //                'Total Expenses' AS name,
            //                'TOTAL_EXPENSE' AS category_code,
            //                SUM(balance) AS balance,
            //                4.5 AS sort_order
            //            FROM AccountBalances
            //            WHERE category_code = 'EXPENSE'
            //        )

            //        SELECT id, name, balance, sort_order
            //        FROM AccountBalances
            //        WHERE category_code IN ('Income', 'Cost')

            //        UNION ALL
            //        SELECT id, name, balance, sort_order FROM TotalIncome
            //        UNION ALL
            //        SELECT id, name, balance, sort_order FROM GrossProfit
            //        UNION ALL
            //        SELECT id, name, balance, sort_order FROM AccountBalances WHERE category_code = 'EXPENSE'
            //        UNION ALL
            //        SELECT id, name, balance, sort_order FROM TotalExpenses

            //        ORDER BY sort_order;

            //            ", DBClass.CreateParameter("sDate", dtFrom.Value.Date), DBClass.CreateParameter("eDate", dtTo.Value.Date)))
            //    {
            //        while (reader.Read())
            //        {
            //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
            //                reader["id"].ToString(), reader["name"].ToString(),
            //                Utilities.FormatDecimal(reader["balance"].ToString()));
            //        }
            //        // Auto-expand everything
            //        //for (int i = 0; i < dgvCustomer.Rows.Count; i++)
            //        //{
            //        //    ExpandRowRecursively(i);
            //        //}

            //        // ===============================
            //        // APPEND GROSS & NET PROFIT LAST
            //        // ===============================

            //        // Calculate totals from already-expanded rows
            //        decimal totalIncome = 0;
            //        decimal totalCOGS = 0;
            //        decimal totalExpense = 0;

            //        foreach (DataGridViewRow row in dgvCustomer.Rows)
            //        {
            //            string name = row.Cells["currname"].Value?.ToString()?.ToUpper() ?? "";
            //            decimal amount = 0;
            //            decimal.TryParse(row.Cells["balance"].Value?.ToString(), out amount);
            //            int currLvl = int.Parse(row.Cells["currLvl"].Value.ToString());

            //            //if (name == ("INCOME") && totalIncome == 0)
            //            //    totalIncome += decimal.Parse(GetBalanceData(1, name));

            //            //else if (name == ("COST") && totalCOGS ==0)
            //            //    totalCOGS += decimal.Parse(GetBalanceData(1, name));

            //            //else if (name == ("EXPENSE") && totalExpense ==0)
            //            //    totalExpense += decimal.Parse(GetBalanceData(1, name));
            //        }
            //        using (MySqlDataReader mySqlDataReader = DBClass.ExecuteReader(@"
            //                SELECT
            //                    t1.category_code,
            //                    IFNULL(COALESCE(SUM(tt.debit) - SUM(tt.credit), 0),0) AS total_balance
            //                FROM tbl_coa_level_1 t1
            //                JOIN tbl_coa_level_2 t2 ON t2.main_id = t1.id
            //                JOIN tbl_coa_level_3 t3 ON t3.main_id = t2.id
            //                JOIN tbl_coa_level_4 t4 ON t4.main_id = t3.id
            //                LEFT JOIN tbl_transaction tt ON tt.account_id = t4.id AND tt.date BETWEEN @sDate AND @eDate
            //                WHERE t1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY t1.category_code;
            //                ", DBClass.CreateParameter("sDate", dtFrom.Value.Date), DBClass.CreateParameter("eDate", dtTo.Value.Date))
            //            )
            //        {
            //            while (mySqlDataReader.Read())
            //            {
            //                string categoryCode = mySqlDataReader["category_code"].ToString();
            //                decimal totalBalance = Convert.ToDecimal(mySqlDataReader["total_balance"].ToString().Replace("-", ""));
            //                if (categoryCode.ToLower() == "income")
            //                    totalIncome = totalBalance;
            //                else if (categoryCode.ToLower() == "cost")
            //                    totalCOGS = totalBalance;
            //                else if (categoryCode.ToLower() == "expense")
            //                    totalExpense = totalBalance;
            //            }
            //        }

            //        // Calculate profits
            //        decimal grossProfit = totalIncome - totalCOGS;
            //        decimal netProfit = grossProfit - totalExpense;

            //        // Net Profit row
            //        dgvCustomer.Rows.Add(
            //            "n", "l", "1",
            //            "   Net Profit",
            //            "0", "Net Profit",
            //            Utilities.FormatDecimal(netProfit)
            //        );

            //        // Make them bold
            //        foreach (DataGridViewRow row in dgvCustomer.Rows)
            //        {
            //            string text = row.Cells["lvl1"].Value?.ToString()?.ToUpper() ?? "";
            //            if (text.Contains("GROSS PROFIT") || text.Contains("NET PROFIT") || text.Contains("TOTAL"))
            //            {
            //                row.DefaultCellStyle.Font =
            //                    new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
            //            }
            //        }
            //    }
            //}
            //else if (reportType == "YTD Comparison")
            //{
            //    dgvCustomer.Rows.Clear();
            //    headerUC1.FormText = this.Text + " " + reportType;
            //    guna2HtmlLabel7.Text = this.Text + " " + reportType;
            //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
            //            WITH AccountBalances AS (
            //                -- Calculate balances for Income, Cost, and Expenses
            //                SELECT 
            //                    l1.name AS Category, 
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.name
            //            ),

            //            FinalBalance AS (
            //                -- Calculate final balance: Income - Cost - Expenses
            //                SELECT 
            //                    'Final Balance (Income - Cost - Expenses)' AS Category,
            //                    COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Income'),0) 
            //                        - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Cost'),0)
            //                        - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance1,

            //                    COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Income'),0) 
            //                        - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Cost'),0)
            //                        - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance2
            //            ),

            //            EquityBalances AS (
            //                -- Calculate balances for Assets, Liabilities, and Equity
            //                SELECT 
            //                    l1.name, 
            //                    l1.id, 
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.id, l1.name
            //            )

            //            -- Final result combining the balances
            //            SELECT 
            //                eb.name, 
            //                eb.id, 
            //                CASE 
            //                    WHEN eb.name='Equity' THEN eb.Balance1 + (SELECT Balance1 FROM FinalBalance)
            //                    ELSE eb.Balance1
            //                END AS Balance1,
            //                CASE 
            //                    WHEN eb.name='Equity' THEN eb.Balance2 + (SELECT Balance2 FROM FinalBalance)
            //                    ELSE eb.Balance2
            //                END AS Balance2
            //            FROM EquityBalances eb
            //            ORDER BY eb.id;

            //            ",
            //            DBClass.CreateParameter("@currentFrom", dtFrom.Value),
            //            DBClass.CreateParameter("@currentTo", dtTo.Value),
            //            DBClass.CreateParameter("@prevFrom", prevFrom),
            //            DBClass.CreateParameter("@prevTo", prevTo)
            //            )
            //        )
            //    {
            //        while (reader.Read())
            //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
            //                reader["id"].ToString(), reader["name"].ToString(),
            //                Utilities.FormatDecimal(reader["balance1"].ToString()), Utilities.FormatDecimal(reader["balance2"].ToString()));

            //        // Auto-expand everything
            //        //for (int i = 0; i < dgvCustomer.Rows.Count; i++)
            //        //{
            //        //    ExpandRowRecursively(i);
            //        //}
            //    }
            //}
            //else if (reportType == "Prev Year Comparison")
            //{
            //    dgvCustomer.Rows.Clear();
            //    headerUC1.FormText = this.Text + " " + reportType;
            //    guna2HtmlLabel7.Text = this.Text + " " + reportType;
            //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
            //            WITH AccountBalances AS (
            //                -- Calculate balances for Income, Cost, and Expenses
            //                SELECT 
            //                    l1.name AS Category, 
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.name
            //            ),

            //            FinalBalance AS (
            //                -- Calculate final balance: Income - Cost - Expenses
            //                SELECT 
            //                    'Final Balance (Income - Cost - Expenses)' AS Category,
            //                    COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Income'),0) 
            //                        - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Cost'),0)
            //                        - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance1,

            //                    COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Income'),0) 
            //                        - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Cost'),0)
            //                        - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance2
            //            ),

            //            EquityBalances AS (
            //                -- Calculate balances for Assets, Liabilities, and Equity
            //                SELECT 
            //                    l1.name, 
            //                    l1.id, 
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
            //                    COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.id, l1.name
            //            )

            //            -- Final result combining the balances
            //            SELECT 
            //                eb.name, 
            //                eb.id, 
            //                CASE 
            //                    WHEN eb.name='Equity' THEN eb.Balance1 + (SELECT Balance1 FROM FinalBalance)
            //                    ELSE eb.Balance1
            //                END AS Balance1,
            //                CASE 
            //                    WHEN eb.name='Equity' THEN eb.Balance2 + (SELECT Balance2 FROM FinalBalance)
            //                    ELSE eb.Balance2
            //                END AS Balance2
            //            FROM EquityBalances eb
            //            ORDER BY eb.id;

            //            ",
            //            DBClass.CreateParameter("@currentFrom", dtFrom.Value),
            //            DBClass.CreateParameter("@currentTo", dtTo.Value),
            //            DBClass.CreateParameter("@prevFrom", prevFrom),
            //            DBClass.CreateParameter("@prevTo", prevTo)
            //            )
            //        )
            //    {
            //        while (reader.Read())
            //        {
            //            decimal balance1 = Convert.ToDecimal(reader["balance1"] ?? 0);
            //            decimal balance2 = Convert.ToDecimal(reader["balance2"] ?? 0);
            //            // Calculate $ Change
            //            decimal change = balance1 - balance2;

            //            // Calculate % Change (avoid division by zero)
            //            decimal percentChange = (balance2 != 0)
            //                ? (change / balance2) * 100
            //                : 0;

            //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
            //                                    reader["id"].ToString(), reader["name"].ToString(), Utilities.FormatDecimal(balance1),
            //                                    Utilities.FormatDecimal(balance2), Utilities.FormatDecimal(change), $"{percentChange:N1}%"
            //                                 );
            //        }
            //        // Auto-expand everything
            //        //for (int i = 0; i < dgvCustomer.Rows.Count; i++)
            //        //{
            //        //    ExpandRowRecursively(i);
            //        //}
            //    }
            //}
            //else if (reportType == "by Job")
            //{
            //    headerUC1.FormText = this.Text + " " + reportType;
            //    guna2HtmlLabel7.Text = this.Text + " " + reportType;

            //    //dgvCustomer.Columns.Clear();
            //    DataTable customersTable = DBClass.ExecuteDataTable(@"SELECT DISTINCT 
            //                                                                c.name,c.id
            //                                                            FROM tbl_customer AS c
            //                                                            JOIN tbl_transaction AS t 
            //                                                                ON c.id = t.hum_id
            //                                                            WHERE t.hum_id <> 0
            //                                                              AND EXISTS (
            //                                                                    SELECT 1
            //                                                                    FROM tbl_transaction AS tx
            //                                                                    LEFT JOIN tbl_coa_level_4 AS l4 ON tx.account_id = l4.id
            //                                                                    LEFT JOIN tbl_coa_level_3 AS l3 ON l4.main_id = l3.id
            //                                                                    LEFT JOIN tbl_coa_level_2 AS l2 ON l3.main_id = l2.id
            //                                                                    LEFT JOIN tbl_coa_level_1 AS l1 ON l2.main_id = l1.id
            //                                                                    WHERE 
            //                                                                        (tx.id = t.id
            //                                                                         OR (tx.type = t.type AND tx.transaction_id = t.transaction_id))
            //                                                                      AND l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                                                                )
            //                                                              AND t.type IN (
            //                                                                    'Customer Receipt',
            //                                                                    'Sales Invoice',
            //                                                                    'Customer Opening Balance',
            //                                                                    'Customer Advance Payment',
            //                                                                    'Check Cancel (Customer)',
            //                                                                    'SalesReturn Invoice',
            //                                                                    'Credit Note',
            //                                                                    'PDC Receivable'
            //                                                                )
            //                                                              AND t.date BETWEEN @sDate AND @eDate
            //                                                            ORDER BY c.name;
            //                                                          ",
            //                                                          DBClass.CreateParameter("sDate", dtFrom.Value),
            //                                                          DBClass.CreateParameter("eDate", dtTo.Value));
            //    // Build dynamic CASE SUM(...) for each customer
            //    string pivotColumns = string.Join(", ",
            //                                            customersTable.Rows.Cast<DataRow>().Select(c =>
            //                                            {
            //                                                string customerName = c["name"].ToString();
            //                                                string customerId = c["id"].ToString();

            //                                                return $@"
            //                                                    SUM(
            //                                                        CASE 
            //                                                            WHEN t.hum_id = {customerId} THEN 
            //                                                                CASE 
            //                                                                    WHEN t.type = 'Sales Invoice Cash' THEN -(COALESCE(t.debit - t.credit, 0))
            //                                                                    ELSE COALESCE(t.debit - t.credit, 0)
            //                                                                END
            //                                                            ELSE 0
            //                                                        END
            //                                                    ) AS `{MySqlHelper.EscapeString(customerName)}`
            //                                                ";
            //                                            })
            //                                        );


            //    // Build final SQL
            //    string sql = $@"
            //                    SELECT 
            //                        l1.id,
            //                        l1.name AS AccountName,
            //                        {pivotColumns},
            //                        SUM(
            //                            CASE 
            //                                WHEN t.type = 'Sales Invoice Cash' THEN -(COALESCE(t.debit - t.credit, 0))
            //                                ELSE COALESCE(t.debit - t.credit, 0)
            //                            END
            //                        ) AS Total
            //                    FROM tbl_coa_level_1 AS l1
            //                    LEFT JOIN tbl_coa_level_2 AS l2 ON l2.main_id = l1.id
            //                    LEFT JOIN tbl_coa_level_3 AS l3 ON l3.main_id = l2.id
            //                    LEFT JOIN tbl_coa_level_4 AS l4 ON l4.main_id = l3.id
            //                    LEFT JOIN tbl_transaction AS t 
            //                        ON t.account_id = l4.id
            //                    LEFT JOIN tbl_customer AS c 
            //                        ON c.id = t.hum_id
            //                    WHERE t.hum_id <> 0
            //                      AND EXISTS (
            //                            SELECT 1
            //                            FROM tbl_transaction AS tx
            //                            LEFT JOIN tbl_coa_level_4 AS lx4 ON tx.account_id = lx4.id
            //                            LEFT JOIN tbl_coa_level_3 AS lx3 ON lx4.main_id = lx3.id
            //                            LEFT JOIN tbl_coa_level_2 AS lx2 ON lx3.main_id = lx2.id
            //                            LEFT JOIN tbl_coa_level_1 AS lx1 ON lx2.main_id = lx1.id
            //                            WHERE 
            //                                (tx.id = t.id
            //                                 OR (tx.type = t.type AND tx.transaction_id = t.transaction_id))
            //                              AND lx1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                        )
            //                      AND t.type IN (
            //                            'Customer Receipt',
            //                            'Sales Invoice',
            //                            'Customer Opening Balance',
            //                            'Customer Advance Payment',
            //                            'Check Cancel (Customer)',
            //                            'SalesReturn Invoice',
            //                            'Credit Note',
            //                            'PDC Receivable'
            //                        )
            //                      AND t.date BETWEEN @sDate AND @eDate
            //                    GROUP BY l1.id, l1.name
            //                    ORDER BY l1.id;
            //                    ";

            //    // Execute
            //    DataTable ResultData = DBClass.ExecuteDataTable(sql,
            //        DBClass.CreateParameter("sDate", dtFrom.Value),
            //        DBClass.CreateParameter("eDate", dtTo.Value));

            //    var op = "";
            //    dgvCustomer.Columns.Clear();
            //    dgvCustomer.DataSource = ResultData;
            //    dgvCustomer.Columns["id"].Visible = false;

            //}
            //else if (reportType == "by Class")
            //{
            //    headerUC1.FormText = this.Text + " " + reportType;
            //    guna2HtmlLabel7.Text = this.Text + " " + reportType;

            //    dgvCustomer.Rows.Clear();
            //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
            //            WITH AccountBalances AS (
            //                -- Calculate balances for Income, Cost, and Expenses
            //                SELECT 
            //                    l1.name AS Category, 
            //                    COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS Balance
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.name
            //            ),

            //            FinalBalance AS (
            //                -- Calculate final balance: Income - Cost - Expenses
            //                SELECT 
            //                    'Final Balance (Income - Cost - Expenses)' AS Category,
            //                    COALESCE(
            //                        (SELECT Balance FROM AccountBalances WHERE Category = 'Income'), 0
            //                    ) -
            //                    COALESCE(
            //                        (SELECT Balance FROM AccountBalances WHERE Category = 'Cost'), 0
            //                    ) -
            //                    COALESCE(
            //                        (SELECT Balance FROM AccountBalances WHERE Category = 'EXPENSE'), 0
            //                    ) AS Balance
            //            ),

            //            EquityBalances AS (
            //                -- Calculate balances for Assets, Liabilities, and Equity
            //                SELECT 
            //                    l1.name, 
            //                    l1.id, 
            //                    COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS balance
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.id, l1.name
            //            )

            //            -- Final result combining the balances
            //            SELECT 
            //                eb.name, 
            //                eb.id, 
            //                CASE 
            //                    -- For Equity, add the final balance from Income - Cost - Expenses to Retained Earnings
            //                    WHEN eb.name = 'Equity' THEN 
            //                        eb.balance + 
            //                        (SELECT Balance FROM FinalBalance)
            //                    ELSE 
            //                        eb.balance
            //                END AS balance
            //            FROM EquityBalances eb
            //            ORDER BY eb.id;

            //            "))
            //    {
            //        while (reader.Read())
            //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
            //                reader["id"].ToString(), reader["name"].ToString(),
            //                Utilities.FormatDecimal(reader["balance"].ToString()), Utilities.FormatDecimal(reader["balance"].ToString()));

            //        // Auto-expand everything
            //        //for (int i = 0; i < dgvCustomer.Rows.Count; i++)
            //        //{
            //        //    ExpandRowRecursively(i);
            //        //}
            //    }
            //}
            //else if (reportType == "Unclassified")
            //{
            //    headerUC1.FormText = this.Text + " " + reportType;
            //    guna2HtmlLabel7.Text = this.Text + " " + reportType;

            //    dgvCustomer.Rows.Clear();
            //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
            //            WITH AccountBalances AS (
            //                -- Calculate balances for Income, Cost, and Expenses
            //                SELECT 
            //                    l1.name AS Category, 
            //                    COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS Balance
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.name
            //            ),

            //            FinalBalance AS (
            //                -- Calculate final balance: Income - Cost - Expenses
            //                SELECT 
            //                    'Final Balance (Income - Cost - Expenses)' AS Category,
            //                    COALESCE(
            //                        (SELECT Balance FROM AccountBalances WHERE Category = 'Income'), 0
            //                    ) -
            //                    COALESCE(
            //                        (SELECT Balance FROM AccountBalances WHERE Category = 'Cost'), 0
            //                    ) -
            //                    COALESCE(
            //                        (SELECT Balance FROM AccountBalances WHERE Category = 'EXPENSE'), 0
            //                    ) AS Balance
            //            ),

            //            EquityBalances AS (
            //                -- Calculate balances for Assets, Liabilities, and Equity
            //                SELECT 
            //                    l1.name, 
            //                    l1.id, 
            //                    COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS balance
            //                FROM tbl_coa_level_1 l1
            //                LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
            //                LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
            //                LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
            //                LEFT JOIN tbl_transaction t ON t.account_id = l4.id
            //                WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
            //                GROUP BY l1.id, l1.name
            //            )

            //            -- Final result combining the balances
            //            SELECT 
            //                eb.name, 
            //                eb.id, 
            //                CASE 
            //                    -- For Equity, add the final balance from Income - Cost - Expenses to Retained Earnings
            //                    WHEN eb.name = 'Equity' THEN 
            //                        eb.balance + 
            //                        (SELECT Balance FROM FinalBalance)
            //                    ELSE 
            //                        eb.balance
            //                END AS balance
            //            FROM EquityBalances eb
            //            ORDER BY eb.id;

            //            "))
            //    {
            //        while (reader.Read())
            //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
            //                reader["id"].ToString(), reader["name"].ToString(),
            //                Utilities.FormatDecimal(reader["balance"].ToString()));

            //        // Auto-expand everything
            //        //for (int i = 0; i < dgvCustomer.Rows.Count; i++)
            //        //{
            //        //    ExpandRowRecursively(i);
            //        //}
            //    }
            //}

        }
        private void LoadCOATables()
        {
            dtLevel1 = DBClass.ExecuteDataTable(@"
                        SELECT id, code, name, category_code
                        FROM tbl_coa_level_1
                        ORDER BY
                            CASE
                                WHEN category_code='Income' THEN 1
                                WHEN category_code='Cost' THEN 2
                                WHEN category_code='EXPENSE' THEN 3
                                ELSE 4
                            END, code");

            dtLevel2 = DBClass.ExecuteDataTable(@"
                        SELECT id, main_id, code, name
                        FROM tbl_coa_level_2
                        ORDER BY main_id, code");

            dtLevel3 = DBClass.ExecuteDataTable(@"
                        SELECT id, main_id, code, name
                        FROM tbl_coa_level_3
                        ORDER BY main_id, code");

            dtLevel4 = DBClass.ExecuteDataTable(@"
                        SELECT id, main_id, code, name
                        FROM tbl_coa_level_4
                        ORDER BY main_id, code");
        }
        private void AddChildren(int level, int parentId)
        {
            DataTable dt = null;

            switch (level)
            {
                case 2:
                    dt = dtLevel2;
                    break;

                case 3:
                    dt = dtLevel3;
                    break;

                case 4:
                    dt = dtLevel4;
                    break;
                default:
                    return;
            }

            DataRow[] rows = dt.Select("main_id=" + parentId, "code");

            foreach (DataRow dr in rows)
            {
                string name = dr["name"].ToString();

                decimal balance = GetBalance(name);

                // Hide empty accounts
                //if (balance == 0)
                //    continue;

                string indent = new string(' ', (level - 1) * 6);

                dgvCustomer.Rows.Add(
                    level == 4 ? "n" : "e",
                    "l",
                    level.ToString(),
                    indent + dr["code"] + " - " + name,
                    dr["id"],
                    name,
                    Utilities.FormatDecimal(balance)
                );

                AddChildren(level + 1, Convert.ToInt32(dr["id"]));
            }
        }
        private void ExpandRowRecursively0(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvCustomer.Rows.Count)
                return;

            DataGridViewRow row = dgvCustomer.Rows[rowIndex];
            int currLvl = int.Parse(row.Cells["currLvl"].Value.ToString());
            string state = row.Cells["state"].Value.ToString();
            string loadState = row.Cells["loadState"].Value.ToString();
            string cellValue = row.Cells["lvl1"].Value.ToString();
            string space = new string(' ', currLvl * 6 + 3);

            try
            {
                if (state == "e")
                {
                    if (loadState == "u")
                    {
                        int parentId = int.Parse(row.Cells["id"].Value.ToString());
                        List<DataGridViewRow> newRows = new List<DataGridViewRow>();

                        using (MySqlDataReader reader = DBClass.ExecuteReader(
                            $@"SELECT name as currname, concat(code,' - ',name) as name , id 
                                FROM tbl_coa_level_" + (currLvl + 1) + " WHERE main_id = @parentId ORDER BY code",
                            DBClass.CreateParameter("parentId", parentId)))
                        {
                            int insertIndex = rowIndex + 1;
                            if (reportType == "standard" || reportType == "Unclassified")
                                if (int.Parse(row.Cells["id"].Value.ToString()) > 0)
                                    dgvCustomer.Rows[rowIndex].Cells["balance"].Value = "";
                                else if (reportType == "YTD Comparison")
                                    if (int.Parse(row.Cells["id"].Value.ToString()) > 0)
                                        dgvCustomer.Rows[rowIndex].Cells["balance1"].Value = dgvCustomer.Rows[rowIndex].Cells["balance2"].Value = "";
                                    else if (reportType == "by Class")
                                        if (int.Parse(row.Cells["id"].Value.ToString()) > 0)
                                            dgvCustomer.Rows[rowIndex].Cells["balance"].Value = dgvCustomer.Rows[rowIndex].Cells["balance1"].Value = "";

                            while (reader.Read())
                            {
                                string nextState = (currLvl + 1 == 4) ? "n" : "e";
                                string nextIcon = (currLvl + 1 == 4) ? "  " : "►";

                                var newRow = new DataGridViewRow();
                                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = nextState });
                                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = "u" });
                                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = currLvl + 1 });
                                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = space + nextIcon + "     " + reader["name"].ToString() });
                                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = reader["id"].ToString() });
                                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = reader["currname"].ToString() });
                                if (reportType == "YTD Comparison")
                                {
                                    var balanceData = GetBalanceData(currLvl + 1, reader["currname"].ToString(), dtFrom.Value, dtTo.Value, prevFrom, prevTo);
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balanceData.balance1) });
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balanceData.balance2) });
                                }
                                else if (reportType == "standard" || reportType == "Unclassified")
                                {
                                    var balanceData = GetBalanceData(currLvl + 1, reader["currname"].ToString());
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balanceData) });
                                }
                                else if (reportType == "Prev Year Comparison")
                                {
                                    var balanceData = GetBalanceData(currLvl + 1, reader["currname"].ToString(), dtFrom.Value, dtTo.Value, prevFrom, prevTo);
                                    decimal balance1 = balanceData.balance1;
                                    decimal balance2 = balanceData.balance2;
                                    decimal change = balance1 - balance2;
                                    decimal percentChange = (balance2 != 0) ? (change / balance2) * 100 : 0;
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balance1) });
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balance2) });
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(change) });
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = $"{percentChange:N1}%" });
                                }
                                else if (reportType == "by Class")
                                {
                                    var balanceData = GetBalanceData(currLvl + 1, reader["currname"].ToString());
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balanceData) });
                                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = Utilities.FormatDecimal(balanceData) });
                                }
                                newRow.Height = dgvCustomer.Rows[rowIndex].Height;

                                ApplyRowStyle(newRow, currLvl + 1);
                                newRows.Add(newRow);

                            }

                            foreach (var r in newRows)
                            {
                                dgvCustomer.Rows.Insert(insertIndex, r);
                                insertIndex++;
                            }
                        }

                        dgvCustomer.Rows[rowIndex].Cells["loadState"].Value = "l";
                    }
                    else
                    {
                        dgvCustomer.Rows[rowIndex].Cells["balance"].Value = "";
                        GetAllChildren(rowIndex);
                    }

                    dgvCustomer.Rows[rowIndex].Cells["lvl1"].Value = cellValue.Replace("►", "▼");
                    dgvCustomer.Rows[rowIndex].Cells["state"].Value = "c";
                }

                // Expand child rows recursively
                int currentRowLevel = int.Parse(row.Cells["currLvl"].Value.ToString());
                int nextIndex = rowIndex + 1;
                //while (nextIndex < dgvCustomer.Rows.Count)
                //{
                //    int childLvl = int.Parse(dgvCustomer.Rows[nextIndex].Cells["currLvl"].Value.ToString());
                //    if (childLvl <= currentRowLevel)
                //        break;

                //    if (dgvCustomer.Rows[nextIndex].Cells["state"].Value.ToString() == "e")
                //    {
                //        ExpandRowRecursively(nextIndex);
                //    }
                //    nextIndex++;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while expanding: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ApplyRowStyle(DataGridViewRow row, int level)
        {
            //if (level == 2)
            //    row.DefaultCellStyle.BackColor = row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            //else if (level == 3)
            //    row.DefaultCellStyle.BackColor = row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gainsboro;
            //else
            //    row.DefaultCellStyle.BackColor = row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
        }
        private decimal GetBalance(string name)
        {
            if (balanceCache.TryGetValue(name, out decimal balance))
                return balance;

            return 0;
        }
        private string GetBalanceData(int level, string name)
        {
            return (balanceCache.TryGetValue(name, out var val) ? val : 0).ToString();
        }
        private string GetBalanceData0(int level, string name)
        {
            using (MySqlDataReader read = DBClass.ExecuteReader($@"SELECT 
                            t1.name AS level1_name, 
                            t2.name AS level2_name, 
                            t3.name AS level3_name, 
                            t4.name AS level4_name, 
                            t1.id AS level1_id, 
                            t2.id AS level2_id, 
                            t3.id AS level3_id, 
                            t4.id AS level4_id,

                            -- Balance for Level 1 (Summing all child transactions)
                            (SELECT COALESCE(SUM(tt.debit) - SUM(tt.credit), 0) 
                             FROM tbl_transaction tt
                             WHERE tt.account_id IN (
                                 SELECT id FROM tbl_coa_level_4 
                                 WHERE main_id IN (SELECT id FROM tbl_coa_level_3 
                                                  WHERE main_id IN (SELECT id FROM tbl_coa_level_2 
                                                                   WHERE main_id = t1.id))
                             ) AND tt.date BETWEEN @fromDate AND @toDate
                            ) AS level1_balance,

                            -- Balance for Level 2 (Summing its child transactions)
                            (SELECT COALESCE(SUM(tt.debit) - SUM(tt.credit), 0) 
                             FROM tbl_transaction tt
                             WHERE tt.account_id IN (
                                 SELECT id FROM tbl_coa_level_4 
                                 WHERE main_id IN (SELECT id FROM tbl_coa_level_3 
                                                  WHERE main_id = t2.id)
                             ) AND tt.date BETWEEN @fromDate AND @toDate
                            ) AS level2_balance,

                            -- Balance for Level 3 (Summing only Level 4 transactions)
                            (SELECT COALESCE(SUM(tt.debit) - SUM(tt.credit), 0) 
                             FROM tbl_transaction tt
                             WHERE tt.account_id IN (
                                 SELECT id FROM tbl_coa_level_4 
                                 WHERE main_id = t3.id
                             ) AND tt.date BETWEEN @fromDate AND @toDate
                            ) AS level3_balance,

                            -- Balance for Level 4 (Direct transactions only)
                            COALESCE(SUM(tt.debit) - SUM(tt.credit), 0) AS level4_balance

                        FROM tbl_coa_level_1 t1
                        LEFT JOIN tbl_coa_level_2 t2 ON t2.main_id = t1.id
                        LEFT JOIN tbl_coa_level_3 t3 ON t3.main_id = t2.id
                        LEFT JOIN tbl_coa_level_4 t4 ON t4.main_id = t3.id
                        LEFT JOIN tbl_transaction tt ON tt.account_id = t4.id AND tt.date BETWEEN @fromDate AND @toDate 

                        WHERE t1.category_code IN ('Income', 'Cost', 'EXPENSE') AND t{level}.name = @name

                        GROUP BY t1.id, t2.id, t3.id, t4.id;
                        ", DBClass.CreateParameter("name", name), DBClass.CreateParameter("fromDate", dtFrom.Value.Date), DBClass.CreateParameter("toDate", dtTo.Value.Date)))
            {
                if (read.Read())
                {
                    return read[$"level{level}_balance"].ToString();
                }
            }

            return null;
        }
        
        private (decimal balance1, decimal balance2) GetBalanceData(int level, string name, DateTime currentFrom, DateTime currentTo, DateTime previousFrom, DateTime previousTo)
        {
            using (MySqlDataReader read = DBClass.ExecuteReader($@"
                    SELECT
                        -- Balance for current period
                        (SELECT COALESCE(SUM(tt.debit) - SUM(tt.credit),0)
                         FROM tbl_transaction tt
                         WHERE tt.account_id IN (
                             SELECT id FROM tbl_coa_level_4 
                             WHERE main_id IN (
                                 SELECT id FROM tbl_coa_level_3 
                                 WHERE main_id IN (
                                     SELECT id FROM tbl_coa_level_2 
                                     WHERE main_id = t1.id
                                 )
                             )
                         ) AND tt.date BETWEEN @currFrom AND @currTo
                        ) AS balance1,

                        -- Balance for previous period
                        (SELECT COALESCE(SUM(tt.debit) - SUM(tt.credit),0)
                         FROM tbl_transaction tt
                         WHERE tt.account_id IN (
                             SELECT id FROM tbl_coa_level_4 
                             WHERE main_id IN (
                                 SELECT id FROM tbl_coa_level_3 
                                 WHERE main_id IN (
                                     SELECT id FROM tbl_coa_level_2 
                                     WHERE main_id = t1.id
                                 )
                             )
                         ) AND tt.date BETWEEN @prevFrom AND @prevTo
                        ) AS balance2

                    FROM tbl_coa_level_1 t1
                    LEFT JOIN tbl_coa_level_2 t2 ON t2.main_id = t1.id
                    LEFT JOIN tbl_coa_level_3 t3 ON t3.main_id = t2.id
                    LEFT JOIN tbl_coa_level_4 t4 ON t4.main_id = t3.id
                    WHERE t{level}.name = @name
                    GROUP BY t1.id, t2.id, t3.id, t4.id;
                ",
                DBClass.CreateParameter("name", name),
                DBClass.CreateParameter("currFrom", currentFrom),
                DBClass.CreateParameter("currTo", currentTo),
                DBClass.CreateParameter("prevFrom", previousFrom),
                DBClass.CreateParameter("prevTo", previousTo)
            ))
            {
                if (read.Read())
                {
                    decimal b1 = Convert.ToDecimal(read["balance1"]);
                    decimal b2 = Convert.ToDecimal(read["balance2"]);
                    return (b1, b2);
                }
            }
            return (0, 0);
        }

        private void GetAllChildren(int parentRowIndex)
        {
            int parentLevel = int.Parse(dgvCustomer.Rows[parentRowIndex].Cells["currLvl"].Value.ToString());

            for (int i = parentRowIndex + 1; i < dgvCustomer.Rows.Count; i++)
            {
                int rowLevel = int.Parse(dgvCustomer.Rows[i].Cells["currLvl"].Value.ToString());

                if (rowLevel > parentLevel)
                {
                    if (rowLevel == parentLevel + 1)
                    {
                        dgvCustomer.Rows[i].Visible = true;
                        if (dgvCustomer.Rows[i].Cells["state"].Value.ToString() == "c")
                            GetAllChildren(i);
                    }
                    else
                        continue;
                }
                else
                    break;
            }

        }

        private void addColumns()
        {
            dgvCustomer.Columns.Clear();

            dgvCustomer.Columns.Add("id", "ID");
            dgvCustomer.Columns.Add("currLvl", "Level");
            dgvCustomer.Columns.Add("currname", "Name");
            dgvCustomer.Columns.Add("lvl1", "Account");
            dgvCustomer.Columns.Add("balance", "Balance");
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["currLvl"].Visible = false;
            dgvCustomer.Columns["currname"].Visible = false;
            dgvCustomer.Columns["lvl1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["balance"].Width = 80;

            dgvCustomer.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns["lvl1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["balance"].HeaderCell.Style.Format = "N2";
        }

        DateTime prevFrom;
        DateTime prevTo;
        private void dateChangeTo()
        {
            if (reportType == "Prev Year Comparison" || reportType == "by Job" || reportType == "by class")
            {
                dtFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            }
            prevFrom = new DateTime(dtFrom.Value.Year, 1, 1);
            prevTo = new DateTime(dtTo.Value.Year, dtTo.Value.Month, DateTime.DaysInMonth(dtTo.Value.Year, dtTo.Value.Month));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //
        }
        private void SavePDF_Click(object sender, EventArgs e)
        {
            //
        }
        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
        }
        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //LoadReport();

            BindDGV_Data();
        }

        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            //
        }

        private ProfitLossRenderer renderer;
        private ProfitLossReportEngine engine;

        private void LoadReport()
        {
            //engine = new FinancialReportEngine(
            //    dtFrom.Value.Date,
            //    dtTo.Value.Date);

            //engine.Load();

            //engine.BuildProfitLoss();

            //renderer = new FinancialRenderer(dgvCustomer);
            ////renderer.Render(engine);
            //renderer.Render(engine.Rows);
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //renderer.Toggle(e.RowIndex);
            if (e.RowIndex < 0)
                return;

            ReportRow row =
                dgvCustomer.Rows[e.RowIndex].Tag as ReportRow;

            if (row == null)
                return;

            engine.Toggle(row);

            renderer.Render(engine);
        }
        private void DateWords()
        {
            string fromDate = dtFrom.Value.ToString("MMMM dd, yyyy");
            string toDate = dtTo.Value.ToString("MMMM dd, yyyy");
            guna2HtmlLabel10.Text = $"{fromDate} through {toDate}";
        }
    }
}

public class CoaLevel1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryCode { get; set; }
}