namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
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

        public static string ToCssClass(this PrintMode mode)
        {
            switch (mode)
            {
                case PrintMode.VisibleBlock:
                    return "visible-print-block";
                case PrintMode.VisibleInline:
                    return "visible-print-inline";
                case PrintMode.VisibleInlineBlock:
                    return "visible-print-inline-block";
                case PrintMode.Hidden:
                    return "hidden-print";
                default:
                    return string.Empty;
            }
        }

        public static string ToCssClass(this MediaObjectAlign align)
        {
            switch (align)
            {
                case MediaObjectAlign.Left:
                    return "media-left";
                case MediaObjectAlign.Right:
                    return "media-right";
                default:
                    return string.Empty;
            }
        }

        public static string ToCssClass(this MediaObjectVerticalAlign align)
        {
            switch (align)
            {
                case MediaObjectVerticalAlign.Top:
                    return string.Empty;
                case MediaObjectVerticalAlign.Middle:
                    return "media-middle";
                case MediaObjectVerticalAlign.Bottom:
                    return "media-bottom";
                default:
                    return string.Empty;
            }
        }
    }
}
