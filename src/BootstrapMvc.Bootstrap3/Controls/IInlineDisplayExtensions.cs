using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class IInlineDisplayExtensions
    {
        #region Fluent

        public static IWriter<T> Inline<T>(this IWriter<T> target, bool inline = true)
            where T : IInlineDisplay, IWritable
        {
            target.Item.SetInline(inline);
            return target;
        }

        #endregion
    }
}
