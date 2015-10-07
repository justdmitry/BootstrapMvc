using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static class TableSectionExtensions
    {
        #region Fluent

        public static IWriter2<T, TableSectionContent> Rows<T>(
            this IWriter2<T, TableSectionContent> target, 
            TableRow row)
            where T : TableSection
        {
            target.Item.AddRow(row);
            return target;
        }

        public static IWriter2<T, TableSectionContent> Rows<T>(
            this IWriter2<T, TableSectionContent> target, 
            params IWriter2<TableRow, TableRowContent>[] rows)
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

        public static IWriter2<TableCaption, AnyContent> TableCaption(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.Context.CreateWriter<TableCaption, AnyContent>().Content(value);
        }

        public static IWriter2<TableCaption, AnyContent> TableCaption(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.Context.CreateWriter<TableCaption, AnyContent>().Content(values);
        }

        public static AnyContent BeginTableCaption(this IAnyContentMarker contentHelper)
        {
            return TableCaption(contentHelper).BeginContent();
        }

        public static IWriter2<TableHeader, TableSectionContent> TableHeader(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableHeader, TableSectionContent>();
        }

        public static TableSectionContent BeginTableHeader(this IAnyContentMarker contentHelper)
        {
            return TableHeader(contentHelper).BeginContent();
        }

        public static IWriter2<TableBody, TableSectionContent> TableBody(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableBody, TableSectionContent>();
        }

        public static TableSectionContent BeginTableBody(this IAnyContentMarker contentHelper)
        {
            return TableBody(contentHelper).BeginContent();
        }

        public static IWriter2<TableFooter, TableSectionContent> TableFooter(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<TableFooter, TableSectionContent>();
        }

        public static TableSectionContent BeginTableFooter(this IAnyContentMarker contentHelper)
        {
            return TableFooter(contentHelper).BeginContent();
        }

        #endregion
    }
}
