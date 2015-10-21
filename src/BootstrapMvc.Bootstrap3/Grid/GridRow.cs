namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public class GridRow : ContentElement<GridRowContent>
    {
        protected override GridRowContent CreateContentContext(IBootstrapContext context)
        {
            return new GridRowContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("row");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</div>");
        }
    }
}
