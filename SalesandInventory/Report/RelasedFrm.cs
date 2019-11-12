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
    public partial class RelasedFrm : Form
    {
        public List<ProductReleases> trx;
        public List<ProductReleasesReport> trx2;
        public string dateparams;
        public RelasedFrm()
        {
            InitializeComponent();
        }

        private void RelasedFrm_Load(object sender, EventArgs e)
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
                reportViewer1.LocalReport.ReportPath = "rpts/ReleaseItemReport.rdlc";
                reportViewer1.LocalReport.DataSources.Add(dtsource);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.Visible = true;
                reportViewer1.RefreshReport();
            }
            else
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource dtsource = new ReportDataSource("Released", trx);
                reportViewer1.LocalReport.ReportPath = "rpts/ReleasedItem.rdlc";
                reportViewer1.LocalReport.DataSources.Add(dtsource);
                reportViewer1.Visible = true;
                reportViewer1.RefreshReport();

            }
        }
    }
}
