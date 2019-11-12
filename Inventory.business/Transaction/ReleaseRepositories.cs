using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.business.Model;
using Inventory.business.Transaction;
using Inventory.business.Configs;
using DataLibrary;
using System.Data;
using System.Data.Objects;
namespace Inventory.business.Transaction
{
    public class ReleaseRepositories : DBRepositories
    {
        public string _err = string.Empty;
        private Products _pr = new Products();
        public ProductReleases ProductReleaseFind(int salesid, string barcode)
        {
            trn_transactionsales_product_details_Result trx = pEntity.trn_transactionsales_product_details(salesid, barcode).FirstOrDefault();
            ProductReleases result = new ProductReleases();
            if (trx != null)
            {
                result.Barcode = trx.Barcode;
                result.productcode = trx.productcode;
                result.ProductName = trx.ProductName;
                result.product_id = trx.product_id;
                result.QTY = trx.QTY;
                result.TotalAmount = trx.TotalAmount;
                result.sales_detail_id = trx.sales_detail_id;
                result.sales_id = trx.sales_id;
            }
            else
            {
                result = null;               
            }
            return result;
        }
        public bool ProductRelease(int sales_detail_id, int productid, int qty, bool ischeckout)
        {
            bool result = false;
            try
            {
                pEntity.trn_transactionsales_detail_releasing_update(sales_detail_id, productid, qty, ischeckout);
                pEntity.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = false;
            }
            return result;
        }
        public bool ReleaseItemInsert(int sales_detail_id,int salesid, int qty)
        {
            bool result = false;
            try
            {
                pEntity.trn_product_release_Insert(sales_detail_id, salesid, qty);
                pEntity.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = false;
            }
            return result;
        }
        public List<Releases> ItemList(int salesid)
        {
            List<Releases> tr = new List<Releases>();
            List<trn_product_release_SelectAll_Result> trxall = new List<trn_product_release_SelectAll_Result>();
            trxall = pEntity.trn_product_release_SelectAll(salesid).ToList();
            foreach (trn_product_release_SelectAll_Result trx in trxall)
            {
                Releases trn = new Releases();
                trn.sales_detail_id = trx.sales_detail_id;
                trn.productcode = trx.productcode;
                trn.ProductName = trx.ProductName;
                trn.releaseQTY = trx.releaseQTY;
                tr.Add(trn);
            }
            return tr;
        }
        public bool removedItem(int salesdetailid)
        {
            bool result = false;
            try
            {
                pEntity.trn_transactionsales_detail_remove_update(salesdetailid, false);
                pEntity.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = false; 
            }
            return result;
        }
        public bool ReleaseRemoved(int salesdetailid)
        {
            bool result = false;
            try
            {
                pEntity.trn_product_release_removed(salesdetailid);
                pEntity.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = false;
            }
            return result;
        }
        public bool isItemExists(int salesid, int salesdetailid)
        {
            bool result = false;
            try
            {
                trn_product_release_exists_Result isExists = pEntity.trn_product_release_exists(salesid, salesdetailid).FirstOrDefault();
                if (isExists == null)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = false;
            }
            return result;
        }
        public bool isAllRelease(int salesid, bool isCheckedout)
        {
            bool result = false;
            try
            {
                trn_transactionsales_detail_isallrelease_Result isReleased = pEntity.trn_transactionsales_detail_isallrelease(salesid, isCheckedout).FirstOrDefault();
                if (isReleased == null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = true;
            }
            return result;
        }

        public bool CompleteRelease(int salesid, int processedby)
        {
            bool result = false;
            try
            {
                var rl = pEntity.trn_transactionsales_detail_isallrelease(salesid, true);
                int TotalQTY = 0;
                foreach (trn_transactionsales_detail_isallrelease_Result x in rl)
                {
                    ref_product_SelectById_Result pr = pEntity.ref_product_SelectById(x.product_id).FirstOrDefault();
                    TotalQTY = Convert.ToInt16(pr.QTY) - Convert.ToInt16(x.QTY);
                    _pr.UpdateQTY(pr.product_id, TotalQTY, processedby);
                }
                result = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                result = false;
            }
            return result;
        }


        public List<ProductReleases> ProductReleaseSelect(int salesid)
        {
            var trxn = pEntity.trn_transactionsales_product_details_select(salesid);
            ProductReleases result = new ProductReleases();
            List<ProductReleases> result2 = new List<ProductReleases>();
            foreach (trn_transactionsales_product_details_select_Result trx in trxn)
            { 
                result.Barcode = trx.Barcode;
                result.productcode = trx.productcode;
                result.ProductName = trx.ProductName;
                result.product_id = trx.product_id;
                result.QTY = trx.QTY;
                result.RetailPrice = trx.RetailPrice;
                result.TotalAmount = trx.TotalAmount;
                result.isCheckedout = trx.isCheckedout;
                result.sales_detail_id = trx.sales_detail_id;
                result.sales_id = trx.sales_id;
                result2.Add(result);
            }
            return result2;
        }
        public List<ProductReleasesReport> ProductReleaseSelectbydate(DateTime datefrm, DateTime datto)
        {
            var trxn = pEntity.trn_transactionsales_product_details_select_bydate(datefrm,datto);
            ProductReleasesReport result = new ProductReleasesReport();
            List<ProductReleasesReport> result2 = new List<ProductReleasesReport>();
            foreach (trn_transactionsales_product_details_select_bydate_Result trx in trxn)
            {
                result.Barcode = trx.Barcode;
                result.productcode = trx.productcode;
                result.ProductName = trx.ProductName;
                result.QTY = trx.QTY;
                result.RetailPrice = trx.retailprice;
                result.TotalAmount = trx.TotalAmount;
                result.isCheckedout = trx.isCheckedout;
                result.dateParameters = Convert.ToString(datefrm.ToShortDateString() + " to " + datto.ToShortDateString());
                result2.Add(result);
            }
            return result2;
        }
        

    }
}
