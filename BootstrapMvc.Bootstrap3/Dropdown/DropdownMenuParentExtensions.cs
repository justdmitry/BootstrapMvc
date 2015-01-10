using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class DropdownMenuParentExtensions
    {
        public static IDropdownMenuParentMarker Dropdown(this IDropdownMenuParentMarker parent, DropdownMenu menu)
        {
            parent.AddCssClass("dropdown-toggle");
            parent.MergeAttribute("data-toggle", "dropdown");
            parent.MergeAttribute("aria-expanded", "false");

            var caret = SimpleContent.FromHtml(" <span class=\"caret\"></span>");
            parent.AddContent(caret);
            parent.AddContent(menu);

            return parent;
        }

        public static DropdownMenuContent BeginDropdown(this IDropdownMenuParentMarker parent)
        {
            parent.AddCssClass("dropdown-toggle");
            parent.MergeAttribute("data-toggle", "dropdown");
            parent.MergeAttribute("aria-expanded", "false");

            var caret = SimpleContent.FromHtml(" <span class=\"caret\"></span>");
            parent.AddContent(caret);

            var parentEnd = parent.BeginContent();
            parentEnd.WriteTo(parent.Context.Writer);

            var menu = new DropdownMenu(parent.Context);
            var menuEnd = menu.BeginContent();

            // return original menuEnd, which contains parentEnd as NextBlock
            return menuEnd; 
        }
    }
}
