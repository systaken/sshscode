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
    public class Products : DBRepositories
    {
        public string _err = string.Empty;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public bool Create(product _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_product_Insert(_ref.product_id,_ref.category_id,_ref.ProductCode,_ref.ProductName, _ref.ProductDescription,
                _ref.Barcode,_ref.measurement,_ref.supplierprice,_ref.retailprice,_ref.QTY,_ref.criticalQTY, _ref.unitWeight,_ref.Weight, _ref.Expirydate, _ref.isDelete,_ref.isActive,_ref.supplier_id,_ref.dateCreated,
                _ref.updatedBy,_ref.dateUpdated);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Product CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }
        public bool Update(product _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_product_Update(_ref.product_id, _ref.category_id, _ref.ProductCode, _ref.ProductName, _ref.ProductDescription,
                _ref.Barcode, _ref.measurement, _ref.supplierprice, _ref.retailprice,_ref.criticalQTY, _ref.unitWeight, _ref.Weight, _ref.Expirydate,_ref.isDelete, _ref.isActive, _ref.supplier_id,
                _ref.updatedBy, _ref.dateUpdated);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Product CS";
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
        public List<product> SelectAll()
        {
    
            List<product> ps = new List<product>();
            List<ref_product_SelectAll_Result> x = pEntity.ref_product_SelectAll().ToList();
           
            foreach (ref_product_SelectAll_Result pr in x)
            {
                product result = new product();
                result.Barcode = pr.Barcode;
                result.category_id = pr.category_id;
                result.criticalQTY = pr.criticalQTY;
                result.Expirydate = pr.Expirydate;
                result.measurement = pr.measurement;
                result.dateCreated = pr.dateCreated;
                result.dateUpdated = pr.dateUpdated;
                result.isActive = pr.isActive;
                result.isDelete = pr.isDelete;
                result.ProductCode = pr.ProductCode;
                result.ProductDescription = pr.ProductDescription;
                result.ProductName = pr.ProductName;
                result.product_id = pr.product_id;
                result.QTY = pr.QTY;
                result.retailprice = pr.retailprice;
                result.supplierprice = pr.supplierprice;
                result.supplier_id = pr.supplier_id;
                result.updatedBy = pr.updatedBy;
                result.Weight = pr.Weight;
                result.unitWeight = pr.unitWeight;
                ps.Add(result);
                //ps.AddRange(result);
            }


            return ps;
        }


        public List<ProductResult> SelectReport()
        {

            List<ProductResult> ps = new List<ProductResult>();
            List<ref_product_SelectAll_Result> x = pEntity.ref_product_SelectAll().ToList();

            foreach (ref_product_SelectAll_Result pr in x)
            {
                ProductResult result = new ProductResult();
                result.Barcode = pr.Barcode;
                result.category_id = pr.category_id;
                result.criticalQTY = pr.criticalQTY;
                result.Expirydate = pr.Expirydate;
                result.measurement = pr.measurement;
                result.dateCreated = pr.dateCreated;
                result.dateUpdated = pr.dateUpdated;
                result.isActive = pr.isActive;
                result.isDelete = pr.isDelete;
                result.ProductCode = pr.ProductCode;
                result.ProductDescription = pr.ProductDescription;
                result.ProductName = pr.ProductName;
                result.product_id = pr.product_id;
                result.QTY = pr.QTY;
                result.retailprice = pr.retailprice;
                result.supplierprice = pr.supplierprice;
                result.supplier_id = pr.supplier_id;
                result.updatedBy = pr.updatedBy;
                result.Weight = pr.Weight;
                result.unitWeight = pr.unitWeight;
                ps.Add(result);
                //ps.AddRange(result);
            }
            return ps;
        }


        public List<product> Search(product _ref)
        {
            List<product> ps = new List<product>();
            List<ref_product_Search_Result1> x = pEntity.ref_product_Search(_ref.product_id, _ref.category_id, _ref.ProductCode, _ref.ProductName, _ref.ProductDescription,
                _ref.Barcode, _ref.measurement, _ref.supplierprice, _ref.retailprice, _ref.QTY, _ref.criticalQTY, _ref.Expirydate, _ref.isDelete, _ref.isActive, _ref.supplier_id, _ref.dateCreated,
                _ref.updatedBy, _ref.dateUpdated).ToList();

            foreach (ref_product_Search_Result1 pr in x)
            {
                product result = new product();
                result.Barcode = pr.Barcode;
                result.category_id = pr.category_id;
                result.criticalQTY = pr.criticalQTY;
                result.Expirydate = pr.Expirydate;
                result.measurement = pr.measurement;
                result.dateCreated = pr.dateCreated;
                result.dateUpdated = pr.dateUpdated;
                result.isActive = pr.isActive;
                result.isDelete = pr.isDelete;
                result.ProductCode = pr.ProductCode;
                result.ProductDescription = pr.ProductDescription;
                result.ProductName = pr.ProductName;
                result.product_id = pr.product_id;
                result.QTY = pr.QTY;
                result.retailprice = pr.retailprice;
                result.supplierprice = pr.supplierprice;
                result.supplier_id = pr.supplier_id;
                result.updatedBy = pr.updatedBy;
                result.Weight = pr.Weight;
                result.unitWeight = pr.unitWeight;
                ps.Add(result);
                //ps.AddRange(result);
            }
            return ps;

        }
        public ProductResult SelectById(int id)
        {
            ref_product_SelectById_Result pr = pEntity.ref_product_SelectById(id).FirstOrDefault();
            ProductResult result = new ProductResult();
            result.Barcode = pr.Barcode;
            result.category_id = pr.category_id;
            result.criticalQTY = pr.criticalQTY;
            result.Expirydate = pr.Expirydate;
            result.measurement = pr.measurement;
            result.dateCreated = pr.dateCreated;
            result.dateUpdated = pr.dateUpdated;
            result.isActive = pr.isActive;
            result.isDelete = pr.isDelete;
            result.ProductCode = pr.ProductCode;
            result.ProductDescription = pr.ProductDescription;
            result.ProductName = pr.ProductName;
            result.product_id = pr.product_id;
            result.QTY = pr.QTY;
            result.retailprice = pr.retailprice;
            result.supplierprice = pr.supplierprice;
            result.supplier_id = pr.supplier_id;
            result.updatedBy = pr.updatedBy;
            result.Weight = pr.Weight;
            result.unitWeight = pr.unitWeight;
            return result;
        }

        public bool UpdateQTY(int productID, int quantity, int processedby)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_product_Update_QTY(productID,quantity,processedby);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Product CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }

    }
}
