using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data;
using System.Data.Objects;
using Inventory.business.Model;

namespace Inventory.business.Logs
{
    public class Loggers : DBRepositories
    {
        public string _err = string.Empty;
        public bool InsertLog(AuditLogs logs)
        {
            bool rtval = false;
            try
            {
                pEntity.log_audit_Insert(logs.logModule,logs.logError,logs.DateCreated);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                rtval = false;
            }
            return rtval;
        }
    }
}
