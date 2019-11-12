using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class TransactionDetails
    {
        public int sales_detail_id { get; set; }
        public string productcode { get; set; }
        public Nullable<int> sales_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<bool> isCheckedout { get; set; }
        public string ProductName { get; set; }
    }
}
