using System.Web.Mvc;
using MultiTenant.RouteConstraints;

namespace MultiTenant.Areas.Microsoft
{
    public class MicrosoftAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Microsoft";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Microsoft_default",
                url: "Microsoft/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                constraints: new { action = new TenantRouteConstraint(2) }
            );
        }
    }
}
