namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public class GridRowContent : DisposableContent
    {
        public GridRowContent(IBootstrapContext context, GridRow parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private GridRow Parent { get; set; }

        public IItemWriter<GridCol, AnyContent> Col(GridSize size)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(size);
        }

        public IItemWriter<GridCol, AnyContent> Col(byte xs, byte sm, byte md, byte lg)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(new GridSize(xs, sm, md, lg));
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
