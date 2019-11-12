using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.business.Model;
using Inventory.business.Transaction;
using DataLibrary;
using System.Data;
using System.Data.Objects;

namespace Inventory.business.Transaction
{
    public class InventoryStocks : DBRepositories
    {
        private string _err = string.Empty;
        public bool DeductStocks(int productId, int QTY, int updatedby)
        {
            bool result = false;
            try
            {
                pEntity.trn_stock_qty_update(productId, QTY, updatedby, 2);
                pEntity.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                _err = e.ToString();
                result = false;
            }
            return result;
        }
        public bool AddStocks(int productId, int QTY, int updatedby)
        {
            bool result = false;
            try
            {
                pEntity.trn_stock_qty_update(productId, QTY, updatedby, 1);
                pEntity.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                _err = e.ToString();
                result = false;
            }
            return result;
        }
        public bool CheckCritical(int productId, int qty, string updatedby)
        {
            bool result = false;
            try
            {

                result = true;
            }
            catch (Exception e)
            {
                _err = e.ToString();
                result = false;
            }
            return result;
        }
    }
}
