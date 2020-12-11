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
using System.Data.Objects;
using Inventory.business.Logs;



namespace SalesandInventory.Product
{
    public partial class SupplierFrm : Form
    {

        private Suppliers _suppliers = new Suppliers();
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public int Id { get; set; }
        public SupplierFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblcatid.Text != "")
                {

                    UpdateRecord();
                }
                else
                {
                    Insert();
                }
                MessageBox.Show("Record has been saved.");
            }
            catch (Exception ex)
            {
                a.logModule = "Supplier Entry";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                MessageBox.Show("No Record created data must be wrong please try again.");
            }
            this.Close();
        }

        private void Insert()
        {
            supplier r = new supplier();
            r.Supplier_name = txtname.Text;
            r.Supplier_address = textBox1.Text;
            r.Supplier_contact = textBox2.Text;
            r.isActive = true;
            _suppliers.Create(r);
        }

        private void UpdateRecord()
        {
            int id = Convert.ToInt32(lblcatid.Text);
            supplier r = new supplier();
            r.Supplier_name = txtname.Text;
            r.Supplier_address = textBox1.Text;
            r.Supplier_contact = textBox2.Text;
            r.supplier_id = id;
            _suppliers.Update(r);
        }

        private void SupplierFrm_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                lblcatid.Text = Id.ToString();
            }
            else
            {
                lblcatid.Text = string.Empty;
            }

            if (lblcatid.Text != string.Empty)
            {
                int id = Convert.ToInt32(lblcatid.Text);
                LoadInformation(id);
            }
        }

        private void LoadInformation(int id)
        {
            supplier dts = _suppliers.SelectById(id);
            txtname.Text = dts.Supplier_name;
            textBox1.Text = dts.Supplier_address;
            textBox2.Text = dts.Supplier_contact;
            lblcatid.Text = dts.supplier_id.ToString();
        }
    }
}
