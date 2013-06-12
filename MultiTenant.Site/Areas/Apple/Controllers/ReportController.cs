using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Controllers;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Areas.Apple.Controllers
{
    public class ReportController : BaseController
    {
        public ReportController(ITenantService tenantService) : base(tenantService)
        {
        }
        //
        // GET: /Apple/Report/

        public ActionResult Report()
        {
            BaseViewModel model = new BaseViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Index", model);
        }

    }
}
