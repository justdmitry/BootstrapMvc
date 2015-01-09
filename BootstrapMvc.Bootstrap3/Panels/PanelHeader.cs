using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelHeader : AnyContentElement
    {
        public PanelHeader(IBootstrapContext context)
            : base(context)
        {
            // nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("panel-heading");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
