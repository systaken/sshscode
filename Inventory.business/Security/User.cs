using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
using Inventory.business.Model;
using Inventory.business.Logs;
namespace Inventory.business.Security
{
    public class User : DBRepositories
    {
        public string _err;
        public string _userId;
        public string _gId;
        public string _position;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public bool IsAuthenticated(string username, string password)
        {
            bool result = false;
            try
            {
                var a = pEntity.ref_user_Login(username, password).FirstOrDefault();
                if (a.userid > 0)
                {
                   
                    _userId = a.userid.ToString();
                    _position = a.position;
                    result = true;
                }
                else
                {
                    _err = "Username or passwod is incorrect.";
                    result = false; 
                }

            }
            catch (Exception e)
            {
                _err = e.ToString();
                a.logModule = "User CS";
                a.logError = e.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                result = false;
            }
            return result;
        }

        public bool addUser(UsersRole usr)
        {
            bool rtval = false;
            try
            {
                pEntity.ref_user_Insert(usr.userid, usr.username, usr.password, usr.isActive, usr.Fullname, usr.position);
                pEntity.SaveChanges();
                rtval = true;
            }
            catch (Exception ex)
            {

                _err = ex.ToString();
                a.logModule = "User CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                rtval = false;
            }
            return rtval;
        }


        public List<UsersRole> LoadUsers()
        {
            List<UsersRole> us = new List<UsersRole>();
            List<ref_user_SelectAll_Result> sr = new List<ref_user_SelectAll_Result>();
            sr = pEntity.ref_user_SelectAll().ToList();
            foreach (ref_user_SelectAll_Result p in sr)
            {
                UsersRole usr = new UsersRole();
                usr.userid = p.userid;
                usr.Fullname = p.Fullname;
                usr.username = p.username;
                usr.password = p.password;
                usr.isActive = p.isActive;
                usr.position = p.position;
                us.Add(usr);
            }
            return us;
        }

        public bool Delete(int id)
        {
            bool result = false;    
            try
            {
                pEntity.ref_user_Delete(id);
                result = true;
                   
            }
            catch (Exception ex) {
                _err = ex.ToString();
                a.logModule = "User CS";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                result = false;
            }
            return result;
        }
    }
}
