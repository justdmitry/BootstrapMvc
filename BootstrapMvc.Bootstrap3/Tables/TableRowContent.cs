using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableRowContent : DisposableContext
    {
        public TableRowContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }
        
        public TableCell Cell(object value)
        {
            var obj = new TableCell(Context);
            obj.Content(value);
            return obj;
        }

        public TableCell Cell(params object[] values)
        {
            var obj = new TableCell(Context);
            obj.Content(values);
            return obj;
        }

        public TableCell Cell(TableRowCellColor color, object value)
        {
            return Cell(value).Color(color);
        }

        public TableCell Cell(TableRowCellColor color, params object[] values)
        {
            return Cell(values).Color(color);
        }

        public AnyContentContext BeginCell()
        {
            return new TableCell(Context).BeginContent();
        }

        public AnyContentContext BeginCell(TableRowCellColor color)
        {
            return new TableCell(Context).Color(color).BeginContent();
        }

        public TableHeaderCell HeaderCell(object value)
        {
            var obj = new TableHeaderCell(Context);
            obj.Content(value);
            return obj;
        }

        public TableHeaderCell HeaderCell(params object[] values)
        {
            var obj = new TableHeaderCell(Context);
            obj.Content(values);
            return obj;
        }

        public TableHeaderCell HeaderCell(TableRowCellColor color, object value)
        {
            return HeaderCell(value).Color(color);
        }

        public TableHeaderCell HeaderCell(TableRowCellColor color, params object[] values)
        {
            return HeaderCell(values).Color(color);
        }

        public AnyContentContext BeginHeaderCell()
        {
            return new TableHeaderCell(Context).BeginContent();
        }

        public AnyContentContext BeginHeaderCell(TableRowCellColor color)
        {
            return new TableHeaderCell(Context).Color(color).BeginContent();
        }
    }
}
