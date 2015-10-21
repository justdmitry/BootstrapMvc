namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Dropdown;

    public static class DropdownMenuParentExtensions
    {
        public static IItemWriter<T, AnyContent> Dropdown<T>(this IItemWriter<T, AnyContent> parent, IItemWriter<DropdownMenu> menu) 
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            parent
                .CssClass("dropdown-toggle")
                .Attribute("data-toggle", "dropdown")
                .Attribute("aria-expanded", "false");

            var caret = parent.Helper.CreateWriter<SimpleBlock>(parent.Item);
            caret.Item.Value = " <span class=\"caret\"></span>";
            caret.Item.DisableEncoding = true;

            parent.Content(caret).Content(menu.Item);

            return parent;
        }

        public static DropdownMenuContent BeginDropdown<T>(this IItemWriter<T, AnyContent> parent) 
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            parent
                .CssClass("dropdown-toggle")
                .Attribute("data-toggle", "dropdown")
                .Attribute("aria-expanded", "false");

            var caret = parent.Helper.CreateWriter<SimpleBlock>(parent.Item);
            caret.Item.Value = " <span class=\"caret\"></span>";
            caret.Item.DisableEncoding = true;
            parent.Content(caret); // NO Content(menu.Item) !!!

            // полностью записываем parent, так как меню будет ПОСЛЕ него    
            var parentEnd = parent.BeginContent();
            parentEnd.Dispose();

            var menu = parent.Helper.CreateWriter<DropdownMenu, DropdownMenuContent>(parent.Item.Parent);

            // пишем начало меню
            var menuEnd = menu.BeginContent();

            // возвращаем конец, чтобы записали "когда надо"
            return menuEnd;
        }
    }
}
