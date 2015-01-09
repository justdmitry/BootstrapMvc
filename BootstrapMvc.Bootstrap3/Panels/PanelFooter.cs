using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelFooter : AnyContentElement
    {
        public PanelFooter(IBootstrapContext context)
            : base(context)
        {
            // nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("panel-footer");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
