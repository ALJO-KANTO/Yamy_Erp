using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management
{
    public partial class frmSiteDiary : Form
    {
        int diaryId = 0;
        public frmSiteDiary()
        {
            InitializeComponent();
        }

        private void frmSiteDiary_Load(object sender, EventArgs e)
        {
            LoadCombos();

            NewRecord();

            if (diaryId > 0)
            {
                LoadDiary(diaryId);
            }
        }

        void LoadDiary(int id)
        {
            try
            {
                DataTable dt =
                    DBClass.ExecuteDataTable(@"
                        SELECT *
                        FROM tbl_site_diary
                        WHERE diary_id=@id ",
                    DBClass.CreateParameter("@id", id));

                if (dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];
                diaryId = Convert.ToInt32(row["diary_id"]);
                txtDiaryNo.Text = row["diary_no"].ToString();
                dtDate.Value = Convert.ToDateTime(row["diary_date"]);
                cmbProject.SelectedValue = row["project_id"];
                cmbSite.SelectedValue = row["site_id"];
                cmbZone.SelectedValue = row["zone_id"];
                cmbEngineer.SelectedValue = row["engineer_id"];
                cmbWeather.Text = row["weather"].ToString();
                txtWorkDone.Text = row["work_done"].ToString();
                txtVisitors.Text = row["visitors"].ToString();
                txtIssues.Text = row["issues"].ToString();
                txtRemarks.Text = row["remarks"].ToString();
                cmbStatus.Text = row["status"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadCombos()
        {

            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_projects");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";

            cmbSite.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_project_sites");
            cmbSite.DisplayMember = "name";
            cmbSite.ValueMember = "id";

            cmbZone.DataSource = DBClass.ExecuteDataTable("SELECT id,zone_name FROM tbl_project_zone");
            cmbZone.DisplayMember = "zone_name";
            cmbZone.ValueMember = "id";

            cmbEngineer.DataSource = DBClass.ExecuteDataTable("SELECT id,name FROM tbl_employee");
            cmbEngineer.DisplayMember = "name";
            cmbEngineer.ValueMember = "id";

            cmbWeather.Items.Clear();
            cmbWeather.Items.AddRange(new object[]
                {
                "Sunny",
                "Cloudy",
                "Rain",
                "Storm",
                "Windy",
                "Fog"
                });
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[]
                {
                "Draft",
                "Submitted",
                "Approved"
                });
        }

        void NewRecord()
        {
            diaryId = 0;
            txtDiaryNo.Text = "SD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtDate.Value = DateTime.Today;
            cmbWeather.Text = "Sunny";
            cmbStatus.Text = "Draft";
            txtWorkDone.Clear();
            txtVisitors.Clear();
            txtIssues.Clear();
            txtRemarks.Clear();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (diaryId > 0)
            {
                UpdateDiary();
            }
            else
            {
                SaveDiary();
            }
        }
        void UpdateDiary()
        {
            try
            {

                DBClass.ExecuteNonQuery(@"
                        UPDATE tbl_site_diary SET
                        diary_date=@diary_date,
                        project_id=@project_id,
                        site_id=@site_id,
                        zone_id=@zone_id,
                        engineer_id=@engineer_id,
                        weather=@weather,
                        work_done=@work_done,
                        visitors=@visitors,
                        issues=@issues,
                        remarks=@remarks
                        WHERE diary_id=@diary_id
                        ",

                DBClass.CreateParameter("@diary_date", dtDate.Value.Date),
                DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                DBClass.CreateParameter("@site_id", cmbSite.SelectedValue),
                DBClass.CreateParameter("@zone_id", cmbZone.SelectedValue),
                DBClass.CreateParameter("@engineer_id", cmbEngineer.SelectedValue),
                DBClass.CreateParameter("@weather", cmbWeather.Text),
                DBClass.CreateParameter("@work_done", txtWorkDone.Text),
                DBClass.CreateParameter("@visitors", txtVisitors.Text),
                DBClass.CreateParameter("@issues", txtIssues.Text),
                DBClass.CreateParameter("@remarks", txtRemarks.Text),
                DBClass.CreateParameter("@diary_id", diaryId));

                MessageBox.Show("Site Diary Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void SaveDiary()
        {
            try
            {

                if (cmbProject.SelectedValue == null)
                {
                    MessageBox.Show("Please select project");
                    return;
                }


                string sql = @"

        INSERT INTO tbl_site_diary
        (
            diary_no,
            diary_date,

            project_id,
            site_id,
            zone_id,

            engineer_id,

            weather,

            work_done,

            visitors,

            issues,

            remarks,

            status,

            created_by
        )

        VALUES
        (
            @diary_no,
            @diary_date,

            @project_id,
            @site_id,
            @zone_id,

            @engineer_id,

            @weather,

            @work_done,

            @visitors,

            @issues,

            @remarks,

            @status,

            @created_by
        );


        SELECT LAST_INSERT_ID();
        ";



                diaryId =
                    Convert.ToInt32(
                    DBClass.ExecuteScalar(
                    sql,


                    DBClass.CreateParameter(
                        "@diary_no",
                        txtDiaryNo.Text),



                    DBClass.CreateParameter(
                        "@diary_date",
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
                        "@engineer_id",
                        cmbEngineer.SelectedValue),



                    DBClass.CreateParameter(
                        "@weather",
                        cmbWeather.Text),



                    DBClass.CreateParameter(
                        "@work_done",
                        txtWorkDone.Text),



                    DBClass.CreateParameter(
                        "@visitors",
                        txtVisitors.Text),



                    DBClass.CreateParameter(
                        "@issues",
                        txtIssues.Text),



                    DBClass.CreateParameter(
                        "@remarks",
                        txtRemarks.Text),



                    DBClass.CreateParameter(
                        "@status",
                        cmbStatus.Text),



                    DBClass.CreateParameter(
                        "@created_by",
                        frmLogin.userId)

                    ));



                MessageBox.Show(
                    "Site Diary Saved Successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            ApproveDiary();
        }
        void ApproveDiary()
        {
            try
            {
                if (diaryId == 0)
                {
                    MessageBox.Show("Please save the Site Diary first.");
                    return;
                }

                DialogResult dr =
                    MessageBox.Show(
                    "Approve this Site Diary?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


                if (dr != DialogResult.Yes)
                    return;

                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_site_diary
                    SET
                        status='Approved',
                        approved_by=@approved_by
                    WHERE diary_id=@diary_id
                    ",
                DBClass.CreateParameter(
                    "@approved_by",
                    frmLogin.userId),
                DBClass.CreateParameter(
                    "@diary_id",
                    diaryId)
                );

                cmbStatus.Text = "Approved";

                Utilities.LogAudit(
                    frmLogin.userId,
                    "Approve Site Diary",
                    "Site Diary",
                    diaryId,
                    "Approved Site Diary : "
                    + txtDiaryNo.Text
                );

                MessageBox.Show("Approved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void DeleteDiary()
        {
            try
            {
                if (diaryId == 0)
                    return;


                DialogResult dr =
                    MessageBox.Show(
                    "Delete this Site Diary?",
                    "Confirm",
                    MessageBoxButtons.YesNo);


                if (dr != DialogResult.Yes)
                    return;


                DBClass.ExecuteNonQuery(@"
                    DELETE FROM tbl_site_diary
                    WHERE diary_id=@id
                    ",
                DBClass.CreateParameter("@id", diaryId));
                MessageBox.Show("Deleted Successfully");

                NewRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
