using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridRow : ContentElement<GridRowContent>
    {
        protected override GridRowContent CreateContentContext(IBootstrapContext context)
        {
            return new GridRowContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
            tb.AddCssClass("row");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</div>");
        }
    }
}
