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
    public partial class frmConsumptionEntry : Form
    {
        public frmConsumptionEntry()
        {
            InitializeComponent();
        }

        private void frmConsumptionEntry_Load(object sender, EventArgs e)
        {
            /*Purpose: Post actual used quantity against work done

            This is very important for construction.

            Header

            Consumption No
            Date
            Linked Issue No
            Work Order
            WBS
            Zone
            Activity
            Status

            Grid

            Item
            Issued Qty
            Consumed Qty
            Wastage Qty
            Balance On Site
            Return Qty
            */
        }
    }
}
