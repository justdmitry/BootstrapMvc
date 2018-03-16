namespace BootstrapMvc.Tables
{
    using System;
    using BootstrapMvc.Core;

    public partial class TableContent : DisposableContent
    {
        public TableContent(IBootstrapContext context, Table parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private Table Parent { get; set; }

        #region Sections

        public IItemWriter<TableCaption, AnyContent> Caption(params object[] content)
        {
            return Context.Helper.CreateWriter<TableCaption, AnyContent>(Parent).Content(content);
        }

        public AnyContent BeginCaption()
        {
            return Caption().BeginContent();
        }

        public IItemWriter<TableHeader, TableSectionContent> Header()
        {
            return Context.Helper.CreateWriter<TableHeader, TableSectionContent>(Parent);
        }

        public IItemWriter<TableHeader, TableSectionContent> Header(TableHeaderColor color)
        {
            return Context.Helper.CreateWriter<TableHeader, TableSectionContent>(Parent).Color(color);
        }

        public TableSectionContent BeginHeader()
        {
            return Header().BeginContent();
        }

        public TableSectionContent BeginHeader(TableHeaderColor color)
        {
            return Header(color).BeginContent();
        }

        public IItemWriter<TableBody, TableSectionContent> Body()
        {
            return Context.Helper.CreateWriter<TableBody, TableSectionContent>(Parent);
        }

        public TableSectionContent BeginBody()
        {
            return Body().BeginContent();
        }

        public IItemWriter<TableFooter, TableSectionContent> Footer()
        {
            return Context.Helper.CreateWriter<TableFooter, TableSectionContent>(Parent);
        }

        public TableSectionContent BeginFooter()
        {
            return Footer().BeginContent();
        }

        #endregion

        #region Rows

        public IItemWriter<TableRow, TableRowContent> Row()
        {
            return Context.Helper.CreateWriter<TableRow, TableRowContent>(Parent);
        }

        public IItemWriter<TableRow, TableRowContent> Row(TableRowCellColor color)
        {
            return Row().Color(color);
        }

        public TableRowContent BeginRow()
        {
            return Row().BeginContent();
        }

        public TableRowContent BeginRow(TableRowCellColor color)
        {
            return Row(color).BeginContent();
        }

        #endregion

        #region Table 'regular' cells and TD synonym


        public IItemWriter<TableCell, AnyContent> Cell(params object[] values)
        {
            return Context.Helper.CreateWriter<TableCell, AnyContent>(Parent).Content(values);
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
            return Cell(color).BeginContent();
        }

        public IItemWriter<TableCell, AnyContent> TD(params object[] values)
        {
            return Cell(values);
        }

        public IItemWriter<TableCell, AnyContent> TD(TableRowCellColor color, params object[] values)
        {
            return Cell(color, values);
        }

        public AnyContent BeginTD()
        {
            return Cell().BeginContent();
        }

        public AnyContent BeginTD(TableRowCellColor color)
        {
            return Cell(color).BeginContent();
        }

        #endregion

        #region Table 'header' cells and TH synonym

        public IItemWriter<TableHeaderCell, AnyContent> HeaderCell(params object[] values)
        {
            return Context.Helper.CreateWriter<TableHeaderCell, AnyContent>(Parent).Content(values);
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
            return HeaderCell(color).BeginContent();
        }

        public IItemWriter<TableHeaderCell, AnyContent> TH(params object[] values)
        {
            return HeaderCell(values);
        }

        public IItemWriter<TableHeaderCell, AnyContent> TH(TableRowCellColor color, params object[] values)
        {
            return HeaderCell(color, values);
        }

        public AnyContent BeginTH()
        {
            return HeaderCell().BeginContent();
        }

        public AnyContent BeginTH(TableRowCellColor color)
        {
            return HeaderCell(color).BeginContent();
        }

        #endregion
    }
}
