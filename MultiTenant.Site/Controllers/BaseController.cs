using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Controllers
{
    public class BaseController : Controller
    {
        public string Host { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string[] host = filterContext.RequestContext.HttpContext.Request.Headers["Host"].Split(':');
            if (host.Length > 0)
            {
                Host = host[0];
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
