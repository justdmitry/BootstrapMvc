using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridRow : ContentElement<GridRowContent>
    {
        public GridRow(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override GridRowContent CreateContent()
        {
            return new GridRowContent(Context);
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
