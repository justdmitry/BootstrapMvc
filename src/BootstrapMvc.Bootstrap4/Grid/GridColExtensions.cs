namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Grid;

    public static partial class GridColExtensions
    {
        [Obsolete("Use method with 'xl' param")]
        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg) where T : GridCol
        {
            return Offset(target, xs, sm, md, lg, lg);
        }

        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) where T : GridCol
        {
            target.Item.Offset = new GridSize(xs, sm, md, lg, xl);
            return target;
        }

        [Obsolete("Use method with 'xl' param")]
        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return GridCol(contentHelper, xs, sm, md, lg, lg);
        }

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return contentHelper.CreateWriter<GridCol, AnyContent>().Size(new GridSize(xs, sm, md, lg, xl));
        }

        [Obsolete("Use method with 'xl' param")]
        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return BeginGridCol(contentHelper, xs, sm, md, lg, lg);
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return GridCol(contentHelper, xs, sm, md, lg, xl).BeginContent();
        }
    }
}
