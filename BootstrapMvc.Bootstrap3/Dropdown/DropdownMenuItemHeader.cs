using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemHeader : AnyContentElement, IDropdownMenuItem
    {
        public DropdownMenuItemHeader(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("li");
            tb.AddCssClass("dropdown-header");
            tb.MergeAttribute("role", "presentation");

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
