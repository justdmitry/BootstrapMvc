using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class List : ContentElement<ListContent>
    {
        private ListType type;

        public List(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public List Type(ListType type)
        {
            this.type = type;
            return this;
        }

        #endregion

        protected override ListContent CreateContent()
        {
            return new ListContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder(type == ListType.Ordered ? "ol" : "ul");

            if (type == ListType.Unstyled)
            {
                tb.AddCssClass("list-unstyled");
            }

            if (type == ListType.Inline)
            {
                tb.AddCssClass("list-inline");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
