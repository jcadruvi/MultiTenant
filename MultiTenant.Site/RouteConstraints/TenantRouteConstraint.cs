using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.RouteConstraints
{
    public class TenantRouteConstraint : IRouteConstraint
    {
        private int _tenantId;
        private ITenantService _tenantService;

        public TenantRouteConstraint(int tenantId)
        {
            _tenantId = tenantId;
            _tenantService = DependencyResolver.Current.GetService(typeof(ITenantService)) as ITenantService;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string[] host = httpContext.Request.Headers["host"].Split(':');
            Tenant currentTenant;
            
            if (host.Length == 0)
            {
                return false;
            }
            currentTenant = _tenantService.GetCurrentTenant(host[0]);
            if (currentTenant == null)
            {
                return false;
            }
            if (currentTenant.Id != _tenantId)
            {
                return false;
            }
            return true;
        }
    }
}