using System.Web.Http;
using System.Web.Mvc;
using MultiTenant.RouteConstraints;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }, 
                constraints: new { action = new PremiumRouteConstraint() }
            );
            
        }
    }
}
