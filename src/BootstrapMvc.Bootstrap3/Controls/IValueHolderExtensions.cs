using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class IValueHolderExtensions
    {
        public static IWriter<T> Value<T>(this IWriter<T> target, string value)
            where T : IValueHolder, IWritable
        {
            target.Item.ValueValue = value;
            return target;
        }

        public static IWriter2<T, TContent> Value<T, TContent>(this IWriter2<T, TContent> target, string value)
            where T : ContentElement<TContent>, IValueHolder
            where TContent : DisposableContent
        {
            target.Item.ValueValue = value;
            return target;
        }
    }
}
