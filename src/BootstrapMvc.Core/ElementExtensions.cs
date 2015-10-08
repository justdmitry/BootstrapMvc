using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static IWriter<T> CssClass<T>(this IWriter<T> target, string value)
            where T : Element
        {
            target.Item.AddCssClass(value);
            return target;
        }

        public static IWriter2<T, TContent> CssClass<T, TContent>(this IWriter2<T, TContent> target, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value);
            return target;
        }

        public static IWriter<T> Attribute<T>(this IWriter<T> target, string name, string value)
            where T : Element
        {
            target.Item.AddAttribute(name, value);
            return target;
        }

        public static IWriter2<T, TContent> Attribute<T, TContent>(this IWriter2<T, TContent> target, string name, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute(name, value);
            return target;
        }
    }
}
