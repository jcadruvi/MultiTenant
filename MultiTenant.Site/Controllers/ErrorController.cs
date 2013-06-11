using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(ITenantService tenantService) : base(tenantService)
        {
        }

        public ActionResult Index()
        {
            return View("Error");
        }

        //
        // GET: /Error/

        public ActionResult Error404()
        {
            return View("Error404");
        }

    }
}
