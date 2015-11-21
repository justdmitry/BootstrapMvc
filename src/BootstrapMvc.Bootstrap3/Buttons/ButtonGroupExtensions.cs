namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class ButtonGroupExtensions
    {
        public static IItemWriter<T, ButtonGroupContent> Justified<T>(this IItemWriter<T, ButtonGroupContent> target, bool value = true) 
            where T : ButtonGroup
        {
            if (value)
            {
                target.CssClass("btn-group-justified");
            }
            return target;
        }
    }
}
