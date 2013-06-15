using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Repository.Interfaces
{
    public interface IPathRepository
    {
        string GetContentLocation(int tenantId, string type);
        string GetRedirectPath(int tenantId, string originalPath);
    }
}
