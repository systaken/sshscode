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
    public class Categorys : DBRepositories
    {
        public string _err = string.Empty;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public bool Create(Category _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_category_Insert(_ref.category_id, _ref.categoryname);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Category";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }


        public Category SelectById(int id)
        {
            ref_category_SelectbyId_Result c = pEntity.ref_category_SelectbyId(id).FirstOrDefault();
            Category result = new Category();
            result.category_id = c.category_id;
            result.categoryname = c.categoryname;
            return result;
        }
        public bool Update(Category _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_category_Update(_ref.category_id, _ref.categoryname);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Category";
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
                pEntity.ref_category_Delete(id);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "Category Delete";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }

        public List<Category> SelectAll()
        {
            var car = pEntity.ref_category_SelectAll();
           
            List<Category> ls = new List<Category>();
            foreach (ref_category_SelectAll_Result c in car)
            {
                Category result = new Category();
                result.categoryname = c.categoryname;
                result.category_id = c.category_id;
                ls.Add(result);
            }
            return ls ;
        }
    } 
}
