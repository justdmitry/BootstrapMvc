namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class UtilityClassesExtensions
    {
        public static IItemWriter<T> Invisible<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("invisible");
            return target;
        }

        public static IItemWriter<T, TContent> Invisible<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("invisible");
            return target;
        }

        [Obsolete("Use Invisible instead")]
        public static IItemWriter<T> Hidden<T>(this IItemWriter<T> target) where T : Element
        {
            return Invisible(target);
        }

        [Obsolete("Use Invisible instead")]
        public static IItemWriter<T, TContent> Hidden<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return Invisible(target);
        }

        public static IItemWriter<T> EmbedResponsive21x9<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("embed-responsive embed-responsive-21by9");
            return target;
        }

        public static IItemWriter<T, TContent> EmbedResponsive21x9<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("embed-responsive embed-responsive-21by9");
            return target;
        }

        public static IItemWriter<T> BackgroundColor<T>(this IItemWriter<T> target, BackgroundColor color) where T : Element
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> BackgroundColor<T, TContent>(this IItemWriter<T, TContent> target, BackgroundColor color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }
    }
}
