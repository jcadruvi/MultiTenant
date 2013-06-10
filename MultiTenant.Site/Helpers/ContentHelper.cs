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
    public static class ContentHelper
    {
        public static string CoreContent(this UrlHelper helper, string relativePath)
        {
            return helper.Content("~/Core/" + relativePath);
        }
        public static string CustomContent(this UrlHelper helper, string relativePath, Tenant currentTenant)
        {
            return helper.Content("~/Custom/" + currentTenant.Id + "/" + relativePath);
        }
        public static string CoreOrCustomContent(this UrlHelper helper, string relativePath, Tenant currentTenant)
        {
            IPathService pathService = DependencyResolver.Current.GetService(typeof(IPathService)) as IPathService;
            string redirectPath = null;
            if (pathService != null)
            {
                redirectPath = pathService.GetRedirectPath(currentTenant.Id, relativePath);
            }
            if (redirectPath == null)
            {
                return helper.Content("~/Core/" + relativePath); 
            }
            return helper.Content("~/Custom/" + currentTenant.Id + "/" + relativePath);
        }
    }
}