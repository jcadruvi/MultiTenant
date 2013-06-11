using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;
using MultiTenant.Repository.Interfaces;
using MultiTenant.Repository.Repositories;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Service.Services
{
    public class AccessService : IAccessService
    {
        private IAccessRepository _accessRepository;

        public AccessService()
        {
            _accessRepository = AccessRepository.Instance;
        }

        public Access GetAccess(int tenantId, string type)
        {
            return _accessRepository.GetAccess(tenantId, type);
        }
    }
}
