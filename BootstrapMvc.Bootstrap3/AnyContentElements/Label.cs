using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Label : AnyContentElement
    {
        public Label(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public LabelType TypeValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("span");
            tb.AddCssClass(TypeValue.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
