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

namespace YamyProject.UI.Settings
{
    public partial class frmSyncData : Form
    {
        public frmSyncData()
        {
            InitializeComponent();
        }
        private void frmSyncData_Load(object sender, EventArgs e)
        {
            dtpLastSync.Value =
                SyncData.LoadLastSyncFromLocalStorage();
        }

        private async void btnStartSync_Click(
            object sender,
            EventArgs e)
        {
            btnStartSync.Enabled = false;

            bool apiAvailable = await IsApiAvailable();

            if (apiAvailable)
            {
                try
                {
                    DateTime lastSync = dtpLastSync.Value.Date;

                    List<(string Name, Func<Task> Action)> steps =
                    new List<(string, Func<Task>)>
                {
                ("Upload COA Level 2", () => SyncData.UploadCoaLevel2()),
                ("Upload COA Level 3", () => SyncData.UploadCoaLevel3()),
                ("Upload COA Level 4", () => SyncData.UploadCoaLevel4()),
                ("Upload Customers", () => SyncData.UploadCustomers()),
                ("Upload Vendors", () => SyncData.UploadVendors()),
                ("Upload Advance Payment Voucher", () => SyncData.UploadAdvancePaymentVouchers()),
                ("Upload Journal Voucher", () => SyncData.UploadJournalVoucher()),
                ("Upload Items", () => SyncData.UploadItems()),
                ("Upload Purchases", () => SyncData.UploadPurchases()),
                ("Upload Payment Voucher", () => SyncData.UploadPaymentVoucher()),
                ("Upload Sales", () => SyncData.UploadSales()),
                ("Upload Receipt Voucher", () => SyncData.UploadReceiptVoucher()),

                ("Download COA Level 2", () => SyncData.DownloadCoaLevel2()),
                ("Download COA Level 3", () => SyncData.DownloadCoaLevel3()),
                ("Download COA Level 4", () => SyncData.DownloadCoaLevel4()),
                ("Download Customers", () => SyncData.DownloadCustomers(lastSync)),
                ("Download Vendors", () => SyncData.DownloadVendors(lastSync)),
                ("Download Advance Payment Voucher", () => SyncData.DownloadAdvancePaymentVouchers(lastSync)),
                ("Download Journal Voucher", () => SyncData.DownloadJournalVoucher(lastSync)),
                ("Download Items", () => SyncData.DownloadItems(lastSync)),
                ("Download Purchases", () => SyncData.DownloadPurchases(lastSync)),
                ("Download Payment Voucher", () => SyncData.DownloadPaymentVoucher(lastSync)),
                ("Download Sales", () => SyncData.DownloadSales(lastSync)),
                ("Download Receipt Voucher", () => SyncData.DownloadReceiptVoucher(lastSync))
                };

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = steps.Count;
                    progressBar1.Value = 0;

                    int current = 0;

                    foreach (var step in steps)
                    {
                        lblStatus.Text = step.Name;

                        await step.Action();

                        current++;
                        progressBar1.Value = current;

                        Application.DoEvents();
                    }

                    SyncData.SaveLastSyncToLocalStorage(
                        DateTime.Now);

                    dtpLastSync.Value =
                        SyncData.LoadLastSyncFromLocalStorage();

                    lblStatus.Text = "Completed";

                    MessageBox.Show(
                        "Synchronization Completed Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    btnStartSync.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(
                    "Sync Server not avilable",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private async Task<bool> IsApiAvailable()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    // Your API health endpoint
                    var response = await client.GetAsync(
                        $"{SyncData.hostedUrl}WeatherForecast");

                    return response.IsSuccessStatusCode; // 200-299
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
