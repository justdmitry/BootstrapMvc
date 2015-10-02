using System;
using BootstrapMvc.Core;
using BootstrapMvc.Paging;

namespace BootstrapMvc
{
    public static class PaginatorItemExtensions
    {
        public static IWriter2<T, AnyContent> Active<T>(this IWriter2<T, AnyContent> target, bool active = true)
            where T : PaginatorItem
        {
            target.Item.ActiveValue = active;
            return target;
        }
    }
}
