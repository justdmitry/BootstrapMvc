namespace BootstrapMvc.Lists
{
    using BootstrapMvc.Core;

    public class LinksListGroup : ContentElement<LinksListGroupContent>
    {
        private string endTag;

        protected override LinksListGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new LinksListGroupContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");

            tb.AddCssClass("list-group");
            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            endTag = tb.GetEndTag();
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
