using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class MarkersExtensions
    {
        public static T Placeholder<T>(this T target, string placeholder) where T : Element, IPlaceholderTarget
        {
            target.Attribute("placeholder", placeholder);
            return target;
        }
    }
}
