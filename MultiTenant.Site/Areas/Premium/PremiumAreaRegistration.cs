using System.Web.Mvc;
using MultiTenant.Common.Types;
using MultiTenant.RouteConstraints;

namespace MultiTenant.Areas.Premium
{
    public class PremiumAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Premium";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Premium_default",
                url: "Premium/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                constraints: new { action = new AccessRouteConstraint(AccessTypes.Premium) }
            );
        }
    }
}
