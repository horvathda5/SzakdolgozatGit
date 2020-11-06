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
    public class DataStockerController : Controller
    {
        private MVCDemoEntities3 db = new MVCDemoEntities3();

        // GET: DataStocker
        public ActionResult Index()
        {
            return View(db.Data.ToList());
        }

        // GET: DataStocker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data data = db.Data.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
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
