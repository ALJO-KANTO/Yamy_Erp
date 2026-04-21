using System;

namespace YamyProject.DAL
{
    public static class NotificationService
    {
        public static void Add(int projectId, int? phaseId, int? taskId,
            string title, string message, string type = "Info")
        {
            // 1. Insert notification
            int notificationId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                INSERT INTO tbl_notifications
                (project_id, phase_id, task_id, user_id, title, message, notification_type)
                VALUES
                (@project_id, @phase_id, @task_id, NULL, @title, @message, @type);
                SELECT LAST_INSERT_ID();",

                DBClass.CreateParameter("@project_id", projectId),
                DBClass.CreateParameter("@phase_id", (object)phaseId ?? DBNull.Value),
                DBClass.CreateParameter("@task_id", (object)taskId ?? DBNull.Value),
                DBClass.CreateParameter("@title", title),
                DBClass.CreateParameter("@message", message),
                DBClass.CreateParameter("@type", type)
            ));

            // 2. Assign to ALL users
            DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_notification_users (notification_id, user_id)
                SELECT @nid, id FROM tbl_sec_users",
                DBClass.CreateParameter("@nid", notificationId));
        }

        public static int GetUnreadCount(int userId)
        {
            object result = DBClass.ExecuteScalar(@"
                SELECT COUNT(*)
                FROM tbl_notification_users nu
                INNER JOIN tbl_notifications n ON n.notification_id = nu.notification_id
                WHERE nu.user_id = @uId AND nu.is_read = 0",
                DBClass.CreateParameter("@uId", userId));

            return Convert.ToInt32(result);
        }

        public static void MarkAsRead(int notificationId)
        {
            DBClass.ExecuteNonQuery(@"
                UPDATE tbl_notifications
                SET is_read = 1
                WHERE notification_id = @id",
                DBClass.CreateParameter("@id", notificationId));
        }

        public static void MarkAllAsRead(int notificationId, int userId)
        {
            DBClass.ExecuteNonQuery(@"
                UPDATE tbl_notification_users
                SET is_read = 1, read_at = NOW()
                WHERE user_id = @uId AND is_read = 0 and notification_id = @id",
                DBClass.CreateParameter("@uId", userId),
                DBClass.CreateParameter("@id", notificationId)
                );
        }
    }
}