using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MultiTenant.Service.Interfaces;
using MultiTenant.Service.Services;
using MultiTenant.App_Start;

namespace MultiTenant
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            string[] host = Context.Request.Headers["Host"].Split(':');
            ITenantService tenantService = new TenantService(); 
            if (host.Length == 0)
            {
                return;
            }
            if (host[0] == "localhost")
            {
                host[0] = "Apple";
            }
            tenantService.SetCurrentTenant(host[0]);
        }
    }
}