namespace BootstrapMvc
{
    public static class TextColorExtensions
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
    }
}
