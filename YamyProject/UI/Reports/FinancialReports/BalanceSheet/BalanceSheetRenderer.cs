using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Reports.FinancialReports.BalanceSheet
{
    public class BalanceSheetRenderer
    {
        private readonly DataGridView dgv;
        public BalanceSheetRenderer(DataGridView grid)
        {
            dgv = grid;
        }
        public void Render(BalanceSheetReportEngine engine)
        {
            dgv.Rows.Clear();
            switch (engine.Type)
            {
                case TypeReport.Detail:
                    RenderDetail(engine.Rows);
                    break;
                case TypeReport.PreviousYearComparison:
                    RenderPreviousYearComparison(engine.Rows);
                    break;
                case TypeReport.ByClass:
                    RenderByClass(engine.Rows);
                    break;

                default:
                    RenderStandard(engine.Rows);
                    break;
            }
        }

        private void RenderByClass(List<ReportRowBS> rows)
        {
            foreach (ReportRowBS row in rows)
            {
                AddClassRow(row);
            }
        }

        private void RenderPreviousYearComparison(List<ReportRowBS> rows)
        {
            foreach (ReportRowBS row in rows)
            {
                AddPreviousYearRow(row);
            }
        }

        private void RenderDetail(List<ReportRowBS> rows)
        {
            foreach (ReportRowBS row in rows)
            {
                AddDetailRow(row);
            }
        }

        private void RenderStandard(List<ReportRowBS> rows)
        {
            foreach (var row in rows)
                AddStandardRow(row);
        }

        private void AddStandardRow(ReportRowBS row)
        {
            string state = row.IsParent ? "e" : "n";
            int index = dgv.Rows.Add();
            DataGridViewRow dgvRow = dgv.Rows[index];
            dgvRow.Cells["state"].Value = state;
            dgvRow.Cells["loadState"].Value = "u";
            dgvRow.Cells["currLvl"].Value = row.Level;
            string icon = row.IsParent ? "►" : "";
            string space = new string(' ', row.Level * 5);
            dgvRow.Cells["lvl1"].Value = space + icon + "     " + row.Text;
            dgvRow.Cells["id"].Value = row.Id;
            dgvRow.Cells["currname"].Value = row.AccountName;
            dgvRow.Cells["balance"].Value = Utilities.FormatDecimal(row.Balance.ToString());
            dgvRow.Tag = row;
        }

        private void AddPreviousYearRow(ReportRowBS row)
        {
            int index = dgv.Rows.Add();

            DataGridViewRow dgvRow = dgv.Rows[index];


            dgvRow.Cells["lvl1"].Value =
                new string(' ', row.Level * 5)
                + (row.IsParent ? "► " : "")
                + row.Text;


            dgvRow.Cells["id"].Value = row.Id;

            dgvRow.Cells["currLvl"].Value = row.Level;


            dgvRow.Cells["balance1"].Value =
                Utilities.FormatDecimal(row.Balance.ToString());


            dgvRow.Cells["balance2"].Value =
                Utilities.FormatDecimal(row.PreviousBalance.ToString());


            dgvRow.Cells["change"].Value =
                Utilities.FormatDecimal(row.Change.ToString());


            dgvRow.Cells["change_percentage"].Value =
                row.ChangePercent.ToString("0.00") + "%";


            dgvRow.Tag = row;
        }
        
        private void AddClassRow(ReportRowBS row)
        {
            int index = dgv.Rows.Add();
            DataGridViewRow dgvRow = dgv.Rows[index];

            dgvRow.Cells["lvl1"].Value =
                new string(' ', row.Level * 5)
                + (row.IsParent ? "► " : "")
                + row.Text;


            dgvRow.Cells["id"].Value = row.Id;
            dgvRow.Cells["currLvl"].Value = row.Level;



            int columnIndex = 5;


            foreach (var cls in row.ClassBalances)
            {
                if (columnIndex < dgv.Columns.Count)
                {
                    dgvRow.Cells[columnIndex].Value =
                        Utilities.FormatDecimal(
                            cls.Value.ToString());
                }

                columnIndex++;
            }

            dgvRow.Cells["balance"].Value = Utilities.FormatDecimal(row.Balance.ToString());
            dgvRow.Tag = row;
        }

        private void AddDetailRow(ReportRowBS row)
        {
            int index = dgv.Rows.Add();
            DataGridViewRow dgvRow = dgv.Rows[index];

            dgvRow.Cells["lvl1"].Value =
                new string(' ', row.Level * 5)
                + (row.IsParent ? "► " : "")
                + row.Text;


            dgvRow.Cells["id"].Value = row.Id;
            dgvRow.Cells["currLvl"].Value = row.Level;
            dgvRow.Cells["balance"].Value = Utilities.FormatDecimal(row.Balance.ToString());


            dgvRow.Tag = row;
        }
    }
}
