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
                TenantId = TenantIds.AppleId,
                OriginalPath = "/admin/user/userview",
                NewPath = "/apple/user/userview"
            });
            _paths.Add(new RequestPath
            {
                TenantId = TenantIds.AppleId,
                OriginalPath = "/report/report",
                NewPath = "/apple/report/report"
            });

            _paths.Add(new RequestPath
            {
                TenantId = TenantIds.MicrosoftId,
                OriginalPath = "/report/report",
                NewPath = "/microsoft/report/report"
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
