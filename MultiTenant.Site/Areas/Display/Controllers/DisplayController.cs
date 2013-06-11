using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Controllers;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Areas.CPG.Controllers
{
    public class DisplayController : BaseController
    {
        public DisplayController(ITenantService tenantService) : base(tenantService)
        {
        }

        //
        // GET: /Display/

        public ActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Index", model);
        }

    }
}
