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
    public class StoreApiController : ApiController
    {
        private IStoreService _storeService;
        public StoreApiController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _storeService.DeleteStore(id);
        } 
        public Store Get(int id)
        {
            return _storeService.Get(id);
        }
        public IEnumerable<Store> GetStores()
        {
            return _storeService.GetStores();
        }
    }
}
