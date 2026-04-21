using System;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject
{
    public partial class ReportCenter : Form
    {
        public ReportCenter()
        {
            InitializeComponent();
        }

        private void ReportCenter_Load(object sender, EventArgs e)
        {
            // Populate left categories (sample)
            lstCategories.Items.Clear();
            lstCategories.Items.AddRange(new object[]
            {
                "Company & Financial",
                "Customers & Receivables",
                "Sales",
                "Jobs, Time & Mileage",
                "Vendors & Payables",
                "Purchases",
                "Inventory",
                "Employees & Payroll",
                "Banking",
                "Accountant & Taxes",
                "Budgets & Forecasts",
                "List",
                "Retail"
            });
            lstCategories.SelectedIndex = 0;

            // Add a few sample report cards
            flowReports.Controls.Clear();
            flowReports.Controls.Add(CreateReportCard("Company & Financial", "Profit & Loss (income statement)"));
            flowReports.Controls.Add(CreateReportCard("Company & Financial", "Profit & Loss Detail"));
            flowReports.Controls.Add(CreateReportCard("Company & Financial", "Profit & Loss YTD Comparison"));
        }

        private Control CreateReportCard(string category, string title)
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

            // Placeholder thumbnail
            var thumb = new PictureBox
            {
                Location = new Point(12, 60),
                Size = new Size(276, 160),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            // create a simple placeholder image
            thumb.Image = CreatePlaceholderImage(thumb.Size, title);
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

            // Icons row (preview, open, favorite, help)
            var btnPreview = new Button
            {
                Text = "▶",
                Font = new Font("Segoe UI", 9F),
                Size = new Size(32, 28),
                Location = new Point(60, 260),
                FlatStyle = FlatStyle.Flat
            };
            btnPreview.FlatAppearance.BorderSize = 0;
            btnPreview.Click += (s, e) => MessageBox.Show($"Preview '{title}'", "Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
            card.Controls.Add(btnPreview);

            var btnOpen = new Button
            {
                Text = "📄",
                Font = new Font("Segoe UI", 9F),
                Size = new Size(32, 28),
                Location = new Point(100, 260),
                FlatStyle = FlatStyle.Flat
            };
            btnOpen.FlatAppearance.BorderSize = 0;
            btnOpen.Click += (s, e) => MessageBox.Show($"Open '{title}'", "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
            card.Controls.Add(btnOpen);

            var btnFav = new Button
            {
                Text = "❤",
                Font = new Font("Segoe UI", 9F),
                Size = new Size(32, 28),
                Location = new Point(140, 260),
                FlatStyle = FlatStyle.Flat
            };
            btnFav.FlatAppearance.BorderSize = 0;
            btnFav.Click += (s, e) => MessageBox.Show($"Favorited '{title}'", "Favorite", MessageBoxButtons.OK, MessageBoxIcon.Information);
            card.Controls.Add(btnFav);

            var btnHelp = new Button
            {
                Text = "?",
                Font = new Font("Segoe UI", 9F),
                Size = new Size(32, 28),
                Location = new Point(180, 260),
                FlatStyle = FlatStyle.Flat
            };
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.Click += (s, e) => MessageBox.Show($"Help for '{title}'", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            card.Controls.Add(btnHelp);

            return card;
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
    }
}