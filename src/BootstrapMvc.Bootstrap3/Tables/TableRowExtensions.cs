using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static class TableRowExtensions
    {
        #region Fluent

        public static IWriter2<T, TableRowContent> Color<T>(this IWriter2<T, TableRowContent> target, TableRowCellColor color)
            where T : TableRow
        {
            target.Item.ColorValue = color;
            return target;
        }

        public static IWriter2<T, TableRowContent> Cells<T>(this IWriter2<T, TableRowContent> target, object value)
            where T : TableRow
        {
            var tcw = value as IWriter2<TableCell, AnyContent>;
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

            tc = new TableCell();
            tc.AddContent(value);
            target.Item.AddCell(tc);
            return target;
        }

        public static IWriter2<T, TableRowContent> Cells<T>(this IWriter2<T, TableRowContent> target, params object[] values)
            where T : TableRow
        {
            foreach (var value in values)
            {
                Cells(target, value);
            }
            return target;
        }

        public static IWriter2<T, TableRowContent> HeaderCells<T>(this IWriter2<T, TableRowContent> target, object value)
            where T : TableRow
        {
            var tcw = value as IWriter2<TableHeaderCell, AnyContent>;
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

            tc = new TableHeaderCell();
            tc.AddContent(value);
            target.Item.AddCell(tc);
            return target;
        }

        public static IWriter2<T, TableRowContent> HeaderCells<T>(this IWriter2<T, TableRowContent> target, params object[] values)
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

        public static IWriter2<TableRow, TableRowContent> TableRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableRow, TableRowContent>();
        }

        public static IWriter2<TableRow, TableRowContent> TableRow(this IAnyContentMarker contentHelper, TableRowCellColor color)
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
