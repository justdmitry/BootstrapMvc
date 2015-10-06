using System;
using BootstrapMvc.Core;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.WebEncoders;

namespace BootstrapMvc.Mvc6
{
    public class BootstrapHelper<TModel> : BootstrapHelper, IAnyContentMarker<TModel>
    {
        public BootstrapHelper(IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
            : base(urlHelper, htmlEncoder)
        {
            this.UrlHelper = urlHelper;
            this.HtmlEncoder = htmlEncoder;
        }

        public new IBootstrapContext<TModel> Context
        {
            get
            {
                if (bootstrapContext == null)
                {
                    bootstrapContext = CreateBootstrapContext();
                }
                return (IBootstrapContext<TModel>)bootstrapContext;
            }
        }

        protected ViewDataDictionary<TModel> ViewData { get; set; }

        public override void Contextualize(ViewContext viewContext)
        {
            this.ViewData = (ViewDataDictionary<TModel>)viewContext.ViewData;
            base.Contextualize(viewContext);
        }

        protected override IBootstrapContext CreateBootstrapContext()
        {
            return new BootstrapContext<TModel>(ViewContext, UrlHelper, HtmlEncoder, ViewData);
        }
    }
}
