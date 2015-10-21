namespace BootstrapMvc.Mvc5
{
    using System;
    using System.Web.Mvc;
    using BootstrapMvc.Core;

    public abstract class BootstrapViewPage : WebViewPage
    {
        public static Func<int, string> BootstrapMessageSource { get; set; }

        public BootstrapHelper Bootstrap { get; protected set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            this.Bootstrap = new BootstrapHelper(this.ViewContext, Url, BootstrapMessageSource);
        }
    }
}
