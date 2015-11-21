namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

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

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("li");
            tb.MergeAttribute("role", "presentation", true);
            if (DisabledValue)
            {
                tb.AddCssClass("disabled");
            }

            tb.WriteStartTag(writer);

            var a = Helper.CreateTagBuilder("a");
            a.MergeAttribute("role", "menuitem", true);
            a.MergeAttribute("tabindex", "-1", true);
            a.MergeAttribute("href", DisabledValue ? "#" : HrefValue, true);

            a.WriteStartTag(writer);

            return "</a></li>";
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
