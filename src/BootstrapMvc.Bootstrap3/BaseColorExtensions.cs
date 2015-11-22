namespace BootstrapMvc
{
    using System;

    public static class BaseColorExtensions
    {
        [Obsolete("Use ToCssClass() instead")]
        public static string ToBackgroundCssClass(this BaseColor color)
        {
            return color.ToCssClass();
        }

        public static string ToCssClass(this BaseColor color)
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
    }
}
