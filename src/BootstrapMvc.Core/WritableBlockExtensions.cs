using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class WritableBlockExtensions
    {
        public static T WithWhitespace<T>(this T target, bool value = true) where T : WritableBlock
        {
            target.WriteWhitespaceSuffix = value;
            return target;
        }

        public static T Append<T>(this T target, WritableBlock value) where T: WritableBlock
        {
            target.AppendNextBlock(value);
            return target;
        }
    }
}
