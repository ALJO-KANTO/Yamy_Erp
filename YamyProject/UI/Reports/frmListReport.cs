using DocumentFormat.OpenXml.Presentation;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Reports
{
    public partial class frmListReport : Form
    {
        string type;
        public frmListReport(string _type)
        {
            InitializeComponent();
            this.type = _type;
            headerUC1.FormText = type;
        }

        private void frmListReport_Load(object sender, EventArgs e)
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            BindData();
            LocalizationManager.LocalizeDataGridViewHeaders(dgvData);
        }

        public void BindData()
        {
            dgvData.Rows.Clear();
            string query = "";
            if (type == "Bank List") { query = "SELECT b.Id, b.Code,b.Name,b.abb_name `Abb Name`,b.ent_id `Ent Id`,b.route_num `Route Num`,IFNULL(c.name,'') `Country`,b.State,b.created_date `Created On` FROM tbl_bank b LEFT JOIN tbl_country c ON c.id = b.country_id"; }
            else if (type == "Bank Card List") { query = "SELECT bc.Id,bc.account_name `Account Name`,b.name `Bank`,bc.account_type `Account Type`,bc.account_no `Account No`,bc.Swift,bc.iban_no `Iban No`,bc.branch_name `Branch Name`,bc.Emirates,bc.Currency,bc.account_manager `Account Manager`,bc.account_sign `Account Sign`,bc.account_mob `Account Mobile`,ac.name `Account`,bc.State,bc.created_date `Created On` FROM tbl_bank_card bc LEFT JOIN tbl_bank b ON b.id = bc.bank_id LEFT JOIN tbl_coa_level_4 ac ON ac.id = bc.account_id"; }
            else if (type == "Cheque List") { query = "SELECT cq.Id,bc.account_name `Bank Card Name`,cq.chq_book_no `Book No`,cq.chq_book_qty `Book Qty`,cq.leaves_start_from `Start From`,cq.leaves_end_in `End In`,cq.created_date `Created On` FROM tbl_cheque cq LEFT JOIN tbl_bank_card bc ON bc.id = cq.bank_card_id"; }
            else if (type == "City List") { query = "SELECT ct.Id,ct.Name,c.name `Country` FROM tbl_city ct INNER JOIN tbl_country c ON c.id = ct.country_id"; }
            else if (type == "Country List") { query = "SELECT Id,Name FROM tbl_country"; }
            else if (type == "Cost Center List") { query = "SELECT Id,Code,Name FROM tbl_cost_center"; }
            else if (type == "Customer List") { query = "SELECT c.Id,c.Code,c.Name,IFNULL(cc.name, '') `Category`,c.Balance,c.date `OBDate`,c.main_phone `Main Phone`,c.work_phone `Work Phone`,c.Mobile,c.Email,c.CCEmail,c.Website,IFNULL(ctr.name,'') `Country`,IFNULL(cty.name,'') City,c.Region,c.building_name `Address`,ac.name `Account`,c.TRN,c.facilty_name `Facility Name`,c.Active,c.created_date `Created On`,c.State FROM tbl_customer c LEFT JOIN tbl_customer_category cc ON cc.id = c.cat_id LEFT JOIN tbl_country ctr ON ctr.id = c.country LEFT JOIN tbl_city cty ON cty.id = c.city LEFT JOIN tbl_coa_level_4 ac ON ac.id = c.account_id"; }
            else if (type == "Customer Phone List") { query = "SELECT Id, concat(code, ' - ',name) Name, main_phone FROM tbl_customer"; }
            else if (type == "Customer Contact List") { query = @"SELECT c.id, CONCAT(c.code,' - ',c.name) Name, c.main_phone 'Main Phone', c.work_phone 'Work Phone',c.mobile 'Mobile', 
                                                                    COALESCE(t.Amount, 0) AS 'Balance' FROM tbl_customer c LEFT JOIN (SELECT hum_id, SUM(debit - credit) AS Amount FROM 
                                                                    tbl_transaction WHERE state = 0 AND type IN ('Customer Receipt','Sales Invoice','Customer Opening Balance','Customer Advance Payment','Check Cancel (Customer)','SalesReturn Invoice','Credit Note','PDC Receivable') GROUP BY hum_id) t ON t.hum_id = c.id"; }
            else if (type == "Customer Category List") { query = "SELECT Id,Name FROM tbl_customer_category"; }
            else if (type == "Department List") { query = "SELECT Id,Name,IFNULL(Department,'') Department FROM tbl_departments"; }
            else if (type == "Employee List") { query = "SELECT e.Id,e.Code,e.Name,IFNULL(cty.name,'') City,e.Address,e.Phone,e.birth_day `Birth Day`,e.Social_Status `Social Status`,e.Social_Insurance_Number `Social Insurance Number`,e.Email,e.EmergencyName,e.EmergencyAddress,e.EmergencyPhone,e.Relation,e.BasicSalary,e.HousingAllowance,e.TransportationAllowance,e.Other,IFNULL(b.Name,'') Bank,e.Iban_Number `Iban Number`,e.Bank_account_Number `Bank Account Number`,e.EmiratesIDFileNumber,e.EmiratesIDIssuingAuthority,e.EmiratesIDIssueDate,e.EmiratesIDExpiryDate,e.PassportNumber,e.CountryOfIssue,e.PassportIssueDate,e.PassportExpiryDate,e.WorkContractNumber,e.WorkContractType,IFNULL(p.name,'') `Position`,IFNULL(d.name,'') Department,e.WorkDays,e.WorkingHours,e.ContractIssueDate,e.ContractExpiryDate,e.ResidencyFileNumber,e.ResidencyIssuingAuthority,e.ResidencyIssueDate,e.ResidencyExpiryDate,IFNULL(ac.name,'') `Account`,e.Active,e.State,e.sRole FROM tbl_employee e LEFT JOIN tbl_city cty ON cty.id = e.city_id LEFT JOIN tbl_bank b ON b.id = e.bank_id LEFT JOIN tbl_position p ON p.id = e.Position_id LEFT JOIN tbl_departments d ON d.id = e.department_id LEFT JOIN tbl_coa_level_4 ac ON ac.id = e.account_id"; }
            else if (type == "Fixed Asset List") { query = "SELECT fa.Id,fa.date,fa.Code,fa.Name,fa.Brand,IFNULL(fac.category_name,'') Category,fa.Model,fa.Supplier,fa.`Status`,fa.invoice_number `Invoice No`,fa.purchase_date `PurchaseDate`,fa.end_date `End Date`,fa.depreciation_life `DepreciationLife`,fa.purchase_price `PurchasePrice`,fa.created_date `Created On`,fa.State FROM tbl_fixed_assets fa LEFT JOIN tbl_fixed_assets_category fac ON fac.id = fa.category_id"; }
            else if (type == "Fixed Asset Category List") { query = "SELECT Id,category_name Name FROM tbl_fixed_assets_category"; }
            else if (type == "FixedAsset Item List")
            {
                query = "SELECT Id, Code, Name, Type, Barcode, cost_price `CostPrice`,sales_price `SalesPrice`, min_amount `MinAmount`, max_amount `MaxAmount`, on_hand Qty FROM tbl_items where item_type = 'Fixed Assets'";
            }
            else if (type == "Item List")
            {
                query = "SELECT Id, Code, Name, Type, Barcode, cost_price `CostPrice`,sales_price `SalesPrice`, min_amount `MinAmount`, max_amount `MaxAmount`, on_hand Qty FROM tbl_items";
            }
            else if (type == "Item Price List")
            {
                query = "SELECT Id, Code, Name, Type, sales_price Price FROM tbl_items";
            }
            else if (type == "Item Category List") { query = "SELECT Id,Code,Name FROM tbl_item_category"; }
            else if (type == "Item Tax Code List") { query = "SELECT Id,Name,Value,Description,State FROM tbl_tax"; }
            else if (type == "Item Unit List") { query = "SELECT Id,Name FROM tbl_unit"; }
            else if (type == "Item Warehouse List") { query = "SELECT Id,Code,Name,City,building_name `BuildingName`,State,created_date `Created On` FROM tbl_warehouse"; }
            else if (type == "Petty Cash Category List") { query = "SELECT Id,Name,Description FROM tbl_petty_cash_category"; }
            else if (type == "Position List") { query = "SELECT p.Id,p.Name,IFNULL(d.name, '')Department FROM tbl_position p LEFT JOIN tbl_departments d ON d.id = p.department_id"; }
            else if (type == "Prepaid Expense List") { query = "SELECT pe.Id,pe.Code,pe.Name,IFNULL(pec.name,'') Category,pe.start_date `StartDate`,pe.end_date `EndDate`,pe.Amount,pe.Fee,pe.Total,pe.created_date `Created On`,pe.State FROM tbl_prepaid_expense pe LEFT JOIN tbl_prepaid_expense_category pec ON pec.id = pe.category_id"; }
            else if (type == "Prepaid Expense Category List") { query = "SELECT Id,Name FROM tbl_prepaid_expense_category"; }
            else if (type == "Vendor List") { query = "SELECT v.Id,v.Code,v.Name,IFNULL(c.name, '') Category,v.Balance,v.date `Created On`,v.main_phone MainPhone,v.work_phone WorkPhone,v.Mobile,v.Email,v.CCEmail,v.WebSite,IFNULL(ctr.name,'') `Country`,IFNULL(cty.name,'') `City`,v.Region,v.building_name `Address`,IFNULL(ac.name,'') Account,v.TRN,v.facilty_name `Facility Name`,v.Active,v.created_date `Created On`,v.State,v.`Type` FROM tbl_vendor v LEFT JOIN tbl_vendor_category c ON c.id = v.cat_id LEFT JOIN tbl_country ctr ON ctr.id = v.country LEFT JOIN tbl_city cty ON cty.id = v.city LEFT JOIN tbl_coa_level_4 ac ON ac.id = v.account_id"; }
            else if (type == "Vendor Phone List") { query = "SELECT Id, concat(code,' - ',name) Name, main_phone MainPhone FROM tbl_vendor"; }
            else if (type == "Vendor Contact List")
            {
                query = @"SELECT c.Id, CONCAT(c.code,' - ',c.name) Name, c.main_phone 'Main Phone', c.work_phone 'Work Phone',c.mobile 'Mobile', 
                                                                    COALESCE(t.Amount, 0) AS 'Balance' FROM tbl_vendor c LEFT JOIN (SELECT hum_id, SUM(debit - credit) AS Amount FROM 
                                                                    tbl_transaction WHERE state = 0 AND type IN ('Vendor Payment','Petty Cash','Purchase Invoice','Vendor Opening Balance','Vendor Advance Payment','Check Cancel (Vendor)','Purchase Return Invoice','Debit Note','PDC Payable') GROUP BY hum_id) t ON t.hum_id = c.id";
            }
            else if (type == "Vendor Category List") { query = "SELECT Id,Name FROM tbl_vendor_category"; }

            if (string.IsNullOrWhiteSpace(query))
                return;

            DataTable dt = DBClass.ExecuteDataTable(query);
            dgvData.DataSource = dt;
            try
            {
                dgvData.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvData.CurrentRow.Cells["id"].Value == null || string.IsNullOrWhiteSpace(dgvData.CurrentRow.Cells["id"].Value.ToString()))
                return;

            int refId = int.Parse(dgvData.CurrentRow.Cells["id"].Value.ToString());
            Form form = null;

            switch (type)
            {
                case "Bank List":
                    form = new frmBankRegister(refId);
                    break;
                case "Bank Card List":
                    form = new frmViewBankCard(refId);
                    break;
                case "Cheque List":
                    form = new frmViewCheque(refId);
                    break;
                case "City List":
                    form = new frmViewCity(refId);
                    break;
                //case "Country List":
                //    form = new frmCountry();
                //    break;
                case "Cost Center List":
                    form = new frmCostCenter(refId);
                    break;
                case "Customer List":
                    form = new frmViewCustomer(refId);
                    break;
                case "Customer Phone List":
                    form = new frmViewCustomer(refId);
                    break;
                case "Customer Contact List":
                    form = new frmViewCustomer(refId);
                    break;
                case "Customer Category List":
                    form = new frmViewCustomerCategory(refId);
                    break;
                case "Department List":
                    form = new frmViewDepartments(refId);
                    break;
                case "Employee List":
                    form = new frmViewEmployee(refId);
                    break;
                case "Fixed Asset List":
                    form = new frmViewFixedAssets(refId);
                    break;
                case "Fixed Asset Category List":
                    form = new frmViewFixedAssetsCategory(refId);
                    break;
                case "FixedAsset Item List":
                    form = new frmViewItem(refId); // or a specific form like frmFixedAssetItem
                    break;
                case "Item List":
                    form = new frmViewItem(refId);
                    break;
                case "Item Price List":
                    form = new frmViewItem(refId);
                    break;
                case "Item Category List":
                    form = new frmViewCategory(refId);
                    break;
                case "Item Tax Code List":
                    form = new frmViewItemTaxCodes(refId);
                    break;
                case "Item Unit List":
                    form = new frmViewItemUnit(refId);
                    break;
                case "Item Warehouse List":
                    form = new frmViewWarehouse(refId);
                    break;
                case "Petty Cash Category List":
                    form = new frmPettyCashCategory(refId);
                    break;
                case "Position List":
                    form = new frmViewPosition(refId);
                    break;
                case "Prepaid Expense List":
                    form = new frmViewPrepaidExpense(refId);
                    break;
                case "Prepaid Expense Category List":
                    form = new frmViewPrepaidExpenseCategory(refId);
                    break;
                case "Vendor List":
                    form = new frmViewVendor(refId);
                    break;
                case "Vendor Category List":
                    form = new frmViewVendorCategory(refId);
                    break;
            }

            if (form != null)
            {
                form.Show();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create a MigraDoc document
            Document doc = new Document();
            Section section = doc.AddSection();

            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
            section.PageSetup.TopMargin = Unit.FromCentimeter(1);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);

            Paragraph heading = section.AddParagraph("Grid Data Export");
            heading.Format.Font.Size = 14;
            heading.Format.Font.Bold = true;
            heading.Format.SpaceAfter = "1cm";

            Table table = section.AddTable();
            table.Borders.Width = 0.75;

            // Add columns from DataGridView
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Visible)
                {
                    Column column = table.AddColumn(Unit.FromCentimeter(4));
                    column.Format.Alignment = ParagraphAlignment.Left;
                }
            }

            // Add header row
            Row headerRow = table.AddRow();
            headerRow.Shading.Color = Colors.LightGray;
            int headerIndex = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Visible)
                {
                    headerRow.Cells[headerIndex].AddParagraph(col.HeaderText);
                    headerRow.Cells[headerIndex].Format.Font.Bold = true;
                    headerIndex++;
                }
            }

            // Add data rows
            foreach (DataGridViewRow dgvRow in dgvData.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                Row row = table.AddRow();
                int cellIndex = 0;

                foreach (DataGridViewCell cell in dgvRow.Cells)
                {
                    if (dgvData.Columns[cell.ColumnIndex].Visible)
                    {
                        row.Cells[cellIndex].AddParagraph(Convert.ToString(cell.Value));
                        cellIndex++;
                    }
                }
            }

            // Render the document to PDF
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = doc;
            renderer.RenderDocument();

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = type.Trim().Replace(" ", "") + ".pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    renderer.PdfDocument.Save(sfd.FileName);
                    MessageBox.Show("PDF saved successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = type.Trim().Replace(" ", "") + ".xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;
                    var workbook = excelApp.Workbooks.Add(Type.Missing);
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = type.Trim();

                    int colIndex = 1;
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        if (col.Visible)
                        {
                            worksheet.Cells[1, colIndex] = col.HeaderText;
                            ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, colIndex]).Font.Bold = true;
                            colIndex++;
                        }
                    }

                    int rowIndex = 2;
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.IsNewRow) continue;
                        colIndex = 1;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (dgvData.Columns[cell.ColumnIndex].Visible)
                            {
                                worksheet.Cells[rowIndex, colIndex] = Convert.ToString(cell.Value);
                                colIndex++;
                            }
                        }
                        rowIndex++;
                    }

                    // Auto-fit columns
                    worksheet.Columns.AutoFit();

                    // Save and release
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close(false);
                    excelApp.Quit();

                    // Release COM objects
                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(excelApp);

                    MessageBox.Show("Excel file saved successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
