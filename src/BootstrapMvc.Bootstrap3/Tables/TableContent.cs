using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableContent : DisposableContent
    {
        public TableContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public TableCaption Caption(object value)
        {
            var obj = new TableCaption(Context);
            obj.Content(value);
            return obj;
        }

        public TableCaption Caption(params object[] values)
        {
            var obj = new TableCaption(Context);
            obj.Content(values);
            return obj;
        }

        public AnyContent BeginCaption()
        {
            return new TableCaption(Context).BeginContent();
        }

        public TableHeader Header()
        {
            return new TableHeader(Context);
        }

        public TableSectionContent BeginHeader()
        {
            return new TableHeader(Context).BeginContent();
        }

        public TableBody Body()
        {
            return new TableBody(Context);
        }
        
        public TableSectionContent BeginBody()
        {
            return new TableBody(Context).BeginContent();
        }
        
        public TableFooter Footer()
        {
            return new TableFooter(Context);
        }

        public TableSectionContent BeginFooter()
        {
            return new TableFooter(Context).BeginContent();
        }

        public TableRow Row()
        {
            return new TableRow(Context);
        }

        public TableRow Row(TableRowCellColor color)
        {
            return new TableRow(Context).Color(color);
        }

        public TableRowContent BeginRow()
        {
            return new TableRow(Context).BeginContent();
        }

        public TableRowContent BeginRow(TableRowCellColor color)
        {
            return new TableRow(Context).Color(color).BeginContent();
        }

        #region Table cells

        public TableCell TD(object value)
        {
            var obj = new TableCell(Context);
            obj.Content(value);
            return obj;
        }

        public TableCell TD(params object[] values)
        {
            var obj = new TableCell(Context);
            obj.Content(values);
            return obj;
        }

        public TableCell TD(TableRowCellColor color, object value)
        {
            return TD(value).Color(color);
        }

        public TableCell TD(TableRowCellColor color, params object[] values)
        {
            return TD(values).Color(color);
        }

        public AnyContent BeginTD()
        {
            return new TableCell(Context).BeginContent();
        }

        public AnyContent BeginTD(TableRowCellColor color)
        {
            return new TableCell(Context).Color(color).BeginContent();
        }

        public TableHeaderCell TH(object value)
        {
            var obj = new TableHeaderCell(Context);
            obj.Content(value);
            return obj;
        }

        public TableHeaderCell TH(params object[] values)
        {
            var obj = new TableHeaderCell(Context);
            obj.Content(values);
            return obj;
        }

        public TableHeaderCell TH(TableRowCellColor color, object value)
        {
            return TH(value).Color(color);
        }

        public TableHeaderCell TH(TableRowCellColor color, params object[] values)
        {
            return TH(values).Color(color);
        }

        public AnyContent BeginTH()
        {
            return new TableHeaderCell(Context).BeginContent();
        }

        public AnyContent BeginTH(TableRowCellColor color)
        {
            return new TableHeaderCell(Context).Color(color).BeginContent();
        }

        #endregion        
    }
}
