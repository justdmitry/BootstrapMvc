namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public partial class GridRowContent : DisposableContent
    {
        [Obsolete("Use method with 'xl' param")]
        public IItemWriter<GridCol, AnyContent> Col(byte xs, byte sm, byte md, byte lg)
        {
            return Col(xs, sm, md, lg, lg);
        }

        public IItemWriter<GridCol, AnyContent> Col(byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(new GridSize(xs, sm, md, lg, xl));
        }

        [Obsolete("Use method with 'xl' param")]
        public AnyContent BeginCol(byte xs, byte sm, byte md, byte lg)
        {
            return BeginCol(xs, sm, md, lg, lg);
        }

        public AnyContent BeginCol(byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return Col(xs, sm, md, lg, xl).BeginContent();
        }
    }
}
