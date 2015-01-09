using System;

namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this TableStyles styles)
        {
            var className = "table";
            if ((styles & TableStyles.Striped) == TableStyles.Striped)
            {
                className += " " + "table-striped";
            }
            if ((styles & TableStyles.Bordered) == TableStyles.Bordered)
            {
                className += " " + "table-bordered";
            }
            if ((styles & TableStyles.Hover) == TableStyles.Hover)
            {
                className += " " + "table-hover";
            }
            if ((styles & TableStyles.Condensed) == TableStyles.Condensed)
            {
                className += " " + "table-condensed";
            }
            return className;
        }

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
