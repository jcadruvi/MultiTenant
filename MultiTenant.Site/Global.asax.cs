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
            string corePath = "/core";
            string customPath = "/custom";
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
            if (path.Length >= 8 && path.ToLower().Substring(0, 4) == "/scripts")
            {
                return;
            }
            if (path.Length >= 8 && path.ToLower().Substring(0, 4) == "/content")
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
                return;
            }
            if (path.ToLower().IndexOf(corePath.ToLower()) >= 0)
            {
                Context.RewritePath("/Goa" + path);
            }
            if (path.ToLower().IndexOf(customPath.ToLower()) >= 0)
            {
                Context.RewritePath("/Goa" + path.Substring(0, customPath.Length) + "/" + currentTenant.Id.ToString() + path.Substring(customPath.Length, path.Length - customPath.Length));
            }
        }
    }
}