using System.Web.Mvc;

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
                "Microsoft_default",
                "Microsoft/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
