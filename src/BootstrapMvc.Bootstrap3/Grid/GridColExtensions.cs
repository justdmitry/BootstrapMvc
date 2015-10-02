using System;
using BootstrapMvc.Core;
using BootstrapMvc.Grid;

namespace BootstrapMvc
{
    public static class GridColExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Offset<T>(this IWriter2<T, AnyContent> target, GridSize value) where T : GridCol
        {
            target.Item.OffsetValue = value;
            return target;
        }

        public static IWriter2<T, AnyContent> Offset<T>(this IWriter2<T, AnyContent> target, byte xs, byte sm, byte md, byte lg) where T : GridCol
        {
            target.Item.OffsetValue = new GridSize(xs, sm, md, lg);
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return contentHelper.Context.CreateWriter<GridCol, AnyContent>().Size(size);
        }

        public static IWriter2<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return contentHelper.Context.CreateWriter<GridCol, AnyContent>().Size(new GridSize(xs, sm, md, lg));
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return GridCol(contentHelper, size).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size, GridSize offset)
        {
            return GridCol(contentHelper, size).Offset(offset).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return GridCol(contentHelper, xs, sm, md, lg).BeginContent();
        }

        #endregion
    }
}
