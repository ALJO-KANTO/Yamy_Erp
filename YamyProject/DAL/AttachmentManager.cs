namespace YamyProject.DAL
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;

    public class AttachmentManager
    {
        /// <summary>
        /// Save attachment to database
        /// </summary>
        public static void SaveAttachment(
            string referenceType,
            int referenceId,
            string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);
            string fileExt = Path.GetExtension(fileName);

            DBClass.ExecuteNonQuery(
                @"
                INSERT INTO tbl_attachments
                (reference_type, reference_id, file_name, file_type, file_data)
                VALUES
                (@type, @id, @name, @ext, @data)
                ON DUPLICATE KEY UPDATE
                    file_name = VALUES(file_name),
                    file_type = VALUES(file_type),
                    file_data = VALUES(file_data)
                ",
                DBClass.CreateParameter("@type", referenceType),
                DBClass.CreateParameter("@id", referenceId),
                DBClass.CreateParameter("@name", fileName),
                DBClass.CreateParameter("@ext", fileExt),
                DBClass.CreateParameter("@data", fileBytes)
            );


            //DBClass.ExecuteNonQuery(
            //        @"INSERT INTO tbl_attachments
            //      (reference_type, reference_id, file_name, file_type, file_data)
            //      VALUES (@type, @id, @name, @ext, @data)",
            //    DBClass.CreateParameter("@type", referenceType),
            //    DBClass.CreateParameter("@id", referenceId),
            //    DBClass.CreateParameter("@name", fileName),
            //    DBClass.CreateParameter("@ext", fileExt),
            //    DBClass.CreateParameter("@data", fileBytes)
            //);
        }

        /// <summary>
        /// Get attachment list for any document
        /// </summary>
        public static DataTable GetAttachments(
            string referenceType,
            int referenceId)
        {
            return DBClass.ExecuteDataTable(
                        @"SELECT attachment_id, file_name, file_type, uploaded_on
                      FROM tbl_attachments
                      WHERE reference_type = @type
                      AND reference_id = @id",
                DBClass.CreateParameter("@type", referenceType),
                DBClass.CreateParameter("@id", referenceId)
            );
        }

        /// <summary>
        /// Open attachment from database
        /// </summary>
        public static void OpenAttachmentById(int attachmentId)
        {
            DataTable dt = DBClass.ExecuteDataTable(
                    @"SELECT file_name, file_data
                  FROM tbl_attachments
                  WHERE attachment_id = @id",
                DBClass.CreateParameter("@id", attachmentId)
            );

            if (dt.Rows.Count == 0) return;

            byte[] fileData = (byte[])dt.Rows[0]["file_data"];
            string fileName = dt.Rows[0]["file_name"].ToString();

            string tempFile = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid() + "_" + fileName);

            File.WriteAllBytes(tempFile, fileData);
            Process.Start(tempFile);
        }
        public static void OpenAttachmentByType(int reference_id, string attachmentType)
        {
            DataTable dt = DBClass.ExecuteDataTable(
                    @"SELECT file_name, file_data
                  FROM tbl_attachments
                  WHERE reference_id = @id and reference_type = @type",
                DBClass.CreateParameter("@id", reference_id),
                DBClass.CreateParameter("@type", attachmentType)
            );

            if (dt.Rows.Count == 0) return;

            byte[] fileData = (byte[])dt.Rows[0]["file_data"];
            string fileName = dt.Rows[0]["file_name"].ToString();

            string tempFile = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid() + "_" + fileName);

            File.WriteAllBytes(tempFile, fileData);
            Process.Start(tempFile);
        }
        
        public static bool HasAttachment(int purchaseId, string referenceType)
        {
            int count = Convert.ToInt32(DBClass.ExecuteScalar(
                            @"SELECT COUNT(1)
                              FROM tbl_attachments
                              WHERE reference_type = @type
                                AND reference_id = @id",
                            DBClass.CreateParameter("@type", referenceType),
                            DBClass.CreateParameter("@id", purchaseId)
                        ));

            return count > 0;
        }
    }
}
