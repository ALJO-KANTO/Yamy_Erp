using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmManCategoryWiseItemMonthly : Form
    {
        int _itemId;
        public frmManCategoryWiseItemMonthly(int itemId)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
            _itemId = itemId;
        }

        private void frmManItemTreeDetails_Load(object sender, EventArgs e)
        {
            btnPrint.Text = "Print ";
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name FROM tbl_company LIMIT 1"))
                if (reader.Read())
                {
                    lblCompany.Text = reader["name"].ToString();
                }
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:tt");
            //AddDGVColumns();
            //LoadItemData();
            //LoadCategoryWiseTree();
            LoadData();
        }
        private void LoadData()
        {
            dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvSales.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            LoadReport();
            //DataTable report = CreateReportTable();
            //FillReport(report);

            //dgvSales.DataSource = report;
        }
        private DataTable CreateReportTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Category");
            dt.Columns.Add("Item");
            dt.Columns.Add("Unit");

            dt.Columns.Add("Opening Qty", typeof(decimal));
            dt.Columns.Add("Opening U/Pr", typeof(decimal));
            dt.Columns.Add("Opening Total", typeof(decimal));

            dt.Columns.Add("Credit Qty", typeof(decimal));
            dt.Columns.Add("Credit U/Pr", typeof(decimal));
            dt.Columns.Add("Credit Total", typeof(decimal));

            dt.Columns.Add("Cash Qty", typeof(decimal));
            dt.Columns.Add("Cash U/Pr", typeof(decimal));
            dt.Columns.Add("Cash Total", typeof(decimal));

            dt.Columns.Add("Closing Qty", typeof(decimal));
            dt.Columns.Add("Closing U/Pr", typeof(decimal));
            dt.Columns.Add("Closing Total", typeof(decimal));

            dt.Columns.Add("Actual Consumption", typeof(decimal));

            return dt;
        }
        private void FillReport(DataTable dt)
        {
            dt.Rows.Add(
                "Frozen Food",
                "Chicken Trimmings",
                "Kg",
                830, 5.75, 4772.50,
                0, 5.75, 0,
                0, 5.75, 0,
                830, 5.75, 4772.50,
                0
            );

            dt.Rows.Add(
                "Frozen Food",
                "Tender Chicken Trimmings",
                "Kg",
                0, 5.50, 0,
                0, 5.50, 0,
                0, 5.50, 0,
                0, 5.50, 0,
                0
            );

            // Continue adding rows...

            dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvSales.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

        }
        private void PrepareColumns()
        {
            dgvSales.Columns.Clear();

            dgvSales.Columns.Add("Category", "Category");
            dgvSales.Columns.Add("Item", "Item");
            dgvSales.Columns.Add("Unit", "Unit");

            dgvSales.Columns.Add("OpeningQty", "Opening Qty");
            dgvSales.Columns.Add("OpeningUpr", "Opening U/Pr");
            dgvSales.Columns.Add("OpeningTotal", "Opening Total");

            dgvSales.Columns.Add("CreditQty", "P-Credit Qty");
            dgvSales.Columns.Add("CreditUpr", "P-Credit U/Pr");
            dgvSales.Columns.Add("CreditTotal", "P-Credit Total");

            dgvSales.Columns.Add("CashQty", "P-Cash Qty");
            dgvSales.Columns.Add("CashUpr", "P-Cash U/Pr");
            dgvSales.Columns.Add("CashTotal", "P-Cash Total");

            dgvSales.Columns.Add("ClosingQty", "Closing Qty");
            dgvSales.Columns.Add("ClosingUpr", "Closing U/Pr");
            dgvSales.Columns.Add("ClosingTotal", "Closing Total");

            dgvSales.Columns.Add("ActualCons", "Actual Consumption");
        }

        private void LoadReport()
        {
            PrepareColumns();
            dgvSales.Rows.Clear();

            string sql = @"SELECT 
                                c.name AS category_name,
                                i.name AS item_name,
                                u.name AS unit,

                                /* ---------- OPENING STOCK ---------- */
                                IFNULL((
                                    SELECT SUM(a.qty_in - a.qty_out)
                                    FROM tbl_item_transaction a
                                    WHERE a.date < @sDate AND a.item_id = i.id
                                ), 0) AS opening_qty,

                                IFNULL((
                                    SELECT a.cost_price
                                    FROM tbl_item_transaction a
                                    WHERE a.date < @sDate AND a.item_id = i.id
                                    ORDER BY a.date DESC
                                    LIMIT 1
                                ), 0) AS opening_upr,

                                /* -------- CREDIT PURCHASE -------- */
                                IFNULL(SUM(CASE WHEN t.type = 'Purchase Invoice' THEN t.qty_in END), 0) AS credit_qty,
                                IFNULL(SUM(CASE WHEN t.type = 'Purchase Invoice' THEN t.cost_price END), 0) AS credit_upr,

                                /* -------- CASH PURCHASE -------- */
                                IFNULL(SUM(CASE WHEN t.type = 'Purchase Cash' THEN t.qty_in END), 0) AS cash_qty,
                                IFNULL(SUM(CASE WHEN t.type = 'Purchase Cash' THEN t.cost_price END), 0) AS cash_upr,

                                /* -------- CLOSING STOCK (last transaction before @eDate) -------- */
                                IFNULL((
                                    SELECT SUM(a.qty_in - a.qty_out)
                                    FROM tbl_item_transaction a
                                    WHERE a.date <= @eDate AND a.item_id = i.id
                                ),0) AS closing_qty,

                                IFNULL((
                                    SELECT a.cost_price
                                    FROM tbl_item_transaction a
                                    WHERE a.date <= @eDate AND a.item_id = i.id
                                    ORDER BY a.date DESC
                                    LIMIT 1
                                ),0) AS closing_upr

                            FROM tbl_items i
                            JOIN tbl_item_category c ON i.category_id = c.id
                            LEFT JOIN tbl_item_transaction t 
                                ON t.item_id = i.id 
                                AND t.date >= @sDate 
                                AND t.date <= @eDate         -- allow date range here ONLY for purchase
                            LEFT JOIN tbl_unit u ON u.id = i.unit_id

                            WHERE i.state = 0

                            GROUP BY i.id,c.code, c.name, i.name, u.name
                            ORDER BY c.code, i.name;
                            ";
            DataTable dt = DBClass.ExecuteDataTable(sql,
            DBClass.CreateParameter("sDate", dtpFrom.Value.Date),
            DBClass.CreateParameter("eDate", dtpTo.Value.Date));

            if (dt.Rows.Count == 0) return;

            string currentCategory = "";
            decimal totOpeningQty = 0, totCreditQty = 0, totCashQty = 0, totClosingQty =0;
            decimal CatTotOpeningQty = 0, catTotCreditQty = 0, catTotCashQty = 0, catTotClosingQty =0;
            decimal totOpening = 0, totCredit = 0, totCash = 0, totClosing = 0, totConsumption = 0;
            decimal catTotOpening = 0, catTotCredit = 0, catTotCash = 0, catTotClosing = 0, catTotConsumption = 0;

            // Group rows Type → Category → Item
            var items = dt.AsEnumerable()
                .GroupBy(r => new
                {
                    Category = r["category_name"].ToString(),
                    Item = r["item_name"].ToString(),
                    Unit = r["unit"].ToString()
                }).ToList();

            foreach (var grp in items)
            {
                string category = grp.Key.Category;

                // If category changed → print TOTAL ROW for previous category
                if (category != currentCategory && currentCategory != "")
                {
                    dgvSales.Rows.Add(
                        "", "   TOTAL", "",
                        totOpeningQty, "", totOpening,        // Opening total
                        totCreditQty, "", totCredit,          // Credit total
                        totCashQty, "", totCash,              // Cash total
                        totClosingQty, "", totClosing,        // Closing total
                        totConsumption                     // Actual Consumption Total
                    );

                    // ---- MAKE TOTAL ROW BOLD ----
                    DataGridViewRow totalRow00 = dgvSales.Rows[dgvSales.Rows.Count - 1];
                    totalRow00.DefaultCellStyle.Font = new System.Drawing.Font(dgvSales.Font, FontStyle.Bold);

                    CatTotOpeningQty += totOpeningQty;
                    catTotOpening += totOpening;
                    catTotCreditQty += totCreditQty;
                    catTotCredit += totCredit;
                    catTotCashQty += totCashQty;
                    catTotCash += totCash;
                    catTotClosingQty += totClosingQty;
                    catTotClosing += totClosing;
                    catTotConsumption += totConsumption;

                    // Reset totals for next category
                    totOpening = totCredit = totCash = totClosing = totConsumption = 0;
                    totOpeningQty = totCreditQty  = totCashQty = totClosingQty = 0;
                }

                // CATEGORY ROW
                if (category != currentCategory)
                {
                    dgvSales.Rows.Add("  " + category, "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****", "*****");
                    currentCategory = category;

                    // ---- MAKE TOTAL ROW BOLD ----
                    DataGridViewRow totalRows = dgvSales.Rows[dgvSales.Rows.Count - 1];
                    totalRows.DefaultCellStyle.Font = new System.Drawing.Font(dgvSales.Font, FontStyle.Bold);
                }

                // ITEM ROW
                var r = grp.First();

                decimal openingQty = Convert.ToDecimal(r["opening_qty"]);
                decimal openingUpr = Convert.ToDecimal(r["opening_upr"]);
                decimal creditQty = Convert.ToDecimal(r["credit_qty"]);
                decimal creditUpr = Convert.ToDecimal(r["credit_upr"]);
                decimal cashQty = Convert.ToDecimal(r["cash_qty"]);
                decimal cashUpr = Convert.ToDecimal(r["cash_upr"]);
                decimal closingQty = Convert.ToDecimal(r["closing_qty"]);
                decimal closingUpr = Convert.ToDecimal(r["closing_upr"]);

                decimal openingTotal = openingQty * openingUpr;
                decimal creditTotal = creditQty * creditUpr;
                decimal cashTotal = cashQty * cashUpr;
                decimal closingTotal = closingQty * closingUpr;

                decimal consumption = openingTotal + creditTotal + cashTotal - closingTotal;

                dgvSales.Rows.Add(
                    "", "   " + grp.Key.Item, grp.Key.Unit,
                    openingQty, openingUpr, openingTotal,
                    creditQty, creditUpr, creditTotal,
                    cashQty, cashUpr, cashTotal,
                    closingQty, closingUpr, closingTotal,
                    consumption
                );

                // ADD TO CATEGORY TOTALS
                totOpeningQty += openingQty;
                totOpening += openingTotal;
                totCreditQty += creditQty;
                totCredit += creditTotal;
                totCashQty += cashQty;
                totCash += cashTotal;
                totClosingQty += closingQty;
                totClosing += closingTotal;
                totConsumption += consumption;
            }

            // Add total row
            //UpdateTotalsRow();

            // Final category total
            if (currentCategory != "")
            {
                dgvSales.Rows.Add(
                    "", "   TOTAL", "",
                    totOpeningQty, "", totOpening,
                    totCreditQty, "", totCredit,
                    totCashQty, "", totCash,
                    totClosingQty, "", totClosing,
                    totConsumption
                );
                // ---- MAKE TOTAL ROW BOLD ----
                DataGridViewRow totalRow0 = dgvSales.Rows[dgvSales.Rows.Count - 1];
                totalRow0.DefaultCellStyle.Font = new System.Drawing.Font(dgvSales.Font, FontStyle.Bold);

                CatTotOpeningQty += totOpeningQty;
                catTotOpening += totOpening;
                catTotCreditQty += totCreditQty;
                catTotCredit += totCredit;
                catTotCashQty += totCashQty;
                catTotCash += totCash;
                catTotClosingQty += totClosingQty;
                catTotClosing += totClosing;
                catTotConsumption += totConsumption;
            }

            dgvSales.Rows.Add(
                    "   TOTAL", "", "",
                    CatTotOpeningQty, "", catTotOpening,
                    catTotCreditQty, "", catTotCredit,
                    catTotCashQty, "", catTotCash,
                    catTotClosingQty, "", catTotClosing,
                    catTotConsumption
                );

            // ---- MAKE TOTAL ROW BOLD ----
            DataGridViewRow totalRow1 = dgvSales.Rows[dgvSales.Rows.Count - 1];
            totalRow1.DefaultCellStyle.Font = new System.Drawing.Font(dgvSales.Font, FontStyle.Bold);

            FormatGrid();
        }
        private void FormatGrid()
        {
            foreach (DataGridViewColumn col in dgvSales.Columns)
            {
                if (col.Index>2)
                {
                    col.DefaultCellStyle.Format = "N2";   // 0.00 format
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }


        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //int currLvl = int.Parse(dgvSales.Rows[e.RowIndex].Cells["currLvl"].Value.ToString());
            //string state = dgvSales.Rows[e.RowIndex].Cells["state"].Value.ToString();
            //string loadState = dgvSales.Rows[e.RowIndex].Cells["loadState"].Value.ToString();
            //string cellValue = dgvSales.Rows[e.RowIndex].Cells["colName"].Value.ToString();
            //string key = dgvSales.Rows[e.RowIndex].Cells["id"].Value.ToString();
            //string space = new string(' ', currLvl * 6 + 3);

            //if (state == "e")
            //{
            //    if (loadState == "u")
            //    {
            //        if (currLvl == 1)
            //        {
            //            // Expand: Type -> Categories
            //            string sql = @"
            //                            SELECT 
            //                                c.id, 
            //                                CONCAT(c.code, ' - ', c.name) AS category_name
            //                            FROM 
            //                                tbl_item_category c
            //                            JOIN 
            //                                tbl_items i ON i.category_id = c.id
            //                            WHERE 
            //                                i.type = @type
            //                            GROUP BY 
            //                                c.id, c.code, c.name
            //                            ORDER BY 
            //                                c.code;";

            //            DataTable categoryTable = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@type", key));
            //            int insertIndex = e.RowIndex + 1;

            //            foreach (DataRow cat in categoryTable.Rows)
            //            {
            //                string catName = cat["category_name"].ToString();
            //                string catId = cat["id"].ToString();
            //                dgvSales.Rows.Insert(insertIndex, "e", "u", "2", space + "► " + catName, "", "", "", "", "", "", "", "", catId + "|" + key);
            //                insertIndex++;
            //            }
            //        }
            //        else if (currLvl == 2)
            //        {
            //            // Expand: Category -> Invoice Rows by Item
            //            string[] split = key.Split('|');
            //            int catId = split.Length>1 ? int.Parse(split[0]) : 0;
            //            string itemType = split.Length > 1 ? split[1] : "";

            //            string sql = @"
            //                        SELECT 
            //                            i.id AS id,
            //                            i.name AS item_name,
            //                            s.date,
            //                            s.invoice_id AS num,
            //                            s.bill_to AS customer,
            //                            CONCAT(i.type,' - ' ,ic.name, ' - ',i.name ) AS memo,
            //                            sd.qty,
            //                            sd.price,
            //                            sd.total AS amount,
            //                            (sd.qty * sd.price) - sd.discount AS balance
            //                        FROM 
            //                            tbl_sales_details sd
            //                        JOIN 
            //                            tbl_items i ON sd.item_id = i.id
            //                        JOIN 
            //                            tbl_sales s ON sd.sales_id = s.id
            //                        JOIN 
            //                            tbl_item_category ic ON i.category_id = ic.id
            //                        WHERE 
            //                        i.category_id = @catId AND i.type = @type
            //                        AND s.state = 0
            //                        AND s.date >= @startDate AND s.date <= @endDate
            //                    ORDER BY 
            //                        i.name, s.date;";

            //            DataTable items = DBClass.ExecuteDataTable(sql,
            //                DBClass.CreateParameter("@catId", catId),
            //                DBClass.CreateParameter("@type", itemType),
            //                DBClass.CreateParameter("startDate", dtpFrom.Value.Date),
            //                DBClass.CreateParameter("endDate", dtpTo.Value.Date));

            //            int insertIndex = e.RowIndex + 1;
            //            string currentItem = "";

            //            foreach (DataRow row in items.Rows)
            //            {
            //                string itemName = row["item_name"].ToString();

            //                if (itemName != currentItem)
            //                {
            //                    dgvSales.Rows.Insert(insertIndex, "e", "l", "3", space + "      " + itemName, "", "", "", "", "", "", "", row["id"].ToString());
            //                    insertIndex++;
            //                    currentItem = itemName;
            //                }

            //                dgvSales.Rows.Insert(insertIndex, "n", "l", "4", "",
            //                    Convert.ToDateTime(row["date"]).ToString("dd/MM/yyyy"),
            //                    row["num"], row["memo"], row["customer"],
            //                    FormatNumber(row["qty"]), FormatNumber(row["price"]), FormatNumber(row["amount"]), FormatNumber(row["balance"]), "");
            //                insertIndex++;
            //            }
            //            UpdateTotalsRow();
            //        }
            //        else if (currLvl == 3)
            //        {
            //            // Expand Item → Invoices
            //            int itemId;
            //            if (int.TryParse(key, out itemId))
            //            {
            //                string sql = @"
            //                    SELECT 
            //                        s.date,
            //                        s.invoice_id AS num,
            //                        s.sales_man AS customer,
            //                        s.po_num AS memo,
            //                        sd.qty,
            //                        sd.price,
            //                        sd.total AS amount,
            //                        (sd.qty * sd.price) - sd.discount AS balance
            //                    FROM 
            //                        tbl_sales_details sd
            //                    JOIN 
            //                        tbl_sales s ON sd.sales_id = s.id
            //                    WHERE 
            //                        sd.item_id = @itemId AND s.state = 0
            //                        AND s.date >= @startDate AND s.date <= @endDate
            //                    ORDER BY 
            //                        s.date";

            //                DataTable invoices = DBClass.ExecuteDataTable(sql,
            //                    DBClass.CreateParameter("@itemId", itemId),
            //                    DBClass.CreateParameter("startDate", dtpFrom.Value.Date),
            //                    DBClass.CreateParameter("endDate", dtpTo.Value.Date));
            //                int insertIndex = e.RowIndex + 1;

            //                foreach (DataRow row in invoices.Rows)
            //                {
            //                    dgvSales.Rows.Insert(insertIndex, "n", "l", "4", "",
            //                        Convert.ToDateTime(row["date"]).ToString("dd/MM/yyyy"),
            //                        row["num"], row["memo"], row["customer"],
            //                        FormatNumber(row["qty"]), FormatNumber(row["price"]), FormatNumber(row["amount"]), FormatNumber(row["balance"]), "");
            //                    insertIndex++;
            //                }

            //                dgvSales.Rows[e.RowIndex].Cells["loadState"].Value = "l";
            //                UpdateTotalsRow();
            //            }
            //        }

            //        dgvSales.Rows[e.RowIndex].Cells["colName"].Value = cellValue.Replace("►", "▼");
            //        dgvSales.Rows[e.RowIndex].Cells["state"].Value = "c";
            //    }
            //    else
            //    {
            //        ToggleSalesChildren(e.RowIndex, true);
            //    }
            //}
            //else if (state == "c")
            //{
            //    ToggleSalesChildren(e.RowIndex, false);
            //    dgvSales.Rows[e.RowIndex].Cells["colName"].Value = cellValue.Replace("▼", "►");
            //    dgvSales.Rows[e.RowIndex].Cells["state"].Value = "e";
            //}
            //UpdateTotalsRow();
        }

        private void ToggleSalesChildren(int parentRowIndex, bool visible)
        {
            int parentLevel = int.Parse(dgvSales.Rows[parentRowIndex].Cells["currLvl"].Value.ToString());

            for (int i = parentRowIndex + 1; i < dgvSales.Rows.Count; i++)
            {
                int rowLevel = int.Parse(dgvSales.Rows[i].Cells["currLvl"].Value.ToString());

                if (rowLevel > parentLevel)
                {
                    dgvSales.Rows[i].Visible = visible;

                    if (!visible)
                    {
                        // When collapsing, also reset arrow for children
                        dgvSales.Rows[i].Cells["state"].Value = "e";
                        dgvSales.Rows[i].Cells["loadState"].Value = "l"; // keep as loaded
                        dgvSales.Rows[i].Cells["colName"].Value = dgvSales.Rows[i].Cells["colName"].Value.ToString().Replace("▼", "►");
                    }
                }
                else
                {
                    // Stop once we hit a sibling or parent's sibling
                    break;
                }
            }
            UpdateTotalsRow();
        }
        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //string bItem = dgvSales.Rows[e.RowIndex].Cells["item"].Value.ToString().Trim();
            //if (!string.IsNullOrEmpty(bItem))
            //{
            //    var iId = DBClass.ExecuteScalar("Select id FROM tbl_items where name = @name",DBClass.CreateParameter("name", bItem));
            //    int bId = iId != null ? int.Parse(iId.ToString()) : 0;
            //    new frmManPackingReport(bId).ShowDialog();
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string companyName = lblCompany.Text;

            // Create PDF document
            Document doc = new Document();
            Section section = doc.AddSection();

            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            //==========================================
            // HEADER TABLE
            //==========================================
            Table headerTable = section.AddTable();
            headerTable.Borders.Width = 0;
            headerTable.AddColumn("5cm");
            headerTable.AddColumn("8cm");
            headerTable.AddColumn("5cm");

            Row headerRow = headerTable.AddRow();

            // Left cell: time/date
            Paragraph left = headerRow.Cells[0].AddParagraph();
            left.Format.Font.Name = "Times New Roman";
            left.Format.Font.Size = 10;
            left.Format.Alignment = ParagraphAlignment.Left;
            left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n");
            left.AddText(DateTime.Now.ToString("dd/MM/yyyy"));

            // Center: company name
            Paragraph center = headerRow.Cells[1].AddParagraph();
            center.Format.Font.Name = "Times New Roman";
            center.Format.Alignment = ParagraphAlignment.Center;

            FormattedText companyText = center.AddFormattedText(companyName.ToUpper() + "\n", TextFormat.Bold);
            companyText.Font.Size = 12;

            FormattedText titleText = center.AddFormattedText("PRODUCTION ITEM REPORT\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Production Item Report", TextFormat.NotBold);
            sub.Font.Size = 9;

            // Separator line
            Paragraph line = section.AddParagraph();
            line.Format.Borders.Bottom.Width = 2;
            line.Format.SpaceAfter = "0.5cm";

            //==========================================
            // DATA TABLE
            //==========================================
            Table table = section.AddTable();
            table.Borders.Width = 0.75;
            table.Format.Font.Name = "Times New Roman";
            table.Format.Font.Size = 9;

            // Create columns based on DataGridView columns
            foreach (DataGridViewColumn col in dgvSales.Columns)
            {
                Column tCol = table.AddColumn(Unit.FromCentimeter(3));
                tCol.Format.Alignment = ParagraphAlignment.Left;
            }

            // Add header row
            Row head = table.AddRow();
            head.Shading.Color = Colors.LightGray;
            head.Format.Font.Bold = true;

            for (int i = 0; i < dgvSales.Columns.Count; i++)
            {
                head.Cells[i].AddParagraph(dgvSales.Columns[i].HeaderText);
            }

            //==========================================
            // ADD DATA ROWS
            //==========================================
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                Row tRow = table.AddRow();

                for (int col = 0; col < dgvSales.Columns.Count; col++)
                {
                    string value = row.Cells[col].Value?.ToString() ?? "";

                    var p = tRow.Cells[col].AddParagraph(value);

                    // Align numeric values (warehouse qty)
                    decimal num;
                    if (decimal.TryParse(value, out num))
                    {
                        p.Format.Alignment = ParagraphAlignment.Right;
                    }

                    // Make Type row bold
                    if (col == 0 && !string.IsNullOrWhiteSpace(value) && row.Cells[1].Value.ToString() == "")
                    {
                        p.Format.Font.Bold = true;
                    }

                    // Make Category row italic
                    if (col == 1 && !string.IsNullOrWhiteSpace(value))
                    {
                        p.Format.Font.Italic = true;
                    }
                }
            }

            //==========================================
            // RENDER PDF
            //==========================================
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            // Save file
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Files (*.pdf)|*.pdf";
                dlg.Title = "Production Item Report";
                dlg.FileName = "ProductionItemReport.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(dlg.FileName);
                    Process.Start("explorer.exe", dlg.FileName);
                }
            }
        }

        private void ExpandAllSalesItems()
        {
            for (int i = 0; i < dgvSales.Rows.Count; i++)
            {
                var row = dgvSales.Rows[i];
                string state = row.Cells["state"].Value?.ToString();
                string loadState = row.Cells["loadState"].Value?.ToString();
                int currLvl = int.Parse(row.Cells["currLvl"].Value?.ToString() ?? "0");

                if (state == "e")
                {
                    dgvSales_CellClick(dgvSales, new DataGridViewCellEventArgs(0, i));
                }
            }
            UpdateTotalsRow();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Production Item Report";
                saveDialog.FileName = "ProductionItemReport.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;

                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Production Item Report";

                    // ================================
                    // HEADER (Date and time)
                    // ================================
                    
                    Excel.Range headerRange0 = worksheet.Range["B1", "J1"];
                    headerRange0.Merge();
                    headerRange0.Value = lblCompany.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["B2", "J2"];
                    headerRange1.Merge();
                    headerRange1.Value = guna2HtmlLabel7.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["B3", "J3"];
                    headerRange2.Merge();
                    headerRange2.Value = "From " + dtpFrom.Text + " - To " + dtpTo.Text;
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["A4", "B4"];
                    headerRange3.Merge();
                    headerRange3.Value = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                    headerRange3.Font.Bold = false;
                    headerRange3.Font.Name = "Times New Roman";
                    headerRange3.Font.Size = 9;
                    headerRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    int rowIndex = 5;

                    // ================================
                    // COLUMN HEADERS
                    // ================================
                    int colIndex = 1;
                    for (int col = 0; col < dgvSales.Columns.Count; col++)
                    {
                        var column = dgvSales.Columns[col];

                        // Skip hidden columns if needed
                        if (!column.Visible) continue;

                        var headerCell = worksheet.Cells[rowIndex, col+1];
                        headerCell.Value = column.HeaderText;  // show column header
                        headerCell.Font.Bold = true;
                        headerCell.Font.Name = "Times New Roman";
                        headerCell.Font.Size = 11;
                        headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }
                    rowIndex++;
                    // ================================
                    // DATA ROWS
                    // ================================

                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        if (row.IsNewRow) continue;

                        for (int i = 0; i < dgvSales.Columns.Count; i++)
                        {
                            var column = dgvSales.Columns[i];
                            if (!column.Visible) continue;

                            var value = row.Cells[i].Value;

                            // Set value
                            worksheet.Cells[rowIndex, i + 1] = value;

                            var cell = worksheet.Cells[rowIndex, i + 1];
                            cell.Font.Name = "Times New Roman";
                            cell.Font.Size = 10;

                            // Right-align numeric warehouse columns
                            if (i >= 3) // warehouse and "Main store" start at column index 3
                            {
                                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                        }

                        rowIndex++;
                    }

                    worksheet.Columns.AutoFit();
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Excel exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string FormatNumber(object val)
        {
            decimal result;
            return decimal.TryParse(Convert.ToString(val), out result) ? result.ToString("N2") : "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DateRangeHelper.SetDateRange(comboBox1.SelectedItem.ToString(), dtpFrom, dtpTo);
                LoadData();
            }
        }

        /// <summary>
        /// Calculate totals for visible invoice rows and ensure a bold TOTAL row at the bottom.
        /// </summary>
        private void UpdateTotalsRow()
        {
            if (dgvSales.Rows.Count == 0) return;

            // REMOVE existing Total row if exists
            if (dgvSales.Rows[dgvSales.Rows.Count - 1].Tag != null &&
                dgvSales.Rows[dgvSales.Rows.Count - 1].Tag.ToString() == "TOTAL")
            {
                dgvSales.Rows.RemoveAt(dgvSales.Rows.Count - 1);
            }

            // Create new TOTAL row
            DataGridViewRow totalRow = new DataGridViewRow();
            totalRow.CreateCells(dgvSales);

            // Columns:
            // 0 = type
            // 1 = category
            // 2 = item
            // 3 = main store
            // 4+ = warehouses

            totalRow.Cells[2].Value = "TOTAL:"; // Show TOTAL in Item column

            // === SUM ALL WAREHOUSE COLUMNS (from column 3 onward) ===
            for (int col = 3; col < dgvSales.Columns.Count; col++)
            {
                decimal sum = 0;

                foreach (DataGridViewRow row in dgvSales.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Skip type/category rows → they have blanks in warehouses
                    decimal v;
                    if (decimal.TryParse(row.Cells[col].Value?.ToString(), out v))
                    {
                        sum += v;
                    }
                }

                totalRow.Cells[col].Value = sum.ToString("N2");
            }

            // Style the TOTAL row
            totalRow.DefaultCellStyle.Font = new System.Drawing.Font(dgvSales.Font, FontStyle.Bold);
            totalRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            totalRow.ReadOnly = true;

            // Mark it to detect later
            totalRow.Tag = "TOTAL";

            // Add into DataGridView
            dgvSales.Rows.Add(totalRow);
        }

    }
}