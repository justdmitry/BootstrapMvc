namespace BootstrapMvc
{
    public static class BaseColorExtensions
    {
        public static string ToCssClass(this BackgroundColor color)
        {
            switch (color)
            {
                case BackgroundColor.PrimaryBlue:
                    return "bg-primary";
                case BackgroundColor.SuccessGreen:
                    return "bg-success";
                case BackgroundColor.InfoCyan:
                    return "bg-info";
                case BackgroundColor.WarningOrange:
                    return "bg-warning";
                case BackgroundColor.DangerRed:
                    return "bg-danger";
                case BackgroundColor.FadedGray:
                    return "bg-faded";
                case BackgroundColor.DefaultNone:
                default:
                    return string.Empty;
            }
        }
    }
}
