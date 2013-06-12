using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Repository.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private static readonly StoreRepository _instance = new StoreRepository();
        private static ICollection<Store> _stores;
        static StoreRepository() {}
        private StoreRepository()
        {
            _stores = new Collection<Store>();
        }
        public static StoreRepository Instance { get { return _instance; } }

        public IEnumerable<Store> GetStores()
        {
            return _stores;
        } 
    }
}
