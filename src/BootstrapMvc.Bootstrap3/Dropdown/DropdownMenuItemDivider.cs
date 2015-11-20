namespace BootstrapMvc.Dropdown
{
    using System;
    using BootstrapMvc.Core;

    public class DropdownMenuItemDivider : Element, IDropdownMenuItem
    {
        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("li");
            tb.AddCssClass("divider");
            tb.MergeAttribute("role", "presentation", true);

            tb.WriteFullTag(writer);
        }
    }
}
