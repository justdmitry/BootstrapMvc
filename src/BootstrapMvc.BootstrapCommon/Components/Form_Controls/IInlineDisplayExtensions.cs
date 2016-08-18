namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Controls;

    public static class IInlineDisplayExtensions
    {
        #region Fluent

        public static IItemWriter<T> Inline<T>(this IItemWriter<T> target, bool inline = true)
            where T : IInlineDisplay, IWritableItem
        {
            target.Item.SetInline(inline);
            return target;
        }

        #endregion
    }
}
