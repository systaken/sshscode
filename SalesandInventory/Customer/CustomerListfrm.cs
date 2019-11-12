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
namespace SalesandInventory.Customer
{
    public partial class CustomerListfrm : Form
    {
        private CustomerInfo cus = new CustomerInfo();
        public int Id { get; set; }
        public string cusName { get; set; }
        private Inventory.business.Transaction.Customer _cus = new Inventory.business.Transaction.Customer();
        public CustomerListfrm()
        {
            InitializeComponent();
        }

        private void CustomerListfrm_Load(object sender, EventArgs e)
        {
            loadInformation();
        }

        private void loadInformation()
        {
            ProdListV.Items.Clear();
            ListViewItem itm;
            List<CustomerInfo> cs = new List<CustomerInfo>();
            cs = _cus.SelectAll();
            foreach (CustomerInfo ci in cs)
            {
                itm = new ListViewItem();
                itm.Text = ci.customer_id.ToString();
                itm.SubItems.Add(ci.Firstname);
                itm.SubItems.Add(ci.Lastname);
                itm.SubItems.Add(ci.Middle);
                ProdListV.Items.Add(itm);
            }
        }

        private void ProdListV_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(ProdListV.SelectedItems[0].Text);
            cusName = ProdListV.SelectedItems[0].SubItems[1].Text + " " + ProdListV.SelectedItems[0].SubItems[2].Text + " " + ProdListV.SelectedItems[0].SubItems[3].Text;
            this.Close();
        }
            
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CustomerInfo c = new CustomerInfo();
            c.Firstname = textBox1.Text;
            c.Lastname = textBox1.Text;

            ProdListV.Items.Clear();
            ListViewItem itm;
            List<CustomerInfo> cs = new List<CustomerInfo>();

            if(textBox1.Text == string.Empty)
            {
                cs = _cus.SelectAll();
            }
            else
            { 
                cs = _cus.Search(c);
            }
            foreach (CustomerInfo ci in cs)
            {
                itm = new ListViewItem();
                itm.Text = ci.customer_id.ToString();
                itm.SubItems.Add(ci.Firstname);
                itm.SubItems.Add(ci.Lastname);
                itm.SubItems.Add(ci.Middle);
                ProdListV.Items.Add(itm);
            }

        }
        
    }
}
