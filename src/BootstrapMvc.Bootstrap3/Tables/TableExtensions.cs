using System;
using BootstrapMvc.Core;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static class TableExtensions
    {
        #region Fluent

        public static IWriter2<T, TableContent> Style<T>(this IWriter2<T, TableContent> target, TableStyles styles)
            where T: Table
        {
            target.Item.StyleValue = styles;
            return target;
        }

        public static IWriter2<T, TableContent> Caption<T>(this IWriter2<T, TableContent> target, TableCaption value)
            where T : Table
        {
            target.Item.CaptionValue = value;
            return target;
        }

        public static IWriter2<T, TableContent> Caption<T>(this IWriter2<T, TableContent> target, object value)
            where T : Table
        {
            var tc = new TableCaption();
            tc.AddContent(value);
            target.Item.CaptionValue = tc;
            return target;
        }

        public static IWriter2<T, TableContent> Caption<T>(this IWriter2<T, TableContent> target, params object[] values)
            where T : Table
        {
            var tc = new TableCaption();
            tc.AddContent(values);
            target.Item.CaptionValue = tc;
            return target;
        }

        public static IWriter2<T, TableContent> Header<T>(this IWriter2<T, TableContent> target, TableHeader value)
            where T : Table
        {
            target.Item.HeaderValue = value;
            return target;
        }

        public static IWriter2<T, TableContent> Footer<T>(this IWriter2<T, TableContent> target, TableFooter value)
            where T : Table
        {
            target.Item.FooterValue = value;
            return target;
        }

        #endregion

        #region Generating

        public static IWriter2<Table, TableContent> Table(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Table, TableContent>();
        }

        public static IWriter2<Table, TableContent> Table(this IAnyContentMarker contentHelper, TableStyles styles)
        {
            return Table(contentHelper);//.Style(styles);
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
