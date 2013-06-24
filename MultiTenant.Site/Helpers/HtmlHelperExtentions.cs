using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MultiTenant.Common.Types;
using MultiTenant.Service.Interfaces;
using MultiTenant.Service.Services;
using MultiTenant.Model;

namespace MultiTenant.Helpers
{
    public static class HtmlHelperExtentions
    {
        public static MvcHtmlString PartialHelper(this HtmlHelper helper, Tenant currentTenant, string type, object model, string defaultLocation)
        {
            IPathService pathService = DependencyResolver.Current.GetService<IPathService>();
            string location = null;
            if (currentTenant != null && pathService != null)
            {
                location = pathService.GetContentLocation(currentTenant.Id.ToString(), type);
            }
            if (location == null)
            {
                location = defaultLocation;
            }
            return helper.Partial(location, model);
        }

        public static MvcHtmlString SiteMenu(this HtmlHelper helper, Tenant currentTenant)
        {
            ILinkService linkService = DependencyResolver.Current.GetService<ILinkService>(); 
            if (currentTenant == null || linkService == null)
            {
                return null;
            }

            TagBuilder itemTag;
            IList<Link> menuItems = linkService.GetMenuLinks(currentTenant.Id.ToString());
            TagBuilder menu = new TagBuilder("ul");
            
            menu.MergeAttribute("id", "menu");
            foreach (Link item in menuItems)
            {
                itemTag = new TagBuilder("li");
                if (String.IsNullOrWhiteSpace(item.Area))
                {
                    itemTag.InnerHtml = helper.ActionLink(item.Name, item.Action, new { area = "", controller = item.Controller }).ToString();
                }
                else
                {
                    itemTag.InnerHtml = helper.ActionLink(item.Name, item.Action, new { area = item.Area, controller = item.Controller }).ToString();
                }
                menu.InnerHtml += itemTag;
            }
            return MvcHtmlString.Create(menu.ToString());
        }
    }
}