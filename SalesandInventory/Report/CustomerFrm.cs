using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Inventory.business.Model;
using Inventory.business.Transaction;
using Inventory.business.Configs;
namespace SalesandInventory.Report
{
    public partial class CustomerFrm : Form
    {
        private ReportClass rc = new ReportClass();
        public CustomerFrm()
        {
            InitializeComponent();
        }

        private void CustomerFrm_Load(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.Fill;
        }

        private void loadReport()
        {
            List<CustomerPurchase> cp = rc.CustomerPurchaseLists(dtfrom.Value, dtto.Value);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource dtsource = new ReportDataSource("DataSet1", cp);
            reportViewer1.LocalReport.ReportPath = "rpts/customerPurchase.rdlc";
            reportViewer1.LocalReport.DataSources.Add(dtsource);
            reportViewer1.Visible = true;
            reportViewer1.RefreshReport();
        }

        private void sbtnGen_Click(object sender, EventArgs e)
        {
            loadReport();
        }
    }
}
