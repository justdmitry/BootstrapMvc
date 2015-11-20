namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Dropdown;

    public class Anchor : AnyContentElement, ILink, IDropdownMenuParentMarker
    {
        public string Href { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("a");
            tb.MergeAttribute("href", Href, true);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }

        void ILink.SetHref(string value)
        {
            Href = value;
        }
    }
}
