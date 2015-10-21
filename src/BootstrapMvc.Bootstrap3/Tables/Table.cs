namespace BootstrapMvc.Tables
{
    using System;
    using BootstrapMvc.Core;

    public class Table : ContentElement<TableContent>
    {
        public TableStyles Style { get; set; } = TableStyles.Default;

        public TableCaption Caption { get; set; }

        public TableHeader Header { get; set; }

        public TableFooter Footer { get; set; }

        protected override TableContent CreateContentContext(IBootstrapContext context)
        {
            return new TableContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("table");
            tb.AddCssClass(Style.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Caption != null)
            {
                Caption.WriteTo(writer);
            }
            if (Header != null)
            {
                Header.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            if (Footer != null)
            {
                Footer.WriteTo(writer);
            }
            writer.Write("</table>");
        }
    }
}
