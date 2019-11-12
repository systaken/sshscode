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
    public partial class TransactionFrm : Form
    {

        public List<Transactions> trx = new List<Transactions>();
        public TransactionFrm()
        {
            InitializeComponent();
        }

        private void TransactionFrm_Load(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.Fill;
            loadInformation();
        }

        private void loadInformation()
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource dtsource = new ReportDataSource("DataSales", trx);
            reportViewer1.LocalReport.ReportPath = "rpts/SalesReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(dtsource);
            reportViewer1.Visible = true;
            reportViewer1.RefreshReport();
        }
    }
}
