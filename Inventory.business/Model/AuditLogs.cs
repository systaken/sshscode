using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class AuditLogs
    {
        public int audit_id { get; set; }
        public string logModule { get; set; }
        public string logError { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}
