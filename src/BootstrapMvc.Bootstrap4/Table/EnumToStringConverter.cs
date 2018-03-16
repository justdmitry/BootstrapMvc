namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this TableStyles styles)
        {
            var className = "table";
            if ((styles & TableStyles.Striped) == TableStyles.Striped)
            {
                className += " table-striped";
            }

            if ((styles & TableStyles.Bordered) == TableStyles.Bordered)
            {
                className += " table-bordered";
            }

            if ((styles & TableStyles.Hover) == TableStyles.Hover)
            {
                className += " table-hover";
            }

            if ((styles & TableStyles.Small) == TableStyles.Small)
            {
                className += " table-sm";
            }

            if ((styles & TableStyles.Dark) == TableStyles.Dark)
            {
                className += " table-dark";
            }

            return className;
        }

        public static string ToCssClass(this TableResponsive value)
        {
            switch (value)
            {
                case TableResponsive.Always:
                    return "table-responsive";
                case TableResponsive.sm:
                    return "table-responsive-sm";
                case TableResponsive.md:
                    return "table-responsive-md";
                case TableResponsive.lg:
                    return "table-responsive-lg";
                case TableResponsive.xl:
                    return "table-responsive-xl";
            }

            return string.Empty;
        }

        public static string ToCssClass(this TableRowCellColor color)
        {
            const string prefix = "table-";

            switch (color)
            {
                case TableRowCellColor.Active:
                    return prefix + "active";
                case TableRowCellColor.PrimaryBlue:
                    return prefix + "primary";
                case TableRowCellColor.SecondaryGrey:
                    return prefix + "secondary";
                case TableRowCellColor.SuccessGreen:
                    return prefix + "success";
                case TableRowCellColor.DangerRed:
                    return prefix + "danger";
                case TableRowCellColor.WarningOrange:
                    return prefix + "warning";
                case TableRowCellColor.InfoCyan:
                    return prefix + "info";
                case TableRowCellColor.LightGrey:
                    return prefix + "light";
                case TableRowCellColor.DarkGrey:
                    return prefix + "dark";
            }

            return string.Empty;
        }
    }
}
