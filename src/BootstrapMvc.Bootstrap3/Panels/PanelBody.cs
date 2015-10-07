using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelBody : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
            tb.AddCssClass("panel-body");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
