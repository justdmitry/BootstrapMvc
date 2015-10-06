using System;
using BootstrapMvc.Core;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.WebEncoders;

namespace BootstrapMvc.Mvc6
{
    public class BootstrapHelper: IAnyContentMarker, ICanHasViewContext
    {
        protected IBootstrapContext bootstrapContext;

        public BootstrapHelper(IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
        {
            this.UrlHelper = urlHelper;
            this.HtmlEncoder = htmlEncoder;
        }

        protected ViewContext ViewContext { get; set; }

        protected IUrlHelper UrlHelper { get; set; }

        protected IHtmlEncoder HtmlEncoder { get; set; }

        public virtual IBootstrapContext Context {
            get
            {
                if (bootstrapContext == null)
                {
                    bootstrapContext = CreateBootstrapContext();
                }
                return bootstrapContext;
            }
        }

        public virtual void Contextualize(ViewContext viewContext)
        {
            ViewContext = viewContext;
        }

        protected virtual IBootstrapContext CreateBootstrapContext()
        {
            return new BootstrapContext(ViewContext, UrlHelper, HtmlEncoder);
        }
    }
}
