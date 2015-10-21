namespace BootstrapMvc.Panels
{
    using BootstrapMvc.Core;

    public class PanelFooter : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("panel-footer");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
