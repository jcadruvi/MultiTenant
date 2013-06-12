using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static bool Access(this HtmlHelper helper, Tenant currentTenant, string accessType)
        { 
            IAccessService accessService = DependencyResolver.Current.GetService<IAccessService>();
            Access access = accessService.GetAccess(currentTenant.Id, accessType);
            if (access == null || !access.HasAccess)
            {
                return false;
            }
            return true;
        }
    }
}