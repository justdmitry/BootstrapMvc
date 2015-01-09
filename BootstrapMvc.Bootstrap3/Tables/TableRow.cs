using System;
using System.Linq;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableRow : ContentElement<TableRowContent>
    {
        private TableRowCellColor color = TableRowCellColor.DefaultNone;
        private WritableBlock[] cells;

        public TableRow(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public TableRow Color(TableRowCellColor color)
        {
            this.color = color;
            return this;
        }

        public TableRow Cells(params object[] cells)
        {
            this.cells = cells.Select(val => val is TableCell ? (WritableBlock)val : new TableCell(Context).Content(val)).ToArray();
            return this;
        }

        public TableRow HeaderCells(params object[] cells)
        {
            this.cells = cells.Select(val => val is TableCell ? (WritableBlock)val : new TableHeaderCell(Context).Content(val)).ToArray();
            return this;
        }

        #endregion

        protected override TableRowContent CreateContent()
        {
            return new TableRowContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("tr");
            if (color != TableRowCellColor.DefaultNone)
            {
                tb.AddCssClass(color.ToCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (cells != null)
            {
                foreach (var cell in cells)
                {
                    cell.WriteTo(writer);
                }
            }

            return new Content(Context).Value(tb.GetEndTag(), true).WriteWhitespaceSuffix(false);
        }
    }
}
