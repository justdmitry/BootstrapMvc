using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public abstract class BootstrapViewPage : WebViewPage
    {
        public BootstrapHelper Bootstrap { get; protected set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            this.Bootstrap = new BootstrapHelper(new BootstrapContext(this.ViewContext, Url, ViewData));
        }

        public void Write(WritableBlock block)
        {
            block.WriteTo(this.ViewContext.Writer);
        }
    }
}
