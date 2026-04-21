using DocumentFormat.OpenXml.Bibliography;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using Org.BouncyCastle.Asn1.Cmp;
using PdfSharp.Drawing.BarCodes;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Default;

namespace YamyProject
{
    public partial class frmProjectDataExport : Form
    {
        DataTable datatable;
        public frmProjectDataExport()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.Text = "Project Date Import";
            headerUC1.FormText = this.Text;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmProjectDataExport_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            string query = @"SELECT code,name,description,start_date,end_date,country_id,city_id,status from tbl_projects p";
            datatable = DBClass.ExecuteDataTable(query);
            if (datatable != null && datatable.Rows.Count > 0)
            {
                dgvCustomer.DataSource = datatable;
                dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
            }
        }
        private int GenerateNextProjectCode()
        {
            object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(code AS UNSIGNED)), 4, '0') FROM tbl_projects;");
            int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
            string formattedId = nextId.ToString().PadLeft(3, '0');
            return int.Parse(formattedId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string openingBalanceEquity = BindCombos.SelectDefaultLevelAccount("Opening Balance Equity").ToString();

            var loadingForm = new LoadingForm();
            Task.Run(() =>
            {
                if (chkRequiredDate())
                {
                    insertProjectData(loadingForm, openingBalanceEquity.ToString());
                }
                else
                {
                    // Close the dialog safely from background thread
                    loadingForm.Invoke(new Action(() => loadingForm.Close()));
                }
            });

            loadingForm.ShowDialog();
        }

        private string ConvertFromDecimal(object value)
        {
            return Utilities.ParseDecimalValue(value).ToString();
        }

        private void insertProjectData(Form loadingForm,string _AccountNameId)
        {
            try
            {
                int formattedCode = GenerateNextProjectCode(); // Similar to customer code generator

                for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                {
                    string code = (i == 0 ? formattedCode : formattedCode + 1).ToString("D5");
                    if (dgvCustomer.Rows[i].Cells["name"].Value != null && dgvCustomer.Rows[i].Cells["name"].Value.ToString() != "")
                    {
                        string name = dgvCustomer.Rows[i].Cells["name"].Value.ToString();
                        string location = dgvCustomer.Rows[i].Cells["location"].Value?.ToString() ?? "";
                        string block = dgvCustomer.Rows[i].Cells["block"].Value?.ToString() ?? "";
                        string PlotNo = dgvCustomer.Rows[i].Cells["plotNo"].Value?.ToString() ?? "";
                        string Contractor = dgvCustomer.Rows[i].Cells["Contractor"].Value?.ToString() ?? "0";
                        string ContractPerson = dgvCustomer.Rows[i].Cells["ContractPerson"].Value?.ToString() ?? "0";
                        string ContractPersonMobile = dgvCustomer.Rows[i].Cells["ContractPersonMobile"].Value?.ToString() ?? "0";
                        string Customer = dgvCustomer.Rows[i].Cells["Customer"].Value?.ToString() ?? "";
                        string CustomerMobile = dgvCustomer.Rows[i].Cells["Mobile"].Value?.ToString() ?? "";

                        // Handle Customer
                        int customerId = 0;
                        if (!string.IsNullOrEmpty(Customer))
                        {
                            object customerExist = DBClass.ExecuteScalar("SELECT id FROM tbl_customer WHERE name = @name", DBClass.CreateParameter("name", name));
                            if (customerExist != null)
                            {
                                customerId = int.Parse(customerExist.ToString());
                            }
                            else
                            {
                                int _formattedCode = 0;
                                using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(code AS UNSIGNED)) AS lastCode FROM tbl_customer"))
                                {
                                    if (reader.Read() && reader["lastCode"] != DBNull.Value)
                                        _formattedCode = int.Parse(reader["lastCode"].ToString());
                                    else
                                        _formattedCode = 10000;
                                }
                                //    string openingBalanceEquity = BindCombos.SelectDefaultLevelAccount("Opening Balance Equity").ToString();

                                //}

                                int countryId = 0, cityId = 0;
                                customerId = Convert.ToInt32(DBClass.ExecuteScalar(@"INSERT INTO tbl_customer (code, NAME, Cat_id, Balance, DATE, 
                                                main_phone, work_phone, mobile, email, ccemail, website, country, city, region, building_name, account_id, 
                                                trn, facilty_name, active, created_by, created_date, state) 
                                                VALUES(@code, @name, @cat_id, @balance, @date, @main_phone, @work_phone, @mobile, @email, @ccemail, @website, 
                                                @country, @city, @region, @building_name, @account_id, @trn, @facilty_name, @active, @created_by, @created_date, @state);
                                                SELECT LAST_INSERT_ID();",
                                                    DBClass.CreateParameter("code", _formattedCode + 1),
                                                    DBClass.CreateParameter("name", name),
                                                    DBClass.CreateParameter("cat_id", 0),
                                                    DBClass.CreateParameter("balance", 0),
                                                    DBClass.CreateParameter("date", dtpDate.Value.Date),
                                                    DBClass.CreateParameter("main_phone", CustomerMobile),
                                                    DBClass.CreateParameter("work_phone", ""),
                                                    DBClass.CreateParameter("mobile", ""),
                                                    DBClass.CreateParameter("email", ""),
                                                    DBClass.CreateParameter("ccemail", ""),
                                                    DBClass.CreateParameter("website", ""),
                                                    DBClass.CreateParameter("country", countryId),
                                                    DBClass.CreateParameter("city", cityId),
                                                    DBClass.CreateParameter("region", ""),
                                                    DBClass.CreateParameter("building_name", ""),
                                                    DBClass.CreateParameter("account_id", _AccountNameId),
                                                    DBClass.CreateParameter("trn", ""),
                                                    DBClass.CreateParameter("facilty_name", ""),
                                                    DBClass.CreateParameter("active", 0),
                                                    DBClass.CreateParameter("created_by", frmLogin.userId),
                                                    DBClass.CreateParameter("created_date", DateTime.Now.Date),
                                                    DBClass.CreateParameter("state", 0)));

                            }
                        }

                        // Prevent duplicates (by name)
                        using (var reader = DBClass.ExecuteReader("SELECT 1 FROM tbl_projects WHERE name=@name",
                                    DBClass.CreateParameter("name", name)))
                        {
                            if (!reader.Read())
                            {
                                int projectId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                                                    INSERT INTO tbl_projects (code, name, name_ar, category, description, start_date, end_date, country_id, city_id, emirate, status, type, extend_delay, execution_period_months, customer, contractor, consultant, location, details, contract_value, additional_value, deduction_value, total_value, billed_to_date, expenses, balance, area,plot_number,block,contact_person,contact_person_number) 
                                                    VALUES (@code, @name, @name_ar, @category, @description, @start_date, @end_date, @country_id, @city_id, @emirate, @status, @type, @extend_delay, @execution_period_months, @customer, @contractor, @consultant, @location, @details, @contract_value, @additional_value, @deduction_value, @total_value, @billed_to_date, @expenses, @balance, @area,@plot_number,@block,@contact_person,@contact_person_number);
                                                    SELECT LAST_INSERT_ID();",
                                                    DBClass.CreateParameter("@code", code),
                                                    DBClass.CreateParameter("@name", name),
                                                    DBClass.CreateParameter("@name_ar", name),
                                                    DBClass.CreateParameter("@category", ""),
                                                    DBClass.CreateParameter("@description", ""),
                                                    DBClass.CreateParameter("@start_date", DateTime.Now.Date),
                                                    DBClass.CreateParameter("@end_date", DateTime.Now.Date),
                                                    DBClass.CreateParameter("@country_id", 0),
                                                    DBClass.CreateParameter("@city_id", 0),
                                                    DBClass.CreateParameter("@emirate", ""),
                                                    DBClass.CreateParameter("@status", "Approved"),
                                                    DBClass.CreateParameter("@type", "Project"),
                                                    DBClass.CreateParameter("@extend_delay", DateTime.Now.Date),
                                                    DBClass.CreateParameter("@execution_period_months", 0),
                                                    DBClass.CreateParameter("@customer", customerId),
                                                    DBClass.CreateParameter("@contractor", Contractor),
                                                    DBClass.CreateParameter("@consultant", ""),
                                                    DBClass.CreateParameter("@location", Location),
                                                    DBClass.CreateParameter("@details", ""),
                                                    DBClass.CreateParameter("@contract_value", 0),
                                                    DBClass.CreateParameter("@additional_value", 0),
                                                    DBClass.CreateParameter("@deduction_value", 0),
                                                    DBClass.CreateParameter("@total_value", 0),
                                                    DBClass.CreateParameter("@billed_to_date", 0),
                                                    DBClass.CreateParameter("@expenses", 0),
                                                    DBClass.CreateParameter("@balance", 0),
                                                    DBClass.CreateParameter("area", ""),
                                                    DBClass.CreateParameter("plot_number", PlotNo),
                                                    DBClass.CreateParameter("block", block),
                                                    DBClass.CreateParameter("contact_person", ContractPerson),
                                                    DBClass.CreateParameter("contact_person_number", ContractPersonMobile)
                                                ));

                                Utilities.LogAudit(frmLogin.userId, "Add Project", "Project", projectId, "Added New Project: " + Name + " (Code: " + code + ")");
                                formattedCode++;
                            }
                        }
                    }
                }

                loadingForm.Invoke(new Action(() => loadingForm.Close()));
                MessageBox.Show("Successfully saved! Employee List", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                loadingForm.Invoke(new Action(() => loadingForm.Close()));
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool chkRequiredDate()
        {
            if(dgvCustomer.Rows.Count == 1)
            {
                MessageBox.Show("Please Enter Date First");
                return false;
            }

            return true;
        }
        private decimal GetDecimalValue(DataGridViewRow row, string columnName)
        {
            decimal result;
            var cellValue = row.Cells[columnName].Value;
            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out result))
                return result;
            else
                return 0;
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Projects");
                    worksheet.Cells["A1"].LoadFromDataTable(datatable, true);
                    
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(fi);
                        MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImportProjectData importForm = new frmImportProjectData();
            if (importForm.ShowDialog() == DialogResult.OK)
            {
                DataTable importedData = importForm.ImportedData;
                dgvCustomer.DataSource = importedData;
                LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
            }
        }
        
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text) && txtCode.Text.Length > 0)
            {
                //
            }
        }
    }
}

public class frmImportProjectData : Form
{
    private TextBox txtStartCell, txtEndCell; 
    TextBox txtNameCell;
    TextBox txtLocationCell;
    TextBox txtBlockCell;
    TextBox txtPlotNoCell;
    TextBox txtContractorCell;
    TextBox txtContractPersonCell;
    TextBox txtContractPersonMobileCell;
    TextBox txtCustomerCell;
    TextBox txtMobileCell;
    private Button btnLoadExcel, btnImport;
    private DataGridView dataGridView;
    private string excelPath = string.Empty;
    DataTable dtFiltered = new DataTable();
    public DataTable ImportedData { get; private set; }

    public frmImportProjectData()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        this.Text = "Excel Import Form";
        this.Size = new Size(1624, 900);
        this.StartPosition = FormStartPosition.CenterScreen;

        // ==== Top Panel ====
        Panel panelTop = new Panel()
        {
            Dock = DockStyle.Top,
            Height = 60,
            Padding = new Padding(10),
        };

        // Starting X position for controls
        int x = 10;
        int spacing = 8;
        int labelWidth = 80;
        int textboxWidth = 15;
        int controlHeight = 28;

        // Excel buttons
        btnLoadExcel = new Button() { Text = "Load Excel", Size = new Size(100, controlHeight), Location = new Point(x, 10) };
        x += 100 + spacing;

        btnImport = new Button() { Text = "Set Data", Size = new Size(80, controlHeight), Location = new Point(x, 10) };
        x += 80 + spacing;

        // Start Cell
        panelTop.Controls.Add(new Label() { Text = "Start Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtStartCell = new TextBox() { Width = textboxWidth, Location = new Point(x - 13, 12) };
        x += textboxWidth + spacing;

        // End Cell
        panelTop.Controls.Add(new Label() { Text = "End Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtEndCell = new TextBox() { Width = textboxWidth, Location = new Point(x - 15, 12) };
        x += textboxWidth + spacing;

        // Name Cell
        panelTop.Controls.Add(new Label() { Text = "Name Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtNameCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // Address Cell
        panelTop.Controls.Add(new Label() { Text = "Location Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtLocationCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // Phone Cell
        panelTop.Controls.Add(new Label() { Text = "Block Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtBlockCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // Birth Day Cell
        panelTop.Controls.Add(new Label() { Text = "Plot No Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtPlotNoCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // Contractor Cell
        panelTop.Controls.Add(new Label() { Text = "Contractor Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtContractorCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // ContractPerson Cell
        panelTop.Controls.Add(new Label() { Text = "ContractPerson Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtContractPersonCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // ContractPersonMobile Cell
        panelTop.Controls.Add(new Label() { Text = "ContractPersonMobile Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtContractPersonMobileCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // Customer Cell
        panelTop.Controls.Add(new Label() { Text = "Customer Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtCustomerCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;

        // Mobile Cell
        panelTop.Controls.Add(new Label() { Text = "Mobile Cell:", AutoSize = true, Location = new Point(x, 15) });
        x += labelWidth;
        txtMobileCell = new TextBox() { Width = textboxWidth, Location = new Point(x, 12) };
        x += textboxWidth + spacing;


        // Add controls
        panelTop.Controls.Add(btnLoadExcel);
        panelTop.Controls.Add(btnImport);
        panelTop.Controls.Add(txtStartCell);
        panelTop.Controls.Add(txtEndCell);
        panelTop.Controls.Add(txtNameCell);
        panelTop.Controls.Add(txtLocationCell);
        panelTop.Controls.Add(txtBlockCell);
        panelTop.Controls.Add(txtPlotNoCell);
        panelTop.Controls.Add(txtContractorCell);
        panelTop.Controls.Add(txtContractPersonCell);
        panelTop.Controls.Add(txtContractPersonMobileCell);
        panelTop.Controls.Add(txtCustomerCell);
        panelTop.Controls.Add(txtMobileCell);

        // Add top panel to form
        this.Controls.Add(panelTop);


        btnLoadExcel.Click += BtnLoadExcel_Click;
        btnImport.Click += BtnImport_Click;

        // ==== Main Panel ====
        Panel panelMain = new Panel()
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10),
        };

        dataGridView = new DataGridView()
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };

        panelMain.Controls.Add(dataGridView);

        // Add both panels to form
        this.Controls.Add(panelMain);
        this.Controls.Add(panelTop);

        // Digit-only for start/end
        txtStartCell.KeyPress += TxtIntOnly_KeyPress;
        txtEndCell.KeyPress += TxtIntOnly_KeyPress;

        // Letter-only for others (your actual text fields)
        txtNameCell.KeyPress += TxtLettersOnly_KeyPress;
        txtLocationCell.KeyPress += TxtLettersOnly_KeyPress;
        txtBlockCell.KeyPress += TxtLettersOnly_KeyPress;
        txtPlotNoCell.KeyPress += TxtLettersOnly_KeyPress;
        txtContractorCell.KeyPress += TxtLettersOnly_KeyPress;
        txtContractPersonCell.KeyPress += TxtLettersOnly_KeyPress;
        txtContractPersonMobileCell.KeyPress += TxtLettersOnly_KeyPress;
        txtCustomerCell.KeyPress += TxtLettersOnly_KeyPress;
        txtMobileCell.KeyPress += TxtLettersOnly_KeyPress;
    }
    private void BtnImport_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(excelPath))
        {
            MessageBox.Show("Please load an Excel file first.");
            return;
        }

        if (dataGridView.Rows.Count == 0)
        {
            MessageBox.Show("Please load an Excel file first.");
            return;
        }

        int startCol = ToNumber(txtStartCell.Text);
        int endCol = ToNumber(txtEndCell.Text);

        if (startCol == -1 || endCol == -1 || endCol < startCol)
        {
            MessageBox.Show("Invalid start or end column.");
            return;
        }

        // Map Excel columns to employee table fields
        int colName = ExcelColumnNameToNumber(txtNameCell.Text);
        int colLocation = ExcelColumnNameToNumber(txtLocationCell.Text);
        int colBlock = ExcelColumnNameToNumber(txtBlockCell.Text);
        int colPlotNo = ExcelColumnNameToNumber(txtPlotNoCell.Text);
        int colContractor = ExcelColumnNameToNumber(txtContractorCell.Text);
        int colContractPerson = ExcelColumnNameToNumber(txtContractPersonCell.Text);
        int colContractPersonMobile = ExcelColumnNameToNumber(txtContractPersonMobileCell.Text);
        int colCustomer = ExcelColumnNameToNumber(txtCustomerCell.Text);
        int colMobile = ExcelColumnNameToNumber(txtMobileCell.Text);

        dtFiltered.Columns.Clear();
        dtFiltered.Columns.Add("Name");
        dtFiltered.Columns.Add("Location");
        dtFiltered.Columns.Add("Block");
        dtFiltered.Columns.Add("PlotNo");
        dtFiltered.Columns.Add("Contractor");
        dtFiltered.Columns.Add("ContractPerson");
        dtFiltered.Columns.Add("ContractPersonMobile");
        dtFiltered.Columns.Add("Customer");
        dtFiltered.Columns.Add("Mobile");

        using (var package = new ExcelPackage(new FileInfo(excelPath)))
        {
            var ws = package.Workbook.Worksheets[0];

            for (int row = ws.Dimension.Start.Row + 1; row <= ws.Dimension.End.Row; row++)
            {
                if (IsRowEmpty(ws, row, endCol)) continue;

                DataRow dr = dtFiltered.NewRow();

                dr["Name"] = (colName != -1) ? ws.Cells[row, colName].Text : "";
                dr["Location"] = (colLocation != -1) ? ws.Cells[row, colLocation].Text : "";
                dr["Block"] = (colBlock != -1) ? ws.Cells[row, colBlock].Text : "";
                dr["PlotNo"] = (colPlotNo != -1) ? ws.Cells[row, colPlotNo].Text : "";
                dr["Contractor"] = (colContractor != -1) ? ws.Cells[row, colContractor].Text : "0";
                dr["ContractPerson"] = (colContractPerson != -1) ? ws.Cells[row, colContractPerson].Text : "0";
                dr["ContractPersonMobile"] = (colContractPersonMobile != -1) ? ws.Cells[row, colContractPersonMobile].Text : "0";
                dr["Customer"] = (colCustomer != -1) ? ws.Cells[row, colCustomer].Text : "";
                dr["Mobile"] = (colMobile != -1) ? ws.Cells[row, colMobile].Text : "";

                dtFiltered.Rows.Add(dr);
            }

            dataGridView.DataSource = dtFiltered;
        }

        this.ImportedData = dtFiltered;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private int ToNumber(string text)
    {
        if (string.IsNullOrEmpty(text)) return -1;
        else return int.Parse(text);
    }

    int ExcelColumnNameToNumber(string columnName)
    {
        if (string.IsNullOrEmpty(columnName)) return -1;

        columnName = columnName.ToUpperInvariant();
        int sum = 0;
        foreach (char c in columnName)
        {
            if (c < 'A' || c > 'Z') return -1; // invalid char
            sum *= 26;
            sum += (c - 'A' + 1);
        }
        return sum;
    }
    private void TxtIntOnly_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Allow control keys like Backspace
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true; // Reject non-digit keys
        }
    }
    private void TxtLettersOnly_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
        {
            e.Handled = true; // block non-letter keys
        }
    }

    private void BtnLoadExcel_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            excelPath = ofd.FileName;
            ImportToGrid();
        }
    }

    private void ImportToGrid()
    {
        if (string.IsNullOrEmpty(excelPath))
        {
            MessageBox.Show("Please load an Excel file first.");
            return;
        }

        try
        {
            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                var ws = package.Workbook.Worksheets[0];
                int startRow = ws.Dimension.Start.Row;
                int endRow = ws.Dimension.End.Row;
                int startCol = ws.Dimension.Start.Column;
                int endCol = ws.Dimension.End.Column;

                DataTable dt = new DataTable();

                // First column: "Index" or "Row"
                dt.Columns.Add("Index");

                // Set headers manually as A, B, C, etc.
                for (int col = startCol; col <= endCol; col++)
                {
                    string colLetter = GetExcelColumnLetter(col);
                    dt.Columns.Add(colLetter);
                }

                // Fill data from all rows
                for (int row = startRow; row <= endRow; row++)
                {
                    DataRow dr = dt.NewRow();

                    dr["Index"] = row.ToString();  // Add Excel-like row number

                    for (int col = startCol; col <= endCol; col++)
                    {
                        dr[col - startCol + 1] = ws.Cells[row, col].Text;
                    }

                    dt.Rows.Add(dr);
                }

                dataGridView.DataSource = dt;

                dataGridView.ReadOnly = true;
                dataGridView.RowHeadersVisible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error reading Excel: {ex.Message}");
        }
    }
    private string GetExcelColumnLetter(int col)
    {
        string columnString = "";
        int columnNumber = col;
        while (columnNumber > 0)
        {
            int currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - 1) / 26;
        }
        return columnString;
    }

    private bool IsRowEmpty(ExcelWorksheet ws, int row, int maxCol)
    {
        for (int col = 1; col <= maxCol; col++)
        {
            if (!string.IsNullOrWhiteSpace(ws.Cells[row, col].Text))
                return false;
        }
        return true;
    }
}