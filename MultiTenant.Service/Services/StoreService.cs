using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;
using MultiTenant.Repository;
using MultiTenant.Repository.Interfaces;
using MultiTenant.Repository.Repositories;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Service.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        public StoreService()
        {
            _storeRepository = StoreRepository.Instance;
        }
        public IEnumerable<Store> GetStores()
        {
            return _storeRepository.GetStores();
        }
    }
}
