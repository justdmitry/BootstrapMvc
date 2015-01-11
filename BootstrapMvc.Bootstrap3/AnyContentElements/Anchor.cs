using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public class Anchor : AnyContentElement, ILink<Anchor>, IDropdownMenuParentMarker
    {
        private string href = string.Empty;

        public Anchor(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public Anchor Href(string value)
        {
            this.href = value;
            return this;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("a");
            tb.MergeAttribute("href", href);

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
