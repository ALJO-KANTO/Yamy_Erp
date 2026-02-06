using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmDataHandler : Form
    {
        public frmDataHandler()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = "Data Handler";
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            DeleteDataWithPasswordPrompt();
        }
        private void DeleteDataWithPasswordPrompt()
        {
            using (var passwordForm = new PasswordPromptForm("Please enter the password to confirm deletion:"))
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    string enteredPassword = passwordForm.EnteredPassword;

                    if (enteredPassword == SecurityConfig.DeveloperPassword)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete all data?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                string query = "";
                                if (ChkAll.Checked)
                                {
                                    query = @"
                                            TRUNCATE TABLE tbl_advance_payment_voucher;
                                            TRUNCATE TABLE tbl_advance_payment_voucher_details;
                                            TRUNCATE TABLE tbl_attendancesheet;
                                            TRUNCATE TABLE tbl_attendance_salary;
                                            TRUNCATE TABLE tbl_bank_card;
                                            TRUNCATE TABLE tbl_bank_register;
                                            TRUNCATE TABLE tbl_bank;
                                            TRUNCATE TABLE tbl_check_details;
                                            TRUNCATE TABLE tbl_cheque;
                                            TRUNCATE TABLE tbl_contractor;
                                            TRUNCATE TABLE tbl_corporate_tax_configration;
                                            TRUNCATE TABLE tbl_cost_center;
                                            TRUNCATE TABLE tbl_cost_center_transaction;
                                            TRUNCATE TABLE tbl_credit_note;
                                            TRUNCATE TABLE tbl_credit_note_details;
                                            TRUNCATE TABLE tbl_crmcustomer;
                                            TRUNCATE TABLE tbl_customer;
                                            TRUNCATE TABLE tbl_customer_category;
                                            TRUNCATE TABLE tbl_damage;
                                            TRUNCATE TABLE tbl_damage_details;
                                            TRUNCATE TABLE tbl_debit_note;
                                            TRUNCATE TABLE tbl_debit_note_details;
                                            TRUNCATE TABLE tbl_departments;
                                            TRUNCATE TABLE tbl_employee;
                                            TRUNCATE TABLE tbl_end_of_service;
                                            TRUNCATE TABLE tbl_final_settlement;
                                            TRUNCATE TABLE tbl_fixed_assets;
                                            TRUNCATE TABLE tbl_fixed_assets_category;
                                            TRUNCATE TABLE tbl_item_assembly;
                                            TRUNCATE TABLE tbl_item_assembly_bos;
                                            TRUNCATE TABLE tbl_item_card_details;
                                            TRUNCATE TABLE tbl_item_category;
                                            TRUNCATE TABLE tbl_item_serial;
                                            TRUNCATE TABLE tbl_item_stock_settlement;
                                            TRUNCATE TABLE tbl_item_stock_settlement_details;
                                            TRUNCATE TABLE tbl_item_transaction;
                                            TRUNCATE TABLE tbl_item_warehouse_transaction;
                                            TRUNCATE TABLE tbl_items;
                                            TRUNCATE TABLE tbl_items_boq;
                                            TRUNCATE TABLE tbl_items_boq_details;
                                            TRUNCATE TABLE tbl_items_unit;
                                            TRUNCATE TABLE tbl_items_warehouse;
                                            TRUNCATE TABLE tbl_journal_voucher;
                                            TRUNCATE TABLE tbl_journal_voucher_details;
                                            TRUNCATE TABLE tbl_labor_attendance;
                                            TRUNCATE TABLE tbl_leave_salary;
                                            TRUNCATE TABLE tbl_loan;
                                            TRUNCATE TABLE tbl_manufacturer_batch;
                                            TRUNCATE TABLE tbl_manufacturer_batchdetails;
                                            TRUNCATE TABLE tbl_manufacturer_task;
                                            TRUNCATE TABLE tbl_manufacturer_task_details;
                                            TRUNCATE TABLE tbl_manufacturing_steps;
                                            TRUNCATE TABLE tbl_payment_voucher;
                                            TRUNCATE TABLE tbl_payment_voucher_details;
                                            TRUNCATE TABLE tbl_petty_cash;
                                            TRUNCATE TABLE tbl_petty_cash_card;
                                            TRUNCATE TABLE tbl_petty_cash_category;
                                            TRUNCATE TABLE tbl_petty_cash_details;
                                            TRUNCATE TABLE tbl_petty_cash_request;
                                            TRUNCATE TABLE tbl_petty_cash_submition;
                                            TRUNCATE TABLE tbl_petty_cash_submition_details;
                                            TRUNCATE TABLE tbl_position;
                                            TRUNCATE TABLE tbl_prepaid_expense;
                                            TRUNCATE TABLE tbl_prepaid_expense_category;
                                            TRUNCATE TABLE tbl_project_activity;
                                            TRUNCATE TABLE tbl_project_activity_assignment;
                                            TRUNCATE TABLE tbl_project_estimate;
                                            TRUNCATE TABLE tbl_project_management;
                                            TRUNCATE TABLE tbl_project_material_requests;
                                            TRUNCATE TABLE tbl_project_plan;
                                            TRUNCATE TABLE tbl_project_planning;
                                            TRUNCATE TABLE tbl_project_resource;
                                            TRUNCATE TABLE tbl_project_role;
                                            TRUNCATE TABLE tbl_project_sites;
                                            TRUNCATE TABLE tbl_project_tender;
                                            TRUNCATE TABLE tbl_project_tender_details;
                                            TRUNCATE TABLE tbl_project_work_done;
                                            TRUNCATE TABLE tbl_project_work_done_details;
                                            TRUNCATE TABLE tbl_projects;
                                            TRUNCATE TABLE tbl_purchase;
                                            TRUNCATE TABLE tbl_purchase_details;
                                            TRUNCATE TABLE tbl_purchase_order;
                                            TRUNCATE TABLE tbl_purchase_order_details;
                                            TRUNCATE TABLE tbl_purchase_return;
                                            TRUNCATE TABLE tbl_purchase_return_details;
                                            TRUNCATE TABLE tbl_receipt_voucher;
                                            TRUNCATE TABLE tbl_receipt_voucher_details;
                                            TRUNCATE TABLE tbl_reconciliation;
                                            TRUNCATE TABLE tbl_reconciliation_item;
                                            TRUNCATE TABLE tbl_rmsdetails;
                                            TRUNCATE TABLE tbl_rmsmain;
                                            TRUNCATE TABLE tbl_rmstables;
                                            TRUNCATE TABLE tbl_salary;
                                            TRUNCATE TABLE tbl_salary_adjustments;
                                            TRUNCATE TABLE tbl_sales;
                                            TRUNCATE TABLE tbl_sales_details;
                                            TRUNCATE TABLE tbl_sales_order;
                                            TRUNCATE TABLE tbl_sales_order_details;
                                            TRUNCATE TABLE tbl_sales_proforma;
                                            TRUNCATE TABLE tbl_sales_proforma_details;
                                            TRUNCATE TABLE tbl_sales_quotation;
                                            TRUNCATE TABLE tbl_sales_quotation_details;
                                            TRUNCATE TABLE tbl_sales_return;
                                            TRUNCATE TABLE tbl_sales_return_details;
                                            TRUNCATE TABLE tbl_sub_contract;
                                            TRUNCATE TABLE tbl_sub_contract_category;
                                            TRUNCATE TABLE tbl_sub_cost_center;
                                            TRUNCATE TABLE tbl_tax;
                                            TRUNCATE TABLE tbl_tender_names;
                                            TRUNCATE TABLE tbl_transaction;
                                            TRUNCATE TABLE tbl_unit;
                                            TRUNCATE TABLE tbl_vat_configration;
                                            TRUNCATE TABLE tbl_vendor;
                                            TRUNCATE TABLE tbl_vendor_category;
                                            TRUNCATE TABLE tbl_warehouse;
                                        ";
                                }
                                else
                                {
                                    if (ChkBoxTables.CheckedItems.Count == 0)
                                    {
                                        MessageBox.Show("Please select at least one table to clear.");
                                        return;
                                    }
                                    else
                                    {
                                        foreach (string item in ChkBoxTables.CheckedItems)
                                        {
                                            if (item == "Advance Payment Voucher")
                                            {
                                                query += "TRUNCATE TABLE tbl_advance_payment_voucher; TRUNCATE TABLE tbl_advance_payment_voucher_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Customer Advance Payment','Vendor Advance Payment');";
                                            }
                                            else if (item == "Attendance Sheet")
                                            {
                                                query += "TRUNCATE TABLE tbl_attendancesheet;";
                                            }
                                            else if (item == "Attendance Salary")
                                            {
                                                query += "TRUNCATE TABLE tbl_attendance_salary;";
                                            }
                                            else if (item == "Bank Card")
                                            {
                                                query += "TRUNCATE TABLE tbl_bank_card;";
                                            }
                                            else if (item == "Bank Register")
                                            {
                                                query += "TRUNCATE TABLE tbl_bank_register;";
                                            }
                                            else if (item == "Bank")
                                            {
                                                query += "TRUNCATE TABLE tbl_bank;";
                                            }
                                            else if (item == "Cheque Details")
                                            {
                                                query += "TRUNCATE TABLE tbl_check_details;";
                                            }
                                            else if (item == "Cheque")
                                            {
                                                query += "TRUNCATE TABLE tbl_cheque;";
                                            }
                                            else if (item == "Corporate Tax Configuration")
                                            {
                                                query += "TRUNCATE TABLE tbl_corporate_tax_configration;";
                                            }
                                            else if (item == "Cost Center")
                                            {
                                                query += "TRUNCATE TABLE tbl_cost_center;";
                                                query += "TRUNCATE TABLE tbl_sub_cost_center;TRUNCATE TABLE tbl_cost_center_transaction;";
                                            }
                                            else if (item == "Credit Note")
                                            {
                                                query += "TRUNCATE TABLE tbl_credit_note; TRUNCATE TABLE tbl_credit_note_details;";
                                                query += "Delete from tbl_transaction where type = 'Credit Note';";
                                            }
                                            else if (item == "Customer")
                                            {
                                                query += "TRUNCATE TABLE tbl_customer;";
                                                query += "Delete from tbl_transaction where type IN ('Sales Invoice','Customer Opening Balance','Customer Receipt','Customer Advance Payment');";
                                            }
                                            else if (item == "Customer Category")
                                            {
                                                query += "TRUNCATE TABLE tbl_customer_category;";
                                            }
                                            else if (item == "Damage")
                                            {
                                                query += "TRUNCATE TABLE tbl_damage; TRUNCATE TABLE tbl_damage_details;";
                                                query += "Delete from tbl_transaction where type = 'Damage Invoice';";
                                            }
                                            else if (item == "Debit Note")
                                            {
                                                query += "TRUNCATE TABLE tbl_debit_note; TRUNCATE TABLE tbl_debit_note_details;";
                                                query += "Delete from tbl_transaction where type = 'Debit Note';";
                                            }
                                            else if (item == "Departments")
                                            {
                                                query += "TRUNCATE TABLE tbl_departments;";
                                            }
                                            else if (item == "Employee")
                                            {
                                                query += "TRUNCATE TABLE tbl_employee;";
                                                query += "Delete from tbl_transaction where type IN ('Employee Opening Balance','Employee Advance Payment','Employee Salary Payment');";
                                            }
                                            else if (item == "End Of Service")
                                            {
                                                query += "TRUNCATE TABLE tbl_end_of_service;";
                                                query += "Delete from tbl_transaction where type = 'End Of Service';";
                                            }
                                            else if (item == "Final Settlement")
                                            {
                                                query += "TRUNCATE TABLE tbl_final_settlement;";
                                                query += "Delete from tbl_transaction where type = 'Final Settlement';";
                                            }
                                            else if (item == "Fixed Assets")
                                            {
                                                query += "TRUNCATE TABLE tbl_fixed_assets;";
                                                query += "DELETE FROM tbl_transaction WHERE type = 'Fixed Assets';";
                                            }
                                            else if (item == "Fixed Assets Category")
                                            {
                                                query += "TRUNCATE TABLE tbl_fixed_assets_category;";
                                            }
                                            //else if (item == "General Config")
                                            //{
                                            //    query += "TRUNCATE TABLE tbl_general_settings;";
                                            //}
                                            else if (item == "Items")
                                            {
                                                query += "TRUNCATE TABLE tbl_items;";
                                                query += "DELETE FROM tbl_transaction WHERE type = 'Opening Qty';";
                                                query += "TRUNCATE TABLE tbl_item_transaction;";
                                            }
                                            else if (item == "Items Unit")
                                            {
                                                query += "TRUNCATE TABLE tbl_items_unit;";
                                            }
                                            else if (item == "Items Warehouse")
                                            {
                                                query += "TRUNCATE TABLE tbl_items_warehouse;";
                                            }
                                            else if (item == "Item Assembly")
                                            {
                                                query += "TRUNCATE TABLE tbl_item_assembly;TRUNCATE TABLE tbl_item_assembly_bos;";
                                            }
                                            else if (item == "Item Category")
                                            {
                                                query += "TRUNCATE TABLE tbl_item_category;";
                                            }
                                            else if (item == "Item Stock Settlement")
                                            {
                                                query += "TRUNCATE TABLE tbl_item_stock_settlement;TRUNCATE TABLE tbl_item_stock_settlement_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type = 'Stock Settlement';";
                                            }
                                            else if (item == "Item BOQ")
                                            {
                                                query += "TRUNCATE TABLE tbl_items_boq;TRUNCATE TABLE tbl_items_boq_details;";
                                            }
                                            else if (item == "Item Serial")
                                            {
                                                query += "TRUNCATE TABLE tbl_item_serial;";
                                            }
                                            else if (item == "journal Voucher")
                                            {
                                                query += "TRUNCATE TABLE tbl_journal_voucher; TRUNCATE TABLE tbl_journal_voucher_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type = 'JOURNAL VOUCHER';";
                                            }
                                            else if (item == "Leave Salary")
                                            {
                                                query += "TRUNCATE TABLE tbl_leave_salary;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Leave Salary');";
                                            }
                                            else if (item == "Loan")
                                            {
                                                query += "TRUNCATE TABLE tbl_loan;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Loan Request');";
                                            }
                                            else if (item == "Labor Attendance")
                                            {
                                                query += "TRUNCATE TABLE tbl_labor_attendance;";
                                            }
                                            else if (item == "Manufacture Batch")
                                            {
                                                query += "TRUNCATE TABLE tbl_manufacturer_batch;TRUNCATE TABLE tbl_manufacturer_batchdetails;";
                                                query += "DELETE FROM tbl_transaction WHERE type = 'Manufacturing';";
                                                query += "DELETE FROM tbl_item_transaction WHERE type = 'Manufacturing';";
                                                query += "DELETE FROM tbl_item_card_details WHERE trans_type='Manufacturing';";
                                            }
                                            else if (item == "Manufacture Task")
                                            {
                                                query += "TRUNCATE TABLE tbl_manufacturer_task;TRUNCATE TABLE tbl_manufacturer_task_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type = 'Manufacturing';";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='Manufacturing';";
                                                query += "DELETE FROM tbl_item_card_details WHERE trans_type='Manufacturing';";
                                            }
                                            else if (item == "Manufacturing Steps")
                                            {
                                                query += "TRUNCATE TABLE tbl_manufacturing_steps;";
                                            }
                                            else if (item == "Manufacture Packing")
                                            {
                                                query += "TRUNCATE TABLE tbl_manufacturer_packing;";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='Manufacture Packing';";
                                            }
                                            else if (item == "Payment")
                                            {
                                                query += "UPDATE tbl_purchase SET pay=0 , `CHANGE`= net WHERE id IN (select inv_id from tbl_payment_voucher_details);";
                                                query += "TRUNCATE TABLE tbl_payment_voucher; TRUNCATE TABLE tbl_payment_voucher_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Payment Voucher','Vendor Payment','Vendor Opening Balance','Vendor Advance Payment','Employee Salary Payment','Employee Petty Cash Payment','Subcontractor Payment','Subcontractor Opening Balance');";
                                            }
                                            else if (item == "Petty Cash Card")
                                            {
                                                query += "TRUNCATE TABLE tbl_petty_cash_card;";
                                            }
                                            else if (item == "Petty Cash")
                                            {
                                                query += "TRUNCATE TABLE tbl_petty_cash;";
                                                query += "TRUNCATE TABLE tbl_petty_cash_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Petty Cash');";
                                            }
                                            else if (item == "petty Cash Category")
                                            {
                                                query += "TRUNCATE TABLE tbl_petty_cash_category;";
                                            }
                                            else if (item == "petty Cash Request")
                                            {
                                                query += "TRUNCATE TABLE tbl_petty_cash_request;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Petty Cash Request');";
                                            }
                                            else if (item == "petty Cash Submission")
                                            {
                                                query += "TRUNCATE TABLE tbl_petty_cash_submition; TRUNCATE TABLE tbl_petty_cash_submition_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Petty Cash Submission',' Petty Cash Submission');";
                                                query += "DELETE FROM tbl_cost_center_transaction WHERE type = 'Petty Cash';";
                                            }
                                            else if (item == "Position")
                                            {
                                                query += "TRUNCATE TABLE tbl_position;";
                                            }
                                            else if (item == "Prepaid Expense")
                                            {
                                                query += "TRUNCATE TABLE tbl_prepaid_expense; TRUNCATE TABLE tbl_prepaid_expense_category;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Prepaid Expense');";
                                            }
                                            else if (item == "Projects")
                                            {
                                                query += "TRUNCATE TABLE tbl_projects;";
                                            }
                                            else if (item == "Project Activity")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_activity;";
                                            }
                                            else if (item == "Project Activity Assignment")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_activity_assignment;";
                                            }
                                            else if (item == "Project Estimate")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_estimate;";
                                            }
                                            else if (item == "Project Management")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_management;";
                                            }
                                            else if (item == "Project Material Requests")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_material_requests;";
                                            }
                                            else if (item == "Project Planning")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_planning;TRUNCATE TABLE tbl_project_plan;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Project Planning');";
                                            }
                                            else if (item == "Project Tender")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_tender;TRUNCATE TABLE tbl_project_tender_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Project Tender');";
                                            }
                                            else if (item == "Project Resource")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_resource;";
                                            }
                                            else if (item == "Project Role")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_role;";
                                            }
                                            else if (item == "Project Sites")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_sites;";
                                            }
                                            else if (item == "Project Work Done")
                                            {
                                                query += "TRUNCATE TABLE tbl_project_work_done;TRUNCATE TABLE tbl_project_work_done_details;";
                                            }
                                            else if (item == "Purchase")
                                            {
                                                query += "TRUNCATE TABLE tbl_purchase; TRUNCATE TABLE tbl_purchase_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Purchase Invoice','Purchase Invoice Cash');";
                                                query += "DELETE FROM tbl_cost_center_transaction WHERE type = 'Purchase';";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='Purchase Invoice';";
                                            }
                                            else if (item == "Purchase Order")
                                            {
                                                query += "TRUNCATE TABLE tbl_purchase_order; TRUNCATE TABLE tbl_purchase_order_details;";
                                            }
                                            else if (item == "Purchase Return")
                                            {
                                                query += "TRUNCATE TABLE tbl_purchase_return; TRUNCATE TABLE tbl_purchase_return_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Purchase Return Invoice','Purchase Return Invoice Cash');";
                                                query += "DELETE FROM tbl_cost_center_transaction WHERE type = 'Purchase Return';";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='Purchase Return Invoice';";
                                            }
                                            else if (item == "Receipt Voucher")
                                            {
                                                query += "UPDATE tbl_sales SET pay=0 , `CHANGE`= net WHERE id IN (select inv_id from tbl_receipt_voucher_details);";
                                                query += "TRUNCATE TABLE tbl_receipt_voucher; TRUNCATE TABLE tbl_receipt_voucher_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Customer Receipt','PDC Receivable');";
                                            }
                                            else if (item == "Reconciliation")
                                            {
                                                query += "TRUNCATE TABLE tbl_reconciliation; TRUNCATE TABLE tbl_reconciliation_item;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Reconciliation');";
                                            }
                                            else if (item == "RMS Main")
                                            {
                                                query += "TRUNCATE TABLE tbl_rmsmain;TRUNCATE TABLE tbl_rmsdetails;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Reconciliation');";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='RMS Bill';";
                                            }
                                            else if (item == "RMS Tables")
                                            {
                                                query += "TRUNCATE TABLE tbl_rmstables;";
                                            }
                                            else if (item == "Salary")
                                            {
                                                query += "TRUNCATE TABLE tbl_salary;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Employee Salary');";
                                            }
                                            else if (item == "Salary Adjustments")
                                            {
                                                query += "TRUNCATE TABLE tbl_salary_adjustments;";
                                            }
                                            else if (item == "Sales")
                                            {
                                                query += "TRUNCATE TABLE tbl_sales; TRUNCATE TABLE tbl_sales_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Sales Invoice','Sales Invoice Cash');";
                                                query += "DELETE FROM tbl_cost_center_transaction WHERE type = 'Sales';";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='Sales Invoice';";
                                            }
                                            else if (item == "Sales Order")
                                            {
                                                query += "TRUNCATE TABLE tbl_sales_order; TRUNCATE TABLE tbl_sales_order_details;";
                                            }
                                            else if (item == "Sales Quotation")
                                            {
                                                query += "TRUNCATE TABLE tbl_sales_quotation; TRUNCATE TABLE tbl_sales_quotation_details;";
                                            }
                                            else if (item == "Sales Performa")
                                            {
                                                query += "TRUNCATE TABLE tbl_sales_proforma; TRUNCATE TABLE tbl_sales_proforma_details;";
                                            }
                                            else if (item == "Sales Return")
                                            {
                                                query += "TRUNCATE TABLE tbl_sales_return; TRUNCATE TABLE tbl_sales_return_details;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('SalesReturn Invoice','SalesReturn Invoice Cash');";
                                                query += "DELETE FROM tbl_cost_center_transaction WHERE type = 'Sales Return';";
                                                query += "DELETE FROM tbl_item_transaction WHERE type='Sales Return Invoice';";
                                            }
                                            else if (item == "Sub Contract")
                                            {
                                                query += "DELETE FROM tbl_vendor where type='SubContract';";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Subcontractor Payment','Subcontractor Opening Balance');";
                                            }
                                            else if (item == "Tax")
                                            {
                                                query += "TRUNCATE TABLE tbl_tax;";
                                            }
                                            else if (item == "Tender Names")
                                            {
                                                query += "TRUNCATE TABLE tbl_tender_names;";
                                            }
                                            else if (item == "Unit")
                                            {
                                                query += "TRUNCATE TABLE tbl_unit;";
                                            }
                                            else if (item == "Vat")
                                            {
                                                query += "TRUNCATE TABLE tbl_vat;";
                                            }
                                            else if (item == "Vendor")
                                            {
                                                query += "TRUNCATE TABLE tbl_vendor;";
                                                query += "DELETE FROM tbl_transaction WHERE type IN ('Vendor Opening Balance','Vendor Advance Payment','Vendor Payment');";
                                            }
                                            else if (item == "Vendor Category")
                                            {
                                                query += "TRUNCATE TABLE tbl_vendor_category;";
                                            }
                                            else if (item == "Warehouse")
                                            {
                                                query += "TRUNCATE TABLE tbl_warehouse;";
                                            }
                                            else if (item == "Warehouse Transaction")
                                            {
                                                query += "TRUNCATE TABLE tbl_item_warehouse_transaction;";
                                            }
                                        }
                                    }
                                }
                                //DBClass.ExecuteNonQuery(query);
                                using (var conn = DBClass.GetConnection())
                                {
                                    conn.Open();
                                    using (var trans = conn.BeginTransaction())
                                    {
                                        try
                                        {
                                            foreach (string stmt in query.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                            {
                                                DBClass.ExecuteNonQueryCommit(stmt + ";", trans);
                                            }

                                            trans.Commit();
                                            MessageBox.Show("Data Cleared");
                                        }
                                        catch (Exception ex)
                                        {
                                            trans.Rollback();
                                            MessageBox.Show("Transaction failed: " + ex.Message);
                                        }
                                    }
                                }

                                if (ChkLevel4.Checked)
                                {
                                    DBClass.ExecuteNonQuery("TRUNCATE TABLE tbl_coa_level_4;");
                                    DBClass.ExecuteNonQuery("Delete from tbl_transaction where type ='General Ledger Opening Balance';");
                                }
                                else if (ChkLevel4OBOnly.Checked)
                                {
                                    DBClass.ExecuteNonQuery("Update tbl_coa_level_4 SET debit=0,credit=0 where id > 0;");
                                    DBClass.ExecuteNonQuery("Delete from tbl_transaction where type ='General Ledger Opening Balance';");
                                }
                                if (ChkLevel3.Checked)
                                {
                                    DBClass.ExecuteNonQuery("TRUNCATE TABLE tbl_coa_level_3;");
                                }
                                if (ChkLevel2.Checked)
                                {
                                    DBClass.ExecuteNonQuery("TRUNCATE TABLE tbl_coa_level_2;");
                                }
                                if (ChkLevel1.Checked)
                                {
                                    DBClass.ExecuteNonQuery("TRUNCATE TABLE tbl_coa_level_1;");
                                }

                                MessageBox.Show("Data Cleared");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password. Deletion canceled.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // User cancelled the password prompt
                    MessageBox.Show("Deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            //if checked , check all items in the checked list box
            if (ChkAll.Checked)
            {
                for (int i = 0; i < ChkBoxTables.Items.Count; i++)
                {
                    ChkBoxTables.SetItemChecked(i, true);
                }
                ChkLevel4OBOnly.Checked = true;
            }
            else
            {
                for (int i = 0; i < ChkBoxTables.Items.Count; i++)
                {
                    ChkBoxTables.SetItemChecked(i, false);
                }
                ChkLevel4OBOnly.Checked = false;
            }
        }
    }
}
