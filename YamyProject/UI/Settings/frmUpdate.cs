using CrystalDecisions.Shared.Json;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
            headerUC1.FormText = "Database Update";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                        CREATE TABLE IF NOT EXISTS `tbl_project_sites` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `location_id` int DEFAULT '0',
                          `plot_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          `address` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
                          PRIMARY KEY (`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @"
                CREATE TABLE IF NOT EXISTS `tbl_project_tender` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `date` date NOT NULL,
                          `tender_name_id` int NOT NULL DEFAULT '0',
                          `account_id` int NOT NULL DEFAULT '0',
                          `project_id` int NOT NULL DEFAULT '0',
                          `fees` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `submission_date` date NOT NULL,
                          `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `tender_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `description` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `warehouse_id` int NOT NULL DEFAULT '0',
                          `created_by` int NOT NULL DEFAULT '0',
                          `created_date` date DEFAULT NULL,
                          `modified_by` int DEFAULT '0',
                          `modified_date` date DEFAULT NULL,
                          `amount` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `bid_amount` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `state` int NOT NULL DEFAULT '0',
                          `contractor_id` int NOT NULL DEFAULT '0',
	                      `estimate_status` INT(10) NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS `tbl_project_tender_details` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `sr` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `tender_id` int NOT NULL DEFAULT '0',
                          `item_id` varchar(350) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
                          `qty` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `unit_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                          `rate` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `amount` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `margin_percentage` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `margin_amount` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `total` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `progress` decimal(20, 4) NOT NULL DEFAULT '0.0000',
                          `assigned` int DEFAULT NULL,
                          `start_date` date DEFAULT NULL,
                          `end_date` date DEFAULT NULL,
	                      `length` DECIMAL(20, 4) NOT NULL DEFAULT '0.0000',
	                      `width` DECIMAL(20, 4) NOT NULL DEFAULT '0.0000',
	                      `thickness` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                      `note` VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                          PRIMARY KEY (`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_audit_log (
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
                        ;";

                DBClass.ExecuteNonQuery(query);

                //query = @"
                //        CREATE TABLE IF NOT EXISTS `tbl_sub_contract` (
                //          `id` int NOT NULL AUTO_INCREMENT,
                //          `code` int NOT NULL DEFAULT '0',
                //          `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `Cat_id` int DEFAULT NULL,
                //          `Balance` decimal(20,4) DEFAULT NULL,
                //          `date` date DEFAULT NULL,
                //          `main_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `work_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `mobile` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `ccemail` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `website` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `country` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `city` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `region` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `building_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `account_id` int DEFAULT NULL,
                //          `trn` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `facilty_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
                //          `active` int DEFAULT NULL,
                //          `created_by` int DEFAULT NULL,
                //          `created_date` date DEFAULT NULL,
                //          `state` int DEFAULT NULL,
                //          PRIMARY KEY (`id`)
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
                //DBClass.ExecuteNonQuery(query);
                //query = @"

                //        CREATE TABLE IF NOT EXISTS `tbl_sub_contract_category` (
                //          `id` int NOT NULL AUTO_INCREMENT,
                //          `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '0',
                //          PRIMARY KEY (`id`) USING BTREE
                //        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
                //DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS `tbl_tender_names` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
                          `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
                          PRIMARY KEY (`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS `tbl_contractor` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `name` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	                        `country_id` INT(10) NULL DEFAULT NULL,
	                        PRIMARY KEY (`id`) USING BTREE
                        ) COLLATE = 'utf8mb4_general_ci' ENGINE = InnoDB;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS `tbl_project_material_requests` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `tender_id` INT(10) NOT NULL DEFAULT '0',
	                        `planning_id` INT(10) NOT NULL DEFAULT '0',
	                        `RequestedDate` DATE NULL DEFAULT NULL,
	                        `IssuedDate` DATE NULL DEFAULT NULL,
	                        `ReceivedDate` DATE NULL DEFAULT NULL,
	                        `itemId` INT(10) NOT NULL DEFAULT '0',
	                        `unit` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	                        `RequestedQty` DECIMAL(10, 2) NOT NULL DEFAULT '0.00',
                            `IssuedQty` DECIMAL(10, 2) NOT NULL DEFAULT '0.00',
                            `ReceivedQty` DECIMAL(10, 2) NOT NULL DEFAULT '0.00',
	                        PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS tbl_project_resource (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `code` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            `date` date DEFAULT NULL,
                            `name` VARCHAR(200) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            `role` INT(10) NOT NULL DEFAULT '0',
                            `phone` VARCHAR(20) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            `type` VARCHAR(80) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	                        `price_unit` DECIMAL(20, 4) NOT NULL DEFAULT '0.0000',
	                        `unit_time` DECIMAL(20, 4) NOT NULL DEFAULT '0.0000',
	                        `max_unit_time` DECIMAL(20, 4) NOT NULL DEFAULT '0.0000',
							`employee_id` INT,
                  PRIMARY KEY(`id`)
                        );";

                DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS tbl_project_role (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    code VARCHAR(50) NOT NULL UNIQUE COLLATE 'utf8mb4_general_ci',
                    name VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci'
                        );";

                DBClass.ExecuteNonQuery(query);

                query = @"

                        CREATE TABLE IF NOT EXISTS tbl_project_activity (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            planning_id INT NOT NULL DEFAULT(0),
                            code VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            name VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
                            start_date DATE NOT NULL,
                            end_date DATE NOT NULL,
                            progress DECIMAL(20,2) NOT NULL DEFAULT '0.000',
                            status VARCHAR(50) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci'
                        );";

                DBClass.ExecuteNonQuery(query);

                query = @"

                CREATE TABLE IF NOT EXISTS `tbl_project_work_done` (
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
                        COLLATE='utf8mb4_0900_ai_ci' ENGINE=InnoDB;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                        CREATE TABLE IF NOT EXISTS `tbl_project_work_done_details` (
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
                        COLLATE='utf8mb4_0900_ai_ci' ENGINE=InnoDB;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                        CREATE TABLE IF NOT EXISTS tbl_project_activity_assignment (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            activity_id INT NOT NULL,
                            resource_id INT NOT NULL
                        ); ";

                DBClass.ExecuteNonQuery(query);

                query = @"

                        CREATE TABLE IF NOT EXISTS `tbl_manufacturer_batch` (
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
                        ENGINE=InnoDB;";

                DBClass.ExecuteNonQuery(query);

                query = @"

                        CREATE TABLE IF NOT EXISTS `tbl_manufacturer_batchdetails` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `batchID` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
	                        `itemid` INT(10) NULL DEFAULT NULL,
	                        `cost` DECIMAL(63,2) NULL DEFAULT NULL,
	                        `qty` INT(10) NULL DEFAULT NULL,
	                        `Total` DECIMAL(63,2) NULL DEFAULT NULL,
	                        PRIMARY KEY (`id`) USING BTREE
                        )
                        COLLATE='utf8mb4_0900_ai_ci'
                        ENGINE=InnoDB;";

                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS `tbl_color` (
	                        `id` INT NOT NULL AUTO_INCREMENT,
	                        `headerColor` VARCHAR(50) NOT NULL DEFAULT 'RoyalBlue',
	                        `TextColor` VARCHAR(50) NOT NULL DEFAULT 'White',
	                        PRIMARY KEY (`id`)
                        )
                        COLLATE='utf8mb4_general_ci';
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_deleted_records (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            table_name VARCHAR(100),
                            record_data TEXT,
                            deleted_by INT,
                            deleted_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_petty_cash(
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
                        ";
                DBClass.ExecuteNonQuery(query);

                DBClass.ExecuteNonQuery(@"
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

                DBClass.ExecuteNonQuery(@"
                    CREATE TABLE IF NOT EXISTS tbl_reconciliation_item (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        reconciliation_id INT NOT NULL,
                        transaction_id INT NOT NULL,
                        amount DECIMAL(18,4) NOT NULL,
                        cleared_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (reconciliation_id) REFERENCES tbl_reconciliation(id)
                    ) ENGINE=InnoDB;
                ");

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_petty_cash_details(
                            id int NOT NULL AUTO_INCREMENT,
                            petty_cash_id INT NOT NULL,
                            entry_date DATE NOT NULL,
                            ref_id VARCHAR(100) NULL,
                            hum_id INT NOT NULL,
                            hum_name VARCHAR(300) NOT NULL DEFAULT '',
                            category INT(10) NOT NULL DEFAULT '0',
                            cost_center_id INT NOT NULL,
                            description TEXT NULL,
                            amount decimal(20,6) DEFAULT 0,
                            vatP decimal(20,6) DEFAULT 0,
                            vat int DEFAULT 0,
                            total DECIMAL(20,4) NOT NULL DEFAULT 0,
                            project_id INT(10) NOT NULL DEFAULT '0',
                            note TEXT NULL,
                            PRIMARY KEY (`id`)
                        );
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS `tbl_item_serial` (
                            `id` INT(10) NOT NULL AUTO_INCREMENT,
                            `item_id` INT(10) NOT NULL,
                            `serial_number` VARCHAR(100) NOT NULL,
                            `transaction_id` INT(10) NULL DEFAULT NULL, -- optional: link to purchase or sale
                            `status` VARCHAR(50) NOT NULL DEFAULT 'Available', -- Available / Sold / Returned
                            `warehouse_id` INT(10) NOT NULL DEFAULT 0,
                            `created_date` DATE NOT NULL,
                            PRIMARY KEY (`id`),
                            UNIQUE KEY `unique_serial` (`serial_number`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"-- Modify column
                        ALTER TABLE tbl_items 
                        MODIFY COLUMN name VARCHAR(500) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"ALTER TABLE tbl_coa_config ADD UNIQUE KEY uq_category (category);";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_coa_level_1 ADD COLUMN category_code VARCHAR(50);";
                DBClass.ExecuteNonQuery(query);

                query = @"ALTER TABLE tbl_set_main_menu ADD COLUMN status INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase_details CHANGE COLUMN sales_id purchase_id INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase_order_details CHANGE COLUMN sales_id purchase_id INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase_return_details CHANGE COLUMN sales_id purchase_id INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_bank_card ADD COLUMN company_ac INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_company ADD COLUMN country_id INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_company ADD COLUMN `stampComp` longblob;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE yamycompany.tbl_company ADD COLUMN `stampComp` longblob;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_item_transaction ADD COLUMN warehouse_id INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_item_transaction MODIFY description VARCHAR(250);";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_tender ADD COLUMN estimate_status INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_activity CHANGE COLUMN activity_id id int NOT NULL AUTO_INCREMENT;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_activity ADD COLUMN progress DECIMAL(20,3) NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_activity ADD COLUMN status VARCHAR(50) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_vendor ADD COLUMN `type` VARCHAR(200) NULL DEFAULT 'Vendor' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_Projects ADD COLUMN `category` VARCHAR(250) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `description` VARCHAR(500) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `emirate` VARCHAR(500) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `type` VARCHAR(500) NULL DEFAULT 'Project' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `start_date` date DEFAULT NULL;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `end_date` date DEFAULT NULL;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `extend_delay` date DEFAULT NULL;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `country_id` int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `city_id` int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `execution_period_months` int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `customer` int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `area` varchar(250) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `plot_number` varchar(50) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `block` varchar(50) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `contract_value` decimal(18,3) NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `additional_value` decimal(18,3) NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `deduction_value` decimal(18,3) NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `total_value` decimal(18,3) NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `contact_person` varchar(150) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `contact_person_number` varchar(50) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `contractor` varchar(500) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `consultant` varchar(500) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `location` varchar(500) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `details` varchar(500) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `billed_to_date` decimal(15,2) DEFAULT 0";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `expenses` decimal(15,2) DEFAULT 0";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `balance` decimal(15,2) DEFAULT 0";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN part_no VARCHAR(100) DEFAULT ''";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP;
                          ALTER TABLE tbl_projects ADD COLUMN updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_planning ADD COLUMN `subcontractor_account_id` int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_planning ADD COLUMN `retention_account_id` int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_planning ADD COLUMN `retention_percentage` DECIMAL(18,2) NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase ADD COLUMN `reference_no` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase_order ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase_return ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_purchase_return ADD COLUMN `purchase_ref_id` INT NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_sales ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_sales_order ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_sales_proforma ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_sales_quotation ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_sales_return ADD COLUMN `description` VARCHAR(300) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_sales_return ADD COLUMN `sales_ref_id` INT(10) NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash ADD COLUMN amount decimal(20,6) DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash ADD COLUMN vat decimal(20,6) DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash_details ADD COLUMN `hum_name` VARCHAR(300) NOT NULL DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash_details ADD COLUMN amount decimal(20,6) DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash_details ADD COLUMN vat int DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash_details ADD COLUMN vatP decimal(20,6) DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_petty_cash_details ADD COLUMN total decimal(20,6) DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects ADD COLUMN `status` VARCHAR(50) DEFAULT 'Planned' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects_site_setup add COLUMN `zone_id` INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects_site_setup add COLUMN `wbs_id` INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects_site_setup add COLUMN `cost_code_id` INT NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects_site_setup add COLUMN `package_code` varchar(50) DEFAULT 'PG-0';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_projects_site_setup add COLUMN `package_name` varchar(250) DEFAULT '';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_project_sites add COLUMN project_id int NOT NULL DEFAULT '0';";
                DBClass.ExecuteNonQuery(query);
                query = @"INSERT INTO tbl_general_settings (name, value, description, status)
                        SELECT 'PROJECT OPTION', 0, '', 0
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbl_general_settings WHERE name = 'PROJECT OPTION'
                        );";
                DBClass.ExecuteNonQuery(query);
                query = @"INSERT INTO tbl_general_settings (name, value, description, status)
                        SELECT 'ENABLE PETTYCASH APPROVAL', 0, '', 0
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbl_general_settings WHERE name = 'ENABLE PETTYCASH APPROVAL'
                        );";
                DBClass.ExecuteNonQuery(query);
                query = @"INSERT INTO tbl_general_settings (name, value, description, status)
                        SELECT 'ENABLE BARCODE', 0, '', 0
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbl_general_settings WHERE name = 'ENABLE BARCODE'
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"ALTER TABLE tbl_vendor ADD COLUMN `project_site` VARCHAR(150) DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);
                query = @"ALTER TABLE tbl_customer ADD COLUMN `project_site` VARCHAR(150) DEFAULT '' COLLATE 'utf8mb4_general_ci';";
                DBClass.ExecuteNonQuery(query);

                query = @"-- Create table if not exists
                        CREATE TABLE IF NOT EXISTS tbl_user (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(50) NOT NULL,
                            name VARCHAR(255) NOT NULL,
                            active TINYINT DEFAULT 1
                        );

                        -- Add 'length' column if not exists
                        SET @col_exists = (
                            SELECT COUNT(*) 
                            FROM INFORMATION_SCHEMA.COLUMNS 
                            WHERE table_schema = DATABASE() 
                              AND table_name = 'tbl_items_boq' 
                              AND column_name = 'length'
                        );

                        SET @sql = IF(@col_exists = 0,
                                      'ALTER TABLE tbl_items_boq ADD COLUMN `length` DECIMAL(20,2) NULL DEFAULT NULL;',
                                      'SELECT ""length column already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;

                        -- Add 'width' column if not exists
                        SET @col_exists = (
                            SELECT COUNT(*) 
                            FROM INFORMATION_SCHEMA.COLUMNS 
                            WHERE table_schema = DATABASE() 
                              AND table_name = 'tbl_items_boq' 
                              AND column_name = 'width'
                        );

                        SET @sql = IF(@col_exists = 0,
                                      'ALTER TABLE tbl_items_boq ADD COLUMN `width` DECIMAL(10,2) NULL DEFAULT NULL;',
                                      'SELECT ""width column already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;

                        -- Add 'thickness' column if not exists
                        SET @col_exists = (
                            SELECT COUNT(*) 
                            FROM INFORMATION_SCHEMA.COLUMNS 
                            WHERE table_schema = DATABASE() 
                              AND table_name = 'tbl_items_boq' 
                              AND column_name = 'thickness'
                        );

                        SET @sql = IF(@col_exists = 0,
                                      'ALTER TABLE tbl_items_boq ADD COLUMN `thickness` VARCHAR(50) NULL DEFAULT NULL COLLATE utf8mb4_general_ci;',
                                      'SELECT ""thickness column already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;

                        -- Add 'note' column if not exists
                        SET @col_exists = (
                            SELECT COUNT(*) 
                            FROM INFORMATION_SCHEMA.COLUMNS 
                            WHERE table_schema = DATABASE() 
                              AND table_name = 'tbl_items_boq' 
                              AND column_name = 'note'
                        );

                        SET @sql = IF(@col_exists = 0,
                                      'ALTER TABLE tbl_items_boq ADD COLUMN `note` VARCHAR(500) NULL DEFAULT NULL COLLATE utf8mb4_general_ci;',
                                      'SELECT ""note column already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;
                        ";

                DBClass.ExecuteNonQuery(query);
                query = @"-- Add 'length' column if it does not exist
                        SET @exists := (SELECT COUNT(*) 
                                        FROM INFORMATION_SCHEMA.COLUMNS 
                                        WHERE TABLE_NAME = 'tbl_project_tender_details' 
                                        AND COLUMN_NAME = 'length'
                                        AND TABLE_SCHEMA = DATABASE());
                
                        SET @sql := IF(@exists = 0, 
                                       'ALTER TABLE tbl_project_tender_details ADD COLUMN `length` DECIMAL(20,2) NULL DEFAULT NULL;',
                                       'SELECT ""Column length already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;


                        -- Add 'width' column if it does not exist
                        SET @exists := (SELECT COUNT(*) 
                                        FROM INFORMATION_SCHEMA.COLUMNS 
                                        WHERE TABLE_NAME = 'tbl_project_tender_details' 
                                        AND COLUMN_NAME = 'width'
                                        AND TABLE_SCHEMA = DATABASE());
                
                        SET @sql := IF(@exists = 0, 
                                       'ALTER TABLE tbl_project_tender_details ADD COLUMN `width` DECIMAL(10,2) NULL DEFAULT NULL;',
                                       'SELECT ""Column width already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;


                        -- Add 'thickness' column if it does not exist
                        SET @exists := (SELECT COUNT(*) 
                                        FROM INFORMATION_SCHEMA.COLUMNS 
                                        WHERE TABLE_NAME = 'tbl_project_tender_details' 
                                        AND COLUMN_NAME = 'thickness'
                                        AND TABLE_SCHEMA = DATABASE());

                        SET @sql := IF(@exists = 0, 
                                       'ALTER TABLE tbl_project_tender_details ADD COLUMN `thickness` VARCHAR(50) NULL DEFAULT NULL COLLATE ''utf8mb4_general_ci'';',
                                       'SELECT ""Column thickness already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;


                        -- Add 'note' column if it does not exist
                        SET @exists := (SELECT COUNT(*) 
                                        FROM INFORMATION_SCHEMA.COLUMNS 
                                        WHERE TABLE_NAME = 'tbl_project_tender_details' 
                                        AND COLUMN_NAME = 'note'
                                        AND TABLE_SCHEMA = DATABASE());

                        SET @sql := IF(@exists = 0, 
                                       'ALTER TABLE tbl_project_tender_details ADD COLUMN `note` VARCHAR(500) NULL DEFAULT NULL COLLATE ''utf8mb4_general_ci'';',
                                       'SELECT ""Column note already exists"";');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;
                        ";

                DBClass.ExecuteNonQuery(query);
                query = @"CREATE TABLE IF NOT EXISTS tbl_error_log (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            procedure_name VARCHAR(255),
                            error_message TEXT,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            user_id INT
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_labor_attendance (
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
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_Manufacturing_Steps (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(20) NOT NULL,
                            step_name VARCHAR(100) NOT NULL,
                            description VARCHAR(500),
                            step_order INT NOT NULL,
                            is_completed TINYINT(1) DEFAULT 0,
                            created_by INT,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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
                        );
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_eng_project_phases (
                            phase_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            phase_name VARCHAR(200) NOT NULL,
                            start_date DATE NOT NULL,
                            end_date DATE DEFAULT NULL,
                            weight_percentage DECIMAL(5,2) NOT NULL DEFAULT 0.00,
                            status VARCHAR(50) NOT NULL,
                            created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_crm_leads (
                            lead_id INT AUTO_INCREMENT PRIMARY KEY,
                            source VARCHAR(200),
                            created_date DATE,
                            assigned_to INT,
                            status VARCHAR(50)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_kpi_comments (
                            comment_id INT AUTO_INCREMENT PRIMARY KEY,
                            result_id INT,
                            commented_by INT,
                            comment TEXT,
                            commented_at DATETIME
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_kpi_periods (
                            period_month INT,
                            period_year INT,
                            is_locked TINYINT(1) DEFAULT 0,
                            locked_at DATETIME,
                            PRIMARY KEY (period_month, period_year)
                        ) ENGINE=InnoDB;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_kpi_score_band (
                            band_id INT AUTO_INCREMENT PRIMARY KEY,
                            min_pct DECIMAL(5,2),
                            max_pct DECIMAL(5,2),
                            score_pct DECIMAL(5,2)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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


                query = @"
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

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_material_request (
                            mr_id INT AUTO_INCREMENT PRIMARY KEY,
                            mr_no VARCHAR(50) NOT NULL UNIQUE,
                            request_date DATE NOT NULL,
                            requested_by INT NOT NULL,        -- link to tbl_users / employee
                            department_id INT NOT NULL,       -- link to tbl_department
                            status ENUM('Draft','Submitted','Approved','Rejected') DEFAULT 'Draft',
                            remarks VARCHAR(250) default(''),
                            created_by INT NULL,           -- link to tbl_attachments
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_material_request_item (
                            mr_item_id INT AUTO_INCREMENT PRIMARY KEY,
                            mr_id INT NOT NULL,                 
                            item_id INT NOT NULL,               
                            required_qty DECIMAL(18,2) NOT NULL,
                            uom VARCHAR(10) NOT NULL default(''),           
                            expected_date DATE NULL,
                            status ENUM('Pending','Ordered','Received') DEFAULT 'Pending',
                            remarks VARCHAR(250) default(''),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_material_received (
                            mr_id INT AUTO_INCREMENT PRIMARY KEY,
                            mr_no VARCHAR(50) NOT NULL UNIQUE,
                            mr_date DATE NOT NULL,
                            po_id INT NOT NULL default 0,
                            vendor_id INT NOT NULL,
                            status VARCHAR(20) DEFAULT 'Partial',
                            remarks VARCHAR(250) default(''),
                            created_by INT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS tbl_material_received_item (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            mr_id INT NOT NULL,
                            po_item_id INT NOT NULL,
                            ordered_qty DECIMAL(18,2) NOT NULL, 
                            received_qty DECIMAL(18,2) NOT NULL,
                            uom VARCHAR(10) NOT NULL default(''),
                            status VARCHAR(20) DEFAULT 'Partial',
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
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

                query = @"
                        CREATE TABLE IF NOT EXISTS `tbl_projects_accounts` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` VARCHAR(3250) NOT NULL DEFAULT '',
                          `project_id` INT(10) NOT NULL DEFAULT '0',
                          `account_id` INT(10) NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"ALTER TABLE tbl_eng_project_milestones
                        ADD COLUMN percentage DECIMAL(5,2) DEFAULT 0,
                        ADD COLUMN amount DECIMAL(18,3) DEFAULT 0;
                        ";
                DBClass.ExecuteNonQuery(query);

                query = @"
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
                            account_id INT NOT NULL DEFAULT 0,
                            cost_center_id INT NOT NULL DEFAULT 0,
                            payment_status VARCHAR(100) NOT NULL,
                            description VARCHAR(500) NOT NULL DEFAULT '',
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

                query = @"  ALTER TABLE tbl_projects_invoices ADD COLUMN retention_amount decimal(20,6) NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"  ALTER TABLE tbl_projects_invoices ADD COLUMN retention_percentage decimal(20,6) NOT NULL DEFAULT 0; ";
                DBClass.ExecuteNonQuery(query);
                query = @"  ALTER TABLE tbl_projects_invoices ADD COLUMN deduction decimal(20,6) NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"  ALTER TABLE tbl_projects_invoices add advance_amount decimal(20,6) NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"  ALTER TABLE tbl_projects_invoices add advance_percentage decimal(20,6) NOT NULL DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);
                query = @"  ALTER TABLE tbl_position
                            ADD AnnualLeaveDays INT DEFAULT 30,
                            ADD EOSDaysPerYear INT DEFAULT 0;";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"
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

                query = @"
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
                            `created_at` DATETIME DEFAULT CURRENT_TIMESTAMP,
                            PRIMARY KEY (`id`)
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;";
                DBClass.ExecuteNonQuery(query);

                query = @"
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

                query = @"CREATE TABLE IF NOT EXISTS `tbl_project_resource_assignment` (
	                        `id` INT(10) NOT NULL AUTO_INCREMENT,
	                        `site_setup_id` INT(10) NOT NULL,
	                        `resource_id` INT(10) NOT NULL,
                            `project_id` INT(10) NOT NULL,
                            `tender_id` INT(10) NOT NULL,
	                        PRIMARY KEY (`id`) USING BTREE
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS `tbl_project_zone` (
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

                query = @"
                        CREATE TABLE IF NOT EXISTS `tbl_project_wbs` (
                          `id` INT NOT NULL AUTO_INCREMENT,
                          `site_setup_id` INT NOT NULL DEFAULT 0,
                          `project_id` INT NOT NULL DEFAULT 0,
                          `parent_wbs_id` INT NOT NULL DEFAULT 0,
                          `code` VARCHAR(50) NOT NULL DEFAULT '',
                          `name` VARCHAR(300) NOT NULL DEFAULT '',
                          `wbs_level` INT NOT NULL DEFAULT 1,
                          `description` VARCHAR(500) DEFAULT '',
                          `is_active` TINYINT(1) NOT NULL DEFAULT 1,
                          `created_by` INT NOT NULL DEFAULT 0,
                          `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                          PRIMARY KEY (`id`),
                          UNIQUE KEY `uq_wbs_code_site` (`site_setup_id`, `code`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";
                DBClass.ExecuteNonQuery(query);

                query = @"
                        CREATE TABLE IF NOT EXISTS `tbl_project_activity_plan` (
                          `id` INT NOT NULL AUTO_INCREMENT,
                          `site_setup_id` INT NOT NULL DEFAULT 0,
                          `project_id` INT NOT NULL DEFAULT 0,
                          `wbs_id` INT NOT NULL DEFAULT 0,
                          `activity_code` VARCHAR(50) NOT NULL DEFAULT '',
                          `activity_name` VARCHAR(300) NOT NULL DEFAULT '',
                          `boq_item_id` INT NOT NULL DEFAULT 0,
                          `planned_qty` DECIMAL(18,3) NOT NULL DEFAULT 0,
                          `unit` VARCHAR(50) DEFAULT '',
                          `start_date` DATE DEFAULT NULL,
                          `end_date` DATE DEFAULT NULL,
                          `dependency_activity_id` INT NOT NULL DEFAULT 0,
                          `responsible_resource_id` INT NOT NULL DEFAULT 0,
                          `remarks` VARCHAR(500) DEFAULT '',
                          `status` VARCHAR(50) DEFAULT 'Planned',
                          `created_by` INT NOT NULL DEFAULT 0,
                          `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";
                DBClass.ExecuteNonQuery(query);

                //query = @"
                //        CREATE TABLE IF NOT EXISTS tbl_project_daily_work (
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
                query = @"CREATE TABLE IF NOT EXISTS `tbl_project_wbs` (
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
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";
                DBClass.ExecuteNonQuery(query);

                query = @"ALTER TABLE tbl_projects
                        ADD COLUMN owner_name VARCHAR(250) DEFAULT '' AFTER customer,
                        ADD COLUMN basin_number VARCHAR(50) DEFAULT '' AFTER plot_number,
                        ADD COLUMN municipality_project_no VARCHAR(100) DEFAULT '' AFTER basin_number,
                        ADD COLUMN bank_project_no VARCHAR(100) DEFAULT '' AFTER municipality_project_no,
                        ADD COLUMN project_classification VARCHAR(50) DEFAULT 'Design' AFTER type,
                        ADD COLUMN priority_level INT DEFAULT 0 AFTER project_classification,
                        ADD COLUMN priority_color VARCHAR(20) DEFAULT '' AFTER priority_level,
                        ADD COLUMN is_starred TINYINT(1) DEFAULT 0 AFTER priority_color,
                        ADD COLUMN last_progress_update DATETIME NULL AFTER updated_at,
                        ADD COLUMN handover_date DATE NULL AFTER extend_delay;";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_phase_templates (
                            template_id INT AUTO_INCREMENT PRIMARY KEY,
                            phase_no INT NOT NULL,                -- 1,2,3
                            phase_name VARCHAR(200) NOT NULL,     -- Phase 1, Phase 2, Phase 3
                            sort_order INT NOT NULL DEFAULT 0,
                            is_active TINYINT(1) NOT NULL DEFAULT 1
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_phase_task_templates (
                            task_template_id INT AUTO_INCREMENT PRIMARY KEY,
                            template_id INT NOT NULL,
                            task_name VARCHAR(300) NOT NULL,
                            sort_order INT NOT NULL DEFAULT 0,
                            is_mandatory TINYINT(1) NOT NULL DEFAULT 1,
                            is_active TINYINT(1) NOT NULL DEFAULT 1,
                            FOREIGN KEY (template_id) REFERENCES tbl_project_phase_templates(template_id)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @"ALTER TABLE tbl_eng_project_phases
                        ADD COLUMN template_id INT NULL AFTER project_id,
                        ADD COLUMN phase_no INT NOT NULL DEFAULT 0 AFTER template_id,
                        ADD COLUMN completed_on DATETIME NULL AFTER end_date,
                        ADD COLUMN phase_color VARCHAR(20) DEFAULT 'Gray' AFTER status;";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_phase_tasks (
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
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_stages (
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_notifications (
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_activity_log (
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_notification_users (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            notification_id INT NOT NULL,
                            user_id INT NOT NULL,
                            is_read TINYINT(1) DEFAULT 0,
                            read_at DATETIME NULL,
                            FOREIGN KEY (notification_id) REFERENCES tbl_notifications(notification_id)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE INDEX idx_projects_search ON tbl_projects (owner_name, plot_number, basin_number, municipality_project_no, bank_project_no);
                        CREATE INDEX idx_phase_project ON tbl_eng_project_phases (project_id);
                        CREATE INDEX idx_task_phase ON tbl_project_phase_tasks (phase_id);
                        CREATE INDEX idx_stage_project ON tbl_project_stages (project_id);
                        CREATE INDEX idx_notifications_project ON tbl_notifications (project_id, is_read);";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_files (
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_engineer_activity (
                            activity_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            engineer_id INT NOT NULL,
                            activity_type VARCHAR(100),
                            description TEXT,
                            status VARCHAR(50),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS project_Classification (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            name_ar VARCHAR(200) NOT NULL,
                            name_en VARCHAR(200) NOT NULL,
                            is_active TINYINT(1) DEFAULT 1,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_planning_new
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_lookahead
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_resource_needs
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_schedule
                        (
                            schedule_id INT AUTO_INCREMENT PRIMARY KEY,
                            project_id INT NOT NULL,
                            activity_code VARCHAR(30),
                            activity_name VARCHAR(200),
                            wbs_code VARCHAR(50),
                            predecessor VARCHAR(50),
                            duration_days INT,
                            start_date DATE,
                            end_date DATE,
                            progress_percent DECIMAL(10,2) DEFAULT 0,
                            responsible_person VARCHAR(100),
                            resource_required VARCHAR(200),
                            priority_level VARCHAR(30),
                            status VARCHAR(30),
                            remarks VARCHAR(350),
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_site_activity_plan
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_reservation
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_reservation_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_project_team 
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_procurement_request
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_procurement_request_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_issue
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_issue_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_receipt
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_receipt_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_return
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_return_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_transfer
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_transfer_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_consumption
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_material_consumption_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_stock_reconciliation
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_stock_reconciliation_item
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_site_entry
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_site_activity
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_labour
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_equipment
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_material
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            item_id INT NULL,
                            qty_used DECIMAL(18,4) DEFAULT 0,
                            uom VARCHAR(20),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_issue
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            entry_id INT NOT NULL,
                            issue_type VARCHAR(50),
                            description VARCHAR(500),
                            impact_level VARCHAR(20),
                            action_taken VARCHAR(500)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_progress
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_progress_activity
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_progress_delay
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

                query = @"CREATE TABLE IF NOT EXISTS tbl_daily_progress_photo
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            progress_id INT NOT NULL,
                            photo_path VARCHAR(500),
                            description VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE IF NOT EXISTS tbl_work_measurement
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

                query = @"CREATE TABLE NOT EXISTS tbl_work_measurement_details
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

                query = @"CREATE TABLE NOT EXISTS tbl_work_measurement_attachment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            measurement_id INT NOT NULL,
                            file_path VARCHAR(500),
                            description VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_work_measurement_approval
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

                query = @"CREATE TABLE NOT EXISTS tbl_resource_deployment
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

                query = @"CREATE TABLE NOT EXISTS tbl_resource_deployment_details
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

                query = @"CREATE TABLE NOT EXISTS tbl_resource_deployment_movement
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

                query = @"CREATE TABLE NOT EXISTS tbl_resource_deployment_attachment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            deployment_id INT NOT NULL,
                            file_path VARCHAR(500),
                            description VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_equipment_usage
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

                query = @"CREATE TABLE NOT EXISTS tbl_equipment_usage_details
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

                query = @"CREATE TABLE NOT EXISTS tbl_equipment_breakdown
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

                query = @"CREATE TABLE NOT EXISTS tbl_equipment_fuel_log
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

                query = @"CREATE TABLE NOT EXISTS tbl_daily_site_report
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

                query = @"CREATE TABLE NOT EXISTS tbl_daily_site_report_activity
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

                query = @"CREATE TABLE NOT EXISTS tbl_daily_site_report_labour
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            trade_name VARCHAR(100),
                            manpower_count INT DEFAULT 0,
                            overtime_hours DECIMAL(10,2) DEFAULT 0,
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_daily_site_report_material
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            material_name VARCHAR(250),
                            qty_used DECIMAL(18,4) DEFAULT 0,
                            unit VARCHAR(20),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_daily_site_report_delay
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            delay_reason VARCHAR(500),
                            affected_activity VARCHAR(250),
                            delay_hours DECIMAL(10,2) DEFAULT 0,
                            corrective_action VARCHAR(500)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_daily_site_report_visitor
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            report_id INT NOT NULL,
                            visitor_name VARCHAR(250),
                            company_name VARCHAR(250),
                            purpose VARCHAR(500),
                            visit_time DATETIME
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_delay_hindrance
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
                            impact_description VARCHAR(1000),
                            corrective_action VARCHAR(1000),
                            preventive_action VARCHAR(1000),
                            estimated_cost_impact DECIMAL(18,2) DEFAULT 0,
                            extension_days DECIMAL(18,2) DEFAULT 0,
                            status VARCHAR(30) DEFAULT 'Open',
                            remarks VARCHAR(500),
                            approved_by INT NULL,
                            created_by INT,
                            created_date DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_delay_attachment
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            delay_id INT NOT NULL,
                            file_name VARCHAR(500),
                            file_path VARCHAR(1000),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                query = @"CREATE TABLE NOT EXISTS tbl_delay_followup
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            delay_id INT NOT NULL,
                            followup_date DATE,
                            action_taken VARCHAR(1000),
                            responsible_person VARCHAR(250),
                            target_date DATE,
                            status VARCHAR(50),
                            remarks VARCHAR(250)
                        );";
                DBClass.ExecuteNonQuery(query);

                AlterTablesWithDeviceIds();

                MessageBox.Show("Database Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.ToString());
            }
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {

        }

        private void BtnAlter_Click(object sender, EventArgs e)
        {
            try
            {
                AlterTablesWithDeviceIds();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AlterTablesWithDeviceIds()
        {
            List<string> tables = new List<string>
            {
                "tbl_advance_payment_voucher",
                "tbl_advance_payment_voucher_details",
                "tbl_customer",
                "tbl_items",
                "tbl_item_transaction",
                "tbl_journal_voucher",
                "tbl_journal_voucher_details",
                "tbl_payment_voucher",
                "tbl_payment_voucher_details",
                "tbl_purchase",
                "tbl_purchase_details",
                "tbl_purchase_order",
                "tbl_purchase_order_details",
                "tbl_purchase_return",
                "tbl_purchase_return_details",
                "tbl_receipt_voucher",
                "tbl_receipt_voucher_details",
                "tbl_sales",
                "tbl_sales_details",
                "tbl_transaction",
                "tbl_vendor"
            };


            foreach (string table in tables)
            {
                DBClass.ExecuteNonQuery($@"
                        ALTER TABLE {table}
                        ADD COLUMN GlobalId VARCHAR(50) NULL;
                ");

                DBClass.ExecuteNonQuery($@"
                        UPDATE {table}
                        SET GlobalId = UUID()
                        WHERE GlobalId IS NULL;
                ");
                HashSet<string> skipUniqueKeyTables = new HashSet<string>
                {
                    "tbl_advance_payment_voucher_details",
                    "tbl_item_transaction",
                    "tbl_journal_voucher_details",
                    "tbl_payment_voucher_details",
                    "tbl_purchase_details",
                    "tbl_purchase_order_details",
                    "tbl_purchase_return_details",
                    "tbl_receipt_voucher_details",
                    "tbl_sales_details",
                    "tbl_transaction"
                };

                if (!skipUniqueKeyTables.Contains(table))
                {
                    DBClass.ExecuteNonQuery($@"
                         ALTER TABLE {table}
                         ADD UNIQUE KEY UK_{table}_GlobalId (GlobalId);
                    ");
                }

                DBClass.ExecuteNonQuery($@"
                         ALTER TABLE {table}
                         ADD COLUMN DeviceId varchar(50) DEFAULT '';
                ");

                DBClass.ExecuteNonQuery($@"
                         ALTER TABLE {table}
                         ADD COLUMN LastModified datetime DEFAULT CURRENT_TIMESTAMP;
                ");

                DBClass.ExecuteNonQuery($@"
                         ALTER TABLE {table}
                         ADD COLUMN SyncStatus tinyint NOT NULL DEFAULT 0;
                ");
            }


            DBClass.ExecuteNonQuery(@"ALTER TABLE tbl_purchase ADD COLUMN retention_percentage decimal(20,4) NOT NULL DEFAULT 0");
            DBClass.ExecuteNonQuery(@"ALTER TABLE tbl_purchase ADD COLUMN retention_amount decimal(20,4) NOT NULL DEFAULT 0");

            string query = "select 'a' a";
            query = @"
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

            query = @"
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

            query = @"
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
                            total DECIMAL(20,4),
                            remarks TEXT
                        );";
            DBClass.ExecuteNonQuery(query);

            query = @"
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

            query = @"
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

            query = @"
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

            query = @"
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

            query = @"
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

            query = @"
                        CREATE TABLE IF NOT EXISTS tbl_service_package_items
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            package_id INT,
                            item_id INT,
                            qty DECIMAL(18,3)
                        );";
            DBClass.ExecuteNonQuery(query);

            query = @"
                        CREATE TABLE IF NOT EXISTS tbl_service_package_labor
                        (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            package_id INT,
                            labor_name VARCHAR(200),
                            hours DECIMAL(10,2),
                            rate DECIMAL(20,4)
                        );";
            DBClass.ExecuteNonQuery(query);

            query = @"
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
        }

    }
}