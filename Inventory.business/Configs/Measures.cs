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
    public class Measures : DBRepositories
    {
        public string _err = string.Empty;
        public bool Create(measure _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_measurement_Insert(_ref.measure_id,_ref.measurement);
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
            return pEntity.ref_measurement_SelectAll();
        }
    }
}
