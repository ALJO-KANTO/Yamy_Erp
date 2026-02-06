using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YamyProject.UI.EngineeringConsultancy
{
    public static class KpiCalculationService
    {
        public static void CalculateMonthlyKPIs(int month, int year)
        {
            DataTable kpis = DBClass.ExecuteDataTable(
                @"SELECT kpi_id, kpi_code, target_value, weight
              FROM tbl_kpi_master
              WHERE is_active = 1");

            foreach (DataRow kpi in kpis.Rows)
            {
                CalculateKpi(
                    kpi["kpi_code"].ToString(),
                    Convert.ToInt32(kpi["kpi_id"]),
                    Convert.ToDecimal(kpi["target_value"]),
                    Convert.ToDecimal(kpi["weight"]),
                    month,
                    year
                );
            }
        }

        private static void CalculateKpi(
            string kpiCode,
            int kpiId,
            decimal target,
            decimal weight,
            int month,
            int year)
        {
            string sql = GetSqlByKpiCode(kpiCode);

            DataTable data = DBClass.ExecuteDataTable(
                sql,
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            foreach (DataRow row in data.Rows)
            {
                int employeeId = Convert.ToInt32(row["employee_id"]);
                decimal actual = Convert.ToDecimal(row["actual_value"]);

                decimal achievementPct = target == 0 ? 0 : (actual / target) * 100;
                decimal scorePct = GetScorePercent(achievementPct);
                decimal weightedScore = (scorePct * weight) / 100;

                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_kpi_results
                  (kpi_id, employee_id, period_month, period_year,
                   actual_value, score, calculated_at)
                  VALUES
                  (@kpi,@emp,@m,@y,@actual,@score,NOW())
                  ON DUPLICATE KEY UPDATE
                    actual_value=@actual,
                    score=@score,
                    calculated_at=NOW()",
                    DBClass.CreateParameter("@kpi", kpiId),
                    DBClass.CreateParameter("@emp", employeeId),
                    DBClass.CreateParameter("@m", month),
                    DBClass.CreateParameter("@y", year),
                    DBClass.CreateParameter("@actual", actual),
                    DBClass.CreateParameter("@score", weightedScore)
                );
            }
        }

        // KPI band logic
        private static decimal GetScorePercent(decimal achievement)
        {
            if (achievement >= 95) return 100;
            if (achievement >= 90) return 80;
            if (achievement >= 85) return 60;
            return 0;
        }
        private static string GetSqlByKpiCode(string code)
        {
            switch (code)
            {
                case "ENG_MILESTONE_ON_TIME":
                    return @"SELECT employee_id,
                            SUM(CASE WHEN completed_on_time=1 THEN 1 ELSE 0 END)
                            / NULLIF(COUNT(*),0) * 100 AS actual_value
                     FROM tbl_project_milestones
                     WHERE MONTH(due_date)=@m AND YEAR(due_date)=@y
                     GROUP BY employee_id";

                case "ENG_ATTENDANCE":
                    return @"SELECT employee_id,
                            SUM(present_days) / NULLIF(SUM(work_days),0) * 100 AS actual_value
                     FROM tbl_attendance
                     WHERE month=@m AND year=@y
                     GROUP BY employee_id";

                default:
                    throw new Exception("KPI SQL not defined for " + code);
            }
        }

        public static Dictionary<string, string> KpiArabicNames = new Dictionary<string, string>()
        {
            { "ENG_BILLABLE_RATIO", "نسبة الساعات القابلة للفوترة" },
            { "ENG_PRODUCTIVITY", "إنتاجية المهندسين" },
            { "SALES_CONVERSION", "نسبة تحويل المبيعات" },
            { "SALES_TARGET", "هدف المبيعات" },
            { "NEW_LEADS", "العملاء المحتملون الجدد" },
            { "LEAD_CONVERSION", "تحويل العملاء المحتملين" },
            { "CONTRACT_VALUE", "قيمة العقود" },
            { "SALES_CYCLE", "دورة المبيعات" },
            { "PROPOSAL_SUCCESS", "نجاح العروض" },
            { "CLIENT_RETENTION", "الاحتفاظ بالعملاء" },
            { "RECEIVABLE_RATIO", "نسبة الذمم المدينة" },
            { "ENG_MILESTONE_ON_TIME", "المرحلة المهمة في الوقت المحدد" },
            { "ENG_SAFETY_VIOLATIONS", "انتهاكات السلامة" }
        };
        public static Dictionary<string, string> KpiEnglishNames = new Dictionary<string, string>()
        {
            { "ENG_BILLABLE_RATIO", "ENG BILLABLE RATIO"},
            { "ENG_PRODUCTIVITY", "ENG PRODUCTIVITY" },
            { "SALES_CONVERSION", "SALES CONVERSION" },
            { "SALES_TARGET", "SALES TARGET" },
            { "NEW_LEADS", "NEW LEADS" },
            { "LEAD_CONVERSION", "LEAD CONVERSION" },
            { "CONTRACT_VALUE", "CONTRACT VALUE" },
            { "SALES_CYCLE", "SALES CYCLE" },
            { "PROPOSAL_SUCCESS", "PROPOSAL SUCCESS" },
            { "CLIENT_RETENTION", "CLIENT RETENTION" },
            { "RECEIVABLE_RATIO", "RECEIVABLE RATIO" },
            { "ENG_MILESTONE_ON_TIME", "ENG MILESTONE ON TIME" },
            { "ENG_SAFETY_VIOLATIONS", "ENG_SAFETY_VIOLATIONS" },
            { "ENG_REPORTING_COMPLIANCE", "ENG_REPORTING_COMPLIANCE" }
        };
        public static Dictionary<string, string> CategoryArabicNames = new Dictionary<string, string>()
        {
            { "Productivity", "الإنتاجية" },
            { "Quality", "الجودة" },
            { "Finance", "المالية" },
            { "Attendance", "الحضور" },
            { "Delivery", "التسليم" }
        };
        public static Dictionary<string, string> CategoryEnglishNames = new Dictionary<string, string>()
        {
            { "Productivity", "Productivity" },
            { "Quality", "Quality" },
            { "Finance", "Finance" },
            { "Attendance", "Attendance" },
            { "Delivery", "Delivery" }
        };
        public static Dictionary<string, string> CalculationArabicNames = new Dictionary<string, string>()
        {
            { "PERCENTAGE", "نسبة مئوية" },
            { "RATIO", "نسبة" },
            { "SCORE", "درجة" },
            { "AMOUNT", "قيمة" }
        };
        public static Dictionary<string, string> CalculationEnglishNames = new Dictionary<string, string>()
        {
            { "PERCENTAGE", "PERCENTAGE" },
            { "RATIO", "RATIO" },
            { "SCORE", "SCORE" },
            { "AMOUNT", "AMOUNT" }
        };

    }
        public class KpiCalculationServiceOld
    {
        public static void CalculateMonthlyKPIs(int month, int year)
        {
            DataTable kpis = DBClass.ExecuteDataTable(
                "SELECT * FROM tbl_kpi_master WHERE is_active=1");

            foreach (DataRow kpi in kpis.Rows)
            {
                CalculateKpi(
                    kpi["kpi_code"].ToString(),
                    Convert.ToInt32(kpi["kpi_id"]),
                    Convert.ToDecimal(kpi["target_value"]),
                    month,
                    year
                );
            }
        }

        private static void CalculateKpi(
            string kpiCode,
            int kpiId,
            decimal target,
            int month,
            int year)
        {
            string sql = GetSqlByKpiCode(kpiCode);

            DataTable data = DBClass.ExecuteDataTable(
                sql,
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );

            foreach (DataRow r in data.Rows)
            {
                decimal actual = Convert.ToDecimal(r["actual_value"]);
                decimal score = target == 0 ? 0 : Math.Min(100, (actual / target) * 100);

                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_kpi_results
                      (kpi_id, employee_id, period_month, period_year, actual_value, score, calculated_at)
                      VALUES (@kpi,@emp,@m,@y,@act,@score, NOW())
                      ON DUPLICATE KEY UPDATE
                        actual_value=@act,
                        score=@score",
                    DBClass.CreateParameter("@kpi", kpiId),
                    DBClass.CreateParameter("@emp", r["employee_id"]),
                    DBClass.CreateParameter("@m", month),
                    DBClass.CreateParameter("@y", year),
                    DBClass.CreateParameter("@act", actual),
                    DBClass.CreateParameter("@score", score)
                );
            }
        }

        private static string GetSqlByKpiCode(string code)
        {
            switch (code)
            {
                case "ENG_BILLABLE_RATIO":
                    return @"SELECT employee_id,
                            SUM(CASE WHEN is_billable=1 THEN hours ELSE 0 END)
                            / NULLIF(SUM(hours),0) * 100 AS actual_value
                     FROM tbl_eng_timesheets
                     WHERE is_approved=1
                       AND MONTH(work_date)=@m AND YEAR(work_date)=@y
                     GROUP BY employee_id";

                case "ENG_PRODUCTIVITY":
                    return @"SELECT t.employee_id,
                            SUM(t.hours) / NULLIF(COUNT(DISTINCT d.deliverable_id),0) AS actual_value
                     FROM tbl_eng_timesheets t
                     JOIN tbl_eng_project_deliverables d ON d.milestone_id=t.milestone_id
                     WHERE t.is_approved=1
                       AND MONTH(t.work_date)=@m AND YEAR(t.work_date)=@y
                     GROUP BY t.employee_id";

                case "SALES_CONVERSION":
                    return @"SELECT employee_id,
                            COUNT(contract_id) / NULLIF(COUNT(proposal_id),0) * 100 AS actual_value
                     FROM tbl_crm_proposals p
                     LEFT JOIN tbl_crm_contracts c ON c.client_id=p.client_id
                     WHERE MONTH(p.created_date)=@m AND YEAR(p.created_date)=@y
                     GROUP BY employee_id";

                default:
                    throw new Exception("KPI SQL not defined: " + code);
            }
        }

        private static string GetSqlByKpiCode0(string code)
        {
            switch (code)
            {
                case "PROD":
                    return @"SELECT employee_id, SUM(hours) actual_value
                         FROM tbl_eng_timesheets
                         WHERE is_approved=1
                           AND MONTH(work_date)=@m
                           AND YEAR(work_date)=@y
                         GROUP BY employee_id";

                case "BILL":
                    return @"SELECT employee_id,
                        SUM(CASE WHEN is_billable=1 THEN hours ELSE 0 END) /
                        NULLIF(SUM(hours),0) * 100 AS actual_value
                        FROM tbl_eng_timesheets
                        WHERE is_approved=1
                          AND MONTH(work_date)=@m
                          AND YEAR(work_date)=@y
                        GROUP BY employee_id";

                default:
                    return "";
            }
        }
        private static string GetSqlByKpiCode1(string code)
        {
            return @"
                    SELECT employee_id,
                           COALESCE(
                               SUM(CASE WHEN is_billable=1 THEN hours ELSE 0 END) / NULLIF(SUM(hours),0) * 100,
                               0
                           ) AS actual_value
                    FROM tbl_eng_timesheets
                    WHERE is_approved=1
                      AND MONTH(work_date)=@m
                      AND YEAR(work_date)=@y
                    GROUP BY employee_id
                    ";
        }

        public static Dictionary<string, string> KpiArabicNames = new Dictionary<string, string>()
        {
            { "ENG_BILLABLE_RATIO", "نسبة الساعات القابلة للفوترة" },
            { "ENG_PRODUCTIVITY", "إنتاجية المهندسين" },
            { "SALES_CONVERSION", "نسبة تحويل المبيعات" },
            { "SALES_TARGET", "هدف المبيعات" },
            { "NEW_LEADS", "العملاء المحتملون الجدد" },
            { "LEAD_CONVERSION", "تحويل العملاء المحتملين" },
            { "CONTRACT_VALUE", "قيمة العقود" },
            { "SALES_CYCLE", "دورة المبيعات" },
            { "PROPOSAL_SUCCESS", "نجاح العروض" },
            { "CLIENT_RETENTION", "الاحتفاظ بالعملاء" },
            { "RECEIVABLE_RATIO", "نسبة الذمم المدينة" }
        };
        public static Dictionary<string, string> CategoryArabicNames = new Dictionary<string, string>()
        {
            { "Productivity", "الإنتاجية" },
            { "Quality", "الجودة" },
            { "Finance", "المالية" },
            { "Attendance", "الحضور" },
            { "Delivery", "التسليم" }
        };
        public static Dictionary<string, string> CalculationArabicNames = new Dictionary<string, string>()
        {
            { "PERCENTAGE", "نسبة مئوية" },
            { "RATIO", "نسبة" },
            { "SCORE", "درجة" },
            { "AMOUNT", "قيمة" }
        };

    }
}
