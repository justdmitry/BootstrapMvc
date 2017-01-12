namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Label : AnyContentElement
    {
        public LabelType Type { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("span");
            tb.AddCssClass(Type.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
