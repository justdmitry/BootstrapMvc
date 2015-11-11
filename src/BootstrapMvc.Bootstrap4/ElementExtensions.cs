namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ElementExtensions
    {

        //public static IItemWriter<T> HtmlTooltip<T>(this IItemWriter<T> target, string value) where T : Element
        //{
        //    target.Item.AddAttribute("title", value);
        //    return target;
        //}

        //public static IItemWriter<T, TContent> HtmlTooltip<T, TContent>(this IItemWriter<T, TContent> target, string value)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddAttribute("title", value);
        //    return target;
        //}

        //public static IItemWriter<T> DoNotPrint<T>(this IItemWriter<T> target) where T : Element
        //{
        //    target.Item.AddCssClass("hidden-print");
        //    return target;
        //}

        //public static IItemWriter<T, TContent> DoNotPrint<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("hidden-print");
        //    return target;
        //}

        //public static IItemWriter<T> PullLeft<T>(this IItemWriter<T> target) where T : Element
        //{
        //    target.Item.AddCssClass("pull-left");
        //    return target;
        //}

        //public static IItemWriter<T, TContent> PullLeft<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("pull-left");
        //    return target;
        //}

        //public static IItemWriter<T> PullRight<T>(this IItemWriter<T> target) where T : Element
        //{
        //    target.Item.AddCssClass("pull-right");
        //    return target;
        //}

        //public static IItemWriter<T, TContent> PullRight<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("pull-right");
        //    return target;
        //}

        //public static IItemWriter<T> CenterBlock<T>(this IItemWriter<T> target) where T : Element
        //{
        //    target.Item.AddCssClass("center-block");
        //    return target;
        //}

        //public static IItemWriter<T, TContent> CenterBlock<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("center-block");
        //    return target;
        //}

        //public static IItemWriter<T> Clearfix<T>(this IItemWriter<T> target) where T : Element
        //{
        //    target.Item.AddCssClass("clearfix");
        //    return target;
        //}

        //public static IItemWriter<T, TContent> Clearfix<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("clearfix");
        //    return target;
        //}

        //public static IItemWriter<T> Visible<T>(this IItemWriter<T> target, Visibility value) where T : Element
        //{
        //    target.Item.AddCssClass(value.ToCssClass());
        //    return target;
        //}

        //public static IItemWriter<T, TContent> Visible<T, TContent>(this IItemWriter<T, TContent> target, Visibility value)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass(value.ToCssClass());
        //    return target;
        //}

        //public static IItemWriter<T> ForScreenReaders<T>(this IItemWriter<T> target, bool focusable = false) where T : Element
        //{
        //    target.Item.AddCssClass("sr-only");
        //    if (focusable)
        //    {
        //        target.Item.AddCssClass("sr-only-focusable");
        //    }
        //    return target;
        //}

        //public static IItemWriter<T, TContent> ForScreenReaders<T, TContent>(this IItemWriter<T, TContent> target, bool focusable = false)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("sr-only");
        //    if (focusable)
        //    {
        //        target.Item.AddCssClass("sr-only-focusable");
        //    }
        //    return target;
        //}

        //public static IItemWriter<T> HiddenText<T>(this IItemWriter<T> target) where T : Element
        //{
        //    target.Item.AddCssClass("text-hide");
        //    return target;
        //}

        //public static IItemWriter<T, TContent> HiddenText<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass("text-hide");
        //    return target;
        //}

        //public static IItemWriter<T> TextColor<T>(this IItemWriter<T> target, TextColor color) where T : Element
        //{
        //    target.Item.AddCssClass(color.ToCssClass());
        //    return target;
        //}

        //public static IItemWriter<T, TContent> TextColor<T, TContent>(this IItemWriter<T, TContent> target, TextColor color)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass(color.ToCssClass());
        //    return target;
        //}

        //public static IItemWriter<T> Muted<T>(this IItemWriter<T> target) where T : Element
        //{
        //    return target.TextColor(BootstrapMvc.TextColor.MutedGray);
        //}

        //public static IItemWriter<T, TContent> Muted<T, TContent>(this IItemWriter<T, TContent> target)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    return target.TextColor(BootstrapMvc.TextColor.MutedGray);
        //}

        //public static IItemWriter<T> BackgroundColor<T>(this IItemWriter<T> target, BaseColor color) where T : Element
        //{
        //    target.Item.AddCssClass(color.ToBackgroundCssClass());
        //    return target;
        //}

        //public static IItemWriter<T, TContent> BackgroundColor<T, TContent>(this IItemWriter<T, TContent> target, BaseColor color)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddCssClass(color.ToBackgroundCssClass());
        //    return target;
        //}

        //public static IItemWriter<T> Id<T>(this IItemWriter<T> target, string id) where T : Element
        //{
        //    target.Item.AddAttribute("id", id);
        //    return target;
        //}

        //public static IItemWriter<T, TContent> Id<T, TContent>(this IItemWriter<T, TContent> target, string id)
        //    where T : ContentElement<TContent>
        //    where TContent : DisposableContent
        //{
        //    target.Item.AddAttribute("id", id);
        //    return target;
        //}
    }
}
