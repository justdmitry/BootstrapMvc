using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementBootstrap3Extensions
    {
        public static T HtmlTooltip<T>(this T element, string value) where T : IWriter<Element>
        {
            element.Item.AddAttribute("title", value);
            return element;
        }

        public static T DoNotPrint<T>(this T target) where T : IWriter<Element>
        {
            target.Item.AddCssClass("hidden-print");
            return target;
        }

        public static T PullLeft<T>(this T target) where T : IWriter<Element>
        {
            target.Item.AddCssClass("pull-left");
            return target;
        }

        public static T PullRight<T>(this T target) where T : IWriter<Element>
        {
            target.Item.AddCssClass("pull-right");
            return target;
        }

        public static T CenterBlock<T>(this T target) where T : IWriter<Element>
        {
            target.Item.AddCssClass("center-block");
            return target;
        }

        public static T Clearfix<T>(this T target) where T : IWriter<Element>
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }

        public static T Visible<T>(this T target, Visibility value) where T : IWriter<Element>
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static T ForScreenReaders<T>(this T target, bool focusable = false) where T : IWriter<Element>
        {
            target.Item.AddCssClass("sr-only");
            if (focusable)
            {
                target.Item.AddCssClass("sr-only-focusable");
            }
            return target;
        }

        public static T HiddenText<T>(this T target) where T : IWriter<Element>
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }

        public static T TextColor<T>(this T target, TextColor color) where T : IWriter<Element>
        {
            target.Item.AddCssClass(color.ToCssClass());
            return target;
        }

        public static T Muted<T>(this T target) where T : IWriter<Element>
        {
            return TextColor(target, BootstrapMvc.TextColor.MutedGray);
        }

        public static T BackgroundColor<T>(this T target, BaseColor color) where T : IWriter<Element>
        {
            target.Item.AddCssClass(color.ToBackgroundCssClass());
            return target;
        }

        public static T Id<T>(this T target, string id) where T : IWriter<Element>
        {
            target.Item.AddAttribute("id", id);
            return target;
        }
    }
}
