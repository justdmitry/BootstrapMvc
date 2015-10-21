namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class WritableItemExtensions
    {
        public static IItemWriter<T> WithWhitespaceSuffix<T>(this IItemWriter<T> target, bool value = true) 
            where T : WritableItem
        {
            target.Item.WithWhitespaceSuffix = value;
            return target;
        }

        public static IItemWriter<T, TContent> WithWhitespaceSuffix<T, TContent>(this IItemWriter<T, TContent> target, bool value = true)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.WithWhitespaceSuffix = value;
            return target;
        }
    }
}
