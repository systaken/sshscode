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
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }
        private void sbtnGen_Click(object sender, EventArgs e)
        {
            loadinformation();
        }
        private void loadinformation()
        {
            List<Transactions> trx = new List<Transactions>();
            Sales _trn = new Sales();
            Transactions req = new Transactions();
            string orderid = string.Empty;
            string status = string.Empty;
            string datefrom = string.Empty;
            string dateto = string.Empty;

            if (radioButton1.Checked == true)
            {
                req.isPaid = true;
            }
            else if (radioButton2.Checked == true)
            {
                req.isPaid = false;
            }
         
            if (dtfrom.Text != "")
            {
                datefrom = dtfrom.Value.ToString();
                dateto = dtto.Value.ToString();
                req.DateCreated = Convert.ToDateTime(datefrom);
                req.dateUpdated = Convert.ToDateTime(dateto);
            }
            trx = _trn.Search(req).ToList();
            Report.TransactionFrm frm = new Report.TransactionFrm();
            frm.trx = trx;
            frm.Show();
        }
    }
}
