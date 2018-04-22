namespace BootstrapMvc
{
    using BootstrapMvc.Core;
    using Microsoft.AspNetCore.Html;

    public static class HtmlStringExtensions
    {
        private static readonly HtmlString br = new HtmlString("<br/>");

        public static HtmlString Br(this IAnyContentMarker contentHelper)
        {
            return br;
        }
    }
}
