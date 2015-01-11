using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridRowContent : DisposableContent
    {
        public GridRowContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public GridCol Col(GridSize size)
        {
            return new GridCol(Context).Size(size);
        }

        public GridCol Col(byte xs, byte sm, byte md, byte lg)
        {
            return new GridCol(Context).Size(new GridSize(xs, sm, md, lg));
        }

        public AnyContent BeginCol(GridSize size)
        {
            return Col(size).BeginContent();
        }

        public AnyContent BeginCol(byte xs, byte sm, byte md, byte lg)
        {
            return Col(xs, sm, md, lg).BeginContent();
        }
    }
}
