using System;
using BootstrapMvc.Core;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.WebEncoders;

namespace BootstrapMvc.Mvc6
{
    public class BootstrapHelper: IAnyContentMarker, ICanHasViewContext
    {
        private IBootstrapContext bootstrapContext;

        public BootstrapHelper(IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
        {
            this.UrlHelper = urlHelper;
            this.HtmlEncoder = htmlEncoder;
        }

        public ViewContext ViewContext { get; private set; }

        protected IUrlHelper UrlHelper { get; set; }

        protected IHtmlEncoder HtmlEncoder { get; set; }

        public IBootstrapContext Context {
            get
            {
                if (bootstrapContext == null)
                {
                    bootstrapContext = new BootstrapContext(ViewContext, UrlHelper, HtmlEncoder);
                }
                return bootstrapContext;
            }
        }

        public void Contextualize(ViewContext viewContext)
        {
            ViewContext = viewContext;
        }
    }
}
