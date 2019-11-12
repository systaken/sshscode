using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.business.Model;
using Inventory.business.Configs;
using Inventory.business.Transaction;


namespace SalesandInventory.Transaction
{
    public partial class ReceiptConfirmFrm : Form
    {
        public ReceiptConfirmFrm()
        {
            InitializeComponent();
        }
        public string sdate;
        public string orderId;
        public string totalamount;
        public string discount;
        public string gtotal;
        public string status;
        public Transactions txn = new Transactions();
        private Categorys _category = new Categorys();
        private Measures _measures = new Measures();
        private Products _product = new Products();
        private Sales _trn = new Sales();
        private ReportClass rclass = new ReportClass();
        private SalesDetail _trnd = new SalesDetail();
        private void button1_Click(object sender, EventArgs e)
        {

            UpdateRecord();
            if (MessageBox.Show("Print Receipt?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //call the printeceipt form on this area.

                Report.PrintReceipt frm = new Report.PrintReceipt();
                frm.MdiParent = MdiParent;
                int index = Convert.ToInt32(lblorderid.Text);
                List<DeliveryReceipt> trxn = new List<DeliveryReceipt>();
                trxn = rclass.CustomerReceipt(index);
                frm.trx = trxn;
                frm.isOldTemplate = false;
                frm.Show();
            }
            else
            {

                MessageBox.Show("You can still print receipt on order lists form");
                this.Close();
            }

        }
        private void UpdateRecord()
        {
            //TODO check if the customer has existing loan
            txn.sales_id = Convert.ToInt32(lblorderid.Text);
            txn.TotalAmount = Convert.ToDouble(lblamount.Text);
            txn.Discounted = Convert.ToDouble(txtdiscount.Text);
            txn.GrandTotal = Convert.ToDouble(lblgrandtotal.Text);
            txn.AmountPaid = Convert.ToDouble(txtpdamount.Text);
            txn.PayBalance = Convert.ToDouble(lblpaybalance.Text);
            txn.payterms = comboBox1.Text;
            if (txtnodays.Text != string.Empty)
            {
                txn.nosofdays = Convert.ToInt16(txtnodays.Text);
            }
            else
            {
                txn.nosofdays = 0;
            }
            if (lblpaybalance.Text == "0" || comboBox1.SelectedItem.ToString() == "Cash" || comboBox1.SelectedItem.ToString() == "C.O.D")
            {
                txn.isPaid = true;
            }
            txn.isVoided = false;   
            txn.status = "For Release";
            _trn.Update(txn);
        }
        private void ReceiptConfirmFrm_Load(object sender, EventArgs e)
        {
            lbldate.Text = Convert.ToDateTime(sdate).ToShortDateString();
            lblorderid.Text = orderId;
            lblamount.Text = totalamount;
            lblgrandtotal.Text = gtotal;
            txtdiscount.Text = discount;
        }
        private void txtpdamount_TextChanged(object sender, EventArgs e)
        {

            if (txtpdamount.Text == string.Empty)
            {
                txtpdamount.Text = "0";
            }

            lblpaybalance.Text = (Convert.ToDouble(lblgrandtotal.Text) - Convert.ToDouble(txtpdamount.Text)).ToString();
        }
        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            if (lblamount.Text == string.Empty || txtdiscount.Text == string.Empty)
            {
                txtdiscount.Text = "0";
            }
            lblgrandtotal.Text = (Convert.ToDouble(lblamount.Text) - Convert.ToDouble(txtdiscount.Text)).ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Check" || comboBox1.SelectedItem.ToString() == "Credit")
            {
                txtnodays.Enabled = true;
            }
            else
            {
                txtnodays.Enabled = false;
            }
        }
    }
}
