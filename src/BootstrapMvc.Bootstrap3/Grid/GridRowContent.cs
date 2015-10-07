using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Grid
{
    public class GridRowContent : DisposableContent
    {
        public GridRowContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<GridCol, AnyContent> Col(GridSize size)
        {
            return Context.CreateWriter<GridCol, AnyContent>().Size(size);
        }

        public IWriter2<GridCol, AnyContent> Col(byte xs, byte sm, byte md, byte lg)
        {
            return Context.CreateWriter<GridCol, AnyContent>().Size(new GridSize(xs, sm, md, lg));
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
