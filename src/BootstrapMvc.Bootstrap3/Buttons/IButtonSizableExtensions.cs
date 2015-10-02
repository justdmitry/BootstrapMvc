using System;
using BootstrapMvc.Core;
using BootstrapMvc.Buttons;

namespace BootstrapMvc
{
    public static class IButtonSizableExtensions
    {
        public static IWriter<T> Size<T>(this IWriter<T> target, ButtonSize value) 
            where T : IButtonSizable, IWritable
        {
            target.Item.SizeValue = value;
            return target;
        }

        public static IWriter2<T, TContent> Size<T, TContent>(this IWriter2<T, TContent> target, ButtonSize value) 
            where T : ContentElement<TContent>, IButtonSizable
            where TContent : DisposableContent
        {
            target.Item.SizeValue = value;
            return target;
        }
    }
}
