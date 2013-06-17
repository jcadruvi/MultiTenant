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
        private ICollection<ContentPath> _contentPaths; 
        private ICollection<RequestPath> _requestPaths; 
        static PathRepository() {}
        private PathRepository()
        {
            _contentPaths = new Collection<ContentPath>();
            _requestPaths = new Collection<RequestPath>();

            #region

            _contentPaths.Add(new ContentPath
            {
                TenantId = TenantIds.AppleId,
                Type = ContentTypes.RetailerPartial,
                Location = "Partial1"
            });

            #endregion

            #region Initialize Request Paths

            _requestPaths.Add(new RequestPath
            {
                TenantId = TenantIds.AppleId,
                OriginalPath = "/admin/user/userview",
                NewPath = "/apple/user/userview"
            });
            _requestPaths.Add(new RequestPath
            {
                TenantId = TenantIds.AppleId,
                OriginalPath = "/report/report",
                NewPath = "/apple/report/report"
            });

            _requestPaths.Add(new RequestPath
            {
                TenantId = TenantIds.MicrosoftId,
                OriginalPath = "/report/report",
                NewPath = "/microsoft/report/report"
            });

            #endregion
        }
        public static PathRepository Instance { get { return _instance; } }

        public string GetContentLocation(int tenantId, string type)
        {
            var content = _contentPaths.FirstOrDefault(c => c.TenantId == tenantId && c.Type == type);
            if (content != null)
            {
                return content.Location;
            }
            return null;
        }

        public string GetRedirectPath(int tenantId, string originalPath)
        {
            var path = _requestPaths.FirstOrDefault(p => p.TenantId == tenantId && p.OriginalPath.ToLower() == originalPath.ToLower());
            if (path != null)
            {
                return path.NewPath;
            }
            return null;
        }
    }
}
