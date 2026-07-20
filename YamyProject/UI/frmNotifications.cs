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
            string query = @"
            SELECT n.notification_id,
            n.title,
            n.message,
            n.notification_type,
            nu.is_read,
            n.created_at FROM tbl_notifications n INNER JOIN tbl_notification_users nu ON nu.notification_id = n.notification_id WHERE nu.user_id=@uId";

            query += " ORDER BY nu.is_read ASC, n.created_at DESC";
            
            dgv.DataSource = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@uId", frmLogin.userId));

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

            //NotificationService.MarkAsRead(id);

            //LoadNotifications();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //bool isRead = Convert.ToBoolean(row.Cells["is_read"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "is_read")
            {
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["notification_id"].Value);
                NotificationService.MarkAllAsRead(id, frmLogin.userId);

                //LoadNotifications();
            }
        }
    }
}