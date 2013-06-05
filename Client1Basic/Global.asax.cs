using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Client1Basic
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
        }

        /// <summary> 
        /// This will add views from Generic 
        /// </summary> 
        /// <param name="viewEngines"></param> 
        public static void RegisterCustomViewEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();
            //Remove this if there are complications.... 
            viewEngines.Add(new MultiTenant.EmbeddedResourceViewEngine());
        }
    }
}