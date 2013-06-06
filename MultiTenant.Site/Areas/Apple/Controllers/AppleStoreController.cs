using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Areas.Apple.Controllers
{
    public class AppleStoreController : Controller
    {
        //
        // GET: /Apple/AppleStore/

        public ActionResult Index()
        {
            return View();
        }

    }
}
