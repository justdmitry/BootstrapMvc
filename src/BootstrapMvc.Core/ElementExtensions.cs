namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ElementExtensions
    {
        public static IItemWriter<T> CssClass<T>(this IItemWriter<T> target, string value)
            where T : Element
        {
            target.Item.AddCssClass(value);
            return target;
        }

        public static IItemWriter<T, TContent> CssClass<T, TContent>(this IItemWriter<T, TContent> target, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value);
            return target;
        }

        public static IItemWriter<T> Attribute<T>(this IItemWriter<T> target, string name, string value)
            where T : Element
        {
            target.Item.AddAttribute(name, value);
            return target;
        }

        public static IItemWriter<T, TContent> Attribute<T, TContent>(this IItemWriter<T, TContent> target, string name, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute(name, value);
            return target;
        }
    }
}
