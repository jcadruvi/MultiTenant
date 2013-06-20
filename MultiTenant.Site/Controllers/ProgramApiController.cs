using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class ProgramApiController : BaseApiController
    {
        private IProgramService _programService;
        public ProgramApiController(IProgramService programService, ITenantService tenantService) : base(tenantService)
        {
            _programService = programService;
        }
        public IEnumerable<KeyValuePair<int, string>> GetProgramItems()
        {
            return _programService.GetProgramItems();
        }
    }
}
