namespace BootstrapMvc.Tables
{
    using System;
    using BootstrapMvc.Core;

    public class TableRowContent : DisposableContent
    {
        public TableRowContent(IBootstrapContext context, TableRow parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private TableRow Parent { get; set; }

        public IItemWriter<TableCell, AnyContent> Cell()
        {
            return Context.Helper.CreateWriter<TableCell, AnyContent>(Parent);
        }

        public IItemWriter<TableCell, AnyContent> Cell(object value)
        {
            return Cell().Content(value);
        }

        public IItemWriter<TableCell, AnyContent> Cell(params object[] values)
        {
            return Cell().Content(values);
        }

        public IItemWriter<TableCell, AnyContent> Cell(TableRowCellColor color, object value)
        {
            return Cell(value).Color(color);
        }

        public IItemWriter<TableCell, AnyContent> Cell(TableRowCellColor color, params object[] values)
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

        public IItemWriter<TableHeaderCell, AnyContent> HeaderCell()
        {
            return Context.Helper.CreateWriter<TableHeaderCell, AnyContent>(Parent);
        }

        public IItemWriter<TableHeaderCell, AnyContent> HeaderCell(object value)
        {
            return HeaderCell().Content(value);
        }

        public IItemWriter<TableHeaderCell, AnyContent> HeaderCell(params object[] values)
        {
            return HeaderCell().Content(values);
        }

        public IItemWriter<TableHeaderCell, AnyContent> HeaderCell(TableRowCellColor color, object value)
        {
            return HeaderCell(value).Color(color);
        }

        public IItemWriter<TableHeaderCell, AnyContent> HeaderCell(TableRowCellColor color, params object[] values)
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
