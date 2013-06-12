using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class TraitApiController : BaseApiController
    {
        private ITraitService _traitService;
        public TraitApiController(ITraitService traitService)
        {
            _traitService = traitService;
        }
        public IEnumerable<Trait> GetAddTraits()
        {
            return _traitService.GetAddTraits();
        }
        public IEnumerable<Trait> GetViewTraits()
        {
            return _traitService.GetViewTraits();
        }
    }
}
