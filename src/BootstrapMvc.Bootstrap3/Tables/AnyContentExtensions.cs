using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region Table

        public static Table Table(this IAnyContentMarker contentHelper)
        {
            return new Table(contentHelper.Context);
        }

        public static Table Table(this IAnyContentMarker contentHelper, TableStyles styles)
        {
            return new Table(contentHelper.Context).Style(styles);
        }

        public static TableContent BeginTable(this IAnyContentMarker contentHelper)
        {
            return Table(contentHelper).BeginContent();
        }

        public static TableContent BeginTable(this IAnyContentMarker contentHelper, TableStyles styles)
        {
            return Table(contentHelper, styles).BeginContent();
        }

        #endregion

        #region Table sections

        public static TableCaption TableCaption(this IAnyContentMarker contentHelper, object value)
        {
            return new TableCaption(contentHelper.Context).Content(value);
        }

        public static TableCaption TableCaption(this IAnyContentMarker contentHelper, params object[] values)
        {
            return new TableCaption(contentHelper.Context).Content(values);
        }
        
        public static TableHeader TableHeader(this IAnyContentMarker contentHelper)
        {
            return new TableHeader(contentHelper.Context);
        }

        public static TableSectionContent BeginTableHeader(this IAnyContentMarker contentHelper)
        {
            return new TableHeader(contentHelper.Context).BeginContent();
        }

        public static TableBody TableBody(this IAnyContentMarker contentHelper)
        {
            return new TableBody(contentHelper.Context);
        }

        public static TableSectionContent BeginTableBody(this IAnyContentMarker contentHelper)
        {
            return new TableBody(contentHelper.Context).BeginContent();
        }

        public static TableFooter TableFooter(this IAnyContentMarker contentHelper)
        {
            return new TableFooter(contentHelper.Context);
        }

        public static TableSectionContent BeginTableFooter(this IAnyContentMarker contentHelper)
        {
            return new TableFooter(contentHelper.Context).BeginContent();
        }
       
        #endregion

        #region TableRow

        public static TableRow TableRow(this IAnyContentMarker contentHelper)
        {
            return new TableRow(contentHelper.Context);
        }

        public static TableRow TableRow(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return new TableRow(contentHelper.Context).Color(color);
        }

        public static TableRowContent BeginTableRow(this IAnyContentMarker contentHelper)
        {
            return new TableRow(contentHelper.Context).BeginContent();
        }

        public static TableRowContent BeginTableRow(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return new TableRow(contentHelper.Context).Color(color).BeginContent();
        }

        #endregion

        #region Table cells

        public static TableCell TableCell(this IAnyContentMarker contentHelper, object value)
        {
            return new TableCell(contentHelper.Context).Content(value);
        }

        public static TableCell TableCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            return new TableCell(contentHelper.Context).Content(values);
        }

        public static TableCell TableCell(this IAnyContentMarker contentHelper, TableRowCellColor color, object value)
        {
            return TableCell(contentHelper, value).Color(color);
        }

        public static TableCell TableCell(this IAnyContentMarker contentHelper, TableRowCellColor color, params object[] values)
        {
            return TableCell(contentHelper, values).Color(color);
        }

        public static AnyContent BeginTableCell(this IAnyContentMarker contentHelper)
        {
            return new TableCell(contentHelper.Context).BeginContent();
        }

        public static AnyContent BeginTableCell(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return new TableCell(contentHelper.Context).Color(color).BeginContent();
        }

        public static TableHeaderCell TableHeaderCell(this IAnyContentMarker contentHelper, object value)
        {
            return new TableHeaderCell(contentHelper.Context).Content(value);
        }

        public static TableHeaderCell TableHeaderCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            return new TableHeaderCell(contentHelper.Context).Content(values);
        }

        public static TableHeaderCell TableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color, object value)
        {
            return TableHeaderCell(contentHelper, value).Color(color);
        }

        public static TableHeaderCell TableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color, params object[] values)
        {
            return TableHeaderCell(contentHelper, values).Color(color);
        }

        public static AnyContent BeginTableHeaderCell(this IAnyContentMarker contentHelper)
        {
            return new TableHeaderCell(contentHelper.Context).BeginContent();
        }

        public static AnyContent BeginTableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return new TableHeaderCell(contentHelper.Context).Color(color).BeginContent();
        }

        #endregion
    }
}
