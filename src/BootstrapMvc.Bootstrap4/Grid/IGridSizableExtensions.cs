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

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, GridSize value)
            where T : ContentElement<TContent>, IGridSizable
            where TContent : DisposableContent
        {
            target.Item.Size = value;
            return target;
        }
    }
}
