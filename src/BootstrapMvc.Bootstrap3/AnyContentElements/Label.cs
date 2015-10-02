using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Label : AnyContentElement
    {
        public LabelType TypeValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("span");
            tb.AddCssClass(TypeValue.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
