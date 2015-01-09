using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static T HtmlTooltip<T>(this T element, string value) where T : Element
        {
            element.MergeAttribute("title", value);
            return element;
        }
    }
}
