using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Service.Interfaces
{
    public interface IPathService
    {
        string GetContentLocation(string tenantId, string type);
        string GetRedirectPath(int tenantId, string originalPath);
    }
}
