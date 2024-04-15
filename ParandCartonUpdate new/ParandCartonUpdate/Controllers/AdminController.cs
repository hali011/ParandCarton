using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI.Fluent;
using Microsoft.Ajax.Utilities;
using ParandCartonUpdate.ClassHelper;
using ParandCartonUpdate.Models;

namespace ParandCartonUpdate.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpPost]
        public JsonResult Login(string pass , decimal nc)
        {
            Session.Timeout = 120;
            pass = hashpass(pass);
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                UserInfo user = db.UserInfoes.Where(w=>w.NationalCode==nc).SingleOrDefault();
                if (user == null)
                {
                    return Json(new {error = 1});
                }
                if (decode(pass , user.Password))
                {
                    Session["UserInfo"] = user;
                    return Json(new { error = 0 });
                }
                else
                {
                    return Json(new {error = 2});
                }
            }
        }
        private string hashpass(string pass)
        {
            ProcessPass PP = new ProcessPass();
            string HashData = PP.SHA1(PP.MD5(PP.SHA1(PP.SHA1(PP.MD5(PP.MD5(PP.SHA1(pass)))))));
            return HashData;
        }
        private bool decode(string enterpass, string userpass)
        {
            if (userpass == enterpass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void sesionact(int x , Var data)
        {
            switch (x)
            {
                case 0:
                    Session["UserInfo"] = data;
                    break;
                case 1:
                    Session.Remove("UserInfo");
                break;
            }
        }
    }
}