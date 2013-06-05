using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic.Controllers
{
    public partial class TestPageController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.IsSetFromClient = Generic.Session.SessionSingleton.Instance.IsSetFromClient;
            return View();
        }

    }
}
