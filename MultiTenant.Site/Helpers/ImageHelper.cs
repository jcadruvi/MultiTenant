using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Model;
using MultiTenant.Service.Interfaces;
using MultiTenant.Service.Services;

namespace MultiTenant.Helpers
{
    public static class ImageHelper
    {
        public static string CoreContent(this UrlHelper helper, string relativePath)
        {
            return helper.Content("~/Core/" + relativePath);
        }
        public static string CustomContent(this UrlHelper helper, string relativePath, string host)
        {
            ITenantService tenantService = new TenantService();
            Tenant currentTenant = tenantService.GetCurrentTenant(host);
            if (currentTenant == null)
            {
                return null;
            }
            return helper.Content("~/Custom/" + currentTenant.Id + "/" + relativePath);
        }
        public static string CoreOrCustomContent(this UrlHelper helper, string relativePath, string host)
        {
            IPathService pathService = new PathService();
            ITenantService tenantService = new TenantService();
            Tenant currentTenant = tenantService.GetCurrentTenant(host);
            if (currentTenant == null)
            {
                return null;
            }
            string redirectPath = pathService.GetRedirectPath(currentTenant.Id, relativePath);
            if (redirectPath == null)
            {
                return helper.Content("~/Core/" + relativePath); 
            }
            return helper.Content("~/Custom/" + currentTenant.Id + "/" + relativePath);
        }
    }
}