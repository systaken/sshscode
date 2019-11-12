﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.business.Model;
using Inventory.business.Transaction;


namespace SalesandInventory.Customer
{
    public partial class CustomerFrm : Form
    {
        public bool _isEdit;
        private CustomerInfo cus = new CustomerInfo();
        private Inventory.business.Transaction.Customer _cus = new  Inventory.business.Transaction.Customer();
        public int Id { get; set; }
        public string cusName { get; set; }

        public CustomerFrm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SaveRecord();
            //Transaction.OrderFrm parent = (Transaction.OrderFrm)this.Owner;
            //parent.cusid = Id;
            this.Close();
        }

        private void loadinformation(int id)
        {
            cus= _cus.SelectById(id);

            txtfirstname.Text = cus.Firstname;
            txtlastname.Text = cus.Lastname;
            txtmiddle.Text = cus.Middle;
            dtbdate.Text = cus.bBdate.ToString();
            txtaddress.Text = cus.Address;
            txtcity.Text = cus.City;
            txttel.Text = cus.TelNos;
            txtcell.Text = cus.cpno;
            txtemail.Text = cus.emailaddress;
        }

        private void SaveRecord()
        {

            string gender = string.Empty;
            cus.Firstname = txtfirstname.Text;
            cus.Lastname = txtlastname.Text;
            cus.Middle = txtmiddle.Text;
            cus.bBdate = Convert.ToDateTime(dtbdate.Text);
            cus.Address = txtaddress.Text;
            cus.City = txtcity.Text;
            cus.TelNos = txttel.Text;
            cus.cpno = txtcell.Text;
            cus.emailaddress = txtemail.Text;
            cus.datecreated = DateTime.Now;
           
            if (rmale.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if (_isEdit == false)
            {
                Id = _cus.Create(cus);
                cusName = cus.Firstname + " " + cus.Lastname + " " + cus.Middle;
            }
            else
            {
                cus.customer_id = Convert.ToInt32(lblcustid.Text);
                _cus.Update(cus);
            }
            MessageBox.Show("Record has been saved");
        }

        private void CustomerFrm_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                lblcustid.Text = Id.ToString();
                loadinformation(Convert.ToInt32(lblcustid.Text));
            }
            else
            {
                lblcustid.Text = Id.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}