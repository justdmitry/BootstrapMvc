namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Paging;

    public static class PaginatorItemExtensions
    {
        public static IItemWriter<T, AnyContent> Active<T>(this IItemWriter<T, AnyContent> target, bool active = true)
            where T : PaginatorItem
        {
            target.Item.Active = active;
            return target;
        }
    }
}
