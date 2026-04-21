using System;
using System.Drawing;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject.UI
{
    public partial class frmNotifications : Form
    {
        public frmNotifications()
        {
            InitializeComponent();
        }

        private void frmNotifications_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            dgv.DataSource = DBClass.ExecuteDataTable(@"
            SELECT 
                notification_id,
                title,
                message,
                notification_type,
                is_read,
                created_at
            FROM tbl_notifications
            ORDER BY is_read ASC, created_at DESC");

            FormatGrid();
        }

        private void FormatGrid()
        {
            dgv.Columns["notification_id"].Visible = false;
            dgv.Columns["is_read"].HeaderText = "Read";
            dgv.Columns["notification_type"].HeaderText = "Type";
            dgv.Columns["created_at"].HeaderText = "Date";

            LocalizationManager.LocalizeDataGridViewHeaders(dgv);
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgv.Rows[e.RowIndex];
            if (row.Cells["notification_id"].Value == null) return;

            bool isRead = Convert.ToBoolean(row.Cells["is_read"].Value);
            string type = row.Cells["notification_type"].Value.ToString();

            if (!isRead)
                row.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);

            if (type == "Alert")
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            else if (type == "Warning")
                row.DefaultCellStyle.BackColor = Color.LightYellow;
            else if (type == "Success")
                row.DefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["notification_id"].Value);

            NotificationService.MarkAsRead(id);

            LoadNotifications();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}