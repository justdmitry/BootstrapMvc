using System;

namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this AlertType type)
        {
            switch (type)
            {
                case AlertType.DangerRed:
                    return "alert alert-danger";
                case AlertType.InfoCyan:
                    return "alert alert-info";
                case AlertType.SuccessGreen:
                    return "alert alert-success";
                case AlertType.WarningOrange:
                    return "alert alert-warning";
            }
            return string.Empty;
        }

        public static string ToCssClass(this IconType type)
        {
            return "glyphicon glyphicon-" + type.ToString().Replace('_', '-').ToLowerInvariant();
        }

        public static string ToCssClass(this LabelType type)
        {
            switch (type)
            {
                case LabelType.DefaultGray:
                    return "label label-default";
                case LabelType.PrimaryBlue:
                    return "label label-primary";
                case LabelType.SuccessGreen:
                    return "label label-success";
                case LabelType.WarningOrange:
                    return "label label-warning";
                case LabelType.DangerRed:
                    return "label label-danger";
                case LabelType.InfoCyan:
                    return "label label-info";
            }
            return string.Empty;
        }

        public static string ToCssClass(this TextColor color)
        {
            switch (color)
            {
                case TextColor.PrimaryBlue:
                    return "text-primary";
                case TextColor.SuccessGreen:
                    return "text-success";
                case TextColor.InfoCyan:
                    return "text-info";
                case TextColor.WarningOrange:
                    return "text-warning";
                case TextColor.DangerRed:
                    return "text-danger";
                case TextColor.MutedGray:
                    return "text-muted";
                case TextColor.DefaultNone:
                default:
                    return string.Empty;
            }
        }

        public static string ToBackgroundCssClass(this BaseColor color)
        {
            switch (color)
            {
                case BaseColor.PrimaryBlue:
                    return "bg-primary";
                case BaseColor.SuccessGreen:
                    return "bg-success";
                case BaseColor.InfoCyan:
                    return "bg-info";
                case BaseColor.WarningOrange:
                    return "bg-warning";
                case BaseColor.DangerRed:
                    return "bg-danger";
                case BaseColor.DefaultNone:
                default:
                    return string.Empty;
            }
        }

        public static string ToCssClass(this Visibility color)
        {
            switch (color)
            {
                case Visibility.Visible:
                    return "show";
                case Visibility.Hidden:
                    return "hidden";
                case Visibility.Invisible:
                    return "invisible";
                default:
                    return string.Empty;
            }
        }
    }
}
