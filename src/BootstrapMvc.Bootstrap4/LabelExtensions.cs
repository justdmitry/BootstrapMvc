namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class LabelExtensions
    {
        public static IItemWriter<T, AnyContent> Pill<T>(this IItemWriter<T, AnyContent> target) 
            where T : Label
        {
            target.CssClass("label-pill");
            return target;
        }
    }
}
