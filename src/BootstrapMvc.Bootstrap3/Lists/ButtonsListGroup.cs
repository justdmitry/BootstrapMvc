namespace BootstrapMvc.Lists
{
    using BootstrapMvc.Core;

    public class ButtonsListGroup : ContentElement<ButtonsListGroupContent>
    {
        private string endTag;

        protected override ButtonsListGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new ButtonsListGroupContent(context, this);
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
