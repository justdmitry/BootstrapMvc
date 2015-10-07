using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class ITextDisplayExtensions
    {
        public static IWriter<T> Text<T>(this IWriter<T> target, string text)
            where T : ITextDisplay, IWritable
        {
            target.Item.TextValue = text;
            return target;
        }
    }
}
