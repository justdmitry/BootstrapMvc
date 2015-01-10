using System;
using System.Web.Routing;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ILinkExtensions
    {
        public static T Href<T>(this T target, RouteValueDictionary routeValues) where T : Element, ILink<T>
        {
            var href = target.Context.CreateUrl(routeValues);
            target.Href(href);
            return target;
        }
    }
}
