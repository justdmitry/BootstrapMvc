namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DropdownMenuItemDivider : Element, IDropdownMenuItem
    {
        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("dropdown-divider");

            tb.WriteFullTag(writer);
        }
    }
}
