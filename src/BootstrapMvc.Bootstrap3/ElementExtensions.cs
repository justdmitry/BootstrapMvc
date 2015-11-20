using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static IItemWriter<T> PullLeft<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("pull-left");
            return target;
        }

        public static IItemWriter<T, TContent> PullLeft<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("pull-left");
            return target;
        }

        public static IItemWriter<T> PullRight<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("pull-right");
            return target;
        }

        public static IItemWriter<T, TContent> PullRight<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("pull-right");
            return target;
        }

        public static IItemWriter<T> CenterBlock<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("center-block");
            return target;
        }

        public static IItemWriter<T, TContent> CenterBlock<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("center-block");
            return target;
        }
        
        public static IItemWriter<T> TextColor<T>(this IItemWriter<T> target, TextColor color) where T : Element
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> TextColor<T, TContent>(this IItemWriter<T, TContent> target, TextColor color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static IItemWriter<T> Muted<T>(this IItemWriter<T> target) where T : Element
        {
            return target.TextColor(BootstrapMvc.TextColor.MutedGray);
        }

        public static IItemWriter<T, TContent> Muted<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.TextColor(BootstrapMvc.TextColor.MutedGray);
        }

        public static IItemWriter<T> BackgroundColor<T>(this IItemWriter<T> target, BaseColor color) where T : Element
        {
            target.Item.AddCssClass(color.ToBackgroundCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> BackgroundColor<T, TContent>(this IItemWriter<T, TContent> target, BaseColor color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(color.ToBackgroundCssClass());
            return target;
        }
    }
}
