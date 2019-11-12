using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class PR_relase_item
    {
        public int po_detail_id { get; set; }
        public Nullable<int> po_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> QTY { get; set; }
        public string Measurement { get; set; }
        public Nullable<double> Purchaseprice { get; set; }
        public Nullable<bool> isCheckedIn { get; set; }
        public Nullable<System.DateTime> DateUpdate { get; set; }
        public Nullable<int> ReleasedBy { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
