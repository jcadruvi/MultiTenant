using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class BaseController : Controller
    {
        public Tenant CurrentTenant { get; set; }
        private ITenantService _tenantService;
        public BaseController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string[] host = filterContext.RequestContext.HttpContext.Request.Headers["Host"].Split(':');
            if (host.Length > 0)
            {
                CurrentTenant = _tenantService.GetCurrentTenant(host[0]);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
