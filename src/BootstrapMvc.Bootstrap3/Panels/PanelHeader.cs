using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelHeader : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
            tb.AddCssClass("panel-heading");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
