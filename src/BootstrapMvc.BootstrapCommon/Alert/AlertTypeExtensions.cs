namespace BootstrapMvc
{
    using System;

    public static class AlertTypeExtensions
    {
        public static string ToCssClass(this AlertType type)
        {
            switch (type)
            {
                case AlertType.DangerRed:
                    return "alert alert-danger";
                case AlertType.InfoCyan:
                    return "alert alert-info";
                case AlertType.SuccessGreen:
                    return "alert alert-success";
                case AlertType.WarningOrange:
                    return "alert alert-warning";
            }
            return string.Empty;
        }
    }
}
