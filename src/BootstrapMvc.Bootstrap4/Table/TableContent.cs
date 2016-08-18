namespace BootstrapMvc.Tables
{
    using System;
    using BootstrapMvc.Core;

    public partial class TableContent
    {
        public IItemWriter<TableHeader, TableSectionContent> Header(TableHeaderStyle style)
        {
            return Context.Helper.CreateWriter<TableHeader, TableSectionContent>(Parent).Style(style);
        }

        public TableSectionContent BeginHeader(TableHeaderStyle style)
        {
            return Header(style).BeginContent();
        }
    }
}
