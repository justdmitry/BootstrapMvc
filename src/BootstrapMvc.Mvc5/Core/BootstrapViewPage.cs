using System;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public abstract class BootstrapViewPage : WebViewPage
    {
        public static Func<int, string> BootstrapMessageSource { get; set; }

        public BootstrapHelper Bootstrap { get; protected set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            this.Bootstrap = new BootstrapHelper(new BootstrapContext(this.ViewContext, Url, ViewData, BootstrapMessageSource));
        }

        public void Write(WritableBlock block)
        {
            block.WriteTo(this.ViewContext.Writer, Bootstrap.Context);
        }
    }
}
