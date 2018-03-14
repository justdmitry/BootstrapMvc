namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class IActivableExtensions
    {
        public static IItemWriter<T> Active<T>(this IItemWriter<T> target, bool active = true)
            where T : IActivable, IWritableItem
        {
            target.Item.SetActive(active);
            return target;
        }

        public static IItemWriter<T, TContent> Active<T, TContent>(this IItemWriter<T, TContent> target, bool active = true)
            where T : ContentElement<TContent>, IActivable
            where TContent : DisposableContent
        {
            target.Item.SetActive(active);
            return target;
        }
    }
}
