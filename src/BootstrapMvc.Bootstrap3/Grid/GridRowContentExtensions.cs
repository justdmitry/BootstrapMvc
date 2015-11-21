namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class GridRowContentExtensions
    {
        public static IItemWriter<GridCol, AnyContent> Col(this GridRowContent target, byte xs, byte sm, byte md, byte lg)
        {
            return target.Col(new GridSize(xs, sm, md, lg));
        }

        public static AnyContent BeginCol(this GridRowContent target, byte xs, byte sm, byte md, byte lg)
        {
            return target.BeginCol(new GridSize(xs, sm, md, lg));
        }
    }
}
