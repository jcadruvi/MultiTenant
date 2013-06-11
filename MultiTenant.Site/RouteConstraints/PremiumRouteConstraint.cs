using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;
using MultiTenant.Service.Services;

namespace MultiTenant.RouteConstraints
{
    public class PremiumRouteConstraint : IRouteConstraint
    {
        private ITenantService _tenantService;

        public PremiumRouteConstraint()
        {
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
            if (currentTenant.Id == 3)
            {
                return false;
            }
            return true;
        }
    }
}