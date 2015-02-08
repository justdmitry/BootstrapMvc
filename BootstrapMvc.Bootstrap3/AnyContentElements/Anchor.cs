using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public class Anchor : AnyContentElement, ILink, IDropdownMenuParentMarker
    {
        public Anchor(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public string HrefValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("a");
            tb.MergeAttribute("href", HrefValue);

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
