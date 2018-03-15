namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public class GridCol : AnyContentElement, IGridSizable
    {
        public VerticalAlignment Align { get; set; }

        public GridSize Size { get; set; }

        public GridSize Offset { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("col");
            tb.AddCssClass(Size.ToCssClass());
            tb.AddCssClass(Offset.ToOffsetCssClass());

            switch (Align)
            {
                case VerticalAlignment.Start:
                    tb.AddCssClass("align-self-start");
                    break;
                case VerticalAlignment.Center:
                    tb.AddCssClass("align-self-center");
                    break;
                case VerticalAlignment.End:
                    tb.AddCssClass("align-self-end");
                    break;
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
