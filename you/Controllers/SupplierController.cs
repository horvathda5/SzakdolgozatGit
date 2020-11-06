using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace you.Controllers
{
    public class SupplierController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}