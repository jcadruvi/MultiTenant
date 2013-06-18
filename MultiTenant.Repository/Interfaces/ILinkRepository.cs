using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Repository.Interfaces
{
    public interface ILinkRepository
    {
        Link GetLink(int tenantId, string linkType);
        IList<Link> GetLinks(int tenantId, string linkType);
        IList<Link> GetMenuLinks(int tenantId);
    }
}
