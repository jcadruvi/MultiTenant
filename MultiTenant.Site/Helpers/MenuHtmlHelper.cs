using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Helpers
{
    public static class MenuHtmlHelper
    {
        public static MvcHtmlString SiteMenu(this HtmlHelper helper)
        {
            TagBuilder menu = new TagBuilder("ul");
            TagBuilder list;
            menu.MergeAttribute("id", "menu");
            list = new TagBuilder("li");
            list.InnerHtml += "Page 1";
            menu.InnerHtml += list;
            list = new TagBuilder("li");
            list.InnerHtml += "Page 2";
            menu.InnerHtml += list;
            list = new TagBuilder("li");
            list.InnerHtml += "Page 3";
            menu.InnerHtml += list;
            return MvcHtmlString.Create(menu.ToString());
        }
    }
}