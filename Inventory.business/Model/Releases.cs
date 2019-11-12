using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class Releases
    {
        public int sales_detail_id { get; set; }
        public Nullable<int> releaseQTY { get; set; }
        public string productcode { get; set; }
        public string ProductName { get; set; }
    }
}
