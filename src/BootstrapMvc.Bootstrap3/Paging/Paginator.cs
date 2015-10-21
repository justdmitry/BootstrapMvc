namespace BootstrapMvc.Paging
{
    using System;
    using BootstrapMvc.Core;

    public class Paginator : ContentElement<PaginatorContent>
    {
        public PaginatorSize Size { get; set; }

        protected override PaginatorContent CreateContentContext(IBootstrapContext context)
        {
            return new PaginatorContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            writer.Write("<nav>");

            var tb = Helper.CreateTagBuilder("ul");
            tb.AddCssClass("pagination");
            tb.AddCssClass(Size.ToCssClass());

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</ul></nav>");
        }
    }
}
