using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class List : ContentElement<ListContent>
    {
        private string endTag;

        public ListType TypeValue { get; set; }

        protected override ListContent CreateContentContext(IBootstrapContext context)
        {
            return new ListContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder(TypeValue == ListType.Ordered ? "ol" : "ul");

            if (TypeValue == ListType.Unstyled)
            {
                tb.AddCssClass("list-unstyled");
            }

            if (TypeValue == ListType.Inline)
            {
                tb.AddCssClass("list-inline");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            endTag = tb.GetEndTag();
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write(endTag);
        }
    }
}
