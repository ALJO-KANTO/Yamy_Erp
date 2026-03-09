using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.DAL
{
    public static class AppTheme
    {
        public static Color PrimaryColor = Color.FromArgb(60, 103, 156);       // Dynamics GP blue
        public static Color SecondaryColor = Color.FromArgb(43, 87, 134);      // Slightly darker blue
        public static Color AccentColor = Color.FromArgb(192, 192, 192);       // Soft gray (used sparingly)

        public static Color BackgroundColor = Color.FromArgb(242, 242, 242);   // Light gray (near white)
        public static Color PanelColor = Color.FromArgb(224, 224, 224);        // Slightly darker gray
        public static Color InputBackgroundColor = Color.White;                // White inputs
        public static Color TextColor = Color.Black;

        public static Color ButtonBackColor = PrimaryColor;
        public static Color ButtonForeColor = Color.White;
        public static Color ButtonHoverColor = SecondaryColor;

        public static Color PrimaryColor1 = Color.FromArgb(207, 221, 238);
        public static Color PrimaryColor2 = Color.FromArgb(38, 50, 56);

        //public static Color PrimaryColor = Color.FromArgb(33, 150, 243);
        //public static Color SecondaryColor = Color.FromArgb(30, 136, 229);
        //public static Color AccentColor = Color.FromArgb(255, 193, 7);
        //public static Color BackgroundColor = Color.WhiteSmoke;
        //public static Color PanelColor = Color.White;
        //public static Color InputBackgroundColor = Color.White;
        //public static Color TextColor = Color.Black;

        //public static Color ButtonBackColor = PrimaryColor;
        //public static Color ButtonForeColor = Color.White;
        //public static Color ButtonHoverColor = SecondaryColor;

        public static void DefaultFont(Guna2DataGridView dgv)
        {
            Font headerFont = new Font("Segoe UI", 8F, FontStyle.Regular);
            Font cellFont = new Font("Segoe UI", 6.6F, FontStyle.Regular);

            // Header
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgv.ThemeStyle.HeaderStyle.Font = headerFont;

            // Cells (VERY IMPORTANT – set all)
            dgv.DefaultCellStyle.Font = cellFont;
            dgv.RowsDefaultCellStyle.Font = cellFont;
            dgv.AlternatingRowsDefaultCellStyle.Font = cellFont;
            dgv.RowTemplate.DefaultCellStyle.Font = cellFont;
            dgv.ThemeStyle.RowsStyle.Font = cellFont;
            dgv.ThemeStyle.AlternatingRowsStyle.Font = cellFont;

            // Optional compact height
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.RowTemplate.Height = 18;
        }

        public static void DefaultFont6(Guna2DataGridView dgv)
        {
            dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 6F, FontStyle.Regular);
        }
    }

}
