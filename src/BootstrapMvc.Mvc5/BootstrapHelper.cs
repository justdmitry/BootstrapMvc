namespace BootstrapMvc.Mvc5
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using mvc = System.Web.Mvc;
    using BootstrapMvc.Core;

    public class BootstrapHelper: IAnyContentMarker, IWritingHelper, IBootstrapContext
    {
        protected IBootstrapContext bootstrapContext;

        private Stack<IWritableItem> parents = new Stack<IWritableItem>(5);

        public BootstrapHelper(mvc.ViewContext viewContext, mvc.UrlHelper urlHelper, Func<int, string> messageSource)
        {
            this.ViewContext = viewContext;
            this.UrlHelper = urlHelper;
            parents.Push(null);
        }

        protected Func<int, string> MessageSource { get; set; }

        protected ViewContext ViewContext { get; set; }

        protected UrlHelper UrlHelper { get; set; }

        public System.IO.TextWriter GetCurrentWriter()
        {
            return ViewContext.Writer;
        }

        public virtual void Contextualize(ViewContext viewContext)
        {
            ViewContext = viewContext;
        }

        #region IAnyContentMarker

        IBootstrapContext IAnyContentMarker.Context
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IBootstrapContext

        IWritableItem IBootstrapContext.GetCurrentParent()
        {
            return parents.Peek();
        }

        void IBootstrapContext.PushParent(IWritableItem parent)
        {
            parents.Push(parent);
        }

        void IBootstrapContext.PopParent(IWritableItem parentToMatch)
        {
            var current = parents.Pop();
            if (!Object.ReferenceEquals(current, parentToMatch))
            {
                throw new Exception("Parents do not match");
            }
        }

        IWritingHelper IBootstrapContext.Helper
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IWritingHelper

        IItemWriter<T> IWritingHelper.CreateWriter<T>(IWritableItem parent)
        {
            var item = new T();
            item.Parent = parent;
            item.Helper = this;
            var writer = new ItemWriter<T>(item);
            return writer;
        }

        IItemWriter<T, TContent> IWritingHelper.CreateWriter<T, TContent>(IWritableItem parent)
        {
            var item = new T();
            item.Parent = parent;
            item.Helper = this;
            var writer = new ItemWriter<T, TContent>(item, this);
            return writer;
        }

        ITagBuilder IWritingHelper.CreateTagBuilder(string tagName)
        {
            return new TagBuilder(tagName);
        }

        string IWritingHelper.CreateUrl(IDictionary<string, object> routeValues)
        {
            return ((IWritingHelper)this).CreateUrl(routeValues, null, null);
        }

        string IWritingHelper.CreateUrl(IDictionary<string, object> routeValues, string protocol, string hostName)
        {
            var routeVals = routeValues as RouteValueDictionary;
            if (routeVals == null)
            {
                routeVals = new RouteValueDictionary(routeValues);
            }
            return UrlHelper.Action(null, null, routeVals, protocol, hostName);
        }

        string IWritingHelper.HtmlEncode(string value)
        {
            return HttpUtility.HtmlEncode(value);
        }

        void IWritingHelper.WriteValue(System.IO.TextWriter writer, object value)
        {
            if (value == null)
            {
                return;
            }
            var writable = value as IWritable;
            if (writable != null)
            {
                writable.WriteTo(writer);
                return;
            }
            var htmlString = value as IHtmlString;
            if (htmlString != null)
            {
                writer.Write(htmlString.ToHtmlString());
                return;
            }
            writer.Write(value);
        }

        #endregion
    }
}
