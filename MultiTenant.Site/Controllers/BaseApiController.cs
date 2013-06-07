using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MultiTenant.Controllers
{
    public class BaseApiController : ApiController
    {
        public string Host { get; set; }
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            string[] host = controllerContext.Request.Headers.Host.Split(':');
            if (host.Length > 0)
            {
                Host = host[0];
            }
            base.Initialize(controllerContext);
        }
    }
}
