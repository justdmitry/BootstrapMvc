using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableHeader : ContentElement<TableSectionContent>
    {
        private WritableBlock[] rows;

        public TableHeader(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public TableHeader Rows(params TableRow[] rows)
        {
            this.rows = rows;
            return this;
        }

        #endregion

        protected override TableSectionContent CreateContent()
        {
            return new TableSectionContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("thead");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (rows != null)
            {
                foreach (var row in rows)
                {
                    row.WriteTo(writer);
                }
            }

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
