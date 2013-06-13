using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;
using MultiTenant.Repository.Interfaces;

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

            _stores.Add(new Store
            {
                Id = 1, 
                City = "San Jose",
                Name = "Frys #1",
                Number = "1",
                State = "CA"
            });
            _stores.Add(new Store
            {
                Id = 2,
                City = "Milpitas",
                Name = "Frys #2",
                Number = "2",
                State = "CA"
            });
            _stores.Add(new Store
            {
                Id = 3,
                City = "Fremont",
                Name = "Frys #3",
                Number = "3",
                State = "CA"
            });
            _stores.Add(new Store
            {
                Id = 4,
                City = "San Ramon",
                Name = "Frys #4",
                Number = "4",
                State = "CA"
            });
            _stores.Add(new Store
            {
                Id = 5,
                City = "Pleasanton",
                Name = "Frys #5",
                Number = "5",
                State = "CA"
            });
            _stores.Add(new Store
            {
                Id = 6,
                City = "Santa Clara",
                Name = "Frys #6",
                Number = "6",
                State = "CA"
            });
        }
        public static StoreRepository Instance { get { return _instance; } }

        public Store Get(int id)
        {
            return (from s in _stores
                    where s.Id == id
                    select s).FirstOrDefault();
        }

        public IEnumerable<Store> GetStores()
        {
            return _stores;
        } 
    }
}
