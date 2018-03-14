namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this ListGroupItemType color)
        {
            switch (color)
            {
                case ListGroupItemType.SuccessGreen:
                    return "list-group-item-success";
                case ListGroupItemType.InfoCyan:
                    return "list-group-item-info";
                case ListGroupItemType.WarningOrange:
                    return "list-group-item-warning";
                case ListGroupItemType.DangerRed:
                    return "list-group-item-danger";
                case ListGroupItemType.DefaultNone:
                default:
                    return string.Empty;
            }
        }
    }
}
