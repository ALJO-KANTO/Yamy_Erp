using System;
using System.Collections.Generic;

namespace YamyProject.UI.Reports.FinancialReports.BalanceSheet
{
    public class ReportRowBS
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AccountName { get; set; }
        public int Level { get; set; }
        public decimal Balance { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal Change
        {
            get
            {
                return Balance - PreviousBalance;
            }
        }
        public decimal ChangePercent
        {
            get
            {
                if (PreviousBalance == 0)
                    return 0;

                return (Change / Math.Abs(PreviousBalance)) * 100;
            }
        }
        public string CategoryCode { get; set; }
        public bool IsParent { get; set; }
        public bool IsExpanded { get; set; }
        public List<ReportRowBS> Children { get; set; }
        public Dictionary<int, decimal> JobBalances { get; set; }
        public Dictionary<int, decimal> ClassBalances { get; set; }
        public COANode Node { get; set; }
        public ReportRowBS()
        {
            Children = new List<ReportRowBS>();
            ClassBalances = new Dictionary<int, decimal>();
            JobBalances = new Dictionary<int, decimal>();
        }
    }
}
