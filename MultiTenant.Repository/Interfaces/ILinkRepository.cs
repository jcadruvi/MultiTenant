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
        Link GetLink(string id, string linkType);
        IList<Link> GetLinks(string id, string linkType);
        IList<Link> GetMenuLinks(string id);
    }
}
