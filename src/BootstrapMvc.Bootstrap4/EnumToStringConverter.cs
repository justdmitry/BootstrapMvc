namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClassSubstring(this Color8 type)
        {
            switch (type)
            {
                case Color8.PrimaryBlue:
                    return "primary";
                case Color8.SecondaryGrey:
                    return "secondary";
                case Color8.SuccessGreen:
                    return "success";
                case Color8.DangerRed:
                    return "danger";
                case Color8.WarningOrange:
                    return "warning";
                case Color8.InfoCyan:
                    return "info";
                case Color8.LightGrey:
                    return "light";
                case Color8.DarkGrey:
                    return "dark";
            }

            return string.Empty;
        }

        public static string ToCssClassSubstring(this Color9 type)
        {
            switch (type)
            {
                case Color9.PrimaryBlue:
                    return "primary";
                case Color9.SecondaryGrey:
                    return "secondary";
                case Color9.SuccessGreen:
                    return "success";
                case Color9.DangerRed:
                    return "danger";
                case Color9.WarningOrange:
                    return "warning";
                case Color9.InfoCyan:
                    return "info";
                case Color9.LightGrey:
                    return "light";
                case Color9.DarkGrey:
                    return "dark";
                case Color9.White:
                    return "white";
            }

            return string.Empty;
        }
    }
}
