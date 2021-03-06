﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class CustomerPurchase
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middle { get; set; }
        public int sales_id { get; set; }
        public string productcode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string unitWeight { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public string referenceNo { get; set; }
        public string measurement { get; set; }
    }
}
