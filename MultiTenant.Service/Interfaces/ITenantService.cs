using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Service.Interfaces
{
    public interface ITenantService
    {
        Tenant GetCurrentTenant(string host);
        string GetRedirectPath(int tenantId, string originalPath);
        IEnumerable<Tenant> GetTenants();
        Tenant SetCurrentTenant(int id);
    }
}
