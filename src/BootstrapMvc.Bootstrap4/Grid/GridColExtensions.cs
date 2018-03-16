namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Grid;

    public static partial class GridColExtensions
    {
        public static IItemWriter<T, AnyContent> Align<T>(this IItemWriter<T, AnyContent> target, VerticalAlignment align)
            where T : GridCol
        {
            target.Item.Align = align;
            return target;
        }

        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, GridSize value)
            where T : GridCol
        {
            target.Item.Offset = value;
            return target;
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>();
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Content(content);
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(size);
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, GridSize size, params object[] content)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(size).Content(content);
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte size)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(new GridSize(size));
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(new GridSize(xs, sm, md, lg, xl));
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte size, params object[] content)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(new GridSize(size)).Content(content);
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper)
        {
            return GridCol(contentHelper).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return GridCol(contentHelper, size).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte size)
        {
            return GridCol(contentHelper, new GridSize(size)).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return GridCol(contentHelper, new GridSize(xs, sm, md, lg, xl)).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size, GridSize offset)
        {
            return GridCol(contentHelper, size).Offset(offset).BeginContent();
        }
    }
}
