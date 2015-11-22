namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class UtilityClassesExtensions
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

        public static IItemWriter<T> Clearfix<T>(this IItemWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }

        public static IItemWriter<T, TContent> Clearfix<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }

        public static IItemWriter<T> HiddenText<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }

        public static IItemWriter<T, TContent> HiddenText<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }

        #region Responsive embed

        public static IItemWriter<T> EmbedResponsive<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("embed-responsive");
            return target;
        }

        public static IItemWriter<T, TContent> EmbedResponsive<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("embed-responsive");
            return target;
        }

        public static IItemWriter<T> EmbedResponsiveItem<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("embed-responsive-item");
            return target;
        }

        public static IItemWriter<T, TContent> EmbedResponsiveItem<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("embed-responsive-item");
            return target;
        }

        public static IItemWriter<T> EmbedResponsive16x9<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("embed-responsive embed-responsive-16by9");
            return target;
        }

        public static IItemWriter<T, TContent> EmbedResponsive16x9<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("embed-responsive embed-responsive-16by9");
            return target;
        }

        public static IItemWriter<T> EmbedResponsive4x3<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("embed-responsive embed-responsive-4by3");
            return target;
        }

        public static IItemWriter<T, TContent> EmbedResponsive4x3<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("embed-responsive embed-responsive-4by3");
            return target;
        }

        #endregion

        public static IItemWriter<T> TextAlignment<T>(this IItemWriter<T> target, TextAlignment value)
            where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> TextAlignment<T, TContent>(this IItemWriter<T, TContent> target, TextAlignment value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T> TextTransform<T>(this IItemWriter<T> target, TextTransformation value)
            where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> TextTransform<T, TContent>(this IItemWriter<T, TContent> target, TextTransformation value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
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
    }
}
