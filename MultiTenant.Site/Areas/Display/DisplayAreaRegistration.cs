using System.Web.Mvc;
using MultiTenant.Common.Types;
using MultiTenant.RouteConstraints;

namespace MultiTenant.Areas.CPG
{
    public class DisplayAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Display";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Display_default",
                url: "Display/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                constraints: new { action = new AccessRouteConstraint(AccessTypes.Ultimate) }
            );
        }
    }
}
