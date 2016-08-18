namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Grid;

    public static class GridRowExtensions
    {
        public static IItemWriter<GridRow, GridRowContent> GridRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<GridRow, GridRowContent>();
        }

        public static GridRowContent BeginGridRow(this IAnyContentMarker contentHelper)
        {
            return GridRow(contentHelper).BeginContent();
        }
    }
}
