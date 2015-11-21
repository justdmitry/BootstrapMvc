namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class GridCol : AnyContentElement, IGridSizable
    {
        public GridSize Size { get; set; }

        public GridSize Offset { get; set; }

        public GridSize Push { get; set; }

        public GridSize Pull { get; set; }

        void IGridSizable.SetSize(GridSize value)
        {
            Size = value;
        }

        GridSize IGridSizable.GetSize()
        {
            return Size;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass(Size.ToCssClass());
            tb.AddCssClass(Offset.ToOffsetCssClass());
            tb.AddCssClass(Push.ToPushCssClass());
            tb.AddCssClass(Pull.ToPullCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
