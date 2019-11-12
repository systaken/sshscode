using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using System.Data;
using System.Data.Objects;
using Inventory.business.Model;
namespace Inventory.business.Configs
{
    public class Categorys : DBRepositories
    {
        public string _err = string.Empty;
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
                rtval = false;
            }
            return rtval;
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
                rtval = false;
            }
            return rtval;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public ObjectResult SelectAll()
        {
            return pEntity.ref_category_SelectAll();
        }
    } 
}
