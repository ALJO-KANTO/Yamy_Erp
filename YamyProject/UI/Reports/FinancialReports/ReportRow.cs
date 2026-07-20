using System.Collections.Generic;

namespace YamyProject.UI.Reports.FinancialReports
{
    public class ReportRow
    {
        public ReportRow()
        {
            JobBalances = new Dictionary<int, decimal>();
            ClassBalances = new Dictionary<int, decimal>();
        }

        public string Text { get; set; } = "";

        public int Level { get; set; }

        public bool Visible { get; set; } = true;

        public bool Expanded { get; set; } = true;

        public bool IsHeader { get; set; }

        public bool IsTotal { get; set; }

        public bool IsFormula { get; set; }

        public COANode Node { get; set; }

        public decimal Balance { get; set; }    // Current
        public decimal Balance2 { get; set; }   // Comparison

        public decimal Change => Balance - Balance2;

        public decimal PercentChange => Balance2 == 0 ? 0 : ((Balance - Balance2) / Balance2) * 100;

        public Dictionary<int, decimal> JobBalances { get; }

        public Dictionary<int, decimal> ClassBalances { get; }

        public bool HasChildren
        {
            get
            {
                return Node != null &&
                       Node.Children.Count > 0;
            }
        }

        public decimal TotalBalance { get; set; }
    }

    //public class ReportRow
    //{
    //    public string Text { get; set; }

    //    public decimal Balance { get; set; }

    //    public decimal Balance2 { get; set; }

    //    public decimal Balance3 { get; set; }

    //    public Dictionary<int, decimal> ClassBalances { get; set; }

    //    public Dictionary<int, decimal> JobBalances { get; set; }

    //    public int Level { get; set; }

    //    public bool IsHeader { get; set; }

    //    public bool IsTotal { get; set; }

    //    public bool IsFormula { get; set; }

    //    public bool Visible { get; set; }

    //    public COANode Node { get; set; }
    //    public bool Expanded { get; internal set; }
    //}
}
