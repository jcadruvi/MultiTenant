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
    public class LinkRepository : ILinkRepository
    {
        private static readonly LinkRepository _instance = new LinkRepository();
        private ICollection<Link> _links;
        static LinkRepository()
        {
        }
        private LinkRepository()
        {
            _links = new Collection<Link>();

            #region Initialize Links

            _links.Add(new Link
            {
                Action = "Store",
                Controller = "Store",
                Name = "Store",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "StoreProgram",
                Controller = "Store",
                Name = "Program",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Area = "Display",
                Controller = "Display",
                Name = "Display",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "UserView",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Survey",
                Area = "Survey",
                Controller = "Survey",
                Name = "Survey",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Report",
                Controller = "Report",
                Name = "Report",
                TennantId = TenantIds.CoreId,
                Type = LinkTypes.Menu
            });

            #endregion
        }
        public static LinkRepository Instance { get { return _instance; } }
        public Link GetLink(int tenantId, string linkType)
        {
            return GetLinks(tenantId, linkType).FirstOrDefault();
        }
        public IList<Link> GetLinks(int tenantId, string linkType)
        {
            return (from m in _links
                    where m.TennantId == tenantId && m.Type == linkType
                    select m).ToList();
        }

        private IList<Link> GetMenuLinks(int tenantId)
        {
            var coreLinks = GetLinks(TenantIds.CoreId, LinkTypes.Menu);
            var tenantLinks = GetLinks(tenantId, LinkTypes.Menu);
            return coreLinks.Concat(tenantLinks).ToList();
        } 
    }
}
