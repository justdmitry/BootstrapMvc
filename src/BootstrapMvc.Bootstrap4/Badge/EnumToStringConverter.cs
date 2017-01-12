using System;

namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this BadgeType type)
        {
            string suffix = null;
            switch (type)
            {
                case BadgeType.DefaultGray:
                    suffix = "default";
                    break;
                case BadgeType.PrimaryBlue:
                    suffix = "primary";
                    break;
                case BadgeType.SuccessGreen:
                    suffix = "success";
                    break;
                case BadgeType.WarningOrange:
                    suffix = "warning";
                    break;
                case BadgeType.DangerRed:
                    suffix = "danger";
                    break;
                case BadgeType.InfoCyan:
                    suffix = "info";
                    break;
                default:
                    return string.Empty;
            }
            return "badge badge-" + suffix;
        }
    }
}
