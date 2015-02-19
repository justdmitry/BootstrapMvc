using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static T HtmlTooltip<T>(this T element, string value) where T : Element
        {
            element.AddAttribute("title", value);
            return element;
        }

        public static T DoNotPrint<T>(this T target) where T : Element
        {
            target.AddCssClass("hidden-print");
            return target;
        }

        public static T PullLeft<T>(this T target) where T : Element
        {
            target.AddCssClass("pull-left");
            return target;
        }

        public static T PullRight<T>(this T target) where T : Element
        {
            target.AddCssClass("pull-right");
            return target;
        }

        public static T CenterBlock<T>(this T target) where T : Element
        {
            target.AddCssClass("center-block");
            return target;
        }

        public static T Clearfix<T>(this T target) where T : Element
        {
            target.AddCssClass("clearfix");
            return target;
        }

        public static T Visible<T>(this T target, Visibility value) where T : Element
        {
            target.AddCssClass(value.ToCssClass());
            return target;
        }

        public static T ForScreenReaders<T>(this T target, bool focusable = false) where T : Element
        {
            target.AddCssClass("sr-only");
            if (focusable)
            {
                target.AddCssClass("sr-only-focusable");
            }
            return target;
        }

        public static T HiddenText<T>(this T target) where T : Element
        {
            target.AddCssClass("text-hide");
            return target;
        }

        public static T TextColor<T>(this T target, TextColor color) where T : Element
        {
            target.AddCssClass(color.ToCssClass());
            return target;
        }

        public static T Muted<T>(this T target) where T : Element
        {
            return TextColor(target, BootstrapMvc.TextColor.MutedGray);
        }

        public static T BackgroundColor<T>(this T target, BaseColor color) where T : Element
        {
            target.AddCssClass(color.ToBackgroundCssClass());
            return target;
        }

        public static T Id<T>(this T target, string id) where T : Element
        {
            target.AddAttribute("id", id);
            return target;
        }
    }
}
