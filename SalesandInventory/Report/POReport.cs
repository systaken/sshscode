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
    public partial class POReport : Form
    {
        public List<PurchaseItem> trx;
        public List<PurchaseItemReport> trx2;

        public string dateparams;
        public POReport()
        {
            InitializeComponent();
        }

        private void POReport_Load(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.Fill;
            loadInformation();
        }

        private void loadInformation()
        {
            if (dateparams != string.Empty)
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource dtsource = new ReportDataSource("DataSet1", trx2);
                reportViewer1.LocalReport.ReportPath = "rpts/POReportDates.rdlc";
                reportViewer1.LocalReport.DataSources.Add(dtsource);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.Visible = true;
                reportViewer1.RefreshReport();
            }
            else
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource dtsource = new ReportDataSource("DataSet1", trx);
                reportViewer1.LocalReport.ReportPath = "rpts/CheckStockItem.rdlc";
                reportViewer1.LocalReport.DataSources.Add(dtsource);
                reportViewer1.Visible = true;
                reportViewer1.RefreshReport();
            }
        }
    }
}
