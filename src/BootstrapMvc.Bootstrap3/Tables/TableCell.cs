using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableCell : AnyContentElement
    {
        public TableRowCellColor ColorValue { get; set; } = TableRowCellColor.DefaultNone;

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("td");
            if (ColorValue != TableRowCellColor.DefaultNone)
            {
                tb.AddCssClass(ColorValue.ToCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
