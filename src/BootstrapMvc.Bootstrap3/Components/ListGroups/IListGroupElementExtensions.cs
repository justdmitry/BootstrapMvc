namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.ListGroups;

    public static class IListGroupElementExtensions
    {
        public static IItemWriter<T> Type<T>(this IItemWriter<T> target, ListGroupItemType value)
            where T : IListGroupElement, IWritableItem
        {
            target.Item.Type = value;
            return target;
        }

        public static IItemWriter<T, TContent> Type<T, TContent>(this IItemWriter<T, TContent> target, ListGroupItemType value)
            where T : ContentElement<TContent>, IListGroupElement
            where TContent : DisposableContent
        {
            target.Item.Type = value;
            return target;
        }
    }
}
