using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class RetailerApiController : BaseApiController
    {
        private IRetailerService _retailerService;
        public RetailerApiController(IRetailerService retailerService)
        {
            _retailerService = retailerService;
        }
        public IEnumerable<Retailer> GetRetailers()
        {
            return _retailerService.GetAll();
        }
    }
}