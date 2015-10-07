using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static IWriter<T> HtmlTooltip<T>(this IWriter<T> target, string value) where T : Element
        {
            target.Item.AddAttribute("title", value);
            return target;
        }

        public static IWriter2<T, TContent> HtmlTooltip<T, TContent>(this IWriter2<T, TContent> target, string value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute("title", value);
            return target;
        }

        public static IWriter<T> DoNotPrint<T>(this IWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("hidden-print");
            return target;
        }

        public static IWriter2<T, TContent> DoNotPrint<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("hidden-print");
            return target;
        }

        public static IWriter<T> PullLeft<T>(this IWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("pull-left");
            return target;
        }

        public static IWriter2<T, TContent> PullLeft<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("pull-left");
            return target;
        }

        public static IWriter<T> PullRight<T>(this IWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("pull-right");
            return target;
        }

        public static IWriter2<T, TContent> PullRight<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("pull-right");
            return target;
        }

        public static IWriter<T> CenterBlock<T>(this IWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("center-block");
            return target;
        }

        public static IWriter2<T, TContent> CenterBlock<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("center-block");
            return target;
        }

        public static IWriter<T> Clearfix<T>(this IWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }

        public static IWriter2<T, TContent> Clearfix<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }

        public static IWriter<T> Visible<T>(this IWriter<T> target, Visibility value) where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IWriter2<T, TContent> Visible<T, TContent>(this IWriter2<T, TContent> target, Visibility value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IWriter<T> ForScreenReaders<T>(this IWriter<T> target, bool focusable = false) where T : Element
        {
            target.Item.AddCssClass("sr-only");
            if (focusable)
            {
                target.Item.AddCssClass("sr-only-focusable");
            }
            return target;
        }

        public static IWriter2<T, TContent> ForScreenReaders<T, TContent>(this IWriter2<T, TContent> target, bool focusable = false)
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

        public static IWriter<T> HiddenText<T>(this IWriter<T> target) where T : Element
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }

        public static IWriter2<T, TContent> HiddenText<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }

        public static IWriter<T> TextColor<T>(this IWriter<T> target, TextColor color) where T : Element
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static IWriter2<T, TContent> TextColor<T, TContent>(this IWriter2<T, TContent> target, TextColor color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static IWriter<T> Muted<T>(this IWriter<T> target) where T : Element
        {
            return target.TextColor(BootstrapMvc.TextColor.MutedGray);
        }

        public static IWriter2<T, TContent> Muted<T, TContent>(this IWriter2<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.TextColor(BootstrapMvc.TextColor.MutedGray);
        }

        public static IWriter<T> BackgroundColor<T>(this IWriter<T> target, BaseColor color) where T : Element
        {
            target.Item.AddCssClass(color.ToBackgroundCssClass());
            return target;
        }

        public static IWriter2<T, TContent> BackgroundColor<T, TContent>(this IWriter2<T, TContent> target, BaseColor color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(color.ToBackgroundCssClass());
            return target;
        }

        public static IWriter<T> Id<T>(this IWriter<T> target, string id) where T : Element
        {
            target.Item.AddAttribute("id", id);
            return target;
        }

        public static IWriter2<T, TContent> Id<T, TContent>(this IWriter2<T, TContent> target, string id)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute("id", id);
            return target;
        }
    }
}
