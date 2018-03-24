namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public class GridRow : ContentElement<GridRowContent>
    {
        public VerticalAlignment VerticalAlignment { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }

        public bool NoGutters { get; set; }

        protected string ClassName { get; set; } = "row";

        protected override GridRowContent CreateContentContext(IBootstrapContext context)
        {
            return new GridRowContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass(ClassName);

            if (NoGutters)
            {
                tb.AddCssClass("no-gutters");
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Start:
                    tb.AddCssClass("align-items-start");
                    break;
                case VerticalAlignment.Center:
                    tb.AddCssClass("align-items-center");
                    break;
                case VerticalAlignment.End:
                    tb.AddCssClass("align-items-end");
                    break;
            }

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Start:
                    tb.AddCssClass("justify-content-start");
                    break;
                case HorizontalAlignment.Center:
                    tb.AddCssClass("justify-content-center");
                    break;
                case HorizontalAlignment.End:
                    tb.AddCssClass("justify-content-end");
                    break;
                case HorizontalAlignment.Around:
                    tb.AddCssClass("justify-content-around");
                    break;
                case HorizontalAlignment.Between:
                    tb.AddCssClass("justify-content-between");
                    break;
            }

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
