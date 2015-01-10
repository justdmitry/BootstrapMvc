using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static class DropdownMenuParentExtensions
    {
        public static T Dropdown<T>(this T parent, DropdownMenu menu) where T : AnyContentElement, IDropdownMenuParentMarker
        {
            parent.AddCssClass("dropdown-toggle");
            parent.MergeAttribute("data-toggle", "dropdown");
            parent.MergeAttribute("aria-expanded", "false");

            var caret = new Content(parent.Context).Value(" <span class=\"caret\"></span>", true);
            parent.AddContent(caret);
            parent.AddContent(menu);

            return parent;
        }

        public static DropdownMenuContent BeginDropdown<T>(this T parent) where T : AnyContentElement, IDropdownMenuParentMarker
        {
            parent.AddCssClass("dropdown-toggle");
            parent.MergeAttribute("data-toggle", "dropdown");
            parent.MergeAttribute("aria-expanded", "false");

            var caret = new Content(parent.Context).Value(" <span class=\"caret\"></span>", true);
            parent.AddContent(caret);

            var parentEnd = parent.BeginContent();
            parentEnd.WriteTo(parent.Context.Writer);

            var menu = new DropdownMenu(parent.Context);
            var menuEnd = menu.BeginContent();

            return menuEnd;
        }
    }
}
