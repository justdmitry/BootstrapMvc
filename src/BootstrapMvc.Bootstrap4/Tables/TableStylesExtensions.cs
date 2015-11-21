namespace BootstrapMvc
{
    using System;

    public static class TableStylesExtensions
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
            if ((styles & TableStyles.Small) == TableStyles.Small)
            {
                className += " " + "table-sm";
            }
            if ((styles & TableStyles.Inverse) == TableStyles.Inverse)
            {
                className += " " + "table-inverse";
            }
            return className;
        }
    }
}
