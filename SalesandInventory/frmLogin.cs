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
using Inventory.business.Security;
using System.Data.Objects;

namespace SalesandInventory
{
    public partial class frmLogin : Form
    {
        private User _us = new User();
        public frmLogin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = false;
            result = _us.IsAuthenticated(txtuser.Text, txtpassword.Text);
            if (result == true)
            {
                MDIParent parent = new MDIParent();
                parent.userid = _us._userId;
                parent.position = _us._position;
                parent.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password may be invalid.");
            }
        }
    }
}
