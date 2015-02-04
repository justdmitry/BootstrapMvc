using System;
using BootstrapMvc.Core;
using BootstrapMvc.Grid;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region GridRow

        public static GridRow GridRow(this IAnyContentMarker contentHelper)
        {
            return new GridRow(contentHelper.Context);
        }

        public static GridRowContent BeginGridRow(this IAnyContentMarker contentHelper)
        {
            return GridRow(contentHelper).BeginContent();
        }

        #endregion

        #region GridCol

        public static GridCol GridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return new GridCol(contentHelper.Context).Size(size);
        }

        public static GridCol GridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return new GridCol(contentHelper.Context).Size(new GridSize(xs, sm, md, lg));
        }

        public static AnyContentContext BeginGridCol(this IAnyContentMarker contentHelper, GridSize size)
        {
            return GridCol(contentHelper, size).BeginContent();
        }

        public static AnyContentContext BeginGridCol(this IAnyContentMarker contentHelper, GridSize size, GridSize offset)
        {
            return GridCol(contentHelper, size).Offset(offset).BeginContent();
        }

        public static AnyContentContext BeginGridCol(this IAnyContentMarker contentHelper, byte xs, byte sm, byte md, byte lg)
        {
            return GridCol(contentHelper, xs, sm, md, lg).BeginContent();
        }
        
        #endregion
    }
}
