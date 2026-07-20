using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace YamyProject.UI.Reports.FinancialReports
{
    public class ProfitLossRenderer
    {
        private readonly DataGridView dgv;

        public ProfitLossRenderer(DataGridView grid)
        {
            dgv = grid;
        }

        public void Render(ProfitLossReportEngine engine)
        {
            dgv.Rows.Clear();

            switch (engine.ReportType)
            {
                case ReportType.Unclassified:
                    RenderStandard(engine.Rows);
                    break;

                case ReportType.PreviousYearComparison:
                    RenderPreviousYearComparison(engine.Rows);
                    break;

                case ReportType.YTDComparison:
                    RenderYTDComparison(engine.Rows);
                    break;
                case ReportType.ByClass:
                    RenderByClass(engine.Rows);
                    break;
                case ReportType.ByJob:
                    RenderByJob(engine.Rows);
                    break;

                default:
                    RenderStandard(engine.Rows);
                    break;
            }
        }

        private void RenderByJob(List<ReportRow> rows)
        {
            foreach (var row in rows.Where(x => x.Visible))
                AddJobRow(row);
        }

        private void AddJobRow(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            dgv.Rows[r].Cells["lvl1"].Value = GetCaption(row);

            foreach (var job in row.JobBalances)
            {
                if (dgv.Columns.Contains(job.Key.ToString()))
                    dgv.Rows[r].Cells[job.Key.ToString()].Value = job.Value;
            }

            dgv.Rows[r].Cells["Total"].Value = row.TotalBalance;

            ApplyStyle(r, row);
        }

        private void RenderByClass(List<ReportRow> rows)
        {
            foreach (var row in rows.Where(x => x.Visible))
                AddClassRow(row);
        }

        private void RenderPreviousYearComparison(List<ReportRow> rows)
        {
            foreach (var row in rows.Where(x => x.Visible))
                AddPreviousYearRow(row);
        }
        private void AddPreviousYearRow(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            dgv.Rows[r].Cells["lvl1"].Value = GetCaption(row);
            dgv.Rows[r].Cells["balance1"].Value = row.Balance;
            dgv.Rows[r].Cells["balance2"].Value = row.Balance2;
            dgv.Rows[r].Cells["change"].Value = row.Change;
            dgv.Rows[r].Cells["change_percentage"].Value = row.PercentChange;

            ApplyStyle(r, row);
        }

        private void RenderStandard(List<ReportRow> rows)
        {
            foreach (var row in rows.Where(x => x.Visible))
                AddStandardRow(row);
        }

        private void RenderYTDComparison(List<ReportRow> rows)
        {
            foreach (var row in rows.Where(x => x.Visible))
                AddYTDRow(row);
        }
        private void AddStandardRow(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            dgv.Rows[r].Cells["lvl1"].Value = GetCaption(row);
            dgv.Rows[r].Cells["balance"].Value = row.Balance;

            ApplyStyle(r, row);
        }
        private void AddYTDRow(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            dgv.Rows[r].Cells["lvl1"].Value = GetCaption(row);
            dgv.Rows[r].Cells["balance1"].Value = row.Balance;
            dgv.Rows[r].Cells["balance2"].Value = row.Balance2;

            ApplyStyle(r, row);
        }
        private void AddClassRow(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            dgv.Rows[r].Cells["lvl1"].Value = GetCaption(row);

            // Unclassified amount
            dgv.Rows[r].Cells["balance"].Value = row.Balance;

            // Total amount
            dgv.Rows[r].Cells["balance1"].Value = row.TotalBalance;

            ApplyStyle(r, row);
        }
        private string GetCaption(ReportRow row)
        {
            string icon = "";

            if (row.Node != null)
            {
                if (row.Node.Children.Count > 0)
                    icon = row.Node.Expanded ? "▼ " : "► ";
            }

            return new string(' ', row.Level * 5) +
                   icon +
                   row.Text;
        }
        
        private void AddRowNew(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            dgv.Rows[r].Cells["id"].Value = row.Node?.Id;
            dgv.Rows[r].Cells["currLvl"].Value = row.Level;
            dgv.Rows[r].Cells["currname"].Value = row.Text;
            dgv.Rows[r].Cells["balance"].Value = row.Balance;

            dgv.Rows[r].Cells["lvl1"].Value = GetCaption(row);

            ApplyStyle(r, row);
        }
        
        private void ApplyStyle(int rowIndex, ReportRow row)
        {
            if (row.IsHeader)
                dgv.Rows[rowIndex].DefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);

            if (row.IsTotal)
                dgv.Rows[rowIndex].DefaultCellStyle.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);

            if (row.IsFormula)
            {
                dgv.Rows[rowIndex].DefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);

                dgv.Rows[rowIndex].DefaultCellStyle.BackColor =
                    Color.Gainsboro;
            }
        }

        private void ApplyStyleOG(int rowIndex, COANode node)
        {
            DataGridViewRow row = dgv.Rows[rowIndex];

            row.DefaultCellStyle.Font =
                new Font("Segoe UI", 9);

            if (node.Level == 1)
            {
                row.DefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);

                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(230, 230, 230);
            }

            if (node.Level == 2)
            {
                row.DefaultCellStyle.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);
            }

            if (node.Children.Count > 0)
            {
                row.DefaultCellStyle.ForeColor =
                    Color.DarkBlue;
            }

            if (node.CurrentBalance < 0)
            {
                row.Cells["balance"].Style.ForeColor =
                    Color.Red;
            }

            row.Cells["balance"].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            row.Cells["balance"].Style.Format = "N2";
        }
        public void RenderOG(List<ReportRow> rows)
        {
            dgv.Rows.Clear();
            foreach (ReportRow row in rows.Where(x => x.Visible))
            {
                AddRowOG(row);
            }
        }
        private void AddRowOG(ReportRow row)
        {
            int r = dgv.Rows.Add();

            dgv.Rows[r].Tag = row;

            string icon = "";

            if (row.Node != null)
            {
                if (row.Node.Children.Count > 0)
                    icon = row.Node.Expanded ? "▼ " : "► ";
            }

            dgv.Rows[r].Cells["lvl1"].Value =
                new string(' ', row.Level * 5) +
                icon +
                row.Text;

            dgv.Rows[r].Cells["balance"].Value =
                row.Balance;

            if (row.IsHeader)
            {
                dgv.Rows[r].DefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
            }

            if (row.IsTotal)
            {
                dgv.Rows[r].DefaultCellStyle.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);
            }

            if (row.IsFormula)
            {
                dgv.Rows[r].DefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);

                dgv.Rows[r].DefaultCellStyle.BackColor =
                    Color.Gainsboro;
            }
        }
    }
}
public enum BalanceType
{
    Current,
    Previous
}