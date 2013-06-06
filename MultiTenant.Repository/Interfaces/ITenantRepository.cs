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
        Tenant GetCurrentTenant();
        Link GetLink(int tenantId, string linkType);
        IList<Link> GetLinks(int tenantId, string linkType);
        string GetRedirectPath(int tenantId, string originalPath);
        Tenant SetCurrentTenant(string host);
    }
}
