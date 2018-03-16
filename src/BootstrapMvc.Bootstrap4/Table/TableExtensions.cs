namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Tables;

    public static class TableExtensions
    {
        public static IItemWriter<T, TableContent> Style<T>(this IItemWriter<T, TableContent> target, TableStyles styles)
            where T: Table
        {
            target.Item.Style = styles;
            return target;
        }

        public static IItemWriter<T, TableContent> Responsive<T>(this IItemWriter<T, TableContent> target, TableResponsive value)
            where T : Table
        {
            target.Item.Responsive = value;
            return target;
        }

        public static IItemWriter<T, TableContent> Caption<T>(this IItemWriter<T, TableContent> target, params object[] values)
            where T : Table
        {
            target.Item.Caption = target.Helper.CreateWriter<TableCaption, AnyContent>(target.Item).Content(values).Item;
            return target;
        }

        public static IItemWriter<T, TableContent> Header<T>(this IItemWriter<T, TableContent> target, TableHeader value)
            where T : Table
        {
            target.Item.Header = value;
            return target;
        }

        public static IItemWriter<T, TableContent> Footer<T>(this IItemWriter<T, TableContent> target, TableFooter value)
            where T : Table
        {
            target.Item.Footer = value;
            return target;
        }

        #region Generating

        public static IItemWriter<Table, TableContent> Table(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Table, TableContent>();
        }

        public static IItemWriter<Table, TableContent> Table(this IAnyContentMarker contentHelper, TableStyles styles)
        {
            return Table(contentHelper).Style(styles);
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
    }
}
