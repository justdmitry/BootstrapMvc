using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ControlContextHolderExtensions
    {
        public static IWriter<T> ControlContext<T>(this IWriter<T> target, IControlContext context)
            where T : IWritable, IControlContextHolder
        {
            target.Item.SetControlContext(context);
            return target;
        }

        public static IWriter2<T, TContent> ControlContext<T, TContent>(this IWriter2<T, TContent> target, IControlContext context)
            where T : ContentElement<TContent>, IControlContextHolder
            where TContent : DisposableContent
        {
            target.Item.SetControlContext(context);
            return target;
        }
    }
}
