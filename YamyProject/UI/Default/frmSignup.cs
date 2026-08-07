using System;
using System.Diagnostics;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Default;

namespace YamyProject
{
    public partial class frmSignup : Form
    {
        public static int userId, RoleId;
        public static string userFName, userLName, userName;
        int dbcode = 0;
        public frmSignup()
        {
            InitializeComponent(); 
            LocalizationManager.LocalizeForm(this);
        }
        public static MainForm frmMain;

        private string GenerateNextDbId()
        {
            string newCode = "db";
            string query = @"SELECT IFNULL(MAX(id),0) as lastCode FROM yamycompany.tbl_company";
            using (var reader = DBClass.ExecuteReader(query))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    dbcode = code;
                    newCode = newCode + code;
                }
            }

            return newCode;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtcompany.Text == "")
            {
                MessageBox.Show("Can't Create New Company Without Name !");
                return;
            }
            if (txtemail.Text == "")
            {
                MessageBox.Show("Can't Create New Company Without Email !");
                return;
            }
            if (txtphone1.Text == "")
            {
                MessageBox.Show("Can't Create New Company Without Phone");
                return;
            }
            if (txtdescription.Text == "")
            {
                MessageBox.Show("Can't Create New Company Without Address");
                return;
            }
            if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("Can't Create New Company Without User Name");
                return;
            }
            if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please Insert Password");
                return;
            }
            if (guna2TextBox4.Text != guna2TextBox6.Text)
            {
                MessageBox.Show(" Passwords Not Match");
                return;
            }
            string dbName = GenerateNextDbId();
            try
            {
                createDataBase(dbName);
                MessageBox.Show("The new company was successfully created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtcompany.ResetText();
            txtemail.ResetText();
            txtphone1.ResetText();
            txtdescription.ResetText();
            guna2TextBox3.ResetText();
            guna2TextBox4.ResetText();
            guna2TextBox6.ResetText();
        }

        private void createDataBase(string dbName)
        {
            try
            {
                // Step 2: Create the database
                string createDbQuery = $"CREATE DATABASE IF NOT EXISTS `{dbName}`;";
                DBClass.ExecuteNonQuery(createDbQuery);

                // Step 4: Execute all your table creation queries
                string query = @" USE " + dbName + @";

                        CREATE TABLE IF NOT EXISTS `tbl_advance_payment_voucher` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `pv_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,4) DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `debit_cost_center_id` int DEFAULT NULL,
                          `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `credit_cost_center_id` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          `GlobalId` varchar(36) NOT NULL DEFAULT '0',
                          `DeviceId` varchar(50) DEFAULT '',
                          `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
                          `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_advance_payment_voucher_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `payment_id` int NOT NULL DEFAULT '0',
                          `name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `bank_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_no` int DEFAULT NULL,
                          `check_date` date DEFAULT NULL,
                          `bank_account_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `book_no` int DEFAULT NULL,
                          `trans_date` date DEFAULT NULL,
                          `trans_name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `trans_ref` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,6) DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,

    -- Sync columns (IMPORTANT)
    `GlobalId` VARCHAR(36) NOT NULL,
    `DeviceId` VARCHAR(50) DEFAULT NULL,
    `LastModified` DATETIME DEFAULT CURRENT_TIMESTAMP,
    `SyncStatus` TINYINT(1) NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_attendancesheet` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `attendance_salary_id` int NOT NULL DEFAULT '0',
                          `code` int NOT NULL,
                          `WorkDate` date NOT NULL,
                          `TimeIn` time DEFAULT NULL,
                          `TimeOut` time DEFAULT NULL,
                          `DayOfWeek` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Status` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Reference` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Ref_Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_attendance_salary` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `emp_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `absence_days` int DEFAULT NULL,
                          `total_absence` decimal(20,6) DEFAULT NULL,
                          `delay_minutes` decimal(20,6) DEFAULT NULL,
                          `total_delay` decimal(20,6) DEFAULT NULL,
                          `total_loan` decimal(20,6) DEFAULT NULL,
                          `net_salary` decimal(20,6) DEFAULT NULL,
                          `pay` decimal(20,6) DEFAULT NULL,
                          `change` decimal(20,6) DEFAULT NULL,
                          `ss_no` int DEFAULT '0',
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_bank` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `abb_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ent_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `route_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `country_id` int DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_bank_card` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `bank_id` int DEFAULT NULL,
                          `account_name` varchar(70) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `swift` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `iban_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `branch_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `emirates` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `currency` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_manager` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_sign` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_mob` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `company_ac` int DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_bank_register` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `bank_id` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_check_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `check_id` int DEFAULT NULL,
                          `check_no` int DEFAULT NULL,
                          `check_date` date DEFAULT NULL,
                          `check_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `pvc_no` int DEFAULT NULL,
                          `check_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,6) DEFAULT NULL,
                          `pass_date` date DEFAULT NULL,
                          `return_date` date DEFAULT NULL,
                          `hold_date` date DEFAULT NULL,
                          `cancel_date` date DEFAULT NULL,
                          `state` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_cheque` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `bank_card_id` int DEFAULT NULL,
                          `chq_book_no` int DEFAULT NULL,
                          `chq_book_qty` int DEFAULT NULL,
                          `leaves_start_from` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `leaves_end_in` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_city` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `country_id` int DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_city` ( `country_id`, `name`) VALUES
                            (1,'Kabul'),
                            (2,'Tirana'),
                            (3,'Algiers'),
                            (4,'Andorra la Vella'),
                            (5,'Luanda'),
                            (6,'Saint John''s'),
                            (7,'Buenos Aires'),
                            (8,'Yerevan'),
                            (9,'Canberra'),
                            (10,'Vienna'),
                            (11,'Baku'),
                            (12,'Nassau'),
                            (13,'Manama'),
                            (14,'Dhaka'),
                            (15,'Bridgetown'),
                            (16,'Minsk'),
                            (17,'Brussels'),
                            (18,'Belmopan'),
                            (19,'Porto-Novo'),
                            (20,'Thimphu'),
                            (21,'Sucre'),
                            (22,'Sarajevo'),
                            (23,'Gaborone'),
                            (24,'Brasilia'),
                            (25,'Bandar Seri Begawan'),
                            (26,'Sofia'),
                            (27,'Ouagadougou'),
                            (28,'Gitega'),
                            (29,'Praia'),
                            (30,'Phnom Penh'),
                            (31,'Yaounde'),
                            (32,'Ottawa'),
                            (33,'Bangui'),
                            (34,'N''Djamena'),
                            (35,'Santiago'),
                            (36,'Beijing'),
                            (37,'Bogota'),
                            (38,'Moroni'),
                            (39,'Brazzaville'),
                            (40,'San Jose'),
                            (41,'Zagreb'),
                            (42,'Havana'),
                            (43,'Nicosia'),
                            (44,'Prague'),
                            (45,'Copenhagen'),
                            (46,'Djibouti'),
                            (47,'Roseau'),
                            (48,'Santo Domingo'),
                            (49,'Quito'),
                            (50,'Cairo'),
                            (51,'San Salvador'),
                            (52,'Malabo'),
                            (53,'Asmara'),
                            (54,'Tallinn'),
                            (55,'Mbabane'),
                            (56,'Addis Ababa'),
                            (57,'Suva'),
                            (58,'Helsinki'),
                            (59,'Paris'),
                            (60,'Libreville'),
                            (61,'Banjul'),
                            (62,'Tbilisi'),
                            (63,'Berlin'),
                            (64,'Accra'),
                            (65,'Athens'),
                            (66,'St George''s'),
                            (67,'Guatemala City'),
                            (68,'Conakry'),
                            (69,'Bissau'),
                            (70,'Georgetown'),
                            (71,'Port-au-Prince'),
                            (72,'Tegucigalpa'),
                            (73,'Budapest'),
                            (74,'Reykjavik'),
                            (75,'New Delhi'),
                            (76,'Jakarta'),
                            (77,'Tehran'),
                            (78,'Baghdad'),
                            (79,'Dublin'),
                            (80,'Jerusalem'),
                            (81,'Rome'),
                            (82,'Kingston'),
                            (83,'Tokyo'),
                            (84,'Amman'),
                            (85,'Astana'),
                            (86,'Nairobi'),
                            (87,'Tarawa'),
                            (88,'Kuwait City'),
                            (89,'Bishkek'),
                            (90,'Vientiane'),
                            (91,'Riga'),
                            (92,'Beirut'),
                            (93,'Maseru'),
                            (94,'Monrovia'),
                            (95,'Tripoli'),
                            (96,'Vaduz'),
                            (97,'Vilnius'),
                            (98,'Luxembourg'),
                            (99,'Antananarivo'),
                            (100,'Lilongwe'),
                            (101,'Kuala Lumpur'),
                            (102,'Male'),
                            (103,'Bamako'),
                            (104,'Valletta'),
                            (105,'Majuro'),
                            (106,'Nouakchott'),
                            (107,'Port Louis'),
                            (108,'Mexico City'),
                            (109,'Palikir'),
                            (110,'Chișinău'),
                            (111,'Monaco'),
                            (112,'Ulaanbaatar'),
                            (113,'Podgorica'),
                            (114,'Rabat'),
                            (115,'Maputo'),
                            (116,'Nay Pyi Taw'),
                            (117,'Windhoek'),
                            (118,'Nauru'),
                            (119,'Kathmandu'),
                            (120,'Amsterdam'),
                            (121,'Wellington'),
                            (122,'Managua'),
                            (123,'Niamey'),
                            (124,'Abuja'),
                            (125,'Pyongyang'),
                            (126,'Skopje'),
                            (127,'Oslo'),
                            (128,'Muscat'),
                            (129,'Islamabad'),
                            (130,'Ngerulmud'),
                            (131,'Jerusalem'),
                            (132,'Panama City'),
                            (133,'Port Moresby'),
                            (134,'Asuncion'),
                            (135,'Lima'),
                            (136,'Manila'),
                            (137,'Warsaw'),
                            (138,'Lisbon'),
                            (139,'Doha'),
                            (140,'Bucharest'),
                            (141,'Moscow'),
                            (142,'Kigali'),
                            (143,'Basseterre'),
                            (144,'Castries'),
                            (145,'Kingstown'),
                            (146,'Apia'),
                            (147,'San Marino'),
                            (148,'Sao Tome'),
                            (149,'Riyadh'),
                            (150,'Dakar'),
                            (151,'Belgrade'),
                            (152,'Victoria'),
                            (153,'Freetown'),
                            (154,'Singapore'),
                            (155,'Bratislava'),
                            (156,'Ljubljana'),
                            (157,'Honiara'),
                            (158,'Mogadishu'),
                            (159,'Pretoria'),
                            (160,'Seoul'),
                            (161,'Juba'),
                            (162,'Madrid'),
                            (163,'Sri Jayawardenapura Kotte'),
                            (164,'Khartoum'),
                            (165,'Paramaribo'),
                            (166,'Stockholm'),
                            (167,'Bern'),
                            (168,'Damascus'),
                            (169,'Dushanbe'),
                            (170,'Dodoma'),
                            (171,'Bangkok'),
                            (172,'Taipei'),
                            (173,'Lome'),
                            (174,'Nuku''alofa'),
                            (175,'Port of Spain'),
                            (176,'Tunis'),
                            (177,'Ankara'),
                            (178,'Ashgabat'),
                            (179,'Funafuti'),
                            (180,'Kampala'),
                            (181,'Kyiv or Kiev'),
	                        (182,'Abu Dhabi'),
	                        (182,'Dubai'),
	                        (182,'Sharjah'),
	                        (182,'Ajman'),
	                        (182,'Umm Al-Quwain'),
	                        (182,'Ras Al Khaimah'),
	                        (182,'Fujairah'),
                            (183,'London'),
                            (184,'Washington D.C.'),
                            (185,'Montevideo'),
                            (186,'Tashkent'),
                            (187,'Port Vila'),
                            (188,'Vatican City'),
                            (189,'Caracas'),
                            (190,'Hanoi'),
                            (191,'Sana''a'),
                            (192,'Lusaka'),
                            (193,'Harare');

                        CREATE TABLE IF NOT EXISTS `tbl_coa_config` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `account_id` int DEFAULT NULL,
                          `category` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL UNIQUE,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                       CREATE TABLE IF NOT EXISTS `tbl_coa_level_1` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `code` int DEFAULT NULL,
                          `category_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_coa_level_1` (`id`, `name`, `code`, `category_code`) VALUES
	                        (1, 'Assets', 1,'ASSET'),
	                        (2, 'Liabilities', 2,'LIABILITY'),
	                        (3, 'Equity', 3,'EQUITY'),
	                        (4, 'Income', 4,'INCOME'),
	                        (5, 'Cost', 5,'COST'),
	                        (6, 'General & Direct Expenses', 6,'EXPENSE');

                        CREATE TABLE IF NOT EXISTS `tbl_coa_level_2` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `code` int NOT NULL,
                          `main_id` int NOT NULL,
                          `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_coa_level_2` (`id`, `name`, `code`, `main_id`,`SyncStatus`) VALUES
	                        (1, 'Current Assets', 11, 1, 1),
	                        (2, 'Long-Term Assets', 12, 1, 1),
	                        (3, 'Current Liabilities', 21, 2, 1),
	                        (4, 'Long-Term Liabilities', 22, 2,1),
	                        (5, 'Equity & Capital', 31, 3,1),
	                        (6, 'Direct Income', 41, 4,1),
	                        (7, 'Indirect Income', 42, 4,1),
	                        (8, 'Cost', 51, 5,1),
	                        (9, 'Direct Expenses', 61, 6,1),
	                        (10, 'Operating Expenses', 62, 6,1),
	                        (11, 'Inventory Adjustments', 63, 6,1),
	                        (12, 'Other Income', 465, 4,1);

                        CREATE TABLE IF NOT EXISTS `tbl_coa_level_3` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `code` int NOT NULL,
                          `main_id` int NOT NULL,
                          `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_coa_level_3` (`id`, `name`, `code`, `main_id`,`SyncStatus`) VALUES
	                        (1, 'Banks', 1101, 1,1),
	                        (2, 'Petty Cash', 1102, 1,1),
	                        (3, 'Accounts Receivable', 1103, 1,1),
	                        (4, 'Inventory', 1104, 1,1),
	                        (5, 'Prepayment', 1105, 1,1),
	                        (6, 'Other\'s Receivable', 1106, 1,1),
	                        (7, 'Related parties Receivable', 1107, 1,1),
	                        (8, 'Fixed Assets', 1201, 2,1),
	                        (9, 'Suppliers', 2101, 3,1),
	                        (10, 'Accrued Employee benefits Expense', 2102, 3,1),
	                        (11, 'Other Current Liabilities', 2103, 3,1),
	                        (12, 'Long-term employee benefits', 2201, 4,1),
	                        (13, 'Capital', 3101, 5,1),
	                        (14, 'Members Draw', 3102, 5,1),
	                        (15, 'Opening Balance Equity', 3201, 5,1),
	                        (16, 'Reserve', 3301, 5,1),
	                        (17, 'Retained earnings', 3401, 5,1),
	                        (18, 'Sales', 4101, 6,1),
	                        (19, 'Sales Return', 4102, 6,1),
	                        (20, 'Maintenance Income', 4201, 7,1),
	                        (21, 'Cost of Goods Sold', 5101, 8,1),
	                        (22, 'Freight Shipping Cost', 5102, 8,1),
	                        (23, 'Customs & Clearance', 5103, 8,1),
	                        (24, 'Other Cost', 5104, 8,1),
	                        (25, 'General Expenses', 6101, 9,1),
                            (26, 'Payroll Liabilities', 2104, 3,1),
	                        (27, 'Employee Receivable', 1108, 1,1),
	                        (28, 'Short Term Investment', 1109, 1,1),
	                        (29, 'Other Payable', 2105, 3,1),
	                        (30, 'Cash & Cash Equivalents', 1110, 1,1),
	                        (31, 'Losses', 6201, 16,1),
	                        (32, 'Stock Write-offs', 6387, 17,1),
	                        (33, 'Stock Adjustments', 46501, 18,1),
	                        (34, 'Accounts Payable', 1111, 1,1),
	                        (35, 'Other Income', 46502, 12,1);

                        CREATE TABLE IF NOT EXISTS `tbl_coa_level_4` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `code` int NOT NULL,
                          `main_id` int NOT NULL,
                          `debit` decimal(20,3) DEFAULT '0.000',
                          `credit` decimal(20,3) DEFAULT '0.000',
                          `date` datetime DEFAULT NULL,
                          `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_coa_level_4` (`id`, `name`, `code`, `main_id`, `debit`, `credit`, `date`,`SyncStatus`) VALUES
	                        (1, 'Bank Account', 1101001, 1, 0.000, 0.000, NULL,1),
	                        (2, 'Petty Cash', 1102001, 2, 0.000, 0.000, NULL,1),
	                        (3, 'Accounts Receivable', 1103001, 3, 0.000, 0.000, NULL,1),
	                        (4, 'Raw Material Inventory', 1104001, 4, 0.000, 0.000, NULL,1),
	                        (5, 'Finish Goods Inventory', 1104002, 4, 0.000, 0.000, NULL,1),
	                        (6, 'Prepayment Government', 1105001, 5, 0.000, 0.000, NULL,1),
	                        (7, 'Prepayment Rent', 1105002, 5, 0.000, 0.000, NULL,1),
	                        (8, 'Prepayment Other\'s', 1105003, 5, 0.000, 0.000, NULL,1),
	                        (9, 'Deposits', 1106001, 6, 0.000, 0.000, NULL,1),
	                        (10, 'Taxes Paid (Input)', 1106002, 6, 0.000, 0.000, NULL,1),
	                        (11, 'Advance payments to employees', 1106003, 6, 0.000, 0.000, NULL,1),
	                        (12, 'Fixed Assets Net', 1201001, 8, 0.000, 0.000, NULL,1),
	                        (13, 'Suppliers (Creditors)  Net', 2101001, 9, 0.000, 0.000, NULL,1),
	                        (14, 'Accrued Salaries', 2102001, 10, 0.000, 0.000, NULL,1),
	                        (15, 'Accrued Sales commission', 2102002, 10, 0.000, 0.000, NULL,1),
	                        (16, 'Accrued Leave Salary', 2102003, 10, 0.000, 0.000, NULL,1),
	                        (17, 'Sales Tax Payable', 2103001, 11, 0.000, 0.000, NULL,1),
	                        (18, 'PDC CHQ', 2103002, 11, 0.000, 0.000, NULL,1),
	                        (19, 'Advance from Customers', 2103004, 11, 0.000, 0.000, NULL,1),
	                        (20, 'Gratuity Provision', 2201001, 12, 0.000, 0.000, NULL,1),
	                        (21, 'Capital - Opening Balance', 3101001, 13, 0.000, 0.000, NULL,1),
	                        (22, 'Opening Balance Equity', 3201001, 15, 0.000, 0.000, NULL,1),
	                        (23, 'Sales - Local', 4101001, 18, 0.000, 0.000, NULL,1),
	                        (24, 'Sales - GCC', 4101002, 18, 0.000, 0.000, NULL,1),
	                        (25, 'Materials Purchased', 5101001, 21, 0.000, 0.000, NULL,1),
	                        (26, 'Employee Salary Advance', 1108001, 27, 0.000, 0.000, NULL,1),
	                        (27, 'Employee Loans', 1108002, 27, 0.000, 0.000, NULL,1),
	                        (28, 'Other Employee Receivables', 1101002, 27, 0.000, 0.000, NULL,1),
	                        (29, 'Accrued Salary', 2102004, 10, 0.000, 0.000, NULL,1),
	                        (30, 'Employee Payables', 2105001, 29, 0.000, 0.000, NULL,1),
	                        (31, 'Stock Settlement Gain', 46501001, 35, 0.000, 0.000, NULL,1),
	                        (32, 'Accumulated Dep Fur', 1201002, 25, 0.000, 0.000, NULL,1),
	                        (33, 'PDC Receivable', 1103002, 3, 0.000, 0.000, NULL,1),
	                        (34, 'PDC Receivable Return', 1103003, 3, 0.000, 0.000, NULL,1),
	                        (35, 'PDC Receivable Hold', 1103004, 3, 0.000, 0.000, NULL,1),
	                        (36, 'PDC Receivable Cancel', 1103005, 3, 0.000, 0.000, NULL,1),
	                        (37, 'PDC Payable', 1111001, 34, 0.000, 0.000, NULL,1),
	                        (38, 'PDC Payable Return', 1111002, 34, 0.000, 0.000, NULL,1),
	                        (39, 'PDC Payable Hold', 1111003, 34, 0.000, 0.000, NULL,1),
	                        (40, 'PDC Payable Cancel', 1111003, 34, 0.000, 0.000, NULL,1),
	                        (41, 'Sales Discount', 6101004, 25, 0.000, 0.000, NULL,1),
	                        (42, 'Cash On Hand', 1103006, 3, 0.000, 0.000, NULL,1),
	                        (43, 'Sales Return', 4101003, 19, 0.000, 0.000, NULL,1),
	                        (44, 'Customer Advances', 2105002, 29, 0.000, 0.000, NULL,1),
	                        (45, 'Retention Receivable', 1103007, 3, 0.000, 0.000, NULL,1),
	                        (46, 'Retention Payable', 2105003, 29, 0.000, 0.000, NULL,1);

                        INSERT INTO `tbl_coa_config` (`id`, `account_id`, `category`) VALUES
	                        (1, 23, 'Sales'),
	                        (2, 25, 'COGS'),
	                        (3, 42, 'Default Account For Cash'),
	                        (4, 5, 'Inventory'),
                            (5, 4, 'Item Damage'),
	                        (6, 42, 'Invoice Payment Cash Method'),
                            (7, 13, 'Invoice Payment Credit Method'),
	                        (8, 17, 'Vat Output'),
	                        (9, 13, 'Vendor'),
	                        (10, 10, 'Vat Input'),
	                        (11, 42, 'Purchase Payment Cash Method'),
	                        (12, 13, 'Purchase Payment Credit Method'),
	                        (13, 3, 'Opening Balance'),
	                        (14, 22, 'Opening Balance Equity'),
	                        (15, 14, 'Accrued Salaries'),
	                        (16, 16, 'Acroal Leave Salary'),
	                        (17, 28, 'Employee Receivable'),
	                        (18, 8, 'Prepaid Expense Debit Account'),
	                        (19, 12, 'Fixed Asset Credit Account'),
	                        (20, 37, 'PDC Payable'),
	                        (21, 38, 'PDC Payable Return'),
	                        (22, 39, 'PDC Payable Hold'),
	                        (23, 40, 'PDC Payable Cancel'),
	                        (24, 33, 'PDC Receivable'),
	                        (25, 34, 'PDC Receivable Return'),
	                        (26, 35, 'PDC Receivable Hold'),
	                        (27, 36, 'PDC Receivable Cancel'),
	                        (28, 3, 'Customer'),
	                        (29, 2, 'Petty Cash Account'),
	                        (30, 14, 'End of Service Debit'),
	                        (31, 30, 'End of Service Credit'),
	                        (32, 30, 'Leave Salary Debit'),
	                        (33, 30, 'Leave Salary Credit'),
	                        (34, 13, 'Purchase'),
	                        (35, 13, 'PurchaseReturn'),
	                        (36, 43, 'SalesReturn'),
	                        (37, 1, 'Default Account For Bank'),
                            (38, 1, 'Salaries'),
                            (39, 31, 'Stock Settlement'),
                            (40, 44, 'Customer Advances'),
                            (41, 45, 'Retention'),
                            (42, 1, 'Deduction'),
                            (43, 46, 'Retention Purchase');

                        CREATE TABLE IF NOT EXISTS `tbl_company` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `descriptions` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `phone1` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `phone2` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `gmail` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `mobile_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `website` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `address` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `trn_no` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `country_id` int NOT NULL DEFAULT(0),
                          `logoComp` longblob,
                          `stampComp` longblob,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_corporate_tax_configration` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `corporateTax_no` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `trn_issue_date` date DEFAULT NULL,
                          `corporatetax_start_date` date DEFAULT NULL,
                          `corporatetax_end_date` date DEFAULT NULL,
                          `corporatetax_due_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_cost_center` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` int DEFAULT NULL,
                          `name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_country` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_country` (`name`) VALUES
	                        ('Afghanistan'),
                            ('Albania'),
                            ('Algeria'),
                            ('Andorra'),
                            ('Angola'),
                            ('Antigua and Barbuda'),
                            ('Argentina'),
                            ('Armenia'),
                            ('Australia'),
                            ('Austria'),
                            ('Azerbaijan'),
                            ('Bahamas'),
                            ('Bahrain'),
                            ('Bangladesh'),
                            ('Barbados'),
                            ('Belarus'),
                            ('Belgium'),
                            ('Belize'),
                            ('Benin'),
                            ('Bhutan'),
                            ('Bolivia'),
                            ('Bosnia and Herzegovina'),
                            ('Botswana'),
                            ('Brazil'),
                            ('Brunei'),
                            ('Bulgaria'),
                            ('Burkina Faso'),
                            ('Burundi'),
                            ('Cabo Verde'),
                            ('Cambodia'),
                            ('Cameroon'),
                            ('Canada'),
                            ('Central African Republic'),
                            ('Chad'),
                            ('Chile'),
                            ('China'),
                            ('Colombia'),
                            ('Comoros'),
                            ('Congo'),
                            ('Costa Rica'),
                            ('Croatia'),
                            ('Cuba'),
                            ('Cyprus'),
                            ('Czechia'),
                            ('Denmark'),
                            ('Djibouti'),
                            ('Dominica'),
                            ('Dominican Republic'),
                            ('Ecuador'),
                            ('Egypt'),
                            ('El Salvador'),
                            ('Equatorial Guinea'),
                            ('Eritrea'),
                            ('Estonia'),
                            ('Eswatini'),
                            ('Ethiopia'),
                            ('Fiji'),
                            ('Finland'),
                            ('France'),
                            ('Gabon'),
                            ('Gambia'),
                            ('Georgia'),
                            ('Germany'),
                            ('Ghana'),
                            ('Greece'),
                            ('Grenada'),
                            ('Guatemala'),
                            ('Guinea'),
                            ('Guinea-Bissau'),
                            ('Guyana'),
                            ('Haiti'),
                            ('Honduras'),
                            ('Hungary'),
                            ('Iceland'),
                            ('India'),
                            ('Indonesia'),
                            ('Iran'),
                            ('Iraq'),
                            ('Ireland'),
                            ('Israel'),
                            ('Italy'),
                            ('Jamaica'),
                            ('Japan'),
                            ('Jordan'),
                            ('Kazakhstan'),
                            ('Kenya'),
                            ('Kiribati'),
                            ('Kuwait'),
                            ('Kyrgyzstan'),
                            ('Laos'),
                            ('Latvia'),
                            ('Lebanon'),
                            ('Lesotho'),
                            ('Liberia'),
                            ('Libya'),
                            ('Liechtenstein'),
                            ('Lithuania'),
                            ('Luxembourg'),
                            ('Madagascar'),
                            ('Malawi'),
                            ('Malaysia'),
                            ('Maldives'),
                            ('Mali'),
                            ('Malta'),
                            ('Marshall Islands'),
                            ('Mauritania'),
                            ('Mauritius'),
                            ('Mexico'),
                            ('Micronesia'),
                            ('Moldova'),
                            ('Monaco'),
                            ('Mongolia'),
                            ('Montenegro'),
                            ('Morocco'),
                            ('Mozambique'),
                            ('Myanmar'),
                            ('Namibia'),
                            ('Nauru'),
                            ('Nepal'),
                            ('Netherlands'),
                            ('New Zealand'),
                            ('Nicaragua'),
                            ('Niger'),
                            ('Nigeria'),
                            ('North Korea'),
                            ('North Macedonia'),
                            ('Norway'),
                            ('Oman'),
                            ('Pakistan'),
                            ('Palau'),
                            ('Palestine'),
                            ('Panama'),
                            ('Papua New Guinea'),
                            ('Paraguay'),
                            ('Peru'),
                            ('Philippines'),
                            ('Poland'),
                            ('Portugal'),
                            ('Qatar'),
                            ('Romania'),
                            ('Russia'),
                            ('Rwanda'),
                            ('Saint Kitts and Nevis'),
                            ('Saint Lucia'),
                            ('Saint Vincent and the Grenadines'),
                            ('Samoa'),
                            ('San Marino'),
                            ('Sao Tome and Principe'),
                            ('Saudi Arabia'),
                            ('Senegal'),
                            ('Serbia'),
                            ('Seychelles'),
                            ('Sierra Leone'),
                            ('Singapore'),
                            ('Slovakia'),
                            ('Slovenia'),
                            ('Solomon Islands'),
                            ('Somalia'),
                            ('South Africa'),
                            ('South Korea'),
                            ('South Sudan'),
                            ('Spain'),
                            ('Sri Lanka'),
                            ('Sudan'),
                            ('Suriname'),
                            ('Sweden'),
                            ('Switzerland'),
                            ('Syria'),
                            ('Tajikistan'),
                            ('Tanzania'),
                            ('Thailand'),
                            ('Taiwan'),
                            ('Togo'),
                            ('Tonga'),
                            ('Trinidad and Tobago'),
                            ('Tunisia'),
                            ('Turkey'),
                            ('Turkmenistan'),
                            ('Tuvalu'),
                            ('Uganda'),
                            ('Ukraine'),
                            ('United Arab Emirates'),
                            ('United Kingdom'),
                            ('United States'),
                            ('Uruguay'),
                            ('Uzbekistan'),
                            ('Vanuatu'),
                            ('Vatican City'),
                            ('Venezuela'),
                            ('Vietnam'),
                            ('Yemen'),
                            ('Zambia'),
                            ('Zimbabwe');

                        CREATE TABLE IF NOT EXISTS `tbl_credit_note` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `credit_account` int DEFAULT '0',
                          `debit_account` int NOT NULL DEFAULT '0',
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `amount` decimal(20,2) DEFAULT '0.00',
                          `vat` decimal(20,2) DEFAULT '0.00',
                          `total` decimal(20,2) DEFAULT '0.00',
                          `description` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `created_date` date DEFAULT NULL,
                          `created_by` int NOT NULL DEFAULT '0',
                          `modified_by` int NOT NULL DEFAULT '0',
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_credit_note_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `ref_id` int NOT NULL DEFAULT '0',
                          `invoice_id` int NOT NULL DEFAULT '0',
                          `inv_no` varchar(50) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `invoice_date` date DEFAULT NULL,
                          `invoice_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `total` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `vat` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `amount` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `balance` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `remaining` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_customer` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` int NOT NULL DEFAULT '0',
                          `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Cat_id` int DEFAULT NULL,
                          `Balance` decimal(20,4) DEFAULT NULL,
                          `date` date DEFAULT NULL,
                          `main_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `work_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `mobile` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ccemail` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `website` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `country` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `region` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `building_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `trn` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `facilty_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `active` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          `project_site` VARCHAR(150) DEFAULT '' COLLATE 'utf8mb4_general_ci',
                          `GlobalId` varchar(36) NOT NULL DEFAULT '0',
                          `DeviceId` varchar(50) DEFAULT NULL,
                          `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
                          `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_customer_category` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_damage` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `reference_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `reported_by` int NOT NULL DEFAULT '0',
                          `damage_reason` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `account_id` int NOT NULL DEFAULT '0',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_damage_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `damage_id` int NOT NULL,
                          `item_id` int NOT NULL,
                          `qty` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `cost_price` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_debit_note` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `credit_account` int DEFAULT '0',
                          `debit_account` int NOT NULL DEFAULT '0',
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `amount` decimal(20,2) DEFAULT '0.00',
                          `vat` decimal(20,2) DEFAULT '0.00',
                          `total` decimal(20,2) DEFAULT '0.00',
                          `description` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `created_date` date DEFAULT NULL,
                          `created_by` int NOT NULL DEFAULT '0',
                          `modified_by` int NOT NULL DEFAULT '0',
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_debit_note_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `ref_id` int NOT NULL DEFAULT '0',
                          `invoice_id` int NOT NULL DEFAULT '0',
                          `inv_no` varchar(50) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `invoice_date` date DEFAULT NULL,
                          `invoice_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `amount` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `vat` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `total` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `balance` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `remaining` decimal(20,2) NOT NULL DEFAULT '0.00',
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_departments` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Department` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_employee` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` int NOT NULL DEFAULT '0',
                          `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `city_id` int DEFAULT 0,
                          `address` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `birth_day` date DEFAULT NULL,
                          `Social_Status` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Social_Insurance_Number` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmergencyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmergencyAddress` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmergencyPhone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Relation` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `BasicSalary` decimal(10,2) DEFAULT 0,
                          `HousingAllowance` decimal(10,2) DEFAULT 0,
                          `TransportationAllowance` decimal(10,2) DEFAULT 0,
                          `Other` decimal(10,2) DEFAULT 0,
                          `bank_id` int DEFAULT 0,
                          `Iban_Number` varchar(70) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Bank_account_Number` varchar(70) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmiratesIDFileNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmiratesIDIssuingAuthority` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmiratesIDIssueDate` date DEFAULT NULL,
                          `EmiratesIDExpiryDate` date DEFAULT NULL,
                          `PassportNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `CountryOfIssue` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `PassportIssueDate` date DEFAULT NULL,
                          `PassportExpiryDate` date DEFAULT NULL,
                          `WorkContractNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `WorkContractType` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Position_id` int DEFAULT 0,
                          `Department_id` int DEFAULT 0,
                          `WorkDays` int DEFAULT 0,
                          `workinghours` int DEFAULT 0,
                          `ContractIssueDate` date DEFAULT NULL,
                          `ContractExpiryDate` date DEFAULT NULL,
                          `ResidencyFileNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ResidencyIssuingAuthority` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ResidencyIssueDate` date DEFAULT NULL,
                          `ResidencyExpiryDate` date DEFAULT NULL,
                          `account_id` int DEFAULT 0,
                          `Accrued_Salaries_id` int DEFAULT 0,
                          `Employee_Recivable_id` int DEFAULT 0,
                          `Acroal_Leave_Salary_id` int DEFAULT 0,
                          `Gratuit_id` int DEFAULT 0,
                          `Petty_Cash_id` int DEFAULT 0,
                          `active` int NOT NULL DEFAULT '0',
                          `state` int NOT NULL DEFAULT '0',
                          `sRole` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_end_of_service` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `code` int DEFAULT NULL,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Reference` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `description` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `debit` decimal(20,6) DEFAULT 0,
                          `leave_days` decimal(20,6) DEFAULT 0,
                          `credit` decimal(20,6) DEFAULT 0,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_final_settlement` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Date` date DEFAULT NULL,
                          `emp_id` int DEFAULT NULL,
                          `DateCommencement` date DEFAULT NULL,
                          `DateLastWork` date DEFAULT NULL,
                          `TotalSalary` decimal(20,2) DEFAULT NULL,
                          `OtherAdditions` decimal(20,2) DEFAULT NULL,
                          `TotalAdditions` decimal(20,2) DEFAULT NULL,
                          `Payments` decimal(20,2) DEFAULT NULL,
                          `OtherDeductions` decimal(20,2) DEFAULT NULL,
                          `TotalDeductions` decimal(20,2) DEFAULT NULL,
                          `NetAccruals` decimal(20,2) DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_fixed_assets` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `brand` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `category_id` int DEFAULT NULL,
                          `model` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `supplier` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `status` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `invoice_number` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `purchase_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
                          `depreciation_life` int DEFAULT NULL,
                          `purchase_price` decimal(20,6) DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `expence_account_id` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT '0',
                          `manufacture` int DEFAULT '0',
                          `manufactureStatus` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_fixed_assets_category` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `category_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
	                      `assets_account_id` INT(10) NOT NULL DEFAULT '0',
	                      `depreciation_account_id` INT(10) NOT NULL DEFAULT '0',
	                      `expence_account_id` INT(10) NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                       CREATE TABLE IF NOT EXISTS `tbl_general_settings` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `value` int NOT NULL DEFAULT '0',
                          `description` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `status` int DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_general_settings` (`id`, `name`, `value`, `description`, `status`) VALUES
	                        (1, 'ALL ITEMS IN SALES', 0, '', 0),
	                        (2, 'ALL ITEMS IN PURCHASE', 0, '', 0),
	                        (3, 'ALLOW ITEM WITHOUT QTY', 0, '', 0),
	                        (4, 'DEFAULT TAX PERCENTAGE', 1, '', 1),
                            (5, 'PRINT KITCHEN KOT', 0, '' ,1),
                            (6, 'PRINT BILL', 0, '' ,1),
                            (7, 'PROJECT OPTION', 0, '' ,0),
                            (8, 'ENABLE PETTYCASH APPROVAL', 0, '', 0),
                            (9, 'ENABLE BARCODE', 0, '', 0),
                            (10, 'ENABLE ITEM SERIAL NO', 0, '', 0),
                            (11, 'ENABLE ITEM EXPIREDATE', 0, '', 0),
                            (12, 'FINISHED GOODS SAVE WITHOUT QTY', 0, '', 0),
                            (13, 'USE PREPAYMENTS (DEPOSITS) FOR SALES ORDERS', 0, '', 0);

                        CREATE TABLE `tbl_items` (
	                    `id` INT(10) NOT NULL AUTO_INCREMENT,
	                    `code` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                    `type` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                    `warehouse_id` INT(10) NOT NULL DEFAULT '0',
	                    `name` VARCHAR(500) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                    `unit_id` INT(10) NOT NULL DEFAULT '0',
	                    `barcode` VARCHAR(70) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                    `cost_price` DECIMAL(20,4) NOT NULL DEFAULT '0.000',
	                    `cogs_account_id` INT(10) NOT NULL DEFAULT '0',
	                    `vendor_id` INT(10) NOT NULL DEFAULT '0',
	                    `sales_price` DECIMAL(20,4) NOT NULL DEFAULT '0.000',
	                    `tax_code_id` INT(10) NOT NULL DEFAULT '0',
	                    `income_account_id` INT(10) NOT NULL DEFAULT '0',
	                    `asset_account_id` INT(10) NOT NULL DEFAULT '0',
	                    `min_amount` DECIMAL(20,4) NOT NULL DEFAULT '0.000',
	                    `max_amount` DECIMAL(20,4) NOT NULL DEFAULT '0.000',
	                    `on_hand` DECIMAL(20,4) NOT NULL DEFAULT '0.000',
	                    `total_value` DECIMAL(20,6) NOT NULL DEFAULT '0.000000',
	                    `date` DATE NOT NULL,
	                    `img` BLOB NULL DEFAULT NULL,
                        `ItemImg` LONGBLOB NULL DEFAULT NULL,
	                    `active` INT(10) NOT NULL DEFAULT '0',
	                    `method` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                    `state` INT(10) NOT NULL DEFAULT '0',
	                    `created_By` INT(10) NOT NULL DEFAULT '0',
	                    `created_date` DATE NOT NULL,
	                    `deleted_by` INT(10) NOT NULL DEFAULT '0',
	                    `category_id` INT(10) NULL DEFAULT NULL,
	                    `posItem` INT(10) NULL DEFAULT NULL,
                        `item_type` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,
	                    PRIMARY KEY (`id`) USING BTREE
                    )
                    COLLATE='utf8mb4_general_ci' ENGINE=InnoDB ;

                        CREATE TABLE IF NOT EXISTS `tbl_items_unit` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `item_id` int NOT NULL DEFAULT '0',
                          `unit_id` int NOT NULL DEFAULT '0',
                          `factor` int NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_items_warehouse` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `warehouse_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,6) DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_assembly` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `assembly_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_category` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '0',
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_stock_settlement` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `date` date DEFAULT NULL,
                          `warehouse_id` int DEFAULT NULL,
                          `total_plus` decimal(20,6) DEFAULT NULL,
                          `total_minus` decimal(20,6) DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_stock_settlement_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `settle_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `on_hand` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `new_on_hand` decimal(20,4) DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `minusamount` decimal(20,4) DEFAULT NULL,
                          `plusamount` decimal(20,4) DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_transaction` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `reference` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `cost_price` decimal(20,8) DEFAULT NULL,
                          `qty_in` decimal(20,4) DEFAULT NULL,
                          `sales_price` decimal(20,4) DEFAULT NULL,
                          `qty_out` decimal(20,4) DEFAULT NULL,
                          `qty_inc` decimal(20,4) DEFAULT NULL,
                          `description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `warehouse_id` INT NOT NULL DEFAULT 0,
                          `project_id` INT NOT NULL DEFAULT 0,
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_warehouse_transaction` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `warehouse_from` int DEFAULT NULL,
                          `warehouse_to` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,6) DEFAULT NULL,
                          `description` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_journal_voucher` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `debit` decimal(20,4) DEFAULT NULL,
                          `credit` decimal(20,4) DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
 `GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`) USING BTREE

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_journal_voucher_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `debit` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `credit` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `inv_id` int NOT NULL DEFAULT '0',
                          `description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `partner` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `account_id` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0, 
  `GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_leave_salary` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `code` int DEFAULT NULL,
                          `name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Reference` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `debit` decimal(20,6) DEFAULT '0.000000',
                          `leave_days` decimal(20,6) DEFAULT NULL,
                          `credit` decimal(20,6) DEFAULT '0.000000',
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_loan` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `LoanDate` date DEFAULT NULL,
                          `EmployeeID` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `EmployeeName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `RequestAmount` decimal(20,6) DEFAULT NULL,
                          `Installments` int DEFAULT NULL,
                          `StartDate` date DEFAULT NULL,
                          `EndDate` date DEFAULT NULL,
                          `loanDates` date DEFAULT NULL,
                          `Months` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Amount` decimal(20,6) DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `pay` decimal(20,6) DEFAULT '0.000000',
                          `change` decimal(20,6) DEFAULT '0.000000',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_payment_voucher` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,4) DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `debit_cost_center_id` int DEFAULT NULL,
                          `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `credit_cost_center_id` int DEFAULT NULL,
                          `bank_id` int DEFAULT NULL,
                          `bank_account_id` int DEFAULT NULL,
                          `book_no` int DEFAULT NULL,
                          `check_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_date` date DEFAULT NULL,
                          `trans_date` date DEFAULT NULL,
                          `trans_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `trans_ref` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_payment_voucher_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `payment_id` int DEFAULT NULL,
                          `hum_id` int DEFAULT NULL,
                          `inv_id` int DEFAULT NULL,
                          `inv_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `total` decimal(20,6) DEFAULT NULL,
                          `payment` decimal(20,6) DEFAULT NULL,
                          `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `voucher_type` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_petty_cash_card` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `mobile` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `whatsapp_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `email` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_petty_cash_category` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_petty_cash_request` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `request_date` date DEFAULT NULL,
                          `request_ref` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Petty_cash_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,6) DEFAULT NULL,
                          `description` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `approved_date` date DEFAULT NULL,
                          `state` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `pay` decimal(20,6) DEFAULT NULL,
                          `change` decimal(20,6) DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_petty_cash_submition` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,6) DEFAULT NULL,
                          `total_before_vat` decimal(20,6) DEFAULT NULL,
                          `total_vat` decimal(20,6) DEFAULT NULL,
                          `net_amount` decimal(20,6) DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_petty_cash_submition_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `petty_id` int NOT NULL DEFAULT '0',
                          `date` date DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `category` int DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `amount` decimal(20,6) DEFAULT NULL,
                          `vat` decimal(20,6) DEFAULT NULL,
                          `total` decimal(20,6) DEFAULT NULL,
                          `note` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `state` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE tbl_petty_cash(
                            id int NOT NULL AUTO_INCREMENT,
                            code VARCHAR(50) NOT NULL,
                            voucher_date DATE NOT NULL,
                            cash_account_id INT NOT NULL,
                            employee_id INT NOT NULL,
                            amount decimal(20,6) DEFAULT 0,
                            vat decimal(20,6) DEFAULT 0,
                            total decimal(20,6) DEFAULT 0,
                            notes TEXT NULL,
                            created_by INT NULL,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            project_id INT NOT NULL DEFAULT '0',
                            status INT NOT NULL DEFAULT '0',
                            PRIMARY KEY (`id`)
                        );

                        CREATE TABLE tbl_petty_cash_details(
                            id int NOT NULL AUTO_INCREMENT,
                            petty_cash_id INT NOT NULL,
                            entry_date DATE NOT NULL,
                            ref_id VARCHAR(100) NULL,
                            hum_id INT NOT NULL,
                            hum_name VARCHAR(300) NOT NULL DEFAULT '',
                            category INT(10) NOT NULL DEFAULT '0',
                            cost_center_id INT NOT NULL,
                            description TEXT NULL,
                            amount DECIMAL(18,2) NOT NULL DEFAULT 0,
                            vatP DECIMAL(18,2) NOT NULL DEFAULT 0,
                            vat int DEFAULT NULL,
                            total DECIMAL(18,2) NOT NULL DEFAULT 0,
                            project_id INT(10) NOT NULL DEFAULT '0',
                            note TEXT NULL,
                            PRIMARY KEY (`id`)
                        );

                        CREATE TABLE IF NOT EXISTS `tbl_position` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `department_id` int DEFAULT NULL,
                          `AnnualLeaveDays` INT DEFAULT 30,
                          `EOSDaysPerYear` INT DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_prepaid_expense` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `category_id` int DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `start_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
                          `amount` decimal(20,4) DEFAULT NULL,
                          `fee` decimal(20,4) DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_prepaid_expense_category` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `vendor_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `retention_percentage` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `retention_amount` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `purchase_type` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
                          `fixed_asset_category_id` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `reference_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `purchase_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_order` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `vendor_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `tranfer_status` int NOT NULL DEFAULT '0',
                          `purchase_id` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`) USING BTREE

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_order_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `purchase_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT '0.000',
                          `price` decimal(20,4) DEFAULT '0.000',
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`) USING BTREE

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_offer` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `vendor_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `tranfer_status` int NOT NULL DEFAULT '0',
                          `purchase_id` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_offer_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `purchase_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT '0.000',
                          `price` decimal(20,4) DEFAULT '0.000',
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_return` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `vendor_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
	                      `purchase_ref_id` INT NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`) USING BTREE

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_purchase_return_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `purchase_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`) USING BTREE

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_receipt_voucher` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(20,6) DEFAULT NULL,
                          `hum_id` int DEFAULT NULL,
                          `credit_account_id` int DEFAULT NULL,
                          `credit_cost_center_id` int DEFAULT NULL,
                          `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `debit_account_id` int DEFAULT NULL,
                          `debit_cost_center_id` int DEFAULT NULL,
                          `bank_account_id` int DEFAULT NULL,
                          `book_no` int DEFAULT NULL,
                          `bank_id` int DEFAULT NULL,
                          `bank_account` int DEFAULT NULL,
                          `bank_code` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_no` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `check_date` date DEFAULT NULL,
                          `trans_date` date DEFAULT NULL,
                          `trans_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `trans_ref` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_receipt_voucher_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `payment_id` int DEFAULT NULL,
                          `inv_id` int DEFAULT NULL,
                          `hum_id` int DEFAULT NULL,
                          `inv_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `total` decimal(20,2) DEFAULT '0.00',
                          `payment` decimal(20,2) DEFAULT '0.00',
                          `description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_rmsdetails` (
                          `DetailID` int NOT NULL AUTO_INCREMENT,
                          `MainID` int DEFAULT NULL,
                          `proID` int DEFAULT NULL,
                          `qty` decimal(65,2) DEFAULT NULL,
                          `Price` decimal(65,2) DEFAULT NULL,
                          `amount` decimal(65,2) DEFAULT NULL,
                          PRIMARY KEY (`DetailID`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_rmsmain` (
                          `MainId` int NOT NULL AUTO_INCREMENT,
                          `aDate` date DEFAULT NULL,
                          `time` varchar(50) DEFAULT NULL,
                          `tableName` varchar(50) DEFAULT NULL,
                          `waiterName` varchar(50) DEFAULT NULL,
                          `status` varchar(50) DEFAULT NULL,
                          `orderType` varchar(50) DEFAULT NULL,
                          `Total` decimal(65,2) DEFAULT NULL,
                          `received` decimal(65,2) DEFAULT NULL,
                          `changetot` decimal(65,2) DEFAULT NULL,
                          `DriverID` int DEFAULT NULL,
                          `CusTName` varchar(50) DEFAULT NULL,
                          `CustPhone` varchar(50) DEFAULT NULL,
                          `TdOrderNo` int DEFAULT NULL,
                          `UserSale` varchar(50) DEFAULT NULL,
                          `PaidSt` varchar(50) DEFAULT NULL,
                          PRIMARY KEY (`MainId`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_rmstables` (
                          `tid` int NOT NULL AUTO_INCREMENT,
                          `tname` varchar(50) NOT NULL,
                          PRIMARY KEY (`tid`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_salary` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `employee_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `date` date DEFAULT NULL,
                          `month` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `year` int DEFAULT NULL,
                          `salary` decimal(20,6) DEFAULT NULL,
                          `pay` decimal(20,6) DEFAULT NULL,
                          `change` decimal(20,6) DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_salary_adjustments` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `adjustment_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `amount` decimal(10,6) DEFAULT NULL,
                          `date` date DEFAULT NULL,
                          `ref_id` int NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `customer_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `form_type` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0',
                          `net` decimal(20,4) NOT NULL DEFAULT '0',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0',
                          `change` decimal(20,4) NOT NULL DEFAULT '0',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `discount` decimal(20,6) NOT NULL DEFAULT '0',
                          `retention_amount` decimal(20,6) NOT NULL DEFAULT '0',
                          `retention_percentage` decimal(20,6) NOT NULL DEFAULT '0',
                          `advance_pay` decimal(20,6) NOT NULL DEFAULT '0',
                          `cost_center_id` decimal(20,6) NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_sales_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sales_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_order` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `customer_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `inv_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `tranfer_status` int NOT NULL DEFAULT '0',
                          `sales_id` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_order_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sales_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT '0.000',
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_proforma` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `customer_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `tranfer_status` int DEFAULT '0',
                          `sales_id` int DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_proforma_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sales_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT '0.000',
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_quotation` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `customer_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `tranfer_status` int DEFAULT '0',
                          `sales_id` int DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_quotation_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sales_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT '0.000',
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_return` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `customer_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
	                      `sales_ref_id` INT(10) NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `account_cash_id` int NOT NULL DEFAULT '0',
                          `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `payment_date` date NOT NULL,
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sales_return_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sales_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_delivery_note` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `customer_id` int NOT NULL DEFAULT '0',
                          `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `po_num` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `bill_to` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `city` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `address` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `sales_man` int NOT NULL DEFAULT '0',
                          `ship_date` date DEFAULT NULL,
                          `ship_via` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ship_to` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `total` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `vat` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `net` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `pay` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `change` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date NOT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int NOT NULL DEFAULT '0',
                          `discount` decimal(20,6) NOT NULL DEFAULT '0.000000',
                          `cost_center_id` decimal(20,6) NOT NULL DEFAULT '0.000000',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_delivery_note_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sales_id` int DEFAULT NULL,
                          `item_id` int DEFAULT NULL,
                          `qty` decimal(20,4) DEFAULT NULL,
                          `cost_price` decimal(20,4) DEFAULT NULL,
                          `price` decimal(20,4) DEFAULT NULL,
                          `vatp` decimal(20,4) DEFAULT '0.000',
                          `vat` int DEFAULT NULL,
                          `total` decimal(20,4) DEFAULT NULL,
                          `discount` decimal(20,4) DEFAULT NULL,
                          `cost_center_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sec_roles` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                       INSERT INTO `tbl_sec_roles` (`id`, `name`) VALUES
                            (1, 'Admin'),
                            (2, 'Manager'),
                            (3, 'Accountant'),
                            (4, 'Sales'),
                            (5, 'Purchaser'),
                            (6, 'Inventory Manager'),
                            (7, 'HR'),
                            (8, 'Cashier'),
                            (9, 'Auditor');

                        CREATE TABLE IF NOT EXISTS `tbl_sec_role_form` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `role_id` int DEFAULT NULL,
                          `form_id` int DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_sec_users` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `user_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `PasswordHash` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `salt` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `emp_id` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `first_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `last_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Role_Id` int NOT NULL,
                          `active` int NOT NULL,
                          `state` int NOT NULL,
                          `password_updated_by` int DEFAULT NULL,
                          `password_last_update` date DEFAULT NULL,
                          PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS tbl_deleted_records (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            table_name VARCHAR(100),
                            record_data TEXT,
                            deleted_by INT,
                            deleted_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );

                        CREATE TABLE IF NOT EXISTS `tbl_setting_attendance` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `day` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `timein` time DEFAULT NULL,
                          `timeout` time DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_setting_deduction_config` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `latearrivaldeduction` decimal(20,2) DEFAULT NULL,
                          `delaytime` time DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_setting_default_account` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `level4_id` int NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_set_main_menu` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `status` int DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_set_main_menu` (`id`, `name`, `status`) VALUES
	                        (1, 'Accountant',1),
	                        (2, 'Banking',1),
	                        (3, 'Inventory',1),
	                        (4, 'HR',1),
	                        (5, 'Construction',0),
	                        (6, 'CRM',0),
	                        (7, 'Manufacture',0),
	                        (8, 'Restaurant',0),
	                        (9, 'Eng Consultants',0),
	                        (10, 'Contracting',0);

                        CREATE TABLE IF NOT EXISTS `tbl_set_menu_forms` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `menu_id` int DEFAULT NULL,
                          `form_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `form_text` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `params` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `seq` int DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_set_menu_forms` (`id`, `menu_id`, `form_name`, `form_text`, `params`, `seq`) VALUES
	                        (1, 1, 'MasterChartOfAccount', 'Chart of Account', 'MainForm', 1),
	                        (2, 9, 'MasterEmployee', 'Employee Center', 'MainForm', 2),
	                        (3, 4, 'MasterCustomer', 'Customer Center', 'MainForm', 1),
	                        (4, 5, 'MasterVendor', 'Vendor Center', 'MainForm', 1),
	                        (5, 4, 'MasterSales', 'Sales Center', 'MainForm', 1),
	                        (6, 8, 'MasterSetting', 'Setting', 'MainForm', 1),
	                        (7, 2, 'MasterBanking', 'Bank Center', 'MainForm', 1),
	                        (8, 5, 'MasterPurchases', 'Purchases Center', 'MainForm', 3),
	                        (9, 1, 'MasterPaymentVoucher', 'Payment Voucher', 'MainForm', 3),
	                        (10, 3, 'MasterInventory', 'Inventory', 'MainForm', 1),
	                        (11, 2, 'MasterBankCard', 'Bank Card Center', 'MainForm', 2),
	                        (13, 1, 'MasterReciptVoucher', 'Receipt Voucher', 'MainForm', 3),
	                        (14, 3, 'MasterInventoryReport', 'Inventory Report', 'MainForm', 3),
	                        (22, 9, 'MasterAttendanceSheet', 'Attendance Sheet Center', 'MainForm', 2),
	                        (23, 9, 'frmSalarySheet', 'Salary Sheet', 'MainForm', 2),
	                        (24, 9, 'frmEndOfService', 'End Of Services', 'MainForm', 2),
	                        (25, 9, 'frmLeaveSalary', 'Leave Salary', 'MainForm', 2),
	                        (26, 9, 'MasterFinalSettlement', 'Final Settlement', 'MainForm', 2),
	                        (27, 9, 'frmViewLoan', 'Loan', 'MainForm', 2),
	                        (28, 1, 'MasterCostCenter', 'Cost Center', 'MainForm', 1),
	                        (29, 1, 'MasterPrepaidExpense', 'Prepaid Expense', 'MainForm', 1),
	                        (30, 1, 'MasterFixedAssets', 'Fixed Assets', 'MainForm', 1),
	                        (31, 2, 'MasterCheque', 'Cheques', 'MainForm', 2),
	                        (32, 1, 'MasterPettyCash', 'Petty Cash', 'MainForm', 1);

                        CREATE TABLE IF NOT EXISTS `tbl_sub_cost_center` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` int DEFAULT NULL,
                          `name` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `main_id` int DEFAULT NULL,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


                        CREATE TABLE IF NOT EXISTS `tbl_tax` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `value` int DEFAULT NULL,
                          `description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `state` int DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_tax` (`id`, `name`, `value`, `description`, `state`) VALUES
	                        (1, 'TAX', 5, 'Standard Rated', 0),
	                        (2, 'TAX', 0, 'Zero Rated', 0),
	                        (3, 'TAX', 15, 'Standard Rated', 0);

                        CREATE TABLE IF NOT EXISTS `tbl_tools` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `tool_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `is_selected` int DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        INSERT INTO `tbl_tools` (`id`, `tool_name`, `is_selected`) VALUES
	                        (1, 'Chart Of Account', 0),
	                        (2, 'Cost Center', 0),
	                        (3, 'Fixed Assets', 0),
	                        (4, 'Payment Voucher', 0),
	                        (5, 'Receipt Voucher', 0),
	                        (6, 'Petty Cash', 0),
	                        (7, 'Prepaid Expense', 0),
	                        (8, 'Bank Card', 0),
	                        (9, 'Bank Register', 0),
	                        (10, 'Cheques', 0),
	                        (11, 'PDC', 0),
	                        (12, 'Customer Center', 0),
	                        (13, 'Sales Center', 0),
	                        (14, 'Vendor Center', 0),
	                        (15, 'Purchases Center', 0),
	                        (16, 'Employee Center', 0),
	                        (17, 'Attendance Sheet Center', 0),
	                        (18, 'Salary Sheet', 0);

                        CREATE TABLE IF NOT EXISTS `tbl_transaction` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `debit` decimal(20,4) DEFAULT NULL,
                          `credit` decimal(20,4) DEFAULT NULL,
                          `transaction_id` INT NOT NULL DEFAULT 0,
                          `hum_id` int DEFAULT '0',
                          `type` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `t_type` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT NULL,
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `voucher_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_unit` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_vat_configration` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `registration_no` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `TRNIssue_date` date DEFAULT NULL,
                          `quarter_one_start_date` date DEFAULT NULL,
                          `quarter_one_end_date` date DEFAULT NULL,
                          `quarter_one_due_date` date DEFAULT NULL,
                          `quarter_two_start_date` date DEFAULT NULL,
                          `quarter_two_end_date` date DEFAULT NULL,
                          `quarter_two_due_date` date DEFAULT NULL,
                          `quarter_three_start_date` date DEFAULT NULL,
                          `quarter_three_end_date` date DEFAULT NULL,
                          `quarter_three_due_date` date DEFAULT NULL,
                          `quarter_four_start_date` date DEFAULT NULL,
                          `quarter_four_end_date` date DEFAULT NULL,
                          `quarter_four_due_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_vendor` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` int NOT NULL DEFAULT '0',
                          `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `Cat_id` int DEFAULT NULL,
                          `Balance` decimal(20,4) DEFAULT NULL,
                          `date` date DEFAULT NULL,
                          `main_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `work_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `mobile` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `ccemail` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `website` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `country` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `region` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `building_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `trn` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `facilty_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `active` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `type` VARCHAR(150) NULL DEFAULT 'Vendor' COLLATE 'utf8mb4_general_ci',
                          `project_id` INT NOT NULL DEFAULT 0,
                          `project_site` VARCHAR(150) DEFAULT '' COLLATE 'utf8mb4_general_ci',
`GlobalId` varchar(36) NOT NULL DEFAULT '0',
  `DeviceId` varchar(50) DEFAULT NULL,
  `LastModified` datetime DEFAULT CURRENT_TIMESTAMP,
  `SyncStatus` tinyint NOT NULL DEFAULT 0,

                          PRIMARY KEY (`id`)

                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_vendor_category` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_warehouse` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `emp_id` int DEFAULT NULL,
                          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `building_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `account_id` int DEFAULT NULL,
                          `state` int DEFAULT NULL,
                          `created_by` int DEFAULT NULL,
                          `created_date` date DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_cost_center_transaction` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `type` varchar(50) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `date` datetime DEFAULT NULL,
                          `ref_id` int DEFAULT '0',
                          `debit` decimal(20,4) DEFAULT '0.000',
                          `credit` decimal(20,4) DEFAULT '0.000',
                          `description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `cost_center_id` int DEFAULT '0',
                          `project_id` INT NOT NULL DEFAULT 0,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE `tbl_item_card_details` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `itemId` INT(10) NOT NULL DEFAULT '0',
	                        `date` DATE NULL DEFAULT NULL,
	                        `wharehouse_id` INT(10) NOT NULL DEFAULT '0',
	                        `inv_no` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                        `trans_no` INT(10) NOT NULL DEFAULT '0',
	                        `trans_type` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                        `description` VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                        `price` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `qty_in` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `qty_out` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `qty_balance` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `debit` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `credit` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `balance` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `fifo_qty` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `fifo_cost` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_general_ci'
                        ENGINE=InnoDB
                        ;

                        CREATE TABLE tbl_bank_transaction (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            bank_account_id INT NOT NULL,
                            account_id INT NOT NULL,
                            statement_date DATE NOT NULL,
                            value_date DATE NOT NULL,
                            narration VARCHAR(500),
                            debit DECIMAL(20,4) DEFAULT 0,
                            credit DECIMAL(20,4) DEFAULT 0,
                            running_balance DECIMAL(20,4),
                            reference_no VARCHAR(100),
                            cheque_no VARCHAR(100),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                            reconciled TINYINT(1) DEFAULT 0,
                            reconciled_date DATE
                        );

                        CREATE TABLE `tbl_credit_card` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `name` VARCHAR(250) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                        `account_type_id` INT(10) NOT NULL DEFAULT '0',
	                        `sub_account_id` INT(10) NOT NULL DEFAULT '0',
	                        `currency` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                        `description` VARCHAR(250) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                        `credit_card_ac_no` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_general_ci'
                        ENGINE=InnoDB
                        ;

                        ";
                DBClass.ExecuteNonQuery(query);
                query = @" USE " + dbName + @";
                        CREATE TABLE `tbl_crmcustomer` (
	                        `ID` INT(10) NOT NULL AUTO_INCREMENT,
	                        `LeadName` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `custcode` INT(10) NULL DEFAULT NULL,
	                        `CustName` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `openlvl` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `Stage` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `Date` DATETIME NULL DEFAULT NULL,
	                        `Amount` DECIMAL(15,2) NULL DEFAULT NULL,
	                        `Discription` VARCHAR(1000) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `Assigendto` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `CreateAt` DATETIME NULL DEFAULT NULL,
	                        PRIMARY KEY (`ID`) USING BTREE
                        ) COLLATE='utf8mb4_general_ci' ENGINE=InnoDB ;

                        CREATE TABLE IF NOT EXISTS `tbl_items_boq` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sr` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `ref_id` int NOT NULL,
                          `type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          `unit_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `qty` decimal(10,2) DEFAULT NULL,
                          `price` decimal(10,2) DEFAULT NULL,
                          `amount` decimal(10,2) DEFAULT NULL,
                          `length` decimal(10,2) DEFAULT NULL,
                          `width` decimal(10,2) DEFAULT NULL,
                          `thickness` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
                          `note` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_items_boq_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(100) NOT NULL,
                          `warehouse_id` int NOT NULL,
                          `type` varchar(50) NOT NULL,
                          `category_id` int DEFAULT NULL,
                          `name` varchar(255) NOT NULL,
                          `unit_id` int NOT NULL,
                          `barcode` varchar(100) DEFAULT NULL,
                          `cost_price` decimal(10,2) DEFAULT NULL,
                          `cogs_account_id` int DEFAULT NULL,
                          `vendor_id` int DEFAULT NULL,
                          `sales_price` decimal(10,2) DEFAULT NULL,
                          `income_account_id` int DEFAULT NULL,
                          `asset_account_id` int DEFAULT NULL,
                          `min_amount` decimal(10,2) DEFAULT NULL,
                          `max_amount` decimal(10,2) DEFAULT NULL,
                          `on_hand` decimal(10,2) DEFAULT NULL,
                          `method` varchar(50) DEFAULT NULL,
                          `total_value` decimal(15,2) DEFAULT NULL,
                          `date` date DEFAULT NULL,
                          `img` varchar(255) DEFAULT NULL,
                          `active` tinyint(1) DEFAULT '1',
                          `state` int DEFAULT '0',
                          `created_by` int NOT NULL,
                          `created_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                          `ref_id` int DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_item_assembly_bos` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `assembly_id` int NOT NULL,
                          `item_id` int NOT NULL,
                          `qty` decimal(10,2) NOT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_projects` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) NOT NULL DEFAULT '',
                          `emirate` varchar(50) NOT NULL DEFAULT '',
                          `country_id` INT(10) NOT NULL DEFAULT '0',
                          `city_id` INT(10) NOT NULL DEFAULT '0',
                          `status` varchar(50) DEFAULT 'Planned',
                          `type` varchar(50) DEFAULT NULL,
                            project_classification VARCHAR(50) DEFAULT 'Design',
                            priority_level INT DEFAULT 0,
                            priority_color VARCHAR(20) DEFAULT '',
                            is_starred TINYINT(1) DEFAULT 0,
                          `name` varchar(250) NOT NULL DEFAULT '',
                          `name_ar` varchar(250) DEFAULT NULL,
                          `category` varchar(250) DEFAULT '',
                          `description` varchar(350) DEFAULT '',
                          `start_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
                          `extend_delay` date DEFAULT NULL,
                            handover_date DATE NULL,
                          `execution_period_months` int NOT NULL DEFAULT '0',
                          `customer` varchar(150) DEFAULT '0',
                          owner_name VARCHAR(250) DEFAULT '',
                          `contractor` varchar(150) DEFAULT '',
                          `consultant` varchar(150) DEFAULT '',
                          `location` varchar(350) DEFAULT '',
                          `details` varchar(350) DEFAULT '',
                          `contract_value` decimal(15,2) DEFAULT 0,
                          `additional_value` decimal(15,2) DEFAULT 0,
                          `deduction_value` decimal(15,2) DEFAULT 0,
                          `total_value` decimal(15,2) DEFAULT 0,
                          `billed_to_date` decimal(15,2) DEFAULT 0,
                          `expenses` decimal(15,2) DEFAULT 0,
                          `balance` decimal(15,2) DEFAULT 0,
                          `area` varchar(250) DEFAULT '',  
                          `plot_number` varchar(50) DEFAULT '',
                            basin_number VARCHAR(50) DEFAULT '',
                            municipality_project_no VARCHAR(100) DEFAULT '',
                            bank_project_no VARCHAR(100) DEFAULT '',
                          `block` varchar(50) DEFAULT '',
                          `contact_person` varchar(150) DEFAULT '',
                          `contact_person_number` varchar(50) DEFAULT '',    
                          `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                          `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            last_progress_update DATETIME NULL,
                          part_no VARCHAR(100) DEFAULT '',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_projects_accounts` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` VARCHAR(3250) NOT NULL DEFAULT '',
                          `project_id` INT(10) NOT NULL DEFAULT '0',
                          `account_id` INT(10) NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_estimate` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `project_id` int NOT NULL DEFAULT '0',
                          `fund_account_id` int NOT NULL DEFAULT '0',
                          `material_cost` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `labor_cost` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `equipment_cost` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `overhead_cost` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `total_estimate` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `description` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
                          `state` int NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_management` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `project_planning_id` int NOT NULL DEFAULT '0',
                          `project_id` int NOT NULL DEFAULT '0',
                          `budget` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `actual_cost` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `remaining_budget` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `modified_date` date DEFAULT NULL,
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date DEFAULT NULL,
                          `modified_by` int NOT NULL DEFAULT '0',
                          `state` int NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_plan` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `project_id` int NOT NULL DEFAULT '0',
                          `location` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `site` int NOT NULL DEFAULT '0',
                          `plot_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `start_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
                          `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `project_type` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `estimated_budget` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `fund_account_id` int NOT NULL DEFAULT '0',
                          `description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `fund_period` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `assigned_team` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `progress` float DEFAULT '0',
                          `tender_id` int DEFAULT '0',
                          `tender_name_id` int DEFAULT '0',
                          `created_by` int DEFAULT '0',
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT '0',
                          `modified_date` date DEFAULT NULL,
                          `state` int DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_planning` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date DEFAULT NULL,
                          `project_id` int NOT NULL DEFAULT '0',
                          `location` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `site_id` int NOT NULL DEFAULT '0',
                          `plot_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                          `start_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
                          `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `project_type` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `estimated_budget` decimal(20,4) NOT NULL DEFAULT '0.000',
                          `fund_account_id` int NOT NULL DEFAULT '0',
                          `description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `fund_period` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `assigned_team` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `progress` decimal(10,2) NOT NULL DEFAULT '0',
                          `tender_id` int DEFAULT '0',
                          `tender_name_id` int DEFAULT '0',
                          `created_by` int DEFAULT '0',
                          `created_date` DATETIME DEFAULT CURRENT_TIMESTAMP,
                          `modified_by` int DEFAULT '0',
                          `modified_date` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                          `state` int DEFAULT '0',
                          `subcontractor_account_id` int NOT NULL DEFAULT '0',
                          `retention_account_id` int NOT NULL DEFAULT '0',
                          `retention_percentage` DECIMAL(18,2) NOT NULL DEFAULT '0',  
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_sites` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `location_id` int DEFAULT '0',
                          `project_id` int NOT NULL DEFAULT '0',  
                          `plot_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `address` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_tender` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `tender_name_id` int NOT NULL DEFAULT '0',
                          `account_id` int NOT NULL DEFAULT '0',
                          `project_id` int NOT NULL DEFAULT '0',
                          `fees` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `submission_date` date NOT NULL,
                          `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `tender_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `description` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT '0',
                          `modified_date` date DEFAULT NULL,
                          `amount` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `bid_amount` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `state` int NOT NULL DEFAULT '0',
                          `contractor_id` int NOT NULL DEFAULT '0',
	                      `estimate_status` INT(10) NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_project_tender_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sr` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `tender_id` int NOT NULL DEFAULT '0',
                          `item_id` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `qty` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `unit_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `rate` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `amount` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `margin_percentage` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `margin_amount` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `total` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `progress` decimal(20,4) NOT NULL DEFAULT '0.0000',
                          `assigned` int DEFAULT NULL,
                          `start_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
	                      `length` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                      `width` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                      `thickness` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                      `note` VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE IF NOT EXISTS `tbl_tender_names` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE `tbl_contractor` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `name` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `country_id` INT(10) NULL DEFAULT NULL,
	                        PRIMARY KEY (`id`) USING BTREE
                        ) COLLATE='utf8mb4_general_ci' ENGINE=InnoDB;
                        
                        CREATE TABLE `tbl_project_material_requests` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `tender_id` INT(10) NOT NULL DEFAULT '0',
	                        `planning_id` INT(10) NOT NULL DEFAULT '0',
	                        `RequestedDate` DATE NULL DEFAULT NULL,
	                        `IssuedDate` DATE NULL DEFAULT NULL,
	                        `ReceivedDate` DATE NULL DEFAULT NULL,
	                        `itemId` INT(10) NOT NULL DEFAULT '0',
	                        `unit` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                        `RequestedQty` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
                            `IssuedQty` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
                            `ReceivedQty` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
	                        PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

                        CREATE TABLE tbl_project_resource (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `code` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            `date` date DEFAULT NULL,
                            `name` VARCHAR(200) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            `role` INT(10) NOT NULL DEFAULT '0',
                            `phone` VARCHAR(20) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            `type` VARCHAR(80) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                        `price_unit` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `unit_time` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
	                        `max_unit_time` DECIMAL(20,4) NOT NULL DEFAULT '0.0000',
							`employee_id` INT,
                          PRIMARY KEY (`id`)
                        );

                        CREATE TABLE tbl_project_role (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(50) NOT NULL UNIQUE COLLATE 'utf8mb4_general_ci',
                            name VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci'
                        );

                        CREATE TABLE tbl_project_activity (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            planning_id INT NOT NULL DEFAULT(0),
                            code VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            name VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            start_date DATE NOT NULL,
                            end_date DATE NOT NULL,
                            progress DECIMAL(20,2) NOT NULL DEFAULT '0.000',
                            status VARCHAR(50) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci'
                        );

                        CREATE TABLE `tbl_project_work_done` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `date` DATE NOT NULL,
	                        `planning_id` INT(10) NOT NULL,
	                        `account_id` INT(10) NOT NULL,
	                        `warehouse_id` INT(10) NOT NULL,
	                        `created_by` INT(10) NOT NULL,
	                        `created_date` DATE NOT NULL,
	                        `state` TINYINT(3) NULL DEFAULT '0',
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci' ENGINE=InnoDB;

                        CREATE TABLE `tbl_project_work_done_details` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `ref_id` INT(10) NOT NULL,
	                        `item_id` INT(10) NOT NULL,
	                        `main_id` INT(10) NOT NULL,
	                        `code` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `qty_total` DECIMAL(10,2) NULL DEFAULT '0.00',
	                        `unit` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `qty_used` DECIMAL(10,2) NULL DEFAULT '0.00',
	                        `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci' ENGINE=InnoDB;

                        CREATE TABLE tbl_project_activity_assignment (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            activity_id INT NOT NULL,
                            resource_id INT NOT NULL
                        ); 

                        CREATE TABLE `tbl_manufacturer_batch` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `batchname` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `Costamount` DECIMAL(64,2) NULL DEFAULT NULL,
	                        `amount` DECIMAL(62,2) NULL DEFAULT NULL,
	                        `hours` DECIMAL(10,0) NULL DEFAULT NULL,
	                        `userinsert` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `date` DATE NULL DEFAULT NULL,
	                        `Description` VARCHAR(1000) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `fixedassetsID` INT(10) NULL DEFAULT NULL,
	                        `fixedStatus` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `product_id` INT(10) NULL DEFAULT '0',
	                        `warehouse_id` INT(10) NULL DEFAULT '0',
	                        `warehouse_to_id` INT(10) NULL DEFAULT '0',
                            `product_qty` DECIMAL(10,0) NULL DEFAULT '0',
	                        `process_stage` VARCHAR(100) NULL DEFAULT '' COLLATE 'utf8mb4_0900_ai_ci',
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci'
                        ENGINE=InnoDB;

                        CREATE TABLE `tbl_manufacturer_batchdetails` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `batchID` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `itemid` INT(10) NULL DEFAULT NULL,
	                        `cost` DECIMAL(63,2) NULL DEFAULT NULL,
	                        `qty` DECIMAL(20,2) NULL DEFAULT NULL,
	                        `Total` DECIMAL(63,2) NULL DEFAULT NULL,
	                        `RequestQty` DECIMAL(20,2) NULL DEFAULT '0.00',
	                        `ReceiveQty` DECIMAL(20,2) NULL DEFAULT '0.00',
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci'
                        ENGINE=InnoDB;

                        CREATE TABLE `tbl_manufacturer_task` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `MachineID` INT(10) NULL DEFAULT NULL,
	                        `BatchID` INT(10) NULL DEFAULT NULL,
	                        `StartTime` DATETIME NULL DEFAULT NULL,
	                        `EndTime` DATETIME NULL DEFAULT NULL,
	                        `Status` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `userID` INT(10) NULL DEFAULT NULL,
                            `current_stage_id` INT(10) NULL DEFAULT 0,
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci'
                        ENGINE=InnoDB;

                        CREATE TABLE tbl_manufacturer_task_details (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            TaskID INT NOT NULL,
                            DepartmentID INT NOT NULL,
                            EmployeeID INT NOT NULL,
                            StartTime DATETIME,
                            EndTime DATETIME,
                            Status VARCHAR(50), -- e.g., 'Pending', 'Progress', 'Done'
                            Remarks TEXT
                        );
                        
                        CREATE TABLE `tbl_printconfg` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `PrintName` VARCHAR(150) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci'
                        ENGINE=InnoDB
                        ;
                        ";

                        DBClass.ExecuteNonQuery(query);

                        query = @" USE " + dbName + @";
                        CREATE TABLE tbl_main_menus ( id INT PRIMARY KEY, name VARCHAR(100) NOT NULL );
                        CREATE TABLE tbl_sub_menus (
                            id INT PRIMARY KEY,
                            name VARCHAR(150) NOT NULL,
                            m_id INT,
                            FOREIGN KEY (m_id) REFERENCES tbl_main_menus(id) );
                                CREATE TABLE tbl_user_permissions (
                                    `id` INT AUTO_INCREMENT PRIMARY KEY,
                                    `user_id` INT NOT NULL,
                                    `sub_menu_id` INT NOT NULL,
                                    `can_view` BOOLEAN NOT NULL DEFAULT FALSE,
                                    `can_edit` BOOLEAN NOT NULL DEFAULT FALSE,
                                    `can_delete` BOOLEAN NOT NULL DEFAULT FALSE
                                );
                        ALTER TABLE tbl_user_permissions
                        ADD UNIQUE KEY uniq_user_submenu (user_id, sub_menu_id);

                        INSERT INTO tbl_main_menus (id, name) VALUES
                        (1, 'Accountant'),
                        (2, 'Inventory'),
                        (3, 'Customer'),
                        (4, 'Vendor'),
                        (5, 'HR'),
                        (6, 'Bank'),
                        (7, 'Report'),
                        (8, 'Setting'),
                        (9, 'File'),
                        (10, 'Construction');
                        
                        INSERT INTO tbl_sub_menus (id, name, m_id) VALUES
                            (1, 'Chart Of Account', 1),
                            (2, 'Cost Center', 1),
                            (3, 'Transactions Journal', 1),
                            (4, 'Fixed Assets', 1),
                            (5, 'Vouchers', 1),
                            (6, 'Prepaid Expense', 1),
                            (7, 'Petty Cash', 1),
                            (8, 'Inventory Items', 2),
                            (9, 'Stock Management', 2),
                            (10, 'Inventory Center', 2),
                            (11, 'Warehouse Center', 2),
                            (12, 'Customer Center', 3),
                            (13, 'Sales Center', 3),
                            (14, 'Create Invoice', 3),
                            (15, 'Receipt Voucher', 3),
                            (16, 'Credit Note', 3),
                            (17, 'Quotation', 3),
                            (18, 'Sales Order', 3),
                            (19, 'Sales Return', 3),
                            (20, 'Sales Proforma', 3),
                            (21, 'Vendor Center', 4),
                            (22, 'Purchases Center', 4),
                            (23, 'Create Purchases', 4),
                            (24, 'Payment Voucher', 4),
                            (25, 'Debit Note', 4),
                            (26, 'Purchase Order', 4),
                            (27, 'Purchase Return', 4),
                            (28, 'Human Resource Center', 5),
                            (29, 'Attendance Sheet', 5),
                            (30, 'Salary Sheet', 5),
                            (31, 'Leave Salary', 5),
                            (32, 'End Of Services', 5),
                            (33, 'Loans', 5),
                            (34, 'Final Settlement', 5),
                            (35, 'Payment Voucher', 5),
                            (36, 'Bank Center', 6),
                            (37, 'Open Bank Card', 6),
                            (38, 'Cheques', 6),
                            (39, 'PDC', 6),
                            (40, 'Company', 7),
                            (41, 'Customer & Receivable', 7),
                            (42, 'Sales', 7),
                            (43, 'Vendor & Payable', 7),
                            (44, 'Purchases', 7),
                            (45, 'Employees', 7),
                            (46, 'Accountant', 7),
                            (47, 'Inventory', 7),
                            (48, 'List', 7),
                            (49, 'Setting', 8),
                            (50, 'Change Current Password', 8),
                            (51, 'Clear Data', 8),
                            (52, 'Users', 8),
                            (53, 'Company List', 9),
                            (54, 'Back Up Company', 9),
                            (55, 'Restore Company', 9),
                            (56, 'Project DashBoard', 10),
                            (57, 'Project Tender', 10),
                            (58, 'Project Estimate', 10),
                            (59, 'Project Planning', 10),
                            (60, 'LessStockItem Notification', 8),
                            (61, 'PurchaseOrder Notification', 8),
                            (62, 'Production ItemRequest Notification', 8);
        
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE tbl_audit_log (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            user_id INT,
                            action_type VARCHAR(50),
                            module_name VARCHAR(100),
                            record_id INT,
                            details TEXT,
                            action_time DATETIME DEFAULT CURRENT_TIMESTAMP,
                            ip_address VARCHAR(45),
                            machine_name VARCHAR(100)
                        )
                        COLLATE='utf8mb4_general_ci'
                        ENGINE=InnoDB
                        ;

                        CREATE TABLE `tbl_color` (
	                        `id` INT NOT NULL AUTO_INCREMENT,
	                        `headerColor` VARCHAR(50) NOT NULL DEFAULT 'White',
	                        `TextColor` VARCHAR(50) NOT NULL DEFAULT 'Black',
	                        PRIMARY KEY (`id`)
                        )
                        COLLATE='utf8mb4_general_ci';
                        INSERT INTO `tbl_color` (id, headerColor, TextColor)
                        VALUES (1,'RoyalBlue','White');
                        ";
                DBClass.ExecuteNonQuery(query);
                DBClass.ExecuteNonQuery(@" USE " + dbName + @";
                    CREATE TABLE IF NOT EXISTS tbl_reconciliation (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        account_id INT NOT NULL,
                        statement_date DATE NOT NULL,
                        ending_balance DECIMAL(18,4) NOT NULL,
                        service_charge DECIMAL(18,4) DEFAULT 0,
                        interest_amount DECIMAL(18,4) DEFAULT 0,
                        created_by INT,
                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB;
                ");

                DBClass.ExecuteNonQuery(@" USE " + dbName + @";
                    CREATE TABLE IF NOT EXISTS tbl_reconciliation_item (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        reconciliation_id INT NOT NULL,
                        transaction_id INT NOT NULL,
                        amount DECIMAL(18,4) NOT NULL,
                        cleared_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (reconciliation_id) REFERENCES tbl_reconciliation(id)
                    ) ENGINE=InnoDB;
                ");

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_labor_attendance (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            employee_id INT NOT NULL,
                            date DATE NOT NULL,
                            time_in TIME NOT NULL,
                            lunch_start TIME DEFAULT NULL,
                            lunch_end TIME DEFAULT NULL,
                            time_out TIME DEFAULT NULL,
                            overtime_hours DECIMAL(5,2) DEFAULT 0,
                            labor_id INT DEFAULT 0,
                            Status VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci'
                        ) ENGINE=InnoDB;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_Manufacturing_Steps (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(20) NOT NULL,
                            step_name VARCHAR(100) NOT NULL,
                            description VARCHAR(500),
                            step_order INT NOT NULL,
                            is_completed TINYINT(1) DEFAULT 0,
                            created_by INT,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_manufacturer_packing (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            item_id INT,
                            batch_id INT,
                            variant VARCHAR(255) NOT NULL DEFAULT(''),
                            quantity DECIMAL(18,2) DEFAULT 0,
                            batch_number VARCHAR(255),
                            packing_date DATE NOT NULL,
                            rack_no VARCHAR(255) DEFAULT '1',
                            created_by INT DEFAULT 0,
                            warehouse_id INT DEFAULT 0,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_project_phases (
                            phase_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            template_id INT NULL,
                            phase_no INT NOT NULL DEFAULT 0,
                            phase_name VARCHAR(200) NOT NULL,
                            start_date DATE NOT NULL,
                            end_date DATE DEFAULT NULL,
                            completed_on DATETIME NULL,
                            weight_percentage DECIMAL(5,2) NOT NULL DEFAULT 0.00,
                            status VARCHAR(50) NOT NULL,
                            phase_color VARCHAR(20) DEFAULT 'Gray',
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_project_milestones (
                            milestone_id INT AUTO_INCREMENT PRIMARY KEY,
                            phase_id INT NOT NULL,
                            milestone_name VARCHAR(150),
                            due_date DATE,
                            progress_percent DECIMAL(5,2),
                            status VARCHAR(50),
                            percentage DECIMAL(5,2) DEFAULT 0,
                            amount DECIMAL(18,3) DEFAULT 0,
                            FOREIGN KEY (phase_id) REFERENCES tbl_eng_project_phases(phase_id)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_project_deliverables (
                            deliverable_id INT AUTO_INCREMENT PRIMARY KEY,
                            milestone_id INT NOT NULL,
                            deliverable_name VARCHAR(200),
                            deliverable_type VARCHAR(50),
                            due_date DATE,
                            status VARCHAR(50),
                            remarks TEXT
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_timesheets (
                            timesheet_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_id INT NOT NULL,
                            milestone_id INT NOT NULL,
                            employee_id INT NOT NULL,
                            work_date DATE NOT NULL,
                            hours DECIMAL(5,2) NOT NULL DEFAULT 0,
                            is_billable TINYINT(1) NOT NULL DEFAULT 0,
                            remarks VARCHAR(500),
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            is_approved TINYINT(1) NULL DEFAULT '0',
	                        approved_by INT(10) NULL DEFAULT NULL,
	                        approved_date DATETIME NULL DEFAULT NULL
                        )  ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_project_costing (
                            costing_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_id INT NOT NULL,
                            cost_type VARCHAR(70),
                            description VARCHAR(500),
                            planned_cost DECIMAL(14,2) NOT NULL DEFAULT 0.00,
                            actual_cost DECIMAL(14,2) NOT NULL DEFAULT 0.00,
                            cost_date DATE NOT NULL,
                            created_by INT NOT NULL,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        )  ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_project_revenue (
                            revenue_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_id INT NOT NULL,
                            recognition_method VARCHAR(80) NOT NULL DEFAULT '',
                            completion_percent DECIMAL(8,2) NOT NULL DEFAULT 0.00,
                            total_contract_value DECIMAL(14,2) NOT NULL,
                            recognized_amount DECIMAL(14,2) NOT NULL DEFAULT 0.00,
                            recognition_date DATE NOT NULL,
                            approved_by INT NOT NULL,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        )  ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_design_documents (
                            document_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_id INT NOT NULL,
                            document_name VARCHAR(255) NOT NULL,
                            document_type VARCHAR(50) NOT NULL,
                            version VARCHAR(20) NOT NULL,
                            file_path VARCHAR(500) NOT NULL,
                            uploaded_by INT NOT NULL,
                            upload_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            status VARCHAR(70) NOT NULL DEFAULT 'Pending',
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_design_revisions (
                            revision_id INT AUTO_INCREMENT PRIMARY KEY,
                            document_id INT NOT NULL,
                            version VARCHAR(20) NOT NULL,
                            change_description TEXT NOT NULL,
                            file_path VARCHAR(500) NOT NULL,
                            revised_by INT NOT NULL,
                            revised_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            status VARCHAR(60) NOT NULL DEFAULT 'Pending',
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
                            INDEX idx_document_id (document_id)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_design_approvals (
                            approval_id INT AUTO_INCREMENT PRIMARY KEY,
                            document_id INT NOT NULL,
                            approved_by INT NOT NULL,
                            approval_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            status VARCHAR(60) NOT NULL DEFAULT 'Pending',
                            remarks TEXT NULL,
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
                            INDEX idx_document_id (document_id),
                            INDEX idx_approved_by (approved_by)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_crm_proposals (
                            proposal_id INT AUTO_INCREMENT PRIMARY KEY,
                            client_id INT NOT NULL,
                            employee_id INT NOT NULL,
                            title VARCHAR(255) NOT NULL,
                            amount DECIMAL(15,2) NOT NULL,
                            status VARCHAR(60) NOT NULL DEFAULT 'Draft',
                            created_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_crm_contracts (
                            contract_id INT AUTO_INCREMENT PRIMARY KEY,
                            client_id INT NOT NULL,
                            contract_no VARCHAR(100) NOT NULL,
                            contract_value DECIMAL(18,2) NOT NULL,
                            start_date DATE NOT NULL,
                            end_date DATE NOT NULL,
                            signed_date DATE NOT NULL,
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_crm_leads (
                            lead_id INT AUTO_INCREMENT PRIMARY KEY,
                            source VARCHAR(200),
                            created_date DATE,
                            assigned_to INT,
                            status VARCHAR(50)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_eng_lookups (
                            lookup_id INT AUTO_INCREMENT PRIMARY KEY,
                            lookup_category VARCHAR(100) NOT NULL,
                            lookup_code VARCHAR(100) NOT NULL,
                            lookup_value VARCHAR(255) NOT NULL,
                            is_active TINYINT(1) NOT NULL DEFAULT 1,
                            sort_order INT NOT NULL DEFAULT 0,
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
                            INDEX idx_lookup_category (lookup_category),
                            INDEX idx_is_active (is_active),
                            INDEX idx_sort_order (sort_order)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_kpi_master (
                            kpi_id INT AUTO_INCREMENT PRIMARY KEY,
                            kpi_code VARCHAR(50) UNIQUE,
                            kpi_name VARCHAR(200),
                            kpi_category VARCHAR(50),   -- Productivity, Quality, Finance
                            weight DECIMAL(18,2),        -- Contribution %
                            target_value DECIMAL(10,2),
                            calculation_method VARCHAR(50),
                            is_active TINYINT(1) DEFAULT 1,
	                        employee_id INT NOT NULL DEFAULT 0,
	                        EvaluationPeriod VARCHAR(70)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_kpi_results (
                            result_id INT AUTO_INCREMENT PRIMARY KEY,
                            kpi_id INT,
                            employee_id INT,
                            period_month INT,
                            period_year INT,
                            actual_value DECIMAL(10,2),
                            score DECIMAL(18,2),
                            calculated_at DATETIME,
                            FOREIGN KEY (kpi_id) REFERENCES tbl_kpi_master(kpi_id)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_kpi_comments (
                            comment_id INT AUTO_INCREMENT PRIMARY KEY,
                            result_id INT,
                            commented_by INT,
                            comment TEXT,
                            commented_at DATETIME
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_kpi_periods (
                            period_month INT,
                            period_year INT,
                            is_locked TINYINT(1) DEFAULT 0,
                            locked_at DATETIME,
                            PRIMARY KEY (period_month, period_year)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_maintenance_requests (
                            request_id INT AUTO_INCREMENT PRIMARY KEY,
                            asset_id INT NOT NULL DEFAULT '0',
                            maintenance_type VARCHAR(50) NOT NULL,
                            priority VARCHAR(50) NOT NULL,
                            technician VARCHAR(100),
                            estimated_cost DECIMAL(18,2),
                            status VARCHAR(50) DEFAULT 'Open',
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_job_orders (
                            job_id INT AUTO_INCREMENT PRIMARY KEY,
                            job_type ENUM('Work Order','Maintenance Job','Emergency Job') NOT NULL,
                            project_id INT NULL,
                            project_name VARCHAR(200) NOT NULL,
                            asset_id INT NULL,
                            assigned_to VARCHAR(150) NOT NULL,
                            estimated_hours DECIMAL(8,2) NOT NULL DEFAULT 0.00,
                            actual_hours DECIMAL(8,2) NOT NULL DEFAULT 0.00,
                            estimated_cost DECIMAL(12,2) NOT NULL DEFAULT 0.00,
                            actual_cost DECIMAL(12,2) NOT NULL DEFAULT 0.00,
                            status ENUM('Open','Approved','In Progress','Completed','Cancelled') NOT NULL DEFAULT 'Open',
                            priority ENUM('Low','Medium','High','Critical') NOT NULL DEFAULT 'Medium',
                            remarks TEXT NULL,
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
                            INDEX idx_status (status),
                            INDEX idx_job_type (job_type),
                            INDEX idx_project (project_id),
                            INDEX idx_asset (asset_id)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_equipment` (
                            `equipment_id` INT AUTO_INCREMENT PRIMARY KEY,
                            `name` VARCHAR(200) NOT NULL,
                            `category` VARCHAR(100) NOT NULL,
                            `status` ENUM('Available', 'In Use', 'Maintenance', 'Retired') NOT NULL DEFAULT 'Available',
                            `allocated_to` VARCHAR(200) DEFAULT NULL,
                            `purchase_date` DATE NOT NULL,
                            `cost` DECIMAL(20,2) NOT NULL DEFAULT 0.00,
                            `depreciation` DECIMAL(20,2) NOT NULL DEFAULT 0.00,
                            `created_date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            `modified_date` DATETIME DEFAULT NULL
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_batch_transaction (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            tran_type VARCHAR(50) NOT NULL,
                            tran_date DATE NOT NULL,
                            account_id INT NOT NULL DEFAULT 0,
                            ref_no VARCHAR(100),
                            total_amount DECIMAL(15,2) NOT NULL DEFAULT 0.00,
                            status ENUM('Draft','Posted','Voided') DEFAULT 'Draft',
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            INDEX idx_tran_type (tran_type),
                            INDEX idx_tran_date (tran_date)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_batch_transaction_detail (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            tran_id INT NOT NULL,
                            payee_name VARCHAR(255),
                            payee_id INT NOT NULL DEFAULT 0,
                            account_name VARCHAR(255),
                            account_id INT NOT NULL DEFAULT 0,
                            item_name VARCHAR(255),
                            item_id INT NOT NULL DEFAULT 0,
                            description VARCHAR(500),
                            qty DECIMAL(12,2) DEFAULT 1,
                            rate DECIMAL(15,4) DEFAULT 0.00,
                            amount DECIMAL(15,2) NOT NULL,
                            tax_code VARCHAR(50),
                            tax_item VARCHAR(100),
                            tax_amount DECIMAL(15,2) DEFAULT 0.00,
                            terms VARCHAR(500) DEFAULT(''),
                            bill_due DATE,
                            check_no VARCHAR(100) DEFAULT(''),
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_kpi_score_band (
                            band_id INT AUTO_INCREMENT PRIMARY KEY,
                            min_pct DECIMAL(5,2),
                            max_pct DECIMAL(5,2),
                            score_pct DECIMAL(5,2)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_procurement_tracking (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            purchase_order_id INT NOT NULL,
                            vendor_id INT NOT NULL,
                            project_id INT NOT NULL,
                            amount DECIMAL(18,2) NOT NULL,
                            approval_status ENUM('Pending', 'Approved', 'Rejected') NOT NULL DEFAULT 'Pending',
                            payment_status ENUM('Unpaid', 'Paid', 'Partial', 'N/A') NOT NULL DEFAULT 'Unpaid',
                            approved_by VARCHAR(100),
                            approved_date DATETIME,
                            remarks VARCHAR(255),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_labor_assignments (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            employee_id INT NOT NULL,
                            project_id INT NOT NULL,
                            role VARCHAR(100),
                            daily_rate DECIMAL(18,2) NOT NULL,
                            hours_worked DECIMAL(18,2) NOT NULL,
                            labor_cost DECIMAL(18,2) NOT NULL,
                            productivity DECIMAL(18,2) NOT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_invoices (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            invoice_no VARCHAR(50) NOT NULL,
                            customer_id INT NOT NULL,
                            project_id INT NOT NULL,
                            amount DECIMAL(18,2) NOT NULL,
                            status VARCHAR(20) NOT NULL,
                            invoice_date DATE NOT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_expenses (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            expense_date DATE NOT NULL,
                            expense_type VARCHAR(100),      -- Rent, Fuel, Salary, Maintenance
                            description VARCHAR(250),
                            amount DECIMAL(12,2) NOT NULL,
                            project_id INT NULL,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	                        updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_attachments (
                            attachment_id INT AUTO_INCREMENT PRIMARY KEY,
                            reference_type VARCHAR(50) NOT NULL,   -- SALES, PURCHASE, PO
                            reference_id INT NOT NULL,
                            file_name VARCHAR(255) NOT NULL,
                            file_type VARCHAR(50),
                            file_data LONGBLOB NOT NULL,
                            uploaded_on DATETIME DEFAULT CURRENT_TIMESTAMP,
                            UNIQUE KEY uq_attachment (reference_type, reference_id)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";

                DBClass.ExecuteNonQuery(query);


                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_documents (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            title VARCHAR(150) NOT NULL,
                            description VARCHAR(250) NOT NULL,
                            keywords VARCHAR(250) NOT NULL,
                            comments VARCHAR(250) NOT NULL,
                            file_name VARCHAR(255) NOT NULL,
                            file_type VARCHAR(50),
                            file_data LONGBLOB NOT NULL,
                            uploaded_on DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_sales_tax_invoice (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            invoice_no VARCHAR(50),
                            invoice_date DATE,
                            customer_id INT,
                            type VARCHAR(20), -- ADVANCE or RETENTION
                            subtotal DECIMAL(18,2),
                            vat DECIMAL(18,2),
                            total DECIMAL(18,2),
                            remarks VARCHAR(250) default(''),
                            state TINYINT DEFAULT 0,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_sales_tax_invoice_item (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            invoice_id INT,
                            item_id INT,
                            description VARCHAR(200) default(''),
                            qty DECIMAL(18,2),
                            rate DECIMAL(18,2),
                            vat DECIMAL(18,2),
                            total DECIMAL(18,2)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_sales_advance` (
                            `id` INT NOT NULL AUTO_INCREMENT,
                            `date` DATE NOT NULL,
                            `customer_id` INT NOT NULL,
                            `sales_order_id` INT DEFAULT NULL,
                            `invoice_id` INT DEFAULT NULL, -- optional if applied to invoice later
                            `amount` DECIMAL(20,6) NOT NULL,
                            `payment_method` VARCHAR(50) DEFAULT NULL,
                            `form_type` VARCHAR(80) DEFAULT NULL,
                            `description` VARCHAR(250) DEFAULT NULL,
                            `account_id` INT NOT NULL, -- liability account
                            `project_id` INT DEFAULT 0,
                            PRIMARY KEY (`id`),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_subcontractors` (
                            `id` INT NOT NULL AUTO_INCREMENT,
                            `code` VARCHAR(50) DEFAULT NULL,
                            `subcontractor_id` INT NOT NULL,
                            `project_id` INT NOT NULL,
                            `contact_no` VARCHAR(50) DEFAULT NULL,
                            `contract_value` DECIMAL(20,6) NOT NULL,
                            `contract_date` DATE NOT NULL,
                            `contract_period` VARCHAR(80) DEFAULT NULL,
                            `works` VARCHAR(250) DEFAULT NULL,
                            `worksEn` VARCHAR(250) DEFAULT NULL,
                            PRIMARY KEY (`id`),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_engineers` (
                            `id` INT NOT NULL AUTO_INCREMENT,
                            `code` VARCHAR(50) DEFAULT NULL,
                            `name` VARCHAR(250) DEFAULT NULL,
                            `contact_no` VARCHAR(50) DEFAULT NULL,
                            PRIMARY KEY (`id`),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_projects_engineers` (
                            `id` INT NOT NULL AUTO_INCREMENT,
                            `engineer_id` INT NOT NULL,
                            `project_id` INT NOT NULL,
                            `date` DATE NOT NULL,
                            `description` VARCHAR(250) DEFAULT NULL,
                            PRIMARY KEY (`id`),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_projects_invoices` (
                            invoice_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            milestone_id INT NOT NULL,
                            invoice_number VARCHAR(100) NOT NULL,
                            invoice_date DATE,
                            amount DECIMAL(18,3) NOT NULL DEFAULT 0,
                            vat DECIMAL(18,3) NOT NULL DEFAULT 0,
                            total DECIMAL(18,3) NOT NULL DEFAULT 0,
                            status VARCHAR(50) DEFAULT 'Pending',
                            description VARCHAR(500) NOT NULL DEFAULT '',
                            account_id INT NOT NULL DEFAULT 0,
                            cost_center_id INT NOT NULL DEFAULT 0,
                            payment_status VARCHAR(100) NOT NULL,
                            paid_amount DECIMAL(18,3) NOT NULL DEFAULT 0,
                            retention_amount decimal(20,6) NOT NULL DEFAULT 0,
                            retention_percentage decimal(20,6) NOT NULL DEFAULT 0,
                            deduction decimal(20,6) NOT NULL DEFAULT 0,
                            advance_amount decimal(20,6) NOT NULL DEFAULT 0,
                            advance_percentage decimal(20,6) NOT NULL DEFAULT 0,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_projects_receipt_voucher` (
                                  `id` int NOT NULL AUTO_INCREMENT,
                                  `date` date DEFAULT NULL,
                                  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `amount` decimal(20, 6) DEFAULT NULL,
                                  `hum_id` int DEFAULT NULL,
                                  `credit_account_id` int DEFAULT NULL,
                                  `credit_cost_center_id` int DEFAULT NULL,
                                  `description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `debit_account_id` int DEFAULT NULL,
                                  `debit_cost_center_id` int DEFAULT NULL,
                                  `bank_account_id` int DEFAULT NULL,
                                  `book_no` int DEFAULT NULL,
                                  `bank_id` int DEFAULT NULL,
                                  `bank_account` int DEFAULT NULL,
                                  `bank_code` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `check_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `check_no` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `check_date` date DEFAULT NULL,
                                  `trans_date` date DEFAULT NULL,
                                  `trans_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `trans_ref` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                  `created_by` int DEFAULT NULL,
                                  `created_date` date DEFAULT NULL,
                                  `state` int DEFAULT NULL,
                                  `modified_by` int DEFAULT NULL,
                                  `modified_date` date DEFAULT NULL,
                                  `project_id` INT NOT NULL DEFAULT 0,
                                  PRIMARY KEY(`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                                        CREATE TABLE IF NOT EXISTS `tbl_projects_receipt_voucher_details` (
                                              `id` int NOT NULL AUTO_INCREMENT,
                                              `date` date DEFAULT NULL,
                                              `payment_id` int DEFAULT NULL,
                                              `inv_id` int DEFAULT NULL,
                                              `hum_id` int DEFAULT NULL,
                                              `inv_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                                              `total` decimal(20, 2) DEFAULT '0.00',
                                              `payment` decimal(20, 2) DEFAULT '0.00',
                                              `description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                                              `cost_center_id` int DEFAULT NULL,
                                              `project_id` INT NOT NULL DEFAULT 0,
                                              PRIMARY KEY(`id`)
                                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;
                                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_project_payments` (
                            `id` INT NOT NULL AUTO_INCREMENT,
                            `payment_date` DATE DEFAULT NULL,
                            `code` VARCHAR(50) DEFAULT '0',
                            `project_id` INT NOT NULL DEFAULT 0,
                            `engineer_id` INT NOT NULL DEFAULT 0,
                            `client_id` INT NOT NULL DEFAULT 0,
                            `payment_source` VARCHAR(50) DEFAULT NULL, -- Bank / Owner
                            `project_value` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `consultancy_percentage` DECIMAL(10,4) NOT NULL DEFAULT 0.00,
                            `consultancy_fee` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            -- DESIGN
                            `design_fee` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `design_received` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `design_tax` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `design_tax_received` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `design_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            -- SUPERVISION
                            `supervision_fee` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `supervision_received_percentage` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                            `supervision_payment_value` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `retention_percentage` DECIMAL(10,2) NOT NULL DEFAULT 10.00,
                            `retention_amount` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `supervision_received_after_retention` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `supervision_tax` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `supervision_tax_received` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `supervision_balance` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                            `remarks` TEXT DEFAULT NULL,
                            `debit_account_id` INT DEFAULT NULL,
                            `credit_account_id` INT DEFAULT NULL,

                            `created_at` DATETIME DEFAULT CURRENT_TIMESTAMP,
                            PRIMARY KEY (`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_projects_site_setup` (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `date` date DEFAULT NULL,
                            `project_id` INT NOT NULL DEFAULT 0,
                            `site_id` INT NOT NULL DEFAULT 0,
                            `tender_id` INT NOT NULL DEFAULT 0,
                            `tender_name_id` INT NOT NULL DEFAULT 0,
                            `start_date` date DEFAULT NULL,
                            `end_date` date DEFAULT NULL,
                            `subcontractor_id` INT NOT NULL DEFAULT 0,
                            `status` varchar(50) DEFAULT '',
                            `engineer_supervisor` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                            `created_by` int DEFAULT NULL,
                            `modified_by` int DEFAULT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            PRIMARY KEY(`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;
                                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE `tbl_project_zone` (
                            `id` INT NOT NULL AUTO_INCREMENT,
                            `site_setup_id` INT NOT NULL,
                            `zone_code` VARCHAR(50) DEFAULT '',
                            `zone_name` VARCHAR(200) DEFAULT '',
                            `description` VARCHAR(500) DEFAULT '',
                            `status` VARCHAR(50) DEFAULT 'Active',
                            `created_by` INT DEFAULT NULL,
                            `modified_by` INT DEFAULT NULL,
                            `created_at` DATETIME DEFAULT CURRENT_TIMESTAMP,
                            `updated_at` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE = utf8mb4_general_ci;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE `tbl_project_resource_assignment` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `site_setup_id` INT(10) NOT NULL,
	                        `resource_id` INT(10) NOT NULL,
                            `project_id` INT(10) NOT NULL,
                            `tender_id` INT(10) NOT NULL,
	                        PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;";
                DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @"
                //        CREATE TABLE IF NOT EXISTS tbl_project_wbs (
                //          `id` INT NOT NULL AUTO_INCREMENT,
                //          `site_setup_id` INT NOT NULL DEFAULT 0,
                //          `project_id` INT NOT NULL DEFAULT 0,
                //          `parent_wbs_id` INT NOT NULL DEFAULT 0,
                //          `code` VARCHAR(50) NOT NULL DEFAULT '',
                //          `name` VARCHAR(300) NOT NULL DEFAULT '',
                //          `wbs_level` INT NOT NULL DEFAULT 1,
                //          `description` VARCHAR(500) DEFAULT '',
                //          `is_active` TINYINT(1) NOT NULL DEFAULT 1,
                //          `created_by` INT NOT NULL DEFAULT 0,
                //          `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                //          PRIMARY KEY (`id`),
                //          UNIQUE KEY `uq_wbs_code_site` (`site_setup_id`, `code`)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE tbl_project_activity (
                //            `id` INT NOT NULL AUTO_INCREMENT,
                //            `site_setup_id` INT NOT NULL,
                //            `zone_id` INT DEFAULT NULL,
                //            `wbs_id` INT NOT NULL,
                //            `activity_code` VARCHAR(50) DEFAULT '',
                //            `activity_name` VARCHAR(255) DEFAULT '',
                //            `activity_type` VARCHAR(100) DEFAULT '',
                //            `start_date` DATE DEFAULT NULL,
                //            `end_date` DATE DEFAULT NULL,
                //            `duration_days` INT DEFAULT 0,
                //            `dependency_activity_id` INT DEFAULT NULL,
                //            `responsible_engineer` VARCHAR(255) DEFAULT '',
                //            `planned_qty` DECIMAL(18,3) DEFAULT 0,
                //            `unit` VARCHAR(50) DEFAULT '',
                //            `status` VARCHAR(50) DEFAULT 'Planned',
                //            `progress_percent` DECIMAL(5,2) DEFAULT 0,
                //            `remarks` VARCHAR(500) DEFAULT '',
                //            `created_by` INT DEFAULT NULL,
                //            `modified_by` INT DEFAULT NULL,
                //            `created_at` DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            `updated_at` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                //            PRIMARY KEY (`id`)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"; 
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_activity_plan (
                //          `id` INT NOT NULL AUTO_INCREMENT,
                //          `site_setup_id` INT NOT NULL DEFAULT 0,
                //          `project_id` INT NOT NULL DEFAULT 0,
                //          `wbs_id` INT NOT NULL DEFAULT 0,
                //          `activity_code` VARCHAR(50) NOT NULL DEFAULT '',
                //          `activity_name` VARCHAR(300) NOT NULL DEFAULT '',
                //          `boq_item_id` INT NOT NULL DEFAULT 0,
                //          `planned_qty` DECIMAL(18,3) NOT NULL DEFAULT 0,
                //          `unit` VARCHAR(50) DEFAULT '',
                //          `start_date` DATE DEFAULT NULL,
                //          `end_date` DATE DEFAULT NULL,
                //          `dependency_activity_id` INT NOT NULL DEFAULT 0,
                //          `responsible_resource_id` INT NOT NULL DEFAULT 0,
                //          `remarks` VARCHAR(500) DEFAULT '',
                //          `status` VARCHAR(50) DEFAULT 'Planned',
                //          `created_by` INT NOT NULL DEFAULT 0,
                //          `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                //          PRIMARY KEY (`id`)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";
                //DBClass.ExecuteNonQuery(query);

                /********************************************* Optional ******************************************/

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS `tbl_project_daily_work` (
                //          `id` INT NOT NULL AUTO_INCREMENT,
                //          `work_date` DATE NOT NULL,
                //          `project_id` INT NOT NULL DEFAULT 0,
                //          `site_id` INT NOT NULL DEFAULT 0,
                //          `zone_id` INT NOT NULL DEFAULT 0,
                //          `shift_name` VARCHAR(30) DEFAULT '',
                //          `weather` VARCHAR(100) DEFAULT '',
                //          `remarks` VARCHAR(500) DEFAULT '',
                //          `status` VARCHAR(30) NOT NULL DEFAULT 'Draft',
                //          `created_by` INT NOT NULL DEFAULT 0,
                //          `created_date` DATETIME DEFAULT CURRENT_TIMESTAMP,
                //          `approved_by` INT NOT NULL DEFAULT 0,
                //          `approved_date` DATETIME DEFAULT NULL,
                //          PRIMARY KEY (`id`)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS `tbl_project_daily_work_details` (
                //          `id` INT NOT NULL AUTO_INCREMENT,
                //          `daily_work_id` INT NOT NULL DEFAULT 0,
                //          `planning_detail_id` INT NOT NULL DEFAULT 0,
                //          `project_id` INT NOT NULL DEFAULT 0,
                //          `site_id` INT NOT NULL DEFAULT 0,
                //          `zone_id` INT NOT NULL DEFAULT 0,
                //          `wbs_id` INT NOT NULL DEFAULT 0,
                //          `activity_id` INT NOT NULL DEFAULT 0,
                //          `boq_item_id` INT NOT NULL DEFAULT 0,

                //          `today_qty` DECIMAL(20,4) NOT NULL DEFAULT 0.0000,
                //          `cumulative_qty` DECIMAL(20,4) NOT NULL DEFAULT 0.0000,
                //          `progress` DECIMAL(10,2) NOT NULL DEFAULT 0.00,

                //          `delay_flag` TINYINT(1) NOT NULL DEFAULT 0,
                //          `delay_reason` VARCHAR(500) DEFAULT '',
                //          `photo_count` INT NOT NULL DEFAULT 0,
                //          `remarks` VARCHAR(500) DEFAULT '',

                //          PRIMARY KEY (`id`)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                ////tbl_project_work_order
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_work_order (
                //            work_order_id INT AUTO_INCREMENT PRIMARY KEY,
                //            work_order_no VARCHAR(50) NOT NULL UNIQUE,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            zone_id INT NOT NULL DEFAULT 0,
                //            wbs_id INT NOT NULL DEFAULT 0,
                //            activity_id INT NOT NULL DEFAULT 0,
                //            boq_id INT NOT NULL DEFAULT 0,
                //            cost_code_id INT NOT NULL DEFAULT 0,
                //            planning_detail_id INT NOT NULL DEFAULT 0,
                //            description VARCHAR(500) default(''),
                //            status ENUM('Draft','Submitted','Approved','Rejected') DEFAULT 'Draft',
                //            created_by INT NULL,
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_work_order_details
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_work_order_details (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            work_order_id INT NOT NULL,
                //            description VARCHAR(500) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_site_instruction
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_site_instruction (
                //            instruction_id INT AUTO_INCREMENT PRIMARY KEY,
                //            instruction_no VARCHAR(50) NOT NULL UNIQUE,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            zone_id INT NOT NULL DEFAULT 0,
                //            wbs_id INT NOT NULL DEFAULT 0,
                //            activity_id INT NOT NULL DEFAULT 0,
                //            boq_id INT NOT NULL DEFAULT 0,
                //            cost_code_id INT NOT NULL DEFAULT 0,
                //            planning_detail_id INT NOT NULL DEFAULT 0,
                //            description VARCHAR(500) default(''),
                //            status ENUM('Draft','Submitted','Approved','Rejected') DEFAULT 'Draft',
                //            created_by INT NULL,
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_request (
                //            mr_id INT AUTO_INCREMENT PRIMARY KEY,
                //            mr_no VARCHAR(50) NOT NULL UNIQUE,
                //            request_date DATE NOT NULL,
                //            requested_by INT NOT NULL,
                //            department_id INT NOT NULL,
                //            status ENUM('Draft','Submitted','Approved','Rejected') DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_by INT NULL,
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_request_item (
                //            mr_item_id INT AUTO_INCREMENT PRIMARY KEY,
                //            mr_id INT NOT NULL,                 
                //            item_id INT NOT NULL,               
                //            required_qty DECIMAL(18,2) NOT NULL,
                //            uom VARCHAR(10) NOT NULL default(''),           
                //            expected_date DATE NULL,
                //            status ENUM('Pending','Ordered','Received') DEFAULT 'Pending',
                //            remarks VARCHAR(250) default(''),
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            zone_id INT NOT NULL DEFAULT 0,
                //            wbs_id INT NOT NULL DEFAULT 0,
                //            activity_id INT NOT NULL DEFAULT 0,
                //            boq_id INT NOT NULL DEFAULT 0,
                //            cost_code_id INT NOT NULL DEFAULT 0,
                //            planning_detail_id INT NOT NULL DEFAULT 0,
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_received (
                //            mr_id INT AUTO_INCREMENT PRIMARY KEY,
                //            mr_no VARCHAR(50) NOT NULL UNIQUE,
                //            mr_date DATE NOT NULL,
                //            po_id INT NOT NULL default 0,
                //            vendor_id INT NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Partial',
                //            remarks VARCHAR(250) default(''),
                //            created_by INT NULL,
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_received_item (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            mr_id INT NOT NULL,
                //            po_item_id INT NOT NULL,
                //            ordered_qty DECIMAL(18,2) NOT NULL, 
                //            received_qty DECIMAL(18,2) NOT NULL,
                //            uom VARCHAR(10) NOT NULL default(''),
                //            status VARCHAR(20) DEFAULT 'Partial',
                //            warehouse_id INT NOT NULL DEFAULT 0,
                //            inspection_status VARCHAR(20) DEFAULT 'Pending',
                //            approved_qty DECIMAL(18,2) NOT NULL DEFAULT 0,
                //            rejected_qty DECIMAL(18,2) NOT NULL DEFAULT 0,
                //            batch_number VARCHAR(255) DEFAULT '',
                //            location_bin VARCHAR(255) DEFAULT '',
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_inspection (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            receipt_id INT NOT NULL,
                //            inspection_date DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
                //            warehouse_id INT NOT NULL DEFAULT 0,
                //            status VARCHAR(20) DEFAULT 'Pending',
                //            inspected_by INT NOT NULL,
                //            approved_by INT NOT NULL,
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_inspection_item (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            inspection_id INT NOT NULL,
                //            receipt_item_id INT NOT NULL,
                //            item_id INT NOT NULL,
                //            received_qty DECIMAL(18,2) NOT NULL,
                //            approved_qty DECIMAL(18,2) NOT NULL,
                //            rejected_qty DECIMAL(18,2) NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Pending',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_issue (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            issue_no VARCHAR(50) NOT NULL UNIQUE,
                //            issue_date DATE NOT NULL,
                //            issued_by INT NOT NULL,
                //            project_id INT NOT NULL,
                //            site_id INT NOT NULL,
                //            zone_id INT NOT NULL,
                //            wbs_id INT NOT NULL,
                //            activity_id INT NOT NULL,
                //            boq_id INT NOT NULL,
                //            cost_code_id INT NOT NULL,
                //            planning_detail_id INT NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_issue_item (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            issue_id INT NOT NULL,
                //            item_id INT NOT NULL,
                //            issued_qty DECIMAL(18,2) NOT NULL,
                //            uom VARCHAR(10) NOT NULL default(''),
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            warehouse_id INT NOT NULL DEFAULT 0,
                //            batch_number VARCHAR(255) DEFAULT '',
                //            location_bin VARCHAR(255) DEFAULT '',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                /////Material Consumption
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_consumption (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            project_id INT NOT NULL,
                //            site_id INT NOT NULL,
                //            zone_id INT NOT NULL,
                //            wbs_id INT NOT NULL,
                //            activity_id INT NOT NULL,
                //            boq_id INT NOT NULL,
                //            cost_code_id INT NOT NULL,
                //            planning_detail_id INT NOT NULL,
                //            consumption_date DATE NOT NULL,
                //            item_id INT NOT NULL,
                //            consumed_qty DECIMAL(18,2) NOT NULL,
                //            uom VARCHAR(10) NOT NULL default(''),
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_consumption_item (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            consumption_id INT NOT NULL,
                //            item_id INT NOT NULL,
                //            consumed_qty DECIMAL(18,2) NOT NULL,
                //            uom VARCHAR(10) NOT NULL default(''),
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            warehouse_id INT NOT NULL DEFAULT 0,
                //            batch_number VARCHAR(255) DEFAULT '',
                //            location_bin VARCHAR(255) DEFAULT '',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_return (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            return_no VARCHAR(50) NOT NULL UNIQUE,
                //            return_date DATE NOT NULL,
                //            returned_by INT NOT NULL,
                //            project_id INT NOT NULL,
                //            site_id INT NOT NULL,
                //            zone_id INT NOT NULL,
                //            wbs_id INT NOT NULL,
                //            activity_id INT NOT NULL,
                //            boq_id INT NOT NULL,
                //            cost_code_id INT NOT NULL,
                //            planning_detail_id INT NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_return_item (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            return_id INT NOT NULL,
                //            item_id INT NOT NULL,
                //            returned_qty DECIMAL(18,2) NOT NULL,
                //            uom VARCHAR(10) NOT NULL default(''),
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            warehouse_id INT NOT NULL DEFAULT 0,
                //            batch_number VARCHAR(255) DEFAULT '',
                //            location_bin VARCHAR(255) DEFAULT '',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_transfer (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            transfer_no VARCHAR(50) NOT NULL UNIQUE,
                //            transfer_date DATE NOT NULL,
                //            transferred_by INT NOT NULL,
                //            from_project_id INT NOT NULL,
                //            from_site_id INT NOT NULL,
                //            from_zone_id INT NOT NULL,
                //            from_wbs_id INT NOT NULL,
                //            from_activity_id INT NOT NULL,
                //            from_boq_id INT NOT NULL,
                //            from_cost_code_id INT NOT NULL,
                //            to_project_id INT NOT NULL,
                //            to_site_id INT NOT NULL,
                //            to_zone_id INT NOT NULL,
                //            to_wbs_id INT NOT NULL,
                //            to_activity_id INT NOT NULL,
                //            to_boq_id INT NOT NULL,
                //            to_cost_code_id INT NOT NULL,
                //            qty DECIMAL(18,2) NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_material_adjustment with item and qty
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_material_adjustment (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            adjustment_no VARCHAR(50) NOT NULL UNIQUE,
                //            adjustment_date DATE NOT NULL,
                //            adjusted_by INT NOT NULL,
                //            project_id INT NOT NULL,
                //            site_id INT NOT NULL,
                //            zone_id INT NOT NULL,
                //            wbs_id INT NOT NULL,
                //            activity_id INT NOT NULL,
                //            boq_id INT NOT NULL,
                //            qty DECIMAL(18,2) NOT NULL,
                //            cost_code_id INT NOT NULL,
                //            planning_detail_id INT NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_stock_reconciliation with item, qty and date
                // query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_stock_reconciliation (
                //            id INT AUTO_INCREMENT PRIMARY KEY,
                //            reconciliation_no VARCHAR(50) NOT NULL UNIQUE,
                //            reconciliation_date DATE NOT NULL,
                //            reconciled_by INT NOT NULL,
                //            project_id INT NOT NULL,
                //            site_id INT NOT NULL,
                //            zone_id INT NOT NULL,
                //            wbs_id INT NOT NULL,
                //            activity_id INT NOT NULL,
                //            boq_id INT NOT NULL,
                //            qty DECIMAL(18,2) NOT NULL,
                //            cost_code_id INT NOT NULL,
                //            planning_detail_id INT NOT NULL,
                //            status VARCHAR(20) DEFAULT 'Draft',
                //            remarks VARCHAR(250) default(''),
                //            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                //            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_daily_labor
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_daily_labor (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            planning_id INT NOT NULL DEFAULT 0,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            tender_id INT NOT NULL DEFAULT 0,
                //            boq_item_id INT NOT NULL DEFAULT 0,
                //            work_date DATE,
                //            today_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            cumulative_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            progress DECIMAL(10,2) NOT NULL DEFAULT 0,
                //            remarks VARCHAR(500) DEFAULT '',
                //            created_by INT NOT NULL DEFAULT 0,
                //            created_date DATETIME,
                //            modified_by INT NOT NULL DEFAULT 0,
                //            modified_date DATETIME,
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_daily_equipment
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_daily_equipment (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            planning_id INT NOT NULL DEFAULT 0,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            tender_id INT NOT NULL DEFAULT 0,
                //            boq_item_id INT NOT NULL DEFAULT 0,
                //            work_date DATE,
                //            today_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            cumulative_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            progress DECIMAL(10,2) NOT NULL DEFAULT 0,
                //            remarks VARCHAR(500) DEFAULT '',
                //            created_by INT NOT NULL DEFAULT 0,
                //            created_date DATETIME,
                //            modified_by INT NOT NULL DEFAULT 0,
                //            modified_date DATETIME,
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_site_expenses
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_site_expenses (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            tender_id INT NOT NULL DEFAULT 0,
                //            expense_date DATE,
                //            amount DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            description VARCHAR(500) DEFAULT '',
                //            created_by INT NOT NULL DEFAULT 0,
                //            created_date DATETIME,
                //            modified_by INT NOT NULL DEFAULT 0,
                //            modified_date DATETIME,
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_daily_report
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_daily_report (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            tender_id INT NOT NULL DEFAULT 0,
                //            report_date DATE,
                //            weather VARCHAR(100) DEFAULT '',
                //            created_by INT NOT NULL DEFAULT 0,
                //            created_date DATETIME,
                //            modified_by INT NOT NULL DEFAULT 0,
                //            modified_date DATETIME,
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_daily_report_details
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_daily_report_details (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            report_id INT NOT NULL DEFAULT 0,
                //            boq_item_id INT NOT NULL DEFAULT 0,
                //            labor_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            equipment_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            material_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                //            progress DECIMAL(10,2) NOT NULL DEFAULT 0,
                //            remarks VARCHAR(500) DEFAULT '',
                //            created_by INT NOT NULL DEFAULT 0,
                //            created_date DATETIME,
                //            modified_by INT NOT NULL DEFAULT 0,
                //            modified_date DATETIME,
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                //        ";
                //DBClass.ExecuteNonQuery(query);
                ////tbl_project_zone
                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_zone (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            parent_zone_id INT NOT NULL DEFAULT 0,
                //            code VARCHAR(50) NOT NULL DEFAULT '',
                //            name VARCHAR(150) NOT NULL DEFAULT '',
                //            zone_type VARCHAR(50) NOT NULL DEFAULT '', -- Block/Floor/Area/Zone
                //            status VARCHAR(50) NOT NULL DEFAULT 'Active',
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_wbs (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            zone_id INT NOT NULL DEFAULT 0,
                //            parent_wbs_id INT NOT NULL DEFAULT 0,
                //            code VARCHAR(50) NOT NULL DEFAULT '',
                //            name VARCHAR(250) NOT NULL DEFAULT '',
                //            description VARCHAR(500) DEFAULT '',
                //            status VARCHAR(50) NOT NULL DEFAULT 'Active',
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_activity_master (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            code VARCHAR(50) NOT NULL DEFAULT '',
                //            name VARCHAR(250) NOT NULL DEFAULT '',
                //            uom VARCHAR(20) DEFAULT '',
                //            category VARCHAR(100) DEFAULT '',
                //            status VARCHAR(50) NOT NULL DEFAULT 'Active',
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_activity_master (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            code VARCHAR(50) NOT NULL DEFAULT '',
                //            name VARCHAR(250) NOT NULL DEFAULT '',
                //            uom VARCHAR(20) DEFAULT '',
                //            category VARCHAR(100) DEFAULT '',
                //            status VARCHAR(50) NOT NULL DEFAULT 'Active',
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                //query = @" USE " + dbName + @";
                //        CREATE TABLE IF NOT EXISTS tbl_project_planning_details (
                //            id INT NOT NULL AUTO_INCREMENT,
                //            planning_id INT NOT NULL DEFAULT 0,
                //            project_id INT NOT NULL DEFAULT 0,
                //            site_id INT NOT NULL DEFAULT 0,
                //            zone_id INT NOT NULL DEFAULT 0,
                //            wbs_id INT NOT NULL DEFAULT 0,
                //            tender_id INT NOT NULL DEFAULT 0,
                //            boq_item_id INT NOT NULL DEFAULT 0,
                //            activity_id INT NOT NULL DEFAULT 0,
                //            activity_name VARCHAR(250) NOT NULL DEFAULT '',
                //            start_date DATE DEFAULT NULL,
                //            end_date DATE DEFAULT NULL,
                //            duration_days INT NOT NULL DEFAULT 0,
                //            planned_qty DECIMAL(20,4) NOT NULL DEFAULT 0,
                //            completed_qty DECIMAL(20,4) NOT NULL DEFAULT 0,
                //            balance_qty DECIMAL(20,4) NOT NULL DEFAULT 0,
                //            planned_daily_qty DECIMAL(20,4) NOT NULL DEFAULT 0,
                //            rate DECIMAL(20,4) NOT NULL DEFAULT 0,
                //            planned_amount DECIMAL(20,4) NOT NULL DEFAULT 0,
                //            progress DECIMAL(10,2) NOT NULL DEFAULT 0,
                //            status VARCHAR(50) NOT NULL DEFAULT 'Planned',
                //            PRIMARY KEY (id)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                //        ";
                //DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS `tbl_project_wbs` (
                          `id`           INT NOT NULL AUTO_INCREMENT,
                          `project_id`   INT NOT NULL DEFAULT 0,
                          `parent_wbs_id`INT NOT NULL DEFAULT 0,   -- 0 = root level
                          `code`         VARCHAR(50)  NOT NULL DEFAULT '',
                          `name`         VARCHAR(300) NOT NULL DEFAULT '',
                          `wbs_level`    INT NOT NULL DEFAULT 1,
                          `description`  VARCHAR(500) DEFAULT '',
                          `is_active`    TINYINT(1)   NOT NULL DEFAULT 1,
                          `created_by`   INT NOT NULL DEFAULT 0,
                          `created_at`   DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
                          PRIMARY KEY (`id`),
                          UNIQUE KEY `uq_wbs_code` (`project_id`, `code`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_phase_templates (
                            template_id INT AUTO_INCREMENT PRIMARY KEY,
                            phase_no INT NOT NULL,                -- 1,2,3
                            phase_name VARCHAR(200) NOT NULL,     -- Phase 1, Phase 2, Phase 3
                            sort_order INT NOT NULL DEFAULT 0,
                            is_active TINYINT(1) NOT NULL DEFAULT 1
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_phase_task_templates (
                            task_template_id INT AUTO_INCREMENT PRIMARY KEY,
                            template_id INT NOT NULL,
                            task_name VARCHAR(300) NOT NULL,
                            sort_order INT NOT NULL DEFAULT 0,
                            is_mandatory TINYINT(1) NOT NULL DEFAULT 1,
                            is_active TINYINT(1) NOT NULL DEFAULT 1,
                            FOREIGN KEY (template_id) REFERENCES tbl_project_phase_templates(template_id)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_phase_tasks (
                            task_id INT AUTO_INCREMENT PRIMARY KEY,
                            phase_id INT NOT NULL,
                            task_template_id INT NULL,
                            task_name VARCHAR(300) NOT NULL,
                            is_required TINYINT(1) NOT NULL DEFAULT 1,
                            is_completed TINYINT(1) NOT NULL DEFAULT 0,
                            completed_on DATETIME NULL,
                            completed_by INT NULL,
                            remarks VARCHAR(500) DEFAULT NULL,
                            attachment_path VARCHAR(500) DEFAULT NULL,
                            status VARCHAR(50) NOT NULL DEFAULT 'Pending',
                            sort_order INT NOT NULL DEFAULT 0,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            FOREIGN KEY (phase_id) REFERENCES tbl_eng_project_phases(phase_id)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_stages (
                            stage_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            stage_no INT NOT NULL,
                            stage_name VARCHAR(200) NOT NULL,
                            status VARCHAR(50) NOT NULL DEFAULT 'Pending',
                            start_date DATE NULL,
                            end_date DATE NULL,
                            completed_on DATETIME NULL,
                            is_current TINYINT(1) DEFAULT 0,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_notifications (
                            notification_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_id INT NULL,
                            task_id INT NULL,
                            user_id INT NULL, -- null = all employees
                            title VARCHAR(250) NOT NULL,
                            message VARCHAR(1000) NOT NULL,
                            notification_type VARCHAR(50) NOT NULL, -- Info, Warning, Alert, Success
                            is_read TINYINT(1) NOT NULL DEFAULT 0,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_activity_log (
                            log_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_id INT NULL,
                            task_id INT NULL,
                            activity_type VARCHAR(100) NOT NULL,   -- StatusUpdate, PhaseCompleted, DelayWarning, etc.
                            old_value VARCHAR(250) DEFAULT NULL,
                            new_value VARCHAR(250) DEFAULT NULL,
                            remarks VARCHAR(500) DEFAULT NULL,
                            created_by INT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE tbl_notification_users (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            notification_id INT NOT NULL,
                            user_id INT NOT NULL,
                            is_read TINYINT(1) DEFAULT 0,
                            read_at DATETIME NULL,
                            FOREIGN KEY (notification_id) REFERENCES tbl_notifications(notification_id)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE INDEX idx_projects_search ON tbl_projects (owner_name, plot_number, basin_number, municipality_project_no, bank_project_no);
                        CREATE INDEX idx_phase_project ON tbl_eng_project_phases (project_id);
                        CREATE INDEX idx_task_phase ON tbl_project_phase_tasks (phase_id);
                        CREATE INDEX idx_stage_project ON tbl_project_stages (project_id);
                        CREATE INDEX idx_notifications_project ON tbl_notifications (project_id, is_read);";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE tbl_project_files (
                            file_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            engineer_id INT NOT NULL,
                            file_name VARCHAR(250),
                            file_path VARCHAR(500),
                            file_type VARCHAR(50),
                            description VARCHAR(500),
                            status VARCHAR(50) DEFAULT 'Pending',
                            uploaded_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE tbl_project_classification (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            name_ar VARCHAR(200) NOT NULL,
                            name_en VARCHAR(200) NOT NULL,
                            is_active TINYINT(1) DEFAULT 1,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_form_configuration (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            form_name VARCHAR(100) NOT NULL,
                            affect_stock TINYINT(1) DEFAULT 0,
                            affect_account TINYINT(1) DEFAULT 0,
                            is_active TINYINT(1) DEFAULT 1,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_planning_new
                        (
                            plan_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            planning_no VARCHAR(30),
                            plan_date DATE,
                            start_date DATE,
                            end_date DATE,
                            total_days INT,
                            planning_engineer VARCHAR(100),
                            work_hours DECIMAL(10,2),
                            weekly_off VARCHAR(30),
                            priority_level VARCHAR(30),
                            progress_percent DECIMAL(10,2),
                            status VARCHAR(30),
                            milestone VARCHAR(200),
                            notes VARCHAR(350),
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_planning_new
                        (
                            plan_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            planning_no VARCHAR(30),
                            plan_date DATE,
                            start_date DATE,
                            end_date DATE,
                            total_days INT,
                            planning_engineer VARCHAR(100),
                            work_hours DECIMAL(10,2),
                            weekly_off VARCHAR(30),
                            priority_level VARCHAR(30),
                            progress_percent DECIMAL(10,2),
                            status VARCHAR(30),
                            milestone VARCHAR(200),
                            notes VARCHAR(350),
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_lookahead
                        (
                            look_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            week_no INT,
                            from_date DATE,
                            to_date DATE,
                            activity_name VARCHAR(200),
                            zone_name VARCHAR(100),
                            responsible_person VARCHAR(100),
                            required_material VARCHAR(200),
                            required_labor INT,
                            required_equipment VARCHAR(200),
                            priority_level VARCHAR(30),
                            status VARCHAR(30),
                            remarks VARCHAR(350),
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_resource_needs
                        (
                            resource_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            request_date DATE NOT NULL,
                            need_type VARCHAR(30) NOT NULL,      -- Labor / Material / Equipment
                            category_name VARCHAR(100),          -- Mason / Cement / Excavator
                            item_name VARCHAR(150),
                            unit_name VARCHAR(30),
                            qty DECIMAL(18,2) NOT NULL,
                            required_from DATE,
                            required_to DATE,
                            priority_level VARCHAR(20),
                            zone_name VARCHAR(100),
                            requested_by VARCHAR(100),
                            approved_by VARCHAR(100),
                            status VARCHAR(30),                  -- Draft/Pending/Approved/Issued/Closed
                            remarks VARCHAR(350),
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_site_activity_plan
                        (
                            activity_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            activity_date DATE NOT NULL,
                            zone_id INT NULL,
                            zone_name VARCHAR(100),
                            activity_name VARCHAR(200) NOT NULL,
                            supervisor_name VARCHAR(100),
                            labor_count INT DEFAULT 0,
                            equipment_used VARCHAR(200),
                            target_qty DECIMAL(18,2) DEFAULT 0,
                            unit_name VARCHAR(30),
                            actual_qty DECIMAL(18,2) DEFAULT 0,
                            progress_percent DECIMAL(10,2) DEFAULT 0,
                            weather_status VARCHAR(50),
                            priority_level VARCHAR(30),
                            status VARCHAR(30),
                            remarks VARCHAR(350),
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_reservation
                        (
                            reservation_id INT AUTO_INCREMENT PRIMARY KEY,
                            reservation_no VARCHAR(30) NOT NULL,
                            reservation_date DATE NOT NULL,
                            mr_id INT NULL,
                            project_id INT NOT NULL,
                            warehouse_id INT NOT NULL,
                            reserved_by INT NOT NULL,
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_reservation_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            reservation_id INT NOT NULL,
                            item_id INT NOT NULL,
                            requested_qty DECIMAL(18,4) DEFAULT 0,
                            available_qty DECIMAL(18,4) DEFAULT 0,
                            reserved_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_project_team 
                        (
                            team_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            emp_code VARCHAR(50) NOT NULL,
                            emp_name VARCHAR(150) NOT NULL,
                            role_name VARCHAR(100) NOT NULL,
                            zone_id INT NOT NULL,
                            mobile VARCHAR(30),
                            join_date DATE NOT NULL,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_procurement_request
                        (
                            pr_id INT AUTO_INCREMENT PRIMARY KEY,
                            pr_no VARCHAR(30) NOT NULL,
                            pr_date DATE NOT NULL,
                            mr_id INT NULL,
                            reservation_id INT NULL,
                            project_id INT NOT NULL,
                            supplier_id INT NULL,
                            priority_level VARCHAR(30) DEFAULT 'Normal',
                            required_date DATE NULL,
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            approved_by INT NULL,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_procurement_request_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            pr_id INT NOT NULL,
                            item_id INT NOT NULL,
                            requested_qty DECIMAL(18,4) DEFAULT 0,
                            ordered_qty DECIMAL(18,4) DEFAULT 0,
                            pending_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            est_rate DECIMAL(18,4) DEFAULT 0,
                            est_amount DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_issue
                        (
                            issue_id INT AUTO_INCREMENT PRIMARY KEY,
                            issue_no VARCHAR(30) NOT NULL,
                            issue_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            warehouse_id INT NOT NULL,
                            reservation_id INT NULL,
                            requested_by INT NULL,
                            issued_to INT NULL,
                            approved_by INT NULL,
                            zone_id INT NULL,
                            purpose VARCHAR(150),
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_issue_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            issue_id INT NOT NULL,
                            item_id INT NOT NULL,
                            reserved_qty DECIMAL(18,4) DEFAULT 0,
                            available_qty DECIMAL(18,4) DEFAULT 0,
                            issue_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            unit_cost DECIMAL(18,4) DEFAULT 0,
                            line_total DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_receipt
                        (
                            receipt_id INT AUTO_INCREMENT PRIMARY KEY,
                            receipt_no VARCHAR(30) NOT NULL,
                            receipt_date DATE NOT NULL,
                            po_id INT NULL,
                            supplier_id INT NULL,
                            project_id INT NULL,
                            warehouse_id INT NOT NULL,
                            invoice_no VARCHAR(50),
                            invoice_date DATE NULL,
                            received_by INT NULL,
                            checked_by INT NULL,
                            vehicle_no VARCHAR(50),
                            driver_name VARCHAR(100),
                            status VARCHAR(30) DEFAULT 'Draft',
                            subtotal DECIMAL(18,4) DEFAULT 0,
                            vat_amount DECIMAL(18,4) DEFAULT 0,
                            net_amount DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(500),
                            created_by INT,
                            approved_by INT NULL,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_receipt_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            receipt_id INT NOT NULL,
                            item_id INT NOT NULL,
                            ordered_qty DECIMAL(18,4) DEFAULT 0,
                            received_qty DECIMAL(18,4) DEFAULT 0,
                            accepted_qty DECIMAL(18,4) DEFAULT 0,
                            rejected_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            unit_cost DECIMAL(18,4) DEFAULT 0,
                            line_total DECIMAL(18,4) DEFAULT 0,
                            batch_no VARCHAR(50),
                            expiry_date DATE NULL,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_return
                        (
                            return_id INT AUTO_INCREMENT PRIMARY KEY,
                            return_no VARCHAR(30) NOT NULL,
                            return_date DATE NOT NULL,
                            issue_id INT NULL,
                            project_id INT NOT NULL,
                            from_warehouse_id INT NOT NULL,
                            to_warehouse_id INT NOT NULL,
                            returned_by INT NULL,
                            received_by INT NULL,
                            approved_by INT NULL,
                            return_type VARCHAR(30) DEFAULT 'Site Return',
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_return_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            return_id INT NOT NULL,
                            item_id INT NOT NULL,
                            issued_qty DECIMAL(18,4) DEFAULT 0,
                            return_qty DECIMAL(18,4) DEFAULT 0,
                            damaged_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            unit_cost DECIMAL(18,4) DEFAULT 0,
                            line_total DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_transfer
                        (
                            transfer_id INT AUTO_INCREMENT PRIMARY KEY,
                            transfer_no VARCHAR(30) NOT NULL,
                            transfer_date DATE NOT NULL,
                            transfer_type VARCHAR(30) DEFAULT 'Warehouse Transfer',
                            from_warehouse_id INT NOT NULL,
                            to_warehouse_id INT NOT NULL,
                            from_project_id INT NULL,
                            to_project_id INT NULL,
                            requested_by INT NULL,
                            approved_by INT NULL,
                            received_by INT NULL,
                            vehicle_no VARCHAR(50),
                            driver_name VARCHAR(100),
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_transfer_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            transfer_id INT NOT NULL,
                            item_id INT NOT NULL,
                            available_qty DECIMAL(18,4) DEFAULT 0,
                            transfer_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            unit_cost DECIMAL(18,4) DEFAULT 0,
                            line_total DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_consumption
                        (
                            consumption_id INT AUTO_INCREMENT PRIMARY KEY,
                            consumption_no VARCHAR(30) NOT NULL,
                            consumption_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            zone_id INT NULL,
                            activity_id INT NULL,
                            wbs_id INT NULL,
                            warehouse_id INT NOT NULL,
                            consumed_by INT NULL,
                            approved_by INT NULL,
                            consumption_type VARCHAR(30) DEFAULT 'Site Consumption',
                            reference_no VARCHAR(50),
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);
                
                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_material_consumption_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            consumption_id INT NOT NULL,
                            item_id INT NOT NULL,
                            available_qty DECIMAL(18,4) DEFAULT 0,
                            consumed_qty DECIMAL(18,4) DEFAULT 0,
                            wastage_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(30),
                            unit_cost DECIMAL(18,4) DEFAULT 0,
                            line_total DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_stock_reconciliation
                        (
                            reconciliation_id INT AUTO_INCREMENT PRIMARY KEY,
                            reconciliation_no VARCHAR(30) NOT NULL,
                            reconciliation_date DATE NOT NULL,
                            warehouse_id INT NOT NULL,
                            project_id INT NULL,
                            reconciliation_type VARCHAR(30) DEFAULT 'Periodic',
                            checked_by INT NULL,
                            approved_by INT NULL,
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_stock_reconciliation_item
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            reconciliation_id INT NOT NULL,
                            item_id INT NOT NULL,
                            system_qty DECIMAL(18,4) DEFAULT 0,
                            physical_qty DECIMAL(18,4) DEFAULT 0,
                            variance_qty DECIMAL(18,4) DEFAULT 0,
                            adjustment_type VARCHAR(20),
                            uom VARCHAR(30),
                            unit_cost DECIMAL(18,4) DEFAULT 0,
                            variance_value DECIMAL(18,4) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_entry
                        (
                            entry_id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_no VARCHAR(30) NOT NULL,
                            entry_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            supervisor_id INT NULL,
                            engineer_id INT NULL,
                            shift_type VARCHAR(20),
                            weather VARCHAR(50),
                            overall_progress DECIMAL(10,2) DEFAULT 0,
                            status VARCHAR(20) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_activity
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            wbs_id INT NULL,
                            activity_id INT NULL,
                            planned_qty DECIMAL(18,4) DEFAULT 0,
                            actual_qty DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(20),
                            progress_percent DECIMAL(10,2) DEFAULT 0,
                            status VARCHAR(20),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_labour
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            employee_id INT NULL,
                            trade_name VARCHAR(50),
                            attendance VARCHAR(20),
                            ot_hours DECIMAL(10,2) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_equipment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            equipment_id INT NULL,
                            start_hour DECIMAL(10,2) DEFAULT 0,
                            end_hour DECIMAL(10,2) DEFAULT 0,
                            working_hours DECIMAL(10,2) DEFAULT 0,
                            fuel_used DECIMAL(10,2) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_material
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            item_id INT NULL,
                            qty_used DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(20),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_issue
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            issue_type VARCHAR(50),
                            description VARCHAR(500),
                            impact_level VARCHAR(20),
                            action_taken VARCHAR(500)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_progress
                        (
                            progress_id INT AUTO_INCREMENT PRIMARY KEY,
                            progress_no VARCHAR(30) NOT NULL,
                            progress_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            prepared_by INT NULL,
                            approved_by INT NULL,
                            planned_progress DECIMAL(10,2) DEFAULT 0,
                            actual_progress DECIMAL(10,2) DEFAULT 0,
                            variance_progress DECIMAL(10,2) DEFAULT 0,
                            overall_status VARCHAR(30),
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_progress_activity
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            progress_id INT NOT NULL,
                            wbs_id INT NULL,
                            activity_id INT NULL,
                            activity_name VARCHAR(250),
                            unit VARCHAR(20),
                            planned_qty DECIMAL(18,4) DEFAULT 0,
                            actual_qty DECIMAL(18,4) DEFAULT 0,
                            cumulative_qty DECIMAL(18,4) DEFAULT 0,
                            planned_percent DECIMAL(10,2) DEFAULT 0,
                            actual_percent DECIMAL(10,2) DEFAULT 0,
                            variance_percent DECIMAL(10,2) DEFAULT 0,
                            manpower_count INT DEFAULT 0,
                            equipment_count INT DEFAULT 0,
                            status VARCHAR(30),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_progress_delay
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            progress_id INT NOT NULL,
                            delay_type VARCHAR(100),
                            delay_reason VARCHAR(500),
                            affected_activity VARCHAR(250),
                            impact_days DECIMAL(10,2) DEFAULT 0,
                            corrective_action VARCHAR(500)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_progress_photo
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            progress_id INT NOT NULL,
                            photo_path VARCHAR(500),
                            description VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_work_measurement
                        (
                            measurement_id INT AUTO_INCREMENT PRIMARY KEY,
                            measurement_no VARCHAR(30) NOT NULL,
                            measurement_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            contractor_id INT NULL,
                            engineer_id INT NULL,
                            consultant_id INT NULL,
                            reference_type VARCHAR(50),
                            reference_no VARCHAR(50),
                            total_qty DECIMAL(18,4) DEFAULT 0,
                            total_amount DECIMAL(18,2) DEFAULT 0,
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_work_measurement_details
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            measurement_id INT NOT NULL,
                            boq_id INT NULL,
                            wbs_id INT NULL,
                            activity_id INT NULL,
                            item_code VARCHAR(50),
                            description VARCHAR(500),
                            unit VARCHAR(20),
                            boq_qty DECIMAL(18,4) DEFAULT 0,
                            previous_qty DECIMAL(18,4) DEFAULT 0,
                            current_qty DECIMAL(18,4) DEFAULT 0,
                            cumulative_qty DECIMAL(18,4) DEFAULT 0,
                            balance_qty DECIMAL(18,4) DEFAULT 0,
                            rate DECIMAL(18,4) DEFAULT 0,
                            amount DECIMAL(18,2) DEFAULT 0,
                            progress_percent DECIMAL(10,2) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_work_measurement_attachment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            measurement_id INT NOT NULL,
                            file_path VARCHAR(500),
                            description VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_work_measurement_approval
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            measurement_id INT NOT NULL,
                            approval_level VARCHAR(50),
                            approved_by INT,
                            approval_date DATETIME,
                            status VARCHAR(30),
                            remarks VARCHAR(500)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_resource_deployment
                        (
                            deployment_id INT AUTO_INCREMENT PRIMARY KEY,
                            deployment_no VARCHAR(30) NOT NULL,
                            deployment_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            deployment_type VARCHAR(30),
                            requested_by INT NULL,
                            approved_by INT NULL,
                            start_date DATE NULL,
                            end_date DATE NULL,
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_resource_deployment_details
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            deployment_id INT NOT NULL,
                            resource_type VARCHAR(30),
                            resource_id INT NULL,
                            resource_name VARCHAR(250),
                            wbs_id INT NULL,
                            activity_id INT NULL,
                            planned_qty DECIMAL(18,4) DEFAULT 0,
                            deployed_qty DECIMAL(18,4) DEFAULT 0,
                            unit VARCHAR(20),
                            deployment_days DECIMAL(10,2) DEFAULT 0,
                            cost_per_day DECIMAL(18,2) DEFAULT 0,
                            total_cost DECIMAL(18,2) DEFAULT 0,
                            utilization_percent DECIMAL(10,2) DEFAULT 0,
                            status VARCHAR(30),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_resource_deployment_movement
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            deployment_id INT NOT NULL,
                            movement_date DATETIME,
                            from_location VARCHAR(250),
                            to_location VARCHAR(250),
                            moved_by INT NULL,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_resource_deployment_attachment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            deployment_id INT NOT NULL,
                            file_path VARCHAR(500),
                            description VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_equipment_usage
                        (
                            usage_id INT AUTO_INCREMENT PRIMARY KEY,
                            usage_no VARCHAR(30) NOT NULL,
                            usage_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            operator_id INT NULL,
                            shift_type VARCHAR(20),
                            weather VARCHAR(50),
                            total_working_hours DECIMAL(10,2) DEFAULT 0,
                            total_fuel_used DECIMAL(18,2) DEFAULT 0,
                            total_cost DECIMAL(18,2) DEFAULT 0,
                            status VARCHAR(30) DEFAULT 'Draft',
                            remarks VARCHAR(500),
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_equipment_usage_details
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            usage_id INT NOT NULL,
                            equipment_id INT NULL,
                            equipment_code VARCHAR(50),
                            equipment_name VARCHAR(250),
                            activity_id INT NULL,
                            start_hour_meter DECIMAL(18,2) DEFAULT 0,
                            end_hour_meter DECIMAL(18,2) DEFAULT 0,
                            working_hours DECIMAL(18,2) DEFAULT 0,
                            idle_hours DECIMAL(18,2) DEFAULT 0,
                            breakdown_hours DECIMAL(18,2) DEFAULT 0,
                            fuel_used DECIMAL(18,2) DEFAULT 0,
                            fuel_rate DECIMAL(18,2) DEFAULT 0,
                            fuel_cost DECIMAL(18,2) DEFAULT 0,
                            operator_cost DECIMAL(18,2) DEFAULT 0,
                            rental_cost DECIMAL(18,2) DEFAULT 0,
                            total_cost DECIMAL(18,2) DEFAULT 0,
                            utilization_percent DECIMAL(10,2) DEFAULT 0,
                            status VARCHAR(30),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_equipment_breakdown
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            usage_id INT NOT NULL,
                            equipment_id INT NULL,
                            breakdown_time DATETIME,
                            resume_time DATETIME,
                            breakdown_reason VARCHAR(500),
                            corrective_action VARCHAR(500),
                            maintenance_required VARCHAR(10)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_equipment_fuel_log
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            usage_id INT NOT NULL,
                            equipment_id INT NULL,
                            fuel_date DATETIME,
                            fuel_qty DECIMAL(18,2),
                            fuel_rate DECIMAL(18,2),
                            amount DECIMAL(18,2),
                            fuel_station VARCHAR(250),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report
                        (
                            report_id INT AUTO_INCREMENT PRIMARY KEY,
                            report_no VARCHAR(30) NOT NULL,
                            report_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            engineer_id INT NULL,
                            weather VARCHAR(50),
                            temperature DECIMAL(10,2) DEFAULT 0,
                            manpower_count INT DEFAULT 0,
                            equipment_count INT DEFAULT 0,
                            visitors_count INT DEFAULT 0,
                            total_progress_percent DECIMAL(10,2) DEFAULT 0,
                            safety_incidents INT DEFAULT 0,
                            delay_hours DECIMAL(10,2) DEFAULT 0,
                            overall_status VARCHAR(30) DEFAULT 'Normal',
                            remarks VARCHAR(1000),
                            prepared_by INT NULL,
                            approved_by INT NULL,
                            status VARCHAR(30) DEFAULT 'Draft',
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report_activity
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            activity_id INT NULL,
                            activity_name VARCHAR(250),
                            location VARCHAR(250),
                            work_description VARCHAR(1000),
                            planned_qty DECIMAL(18,4) DEFAULT 0,
                            completed_qty DECIMAL(18,4) DEFAULT 0,
                            unit VARCHAR(20),
                            progress_percent DECIMAL(10,2) DEFAULT 0,
                            manpower_used INT DEFAULT 0,
                            equipment_used INT DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report_labour
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            trade_name VARCHAR(100),
                            manpower_count INT DEFAULT 0,
                            overtime_hours DECIMAL(10,2) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report_equipment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            equipment_name VARCHAR(250),
                            working_hours DECIMAL(10,2) DEFAULT 0,
                            idle_hours DECIMAL(10,2) DEFAULT 0,
                            breakdown_hours DECIMAL(10,2) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report_material
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            material_name VARCHAR(250),
                            qty_used DECIMAL(18,4) DEFAULT 0,
                            unit VARCHAR(20),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report_delay
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            delay_reason VARCHAR(500),
                            affected_activity VARCHAR(250),
                            delay_hours DECIMAL(10,2) DEFAULT 0,
                            corrective_action VARCHAR(500)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_site_report_visitor
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            visitor_name VARCHAR(250),
                            company_name VARCHAR(250),
                            purpose VARCHAR(500),
                            visit_time DATETIME
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_delay_hindrance
                        (
                            delay_id INT AUTO_INCREMENT PRIMARY KEY,
                            delay_no VARCHAR(30) NOT NULL,
                            delay_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            reported_by INT NULL,
                            delay_category VARCHAR(100),
                            severity VARCHAR(50),
                            affected_area VARCHAR(250),
                            affected_activity VARCHAR(250),
                            start_datetime DATETIME,
                            end_datetime DATETIME,
                            total_delay_hours DECIMAL(18,2) DEFAULT 0,
                            responsible_party VARCHAR(100),
                            weather_condition VARCHAR(100),
                            impact_description VARCHAR(500),
                            corrective_action VARCHAR(500),
                            preventive_action VARCHAR(500),
                            estimated_cost_impact DECIMAL(18,2) DEFAULT 0,
                            extension_days DECIMAL(18,2) DEFAULT 0,
                            status VARCHAR(30) DEFAULT 'Open',
                            remarks VARCHAR(500),
                            approved_by INT NULL,
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_delay_attachment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            delay_id INT NOT NULL,
                            file_name VARCHAR(500),
                            file_path VARCHAR(500),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_delay_followup
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            delay_id INT NOT NULL,
                            followup_date DATE,
                            action_taken VARCHAR(200),
                            responsible_person VARCHAR(250),
                            target_date DATE,
                            status VARCHAR(50),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_vehicle
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code INT NOT NULL DEFAULT 0,
                            customer_id INT NOT NULL,
                            plate_no VARCHAR(30),
                            chassis_no VARCHAR(50),
                            vin_no VARCHAR(50),
                            engine_no VARCHAR(50),
                            make VARCHAR(100),
                            model VARCHAR(100),
                            variant VARCHAR(100),
                            model_year INT,
                            color VARCHAR(50),
                            transmission VARCHAR(30),
                            fuel_type VARCHAR(30),
                            current_mileage INT,
                            registration_expiry DATE,
                            insurance_expiry DATE,
                            warranty_expiry DATE,
                            notes TEXT,
                            active INT DEFAULT 1,
                            created_by INT,
                            created_date DATE,
                            state INT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_job_card
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(50) DEFAULT '0',
                            customer_id INT NOT NULL,
                            vehicle_id INT NOT NULL,
                            advisor_id INT,
                            job_date DATE,
                            expected_delivery DATE,
                            mileage INT,
                            fuel_type VARCHAR(20),
                            priority VARCHAR(20),
                            complaint TEXT,
                            diagnosis TEXT,
                            work_required TEXT,
                            remarks TEXT,
                            estimated_amount DECIMAL(20,4),
                            approved_amount DECIMAL(20,4),
                            quotation_id INT DEFAULT 0,
                            sales_order_id INT DEFAULT 0,
                            invoice_id INT DEFAULT 0,
                            status VARCHAR(30),
                            active INT DEFAULT 1,
                            created_by INT,
                            created_date DATE,
                            state INT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_job_card_parts
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            jobcard_id INT,
                            item_id INT,
                            warehouse_id INT,
                            qty DECIMAL(18,3),
                            issued_qty DECIMAL(18,3),
                            returned_qty DECIMAL(18,3),
                            unit_price DECIMAL(20,4),
                            discount DECIMAL(20,4),
                            vatP INT,
                            vat DECIMAL(20,4),
                            charge DECIMAL(20,4),
                            total DECIMAL(20,4),
                            remarks TEXT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_job_card_labor
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            jobcard_id INT,
                            employee_id INT,
                            labor_name VARCHAR(200),
                            estimated_hours DECIMAL(10,2),
                            actual_hours DECIMAL(10,2),
                            hourly_rate DECIMAL(20,4),
                            total DECIMAL(20,4),
                            status VARCHAR(30),
                            remarks TEXT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_vehicle_inspection
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            jobcard_id INT,
                            engine_oil TINYINT,
                            brake_oil TINYINT,
                            coolant TINYINT,
                            battery TINYINT,
                            tyres TINYINT,
                            brake_pads TINYINT,
                            steering TINYINT,
                            suspension TINYINT,
                            lights TINYINT,
                            horn TINYINT,
                            wiper TINYINT,
                            ac TINYINT,
                            interior TINYINT,
                            exterior TINYINT,
                            remarks TEXT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_vehicle_damage
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            jobcard_id INT,
                            damage_location VARCHAR(100),
                            damage_type VARCHAR(100),
                            severity VARCHAR(30),
                            remarks TEXT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_job_status_history
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            jobcard_id INT,
                            status VARCHAR(30),
                            employee_id INT,
                            remarks TEXT,
                            status_date DATETIME
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_service_package
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code INT,
                            package_name VARCHAR(200),
                            description TEXT,
                            amount DECIMAL(20,4),
                            active INT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_service_package_items
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            package_id INT,
                            item_id INT,
                            qty DECIMAL(18,3)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_service_package_labor
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            package_id INT,
                            labor_name VARCHAR(200),
                            hours DECIMAL(10,2),
                            rate DECIMAL(20,4)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_job_qc
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            jobcard_id INT,
                            checked_by INT,
                            road_test TINYINT,
                            leak_check TINYINT,
                            warning_lights TINYINT,
                            final_cleaning TINYINT,
                            remarks TEXT,
                            approved TINYINT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_site_diary
                        (
                            diary_id INT AUTO_INCREMENT PRIMARY KEY,
                            diary_no VARCHAR(30) NOT NULL,
                            diary_date DATE NOT NULL,
                            project_id INT NOT NULL,
                            site_id INT NULL,
                            zone_id INT NULL,
                            engineer_id INT NULL,
                            weather VARCHAR(100),
                            work_done VARCHAR(1000),
                            visitors VARCHAR(500),
                            issues VARCHAR(1000),
                            remarks VARCHAR(1000),
                            status VARCHAR(30) DEFAULT 'Draft',
                            approved_by INT NULL,
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";

                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                    CREATE TABLE IF NOT EXISTS tbl_daily_work_plan
                    (
                        workplan_id INT AUTO_INCREMENT PRIMARY KEY,
                        workplan_no VARCHAR(30) NOT NULL,
                        plan_date DATE NOT NULL,
                        project_id INT NOT NULL,
                        site_id INT NULL,
                        zone_id INT NULL,
                        engineer_id INT NULL,
                        supervisor_id INT NULL,
                        work_location VARCHAR(250),
                        work_description VARCHAR(1000),
                        planned_start_time TIME,
                        planned_end_time TIME,
                        priority VARCHAR(50),
                        status VARCHAR(30) DEFAULT 'Planned',
                        remarks VARCHAR(1000),
                        approved_by INT NULL,
                        created_by INT,
                        created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";
                DBClass.ExecuteNonQuery(query);

                query = @" USE " + dbName + @";
                        CREATE TABLE IF NOT EXISTS tbl_daily_work_plan_details
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            workplan_id INT NOT NULL,
                            activity VARCHAR(250),
                            location VARCHAR(250),
                            planned_qty DECIMAL(18,2) DEFAULT 0,
                            unit VARCHAR(50),
                            assigned_to VARCHAR(250),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                /****************************************/

                query = @" USE " + dbName + @";
                        INSERT INTO tbl_form_configuration (form_name, affect_stock, affect_account)
                        VALUES
                        -- PURCHASE
                        ('Material Request', 0, 0),
                        ('Purchase Order', 0, 0),
                        ('Purchase', 1, 1),
                        ('Purchase Return', 1, 1),
                        -- SALES
                        ('Sales Quotation', 0, 0),
                        ('Sales Proforma', 0, 0),
                        ('Sales Order', 0, 0),
                        ('Sales', 1, 1),
                        ('Sales Return', 1, 1),
                        -- FINANCIAL
                        ('Receipt Voucher', 0, 1),
                        ('Payment Voucher', 0, 1),
                        ('Advance Payment Voucher', 0, 1);
                        ";
                DBClass.ExecuteNonQuery(query);

                // Step 4: Execute all your table creation queries
                query = @" USE " + dbName + @";
                INSERT INTO `tbl_company` ( `name`, `descriptions`, `phone1`, `phone2`, `gmail`, `mobile_number`, `website`, `address`, `trn_no`, `logoComp`) VALUES
	                ( '" + txtcompany.Text.Trim() + "', '" + txtdescription.Text.Trim() + "', '" + txtphone1.Text.Trim() + "','','" + txtemail.Text.Trim() + "', '', '', '', '', NULL); ";
                DBClass.ExecuteNonQuery(query);
                string salt = "";
                DBClass.ExecuteNonQuery(@" USE " + dbName + @";insert into tbl_sec_users (user_name,passwordhash,salt,emp_id,first_name,last_name,role_id,active,state)values 
                                         (@user_name,@passwordhash,@salt,@emp_id,@first_name,@last_name,@role_id,@active,0)",
                  DBClass.CreateParameter("user_name", guna2TextBox3.Text),
                  DBClass.CreateParameter("passwordhash", PasswordHelper.HashPassword(guna2TextBox4.Text, out salt)),
                    DBClass.CreateParameter("emp_id", 0),
                    DBClass.CreateParameter("first_name", guna2TextBox3.Text),
                    DBClass.CreateParameter("salt", salt),
                    DBClass.CreateParameter("last_name", ""),
                    DBClass.CreateParameter("role_id", 1),
                    DBClass.CreateParameter("active", 0));

                string customerCode = Environment.GetEnvironmentVariable("yamy_company_code", EnvironmentVariableTarget.User);

                object resultId = DBClass.ExecuteScalar("USE " + dbName + "; SELECT id FROM tbl_sec_users ORDER BY id DESC LIMIT 1");

                int recordId = 0;
                if (resultId != null && resultId != DBNull.Value)
                    recordId = Convert.ToInt32(resultId);

                if (recordId > 0)
                {
                    DBClass.ExecuteNonQuery(@"USE " + dbName + @";
                        INSERT INTO `tbl_user_permissions` (`user_id`, `sub_menu_id`, `can_view`, `can_edit`, `can_delete`) VALUES
	                        (@last_user_id, 1, 1, 1, 1),
	                        (@last_user_id, 2, 1, 1, 1),
	                        (@last_user_id, 3, 1, 1, 1),
	                        (@last_user_id, 4, 1, 1, 1),
	                        (@last_user_id, 5, 1, 1, 1),
	                        (@last_user_id, 0, 1, 1, 1),
	                        (@last_user_id, 7, 1, 1, 1),
	                        (@last_user_id, 8, 1, 1, 1),
	                        (@last_user_id, 9, 1, 1, 1),
	                        (@last_user_id, 10, 1, 1, 1),
	                        (@last_user_id, 11, 1, 1, 1),
	                        (@last_user_id, 12, 1, 1, 1),
	                        (@last_user_id, 13, 1, 1, 1),
	                        (@last_user_id, 14, 1, 1, 1),
	                        (@last_user_id, 15, 1, 1, 1),
	                        (@last_user_id, 16, 1, 1, 1),
	                        (@last_user_id, 17, 1, 1, 1),
	                        (@last_user_id, 18, 1, 1, 1),
	                        (@last_user_id, 19, 1, 1, 1),
	                        (@last_user_id, 20, 1, 1, 1),
	                        (@last_user_id, 21, 1, 1, 1),
	                        (@last_user_id, 22, 1, 1, 1),
	                        (@last_user_id, 23, 1, 0, 0),
	                        (@last_user_id, 24, 1, 0, 0),
	                        (@last_user_id, 25, 1, 1, 1),
	                        (@last_user_id, 26, 1, 1, 1),
	                        (@last_user_id, 27, 1, 1, 1),
	                        (@last_user_id, 28, 1, 1, 1),
	                        (@last_user_id, 29, 1, 1, 1),
	                        (@last_user_id, 30, 1, 0, 0),
	                        (@last_user_id, 31, 1, 0, 0),
	                        (@last_user_id, 32, 1, 0, 0),
	                        (@last_user_id, 33, 1, 1, 1),
	                        (@last_user_id, 34, 1, 1, 1),
	                        (@last_user_id, 36, 1, 0, 1),
	                        (@last_user_id, 37, 1, 1, 1),
	                        (@last_user_id, 38, 1, 0, 0),
	                        (@last_user_id, 39, 1, 0, 0),
	                        (@last_user_id, 40, 1, 0, 0),
	                        (@last_user_id, 41, 1, 0, 0),
	                        (@last_user_id, 42, 1, 0, 0),
	                        (@last_user_id, 43, 1, 0, 0),
	                        (@last_user_id, 44, 1, 0, 0),
	                        (@last_user_id, 45, 1, 0, 0),
	                        (@last_user_id, 46, 1, 0, 0),
	                        (@last_user_id, 47, 1, 0, 0),
	                        (@last_user_id, 48, 1, 0, 0),
	                        (@last_user_id, 49, 1, 0, 0),
	                        (@last_user_id, 50, 1, 0, 0),
	                        (@last_user_id, 51, 1, 0, 0),
	                        (@last_user_id, 52, 1, 0, 0),
	                        (@last_user_id, 53, 1, 0, 0),
	                        (@last_user_id, 54, 1, 0, 0),
	                        (@last_user_id, 55, 1, 0, 0),
	                        (@last_user_id, 6, 1, 1, 1),
	                        (@last_user_id, 56, 1, 0, 0),
	                        (@last_user_id, 57, 1, 0, 0),
	                        (@last_user_id, 58, 1, 0, 0),
	                        (@last_user_id, 59, 1, 0, 0);",DBClass.CreateParameter("last_user_id", recordId));
                }
                query = @"USE yamycompany ;
                    INSERT INTO `tbl_company` (
                        `database_name`, `name`, `code`, `descriptions`,
                        `phone1`, `phone2`, `gmail`, `mobile_number`,
                        `website`, `address`, `trn_no`, `logoComp`,
                        `default_company`,`customer_code`
                    )
                    VALUES (
                        '" + dbName + "', '" + txtcompany.Text.Trim() + "','" + dbcode + "', '" + txtdescription.Text.Trim() + "', '" + txtphone1.Text.Trim() + "','','" + txtemail.Text.Trim() + "', '', '', '' , '' , NULL,' " + (guna2CustomCheckBox1.Checked ? 1 : 0) + "','"+ customerCode + "'); ";
                
                DBClass.ExecuteNonQuery(query);

                //INSERT INTO tbl_project_phase_templates(phase_no, phase_name, sort_order) VALUES
                //(1, 'Phase 1', 1),
                //(2, 'Phase 2', 2),
                //(3, 'Phase 3', 3);

                //INSERT INTO tbl_project_phase_task_templates(template_id, task_name, sort_order) VALUES
                //(1, '2D proposals submitted and approved by owner', 1),
                //(1, '3D proposals submitted and approved by owner', 2),
                //(1, 'Opening project file with municipality', 3),
                //(1, 'Soil testing', 4);

                //INSERT INTO tbl_project_phase_task_templates(template_id, task_name, sort_order) VALUES
                //(2, 'Municipality approval of architectural and structural drawings', 1),
                //(2, 'Interior design and decoration drawings', 2),
                //(2, 'Tender drawings (architectural + services)', 3),
                //(2, 'Project pricing file and contractor selection', 4),
                //(2, 'Project file in bank', 5);

                //INSERT INTO tbl_project_phase_task_templates(template_id, task_name, sort_order) VALUES
                //(3, 'Project execution on site', 1),
                //(3, 'Modification of drawings during execution', 2),
                //(3, 'Completion of execution and project handover', 3);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLearnMore_Click(object sender, EventArgs e)
        {
            string url = "https://yamyco.co/yamy-software";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // This is required for .NET Core and .NET 5+
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening link: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmCompanyList().Show();
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmCompanyList().Show();

        }


    }
}
