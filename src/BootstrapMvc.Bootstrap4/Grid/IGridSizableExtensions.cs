namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class IGridSizableExtensions
    {
        [Obsolete("Use method with 'xl' param")]
        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, byte xs, byte sm, byte md, byte lg) 
            where T : IGridSizable, IWritableItem
        {
            return Size(target, xs, sm, md, lg, lg);
        }

        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, byte xs, byte sm, byte md, byte lg, byte xl)
            where T : IGridSizable, IWritableItem
        {
            target.Item.SetSize(new GridSize(xs, sm, md, lg, xl));
            return target;
        }

        [Obsolete("Use method with 'xl' param")]
        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, byte xs, byte sm, byte md, byte lg)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            return Size(target, xs, sm, md, lg, lg);
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, byte xs, byte sm, byte md, byte lg, byte xl)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.SetSize(new GridSize(xs, sm, md, lg, xl));
            return target;
        }
    }
}
