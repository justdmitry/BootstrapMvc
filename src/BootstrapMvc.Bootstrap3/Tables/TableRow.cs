using System;
using System.Linq;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableRow : ContentElement<TableRowContent>
    {
        private WritableBlock content;

        public TableRowCellColor ColorValue { get; set; } = TableRowCellColor.DefaultNone;

        public TableRow AddCell(TableCell value)
        {
            if (value == null)
            {
                return this;
            }
            if (content == null)
            {
                content = value;
            }
            else
            {
                content.Append(value);
            }
            return this;
        }

        protected override TableRowContent CreateContentContext(IBootstrapContext context)
        {
            return new TableRowContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("tr");
            if (ColorValue != TableRowCellColor.DefaultNone)
            {
                tb.AddCssClass(ColorValue.ToCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (content != null)
            {
                content.WriteTo(writer, context);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</tr>");
        }
    }
}
