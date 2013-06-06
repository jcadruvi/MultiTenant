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
        Tenant GetCurrentTenant();
        Link GetLink(int tenantId, string linkType);
        IList<Link> GetLinks(int tenantId, string linkType);
        string GetRedirectPath(int tenantId, string originalPath);
        Tenant SetCurrentTenant(string host);
    }
}
