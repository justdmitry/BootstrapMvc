namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Badge : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("span");
            tb.AddCssClass("badge");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
