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
    public class TraitService : ITraitService
    {
        private ITraitRepository _traitRepository;
        public TraitService()
        {
            _traitRepository = TraitRepository.Instance;
        }
        public IEnumerable<Trait> GetAddTraits()
        {
            return _traitRepository.GetAddTraits();
        }
        public IEnumerable<Trait> GetViewTraits()
        {
            return _traitRepository.GetViewTraits();
        }
    }
}
