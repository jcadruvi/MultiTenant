using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void SetCurrentTenant(string host)
        {
            _repository.SetCurrentTenant(host);
        }
    }
}
