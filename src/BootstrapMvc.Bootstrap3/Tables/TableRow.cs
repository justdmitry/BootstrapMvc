namespace BootstrapMvc.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BootstrapMvc.Core;

    public class TableRow : ContentElement<TableRowContent>
    {
        private List<TableCell> cells;

        public TableRowCellColor Color { get; set; } = TableRowCellColor.DefaultNone;

        public void AddCell(TableCell value)
        {
            if (value == null)
            {
                return;
            }
            if (cells == null)
            {
                cells = new List<TableCell>();
            }
            cells.Add(value);
        }

        protected override TableRowContent CreateContentContext(IBootstrapContext context)
        {
            return new TableRowContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("tr");
            if (Color != TableRowCellColor.DefaultNone)
            {
                tb.AddCssClass(Color.ToCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (cells != null)
            {
                foreach(var cell in cells)
                {
                    cell.WriteTo(writer);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</tr>");
        }
    }
}
