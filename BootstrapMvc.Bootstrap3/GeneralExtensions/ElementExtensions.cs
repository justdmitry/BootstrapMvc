using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ElementExtensions
    {
        public static T HtmlTooltip<T>(this T element, string value) where T : Element
        {
            element.MergeAttribute("title", value);
            return element;
        }

        public static T DoNotPrint<T>(this T target) where T : Element
        {
            target.AddCssClass("hidden-print");
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
            target.MergeAttribute("id", id);
            return target;
        }
    }
}
