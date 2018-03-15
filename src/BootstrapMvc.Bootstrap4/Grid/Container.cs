namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Container : AnyContentElement
    {
        public bool Fluid { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass(Fluid ? "container-fluid" : "container");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
