using Microsoft.Vbe.Interop;
using Org.BouncyCastle.Asn1.Cmp;
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

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmDelayHindranceLog : Form
    {
        int delayId = 0;

        public frmDelayHindranceLog()
        {
            InitializeComponent();
        }

        private void frmDelayHindranceLog_Load(object sender, EventArgs e)
        {
            LoadCombos();

            InitializeGrid();

            NewRecord();
        }

        void LoadCombos()
        {
            cmbProject.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_projects");

            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbSite.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_project_sites");

            cmbSite.DisplayMember = "name";
            cmbSite.ValueMember = "id";

            cmbZone.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,zone_name FROM tbl_project_zone");

            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbReportedBy.DataSource =
                DBClass.ExecuteDataTable(
                "SELECT id,name FROM tbl_employee");

            cmbReportedBy.DisplayMember =
                "name";

            cmbReportedBy.ValueMember =
                "id";

            cmbCategory.Items.AddRange(new object[]
            {
                "Weather",
                "Material Delay",
                "Labour Shortage",
                "Equipment Breakdown",
                "Consultant Delay",
                "Client Instruction",
                "Drawing Issue",
                "Permit Issue",
                "Utility Conflict",
                "Safety Issue"
            });

            cmbSeverity.Items.AddRange(new object[]
            {
                "Low",
                "Medium",
                "High",
                "Critical"
            });

            cmbResponsibleParty.Items.AddRange(
                new object[]
            {
                "Client",
                "Consultant",
                "Contractor",
                "Supplier",
                "Subcontractor",
                "Government Authority"
            });

            cmbWeather.Items.AddRange(new object[]
            {
                "Sunny",
                "Rainy",
                "Windy",
                "Cloudy",
                "Storm"
            });

            cmbStatus.Items.AddRange(new object[]
            {
                "Open",
                "Under Review",
                "Resolved",
                "Closed",
                "Approved"
            });
        }

        void InitializeGrid()
        {
            dgvFollowup.Columns.Add(
                "followup_date",
                "Date");

            dgvFollowup.Columns.Add(
                "action_taken",
                "Action Taken");

            dgvFollowup.Columns.Add(
                "responsible_person",
                "Responsible");

            dgvFollowup.Columns.Add(
                "target_date",
                "Target Date");

            dgvFollowup.Columns.Add(
                "status",
                "Status");

            dgvFollowup.Columns.Add(
                "remarks",
                "Remarks");

            dgvAttachment.Columns.Add(
                "file_name",
                "File Name");

            dgvAttachment.Columns.Add(
                "file_path",
                "File Path");

            dgvAttachment.Columns.Add(
                "remarks",
                "Remarks");
        }

        void NewRecord()
        {
            delayId = 0;

            txtDelayNo.Text =
                "DLY-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            dtDate.Value = DateTime.Today;

            dtStart.Value = DateTime.Now;

            dtEnd.Value = DateTime.Now;

            cmbStatus.Text = "Open";

            txtDelayHours.Text = "0";

            txtCostImpact.Text = "0";

            txtExtensionDays.Text = "0";

            txtAffectedArea.Clear();
            txtAffectedActivity.Clear();

            txtImpact.Clear();
            txtCorrective.Clear();
            txtPreventive.Clear();
            //txtRemarks.Clear();

            dgvFollowup.Rows.Clear();
            dgvAttachment.Rows.Clear();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            TimeSpan ts =
                dtEnd.Value - dtStart.Value;

            txtDelayHours.Text =
                ts.TotalHours.ToString("0.00");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDelay();
            SaveFollowup();
            SaveAttachments();

            MessageBox.Show("Delay / Hindrance Saved Successfully");
        }

        void SaveDelay()
        {
            string sql = @"
            INSERT INTO tbl_delay_hindrance
            (
                delay_no,
                delay_date,
                project_id,
                site_id,
                zone_id,
                reported_by,
                delay_category,
                severity,
                affected_area,
                affected_activity,
                start_datetime,
                end_datetime,
                total_delay_hours,
                responsible_party,
                weather_condition,
                impact_description,
                corrective_action,
                preventive_action,
                estimated_cost_impact,
                extension_days,
                status,
                remarks,
                created_by
            )
            VALUES
            (
                @delay_no,
                @delay_date,
                @project_id,
                @site_id,
                @zone_id,
                @reported_by,
                @delay_category,
                @severity,
                @affected_area,
                @affected_activity,
                @start_datetime,
                @end_datetime,
                @total_delay_hours,
                @responsible_party,
                @weather_condition,
                @impact_description,
                @corrective_action,
                @preventive_action,
                @estimated_cost_impact,
                @extension_days,
                @status,
                @remarks,
                @created_by
            );

            SELECT LAST_INSERT_ID();";

            delayId =
                Convert.ToInt32(
                DBClass.ExecuteScalar(sql,

                DBClass.CreateParameter(
                    "@delay_no",
                    txtDelayNo.Text),

                DBClass.CreateParameter(
                    "@delay_date",
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
                    "@reported_by",
                    cmbReportedBy.SelectedValue),

                DBClass.CreateParameter(
                    "@delay_category",
                    cmbCategory.Text),

                DBClass.CreateParameter(
                    "@severity",
                    cmbSeverity.Text),

                DBClass.CreateParameter(
                    "@affected_area",
                    txtAffectedArea.Text),

                DBClass.CreateParameter(
                    "@affected_activity",
                    txtAffectedActivity.Text),

                DBClass.CreateParameter(
                    "@start_datetime",
                    dtStart.Value),

                DBClass.CreateParameter(
                    "@end_datetime",
                    dtEnd.Value),

                DBClass.CreateParameter(
                    "@total_delay_hours",
                    txtDelayHours.Text),

                DBClass.CreateParameter(
                    "@responsible_party",
                    cmbResponsibleParty.Text),

                DBClass.CreateParameter(
                    "@weather_condition",
                    cmbWeather.Text),

                DBClass.CreateParameter(
                    "@impact_description",
                    txtImpact.Text),

                DBClass.CreateParameter(
                    "@corrective_action",
                    txtCorrective.Text),

                DBClass.CreateParameter(
                    "@preventive_action",
                    txtPreventive.Text),

                DBClass.CreateParameter(
                    "@estimated_cost_impact",
                    txtCostImpact.Text),

                DBClass.CreateParameter(
                    "@extension_days",
                    txtExtensionDays.Text),

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

        void SaveFollowup()
        {
            foreach (DataGridViewRow row in dgvFollowup.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_delay_followup
                (
                    delay_id,
                    followup_date,
                    action_taken,
                    responsible_person,
                    target_date,
                    status,
                    remarks
                )
                VALUES
                (
                    @delay_id,
                    @followup_date,
                    @action_taken,
                    @responsible_person,
                    @target_date,
                    @status,
                    @remarks
                )",

                DBClass.CreateParameter(
                    "@delay_id",
                    delayId),

                DBClass.CreateParameter(
                    "@followup_date",
                    row.Cells["followup_date"].Value),

                DBClass.CreateParameter(
                    "@action_taken",
                    row.Cells["action_taken"].Value),

                DBClass.CreateParameter(
                    "@responsible_person",
                    row.Cells["responsible_person"].Value),

                DBClass.CreateParameter(
                    "@target_date",
                    row.Cells["target_date"].Value),

                DBClass.CreateParameter(
                    "@status",
                    row.Cells["status"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        void SaveAttachments()
        {
            foreach (DataGridViewRow row in dgvAttachment.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_delay_attachment
                (
                    delay_id,
                    file_name,
                    file_path,
                    remarks
                )
                VALUES
                (
                    @delay_id,
                    @file_name,
                    @file_path,
                    @remarks
                )",

                DBClass.CreateParameter(
                    "@delay_id",
                    delayId),

                DBClass.CreateParameter(
                    "@file_name",
                    row.Cells["file_name"].Value),

                DBClass.CreateParameter(
                    "@file_path",
                    row.Cells["file_path"].Value),

                DBClass.CreateParameter(
                    "@remarks",
                    row.Cells["remarks"].Value));
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (delayId == 0)
                {
                    MessageBox.Show(
                        "Please save the record first.");

                    return;
                }

                DialogResult dr =
                    MessageBox.Show(
                    "Approve this delay record?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                DBClass.ExecuteNonQuery(@"
                UPDATE tbl_delay_hindrance
                SET
                    status='Approved',
                    approved_by=@approved_by
                WHERE delay_id=@delay_id",

                DBClass.CreateParameter(
                    "@approved_by",
                    frmLogin.userId),

                DBClass.CreateParameter(
                    "@delay_id",
                    delayId));

                cmbStatus.Text = "Approved";

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Approve Delay Log",
                    "Delay Hindrance",
                    delayId,
                    "Approved Delay Log : "
                    + txtDelayNo.Text);

                MessageBox.Show(
                    "Approved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
