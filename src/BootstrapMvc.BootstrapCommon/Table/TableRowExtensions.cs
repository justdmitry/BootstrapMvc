namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class TableRowExtensions
    {
        #region Fluent

        public static IItemWriter<T, TableRowContent> Color<T>(this IItemWriter<T, TableRowContent> target, TableRowCellColor color)
            where T : TableRow
        {
            target.Item.Color = color;
            return target;
        }

        public static IItemWriter<T, TableRowContent> Cells<T>(this IItemWriter<T, TableRowContent> target, object value)
            where T : TableRow
        {
            var tcw = value as IItemWriter<TableCell, AnyContent>;
            if (tcw != null)
            {
                target.Item.AddCell(tcw.Item);
                return target;
            }

            var tc = value as TableCell;
            if (tc != null)
            {
                target.Item.AddCell(tc);
                return target;
            }

            target.Item.AddCell(target.Helper.CreateWriter<TableCell, AnyContent>(target.Item).Content(value).Item);
            return target;
        }

        public static IItemWriter<T, TableRowContent> Cells<T>(this IItemWriter<T, TableRowContent> target, params object[] values)
            where T : TableRow
        {
            foreach (var value in values)
            {
                Cells(target, value);
            }
            return target;
        }

        public static IItemWriter<T, TableRowContent> HeaderCells<T>(this IItemWriter<T, TableRowContent> target, object value)
            where T : TableRow
        {
            var tcw = value as IItemWriter<TableHeaderCell, AnyContent>;
            if (tcw != null)
            {
                target.Item.AddCell(tcw.Item);
                return target;
            }

            var tc = value as TableHeaderCell;
            if (tc != null)
            {
                target.Item.AddCell(tc);
                return target;
            }

            target.Item.AddCell(target.Helper.CreateWriter<TableHeaderCell, AnyContent>(target.Item).Content(value).Item);
            return target;
        }

        public static IItemWriter<T, TableRowContent> HeaderCells<T>(this IItemWriter<T, TableRowContent> target, params object[] values)
            where T : TableRow
        {
            foreach (var value in values)
            {
                HeaderCells(target, value);
            }
            return target;
        }

        #endregion

        #region Generating

        public static IItemWriter<TableRow, TableRowContent> TableRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableRow, TableRowContent>();
        }

        public static IItemWriter<TableRow, TableRowContent> TableRow(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return TableRow(contentHelper).Color(color);
        }

        public static TableRowContent BeginTableRow(this IAnyContentMarker contentHelper)
        {
            return TableRow(contentHelper).BeginContent();
        }

        public static TableRowContent BeginTableRow(this IAnyContentMarker contentHelper, TableRowCellColor color)
        {
            return TableRow(contentHelper).Color(color).BeginContent();
        }

        #endregion
    }
}
