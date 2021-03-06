﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class CustomerInfo
    {
        public int customer_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middle { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> bBdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string TelNos { get; set; }
        public string cpno { get; set; }
        public string emailaddress { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public string AgentName { get; set; }
        public string Terms { get; set; }
        public Nullable<double> Discount { get; set; }
        public string BusinessName { get; set; }
        public Nullable<int> truck_id { get; set; }
        public Nullable<bool> isDelete { get; set; }

    }
}
