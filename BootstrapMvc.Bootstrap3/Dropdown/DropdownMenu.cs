using System.Web.Mvc;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class DropdownMenu : ContentElement<DropdownMenuContent>
    {
        private bool rightAlign;

        public DropdownMenu(BootstrapContext context)
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

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = new TagBuilder("ul");
            tb.AddCssClass("dropdown-menu");
            if (rightAlign)
            {
                tb.AddCssClass("dropdown-menu-right");
            }
            tb.MergeAttribute("role", "menu");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.ToString(TagRenderMode.StartTag));

            return SimpleContent.FromHtml("</ul>");
        }
    }
}
