using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using you.Models;
using System.ComponentModel.DataAnnotations;

namespace you.Controllers
{
    public class ManageController : Controller
    {
        MVCDemoEntities3 db = new MVCDemoEntities3();

        [HttpPost]
        public ActionResult UserList()
        {
            var users = db.User.ToList();
            return View(users);
        }

        public ActionResult UserList(string search)
        {
            MVCDemoEntities3 db = new MVCDemoEntities3();
            List<User> listuser = db.User.ToList();
            return View(db.User.Where(x=>x.Name.StartsWith(search) || search == null).ToList());
        }

        public ActionResult UserRegistration()
        {
            ViewBag.District= db.District.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult UserRegistration(User userdet)
        {
            if(ModelState.IsValid)
            {
            Login log = new Login();
            log.Username = userdet.Username;
            log.Password = userdet.Password;
            log.RoleID = 2;
            log.Isdeleted = false;
            log.CreatedOn = DateTime.Today.Date;
                
            db.Login.Add(log);
            db.SaveChanges();

            userdet.LoginID = db.Login.Max(a=>a.LoginID);
            db.User.Add(userdet);
            db.SaveChanges();

            }
            ViewBag.District = db.District.ToList();
            return RedirectToAction("UserRegistration");
        }

        public JsonResult IsUsernameAvaliable(String Username)
        {
            return Json(!db.Login.Any(x => x.Username == Username), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "UserID,LoginID,Name,Address,Gender,Email,DistrictID")] User user)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.Entry(user).Property(uco => uco.UserID).IsModified = false;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}