using System;
using BootstrapMvc.Core;
using Microsoft.AspNet.Routing;

namespace BootstrapMvc
{
    public static class Mvc6LinkExtensions
    {
        public static IWriter<T> Href<T>(this IWriter<T> target, RouteValueDictionary routeValues)
            where T : Element, ILink
        {
            var href = target.Context.CreateUrl(routeValues);
            target.Href(href);
            return target;
        }

        public static IWriter2<T, TContent> Href<T, TContent>(this IWriter2<T, TContent> target, RouteValueDictionary routeValues) 
            where T : ContentElement<TContent>, ILink
            where TContent : DisposableContent
        {
            var href = target.Context.CreateUrl(routeValues);
            target.Href(href);
            return target;
        }

        public static IWriter<T> Href<T>(this IWriter<T> target, string actionName, string controllerName) 
            where T : Element, ILink
        {
            var dic = new RouteValueDictionary();
            if (!string.IsNullOrEmpty(actionName))
            {
                dic.Add("action", actionName);
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                dic.Add("controller", controllerName);
            }
            return Href(target, dic);
        }

        public static IWriter2<T, TContent> Href<T, TContent>(this IWriter2<T, TContent> target, string actionName, string controllerName)
            where T : ContentElement<TContent>, ILink
            where TContent : DisposableContent
        {
            var dic = new RouteValueDictionary();
            if (!string.IsNullOrEmpty(actionName))
            {
                dic.Add("action", actionName);
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                dic.Add("controller", controllerName);
            }
            return Href(target, dic);
        }

        public static IWriter<T> Href<T>(this IWriter<T> target, string actionName, string controllerName, object routeValues) 
            where T : Element, ILink
        {
            var dic = new RouteValueDictionary(routeValues);
            if (!string.IsNullOrEmpty(actionName))
            {
                dic.Add("action", actionName);
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                dic.Add("controller", controllerName);
            }
            return Href(target, dic);
        }

        public static IWriter2<T, TContent> Href<T, TContent>(this IWriter2<T, TContent> target, string actionName, string controllerName, object routeValues)
            where T : ContentElement<TContent>, ILink
            where TContent : DisposableContent
        {
            var dic = new RouteValueDictionary(routeValues);
            if (!string.IsNullOrEmpty(actionName))
            {
                dic.Add("action", actionName);
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                dic.Add("controller", controllerName);
            }
            return Href(target, dic);
        }
    }
}
