using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Controllers;
using MultiTenant.Models;

namespace MultiTenant.Areas.Apple.Controllers
{
    public class AppleStoreController : BaseController
    {
        //
        // GET: /Apple/AppleStore/

        public ActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.Host = Host;
            return View("Index", model);
        }

    }
}
