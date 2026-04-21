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
    public partial class frmStockBalanceInquiry : Form
    {
        public frmStockBalanceInquiry()
        {
            InitializeComponent();
        }

        private void frmStockBalanceInquiry_Load(object sender, EventArgs e)
        {
            /*Purpose: current stock by item / warehouse / bin

            Columns

            Item
            Warehouse
            Bin
            Qty On Hand
            Reserved Qty
            Available Qty
            Avg Rate
            Stock Value*/
        }
    }
}
