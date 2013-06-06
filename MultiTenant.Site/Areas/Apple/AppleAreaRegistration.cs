using System.Web.Mvc;

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
                "Apple_default",
                "Apple/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
