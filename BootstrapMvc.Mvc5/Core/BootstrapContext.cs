using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
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
            return Url.RouteUrl(null, new RouteValueDictionary(routeValues), protocol, hostName);
        }

        public string HtmlEncode(string value)
        {
            return HttpUtility.HtmlEncode(value);
        }

        public void Write(object value)
        {
            var html = value as IHtmlString;
            if (html != null)
            {
                Writer.Write(html.ToHtmlString());
                return;
            }
            var helperResult = value as HelperResult;
            if (helperResult != null)
            {
                WebPageExecutingBase.WriteTo(Writer, helperResult);
                return;
            }
            WebPageExecutingBase.WriteTo(Writer, value);
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
