using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableSectionContent : DisposableContent
    {
        public TableSectionContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public TableRow Row()
        {
            return new TableRow(Context);
        }

        public TableRow Row(TableRowCellColor color)
        {
            return new TableRow(Context).Color(color);
        }

        public TableRowContent BeginRow()
        {
            return new TableRow(Context).BeginContent();
        }

        public TableRowContent BeginRow(TableRowCellColor color)
        {
            return new TableRow(Context).Color(color).BeginContent();
        }
    }
}
