using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MultiTenant.Model;
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
            Tenant currentTenant;
            string[] host = Context.Request.Headers["Host"].Split(':');
            ITenantService tenantService = new TenantService(); 

            if (host.Length == 0)
            {
                return;
            }
            currentTenant = host[0] == "localhost"
                ? tenantService.GetCurrentTenant()
                : tenantService.SetCurrentTenant(host[0]);
            if (host[0] == "localhost" && currentTenant == null)
            {
                currentTenant = tenantService.SetCurrentTenant(1);
            }
            if (currentTenant == null)
            {
                return;
            }
            string redirectPath = tenantService.GetRedirectPath(currentTenant.Id, Context.Request.Path);
            if (redirectPath != null)
            {
                Context.RewritePath(redirectPath);
            }
        }
    }
}