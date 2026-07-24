using System;
using System.Data;
using YamyProject;
using YamyProject.DAL;

namespace YamyProject.UI.HR
{
    public class HRDocumentExpiryNotification
    {
        public static DataTable CheckExpiry()
        {
            string query = @"
                SELECT 
                    id,
                    name,
                    'Passport' Document,
                    PassportExpiryDate ExpiryDate,
                    DATEDIFF(PassportExpiryDate,CURDATE()) RemainingDays
                FROM tbl_employee
                WHERE active=0
                AND PassportExpiryDate IS NOT NULL
                AND DATEDIFF(PassportExpiryDate,CURDATE()) <= 60

                UNION ALL

                SELECT 
                    id,
                    name,
                    'Visa',
                    ResidencyExpiryDate,
                    DATEDIFF(ResidencyExpiryDate,CURDATE())
                FROM tbl_employee
                WHERE active=0
                AND ResidencyExpiryDate IS NOT NULL
                AND DATEDIFF(ResidencyExpiryDate,CURDATE()) <= 60

                UNION ALL

                SELECT 
                    id,
                    name,
                    'Emirates ID',
                    EmiratesIDExpiryDate,
                    DATEDIFF(EmiratesIDExpiryDate,CURDATE())
                FROM tbl_employee
                WHERE active=0
                AND EmiratesIDExpiryDate IS NOT NULL
                AND DATEDIFF(EmiratesIDExpiryDate,CURDATE()) <= 30
                ";


            DataTable dt = DBClass.ExecuteDataTable(query);


            //foreach (DataRow row in dt.Rows)
            //{
            //    CreateNotification(
            //        row["name"].ToString(),
            //        row["Document"].ToString(),
            //        Convert.ToDateTime(row["ExpiryDate"]),
            //        row["RemainingDays"].ToString()
            //    );
            //}
            return dt;
        }

        private static void CreateNotification(
            string employee,
            string document,
            DateTime expiryDate,
            string days)
        {

            string title = "Employee Document Expiry";

            string message = $"{employee} {document} will expire on {expiryDate:dd/MM/yyyy}. Remaining {days} days";
            string message0 = $"{employee} {document} will expire on {expiryDate:dd/MM/yyyy}";

            //if(!NotificationService.Exist(title,message0))
            //    NotificationService.Add(0, 0, 0, title, message);

    //        string query = @"
    //INSERT INTO tbl_notifications
    //(
    //    title,
    //    message,
    //    notification_type,
    //    created_at
    //)
    //VALUES
    //(
    //    @title,
    //    @message,
    //    'HR',
    //    NOW()
    //)";


            //        DBClass.ExecuteNonQuery(query,
            //            DBClass.CreateParameter("@title", title),
            //            DBClass.CreateParameter("@message", message)
            //        );


            //        int notificationId = Convert.ToInt32(
            //            DBClass.ExecuteScalar("SELECT LAST_INSERT_ID()")
            //        );


            //        // Send to HR users
            //        string userQuery = @"
            //INSERT INTO tbl_notification_users
            //(
            //    notification_id,
            //    user_id,
            //    is_read
            //)
            //SELECT
            //    @notificationId,
            //    id,
            //    0
            //FROM tbl_sec_users
            //WHERE role='HR'";


            //        DBClass.ExecuteNonQuery(userQuery,
            //            DBClass.CreateParameter("@notificationId", notificationId));
        }
    }
}