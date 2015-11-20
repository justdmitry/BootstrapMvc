namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ScreenReaderExtensions
    {
        public static IItemWriter<T> ForScreenReaders<T>(this IItemWriter<T> target, bool focusable = false) where T : Element
        {
            target.Item.AddCssClass("sr-only");
            if (focusable)
            {
                target.Item.AddCssClass("sr-only-focusable");
            }
            return target;
        }

        public static IItemWriter<T, TContent> ForScreenReaders<T, TContent>(this IItemWriter<T, TContent> target, bool focusable = false)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("sr-only");
            if (focusable)
            {
                target.Item.AddCssClass("sr-only-focusable");
            }
            return target;
        }
    }
}
