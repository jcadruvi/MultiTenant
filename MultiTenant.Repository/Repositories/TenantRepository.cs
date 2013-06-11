using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Common.Types;
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

            #region Initialize _tenants

            _tenants.Add(new Tenant
            {
                Host = "apple",
                Name = "Apple",
                Id = TenantIds.AppleId
            });
            _tenants.Add(new Tenant
            {
                Host = "microsoft",
                Name = "Microsoft",
                Id = TenantIds.MicrosoftId
            });
            _tenants.Add(new Tenant
            {
                Host = "bestbuy",
                Name = "BestBuy",
                Id = TenantIds.BestBuyId
            });

            #endregion

            _currentTenant = null;
        }
        public static TenantRepository Instance
        {
            get { return _instance; }
        }
        /**********************************************************************************
         * The check for "localhost" is a hack to get it working in debug mode. 
         * This makes the example easier to use but in production you will always need to 
         * use the host to get the tenant. You can't rely on a variable because you could 
         * have requests from different tenants that occur at the same time.
        **********************************************************************************/
        public Tenant GetCurrentTenant(string host)
        {
            if (host == "localhost")
            {
                return _currentTenant;
            }
            return (from t in _tenants
                    where t.Host == host
                    select t).FirstOrDefault();
        }
        
        public IEnumerable<Tenant> GetTenants()
        {
            return _tenants;
        }
        public Tenant SetCurrentTenant(int id)
        {
            var tenant = (from t in _tenants
                          where t.Id == id
                          select t).FirstOrDefault();
            _currentTenant = tenant;
            return _currentTenant;
        }
    }
}
