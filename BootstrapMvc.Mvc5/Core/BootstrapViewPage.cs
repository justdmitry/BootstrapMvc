using System;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public abstract class BootstrapViewPage : WebViewPage, IBootstrapMvcViewPage
    {
        public BootstrapHelper Bootstrap { get; protected set; }

        public static void WriteTo(System.IO.TextWriter writer, WritableBlock block)
        {
            if (block != null)
            {
                block.WriteTo(writer);
            }
        }

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
