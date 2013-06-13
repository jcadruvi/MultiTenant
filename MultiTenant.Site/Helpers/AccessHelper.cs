using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Helpers
{
    public static class AccessHelper
    {
        public static bool HasAccess(Tenant currentTenant, string accessType)
        { 
            IAccessService accessService = DependencyResolver.Current.GetService<IAccessService>();
            if (currentTenant == null)
            {
                return false;
            }
            return accessService.HasAccess(currentTenant.Id, accessType);
        }

        public static bool HasAccess(Tenant currentTenant, string[] accessTypes)
        {
            IAccessService accessService = DependencyResolver.Current.GetService<IAccessService>();
            if (currentTenant == null)
            {
                return false;
            }
            return accessService.HasAccess(currentTenant.Id, accessTypes);
        }
    }
}