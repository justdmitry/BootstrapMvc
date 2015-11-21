namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class GridColExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Offset<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) 
            where T : GridCol
        {
            return target.Offset(new GridSize(xs, sm, md, lg, xl));
        }

        public static IItemWriter<T, AnyContent> Push<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) 
            where T : GridCol
        {
            return target.Push(new GridSize(xs, sm, md, lg, xl));
        }

        public static IItemWriter<T, AnyContent> Pull<T>(this IItemWriter<T, AnyContent> target, byte xs, byte sm, byte md, byte lg, byte xl) 
            where T : GridCol
        {
            return target.Pull(new GridSize(xs, sm, md, lg, xl));
        }

        #endregion

        #region Generation

        public static IItemWriter<GridCol, AnyContent> GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return contentHelper.GridCol(new GridSize(xs, sm, md, lg, xl));
        }

        public static AnyContent BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return contentHelper.BeginGridCol(new GridSize(xs, sm, md, lg, xl));
        }

        #endregion
    }
}
