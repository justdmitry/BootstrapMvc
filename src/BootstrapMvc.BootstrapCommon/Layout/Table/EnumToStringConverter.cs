namespace BootstrapMvc
{
    using System;

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
#if BOOTSTRAP3
            if ((styles & TableStyles.Condensed) == TableStyles.Condensed)
            {
                className += " " + "table-condensed";
            }
#endif
#if BOOTSTRAP4
            if ((styles & TableStyles.Small) == TableStyles.Small)
            {
                className += " " + "table-sm";
            }
            if ((styles & TableStyles.Inverse) == TableStyles.Inverse)
            {
                className += " " + "table-inverse";
            }
            if ((styles & TableStyles.Reflow) == TableStyles.Reflow)
            {
                className += " " + "table-reflow";
            }

            // TableStyles.Responsive is manager in Table class itself!
#endif
            return className;
        }

        public static string ToCssClass(this TableRowCellColor color)
        {
#if BOOTSTRAP4
            const string prefix = "table-";
#else
            const string prefix = "";
#endif
            // String concatenation will be optimized at compile-time
            switch (color)
            {
                case TableRowCellColor.ActiveGray:
                    return prefix + "active";
                case TableRowCellColor.SuccessGreen:
                    return prefix + "success";
                case TableRowCellColor.InfoCyan:
                    return prefix + "info";
                case TableRowCellColor.WarningOrange:
                    return prefix + "warning";
                case TableRowCellColor.DangerRed:
                    return prefix + "danger";
                case TableRowCellColor.DefaultNone:
                default:
                    return string.Empty;
            }
        }
    }
}
