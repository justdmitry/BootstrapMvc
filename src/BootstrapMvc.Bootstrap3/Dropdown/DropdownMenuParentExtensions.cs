using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static class DropdownMenuParentExtensions
    {
        public static IWriter2<T, AnyContent> Dropdown<T>(this IWriter2<T, AnyContent> parent, IWriter<DropdownMenu> menu) 
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            parent.Item
                .CssClass("dropdown-toggle")
                .Attribute("data-toggle", "dropdown")
                .Attribute("aria-expanded", "false");

            var caret = parent.Context.CreateWriter<SimpleBlock>();
            caret.Item.Value(" <span class=\"caret\"></span>", true);
            parent.Content(caret).Content(menu.Item);

            return parent;
        }

        public static DropdownMenuContent BeginDropdown<T>(this IWriter2<T, AnyContent> parent) 
            where T : AnyContentElement, IDropdownMenuParentMarker
        {
            var context = parent.Context;

            parent.Item
                .CssClass("dropdown-toggle")
                .Attribute("data-toggle", "dropdown")
                .Attribute("aria-expanded", "false");

            var caret = parent.Context.CreateWriter<SimpleBlock>();
            caret.Item.Value(" <span class=\"caret\"></span>", true);
            parent.Content(caret); // NO Content(menu.Item) !!!

            // полностью записываем parent, так как меню будет ПОСЛЕ него    
            var parentEnd = parent.BeginContent();
            parentEnd.Dispose();

            var menu = context.CreateWriter<DropdownMenu, DropdownMenuContent>();

            // пишем начало меню
            var menuEnd = menu.BeginContent();

            // возвращаем конец, чтобы записали "когда надо"
            return menuEnd;
        }
    }
}
