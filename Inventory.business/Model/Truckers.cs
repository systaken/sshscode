using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class Truckers
    {
        public int trucking_id { get; set; }
        public string trucking_name { get; set; }
        public string platenos { get; set; }
        public Nullable<bool> isDelete { get; set; }
    }
}
