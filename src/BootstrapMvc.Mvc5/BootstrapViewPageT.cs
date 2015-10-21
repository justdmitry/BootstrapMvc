namespace BootstrapMvc.Mvc5
{
    using System;
    using System.Web.Mvc;
    using BootstrapMvc.Core;

    public abstract class BootstrapViewPage<TModel> : WebViewPage<TModel>
    {
        public BootstrapHelper<TModel> Bootstrap { get; protected set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            this.Bootstrap = new BootstrapHelper<TModel>(this.ViewContext, Url, ViewData, BootstrapViewPage.BootstrapMessageSource);
        }
    }
}
