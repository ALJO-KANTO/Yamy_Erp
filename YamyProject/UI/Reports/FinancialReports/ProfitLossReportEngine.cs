using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace YamyProject.UI.Reports.FinancialReports
{
    public class ProfitLossReportEngine
    {
        public List<COANode> Roots = new List<COANode>();
        public List<ReportRow> Rows = new List<ReportRow>();
        public Dictionary<int, decimal> Balances = new Dictionary<int, decimal>();
        public Dictionary<int, COANode> Level1Nodes = new Dictionary<int, COANode>();
        public Dictionary<int, COANode> Level2Nodes = new Dictionary<int, COANode>();
        public Dictionary<int, COANode> Level3Nodes = new Dictionary<int, COANode>();
        public Dictionary<int, COANode> Level4Nodes = new Dictionary<int, COANode>();

        public DateTime FromDate;
        public DateTime ToDate;
        public DateTime PreviousFromDate;
        public DateTime PreviousToDate;

        public ReportType ReportType { get; set; }

        public ProfitLossReportEngine(DateTime from, DateTime to)
        {
            FromDate = from;
            ToDate = to;
        }

        public void Load()
        {
            DateTime currentFrom = FromDate;
            DateTime currentTo = ToDate;

            DateTime previousFrom = FromDate;
            DateTime previousTo = ToDate;

            switch (ReportType)
            {
                case ReportType.YTDComparison:

                    // Current = Selected Period
                    currentFrom = FromDate;
                    currentTo = ToDate;

                    // Comparison = YTD
                    previousFrom = new DateTime(ToDate.Year, 1, 1);
                    previousTo = ToDate;

                    break;

                case ReportType.PreviousYearComparison:

                    currentFrom = FromDate;
                    currentTo = ToDate;

                    previousFrom = FromDate.AddYears(-1);
                    previousTo = ToDate.AddYears(-1);

                    break;

                case ReportType.ByJob:
                case ReportType.ByClass:

                    currentFrom = FromDate;
                    currentTo = ToDate;

                    break;

                default:

                    currentFrom = FromDate;
                    currentTo = ToDate;

                    break;
            }

            LoadChartOfAccounts();
            ResetBalances();

            LoadBalances(currentFrom, currentTo, BalanceType.Current);
            
            if (ReportType != ReportType.Standard &&
                ReportType != ReportType.Unclassified)
            {
                LoadBalances(previousFrom, previousTo, BalanceType.Previous);
            }
            CalculateTreeTotals();

        }
        private void ResetBalances()
        {
            foreach (var node in Level4Nodes.Values)
            {
                node.CurrentBalance = 0;
                node.PreviousBalance = 0;
                node.TotalCurrent = 0;
                node.TotalPrevious = 0;
            }
        }
        private void LoadChartOfAccounts()
        {
            Level1Nodes.Clear();
            Level2Nodes.Clear();
            Level3Nodes.Clear();
            Level4Nodes.Clear();
            Roots.Clear();

            string sql = @"
                    SELECT
                        l4.id,
                        l4.main_id parent,
                        l4.code,
                        l4.name,
                        '' category_code,
                        4 level
                    FROM tbl_coa_level_4 l4

                    UNION ALL

                    SELECT
                        l3.id,
                        l3.main_id,
                        l3.code,
                        l3.name,
                        '' category_code,
                        3 level
                    FROM tbl_coa_level_3 l3

                    UNION ALL

                    SELECT
                        l2.id,
                        l2.main_id,
                        l2.code,
                        l2.name,
                        '' category_code,
                        2 level
                    FROM tbl_coa_level_2 l2

                    UNION ALL

                    SELECT
                        l1.id,
                        0,
                        l1.code,
                        l1.name,
                        l1.category_code,
                        1 level
                    FROM tbl_coa_level_1 l1

                    ORDER BY level,code";

            using (MySqlDataReader rd = DBClass.ExecuteReader(sql))
            {
                while (rd.Read())
                {
                    COANode node = new COANode();

                    node.Id = Convert.ToInt32(rd["id"]);
                    node.ParentId = Convert.ToInt32(rd["parent"]);
                    node.Code = rd["code"].ToString();
                    node.Name = rd["name"].ToString();
                    node.Level = Convert.ToInt32(rd["level"]);
                    node.Category = rd["category_code"].ToString();
                    //node.Type = NodeType.Account;

                    switch (node.Level)
                    {
                        case 1:
                            Level1Nodes.Add(node.Id, node);
                            break;

                        case 2:
                            Level2Nodes.Add(node.Id, node);
                            break;

                        case 3:
                            Level3Nodes.Add(node.Id, node);
                            break;

                        case 4:
                            Level4Nodes.Add(node.Id, node);
                            break;
                    }
                }
            }

            // Level1 -> Roots
            foreach (COANode node in Level1Nodes.Values)
            {
                Roots.Add(node);
            }

            // Level2 -> Level1
            foreach (COANode node in Level2Nodes.Values)
            {
                if (Level1Nodes.TryGetValue(node.ParentId, out COANode parent))
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }

            // Level3 -> Level2
            foreach (COANode node in Level3Nodes.Values)
            {
                if (Level2Nodes.TryGetValue(node.ParentId, out COANode parent))
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }

            // Level4 -> Level3
            foreach (COANode node in Level4Nodes.Values)
            {
                if (Level3Nodes.TryGetValue(node.ParentId, out COANode parent))
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }
        }

        private void LoadBalances(DateTime from, DateTime to, BalanceType type)
        {
            string sql = @"
                    SELECT
                        t.account_id,
                        CASE
                            WHEN l1.category_code='Income'
                                THEN COALESCE(SUM(t.credit)-SUM(t.debit),0)
                            ELSE
                                COALESCE(SUM(t.debit)-SUM(t.credit),0)
                        END Balance
                    FROM tbl_transaction t
                    INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id
                    WHERE t.date BETWEEN @from AND @to
                    GROUP BY t.account_id, l1.category_code";

            // IMPORTANT: reset per load (prevents mixing current/previous)
            Balances.Clear();

            using (MySqlDataReader rd =
                DBClass.ExecuteReader(
                    sql,
                    DBClass.CreateParameter("from", from),
                    DBClass.CreateParameter("to", to)))
            {
                while (rd.Read())
                {
                    int accountId = Convert.ToInt32(rd["account_id"]);
                    decimal balance = Convert.ToDecimal(rd["Balance"]);

                    Balances[accountId] = balance;
                }
            }

            foreach (COANode node in Level4Nodes.Values)
            {
                if (Balances.TryGetValue(node.Id, out decimal bal))
                {
                    switch (type)
                    {
                        case BalanceType.Current:
                            node.CurrentBalance = bal;
                            break;

                        case BalanceType.Previous:
                            node.PreviousBalance = bal;
                            break;
                    }
                }
                else
                {
                    if (type == BalanceType.Current)
                        node.CurrentBalance = 0;
                    else
                        node.PreviousBalance = 0;
                }
            }
        }
        private void CalculateTreeTotals()
        {
            foreach (var root in Roots)
            {
                CalculateNode(root);
            }
        }

        private void CalculateNode(COANode node)
        {
            decimal current = node.CurrentBalance;
            decimal previous = node.PreviousBalance;

            foreach (var child in node.Children)
            {
                CalculateNode(child); // IMPORTANT: calculate child first

                current += child.TotalCurrent;
                previous += child.TotalPrevious;
            }

            node.TotalCurrent = current;
            node.TotalPrevious = previous;
        }
        private void AddNode(COANode node)
        {
            foreach (COANode child in node.Children.OrderBy(x => x.Code))
            {
                Rows.Add(new ReportRow()
                {
                    Node = child,
                    Text = child.Code + " - " + child.Name,
                    Balance = child.TotalCurrent,
                    Balance2 = child.TotalPrevious,
                    Expanded = child.Expanded,
                    Level = child.Level
                });

                if (child.Expanded)
                    AddNode(child);
            }
        }
        public void BuildProfitLossStandard()
        {
            Rows.Clear();

            decimal income = 0;
            decimal cost = 0;
            decimal expense = 0;

            foreach (var root in Roots.OrderBy(x => x.Code))
            {
                string cat = root.Category.ToUpper();

                if (cat != "INCOME" && cat != "COST" && cat != "EXPENSE")
                    continue;

                AddSection(root);

                switch (cat)
                {
                    case "INCOME":
                        income += root.TotalCurrent;
                        AddTotal("Total Income", income);
                        break;

                    case "COST":
                        cost += root.TotalCurrent;
                        AddFormula("Gross Profit", income - cost);
                        break;

                    case "EXPENSE":
                        expense += root.TotalCurrent;
                        AddTotal("Total Expenses", expense);
                        break;
                }
            }

            AddFormula("NET PROFIT", income - cost - expense);
        }

        public void BuildProfitLossYTDComparison()
        {
            Rows.Clear();

            decimal incomeCurrent = 0;
            decimal incomePrevious = 0;

            decimal costCurrent = 0;
            decimal costPrevious = 0;

            decimal expenseCurrent = 0;
            decimal expensePrevious = 0;

            foreach (COANode root in Roots.OrderBy(x => x.Code))
            {
                string category = root.Category.ToUpper();

                if (category != "INCOME" &&
                    category != "COST" &&
                    category != "EXPENSE")
                    continue;

                AddComparisonSection(root);

                switch (category)
                {
                    case "INCOME":

                        incomeCurrent += root.TotalCurrent;
                        incomePrevious += root.TotalPrevious;

                        AddComparisonTotal(
                            "Total Income",
                            incomeCurrent,
                            incomePrevious);

                        break;

                    case "COST":

                        costCurrent += root.TotalCurrent;
                        costPrevious += root.TotalPrevious;

                        AddComparisonFormula(
                            "Gross Profit",
                            incomeCurrent - costCurrent,
                            incomePrevious - costPrevious);

                        break;

                    case "EXPENSE":

                        expenseCurrent += root.CurrentBalance;
                        expensePrevious += root.PreviousBalance;

                        AddComparisonTotal(
                            "Total Expenses",
                            expenseCurrent,
                            expensePrevious);

                        break;
                }
            }

            AddComparisonFormula(
                "NET PROFIT",
                incomeCurrent - costCurrent - expenseCurrent,
                incomePrevious - costPrevious - expensePrevious);
        }

        private void AddComparisonSection(COANode root)
        {
            Rows.Add(new ReportRow
            {
                Node = root,
                Text = root.Name.ToUpper(),
                Level = 0,
                Expanded = root.Expanded,
                IsHeader = true,
                Balance = root.TotalCurrent,
                Balance2 = root.TotalPrevious
            });

            if (root.Expanded)
                AddComparisonNode(root);
        }
        private void AddComparisonNode(COANode node)
        {
            foreach (COANode child in node.Children.OrderBy(x => x.Code))
            {
                Rows.Add(new ReportRow
                {
                    Node = child,
                    Text = child.Code + " - " + child.Name,
                    Level = child.Level,
                    Expanded = child.Expanded,
                    Balance = child.TotalCurrent,
                    Balance2 = child.TotalPrevious
                });

                if (child.Expanded)
                    AddComparisonNode(child);
            }
        }

        public void BuildProfitLossPreviousYear()
        {
            Rows.Clear();

            decimal incomeCurrent = 0;
            decimal incomePrevious = 0;

            decimal costCurrent = 0;
            decimal costPrevious = 0;

            decimal expenseCurrent = 0;
            decimal expensePrevious = 0;

            foreach (COANode root in Roots.OrderBy(x => x.Code))
            {
                string category = root.Category.ToUpper();

                if (category != "INCOME" &&
                    category != "COST" &&
                    category != "EXPENSE")
                    continue;

                AddComparisonSection(root);

                switch (category)
                {
                    case "INCOME":

                        incomeCurrent += root.TotalCurrent;
                        incomePrevious += root.TotalPrevious;

                        AddComparisonTotal(
                            "Total Income",
                            incomeCurrent,
                            incomePrevious);

                        break;

                    case "COST":

                        costCurrent += root.TotalCurrent;
                        costPrevious += root.TotalPrevious;

                        AddComparisonFormula(
                            "Gross Profit",
                            incomeCurrent - costCurrent,
                            incomePrevious - costPrevious);

                        break;

                    case "EXPENSE":

                        // <-- use TotalCurrent/TotalPrevious
                        expenseCurrent += root.TotalCurrent;
                        expensePrevious += root.TotalPrevious;

                        AddComparisonTotal(
                            "Total Expenses",
                            expenseCurrent,
                            expensePrevious);

                        break;
                }
            }

            AddComparisonFormula(
                "NET PROFIT",
                incomeCurrent - costCurrent - expenseCurrent,
                incomePrevious - costPrevious - expensePrevious);
        }

        public void BuildProfitLossByJob()
        {
            Rows.Clear();

            string sql = @"
                    SELECT
                        c.id,
                        c.name JobName,
                        SUM(
                            CASE
                                WHEN UPPER(l1.category_code)='INCOME'
                                THEN t.credit-t.debit
                                ELSE 0
                            END
                        ) Income,
                        SUM(
                            CASE
                                WHEN UPPER(l1.category_code)='COST'
                                THEN t.debit-t.credit
                                ELSE 0
                            END
                        ) Cost,
                        SUM(
                            CASE
                                WHEN UPPER(l1.category_code)='EXPENSE'
                                THEN t.debit-t.credit
                                ELSE 0
                            END
                        ) Expense
                    FROM tbl_customer c
                    INNER JOIN tbl_transaction t
                        ON t.hum_id=c.id
                    INNER JOIN tbl_coa_level_4 l4
                        ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3
                        ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2
                        ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1
                        ON l1.id=l2.main_id
                    WHERE t.date BETWEEN @from AND @to
                    GROUP BY c.id,c.name
                    ORDER BY c.name
                ";

            decimal totalProfit = 0;

            using (MySqlDataReader rd =
                DBClass.ExecuteReader(
                    sql,
                    DBClass.CreateParameter("from", FromDate),
                    DBClass.CreateParameter("to", ToDate)))
            {

                while (rd.Read())
                {

                    decimal income =
                        Convert.ToDecimal(rd["Income"]);

                    decimal cost =
                        Convert.ToDecimal(rd["Cost"]);

                    decimal expense =
                        Convert.ToDecimal(rd["Expense"]);



                    Rows.Add(new ReportRow
                    {
                        Text = rd["JobName"].ToString(),
                        IsHeader = true,
                        Level = 0
                    });


                    Rows.Add(new ReportRow
                    {
                        Text = "Income",
                        Balance = income,
                        Level = 1
                    });


                    Rows.Add(new ReportRow
                    {
                        Text = "Cost",
                        Balance = cost,
                        Level = 1
                    });


                    Rows.Add(new ReportRow
                    {
                        Text = "Expense",
                        Balance = expense,
                        Level = 1
                    });


                    decimal profit =
                        income - cost - expense;


                    Rows.Add(new ReportRow
                    {
                        Text = "Profit",
                        Balance = profit,
                        IsFormula = true
                    });


                    totalProfit += profit;
                }
            }


            AddFormula(
                "TOTAL PROFIT",
                totalProfit
            );
        }
        public void BuildProfitLossByClass()
        {
            Rows.Clear();


            foreach (COANode root in Roots.OrderBy(x => x.Code))
            {
                string category = root.Category.ToUpper();


                if (category != "INCOME" &&
                   category != "COST" &&
                   category != "EXPENSE")
                    continue;


                Rows.Add(new ReportRow
                {
                    Node = root,
                    Text = root.Name.ToUpper(),
                    Level = 0,
                    IsHeader = true,
                    Balance = root.TotalCurrent
                });


                if (root.Expanded)
                    AddNode(root);
            }


            decimal income = 0;
            decimal cost = 0;
            decimal expense = 0;


            foreach (COANode root in Roots)
            {
                switch (root.Category.ToUpper())
                {
                    case "INCOME":
                        income += root.TotalCurrent;
                        break;

                    case "COST":
                        cost += root.TotalCurrent;
                        break;

                    case "EXPENSE":
                        expense += root.TotalCurrent;
                        break;
                }
            }


            AddFormula(
                "NET PROFIT",
                income - cost - expense
            );
        }
        public void BuildProfitLossUnclassified()
        {
            Rows.Clear();

            decimal income = 0;
            decimal cost = 0;
            decimal expense = 0;

            foreach (COANode root in Roots.OrderBy(x => x.Code))
            {
                string category = root.Category.ToUpper();

                if (category != "INCOME" &&
                    category != "COST" &&
                    category != "EXPENSE")
                    continue;

                AddSection(root);

                switch (category)
                {
                    case "INCOME":
                        income += root.TotalCurrent;
                        AddTotal("Total Income", income);
                        break;

                    case "COST":
                        cost += root.TotalCurrent;
                        AddFormula("Gross Profit", income - cost);
                        break;

                    case "EXPENSE":
                        expense += root.TotalCurrent;
                        AddTotal("Total Expenses", expense);
                        break;
                }
            }

            AddFormula("NET PROFIT", income - cost - expense);
        }

        public void BuildReport(ReportType type)
        {
            switch (type)
            {
                case ReportType.Standard:
                    BuildProfitLossStandard();
                    break;
                case ReportType.YTDComparison:
                    BuildProfitLossYTDComparison();
                    break;
                case ReportType.PreviousYearComparison:
                    BuildProfitLossPreviousYear();
                    break;
                case ReportType.ByJob:
                    BuildProfitLossByJob();
                    break;
                case ReportType.ByClass:
                    BuildProfitLossByClass();
                    break;
                case ReportType.Unclassified:
                    BuildProfitLossUnclassified();
                    break;
            }
        }
        private void AddSection(COANode root)
        {
            Rows.Add(new ReportRow
            {
                Node = root,
                Text = root.Name.ToUpper(),
                Balance = root.TotalCurrent,
                Balance2 = root.TotalPrevious,
                Expanded = root.Expanded,
                Level = 0,
                IsHeader = true
            });

            if (root.Expanded)
                AddNode(root);
        }
        private void AddTotal(string text, decimal balance)
        {
            Rows.Add(new ReportRow
            {
                Text = text,
                Balance = balance,
                IsTotal = true
            });
        }
        private void AddFormula(string text, decimal balance)
        {
            Rows.Add(new ReportRow
            {
                Text = text,
                Balance = balance,
                IsFormula = true
            });
        }
        private void AddComparisonTotal(string text,
                                decimal current,
                                decimal previous)
        {
            Rows.Add(new ReportRow
            {
                Text = text,
                Balance = current,
                Balance2 = previous,
                IsTotal = true
            });
        }
        private void AddComparisonFormula(string text,
                                  decimal current,
                                  decimal previous)
        {
            Rows.Add(new ReportRow
            {
                Text = text,
                Balance = current,
                Balance2 = previous,
                IsFormula = true
            });
        }

        public void Toggle(ReportRow row)
        {
            if (row.Node == null)
                return;

            row.Node.Expanded = !row.Node.Expanded;

            BuildReport(ReportType);
        }
    }
}

//namespace YamyProject.UI.Reports.FinancialReports
//{
//    public class ProfitLossReportEngine
//    {
//        public List<COANode> Roots = new List<COANode>();
//        public List<ReportRow> Rows = new List<ReportRow>();
//        public Dictionary<int, decimal> Balances = new Dictionary<int, decimal>();
//        public Dictionary<int, COANode> Level1Nodes = new Dictionary<int, COANode>();
//        public Dictionary<int, COANode> Level2Nodes = new Dictionary<int, COANode>();
//        public Dictionary<int, COANode> Level3Nodes = new Dictionary<int, COANode>();
//        public Dictionary<int, COANode> Level4Nodes = new Dictionary<int, COANode>();

//        public DateTime FromDate;
//        public DateTime ToDate;
//        public DateTime PreviousFromDate;
//        public DateTime PreviousToDate;

//        public ReportType ReportType { get; set; }

//        public ProfitLossReportEngine(DateTime from, DateTime to)
//        {
//            FromDate = from;
//            ToDate = to;
//            if (ReportType == ReportType.PreviousYearComparison || ReportType == ReportType.ByJob || ReportType == ReportType.ByClass)
//            {
//                FromDate = new DateTime(DateTime.Now.Year, 1, 1);
//            }
//            PreviousFromDate = new DateTime(FromDate.Year, 1, 1);
//            PreviousToDate = new DateTime(ToDate.Year, ToDate.Month, DateTime.DaysInMonth(ToDate.Year, ToDate.Month));
//        }

//        public void Load()
//        {
//            LoadChartOfAccounts();
//            ResetBalances();
//            LoadBalances(FromDate, ToDate, BalanceType.Current);
//            LoadBalances(PreviousFromDate, PreviousToDate, BalanceType.Previous);
//            CalculateTreeTotals();
//        }
//        private void ResetBalances()
//        {
//            foreach (var node in Level4Nodes.Values)
//            {
//                node.CurrentBalance = 0;
//                node.PreviousBalance = 0;
//                node.TotalCurrent = 0;
//                node.TotalPrevious = 0;
//            }
//        }
//        private void LoadChartOfAccounts()
//        {
//            Level1Nodes.Clear();
//            Level2Nodes.Clear();
//            Level3Nodes.Clear();
//            Level4Nodes.Clear();
//            Roots.Clear();

//            string sql = @"
//                    SELECT
//                        l4.id,
//                        l4.main_id parent,
//                        l4.code,
//                        l4.name,
//                        '' category_code,
//                        4 level
//                    FROM tbl_coa_level_4 l4

//                    UNION ALL

//                    SELECT
//                        l3.id,
//                        l3.main_id,
//                        l3.code,
//                        l3.name,
//                        '' category_code,
//                        3 level
//                    FROM tbl_coa_level_3 l3

//                    UNION ALL

//                    SELECT
//                        l2.id,
//                        l2.main_id,
//                        l2.code,
//                        l2.name,
//                        '' category_code,
//                        2 level
//                    FROM tbl_coa_level_2 l2

//                    UNION ALL

//                    SELECT
//                        l1.id,
//                        0,
//                        l1.code,
//                        l1.name,
//                        l1.category_code,
//                        1 level
//                    FROM tbl_coa_level_1 l1

//                    ORDER BY level,code";

//            using (MySqlDataReader rd = DBClass.ExecuteReader(sql))
//            {
//                while (rd.Read())
//                {
//                    COANode node = new COANode();

//                    node.Id = Convert.ToInt32(rd["id"]);
//                    node.ParentId = Convert.ToInt32(rd["parent"]);
//                    node.Code = rd["code"].ToString();
//                    node.Name = rd["name"].ToString();
//                    node.Level = Convert.ToInt32(rd["level"]);
//                    node.Category = rd["category_code"].ToString();
//                    //node.Type = NodeType.Account;

//                    switch (node.Level)
//                    {
//                        case 1:
//                            Level1Nodes.Add(node.Id, node);
//                            break;

//                        case 2:
//                            Level2Nodes.Add(node.Id, node);
//                            break;

//                        case 3:
//                            Level3Nodes.Add(node.Id, node);
//                            break;

//                        case 4:
//                            Level4Nodes.Add(node.Id, node);
//                            break;
//                    }
//                }
//            }

//            // Level1 -> Roots
//            foreach (COANode node in Level1Nodes.Values)
//            {
//                Roots.Add(node);
//            }

//            // Level2 -> Level1
//            foreach (COANode node in Level2Nodes.Values)
//            {
//                if (Level1Nodes.TryGetValue(node.ParentId, out COANode parent))
//                {
//                    node.Parent = parent;
//                    parent.Children.Add(node);
//                }
//            }

//            // Level3 -> Level2
//            foreach (COANode node in Level3Nodes.Values)
//            {
//                if (Level2Nodes.TryGetValue(node.ParentId, out COANode parent))
//                {
//                    node.Parent = parent;
//                    parent.Children.Add(node);
//                }
//            }

//            // Level4 -> Level3
//            foreach (COANode node in Level4Nodes.Values)
//            {
//                if (Level3Nodes.TryGetValue(node.ParentId, out COANode parent))
//                {
//                    node.Parent = parent;
//                    parent.Children.Add(node);
//                }
//            }
//        }

//        private void LoadBalances(DateTime from, DateTime to, BalanceType type)
//        {
//            string sql = @"
//        SELECT
//            t.account_id,
//            CASE
//                WHEN l1.category_code='Income'
//                    THEN COALESCE(SUM(t.credit)-SUM(t.debit),0)
//                ELSE
//                    COALESCE(SUM(t.debit)-SUM(t.credit),0)
//            END Balance
//        FROM tbl_transaction t
//        INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
//        INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
//        INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
//        INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id
//        WHERE t.date BETWEEN @from AND @to
//        GROUP BY t.account_id, l1.category_code";

//            // IMPORTANT: reset per load (prevents mixing current/previous)
//            Balances.Clear();

//            using (MySqlDataReader rd =
//                DBClass.ExecuteReader(
//                    sql,
//                    DBClass.CreateParameter("from", from),
//                    DBClass.CreateParameter("to", to)))
//            {
//                while (rd.Read())
//                {
//                    int accountId = Convert.ToInt32(rd["account_id"]);
//                    decimal balance = Convert.ToDecimal(rd["Balance"]);

//                    Balances[accountId] = balance;
//                }
//            }

//            foreach (COANode node in Level4Nodes.Values)
//            {
//                if (Balances.TryGetValue(node.Id, out decimal bal))
//                {
//                    switch (type)
//                    {
//                        case BalanceType.Current:
//                            node.CurrentBalance = bal;
//                            break;

//                        case BalanceType.Previous:
//                            node.PreviousBalance = bal;
//                            break;
//                    }
//                }
//                else
//                {
//                    if (type == BalanceType.Current)
//                        node.CurrentBalance = 0;
//                    else
//                        node.PreviousBalance = 0;
//                }
//            }
//        }
//        private void CalculateTreeTotals()
//        {
//            foreach (var root in Roots)
//            {
//                CalculateNode(root);
//            }
//        }

//        private void CalculateNode(COANode node)
//        {
//            decimal current = node.CurrentBalance;
//            decimal previous = node.PreviousBalance;

//            foreach (var child in node.Children)
//            {
//                CalculateNode(child); // IMPORTANT: calculate child first

//                current += child.TotalCurrent;
//                previous += child.TotalPrevious;
//            }

//            node.TotalCurrent = current;
//            node.TotalPrevious = previous;
//        }
//        private void AddNode(COANode node)
//        {
//            foreach (COANode child in node.Children.OrderBy(x => x.Code))
//            {
//                Rows.Add(new ReportRow()
//                {
//                    Node = child,
//                    Text = child.Code + " - " + child.Name,
//                    Balance = child.TotalCurrent,
//                    Balance2 = child.TotalPrevious,
//                    Expanded = child.Expanded,
//                    Level = child.Level
//                });

//                if (child.Expanded)
//                    AddNode(child);
//            }
//        }
//        public void BuildProfitLossStandard()
//        {
//            Rows.Clear();

//            decimal income = 0;
//            decimal cost = 0;
//            decimal expense = 0;

//            foreach (var root in Roots.OrderBy(x => x.Code))
//            {
//                string cat = root.Category.ToUpper();

//                if (cat != "INCOME" && cat != "COST" && cat != "EXPENSE")
//                    continue;

//                AddSection(root);

//                switch (cat)
//                {
//                    case "INCOME":
//                        income += root.TotalCurrent;
//                        AddTotal("Total Income", income);
//                        break;

//                    case "COST":
//                        cost += root.TotalCurrent;
//                        AddFormula("Gross Profit", income - cost);
//                        break;

//                    case "EXPENSE":
//                        expense += root.TotalCurrent;
//                        AddTotal("Total Expenses", expense);
//                        break;
//                }
//            }

//            AddFormula("NET PROFIT", income - cost - expense);
//        }

//        public void BuildProfitLossYTDComparison()
//        {
//            Rows.Clear();

//            decimal incomeCurrent = 0;
//            decimal incomePrevious = 0;

//            decimal costCurrent = 0;
//            decimal costPrevious = 0;

//            decimal expenseCurrent = 0;
//            decimal expensePrevious = 0;

//            foreach (COANode root in Roots.OrderBy(x => x.Code))
//            {
//                string category = root.Category.ToUpper();

//                if (category != "INCOME" &&
//                    category != "COST" &&
//                    category != "EXPENSE")
//                    continue;

//                AddComparisonSection(root);

//                switch (category)
//                {
//                    case "INCOME":

//                        incomeCurrent += root.CurrentBalance;
//                        incomePrevious += root.PreviousBalance;

//                        AddComparisonTotal(
//                            "Total Income",
//                            incomeCurrent,
//                            incomePrevious);

//                        break;

//                    case "COST":

//                        costCurrent += root.CurrentBalance;
//                        costPrevious += root.PreviousBalance;

//                        AddComparisonFormula(
//                            "Gross Profit",
//                            incomeCurrent - costCurrent,
//                            incomePrevious - costPrevious);

//                        break;

//                    case "EXPENSE":

//                        expenseCurrent += root.CurrentBalance;
//                        expensePrevious += root.PreviousBalance;

//                        AddComparisonTotal(
//                            "Total Expenses",
//                            expenseCurrent,
//                            expensePrevious);

//                        break;
//                }
//            }

//            AddComparisonFormula(
//                "NET PROFIT",
//                incomeCurrent - costCurrent - expenseCurrent,
//                incomePrevious - costPrevious - expensePrevious);
//        }

//        private void AddComparisonSection(COANode root)
//        {
//            Rows.Add(new ReportRow
//            {
//                Node = root,
//                Text = root.Name.ToUpper(),
//                Level = 0,
//                Expanded = root.Expanded,
//                IsHeader = true,

//                Balance = root.CurrentBalance,
//                Balance2 = root.PreviousBalance
//            });

//            if (root.Expanded)
//                AddComparisonNode(root);
//        }
//        private void AddComparisonNode(COANode node)
//        {
//            foreach (COANode child in node.Children.OrderBy(x => x.Code))
//            {
//                Rows.Add(new ReportRow
//                {
//                    Node = child,
//                    Text = child.Code + " - " + child.Name,
//                    Level = child.Level,
//                    Expanded = child.Expanded,

//                    Balance = child.CurrentBalance,
//                    Balance2 = child.PreviousBalance
//                });

//                if (child.Expanded)
//                    AddComparisonNode(child);
//            }
//        }

//        public void BuildProfitLossPreviousYear()
//        {
//            Rows.Clear();
//        }

//        public void BuildProfitLossByJob()
//        {
//            Rows.Clear();
//        }

//        public void BuildProfitLossByClass()
//        {
//            Rows.Clear();
//        }

//        public void BuildProfitLossUnclassified()
//        {
//            Rows.Clear();
//        }
//        public void BuildReport(ReportType type)
//        {
//            switch (type)
//            {
//                case ReportType.Standard:
//                    BuildProfitLossStandard();
//                    break;
//                case ReportType.YTDComparison:
//                    BuildProfitLossYTDComparison();
//                    break;
//                case ReportType.PreviousYearComparison:
//                    BuildProfitLossPreviousYear();
//                    break;
//                case ReportType.ByJob:
//                    BuildProfitLossByJob();
//                    break;
//                case ReportType.ByClass:
//                    BuildProfitLossByClass();
//                    break;
//                case ReportType.Unclassified:
//                    BuildProfitLossUnclassified();
//                    break;
//            }
//        }
//        private void AddSection(COANode root)
//        {
//            Rows.Add(new ReportRow
//            {
//                Node = root,
//                Text = root.Name.ToUpper(),
//                Balance = root.TotalCurrent,
//                Balance2 = root.TotalPrevious,
//                Expanded = root.Expanded,
//                Level = 0,
//                IsHeader = true
//            });

//            if (root.Expanded)
//                AddNode(root);
//        }
//        private void AddTotal(string text, decimal balance)
//        {
//            Rows.Add(new ReportRow
//            {
//                Text = text,
//                Balance = balance,
//                IsTotal = true
//            });
//        }
//        private void AddFormula(string text, decimal balance)
//        {
//            Rows.Add(new ReportRow
//            {
//                Text = text,
//                Balance = balance,
//                IsFormula = true
//            });
//        }
//        private void AddComparisonTotal(string text,
//                                decimal current,
//                                decimal previous)
//        {
//            Rows.Add(new ReportRow
//            {
//                Text = text,
//                Balance = current,
//                Balance2 = previous,
//                IsTotal = true
//            });
//        }
//        private void AddComparisonFormula(string text,
//                                  decimal current,
//                                  decimal previous)
//        {
//            Rows.Add(new ReportRow
//            {
//                Text = text,
//                Balance = current,
//                Balance2 = previous,
//                IsFormula = true
//            });
//        }

//        public void Toggle(ReportRow row)
//        {
//            if (row.Node == null)
//                return;

//            row.Node.Expanded = !row.Node.Expanded;

//            BuildReport(ReportType);
//        }
//    }
//}
