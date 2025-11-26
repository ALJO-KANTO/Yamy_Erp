using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Reports
{
    public partial class ReportCenter : Form
    {
        // map normalized category text -> color used for selected background
        private Dictionary<string, Color> _categoryColors;

        public ReportCenter()
        {
            InitializeComponent(); InitializeCategoryColors();
        }

        private void InitializeCategoryColors()
        {
            // keys are normalized versions of the displayed items (see NormalizeCategory)
            _categoryColors = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
            {
                { NormalizeCategory("Company & Financial"), Color.FromArgb(23, 41, 83) },     // dark blue
                { NormalizeCategory("Customers & Receivables"), Color.FromArgb(0, 120, 215) }, // blue
                { NormalizeCategory("Sales"), Color.FromArgb(0, 153, 51) },                   // green
                { NormalizeCategory("Vendors & Payables"), Color.FromArgb(188, 80, 0) },      // orange-brown
                { NormalizeCategory("Purchases"), Color.FromArgb(128, 0, 128) },              // purple
                { NormalizeCategory("Inventory"), Color.FromArgb(0, 153, 153) },              // teal
                { NormalizeCategory("Employees & Payroll"), Color.FromArgb(153, 51, 0) },     // brown
                { NormalizeCategory("Banking"), Color.FromArgb(0, 82, 204) },                 // deep blue
                { NormalizeCategory("Accountant & Taxes"), Color.FromArgb(204, 0, 0) },       // red
                { NormalizeCategory("List"), Color.FromArgb(96, 96, 96) },                    // gray
                { NormalizeCategory("Retail"), Color.FromArgb(255, 102, 0) }                  // orange
            };
        }

        private static string NormalizeCategory(string s)
        {
            // Designer used "&&" to escape &, normalize to single &
            return s?.Replace("&", "&&").Trim() ?? string.Empty;
        }

        private void ReportCenter_Load(object sender, EventArgs e)
        {
            headerUC1.FormText = this.Text;
            // Populate left categories (sample)
            lstCategories.Items.Clear();
            lstCategories.Items.AddRange(new object[]
            {
                "Company & Financial",
                "Customers & Receivables",
                "Sales",
                "Vendors & Payables",
                "Purchases",
                "Inventory",
                "Employees & Payroll",
                "Banking",
                "Accountant & Taxes",
                "List",
                "Retail"
            });
            lstCategories.SelectedIndex = 0;

            selectedCategory();
        }

        private Control CreateReportCard(string category, string title, Image image)
        {
            // Outer panel that resembles a card
            var card = new Panel
            {
                Width = 300,
                Height = 320,
                Margin = new Padding(12),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Title area
            var lblCategory = new Label
            {
                Text = category,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(12, 8),
                AutoSize = true
            };
            card.Controls.Add(lblCategory);

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(12, 30),
                AutoSize = true
            };
            card.Controls.Add(lblTitle);

            //// Placeholder thumbnail
            //var thumb = new PictureBox
            //{
            //    Location = new Point(12, 60),
            //    Size = new Size(276, 160),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.CenterImage
            //};
            //// create a simple placeholder image
            //thumb.Image = CreatePlaceholderImage(thumb.Size, title);
            //card.Controls.Add(thumb);
            // Picture area -- use provided image or try resources, fallback to placeholder
            var thumb = new PictureBox
            {
                Location = new Point(12, 58),
                Size = new Size(276, 160),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            thumb.Image = image ?? GetReportImage(title) ?? CreatePlaceholderImage(thumb.Size, title);
            card.Controls.Add(thumb);

            // Dates row
            var lblDates = new Label
            {
                Text = "Dates:",
                Location = new Point(12, 230),
                AutoSize = true
            };
            card.Controls.Add(lblDates);

            var dtFrom = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(60, 226),
                Width = 100,
                Value = DateTime.Today.AddDays(-30)
            };
            card.Controls.Add(dtFrom);

            var dtTo = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(170, 226),
                Width = 100,
                Value = DateTime.Today
            };
            card.Controls.Add(dtTo);

            // Icons row (preview, open, favorite, help) - small flat buttons
            var btnPreview = CreateIconButton("▶", new Point(60, 259), (s, e) => MessageBox.Show($"Preview '{title}'"));
            card.Controls.Add(btnPreview);

            var btnOpen = CreateIconButton("📄", new Point(100, 259), (s, e) => MessageBox.Show($"Open '{title}'"));
            card.Controls.Add(btnOpen);

            var btnFav = CreateIconButton("❤", new Point(140, 259), (s, e) => MessageBox.Show($"Favorited '{title}'"));
            card.Controls.Add(btnFav);

            var btnHelp = CreateIconButton("?", new Point(180, 259), (s, e) => MessageBox.Show($"Help for '{title}'"));
            card.Controls.Add(btnHelp);

            return card;
        }

        private Button CreateIconButton(string text, Point location, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 9F),
                Size = new Size(32, 28),
                Location = location,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                TabStop = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += onClick;
            return btn;
        }

        private Image GetReportImage(string title)
        {
            if (string.IsNullOrEmpty(title)) return null;

            var rm = new ComponentResourceManager(typeof(ReportCenter));
            // try a few keys to match resource names
            string[] candidates = new[]
            {
                title,
                SanitizeKey(title),
                title.Replace("&", "and"),
                SanitizeKey(title.Replace("&", "and"))
            };

            foreach (var key in candidates)
            {
                try
                {
                    var obj = rm.GetObject(key);
                    if (obj is Image) return (Image)obj;
                }
                catch { /* ignore */ }
            }

            return null;
        }

        private static string SanitizeKey(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c)) sb.Append(char.ToLowerInvariant(c));
                else sb.Append('_');
            }
            var res = Regex.Replace(sb.ToString(), "_{2,}", "_").Trim('_');
            return res;
        }

        private Image CreatePlaceholderImage(Size size, string title)
        {
            var bmp = new Bitmap(size.Width, size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(250, 250, 250));
                using (var pen = new Pen(Color.LightGray))
                {
                    g.DrawRectangle(pen, 4, 4, size.Width - 9, size.Height - 9);
                }

                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                using (var font = new Font("Segoe UI", 9F))
                using (var brush = new SolidBrush(Color.Gray))
                {
                    g.DrawString(title, font, brush, new RectangleF(0, 0, size.Width, size.Height), sf);
                }
            }
            return bmp;
        }
        // Owner-draw handler to decorate selected background and draw a left accent
        private void lstCategories_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            var lb = (ListBox)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            string rawText = lb.Items[e.Index].ToString();
            string normalized = NormalizeCategory(rawText);

            Color normalBack = lb.BackColor;
            Color normalFore = lb.ForeColor;

            // get color for this category if available, otherwise fallback
            Color catColor;
            //if (!_categoryColors.TryGetValue(normalized, out catColor))
                catColor = Color.FromArgb(23, 41, 83); // default selected color

            // derive accent and contrasting text color
            Color selectedBack = Color.FromArgb(23, 41, 83); //catColor;
            Color accentBarColor = Color.FromArgb(18, 32, 64);  //ShadeColor(catColor, 0.8f);
            Color selectedFore = Color.White; //GetContrastColor(selectedBack);

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            // Fill background
            using (var bgBrush = new SolidBrush(selected ? selectedBack : normalBack))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            // Draw a left accent bar when selected
            if (selected)
            {
                var barRect = new Rectangle(e.Bounds.Left + 6, e.Bounds.Top + 8, 6, e.Bounds.Height - 16);
                using (var barBrush = new SolidBrush(accentBarColor))
                {
                    e.Graphics.FillRectangle(barBrush, barRect);
                }
            }

            // Text area with padding
            var textColor = selected ? selectedFore : normalFore;
            var textRect = new Rectangle(e.Bounds.Left + 18, e.Bounds.Top + (e.Bounds.Height - e.Font.Height) / 2, e.Bounds.Width - 20, e.Font.Height);
            TextRenderer.DrawText(e.Graphics, normalized, e.Font, textRect, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            // Draw focus rectangle if needed
            e.DrawFocusRectangle();
        }

        // ensure redraw on selection change
        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCategories.Invalidate();
            selectedCategory();
        }

        private void selectedCategory()
        {
            int selectedIndex = lstCategories.SelectedIndex;
            if (selectedIndex < 0)
                return;

            // clear current cards
            flowReports.Controls.Clear();

            if (selectedIndex == 0)
            {// Company & Financial
                lblHeader.Text = "Company && Financial";

                var titles = new[]
                                {
                                    "Profit && Loss Standard",
                                    "Profit && Loss Detail",
                                    "Profit && Loss YTD Comparison",
                                    "Profit && Loss Prev Year Comparison",
                                    "Profit && Loss by Job",
                                    "Profit && Loss by Class",
                                    "Profit && Loss Unclassified"
                                };

                var images = new[]
                {
                    Properties.Resources.P_and_L_standard,
                    Properties.Resources.P_and_L_details,
                    Properties.Resources.P_and_L_ytd_comparison,
                    Properties.Resources.P_and_L_Prev_Y_Comparison,
                    Properties.Resources.P_and_L_by_Job,
                    Properties.Resources.P_and_L_by_Class,
                    Properties.Resources.P_and_L_standard,
                };

                for (int i = 0; i < titles.Length; i++)
                {
                    flowReports.Controls.Add(CreateReportCard(titles[i], "Company && Financial", images[i]));
                }
            }
            else if (selectedIndex == 1)
            {// Customers & Receivables
                lblHeader.Text = "Customers && Receivables";
                var titles = new[]
                                {
                                    "A/R Aging Summary",
                                    "A/R Aging Detail",
                                    "Accounts Receivable Graph",
                                    "Open Invoices",
                                    "Collections Report",
                                    "Average Days to Pay Summary",
                                    "Average Days to Pay",
                                    "Customer Balance Summary",
                                    "Customer Balance Detail",
                                    "Unbilled Costs by Job",
                                    "Transaction List by Customer",
                                    "Customer Phone List",
                                    "Customer Contact List",
                                    "Item Price List"
                                };

                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard( title, "Customers && Receivables",null));
                }
            }
            else if (selectedIndex == 2)
            {// Sales
                lblHeader.Text = "Sales";
                var titles = new[]
                                {
                    "Sales by Customer Summary",
                    "Sales by Customer Detail",
                    "Sales by Ship To Address",
                    "Pending Sales",
                    "Sales Graph",
                    "Sales by Item Summary",
                    "Sales by Item Detail",
                    "Sales by Rep Summary",
                    "Sales by Rep Detail"
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Sales", null));
                }
            }
            else if (selectedIndex == 3)
            {
                // Vendors & Payables
                lblHeader.Text = "Vendors && Payables";
                var titles = new[]
                                {
                    "A/P Aging Summary",
                    "A/P Aging Detail",
                    "Accounts Payable Graph",
                    "Vendor Balance Summary",
                    "Vendor Balance Detail",
                    "Unpaid Bills Detail",
                    "Transaction List by Vendor",
                    "Sales Tax Liability",
                    "Sales Tax Revenue Summary",
                    "Vendor Phone List",
                    "Vendor Contact List"
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Vendors && Payables", null));
                }
            }
            else if (selectedIndex == 4)
            {
                // Purchases
                lblHeader.Text = "Purchases";
                
                var titles = new[]
                                {
                    "Purchase by Vendor Summary",
                    "Purchase by Vendor Detail",
                    "Purchase by Item Summary",
                    "Purchase by Item Detail",
                    "Open Purchase Orders",
                    "Open Purchase Order Detail",
                    "Open Purchase Order By Job"
                };

                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Purchases", null));
                }
            }
            else if (selectedIndex == 5)
            {
                // Inventory
                lblHeader.Text = "Inventory";
                
                var titles = new[]
                                {
                    "Inventory Valuation Summary",
                    "Inventory Valuation Detail",
                    "Inventory Stock Status by Item",
                    "Inventory Stock Status by Vendor",
                    "Physical Inventory Worksheet",
                    "Pending Builds"
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Inventory", null));
                }
            }
            else if (selectedIndex == 6)
            {
                // Employees & Payroll
                lblHeader.Text = "Employees && Payroll";
                
                var titles = new[]
                                {
                    "Employee Contact List"
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Employees && Payroll", null));
                }
            }
            else if (selectedIndex == 7)
            {
                // Banking
                lblHeader.Text = "Banking";
                
                var titles = new[]
                                {
                    "Deposit Detail",
                    "Check Detail",
                    "Missing Checks",
                    "Reconciliation Discrepancy",
                    "Previous Reconciliation"
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Banking", null));
                }
            }
            else if (selectedIndex == 8)
            {
                // Accountant & Taxes
                lblHeader.Text = "Accountant && Taxes";
                
                var titles = new[]
                                {
                    "Adjusted Trial Balance",
                    "Adjusting Journal Entries",
                    "Trial Balance",
                    "General Ledger",
                    "Transaction Detail by Account",
                    "Journal",
                    "Audit Trail",
                    "Closing Date Exception Report",
                    "Voided/Deleted Transactions Summary",
                    "Voided/Deleted Transactions Detail",
                    "Transaction List by Date",
                    "Account Listing",
                    "Fixed Asset Listing",
                    "Income Tax Preparation",
                    "Income Tax Summary",
                    "Income Tax Detail"
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Accountant && Taxes", null));
                }
            }
            else if (selectedIndex == 9)
            {
                // List
                lblHeader.Text = "List";
                
                var titles = new[]
                                {
                    "Customer Phone List",
                    "Customer Contact List",
                    "Vendor Phone List",
                    "Vendor Contact List",
                    "Employee Contact List",
                    "Other Names Phone List",
                    "Other Names Contact List",
                    "Account Listing",
                    "Item Price List",
                    "Item Listing",
                    "Fixed Asset Listing",
                    "Terms Listing",
                    "To Do Notes",
                    "Memorized Transaction Listing"
                };

                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "List", null));
                }
            }
            else if (selectedIndex == 10)
            {
                // Retail
                lblHeader.Text = "Retail";

                var titles = new[]
                {
                    "Profit && Loss Monthly Comparison",
                    "Balance Sheet Monthly Comparison",
                    "Sales Graph",
                    "Monthly Sales by Customer",
                    "Gross Margin by Inventory Item",
                    "Customer Payments by Payment Item",
                    "Bill by Due Date",
                    "Sales Tax Liability",
                    "Purchase Volume by Vendor",
                    "Vendor Returns Summary",
                    "Vendor Returns Detail",
                    "Open Purchase Orders by Vendor",
                    "Accounts Payable Graph",
                };
                foreach (var title in titles)
                {
                    flowReports.Controls.Add(CreateReportCard(title, "Retail", null));
                }
            }
        }
        // helper: create a table row with 3 equal columns and add the three controls into each column
        private void AddRowThreeCards(Control left, Control middle, Control right)
        {
            var tbl = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 1,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            tbl.ColumnStyles.Clear();
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));

            // wrap each control in a Panel so card stays centered in the column
            Control[] controls = new Control[] { left, middle, right };
            for (int i = 0; i < 3; i++)
            {
                var cell = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0), Margin = new Padding(0) };
                var c = controls[i];
                if (c != null)
                {
                    c.Anchor = AnchorStyles.None;
                    // ensure control has correct margin/size
                    cell.Controls.Add(c);
                }
                tbl.Controls.Add(cell, i, 0);
            }

            flowReports.Controls.Add(tbl);
        }

        // helper: create a row where the card is centered (placed in middle column)
        private void AddRowCenteredCard(Control card)
        {
            var tbl = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 1,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            tbl.ColumnStyles.Clear();
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));

            var leftCell = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0), Margin = new Padding(0) };
            var centerCell = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0), Margin = new Padding(0) };
            var rightCell = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0), Margin = new Padding(0) };

            card.Anchor = AnchorStyles.None;
            centerCell.Controls.Add(card);

            tbl.Controls.Add(leftCell, 0, 0);
            tbl.Controls.Add(centerCell, 1, 0);
            tbl.Controls.Add(rightCell, 2, 0);

            flowReports.Controls.Add(tbl);
        }

        // return a contrasting color (white or black) for readability
        private static Color GetContrastColor(Color bg)
        {
            // Perceived luminance
            double l = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return l > 0.5 ? Color.Black : Color.White;
        }

        // darken or lighten a color by factor (<1 darken, >1 lighten)
        private static Color ShadeColor(Color color, float factor)
        {
            int r = (int)Math.Min(255, Math.Max(0, color.R * factor));
            int g = (int)Math.Min(255, Math.Max(0, color.G * factor));
            int b = (int)Math.Min(255, Math.Max(0, color.B * factor));
            return Color.FromArgb(color.A, r, g, b);
        }
    }
}