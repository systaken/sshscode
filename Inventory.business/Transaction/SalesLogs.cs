using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data.Objects;
using Inventory.business.Logs;
using Inventory.business.Model;
namespace Inventory.business.Transaction
{
    public class SalesLogs : DBRepositories
    {
        public string _err = string.Empty;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public bool Create(trn_transaction_log trx)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_transaction_log_Insert(trx.sales_id,
                    trx.current_status,
                    trx.statusby,
                    trx.DateUpdated
                    );
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                a.logModule = "Sales Logs CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }
        //public bool Update(trn_transaction_log _ref)
        //{
        //    bool rtval = false;
        //    try
        //    {
        //        pEntity.trn_transactionsales_detail_Update(
        //            _ref.sales_detail_id,
        //            _ref.productcode,
        //            _ref.product_id,
        //            _ref.RetailPrice,
        //            _ref.QTY,
        //            _ref.TotalAmount,
        //            _ref.isCheckedout
        //            );
        //        pEntity.SaveChanges();
        //        rtval = true;
        //    }
        //    catch (Exception ex)
        //    {

        //        _err = ex.ToString();
        //        rtval = false;
        //    }
        //    return rtval;
        //}
        //public bool Delete(int id)
        //{
        //    bool rtval = false;
        //    try
        //    {
        //        pEntity.trn_transactionsales_detail_Delete(id, null);

        //        pEntity.SaveChanges();
        //        rtval = true;
        //    }
        //    catch (Exception ex)
        //    {

        //        _err = ex.ToString();
        //        rtval = false;
        //    }
        //    return rtval;
        //}
        public ObjectResult SelectAll()
        {
            return pEntity.trn_transaction_log_SelectAll();
        }
        public ObjectResult Search(trn_transaction_log trx)
        {
            return pEntity.trn_transaction_log_Search(
                    trx.statusLog_id,
                    trx.sales_id,
                    trx.current_status,
                    trx.statusby,
                    trx.DateUpdated
                );
        }
    }
}
