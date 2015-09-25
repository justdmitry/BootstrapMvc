using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelBody : AnyContentElement
    {
        public PanelBody(IBootstrapContext context)
            : base(context)
        {
            // nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("panel-body");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
