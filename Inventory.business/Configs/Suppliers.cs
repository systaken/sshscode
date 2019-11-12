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
    public class Suppliers : DBRepositories
    {
        public string _err = string.Empty;
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
            return pEntity.ref_supplier_SelectAll();
        }
    }
}
