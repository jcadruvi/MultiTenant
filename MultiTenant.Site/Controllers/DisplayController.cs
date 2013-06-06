using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Controllers
{
    public class DisplayController : Controller
    {
        //
        // GET: /Display/

        public ActionResult Index()
        {
            return View();
        }

    }
}
