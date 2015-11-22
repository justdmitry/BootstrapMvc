namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DropdownMenu : ContentElement<DropdownMenuContent>
    {
        public bool RightAlign { get; set; }

        protected override DropdownMenuContent CreateContentContext(IBootstrapContext context)
        {
            return new DropdownMenuContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("dropdown-menu");
            if (RightAlign)
            {
                tb.AddCssClass("dropdown-menu-right");
            }
            tb.MergeAttribute("role", "menu", true);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</div>");
        }
    }
}
