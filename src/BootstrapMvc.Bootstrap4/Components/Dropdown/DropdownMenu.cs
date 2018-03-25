namespace BootstrapMvc.Dropdown
{
    using System;
    using BootstrapMvc.Buttons;
    using BootstrapMvc.Core;

    public class DropdownMenu : ContentElement<DropdownMenuContent>
    {
        private string selfEnd;

        public DropdownDirection Direction { get; set; }

        public bool RightAlign { get; set; }

        public Element Trigger { get; set; }

        protected override DropdownMenuContent CreateContentContext(IBootstrapContext context)
        {
            return new DropdownMenuContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var parentGroup = this.Parent as ButtonGroup;

            if (parentGroup != null)
            {
                parentGroup.AddCssClass(Direction.ToCssClass());

                selfEnd = "</div>";
            }
            else
            {
                var div = Helper.CreateTagBuilder("div");
                div.AddCssClass("dropdown");
                div.AddCssClass(Direction.ToCssClass());
                div.WriteStartTag(writer);

                selfEnd = "</div></div>";
            }

            if (Trigger == null)
            {
                throw new InvalidOperationException("Set dropdown trigger element with Trigger()");
            }

            Trigger.AddCssClass("dropdown-toggle");
            Trigger.AddAttribute("data-toggle", "dropdown");
            Trigger.AddAttribute("aria-expanded", "false");

            Trigger.Parent = this;
            Trigger.WriteTo(writer);

            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("dropdown-menu");
            if (RightAlign)
            {
                tb.AddCssClass("dropdown-menu-right");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(selfEnd);
        }
    }
}
