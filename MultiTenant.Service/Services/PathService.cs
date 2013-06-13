using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Repository.Repositories;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Service.Services
{
    public class PathService : IPathService
    {
        private readonly PathRepository _repository;
        public PathService()
        {
            _repository = PathRepository.Instance;
        }
        public string GetRedirectPath(int tenantId, string originalPath)
        {
            return _repository.GetRedirectPath(tenantId, originalPath);
        }
    }
}
