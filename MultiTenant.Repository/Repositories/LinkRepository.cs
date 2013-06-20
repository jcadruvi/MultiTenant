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
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "StoreProgram",
                Controller = "Store",
                Name = "Program",
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "UserView",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Survey",
                Area = "Survey",
                Controller = "Survey",
                Name = "Survey",
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Report",
                Controller = "Report",
                Name = "Report",
                Id = TenantIds.CoreId.ToString(),
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Area = "Display",
                Controller = "Display",
                Name = "Display",
                Id = TenantIds.AppleId.ToString(),
                Type = LinkTypes.Menu
            });
            #endregion
        }
        public static LinkRepository Instance { get { return _instance; } }
        public Link GetLink(string id, string linkType)
        {
            return GetLinks(id, linkType).FirstOrDefault();
        }
        public IList<Link> GetLinks(string id, string linkType)
        {
            return (from m in _links
                    where m.Id == id && m.Type == linkType
                    select m).ToList();
        }

        public IList<Link> GetMenuLinks(string id)
        {
            var coreLinks = GetLinks(TenantIds.CoreId.ToString(), LinkTypes.Menu);
            var tenantLinks = GetLinks(id, LinkTypes.Menu);
            return coreLinks.Concat(tenantLinks).ToList();
        } 
    }
}
