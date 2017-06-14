using System;

namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this BadgeType type)
        {
            // String concatenation will be optimized at compile time
            const string prefix = "badge badge-";
            switch (type)
            {
                case BadgeType.DefaultGray:
                    return prefix + "default";
                case BadgeType.PrimaryBlue:
                    return prefix + "primary";
                case BadgeType.SuccessGreen:
                    return prefix + "success";
                case BadgeType.WarningOrange:
                    return prefix + "warning";
                case BadgeType.DangerRed:
                    return prefix + "danger";
                case BadgeType.InfoCyan:
                    return prefix + "info";
                default:
                    return string.Empty;
            }
        }
    }
}
