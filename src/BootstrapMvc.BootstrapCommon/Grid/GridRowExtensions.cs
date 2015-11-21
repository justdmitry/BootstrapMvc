namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class GridRowExtensions
    {
        #region Generation

        public static IItemWriter<GridRow, GridRowContent> GridRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<GridRow, GridRowContent>();
        }

        public static GridRowContent BeginGridRow(this IAnyContentMarker contentHelper)
        {
            return GridRow(contentHelper).BeginContent();
        }

        #endregion
    }
}
