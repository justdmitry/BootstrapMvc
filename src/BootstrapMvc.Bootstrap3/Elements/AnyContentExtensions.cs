using System;
using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        public static Icon Icon(this IAnyContentMarker contentHelper, IconType type)
        {
            return new Icon(contentHelper.Context).Type(type);
        }
    }
}
