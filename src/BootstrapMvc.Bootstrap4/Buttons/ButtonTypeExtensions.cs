namespace BootstrapMvc
{
    using System;

    public static class ButtonTypeExtensions
    {
        public static string ToCssClass(this ButtonType type)
        {
            switch (type)
            {
                case ButtonType.PrimaryBlue:
                    return "btn btn-primary";
                case ButtonType.SecondaryWhite:
                    return "btn btn-secondary";
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

    }
}
