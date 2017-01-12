namespace BootstrapMvc.ListGroups
{
    using BootstrapMvc.Core;

    public class ActionableListGroup : ContentElement<ActionableListGroupContent>
    {
        private string endTag;

        protected override ActionableListGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new ActionableListGroupContent(context, this);
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
