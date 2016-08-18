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
                    return "table-active";
                case TableRowCellColor.SuccessGreen:
                    return "table-success";
                case TableRowCellColor.InfoCyan:
                    return "table-info";
                case TableRowCellColor.WarningOrange:
                    return "table-warning";
                case TableRowCellColor.DangerRed:
                    return "table-danger";
                case TableRowCellColor.DefaultNone:
                default:
                    return string.Empty;
            }
        }

        public static string ToCssClass(this TableHeaderStyle style)
        {
            switch (style)
            {
                case TableHeaderStyle.Inverse:
                    return "thead-inverse";
                case TableHeaderStyle.DefaultGray:
                    return "thead-default";
                case TableHeaderStyle.None:
                default:
                    return string.Empty;
            }
        }
    }
}
