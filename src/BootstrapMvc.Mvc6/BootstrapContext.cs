using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.WebEncoders;
using BootstrapMvc.Core;

namespace BootstrapMvc.Mvc6
{
    public class BootstrapContext : IBootstrapContext
    {
        public static readonly string WarningSpecialField = "BootstrapContext_WarningField";

        private static readonly string CachedDataContextKey = "BootstrapMvc.Mvc6.BootstrapContext.CachedData";

        private Stack<object> cachedData;

        public BootstrapContext(ViewContext viewContext, IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
        {
            this.ViewContext = viewContext;
            this.UrlHelper = urlHelper;
            this.HtmlEncoder = htmlEncoder;

            var httpContext = viewContext.HttpContext;
            if (httpContext.Items.ContainsKey(CachedDataContextKey))
            {
                cachedData = (Stack<object>)httpContext.Items[CachedDataContextKey];
            }
            else
            {
                cachedData = new Stack<object>(5);
                httpContext.Items[CachedDataContextKey] = cachedData;
            }
        }

        public TextWriter Writer
        {
            get
            {
                return ViewContext.Writer;
            }
        }

        public Func<int, string> MessageSource { get; set; }

        public IUrlHelper UrlHelper { get; set; }

        public ViewContext ViewContext { get; set; }

        public IHtmlEncoder HtmlEncoder { get; set; }

        public IWriter<T> CreateWriter<T>() where T : IWritable, new()
        {
            T item = new T();
            return new Writer<T>() { Item = item, Context = this };
        }

        public ITagBuilder CreateTagBuilder(string tagName)
        {
            return new TagBuilder(tagName, HtmlEncoder);
        }

        public string CreateUrl(IDictionary<string, object> routeValues)
        {
            return CreateUrl(routeValues, null, null);
        }

        public string CreateUrl(IDictionary<string, object> routeValues, string protocol, string hostName)
        {
            var routeVals = routeValues as RouteValueDictionary;
            if (routeVals == null)
            {
                routeVals = new RouteValueDictionary(routeValues);
            }
            return UrlHelper.Action(null, null, routeVals, protocol, hostName, null);
        }

        public string HtmlEncode(string value)
        {
            return HtmlEncoder.HtmlEncode(value);
        }

        public void Write(object value)
        {
            var html = value as IHtmlContent;
            if (html != null)
            {
                html.WriteTo(Writer, HtmlEncoder);
                return;
            }
            RazorPage.WriteTo(Writer, HtmlEncoder, value, false);
        }

        public string GetMessage(int id)
        {
            return (MessageSource == null) ? null : MessageSource(id);
        }


        public void Push(object value)
        {
            cachedData.Push(value);
        }

        public T PeekNearest<T>() where T : class
        {
            T res;
            foreach(var item in cachedData)
            {
                res = item as T;
                if (res != null)
                {
                    return res;
                }
            }
            return null;
        }

        public void PopIfEqual(object value)
        {
            var cached = cachedData.Peek();
            if (object.ReferenceEquals(value, cached))
            {
                cachedData.Pop();
            }
            else
            {
                throw new ArgumentException("Value not equal to pop'ed one.");
            }
        }
    }
}
