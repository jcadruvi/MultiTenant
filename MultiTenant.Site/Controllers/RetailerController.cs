using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class RetailerController : BaseController
    {
        public RetailerController(ITenantService tenantService) : base(tenantService)
        {
        }

        //
        // GET: /Retailer/

        public ActionResult Index()
        {
            RetailerViewModel model = new RetailerViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Index", model);
        }

    }
}
