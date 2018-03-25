using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static class DropdownMenuExtensions
    {
        public static IItemWriter<T, DropdownMenuContent> Direction<T>(this IItemWriter<T, DropdownMenuContent> target, DropdownDirection value)
            where T : DropdownMenu
        {
            target.Item.Direction = value;
            return target;
        }

        public static IItemWriter<T, DropdownMenuContent> RightAlign<T>(this IItemWriter<T, DropdownMenuContent> target, bool value = true) 
            where T : DropdownMenu
        {
            target.Item.RightAlign = value;
            return target;
        }
    }
}
