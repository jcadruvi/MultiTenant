using System;
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
    public class TenantApiController : ApiController
    {
        private ITenantService _service; 
        public TenantApiController()
        {
            _service = new TenantService();
        }
        public Tenant Get()
        {
            return _service.GetCurrentTenant();
        }
        public IEnumerable<Tenant> GetAll()
        {
            return _service.GetTenants();
        }

        public void Put(int id)
        {
            _service.SetCurrentTenant(id);
        }
    }
}
