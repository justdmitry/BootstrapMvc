namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class PrintExtensions
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
    }
}
