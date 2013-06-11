using System.Web.Mvc;
using MultiTenant.Common.Types;
using MultiTenant.RouteConstraints;

namespace MultiTenant.Areas.Survey
{
    public class SurveyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Survey";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Survey_default",
                url: "Survey/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = new AccessRouteConstraint(AccessTypes.Ultimate) }
            );
        }
    }
}
