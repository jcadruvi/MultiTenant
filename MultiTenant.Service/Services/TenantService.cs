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
        private readonly TenantRepository _repository;
        public TenantService()
        {
            _repository = TenantRepository.Instance;
        }
        public Tenant GetCurrentTenant(string host)
        {
            return _repository.GetCurrentTenant(host);
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
