namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class VisibilityExtensions
    {
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

        public static string ToCssClass(this VisibilityType visibility)
        {
            switch (visibility)
            {
                case VisibilityType.HiddenXsDown:
                    return "hidden-xs-down";
                case VisibilityType.HiddenSmDown:
                    return "hidden-sm-down";
                case VisibilityType.HiddenMdDown:
                    return "hidden-md-down";
                case VisibilityType.HiddenLgDown:
                    return "hidden-lg-down";
                case VisibilityType.HiddenXlDown:
                    return "hidden-xl-down";
                case VisibilityType.HiddenXsUp:
                    return "hidden-xs-up";
                case VisibilityType.HiddenSmUp:
                    return "hidden-sm-up";
                case VisibilityType.HiddenMdUp:
                    return "hidden-md-up";
                case VisibilityType.HiddenLgUp:
                    return "hidden-lg-up";
                case VisibilityType.HiddenXlUp:
                    return "hidden-xl-up";
                default:
                    return string.Empty;
            }
        }
    }
}
