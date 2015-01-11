using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridCol : AnyContentElement
    {
        private GridSize size;

        private GridSize offset;

        public GridCol(IBootstrapContext context)
            : base(context) 
        {
            // Nothing
        }

        #region Fluent

        public GridCol Size(GridSize size)
        {
            this.size = size;
            return this;
        }

        public GridCol Offset(GridSize offset)
        {
            this.offset = offset;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass(size.ToCssClass());
            tb.AddCssClass(offset.ToOffsetCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
