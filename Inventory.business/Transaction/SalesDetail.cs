using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data.Objects;
using Inventory.business.Model;
namespace Inventory.business.Transaction
{
    public class SalesDetail : DBRepositories
    {
        public string _err = string.Empty;
        public bool Create(TransactionDetails trx)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_transactionsales_detail_Insert(trx.productcode,trx.sales_id,
                    trx.product_id,
                    trx.RetailPrice,
                    trx.QTY,
                    trx.TotalAmount,
                    trx.isCheckedout
                    );
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
        public bool Update(TransactionDetails _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_transactionsales_detail_Update(
                    _ref.sales_detail_id,
                    _ref.productcode,
                    _ref.product_id,
                    _ref.RetailPrice,
                    _ref.QTY,
                    _ref.TotalAmount,
                    _ref.isCheckedout
                    );
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
        public bool Delete(int id)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_transactionsales_detail_Delete(id,null);
                    
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
        public List<TransactionDetails> SelectbySalesId(int salesid)
        {
            List<TransactionDetails> t = new List<TransactionDetails>();
            List<trn_transactionsales_detail_Selectbysales_id_Result> tr = new List<trn_transactionsales_detail_Selectbysales_id_Result>();
            tr = pEntity.trn_transactionsales_detail_Selectbysales_id(salesid).ToList();
            foreach (trn_transactionsales_detail_Selectbysales_id_Result a in tr)
            {
                TransactionDetails td = new TransactionDetails();
                td.sales_detail_id = a.sales_detail_id;
                td.TotalAmount = a.TotalAmount;
                td.RetailPrice = a.RetailPrice;
                td.QTY = a.QTY;
                td.productcode = a.productcode;
                td.product_id = a.product_id;
                td.isCheckedout = a.isCheckedout;
                t.Add(td);
            }
            return t;
        }
        public ObjectResult SelectAll()
        {
            return pEntity.trn_transactionsales_detail_SelectAll();
        }
        public ObjectResult Search(trn_transactionSales_detail _ref)
        {
            return pEntity.trn_transactionSales_detail_Search(
                     _ref.sales_detail_id,
                    _ref.productcode,
                    _ref.product_id,
                    _ref.RetailPrice,
                    _ref.QTY,
                    _ref.TotalAmount,
                    _ref.isCheckedout
                );
        }
    }
}
