namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class List : ContentElement<ListContent>
    {
        private string endTag;

        public ListType Type { get; set; }

        protected override ListContent CreateContentContext(IBootstrapContext context)
        {
            return new ListContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder(Type == ListType.Ordered ? "ol" : "ul");

            if (Type == ListType.Unstyled)
            {
                tb.AddCssClass("list-unstyled");
            }

            if (Type == ListType.Inline)
            {
                tb.AddCssClass("list-inline");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            endTag = tb.GetEndTag();
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
