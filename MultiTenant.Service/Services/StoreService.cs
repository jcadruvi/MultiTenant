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
        public void DeleteStore(int id)
        {
            _storeRepository.DeleteStore(id);
        }
        public Store Get(int id)
        {
            return _storeRepository.Get(id);
        }
        public IEnumerable<Store> GetStores()
        {
            return _storeRepository.GetStores();
        }
        public void UpdateStore(Store store)
        {
            _storeRepository.UpdateStore(store);
        }
    }
}
