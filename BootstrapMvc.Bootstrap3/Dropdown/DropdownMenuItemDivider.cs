using System.Web.Mvc;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class DropdownMenuItemDivider : SimpleElement, IDropdownMenuItem
    {
        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = new TagBuilder("li");
            tb.AddCssClass("divider");
            tb.MergeAttribute("role", "presentation");

            writer.Write(tb.ToString());
        }
    }
}
