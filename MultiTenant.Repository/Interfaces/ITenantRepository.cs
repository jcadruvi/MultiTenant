using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Repository.Interfaces
{
    public interface ITenantRepository
    {
        Tenant GetCurrentTenant(string host);
        string GetRedirectPath(int tenantId, string originalPath);
        IEnumerable<Tenant> GetTenants();
        Tenant SetCurrentTenant(int id);
    }
}
