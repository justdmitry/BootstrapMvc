namespace BootstrapMvc.ListGroups
{
    using BootstrapMvc.Core;

    public class OrdinaryListGroup : ContentElement<OrdinaryListGroupContent>
    {
        private string endTag;

        protected override OrdinaryListGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new OrdinaryListGroupContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("ul");

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
