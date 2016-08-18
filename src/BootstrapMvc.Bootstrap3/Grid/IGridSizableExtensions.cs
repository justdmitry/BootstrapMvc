namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class IGridSizableExtensions
    {
        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, byte xs, byte sm, byte md, byte lg) 
            where T : IGridSizable, IWritableItem
        {
            target.Item.SetSize(new GridSize(xs, sm, md, lg));
            return target;
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, byte xs, byte sm, byte md, byte lg)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.SetSize(new GridSize(xs, sm, md, lg));
            return target;
        }
    }
}
