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
    public class AccessRepository : IAccessRepository
    {
        private static AccessRepository _instance = new AccessRepository();
        private ICollection<Access> _accessList;
        static AccessRepository() {}
        private AccessRepository()
        {
            _accessList = new Collection<Access>();
            _accessList.Add(new Access
            {
                TenantId = TenantIds.AppleId,
                Type = AccessTypes.ProgramFeature,
                HasAccess = true
            });
            _accessList.Add(new Access
            {
                TenantId = TenantIds.AppleId,
                Type = AccessTypes.Ultimate,
                HasAccess = true
            });
            _accessList.Add(new Access
            {
                TenantId = TenantIds.MicrosoftId,
                Type = AccessTypes.Premium,
                HasAccess = true
            });
        }
        public static AccessRepository Instance { get { return _instance; } }
        public Access GetAccess(int tenantId, string type)
        {
            Access access = (from a in _accessList
                             where a.TenantId == tenantId && a.Type == type
                             select a).FirstOrDefault();
            if (access == null && type == AccessTypes.Premium)
            {
                access = (from a in _accessList
                          where a.TenantId == tenantId && a.Type == AccessTypes.Ultimate
                          select a).FirstOrDefault();
            }
            return access;
        }

        public bool HasAccess(int tenantId, string type)
        {
            Access access = GetAccess(tenantId, type);
            if (access == null || !access.HasAccess)
            {
                return false;
            }
            return true;
        }

        public bool HasAccess(int tenantId, string[] types)
        {
            Access access;
            foreach (string type in types)
            {
                access = GetAccess(tenantId, type);
                if (access == null || !access.HasAccess)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
