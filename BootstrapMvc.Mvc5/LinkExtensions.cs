using System;
using System.Web.Routing;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class LinkExtensions
    {
        public static T Href<T>(this T target, RouteValueDictionary routeValues) where T : Element, ILink
        {
            var href = target.Context.CreateUrl(routeValues);
            target.SetHref(href);
            return target;
        }

        public static T Href<T>(this T target, string actionName, string controllerName) where T : Element, ILink
        {
            var dic = new RouteValueDictionary();
            dic.Add("action", actionName);
            dic.Add("controller", controllerName);
            return Href(target, dic);
        }

        public static T Href<T>(this T target, string actionName, string controllerName, object routeValues) where T : Element, ILink
        {
            var dic = new RouteValueDictionary(routeValues);
            dic.Add("action", actionName);
            dic.Add("controller", controllerName);
            return Href(target, dic);
        }
    }
}
