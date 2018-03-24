namespace BootstrapMvc
{
    using System;
    using System.Web.Routing;
    using BootstrapMvc.Core;

    public static class Mvc5LinkExtensions
    {
        public static IItemWriter<T> Href<T>(this IItemWriter<T> target, RouteValueDictionary routeValues)
            where T : Element, ILink
        {
            var href = target.Helper.CreateUrl(routeValues);
            target.Href(href);
            return target;
        }

        public static IItemWriter<T, TContent> Href<T, TContent>(this IItemWriter<T, TContent> target, RouteValueDictionary routeValues)
            where T : ContentElement<TContent>, ILink
            where TContent : DisposableContent
        {
            var href = target.Helper.CreateUrl(routeValues);
            target.Href(href);
            return target;
        }

        public static IItemWriter<T> Href<T>(this IItemWriter<T> target, string actionName, string controllerName)
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

        public static IItemWriter<T, TContent> Href<T, TContent>(this IItemWriter<T, TContent> target, string actionName, string controllerName)
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

        public static IItemWriter<T> Href<T>(this IItemWriter<T> target, string actionName, string controllerName, object routeValues)
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

        public static IItemWriter<T, TContent> Href<T, TContent>(this IItemWriter<T, TContent> target, string actionName, string controllerName, object routeValues)
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
