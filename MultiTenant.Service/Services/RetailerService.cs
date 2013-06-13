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
    public class RetailerService : IRetailerService
    {
        private readonly RetailerRepository _repository;
        public RetailerService()
        {
            _repository = RetailerRepository.Instance;
        }
        public IEnumerable<Retailer> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
