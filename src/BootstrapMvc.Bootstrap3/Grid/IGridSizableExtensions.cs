using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class IGridSizableExtensions
    {
        public static IWriter<T> Size<T>(this IWriter<T> target, GridSize value) 
            where T : IGridSizable, IWritable
        {
            target.Item.SetSize(value);
            return target;
        }

        public static IWriter<T> Size<T>(this IWriter<T> target, byte xs, byte sm, byte md, byte lg) 
            where T : IGridSizable, IWritable
        {
            target.Item.SetSize(new GridSize(xs, sm, md, lg));
            return target;
        }

        public static IWriter2<T, TContent> Size<T, TContent>(this IWriter2<T, TContent> target, GridSize value)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.SetSize(value);
            return target;
        }

        public static IWriter2<T, TContent> Size<T, TContent>(this IWriter2<T, TContent> target, byte xs, byte sm, byte md, byte lg)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.SetSize(new GridSize(xs, sm, md, lg));
            return target;
        }
    }
}
