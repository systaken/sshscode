using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.business.Model;
using Inventory.business.Transaction;
using Inventory.business.Configs;
using DataLibrary;

namespace Inventory.business.Transaction
{
    public class ReportClass : DBRepositories
    {
        public List<CustomerPurchase> CustomerPurchaseLists(DateTime datefrom , DateTime dateto)
        {
            var x = pEntity.customer_sales_date(datefrom, dateto);
            List<CustomerPurchase> cus = new List<CustomerPurchase>();
            foreach (customer_sales_date_Result a in x)
            {
                CustomerPurchase cp = new CustomerPurchase();

                cp.Firstname = a.Firstname;
                cp.Lastname = a.Lastname;
                cp.productcode = a.productcode;
                cp.ProductDescription = a.ProductDescription;
                cp.ProductName = a.ProductName;
                cp.QTY = a.QTY;
                cp.RetailPrice = a.RetailPrice;
                cp.sales_id = a.sales_id;
                cp.TotalAmount = a.TotalAmount;
                cp.unitWeight = a.unitWeight;
                cp.Weight = a.Weight;
                cp.measurement = a.measurement;
                cp.referenceNo = a.referenceNo;
               
                cus.Add(cp);    
              }
            return cus;
        }


        public List<DeliveryReceipt> CustomerReceipt(int salesid)
        {
            var x = pEntity.customer_sales_receipt(salesid);
            List<DeliveryReceipt> cus = new List<DeliveryReceipt>();
            foreach (customer_sales_receipt_Result a in x)
            {
                DeliveryReceipt cp = new DeliveryReceipt();
                cp.Firstname = a.Firstname;
                cp.Lastname = a.Lastname;
                cp.productcode = a.productcode;
                cp.ProductDescription = a.ProductDescription;
                cp.ProductName = a.ProductName;
                cp.QTY = a.QTY;
                cp.RetailPrice = a.RetailPrice;
                cp.sales_id = a.sales_id;
                cp.TotalAmount = a.TotalAmount;
                cp.unitWeight = a.unitWeight;
                cp.Weight = a.Weight;
                cp.measurement = a.measurement;
                cp.referenceNo = a.referenceNo;
                cp.Address = a.Address + " " + a.City;
                cp.ContactNo = a.cpno;
                cp.Date =  a.DateCreated.Value.ToShortDateString();
                cp.Discounted = a.Discounted;
                cp.GrandTotal = a.GrandTotal;
                cus.Add(cp);
            }
            return cus;
        }



    }
}
