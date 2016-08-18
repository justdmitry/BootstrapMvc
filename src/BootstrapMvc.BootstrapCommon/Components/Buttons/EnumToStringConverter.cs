namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this ButtonType type)
        {
            switch (type)
            {
#if BOOTSTRAP3
                case ButtonType.DefaultGray:
                    return "btn btn-default";
#endif
#if BOOTSTRAP4
                case ButtonType.SecondaryWhite:
                    return "btn btn-secondary";
#endif
                case ButtonType.PrimaryBlue:
                    return "btn btn-primary";
                case ButtonType.InfoCyan:
                    return "btn btn-info";
                case ButtonType.SuccessGreen:
                    return "btn btn-success";
                case ButtonType.WarningOrange:
                    return "btn btn-warning";
                case ButtonType.DangerRed:
                    return "btn btn-danger";
                case ButtonType.Link:
                    return "btn btn-link";
            }
            return string.Empty;
        }

        public static string ToButtonCssClass(this ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Large:
                    return "btn-lg";
                case ButtonSize.Small:
                    return "btn-sm";
#if BOOTSTRAP3
                case ButtonSize.ExtraSmall:
                    return "btn-xs";
#endif
            }
            return string.Empty;
        }

        public static string ToButtonGroupCssClass(this ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Large:
                    return "btn-group-lg";
                case ButtonSize.Small:
                    return "btn-group-sm";
#if BOOTSTRAP3
                case ButtonSize.ExtraSmall:
                    return "btn-group-xs";
#endif
            }
            return string.Empty;
        }
    }
}
