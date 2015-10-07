using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableRowContent : DisposableContent
    {
        public TableRowContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<TableCell, AnyContent> Cell()
        {
            return Context.CreateWriter<TableCell, AnyContent>();
        }

        public IWriter2<TableCell, AnyContent> Cell(object value)
        {
            return Cell().Content(value);
        }

        public IWriter2<TableCell, AnyContent> Cell(params object[] values)
        {
            return Cell().Content(values);
        }

        public IWriter2<TableCell, AnyContent> Cell(TableRowCellColor color, object value)
        {
            return Cell(value).Color(color);
        }

        public IWriter2<TableCell, AnyContent> Cell(TableRowCellColor color, params object[] values)
        {
            return Cell(values).Color(color);
        }

        public AnyContent BeginCell()
        {
            return Cell().BeginContent();
        }

        public AnyContent BeginCell(TableRowCellColor color)
        {
            return Cell().Color(color).BeginContent();
        }

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell()
        {
            return Context.CreateWriter<TableHeaderCell, AnyContent>();
        }

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell(object value)
        {
            return HeaderCell().Content(value);
        }

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell(params object[] values)
        {
            return HeaderCell().Content(values);
        }

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell(TableRowCellColor color, object value)
        {
            return HeaderCell(value).Color(color);
        }

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell(TableRowCellColor color, params object[] values)
        {
            return HeaderCell(values).Color(color);
        }

        public AnyContent BeginHeaderCell()
        {
            return HeaderCell().BeginContent();
        }

        public AnyContent BeginHeaderCell(TableRowCellColor color)
        {
            return HeaderCell().Color(color).BeginContent();
        }
    }
}
