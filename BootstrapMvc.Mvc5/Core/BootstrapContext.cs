using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Routing;
using mvc = System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class BootstrapContext : IBootstrapContext
    {
        private Dictionary<string, Stack<object>> cachedData = null;

        public BootstrapContext(mvc.ViewContext viewContext, mvc.UrlHelper urlHelper, mvc.ViewDataDictionary viewData)
        {
            this.ViewContext = viewContext;
            this.Url = urlHelper;
            this.ViewData = viewData;
        }

        private mvc.ViewContext ViewContext { get; set; }

        public TextWriter Writer 
        {
            get
            {
                return ViewContext.Writer;
            }  
        }

        protected mvc.UrlHelper Url { get; set; }

        protected mvc.ViewDataDictionary ViewData { get; set; }

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
            Writer.Write(HtmlEncode(value.ToString()));
        }

        public void PushValue(string key, object value)
        {
            if (cachedData == null)
            {
                cachedData = new Dictionary<string, Stack<object>>();
            }
            if (!cachedData.ContainsKey(key))
            {
                cachedData.Add(key, new Stack<object>());
            }
            cachedData[key].Push(value);
        }

        public object PopValue(string key)
        {
            if (cachedData == null)
            {
                throw new InvalidOperationException("Nothing to pop. Call PushValue first");
            }
            Stack<object> stack = null;
            if (!cachedData.TryGetValue(key, out stack))
            {
                throw new InvalidOperationException("Nothing to pop. Call PushValue first");
            }
            return stack.Pop();
        }

        public T PeekValue<T>(string key) where T : class
        {
            if (cachedData == null)
            {
                throw new InvalidOperationException("Nothing to pop. Call PushValue first");
            }
            Stack<object> stack = null;
            if (!cachedData.TryGetValue(key, out stack))
            {
                throw new InvalidOperationException("Nothing to pop. Call PushValue first");
            }
            return (T)stack.Peek();
        }

        public bool TryPeekValue<T>(string key, out T value) where T : class
        {
            value = null;
            if (cachedData == null)
            {
                return false;
            }
            Stack<object> stack = null;
            if (!cachedData.TryGetValue(key, out stack))
            {
                return false;
            }
            value = stack.Peek() as T;
            return value != null;
        }
    }
}
