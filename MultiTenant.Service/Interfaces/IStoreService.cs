using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Service.Interfaces
{
    public interface IStoreService
    {
        void DeleteStore(int id);
        Store Get(int id);
        IEnumerable<Store> GetStores();
        void UpdateStore(Store store);
    }
}
