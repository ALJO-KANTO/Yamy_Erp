using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YamyProject.UI.Reports.FinancialReports.BalanceSheet
{
    public class BalanceSheetReportEngine
    {
        public List<ReportRowBS> Rows { get; set; } = new List<ReportRowBS>();
        public Dictionary<int, COANode> Level1Nodes = new Dictionary<int, COANode>();
        public Dictionary<int, COANode> Level2Nodes = new Dictionary<int, COANode>();
        public Dictionary<int, COANode> Level3Nodes = new Dictionary<int, COANode>();
        public Dictionary<int, COANode> Level4Nodes = new Dictionary<int, COANode>();
        public List<COANode> Roots = new List<COANode>();
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime PreviousFromDate { get; set; }
        public DateTime PreviousToDate { get; set; }
        public TypeReport Type { get; set; }
        public BalanceSheetReportEngine(DateTime fromDate, DateTime toDate)
        {
            FromDate = fromDate;
            ToDate = toDate;

            Rows = new List<ReportRowBS>();

            Level1Nodes = new Dictionary<int, COANode>();
            Level2Nodes = new Dictionary<int, COANode>();
            Level3Nodes = new Dictionary<int, COANode>();
            Level4Nodes = new Dictionary<int, COANode>();
        }
        public void Load()
        {
            Rows.Clear();
            LoadChartOfAccounts();
        }
        private void LoadChartOfAccounts()
        {

            Level1Nodes.Clear();
            Level2Nodes.Clear();
            Level3Nodes.Clear();
            Level4Nodes.Clear();

            Roots.Clear();

            string sql = @"
                    SELECT id, name, code, category_code, 1 level, 0 parent_id
                    FROM tbl_coa_level_1
                    UNION ALL
                    SELECT id, name, code, '', 2 level, main_id
                    FROM tbl_coa_level_2
                    UNION ALL
                    SELECT id, name, code, '', 3 level, main_id
                    FROM tbl_coa_level_3
                    UNION ALL
                    SELECT id, name, code, '', 4 level, main_id
                    FROM tbl_coa_level_4
                ";

            using (MySqlDataReader reader = DBClass.ExecuteReader(sql))
            {

                while (reader.Read())
                {

                    COANode node = new COANode()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Code = reader["code"].ToString(),
                        Level = Convert.ToInt32(reader["level"]),
                        ParentId = Convert.ToInt32(reader["parent_id"]),
                        Category = reader["category_code"].ToString(),
                        CategoryCode = reader["category_code"].ToString()
                    };

                    switch (node.Level)
                    {
                        case 1:
                            Level1Nodes[node.Id] = node;
                            Roots.Add(node);
                            break;


                        case 2:
                            Level2Nodes[node.Id] = node;
                            break;


                        case 3:
                            Level3Nodes[node.Id] = node;
                            break;


                        case 4:
                            Level4Nodes[node.Id] = node;
                            break;

                    }

                }
            }
            // Build Tree

            foreach (var node in Level2Nodes.Values)
            {
                if (Level1Nodes.ContainsKey(node.ParentId))
                    Level1Nodes[node.ParentId].Children.Add(node);
            }

            foreach (var node in Level3Nodes.Values)
            {
                if (Level2Nodes.ContainsKey(node.ParentId))
                    Level2Nodes[node.ParentId].Children.Add(node);
            }

            foreach (var node in Level4Nodes.Values)
            {
                if (Level3Nodes.ContainsKey(node.ParentId))
                    Level3Nodes[node.ParentId].Children.Add(node);
            }

        }

        public void BuildReport()
        {
            Rows.Clear();

            switch (Type)
            {
                case TypeReport.Standard:
                    BuildStandard();
                    break;
                case TypeReport.PreviousYearComparison:
                    BuildPreviousYear();
                    break;
                case TypeReport.ByClass:
                    BuildByClass();
                    break;
                case TypeReport.Detail:
                    BuildDetail();
                    break;
            }
        }

        decimal totalAssets = 0;
        decimal totalLiabilities = 0;
        decimal totalEquity = 0;

        private void BuildStandard()
        {
            totalAssets = 0;
            totalLiabilities = 0;
            totalEquity = 0;
            Rows.Clear();

            foreach (COANode root in Level1Nodes.Values.OrderBy(x => x.Code))
            {
                if (root.Category != "ASSET" &&
                    root.Category != "LIABILITY" &&
                    root.Category != "EQUITY")
                    continue;

                ReportRowBS row = BuildNode(root);

                switch (root.Category)
                {
                    case "ASSET":
                        totalAssets += row.Balance;
                        break;

                    case "LIABILITY":
                        totalLiabilities += row.Balance;
                        break;

                    case "EQUITY":
                        totalEquity += row.Balance;
                        break;
                }

                AddVisibleRows(row);
            }

            AddRetainedEarnings();

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL ASSETS",
                Balance = totalAssets
            });

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL LIABILITIES & EQUITY",
                Balance = totalLiabilities + totalEquity
            });
        }
        private void BuildPreviousYear()
        {
            totalAssets = 0;
            totalLiabilities = 0;
            totalEquity = 0;
            Rows.Clear();

            foreach (COANode root in Level1Nodes.Values.OrderBy(x => x.Code))
            {
                if (root.Category != "ASSET" &&
                    root.Category != "LIABILITY" &&
                    root.Category != "EQUITY")
                    continue;

                ReportRowBS row = BuildNodePrevious(root);

                switch (root.Category)
                {
                    case "ASSET":
                        totalAssets += row.Balance;
                        break;

                    case "LIABILITY":
                        totalLiabilities += row.Balance;
                        break;

                    case "EQUITY":
                        totalEquity += row.Balance;
                        break;
                }

                AddVisibleRows(row);
            }

            AddRetainedEarningsPrevious();

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL ASSETS",
                Balance = totalAssets
            });

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL LIABILITIES & EQUITY",
                Balance = totalLiabilities + totalEquity
            });
        }
        private void BuildDetail()
        {
            totalAssets = 0;
            totalLiabilities = 0;
            totalEquity = 0;
            Rows.Clear();

            foreach (COANode root in Level1Nodes.Values.OrderBy(x => x.Code))
            {
                if (root.Category != "ASSET" &&
                    root.Category != "LIABILITY" &&
                    root.Category != "EQUITY")
                    continue;

                ReportRowBS row = BuildNodeDetail(root);

                switch (root.Category)
                {
                    case "ASSET":
                        totalAssets += row.Balance;
                        break;

                    case "LIABILITY":
                        totalLiabilities += row.Balance;
                        break;

                    case "EQUITY":
                        totalEquity += row.Balance;
                        break;
                }

                AddVisibleRows(row);
            }

            AddRetainedEarningsDetail();

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL ASSETS",
                Balance = totalAssets
            });

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL LIABILITIES & EQUITY",
                Balance = totalLiabilities + totalEquity
            });
        }
        private void BuildByClass()
        {
            totalAssets = 0;
            totalLiabilities = 0;
            totalEquity = 0;
            Rows.Clear();

            foreach (COANode root in Level1Nodes.Values.OrderBy(x => x.Code))
            {
                if (root.Category != "ASSET" &&
                    root.Category != "LIABILITY" &&
                    root.Category != "EQUITY")
                    continue;

                ReportRowBS row = BuildNodeByClass(root);

                switch (root.Category)
                {
                    case "ASSET":
                        totalAssets += row.Balance;
                        break;

                    case "LIABILITY":
                        totalLiabilities += row.Balance;
                        break;

                    case "EQUITY":
                        totalEquity += row.Balance;
                        break;
                }

                AddVisibleRows(row);
            }

            AddRetainedEarningsByClass();

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL ASSETS",
                Balance = totalAssets
            });

            Rows.Add(new ReportRowBS
            {
                Text = "TOTAL LIABILITIES & EQUITY",
                Balance = totalLiabilities + totalEquity
            });
        }
        private void AddRetainedEarningsDetail()
        {
            COANode equity = Level1Nodes.Values.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equity == null)
                return;

            decimal profit = GetRetainedEarningsDetail();

            ReportRowBS retained = new ReportRowBS()
            {
                Id = -1,
                Text = "Retained Earnings / Current Year Profit",
                AccountName = "Retained Earnings",
                Level = 2,
                CategoryCode = "EQUITY",
                Balance = profit,
                IsParent = false
            };
            ReportRowBS equityRow = Rows.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equityRow != null)
            {
                equityRow.Children.Add(retained);
                equityRow.Balance += profit;
                totalEquity += profit;
                Rows.Add(retained);
            }
        }
        private decimal GetRetainedEarningsDetail()
        {
            string sql = @"
                    SELECT
                    COALESCE(SUM(
                        CASE
                            WHEN l1.category_code='INCOME'
                                THEN t.credit - t.debit
                            WHEN l1.category_code IN ('COST','EXPENSE')
                                THEN -(t.debit - t.credit)
                            ELSE 0
                        END
                    ),0)
                    FROM tbl_transaction t
                    INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id
                    WHERE t.state=0
                      AND t.date BETWEEN @fromDate AND @toDate";
            object result = DBClass.ExecuteScalar(
                sql,
                DBClass.CreateParameter("@fromDate", FromDate),
                DBClass.CreateParameter("@toDate", ToDate));

            return Convert.ToDecimal(result ?? 0);
        }
        private ReportRowBS BuildNodePrevious(COANode node)
        {
            ReportRowBS row = new ReportRowBS();

            row.Node = node;
            row.Id = node.Id;
            row.Text = node.FullName;
            row.AccountName = node.Name;
            row.Level = node.Level;
            row.CategoryCode = node.Category;
            row.IsParent = node.HasChildren;
            row.IsExpanded = node.Expanded;

            (decimal current, decimal previous) = GetNodeBalancePrevious(node);

            row.Balance = current;
            row.PreviousBalance = previous;

            foreach (COANode child in node.Children.OrderBy(x => x.Code))
            {
                row.Children.Add(BuildNodePrevious(child));
            }

            return row;
        }
        private (decimal Current, decimal Previous) GetNodeBalancePrevious(COANode node)
        {
            string condition = "";

            switch (node.Level)
            {
                case 1:
                    condition = "l1.id=@id";
                    break;
                case 2:
                    condition = "l2.id=@id";
                    break;
                case 3:
                    condition = "l3.id=@id";
                    break;
                case 4:
                    condition = "l4.id=@id";
                    break;
            }

            string sql = @"
                    SELECT
                    COALESCE(SUM(
                    CASE
                    WHEN t.date BETWEEN @currFrom AND @currTo THEN
                    CASE
                    WHEN l1.category_code='ASSET'
                    THEN t.debit-t.credit
                    WHEN l1.category_code IN('LIABILITY','EQUITY')
                    THEN t.credit-t.debit
                    ELSE 0
                    END
                    ELSE 0
                    END),0) CurrentBalance,
                    COALESCE(SUM(
                    CASE
                    WHEN t.date BETWEEN @prevFrom AND @prevTo THEN
                    CASE
                    WHEN l1.category_code='ASSET'
                    THEN t.debit-t.credit
                    WHEN l1.category_code IN('LIABILITY','EQUITY')
                    THEN t.credit-t.debit
                    ELSE 0
                    END
                    ELSE 0
                    END),0) PreviousBalance
                    FROM tbl_transaction t
                    INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id
                    WHERE t.state=0
                    AND " + condition;

            using (MySqlDataReader rd = DBClass.ExecuteReader(
                sql,
                DBClass.CreateParameter("@id", node.Id),
                DBClass.CreateParameter("@currFrom", FromDate),
                DBClass.CreateParameter("@currTo", ToDate),
                DBClass.CreateParameter("@prevFrom", PreviousFromDate),
                DBClass.CreateParameter("@prevTo", PreviousToDate)))
            {
                if (rd.Read())
                {
                    return (
                        Convert.ToDecimal(rd["CurrentBalance"]),
                        Convert.ToDecimal(rd["PreviousBalance"])
                    );
                }
            }

            return (0, 0);
        }
        private void AddRetainedEarningsPrevious()
        {
            COANode equity = Level1Nodes.Values.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equity == null)
                return;

            decimal current = GetRetainedEarnings(FromDate, ToDate);

            decimal previous = GetRetainedEarnings(
                PreviousFromDate,
                PreviousToDate);

            ReportRowBS retained = new ReportRowBS
            {
                Id = -1,
                Text = "Retained Earnings / Current Year Profit",
                AccountName = "Retained Earnings",
                Level = 2,
                CategoryCode = "EQUITY",
                Balance = current,
                PreviousBalance = previous,
                IsParent = false
            };

            ReportRowBS equityRow = Rows.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equityRow != null)
            {
                equityRow.Children.Add(retained);

                equityRow.Balance += current;
                equityRow.PreviousBalance += previous;
                Rows.Add(retained);
                totalEquity += current;
            }
        }
        private void AddRetainedEarnings()
        {
            COANode equity = Level1Nodes.Values.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equity == null)
                return;


            decimal profit = GetRetainedEarnings();


            ReportRowBS retained = new ReportRowBS()
            {
                Id = -1,
                Text = "Retained Earnings / Current Year Profit",
                AccountName = "Retained Earnings",
                Level = 2,
                CategoryCode = "EQUITY",
                Balance = profit,
                IsParent = false
            };

            ReportRowBS equityRow = Rows.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equityRow != null)
            {
                equityRow.Children.Add(retained);
                equityRow.Balance += profit;

                Rows.Add(retained);

                totalEquity += profit;
            }
        }
        private void AddRetainedEarningsByClass()
        {
            COANode equity = Level1Nodes.Values.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equity == null)
                return;

            ReportRowBS retained = new ReportRowBS()
            {
                Id = -1,
                Text = "Retained Earnings / Current Year Profit",
                AccountName = "Retained Earnings",
                Level = 2,
                CategoryCode = "EQUITY",
                IsParent = false
            };

            ReportRowBS equityRow = Rows.FirstOrDefault(x => x.CategoryCode == "EQUITY");

            if (equityRow != null)
            {
                Dictionary<int, decimal> balances = GetRetainedEarningsByClass();
                decimal profit = 0;
                foreach (var item in balances)
                {
                    retained.ClassBalances[item.Key] = item.Value;
                    retained.Balance += item.Value;
                    profit += item.Value;
                }

                Rows.Add(retained);
                totalEquity += profit;
            }
        }
        private Dictionary<int, decimal> GetRetainedEarningsByClass()
        {
            Dictionary<int, decimal> result = new Dictionary<int, decimal>();

            string sql = @"
                    SELECT
                        t.hum_id,
                        COALESCE(SUM(
                            CASE
                                WHEN l1.category_code='INCOME'
                                    THEN t.credit - t.debit
                                WHEN l1.category_code IN ('COST','EXPENSE')
                                    THEN -(t.debit - t.credit)
                                ELSE 0
                            END
                        ),0) AS Balance
                    FROM tbl_transaction t
                    INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id
                    WHERE t.state=0
                      AND t.date<=@date
                    GROUP BY t.hum_id";

            using (MySqlDataReader rd = DBClass.ExecuteReader(
                sql,
                DBClass.CreateParameter("@date", ToDate)))
            {
                while (rd.Read())
                {
                    int classId = Convert.ToInt32(rd["hum_id"]);
                    decimal balance = Convert.ToDecimal(rd["Balance"]);

                    result[classId] = balance;
                }
            }

            return result;
        }
        private decimal GetRetainedEarnings()
        {
            string sql = @"
                SELECT
                COALESCE(SUM(
                    CASE
                    WHEN l1.category_code='INCOME'
                    THEN t.credit-t.debit
                    WHEN l1.category_code IN
                    ('COST','EXPENSE')
                    THEN -(t.debit-t.credit)
                    ELSE 0
                    END
                ),0)
                FROM tbl_transaction t
                INNER JOIN tbl_coa_level_4 l4
                ON l4.id=t.account_id
                INNER JOIN tbl_coa_level_3 l3
                ON l3.id=l4.main_id
                INNER JOIN tbl_coa_level_2 l2
                ON l2.id=l3.main_id
                INNER JOIN tbl_coa_level_1 l1
                ON l1.id=l2.main_id
                WHERE t.state=0
                AND t.date<=@date
                ";
            object result =
                DBClass.ExecuteScalar(
                    sql,
                    DBClass.CreateParameter("@date", ToDate)
                );

            return Convert.ToDecimal(result ?? 0);
        }
        private decimal GetRetainedEarnings(DateTime from, DateTime to)
        {
            string sql = @"
                SELECT
                COALESCE(SUM(
                CASE
                WHEN l1.category_code='INCOME'
                THEN t.credit-t.debit
                WHEN l1.category_code IN('COST','EXPENSE')
                THEN -(t.debit-t.credit)
                ELSE 0
                END
                ),0)
                FROM tbl_transaction t
                INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
                INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
                INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
                INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id
                WHERE t.state=0
                AND t.date BETWEEN @from AND @to";

            object result = DBClass.ExecuteScalar(
                sql,
                DBClass.CreateParameter("@from", from),
                DBClass.CreateParameter("@to", to));

            return Convert.ToDecimal(result ?? 0);
        }
        private ReportRowBS BuildNode(COANode node)
        {
            ReportRowBS row = new ReportRowBS();
            row.Node = node;
            row.Id = node.Id;
            row.Text = node.FullName;
            row.AccountName = node.Name;
            row.Level = node.Level;
            row.CategoryCode = node.Category;
            row.IsParent = node.HasChildren;
            row.IsExpanded = node.Expanded;
            row.Balance = GetNodeBalance(node);
            row.PreviousBalance = node.PreviousBalance;

            foreach (COANode child in node.Children.OrderBy(x => x.Code))
            {
                row.Children.Add(BuildNode(child));
            }

            return row;
        }
        private decimal GetNodeBalance(COANode node)
        {
            string condition = "";

            switch (node.Level)
            {
                case 1:
                    condition = "l1.id=@id";
                    break;

                case 2:
                    condition = "l2.id=@id";
                    break;

                case 3:
                    condition = "l3.id=@id";
                    break;

                case 4:
                    condition = "l4.id=@id";
                    break;
            }

            string sql = @"
                    SELECT
                    COALESCE(SUM(
                        CASE
                            WHEN l1.category_code='ASSET'
                                THEN t.debit-t.credit

                            WHEN l1.category_code IN('LIABILITY','EQUITY')
                                THEN t.credit-t.debit

                            ELSE 0
                        END
                    ),0)

                    FROM tbl_transaction t

                    INNER JOIN tbl_coa_level_4 l4 ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3 ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2 ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1 ON l1.id=l2.main_id

                    WHERE t.state=0
                    AND t.date<=@date
                    AND " + condition;

            object result = DBClass.ExecuteScalar(
                sql,
                DBClass.CreateParameter("@id", node.Id),
                DBClass.CreateParameter("@date", ToDate));

            return Convert.ToDecimal(result ?? 0);
        }
        private void AddVisibleRows(ReportRowBS row)
        {
            Rows.Add(row);

            if (!row.IsExpanded)
                return;

            foreach (ReportRowBS child in row.Children)
            {
                AddVisibleRows(child);
            }
        }
        private ReportRowBS BuildNodeByClass(COANode node)
        {
            ReportRowBS row = new ReportRowBS();

            row.Node = node;
            row.Id = node.Id;
            row.Text = node.FullName;
            row.AccountName = node.Name;
            row.Level = node.Level;
            row.CategoryCode = node.Category;
            row.IsParent = node.HasChildren;
            row.IsExpanded = node.Expanded;

            row.ClassBalances = GetNodeBalanceByClass(node);
            row.Balance = row.ClassBalances.Values.Sum();

            foreach (COANode child in node.Children.OrderBy(x => x.Code))
            {
                row.Children.Add(BuildNodeByClass(child));
            }

            return row;
        }
        
        private Dictionary<int, decimal> GetNodeBalanceByClass(COANode node)
        {
            Dictionary<int, decimal> balances = new Dictionary<int, decimal>();
            string condition = "";

            switch (node.Level)
            {
                case 1:
                    condition = "l1.id=@id";
                    break;

                case 2:
                    condition = "l2.id=@id";
                    break;

                case 3:
                    condition = "l3.id=@id";
                    break;

                case 4:
                    condition = "l4.id=@id";
                    break;
            }


            string sql = @"
                    SELECT
                        t.hum_id,
                        COALESCE(SUM(
                            CASE
                                WHEN l1.category_code='ASSET'
                                    THEN t.debit - t.credit
                                WHEN l1.category_code IN('LIABILITY','EQUITY')
                                    THEN t.credit - t.debit
                                ELSE 0
                            END
                        ),0) AS Balance
                    FROM tbl_transaction t
                    INNER JOIN tbl_coa_level_4 l4 
                        ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3 
                        ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2 
                        ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1 
                        ON l1.id=l2.main_id
                    WHERE t.state=0
                    AND t.date <= @date
                    AND " + condition + @"
                    GROUP BY t.hum_id
                ";

            using (MySqlDataReader reader = DBClass.ExecuteReader(
                sql,
                DBClass.CreateParameter("@id", node.Id),
                DBClass.CreateParameter("@date", ToDate)))
            {
                while (reader.Read())
                {
                    if (reader["hum_id"] == DBNull.Value)
                        continue;

                    int classId = Convert.ToInt32(reader["hum_id"]);
                    decimal balance = Convert.ToDecimal(reader["Balance"]);
                    balances[classId] = balance;
                }
            }

            return balances;
        }
        
        private ReportRowBS BuildNodeDetail(COANode node)
        {
            ReportRowBS row = new ReportRowBS();

            row.Node = node;
            row.Id = node.Id;
            row.Text = node.FullName;
            row.AccountName = node.Name;
            row.Level = node.Level;
            row.CategoryCode = node.Category;
            row.IsParent = node.HasChildren;
            row.IsExpanded = node.Expanded;

            row.Balance = GetNodeBalanceDetail(node);

            foreach (COANode child in node.Children.OrderBy(x => x.Code))
            {
                row.Children.Add(BuildNodeDetail(child));
            }

            return row;
        }
        private decimal GetNodeBalanceDetail(COANode node)
        {
            string condition = "";

            switch (node.Level)
            {
                case 1:
                    condition = "l1.id=@id";
                    break;

                case 2:
                    condition = "l2.id=@id";
                    break;

                case 3:
                    condition = "l3.id=@id";
                    break;

                case 4:
                    condition = "l4.id=@id";
                    break;
            }

            string sql = @"
                    SELECT
                    COALESCE(SUM(
                        CASE
                            WHEN l1.category_code='ASSET'
                                THEN t.debit - t.credit
                            WHEN l1.category_code IN
                                ('LIABILITY','EQUITY')
                                THEN t.credit - t.debit
                            ELSE 0
                        END
                    ),0) AS Balance
                    FROM tbl_transaction t
                    INNER JOIN tbl_coa_level_4 l4
                        ON l4.id=t.account_id
                    INNER JOIN tbl_coa_level_3 l3
                        ON l3.id=l4.main_id
                    INNER JOIN tbl_coa_level_2 l2
                        ON l2.id=l3.main_id
                    INNER JOIN tbl_coa_level_1 l1
                        ON l1.id=l2.main_id
                    WHERE t.state=0
                    AND t.date BETWEEN @fromDate AND @toDate
                    AND " + condition;

            object result = DBClass.ExecuteScalar(
                sql,
                DBClass.CreateParameter("@id", node.Id),
                DBClass.CreateParameter("@fromDate", FromDate),
                DBClass.CreateParameter("@toDate", ToDate)
            );

            return Convert.ToDecimal(result ?? 0);
        }
        public void Toggle(ReportRowBS row)
        {
            if (row == null)
                return;

            if (row.Node == null)
                return;

            row.Node.Expanded = !row.Node.Expanded;

            BuildReport();
        }
    }
}

public enum TypeReport
{
    Detail,
    PreviousYearComparison,
    ByClass,
    Standard
}