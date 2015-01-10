using System.Web.Mvc;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class DropdownMenuItemLink : AnyContentElement, IDropdownMenuItem, ILink<DropdownMenuItemLink>
    {
        private string href = "#";

        private bool disabled = false;

        public DropdownMenuItemLink(BootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public DropdownMenuItemLink Href(string value)
        {
            this.href = value;
            return this;
        }

        public DropdownMenuItemLink Disabled(bool disabled = true)
        {
            this.disabled = disabled;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = new TagBuilder("li");
            tb.MergeAttribute("role", "presentation");
            if (disabled)
            {
                tb.AddCssClass("disabled");
            }

            writer.Write(tb.ToString(TagRenderMode.StartTag));

            var a = new TagBuilder("a");
            a.MergeAttribute("role", "menuitem");
            a.MergeAttribute("tabindex", "-1");
            a.MergeAttribute("href", disabled ? "#" : href);
            writer.Write(a.ToString(TagRenderMode.StartTag));

            return "</a></li>";
        }
    }
}
