using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemLink : AnyContentElement, IDropdownMenuItem, ILink, IDisableable
    {
        public DropdownMenuItemLink(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public string HrefValue { get; set; }

        public bool DisabledValue { get; set; }

        void IDisableable.SetDisabled(bool disabled)
        {
            DisabledValue = disabled;
        }

        bool IDisableable.Disabled()
        {
            return DisabledValue;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("li");
            tb.MergeAttribute("role", "presentation");
            if (DisabledValue)
            {
                tb.AddCssClass("disabled");
            }

            writer.Write(tb.GetStartTag());

            var a = Context.CreateTagBuilder("a");
            a.MergeAttribute("role", "menuitem");
            a.MergeAttribute("tabindex", "-1");
            a.MergeAttribute("href", DisabledValue ? "#" : HrefValue);
            writer.Write(a.GetStartTag());

            return "</a></li>";
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
