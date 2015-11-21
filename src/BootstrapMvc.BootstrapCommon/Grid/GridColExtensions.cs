namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class GridColExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, GridSize value) 
            where T : GridCol
        {
            target.Item.Offset = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Push<T>(this IItemWriter<T, AnyContent> target, GridSize value) 
            where T : GridCol
        {
            target.Item.Push = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Pull<T>(this IItemWriter<T, AnyContent> target, GridSize value) 
            where T : GridCol
        {
            target.Item.Pull = value;
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(size);
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return GridCol(contentHelper, size).BeginContent();
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, GridSize size, GridSize offset)
        {
            return GridCol(contentHelper, size).Offset(offset).BeginContent();
        }

        #endregion
    }
}
