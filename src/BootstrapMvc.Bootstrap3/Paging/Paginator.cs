using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Paging
{
    public class Paginator : ContentElement<PaginatorContent>
    {
        public PaginatorSize SizeValue { get; set; }

        protected override PaginatorContent CreateContentContext(IBootstrapContext context)
        {
            return new PaginatorContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("<nav>");

            var tb = context.CreateTagBuilder("ul");
            tb.AddCssClass("pagination");
            tb.AddCssClass(SizeValue.ToCssClass());

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</ul></nav>");
        }
    }
}
