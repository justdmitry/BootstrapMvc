using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class Table : ContentElement<TableContent>
    {
        private WritableBlock caption;
        private WritableBlock header;
        private WritableBlock footer;

        private TableStyles styles = TableStyles.Default;

        public Table(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Table Style(TableStyles styles)
        {
            this.styles = styles;
            return this;
        }

        public Table Caption(TableCaption value)
        {
            caption = value;
            return this;
        }

        public Table Caption(object value)
        {
            caption = new TableCaption(Context).Content(value);
            return this;
        }

        public Table Caption(params object[] values)
        {
            caption = new TableCaption(Context).Content(values);
            return this;
        }

        public Table Header(TableHeader value)
        {
            header = value;
            return this;
        }

        public Table Footer(TableFooter value)
        {
            footer = value;
            return this;
        }

        #endregion

        protected override TableContent CreateContentContext()
        {
            return new TableContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("table");
            tb.AddCssClass(styles.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (caption != null)
            {
                caption.WriteTo(writer);
            }
            if (header != null)
            {
                header.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            if (footer != null)
            {
                footer.WriteTo(writer);
            }
            writer.Write("</table>");
        }
    }
}
