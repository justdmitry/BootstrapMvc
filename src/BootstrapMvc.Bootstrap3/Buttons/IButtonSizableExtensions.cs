namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Buttons;

    public static class IButtonSizableExtensions
    {
        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, ButtonSize value) 
            where T : IButtonSizable, IWritableItem
        {
            target.Item.Size = value;
            return target;
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, ButtonSize value) 
            where T : ContentElement<TContent>, IButtonSizable
            where TContent : DisposableContent
        {
            target.Item.Size = value;
            return target;
        }
    }
}
