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
            string path = Context.Request.Path;
            IPathService pathService = DependencyResolver.Current.GetService(typeof(IPathService)) as IPathService;
            ITenantService tenantService = DependencyResolver.Current.GetService(typeof(ITenantService)) as ITenantService;
            if (host.Length == 0)
            {
                return;
            }
            if (path.Length >= 4 && path.ToLower().Substring(0, 4) == "/api")
            {
                return;
            }
            // Web api calls can have an Area before the /api call. 
            if (path.Length >= 5 && path.ToLower().IndexOf("/api/") > 0)
            {
                return;
            }
            if (path.Length >= 5 && path.ToLower().Substring(0, 5) == "/core")
            {
                return;
            }
            if (path.Length >= 7 && path.ToLower().Substring(0, 7) == "/custom")
            {
                return;
            }
            currentTenant = tenantService.GetCurrentTenant(host[0]);
            if (currentTenant == null)
            {
                return;
            }
            string redirectPath = pathService.GetRedirectPath(currentTenant.Id, path);
            if (redirectPath != null)
            {
                Context.RewritePath(redirectPath);
            }
        }
    }
}