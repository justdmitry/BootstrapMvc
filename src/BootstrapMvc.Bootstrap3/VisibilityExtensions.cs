namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class VisibilityExtensions
    {
        public static IItemWriter<T> Visible<T>(this IItemWriter<T> target, Visibility value) where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> Visible<T, TContent>(this IItemWriter<T, TContent> target, Visibility value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T> Visibility<T>(this IItemWriter<T> target, VisibilityType value) 
            where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> Visibility<T, TContent>(this IItemWriter<T, TContent> target, VisibilityType value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static string ToCssClass(this Visibility color)
        {
            switch (color)
            {
                case BootstrapMvc.Visibility.Visible:
                    return "show";
                case BootstrapMvc.Visibility.Hidden:
                    return "hidden";
                case BootstrapMvc.Visibility.Invisible:
                    return "invisible";
                default:
                    return string.Empty;
            }
        }

        public static string ToCssClass(this VisibilityType visibility)
        {
            switch (visibility)
            {
                case VisibilityType.VisibleXsBlock:
                    return "visible-xs-block";
                case VisibilityType.VisibleXsInline:
                    return "visible-xs-inline";
                case VisibilityType.VisibleXsInlineBlock:
                    return "visible-xs-inline-block";

                case VisibilityType.VisibleSmBlock:
                    return "visible-sm-block";
                case VisibilityType.VisibleSmInline:
                    return "visible-sm-inline";
                case VisibilityType.VisibleSmInlineBlock:
                    return "visible-sm-inline-block";

                case VisibilityType.VisibleMdBlock:
                    return "visible-md-block";
                case VisibilityType.VisibleMdInline:
                    return "visible-md-inline";
                case VisibilityType.VisibleMdInlineBlock:
                    return "visible-md-inline-block";

                case VisibilityType.VisibleLgBlock:
                    return "visible-lg-block";
                case VisibilityType.VisibleLgInline:
                    return "visible-lg-inline";
                case VisibilityType.VisibleLgInlineBlock:
                    return "visible-lg-inline-block";

                case VisibilityType.HiddenXs:
                    return "hidden-xs";
                case VisibilityType.HiddenSm:
                    return "hidden-sm";
                case VisibilityType.HiddenMd:
                    return "hidden-md";
                case VisibilityType.HiddenLg:
                    return "hidden-lg";

                default:
                    return string.Empty;
            }
        }
    }
}
