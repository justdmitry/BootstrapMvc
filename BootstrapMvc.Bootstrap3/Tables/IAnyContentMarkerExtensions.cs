using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
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
            var obj = new TableCaption(contentHelper.Context);
            obj.Content(value);
            return obj;
        }

        public static TableCaption TableCaption(this IAnyContentMarker contentHelper, params object[] values)
        {
            var obj = new TableCaption(contentHelper.Context);
            obj.Content(values);
            return obj;
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

        #endregion

        #region Table cells

        public static TableCell TableCell(this IAnyContentMarker contentHelper, object value)
        {
            var obj = new TableCell(contentHelper.Context);
            obj.Content(value);
            return obj;
        }

        public static TableCell TableCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            var obj = new TableCell(contentHelper.Context);
            obj.Content(values);
            return obj;
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
            var obj = new TableHeaderCell(contentHelper.Context);
            obj.Content(value);
            return obj;
        }

        public static TableHeaderCell TableHeaderCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            var obj = new TableHeaderCell(contentHelper.Context);
            obj.Content(values);
            return obj;
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
