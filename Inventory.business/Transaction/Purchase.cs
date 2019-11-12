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
    public class Purchase : DBRepositories
    {
        public string _err = string.Empty;
        private Products prod = new Products();
        public bool Create(PurchaseRequest _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_porequest_Insert(_ref.poRef, _ref.TotalAmount, _ref.DateCreated, _ref.Createdby, false, _ref.status);
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
        public int GetPOId(string refno)
        {
            int result = pEntity.trn_porequest_GetId(refno).FirstOrDefault().Value;
            return result;
        }
        public bool PurchaseAmountUpdate(int poid,double totalamount)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_porequest_Update_amount(poid, totalamount);
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
        public bool PurchaseRequest_Update_status(int poid, bool iscompleted,string status)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_porequest_Update_status(poid, iscompleted,status);
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
        public bool CreateItem(PurchaseItem _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_po_item_Insert(_ref.po_id, _ref.product_id, _ref.QTY, _ref.Measurement, _ref.Purchaseprice, false,_ref.DateUpdate,_ref.ReleasedBy);
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
        public bool UpdateItem(PurchaseItem _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_po_item_Update(_ref.po_detail_id, _ref.product_id, _ref.QTY, _ref.Measurement, _ref.Purchaseprice, false, _ref.DateUpdate, _ref.ReleasedBy);
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
        public bool UpdateItemStatus(PurchaseItem _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_po_item_Update_status(_ref.po_detail_id, _ref.QTY, _ref.isCheckedIn, _ref.DateUpdate, _ref.ReleasedBy);
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
        public List<PurchaseRequest> SelectAll_PO()
        {
            List<PurchaseRequest> tr = new List<PurchaseRequest>();
            List <trn_porequest_SelectAll_Result> trxall = new List<trn_porequest_SelectAll_Result>();
            trxall = pEntity.trn_porequest_SelectAll().ToList();
            foreach (trn_porequest_SelectAll_Result trx in trxall)
            {
                PurchaseRequest trn = new PurchaseRequest();
                trn.po_id = trx.po_id;
                trn.poRef = trx.poRef;
                trn.status = trx.status;
                trn.Createdby = trx.Createdby;
                trn.DateCreated = trx.DateCreated;
                trn.isCompleted = trx.isCompleted;
                trn.TotalAmount = trx.TotalAmount;
                tr.Add(trn);
            }
            return tr;
        }
        public List<PurchaseItem> SelectItemLists(int poId)
        {
            List<PurchaseItem> tr = new List<PurchaseItem>();
            List<trn_po_item_List_Result> trxall = new List<trn_po_item_List_Result>();
            trxall = pEntity.trn_po_item_List(poId).ToList();
            foreach (trn_po_item_List_Result trx in trxall)
            {
                PurchaseItem trn = new PurchaseItem();
                trn.po_id = trx.po_id;
               
                trn.product_id = trx.product_id;
                trn.po_detail_id = trx.po_detail_id;
                trn.DateUpdate = trx.DateUpdate;
                trn.isCheckedIn = trx.isCheckedIn;
                trn.Measurement = trx.Measurement;
                trn.Purchaseprice = trx.Purchaseprice;
                trn.QTY = trx.QTY;
                trn.ReleasedBy = trx.ReleasedBy;
                tr.Add(trn);
            }
            return tr;
        }
        public bool RemovedItem(int poDetailId)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_po_item_Remove(poDetailId);
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
        public List<PurchaseItem> CheckedInItem_list(int poId, bool ischeckedin)
        {
            List<PurchaseItem> tr = new List<PurchaseItem>();
            List<trn_po_item_Checkedin_List_Result> trxall = new List<trn_po_item_Checkedin_List_Result>();
            trxall = pEntity.trn_po_item_Checkedin_List(poId, ischeckedin).ToList();
            foreach (trn_po_item_Checkedin_List_Result trx in trxall)
            {
                PurchaseItem trn = new PurchaseItem();
                trn.po_id = trx.po_id;
                trn.product_id = trx.product_id;
                trn.po_detail_id = trx.po_detail_id;
                trn.DateUpdate = trx.DateUpdate;
                trn.isCheckedIn = trx.isCheckedIn;
                trn.Measurement = trx.Measurement;
                trn.Purchaseprice = trx.Purchaseprice;
                trn.ProductCode = trx.ProductCode;
                trn.ProductName = trx.ProductName;
                trn.QTY = trx.QTY;
                trn.ReleasedBy = trx.ReleasedBy;
                tr.Add(trn);
            }
            return tr;
        }
        public PurchaseItem Purchase_Item_lis_find(int poId,string barcode, bool ischeckedin)
        {
            PurchaseItem trn = new PurchaseItem();
            trn_po_item_Checkedin_List_byBarcode_Result trxall = new trn_po_item_Checkedin_List_byBarcode_Result();

            trxall = pEntity.trn_po_item_Checkedin_List_byBarcode(barcode,ischeckedin, poId).FirstOrDefault();
            trn.po_id = trxall.po_id;
            trn.product_id = trxall.product_id;
            trn.po_detail_id = trxall.po_detail_id;
            trn.ProductCode = trxall.ProductCode;
            trn.ProductName = trxall.ProductName;
            trn.DateUpdate = trxall.DateUpdate;
            trn.isCheckedIn = trxall.isCheckedIn;
            trn.Measurement = trxall.Measurement;
            trn.Purchaseprice = trxall.Purchaseprice;
            trn.QTY = trxall.QTY;
            trn.ReleasedBy = trxall.ReleasedBy;
            return trn;
        }
        public bool isAllCheckedin(int Poid, bool isCheckedout)
        {
            bool result = false;
            try
            {
                trn_po_item_Checkedin_List_Result isallCheckedin = pEntity.trn_po_item_Checkedin_List(Poid, isCheckedout).FirstOrDefault();
                if (isallCheckedin == null)
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
        public bool isItemExists(int POid, int productid, bool status)
        {
            bool result = false;
            try
            {
                trn_po_item_List_exists_Result isExists = pEntity.trn_po_item_List_exists(POid, productid, status).FirstOrDefault();
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
        public List<PurchaseRequest> Search(PurchaseRequest _ref, DateTime datefrom , DateTime dateto)
        {
            List<PurchaseRequest> tr = new List<PurchaseRequest>();
            List<trn_PORequest_Search_Result> trxall = new List<trn_PORequest_Search_Result>();
            trxall = pEntity.trn_PORequest_Search(_ref.po_id,
                _ref.poRef,
                _ref.TotalAmount,
                _ref.DateCreated,
                _ref.Createdby,
                _ref.isCompleted,
                _ref.status,
                datefrom,
                dateto).ToList();
            foreach (trn_PORequest_Search_Result trx in trxall)
            {
                PurchaseRequest trn = new PurchaseRequest();
                trn.po_id = trx.po_id;
                trn.DateCreated = trx.DateCreated;
                trn.status = trx.status;
                trn.TotalAmount = trx.TotalAmount;
                tr.Add(trn);
            }
            return tr;
        }

        public bool CompletePO(int POid, int processedby)
        {
            bool result = false;
            try
            {
                var rl = pEntity.trn_po_item_List_bystatus(POid, true);
                int TotalQTY = 0;
                foreach (trn_po_item_List_bystatus_Result x in rl)
                {
                    ref_product_SelectById_Result pr = pEntity.ref_product_SelectById(x.product_id).FirstOrDefault();
                    TotalQTY = Convert.ToInt16(pr.QTY) + Convert.ToInt16(x.QTY);
                    prod.UpdateQTY(pr.product_id, TotalQTY, processedby);
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

        public List<PurchaseItem> SelectItemListsAll(int poId)
        {
            List<PurchaseItem> tr = new List<PurchaseItem>();
            List<trn_po_item_List_select_Result> trxall = new List<trn_po_item_List_select_Result>();
            trxall = pEntity.trn_po_item_List_select(poId).ToList();
            foreach (trn_po_item_List_select_Result trx in trxall)
            {
                PurchaseItem trn = new PurchaseItem();
                trn.po_id = trx.po_id;
                trn.ProductCode = trx.ProductCode;
                trn.ProductName = trx.ProductName;
                trn.product_id = trx.product_id;
                trn.po_detail_id = trx.po_detail_id;
                trn.DateUpdate = trx.DateUpdate;
                trn.isCheckedIn = trx.isCheckedIn;
                trn.Measurement = trx.Measurement;
                trn.Purchaseprice = trx.Purchaseprice;
                trn.QTY = trx.QTY;
                trn.ReleasedBy = trx.ReleasedBy;
                tr.Add(trn);
            }
            return tr;
        }

        public List<PurchaseItem> SelectItemListsBydate(bool ischeckedin,DateTime datefrom, DateTime dateto)
        {

            List<PurchaseItem> tr = new List<PurchaseItem>();
            List<trn_po_item_Checkedin_List_by_date_Result> trxall = new List<trn_po_item_Checkedin_List_by_date_Result>();
            trxall = pEntity.trn_po_item_Checkedin_List_by_date(ischeckedin,datefrom,dateto).ToList();
            foreach (trn_po_item_Checkedin_List_by_date_Result trx in trxall)
            {
                PurchaseItem trn = new PurchaseItem();
                trn.ProductCode = trx.ProductCode;
                trn.ProductName = trx.ProductName;
                trn.isCheckedIn = trx.isCheckedIn;
                trn.Measurement = trx.Measurement;
                trn.Purchaseprice = trx.Purchaseprice;
                trn.QTY = trx.QTY;
                tr.Add(trn);
            }
            return tr;
        }

        public List<PurchaseItemReport> SelectItemListsBydateReport(bool ischeckedin, DateTime datefrom, DateTime dateto)
        {

            List<PurchaseItemReport> tr = new List<PurchaseItemReport>();
            List<trn_po_item_Checkedin_List_by_date_Result> trxall = new List<trn_po_item_Checkedin_List_by_date_Result>();
            trxall = pEntity.trn_po_item_Checkedin_List_by_date(ischeckedin, datefrom, dateto).ToList();
            foreach (trn_po_item_Checkedin_List_by_date_Result trx in trxall)
            {
                PurchaseItemReport trn = new PurchaseItemReport();
                trn.ProductCode = trx.ProductCode;
                trn.ProductName = trx.ProductName;
                trn.isCheckedIn = trx.isCheckedIn;
                trn.Measurement = trx.Measurement;
                trn.Purchaseprice = trx.Purchaseprice;
                trn.DateParameters = Convert.ToString(datefrom.ToShortDateString() + " to " + dateto.ToShortDateString());
                trn.QTY = trx.QTY;
                tr.Add(trn);
            }
            return tr;
        }


    }
}
