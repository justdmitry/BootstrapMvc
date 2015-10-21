using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemHeader : AnyContentElement, IDropdownMenuItem
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("li");
            tb.AddCssClass("dropdown-header");
            tb.MergeAttribute("role", "presentation");

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
