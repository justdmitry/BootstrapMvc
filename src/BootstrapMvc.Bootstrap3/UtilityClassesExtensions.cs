namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class UtilityClassesExtensions
    {
        public static IItemWriter<T> Hidden<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("hidden");
            return target;
        }

        public static IItemWriter<T, TContent> Hidden<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("hidden");
            return target;
        }

        public static IItemWriter<T> BackgroundColor<T>(this IItemWriter<T> target, BaseColor color) where T : Element
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> BackgroundColor<T, TContent>(this IItemWriter<T, TContent> target, BaseColor color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }
    }
}
