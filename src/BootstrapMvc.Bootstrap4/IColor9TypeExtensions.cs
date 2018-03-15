namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class IColor9TypeExtensions
    {
        public static IItemWriter<T> Type<T>(this IItemWriter<T> target, Color9 type)
            where T : IColor9Type, IWritableItem
        {
            target.Item.Type = type;
            return target;
        }

        public static IItemWriter<T, TContent> Type<T, TContent>(this IItemWriter<T, TContent> target, Color9 type)
            where T : ContentElement<TContent>, IColor9Type
            where TContent : DisposableContent
        {
            target.Item.Type = type;
            return target;
        }
    }
}
