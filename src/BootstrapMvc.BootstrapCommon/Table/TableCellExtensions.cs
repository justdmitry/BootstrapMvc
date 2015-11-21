namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class TableCellExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Color<T>(this IItemWriter<T, AnyContent> target, TableRowCellColor color)
            where T: TableCell
        {
            target.Item.Color = color;
            return target;
        }

        public static IItemWriter<T, AnyContent> RowSpan<T>(this IItemWriter<T, AnyContent> target, int value)
            where T : TableCell
        {
            target.Item.AddAttribute("rowspan", value.ToString());
            return target;
        }

        public static IItemWriter<T, AnyContent> ColSpan<T>(this IItemWriter<T, AnyContent> target, int value)
            where T : TableCell
        {
            target.Item.AddAttribute("colspan", value.ToString());
            return target;
        }

        #endregion

        #region Generating

        public static IItemWriter<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableCell, AnyContent>();
        }

        public static IItemWriter<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, object value)
        {
            return TableCell(contentHelper).Content(value);
        }

        public static IItemWriter<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            return TableCell(contentHelper).Content(values);
        }

        public static IItemWriter<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, TableRowCellColor color, object value)
        {
            return TableCell(contentHelper, value).Color(color);
        }

        public static IItemWriter<TableCell, AnyContent> TableCell(this IAnyContentMarker contentHelper, TableRowCellColor color, params object[] values)
        {
            return TableCell(contentHelper, values).Color(color);
        }

        public static AnyContent BeginTableCell(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableCell, AnyContent>().BeginContent();
        }

        public static AnyContent BeginTableCell(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return contentHelper.CreateWriter<TableCell, AnyContent>().BeginContent();
        }

        public static IItemWriter<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableHeaderCell, AnyContent>();
        }

        public static IItemWriter<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, object value)
        {
            return TableHeaderCell(contentHelper).Content(value);
        }

        public static IItemWriter<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, params object[] values)
        {
            return TableHeaderCell(contentHelper).Content(values);
        }

        public static IItemWriter<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color, object value)
        {
            return TableHeaderCell(contentHelper, value).Color(color);
        }

        public static IItemWriter<TableHeaderCell, AnyContent> TableHeaderCell(this IAnyContentMarker contentHelper, TableRowCellColor color, params object[] values)
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
