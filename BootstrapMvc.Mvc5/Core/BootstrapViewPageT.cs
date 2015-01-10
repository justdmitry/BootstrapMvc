using System;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public abstract class BootstrapViewPage<TModel> : WebViewPage<TModel>, IBootstrapMvcViewPage<TModel>
    {
        public BootstrapHelper<TModel> Bootstrap { get; protected set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            this.Bootstrap = new BootstrapHelper<TModel>(new BootstrapContext<TModel>(this.ViewContext, Url, ViewData));
        }

        public void Write(WritableBlock block)
        {
            block.WriteTo(this.ViewContext.Writer);
        }
    }
}
