namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Grid;

    public static partial class GridColExtensions
    {
        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg) where T : GridCol
        {
            target.Item.Offset = new GridSize(xs, sm, md, lg);
            return target;
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(new GridSize(xs, sm, md, lg));
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return GridCol(contentHelper, xs, sm, md, lg).BeginContent();
        }
    }
}
