using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemLink : AnyContentElement, IDropdownMenuItem, ILink<DropdownMenuItemLink>
    {
        private string href = "#";

        private bool disabled = false;

        public DropdownMenuItemLink(IBootstrapContext context)
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
            var tb = Context.CreateTagBuilder("li");
            tb.MergeAttribute("role", "presentation");
            if (disabled)
            {
                tb.AddCssClass("disabled");
            }

            writer.Write(tb.GetStartTag());

            var a = Context.CreateTagBuilder("a");
            a.MergeAttribute("role", "menuitem");
            a.MergeAttribute("tabindex", "-1");
            a.MergeAttribute("href", disabled ? "#" : href);
            writer.Write(a.GetStartTag());

            return "</a></li>";
        }
    }
}
