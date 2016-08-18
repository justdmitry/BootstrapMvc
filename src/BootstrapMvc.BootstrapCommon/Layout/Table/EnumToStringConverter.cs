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
    }
}
