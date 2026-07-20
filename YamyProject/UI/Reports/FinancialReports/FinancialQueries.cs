using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject;

namespace YamyProject.UI.Reports.FinancialReports
{
    public class FinancialQueries
    {
        //        if(type == "standard") {
        //            query = @"
        //                        WITH AccountBalances AS (
        //                        SELECT 
        //                            l1.id,
        //                            l1.name,
        //                            l1.category_code,
        //                            CASE 
        //                                WHEN l1.category_code = 'Income'
        //                                    THEN COALESCE(SUM(t.credit) - SUM(t.debit), 0)
        //                                ELSE
        //                                    COALESCE(SUM(t.debit) - SUM(t.credit), 0)
        //                            END AS balance,
        //                            CASE
        //                                WHEN l1.category_code = 'Income'  THEN 1
        //                                WHEN l1.category_code = 'Cost'    THEN 2
        //                                WHEN l1.category_code = 'EXPENSE' THEN 4
        //                            END AS sort_order
        //                        FROM tbl_coa_level_1 l1
        //                        LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                        LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                        LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                        LEFT JOIN tbl_transaction t ON t.account_id = l4.id AND t.date BETWEEN @sDate AND @eDate
        //                        WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                        GROUP BY l1.id, l1.name, l1.category_code
        //                    ),

        //                    TotalIncome AS (
        //                        SELECT
        //                            -1 AS id,
        //                            'Total Income' AS name,
        //                            'TOTAL_INCOME' AS category_code,
        //                            SUM(balance) AS balance,
        //                            1.5 AS sort_order
        //                        FROM AccountBalances
        //                        WHERE category_code = 'Income'
        //                    ),

        //                    GrossProfit AS (
        //                        SELECT
        //                            0 AS id,
        //                            'Gross Profit' AS name,
        //                            'GROSS_PROFIT' AS category_code,
        //                            COALESCE(
        //                                (SELECT SUM(balance) FROM AccountBalances WHERE category_code = 'Income'), 0
        //                            ) -
        //                            COALESCE(
        //                                (SELECT SUM(balance) FROM AccountBalances WHERE category_code = 'Cost'), 0
        //                            ) AS balance,
        //                            3 AS sort_order
        //                    ),

        //                    TotalExpenses AS (
        //                        SELECT
        //                            -2 AS id,
        //                            'Total Expenses' AS name,
        //                            'TOTAL_EXPENSE' AS category_code,
        //                            SUM(balance) AS balance,
        //                            4.5 AS sort_order
        //                        FROM AccountBalances
        //                        WHERE category_code = 'EXPENSE'
        //                    )

        //                    SELECT id, name, balance, sort_order
        //                    FROM AccountBalances
        //                    WHERE category_code IN ('Income', 'Cost')

        //                    UNION ALL
        //                    SELECT id, name, balance, sort_order FROM TotalIncome
        //                    UNION ALL
        //                    SELECT id, name, balance, sort_order FROM GrossProfit
        //                    UNION ALL
        //                    SELECT id, name, balance, sort_order FROM AccountBalances WHERE category_code = 'EXPENSE'
        //                    UNION ALL
        //                    SELECT id, name, balance, sort_order FROM TotalExpenses

        //                    ORDER BY sort_order;

        //                        ", DBClass.CreateParameter("sDate", dtFrom.Value.Date), DBClass.CreateParameter("eDate", dtTo.Value.Date)))
        //                {
        //                    while (reader.Read())
        //                    {
        //                        dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
        //                            reader["id"].ToString(), reader["name"].ToString(),
        //                            Utilities.FormatDecimal(reader["balance"].ToString()));
        //                    }
        //                    // Auto-expand everything
        //                    for (int i = 0; i<dgvCustomer.Rows.Count; i++)
        //                    {
        //                        ExpandRowRecursively(i);
        //}

        //// ===============================
        //// APPEND GROSS & NET PROFIT LAST
        //// ===============================

        //// Calculate totals from already-expanded rows
        //decimal totalIncome = 0;
        //decimal totalCOGS = 0;
        //decimal totalExpense = 0;

        //foreach (DataGridViewRow row in dgvCustomer.Rows)
        //{
        //    string name = row.Cells["currname"].Value?.ToString()?.ToUpper() ?? "";
        //    decimal amount = 0;
        //    decimal.TryParse(row.Cells["balance"].Value?.ToString(), out amount);
        //    int currLvl = int.Parse(row.Cells["currLvl"].Value.ToString());

        //    //if (name == ("INCOME") && totalIncome == 0)
        //    //    totalIncome += decimal.Parse(GetBalanceData(1, name));

        //    //else if (name == ("COST") && totalCOGS ==0)
        //    //    totalCOGS += decimal.Parse(GetBalanceData(1, name));

        //    //else if (name == ("EXPENSE") && totalExpense ==0)
        //    //    totalExpense += decimal.Parse(GetBalanceData(1, name));
        //}
        //using (MySqlDataReader mySqlDataReader = DBClass.ExecuteReader(@"
        //                            SELECT
        //                                t1.category_code,
        //                                IFNULL(COALESCE(SUM(tt.debit) - SUM(tt.credit), 0),0) AS total_balance
        //                            FROM tbl_coa_level_1 t1
        //                            JOIN tbl_coa_level_2 t2 ON t2.main_id = t1.id
        //                            JOIN tbl_coa_level_3 t3 ON t3.main_id = t2.id
        //                            JOIN tbl_coa_level_4 t4 ON t4.main_id = t3.id
        //                            LEFT JOIN tbl_transaction tt ON tt.account_id = t4.id AND tt.date BETWEEN @sDate AND @eDate
        //                            WHERE t1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY t1.category_code;
        //                            ", DBClass.CreateParameter("sDate", dtFrom.Value.Date), DBClass.CreateParameter("eDate", dtTo.Value.Date))
        //    )
        //{
        //    while (mySqlDataReader.Read())
        //    {
        //        string categoryCode = mySqlDataReader["category_code"].ToString();
        //        decimal totalBalance = Convert.ToDecimal(mySqlDataReader["total_balance"].ToString().Replace("-", ""));
        //        if (categoryCode.ToLower() == "income")
        //            totalIncome = totalBalance;
        //        else if (categoryCode.ToLower() == "cost")
        //            totalCOGS = totalBalance;
        //        else if (categoryCode.ToLower() == "expense")
        //            totalExpense = totalBalance;
        //    }
        //}

        //// Calculate profits
        //decimal grossProfit = totalIncome - totalCOGS;
        //decimal netProfit = grossProfit - totalExpense;

        //// Net Profit row
        //dgvCustomer.Rows.Add(
        //    "n", "l", "1",
        //    "   Net Profit",
        //    "0", "Net Profit",
        //    Utilities.FormatDecimal(netProfit)
        //);

        //// Make them bold
        //foreach (DataGridViewRow row in dgvCustomer.Rows)
        //{
        //    string text = row.Cells["lvl1"].Value?.ToString()?.ToUpper() ?? "";
        //    if (text.Contains("GROSS PROFIT") || text.Contains("NET PROFIT") || text.Contains("TOTAL"))
        //    {
        //        row.DefaultCellStyle.Font =
        //            new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
        //    }
        //}
        //                }
        //            }
        //            else if (reportType == "YTD Comparison")
        //{
        //    dgvCustomer.Rows.Clear();
        //    headerUC1.FormText = this.Text + " " + reportType;
        //    guna2HtmlLabel7.Text = this.Text + " " + reportType;
        //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
        //                        WITH AccountBalances AS (
        //                            -- Calculate balances for Income, Cost, and Expenses
        //                            SELECT 
        //                                l1.name AS Category, 
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.name
        //                        ),

        //                        FinalBalance AS (
        //                            -- Calculate final balance: Income - Cost - Expenses
        //                            SELECT 
        //                                'Final Balance (Income - Cost - Expenses)' AS Category,
        //                                COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Income'),0) 
        //                                    - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Cost'),0)
        //                                    - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance1,

        //                                COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Income'),0) 
        //                                    - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Cost'),0)
        //                                    - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance2
        //                        ),

        //                        EquityBalances AS (
        //                            -- Calculate balances for Assets, Liabilities, and Equity
        //                            SELECT 
        //                                l1.name, 
        //                                l1.id, 
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.id, l1.name
        //                        )

        //                        -- Final result combining the balances
        //                        SELECT 
        //                            eb.name, 
        //                            eb.id, 
        //                            CASE 
        //                                WHEN eb.name='Equity' THEN eb.Balance1 + (SELECT Balance1 FROM FinalBalance)
        //                                ELSE eb.Balance1
        //                            END AS Balance1,
        //                            CASE 
        //                                WHEN eb.name='Equity' THEN eb.Balance2 + (SELECT Balance2 FROM FinalBalance)
        //                                ELSE eb.Balance2
        //                            END AS Balance2
        //                        FROM EquityBalances eb
        //                        ORDER BY eb.id;

        //                        ",
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
        //        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
        //        {
        //            ExpandRowRecursively(i);
        //        }
        //    }
        //}
        //else if (reportType == "Prev Year Comparison")
        //{
        //    dgvCustomer.Rows.Clear();
        //    headerUC1.FormText = this.Text + " " + reportType;
        //    guna2HtmlLabel7.Text = this.Text + " " + reportType;
        //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
        //                        WITH AccountBalances AS (
        //                            -- Calculate balances for Income, Cost, and Expenses
        //                            SELECT 
        //                                l1.name AS Category, 
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.name
        //                        ),

        //                        FinalBalance AS (
        //                            -- Calculate final balance: Income - Cost - Expenses
        //                            SELECT 
        //                                'Final Balance (Income - Cost - Expenses)' AS Category,
        //                                COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Income'),0) 
        //                                    - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='Cost'),0)
        //                                    - COALESCE((SELECT Balance1 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance1,

        //                                COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Income'),0) 
        //                                    - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='Cost'),0)
        //                                    - COALESCE((SELECT Balance2 FROM AccountBalances WHERE Category='EXPENSE'),0) AS Balance2
        //                        ),

        //                        EquityBalances AS (
        //                            -- Calculate balances for Assets, Liabilities, and Equity
        //                            SELECT 
        //                                l1.name, 
        //                                l1.id, 
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @currentFrom AND @currentTo THEN t.debit - t.credit END),0) AS Balance1,
        //                                COALESCE(SUM(CASE WHEN t.date BETWEEN @prevFrom AND @prevTo THEN t.debit - t.credit END),0) AS Balance2
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.id, l1.name
        //                        )

        //                        -- Final result combining the balances
        //                        SELECT 
        //                            eb.name, 
        //                            eb.id, 
        //                            CASE 
        //                                WHEN eb.name='Equity' THEN eb.Balance1 + (SELECT Balance1 FROM FinalBalance)
        //                                ELSE eb.Balance1
        //                            END AS Balance1,
        //                            CASE 
        //                                WHEN eb.name='Equity' THEN eb.Balance2 + (SELECT Balance2 FROM FinalBalance)
        //                                ELSE eb.Balance2
        //                            END AS Balance2
        //                        FROM EquityBalances eb
        //                        ORDER BY eb.id;

        //                        ",
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
        //        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
        //        {
        //            ExpandRowRecursively(i);
        //        }
        //    }
        //}
        //else if (reportType == "by Job")
        //{
        //    headerUC1.FormText = this.Text + " " + reportType;
        //    guna2HtmlLabel7.Text = this.Text + " " + reportType;

        //    //dgvCustomer.Columns.Clear();
        //    DataTable customersTable = DBClass.ExecuteDataTable(@"SELECT DISTINCT 
        //                                                                            c.name,c.id
        //                                                                        FROM tbl_customer AS c
        //                                                                        JOIN tbl_transaction AS t 
        //                                                                            ON c.id = t.hum_id
        //                                                                        WHERE t.hum_id <> 0
        //                                                                          AND EXISTS (
        //                                                                                SELECT 1
        //                                                                                FROM tbl_transaction AS tx
        //                                                                                LEFT JOIN tbl_coa_level_4 AS l4 ON tx.account_id = l4.id
        //                                                                                LEFT JOIN tbl_coa_level_3 AS l3 ON l4.main_id = l3.id
        //                                                                                LEFT JOIN tbl_coa_level_2 AS l2 ON l3.main_id = l2.id
        //                                                                                LEFT JOIN tbl_coa_level_1 AS l1 ON l2.main_id = l1.id
        //                                                                                WHERE 
        //                                                                                    (tx.id = t.id
        //                                                                                     OR (tx.type = t.type AND tx.transaction_id = t.transaction_id))
        //                                                                                  AND l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                                                                            )
        //                                                                          AND t.type IN (
        //                                                                                'Customer Receipt',
        //                                                                                'Sales Invoice',
        //                                                                                'Customer Opening Balance',
        //                                                                                'Customer Advance Payment',
        //                                                                                'Check Cancel (Customer)',
        //                                                                                'SalesReturn Invoice',
        //                                                                                'Credit Note',
        //                                                                                'PDC Receivable'
        //                                                                            )
        //                                                                          AND t.date BETWEEN @sDate AND @eDate
        //                                                                        ORDER BY c.name;
        //                                                                      ",
        //                                                          DBClass.CreateParameter("sDate", dtFrom.Value),
        //                                                          DBClass.CreateParameter("eDate", dtTo.Value));
        //    // Build dynamic CASE SUM(...) for each customer
        //    string pivotColumns = string.Join(", ",
        //                                            customersTable.Rows.Cast<DataRow>().Select(c =>
        //                                            {
        //                                                string customerName = c["name"].ToString();
        //                                                string customerId = c["id"].ToString();

        //                                                return $@"
        //                                                                SUM(
        //                                                                    CASE 
        //                                                                        WHEN t.hum_id = {customerId} THEN 
        //                                                                            CASE 
        //                                                                                WHEN t.type = 'Sales Invoice Cash' THEN -(COALESCE(t.debit - t.credit, 0))
        //                                                                                ELSE COALESCE(t.debit - t.credit, 0)
        //                                                                            END
        //                                                                        ELSE 0
        //                                                                    END
        //                                                                ) AS `{MySqlHelper.EscapeString(customerName)}`
        //                                                            ";
        //                                            })
        //                                        );


        //    // Build final SQL
        //    string sql = $@"
        //                                SELECT 
        //                                    l1.id,
        //                                    l1.name AS AccountName,
        //                                    {pivotColumns},
        //                                    SUM(
        //                                        CASE 
        //                                            WHEN t.type = 'Sales Invoice Cash' THEN -(COALESCE(t.debit - t.credit, 0))
        //                                            ELSE COALESCE(t.debit - t.credit, 0)
        //                                        END
        //                                    ) AS Total
        //                                FROM tbl_coa_level_1 AS l1
        //                                LEFT JOIN tbl_coa_level_2 AS l2 ON l2.main_id = l1.id
        //                                LEFT JOIN tbl_coa_level_3 AS l3 ON l3.main_id = l2.id
        //                                LEFT JOIN tbl_coa_level_4 AS l4 ON l4.main_id = l3.id
        //                                LEFT JOIN tbl_transaction AS t 
        //                                    ON t.account_id = l4.id
        //                                LEFT JOIN tbl_customer AS c 
        //                                    ON c.id = t.hum_id
        //                                WHERE t.hum_id <> 0
        //                                  AND EXISTS (
        //                                        SELECT 1
        //                                        FROM tbl_transaction AS tx
        //                                        LEFT JOIN tbl_coa_level_4 AS lx4 ON tx.account_id = lx4.id
        //                                        LEFT JOIN tbl_coa_level_3 AS lx3 ON lx4.main_id = lx3.id
        //                                        LEFT JOIN tbl_coa_level_2 AS lx2 ON lx3.main_id = lx2.id
        //                                        LEFT JOIN tbl_coa_level_1 AS lx1 ON lx2.main_id = lx1.id
        //                                        WHERE 
        //                                            (tx.id = t.id
        //                                             OR (tx.type = t.type AND tx.transaction_id = t.transaction_id))
        //                                          AND lx1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                                    )
        //                                  AND t.type IN (
        //                                        'Customer Receipt',
        //                                        'Sales Invoice',
        //                                        'Customer Opening Balance',
        //                                        'Customer Advance Payment',
        //                                        'Check Cancel (Customer)',
        //                                        'SalesReturn Invoice',
        //                                        'Credit Note',
        //                                        'PDC Receivable'
        //                                    )
        //                                  AND t.date BETWEEN @sDate AND @eDate
        //                                GROUP BY l1.id, l1.name
        //                                ORDER BY l1.id;
        //                                ";

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
        //                        WITH AccountBalances AS (
        //                            -- Calculate balances for Income, Cost, and Expenses
        //                            SELECT 
        //                                l1.name AS Category, 
        //                                COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS Balance
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.name
        //                        ),

        //                        FinalBalance AS (
        //                            -- Calculate final balance: Income - Cost - Expenses
        //                            SELECT 
        //                                'Final Balance (Income - Cost - Expenses)' AS Category,
        //                                COALESCE(
        //                                    (SELECT Balance FROM AccountBalances WHERE Category = 'Income'), 0
        //                                ) -
        //                                COALESCE(
        //                                    (SELECT Balance FROM AccountBalances WHERE Category = 'Cost'), 0
        //                                ) -
        //                                COALESCE(
        //                                    (SELECT Balance FROM AccountBalances WHERE Category = 'EXPENSE'), 0
        //                                ) AS Balance
        //                        ),

        //                        EquityBalances AS (
        //                            -- Calculate balances for Assets, Liabilities, and Equity
        //                            SELECT 
        //                                l1.name, 
        //                                l1.id, 
        //                                COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS balance
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.id, l1.name
        //                        )

        //                        -- Final result combining the balances
        //                        SELECT 
        //                            eb.name, 
        //                            eb.id, 
        //                            CASE 
        //                                -- For Equity, add the final balance from Income - Cost - Expenses to Retained Earnings
        //                                WHEN eb.name = 'Equity' THEN 
        //                                    eb.balance + 
        //                                    (SELECT Balance FROM FinalBalance)
        //                                ELSE 
        //                                    eb.balance
        //                            END AS balance
        //                        FROM EquityBalances eb
        //                        ORDER BY eb.id;

        //                        "))
        //    {
        //        while (reader.Read())
        //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
        //                reader["id"].ToString(), reader["name"].ToString(),
        //                Utilities.FormatDecimal(reader["balance"].ToString()), Utilities.FormatDecimal(reader["balance"].ToString()));

        //        // Auto-expand everything
        //        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
        //        {
        //            ExpandRowRecursively(i);
        //        }
        //    }
        //}
        //else if (reportType == "Unclassified")
        //{
        //    headerUC1.FormText = this.Text + " " + reportType;
        //    guna2HtmlLabel7.Text = this.Text + " " + reportType;

        //    dgvCustomer.Rows.Clear();
        //    using (MySqlDataReader reader = DBClass.ExecuteReader(@"
        //                        WITH AccountBalances AS (
        //                            -- Calculate balances for Income, Cost, and Expenses
        //                            SELECT 
        //                                l1.name AS Category, 
        //                                COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS Balance
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.name
        //                        ),

        //                        FinalBalance AS (
        //                            -- Calculate final balance: Income - Cost - Expenses
        //                            SELECT 
        //                                'Final Balance (Income - Cost - Expenses)' AS Category,
        //                                COALESCE(
        //                                    (SELECT Balance FROM AccountBalances WHERE Category = 'Income'), 0
        //                                ) -
        //                                COALESCE(
        //                                    (SELECT Balance FROM AccountBalances WHERE Category = 'Cost'), 0
        //                                ) -
        //                                COALESCE(
        //                                    (SELECT Balance FROM AccountBalances WHERE Category = 'EXPENSE'), 0
        //                                ) AS Balance
        //                        ),

        //                        EquityBalances AS (
        //                            -- Calculate balances for Assets, Liabilities, and Equity
        //                            SELECT 
        //                                l1.name, 
        //                                l1.id, 
        //                                COALESCE(SUM(t.debit) - SUM(t.credit), 0) AS balance
        //                            FROM tbl_coa_level_1 l1
        //                            LEFT JOIN tbl_coa_level_2 l2 ON l2.main_id = l1.id
        //                            LEFT JOIN tbl_coa_level_3 l3 ON l3.main_id = l2.id
        //                            LEFT JOIN tbl_coa_level_4 l4 ON l4.main_id = l3.id
        //                            LEFT JOIN tbl_transaction t ON t.account_id = l4.id
        //                            WHERE l1.category_code IN ('Income', 'Cost', 'EXPENSE')
        //                            GROUP BY l1.id, l1.name
        //                        )

        //                        -- Final result combining the balances
        //                        SELECT 
        //                            eb.name, 
        //                            eb.id, 
        //                            CASE 
        //                                -- For Equity, add the final balance from Income - Cost - Expenses to Retained Earnings
        //                                WHEN eb.name = 'Equity' THEN 
        //                                    eb.balance + 
        //                                    (SELECT Balance FROM FinalBalance)
        //                                ELSE 
        //                                    eb.balance
        //                            END AS balance
        //                        FROM EquityBalances eb
        //                        ORDER BY eb.id;

        //                        "))
        //    {
        //        while (reader.Read())
        //            dgvCustomer.Rows.Add("e", "u", "1", "   ►     " + reader["name"].ToString(),
        //                reader["id"].ToString(), reader["name"].ToString(),
        //                Utilities.FormatDecimal(reader["balance"].ToString()));

        //        // Auto-expand everything
        //        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
        //        {
        //            ExpandRowRecursively(i);
        //        }
        //    }
    }
}
