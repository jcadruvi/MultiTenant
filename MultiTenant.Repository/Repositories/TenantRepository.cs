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
    public class TenantRepository : ITenantRepository
    {
        private static readonly TenantRepository _instance = new TenantRepository();
        private ICollection<Tenant> _tenants;
        private Tenant _currentTenant;
        static TenantRepository()
        {
        }
        private TenantRepository()
        {
            _tenants = new Collection<Tenant>();
            _tenants.Add(new Tenant
            {
                Host = "Apple",
                Name = "Apple",
                Id = 1
            });
            _tenants.Add(new Tenant
            {
                Host = "Safeway",
                Name = "Safeway",
                Id = 2
            });
            _tenants.Add(new Tenant
            {
                Host = "BestBuy",
                Name = "BestBuy",
                Id = 3
            });
            _currentTenant = null;
        }
        public static TenantRepository Instance
        {
            get { return _instance; }
        }
        public Tenant GetCurrentTenant()
        {
            return _currentTenant;
        }
        public void SetCurrentTenant(string host)
        {
            var tenant = (from t in _tenants
                          where t.Host == host
                          select t).FirstOrDefault();
            _currentTenant = tenant;
        }
    }
}
