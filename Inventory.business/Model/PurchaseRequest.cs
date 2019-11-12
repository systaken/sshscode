using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
   public class PurchaseRequest
    {
        public int po_id { get; set; }
        public string poRef { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<bool> isCompleted { get; set; }
        public string status { get; set; }
    }
}
