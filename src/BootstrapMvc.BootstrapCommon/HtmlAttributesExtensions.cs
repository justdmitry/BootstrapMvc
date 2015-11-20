namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class HtmlAttributesExtensions
    {
        public static IItemWriter<T> Id<T>(this IItemWriter<T> target, string id) 
            where T : Element
        {
            target.Item.AddAttribute("id", id);
            return target;
        }

        public static IItemWriter<T, TContent> Id<T, TContent>(this IItemWriter<T, TContent> target, string id)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute("id", id);
            return target;
        }

        public static IItemWriter<T> Tooltip<T>(this IItemWriter<T> target, string value) 
            where T : Element
        {
            target.Item.AddAttribute("title", value);
            return target;
        }

        public static IItemWriter<T, TContent> Tooltip<T, TContent>(this IItemWriter<T, TContent> target, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute("title", value);
            return target;
        }

        [Obsolete("Use Tooltip()")]
        public static IItemWriter<T> HtmlTooltip<T>(this IItemWriter<T> target, string value)
            where T : Element
        {
            return Tooltip(target, value);
        }

        [Obsolete("Use Tooltip()")]
        public static IItemWriter<T, TContent> HtmlTooltip<T, TContent>(this IItemWriter<T, TContent> target, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return Tooltip(target, value);
        }
    }
}
