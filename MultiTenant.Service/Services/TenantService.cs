using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;
using MultiTenant.Repository.Repositories;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Service.Services
{
    public class TenantService : ITenantService
    {
        private TenantRepository _repository;
        public TenantService()
        {
            _repository = TenantRepository.Instance;

        }
        public Tenant GetCurrentTenant(string host)
        {
            return _repository.GetCurrentTenant(host);
        }
        public Link GetLink(int tenantId, string linkType)
        {
            return _repository.GetLink(tenantId, linkType);
        }
        public IList<Link> GetLinks(int tenantId, string linkType)
        {
            return _repository.GetLinks(tenantId, linkType);
        }
        public string GetRedirectPath(int tenantId, string originalPath)
        {
            return _repository.GetRedirectPath(tenantId, originalPath);
        }
        public IEnumerable<Tenant> GetTenants()
        {
            return _repository.GetTenants();
        }
        public Tenant SetCurrentTenant(int id)
        {
            return _repository.SetCurrentTenant(id);
        }
    }
}
