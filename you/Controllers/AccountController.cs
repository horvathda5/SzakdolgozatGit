using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using you.Models;

namespace you.Controllers
{
    public class AccountController : Controller
    {
        MVCDemoEntities3 db = new MVCDemoEntities3();

        public ActionResult Login()
        {
            return View();
            ViewBag.Message = "";
        }
        [HttpPost]
        public ActionResult Login(Login log)
        {
            var result = db.Login.Where(a=>a.Username==log.Username && a.Password==log.Password).ToList();
            if(result.Count()>0)
            {
                Session["LoginID"] = result[0].LoginID;
                FormsAuthentication.SetAuthCookie(result[0].Username, false);
                //Ha admin
                if(result[0].RoleID==1)
                {
                    return RedirectToAction("../Admin/Index");
                }
                //ha beszerzo
                else if (result[0].RoleID == 2)
                {
                    return RedirectToAction("../User/Index");
                }
                //ha beszallito
                else if (result[0].RoleID == 3)
                {
                    return RedirectToAction("../Supplier/Index");
                }
                //ha raktáros
                else if (result[0].RoleID == 4)
                {
                    return RedirectToAction("../Stocker/Index");
                }
            }
            else
            {
                ViewBag.Message = "Incorrect username or password";
                
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["LoginID"] = 0;
            FormsAuthentication.SignOut();
            return RedirectToAction("../Home/Index");
        }
    }
}