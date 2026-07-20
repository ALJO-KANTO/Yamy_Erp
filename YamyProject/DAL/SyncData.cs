using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Vml;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static YamyProject.BindCombos;

namespace YamyProject.DAL
{
    public class SyncData
    {
        public static object hostedUrl { get; set; } // = "http://localhost:8600/";

        public static async Task UploadCoaLevel2()
        {
            var list = GetCoaLevel2ForSync();

            if (list.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(list);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response =
                    await client.PostAsync($"{hostedUrl}api/sync/upload-coa-level-2",
                        content);

                string result = await response.Content.ReadAsStringAsync();

                //MessageBox.Show(result);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_coa_level_2
                    SET SyncStatus = 1
                    WHERE SyncStatus = 0");
                }
            }
        }
        public static List<CoaLevel2SyncDto> GetCoaLevel2ForSync()
        {
            List<CoaLevel2SyncDto> list = new List<CoaLevel2SyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_coa_level_2
        WHERE SyncStatus = 0
    ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CoaLevel2SyncDto
                {
                    name = row["name"].ToString(),
                    code = Convert.ToInt32(row["code"]),
                    main_id = Convert.ToInt32(row["main_id"])
                });
            }

            return list;
        }
        public static async Task DownloadCoaLevel2()
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-coa-level-2?lastSync=2000-01-01";

                string json = await client.GetStringAsync(url);

                List<CoaLevel2SyncDto> list =
                    JsonConvert.DeserializeObject<List<CoaLevel2SyncDto>>(json);

                foreach (var item in list)
                {
                    int exists = Convert.ToInt32(DBClass.ExecuteScalar(@"
                SELECT COUNT(*) 
                FROM tbl_coa_level_2 
                WHERE code = @code AND main_id = @main_id",
                        DBClass.CreateParameter("@code", item.code),
                        DBClass.CreateParameter("@main_id", item.main_id)
                    ));

                    if (exists == 0)
                    {
                        DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_coa_level_2
                    (
                        name,
                        code,
                        main_id
                    )
                    VALUES
                    (
                        @name,
                        @code,
                        @main_id
                    )",
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@main_id", item.main_id)
                        );
                    }
                    else
                    {
                        DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_coa_level_2
                    SET name = @name
                    WHERE code = @code AND main_id = @main_id",
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@main_id", item.main_id)
                        );
                    }
                }
            }
        }
        public static async Task DownloadCoaLevel3()
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-coa-level-3?lastSync=2000-01-01";

                string json = await client.GetStringAsync(url);

                List<CoaLevel3SyncDto> list =
                    JsonConvert.DeserializeObject<List<CoaLevel3SyncDto>>(json);

                foreach (var item in list)
                {
                    int exists = Convert.ToInt32(DBClass.ExecuteScalar(@"
                SELECT COUNT(*) 
                FROM tbl_coa_level_3 
                WHERE code = @code AND main_id = @main_id",
                        DBClass.CreateParameter("@code", item.code),
                        DBClass.CreateParameter("@main_id", item.main_id)
                    ));

                    if (exists == 0)
                    {
                        DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_coa_level_3
                    (
                        name,
                        code,
                        main_id
                    )
                    VALUES
                    (
                        @name,
                        @code,
                        @main_id
                    )",
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@main_id", item.main_id)
                        );
                    }
                    else
                    {
                        DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_coa_level_3
                    SET name = @name
                    WHERE code = @code AND main_id = @main_id",
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@main_id", item.main_id)
                        );
                    }
                }
            }
        }
        public static async Task UploadCoaLevel3()
        {
            var list = GetCoaLevel3ForSync();

            if (list.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(list);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-coa-level-3",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                UPDATE tbl_coa_level_3
                SET SyncStatus = 1
                WHERE SyncStatus = 0");
                }
            }
        }
        public static List<CoaLevel3SyncDto> GetCoaLevel3ForSync()
        {
            List<CoaLevel3SyncDto> list = new List<CoaLevel3SyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_coa_level_3
        WHERE SyncStatus = 0
    ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CoaLevel3SyncDto
                {
                    name = row["name"].ToString(),
                    code = Convert.ToInt32(row["code"]),
                    main_id = Convert.ToInt32(row["main_id"])
                });
            }

            return list;
        }
        public static async Task DownloadCoaLevel4()
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-coa-level-4?lastSync=2000-01-01";

                string json = await client.GetStringAsync(url);

                List<CoaLevel4SyncDto> list =
                    JsonConvert.DeserializeObject<List<CoaLevel4SyncDto>>(json);

                foreach (var item in list)
                {
                    int exists = Convert.ToInt32(DBClass.ExecuteScalar(@"
                SELECT COUNT(*) 
                FROM tbl_coa_level_4 
                WHERE code = @code AND main_id = @main_id",
                        DBClass.CreateParameter("@code", item.code),
                        DBClass.CreateParameter("@main_id", item.main_id)
                    ));

                    if (exists == 0)
                    {
                        DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_coa_level_4
                    (
                        name,
                        code,
                        main_id,
                        debit,
                        credit,
                        date
                    )
                    VALUES
                    (
                        @name,
                        @code,
                        @main_id,
                        @debit,
                        @credit,
                        @date
                    )",
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@main_id", item.main_id),
                            DBClass.CreateParameter("@debit", item.debit),
                            DBClass.CreateParameter("@credit", item.credit),
                            DBClass.CreateParameter("@date", item.date)
                        );
                    }
                    else
                    {
                        DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_coa_level_4
                    SET 
                        name = @name,
                        debit = @debit,
                        credit = @credit,
                        date = @date
                    WHERE code = @code AND main_id = @main_id",
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@debit", item.debit),
                            DBClass.CreateParameter("@credit", item.credit),
                            DBClass.CreateParameter("@date", item.date),
                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@main_id", item.main_id)
                        );
                    }
                }
            }
        }
        public static async Task UploadCoaLevel4()
        {
            var list = GetCoaLevel4ForSync();

            if (list.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(list);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-coa-level-4",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                UPDATE tbl_coa_level_4
                SET SyncStatus = 1
                WHERE SyncStatus = 0");
                }
            }
        }
        public static List<CoaLevel4SyncDto> GetCoaLevel4ForSync()
        {
            List<CoaLevel4SyncDto> list = new List<CoaLevel4SyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_coa_level_4
        WHERE SyncStatus = 0
    ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CoaLevel4SyncDto
                {
                    name = row["name"].ToString(),
                    code = Convert.ToInt32(row["code"]),
                    main_id = Convert.ToInt32(row["main_id"]),
                    debit = row["debit"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["debit"]),
                    credit = row["credit"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["credit"]),
                    date = row["date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["date"])
                });
            }

            return list;
        }
        public static async Task UploadCustomers()
        {
            try
            {
                var customers = GetCustomersForSync();

                if (customers.Count == 0)
                {
                    //MessageBox.Show("No records to sync");
                    return;
                }

                string json = JsonConvert.SerializeObject(customers);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                    HttpResponseMessage response =
                        await client.PostAsync(
                            $"{hostedUrl}api/Sync/upload-customers",
                            content);

                    string result =
                        await response.Content.ReadAsStringAsync();

                    //MessageBox.Show(result);

                    if (response.IsSuccessStatusCode)
                    {
                        //DBClass.ExecuteNonQuery(@"
                        //    UPDATE tbl_customer
                        //    SET SyncStatus = 1
                        //    WHERE SyncStatus = 0
                        //");
                        foreach (var item in customers)
                        {
                            DBClass.ExecuteNonQuery(
                                "UPDATE tbl_customer SET SyncStatus=1 WHERE GlobalId=@GlobalId",
                                DBClass.CreateParameter("@GlobalId", item.GlobalId));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task DownloadCustomers(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-customers?lastSync={Uri.EscapeDataString(lastSync.ToString("o"))}&deviceId={Uri.EscapeDataString(DeviceId)}";

                string json = await client.GetStringAsync(url);

                List<CustomerSyncDto> customers =
                    JsonConvert.DeserializeObject<List<CustomerSyncDto>>(json);

                foreach (var item in customers)
                {
                    string sqlCheck = @"
                SELECT COUNT(*) 
                FROM tbl_customer 
                WHERE GlobalId = @GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sqlCheck,
                            DBClass.CreateParameter("@GlobalId", item.GlobalId)));

                    if (exists == 0)
                    {
                        // INSERT NEW CUSTOMER
                        DBClass.ExecuteNonQuery(@"
                                INSERT INTO tbl_customer
                                (
                                    code,
                                    name,
                                    Cat_id,
                                    Balance,
                                    date,
                                    main_phone,
                                    work_phone,
                                    mobile,
                                    email,
                                    country,
                                    city,
                                    region,
                                    account_id,
                                    trn,
                                    active,
                                    state,
                                    project_id,
                                    project_site,
                                    GlobalId,
                                    DeviceId,
                                    LastModified,
                                    SyncStatus
                                )
                                VALUES
                                (
                                    @code,
                                    @name,
                                    @Cat_id,
                                    @Balance,
                                    @date,
                                    @main_phone,
                                    @work_phone,
                                    @mobile,
                                    @email,
                                    @country,
                                    @city,
                                    @region,
                                    @account_id,
                                    @trn,
                                    @active,
                                    @state,
                                    @project_id,
                                    @project_site,
                                    @GlobalId,
                                    @DeviceId,
                                    @LastModified,
                                    1
                                )",

                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@Cat_id", item.Cat_id),
                            DBClass.CreateParameter("@Balance", item.Balance),
                            DBClass.CreateParameter("@date", item.date),
                            DBClass.CreateParameter("@main_phone", item.main_phone),
                            DBClass.CreateParameter("@work_phone", item.work_phone),
                            DBClass.CreateParameter("@mobile", item.mobile),
                            DBClass.CreateParameter("@email", item.email),
                            DBClass.CreateParameter("@country", item.country),
                            DBClass.CreateParameter("@city", item.city),
                            DBClass.CreateParameter("@region", item.region),
                            DBClass.CreateParameter("@account_id", item.account_id),
                            DBClass.CreateParameter("@trn", item.trn),
                            DBClass.CreateParameter("@active", item.active),
                            DBClass.CreateParameter("@state", item.state),
                            DBClass.CreateParameter("@project_id", item.project_id),
                            DBClass.CreateParameter("@project_site", item.project_site),
                            DBClass.CreateParameter("@GlobalId", item.GlobalId),
                            DBClass.CreateParameter("@DeviceId", item.DeviceId),
                            DBClass.CreateParameter("@LastModified", item.LastModified)
                        );

                        string customerId = DBClass.ExecuteScalar(@"SELECT id FROM tbl_customer WHERE GlobalId=@id", DBClass.CreateParameter("@id", item.GlobalId)).ToString();
                        if (!string.IsNullOrEmpty(customerId))
                        {
                            ProcessOpeningBalanceTransactionsCustomers(Convert.ToInt32(customerId), item.code.ToString(), item.account_id.ToString(), item.Balance.ToString(), Convert.ToDateTime(item.date));
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                                DBClass.ExecuteScalar(
                                    "SELECT LastModified FROM tbl_customer WHERE GlobalId=@GlobalId",
                                    DBClass.CreateParameter("@GlobalId", item.GlobalId)
                                )
                            );

                        if (item.LastModified > existingLastModified)
                        {
                            DBClass.ExecuteNonQuery(@"
                                UPDATE tbl_customer
                                SET 
                                    name = @name,
                                    mobile = @mobile,
                                    email = @email,
                                    city = @city,
                                    country = @country,
                                    DeviceId = @DeviceId,
                                    LastModified = @LastModified
                                WHERE GlobalId = @GlobalId",

                                DBClass.CreateParameter("@name", item.name),
                                DBClass.CreateParameter("@mobile", item.mobile),
                                DBClass.CreateParameter("@email", item.email),
                                DBClass.CreateParameter("@city", item.city),
                                DBClass.CreateParameter("@country", item.country),
                                DBClass.CreateParameter("@DeviceId", item.DeviceId),
                                DBClass.CreateParameter("@LastModified", item.LastModified),
                                DBClass.CreateParameter("@GlobalId", item.GlobalId)
                            );


                            string customerId = DBClass.ExecuteScalar(@"SELECT id FROM tbl_customer WHERE GlobalId=@id", DBClass.CreateParameter("@id", item.GlobalId)).ToString();
                            if (!string.IsNullOrEmpty(customerId))
                            {
                                DBClass.ExecuteNonQuery("DELETE from tbl_transaction WHERE transaction_id= @id AND TYPE='Customer Opening Balance'", DBClass.CreateParameter("id", customerId));
                                ProcessOpeningBalanceTransactionsCustomers(Convert.ToInt32(customerId), item.code.ToString(), item.account_id.ToString(), item.Balance.ToString(), Convert.ToDateTime(item.date));
                            }
                        }
                    }
                }
            }
        }
        private static void ProcessOpeningBalanceTransactionsCustomers(int customerId, string formattedCode, string accountId, string balance, DateTime dtOpen)
        {
            
            string openingBalanceEquity = BindCombos.SelectDefaultLevelAccount("Opening Balance Equity").ToString();
            string txtCredit = "0"; 
            string txtDepit = "0";
            if (Convert.ToDecimal(balance) > 0)
                txtDepit = Convert.ToString(balance);
            else
                txtCredit = Convert.ToString(balance).Replace("-", "");

            decimal creditAmount = decimal.Parse(txtCredit);
            decimal debitAmount = decimal.Parse(txtDepit);
            if (int.Parse(openingBalanceEquity) == 0)
            {
                object result = DBClass.ExecuteScalar(@"SELECT id FROM tbl_coa_level_4 WHERE name = 'Opening Balance Equity'");
                if (result != null && result != DBNull.Value)
                {
                    openingBalanceEquity = result.ToString();
                }
            }
            if (int.Parse(openingBalanceEquity) > 0)
            {
                if (creditAmount != 0)
                {
                    CommonInsert.addTransactionEntry(dtOpen.Date, openingBalanceEquity, creditAmount.ToString(), "0",
                        customerId.ToString(), "0", "Customer Opening Balance", "OPENING BALANCE", "Opening Balance Equity - Customer Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");

                    CommonInsert.addTransactionEntry(dtOpen.Date, accountId, "0", creditAmount.ToString(),
                        customerId.ToString(), customerId.ToString(), "Customer Opening Balance", "OPENING BALANCE", "Opening Balance - Customer Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");

                }

                if (debitAmount != 0)
                {
                    CommonInsert.addTransactionEntry(dtOpen.Date, openingBalanceEquity, "0", debitAmount.ToString(),
                        customerId.ToString(), "0", "Customer Opening Balance", "OPENING BALANCE", "Opening Balance Equity - Customer Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");

                    CommonInsert.addTransactionEntry(dtOpen.Date, accountId, debitAmount.ToString(), "0",
                        customerId.ToString(), customerId.ToString(), "Customer Opening Balance", "OPENING BALANCE", "Opening Balance - Customer Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");
                }
            }
        }
        public static List<CustomerSyncDto> GetCustomersForSync()
        {
            List<CustomerSyncDto> list = new List<CustomerSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT *
                FROM tbl_customer
                WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CustomerSyncDto
                {
                    GlobalId = row["GlobalId"].ToString(),
                    code = Convert.ToInt32(row["code"]),
                    name = row["name"].ToString(),
                    Cat_id = row["Cat_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["Cat_id"]),
                    Balance = row["Balance"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["Balance"]),
                    date = row["date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["date"]),
                    main_phone = row["main_phone"].ToString(),
                    work_phone = row["work_phone"].ToString(),
                    mobile = row["mobile"].ToString(),
                    email = row["email"].ToString(),
                    country = row["country"].ToString(),
                    city = row["city"].ToString(),
                    region = row["region"].ToString(),
                    account_id = row["account_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["account_id"]),
                    trn = row["trn"].ToString(),
                    active = row["active"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["active"]),
                    state = row["state"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["state"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    project_site = row["project_site"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }

        public static async Task UploadVendors()
        {
            var vendors = GetVendorsForSync();

            if (vendors.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(vendors);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-vendors",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    //DBClass.ExecuteNonQuery(@"
                    //    UPDATE tbl_vendor
                    //    SET SyncStatus = 1
                    //    WHERE SyncStatus = 0");
                    foreach (var item in vendors)
                    {
                        DBClass.ExecuteNonQuery(
                            "UPDATE tbl_vendor SET SyncStatus=1 WHERE GlobalId=@GlobalId",
                            DBClass.CreateParameter("@GlobalId", item.GlobalId));
                    }
                }
            }
        }
        public static async Task DownloadVendors(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-vendors?lastSync={lastSync}&deviceId={DeviceId}";

                string json = await client.GetStringAsync(url);

                List<VendorSyncDto> vendors =
                    JsonConvert.DeserializeObject<List<VendorSyncDto>>(json);

                foreach (var item in vendors)
                {
                    string sql = @"
                            SELECT COUNT(*)
                            FROM tbl_vendor
                            WHERE GlobalId=@GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sql,
                            DBClass.CreateParameter("@GlobalId", item.GlobalId)));

                    if (exists == 0)
                    {
                        DBClass.ExecuteNonQuery(@"
                            INSERT INTO tbl_vendor
                            (
                                code,
                                name,
                                Cat_id,
                                Balance,
                                date,
                                main_phone,
                                work_phone,
                                mobile,
                                email,
                                ccemail,
                                website,
                                country,
                                city,
                                region,
                                building_name,
                                account_id,
                                trn,
                                facilty_name,
                                active,
                                created_by,
                                created_date,
                                state,
                                type,
                                project_id,
                                project_site,
                                GlobalId,
                                DeviceId,
                                LastModified,
                                SyncStatus
                            )
                            VALUES
                            (
                                @code,
                                @name,
                                @Cat_id,
                                @Balance,
                                @date,
                                @main_phone,
                                @work_phone,
                                @mobile,
                                @email,
                                @ccemail,
                                @website,
                                @country,
                                @city,
                                @region,
                                @building_name,
                                @account_id,
                                @trn,
                                @facilty_name,
                                @active,
                                @created_by,
                                @created_date,
                                @state,
                                @type,
                                @project_id,
                                @project_site,
                                @GlobalId,
                                @DeviceId,
                                @LastModified,
                                1
                            )",
                                DBClass.CreateParameter("@code", item.code),
                                DBClass.CreateParameter("@name", item.name),
                                DBClass.CreateParameter("@Cat_id", item.Cat_id),
                                DBClass.CreateParameter("@Balance", item.Balance),
                                DBClass.CreateParameter("@date", item.date),
                                DBClass.CreateParameter("@main_phone", item.main_phone),
                                DBClass.CreateParameter("@work_phone", item.work_phone),
                                DBClass.CreateParameter("@mobile", item.mobile),
                                DBClass.CreateParameter("@email", item.email),
                                DBClass.CreateParameter("@ccemail", item.ccemail),
                                DBClass.CreateParameter("@website", item.website),
                                DBClass.CreateParameter("@country", item.country),
                                DBClass.CreateParameter("@city", item.city),
                                DBClass.CreateParameter("@region", item.region),
                                DBClass.CreateParameter("@building_name", item.building_name),
                                DBClass.CreateParameter("@account_id", item.account_id),
                                DBClass.CreateParameter("@trn", item.trn),
                                DBClass.CreateParameter("@facilty_name", item.facilty_name),
                                DBClass.CreateParameter("@active", item.active),
                                DBClass.CreateParameter("@created_by", item.created_by),
                                DBClass.CreateParameter("@created_date", item.created_date),
                                DBClass.CreateParameter("@state", item.state),
                                DBClass.CreateParameter("@type", item.type),
                                DBClass.CreateParameter("@project_id", item.project_id),
                                DBClass.CreateParameter("@project_site", item.project_site),
                                DBClass.CreateParameter("@GlobalId", item.GlobalId),
                                DBClass.CreateParameter("@DeviceId", item.DeviceId),
                                DBClass.CreateParameter("@LastModified", item.LastModified)
                            );

                        string vendorId = DBClass.ExecuteScalar(@"SELECT id FROM tbl_vendor WHERE GlobalId=@id", DBClass.CreateParameter("@id", item.GlobalId)).ToString();
                        if (!string.IsNullOrEmpty(vendorId))
                        {
                            ProcessOpeningBalanceTransactionsVendors(Convert.ToInt32(vendorId), item.code.ToString(), item.account_id.ToString(), item.Balance.ToString(), Convert.ToDateTime(item.date));
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                                DBClass.ExecuteScalar(
                                    "SELECT LastModified FROM tbl_vendor WHERE GlobalId=@GlobalId",
                                    DBClass.CreateParameter("@GlobalId", item.GlobalId)
                                )
                            );

                        if (item.LastModified > existingLastModified)
                        {
                            DBClass.ExecuteNonQuery(@"
                                UPDATE tbl_vendor
                                SET 
                                    code = @code,
                                    name = @name,
                                    Cat_id = @Cat_id,
                                    Balance = @Balance,
                                    date = @date,
                                    main_phone = @main_phone,
                                    work_phone = @work_phone,
                                    mobile = @mobile,
                                    email = @email,
                                    ccemail = @ccemail,
                                    website = @website,
                                    country = @country,
                                    city = @city,
                                    region = @region,
                                    building_name = @building_name,
                                    account_id = @account_id,
                                    trn = @trn,
                                    facilty_name = @facilty_name,
                                    active = @active,
                                    created_by = @created_by,
                                    created_date = @created_date,
                                    state = @state,
                                    type = @type,
                                    project_id = @project_id,
                                    project_site = @project_site,
                                    DeviceId = @DeviceId,
                                    LastModified = @LastModified
                                WHERE GlobalId = @GlobalId",

                                DBClass.CreateParameter("@code", item.code),
                                DBClass.CreateParameter("@name", item.name),
                                DBClass.CreateParameter("@Cat_id", item.Cat_id),
                                DBClass.CreateParameter("@Balance", item.Balance),
                                DBClass.CreateParameter("@date", item.date),
                                DBClass.CreateParameter("@main_phone", item.main_phone),
                                DBClass.CreateParameter("@work_phone", item.work_phone),
                                DBClass.CreateParameter("@mobile", item.mobile),
                                DBClass.CreateParameter("@email", item.email),
                                DBClass.CreateParameter("@ccemail", item.ccemail),
                                DBClass.CreateParameter("@website", item.website),
                                DBClass.CreateParameter("@country", item.country),
                                DBClass.CreateParameter("@city", item.city),
                                DBClass.CreateParameter("@region", item.region),
                                DBClass.CreateParameter("@building_name", item.building_name),
                                DBClass.CreateParameter("@account_id", item.account_id),
                                DBClass.CreateParameter("@trn", item.trn),
                                DBClass.CreateParameter("@facilty_name", item.facilty_name),
                                DBClass.CreateParameter("@active", item.active),
                                DBClass.CreateParameter("@created_by", item.created_by),
                                DBClass.CreateParameter("@created_date", item.created_date),
                                DBClass.CreateParameter("@state", item.state),
                                DBClass.CreateParameter("@type", item.type),
                                DBClass.CreateParameter("@project_id", item.project_id),
                                DBClass.CreateParameter("@project_site", item.project_site),
                                DBClass.CreateParameter("@DeviceId", item.DeviceId),
                                DBClass.CreateParameter("@LastModified", Convert.ToDateTime(item.LastModified)),
                                DBClass.CreateParameter("@GlobalId", item.GlobalId)
                            );
                            string vendorId = DBClass.ExecuteScalar(@"SELECT id FROM tbl_vendor WHERE GlobalId=@id", DBClass.CreateParameter("@id", item.GlobalId)).ToString();
                            if (!string.IsNullOrEmpty(vendorId))
                            {
                                DBClass.ExecuteNonQuery("DELETE from tbl_transaction WHERE transaction_id=@id AND TYPE='Vendor Opening Balance'", DBClass.CreateParameter("id", vendorId));
                                ProcessOpeningBalanceTransactionsVendors(Convert.ToInt32(vendorId), item.code.ToString(), item.account_id.ToString(), item.Balance.ToString(), Convert.ToDateTime(item.date));
                            }
                        }
                    }
                }
            }
        }
        private static void ProcessOpeningBalanceTransactionsVendors(int vendorId, string formattedCode, string accountId, string balance, DateTime dtOpen)
        {
            string openingBalanceEquity = BindCombos.SelectDefaultLevelAccount("Opening Balance Equity").ToString();
            string txtCredit = "0";
            string txtDepit = "0";
            if (Convert.ToDecimal(balance) > 0)
                txtCredit = Convert.ToString(balance);
            else
                txtDepit = Convert.ToString(balance).Replace("-", "");
            decimal creditAmount = decimal.Parse(txtCredit);
            decimal debitAmount = decimal.Parse(txtDepit);
            if (int.Parse(openingBalanceEquity) == 0)
            {
                object result = DBClass.ExecuteScalar(@"SELECT id FROM tbl_coa_level_4 WHERE name = 'Opening Balance Equity'");
                if (result != null && result != DBNull.Value)
                {
                    openingBalanceEquity = result.ToString();
                }
            }
            if (int.Parse(openingBalanceEquity) > 0)
            {
                if (creditAmount != 0)
                {
                    CommonInsert.addTransactionEntry(dtOpen.Date, openingBalanceEquity, creditAmount.ToString(), "0",
                      vendorId.ToString(), "0", "Vendor Opening Balance", "OPENING BALANCE", "Opening Balance Equity - Vendor Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");

                    CommonInsert.addTransactionEntry(dtOpen.Date, accountId, "0", creditAmount.ToString(),
                       vendorId.ToString(), vendorId.ToString(), "Vendor Opening Balance", "OPENING BALANCE", "Account Payable - Vendor Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");
                }

                if (debitAmount != 0)
                {
                    CommonInsert.addTransactionEntry(dtOpen.Date, openingBalanceEquity, "0", debitAmount.ToString(),
                            vendorId.ToString(), "0", "Vendor Opening Balance", "OPENING BALANCE", "Opening Balance Equity - Vendor Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");

                    CommonInsert.addTransactionEntry(dtOpen.Date, accountId, debitAmount.ToString(), "0",
                       vendorId.ToString(), vendorId.ToString(), "Vendor Opening Balance", "OPENING BALANCE", "Account Payable - Vendor Code - " + formattedCode, frmLogin.userId, DateTime.Now.Date, "");
                }
            }
        }
        public static List<VendorSyncDto> GetVendorsForSync()
        {
            List<VendorSyncDto> list = new List<VendorSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                            SELECT *
                            FROM tbl_vendor
                            WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new VendorSyncDto
                {
                    GlobalId = row["GlobalId"].ToString(),
                    code = Convert.ToInt32(row["code"]),
                    name = row["name"].ToString(),
                    Cat_id = row["Cat_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["Cat_id"]),
                    Balance = row["Balance"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["Balance"]),
                    date = row["date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["date"]),
                    main_phone = row["main_phone"].ToString(),
                    work_phone = row["work_phone"].ToString(),
                    mobile = row["mobile"].ToString(),
                    email = row["email"].ToString(),
                    ccemail = row["ccemail"].ToString(),
                    website = row["website"].ToString(),
                    country = row["country"].ToString(),
                    city = row["city"].ToString(),
                    region = row["region"].ToString(),
                    building_name = row["building_name"].ToString(),
                    account_id = row["account_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["account_id"]),
                    trn = row["trn"].ToString(),
                    facilty_name = row["facilty_name"].ToString(),
                    active = row["active"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["active"]),
                    created_by = row["created_by"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["created_by"]),
                    created_date = row["created_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["created_date"]),
                    state = row["state"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["state"]),
                    type = row["type"].ToString(),
                    project_id = Convert.ToInt32(row["project_id"]),
                    project_site = row["project_site"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task DownloadItems(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;

            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-items?lastSync={lastSync}&deviceId={DeviceId}";

                string json = await client.GetStringAsync(url);

                List<ItemSyncDto> list =
                    JsonConvert.DeserializeObject<List<ItemSyncDto>>(json);

                foreach (var item in list)
                {
                    int exists = Convert.ToInt32(DBClass.ExecuteScalar(@"
                                        SELECT COUNT(*) 
                                        FROM tbl_items 
                                        WHERE GlobalId = @GlobalId",
                                    DBClass.CreateParameter("@GlobalId", item.GlobalId)
                                ));

                    if (exists == 0)
                    {
                        DBClass.ExecuteNonQuery(@"
                                INSERT INTO tbl_items
                                (
                                    code, type, warehouse_id, name, unit_id, barcode,
                                    cost_price, cogs_account_id, vendor_id,
                                    sales_price, tax_code_id, income_account_id, asset_account_id,
                                    min_amount, max_amount, on_hand, total_value,
                                    date, active, method, state,
                                    created_By, created_date, deleted_by,
                                    category_id, posItem, item_type,
                                    GlobalId, DeviceId, LastModified, SyncStatus
                                )
                                VALUES
                                (
                                    @code, @type, @warehouse_id, @name, @unit_id, @barcode,
                                    @cost_price, @cogs_account_id, @vendor_id,
                                    @sales_price, @tax_code_id, @income_account_id, @asset_account_id,
                                    @min_amount, @max_amount, @on_hand, @total_value,
                                    @date, @active, @method, @state,
                                    @created_By, @created_date, @deleted_by,
                                    @category_id, @posItem, @item_type,
                                    @GlobalId, @DeviceId, @LastModified, 1
                                )",

                            DBClass.CreateParameter("@code", item.code),
                            DBClass.CreateParameter("@type", item.type),
                            DBClass.CreateParameter("@warehouse_id", item.warehouse_id),
                            DBClass.CreateParameter("@name", item.name),
                            DBClass.CreateParameter("@unit_id", item.unit_id),
                            DBClass.CreateParameter("@barcode", item.barcode),

                            DBClass.CreateParameter("@cost_price", item.cost_price),
                            DBClass.CreateParameter("@cogs_account_id", item.cogs_account_id),
                            DBClass.CreateParameter("@vendor_id", item.vendor_id),
                            DBClass.CreateParameter("@sales_price", item.sales_price),
                            DBClass.CreateParameter("@tax_code_id", item.tax_code_id),
                            DBClass.CreateParameter("@income_account_id", item.income_account_id),
                            DBClass.CreateParameter("@asset_account_id", item.asset_account_id),

                            DBClass.CreateParameter("@min_amount", item.min_amount),
                            DBClass.CreateParameter("@max_amount", item.max_amount),
                            DBClass.CreateParameter("@on_hand", item.on_hand),
                            DBClass.CreateParameter("@total_value", item.total_value),

                            DBClass.CreateParameter("@date", item.date),
                            DBClass.CreateParameter("@active", item.active),
                            DBClass.CreateParameter("@method", item.method),
                            DBClass.CreateParameter("@state", item.state),
                            DBClass.CreateParameter("@created_By", item.created_By),
                            DBClass.CreateParameter("@created_date", item.created_date),
                            DBClass.CreateParameter("@deleted_by", item.deleted_by),

                            DBClass.CreateParameter("@category_id", item.category_id),
                            DBClass.CreateParameter("@posItem", item.posItem),
                            DBClass.CreateParameter("@item_type", item.item_type),

                            DBClass.CreateParameter("@GlobalId", item.GlobalId),
                            DBClass.CreateParameter("@DeviceId", item.DeviceId),
                            DBClass.CreateParameter("@LastModified", item.LastModified)
                        );

                        string itemId = DBClass.ExecuteScalar(@"SELECT id FROM tbl_items WHERE GlobalId=@id", DBClass.CreateParameter("@id", item.GlobalId)).ToString();
                        if (!string.IsNullOrEmpty(itemId))
                        {
                            if (item.type != "12 - Service" && item.unit_id > 0)
                                insertItemUnits(Convert.ToInt32(itemId), item.unit_id);
                            if (item.type == "13 - Inventory Assembly")
                            {
                                //insertItemsAssembly(itemId);
                            }

                            if (item.on_hand != 0 && item.type != "12 - Service")
                            {
                                if (item.on_hand > 0)
                                {
                                    insertItemTransaction(Convert.ToInt32(itemId),item.cost_price.ToString(), item.on_hand.ToString(),item.warehouse_id.ToString(), item.date);
                                    insertItemJournal(Convert.ToInt32(itemId),item.date,item.code.ToString(), item.total_value.ToString());
                                }
                            }
                        }
                    }
                    else
                    {

                        var existingLastModified = Convert.ToDateTime(
                                DBClass.ExecuteScalar(
                                    "SELECT LastModified FROM tbl_items WHERE GlobalId=@GlobalId",
                                    DBClass.CreateParameter("@GlobalId", item.GlobalId)
                                )
                            );

                        if (item.LastModified > existingLastModified)
                        {
                            DBClass.ExecuteNonQuery(@"
                                UPDATE tbl_items
                                SET
                                    name = @name,
                                    sales_price = @sales_price,
                                    cost_price = @cost_price,
                                    barcode = @barcode,
                                    on_hand = @on_hand,
                                    LastModified = @LastModified
                                WHERE GlobalId = @GlobalId",

                                DBClass.CreateParameter("@name", item.name),
                                DBClass.CreateParameter("@sales_price", item.sales_price),
                                DBClass.CreateParameter("@cost_price", item.cost_price),
                                DBClass.CreateParameter("@barcode", item.barcode),
                                DBClass.CreateParameter("@on_hand", item.on_hand),
                                DBClass.CreateParameter("@LastModified", item.LastModified),
                                DBClass.CreateParameter("@GlobalId", item.GlobalId)
                            );

                            string itemId = DBClass.ExecuteScalar(@"SELECT id FROM tbl_items WHERE GlobalId=@id", DBClass.CreateParameter("@id", item.GlobalId)).ToString();
                            if (!string.IsNullOrEmpty(itemId))
                            {
                                DBClass.ExecuteNonQuery("delete from tbl_items_unit where item_id=@id", DBClass.CreateParameter("id", itemId));
                                DBClass.ExecuteNonQuery("delete from tbl_item_assembly where assembly_id=@id", DBClass.CreateParameter("id", itemId));
                                
                                if (item.type != "12 - Service" && item.unit_id > 0)
                                    insertItemUnits(Convert.ToInt32(itemId), item.unit_id);
                                if (item.type == "13 - Inventory Assembly")
                                {
                                    //insertItemsAssembly(itemId);
                                }
                                    
                                DBClass.ExecuteNonQuery(@"DELETE FROM tbl_item_transaction where type = 'Opening Qty' and item_id = @id;DELETE FROM tbl_transaction where type = 'Opening Qty' AND transaction_id= @id", DBClass.CreateParameter("id", itemId));
                                DBClass.ExecuteNonQuery("DELETE FROM tbl_item_card_details WHERE `trans_type` = 'Opening Qty' and itemId = @id", DBClass.CreateParameter("id", itemId));
                                
                                if (item.on_hand != 0 && item.type != "12 - Service")
                                {
                                    if (item.on_hand > 0)
                                    {
                                        insertItemTransaction(Convert.ToInt32(itemId), item.cost_price.ToString(), item.on_hand.ToString(), item.warehouse_id.ToString(), item.date);
                                        insertItemJournal(Convert.ToInt32(itemId), item.date, item.code.ToString(), item.total_value.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void insertItemTransaction(int id,string txtCostPrice,string txtOnHand,string warehouseId, DateTime dtStart)
        {
            CommonInsert.InsertItemTransaction(dtStart.Date, "Opening Qty", "0", id.ToString(), txtCostPrice,
                txtOnHand, "0", "0", txtOnHand, "Opening Balance", warehouseId);
        }
        private static void insertItemJournal(int id,DateTime dtStart, string itemCode,string txtTotalValue)
        {
            CommonInsert.InsertTransactionEntry(dtStart.Date, BindCombos.SelectDefaultLevelAccount("Inventory").ToString(), txtTotalValue, "0",
                id.ToString(), id.ToString(), "Opening Qty", "Opening Balance - Item Code - " + itemCode, frmLogin.userId, DateTime.Now.Date);
            CommonInsert.InsertTransactionEntry(dtStart.Date, BindCombos.SelectDefaultLevelAccount("Opening Balance Equity").ToString(), "0", txtTotalValue,
                    id.ToString(), "0", "Opening Qty", "Opening Balance Equity - Item Code - " + itemCode, frmLogin.userId, DateTime.Now.Date);
        }

        private static void insertItemUnits(int id,int unitId)
        {
            DBClass.ExecuteReader(@"insert into tbl_items_unit (item_id,unit_id,factor) values (@id,@unit_id,@factor)",
                   DBClass.CreateParameter("id", id),
                   DBClass.CreateParameter("unit_id", unitId),
                   DBClass.CreateParameter("factor", 1));
        }

        public static async Task UploadItems()
        {
            var list = GetItemsForSync();

            if (list.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(list);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-items",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                UPDATE tbl_items
                SET SyncStatus = 1
                WHERE SyncStatus = 0");
                }
            }
        }
        public static List<ItemSyncDto> GetItemsForSync()
        {
            List<ItemSyncDto> list = new List<ItemSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_items
        WHERE SyncStatus = 0
    ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ItemSyncDto
                {
                    code = row["code"].ToString(),
                    type = row["type"].ToString(),
                    warehouse_id = Convert.ToInt32(row["warehouse_id"]),
                    name = row["name"].ToString(),
                    unit_id = Convert.ToInt32(row["unit_id"]),
                    barcode = row["barcode"].ToString(),

                    cost_price = Convert.ToDecimal(row["cost_price"]),
                    cogs_account_id = Convert.ToInt32(row["cogs_account_id"]),
                    vendor_id = Convert.ToInt32(row["vendor_id"]),
                    sales_price = Convert.ToDecimal(row["sales_price"]),
                    tax_code_id = Convert.ToInt32(row["tax_code_id"]),
                    income_account_id = Convert.ToInt32(row["income_account_id"]),
                    asset_account_id = Convert.ToInt32(row["asset_account_id"]),

                    min_amount = Convert.ToDecimal(row["min_amount"]),
                    max_amount = Convert.ToDecimal(row["max_amount"]),
                    on_hand = Convert.ToDecimal(row["on_hand"]),
                    total_value = Convert.ToDecimal(row["total_value"]),

                    date = Convert.ToDateTime(row["date"]),
                    active = Convert.ToInt32(row["active"]),
                    method = row["method"].ToString(),
                    state = Convert.ToInt32(row["state"]),
                    created_By = Convert.ToInt32(row["created_By"]),
                    created_date = Convert.ToDateTime(row["created_date"]),
                    deleted_by = Convert.ToInt32(row["deleted_by"]),

                    category_id = row["category_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["category_id"]),
                    posItem = row["posItem"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["posItem"]),
                    item_type = row["item_type"].ToString(),

                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static List<PurchaseSyncDto> GetPurchasesForSync()
        {
            List<PurchaseSyncDto> list = new List<PurchaseSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_purchase
        WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseSyncDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    vendor_id = Convert.ToInt32(row["vendor_id"]),
                    invoice_id = row["invoice_id"].ToString(),
                    warehouse_id = Convert.ToInt32(row["warehouse_id"]),
                    po_num = row["po_num"].ToString(),
                    bill_to = row["bill_to"].ToString(),
                    city = row["city"].ToString(),
                    sales_man = row["sales_man"].ToString(),
                    ship_date = row["ship_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["ship_date"]),
                    ship_via = row["ship_via"].ToString(),
                    ship_to = row["ship_to"].ToString(),
                    payment_method = row["payment_method"].ToString(),
                    account_cash_id = Convert.ToInt32(row["account_cash_id"]),
                    payment_terms = row["payment_terms"].ToString(),
                    payment_date = Convert.ToDateTime(row["payment_date"]),
                    total = Convert.ToDecimal(row["total"]),
                    vat = Convert.ToDecimal(row["vat"]),
                    net = Convert.ToDecimal(row["net"]),
                    pay = Convert.ToDecimal(row["pay"]),
                    change = Convert.ToDecimal(row["change"]),
                    created_by = Convert.ToInt32(row["created_by"]),
                    created_date = Convert.ToDateTime(row["created_date"]),
                    modified_by = row["modified_by"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["modified_by"]),
                    modified_date = row["modified_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["modified_date"]),
                    state = Convert.ToInt32(row["state"]),
                    purchase_type = row["purchase_type"].ToString(),
                    fixed_asset_category_id = Convert.ToInt32(row["fixed_asset_category_id"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    description = row["description"].ToString(),
                    reference_no = row["reference_no"].ToString(),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = row["LastModified"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task UploadPurchases()
        {
            var purchases = GetPurchasesForSync();
            var details = GetPurchaseDetailsForSync();

            var package = purchases.Select(p => new PurchaseSyncPackageDto
            {
                Info = p,
                Details = details
                    .Where(d => d.GlobalId == p.GlobalId)
                    .ToList()
            }).ToList();

            if (package.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(package);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-purchases",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                        UPDATE tbl_purchase
                        SET SyncStatus = 1
                        WHERE SyncStatus = 0");
                }
            }
        }
        public static List<PurchaseDetailSyncDto> GetPurchaseDetailsForSync()
        {
            List<PurchaseDetailSyncDto> list = new List<PurchaseDetailSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_purchase_details
        WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseDetailSyncDto
                {
                    purchase_id = row["purchase_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["purchase_id"]),
                    item_id = row["item_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["item_id"]),
                    qty = row["qty"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["qty"]),
                    cost_price = row["cost_price"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["cost_price"]),
                    price = row["price"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["price"]),
                    vatp = row["vatp"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["vatp"]),
                    vat = row["vat"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["vat"]),
                    total = row["total"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["total"]),
                    discount = row["discount"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["discount"]),
                    cost_center_id = row["cost_center_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["cost_center_id"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = row["LastModified"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task DownloadPurchases(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-purchases?lastSync={Uri.EscapeDataString(lastSync.ToString("o"))}&deviceId={Uri.EscapeDataString(DeviceId)}";

                string json = await client.GetStringAsync(url);

                List<PurchaseSyncPackageDto> purchases = JsonConvert.DeserializeObject<List<PurchaseSyncPackageDto>>(json);
                var defaultAccounts = BindCombos.DefaultAccounts();
                int level4PaymentCreditMethodId = defaultAccounts.ContainsKey("Vendor") ? defaultAccounts["Vendor"] : 0;
                int level4VatId = defaultAccounts.ContainsKey("Vat Output") ? defaultAccounts["Vat Input"] : 0;
                int level4Inventory = defaultAccounts.ContainsKey("Inventory") ? defaultAccounts["Inventory"] : 0;
                int level4PurchaseInvoice = defaultAccounts.ContainsKey("Purchase") ? defaultAccounts["Purchase"] : 0;

                foreach (var purchase in purchases)
                {
                    PurchaseSyncDto info = purchase.Info;

                    string sqlCheck = @"
                                        SELECT COUNT(*) 
                                        FROM tbl_purchase 
                                        WHERE GlobalId = @GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sqlCheck,
                            DBClass.CreateParameter("@GlobalId", info.GlobalId)));

                    int invId = 0;

                    if (exists == 0)
                    {
                        invId = int.Parse(DBClass.ExecuteScalar(@"INSERT INTO tbl_purchase (date, vendor_id, invoice_id,warehouse_id, po_num, bill_to,city,sales_man,
                               ship_date,ship_via, ship_to, payment_method,account_cash_id, payment_terms, payment_date,  
                               total,vat,net, pay, `change`, created_by, created_date, state,purchase_type,fixed_asset_category_id,description,reference_no, GlobalId, DeviceId, LastModified, SyncStatus) VALUES (@DATE, @vendor_id, @invoice_id,@warehouse_id,
                               @po_num, @bill_to,@city,@sales_man, @ship_date, @ship_via,@ship_to, @payment_method,@account_cash_id ,@payment_terms, @payment_date, 
                               @total,  @vat,@net, @pay, @change, @created_by, @created_date, @state,@purchase_type,@fixed_asset_category_id,@description,@reference_no, @GlobalId, @DeviceId, @LastModified, 1);
                               SELECT LAST_INSERT_ID();",
                               DBClass.CreateParameter("date", info.date),
                               DBClass.CreateParameter("vendor_id", info.vendor_id),
                               DBClass.CreateParameter("invoice_id", info.invoice_id),
                               DBClass.CreateParameter("city", info.city),
                               DBClass.CreateParameter("warehouse_id", info.warehouse_id),
                               DBClass.CreateParameter("po_num", info.po_num),
                               DBClass.CreateParameter("bill_to", info.bill_to),
                               DBClass.CreateParameter("ship_date", info.ship_date),
                               DBClass.CreateParameter("sales_man", info.sales_man),
                               DBClass.CreateParameter("ship_via", info.ship_via),
                               DBClass.CreateParameter("ship_to", info.ship_to),
                               DBClass.CreateParameter("payment_method", info.payment_method),
                               DBClass.CreateParameter("account_cash_id", info.account_cash_id),
                               DBClass.CreateParameter("payment_terms", info.payment_terms),
                               DBClass.CreateParameter("payment_date", info.payment_date),
                               DBClass.CreateParameter("vat", info.vat),
                               DBClass.CreateParameter("total", info.total),
                               DBClass.CreateParameter("net", info.net),
                               DBClass.CreateParameter("pay", info.payment_method == "Cash" ? string.IsNullOrEmpty(info.total.ToString()) ? 0 : Convert.ToDecimal(info.total) : 0),
                               DBClass.CreateParameter("change", info.payment_method == "Cash" ? 0 : string.IsNullOrEmpty(info.total.ToString()) ? 0 : Convert.ToDecimal(info.total)),
                               DBClass.CreateParameter("created_by", frmLogin.userId),
                               DBClass.CreateParameter("created_date", DateTime.Now.Date),
                               DBClass.CreateParameter("state", 0),
                               DBClass.CreateParameter("purchase_type", info.purchase_type),
                               DBClass.CreateParameter("description", info.description),
                               DBClass.CreateParameter("reference_no", info.reference_no),
                               DBClass.CreateParameter("fixed_asset_category_id", info.fixed_asset_category_id),
                               DBClass.CreateParameter("@GlobalId", info.GlobalId),
                               DBClass.CreateParameter("@DeviceId", info.DeviceId),
                               DBClass.CreateParameter("@LastModified", info.LastModified)
                               ).ToString());


                        foreach (var detail in purchase.Details)
                        {
                            insertPurchaseItems(detail, invId, info);
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                                DBClass.ExecuteScalar(
                                    "SELECT LastModified FROM tbl_purchase WHERE GlobalId=@GlobalId",
                                    DBClass.CreateParameter("@GlobalId", info.GlobalId)
                                )
                            );

                        if (info.LastModified > existingLastModified)
                        {
                            invId = Convert.ToInt32(DBClass.ExecuteScalar(@"SELECT id FROM tbl_purchase WHERE GlobalId=@id",
                                                            DBClass.CreateParameter("@id", info.GlobalId)).ToString());

                            CommonInsert.DeleteTransactionEntry(invId, "PURCHASE");
                            DBClass.ExecuteNonQuery(@"
                                    DELETE FROM tbl_item_transaction  
                                    WHERE reference = @id AND type = 'Purchase Invoice';
                                    DELETE FROM tbl_item_card_details 
                                    WHERE trans_type = 'Purchase Invoice' AND trans_no = @id;
                                    DELETE FROM tbl_purchase_details 
                                    WHERE purchase_id = @id;",
                                        DBClass.CreateParameter("id", invId));

                            DBClass.ExecuteNonQuery(@"UPDATE tbl_purchase 
                                     SET  modified_by = @modifiedBy, modified_date = @modifiedDate ,date = @date,sales_man=@sales_man, vendor_id = @vendor_id, invoice_id = @invoice_id, warehouse_id = @warehouse_id,
                                     po_num = @po_num, bill_to = @bill_to, ship_date = @ship_date, 
                                     ship_via = @ship_via, ship_to = @ship_to, payment_method = @payment_method, account_cash_id = @account_cash_id, 
                                     payment_terms = @payment_terms, payment_date = @payment_date, total = @total, 
                                     vat = @vat, net = @net, pay = @pay, `change` = @change, city = @city,purchase_type =@purchase_type, fixed_asset_category_id=@fixed_asset_category_id, description = @description, reference_no = @reference_no,
                                     LastModified = @LastModified, GlobalId = @GlobalId  WHERE id = @id;",
                                     DBClass.CreateParameter("id", invId),
                                     DBClass.CreateParameter("date", info.date),
                                   DBClass.CreateParameter("vendor_id", info.vendor_id),
                                   DBClass.CreateParameter("invoice_id", info.invoice_id),
                                   DBClass.CreateParameter("city", info.city),
                                   DBClass.CreateParameter("warehouse_id", info.warehouse_id),
                                   DBClass.CreateParameter("po_num", info.po_num),
                                   DBClass.CreateParameter("bill_to", info.bill_to),
                                   DBClass.CreateParameter("ship_date", info.ship_date),
                                   DBClass.CreateParameter("sales_man", info.sales_man),
                                   DBClass.CreateParameter("ship_via", info.ship_via),
                                   DBClass.CreateParameter("ship_to", info.ship_to),
                                   DBClass.CreateParameter("payment_method", info.payment_method),
                                   DBClass.CreateParameter("account_cash_id", info.account_cash_id),
                                   DBClass.CreateParameter("payment_terms", info.payment_terms),
                                   DBClass.CreateParameter("payment_date", info.payment_date),
                                   DBClass.CreateParameter("vat", info.vat),
                                   DBClass.CreateParameter("total", info.total),
                                   DBClass.CreateParameter("net", info.net),
                                    DBClass.CreateParameter("@modifiedBy", frmLogin.userId),
                                    DBClass.CreateParameter("@modifiedDate", DateTime.Now.Date),
                                DBClass.CreateParameter("pay", info.pay),
                                DBClass.CreateParameter("change", info.change),
                                DBClass.CreateParameter("purchase_type", info.purchase_type),
                                DBClass.CreateParameter("description", info.description),
                                DBClass.CreateParameter("reference_no", info.reference_no),
                                   DBClass.CreateParameter("fixed_asset_category_id", info.fixed_asset_category_id),
                                DBClass.CreateParameter("@LastModified", info.LastModified),
                                DBClass.CreateParameter("@GlobalId", info.GlobalId)
                                );
                        }

                    }
                    
                    if (invId > 0)
                    {
                        string accountId = info.payment_method == "Credit" ? level4PaymentCreditMethodId.ToString() : info.account_cash_id.ToString();
                        if (!string.IsNullOrEmpty(info.net.ToString()))
                        {
                            CommonInsert.addTransactionEntry(info.date,
                                 accountId,
                                  "0", info.net.ToString(), invId.ToString(), info.vendor_id.ToString(), info.payment_method == "Credit" ? "Purchase Invoice" : "Purchase Invoice Cash", "PURCHASE", "Purchase Invoice NO. " + info.invoice_id,
                                 frmLogin.userId, DateTime.Now.Date, info.invoice_id);
                        }
                        if (info.vat > 0)
                        {
                            CommonInsert.addTransactionEntry(info.date,
                          level4VatId.ToString(), info.vat.ToString(), "0", invId.ToString(), "0", "Purchase Invoice", "PURCHASE",
                          "Vat Input For Invoice No. " + info.invoice_id.ToString(), frmLogin.userId, DateTime.Now.Date, info.invoice_id);
                        }
                        if (info.total > 0)
                        {
                            CommonInsert.addTransactionEntry(info.date,
                              level4Inventory.ToString(), info.total.ToString(), "0", invId.ToString(), "0", "Purchase Invoice", "PURCHASE",
                              "Purchase For Invoice No. " + info.invoice_id, frmLogin.userId, DateTime.Now.Date, info.invoice_id);
                        }
                    }
                }
            }
        }

        private static void insertPurchaseItems(PurchaseDetailSyncDto item, int invId, PurchaseSyncDto info)
        {
            string sql = $@"
                            INSERT INTO tbl_purchase_details
                            (purchase_id, item_id, qty, cost_price, price, discount, vatp, vat, total, cost_center_id, GlobalId, DeviceId)
                            VALUES(@purchase_id, @item_id, @qty, @cost_price, @price, @discount, @vatp, @vat, @total, @costCenter, @GlobalId, @DeviceId)";

            DBClass.ExecuteNonQuery(sql,
            DBClass.CreateParameter($"@purchase_id", invId),
            DBClass.CreateParameter($"@item_id", item.item_id),
            DBClass.CreateParameter($"@qty", item.qty),
            DBClass.CreateParameterNew($"@cost_price", item.cost_price),
            DBClass.CreateParameterNew($"@price", item.price),
            DBClass.CreateParameterNew($"@discount", item.discount),
            DBClass.CreateParameterNew($"@vat", item.vat),
            DBClass.CreateParameterNew($"@vatp", item.vatp),
            DBClass.CreateParameterNew($"@total", item.total),
            DBClass.CreateParameter($"@costCenter", item.cost_center_id),
            DBClass.CreateParameter($"@GlobalId", item.GlobalId),
            DBClass.CreateParameter($"@DeviceId", item.DeviceId));

            if (item.Type == "13 - Inventory Assembly")
            {
                //HandleAssemblyItems(itemId, qty);
            }
            else if (item.Type != "12 - Service")
            {
                CommonInsert.InsertItemTransaction(info.date, "Purchase Invoice", invId.ToString(), item.item_id.ToString(),
                    item.cost_price.ToString(), item.qty.ToString(), "0", "0", item.qty.ToString(),
                    "Purchase Invoice No. " + info.invoice_id, info.warehouse_id.ToString());
            }
        }
        public static async Task UploadSales()
        {
            var sales = GetSalesForSync();
            var details = GetSalesDetailsForSync();

            var package = sales.Select(s => new SalesSyncPackageDto
            {
                Info = s,
                Details = details
                                .Where(d => d.GlobalId == s.GlobalId)
                                .ToList()
            }).ToList();


            if (package.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(package);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-sales",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_sales
                    SET SyncStatus = 1
                    WHERE SyncStatus = 0");
                }
            }
        }
        public static List<SalesSyncDto> GetSalesForSync()
        {
            List<SalesSyncDto> list = new List<SalesSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_sales
        WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SalesSyncDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    customer_id = Convert.ToInt32(row["customer_id"]),
                    invoice_id = row["invoice_id"].ToString(),
                    warehouse_id = Convert.ToInt32(row["warehouse_id"]),
                    po_num = row["po_num"].ToString(),
                    form_type = row["form_type"].ToString(),
                    bill_to = row["bill_to"].ToString(),
                    city = row["city"].ToString(),
                    sales_man = row["sales_man"].ToString(),
                    ship_date = row["ship_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["ship_date"]),
                    ship_via = row["ship_via"].ToString(),
                    ship_to = row["ship_to"].ToString(),
                    payment_method = row["payment_method"].ToString(),
                    account_cash_id = Convert.ToInt32(row["account_cash_id"]),
                    payment_terms = row["payment_terms"].ToString(),
                    payment_date = Convert.ToDateTime(row["payment_date"]),
                    total = Convert.ToDecimal(row["total"]),
                    vat = Convert.ToDecimal(row["vat"]),
                    net = Convert.ToDecimal(row["net"]),
                    pay = Convert.ToDecimal(row["pay"]),
                    change = Convert.ToDecimal(row["change"]),
                    created_by = Convert.ToInt32(row["created_by"]),
                    created_date = Convert.ToDateTime(row["created_date"]),
                    modified_by = row["modified_by"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["modified_by"]),
                    modified_date = row["modified_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["modified_date"]),
                    state = Convert.ToInt32(row["state"]),
                    discount = Convert.ToDecimal(row["discount"]),
                    retention_amount = Convert.ToDecimal(row["retention_amount"]),
                    retention_percentage = Convert.ToDecimal(row["retention_percentage"]),
                    advance_pay = Convert.ToDecimal(row["advance_pay"]),
                    cost_center_id = Convert.ToDecimal(row["cost_center_id"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    description = row["description"].ToString(),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = row["LastModified"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }

        public static async Task DownloadSales(DateTime lastSync)
        {
            bool AllowItemWithOutQty = false;
            string DeviceId = Utilities.MachineName;
            var generalS = Utilities.GeneralSettingsState("ALLOW ITEM WITHOUT QTY");
            if (!string.IsNullOrEmpty(generalS) & int.Parse(generalS) > 0)
            {
                AllowItemWithOutQty = true;
            }
            else
            {
                AllowItemWithOutQty = false;
            }
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-sales?lastSync={Uri.EscapeDataString(lastSync.ToString("o"))}&deviceId={Uri.EscapeDataString(DeviceId)}";

                string json = await client.GetStringAsync(url);

                List<SalesSyncPackageDto> saleses = JsonConvert.DeserializeObject<List<SalesSyncPackageDto>>(json);
                var defaultAccounts = BindCombos.DefaultAccounts();
                int level4PaymentCreditMethodId = defaultAccounts.ContainsKey("Vendor") ? defaultAccounts["Vendor"] : 0;
                int level4VatId = defaultAccounts.ContainsKey("Vat Output") ? defaultAccounts["Vat Input"] : 0;
                int level4Inventory = defaultAccounts.ContainsKey("Inventory") ? defaultAccounts["Inventory"] : 0;
                int level4PurchaseInvoice = defaultAccounts.ContainsKey("Purchase") ? defaultAccounts["Purchase"] : 0;
                int level4SalesInvoice = frmLogin.defaultAccounts.ContainsKey("Sales") ? frmLogin.defaultAccounts["Sales"] : 0;
                int level4COGS = frmLogin.defaultAccounts.ContainsKey("COGS") ? frmLogin.defaultAccounts["COGS"] : 0;
                int level4AdvancePayment = frmLogin.defaultAccounts.ContainsKey("Customer Advances") ? frmLogin.defaultAccounts["Customer Advances"] : 0;
                int level4RetentionAccount = frmLogin.defaultAccounts.ContainsKey("Retention") ? frmLogin.defaultAccounts["Retention"] : 0;
                int level4DeductionAccount = frmLogin.defaultAccounts.ContainsKey("Deduction") ? frmLogin.defaultAccounts["Deduction"] : 0;


                foreach (var sale in saleses)
                {
                    SalesSyncDto info = sale.Info;

                    string sqlCheck = @"
                                        SELECT COUNT(*) 
                                        FROM tbl_sales 
                                        WHERE GlobalId = @GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sqlCheck,
                            DBClass.CreateParameter("@GlobalId", info.GlobalId)));

                    int invId = 0;

                    if (exists == 0)
                    {
                        invId = int.Parse(DBClass.ExecuteScalar(@"INSERT INTO tbl_sales (date, customer_id, invoice_id,warehouse_id, po_num, bill_to,city,sales_man,
                                   ship_date,ship_via, ship_to, payment_method,account_cash_id, payment_terms, payment_date,  
                                   total,vat,net, pay, `change`, created_by, created_date, state, description,retention_percentage,retention_amount,advance_pay,form_type, GlobalId, DeviceId) VALUES (@DATE, @customer_id, @invoice_id,@warehouse_id,
                                   @po_num, @bill_to,@city,@sales_man, @ship_date, @ship_via,@ship_to, @payment_method,@account_cash_id ,@payment_terms, @payment_date, 
                                   @total,  @vat,@net, @pay, @change, @created_by, @created_date, @state, @description, @retention_percentage, @retention_amount, @advance_pay, @form_type, @GlobalId, @DeviceId);
                                   SELECT LAST_INSERT_ID();",
                                   DBClass.CreateParameter("date", info.date),
                                   DBClass.CreateParameter("customer_id", info.customer_id),
                                   DBClass.CreateParameter("invoice_id", info.invoice_id),
                                   DBClass.CreateParameter("city", info.city),
                                   DBClass.CreateParameter("warehouse_id", info.warehouse_id),
                                   DBClass.CreateParameter("po_num", info.po_num),
                                   DBClass.CreateParameter("form_type", info.form_type),
                                   DBClass.CreateParameter("bill_to", info.bill_to),
                                   DBClass.CreateParameter("ship_date", info.ship_date),
                                   DBClass.CreateParameter("sales_man", info.sales_man),
                                   DBClass.CreateParameter("ship_via", info.ship_via),
                                   DBClass.CreateParameter("ship_to", info.ship_to),
                                   DBClass.CreateParameter("payment_method", info.payment_method),
                                   DBClass.CreateParameter("account_cash_id", info.account_cash_id),
                                   DBClass.CreateParameter("payment_terms", info.payment_terms),
                                   DBClass.CreateParameter("payment_date", info.payment_date),
                                   DBClass.CreateParameter("vat", info.vat),
                                   DBClass.CreateParameter("total", info.total),
                                   DBClass.CreateParameter("net", info.net),
                                   DBClass.CreateParameter("description", info.description),
                                   DBClass.CreateParameter("pay", info.pay),
                                   DBClass.CreateParameter("change", info.change),
                                   DBClass.CreateParameter("retention_amount", Convert.ToDecimal(info.retention_amount)),
                                   DBClass.CreateParameter("retention_percentage", Convert.ToDecimal(info.retention_percentage)),
                                   DBClass.CreateParameter("advance_pay", info.advance_pay),
                                   DBClass.CreateParameter("created_by", frmLogin.userId),
                                   DBClass.CreateParameter("created_date", DateTime.Now.Date),
                                    DBClass.CreateParameter("GlobalId", info.GlobalId),
                                    DBClass.CreateParameter("DeviceId", info.DeviceId),
                                   DBClass.CreateParameter("state", info.state)).ToString());

                        foreach (var detail in sale.Details)
                        {
                            InsertSalesItems(detail, invId, info, AllowItemWithOutQty);
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                                DBClass.ExecuteScalar(
                                    "SELECT LastModified FROM tbl_sales WHERE GlobalId=@GlobalId",
                                    DBClass.CreateParameter("@GlobalId", info.GlobalId)
                                )
                            );

                        if (info.LastModified > existingLastModified)
                        {
                            invId = Convert.ToInt32(DBClass.ExecuteScalar(@"SELECT id FROM tbl_sales WHERE GlobalId=@id",
                                                            DBClass.CreateParameter("@id", info.GlobalId)).ToString());

                            DBClass.ExecuteNonQuery(@"UPDATE tbl_sales 
                                     SET  modified_by = @modifiedBy, modified_date = @modifiedDate ,date = @date,sales_man=@sales_man, customer_id = @customer_id, invoice_id = @invoice_id, warehouse_id = @warehouse_id,
                                     po_num = @po_num, bill_to = @bill_to, ship_date = @ship_date, 
                                     ship_via = @ship_via, ship_to = @ship_to, payment_method = @payment_method, account_cash_id = @account_cash_id, 
                                     payment_terms = @payment_terms, payment_date = @payment_date, total = @total, 
                                     vat = @vat, net = @net, pay = @pay, `change` = @change, city = @city, description = @description, retention_percentage = @retention_percentage, retention_amount = @retention_amount, advance_pay = @advance_pay, form_type = @form_type WHERE id = @id;",
                                       DBClass.CreateParameter("@id", invId),
                                       DBClass.CreateParameter("@date", info.date),
                                       DBClass.CreateParameter("@customer_id", info.customer_id),
                                       DBClass.CreateParameter("@invoice_id", info.invoice_id),
                                       DBClass.CreateParameter("@city", info.city),
                                       DBClass.CreateParameter("@warehouse_id", info.warehouse_id),
                                       DBClass.CreateParameter("@po_num", info.po_num),
                                       DBClass.CreateParameter("@bill_to", info.bill_to),
                                       DBClass.CreateParameter("@ship_date", info.ship_date),
                                       DBClass.CreateParameter("@sales_man", info.sales_man.ToString()),
                                       DBClass.CreateParameter("@ship_via", info.ship_via),
                                       DBClass.CreateParameter("@ship_to", info.ship_to),
                                       DBClass.CreateParameter("@payment_method", info.payment_method),
                                       DBClass.CreateParameter("@account_cash_id", info.account_cash_id.ToString()),
                                       DBClass.CreateParameter("@payment_terms", info.payment_terms),
                                       DBClass.CreateParameter("@payment_date", info.payment_date),
                                       DBClass.CreateParameter("@vat", info.vat),
                                       DBClass.CreateParameter("@total", info.total),
                                       DBClass.CreateParameter("@net", info.net),
                                       DBClass.CreateParameter("@description", info.description),
                                       DBClass.CreateParameter("@modifiedBy", frmLogin.userId),
                                       DBClass.CreateParameter("@modifiedDate", DateTime.Now.Date),
                                       DBClass.CreateParameter("@pay", info.pay),
                                       DBClass.CreateParameter("@change", info.change),
                                       DBClass.CreateParameter("retention_amount", info.retention_amount.ToString().Replace(",", "")),
                                       DBClass.CreateParameter("retention_percentage", info.retention_percentage.ToString().Replace(",", "")),
                                       DBClass.CreateParameter("advance_pay", info.advance_pay.ToString().Replace(",", "")),
                                       DBClass.CreateParameter("form_type", info.form_type));

                            DBClass.ExecuteNonQuery(@"DELETE FROM tbl_sales_details WHERE sales_id = @salesDetailId", DBClass.CreateParameter("salesDetailId", invId.ToString()));
                            DBClass.ExecuteNonQuery(@"DELETE FROM tbl_item_transaction WHERE reference = @invId AND type = 'Sales Invoice';DELETE FROM tbl_item_card_details 
                            WHERE trans_type = 'Sales Invoice' and trans_no=@invId", DBClass.CreateParameter("invId", invId));
                            CommonInsert.DeleteCostCenterTransactionEntry(invId.ToString(), "Sales");
                            CommonInsert.DeleteTransactionEntry(invId, "SALES");
                            foreach (var detail in sale.Details)
                            {
                                InsertSalesItems(detail, invId, info, AllowItemWithOutQty);
                            }
                        }
                    }

                    if (invId > 0)
                    {
                        string _accountId = info.payment_method == "Credit" ? level4PaymentCreditMethodId.ToString()
                       : info.account_cash_id.ToString();
                        CommonInsert.addTransactionEntry(info.date, _accountId,
                               info.net.ToString(), "0", invId.ToString(), info.customer_id.ToString(), info.payment_method == "Credit" ? "Sales Invoice" : "Sales Invoice Cash", "SALES", "Sales Invoice NO. " + info.invoice_id,
                               frmLogin.userId, DateTime.Now.Date, info.invoice_id);


                        CommonInsert.addTransactionEntry(info.date,
                          level4SalesInvoice.ToString(), "0", info.total.ToString(), invId.ToString(), "0", info.payment_method == "Credit" ? "Sales Invoice" : "Sales Invoice Cash", "SALES",
                          "Sales Revenue For Invoice No. " + info.invoice_id, frmLogin.userId, DateTime.Now.Date, info.invoice_id);

                        if (info.vat > 0)
                        {
                            CommonInsert.addTransactionEntry(info.date,
                          level4VatId.ToString(), "0", info.vat.ToString(), invId.ToString(), "0", info.payment_method == "Credit" ? "Sales Invoice" : "Sales Invoice Cash", "SALES",
                          "Vat Output For Invoice No. " + info.invoice_id, frmLogin.userId, DateTime.Now.Date, info.invoice_id);
                        }

                        object netResult = DBClass.ExecuteScalar("SELECT account_id FROM tbl_warehouse WHERE id = @id", DBClass.CreateParameter("id", info.warehouse_id.ToString()));
                        int level4Id = netResult != DBNull.Value ? Convert.ToInt32(netResult) : 0;

                        if (!string.IsNullOrEmpty(info.advance_pay.ToString()) && decimal.Parse(info.advance_pay.ToString().Replace(",", "")) > 0)
                        {
                            CommonInsert.addTransactionEntry(info.date,
                               level4AdvancePayment.ToString(),
                               info.advance_pay.ToString().Replace(",", ""), "0", invId.ToString(), "0", info.payment_method == "Credit" ? "Sales Invoice" : "Sales Invoice Cash", "SALES", "Sales Invoice NO. " + info.invoice_id + " Customer Advance Payment",
                               frmLogin.userId, DateTime.Now.Date, info.invoice_id);

                            CommonInsert.addTransactionEntry(info.date,
                               _accountId,
                                "0", info.advance_pay.ToString().Replace(",", ""), invId.ToString(), info.customer_id.ToString(), info.payment_method == "Credit" ? "Sales Invoice" : "Sales Invoice Cash", "SALES", "Sales Invoice NO. " + info.invoice_id + " Customer Advance Payment",
                               frmLogin.userId, DateTime.Now.Date, info.invoice_id);
                        }
                        if (info.retention_amount > 0)
                        {
                            CommonInsert.addTransactionEntry(info.date,
                               level4RetentionAccount.ToString(),
                               info.retention_amount.ToString().Replace(",", ""), "0", invId.ToString(), "0", info.payment_method.ToString() == "Credit" ? "Sales Invoice" : "Sales Invoice Cash", "SALES", "Sales Invoice NO. " + info.invoice_id + " Retention Amount",
                               frmLogin.userId, DateTime.Now.Date, info.invoice_id);
                        }
                    }
                }
            }
        }

        private static void InsertSalesItems(SalesDetailSyncDto detail, int invId, SalesSyncDto info,bool AllowItemWithOutQty)
        {
            DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_sales_details (sales_id, item_id, qty, cost_price, price,discount, vatp, vat, total,cost_center_id, GlobalId, DeviceId)
                    VALUES (@sales_id, @item_id, @qty, @cost_price, @price,@discount, @vatp, @vat, @total,@costCenter, @GlobalId, @DeviceId);",
                        DBClass.CreateParameter("sales_id", invId),
                        DBClass.CreateParameter("item_id", detail.item_id),
                        DBClass.CreateParameter("qty", detail.qty),
                        DBClass.CreateParameter("price", detail.price),
                        DBClass.CreateParameter("cost_price", detail.cost_price),
                        DBClass.CreateParameter("discount", detail.discount),
                        DBClass.CreateParameter("vat", detail.vat),
                        DBClass.CreateParameter("vatp", detail.vatp),
                        DBClass.CreateParameter("total", detail.total),
                        DBClass.CreateParameter("@costCenter", detail.cost_center_id),
                        DBClass.CreateParameter("GlobalId", info.GlobalId.ToString()),
                        DBClass.CreateParameter("DeviceId", info.DeviceId)
                    );

            if (detail.Type == "12 - Service")
            {
                //
            }else if (detail.Type == "13 - Inventory Assembly")
            {
                //using (MySqlDataReader componentReader = DBClass.ExecuteReader(@"
                //            SELECT item_id, qty,(select method FROM tbl_items WHERE tbl_items.id = tbl_item_assembly.item_id) as method 
                //            FROM tbl_item_assembly 
                //            WHERE assembly_id = @assemblyId",
                //    DBClass.CreateParameter("assemblyId", detail.item_id)))
                //{
                //    while (componentReader.Read())
                //    {
                //        int componentId = Convert.ToInt32(componentReader["item_id"]);
                //        decimal componentQty = (decimal)(Convert.ToDecimal(componentReader["qty"]) * detail.qty);
                //        string methodOfIngredients = componentReader["method"].ToString().Trim();

                //        InsertItemTransaction(dgvItems.Rows[i], componentId, componentQty, methodOfIngredients);
                //    }
                //}
            }
            else
            {
                InsertItemTransaction(detail, info, invId, AllowItemWithOutQty);
            }
            
        }
        private static void InsertItemTransaction(SalesDetailSyncDto item, SalesSyncDto info, int invId,bool AllowItemWithOutQty)
        {
            if (item.item_id <= 0 || item.qty <= 0)
                return;

            decimal cost_price = 0;
            if (AllowItemWithOutQty)
            {
                object result = DBClass.ExecuteScalar(@"
                                SELECT cost_price
                                FROM tbl_item_transaction
                                WHERE item_id = @id
                                  AND qty_in > 0
                                  AND date <= @date
                                ORDER BY date DESC, id DESC
                                LIMIT 1;",
                                DBClass.CreateParameter("@id", item.item_id),
                                DBClass.CreateParameter("@date", info.date));

                if (result != null && result != DBNull.Value)
                    cost_price = Convert.ToDecimal(result);

                CommonInsert.InsertItemTransaction(
                    info.date,
                    "Sales Invoice",
                    invId.ToString(),
                    item.item_id.ToString(),
                    cost_price.ToString("N6"),
                    "0",
                    item.price.ToString(),
                    item.qty.ToString(),
                    "0",
                    $"Sales Invoice No. {item.item_id} (Negative Stock)",
                    info.warehouse_id.ToString()
                );
                return;
            }

            if (item.Method == "fifo" || item.Method == "lifo")
            {
                string orderBy = item.Method == "fifo" ? "ASC" : "DESC";
                decimal remainingQty = (decimal)item.qty;

                using (var reader = DBClass.ExecuteReader($@"
                            SELECT id, qty_in, cost_price
                            FROM tbl_item_transaction
                            WHERE item_id = @id
                              AND qty_in > 0
                              AND date <= @date
                            ORDER BY date {orderBy}, id {orderBy}
                            FOR UPDATE;",
                            DBClass.CreateParameter("@id", item.item_id),
                            DBClass.CreateParameter("@date", info.date)))
                {
                    while (reader.Read() && remainingQty > 0)
                    {
                        decimal availableQty = Convert.ToDecimal(reader["qty_in"]);
                        cost_price = Convert.ToDecimal(reader["cost_price"]);
                        decimal qtyToUse = Math.Min(remainingQty, availableQty);

                        remainingQty -= qtyToUse;

                        CommonInsert.InsertItemTransaction(
                            info.date,
                            "Sales Invoice",
                            invId.ToString(),
                            item.item_id.ToString(),
                            cost_price.ToString("N6"),
                            "0",
                            item.price.ToString(),
                            qtyToUse.ToString("N6"),
                            "0",
                            $"Sales Invoice No. {item.item_id}",
                            info.warehouse_id.ToString()
                        );

                        DBClass.ExecuteNonQuery(
                            "UPDATE tbl_item_transaction SET qty_in = qty_in - @qty WHERE id = @id",
                            DBClass.CreateParameter("@qty", qtyToUse),
                            DBClass.CreateParameter("@id", reader["id"])
                        );
                    }
                }

                if (remainingQty > 0)
                {
                    if (cost_price <= 0)
                    {
                        object fallbackCost = DBClass.ExecuteScalar(@"
                                                SELECT cost_price
                                                FROM tbl_item_transaction
                                                WHERE item_id = @id
                                                  AND qty_in > 0
                                                  AND date <= @date
                                                ORDER BY date DESC, id DESC
                                                LIMIT 1;",
                                                DBClass.CreateParameter("@id", item.item_id),
                                                DBClass.CreateParameter("@date", info.date));

                        if (fallbackCost != null && fallbackCost != DBNull.Value)
                            cost_price = Convert.ToDecimal(fallbackCost);
                    }


                    CommonInsert.InsertItemTransaction(
                        info.date,
                        "Sales Invoice",
                        invId.ToString(),
                        item.item_id.ToString(),
                        cost_price.ToString("N6"),
                        "0",
                        item.price.ToString(),
                        remainingQty.ToString("N6"),
                        "0",
                        $"Sales Invoice No. {item.item_id} (Neg. Stock)",
                        info.warehouse_id.ToString()
                    );
                }

                return;
            }

            object avgCostResult = DBClass.ExecuteScalar(@"
                                    SELECT 
                                        CASE 
                                            WHEN SUM(qty_in - qty_out) <= 0 THEN 0
                                            ELSE SUM((qty_in - qty_out) * cost_price) / SUM(qty_in - qty_out)
                                        END
                                    FROM tbl_item_transaction
                                    WHERE item_id = @id
                                      AND date <= @date;",
                                    DBClass.CreateParameter("@id", item.item_id),
                                    DBClass.CreateParameter("@date", info.date));

            if (avgCostResult != null && avgCostResult != DBNull.Value)
                cost_price = Convert.ToDecimal(avgCostResult);

            CommonInsert.InsertItemTransaction(
                info.date,
                "Sales Invoice",
                invId.ToString(),
                item.item_id.ToString(),
                cost_price.ToString("N6"),
                "0",
                item.price.ToString(),
                item.qty.ToString(),
                "0",
                $"Sales Invoice No. {item.item_id}",
                info.warehouse_id.ToString()
            );
        }

        public static List<SalesDetailSyncDto> GetSalesDetailsForSync()
        {
            List<SalesDetailSyncDto> list = new List<SalesDetailSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                            SELECT d.*,i.method Methode,i.type as Type
                            FROM tbl_sales_details d INNER JOIN tbl_items i ON i.id = d.item_id
                            WHERE d.SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SalesDetailSyncDto
                {
                    sales_id = row["sales_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["sales_id"]),
                    item_id = row["item_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["item_id"]),
                    qty = row["qty"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["qty"]),
                    cost_price = row["cost_price"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["cost_price"]),
                    price = row["price"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["price"]),
                    vatp = row["vatp"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["vatp"]),
                    vat = row["vat"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["vat"]),
                    total = row["total"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["total"]),
                    discount = row["discount"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["discount"]),
                    cost_center_id = row["cost_center_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["cost_center_id"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    Method = row["Methode"].ToString(),
                    Type = row["Type"].ToString(),
                    LastModified = row["LastModified"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static List<AdvancePaymentVoucherSyncDto> GetAdvancePaymentVouchersForSync()
        {
            List<AdvancePaymentVoucherSyncDto> list =
                new List<AdvancePaymentVoucherSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_advance_payment_voucher
        WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new AdvancePaymentVoucherSyncDto
                {
                    date = row["date"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["date"]),

                    pv_code = row["pv_code"].ToString(),

                    type = row["type"].ToString(),

                    method = row["method"].ToString(),

                    amount = row["amount"] == DBNull.Value
                        ? null
                        : (decimal?)Convert.ToDecimal(row["amount"]),

                    debit_account_id = row["debit_account_id"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["debit_account_id"]),

                    debit_cost_center_id = row["debit_cost_center_id"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["debit_cost_center_id"]),

                    description = row["description"].ToString(),

                    credit_account_id = row["credit_account_id"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["credit_account_id"]),

                    credit_cost_center_id = row["credit_cost_center_id"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["credit_cost_center_id"]),

                    created_by = row["created_by"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["created_by"]),

                    created_date = row["created_date"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["created_date"]),

                    modified_by = row["modified_by"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["modified_by"]),

                    modified_date = row["modified_date"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["modified_date"]),

                    state = row["state"] == DBNull.Value
                        ? null
                        : (int?)Convert.ToInt32(row["state"]),

                    project_id = Convert.ToInt32(row["project_id"]),

                    GlobalId = row["GlobalId"].ToString(),

                    DeviceId = row["DeviceId"].ToString(),

                    LastModified = row["LastModified"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task UploadAdvancePaymentVouchers()
        {
            var data = GetAdvancePaymentVouchersForSync();

            if (data.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(data);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{hostedUrl}api/sync/upload-advance-payment-vouchers",
                        content);

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                UPDATE tbl_advance_payment_voucher
                SET SyncStatus = 1
                WHERE SyncStatus = 0");
                }
            }
        }
        public static List<AdvancePaymentVoucherDetailSyncDto> GetAdvancePaymentVoucherDetailsForSync()
        {
            List<AdvancePaymentVoucherDetailSyncDto> list =
                new List<AdvancePaymentVoucherDetailSyncDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
        SELECT *
        FROM tbl_advance_payment_voucher_details
        WHERE SyncStatus = 0");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new AdvancePaymentVoucherDetailSyncDto
                {
                    payment_id = Convert.ToInt32(row["payment_id"]),
                    name = row["name"].ToString(),
                    bank_name = row["bank_name"].ToString(),
                    check_name = row["check_name"].ToString(),
                    check_no = row["check_no"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["check_no"]),
                    check_date = row["check_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["check_date"]),
                    bank_account_name = row["bank_account_name"].ToString(),
                    book_no = row["book_no"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["book_no"]),
                    trans_date = row["trans_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["trans_date"]),
                    trans_name = row["trans_name"].ToString(),
                    trans_ref = row["trans_ref"].ToString(),
                    description = row["description"].ToString(),
                    amount = row["amount"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["amount"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = row["LastModified"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task DownloadAdvancePaymentVouchers(DateTime lastSync)
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/sync/download-advance-payment-vouchers?lastSync={lastSync}";

                string json = await client.GetStringAsync(url);

                List<AdvancePaymentVoucherSyncDto> list =
                    JsonConvert.DeserializeObject<List<AdvancePaymentVoucherSyncDto>>(json);

                foreach (var item in list)
                {
                    int count = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            "SELECT COUNT(*) FROM tbl_advance_payment_voucher WHERE GlobalId=@GlobalId",
                            DBClass.CreateParameter("@GlobalId", item.GlobalId)));

                    if (count == 0)
                    {
                        DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_advance_payment_voucher
                    (
                        date,
                        pv_code,
                        type,
                        method,
                        amount,
                        debit_account_id,
                        debit_cost_center_id,
                        description,
                        credit_account_id,
                        credit_cost_center_id,
                        created_by,
                        created_date,
                        modified_by,
                        modified_date,
                        state,
                        project_id,
                        GlobalId,
                        DeviceId,
                        LastModified,
                        SyncStatus
                    )
                    VALUES
                    (
                        @date,
                        @pv_code,
                        @type,
                        @method,
                        @amount,
                        @debit_account_id,
                        @debit_cost_center_id,
                        @description,
                        @credit_account_id,
                        @credit_cost_center_id,
                        @created_by,
                        @created_date,
                        @modified_by,
                        @modified_date,
                        @state,
                        @project_id,
                        @GlobalId,
                        @DeviceId,
                        @LastModified,
                        1
                    )",

                            DBClass.CreateParameter("@date", item.date),
                            DBClass.CreateParameter("@pv_code", item.pv_code),
                            DBClass.CreateParameter("@type", item.type),
                            DBClass.CreateParameter("@method", item.method),
                            DBClass.CreateParameter("@amount", item.amount),
                            DBClass.CreateParameter("@debit_account_id", item.debit_account_id),
                            DBClass.CreateParameter("@debit_cost_center_id", item.debit_cost_center_id),
                            DBClass.CreateParameter("@description", item.description),
                            DBClass.CreateParameter("@credit_account_id", item.credit_account_id),
                            DBClass.CreateParameter("@credit_cost_center_id", item.credit_cost_center_id),
                            DBClass.CreateParameter("@created_by", item.created_by),
                            DBClass.CreateParameter("@created_date", item.created_date),
                            DBClass.CreateParameter("@modified_by", item.modified_by),
                            DBClass.CreateParameter("@modified_date", item.modified_date),
                            DBClass.CreateParameter("@state", item.state),
                            DBClass.CreateParameter("@project_id", item.project_id),
                            DBClass.CreateParameter("@GlobalId", item.GlobalId),
                            DBClass.CreateParameter("@DeviceId", item.DeviceId),
                            DBClass.CreateParameter("@LastModified", item.LastModified)
                        );
                    }
                }
            }
        }
        public static async Task UploadJournalVoucher()
        {
            var journal = GetJournalVoucherForSync();
            var details = GetJournalVoucherDetailsForSync();

            var package = journal.Select(j => new JournalSyncPackageDto
            {
                Info = j,
                Details = details
                                .Where(d => d.GlobalId == j.GlobalId)
                                .ToList()
            }).ToList();

            if (package.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(package);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(
                    $"{hostedUrl}api/Sync/upload-journal-voucher",
                    content);

                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                        UPDATE tbl_journal_voucher
                        SET SyncStatus = 1
                        WHERE SyncStatus = 0
                    ");
                }
            }
        }
        public static List<JournalVoucherDto> GetJournalVoucherForSync()
        {
            List<JournalVoucherDto> list = new List<JournalVoucherDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                                SELECT *
                                FROM tbl_journal_voucher
                                WHERE SyncStatus = 0
                            ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new JournalVoucherDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    code = row["code"].ToString(),

                    debit = row["debit"] == DBNull.Value ? 0 : Convert.ToDecimal(row["debit"]),
                    credit = row["credit"] == DBNull.Value ? 0 : Convert.ToDecimal(row["credit"]),

                    created_by = row["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(row["created_by"]),
                    created_date = row["created_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["created_date"]),

                    modified_by = row["modified_by"] == DBNull.Value ? 0 : Convert.ToInt32(row["modified_by"]),
                    modified_date = row["modified_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["modified_date"]),

                    state = row["state"] == DBNull.Value ? 0 : Convert.ToInt32(row["state"]),
                    project_id = Convert.ToInt32(row["project_id"]),

                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static List<JournalVoucherDetailDto> GetJournalVoucherDetailsForSync()
        {
            List<JournalVoucherDetailDto> list = new List<JournalVoucherDetailDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT *
                FROM tbl_journal_voucher_details
                WHERE SyncStatus = 0
            ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new JournalVoucherDetailDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    debit = Convert.ToDecimal(row["debit"]),
                    credit = Convert.ToDecimal(row["credit"]),
                    inv_id = Convert.ToInt32(row["inv_id"]),
                    description = row["description"].ToString(),
                    partner = row["partner"].ToString(),
                    account_id = Convert.ToInt32(row["account_id"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task DownloadJournalVoucher(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/Sync/download-journal-voucher?lastSync={Uri.EscapeDataString(lastSync.ToString("o"))}&deviceId={Uri.EscapeDataString(DeviceId)}";

                var json = await client.GetStringAsync(url);

                List<JournalSyncPackageDto> journals = JsonConvert.DeserializeObject<List<JournalSyncPackageDto>>(json);
                //var defaultAccounts = BindCombos.DefaultAccounts();

                foreach (var journal in journals)
                {
                    JournalVoucherDto info = journal.Info;
                    string sqlCheck = @"
                                SELECT COUNT(*) 
                                FROM tbl_journal_voucher 
                                WHERE GlobalId = @GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sqlCheck,
                            DBClass.CreateParameter("@GlobalId", info.GlobalId)));

                    int insId = 0;

                    if (exists == 0)
                    {
                        insId = int.Parse(DBClass.ExecuteScalar(@"
                                        INSERT INTO tbl_journal_voucher
                                        (date, code, debit, credit,
                                         created_by, created_date,
                                         modified_by, modified_date,
                                         state, project_id,
                                         GlobalId, DeviceId, LastModified, SyncStatus)
                                        VALUES
                                        (@date, @code, @debit, @credit,
                                         @created_by, @created_date,
                                         @modified_by, @modified_date,
                                         @state, @project_id,
                                         @GlobalId, @DeviceId, @LastModified, 1);
                                        SELECT LAST_INSERT_ID();",
                                DBClass.CreateParameter("@date", info.date),
                                DBClass.CreateParameter("@code", info.code),
                                DBClass.CreateParameter("@debit", info.debit),
                                DBClass.CreateParameter("@credit", info.credit),
                                DBClass.CreateParameter("@created_by", info.created_by),
                                DBClass.CreateParameter("@created_date", info.created_date),
                                DBClass.CreateParameter("@modified_by", info.modified_by),
                                DBClass.CreateParameter("@modified_date", info.modified_date),
                                DBClass.CreateParameter("@state", info.state),
                                DBClass.CreateParameter("@project_id", info.project_id),
                                DBClass.CreateParameter("@GlobalId", info.GlobalId),
                                DBClass.CreateParameter("@DeviceId", info.DeviceId),
                                DBClass.CreateParameter("@LastModified", info.LastModified)).ToString()
                        );

                        foreach (var detail in journal.Details)
                        {
                            insertJournalDetails(detail, insId, info);
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                            DBClass.ExecuteScalar(
                                "SELECT LastModified FROM tbl_journal_voucher WHERE GlobalId=@GlobalId",
                                DBClass.CreateParameter("@GlobalId", info.GlobalId)
                            ));

                        if (info.LastModified > existingLastModified)
                        {
                            insId = Convert.ToInt32(DBClass.ExecuteScalar(@"SELECT id FROM tbl_journal_voucher WHERE GlobalId=@id",
                                                    DBClass.CreateParameter("@id", info.GlobalId)).ToString());

                            DBClass.ExecuteNonQuery(@"UPDATE tbl_journal_voucher SET date=@date, code=@code, debit=@debit, credit=@credit, modified_by=@modified_by, modified_date=@modified_date WHERE id=@id",
                                                      DBClass.CreateParameter("id", insId),
                                                      DBClass.CreateParameter("date", info.date),
                                                      DBClass.CreateParameter("code", info.code),
                                                      DBClass.CreateParameter("debit", info.debit.ToString()),
                                                      DBClass.CreateParameter("credit", info.credit.ToString()),
                                                      DBClass.CreateParameter("modified_by", frmLogin.userId),
                                                      DBClass.CreateParameter("modified_date", DateTime.Now.Date));

                            DBClass.ExecuteNonQuery(@"DELETE from tbl_journal_voucher_details where inv_id=@id;", DBClass.CreateParameter("id", insId.ToString()));
                            CommonInsert.DeleteTransactionEntry(insId, "JOURNAL");

                            foreach (var detail in journal.Details)
                            {
                                insertJournalDetails(detail, insId, info);
                            }
                        }
                    }
                }
            }
        }

        private static void insertJournalDetails(JournalVoucherDetailDto detail, int insId, JournalVoucherDto info)
        {
            DBClass.ExecuteNonQuery(@"INSERT INTO tbl_journal_voucher_details
                                        (date,debit,credit, inv_id, description, account_id,partner, GlobalId, DeviceId) 
                                        VALUES (@date,@debit,@credit, @inv_id, @description, @account_id, @partner, @GlobalId, @DeviceId);",
                        DBClass.CreateParameter("@date", info.date),
                        DBClass.CreateParameter("@debit", detail.debit.ToString()),
                        DBClass.CreateParameter("@credit", detail.credit.ToString()),
                        DBClass.CreateParameter("@inv_id", detail.inv_id),
                        DBClass.CreateParameter("@description", detail.description),
                        DBClass.CreateParameter("@partner", detail.partner),
                        DBClass.CreateParameter("@account_id", detail.account_id),
                        DBClass.CreateParameter("GlobalId", info.GlobalId),
                        DBClass.CreateParameter("DeviceId", info.DeviceId));

            CommonInsert.addTransactionEntry((DateTime)info.date,
                   detail.account_id.ToString(),
                   detail.debit.ToString(), detail.credit.ToString(), insId.ToString(), "0", "JOURNAL VOUCHER", "JOURNAL", "Journal Voucher NO. " + insId,
                    frmLogin.userId, DateTime.Now.Date, detail.inv_id.ToString());
        }

        public static async Task UploadPaymentVoucher()
        {
            var payments = GetPaymentVoucherForSync();
            var details = GetPaymentVoucherDetailsForSync();


            var package = payments.Select(p => new PaymentSyncPackageDto
            {
                Info = p,
                Details = details
                                .Where(d => d.GlobalId == p.GlobalId)
                                .ToList()
            }).ToList();


            if (package.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(package);


            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    $"{hostedUrl}api/Sync/upload-payment-voucher",
                    content);

                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                        UPDATE tbl_payment_voucher
                        SET SyncStatus = 1
                        WHERE SyncStatus = 0
                    ");
                }
            }
        }
        public static List<PaymentVoucherDto> GetPaymentVoucherForSync()
        {
            List<PaymentVoucherDto> list = new List<PaymentVoucherDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT * FROM tbl_payment_voucher
                WHERE SyncStatus = 0
            ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PaymentVoucherDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    code = row["code"].ToString(),
                    type = row["type"].ToString(),
                    method = row["method"].ToString(),

                    amount = row["amount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["amount"]),

                    debit_account_id = Convert.ToInt32(row["debit_account_id"]),
                    debit_cost_center_id = Convert.ToInt32(row["debit_cost_center_id"]),

                    description = row["description"].ToString(),

                    credit_account_id = Convert.ToInt32(row["credit_account_id"]),
                    credit_cost_center_id = Convert.ToInt32(row["credit_cost_center_id"]),

                    bank_id = Convert.ToInt32(row["bank_id"]),
                    bank_account_id = Convert.ToInt32(row["bank_account_id"]),

                    book_no = Convert.ToInt32(row["book_no"]),

                    check_name = row["check_name"].ToString(),
                    check_no = row["check_no"] == DBNull.Value ? "" : row["check_no"].ToString(),
                    check_date = row["check_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["check_date"]),

                    trans_date = row["trans_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["trans_date"]),
                    trans_name = row["trans_name"].ToString(),
                    trans_ref = row["trans_ref"].ToString(),

                    created_by = Convert.ToInt32(row["created_by"]),
                    created_date = row["created_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["created_date"]),

                    modified_by = row["modified_by"] == DBNull.Value ? 0 : Convert.ToInt32(row["modified_by"]),
                    modified_date = row["modified_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["modified_date"]),

                    state = Convert.ToInt32(row["state"]),
                    project_id = Convert.ToInt32(row["project_id"]),

                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static List<PaymentVoucherDetailsDto> GetPaymentVoucherDetailsForSync()
        {
            List<PaymentVoucherDetailsDto> list = new List<PaymentVoucherDetailsDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT * FROM tbl_payment_voucher_details
                WHERE SyncStatus = 0
            ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PaymentVoucherDetailsDto
                {
                    date = Convert.ToDateTime(row["date"]),

                    payment_id = row["payment_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["payment_id"]),
                    hum_id = row["hum_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["hum_id"]),
                    inv_id = row["inv_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["inv_id"]),

                    inv_code = row["inv_code"].ToString(),

                    total = row["total"] == DBNull.Value ? 0 : Convert.ToDecimal(row["total"]),
                    payment = row["payment"] == DBNull.Value ? 0 : Convert.ToDecimal(row["payment"]),

                    description = row["description"].ToString(),
                    voucher_type = row["voucher_type"].ToString(),

                    cost_center_id = row["cost_center_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["cost_center_id"]),
                    project_id = Convert.ToInt32(row["project_id"]),

                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task UploadReceiptVoucher()
        {
            var receipt = GetReceiptVoucherForSync();
            var details = GetReceiptVoucherDetailsForSync();

            var package = receipt.Select(p => new ReceiptSyncPackageDto
            {
                Info = p,
                Details = details
                                .Where(d => d.GlobalId == p.GlobalId)
                                .ToList()
            }).ToList();

            if (package.Count == 0)
                return;

            string json = JsonConvert.SerializeObject(package);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    $"{hostedUrl}api/Sync/upload-receipt-voucher",
                    content);
                
                if (response.IsSuccessStatusCode)
                {
                    DBClass.ExecuteNonQuery(@"
                        UPDATE tbl_receipt_voucher
                        SET SyncStatus = 1
                        WHERE SyncStatus = 0
                    ");
                }
            }
        }
        public static List<ReceiptVoucherDto> GetReceiptVoucherForSync()
        {
            List<ReceiptVoucherDto> list = new List<ReceiptVoucherDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT * FROM tbl_receipt_voucher
                WHERE SyncStatus = 0
            ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ReceiptVoucherDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    code = row["code"].ToString(),
                    type = row["type"].ToString(),
                    method = row["method"].ToString(),
                    amount = row["amount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["amount"]),
                    hum_id = row["hum_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["hum_id"]),
                    credit_account_id = row["credit_account_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["credit_account_id"]),
                    credit_cost_center_id = row["credit_cost_center_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["credit_cost_center_id"]),
                    debit_account_id = row["debit_account_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["debit_account_id"]),
                    debit_cost_center_id = row["debit_cost_center_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["debit_cost_center_id"]),
                    bank_account_id = row["bank_account_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["bank_account_id"]),
                    book_no = row["book_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["book_no"]),
                    bank_id = row["bank_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["bank_id"]),
                    bank_account = row["bank_account"] == DBNull.Value ? 0 : Convert.ToInt32(row["bank_account"]),
                    bank_code = row["bank_code"].ToString(),
                    check_name = row["check_name"].ToString(),
                    check_no = row["check_no"].ToString(),
                    check_date = row["check_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["check_date"]),
                    trans_date = row["trans_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["trans_date"]),
                    trans_name = row["trans_name"].ToString(),
                    trans_ref = row["trans_ref"].ToString(),
                    created_by = row["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(row["created_by"]),
                    created_date = row["created_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["created_date"]),
                    state = row["state"] == DBNull.Value ? 0 : Convert.ToInt32(row["state"]),
                    modified_by = row["modified_by"] == DBNull.Value ? 0 : Convert.ToInt32(row["modified_by"]),
                    modified_date = row["modified_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["modified_date"]),
                    project_id = Convert.ToInt32(row["project_id"]),
                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"]),
                    description = row["Description"].ToString()
                });
            }

            return list;
        }
        public static List<ReceiptVoucherDetailDto> GetReceiptVoucherDetailsForSync()
        {
            List<ReceiptVoucherDetailDto> list = new List<ReceiptVoucherDetailDto>();

            DataTable dt = DBClass.ExecuteDataTable(@"
                SELECT * FROM tbl_receipt_voucher_details
                WHERE SyncStatus = 0
            ");

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ReceiptVoucherDetailDto
                {
                    date = Convert.ToDateTime(row["date"]),
                    payment_id = row["payment_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["payment_id"]),
                    inv_id = row["inv_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["inv_id"]),
                    hum_id = row["hum_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["hum_id"]),

                    inv_code = row["inv_code"].ToString(),

                    total = row["total"] == DBNull.Value ? 0 : Convert.ToDecimal(row["total"]),
                    payment = row["payment"] == DBNull.Value ? 0 : Convert.ToDecimal(row["payment"]),

                    description = row["description"].ToString(),

                    cost_center_id = row["cost_center_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["cost_center_id"]),

                    project_id = Convert.ToInt32(row["project_id"]),

                    GlobalId = row["GlobalId"].ToString(),
                    DeviceId = row["DeviceId"].ToString(),
                    LastModified = Convert.ToDateTime(row["LastModified"])
                });
            }

            return list;
        }
        public static async Task DownloadPaymentVoucher(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/Sync/download-payment-voucher?lastSync={Uri.EscapeDataString(lastSync.ToString("o"))}&deviceId={Uri.EscapeDataString(DeviceId)}";

                string json = await client.GetStringAsync(url);

                List<PaymentSyncPackageDto> paymentses = JsonConvert.DeserializeObject<List<PaymentSyncPackageDto>>(json);
                //var defaultAccounts = BindCombos.DefaultAccounts();

                foreach (var payment in paymentses)
                {
                    PaymentVoucherDto info = payment.Info;

                    string sqlCheck = @"
                                SELECT COUNT(*) 
                                FROM tbl_payment_voucher 
                                WHERE GlobalId = @GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sqlCheck,
                            DBClass.CreateParameter("@GlobalId", info.GlobalId)));

                    int insId = 0;

                    if (exists == 0)
                    {
                        insId = int.Parse(DBClass.ExecuteScalar(@"
                                        INSERT INTO tbl_payment_voucher
                                        (
                                            date,
                                            code,
                                            type,
                                            method,
                                            amount,
                                            debit_account_id,
                                            debit_cost_center_id,
                                            description,
                                            credit_account_id,
                                            credit_cost_center_id,
                                            bank_id,
                                            bank_account_id,
                                            book_no,
                                            check_name,
                                            check_no,
                                            check_date,
                                            trans_date,
                                            trans_name,
                                            trans_ref,
                                            created_by,
                                            created_date,
                                            modified_by,
                                            modified_date,
                                            state,
                                            project_id,
                                            GlobalId,
                                            DeviceId,
                                            LastModified,
                                            SyncStatus
                                        )
                                        VALUES
                                        (
                                            @date,
                                            @code,
                                            @type,
                                            @method,
                                            @amount,
                                            @debit_account_id,
                                            @debit_cost_center_id,
                                            @description,
                                            @credit_account_id,
                                            @credit_cost_center_id,
                                            @bank_id,
                                            @bank_account_id,
                                            @book_no,
                                            @check_name,
                                            @check_no,
                                            @check_date,
                                            @trans_date,
                                            @trans_name,
                                            @trans_ref,
                                            @created_by,
                                            @created_date,
                                            @modified_by,
                                            @modified_date,
                                            @state,
                                            @project_id,
                                            @GlobalId,
                                            @DeviceId,
                                            @LastModified,
                                            1
                                        );
                                        SELECT LAST_INSERT_ID();",
                                        DBClass.CreateParameter("@date", info.date),
                                        DBClass.CreateParameter("@code", info.code),
                                        DBClass.CreateParameter("@type", info.type),
                                        DBClass.CreateParameter("@method", info.method),
                                        DBClass.CreateParameter("@amount", info.amount),
                                        DBClass.CreateParameter("@debit_account_id", info.debit_account_id),
                                        DBClass.CreateParameter("@debit_cost_center_id", info.debit_cost_center_id),
                                        DBClass.CreateParameter("@description", info.description),
                                        DBClass.CreateParameter("@credit_account_id", info.credit_account_id),
                                        DBClass.CreateParameter("@credit_cost_center_id", info.credit_cost_center_id),
                                        DBClass.CreateParameter("@bank_id", info.bank_id),
                                        DBClass.CreateParameter("@bank_account_id", info.bank_account_id),
                                        DBClass.CreateParameter("@book_no", info.book_no),
                                        DBClass.CreateParameter("@check_name", info.check_name),
                                        DBClass.CreateParameter("@check_no", info.check_no),
                                        DBClass.CreateParameter("@check_date", info.check_date),
                                        DBClass.CreateParameter("@trans_date", info.trans_date),
                                        DBClass.CreateParameter("@trans_name", info.trans_name),
                                        DBClass.CreateParameter("@trans_ref", info.trans_ref),
                                        DBClass.CreateParameter("@created_by", info.created_by),
                                        DBClass.CreateParameter("@created_date", info.created_date),
                                        DBClass.CreateParameter("@modified_by", info.modified_by),
                                        DBClass.CreateParameter("@modified_date", info.modified_date),
                                        DBClass.CreateParameter("@state", info.state),
                                        DBClass.CreateParameter("@project_id", info.project_id),
                                        DBClass.CreateParameter("@GlobalId", info.GlobalId),
                                        DBClass.CreateParameter("@DeviceId", info.DeviceId),
                                        DBClass.CreateParameter("@LastModified", info.LastModified)).ToString()
                        );

                        foreach (var detail in payment.Details)
                        {
                            insertPaymentDetails(detail, insId, info);
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                            DBClass.ExecuteScalar(
                                "SELECT LastModified FROM tbl_payment_voucher WHERE GlobalId=@GlobalId",
                                DBClass.CreateParameter("@GlobalId", info.GlobalId)
                            ));

                        if (info.LastModified > existingLastModified)
                        {
                            insId = Convert.ToInt32(DBClass.ExecuteScalar(@"SELECT id FROM tbl_payment_voucher WHERE GlobalId=@id",
                                                    DBClass.CreateParameter("@id", info.GlobalId)).ToString());

                            DBClass.ExecuteScalar(@"UPDATE tbl_payment_voucher SET date=@date, code=@code, type=@type, method=@method, amount=@amount,  
                                                            debit_account_id=@debit_account_id, debit_cost_center_id=@debit_cost_center_id, description=@description,credit_account_id=@credit_account_id,
                                                            credit_cost_center_id=@credit_cost_center_id,bank_id=@bank_id, bank_account_id=@bank_account_id, book_no=@book_no, check_name=@check_name, check_no=@check_no,
                                                            check_date=@check_date, trans_date=@trans_date, trans_name=@trans_name, trans_ref=@trans_ref, modified_by=@modified_by, modified_date=@modified_date where id=@id",
                                                            DBClass.CreateParameter("id", insId),
                                                            DBClass.CreateParameter("date", info.date),
                                                            DBClass.CreateParameter("code", info.code),
                                                            DBClass.CreateParameter("type", info.type),
                                                            DBClass.CreateParameter("method", info.method),
                                                            DBClass.CreateParameter("amount", info.amount),
                                                            DBClass.CreateParameter("debit_account_id", info.debit_account_id ?? 0),
                                                            DBClass.CreateParameter("debit_cost_center_id", info.debit_cost_center_id ?? 0),
                                                            DBClass.CreateParameter("description", info.description),
                                                            DBClass.CreateParameter("credit_account_id", info.credit_account_id ?? 0),
                                                            DBClass.CreateParameter("credit_cost_center_id", info.credit_cost_center_id ?? 0),
                                                            DBClass.CreateParameter("bank_id", info.method == "Cheque" ? info.bank_id ?? 0 : 0),
                                                            DBClass.CreateParameter("bank_account_id", info.method == "Cheque" ? info.bank_account_id ?? 0 : 0),
                                                            DBClass.CreateParameter("book_no", info.book_no ?? 0),
                                                            DBClass.CreateParameter("check_name", info.check_name),
                                                            DBClass.CreateParameter("check_no", info.check_no.ToString()),
                                                            DBClass.CreateParameter("check_date", info.method == "Cheque" ? info.check_date : null),
                                                            DBClass.CreateParameter("trans_date", info.method == "Transfer" ? info.trans_date : null),
                                                            DBClass.CreateParameter("trans_name", info.trans_name),
                                                            DBClass.CreateParameter("trans_ref", info.trans_ref),
                                                            DBClass.CreateParameter("modified_by", frmLogin.userId),
                                                            DBClass.CreateParameter("modified_date", DateTime.Now.Date),
                                                            DBClass.CreateParameter("LastModified", DateTime.Now.Date));

                            DBClass.ExecuteNonQuery("Delete from tbl_payment_voucher_details where payment_id=@id", DBClass.CreateParameter("id", insId));
                            CommonInsert.DeleteTransactionEntry(insId, "PAYMENT");
                            foreach (var detail in payment.Details)
                            {
                                insertPaymentDetails(detail, insId, info);
                            }
                        }
                    }
                    if(insId > 0)
                    {
                        string tType = "", humId = "0";
                        tType = "Vendor Payment";
                        humId = "0";

                        CommonInsert.addTransactionEntry(info.date,
                            info.debit_account_id.ToString(),
                            info.amount.ToString(), "0", insId.ToString(), humId, tType, "PAYMENT", "Payment Voucher NO. " + info.code,
                             frmLogin.userId, DateTime.Now.Date, info.code);

                        CommonInsert.addTransactionEntry(info.date,
                                              info.credit_account_id.ToString(),
                                           "0", info.amount.ToString(), insId.ToString(), "0", tType, "PAYMENT", "Payment Voucher NO. " + info.code,
                                               frmLogin.userId, DateTime.Now.Date, info.code);
                    }
                }
            }
        }

        private static void insertPaymentDetails(PaymentVoucherDetailsDto detail, int insId, PaymentVoucherDto info)
        {
            DBClass.ExecuteNonQuery(@"INSERT INTO tbl_payment_voucher_details(date,payment_id,hum_id, inv_id,inv_code,total, payment, description,voucher_type, GlobalId, DeviceId) 
                                        VALUES (@date,@payment_id,@hum_id ,@inv_id,@inv_code,@total, @payment, @description,@voucher_type, @GlobalId, @DeviceId);",
                                        DBClass.CreateParameter("@payment_id", insId),
                                        DBClass.CreateParameter("@date", detail.date),
                                        DBClass.CreateParameter("@hum_id", detail.hum_id),
                                        DBClass.CreateParameter("@total", detail.total),
                                        DBClass.CreateParameter("@inv_code", detail.inv_code),
                                        DBClass.CreateParameter("@inv_id", detail.inv_id),
                                        DBClass.CreateParameter("@payment", detail.payment),
                                        DBClass.CreateParameter("@description", detail.description),
                                        DBClass.CreateParameter("@voucher_type", detail.voucher_type),
                                        DBClass.CreateParameter("GlobalId", info.GlobalId),
                                        DBClass.CreateParameter("DeviceId", info.DeviceId)
                                        );

        }

        public static async Task DownloadReceiptVoucher(DateTime lastSync)
        {
            string DeviceId = Utilities.MachineName;
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"{hostedUrl}api/Sync/download-receipt-voucher?lastSync={Uri.EscapeDataString(lastSync.ToString("o"))}&deviceId={Uri.EscapeDataString(DeviceId)}";

                string json = await client.GetStringAsync(url);

                List<ReceiptSyncPackageDto> receipts = JsonConvert.DeserializeObject<List<ReceiptSyncPackageDto>>(json);
                var defaultAccounts = BindCombos.DefaultAccounts();

                foreach (var receipt in receipts)
                {
                    ReceiptVoucherDto info = receipt.Info;

                    string sqlCheck = @"
                    SELECT COUNT(*) 
                    FROM tbl_receipt_voucher 
                    WHERE GlobalId = @GlobalId";

                    int exists = Convert.ToInt32(
                        DBClass.ExecuteScalar(
                            sqlCheck,
                            DBClass.CreateParameter("@GlobalId", info.GlobalId)));

                    int insId = 0;

                    if (exists == 0)
                    {
                        insId = int.Parse(DBClass.ExecuteScalar(@"
                                            INSERT INTO tbl_receipt_voucher
                                            (
                                                date,code,type,method,amount,hum_id,credit_account_id,credit_cost_center_id,
                                                description,debit_account_id,debit_cost_center_id,bank_account_id,
                                                book_no,bank_id,bank_account,bank_code,check_name,
                                                check_no,check_date,trans_date,trans_name,trans_ref,created_by,created_date,
                                                state,modified_by,modified_date,project_id,GlobalId,DeviceId,LastModified,SyncStatus
                                            )
                                            VALUES
                                            (
                                                @date,@code,@type,@method,@amount,@hum_id,@credit_account_id,@credit_cost_center_id,@description,@debit_account_id,
                                                @debit_cost_center_id,@bank_account_id,@book_no,@bank_id,@bank_account,@bank_code,@check_name,
                                                @check_no,@check_date,@trans_date,@trans_name,@trans_ref,
                                                @created_by,@created_date,@state,@modified_by,@modified_date,
                                                @project_id,@GlobalId,@DeviceId,@LastModified,1
                                            );
                                            SELECT LAST_INSERT_ID();",
                                    DBClass.CreateParameter("@date", info.date),
                                    DBClass.CreateParameter("@code", info.code),
                                    DBClass.CreateParameter("@type", info.type),
                                    DBClass.CreateParameter("@method", info.method),
                                    DBClass.CreateParameter("@amount", info.amount),
                                    DBClass.CreateParameter("@hum_id", info.hum_id),
                                    DBClass.CreateParameter("@credit_account_id", info.credit_account_id),
                                    DBClass.CreateParameter("@credit_cost_center_id", info.credit_cost_center_id),
                                    DBClass.CreateParameter("@description", info.description),
                                    DBClass.CreateParameter("@debit_account_id", info.debit_account_id),
                                    DBClass.CreateParameter("@debit_cost_center_id", info.debit_cost_center_id),
                                    DBClass.CreateParameter("@bank_account_id", info.bank_account_id),
                                    DBClass.CreateParameter("@book_no", info.book_no),
                                    DBClass.CreateParameter("@bank_id", info.bank_id),
                                    DBClass.CreateParameter("@bank_account", info.bank_account),
                                    DBClass.CreateParameter("@bank_code", info.bank_code),
                                    DBClass.CreateParameter("@check_name", info.check_name),
                                    DBClass.CreateParameter("@check_no", info.check_no),
                                    DBClass.CreateParameter("@check_date", info.check_date),
                                    DBClass.CreateParameter("@trans_date", info.trans_date),
                                    DBClass.CreateParameter("@trans_name", info.trans_name),
                                    DBClass.CreateParameter("@trans_ref", info.trans_ref),
                                    DBClass.CreateParameter("@created_by", info.created_by),
                                    DBClass.CreateParameter("@created_date", info.created_date),
                                    DBClass.CreateParameter("@state", info.state),
                                    DBClass.CreateParameter("@modified_by", info.modified_by),
                                    DBClass.CreateParameter("@modified_date", info.modified_date),
                                    DBClass.CreateParameter("@project_id", info.project_id),
                                    DBClass.CreateParameter("@GlobalId", info.GlobalId),
                                    DBClass.CreateParameter("@DeviceId", info.DeviceId),
                                    DBClass.CreateParameter("@LastModified", info.LastModified)).ToString()
                        );

                        foreach (var detail in receipt.Details)
                        {
                            insertReceiptDetails(detail, insId, info);
                        }
                    }
                    else
                    {
                        var existingLastModified = Convert.ToDateTime(
                                                DBClass.ExecuteScalar(
                                                    "SELECT LastModified FROM tbl_receipt_voucher WHERE GlobalId=@GlobalId",
                                                    DBClass.CreateParameter("@GlobalId", info.GlobalId)
                                                ));

                        if (info.LastModified > existingLastModified)
                        {
                            insId = Convert.ToInt32(DBClass.ExecuteScalar(@"SELECT id FROM tbl_receipt_voucher WHERE GlobalId=@id",
                                                    DBClass.CreateParameter("@id", info.GlobalId)).ToString());

                            DBClass.ExecuteScalar(@"UPDATE tbl_receipt_voucher SET
                                                          date=@date, code=@code, type=@type, method=@method, amount=@amount,  debit_account_id=@debit_account_id,debit_cost_center_id=@debit_cost_center_id, 
                                                          description=@description,credit_account_id=@credit_account_id,credit_cost_center_id=@credit_cost_center_id,
                                                          bank_account_id=@bank_account, book_no=@book_no,bank_id=@bank_id, bank_code=@bank_code, check_name=@check_name, check_no=@check_no,
                                                          check_date=@check_date,trans_date=@trans_date, trans_name=@trans_name, trans_ref=@trans_ref, modified_by=@modified_by, modified_date=@modified_date where id=@id",
                                                       DBClass.CreateParameter("id", insId),
                                                       DBClass.CreateParameter("date", info.date),
                                                       DBClass.CreateParameter("code", info.code),
                                                       DBClass.CreateParameter("type", info.type),
                                                       DBClass.CreateParameter("method", info.method),
                                                       DBClass.CreateParameter("amount", info.amount),
                                                       DBClass.CreateParameter("credit_account_id", info.credit_account_id),
                                                       DBClass.CreateParameter("credit_cost_center_id", info.credit_cost_center_id),
                                                       DBClass.CreateParameter("description", info.description),
                                                       DBClass.CreateParameter("debit_account_id", info.debit_account_id),
                                                       DBClass.CreateParameter("debit_cost_center_id", info.debit_cost_center_id),
                                                       DBClass.CreateParameter("bank_id", info.bank_id),
                                                       DBClass.CreateParameter("bank_account", info.bank_account),
                                                       DBClass.CreateParameter("book_no", info.book_no),
                                                       DBClass.CreateParameter("bank_code", info.bank_code),
                                                       DBClass.CreateParameter("check_name", info.check_name),
                                                       DBClass.CreateParameter("check_no", info.check_no),
                                                       DBClass.CreateParameter("check_date", info.check_date),
                                                       DBClass.CreateParameter("trans_date", info.trans_date),
                                                       DBClass.CreateParameter("trans_name", info.trans_name),
                                                       DBClass.CreateParameter("trans_ref", info.trans_ref),
                                                       DBClass.CreateParameter("modified_by", frmLogin.userId),
                                                       DBClass.CreateParameter("modified_date", DateTime.Now.Date));
                            DBClass.ExecuteNonQuery("Delete from tbl_receipt_voucher_details where payment_id=@id", DBClass.CreateParameter("id", insId));
                            CommonInsert.DeleteTransactionEntry(insId, "RECEIPT");

                            foreach (var detail in receipt.Details)
                            {
                                insertReceiptDetails(detail, insId, info);
                            }
                        }
                    }
                    if (insId > 0)
                    {
                        CommonInsert.addTransactionEntry(info.date,
                              info.debit_account_id.ToString(),
                              info.amount.ToString(), "0", insId.ToString(), "0", info.type + " Receipt", "RECEIPT", "Receipt Voucher NO. " + info.code,
                               frmLogin.userId, DateTime.Now.Date, info.code);

                        CommonInsert.addTransactionEntry(info.date,
                                              info.credit_account_id.ToString(),
                                             "0", info.amount.ToString(), insId.ToString(), info.type == "Customer" ? info.hum_id.ToString() : "0", info.type + " Receipt", "RECEIPT", "Receipt Voucher NO. " + info.code,
                                               frmLogin.userId, DateTime.Now.Date, info.code);
                    }
                }
            }
        }

        private static void insertReceiptDetails(ReceiptVoucherDetailDto detail, int insId, ReceiptVoucherDto info)
        {
            DBClass.ExecuteNonQuery(@"INSERT INTO tbl_receipt_voucher_details
                                        (date,payment_id,hum_id, inv_id,inv_code,total, payment, description, GlobalId, DeviceId) 
                                        VALUES (@date,@payment_id,@hum_id ,@inv_id,@inv_code,@total, @payment, @description, @GlobalId, @DeviceId);",
                    DBClass.CreateParameter("@payment_id", insId),
                    DBClass.CreateParameter("@date", detail.date),
                    DBClass.CreateParameter("@hum_id", detail.hum_id),
                    DBClass.CreateParameter("@inv_code", detail.inv_code),
                    DBClass.CreateParameter("@total", detail.total),
                    DBClass.CreateParameter("@inv_id", detail.inv_id),
                    DBClass.CreateParameter("@payment", detail.payment),
                    DBClass.CreateParameter("@description", detail.description),
                DBClass.CreateParameter("GlobalId", info.GlobalId),
                DBClass.CreateParameter("DeviceId", info.DeviceId));

        }

        
        private static string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lastsync.txt");

        // LOAD
        public static DateTime LoadLastSyncFromLocalStorage()
        {
            try
            {
                if (!File.Exists(filePath))
                    return DateTime.MinValue;

                string content = File.ReadAllText(filePath);

                return DateTime.Parse(
                    content,
                    null,
                    DateTimeStyles.RoundtripKind);
            }
            catch
            {
                return DateTime.MinValue;
            }
            //try
            //{
            //    if (!File.Exists(filePath))
            //        return DateTime.MinValue; // first sync

            //    string content = File.ReadAllText(filePath);

            //    if (DateTime.TryParse(content, out DateTime lastSync))
            //        return lastSync;

            //    return DateTime.MinValue;
            //}
            //catch
            //{
            //    return DateTime.MinValue;
            //}
        }

        // SAVE
        public static void SaveLastSyncToLocalStorage(DateTime lastSync)
        {
            try
            {
                File.WriteAllText(filePath, lastSync.ToString("o")); // ISO format
            }
            catch
            {
                // optionally log error
            }
        }
    }
}


public class CustomerSyncDto
{
    public string GlobalId { get; set; }
    public int code { get; set; }
    public string name { get; set; }
    public int? Cat_id { get; set; }
    public decimal? Balance { get; set; }
    public DateTime? date { get; set; }
    public string main_phone { get; set; }
    public string work_phone { get; set; }
    public string mobile { get; set; }
    public string email { get; set; }
    public string country { get; set; }
    public string city { get; set; }
    public string region { get; set; }
    public int? account_id { get; set; }
    public string trn { get; set; }
    public int? active { get; set; }
    public int? state { get; set; }
    public int project_id { get; set; }
    public string project_site { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class VendorSyncDto
{
    public string GlobalId { get; set; }

    public int code { get; set; }

    public string name { get; set; }

    public int? Cat_id { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? date { get; set; }

    public string main_phone { get; set; }

    public string work_phone { get; set; }

    public string mobile { get; set; }

    public string email { get; set; }

    public string ccemail { get; set; }

    public string website { get; set; }

    public string country { get; set; }

    public string city { get; set; }

    public string region { get; set; }

    public string building_name { get; set; }

    public int? account_id { get; set; }

    public string trn { get; set; }

    public string facilty_name { get; set; }

    public int? active { get; set; }

    public int? created_by { get; set; }

    public DateTime? created_date { get; set; }

    public int? state { get; set; }

    public string type { get; set; }

    public int project_id { get; set; }

    public string project_site { get; set; }

    public string DeviceId { get; set; }

    public DateTime LastModified { get; set; }
}
public class PurchaseSyncPackageDto
{
    public PurchaseSyncDto Info { get; set; }

    public List<PurchaseDetailSyncDto> Details { get; set; }
}
public class PurchaseSyncDto
{
    public DateTime date { get; set; }

    public int vendor_id { get; set; }

    public string invoice_id { get; set; }

    public int warehouse_id { get; set; }

    public string po_num { get; set; }

    public string bill_to { get; set; }

    public string city { get; set; }

    public string sales_man { get; set; }

    public DateTime? ship_date { get; set; }

    public string ship_via { get; set; }

    public string ship_to { get; set; }

    public string payment_method { get; set; }

    public int account_cash_id { get; set; }

    public string payment_terms { get; set; }

    public DateTime payment_date { get; set; }

    public decimal total { get; set; }

    public decimal vat { get; set; }

    public decimal net { get; set; }

    public decimal pay { get; set; }

    public decimal change { get; set; }

    public int created_by { get; set; }

    public DateTime created_date { get; set; }

    public int? modified_by { get; set; }

    public DateTime? modified_date { get; set; }

    public int state { get; set; }

    public string purchase_type { get; set; }

    public int fixed_asset_category_id { get; set; }

    public int project_id { get; set; }

    public string description { get; set; }

    public string reference_no { get; set; }

    public string GlobalId { get; set; }

    public string DeviceId { get; set; }

    public DateTime? LastModified { get; set; }
}
public class PurchaseDetailSyncDto
{
    public int? purchase_id { get; set; }

    public int? item_id { get; set; }

    public decimal? qty { get; set; }

    public decimal? cost_price { get; set; }

    public decimal? price { get; set; }

    public decimal? vatp { get; set; }

    public int? vat { get; set; }

    public decimal? total { get; set; }

    public decimal? discount { get; set; }

    public int? cost_center_id { get; set; }

    public int project_id { get; set; }

    // New fields from Item table
    public string Method { get; set; }
    public string Type { get; set; }
    public string GlobalId { get; set; }

    public string DeviceId { get; set; }

    public DateTime? LastModified { get; set; }
}
public class SalesSyncPackageDto
{
    public SalesSyncDto Info { get; set; }

    public List<SalesDetailSyncDto> Details { get; set; }
}
public class SalesSyncDto
{
    public DateTime date { get; set; }
    public int customer_id { get; set; }
    public string invoice_id { get; set; }
    public int warehouse_id { get; set; }
    public string po_num { get; set; }
    public string form_type { get; set; }
    public string bill_to { get; set; }
    public string city { get; set; }
    public string sales_man { get; set; }
    public DateTime? ship_date { get; set; }
    public string ship_via { get; set; }
    public string ship_to { get; set; }
    public string payment_method { get; set; }
    public int account_cash_id { get; set; }
    public string payment_terms { get; set; }
    public DateTime payment_date { get; set; }
    public decimal total { get; set; }
    public decimal vat { get; set; }
    public decimal net { get; set; }
    public decimal pay { get; set; }
    public decimal change { get; set; }
    public int created_by { get; set; }
    public DateTime created_date { get; set; }
    public int? modified_by { get; set; }
    public DateTime? modified_date { get; set; }
    public int state { get; set; }
    public decimal discount { get; set; }
    public decimal retention_amount { get; set; }
    public decimal retention_percentage { get; set; }
    public decimal advance_pay { get; set; }
    public decimal cost_center_id { get; set; }
    public int project_id { get; set; }
    public string description { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime? LastModified { get; set; }
}
public class SalesDetailSyncDto
{
    public int? sales_id { get; set; }

    public int? item_id { get; set; }

    public decimal? qty { get; set; }

    public decimal? cost_price { get; set; }

    public decimal? price { get; set; }

    public decimal? vatp { get; set; }

    public int? vat { get; set; }

    public decimal? total { get; set; }

    public decimal? discount { get; set; }

    public int? cost_center_id { get; set; }

    public int project_id { get; set; }

    // New fields from Item table
    public string Method { get; set; }
    public string Type { get; set; }
    public string GlobalId { get; set; }

    public string DeviceId { get; set; }

    public DateTime? LastModified { get; set; }
}
public class AdvancePaymentVoucherSyncDto
{
    public DateTime? date { get; set; }

    public string pv_code { get; set; }

    public string type { get; set; }

    public string method { get; set; }

    public decimal? amount { get; set; }

    public int? debit_account_id { get; set; }

    public int? debit_cost_center_id { get; set; }

    public string description { get; set; }

    public int? credit_account_id { get; set; }

    public int? credit_cost_center_id { get; set; }

    public int? created_by { get; set; }

    public DateTime? created_date { get; set; }

    public int? modified_by { get; set; }

    public DateTime? modified_date { get; set; }

    public int? state { get; set; }

    public int project_id { get; set; }

    public string GlobalId { get; set; }

    public string DeviceId { get; set; }

    public DateTime? LastModified { get; set; }
}
public class AdvancePaymentVoucherDetailSyncDto
{
    public int payment_id { get; set; }

    public string name { get; set; }

    public string bank_name { get; set; }

    public string check_name { get; set; }

    public int? check_no { get; set; }

    public DateTime? check_date { get; set; }

    public string bank_account_name { get; set; }

    public int? book_no { get; set; }

    public DateTime? trans_date { get; set; }

    public string trans_name { get; set; }

    public string trans_ref { get; set; }

    public string description { get; set; }

    public decimal? amount { get; set; }

    public int project_id { get; set; }

    public string GlobalId { get; set; }

    public string DeviceId { get; set; }

    public DateTime? LastModified { get; set; }
}
public class CoaLevel2SyncDto
{
    public string name { get; set; }

    public int code { get; set; }

    public int main_id { get; set; }
}
public class CoaLevel3SyncDto
{
    public string name { get; set; }
    public int code { get; set; }
    public int main_id { get; set; }
}
public class CoaLevel4SyncDto
{
    public string name { get; set; }
    public int code { get; set; }
    public int main_id { get; set; }

    public decimal? debit { get; set; }
    public decimal? credit { get; set; }

    public DateTime? date { get; set; }
}
public class ItemSyncDto
{
    public string code { get; set; }
    public string type { get; set; }
    public int warehouse_id { get; set; }
    public string name { get; set; }
    public int unit_id { get; set; }
    public string barcode { get; set; }

    public decimal cost_price { get; set; }
    public int cogs_account_id { get; set; }
    public int vendor_id { get; set; }
    public decimal sales_price { get; set; }
    public int tax_code_id { get; set; }
    public int income_account_id { get; set; }
    public int asset_account_id { get; set; }

    public decimal min_amount { get; set; }
    public decimal max_amount { get; set; }
    public decimal on_hand { get; set; }
    public decimal total_value { get; set; }

    public DateTime date { get; set; }

    public int active { get; set; }
    public string method { get; set; }
    public int state { get; set; }
    public int created_By { get; set; }
    public DateTime created_date { get; set; }
    public int deleted_by { get; set; }

    public int? category_id { get; set; }
    public int? posItem { get; set; }
    public string item_type { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class JournalSyncPackageDto
{
    public JournalVoucherDto Info {  get; set; }
    public List<JournalVoucherDetailDto> Details { get; set; }
}
public class JournalVoucherDto
{
    public DateTime? date { get; set; }
    public string code { get; set; }

    public decimal debit { get; set; }
    public decimal credit { get; set; }

    public int created_by { get; set; }
    public DateTime? created_date { get; set; }

    public int modified_by { get; set; }
    public DateTime? modified_date { get; set; }

    public int state { get; set; }
    public int project_id { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class JournalVoucherDetailDto
{
    public DateTime date { get; set; }

    public decimal debit { get; set; }
    public decimal credit { get; set; }

    public int inv_id { get; set; }

    public string description { get; set; }
    public string partner { get; set; }

    public int account_id { get; set; }
    public int project_id { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class PaymentSyncPackageDto
{
    public PaymentVoucherDto Info { get; set; }
    public List<PaymentVoucherDetailsDto> Details { get; set; }
}
public class PaymentVoucherDto
{
    public DateTime date { get; set; }
    public string code { get; set; }
    public string type { get; set; }
    public string method { get; set; }

    public decimal? amount { get; set; }

    public int? debit_account_id { get; set; }
    public int? debit_cost_center_id { get; set; }

    public string description { get; set; }

    public int? credit_account_id { get; set; }
    public int? credit_cost_center_id { get; set; }

    public int? bank_id { get; set; }
    public int? bank_account_id { get; set; }

    public int? book_no { get; set; }

    public string check_name { get; set; }
    public string check_no { get; set; }
    public DateTime? check_date { get; set; } = null;

    public DateTime? trans_date { get; set; } = null;
    public string trans_name { get; set; }
    public string trans_ref { get; set; }

    public int? created_by { get; set; }
    public DateTime? created_date { get; set; }

    public int modified_by { get; set; }
    public DateTime? modified_date { get; set; }

    public int? state { get; set; }
    public int project_id { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class PaymentVoucherDetailsDto
{
    public DateTime? date { get; set; }

    public int? payment_id { get; set; }
    public int? hum_id { get; set; }
    public int? inv_id { get; set; }

    public string inv_code { get; set; }

    public decimal? total { get; set; }
    public decimal? payment { get; set; }

    public string description { get; set; }
    public string voucher_type { get; set; }

    public int? cost_center_id { get; set; }
    public int project_id { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class ReceiptSyncPackageDto
{
    public ReceiptVoucherDto Info {  get; set; }
    public List<ReceiptVoucherDetailDto> Details { get; set; }
}
public class ReceiptVoucherDto
{
    public DateTime date { get; set; }
    public string code { get; set; }
    public string type { get; set; }
    public string method { get; set; }
    public decimal? amount { get; set; }

    public int? hum_id { get; set; }

    public int? credit_account_id { get; set; }
    public int? credit_cost_center_id { get; set; }

    public string description { get; set; }

    public int? debit_account_id { get; set; }
    public int? debit_cost_center_id { get; set; }

    public int? bank_account_id { get; set; }
    public int? book_no { get; set; }

    public int? bank_id { get; set; }
    public int? bank_account { get; set; }

    public string bank_code { get; set; }

    public string check_name { get; set; }
    public string check_no { get; set; }

    public DateTime? check_date { get; set; }
    public DateTime? trans_date { get; set; }

    public string trans_name { get; set; }
    public string trans_ref { get; set; }

    public int? created_by { get; set; }
    public DateTime? created_date { get; set; }

    public int? state { get; set; }
    public int? modified_by { get; set; }
    public DateTime? modified_date { get; set; }

    public int project_id { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class ReceiptVoucherDetailDto
{
    public DateTime? date { get; set; }

    public int? payment_id { get; set; }
    public int? inv_id { get; set; }
    public int? hum_id { get; set; }

    public string inv_code { get; set; }

    public decimal? total { get; set; }
    public decimal? payment { get; set; }

    public string description { get; set; }

    public int? cost_center_id { get; set; }

    public int project_id { get; set; }

    public string GlobalId { get; set; }
    public string DeviceId { get; set; }
    public DateTime LastModified { get; set; }
}
public class TransactionDto
{
    public DateTime? date { get; set; }

    public int? account_id { get; set; }

    public decimal? debit { get; set; }
    public decimal? credit { get; set; }

    public int transaction_id { get; set; }

    public int? hum_id { get; set; }

    public string type { get; set; }
    public string t_type { get; set; }

    public string description { get; set; }

    public int? created_by { get; set; }
    public DateTime? created_date { get; set; }

    public int? modified_by { get; set; }
    public DateTime? modified_date { get; set; }

    public int? state { get; set; }

    public string voucher_no { get; set; }

    public int project_id { get; set; }

    public string GlobalId { get; set; }

    public string DeviceId { get; set; }

    public DateTime LastModified { get; set; }
}
