using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Controllers;
using MultiTenant.Models;

namespace MultiTenant.Areas.Microsoft.Controllers
{
    public class MicrosoftStoreController : BaseController
    {
        //
        // GET: /Microsoft/MicrosoftStore/

        public ActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.Host = Host;
            return View("Index", model);
        }

    }
}
