using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class supplier
    {
        public int supplier_id { get; set; }
        public string Supplier_name { get; set; }
        public string Supplier_address { get; set; }
        public string Supplier_contact { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<bool> isActive { get; set; }

    }
}
