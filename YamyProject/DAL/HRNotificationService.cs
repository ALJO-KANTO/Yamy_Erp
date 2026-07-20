using System;

namespace YamyProject.DAL
{
    public class HRNotificationService
    {
        public static int GetExpiryDocumentCount()
        {
            string sql = @"
        SELECT COUNT(*) FROM
        (
            SELECT id
            FROM tbl_employee
            WHERE active = 0
            AND PassportExpiryDate IS NOT NULL
            AND DATEDIFF(PassportExpiryDate,CURDATE()) <= 60

            UNION ALL

            SELECT id
            FROM tbl_employee
            WHERE active = 0
            AND ResidencyExpiryDate IS NOT NULL
            AND DATEDIFF(ResidencyExpiryDate,CURDATE()) <= 60

            UNION ALL

            SELECT id
            FROM tbl_employee
            WHERE active = 0
            AND EmiratesIDExpiryDate IS NOT NULL
            AND DATEDIFF(EmiratesIDExpiryDate,CURDATE()) <= 30
        ) X";

            return Convert.ToInt32(DBClass.ExecuteScalar(sql));
        }
    }
}
