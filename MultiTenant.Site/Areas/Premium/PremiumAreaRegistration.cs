using System.Web.Mvc;

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
                "Premium_default",
                "Premium/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
