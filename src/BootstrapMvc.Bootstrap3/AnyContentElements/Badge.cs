using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Badge : AnyContentElement
    {
        public Badge(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("span");
            tb.AddCssClass("badge");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
