using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using YamyProject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmWorkMeasurement : Form
    {
        int measurementId = 0;

        public frmWorkMeasurement()
        {
            InitializeComponent();

            Load += Frm_Load;

            btnSave.Click += BtnSave_Click;

            btnCalculate.Click += BtnCalculate_Click;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrid();

            if (measurementId > 0)
                LoadData();
            else
                NewRecord();
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_work_measurement where measurement_id = @id", DBClass.CreateParameter("id", measurementId)))
            {
                if (reader.Read())
                {
                    txtMeasurementNo.Text = reader["measurement_no"].ToString();
                    dtDate.Value = Convert.ToDateTime(reader["measurement_date"]);
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSite.SelectedValue = reader["site_id"];
                    cmbZone.SelectedValue = reader["zone_id"];
                    //reader["contractor_id"];
                    cmbEngineer.SelectedValue = reader["engineer_id"];
                    cmbConsultant.SelectedValue = reader["consultant_id"];
                    cmbReferenceType.Text = reader["reference_type"].ToString();
                    txtReferenceNo.Text = reader["reference_no"].ToString();
                    txtTotalQty.Text = reader["total_qty"].ToString();
                    txtTotalAmount.Text = reader["total_amount"].ToString();
                    cmbStatus.Text = reader["status"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();

                    using (MySqlDataReader readerMeasurement = DBClass.ExecuteReader("select * from bl_work_measurement_details where measurement_id=@id", DBClass.CreateParameter("id", measurementId)))
                    {
                        while (readerMeasurement.Read())
                        {
                            dgvMeasurement.Rows.Add(
                                readerMeasurement["item_code"],
                                readerMeasurement["description"],
                                readerMeasurement["unit"],
                                readerMeasurement["boq_qty"],
                                readerMeasurement["previous_qty"],
                                readerMeasurement["current_qty"],
                                readerMeasurement["cumulative_qty"],
                                readerMeasurement["balance_qty"],
                                readerMeasurement["rate"],
                                readerMeasurement["amount"],
                                readerMeasurement["progress_percent"],
                                readerMeasurement["remarks"]);
                        }

                        using (MySqlDataReader readerAttachment = DBClass.ExecuteReader("select * from tbl_work_measurement_attachment where measurement_id=@id", DBClass.CreateParameter("id", measurementId)))
                        {
                            dgvAttachment.Rows.Add(readerAttachment["file_path"], readerAttachment["description"]);
                        }
                        using (MySqlDataReader readerApproval = DBClass.ExecuteReader("select * from tbl_work_measurement_approval where measurement_id=@id", DBClass.CreateParameter("id", measurementId)))
                        {
                            dgvApproval.Rows.Add(readerApproval["approval_level"], readerApproval["approved_by"], readerApproval["approval_date"], readerApproval["status"], readerApproval["remarks"]);
                        }
                    }
                }
            }
        }

        void LoadCombos()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_projects");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbSite.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_project_sites");
            cmbSite.DisplayMember = "name";
            cmbSite.ValueMember = "id";

            cmbZone.DataSource = DBClass.ExecuteDataTable("SELECT id,zone_name FROM tbl_project_zone");
            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbEngineer.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_employee");
            cmbEngineer.DisplayMember = "name";
            cmbEngineer.ValueMember = "id";

            cmbConsultant.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_employee");
            cmbConsultant.DisplayMember = "name";
            cmbConsultant.ValueMember = "id";

            cmbReferenceType.Items.AddRange(new object[]
            {
                "BOQ",
                "IPC",
                "Subcontract",
                "Variation",
                "Site Work"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Draft",
                "Submitted",
                "Approved",
                "Rejected"
            });
        }

        void InitializeGrid()
        {
            dgvMeasurement.Columns.Add("item_code", "Item Code");

            dgvMeasurement.Columns.Add("description", "Description");

            dgvMeasurement.Columns.Add("unit", "Unit");

            dgvMeasurement.Columns.Add("boq_qty", "BOQ Qty");

            dgvMeasurement.Columns.Add("previous_qty", "Previous Qty");

            dgvMeasurement.Columns.Add("current_qty", "Current Qty");

            dgvMeasurement.Columns.Add("cumulative_qty", "Cumulative Qty");

            dgvMeasurement.Columns.Add("balance_qty", "Balance Qty");

            dgvMeasurement.Columns.Add("rate", "Rate");

            dgvMeasurement.Columns.Add("amount", "Amount");

            dgvMeasurement.Columns.Add("progress", "Progress %");

            dgvMeasurement.Columns.Add("remarks", "Remarks");

            dgvAttachment.Columns.Add("file_path", "File Path");
            dgvAttachment.Columns.Add("description", "Description");

            dgvApproval.Columns.Add("level", "Approval Level");
            dgvApproval.Columns.Add("approved_by", "Approved By");
            dgvApproval.Columns.Add("date", "Date");
            dgvApproval.Columns.Add("status", "Status");
            dgvApproval.Columns.Add("remarks", "Remarks");
        }

        void NewRecord()
        {
            measurementId = 0;

            txtMeasurementNo.Text =
                "WM-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            cmbStatus.Text = "Draft";

            txtTotalQty.Text = "0";
            txtTotalAmount.Text = "0";

            dgvMeasurement.Rows.Clear();
            dgvAttachment.Rows.Clear();
            dgvApproval.Rows.Clear();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        void CalculateTotals()
        {
            decimal totalQty = 0;
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvMeasurement.Rows)
            {
                if (row.IsNewRow) continue;

                decimal boqQty =
                    Utilities.ParseDecimalValue(
                        row.Cells["boq_qty"].Value);

                decimal prevQty =
                    Utilities.ParseDecimalValue(
                        row.Cells["previous_qty"].Value);

                decimal currentQty =
                    Utilities.ParseDecimalValue(
                        row.Cells["current_qty"].Value);

                decimal rate =
                    Utilities.ParseDecimalValue(
                        row.Cells["rate"].Value);

                decimal cumulative =
                    prevQty + currentQty;

                decimal balance =
                    boqQty - cumulative;

                decimal amount =
                    currentQty * rate;

                decimal progress = 0;

                if (boqQty > 0)
                {
                    progress =
                        (cumulative / boqQty) * 100;
                }

                row.Cells["cumulative_qty"].Value =
                    cumulative.ToString("0.000");

                row.Cells["balance_qty"].Value =
                    balance.ToString("0.000");

                row.Cells["amount"].Value =
                    amount.ToString("0.00");

                row.Cells["progress"].Value =
                    progress.ToString("0.00");

                totalQty += currentQty;
                totalAmount += amount;
            }

            txtTotalQty.Text =
                totalQty.ToString("0.000");

            txtTotalAmount.Text =
                totalAmount.ToString("0.00");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CalculateTotals();

            SaveHeader();

            SaveDetails();

            SaveAttachments();

            SaveApprovals();

            MessageBox.Show(
                "Work Measurement Saved Successfully");
        }

        void SaveHeader()
        {
            string sql = @"
            INSERT INTO tbl_work_measurement
            (
                measurement_no,
                measurement_date,
                project_id,
                site_id,
                zone_id,
                contractor_id,
                engineer_id,
                consultant_id,
                reference_type,
                reference_no,
                total_qty,
                total_amount,
                status,
                remarks,
                created_by
            )
            VALUES
            (
                @measurement_no,
                @measurement_date,
                @project_id,
                @site_id,
                @zone_id,
                @contractor_id,
                @engineer_id,
                @consultant_id,
                @reference_type,
                @reference_no,
                @total_qty,
                @total_amount,
                @status,
                @remarks,
                @created_by
            );

            SELECT LAST_INSERT_ID();";

            measurementId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter(
                    "@measurement_no",
                    txtMeasurementNo.Text),

                DBClass.CreateParameter(
                    "@measurement_date",
                    dtDate.Value.Date),

                DBClass.CreateParameter(
                    "@project_id",
                    cmbProject.SelectedValue),

                DBClass.CreateParameter(
                    "@site_id",
                    cmbSite.SelectedValue),

                DBClass.CreateParameter(
                    "@zone_id",
                    cmbZone.SelectedValue),

                DBClass.CreateParameter(
                    "@contractor_id", 0),

                DBClass.CreateParameter(
                    "@engineer_id",
                    cmbEngineer.SelectedValue),

                DBClass.CreateParameter(
                    "@consultant_id",
                    cmbConsultant.SelectedValue),

                DBClass.CreateParameter(
                    "@reference_type",
                    cmbReferenceType.Text),

                DBClass.CreateParameter(
                    "@reference_no",
                    txtReferenceNo.Text),

                DBClass.CreateParameter(
                    "@total_qty",
                    txtTotalQty.Text),

                DBClass.CreateParameter(
                    "@total_amount",
                    txtTotalAmount.Text),

                DBClass.CreateParameter(
                    "@status",
                    cmbStatus.Text),

                DBClass.CreateParameter(
                    "@remarks",
                    txtRemarks.Text),

                DBClass.CreateParameter(
                    "@created_by",
                    frmLogin.userId)
                ));
        }

        void SaveDetails()
        {
            foreach (DataGridViewRow row in dgvMeasurement.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_work_measurement_details
                (
                    measurement_id,
                    item_code,
                    description,
                    unit,
                    boq_qty,
                    previous_qty,
                    current_qty,
                    cumulative_qty,
                    balance_qty,
                    rate,
                    amount,
                    progress_percent,
                    remarks
                )
                VALUES
                (
                    @measurement_id,
                    @item_code,
                    @description,
                    @unit,
                    @boq_qty,
                    @previous_qty,
                    @current_qty,
                    @cumulative_qty,
                    @balance_qty,
                    @rate,
                    @amount,
                    @progress_percent,
                    @remarks
                )",

                DBClass.CreateParameter(
                    "@measurement_id",
                    measurementId),

                DBClass.CreateParameter(
                    "@item_code",
                    row.Cells["item_code"].Value),

                DBClass.CreateParameter(
                    "@description",
                    row.Cells["description"].Value),

                DBClass.CreateParameter(
                    "@unit",
                    row.Cells["unit"].Value),

                DBClass.CreateParameter(
                    "@boq_qty",
                    row.Cells["boq_qty"].Value),

                DBClass.CreateParameter(
                    "@previous_qty",
                    row.Cells["previous_qty"].Value),

                DBClass.CreateParameter(
                    "@current_qty",
                    row.Cells["current_qty"].Value),

                DBClass.CreateParameter(
                    "@cumulative_qty",
                    row.Cells["cumulative_qty"].Value),

                DBClass.CreateParameter(
                    "@balance_qty",
                    row.Cells["balance_qty"].Value),

                DBClass.CreateParameter(
                    "@rate",
                    row.Cells["rate"].Value),

                DBClass.CreateParameter(
                    "@amount",
                    row.Cells["amount"].Value),

                DBClass.CreateParameter(
                    "@progress_percent",
                    row.Cells["progress"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveAttachments()
        {
            foreach (DataGridViewRow row in dgvAttachment.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_work_measurement_attachment
                (
                    measurement_id,
                    file_path,
                    description
                )
                VALUES
                (
                    @measurement_id,
                    @file_path,
                    @description
                )",

                DBClass.CreateParameter(
                    "@measurement_id",
                    measurementId),

                DBClass.CreateParameter(
                    "@file_path",
                    row.Cells["file_path"].Value),

                DBClass.CreateParameter(
                    "@description",
                    row.Cells["description"].Value));
            }
        }

        void SaveApprovals()
        {
            foreach (DataGridViewRow row in dgvApproval.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_work_measurement_approval
                (
                    measurement_id,
                    approval_level,
                    approved_by,
                    approval_date,
                    status,
                    remarks
                )
                VALUES
                (
                    @measurement_id,
                    @approval_level,
                    @approved_by,
                    @approval_date,
                    @status,
                    @remarks
                )",

                DBClass.CreateParameter(
                    "@measurement_id",
                    measurementId),

                DBClass.CreateParameter(
                    "@approval_level",
                    row.Cells["level"].Value),

                DBClass.CreateParameter(
                    "@approved_by",
                    row.Cells["approved_by"].Value),

                DBClass.CreateParameter(
                    "@approval_date",
                    row.Cells["date"].Value),

                DBClass.CreateParameter(
                    "@status",
                    row.Cells["status"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }
    }
}