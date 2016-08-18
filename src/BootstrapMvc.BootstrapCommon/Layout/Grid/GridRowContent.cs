namespace BootstrapMvc.Grid
{
    using System;
    using BootstrapMvc.Core;

    public partial class GridRowContent : DisposableContent
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

        public AnyContent BeginCol(GridSize size)
        {
            return Col(size).BeginContent();
        }
    }
}
