using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace you.Controllers
{
    [Authorize]
    public class StockerController : Controller
    {

        // GET: Stocker
        public ActionResult Index()
        {
            return View();
        }
    }
}