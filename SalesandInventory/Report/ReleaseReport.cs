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
    public partial class ReleaseReport : Form
    {
        private ReleaseRepositories _release = new ReleaseRepositories();
        public ReleaseReport()
        {
            InitializeComponent();
        }
        private void sbtnGen_Click(object sender, EventArgs e)
        {
            List<ProductReleasesReport> trx = new List<ProductReleasesReport>();
            trx = _release.ProductReleaseSelectbydate(dtfrom.Value,dtto.Value).ToList();
            Report.RelasedFrm frm = new Report.RelasedFrm();
            frm.trx2 = trx;
            frm.dateparams = dtfrom.Value.ToShortDateString() + " to " + dtto.Value.ToShortDateString();
            frm.Show();
        }
    }
}
