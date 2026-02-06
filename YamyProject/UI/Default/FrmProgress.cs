using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Default
{
    public partial class FrmProgress : Form
    {
        public bool CancelRequested = false;
        public FrmProgress()
        {
            InitializeComponent();
        }

        private void FrmProgress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CancelRequested = true;
        }
        public void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(value)));
                return;
            }

            if (value < 0) value = 0;
            if (value > 100) value = 100;

            progressBar1.Value = value;
            lblPercent.Text = value + " %";
        }
    }
}
