using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenu : ContentElement<DropdownMenuContent>
    {
        public DropdownMenu(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public bool RightAlignValue { get; set; }

        protected override DropdownMenuContent CreateContentContext()
        {
            return new DropdownMenuContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("ul");
            tb.AddCssClass("dropdown-menu");
            if (RightAlignValue)
            {
                tb.AddCssClass("dropdown-menu-right");
            }
            tb.MergeAttribute("role", "menu");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</ul>");
        }
    }
}
