using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class Table : ContentElement<TableContent>
    {
        public TableStyles StyleValue { get; set; } = TableStyles.Default;

        public TableCaption CaptionValue { get; set; }

        public TableHeader HeaderValue { get; set; }

        public TableFooter FooterValue { get; set; }

        protected override TableContent CreateContentContext(IBootstrapContext context)
        {
            return new TableContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("table");
            tb.AddCssClass(StyleValue.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (CaptionValue != null)
            {
                CaptionValue.WriteTo(writer, context);
            }
            if (HeaderValue != null)
            {
                HeaderValue.WriteTo(writer, context);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            if (FooterValue != null)
            {
                FooterValue.WriteTo(writer, context);
            }
            writer.Write("</table>");
        }
    }
}
