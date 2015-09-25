using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static T CssClass<T>(this T target, string value) where T : Element
        {
            target.AddCssClass(value);
            return target;
        }

        public static T Attribute<T>(this T target, string name, string value) where T : Element
        {
            target.AddAttribute(name, value);
            return target;
        }
    }
}
