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
        private ICollection<Link> _menuItems;
        private ICollection<RequestPath> _paths; 
        private ICollection<Tenant> _tenants;
        private Tenant _currentTenant;
        static TenantRepository()
        {
        }
        private TenantRepository()
        {
            _menuItems = new Collection<Link>();
            _paths = new Collection<RequestPath>();
            _tenants = new Collection<Tenant>();

            #region Initialize _menuItems

            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Store",
                Name = "Store",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Display",
                Name = "Display",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "User",
                Name = "User",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Store",
                Name = "Store",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "User",
                Name = "User",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Store",
                Name = "Store",
                TennantId = 3,
                Type = LinkTypes.Menu
            }); 
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "User",
                Name = "User",
                TennantId = 3,
                Type = LinkTypes.Menu
            });
            _menuItems.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = 3,
                Type = LinkTypes.Menu
            });
            #endregion

            #region Initialize _paths

            _paths.Add(new RequestPath
            {
                TenantId = 1,
                OriginalPath = "/store",
                NewPath = "/apple/applestore"
            });

            _paths.Add(new RequestPath
            {
                TenantId = 1,
                OriginalPath = "/retailer",
                NewPath = "/apple/appleretailer"
            });

            _paths.Add(new RequestPath
            {
                TenantId = 1,
                OriginalPath = "Images/userCoreCustom.jpg",
                NewPath = "/1/Images/userCoreCustom.jpg"
            });

            _paths.Add(new RequestPath
            {
                TenantId = 2,
                OriginalPath = "/store",
                NewPath = "/microsoft/microsoftstore"
            });

            #endregion

            #region Initialize _tenants

            _tenants.Add(new Tenant
            {
                Host = "apple",
                Name = "Apple",
                Id = 1
            });
            _tenants.Add(new Tenant
            {
                Host = "microsoft",
                Name = "Microsoft",
                Id = 2
            });
            _tenants.Add(new Tenant
            {
                Host = "bestbuy",
                Name = "BestBuy",
                Id = 3
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
        public Link GetLink(int tenantId, string linkType)
        {
            return GetLinks(tenantId, linkType).FirstOrDefault();
        }
        public IList<Link> GetLinks(int tenantId, string linkType)
        {
            return (from m in _menuItems
                    where m.TennantId == tenantId && m.Type == linkType
                    select m).ToList();
        }
        public string GetRedirectPath(int tenantId, string originalPath)
        {
            var path = (from p in _paths
                        where p.TenantId == tenantId && p.OriginalPath.ToLower() == originalPath.ToLower()
                        select p).FirstOrDefault();
            if (path != null)
            {
                return path.NewPath;
            }
            return null;
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
