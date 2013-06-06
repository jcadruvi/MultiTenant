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
        public Tenant GetCurrentTenant()
        {
            return _repository.GetCurrentTenant();
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
        public Tenant SetCurrentTenant(string host)
        {
            return _repository.SetCurrentTenant(host);
        }
    }
}
