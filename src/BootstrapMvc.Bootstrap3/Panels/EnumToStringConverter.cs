namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this PanelType type)
        {
            switch (type)
            {
                case PanelType.PrimaryBlue:
                    return "panel panel-primary";
                case PanelType.SuccessGreen:
                    return "panel panel-success";
                case PanelType.InfoCyan:
                    return "panel panel-info";
                case PanelType.WarningOrange:
                    return "panel panel-warning";
                case PanelType.DangerRed:
                    return "panel panel-danger";
                case PanelType.DefaultGray:
                default:
                    return "panel panel-default";
            }
        }
    }
}
