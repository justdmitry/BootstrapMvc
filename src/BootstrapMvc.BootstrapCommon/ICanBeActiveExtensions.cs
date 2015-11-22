namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ICanBeActiveExtensions
    {
        public static IItemWriter<T> Active<T>(this IItemWriter<T> target, bool active = true)
            where T : Element, ICanBeActive
        {
            target.Item.Active = active;
            return target;
        }

        public static IItemWriter<T, TContent> Active<T, TContent>(this IItemWriter<T, TContent> target, bool active = true)
            where T : ContentElement<TContent>, ICanBeActive
            where TContent : DisposableContent
        {
            target.Item.Active = active;
            return target;
        }
    }
}
