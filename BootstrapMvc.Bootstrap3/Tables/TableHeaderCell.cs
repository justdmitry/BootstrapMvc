using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableHeaderCell : TableCell
    {
        private TableRowCellColor color = TableRowCellColor.DefaultNone;

        public TableHeaderCell(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public new TableHeaderCell Color(TableRowCellColor color)
        {
            this.color = color;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("th");
            if (color != TableRowCellColor.DefaultNone)
            {
                tb.AddCssClass(color.ToCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
