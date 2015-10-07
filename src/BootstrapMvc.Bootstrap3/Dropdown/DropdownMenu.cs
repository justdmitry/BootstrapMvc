using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenu : ContentElement<DropdownMenuContent>
    {
        public bool RightAlignValue { get; set; }

        protected override DropdownMenuContent CreateContentContext(IBootstrapContext context)
        {
            return new DropdownMenuContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("ul");
            tb.AddCssClass("dropdown-menu");
            if (RightAlignValue)
            {
                tb.AddCssClass("dropdown-menu-right");
            }
            tb.MergeAttribute("role", "menu");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</ul>");
        }
    }
}
