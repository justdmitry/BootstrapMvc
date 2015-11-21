namespace BootstrapMvc
{
    using System;

    public static class PrintTypeExtensions
    {
        public static string ToCssClass(this PrintMode mode)
        {
            switch (mode)
            {
                case PrintMode.VisibleBlock:
                    return "visible-print-block";
                case PrintMode.VisibleInline:
                    return "visible-print-inline";
                case PrintMode.VisibleInlineBlock:
                    return "visible-print-inline-block";
                case PrintMode.Hidden:
                    return "hidden-print";
                default:
                    return string.Empty;
            }
        }
    }
}
