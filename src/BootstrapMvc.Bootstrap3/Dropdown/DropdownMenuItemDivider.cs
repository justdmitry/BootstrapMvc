using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemDivider : Element, IDropdownMenuItem
    {
        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("li");
            tb.AddCssClass("divider");
            tb.MergeAttribute("role", "presentation");

            tb.WriteFullTag(writer);
        }
    }
}
