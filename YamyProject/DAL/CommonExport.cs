using System;
using System.Data;
using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources
{
    public class CommonExport
    {
        public static void ExportToExcel(DataTable dt, string reportName)
        {
            if (dt == null || dt.Rows.Count == 0)
                return;

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application
                {
                    Visible = true,
                    DisplayAlerts = false
                };

                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = reportName;

                // ===== Header Row =====
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    worksheet.Cells[1, i + 1].Font.Bold = true;
                }

                // ===== Data Rows =====
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        worksheet.Cells[r + 2, c + 1] = dt.Rows[r][c]?.ToString();
                    }
                }

                // ===== Formatting =====
                Excel.Range usedRange = worksheet.UsedRange;
                usedRange.Columns.AutoFit();
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Optional: Freeze header row
                worksheet.Application.ActiveWindow.SplitRow = 1;
                worksheet.Application.ActiveWindow.FreezePanes = true;
            }
            finally
            {
                // Cleanup COM objects (important)
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

    }
}