using System;

namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {

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

        public static string ToCssClass(this PaginatorSize size)
        {
            switch (size)
            {
                case PaginatorSize.Large:
                    return "pagination-lg";
                case PaginatorSize.Small:
                    return "pagination-sm";
                default:
                    return string.Empty;
            }
        }
    }
}
