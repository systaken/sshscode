using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.business.Model;
using Inventory.business.Transaction;

namespace SalesandInventory.Report
{
    public partial class CheckedinReport : Form
    {
        private Purchase _pr = new Purchase();
        public CheckedinReport()
        {
            InitializeComponent();
        }

        private void sbtnGen_Click(object sender, EventArgs e)
        {
            List<PurchaseItemReport> trx = new List<PurchaseItemReport>();
            trx = _pr.SelectItemListsBydateReport(true,dtfrom.Value,dtto.Value).ToList();
            Report.POReport frm = new Report.POReport();
            string datepars = dtfrom.Value.ToShortDateString() + " - " + dtto.Value.ToShortDateString();
            frm.dateparams = datepars;
            frm.trx2 = trx;
            frm.Show();
        }
    }
}
