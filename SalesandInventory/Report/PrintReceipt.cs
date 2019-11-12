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
    public partial class PrintReceipt : Form
    {
        public List<DeliveryReceipt> trx;
        public bool isOldTemplate;
        public PrintReceipt()
        {
            InitializeComponent();
        }

        private void PrintReceipt_Load(object sender, EventArgs e)
        {
            loadinformation();
        }
        private void loadinformation()
        {
            if (isOldTemplate == true)
            {

            }
            else
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource dtsource = new ReportDataSource("pRelease", trx);
                reportViewer1.LocalReport.ReportPath = "rpts/ReceiptDeliverNew.rdlc";
                reportViewer1.LocalReport.DataSources.Add(dtsource);
                reportViewer1.Visible = true;
                reportViewer1.RefreshReport();
            }
        }
    }
}
