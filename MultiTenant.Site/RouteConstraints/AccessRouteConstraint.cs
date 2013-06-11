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
    public class AccessRouteConstraint : IRouteConstraint
    {
        private IAccessService _accessService;
        private string _accessType;
        private ITenantService _tenantService;

        public AccessRouteConstraint(string accessType)
        {
            _accessService = DependencyResolver.Current.GetService(typeof(IAccessService)) as IAccessService;
            _accessType = accessType;
            _tenantService = DependencyResolver.Current.GetService(typeof(ITenantService)) as ITenantService;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            Access access;
            Tenant currentTenant;
            string[] host = httpContext.Request.Headers["host"].Split(':');
            
            if (host.Length == 0 || _tenantService == null || _accessService == null || _accessType == null)
            {
                return false;
            }
            currentTenant = _tenantService.GetCurrentTenant(host[0]);
            if (currentTenant == null)
            {
                return false;
            }
            access = _accessService.GetAccess(currentTenant.Id, _accessType);
            if (access == null || !access.HasAccess)
            {
                return false;
            }
            return true;
        }
    }
}