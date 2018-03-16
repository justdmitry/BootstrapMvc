namespace BootstrapMvc.Tables
{
    using System;
    using System.Collections.Generic;
    using BootstrapMvc.Core;

    public abstract class TableSection : ContentElement<TableSectionContent>
    {
        private List<TableRow> rows;

        protected abstract string GetTagName();

        public void AddRow(TableRow value)
        {
            if (value == null)
            {
                return;
            }
            if (rows == null)
            {
                rows = new List<TableRow>();
            }
            rows.Add(value);
        }

        protected override TableSectionContent CreateContentContext(IBootstrapContext context)
        {
            return new TableSectionContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder(GetTagName());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (rows != null)
            {
                foreach (var row in rows)
                {
                    row.Parent = this;
                    row.WriteTo(writer);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</");
            writer.Write(GetTagName());
            writer.Write(">");
        }
    }
}
