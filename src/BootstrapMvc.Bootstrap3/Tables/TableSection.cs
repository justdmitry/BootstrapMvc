using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public abstract class TableSection : ContentElement<TableSectionContent>
    {
        private WritableBlock content;

        protected abstract string GetTagName();

        public TableSection AddRow(TableRow value)
        {
            if (value == null)
            {
                return this;
            }
            if (content == null)
            {
                content = value;
            }
            else
            {
                content.Append(value);
            }
            return this;
        }

        protected override TableSectionContent CreateContentContext(IBootstrapContext context)
        {
            return new TableSectionContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder(GetTagName());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (content != null)
            {
                content.WriteTo(writer, context);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</");
            writer.Write(GetTagName());
            writer.Write(">");
        }
    }
}
