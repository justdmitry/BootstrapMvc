namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this TableRowCellColor color)
        {
            switch (color)
            {
                case TableRowCellColor.ActiveGray:
                    return "active";
                case TableRowCellColor.SuccessGreen:
                    return "success";
                case TableRowCellColor.InfoCyan:
                    return "info";
                case TableRowCellColor.WarningOrange:
                    return "warning";
                case TableRowCellColor.DangerRed:
                    return "danger";
                case TableRowCellColor.DefaultNone:
                default:
                    return string.Empty;
            }
        }
    }
}
