using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Excel = Microsoft.Office.Interop.Excel;

namespace YamyProject
{
    public partial class frmManCategoryWiseItemDetails : Form
    {
        int _itemId;
        public frmManCategoryWiseItemDetails(int itemId)
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
            AddDGVColumns();
            //LoadItemData();
            //LoadCategoryWiseTree();
            LoadData();
        }
        private void LoadData()
        {
            LoadStockReport();
        }
        private void AddDGVColumns()
        {
            dgvSales.Columns.Clear();

            //dgvSales.Columns.Add("state", "state");
            //dgvSales.Columns.Add("loadState", "loadState");
            //dgvSales.Columns.Add("currLvl", "lvl");
            //dgvSales.Columns.Add("colName", "Name");
            //dgvSales.Columns.Add("date", "Date");
            //dgvSales.Columns.Add("num", "Invoice No.");
            //dgvSales.Columns.Add("memo", "Memo");
            //dgvSales.Columns.Add("customer", "Customer");
            //dgvSales.Columns.Add("qty", "Qty");
            //dgvSales.Columns.Add("price", "Price");
            //dgvSales.Columns.Add("amount", "Amount");
            //dgvSales.Columns.Add("balance", "Balance");
            //dgvSales.Columns.Add("id", "ID");

            //dgvSales.Columns["state"].Visible = false;
            //dgvSales.Columns["loadState"].Visible = false;
            //dgvSales.Columns["currLvl"].Visible = false;
            //dgvSales.Columns["id"].Visible = false;

            //dgvSales.Columns["colName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvSales.Columns["qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvSales.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvSales.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvSales.Columns["balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvSales.Columns["qty"].DefaultCellStyle.Format = "N2";
            //dgvSales.Columns["price"].DefaultCellStyle.Format = "N2";
            //dgvSales.Columns["amount"].DefaultCellStyle.Format = "N2";
            //dgvSales.Columns["balance"].DefaultCellStyle.Format = "N2";

            dgvSales.Columns.Add("type", "Type");
            dgvSales.Columns.Add("category", "Category");
            dgvSales.Columns.Add("item", "Item");
            dgvSales.Columns.Add("main", "Main Store");
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id, name FROM tbl_warehouse"))
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    dgvSales.Columns.Add(name, name); 
                    dgvSales.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSales.Columns[name].DefaultCellStyle.Format = "N2";
                }
            }
            dgvSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvSales.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvSales.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvSales.Columns["item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSales.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSales.Columns["category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSales.Columns["type"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvSales);
        }

        private void LoadStockReport()
        {
            dgvSales.Rows.Clear();

            string sql = @"SELECT
                                i.type,
                                CONCAT(c.code, ' - ', c.name) AS category_name,
                                i.name AS item_name,
                                IFNULL(w.name, 'No Warehouse') AS warehouse_name,
                                IFNULL(SUM(t.qty_in - t.qty_out),'') AS qty
                            FROM tbl_items i
                            JOIN tbl_item_category c ON i.category_id = c.id
                            LEFT JOIN tbl_item_transaction t ON i.id = t.item_id
                            LEFT JOIN tbl_warehouse w ON w.id = t.warehouse_id
                            WHERE i.state = 0 ";
            // Add date filter only when needed
            if (!(comboBox1.Text == "" || comboBox1.Text == "All"))
            {
                sql += " AND t.date >= @sDate AND t.date <= @eDate ";
            }
            sql += @"
                            GROUP BY 
                                i.type, c.code, c.name, i.name, w.name
                            ORDER BY 
                                i.type, c.code, i.name, w.name";

            DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("sDate", dtpFrom.Value.Date), DBClass.CreateParameter("eDate", dtpTo.Value.Date));

            if (dt.Rows.Count == 0) return;

            string currentType = "";
            string currentCategory = "";

            // Convert dt → grouped dictionary
            var items = dt.AsEnumerable()
                .GroupBy(r => new
                {
                    Type = r["type"].ToString(),
                    Category = r["category_name"].ToString(),
                    Item = r["item_name"].ToString()
                })
                .ToList();

            foreach (var grp in items)
            {
                string type = grp.Key.Type;
                string category = grp.Key.Category;

                // TYPE row
                if (type != currentType)
                {
                    dgvSales.Rows.Add(type, "", "", "", "");
                    currentType = type;
                    currentCategory = "";
                }

                // CATEGORY row
                if (category != currentCategory)
                {
                    dgvSales.Rows.Add("", "   " + category, "", "", "");
                    currentCategory = category;
                }

                // ITEM row
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvSales);

                row.Cells[0].Value = "";  // Type empty
                row.Cells[1].Value = "";  // Category empty
                row.Cells[2].Value = "      " + grp.Key.Item; // Item

                // Fill all warehouse qty = 0 initially
                for (int i = 3; i < dgvSales.Columns.Count; i++)
                    row.Cells[i].Value = 0;

                // Fill qty for each warehouse
                foreach (var w in grp)
                {
                    string warehouseName = w["warehouse_name"].ToString();
                    string qty = string.IsNullOrEmpty(w["qty"].ToString()) ? "" : decimal.Parse(w["qty"].ToString()).ToString("N2"); //w["qty"].ToString();
                    if (dgvSales.Columns.Contains(warehouseName))
                        row.Cells[dgvSales.Columns[warehouseName].Index].Value = qty;
                }

                dgvSales.Rows.Add(row);
            }
            // total from all after item,type, category columns
            UpdateTotalsRow();
        }

        private void LoadCategoryWiseTree0()
        {
            dgvSales.Rows.Clear();

            string sql = @" 
                            SELECT 
                                i.type,
                                ic.id AS category_id,
                                CONCAT(ic.code, ' - ', ic.name) AS category_name,
                                i.id AS item_id,
                                i.name AS item_name,
                                SUM(t.qty_in - t.qty_out) AS qty
                            FROM tbl_items i
                            JOIN tbl_item_category ic ON i.category_id = ic.id
                            LEFT JOIN tbl_item_transaction t ON t.item_id = i.id
                            WHERE i.state = 0
                            GROUP BY i.type, ic.id, ic.code, ic.name, i.id, i.name
                            ORDER BY i.type, ic.code, i.name";

            DataTable dt = DBClass.ExecuteDataTable(sql);

            if (dt.Rows.Count == 0) return;

            string currentType = "";
            string currentCategory = "";
            int typeRow = -1, catRow = -1;

            foreach (DataRow row in dt.Rows)
            {
                string type = row["type"].ToString();
                string category = row["category_name"].ToString();
                string itemName = row["item_name"].ToString();
                string itemId = row["item_id"].ToString();
                string qty = string.IsNullOrEmpty(row["qty"].ToString()) ? "" : decimal.Parse(row["qty"].ToString()).ToString("N2");

                // LEVEL 1 — TYPE
                if (type != currentType)
                {
                    dgvSales.Rows.Add("e", "u", "1", "► " + type, "", "", "", "", "", "", "", "", "", type);
                    typeRow = dgvSales.Rows.Count - 1;
                    currentType = type;
                    currentCategory = ""; // reset category
                }

                // LEVEL 2 — CATEGORY
                if (category != currentCategory)
                {
                    dgvSales.Rows.Add("e", "u", "2", "      ► " + category, "", "", "", "", "", "", "", "", "", row["category_id"] + "|" + type);
                    catRow = dgvSales.Rows.Count - 1;
                    currentCategory = category;
                }

                // LEVEL 3 — ITEM with Qty
                dgvSales.Rows.Add("e", "u", "3", "            " + itemName, "", "", "", "", qty, "", "", "", itemId);
            }

            UpdateTotalsRow();
        }

        //private void LoadItemData()
        //{
        //    dgvSales.Rows.Clear();

        //    string sql = @"
        //                    SELECT 
        //                        i.id AS item_id,
        //                        i.name AS item_name,
        //                        i.type,
        //                        ic.id AS category_id,
        //                        ic.code,
        //                        ic.name AS category_name
        //                    FROM 
        //                        tbl_items i
        //                    JOIN 
        //                        tbl_item_category ic ON i.category_id = ic.id
        //                    WHERE 
        //                        i.id = @itemId
        //                    AND i.state = 0";

        //    if(_itemId <= 0)
        //        sql = sql.Replace("i.id = @itemId", "1=1"); // Load all items if no specific item is provided
        //    DataTable dt = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@itemId", _itemId));

        //    if (dt.Rows.Count == 0)
        //        return;

        //    var row = dt.Rows[0];

        //    string itemName = row["item_name"].ToString();
        //    string type = row["type"].ToString();
        //    string category = $"{row["code"]} - {row["category_name"]}";
        //    int categoryId = Convert.ToInt32(row["category_id"]);

        //    // Add: Type (Level 1)
        //    dgvSales.Rows.Add("e", "l", "1", "   ▼   " + type, "", "", "", "", "", "", "", "", type);

        //    // Add: Category (Level 2)
        //    dgvSales.Rows.Add("e", "l", "2", "         ▼ " + category, "", "", "", "", "", "", "", "", categoryId + "|" + type);

        //    // Add: Item (Level 3)
        //    dgvSales.Rows.Add("e", "l", "3", "               " + itemName, "", "", "", "", "", "", "", "", _itemId.ToString());

        //    // Add: Invoices (Level 4)
        //    LoadInvoicesForItem(_itemId, dgvSales.Rows.Count - 1);  // insert below item
        //    UpdateTotalsRow();
        //}
        //private void LoadInvoicesForItem(int itemId, int insertIndex)
        //{
        //    string sql = @"
        //                SELECT 
        //                sd.sales_id AS sales_id,
        //                i.id AS item_id,
        //                i.name AS item_name,
        //                s.date,
        //                s.invoice_id AS num,
        //                s.bill_to AS customer,
        //                CONCAT(i.type,' - ' ,i.name, ' - ', ic.name) AS memo,
        //                sd.qty,
        //                sd.price,
        //                sd.total AS amount,
        //                (sd.qty * sd.price) - sd.discount AS balance
        //                FROM 
        //                tbl_sales_details sd
        //                JOIN 
        //                tbl_items i ON sd.item_id = i.id
        //                JOIN 
        //                tbl_sales s ON sd.sales_id = s.id
        //                JOIN 
        //                tbl_item_category ic ON i.category_id = ic.id
        //                WHERE 
        //                sd.item_id = @itemId AND s.state = 0
        //                AND s.date >= @startDate AND s.date <= @endDate
        //                ORDER BY s.date";

        //    DataTable invoices = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@itemId", itemId),
        //        DBClass.CreateParameter("startDate", dtpFrom.Value.Date),
        //        DBClass.CreateParameter("endDate", dtpTo.Value.Date));

        //    foreach (DataRow row in invoices.Rows)
        //    {
        //        dgvSales.Rows.Insert(insertIndex + 1, "n", "l", "4", "",
        //            Convert.ToDateTime(row["date"]).ToString("dd/MM/yyyy"),
        //            row["num"], row["memo"], row["customer"],
        //            FormatNumber(row["qty"].ToString()), FormatNumber(row["price"]), FormatNumber(row["amount"]), FormatNumber(row["balance"]), row["sales_id"]);
        //        insertIndex++;
        //    }
        //    UpdateTotalsRow();
        //}
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

            string bItem = dgvSales.Rows[e.RowIndex].Cells["item"].Value.ToString().Trim();
            if (!string.IsNullOrEmpty(bItem))
            {
                var iId = DBClass.ExecuteScalar("Select id FROM tbl_items where name = @name",DBClass.CreateParameter("name", bItem));
                int bId = iId != null ? int.Parse(iId.ToString()) : 0;
                new frmManPackingReport(bId).ShowDialog();
            }
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

            FormattedText titleText = center.AddFormattedText("PRODUCTION STOCK REPORT\n", TextFormat.Bold);
            titleText.Font.Size = 12;

            FormattedText sub = center.AddFormattedText("Production Report", TextFormat.NotBold);
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
                dlg.Title = "Production Stock Report";
                dlg.FileName = "ProductionStockReport.pdf";

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
                saveDialog.Title = "Production Stock Report";
                saveDialog.FileName = "ProductionStockReport.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;

                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Production Stock Report";

                    // ================================
                    // HEADER (Date and time)
                    // ================================
                    
                    Excel.Range headerRange0 = worksheet.Range["B1", "C1"];
                    headerRange0.Merge();
                    headerRange0.Value = lblCompany.Text;
                    headerRange0.Font.Bold = true;
                    headerRange0.Font.Name = "Times New Roman";
                    headerRange0.Font.Size = 12;
                    headerRange0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange1 = worksheet.Range["B2", "C2"];
                    headerRange1.Merge();
                    headerRange1.Value = guna2HtmlLabel7.Text;
                    headerRange1.Font.Bold = true;
                    headerRange1.Font.Name = "Times New Roman";
                    headerRange1.Font.Size = 11;
                    headerRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    Excel.Range headerRange2 = worksheet.Range["B3", "C3"];
                    headerRange2.Merge();
                    headerRange2.Value = "From " + dtpFrom.Text + " - To " + dtpTo.Text;
                    headerRange2.Font.Bold = false;
                    headerRange2.Font.Name = "Times New Roman";
                    headerRange2.Font.Size = 9;
                    headerRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    // Merge and format header row (Date)
                    Excel.Range headerRange3 = worksheet.Range["B4", "C4"];
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