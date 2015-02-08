using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableCell : AnyContentElement
    {
        private TableRowCellColor color = TableRowCellColor.DefaultNone;

        public TableCell(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public TableCell Color(TableRowCellColor color)
        {
            this.color = color;
            return this;
        }

        public TableCell RowSpan(int value)
        {
            this.AddAttribute("rowspan", value.ToString());
            return this;
        }

        public TableCell ColSpan(int value)
        {
            this.AddAttribute("colspan", value.ToString());
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("td");
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
