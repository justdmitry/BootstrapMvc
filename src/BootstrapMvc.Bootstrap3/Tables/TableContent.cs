using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableContent : DisposableContent
    {
        public TableContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        #region Sections

        public IWriter2<TableCaption, AnyContent> Caption(object value)
        {
            return Context.CreateWriter<TableCaption, AnyContent>().Content(value);
        }

        public IWriter2<TableCaption, AnyContent> Caption(params object[] values)
        {
            return Context.CreateWriter<TableCaption, AnyContent>().Content(values);
        }

        public AnyContent BeginCaption()
        {
            return Context.CreateWriter<TableCaption, AnyContent>().BeginContent();
        }

        public IWriter2<TableHeader, TableSectionContent> Header()
        {
            return Context.CreateWriter<TableHeader, TableSectionContent>();
        }

        public TableSectionContent BeginHeader()
        {
            return Header().BeginContent();
        }

        public IWriter2<TableBody, TableSectionContent> Body()
        {
            return Context.CreateWriter<TableBody, TableSectionContent>();
        }

        public TableSectionContent BeginBody()
        {
            return Body().BeginContent();
        }
        
        public IWriter2<TableFooter, TableSectionContent> Footer()
        {
            return Context.CreateWriter<TableFooter, TableSectionContent>();
        }

        public TableSectionContent BeginFooter()
        {
            return Footer().BeginContent();
        }

        #endregion

        #region Rows

        public IWriter2<TableRow, TableRowContent> Row()
        {
            return Context.CreateWriter<TableRow, TableRowContent>();
        }

        public IWriter2<TableRow, TableRowContent> Row(TableRowCellColor color)
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

        public IWriter2<TableCell, AnyContent> Cell(object value)
        {
            return Context.CreateWriter<TableCell, AnyContent>().Content(value);
        }

        public IWriter2<TableCell, AnyContent> Cell(params object[] values)
        {
            return Context.CreateWriter<TableCell, AnyContent>().Content(values);
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
            return Cell(color).BeginContent();
        }

        public IWriter2<TableCell, AnyContent> TD(object value)
        {
            return Cell(value);
        }

        public IWriter2<TableCell, AnyContent> TD(params object[] values)
        {
            return Cell(values);
        }

        public IWriter2<TableCell, AnyContent> TD(TableRowCellColor color, object value)
        {
            return Cell(color, value);
        }

        public IWriter2<TableCell, AnyContent> TD(TableRowCellColor color, params object[] values)
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

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell(object value)
        {
            return Context.CreateWriter<TableHeaderCell, AnyContent>().Content(value);
        }

        public IWriter2<TableHeaderCell, AnyContent> HeaderCell(params object[] values)
        {
            return Context.CreateWriter<TableHeaderCell, AnyContent>().Content(values);
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
            return HeaderCell(color).BeginContent();
        }

        public IWriter2<TableHeaderCell, AnyContent> TH(object value)
        {
            return HeaderCell(value);
        }

        public IWriter2<TableHeaderCell, AnyContent> TH(params object[] values)
        {
            return HeaderCell(values);
        }

        public IWriter2<TableHeaderCell, AnyContent> TH(TableRowCellColor color, object value)
        {
            return HeaderCell(color, value);
        }

        public IWriter2<TableHeaderCell, AnyContent> TH(TableRowCellColor color, params object[] values)
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
