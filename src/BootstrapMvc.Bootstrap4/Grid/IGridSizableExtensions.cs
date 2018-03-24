namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class IGridSizableExtensions
    {
        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, GridSize value)
            where T : IGridSizable, IWritableItem
        {
            target.Item.Size = value;
            return target;
        }

        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, byte value)
            where T : IGridSizable, IWritableItem
        {
            target.Item.Size = new GridSize(value);
            return target;
        }

        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, byte xs, byte sm, byte md, byte lg, byte xl)
            where T : IGridSizable, IWritableItem
        {
            target.Item.Size = new GridSize(xs, sm, md, lg, xl);
            return target;
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, GridSize value)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.Size = value;
            return target;
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, byte xs, byte sm, byte md, byte lg, byte xl)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.Size = new GridSize(xs, sm, md, lg, xl);
            return target;
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.Size = new GridSize(value);
            return target;
        }
    }
}
