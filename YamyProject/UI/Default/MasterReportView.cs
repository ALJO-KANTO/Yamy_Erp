using CrystalDecisions.CrystalReports.Engine;
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
    public partial class MasterReportView : Form
    {
        ReportDocument cr;
        string fileName;
        public MasterReportView(ReportDocument _cr, string _fileName)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.cr = _cr;
            this.fileName = _fileName;
        }

        private void MasterReportView_Load(object sender, EventArgs e)
        {
            //crReportViewer
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = fileName.Replace(" ", "_") + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                cr.ExportToDisk(
                    CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                    sfd.FileName);
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = fileName.Replace(" ", "_") + ".xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                cr.ExportToDisk(
                    CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook,
                    sfd.FileName);
            }
        }
    }
}
