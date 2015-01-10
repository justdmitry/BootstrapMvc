using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenu : ContentElement<DropdownMenuContent>
    {
        private bool rightAlign;

        public DropdownMenu(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public DropdownMenu Right(bool right = true)
        {
            this.rightAlign = right;
            return this;
        }

        #endregion

        protected override DropdownMenuContent CreateContent()
        {
            return new DropdownMenuContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("ul");
            tb.AddCssClass("dropdown-menu");
            if (rightAlign)
            {
                tb.AddCssClass("dropdown-menu-right");
            }
            tb.MergeAttribute("role", "menu");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return new Content(Context).Value("</ul>", true);
        }
    }
}
