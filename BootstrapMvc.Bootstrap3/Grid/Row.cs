using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class Row : ContentElement<RowContent>
    {
        public Row(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override RowContent CreateContent()
        {
            throw new NotImplementedException();
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("row");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
