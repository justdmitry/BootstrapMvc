using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridCol : AnyContentElement, IGridSizable
    {
        public GridCol(IBootstrapContext context)
            : base(context) 
        {
            // Nothing
        }

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

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass(SizeValue.ToCssClass());
            tb.AddCssClass(OffsetValue.ToOffsetCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
