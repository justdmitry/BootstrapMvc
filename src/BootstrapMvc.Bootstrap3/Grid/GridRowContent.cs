namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public partial class GridRowContent : DisposableContent
    {
        public IItemWriter<GridCol, AnyContent> Col(byte xs, byte sm, byte md, byte lg)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(new GridSize(xs, sm, md, lg));
        }

        public AnyContent BeginCol(byte xs, byte sm, byte md, byte lg)
        {
            return Col(xs, sm, md, lg).BeginContent();
        }
    }
}
