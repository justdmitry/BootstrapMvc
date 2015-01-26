using System;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public abstract class BootstrapViewPage<TModel> : WebViewPage<TModel>, IBootstrapMvcViewPage<TModel>
    {
        public BootstrapHelper<TModel> Bootstrap { get; protected set; }

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
            this.Bootstrap = new BootstrapHelper<TModel>(new BootstrapContext<TModel>(this.ViewContext, Url, ViewData));
        }

        public void Write(WritableBlock block)
        {
            if (block != null)
            {
                block.WriteTo(this.ViewContext.Writer);
            }
        }
    }
}
