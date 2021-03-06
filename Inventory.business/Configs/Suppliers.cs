﻿using System;
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
    public class Suppliers : DBRepositories
    {
        public string _err = string.Empty;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public bool Create(supplier _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_supplier_Insert(_ref.Supplier_name,_ref.Supplier_address,_ref.Supplier_contact,_ref.isDelete,_ref.isActive);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Suppliers CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }

        public bool Update(supplier _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_supplier_Update(_ref.supplier_id,_ref.Supplier_name, _ref.Supplier_address, _ref.Supplier_contact, _ref.isDelete, _ref.isActive);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Suppliers CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }

        public bool Delete(int id)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_supplier_Delete(id);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                a.logModule = "Suppliers CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }
        public List<supplier> SelectAll()
        {
            var car = pEntity.ref_supplier_SelectAll();
            List<supplier> ls = new List<supplier>();
            foreach (ref_supplier_SelectAll_Result c in car)
            {
                supplier result = new supplier();
                result.supplier_id = c.supplier_id;
                result.Supplier_name = c.Supplier_name;
                result.Supplier_address = c.Supplier_address;
                result.Supplier_contact = c.Supplier_contact;
                ls.Add(result);
            }
            return ls;
        }

        public supplier SelectById(int id)
        {
            ref_supplier_bydId_Result c = pEntity.ref_supplier_bydId(id).FirstOrDefault();
            supplier result = new supplier();
            result.supplier_id = c.supplier_id;
            result.Supplier_name = c.Supplier_name;
            result.Supplier_address = c.Supplier_address;
            result.Supplier_contact = c.Supplier_contact;
            return result;
        }
    }
}
