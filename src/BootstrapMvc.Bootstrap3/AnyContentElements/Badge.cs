using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Badge : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("span");
            tb.AddCssClass("badge");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
