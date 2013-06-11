using System.Web.Mvc;
using MultiTenant.RouteConstraints;

namespace MultiTenant.Areas.Apple
{
    public class AppleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Apple";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Apple_default",
                url: "Apple/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                constraints: new { action = new TenantRouteConstraint(1) }
            );
        }
    }
}
