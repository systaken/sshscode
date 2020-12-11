using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data;
using System.Data.Objects;
using Inventory.business.Model;
using Inventory.business.Logs;
namespace Inventory.business.Configs
{
    public class ProductDetails : DBRepositories
    {
        public string _err = string.Empty;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public bool Create(trn_productDetail _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_productdetail_Insert(_ref.product_detail_id,
                    _ref.product_id,
                    _ref.measurement,
                    _ref.measurevalue,
                    _ref.supplierprice,
                    _ref.retailprice,
                    _ref.QTY,
                    _ref.dateupdated,
                    _ref.datecreated,
                    _ref.updatedby,
                    _ref.isActive,
                    _ref.isDelete,
                    _ref.ExpiryDate
                    );
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Product Detail CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }

        public bool Update(trn_productDetail _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_productdetail_Update(
                    _ref.product_detail_id,
                    _ref.product_id,
                    _ref.measurement,
                    _ref.measurevalue,
                    _ref.supplierprice,
                    _ref.retailprice,
                    _ref.QTY,
                    _ref.dateupdated,
                    _ref.datecreated,
                    _ref.updatedby,
                    _ref.isActive,
                    _ref.isDelete,
                    _ref.ExpiryDate
                    );
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Product Detail CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public ObjectResult Search(trn_productDetail _ref)
        {
            return pEntity.trn_productDetail_Search(
                _ref.product_detail_id,
                    _ref.product_id,
                    _ref.measurement,
                    _ref.measurevalue,
                    _ref.supplierprice,
                    _ref.retailprice,
                    _ref.QTY,
                    _ref.dateupdated,
                    _ref.datecreated,
                    _ref.updatedby,
                    _ref.isActive,
                    _ref.isDelete,
                    _ref.ExpiryDate
                );
        }
        public ObjectResult SelectAll()
        {
            return pEntity.trn_productdetail_SelectAll();
        }

    }
}
