﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;
using MultiTenant.Service.Services;

namespace MultiTenant.Controllers
{
    public class TenantApiController : BaseApiController
    {
        private ITenantService _tenantService; 
        public TenantApiController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }
        public Tenant Get()
        {
            return _tenantService.GetCurrentTenant(Host);
        }
        public IEnumerable<Tenant> GetAll()
        {
            return _tenantService.GetTenants();
        }

        public void Put(int id)
        {
            _tenantService.SetCurrentTenant(id);
        }
    }
}
