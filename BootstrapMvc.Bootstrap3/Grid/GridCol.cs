using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridCol : AnyContentElement
    {
        public GridCol(IBootstrapContext context)
            : base(context) 
        {
            // Nothing
        }

        public GridSize SizeValue { get; set; }

        public GridSize OffsetValue { get; set; }

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
