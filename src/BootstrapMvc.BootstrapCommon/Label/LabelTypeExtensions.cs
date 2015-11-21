namespace BootstrapMvc
{
    using System;

    public static class LabelTypeExtensions
    {
        public static string ToCssClass(this LabelType type)
        {
            switch (type)
            {
                case LabelType.DefaultGray:
                    return "label label-default";
                case LabelType.PrimaryBlue:
                    return "label label-primary";
                case LabelType.SuccessGreen:
                    return "label label-success";
                case LabelType.WarningOrange:
                    return "label label-warning";
                case LabelType.DangerRed:
                    return "label label-danger";
                case LabelType.InfoCyan:
                    return "label label-info";
            }
            return string.Empty;
        }
    }
}
