using System.Web.Mvc;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class DropdownMenuItemHeader : AnyContentElement, IDropdownMenuItem
    {
        public DropdownMenuItemHeader(BootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = new TagBuilder("li");
            tb.AddCssClass("dropdown-header");
            tb.MergeAttribute("role", "presentation");

            writer.Write(tb.ToString(TagRenderMode.StartTag));

            return "</li>";
        }
    }
}
