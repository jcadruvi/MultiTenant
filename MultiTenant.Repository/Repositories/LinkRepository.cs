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
                Action = "Index",
                Controller = "Store",
                Name = "Store",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Display",
                Name = "Display",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = 1,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Store",
                Name = "Store",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = 2,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Store",
                Name = "Store",
                TennantId = 3,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                TennantId = 3,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = 3,
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
    }
}
