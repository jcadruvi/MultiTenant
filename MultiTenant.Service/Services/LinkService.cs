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
        private readonly ILinkRepository _repository;
        public LinkService()
        {
            _repository = LinkRepository.Instance;
        }
        public Link GetLink(string id, string linkType)
        {
            return _repository.GetLink(id, linkType);
        }
        public IList<Link> GetLinks(string id, string linkType)
        {
            return _repository.GetLinks(id, linkType);
        }
        public IList<Link> GetMenuLinks(string id)
        {
            return _repository.GetMenuLinks(id);
        }
    }
}
