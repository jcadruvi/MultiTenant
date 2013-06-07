using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;
using MultiTenant.Repository.Interfaces;
using MultiTenant.Repository.Repositories;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Service.Services
{
    public class LinkService : ILinkService
    {
        private ILinkRepository _repository;
        public LinkService()
        {
            _repository = LinkRepository.Instance;
        }
        public Link GetLink(int tenantId, string linkType)
        {
            return _repository.GetLink(tenantId, linkType);
        }
        public IList<Link> GetLinks(int tenantId, string linkType)
        {
            return _repository.GetLinks(tenantId, linkType);
        }
    }
}
