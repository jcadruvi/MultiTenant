using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MultiTenant.Common.Types;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;
using MultiTenant.Service.Services;

namespace MultiTenant.RouteConstraints
{
    public class PremiumRouteConstraint : IRouteConstraint
    {
        private IAccessService _accessService;
        private ITenantService _tenantService;

        public PremiumRouteConstraint()
        {
            _accessService = DependencyResolver.Current.GetService(typeof(IAccessService)) as IAccessService;
            _tenantService = DependencyResolver.Current.GetService(typeof(ITenantService)) as ITenantService;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            Access access;
            Tenant currentTenant;
            string[] host = httpContext.Request.Headers["host"].Split(':');
            
            if (host.Length == 0 || _tenantService == null || _accessService == null)
            {
                return false;
            }
            currentTenant = _tenantService.GetCurrentTenant(host[0]);
            if (currentTenant == null)
            {
                return false;
            }
            access = _accessService.GetAccess(currentTenant.Id, AccessTypes.Premium);
            if (access == null || !access.HasAccess)
            {
                return false;
            }
            return true;
        }
    }
}