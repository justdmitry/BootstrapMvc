using System.Collections.Generic;
using BootstrapMvc.Core;

namespace BootstrapMvc.Paging
{
    public class Paginator : ContentElement<PaginatorContent>
    {
        public Paginator(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public PaginatorSize SizeValue { get; set; }

        protected override PaginatorContent CreateContentContext()
        {
            return new PaginatorContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            writer.Write("<nav>");

            var tb = Context.CreateTagBuilder("ul");
            tb.AddCssClass("pagination");
            tb.AddCssClass(SizeValue.ToCssClass());

            writer.Write(tb.GetStartTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</ul></nav>");
        }
    }
}
