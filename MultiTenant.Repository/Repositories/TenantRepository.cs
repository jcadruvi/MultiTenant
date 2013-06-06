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
        private ICollection<MenuItem> _menuItems; 
        private ICollection<Tenant> _tenants;
        private Tenant _currentTenant;
        static TenantRepository()
        {
        }
        private TenantRepository()
        {
            _menuItems = new Collection<MenuItem>();
            _tenants = new Collection<Tenant>();

            _menuItems.Add(new MenuItem
            {
                Action = "Store",
                Area = "Apple",
                Controller = "Store",
                Name = "Store",
                TennantId = 1
            });
            _menuItems.Add(new MenuItem
            {
                Action = "Retailer",
                Area = "Apple",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = 1
            });
            _menuItems.Add(new MenuItem
            {
                Action = "Display",
                Area = "Apple",
                Controller = "Display",
                Name = "Display",
                TennantId = 1
            });
            _menuItems.Add(new MenuItem
            {
                Action = "Store",
                Area = "Safeway",
                Controller = "Store",
                Name = "Store",
                TennantId = 2
            });
            _menuItems.Add(new MenuItem
            {
                Action = "Retailer",
                Area = "Safeway",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = 2
            });
            _menuItems.Add(new MenuItem
            {
                Action = "Store",
                Area = "Safeway",
                Controller = "Store",
                Name = "Store",
                TennantId = 3
            });

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
        public IList<MenuItem> GetMenuItems(int tenantId)
        {
            return (from m in _menuItems
                    where m.TennantId == tenantId
                    select m).ToList();
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
