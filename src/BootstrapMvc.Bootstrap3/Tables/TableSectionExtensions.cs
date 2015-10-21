using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static class TableSectionExtensions
    {
        #region Fluent

        public static IItemWriter<T, TableSectionContent> Rows<T>(
            this IItemWriter<T, TableSectionContent> target, 
            TableRow row)
            where T : TableSection
        {
            target.Item.AddRow(row);
            return target;
        }

        public static IItemWriter<T, TableSectionContent> Rows<T>(
            this IItemWriter<T, TableSectionContent> target, 
            params IItemWriter<TableRow, TableRowContent>[] rows)
            where T : TableSection
        {
            foreach (var row in rows)
            {
                target.Item.AddRow(row.Item);
            }
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<TableCaption, AnyContent> TableCaption(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.CreateWriter<TableCaption, AnyContent>().Content(value);
        }

        public static IItemWriter<TableCaption, AnyContent> TableCaption(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.CreateWriter<TableCaption, AnyContent>().Content(values);
        }

        public static AnyContent BeginTableCaption(this IAnyContentMarker contentHelper)
        {
            return TableCaption(contentHelper).BeginContent();
        }

        public static IItemWriter<TableHeader, TableSectionContent> TableHeader(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableHeader, TableSectionContent>();
        }

        public static TableSectionContent BeginTableHeader(this IAnyContentMarker contentHelper)
        {
            return TableHeader(contentHelper).BeginContent();
        }

        public static IItemWriter<TableBody, TableSectionContent> TableBody(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableBody, TableSectionContent>();
        }

        public static TableSectionContent BeginTableBody(this IAnyContentMarker contentHelper)
        {
            return TableBody(contentHelper).BeginContent();
        }

        public static IItemWriter<TableFooter, TableSectionContent> TableFooter(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<TableFooter, TableSectionContent>();
        }

        public static TableSectionContent BeginTableFooter(this IAnyContentMarker contentHelper)
        {
            return TableFooter(contentHelper).BeginContent();
        }

        #endregion
    }
}
