using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuItemLink : AnyContentElement, IDropdownMenuItem, ILink, IDisableable
    {
        public string Href { get; set; }

        public bool Disabled { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var a = Helper.CreateTagBuilder("a");
            a.AddCssClass("dropdown-item");
            if (Disabled)
            {
                a.AddCssClass("disabled");
            }

            a.MergeAttribute("href", Disabled ? "#" : Href, true);

            a.WriteStartTag(writer);

            return "</a>";
        }
    }
}
