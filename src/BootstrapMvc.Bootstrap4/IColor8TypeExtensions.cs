namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class IColor8TypeExtensions
    {
        public static IItemWriter<T> Type<T>(this IItemWriter<T> target, Color8 type)
            where T : IColor8Type, IWritableItem
        {
            target.Item.Type = type;
            return target;
        }

        public static IItemWriter<T, TContent> Type<T, TContent>(this IItemWriter<T, TContent> target, Color8 type)
            where T : ContentElement<TContent>, IColor8Type
            where TContent : DisposableContent
        {
            target.Item.Type = type;
            return target;
        }
    }
}
