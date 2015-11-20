namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class PrintExtensions
    {
        public static IItemWriter<T> PrintMode<T>(this IItemWriter<T> target, PrintMode value)
            where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> PrintMode<T, TContent>(this IItemWriter<T, TContent> target, PrintMode value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static string ToCssClass(this PrintMode mode)
        {
            switch (mode)
            {
                case BootstrapMvc.PrintMode.VisibleBlock:
                    return "visible-print-block";
                case BootstrapMvc.PrintMode.VisibleInline:
                    return "visible-print-inline";
                case BootstrapMvc.PrintMode.VisibleInlineBlock:
                    return "visible-print-inline-block";
                case BootstrapMvc.PrintMode.Hidden:
                    return "hidden-print";
                default:
                    return string.Empty;
            }
        }
    }
}
