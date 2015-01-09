using System;
using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
    {
        public static Icon Icon(this IAnyContentMarker contentHelper, IconType type)
        {
            return new Icon(contentHelper.Context).Type(type);
        }

        public static Icon Icon(this IAnyContentMarker contentHelper, IconType type, string tooltip)
        {
            return new Icon(contentHelper.Context).Type(type).HtmlTooltip(tooltip);
        }
    }
}
