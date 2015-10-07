using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableSectionContent : DisposableContent
    {
        public TableSectionContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<TableRow, TableRowContent> Row()
        {
            return Context.CreateWriter<TableRow, TableRowContent>();
        }

        public IWriter2<TableRow, TableRowContent> Row(TableRowCellColor color)
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
