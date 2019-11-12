using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data;
using System.Data.Objects;
using Inventory.business.Model;
namespace Inventory.business.Transaction
{
    public class Sales : DBRepositories
    {
        public string _err = string.Empty;
        public bool Create(Transactions trx)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_transactionsales_Insert(trx.referenceNo,
                    trx.TotalAmount,
                    trx.Discounted,
                    trx.GrandTotal,
                    trx.AmountPaid,
                    trx.PayBalance,
                    trx.status,
                    trx.isPaid,
                    trx.isVoided,
                    trx.TransactionType,
                    trx.CustomerId,
                    trx.DateCreated,
                    trx.dateUpdated,
                    trx.processed_by
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
        public bool Update(Transactions _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_transactionsales_Update(
                    _ref.sales_id,
                    _ref.referenceNo,
                    _ref.TotalAmount,
                    _ref.Discounted,
                    _ref.GrandTotal,
                    _ref.AmountPaid,
                    _ref.PayBalance,
                    _ref.status,
                    _ref.isPaid,
                    _ref.isVoided,
                    _ref.TransactionType, 
                    _ref.CustomerId,
                    _ref.payterms,
                    _ref.nosofdays,
                    _ref.dateUpdated,
                    _ref.processed_by
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
        public bool Delete()
        {
            throw new NotImplementedException();
        }
        public List<Transactions> SelectAll()
        {
            List<Transactions> tr = new List<Transactions>();
            List<trn_transactionsales_SelectAll_Result> trxall = new List<trn_transactionsales_SelectAll_Result>();
            trxall = pEntity.trn_transactionsales_SelectAll().ToList();
            foreach (trn_transactionsales_SelectAll_Result trx in trxall)
            {
                Transactions trn = new Transactions();
                trn.AmountPaid = trx.AmountPaid;
                trn.CustomerId = trx.CustomerId;
                trn.DateCreated = trx.DateCreated;
                trn.dateUpdated = trx.dateUpdated;
                trn.Discounted = trx.Discounted;
                trn.GrandTotal = trx.GrandTotal;
                trn.isPaid = trx.isPaid;
                trn.isVoided = trx.isVoided;
                trn.PayBalance = trx.PayBalance;
                trn.processed_by = trx.processed_by;
                trn.referenceNo = trx.referenceNo;
                trn.sales_id = trx.sales_id;
                trn.status = trx.status;
                trn.TotalAmount = trx.TotalAmount;
                trn.TransactionType = trx.TransactionType;
                tr.Add(trn);
            }
            return tr;
        }
        public Transactions SelectById(int id)
        {
            trn_transactionsales_SelectbyId_Result pr = pEntity.trn_transactionsales_SelectbyId(id.ToString()).FirstOrDefault();
            Transactions result = new Transactions();
            result.CustomerId = pr.CustomerId;
            result.DateCreated = pr.dateUpdated;
            result.dateUpdated = pr.dateUpdated;
            result.Discounted = pr.Discounted;
            result.GrandTotal = pr.GrandTotal;
            result.AmountPaid = pr.AmountPaid;
            result.isPaid = pr.isPaid;
            result.isVoided = pr.isVoided;
            result.TransactionType = pr.TransactionType;
            result.PayBalance = pr.PayBalance;
            result.processed_by = pr.processed_by;
            result.referenceNo = pr.referenceNo;
            result.sales_id = pr.sales_id;
            result.status = pr.status;
            result.TotalAmount = pr.TotalAmount;
            return result;
        }
        public Transactions SelectByRef(string refid)
        {
            trn_transactionsales_Selectrefno_Result pr = pEntity.trn_transactionsales_Selectrefno(refid).FirstOrDefault();
            Transactions result = new Transactions();
            result.CustomerId = pr.CustomerId;
            result.DateCreated = pr.dateUpdated;
            result.dateUpdated = pr.dateUpdated;
            result.Discounted = pr.Discounted;
            result.GrandTotal = pr.GrandTotal;
            result.isPaid = pr.isPaid;
            result.isVoided = pr.isVoided;
            result.PayBalance = pr.PayBalance;
            result.processed_by = pr.processed_by;
            result.referenceNo = pr.referenceNo;
            result.sales_id = pr.sales_id;
            result.status = pr.status;
            result.TotalAmount = pr.TotalAmount;
            result.AmountPaid = pr.AmountPaid;
            result.TransactionType = pr.TransactionType;
            return result;
        }
        public List<Transactions> Search(Transactions _ref)
        {
            List<Transactions> tr = new List<Transactions>();
            List<trn_transactionSales_Search_Result> trxall = new List<trn_transactionSales_Search_Result>();
            trxall = pEntity.trn_transactionSales_Search(
                    _ref.sales_id,
                    _ref.referenceNo,
                    _ref.TotalAmount,
                    _ref.Discounted,
                    _ref.GrandTotal,
                    _ref.PayBalance,
                    _ref.status,
                    _ref.isPaid,
                    _ref.isVoided,
                    _ref.CustomerId,
                    _ref.DateCreated,
                    _ref.dateUpdated,
                    _ref.processed_by,
                    _ref.DateCreated,
                    _ref.dateUpdated
                ).ToList();

            foreach (trn_transactionSales_Search_Result trx in trxall)
            {
                Transactions trn = new Transactions();
                trn.AmountPaid = trx.AmountPaid;
                trn.CustomerId = trx.CustomerId;
                trn.DateCreated = trx.DateCreated;
                trn.dateUpdated = trx.dateUpdated;
                trn.Discounted = trx.Discounted;
                trn.GrandTotal = trx.GrandTotal;
                trn.isPaid = trx.isPaid;
                trn.isVoided = trx.isVoided;
                trn.PayBalance = trx.PayBalance;
                trn.processed_by = trx.processed_by;
                trn.referenceNo = trx.referenceNo;
                trn.sales_id = trx.sales_id;
                trn.status = trx.status;
                trn.TotalAmount = trx.TotalAmount;
                trn.TransactionType = trx.TransactionType;
                tr.Add(trn);
            }
            return tr;
        }
        public bool CancelOrder(Transactions tx)
        {
            bool result = false;
            try
            {
                pEntity.trn_transactionsales_void_update(tx.sales_id, tx.status, false, false, tx.processed_by);
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

        public bool CompleteSales(int salesid, string status, string processedby)
        {
            bool result = false;
            try
            {
                pEntity.trn_transactionsales_Update_status(salesid,status,processedby);
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

        
    }
}
