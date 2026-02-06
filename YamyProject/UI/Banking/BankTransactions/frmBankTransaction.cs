using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Banking.BankTransactions
{
    public partial class frmBankTransaction : Form
    {
        int selectedId;
        public frmBankTransaction(int _selectedId = 0)
        {
            InitializeComponent();
            this.selectedId = _selectedId;
        }

        private void frmBankTransaction_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateRegisterBanks(cmbBankName, true);
            cmbBankName.SelectedIndex = -1;
            // Load data once
            DataTable dt = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_coa_level_4");

            DataGridViewComboBoxColumn columnBank = (DataGridViewComboBoxColumn)dgvJV.Columns["bank_ac"];
            DataGridViewComboBoxColumn columnAccount = (DataGridViewComboBoxColumn)dgvJV.Columns["account_name"];
            // Bind bank column
            columnBank.DataSource = dt.Copy();
            columnBank.DisplayMember = "name";
            columnBank.ValueMember = "id";

            // Bind account column
            columnAccount.DataSource = dt.Copy();
            columnAccount.DisplayMember = "name";
            columnAccount.ValueMember = "id";

            // Optional but recommended
            columnBank.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            columnAccount.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            //DataGridViewColumn columnBank = dgvJV.Columns["bank_ac"];
            //DataGridViewColumn columnAccount = dgvJV.Columns["account_name"];

            //DataTable dt = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_coa_level_4");
            //columnBank.DataSource = dt.Copy();
            //columnAccount.DataSource = dt.Copy();
            //columnBank.DisplayMember = "name";
            //columnBank.ValueMember = "id";
            //columnAccount.DisplayMember = "name";
            //columnAccount.ValueMember = "id";

            LocalizationManager.LocalizeDataGridViewHeaders(dgvJV);

            if (selectedId > 0)
            {
                ShowData();
                txtJvId.Text = selectedId.ToString();
            } else
            {
                txtJvId.Text = GenerateNextId();
            }
        }
        private string GenerateNextId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_bank_transaction"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }

        private void ShowData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT bank_account_id, account_id, statement_date, value_date, narration, debit, credit, running_balance, reference_no, cheque_no, reconciled 
                                                        FROM tbl_bank_transaction WHERE id = @id",
                                                        DBClass.CreateParameter("@id", selectedId)))
            {
                if (reader.Read())
                {
                    dgvJV.Rows.Clear();
                    int rowIndex = dgvJV.Rows.Add();
                    DataGridViewRow dgvRow = dgvJV.Rows[rowIndex];
                    dgvRow.Cells["bank_ac"].Value = reader["bank_account_id"];
                    dgvRow.Cells["account_name"].Value = reader["account_id"];
                    dgvRow.Cells["dated"].Value = Convert.ToDateTime(reader["statement_date"]).ToString("yyyy-MM-dd");
                    dgvRow.Cells["description"].Value = reader["narration"];
                    dgvRow.Cells["debit"].Value = reader["debit"];
                    dgvRow.Cells["credit"].Value = reader["credit"];
                    dgvRow.Cells["balance"].Value = reader["running_balance"];
                    dgvRow.Cells["account_id"].Value = "0";//reader["id"];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckRequired())
            {
                if (selectedId > 0)
                    EditData(); 
                else
                    SaveData();
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtJvId.Text); // Utilities.GetVoucherIdFromCode(txtPVCode.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            txtJvId.Text = currentId.ToString();
            string query = "SELECT id FROM tbl_bank_transaction WHERE id =@id";
            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
            {
                if (reader.Read())
                {
                    selectedId = int.Parse(reader["id"].ToString());
                    ShowData();
                }
                else
                {
                    Clear();
                    MessageBox.Show("No next record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Clear()
        {
            dgvJV.Rows.Clear();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtJvId.Text);
            if (currentId == null || currentId <= 1)
                return;

            currentId = currentId - 1;
            txtJvId.Text = currentId.ToString();
            if (currentId <= 0)
            {
                Clear();
                MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string query = "select id from tbl_bank_transaction where id =@id";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@id", currentId)))
                if (reader.Read())
                {
                    selectedId = int.Parse(reader["id"].ToString());
                    ShowData();
                }
                else
                {
                    Clear();
                    MessageBox.Show("No previous record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            frmImportBankData importForm = new frmImportBankData();
            if (importForm.ShowDialog() == DialogResult.OK)
            {
                DataTable importedData = importForm.ImportedData;
                dgvJV.Rows.Clear();

                foreach (DataRow row in importedData.Rows)
                {
                    int rowIndex = dgvJV.Rows.Add();
                    DataGridViewRow dgvRow = dgvJV.Rows[rowIndex];
                    dgvRow.Cells["account_id"].Value = 0;
                    dgvRow.Cells["dated"].Value = row["Date"];
                    dgvRow.Cells["description"].Value = row["Narration"];
                    dgvRow.Cells["debit"].Value = row["Debit"];
                    dgvRow.Cells["credit"].Value = row["Credit"];
                    dgvRow.Cells["balance"].Value = row["Balance"];
                    object d0 = GetAccountIdByName(row["Bank Name"].ToString());
                    if (d0 != null)
                    {
                        dgvRow.Cells["bank_ac"].Value = d0;
                    }
                    object d1 = GetAccountIdByName(row["Account Name"].ToString());
                    if(d1 != null)
                    {
                        dgvRow.Cells["account_name"].Value = d1;
                    }
                }
            }
        }

        private object GetAccountIdByName(string v)
        {
            object accountID = DBClass.ExecuteScalar("select id from tbl_coa_level_4 where name = @name", DBClass.CreateParameter("@name", v.Trim()));

            return accountID != null ? accountID : null;
        }

        private void guna2TileButton23_Click(object sender, EventArgs e)
        {
            dgvJV.Rows.Clear();
        }

        private void guna2TileButton22_Click(object sender, EventArgs e)
        {
            if (CheckRequired())
            {
                if (selectedId > 0)
                    EditData();
                else
                    SaveData();
            }
        }
        private void EditData()
        {
            // insert logic here
            foreach (DataGridViewRow row in dgvJV.Rows)
            {
                if (row.IsNewRow) continue;

                string query = @"UPDATE tbl_bank_transaction SET bank_account_id = @bank_account_id, account_id = @account_id, statement_date = @statement_date, 
                                value_date = @value_date, narration = @narration, debit = @debit, credit = @credit, running_balance = @running_balance, 
                                reference_no = @reference_no, cheque_no = @cheque_no, reconciled = @reconciled where id = @id;";

                DBClass.ExecuteNonQuery(query,
                    DBClass.CreateParameter("@bank_account_id", row.Cells["bank_ac"].Value),
                    DBClass.CreateParameter("@account_id", row.Cells["account_name"].Value),
                    DBClass.CreateParameter("@statement_date", Convert.ToDateTime(row.Cells["dated"].Value)),
                    DBClass.CreateParameter("@value_date", DateTime.Now.Date),
                    DBClass.CreateParameter("@narration", row.Cells["description"].Value),
                    DBClass.CreateParameter("@debit", row.Cells["debit"].Value.ToString().Replace(",", "")),
                    DBClass.CreateParameter("@credit", row.Cells["credit"].Value.ToString().Replace(",", "")),
                    DBClass.CreateParameter("@running_balance", row.Cells["balance"].Value.ToString().Replace(",", "")),
                    DBClass.CreateParameter("@reference_no", "0"),
                    DBClass.CreateParameter("@cheque_no", ""),
                    DBClass.CreateParameter("@reconciled", 0),
                    DBClass.CreateParameter("@id", selectedId)
                    );

                object obj0 = DBClass.ExecuteScalar("Select id from tbl_transaction where type = 'Bank' and t_type = 'Bank Statement' and transaction_id = @id and account_id = @acId", 
                    DBClass.CreateParameter("@id", selectedId),
                    DBClass.CreateParameter("@acId", row.Cells["bank_ac"].Value));
                int jvId0 = obj0 != null ? Convert.ToInt32(obj0) : 0;

                object obj1 = DBClass.ExecuteScalar("Select id from tbl_transaction where type = 'Bank' and t_type = 'Bank Statement' and transaction_id = @id and account_id = @acId",
                    DBClass.CreateParameter("@id", selectedId),
                DBClass.CreateParameter("@acId", row.Cells["account_name"].Value));
                int jvId1 = obj1 != null ? Convert.ToInt32(obj1) : 0;


                // ────────────── BANK SIDE ENTRY ──────────────
                CommonInsert.UpdateTransactionEntry(
                    jvId0,
                    Convert.ToDateTime(row.Cells["dated"].Value).Date,
                    Convert.ToInt32(row.Cells["bank_ac"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["debit"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["credit"].Value).ToString(),
                    selectedId.ToString(),
                    "0",
                    "Bank",
                    "Bank Statement",
                    row.Cells["description"].Value.ToString(),
                    frmLogin.userId,
                    DateTime.Now.Date
                    );

                // ────────────── COUNTER ACCOUNT ENTRY ──────────────
                CommonInsert.UpdateTransactionEntry(
                    jvId1,
                    Convert.ToDateTime(row.Cells["dated"].Value).Date,
                    Convert.ToInt32(row.Cells["account_name"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["credit"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["debit"].Value).ToString(),
                    selectedId.ToString(),
                    "0",
                    "Bank",
                    "Bank Statement",
                    row.Cells["description"].Value.ToString(),
                    frmLogin.userId,
                    DateTime.Now.Date
                    );
            }

            MessageBox.Show("Updated", "Successfully");
        }
        private void SaveData()
        {
            // insert logic here
            foreach (DataGridViewRow row in dgvJV.Rows)
            {
                if (row.IsNewRow) continue;

                string query = @"INSERT INTO tbl_bank_transaction (bank_account_id, account_id, statement_date, value_date, narration, debit, credit, running_balance, reference_no, cheque_no, reconciled) 
                            Values(@bank_account_id, @account_id, @statement_date, @value_date, @narration, @debit, @credit, @running_balance, @reference_no, @cheque_no, @reconciled); SELECT LAST_INSERT_ID();";

                int refId = int.Parse(DBClass.ExecuteScalar(query,
                    DBClass.CreateParameter("@bank_account_id", row.Cells["bank_ac"].Value),
                    DBClass.CreateParameter("@account_id", row.Cells["account_name"].Value),
                    DBClass.CreateParameter("@statement_date", Convert.ToDateTime(row.Cells["dated"].Value)),
                    DBClass.CreateParameter("@value_date", DateTime.Now.Date),
                    DBClass.CreateParameter("@narration", row.Cells["description"].Value),
                    DBClass.CreateParameter("@debit", row.Cells["debit"].Value.ToString().Replace(",", "")),
                    DBClass.CreateParameter("@credit", row.Cells["credit"].Value.ToString().Replace(",", "")),
                    DBClass.CreateParameter("@running_balance", row.Cells["balance"].Value.ToString().Replace(",", "")),
                    DBClass.CreateParameter("@reference_no", "0"),
                    DBClass.CreateParameter("@cheque_no", ""),
                    DBClass.CreateParameter("@reconciled", 0
                    )).ToString());

                // ────────────── BANK SIDE ENTRY ──────────────
                CommonInsert.addTransactionEntry(
                    Convert.ToDateTime(row.Cells["dated"].Value).Date,
                    Convert.ToInt32(row.Cells["bank_ac"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["debit"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["credit"].Value).ToString(),
                    refId.ToString(),
                    cmbBankName.SelectedValue.ToString(),
                    "Bank",
                    "Bank Statement",
                    row.Cells["description"].Value.ToString(),
                    frmLogin.userId,
                    DateTime.Now.Date,
                    "BTS-" + refId.ToString()
                    );

                // ────────────── COUNTER ACCOUNT ENTRY ──────────────
                CommonInsert.addTransactionEntry(
                    Convert.ToDateTime(row.Cells["dated"].Value).Date,
                    Convert.ToInt32(row.Cells["account_name"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["credit"].Value).ToString(),
                    Convert.ToDecimal(row.Cells["debit"].Value).ToString(),
                    refId.ToString(),
                    "0",
                    "Bank",
                    "Bank Statement",
                    row.Cells["description"].Value.ToString(),
                    frmLogin.userId,
                    DateTime.Now.Date,
                    "BTS-" + refId.ToString()
                    );
            }
            //int refId = (DBClass.ExecuteScalar(query,
            //    DBClass.CreateParameter("@bank_account_id", ),
            //    DBClass.CreateParameter("@account_id", DBNull.Value),
            //    DBClass.CreateParameter("@statement_date", DBNull.Value),
            //    DBClass.CreateParameter("@value_date", DBNull.Value),
            //    DBClass.CreateParameter("@narration", DBNull.Value),
            //    DBClass.CreateParameter("@debit", DBNull.Value),
            //    DBClass.CreateParameter("@credit", DBNull.Value),
            //    DBClass.CreateParameter("@running_balance", DBNull.Value),
            //    DBClass.CreateParameter("@reference_no", DBNull.Value),
            //    DBClass.CreateParameter("@cheque_no", DBNull.Value),
            //    DBClass.CreateParameter("@reconciled", DBNull.Value
            //    ));

            MessageBox.Show("Saved", "Successfully");
        }

        private bool CheckRequired()
        {
            if (dgvJV.Rows.Count == 0)
            {
                MessageBox.Show("No data to save.");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCreditAmount.Text))
            {
                MessageBox.Show("Please enter Amount.");
                return false;
            }
            else if (string.IsNullOrEmpty(txtDebitAmount.Text))
            {
                MessageBox.Show("Please enter Amount.");
                return false;
            }
            else if (cmbBankName.SelectedValue == null || cmbBankName.SelectedIndex <= 0)
            {
                MessageBox.Show("Select bank name.");
                return false;
            }

            return true;
        }

        private void calculateTotal()
        {
            decimal totalDebit = 0, totalCredit = 0;
            for (int i = 0; i < dgvJV.Rows.Count; i++)
            {
                if (dgvJV.Columns.Contains("Debit") && dgvJV.Columns.Contains("Credit"))
                {
                    var debitColumnIndex = dgvJV.Columns["Debit"].Index;
                    var creditColumnIndex = dgvJV.Columns["Credit"].Index;
                    var debitCellValue = dgvJV.Rows[i].Cells[debitColumnIndex].Value;
                    var creditCellValue = dgvJV.Rows[i].Cells[creditColumnIndex].Value;
                    if (debitCellValue == DBNull.Value || debitCellValue == null || string.IsNullOrEmpty(debitCellValue.ToString().Trim()) || creditCellValue == DBNull.Value || creditCellValue == null || string.IsNullOrEmpty(creditCellValue.ToString().Trim()))
                    {
                        //
                    }
                    else
                    {

                        if (dgvJV.Rows[i].Cells["Debit"].Value.ToString() != "" || dgvJV.CurrentRow.Cells["Credit"].Value.ToString() != "")
                        {
                            totalDebit += decimal.Parse(dgvJV.Rows[i].Cells["Debit"].Value.ToString());
                            totalCredit += decimal.Parse(dgvJV.Rows[i].Cells["Credit"].Value.ToString());
                        }
                    }
                }
            }
            txtDebitAmount.Text = totalDebit.ToString();
            txtCreditAmount.Text = totalCredit.ToString();
            validateDebitAndCreditAmount();
        }
        private bool validateDebitAndCreditAmount()
        {
            if (!string.IsNullOrEmpty(txtDebitAmount.Text) && !string.IsNullOrEmpty(txtCreditAmount.Text))
            {
                decimal dr = decimal.Parse(txtDebitAmount.Text);
                decimal cr = decimal.Parse(txtCreditAmount.Text);
                if (dr == 0 && cr == 0)
                {
                    return false;
                }
                if (dr == cr)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private void dgvJV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        private void dgvJV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvJV.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TileButton21_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Not found", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show(LocalizationManager.GetString("confirm_delete"), LocalizationManager.GetString("delete"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                DBClass.ExecuteNonQuery("DELETE FROM tbl_bank_transaction WHERE id = @id",
                    DBClass.CreateParameter("id", selectedId));
                CommonInsert.DeleteTransactionEntry(selectedId, "Bank Statement");
                Utilities.LogAudit(frmLogin.userId, "Delete Bank Transaction", "Bank Transaction", selectedId, "Deleted Bank Transaction: " + selectedId);
                Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {
            //make PDF
            if (selectedId > 0)
            {
                if (dgvJV.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ──────── 1. Create document & page ────────
                Document doc = new Document();
                Section section = doc.AddSection();
                section.PageSetup.TopMargin = Unit.FromCentimeter(1);
                section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
                section.PageSetup.RightMargin = Unit.FromCentimeter(1);
                section.PageSetup.BottomMargin = Unit.FromCentimeter(1);
                section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;

                // ──────── 2. Header (time ‑ title ‑ date) ────────
                Table headerTable = section.AddTable();
                headerTable.Borders.Width = 0;
                headerTable.AddColumn("5cm");
                headerTable.AddColumn("8cm");
                headerTable.AddColumn("5cm");

                Row headerRow = headerTable.AddRow();

                // left cell – time/date
                Paragraph left = headerRow.Cells[0].AddParagraph();
                left.Format.Font.Name = "Times New Roman";
                left.Format.Font.Size = 10;
                headerRow.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                left.AddText(DateTime.Now.ToString("hh:mm tt") + "\n" +
                             DateTime.Now.ToString("dd/MM/yyyy"));

                // center cell – title
                Paragraph center = headerRow.Cells[1].AddParagraph();
                center.Format.Font.Name = "Times New Roman";
                center.Format.Alignment = ParagraphAlignment.Center;
                center.AddFormattedText("Bank Transaction Details\n", TextFormat.Bold).Font.Size = 12;
                center.AddFormattedText("Bank Statement", TextFormat.NotBold).Font.Size = 9;
                headerRow.Cells[1].VerticalAlignment = VerticalAlignment.Top;

                // separator line
                Paragraph line = section.AddParagraph();
                line.Format.Borders.Bottom.Width = 2;
                line.Format.SpaceAfter = "0.5cm";

                // ──────── 3. Data table ────────
                Table table = section.AddTable();
                table.Borders.Width = 0.75;

                // columns: Date | Bank Name | Account Name | Debit | Credit | Running Balance | Description
                table.AddColumn("2.5cm");
                table.AddColumn("4cm");
                table.AddColumn("4cm");
                table.AddColumn("2.5cm");
                table.AddColumn("2.5cm");
                table.AddColumn("2.5cm");
                table.AddColumn("6cm");

                // header row
                Row hdr = table.AddRow();
                hdr.Shading.Color = Colors.LightGray;
                hdr.Cells[0].AddParagraph("Date").Format.Alignment = ParagraphAlignment.Center;
                hdr.Cells[1].AddParagraph("Bank Name").Format.Alignment = ParagraphAlignment.Center;
                hdr.Cells[2].AddParagraph("Account Name").Format.Alignment = ParagraphAlignment.Center;
                hdr.Cells[3].AddParagraph("Debit").Format.Alignment = ParagraphAlignment.Center;
                hdr.Cells[4].AddParagraph("Credit").Format.Alignment = ParagraphAlignment.Center;
                hdr.Cells[5].AddParagraph("Balance").Format.Alignment = ParagraphAlignment.Center;
                hdr.Cells[6].AddParagraph("Description").Format.Alignment = ParagraphAlignment.Center;

                // ──────── 4. Fill rows from DataGridView ────────
                foreach (DataGridViewRow row in dgvJV.Rows)
                {
                    if (row.IsNewRow) continue;

                    Row tRow = table.AddRow();
                    // Adjust column‑name strings if your Name properties differ
                    /*
                        DBClass.CreateParameter("@bank_account_id", row.Cells["bank_ac"].Value),
                        DBClass.CreateParameter("@account_id", row.Cells["account_name"].Value),
                        DBClass.CreateParameter("@statement_date", Convert.ToDateTime(row.Cells["dated"].Value)),
                        DBClass.CreateParameter("@value_date", DateTime.Now.Date),
                        DBClass.CreateParameter("@narration", row.Cells["description"].Value),
                        DBClass.CreateParameter("@debit", row.Cells["debit"].Value.ToString().Replace(",", "")),
                        DBClass.CreateParameter("@credit", row.Cells["credit"].Value.ToString().Replace(",", "")),
                        DBClass.CreateParameter("@running_balance", row.Cells["balance"].Value.ToString().Replace(",", "")),
                     */
                    tRow.Cells[0].AddParagraph(row.Cells["dated"].Value?.ToString() ?? "");
                    tRow.Cells[1].AddParagraph(row.Cells["bank_ac"].FormattedValue?.ToString() ?? "");
                    tRow.Cells[2].AddParagraph(row.Cells["account_name"].FormattedValue?.ToString() ?? "");
                    tRow.Cells[3].AddParagraph(string.Format("{0:N2}", row.Cells["debit"].Value)).Format.Alignment = ParagraphAlignment.Right;
                    tRow.Cells[4].AddParagraph(string.Format("{0:N2}", row.Cells["credit"].Value)).Format.Alignment = ParagraphAlignment.Right;
                    tRow.Cells[5].AddParagraph(string.Format("{0:N2}", row.Cells["balance"].Value)).Format.Alignment = ParagraphAlignment.Right;
                    tRow.Cells[6].AddParagraph(row.Cells["Description"].Value?.ToString() ?? "");

                    // optional: unifying font for data cells
                    for (int i = 0; i < 6; i++)
                    {
                        tRow.Cells[i].Format.Font.Name = "Times New Roman";
                        tRow.Cells[i].Format.Font.Size = 9;
                    }
                }

                // ──────── 5. Render and open PDF ────────
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                renderer.Document = doc;
                renderer.RenderDocument();

                string path = Path.Combine(Environment.GetFolderPath(
                                Environment.SpecialFolder.Desktop), "BankTransactionReport.pdf");
                renderer.PdfDocument.Save(path);
                Process.Start("explorer.exe", path);
            }
        }
    }
}

public class frmImportBankData : Form
{
    private TextBox txtStartCell, txtEndCell;
    TextBox txtDate, txtNarration, txtDebit, txtCredit, txtBalance, txtBankCode, txtBankName, txtAccountCode, txtAccountName;
    private Button btnLoadExcel, btnImport;
    private DataGridView dataGridView;
    private string excelPath = string.Empty;
    DataTable dtFiltered = new DataTable();
    public DataTable ImportedData { get; private set; }
    public frmImportBankData()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        this.Text = "Excel Import Form";
        this.Size = new Size(1300, 750);
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
        txtStartCell = new TextBox() { Width = textboxWidth, Location = new Point(x - 28, 12) };
        x += textboxWidth + spacing;

        // End Cell
        panelTop.Controls.Add(new Label() { Text = "End Cell:", AutoSize = true, Location = new Point(x - 26, 15) });
        x += labelWidth;
        txtEndCell = new TextBox() { Width = textboxWidth+10 , Location = new Point(x - 59, 12) };
        x += textboxWidth + spacing;

        // txtDate
        panelTop.Controls.Add(new Label() { Text = "Date Col:", AutoSize = true, Location = new Point(x - 56, 15) });
        x += labelWidth;
        txtDate = new TextBox() { Width = textboxWidth, Location = new Point(x - 84, 12) };
        x += textboxWidth + spacing;

        // txtNarration
        panelTop.Controls.Add(new Label() { Text = "Narration Col:", AutoSize = true, Location = new Point(x - 86, 15) });
        x += labelWidth;
        txtNarration = new TextBox() { Width = textboxWidth, Location = new Point(x - 95, 12) };
        x += textboxWidth + spacing;

        // txtDebit
        panelTop.Controls.Add(new Label() { Text = "Debit Col:", AutoSize = true, Location = new Point(x - 97, 15) });
        x += labelWidth;
        txtDebit = new TextBox() { Width = textboxWidth, Location = new Point(x - 125, 12) };
        x += textboxWidth + spacing;

        // txtCredit
        panelTop.Controls.Add(new Label() { Text = "Credit Col:", AutoSize = true, Location = new Point(x - 123, 15) });
        x += labelWidth;
        txtCredit = new TextBox() { Width = textboxWidth, Location = new Point(x - 142, 12) };
        x += textboxWidth + spacing;

        // txtBalance
        panelTop.Controls.Add(new Label() { Text = "Balance Col:", AutoSize = true, Location = new Point(x - 140, 15) });
        x += labelWidth;
        txtBalance = new TextBox() { Width = textboxWidth, Location = new Point(x - 152, 12) };
        x += textboxWidth + spacing;

        // txtBankCode
        panelTop.Controls.Add(new Label() { Text = "Bank Code Col:", AutoSize = true, Location = new Point(x - 148, 15) });
        x += labelWidth;
        txtBankCode = new TextBox() { Width = textboxWidth, Location = new Point(x - 148, 12) };
        x += textboxWidth + spacing;

        // txtBankName
        panelTop.Controls.Add(new Label() { Text = "Bank Name Col:", AutoSize = true, Location = new Point(x - 146, 15) });
        x += labelWidth;
        txtBankName = new TextBox() { Width = textboxWidth, Location = new Point(x - 142, 12) };
        x += textboxWidth + spacing;

        // txtAccountCode
        panelTop.Controls.Add(new Label() { Text = "Account Code Col:", AutoSize = true, Location = new Point(x - 136, 15) });
        x += labelWidth;
        txtAccountCode = new TextBox() { Width = textboxWidth, Location = new Point(x - 120, 12) };
        x += textboxWidth + spacing;

        // txtAccountName
        panelTop.Controls.Add(new Label() { Text = "Account Name Col:", AutoSize = true, Location = new Point(x - 120, 15) });
        x += labelWidth;
        txtAccountName = new TextBox() { Width = textboxWidth, Location = new Point(x - 100, 12) };
        x += textboxWidth + spacing;

        // Add controls to top panel
        panelTop.Controls.Add(txtStartCell);
        panelTop.Controls.Add(txtEndCell);
        panelTop.Controls.Add(txtDate);
        panelTop.Controls.Add(txtNarration);
        panelTop.Controls.Add(txtDebit);
        panelTop.Controls.Add(txtCredit);
        panelTop.Controls.Add(txtBalance);
        panelTop.Controls.Add(txtBankCode);
        panelTop.Controls.Add(txtBankName);
        panelTop.Controls.Add(txtAccountCode);
        panelTop.Controls.Add(txtAccountName);

        panelTop.Controls.Add(btnLoadExcel);
        panelTop.Controls.Add(btnImport);

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

        txtDate.KeyPress += TxtLettersOnly_KeyPress;
        txtAccountCode.KeyPress += TxtLettersOnly_KeyPress;
        txtAccountName.KeyPress += TxtLettersOnly_KeyPress;
        txtBalance.KeyPress += TxtLettersOnly_KeyPress;
        txtBankCode.KeyPress += TxtLettersOnly_KeyPress;
        txtBankName.KeyPress += TxtLettersOnly_KeyPress;
        txtCredit.KeyPress += TxtLettersOnly_KeyPress;
        txtDebit.KeyPress += TxtLettersOnly_KeyPress;
        txtNarration.KeyPress += TxtLettersOnly_KeyPress;
    }

    private void BtnImport_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(excelPath))
        {
            MessageBox.Show("Please load an Excel file first.");
            return;
        }
        else
        {
            //dataGridView.Rows.Clear();
            //dataGridView.Columns.Clear();
            if (dataGridView.Rows.Count > 0)
            {
                int startCol = ToNumber(txtStartCell.Text);
                int endCol = ToNumber(txtEndCell.Text);

                // Check for invalid inputs
                if (startCol == -1 || endCol == -1 || endCol < startCol)
                {
                    MessageBox.Show("Invalid start or end column.");
                    return;
                }

                int cDate = ExcelColumnNameToNumber(txtDate.Text);
                int cNarration = ExcelColumnNameToNumber(txtNarration.Text);
                int cDebit = ExcelColumnNameToNumber(txtDebit.Text);
                int cCredit = ExcelColumnNameToNumber(txtCredit.Text);
                int cBalance = ExcelColumnNameToNumber(txtBalance.Text);
                int cAcCode = ExcelColumnNameToNumber(txtAccountCode.Text);
                int cAcName = ExcelColumnNameToNumber(txtAccountName.Text);
                int cBankCode = ExcelColumnNameToNumber(txtBankCode.Text);
                int cBankName = ExcelColumnNameToNumber(txtBankName.Text);


                using (var package = new ExcelPackage(new FileInfo(excelPath)))
                {
                    // Create DataTable with new columns

                    dtFiltered.Columns.Add("Date");
                    dtFiltered.Columns.Add("Narration");
                    dtFiltered.Columns.Add("Debit");
                    dtFiltered.Columns.Add("Credit");
                    dtFiltered.Columns.Add("Balance");
                    dtFiltered.Columns.Add("Bank Code");
                    dtFiltered.Columns.Add("Bank Name");
                    dtFiltered.Columns.Add("Account Code");
                    dtFiltered.Columns.Add("Account Name");

                    var ws = package.Workbook.Worksheets[0];
                    for (int row = startCol; row <= endCol; row++)
                    {
                        if (IsRowEmpty(ws, row, endCol)) continue;
                        
                        DataRow dr = dtFiltered.NewRow();

                        //dr["Code"] = (colCode != -1) ? ws.Cells[row, colCode].Text : "";
                        //dr["Level1 Code"] = (cL1Code != -1) ? ws.Cells[row, cL1Code].Text : "";
                        //dr["Level4 Credit"] = (cCredit != -1) ? ws.Cells[row, cCredit].Text : "0";
                        dr["Date"] = (cDate != -1) ? ws.Cells[row, cDate].Text : "";
                        dr["Narration"] = (cNarration != -1) ? ws.Cells[row, cNarration].Text : "";
                        dr["Debit"] = (cDebit != -1) ? ws.Cells[row, cDebit].Text : "0";
                        dr["Credit"] = (cCredit != -1) ? ws.Cells[row, cCredit].Text : "0";
                        dr["Balance"] = (cBalance != -1) ? ws.Cells[row, cBalance].Text : "0";
                        dr["Bank Code"] = (cBankCode != -1) ? ws.Cells[row, cBankCode].Text : "";
                        dr["Bank Name"] = (cBankName != -1) ? ws.Cells[row, cBankName].Text : "";
                        dr["Account Code"] = (cAcCode != -1) ? ws.Cells[row, cAcCode].Text : "";
                        dr["Account Name"] = (cAcName != -1) ? ws.Cells[row, cAcName].Text : "";

                        dtFiltered.Rows.Add(dr);
                    }

                    // Now you can bind the filtered table somewhere or return it
                    dataGridView.DataSource = dtFiltered;
                }

                this.ImportedData = dtFiltered;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please load an Excel file first.");
                return;
            }
        }
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