namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Dropdown;

    public static class DropdownMenuParentExtensions
    {
        public static DropdownMenuContent BeginDropdown<T>(this IItemWriter<T, AnyContent> parent) 
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            var menu = parent.Helper.CreateWriter<DropdownMenu, DropdownMenuContent>(parent.Item.Parent);
            menu.Item.Trigger = parent.Item;

            return menu.BeginContent();
        }

        public static DropdownMenuContent BeginDropdown<T>(this IItemWriter<T, AnyContent> parent, DropdownDirection direction)
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            var menu = parent.Helper.CreateWriter<DropdownMenu, DropdownMenuContent>(parent.Item.Parent);
            menu.Item.Trigger = parent.Item;

            menu.Direction(direction);

            return menu.BeginContent();
        }

        public static DropdownMenuContent BeginDropdown<T>(this IItemWriter<T, AnyContent> parent, DropdownDirection direction, bool rightAlign)
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            var menu = parent.Helper.CreateWriter<DropdownMenu, DropdownMenuContent>(parent.Item.Parent);
            menu.Item.Trigger = parent.Item;

            menu.Direction(direction).RightAlign(rightAlign);

            return menu.BeginContent();
        }
    }
}
