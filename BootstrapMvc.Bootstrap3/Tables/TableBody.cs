using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableBody : ContentElement<TableSectionContent>
    {
        private WritableBlock[] rows;

        public TableBody(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public TableBody Rows(params TableRow[] rows)
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
            var tb = Context.CreateTagBuilder("tbody");

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
