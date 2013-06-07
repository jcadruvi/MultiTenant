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
    public static class MenuHtmlHelper
    {
        public static MvcHtmlString SiteMenu(this HtmlHelper helper, string host)
        {
            ILinkService linkService = new LinkService();
            ITenantService tenantService = new TenantService();
            Tenant currentTenant = tenantService.GetCurrentTenant(host);
            if (currentTenant == null)
            {
                return null;
            }

            TagBuilder itemTag;
            IList<Link> menuItems = linkService.GetLinks(currentTenant.Id, LinkTypes.Menu);
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