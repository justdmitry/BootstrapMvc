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

        protected override GridRowContent CreateContentContext()
        {
            return new GridRowContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("row");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</div>");
        }
    }
}
