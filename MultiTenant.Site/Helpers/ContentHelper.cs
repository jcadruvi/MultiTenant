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
        public static string CustomContent(this UrlHelper helper, string relativePath)
        {
            return helper.Content("~/Custom/" + relativePath);
        }
        public static string Script(this UrlHelper helper, string scriptName)
        {
            return helper.Content("~/Scripts/" + scriptName);
        }
        public static string Style(this UrlHelper helper, string styleName)
        {
            return helper.Content("~/Content/" + styleName);
        }
        public static string StyleBundle(this UrlHelper helper, Tenant currentTenant, string type, string defaultLocation)
        {
            IPathService pathService = DependencyResolver.Current.GetService<IPathService>();
            string location;
            if (currentTenant == null || pathService == null)
            {
                return defaultLocation;
            }
            location = pathService.GetContentLocation(currentTenant.Id.ToString(), type);
            if (location == null)
            {
                return defaultLocation;
            }
            return helper.Content(location);
        }
    }
}