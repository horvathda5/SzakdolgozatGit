using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using you.Models;

namespace you.Controllers
{
    public class Users1Controller : Controller
    {
        private MVCDemoEntities3 db = new MVCDemoEntities3();

        // GET: Users1
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.District).Include(u => u.Login).Include(u => u.Permission);
            return View(user.ToList());
        }

        // GET: Users1/Details/5
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

        // GET: Users1/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.District, "DistrictID", "DistrictName");
            ViewBag.LoginID = new SelectList(db.Login, "LoginID", "Username");
            ViewBag.UserID = new SelectList(db.Permission, "UserID", "Permission1");
            return View();
        }

        // POST: Users1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,LoginID,Name,Address,Gender,Email,DistrictID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.District, "DistrictID", "DistrictName", user.DistrictID);
            ViewBag.LoginID = new SelectList(db.Login, "LoginID", "Username", user.LoginID);
            ViewBag.UserID = new SelectList(db.Permission, "UserID", "Permission1", user.UserID);
            return View(user);
        }

        // GET: Users1/Edit/5
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
            ViewBag.DistrictID = new SelectList(db.District, "DistrictID", "DistrictName", user.DistrictID);
            ViewBag.LoginID = new SelectList(db.Login, "LoginID", "Username", user.LoginID);
            ViewBag.UserID = new SelectList(db.Permission, "UserID", "Permission1", user.UserID);
            return View(user);
        }

        // POST: Users1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,LoginID,Name,Address,Gender,Email,DistrictID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.District, "DistrictID", "DistrictName", user.DistrictID);
            ViewBag.LoginID = new SelectList(db.Login, "LoginID", "Username", user.LoginID);
            ViewBag.UserID = new SelectList(db.Permission, "UserID", "Permission1", user.UserID);
            return View(user);
        }

        // GET: Users1/Delete/5
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

        // POST: Users1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
