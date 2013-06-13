﻿using System;
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
            Access access = accessService.GetAccess(currentTenant.Id, accessType);
            if (access == null || !access.HasAccess)
            {
                return false;
            }
            return true;
        }

        public static bool HasAccess(Tenant currentTenant, string[] accessTypes)
        {
            IAccessService accessService = DependencyResolver.Current.GetService<IAccessService>();
            foreach (string accessType in accessTypes)
            {
                Access access = accessService.GetAccess(currentTenant.Id, accessType);
                if (access == null || !access.HasAccess)
                {
                    return false;
                }
            }
            return true;
        }
    }
}