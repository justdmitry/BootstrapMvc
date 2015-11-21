namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class TableSectionContent : DisposableContent
    {
        public TableSectionContent(IBootstrapContext context, TableSection parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private TableSection Parent { get; set; }

        public IItemWriter<TableRow, TableRowContent> Row()
        {
            return Context.Helper.CreateWriter<TableRow, TableRowContent>(Parent);
        }

        public IItemWriter<TableRow, TableRowContent> Row(TableRowCellColor color)
        {
            return Row().Color(color);
        }

        public TableRowContent BeginRow()
        {
            return Row().BeginContent();
        }

        public TableRowContent BeginRow(TableRowCellColor color)
        {
            return Row().Color(color).BeginContent();
        }
    }
}
