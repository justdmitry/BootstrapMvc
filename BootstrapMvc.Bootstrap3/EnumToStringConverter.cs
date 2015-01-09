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

        ////public static TextColor ToTextColor(this LabelType type)
        ////{
        ////    switch (type)
        ////    {
        ////        case LabelType.PrimaryBlue:
        ////            return TextColor.PrimaryBlue;
        ////        case LabelType.SuccessGreen:
        ////            return TextColor.SuccessGreen;
        ////        case LabelType.WarningOrange:
        ////            return TextColor.WarningOrange;
        ////        case LabelType.DangerRed:
        ////            return TextColor.DangerRed;
        ////        case LabelType.InfoCyan:
        ////            return TextColor.InfoCyan;
        ////    }
        ////    return TextColor.Default;
        ////}
    }
}
