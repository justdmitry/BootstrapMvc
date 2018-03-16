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

        public IItemWriter<GridCol, AnyContent> Col()
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent);
        }

        public IItemWriter<GridCol, AnyContent> Col(params object[] content)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Content(content);
        }

        public IItemWriter<GridCol, AnyContent> Col(GridSize size)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(size);
        }

        public IItemWriter<GridCol, AnyContent> Col(byte xs, byte sm, byte md, byte lg, byte xl)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(xs, sm, md, lg, xl);
        }

        public IItemWriter<GridCol, AnyContent> Col(GridSize size, params object[] content)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Content(content)
                .Size(size);
        }

        public IItemWriter<GridCol, AnyContent> Col(byte size)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Size(new GridSize(size));
        }

        public IItemWriter<GridCol, AnyContent> Col(byte size, params object[] content)
        {
            return Context.Helper.CreateWriter<GridCol, AnyContent>(Parent)
                .Content(content)
                .Size(new GridSize(size));
        }

        public AnyContent BeginCol(GridSize size)
        {
            return Col(size).BeginContent();
        }
    }
}
