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
    public class Trucking : DBRepositories
    {
        public string _err = string.Empty;
        public bool Create(Truckers _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_trucking_Insert(_ref.trucking_id,_ref.trucking_name,_ref.platenos);
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

        public bool Update(Truckers _ref)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_trucking_Update(_ref.trucking_id,_ref.trucking_name,_ref.platenos);
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

        public List<Truckers> SelectAll()
        {
            List<Truckers> cs = new List<Truckers>();
            List<ref_trucking_SelectAll_Result> rs = pEntity.ref_trucking_SelectAll().ToList();

            foreach (ref_trucking_SelectAll_Result cr in rs)
            {
                Truckers info = new Truckers();
                info.trucking_id = cr.trucking_id;
                info.trucking_name = cr.trucking_name;
                info.platenos = cr.platenos;
                cs.Add(info);
            }
            return cs;
        }

    }
}
