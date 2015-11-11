namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Clearfix : Element
    {
        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("clearfix");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteFullTag(writer);
        }
    }
}
