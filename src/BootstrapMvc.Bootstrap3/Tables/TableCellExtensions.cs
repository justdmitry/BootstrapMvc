using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static class TableCellExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Color<T>(this IWriter2<T, AnyContent> target, TableRowCellColor color)
            where T: TableCell
        {
            target.Item.ColorValue = color;
            return target;
        }

        public static IWriter2<T, AnyContent> RowSpan<T>(this IWriter2<T, AnyContent> target, int value)
            where T : TableCell
        {
            target.Item.AddAttribute("rowspan", value.ToString());
            return target;
        }

        public static IWriter2<T, AnyContent> ColSpan<T>(this IWriter2<T, AnyContent> target, int value)
            where T : TableCell
        {
            target.Item.AddAttribute("colspan", value.ToString());
            return target;
        }

        #endregion

        #region Generating

        public static IWriter2<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableCell, AnyContent>();
        }

        public static IWriter2<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, object value)
        {
            return TableCell(contentHelper).Content(value);
        }

        public static IWriter2<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            return TableCell(contentHelper).Content(values);
        }

        public static IWriter2<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, TableRowCellColor color, object value)
        {
            return TableCell(contentHelper, value).Color(color);
        }

        public static IWriter2<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, TableRowCellColor color, params object[] values)
        {
            return TableCell(contentHelper, values).Color(color);
        }

        public static AnyContent BeginTableCell(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableCell, AnyContent>().BeginContent();
        }

        public static AnyContent BeginTableCell(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return contentHelper.Context.CreateWriter<TableCell, AnyContent>().BeginContent();
        }

        public static IWriter2<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableHeaderCell, AnyContent>();
        }

        public static IWriter2<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, object value)
        {
            return TableHeaderCell(contentHelper).Content(value);
        }

        public static IWriter2<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            return TableHeaderCell(contentHelper).Content(values);
        }

        public static IWriter2<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color, object value)
        {
            return TableHeaderCell(contentHelper, value).Color(color);
        }

        public static IWriter2<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color, params object[] values)
        {
            return TableHeaderCell(contentHelper, values).Color(color);
        }

        public static AnyContent BeginTableHeaderCell(this IAnyContentMarker contentHelper)
        {
            return TableHeaderCell(contentHelper).BeginContent();
        }

        public static AnyContent BeginTableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return TableHeaderCell(contentHelper).Color(color).BeginContent();
        }

        #endregion
    }
}
