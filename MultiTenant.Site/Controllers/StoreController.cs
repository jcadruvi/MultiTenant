using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class StoreController : BaseController
    {
        public StoreController(ITenantService tenantService) : base(tenantService)
        {
            
        }

        //
        // GET: /Store/

        public ActionResult Store()
        {
            StoreViewModel model = new StoreViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Index", model);
        }
        public ActionResult Store2()
        {
            StoreViewModel model = new StoreViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Store2", model);
        }
    }
}
