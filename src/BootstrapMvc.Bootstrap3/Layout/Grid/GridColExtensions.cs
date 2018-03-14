namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Grid;

    public static partial class GridColExtensions
    {
        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, GridSize value) where T : GridCol
        {
            target.Item.Offset = value;
            return target;
        }

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
    }
}
