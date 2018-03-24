namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Buttons;

    public static class IControlSizableExtensions
    {
        public static IItemWriter<T> Size<T>(this IItemWriter<T> target, ControlSize value)
            where T : IControlSizable, IWritableItem
        {
            target.Item.Size = value;
            return target;
        }

        public static IItemWriter<T, TContent> Size<T, TContent>(this IItemWriter<T, TContent> target, ControlSize value)
            where T : ContentElement<TContent>, IControlSizable
            where TContent : DisposableContent
        {
            target.Item.Size = value;
            return target;
        }
    }
}
