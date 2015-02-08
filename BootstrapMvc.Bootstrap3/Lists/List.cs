using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class List : ContentElement<ListContent>
    {
        private string endTag;

        public List(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public ListType TypeValue { get; set; }

        protected override ListContent CreateContentContext()
        {
            return new ListContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder(TypeValue == ListType.Ordered ? "ol" : "ul");

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

            writer.Write(tb.GetStartTag());

            endTag = tb.GetEndTag();
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
