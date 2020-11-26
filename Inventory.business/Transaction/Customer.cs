using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data;
using System.Data.Objects;
using Inventory.business.Model;
using Inventory.business.Logs;
namespace Inventory.business.Transaction
{
    public class Customer : DBRepositories
    {
        public string _err = string.Empty;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public int Create(CustomerInfo _ref)
        {
            idResult rtval = new idResult();
            try
            {
                rtval.ID = pEntity.trn_customer_Insert(_ref.Firstname,_ref.Lastname,_ref.Middle,_ref.Gender,_ref.bBdate,_ref.Address,_ref.City,_ref.Country,_ref.TelNos,_ref.cpno,_ref.emailaddress,DateTime.Now,_ref.AgentName,_ref.Terms,_ref.Discount,_ref.BusinessName,_ref.truck_id,_ref.isDelete).FirstOrDefault().ID;
                pEntity.SaveChanges();
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Customer CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = null;
            }
            return Convert.ToInt32(rtval.ID);
        }

        public bool Update(CustomerInfo _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.trn_customer_Update(_ref.customer_id, _ref.Firstname, _ref.Lastname, _ref.Middle, _ref.Gender, _ref.bBdate, _ref.Address, _ref.City, _ref.Country, _ref.TelNos, _ref.cpno, _ref.emailaddress, DateTime.Now, _ref.AgentName, _ref.Terms,_ref.Discount, _ref.BusinessName, _ref.truck_id);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Customer CS";
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

        public List<CustomerInfo> SelectAll()
        {

            List<CustomerInfo> cs = new List<CustomerInfo>();
            List<trn_customer_SelectAll_Result> rs = pEntity.trn_customer_SelectAll().ToList();

            foreach (trn_customer_SelectAll_Result cr in rs)
            {
                CustomerInfo info = new CustomerInfo();
                info.customer_id = cr.customer_id;
                info.Firstname = cr.Firstname;
                info.Lastname = cr.Lastname;
                info.Middle = cr.Middle;
                cs.Add(info);
            }
            return cs;
        }

        public List<CustomerInfo> Search(CustomerInfo _ref)
        {
            List<CustomerInfo> cs = new List<CustomerInfo>();
            List<trn_customer_Search_Result> rs = pEntity.trn_customer_Search(_ref.customer_id, _ref.Firstname, _ref.Lastname, _ref.Middle, _ref.Gender, _ref.bBdate, _ref.Address, _ref.City, _ref.Country, _ref.TelNos, _ref.cpno, _ref.emailaddress, _ref.datecreated).ToList();
            foreach (trn_customer_Search_Result cr in rs)
            {
                CustomerInfo info = new CustomerInfo();
                info.customer_id = cr.customer_id;
                info.Firstname = cr.Firstname;
                info.Lastname = cr.Lastname;
                info.Middle = cr.Middle;
                cs.Add(info);
            }
            return cs;
        }


        public CustomerInfo SelectById(int id)
        {
            trn_customer_SelectbyId_Result pr = pEntity.trn_customer_SelectbyId(id).FirstOrDefault();
            CustomerInfo result = new CustomerInfo();
            result.customer_id = pr.customer_id;
            result.Firstname = pr.Firstname;
            result.Middle = pr.Middle;
            result.Lastname = pr.Lastname;
            result.emailaddress = pr.emailaddress;
            result.Gender = pr.Gender;
            result.bBdate = pr.bBdate;
            result.Address = pr.Address;
            result.City = pr.City;
            result.Country = pr.Country;
            result.cpno = pr.cpno;
            result.TelNos = pr.TelNos;
            result.emailaddress = pr.emailaddress;
            result.AgentName = pr.AgentName;
            result.Terms = pr.Terms;
            result.Discount = pr.Discount;
            result.BusinessName = pr.BusinessName;
            result.truck_id = pr.truck_id;
           return result;
        }
    }
}
