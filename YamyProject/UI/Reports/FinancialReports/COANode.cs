using System.Collections.Generic;

namespace YamyProject.UI.Reports.FinancialReports
{
    public class COANode
    {
        public COANode()
        {
            Children = new List<COANode>();
            JobBalances = new Dictionary<int, decimal>();
            ClassBalances = new Dictionary<int, decimal>();
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public COANode Parent { get; set; }
        public List<COANode> Children { get; }
        public bool Expanded { get; set; } = true;
        public decimal CurrentBalance { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal TotalCurrent { get; set; }
        public decimal TotalPrevious { get; set; }
        public Dictionary<int, decimal> JobBalances { get; }
        public Dictionary<int, decimal> ClassBalances { get; }
        public bool IsLeaf => Level == 4;
        public bool HasChildren => Children.Count > 0;
        public string FullName => string.IsNullOrWhiteSpace(Code)
            ? Name
            : Code + " - " + Name;
        public string CategoryCode { get; internal set; }
    }
}