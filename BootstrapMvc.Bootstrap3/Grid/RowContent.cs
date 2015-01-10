using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class RowContent : DisposableContent
    {
        public RowContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public RowCol Col(GridSize size)
        {
            return new RowCol(Context).Size(size);
        }

        public RowCol Col(byte xs, byte sm, byte md, byte lg)
        {
            return new RowCol(Context).Size(new GridSize(xs, sm, md, lg));
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
