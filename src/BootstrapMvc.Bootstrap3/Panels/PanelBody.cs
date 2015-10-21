namespace BootstrapMvc.Panels
{
    using BootstrapMvc.Core;

    public class PanelBody : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("panel-body");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
