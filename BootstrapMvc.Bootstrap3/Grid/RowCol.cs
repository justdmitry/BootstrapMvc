using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class RowCol : AnyContentElement
    {
        private GridSize size;

        private GridSize offset;

        public RowCol(IBootstrapContext context)
            : base(context) 
        {
            // Nothing
        }

        #region Fluent

        public RowCol Size(GridSize size)
        {
            this.size = size;
            return this;
        }

        public RowCol Offset(GridSize offset)
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
