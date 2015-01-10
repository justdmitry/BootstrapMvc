using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemDivider : Element, IDropdownMenuItem
    {
        public DropdownMenuItemDivider(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("li");
            tb.AddCssClass("divider");
            tb.MergeAttribute("role", "presentation");

            writer.Write(tb.GetFullTag());
        }
    }
}
