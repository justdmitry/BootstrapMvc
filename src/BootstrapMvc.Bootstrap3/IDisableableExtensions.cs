using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class IDisableableExtensions
    {
        public static IWriter<T> Disabled<T>(this IWriter<T> target, bool disabled = true) 
            where T : IDisableable, IWritable
        {
            target.Item.SetDisabled(disabled);
            return target;
        }

        public static IWriter2<T, TContent> Disabled<T, TContent>(this IWriter2<T, TContent> target, bool disabled = true)
            where T : ContentElement<TContent>, IDisableable
            where TContent : DisposableContent
        {
            target.Item.SetDisabled(disabled);
            return target;
        }
    }
}
