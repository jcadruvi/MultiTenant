using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class BaseApiController : ApiController
    {
        private ITenantService _tenantService;
        public Tenant CurrentTenant { get; set; }
        public BaseApiController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            string[] host = controllerContext.Request.Headers.Host.Split(':');
            if (host.Length > 0)
            {
                CurrentTenant = _tenantService.GetCurrentTenant(host[0]);
            }
            base.Initialize(controllerContext);
        }
    }
}
