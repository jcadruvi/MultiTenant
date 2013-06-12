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
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Area = "Display",
                Controller = "Display",
                Name = "Display",
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "UserView",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Survey",
                Area = "Survey",
                Controller = "Survey",
                Name = "Survey",
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Report",
                Name = "Report",
                TennantId = TenantIds.AppleId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Store",
                Controller = "Store",
                Name = "Store",
                TennantId = TenantIds.MicrosoftId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = TenantIds.MicrosoftId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "UserView",
                Area = "Admin",
                Controller = "User",
                Name = "User",
                TennantId = TenantIds.MicrosoftId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = TenantIds.MicrosoftId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Survey",
                Area = "Survey",
                Controller = "Survey",
                Name = "Survey",
                TennantId = TenantIds.MicrosoftId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Report",
                Name = "Report",
                TennantId = TenantIds.MicrosoftId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Store",
                Controller = "Store",
                Name = "Store",
                TennantId = TenantIds.BestBuyId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Retailer",
                Name = "Retailer",
                TennantId = TenantIds.BestBuyId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Image",
                Name = "Image",
                TennantId = TenantIds.BestBuyId,
                Type = LinkTypes.Menu
            });
            _links.Add(new Link
            {
                Action = "Index",
                Controller = "Report",
                Name = "Report",
                TennantId = TenantIds.BestBuyId,
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
