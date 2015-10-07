using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using mvc = System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class BootstrapContext : IBootstrapContext
    {
        public static readonly string WarningSpecialField = "BootstrapContext_WarningField";

        private static readonly string CachedDataContextKey = "BootstrapMvc.Mvc5.BootstrapContext.CachedData";

        private Stack cachedData;

        public BootstrapContext(mvc.ViewContext viewContext, mvc.UrlHelper urlHelper, mvc.ViewDataDictionary viewData, Func<int, string> messageSource)
        {
            this.ViewContext = viewContext;
            this.Url = urlHelper;
            this.ViewData = viewData;
            this.MessageSource = messageSource;

            var httpContext = viewContext.RequestContext.HttpContext;
            if (httpContext.Items.Contains(CachedDataContextKey))
            {
                cachedData = (Stack)httpContext.Items[CachedDataContextKey];
            }
            else
            {
                cachedData = new Stack(5);
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

        protected Func<int, string> MessageSource { get; set; }

        protected mvc.UrlHelper Url { get; set; }

        protected mvc.ViewDataDictionary ViewData { get; set; }

        private mvc.ViewContext ViewContext { get; set; }

        public ITagBuilder CreateTagBuilder(string tagName)
        {
            return new TagBuilder(tagName);
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
            return UrlHelper.GenerateUrl(null, null, null, protocol, hostName, null, routeVals, Url.RouteCollection, Url.RequestContext, true);
        }

        public IWriter<T> CreateWriter<T>() where T : IWritable, new()
        {
            T item = new T();
            return new Writer<T>() { Item = item, Context = this };
        }

        public IWriter2<T, TContent> CreateWriter<T, TContent>()
            where T : ContentElement<TContent>, new()
            where TContent : DisposableContent
        {
            T item = new T();
            return new WriterEx<T, TContent>() { Item = item, Context = this };
        }

        public string HtmlEncode(string value)
        {
            return HttpUtility.HtmlEncode(value);
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
