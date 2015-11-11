namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class GridColExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, GridSize value) where T : GridCol
        {
            target.Item.Offset = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) where T : GridCol
        {
            target.Item.Offset = new GridSize(xs, sm, md, lg, xl);
            return target;
        }

        public static IItemWriter<T, AnyContent> Push<T>(this IItemWriter<T, AnyContent> target, GridSize value) where T : GridCol
        {
            target.Item.Push = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Push<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) where T : GridCol
        {
            target.Item.Push = new GridSize(xs, sm, md, lg, xl);
            return target;
        }

        public static IItemWriter<T, AnyContent> Pull<T>(this IItemWriter<T, AnyContent> target, GridSize value) where T : GridCol
        {
            target.Item.Pull = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Pull<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) where T : GridCol
        {
            target.Item.Pull = new GridSize(xs, sm, md, lg, xl);
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(size);
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(new GridSize(xs, sm, md, lg, xl));
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return GridCol(contentHelper, size).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size, GridSize offset)
        {
            return GridCol(contentHelper, size).Offset(offset).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return GridCol(contentHelper, xs, sm, md, lg, xl).BeginContent();
        }

        #endregion
    }
}
