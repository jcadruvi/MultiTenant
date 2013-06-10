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
    public class PathRepository : IPathRepository
    {
        private static PathRepository _instance = new PathRepository();
        private ICollection<RequestPath> _paths; 
        static PathRepository() {}
        private PathRepository()
        {
            _paths = new Collection<RequestPath>();

            #region Initialize Paths

            _paths.Add(new RequestPath
            {
                TenantId = 1,
                OriginalPath = "/store",
                NewPath = "/apple/applestore"
            });
            _paths.Add(new RequestPath
            {
                TenantId = 1,
                OriginalPath = "/admin/user",
                NewPath = "/apple/appleuser"
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
        }
        public static PathRepository Instance { get { return _instance; } }

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
    }
}
