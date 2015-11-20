namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class PrintExtensions
    {
        public static IItemWriter<T> DoNotPrint<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("hidden-print");
            return target;
        }

        public static IItemWriter<T, TContent> DoNotPrint<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("hidden-print");
            return target;
        }
    }
}
