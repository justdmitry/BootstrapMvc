using System;

namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this LabelType type)
        {
            string suffix = null;
            switch (type)
            {
                case LabelType.DefaultGray:
                    suffix = "default";
                    break;
                case LabelType.PrimaryBlue:
                    suffix = "primary";
                    break;
                case LabelType.SuccessGreen:
                    suffix = "success";
                    break;
                case LabelType.WarningOrange:
                    suffix = "warning";
                    break;
                case LabelType.DangerRed:
                    suffix = "danger";
                    break;
                case LabelType.InfoCyan:
                    suffix = "info";
                    break;
                default:
                    return string.Empty;
            }
#if BOOTSTRAP3
            return "label label-" + suffix;
#elif BOOTSTRAP4
            return "tag tag-" + suffix;
#else
            return string.Empty;
#endif
        }
    }
}
