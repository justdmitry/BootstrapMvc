using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public class Anchor : AnyContentElement, ILink, IDropdownMenuParentMarker
    {
        public string HrefValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("a");
            tb.MergeAttribute("href", HrefValue);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
