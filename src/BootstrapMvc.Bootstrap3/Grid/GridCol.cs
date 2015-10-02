using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridCol : AnyContentElement, IGridSizable
    {
        public GridSize SizeValue { get; set; }

        public GridSize OffsetValue { get; set; }

        public void SetSize(GridSize value)
        {
            SizeValue = value;
        }

        public GridSize Size()
        {
            return SizeValue;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
            tb.AddCssClass(SizeValue.ToCssClass());
            tb.AddCssClass(OffsetValue.ToOffsetCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
