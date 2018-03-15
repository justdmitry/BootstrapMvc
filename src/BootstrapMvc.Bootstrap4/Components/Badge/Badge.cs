namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Badge : AnyContentElement, ILink, IColor8Type
    {
        public Color8 Type { get; set; }

        public string Href { get; set; }

        public bool Pill { get; set; }

        public bool WithWhitespacePrefix { get; set; } = true;

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var isLink = !string.IsNullOrEmpty(Href);

            var tb = Helper.CreateTagBuilder(isLink ? "a" : "span");
            tb.AddCssClass("badge");
            tb.AddCssClass("badge-" + Type.ToCssClassSubstring());

            if (Pill)
            {
                tb.AddCssClass("badge-pill");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            if (isLink)
            {
                tb.MergeAttribute("href", Href, true);
            }

            if (WithWhitespacePrefix)
            {
                writer.Write(" ");
            }

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }

        void ILink.SetHref(string value)
        {
            Href = value;
        }
    }
}
