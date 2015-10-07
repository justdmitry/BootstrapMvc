using System;
using BootstrapMvc.Core;
using BootstrapMvc.Grid;

namespace BootstrapMvc
{
    public static class GridRowExtensions
    {
        #region Generation

        public static IWriter2<GridRow, GridRowContent> GridRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<GridRow, GridRowContent>();
        }

        public static GridRowContent BeginGridRow(this IAnyContentMarker contentHelper)
        {
            return GridRow(contentHelper).BeginContent();
        }

        #endregion
    }
}
