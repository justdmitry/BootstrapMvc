using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemLink : AnyContentElement, IDropdownMenuItem, ILink, IDisableable
    {
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

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("li");
            tb.MergeAttribute("role", "presentation");
            if (DisabledValue)
            {
                tb.AddCssClass("disabled");
            }

            tb.WriteStartTag(writer);

            var a = context.CreateTagBuilder("a");
            a.MergeAttribute("role", "menuitem");
            a.MergeAttribute("tabindex", "-1");
            a.MergeAttribute("href", DisabledValue ? "#" : HrefValue);

            a.WriteStartTag(writer);

            return "</a></li>";
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
