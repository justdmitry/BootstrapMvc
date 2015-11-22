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
            var a = Helper.CreateTagBuilder("a");
            a.AddCssClass("dropdown-item");
            if (DisabledValue)
            {
                a.AddCssClass("disabled");
            }
            a.MergeAttribute("href", DisabledValue ? "#" : HrefValue, true);

            a.WriteStartTag(writer);

            return "</a>";
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
