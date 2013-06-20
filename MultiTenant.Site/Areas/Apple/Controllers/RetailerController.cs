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
    public class RetailerController : BaseController
    {
        public RetailerController(ITenantService tenantService)
            : base(tenantService)
        {
        }
        //
        // GET: /Apple/Report/

        public ActionResult RetailerInfo()
        {
            BaseViewModel model = new BaseViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("RetailerInfo", model);
        }
    }
}