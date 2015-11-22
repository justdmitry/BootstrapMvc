namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DropdownMenuItemHeader : AnyContentElement, IDropdownMenuItem
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("h5");
            tb.AddCssClass("dropdown-header");

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
