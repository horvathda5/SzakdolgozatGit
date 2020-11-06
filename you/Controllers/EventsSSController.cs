using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace you.Controllers
{
    [Authorize]
    public class EventsSSController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetEvents()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
        }
    }
}